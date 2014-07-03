(function() {
    /**
     * The spinner that keeps track of our current guess at the item value
     */
    var DyscalculiaSpinner = function(ctr) {
        //Helpers
        function addWheel(cls) {
            var n = $('<div></div>').addClass('dyscalculia_spinner_wheel dyscalculia_spinner' + cls);
            for(var i = 0; i < 10; i ++) {
                n.append($('<div></div>').text(i));
            }
            ui.body.append(n);
            return n;
        }
        function setWheelTo(wheel, val, skewResults) {
            var skew = (skewResults) ? getSkew() : 0;
            var duration = (skewResults) ? SSGame.current.config.spinnerDurationBroken: SSGame.current.config.spinnerDurationNormal;
            var h = wheel.find('div').height();
            var newT = val * h + skew;
            //console.log('Was %s, skew %s, will be %s', wheel.scrollTop(), skew, newT);
            wheel.stop(true).animate({ scrollTop: newT }, duration);
        }
        function getSkew() {
            return skew = SSGame.rnd(3, 18) * SSGame.pick([-1,1], []);
        }
        function clearState() {
            ui.body
                .removeClass('dyscalculia_spinner_wrong')
                .removeClass('dyscalculia_spinner_right');
        }
        //Public UI
        var ui = {
            value: 0,
            body: null,
            dollar: null,
            tencent: null,
            cent: null,
            mask: null,
            disabled: false,
            setValue: function(val, skewResults) {
                val = Math.round(val * 100) / 100;
                if(ui.disabled) {
                    ui.value = val;
                    return;
                }
                if(val >= 10) {
                    console.error('Can only do 9.99 or less');
                    return;
                }
                var bits = (val + '').replace('.', '').split('');
                while(bits.length < 3) bits.push(0);
                for(var i = 0; i < bits.length; i ++) bits[i] = bits[i] * 1;
                var dollars = bits[0];
                var tencents = bits[1];
                var cents = bits[2];
                //console.log('%s becomes %s, %s, %s', val, dollars, tencents, cents);
                setWheelTo(ui.dollar, dollars, skewResults);
                setWheelTo(ui.tencent, tencents, skewResults);
                setWheelTo(ui.cent, cents, skewResults);
                if(!skewResults) {
                    ui.value = val;
                }
                return ui;
            },
            getValue: function() {
                return ui.value;
            },
            scramble: function() {
                var num = [
                    Math.round(SSGame.rnd(0, 90) / 10),
                    '.',
                    Math.round(SSGame.rnd(0, 90) / 10),
                    Math.round(SSGame.rnd(0, 90) / 10),
                    ].join('') * 1;
                ui.setValue(num, true);
                return ui;
            },
            disable: function() {
                ui.disabled = true;
                ui.scramble();
                ui.dollar.queue(function() {
                    ui.mask = $('<div></div>').addClass('dyscalculia_spinner_mask');
                    ui.mask.css({
                        width: ctr.width(),
                        height: 0
                    });
                    ui.body.append(ui.mask);
                    ui.mask.animate({ height: ctr.height() });
                });
                return ui;
            },
            enable: function() {
                if(ui.mask) ui.mask.remove();
                ui.disabled = false;
                return ui;
            },
            reset: function() {
                ui.setValue(0);
                return ui;
            },
            setInProgress: function() {
                clearState();
                return ui;
            },
            setWrong: function() {
                clearState();
                ui.body.addClass('dyscalculia_spinner_wrong');
                return ui;
            },
            setRight: function() {
                clearState();
                ui.body.addClass('dyscalculia_spinner_right');
                return ui;
            },
            add: function(val) {
                this.setValue(this.value + val);
                return ui;
            },
            subtract: function(val) {
                this.setValue(this.value - val);
                return ui;
            }
        };
        //Draw it
        ui.body = $('<div></div>').addClass('dyscalculia_spinner');
        ui.body.append($('<div></div>').addClass('dyscalculia_spinner_static dyscalculia_spinner_currency').text('$'));
        ui.dollar = addWheel('dollar');
        ui.body.append($('<div></div>').addClass('dyscalculia_spinner_static dyscalculia_spinner_separator').text('.'));
        ui.tencent = addWheel('tencent');
        ui.cent = addWheel('cent');
        ctr.append(ui.body);

    
        return ui;
    }
    function item(name, cls, value, onClick) {
        var game = SSGame.current;
        var ui = {
            container: null,
            picture: null,
            valLabel: null,
            label: null,
            value: 0,
            name: null,
            setValue: function(value) {
                this.valLabel.text('$' + sprintf('%0.2f', value/100));
                this.value = value;
            },
            getValue: function() {
                return this.value;
            },
            setName: function(name) {
                this.label.text(name);
                this.name = name;
            },
            getName: function() {
                return this.name;
            },
            say: function(text, speedOut, speedIn) {
                ctr.find('.paybutton').animate({ opacity: 0}, speedOut, function() {
                    $(this).css('display', 'none');
                    var txt = $('<div></div>').text(text).addClass('feedback');
                    ctr.append(txt);
                    if(SSGame.current.board.getCurrentBreakpoint()[2] == 'phone') {
                        //Just show it for now
                    } else {
                        txt.css('marginTop', 200).animate({ marginTop: 0 }, speedIn);
                    }
                        
                });
            },
            unsay: function(speedIn) {
                if(SSGame.current.board.getCurrentBreakpoint()[2] == 'phone') {
                    //Just show it for now
                } else {
                    var txt = ctr.find('.feedback');
                    txt.animate({ marginTop: 200 }, speedIn, function() {
                        ctr.find('.paybutton').css('display', 'block').animate({ opacity: 1}, speedIn);
                        txt.remove();
                    });
                }
            },
            show: function() {
                if(SSGame.current.board.getCurrentBreakpoint()[2] == 'phone') {
                    //Leave it alone for now
                } else {
                    var ctrWidth = this.container.width();
                    this.container.find('div')
                        .filter(function() { return !($(this).hasClass('paybutton') || $(this).hasClass('paybuttontarget')); })
                        .css({ marginLeft: ctrWidth })
                        .animate({ marginLeft: 0 });
                    this.container.find('.paybutton')
                        .css({ marginTop: 200 })
                        .animate({ marginTop: 0 });
                }
            },
            remove: function(after) {
                if(SSGame.current.board.getCurrentBreakpoint()[2] == 'phone') {
                    //Just remove stuff for now
                    this.container.remove();
                    after();
                } else {
                    ctr.find('div')
                        .filter(function() { return !($(this).hasClass('paybutton') || $(this).hasClass('paybuttontarget')); })
                        .animate({ marginLeft: ctr.width() * -1 }, 1000);
                    ctr.find('.paybutton,.feedback')
                        .animate({ marginTop: 200 }, 1000);
                    setTimeout($.proxy(function() {
                        this.container.remove();
                        after();
                    }, this), 1000);
                }
            },
            showCorrect: function() {
                var t = SSGame.current.config.feedbackSpeed.correct;
                ui.say('Thanks', t.text[0], t.text[1]);
                game.nodes.store.transit({
                    backgroundColor: '#8fad15'
                }, t.color[0]).delay(t.color[1]).transit({
                    backgroundColor: '#298FC2'
                }, t.color[2]);
            },
            showWrong: function() {
                var t = game.config.feedbackSpeed.incorrect;
                ui.say('Sorry', t.text[0], t.text[1]);
                game.nodes.store
                    .effect('shake')
                    .css('backgroundColor', '#e84646')
                    .delay(t.color[0])
                    .queue(function(next) {
                        next();
                        game.spinner.setInProgress();
                        ui.unsay(t.color[1]);
                    })
                    .animate({ backgroundColor: '#298FC2' }, t.color[1]);
            },
            resetInput: function() {
            }

        };
        var ctr = $('<div></div>')
            .addClass('item ' + cls)
            .click(function(e) {
                onClick(ui, e);
            });

        var picture = $('<div></div>').addClass('item_picture');
        var label = $('<div></div>').addClass('item_name');
        var valLabel = $('<div></div>').addClass('item_value');
        var payButtonTarget = $('<div></div>').addClass('paybuttontarget');
        var payButton = $('<div></div>').addClass('paybutton').text('Buy');

        ctr.append(picture);
        ctr.append(label);
        ctr.append(valLabel);
        ctr.append(payButtonTarget);
        ctr.append(payButton);
        game.nodes.itemContainer.append(ctr);
       
        ui.picture = picture;
        ui.container = ctr;
        ui.valLabel = valLabel;
        ui.label = label;
        ui.setValue(value);
        ui.setName(name);
        ui.show();
        return ui;
    }
    var coinTools = {
        setAllAvailable: function() {
            $('.coin_anim').stop().remove();
            SSGame.current.nodes.coins.append(SSGame.current.nodes.counter.find('.coin'));
        },
        adjustZIndex: function(ctr) {
            var coins = ctr.find('.coin');
            console.log(coins);
            var idx = 1;
            coins.each(function() {
                $(this).css('zIndex', idx);
                idx ++;
            });
        },
        getStats: function(ctr) {
            var placedCoins = ctr.find('.coin');
            var coinStats = [];
            placedCoins.each(function() {
                var $this = $(this);
                var pos = $this.position();
                coinStats.push({
                    width: $this.width(),
                    height: $this.height(),
                    left: pos.left,
                    top: pos.top
                });
            });
            return coinStats;
        },
        getLayoutSpecs: function(coin, ctr) {
            var cfgRoot = SSGame.current.board.getCurrentBreakpoint()[2] == 'phone' ? 'phone' : 'desktop';
            return {
                siblings: coinTools.getStats(ctr),
                container: { width: ctr.width(), height: ctr.height() },
                coinSize: { width: coin.body.width(), height: coin.body.height() },
                coinPosition: coin.body.offset(),
                grid: SSGame.current.config.coinUI[cfgRoot].scatterGrid
            }
        },
        dummyJump: function(coin, coinFrom, coinTo, dir, after) {
            var cfgRoot = SSGame.current.board.getCurrentBreakpoint()[2] == 'phone' ? 'phone' : 'desktop';
            var cfg = SSGame.current.config.coinUI[cfgRoot];
            var dummy = $('<div></div>').html('&nbsp;');
            if(coin.body.hasClass('quarter')) dummy.addClass('coin_anim quarter_anim');
            if(coin.body.hasClass('dime')) dummy.addClass('coin_anim dime_anim');
            if(coin.body.hasClass('nickel')) dummy.addClass('coin_anim nickel_anim');
            if(coin.body.hasClass('penny')) dummy.addClass('coin_anim penny_anim');

            //Animation assets are sized differently than placed assets, so we need to adjust thier position
            var leftDelta = 50 - Math.round(coin.body.width() / 2); //We know it's 50, but this might need to be configurable later.
            var topDelta = 50 - Math.round(coin.body.height() / 2); //We know it's 50, but this might need to be configurable later.
            var animFrom = $.extend({}, coinFrom);
            animFrom.left += leftDelta;
            animFrom.top += topDelta;
            var animTo = $.extend({}, coinTo);
            if(SSGame.current.board.getCurrentBreakpoint()[2] != 'phone') {
                animTo.left += leftDelta + 10;
                animTo.top += topDelta + 10;
            } else {
                animTo.left += leftDelta;
                animTo.top += topDelta;
            }

            dummy.css(animFrom);
            $(document.body).append(dummy);
            var justSlideAt = cfg.stopFlippingAt / 100;
            //We have frames 0-6, i.e. 0, -100, ..., -600px
            //So 1 flip is 7 frames, 2 flips is 14, etc.
            //We have from 0 tojustSlideAt (0 to <1) in which to do make our N flips,
            // so a new frame should show every...
            var frameJump = justSlideAt / (cfg.jumpFlips * 7);
            dummy.animate(animTo, {
                duration: cfg.jumpDuration,
                progress: function(anim, progress, remaining) {
                    var bgPos;
                    if(progress > justSlideAt) {
                        bgPos = 0;
                    } else {
                        var absoluteFrame = Math.floor(progress / frameJump);
                        var relativeFrame = Math.floor(absoluteFrame % 7);
                        var bgPos = (dir > 1) ? relativeFrame * -100 : -600 + (relativeFrame * 100);
                        if(false) console.log('Frame is %s, bg idx is %s, bg pos is %s',
                            absoluteFrame, relativeFrame, bgPos);
                    }
                    dummy.css('background-position', bgPos + 'px center');
                },
                complete: $.proxy(function() {
                    dummy.remove();
                    after();
                }, this)
            });
        }
    };
    function coin(cls, value, onClick) {
        var game = SSGame.current;
        var ui = {
            body: null,
            label: null,
            value: null,
            setValue: function(value) {
                this.value = value * 1;
                this.body.data('value', value);
            },
            getValue: function() {
                return this.value;
            },
            showValue: function() {
                this.label.css('display', '').html('&nbsp;' + this.value + '&cent;');
            },
            destroy: function() {
                this.body.remove();
            },
            setPosition: function(x, y, z) {
                this.body.css({
                    position: 'absolute',
                    top: y,
                    left: x,
                    zIndex: z
                });
            },
            onChoose: function() {
                SSGame.current.playSound('coinClick', true);
                //Get our specs for finding a new random position
                var coinCfgRoot = SSGame.current.board.getCurrentBreakpoint()[2] == 'phone' ? 'phone' : 'desktop';
                var coinCfg = SSGame.current.config.coinUI[coinCfgRoot];
                var ctr = SSGame.current.nodes.selectedCoins;
                var specs = coinTools.getLayoutSpecs(this, ctr);
                var newPos = SSGame.getRandomPosition(specs.coinSize, specs.siblings, specs.container,
                        coinCfg.scatterAmount, specs.grid[0], specs.grid[1]);
                coinTools.adjustZIndex(ctr);
                newPos.zIndex = specs.siblings.length + 1;
                //Stick the coin in the new ctr and hide it
                ctr.append(this.body);
                this.body.css(newPos).css('visibility', 'hidden');

                //Stick a new animation dummy where the coin was
                var newCoinPos = this.body.offset();
                coinTools.dummyJump(this, specs.coinPosition, newCoinPos, 1, $.proxy(function() {
                    this.body.css('visibility', 'visible');
                }, this));
            },
            onUnChoose: function() {
                SSGame.current.playSound('coinClick', true);
                //Get our specs for finding a new random position
                var coinCfgRoot = SSGame.current.board.getCurrentBreakpoint()[2] == 'phone' ? 'phone' : 'desktop';
                var coinCfg = SSGame.current.config.coinUI[coinCfgRoot];
                var ctr = SSGame.current.nodes.coins;
                var specs = coinTools.getLayoutSpecs(this, ctr);
                var newPos = SSGame.getRandomPosition(specs.coinSize, specs.siblings, specs.container,
                        coinCfg.scatterAmount, specs.grid[0], specs.grid[1]);
                coinTools.adjustZIndex(ctr);
                newPos.zIndex = specs.siblings.length + 1;
                //Stick the coin in the new ctr and hide it
                ctr.append(this.body);
                this.body.css(newPos).css('visibility', 'hidden');
                //Stick a new animation dummy where the coin was
                var newCoinPos = this.body.offset();
                coinTools.dummyJump(this, specs.coinPosition, newCoinPos, 1, $.proxy(function() {
                    this.body.css('visibility', 'visible');
                }, this));
            }

        };

        var body = $('<div></div>')
            .addClass('coin').addClass(cls)
            .click(function(e) {
                onClick(ui, e);
            });

        var label = $('<div></div>').css('display', 'none');

        body.append(label);
        ui.body = body;
        ui.label = label;
        ui.setValue(value);
        return ui;
    };
    var randomizer = {
        used: {},
        reset: function() {
            this.used = {};
        },
        str: function(type, prop, vals) {
            if(!vals.push) return vals;
            var key = [type, prop].join('.');
            if(!randomizer.used[key]) randomizer.used[key] = [];
            var val = SSGame.pick(vals, randomizer.used[key]);
            var idx = -1;
            $.each(vals, function(i, allval) {
                if(val == allval) {
                    idx = i;
                    return false;
                }
            });
            randomizer.used[key].push(idx);
            return val;
        },
        num: function(type, prop, vals) {
            if(typeof vals != 'object' || !vals.push) return vals;
            return SSGame.rnd(vals[0], vals[1]);
        },
        coin: function(cfg) {
            return {
                cls: cfg.cls,
                value: randomizer.str('coin', 'value', cfg.value),
                count: randomizer.num('coin', 'count', cfg.count)
            }
        },
        item: function(cfg) {
            if(!cfg) return null;
            return {
                name: randomizer.str('item', 'name', cfg.name),
                value: randomizer.num('item', 'value', cfg.value),
                cls: randomizer.str('item', 'cls', cfg.cls),
                showTally: cfg.showTally
            }
        }
    };

    window.DyscalculiaSpinner = DyscalculiaSpinner;
    window.DyscalculiaGameLib = {
        coin: coin,
        item: item,
        coinTools: coinTools,
        randomizer: randomizer
    };

})();
