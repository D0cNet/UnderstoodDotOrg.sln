(function() {
    window.DyscalculiaGame = SSGame.extend({
        bodySize: null,
        state: null,
        currentItem: null,
        nextItemIndex: 0,
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
                counterCopy: 'dyscalculia_counter_copy',
                itemContainer: 'dyscalculia_item',
                coins: 'dyscalculia_coins',
                selectedCoins: 'dyscalculia_coins_selected',
                tally: 'dyscalculia_tally'
            });
            var copy = this.config.uiCopy;
            var layout = this.board.getCurrentBreakpoint()[2];
            this.nodes.key.append($('<h2></h2>').text(this.getText(copy.key)));
            this.nodes.counterCopy.append($('<h2></h2>').text(this.getText(copy.trayTitle)));
            this.nodes.counterCopy.append($('<p></p>').text(this.getText(copy.trayDesc[layout])));
            this.nodes.counter.append(this.nodes.tally);
            this.spinner = DyscalculiaSpinner(this.nodes.tally);
            this.nodes.store.append(this.nodes.itemContainer);
            this.nodes.counter.append(this.nodes.selectedCoins);
            this.nodes.counter.append(this.nodes.counterCopy);
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
            this.lib.coinTools.init(this.config.coins, $.proxy(this.coinClick, this));
            this.lib.coinTools.drawKey();
        },
        reset: function() {
            this._super();
            SSGameModal.intro(this);
            if(this.spinner) this.spinner.setValue(0);
            this.lib.randomizer.reset();
            this.started = false;
            this.nextItemIndex = 0;
            this.success.reset();
            this.timer.reset();
            this.nodes.coins.empty();
            if(this.key) this.key.remove();
            this.setupElements();
        },
        start: function() {
            this.setState('needsItem');
            this.events.trigger('start');
        },
        stop: function() {
            var score = this.success.getScore();
            var success = (score.correct >= score.max);
            if(success) {
                this.playSound('gameOverSuccess', false);
            } else {
                this.playSound('gameOverFail', false);
            }
            SSGameModal.outro(this, success);
            this.events.trigger('stop');
        },
        run: function(localCfg) {
            if(!this._super(localCfg)) return;
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
                            this.currentItem = this.lib.item(
                                this.getText(vals.name), vals.cls, vals.value, $.proxy(this.payClick, this)
                            );
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
                        this.currentItem.remove(go);
                    } else {
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
                    this.setState('sleep');
                    var coins = this.nodes.counter.find('coin');
                    var total = Math.round(this.states.itemChosen.getTotal() * 100);
                    if(total != this.currentItem.value) {
                        this.playSound('incorrect', true);
                        this.spinner.setWrong();
                        this.currentItem.showWrong();
                        setTimeout($.proxy(function() {
                            this.setState('itemChosen');
                        }, this), this.config.warningDisplayTimeInMilliseconds);
                    } else {
                        this.playSound('correct', true);
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
