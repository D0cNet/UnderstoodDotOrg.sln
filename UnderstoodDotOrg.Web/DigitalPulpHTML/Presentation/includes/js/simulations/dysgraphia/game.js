(function() {
    window.DysgraphiaGame = SSGame.extend({
        maps: {
            lower: ['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'],
            higher: ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z']
        },
        currPromptIdx: null,
        currPrompt: null,
        inputUI: null,
        timer: null,
        initialTweaks: null,
        initialTweakCounter: 0,
        init: function() {
            this._super('DysgraphiaGame', null);
        },
        reset: function() {
            this._super();
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
            this.currPromptIdx = -1;
            this.nodes.prompt.text('');
            this.success.reset();
            this.timer.reset();
            this.inputUI.clear();
        },
        draw: function() {
            this._super({
                timer: 'SSGame_timer',
                score: 'dysgraphia_score',
                prompt: 'dysgraphia_prompt',
                input: 'dysgraphia_input',
                challenge: 'dysgraphia_challenge'
            });
            this.nodes.challenge.append(this.nodes.prompt);
            this.nodes.challenge.append(this.nodes.input);
        },
        loadSounds: function() {
            var root = '/Presentation/includes/audio/simulations/dysgraphia/effects/';
            this._super({
                keypress: [
                    root + 'Dysgraphia_KeyType1',
                    root + 'Dysgraphia_KeyType2',
                    root + 'Dysgraphia_KeyType3',
                    root + 'Dysgraphia_KeyType4',
                    root + 'Dysgraphia_KeyType5',
                    root + 'Dysgraphia_KeyType4',
                    root + 'Dysgraphia_KeyType5',
                    root + 'Dysgraphia_KeyType6',
                    root + 'Dysgraphia_KeyType7',
                    root + 'Dysgraphia_KeyType8',
                    root + 'Dysgraphia_KeyType9',
                    root + 'Dysgraphia_KeyType10',
                    root + 'Dysgraphia_KeyType11'
                ]
            });
        },
        start: function() {
            this.timer.start();
            this.showNextPrompt();
            this.inputUI.focus();
            this.events.trigger('start');
        },
        stop: function() {
            var score = this.success.getScore();
            var finalText = '';
            var scoreText = score.correct + '/' + score.max;
            if(score.correct < score.max) {
                this.playSound('gameOverFail');
                finalText = this.getText(this.config.finalText.onTimeout);
            } else {
                this.playSound('gameOverSuccess');
                finalText = this.getText(this.config.finalText.onComplete);
            }
            finalText = finalText.replace('%score', scoreText);
            var done = new SSGameModal({
                showDuration: 0,
                text: finalText
            });
            done.setButtons([{
                text: 'Try Again',
                click: function() {
                    SSGame.current.reset();
                    done.close();
                }
            }, {
                text: 'Continue',
                click: function() {
                    SSGame.current.events.trigger('moveon');
                }
            }]);
            done.open();
            this.events.trigger('stop');
        },
        setMaxLength: function() {
            var bp = this.board.getCurrentBreakpoint();
            this.inputUI.setMaxLength(this.config.maxLength[bp[2]]);
        },
        run: function(localCfg) {
            if(!this._super(localCfg)) return;
            this.board.board.on('breakpointChange', $.proxy(this.setMaxLength, this));
            this.inputUI = new WTFInput(this.nodes.input, {
                maxLength: this.config.maxLength[this.board.getCurrentBreakpoint()[2]],
                tweakOutputFunction: $.proxy(function(typed) {
                    if(this.success.correct == 0) {
                        return this.initialTweak(typed);
                    } else {
                        return this.randomTweak(typed);
                    }
                }, this),
                onWrite: $.proxy(function() {
                    this.checkResponse();
                }, this)
            });
            this.board.board.find('textarea')
                .on('focus', function() { SSGame.current.board.board.addClass('infocus'); })
                .on('blur', function() { SSGame.current.board.board.removeClass('infocus'); })
                .on('keydown', function(e) {
                    var typedChr = String.fromCharCode(e.which);
                    if(typedChr && typedChr.match(/\w/)) {
                        //SSGame.current.playSound('keypress');
                    }
                });
            this.success = new SSGameSuccess({
                node: this.nodes.score,
                count: this.config.prompts.length,
                numbers: true
            });
            this.timer = new SSGameTimer({
                container: this.nodes.timer,
                maxTime: this.config.timeInSeconds
            });
            this.timer.onStop.add($.proxy(this.stop, this));
            this.addCheat($('<button></button').text('Solve').click($.proxy(function() {
                this.onSuccess();
            }, this)));
            this.addCheat($('<button></button>').text('Fake keyboard').click(function() {
                var existing = $('#fake_keyboard');
                var board = SSGame.current.board;
                var bp = board.getCurrentBreakpoint();
                if(existing.length > 0) {
                    existing.remove();
                    board.board.height(bp[1]);
                    board.board.unwrap();
                    board.board.find('textarea').blur();
                } else {
                    var kb = $('<div></div>')
                        .text('This is a keyboard.  Really.')
                        .attr('id', 'fake_keyboard')
                        .css({
                            width: bp[0],
                            height: 288, //I think?
                            backgroundColor: '#EEE',
                            position: 'absolute',
                            bottom: 0,
                            left: 0
                        });
                    board.board.wrap($('<div></div>').css({
                        position: 'relative',
                        width: bp[0],
                        height: bp[1]
                    }));
                    board.board.parent().append(kb);
                    var currHeight = board.board.height();
                    currHeight -= 288;
                    board.board.height(currHeight);
                    board.board.find('textarea').focus();
                }
            }));
            this.reset();
        },
        showNextPrompt: function() {
            this.currPromptIdx ++;
            var options = this.config.prompts[this.currPromptIdx];
            if(!options) this.timer.stop();
            else {
                var text = SSGame.pick(options, []);
                if(!text) this.timer.stop();
                else {
                    this.currPrompt = text;
                    this.nodes.prompt.text(text);
                    this.inputUI.startInput();
                }
            }
        },
        checkResponse: function() {
            var shouldBe = this.currPrompt.trim().replace(/\s+/g, ' ');
            var reallyIs = this.inputUI.getShownContent().trim().replace(/\s+/g, ' ');
            console.log('"%s" vs "%s"', shouldBe, reallyIs);
            if(shouldBe == reallyIs) {
                this.onSuccess();
            }
        },
        onSuccess: function() {
            this.playSound('sentenceComplete');
            this.success.increment();
            this.inputUI.stopInput();
            $('.wtfinput span').animate({
                color: '#00AA00'
            }, 500);
            setTimeout($.proxy(function() {
                this.inputUI.clear();
                this.showNextPrompt();
            }, this), 1000);
        },
        initialTweak: function(typed) {
            var cfg = this.config.tweaks.initial;
            if(!this.initialTweaks) {
                this.initialTweaks = [];
                for(var i = 0; i < cfg.length; i ++) this.initialTweaks.push(SSGame.rnd(cfg[i][0], cfg[i][1]));
            }
            this.initialTweakCounter ++;
            if($.inArray(this.initialTweakCounter, this.initialTweaks) >= 0) {
                return this.tweaks.replaceRandomly.call(this, typed);
            }
            return typed;
        },
        randomTweak: function(typed) {
            if(typed.search(/[a-zA-Z]/) !== 0) return typed;
            var rand = Math.floor(Math.random() * 100);
            var counter = 0;
            var shown;
            var chances = this.config.tweaks.chances[this.currPromptIdx];
            for(var key in chances) {
                counter += chances[key];
                if(rand < counter) {
                    shown = this.tweaks[key].call(this, typed);
                    console.log('Tweak %s changed "%s" to "%s"', key, typed, shown);
                    return shown;
                }
            }
            return typed;
        },
        getRandomMapItem: function(name) {
            var map = this.maps[name];
            var count = map.length;
            var rand = Math.floor(Math.random() * count);
            return map[rand];
        },
        tweaks: {
            replaceRandomly: function(typed) {
                var map = (typed == typed.toLowerCase()) ? 'lower' : 'higher';
                return this.getRandomMapItem(map);
            },
            extraRandom: function(typed) {
                var map = (typed == typed.toLowerCase()) ? 'lower' : 'higher';
                var pos = Math.floor(Math.random() * 2);
                var chr =  this.getRandomMapItem(map);
                return (pos == 0) ? chr + typed : typed + chr;
            },
            ignoreInput: function(typed) {
                return '';
            },
            changeCaps: function(typed) {
                if(typed == typed.toLowerCase()) {
                    return typed.toUpperCase();
                } else {
                    return typed.toLowerCase();
                }
            },
            repeatCharacters: function(typed) {
                var min = this.config.tweaks.rules.repeatCharacters.countMin;
                var max = this.config.tweaks.rules.repeatCharacters.countMax;
                var rand = min + Math.floor(Math.random() * (max - min + 1));
                console.log('Randomizing repetitions between %s and %s for %s, picked %s', min, max, typed, rand);
                var str = '';
                for(var i = 0; i < rand; i ++) str += typed;
                return str;
            }
        }
    });
    SSGame.current = new DysgraphiaGame();
})();
