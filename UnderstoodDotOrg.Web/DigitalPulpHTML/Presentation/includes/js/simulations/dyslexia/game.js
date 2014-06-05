(function() {
    var transitions = {
        phrases: { 
            _swapTo: function(phrase, text, directionOut, letterCss, onComplete) {
                var newHtml = swaps.parseLetters(text);
                var pause = SSGame.current.config.display.clickFadeInDuration
                //First, figure out what we're going to do, depending on the browser's 3d support
                var animations = null;
                if(SSGame.current.canUse3d) {
                    animations = { out: { rotateY: (directionOut * 90) + 'deg' }, in: { rotateY: '0deg'}};
                } else {
                    var letterExample = phrase.find('.letter').first();
                    var letterWidth = letterExample.width();
                    var resizeMargin = Math.floor(letterWidth / 2);
                    animations = { out: { width: '0px', marginLeft: resizeMargin }, in: { width: letterWidth, marginLeft: 0 }};
                }
                //Next, pre-render the new phrase in the sentence container so we can get its width
                var dummyCtr = $('<div></div>').css({ visibility: 'hidden', position: 'absolute'}).html(newHtml);
                SSGame.current.nodes.sentence.append(dummyCtr);
                var newWidth = dummyCtr.outerWidth();
                //Hide the dummy so it doesn't interfere with the UI
                dummyCtr.css('display', 'none');
                //Then fix the phrase's min width at the size we're switching to so it doesn't jump oddly as the stuff inside moves around.
                phrase.css('minWidth', newWidth);
                //Now we animate!
                phrase.find('.letter').transition(animations.out, pause);
                //When the animations are done (hopefully), swap the letters
                setTimeout(function() {
                    phrase.find('.letter').remove();
                    var newLetters = dummyCtr.find('.letter');
                    phrase.append(newLetters);
                    dummyCtr.remove();
                    phrase.find('.letter').css(animations.out).css(letterCss);
                    newLetters.transition(animations.in, pause);
                    setTimeout(function() {
                        if(typeof onComplete == 'function') onComplete();
                    }, pause);
                }, pause);
            },
            correct: function(phrase, onComplete) {
                phrase.data('corrected_visible', true);
                this._swapTo(phrase, phrase.data('real'), -1, SSGame.current.config.display.letterStates.correct, function() {
                    setTimeout(function() {
                        if(!SSGame.current.nodes.sentence.data('successQueued')) {
                            phrase.data('corrected_visible', false);
                            phrase.find('.letter').transit(SSGame.current.config.display.letterStates.unknown, 250);
                        }
                    }, 2000);
                    if(typeof onComplete == 'function') onComplete();
                });
                thumbs.up(phrase);
            },
            uncorrected: function(phrase, onComplete) {
                this._swapTo(phrase, phrase.data('fake'), 1, SSGame.current.config.display.letterStates.unknown, onComplete);
                thumbs.down(phrase);
            },
            rotate: function(phrase, to, css, onComplete) {
                phrase.find('.letter').css(css).transit({'rotate': to}, 'fast',  onComplete);
            },
            wrong: function(phrase, onComplete) {
                phrase.data('wrong_visible', true);
                thumbs.down(phrase);
                this.rotate(phrase, 180, SSGame.current.config.display.letterStates.wrong, function() {
                    setTimeout(function() {
                        phrase.data('wrong_visible', false);
                        phrase.find('.letter').transit(SSGame.current.config.display.letterStates.unknown, 250);
                    }, 2000);
                    if(typeof onComplete == 'function') onComplete();
                });
            },
            unwronged: function(phrase, onComplete) {
                phrase.data('corrected_visible', true);
                phrase.data('wrong_visible', false);
                this.rotate(phrase, 0, SSGame.current.config.display.letterStates.correct, function() {
                    setTimeout(function() {
                        phrase.data('corrected_visible', false);
                        phrase.find('.letter').transit(SSGame.current.config.display.letterStates.unknown, 250);
                    }, 2000);
                    if(typeof onComplete == 'function') onComplete();
                });

            },
            hover: function(phrase) {
                //We do this manually instead of via CSS for finer control
                phrase.hover(function() {
                    var $this = $(this);
                    //After a swap, we temporarily don't want hover, so make sure it's enabled
                    if(!$this.data('nohover')) {
                        $this.find('.letter').transit(SSGame.current.config.display.letterStates.hover, 250);
                    }
                }, function() {
                    var $this = $(this);
                    if(!$this.data('nohover')) {
                        var to = SSGame.current.config.display.letterStates.unknown;
                        if($this.data('corrected_visible')) to = SSGame.current.config.display.letterStates.correct;
                        else if($this.data('wrong_visible')) to = SSGame.current.config.display.letterStates.wrong;
                        $this.find('.letter').transit(to, 250);
                    }
                    $this.data('nohover', false);
                });
            }
        },
        sentences: {
            success: function(onComplete) {
                var game = SSGame.current;
                game.nodes.sentence.data('successQueued', true);
                game.nodes.sentence.find('.letter').transit(
                    { backgroundColor: '#8FAD15', color: '#FFFFFF' },
                    game.config.display.sentenceDoneFadeDuration
                );
                setTimeout(function() {
                    setTimeout(function() {
                        game.nodes.sentence.transit({ opacity: 0 }, 'slow', function() {
                            if(typeof onComplete == 'function') onComplete();
                            game.nodes.sentence.transit({ opacity: 1 }, 'fast');
                            game.nodes.sentence.data('successQueued', false);
                        });
                    }, game.config.display.sentenceDonePauseDuration);
                }, game.config.display.sentenceDoneFadeDuration);
            }
        }
    };


    var thumbs = {
        distance: 50,
        speed: 500,
        pause: 250,
        makeAt: function(target, cls, atEdge) {
            var myEdge = (atEdge == 'bottom') ? 'top' : 'bottom';
            var thumb = $('<div></div>').addClass(cls);
            SSGame.current.board.board.append(thumb);
            thumb.position({
                    of: target,
                    my: 'center ' + myEdge,
                    at: 'center ' + atEdge,
                    collision: 'none none'
                });
            return thumb;
        },
        up: function(target) {
            this.makeAt(target, 'thumbsup', 'top')
                .css('opacity', 0)
                .transit({
                    opacity: 1,
                    y: '-=' + thumbs.distance
                }, thumbs.speed, 'easeOutQuad', function() {
                    setTimeout($.proxy(function() {
                        this.remove();
                    }, this), thumbs.pause);
                });
        },
        down: function(target) {
            this.makeAt(target, 'thumbsdown', 'bottom')
                .css('opacity', 0)
                .transit({
                    opacity: 1,
                    y: '+=' + thumbs.distance
                }, thumbs.speed, 'easeOutQuad', function() {
                    setTimeout($.proxy(function() {
                        this.remove();
                    }, this), thumbs.pause);
                });
            var board = SSGame.current.board.board;
            var bg = board.css('backgroundColor');
            var orig = board.css('backgroundColor');
            board.css('backgroundColor', '#e84646');
            board.transit({'backgroundColor': orig}, thumbs.speed + thumbs.pause, function() {
            });
        }
    };

    var swaps = {
        map: {},
        swaps: null,
        reset: function() {
            var game = SSGame.current;
            game.nodes.swaps.html('');
        },
        fillMap: function(from, to) {
            var first = from[0].toLowerCase();
            if(this.map[first] === undefined) {
                this.map[first] = [];
            }
            this.map[first].push({
                from: from,
                to: to
            });
        },
        load: function(swaps) {
            this.swaps = swaps;
            this.map = {};
            var key, html = [];
            for(key in this.swaps) {
                this.fillMap(key, this.swaps[key]);
                html.push(sprintf(
                    '<span class="rule"><span class="from">%s</span>=<span class="to">%s</span></span>',
                    key,
                    this.swaps[key]
                ));
                //Don't show the reverse, but map it
                this.fillMap(this.swaps[key], key);
            }
            var game = SSGame.current;
            game.nodes.swaps.html(html.join(''));
        },
        matchAtStart: function(s) {
            s = s.toLowerCase();
            var first = s[0];
            if(this.map[first] !== undefined) {
                var i, rule;
                for(i in this.map[first]) {
                    rule = this.map[first][i];
                    if(s.indexOf(rule.from) === 0) {
                        return rule;
                    }
                }
            }
            return null;
        },
        markupString: function(s) {
            var html = ['<span class="word">'];
            var i, rule, isReal, realVal, displayVal;
            for(i = 0; i < s.length; i ++) {
                if(s[i] == ' ') {
                    html.push('</span><span class="word">')
                    continue;
                }
                rule = this.matchAtStart(s.substring(i));
                isReal = true;
                if(rule) {
                    isReal = false;
                    realVal = s.substring(i, i + rule.from.length);
                    displayVal = rule.to;
                    i += realVal.length - 1; //Skip ahead for multi-character matches
                } else {
                    realVal = s[i];
                    displayVal = s[i];
                }
                html.push(sprintf('<span class="phrase %s" data-real="%s" data-fake="%s">',
                    (isReal) ? 'real' : 'swapped',
                    realVal,
                    displayVal
                    ));
                html.push(swaps.parseLetters(displayVal));
                html.push('</span>');
            }
            html.push('</span>');
            return html.join('');
        },
        parseLetters: function(str) {
            var html = [];
            for(var i = 0; i < str.length; i ++) {
                if(str[i].match(/\w/)) {
                    html.push('<span class="letter">' + str[i] + '</span>');
                } else {
                    html.push('<span class="punctuation">' + str[i] + '</span>');
                }
            }
            return html.join('');
        }
    };

    var sentences = {
        sentences: null,
        display: null,
        shown: [],
        idx: 0,
        init: function(game) {
            this.display = game.config.display;
            this.sentences = SSGame.pick(game.config.sentences, []);
        },
        reset: function() {
            var game = SSGame.current;
            var letters = game.nodes.sentence.find('span');
            letters.finish();
            letters.remove();
            this.shown = [];
            this.idx = 0;
            game.nodes.sentence.html('');
        },
        getCount: function() {
            console.log(this);
            return this.sentences.length;
        },
        getNext: function() {
            /* Older random-from-bucket strategy
            if(this.sentences.length > this.idx) {
                pool = this.sentences[this.idx];
                return SSGame.pick(pool, []);
            } else {
                return null;
            } */
            if(this.sentences.length > this.idx) {
                return this.sentences[this.idx];
            } else {
                return null;
            }
        },
        showNext: function() {
            var game = SSGame.current;
            var s = sentences.getNext();
            if(!s) {
                game.timer.stop();
                return;
            } else {
                swaps.load(s.rules);
                this.idx ++;
                var html = swaps.markupString(s.text);
                game.nodes.sentence.html(html);
                var phrases = game.nodes.sentence.find('.phrase');
                phrases
                    .click(this.phraseClick);
                phrases.each(function() {
                    transitions.phrases.hover($(this));
                });
                phrases.find('.letter').css(SSGame.current.config.display.letterStates.unknown);
            }
        },
        phraseClick: function(e) {
            var $this = $(this);
            if($this.is(':animated')) return;
            if($this.text().replace(/ /g, '') == '') return;
            if($this.find('.letter').length == 0) return;

            if($this.hasClass('real')) {
                //Real, unswapped phrases get turned upsidedown, or restored to their original state
                if($this.hasClass('wrong')) {
                    $this.removeClass('wrong');
                    sentences.onCorrectLetter();
                    SSGame.current.playSound('fixedclick');
                    transitions.phrases.unwronged($this, function() {
                    });
                } else {
                    $this.addClass('wrong');
                    SSGame.current.playSound('wrongclick');
                    transitions.phrases.wrong($this);
                }
            } else {
                //Swapped text either gets corrected or swapped back to the wrong text
                if($this.text() == $this.data('real')) {
                    $this.removeClass('corrected');
                    SSGame.current.playSound('wrongclick');
                    transitions.phrases.uncorrected($this);
                } else {
                    $this.addClass('corrected');
                    SSGame.current.playSound('correctclick');
                    sentences.onCorrectLetter();
                    transitions.phrases.correct($this, $.proxy(function() {
                    }, this));
                }
            }
            $this.data('nohover', true);
        },
        onCorrectLetter: function() {
            var b = SSGame.current.nodes.sentence;
            var startedWrong = b.find('.swapped, .wrong');
            var stillWrong = startedWrong.filter(function() {
                return !$(this).hasClass('corrected');
            });
            if(stillWrong.length == 0) {
                SSGame.current.onSuccess();
            }
        }
    };

    window.DyslexiaGame = SSGame.extend({
        success: null,
        timer: null,
        started: false,
        init: function() {
            this._super('DyslexiaGame', null);
        },
        reset: function() {
            this._super();
            swaps.reset();
            sentences.reset();
            this.success.reset();
            this.timer.reset();
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
            this.started = false;
        },
        draw: function() {
            this._super({
                timer: 'SSGame_timer',
                swapsContainer: 'dyslexia_swaps_ctr',
                swaps: 'dyslexia_swaps',
                sentence: 'dyslexia_sentence',
                score: 'dyslexia_score'
            });
            this.nodes.swapsContainer.append(this.nodes.swaps);
        },
        loadSounds: function() {
            var root = '/Presentation/includes/audio/simulations/dyslexia/effects/';
            this._super({
                wrongclick: root + 'Dyslexia_ThumbsDownBuzzer',
                correctclick: root + 'Dyslexia_TileFlipClick',
                fixedclick: root + 'Dyslexia_VerticalLetterFlip'
            });
        },
        start: function() {
            this.timer.start();
            sentences.showNext();
            this.events.trigger('start');
            this.started = true;
            //Can be set to 0 if reset during an animation
            this.nodes.sentence.finish().css('opacity', 1);
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
        run: function(localCfg) {
            if(!this._super(localCfg)) return;
            sentences.init(this);
            this.success = new SSGameSuccess({
                numbers: true,
                node: this.nodes.score,
                count: sentences.getCount()
            });
            this.timer = new SSGameTimer({
                container: this.nodes.timer,
                maxTime: this.config.timeInSeconds
            });
            this.timer.onStop.add($.proxy(this.stop, this));
            this.reset();
            this.addCheat($('<button></button').text('Solve').click($.proxy(function(e) {
                e.preventDefault();
                this.onSuccess();
            }, this)));
        },
        onSuccess: function() {
            this.playSound('sentenceComplete');
            var b = this.nodes.sentence;
            this.success.increment();
            transitions.sentences.success($.proxy(function() {
                if(!SSGame.current.started) return;
                console.log('Next');
                sentences.showNext();
            }, this));
        }
    });

    SSGame.current = new DyslexiaGame();
})();
