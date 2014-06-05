(function() {
    window.DyscalculiaGame = SSGame.extend({
        bodySize: null,
        state: null,
        currentItem: null,
        nextItemIndex: 0,
        coins: [],
        interval: null,
        selectedItem: null,
        timer: null,
        success: null,
        key: null,
        spinner: null,
        init: function() {
            this._super('DyscalculiaGame', null);
            this.lib = DyscalculiaGameLib;
        },
        draw: function() {
            this._super({
                store: 'dyscalculia_store',
                timer: 'SSGame_timer',
                key: 'dyscalculia_key',
                score: 'dyscalculia_score',
                counter: 'dyscalculia_counter',
                itemContainer: 'dyscalculia_item',
                coins: 'dyscalculia_coins',
                selectedCoins: 'dyscalculia_coins_selected',
                tally: 'dyscalculia_tally'
            });
            this.nodes.key.append($('<h2>Key</h2>'));
            this.nodes.counter.append($('<h2>Coin Tray</h2>'));
            this.nodes.counter.append(this.nodes.tally);
            this.spinner = DyscalculiaSpinner(this.nodes.tally);
            this.nodes.store.append(this.nodes.itemContainer);
            this.nodes.counter.append(this.nodes.selectedCoins);
        },
        loadSounds: function() {
            var root = '/Presentation/includes/audio/simulations/dyscalculia/effects/';
            this._super({
                coinClick: [
                    root + 'Dyscalculia_CoinFlip1',
                    root + 'Dyscalculia_CoinFlip2',
                    root + 'Dyscalculia_CoinFlip3'
                ],
                correct: root + 'Dyscalculia_CorrectPayment',
                incorrect: root + 'Dyscalculia_InvalidAmount',
                newItem: root + 'Dyscalculia_CounterReset'
            });
        },
        setupElements: function() {
            //Build our coin data
            var gameVals = [], coinVals = [], key, i, val;
            for(key in this.config.coins) {
                gameVals.push(this.lib.randomizer.coin(this.config.coins[key]));
            }
            for(key in gameVals) {
                val = gameVals[key];
                for(i = 0; i < val.count; i ++) {
                    coinVals.push(val);
                }
            }
            SSGame.shuffle(coinVals);
            var coinObj, coinDim, coinPos, coinStats = [],
                ctrStats = { width: this.nodes.coins.width(), height: this.nodes.coins.height() };
            var coinCfgRoot = SSGame.current.board.getCurrentBreakpoint()[2] == 'phone' ? 'phone' : 'desktop';
            var coinCfg = SSGame.current.config.coinUI[coinCfgRoot];
            for(var i=0;i<coinVals.length;++i) {
                val = coinVals[i];
                coinObj = this.lib.coin(val.cls, val.value, $.proxy(this.coinClick, this));
                this.nodes.coins.append(coinObj.body);
                //Isolate the size of our coin
                coinDim = { width: coinObj.body.width(), height: coinObj.body.height() };
                //Figoure out a random position for the coin
                var layoutGrid = coinCfg.scatterGrid;
                coinPos = SSGame.getRandomPosition(coinDim, coinStats, ctrStats, i, layoutGrid[0], layoutGrid[1]);
                //Actually move the coin
                coinObj.setPosition(coinPos.left, coinPos.top, coinStats.length + 1);
                //Track our final stats for the next random placements
                coinDim.left = coinPos.left;
                coinDim.top = coinPos.top;
                coinStats.push(coinDim);
            }
            this.coins = gameVals;
            //Set up the key
            for(key in this.coins) {
                val = this.coins[key];
                c = this.lib.coin(val.cls, val.value, function(){});
                c.showValue();
                this.nodes.key.append(c.body);
            }
        },
        reset: function() {
            this._super();
            if(this.spinner) this.spinner.setValue(0);
            this.lib.randomizer.reset();
            this.started = false;
            this.nextItemIndex = 0;
            this.success.reset();
            this.timer.reset();
            this.nodes.coins.empty();
            if(this.key) this.key.remove();
            this.setupElements();
            var intro = new SSGameModal({
                showDuration: this.config.introDurationInSeconds * 1000,
                title: this.getText(this.config.title),
                text: SSGameModal.textToParagraphs(this.config.introText),
                onClose: $.proxy(this.start, this)
            });
            intro.setButtons([{
                text: 'Start',
                click: $.proxy(intro.close, intro)
            }]);
            intro.open();
        },
        start: function() {
            this.setState('needsItem');
            this.events.trigger('start');
        },
        stop: function() {
            var score = this.success.getScore();
            var scoreText = score.correct + '/' + score.max;
            if(score.correct < score.max) {
                this.playSound('gameOverFail');
            } else {
                this.playSound('gameOverSuccess');
            }
            var done = new SSGameModal({
                showDuration: 0,
                text: this.config.finalText.replace('%score', scoreText)
            });
            done.setButtons([{
                text: 'Go',
                click: function() {
                    window.location = window.location;
                }
            }]);
            done.open();
            this.events.trigger('stop');
        },
        run: function() {
            if(!this._super()) return;
            this.timer = new SSGameTimer({
                container: this.nodes.timer,
                maxTime: this.config.timeInSeconds
            });
            this.timer.onTick.add($.proxy(this.onTick, this));
            this.timer.onStop.add($.proxy(this.stop, this));
            this.success = new SSGameSuccess({
                numbers: true,
                node: this.nodes.score,
                count: this.config.items.length
            });
            this.addCheat(
                $('<button></button>')
                    .text('Next item')
                    .click($.proxy(function() {
                        this.success.increment();
                        this.setState('needsItem');
                    }, this))
            );
            this.reset();
        },
        setState: function(state) {
            this.state = state;
            $.proxy(this.states[this.state].start, this)();
        },
        payClick: function(e) {
            $.proxy(this.states[this.state].payClick, this)(e);
        },
        coinClick: function(item, e) {
            $.proxy(this.states[this.state].coinClick, this)(item, e);
        },
        getKey: function() {
        },
        onTick: function() {
            $.proxy(this.states[this.state].tick, this)();
        },
        states: {
            needsItem: {
                start: function() {
                    var go = $.proxy(function() {
                        var vals = this.lib.randomizer.item(this.config.items[this.nextItemIndex]);
                        if(!vals) {
                            this.timer.stop();
                        } else {
                            this.nextItemIndex ++;
                            this.currentItem = this.lib.item(vals.name, vals.cls, vals.value, $.proxy(this.payClick, this));
                            if(vals.showTally) {
                                this.spinner.setValue(0).enable();
                            } else {
                                this.spinner.scramble().disable();
                            }
                            this.spinner.setValue(0);
                            this.spinner.setInProgress();
                            if(!this.started) {
                                this.timer.start();
                                this.started = true;
                            }
                            this.setState('itemChosen');
                        }
                    }, this);
                    if(this.currentItem) {
                        console.log('Removing old item');
                        this.currentItem.remove(go);
                    } else {
                        console.log('Showing first item');
                        go();
                    }
                },
                payClick: function(e) {
                },
                coinClick: function(item, e) {
                },
                tick: function() {
                }
            },
            itemChosen: {
                start: function() {
                },
                getTotal: function() {
                    return SSGame.current.spinner.getValue();
                },
                payClick: function(e) {
                    console.log('click');
                    this.setState('sleep');
                    var coins = this.nodes.counter.find('coin');
                    var total = Math.round(this.states.itemChosen.getTotal() * 100);
                    console.log('%s total, %s val', total, this.currentItem.value);
                    if(total != this.currentItem.value) {
                        this.playSound('incorrect');
                        this.spinner.setWrong();
                        this.currentItem.showWrong();
                        setTimeout($.proxy(function() {
                            this.setState('itemChosen');
                        }, this), this.config.warningDisplayTimeInMilliseconds);
                    } else {
                        this.playSound('correct');
                        this.success.increment();
                        this.spinner.setRight();
                        this.currentItem.showCorrect();
                        this.lib.coinTools.setAllAvailable();
                        setTimeout($.proxy(function() {
                            coins.remove();
                            this.setState('needsItem');
                        }, this), this.config.warningDisplayTimeInMilliseconds);
                    }
                },
                coinClick: function(coin, e) {
                    var val = coin.getValue();
                    if(coin.body.parent().attr('id') == SSGame.current.nodes.selectedCoins.attr('id')) {
                        this.spinner.subtract(val/100);
                        coin.onUnChoose();
                    } else {
                        this.spinner.add(val/100);
                        coin.onChoose();
                    }
                },
                tick: function() {
                }
            },
            sleep: {
                start: function() {
                },
                payClick: function(e) {
                },
                coinClick: function(item, e) {
                },
                tick: function() {
                }
            }
        }
    });
    SSGame.current = new DyscalculiaGame();
})();
