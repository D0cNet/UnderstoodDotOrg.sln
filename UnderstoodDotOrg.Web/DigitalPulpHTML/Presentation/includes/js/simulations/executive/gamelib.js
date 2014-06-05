/*
 * Pause jQuery plugin v0.1
 *
 * Copyright 2010 by Tobia Conforto <tobia.conforto@gmail.com>
 *
 * Based on Pause-resume-animation jQuery plugin by Joe Weitzel
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General Public License as published by the Free
 * Software Foundation; either version 2 of the License, or(at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
 * more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
 */

(function(){var e=jQuery,f="jQuery.pause",d=1,b=e.fn.animate,a={};function c(){return new Date().getTime()}e.fn.animate=function(k,h,j,i){var g=e.speed(h,j,i);g.complete=g.old;return this.each(function(){if(!this[f]){this[f]=d++}var l=e.extend({},g);b.apply(e(this),[k,e.extend({},l)]);a[this[f]]={run:true,prop:k,opt:l,start:c(),done:0}})};e.fn.pause=function(){return this.each(function(){if(!this[f]){this[f]=d++}var g=a[this[f]];if(g&&g.run){g.done+=c()-g.start;if(g.done>g.opt.duration){delete a[this[f]]}else{e(this).stop();g.run=false}}})};e.fn.resume=function(){return this.each(function(){if(!this[f]){this[f]=d++}var g=a[this[f]];if(g&&!g.run){g.opt.duration-=g.done;g.done=0;g.run=true;g.start=c();b.apply(e(this),[g.prop,e.extend({},g.opt)])}})}})();
(function() {
    var channels = {
        channels: [],
        height: 0,
        bottom: 0,
        bottomRelative: 0,
        getAt: function(idx) {
            return channels.channels[idx];
        },
        getAvailable: function() {
            var full = [];
            for(var key in balls.balls) full.push(key);
            var all = [];
            for(var i = 0; i < channels.channels.length; i ++) all.push(i);
            return SSGame.pick(all, full);
        },
        getCenter: function() {
            return Math.floor(this.channels.length / 2);
        },
        reset: function() {
        },
        updateSize: function() {
            if(this.channels.length > 0) {
                var channel = this.channels[0];
                var inner = channel.find('.inner_channel');
                var channelTop = channel.offset().top;
                var channelHeight = channel.height();
                var channelBorder = inner.css('border-bottom-width').replace('px', '') * 1;
                if(!channelBorder) channelBorder = 0;
                this.bottomRelative = channelHeight - channelBorder;
                this.bottom = this.bottomRelative + channelTop;
                this.height = channelHeight;
            }
        },
        init: function() {
            var game = SSGame.current;
            var channel, inner;
            for(var i = 0; i < game.maxChannels; i ++) {
                channel = $('<div></div>')
                    .addClass('channel channel' + i)
                    .data('channel', i)
                    .click(function(e) {
                        SSGame.current.playSound('pickcolumn');
                        trap.moveTo($(this).data('channel'));
                    });
                inner = $('<div></div>').addClass('inner_channel');
                channel.append(inner);
                game.nodes.body.append(channel);
                channels.channels.push(channel);
            }
            this.updateSize();
        },
        showText: function(i, txt, color) {
            var cfg = SSGame.current.config.channelText;
            var c = channels.channels[i];
            if(!c) {
                console.error('Cannot show text in channel %o', i);
                return;
            }
            var css = { top: channels.height + cfg.startBelow };
            if(color) css['color'] = color;
            var n = $('<div></div>').addClass('feedback').text(txt).css(css);
            c.find('.inner_channel').append(n);
            n.animate({ top: channels.height - cfg.endAbove }, cfg.moveDuration);
            n.delay(cfg.pauseBeforeRemoval);
            n.animate({ opacity: 0 }, 200);
            n.queue(function() {
                n.remove();
            });
        }
    };
    var trap = {
        node: null,
        nodeRear: null,
        nodes: null,
        targetZone: null,
        clickQueue: [],
        dColor: 0,
        lipSize: 2,
        positionFix: 0,
        init: function() {
            var me = SSGame.current;
            var bp = me.board.getCurrentBreakpoint();
            this.updateSize(bp);
            var n = $('<div></div>').attr('id', 'executive_trap').css({
                left: 0
            });
            var nRear = $('<div></div>').attr('id', 'executive_trap_rear').css({
                left: 0
            });
            me.nodes.body.append(n);
            me.nodes.body.append(nRear);
            trap.node = n;
            trap.nodeRear = nRear;
            trap.nodes = $(n).add(nRear);
            trap.updateBoundary();
            trap.dColor = Math.floor(128/ me.config.maxQueue);
            this.reset();
        },
        updateSize: function(bp) {
            console.log(bp);
            this.positionFix = (bp[2] == 'phone') ? 5 : 1; //Hack...
        },
        reset: function() {
            if(this.nodes) {
                this.nodes.stop();
                this.centerTrap();
            }
        },
        centerTrap: function() {
            if(channels.channels.length > 0) {
                var middle = Math.floor(channels.channels.length / 2);
                var middleLeft = channels.channels[middle].position().left;
                trap.nodes.css('left', middleLeft - this.positionFix);
                trap.updateBoundary();
            }
        },
        moveTo: function(channelIdx) {
            var game = SSGame.current;
            if(game.paused) return;
            if(trap.clickQueue.length >= game.config.maxQueue) return;
            if(trap.node.is(':animated')) {
                if(trap.clickQueue.length < game.config.maxQueue) {
                    trap.clickQueue.push({ channel: channelIdx });
                    if(trap.clickQueue.length >= game.config.maxQueue) {
                        game.nodes.body.css('cursor', 'wait');
                    }
                }
            } else {
                var channel = channels.getAt(channelIdx);
                channel.addClass('targetted');
                var game = SSGame.current;
                var speedPerPixel = Math.floor(game.config.trap.clickReactionSpeed / (channel.outerWidth() * channels.channels.length));
                var trapLeft = trap.node.position().left;
                var channelLeft = channel.position().left;
                var speed = Math.abs(trapLeft - channelLeft) * speedPerPixel;
                //console.log('SPP: %s, TL: %s, CL: %s, S: %s', speedPerPixel, trapLeft, channelLeft, speed);

                trap.nodes.animate({
                    left: channelLeft - this.positionFix
                }, {
                    duration: speed,
                    easing: 'linear',
                    progress: function(animation, progress, remainingTime) {
                        trap.updateBoundary();
                    },
                    complete: function() {
                        channel.removeClass('targetted');
                        if(trap.clickQueue.length > 0) {
                            var data = trap.clickQueue.shift();
                            if(trap.clickQueue.length < game.config.maxQueue) {
                                game.nodes.body.css('cursor', 'pointer');
                            }
                            trap.moveTo(channelIdx);
                        }
                    }
                });
            }
        },
        updateBoundary: function() {
            var game = SSGame.current;
            var off = trap.node.offset();
            trap.boundary = {
                left: off.left,
                top: off.top,
                right: off.left + trap.node.width(),
                bottom: off.top + trap.node.height()
            };
        },
        canCatch: function(ballNode) {
            var bleft = ballNode.offset().left;
            var bright = bleft + ballNode.width();
            return bleft > trap.boundary.left + trap.lipSize && bright < trap.boundary.right - trap.lipSize;
        },
        touches: function(ballNode) {
            var bleft = ballNode.offset().left;
            var bright = bleft + ballNode.width();
            var tll = trap.boundary.left;
            var tlr = trap.boundary.left + trap.lipSize;
            var trl = trap.boundary.right - trap.lipSize;
            var trr = trap.boundary.right;
            var retVal = false;
            if(bleft <= tlr && bright >= tll) {
                retVal = 'left';
            } else if(bleft <= trr && bright >= trl) {
                retVal = 'right';
            }
            //console.log('Touching? %o: Ball [%s %s], left lip [%s %s], right lip [%s %s]', retVal, bleft, bright, tll, tlr, trl, trr);
            return retVal;
        },
        fadeTo: function(color, whileOut) {
            var cfg = SSGame.current.config.trapFade[color];
            var newBG = $('<div></div>').addClass('bg_' + color).css('opacity', 0);
            trap.node.append(newBG);
            trap.nodeRear.append(newBG.clone());
            var newNodes = trap.nodes.find('.bg_' + color);
            newNodes.transit({ opacity: 1}, cfg.fadeIn, function() {
                setTimeout(function() {
                    if(whileOut) whileOut();
                    newNodes.transit({ opacity: 0}, cfg.fadeOut);
                    newNodes.queue(function() {
                        newNodes.remove();
                    });
                }, cfg.pause);
            });
        }
    };
    var balls = {
        balls: [],
        firstDropped: false,
        boardColor: null,
        init: function() {
            this.boardColor = SSGame.current.board.board.css('backgroundColor');
        },
        reset: function() {
            for(var key in this.balls) this.balls[key].remove();
            this.balls = [];
        },
        drop: function() {
            var channel;
            if(!this.firstDropped) {
                channel = channels.getCenter();
                this.firstDropped = true;
            } else {
                channel = channels.getAvailable();
            }
            if(channel === null) {
                console.error('No channel free!');
                return;
            }
            var cfg = state.pickBall();
            if(!cfg) {
                console.error('Ballless!');
                return;
            }
            console.log('Picked %o for channel %s', cfg, channel);
            var spritePos = (cfg.sprites) ? SSGame.pick(cfg.sprites, []) : 0;
            var ball = makeBall(cfg.cls, cfg.radius, cfg.id, spritePos);
            dropBallDownChannel(ball, channel, SSGame.rnd(state.speed[0], state.speed[1]));
            state.dropped();
        },
        scorable: function(ball) {
            var bbottom = ball.offset().top + ball.height();
            return bbottom >= channels.bottom;
        },
        hidden: function(ball) {
            var btop = ball.offset().top;
            return btop >= channels.bottom;
        },
        checkStatus: function(ballNode) {
            //See if it's ready to look at
            if(!ballNode.data('done') && balls.scorable(ballNode)) {
                var valid = state.ballValid(ballNode);
                var touched;
                ballNode.data('done', true);
                if(trap.canCatch(ballNode)) {
                    if(valid) {
                        balls.validCatch(ballNode);
                    } else {
                        balls.invalidCatch(ballNode);
                    }
                } else if((touched = trap.touches(ballNode)) !== false) {
                    if(valid) {
                        balls.validTouchedTrap(ballNode, touched);
                    } else {
                        balls.invalidTouchedTrap(ballNode, touched);
                    }
                } else {
                    if(valid) {
                        balls.validMissed(ballNode);
                    } else if(balls.hidden(ballNode)) {
                        balls.invalidMissed(ballNode);
                    }
                }
            }
        },
        validCatch: function(ballNode) {
            score.increment(ballNode);
            balls.animations.success(ballNode);
            state.everyOtherToggle = false;
            SSGame.current.playSound('caughtright');
        },
        invalidCatch: function(ballNode) {
            score.decrement(ballNode, 'wrong');
            var txt = SSGame.current.config.channelText.copy[SSGame.current.getLanguage()].wrongCatch;
            balls.animations.error(ballNode, txt);
            state.everyOtherToggle = true;
            SSGame.current.playSound('caughtwrong');
        },
        validTouchedTrap: function(ballNode, dir) {
            score.decrement(ballNode, 'contact');
            balls.animations.bounce(ballNode, true, dir);
            state.everyOtherToggle = true;
            SSGame.current.playSound('bounce');
        },
        invalidTouchedTrap: function(ballNode, dir) {
            balls.animations.bounce(ballNode, false, dir);
            state.everyOtherToggle = true;
            SSGame.current.playSound('bounce');
        },
        validMissed: function(ballNode) {
            score.decrement(ballNode, 'missed');
            var txt = SSGame.current.config.channelText.copy[SSGame.current.getLanguage()].missed;
            balls.animations.error(ballNode, txt);
            state.everyOtherToggle = true;
            SSGame.current.playSound('missedright');
        },
        invalidMissed: function(ballNode) {
            state.everyOtherToggle = true;
        },
        remove: function(ballNode) {
            var channel = ballNode.data('channel') * 1;
            delete balls.balls[channel];
            ballNode.remove();
        },
        animations: {
            success: function(ballNode) {
                var channel = ballNode.data('channel')
                channels.showText(channel, '+1', '#00FF00');
                trap.fadeTo('green', function() {
                    if(SSGame.current.board.getCurrentBreakpoint()[2] !== 'phone') {
                        var txt = SSGame.current.config.channelText.copy[SSGame.current.getLanguage()].right;
                        channels.showText(channel, txt, null);
                    }
                });
            },
            error: function(ballNode, reason) {
                var cfg = SSGame.current.config.errorShakeConfig;
                var channel = ballNode.data('channel')
                channels.showText(channel, '-1', '#FF0000');
                trap.fadeTo('red', function() {
                    if(SSGame.current.board.getCurrentBreakpoint()[2] !== 'phone') {
                        channels.showText(channel, reason, null);
                    }
                });
                SSGame.current.nodes.body.effect('shake', { distance: cfg.amount, times: cfg.times });
                SSGame.current.board.board.css('backgroundColor', '#FF0000')
                    .delay(cfg.stayRedDuration)
                    .transit({
                        backgroundColor: balls.boardColor
                    }, cfg.fadeBackDuration);
                balls.animations.bounce(ballNode, false, 'up');
            },
            bounce: function(ballNode, decrement, dir) {
                var cfg = SSGame.current.config.ballBounceConfig;
                if(decrement) channels.showText(ballNode.data('channel'), '-1', '#FF0000');
                var ctr = SSGame.current.nodes.body;
                var ballHeight = ballNode.height();
                //Get the ball offset and the board offset, then figure out the relative distance
                var ballOffset = ballNode.offset();
                var boardOffset = ctr.offset();
                var newPos = {
                    top: ballOffset.top - boardOffset.top,
                    left: ballOffset.left - boardOffset.left
                };
                //Move the ball to the body so it's not obsured by the channel
                ctr.append(ballNode);
                //Jump it up so it starts animating slightly above the channel bottomto avoid occlusion
                ballNode.stop().data('stopped', true);
                ballNode.css({
                    top: channels.bottomRelative - ballHeight - 8,
                    left: newPos.left,
                    zIndex: 999
                });
                //Then roll it around
                var t = channels.bottom - (ballHeight * 2) - 20;
                var anim = {
                    top: '-=' + (ballHeight * 3),
                    scale: 1.5,
                    opacity: 0,
                };
                if(dir == 'right') {
                    anim.left = '+=' + cfg.horizontalDistance;
                    anim.rotate = '+=' + cfg.rotationAmount + 'deg';
                } else if(dir == 'left') {
                    anim.left = '-=' + cfg.horizontalDistance;
                    anim.rotate = '-=' + cfg.rotationAmount + 'deg';
                }
                ballNode.transition(anim, cfg.duration, function() {
                    balls.remove($(this));
                });
            }
        }
    };
    function makeBall(cls, radiusSet, ballType, spritePos) { 
        var game = SSGame.current;
        var bp = game.board.getCurrentBreakpoint();
        var radius = (bp[2] == 'phone') ? radiusSet[1] : radiusSet[0];
        var bgOffset = spritePos * radius;
        return $('<div></div>')
            .addClass('ball')
            .addClass(cls)
            .css({
                width: radius,
                height: radius,
                backgroundPosition: (bgOffset * -1) + 'px 0'
            })
            .data('type', ballType)
        ;
    };
    function dropBallDownChannel(ballNode, channelIdx, speed) {
        var game = SSGame.current;
        var channelNode = channels.getAt(channelIdx);
        var channelWidth = channelNode.outerWidth();
        var ballWidth = ballNode.width()
        ballNode.css({
            top: ballWidth * -1
        });
        ballNode.data('channel', channelIdx);
        balls.balls[channelIdx * 1] = ballNode;
        channelNode.find('.inner_channel').append(ballNode);

        //The drop speed is optimized for a 225px high channel.  Figure out the relative speed.
        var fixedSpeed = Math.floor(speed * ((channels.height / 4) / channels.height));
        //Next, since we drop 900px to accommodate size changes, bump the speed up accordingly.
        fixedSpeed = Math.floor(fixedSpeed * 4);
        //console.log('Speed of %s adjusted to %s to accommodate column height of %s and 900px drop', speed, fixedSpeed, channelNode.outerHeight());

        var animShim = $({frame: 0});
        var target = channels.height;
        animShim.animate({
            frame: target
        }, {
            duration: fixedSpeed,
            easing: 'linear',
            step: function(now, tween) {
                //This strategy prevents stop() from working, so we need to do it manually.
                if(ballNode.data('stopped')) {
                    animShim.stop();
                } else {
                    var newPos = this.frame - ballWidth;
                    //if(Math.round(this.frame % 50) == 0) console.log(this.frame, newPos, channels.height, cutoff);
                    var d = 0;
                    var cutoff = channels.height - ballWidth + 30; //The 30 is a fudge
                    if(this.frame > cutoff) {
                        d =  (this.frame - cutoff);
                        d = d * d / 2;
                    }
                    newPos += d;
                    ballNode.css('top', newPos);
                }
            },
            progress: function(animation, progress, remainingTime) {
                balls.checkStatus(ballNode);
            },
            complete: function() {
                balls.checkStatus(ballNode);
                balls.remove(ballNode);
            }
        });
    }
    var score = {
        val: 0,
        node: null,
        decrementToggle: false,
        init: function() {
            var game = SSGame.current;
            score.node = $('<div></div>');
            game.nodes.score.append(score.node);
            this.reset();
        },
        reset: function() {
            var game = SSGame.current;
            score.set(0);
            this.decrementToggle = false;
            game.nodes.body.find('.scoreMarker').remove();
        },
        increment: function() {
            score.set(score.val + 1);
        },
        decrement: function(why) {
            //score.wrong(why);
            score.set(score.val - 1);
        },
        set: function(i) {
            score.node.text('Score: ' + i);
            score.val = i;
            if(i < 0) score.node.css('color', 'red');
            else if(i > 0) score.node.css('color', 'green');
            else score.node.css('color', '');
        }
    };
    var state = {
        rules: null,
        second: null,
        tick: null,
        prompt: null,
        balls: null,
        ballChances: 0,
        ballChanceMax: 0,
        nextDrop: null,
        rate: null,
        speed: null,
        scoring: null,
        everyOther: false,
        everyOtherToggle: false,
        done: false,
        paused: false,
        init: function() {
            var game = SSGame.current;
            state.rules = game.config.rules;
        },
        reset: function() {
            this.second = null;
            this.tick = null;
        },
        getAll: function(set) {
            var i, n, retVal = [];
            for(i = 0; i < set.length; i ++) {
                n = set[i];
                if(n.start <= this.second && n.stop >= this.second) {
                    retVal.push(n);
                }
            }
            return retVal;
        },
        getLatest: function(set) {
            var filtered = this.getAll(set);
            var n, retVal = null;
            for(var i = 0; i < filtered.length; i ++) {
                n = filtered[i];
                if(!retVal || retVal.start <= n.start) {
                    if(retVal && retVal.start == n.start) {
                        if(n.stop < retVal.stop) {
                            continue;
                        }
                    }
                    retVal = n;
                }
            }
            return retVal;
        },
        onTick: function() {
            this.regen();
            if(this.prompt) {
                var promptMethod = (this.prompt.promptMethod) ? this.prompt.promptMethod : 'random';
                showPrompt(this.prompt.text, this.prompt.audio, SSGame.current.config.promptDuration, promptMethod);
                this.promptShown(this.prompt);
            }
            if(!this.paused && this.canDrop()) {
                balls.drop();
            }
        },
        regen: function() {
            var game = SSGame.current;
            this.tick = new Date().getTime();
            var currentSecond = Math.floor((this.tick - game.started) / 1000);
            if(this.second === null || currentSecond != this.second) {
                this.second = currentSecond;
                this.balls = this.getAll(this.rules.drops);
                this.rate = this.getLatest(this.rules.rates);
                if(this.rate) this.rate = this.rate.rate;
                this.speed = this.getLatest(this.rules.speeds);
                if(this.speed) this.speed = this.speed.speed;
                //Calculate ball drop chances
                var chances = {};
                var chanceMax = 0;
                for(var i = 0; i < this.balls.length; i ++) {
                    chanceMax += this.balls[i].weight;
                    chances[chanceMax] = this.balls[i];
                };
                this.ballChances = chances;
                this.ballChanceMax = chanceMax;

                //These used to be seperate configs, so this is a bit of a kludge
                this.scoring = this.getLatest(this.rules.scoring);
                //Only establish a prompt if it hasn't been shown and if there's one to show
                if(this.scoring['prompted'] || (!this.scoring['text'] && !this.scoring['audio'])) {
                    this.prompt = null;
                } else {
                    this.prompt = $.extend({}, this.scoring);
                }

                if(this.scoring) {
                    //Special rule: every other valid must be missed, reset if false
                    this.everyOther = this.scoring.everyOther === true;
                    if(!this.everyOther) this.everyOtherToggle = false;

                    this.scoring = this.scoring.valid;
                }

                this.done = this.balls.length == 0 || !this.rate || !this.speed || !this.scoring;
            }
        },
        promptShown: function(prompt) {
            this.prompt = null;
            var i, p, found = false;
            for(i = 0; i < this.rules.scoring.length; i ++) {
                p = this.rules.scoring[i];
                if(prompt.text == p.text && prompt.start == p.start && prompt.stop == p.stop) {
                    found = true;
                    break;
                }
            }
            if(found) this.rules.scoring[i].prompted = true;
            else console.error('No prompt found to remove!: %s, %o, %o', i, prompt, this.rules.messages);
        },
        pickBall: function() {
            var objCfg = null;
            var roll = SSGame.rnd(0, this.ballChanceMax);
            for(var key in this.ballChances) {
                if(key > roll) {
                    objCfg = this.ballChances[key];
                    break;
                }
            }
            return objCfg;
        },
        canDrop: function() {
            return (!this.nextDrop || this.nextDrop < this.tick);
        },
        dropped: function() {
            this.nextDrop = this.tick + SSGame.rnd(this.rate[0], this.rate[1]);
        },
        ballValid: function(ballNode) {
            var ballType = ballNode.data('type');
            var valid = false;
            for(var i = 0; i < state.scoring.length; i ++) {
                if(state.scoring[i] == ballType) {
                    valid = true;
                    break;
                }
            }
            if(this.everyOther && valid && !this.everyOtherToggle) {
                console.log('Every other rule break');
                valid = false;
            }
            return valid;
        }
    };
    function showPrompt(text, audio, speed, promptMethod) {
        var game = SSGame.current;
        if($('.executive_game_prompt').length > 0) return;
        text = game.getText(text);
        if(audio) {
            var strategy = null;
            switch(promptMethod) {
                case 'both':
                    strategy = 0;
                    break;
                case 'random':
                    strategy = SSGame.rnd(0, 3);
                    break;
            }
            var play = false;
            switch(strategy) {
                case 0:
                    //Audio and text
                    play = true;
                    break;
                case 1:
                    //Just audio
                    play = true;
                    text = '(listen)';
                    break;
                case 2:
                    //Just text
                    break;
            }
            if(play) {
                game.playVO(audio);
            }
        }
        var p = $('<div></div>').addClass('executive_game_prompt');
        var pIn = $('<div></div>').addClass('executive_game_prompt_inner').html([
                '<p>', text, '</p>'].join(''));
        p.append(pIn);
        SSGame.current.nodes.body.append(p);
        var pH = p.height();
        var pInH = pIn.height();
        pIn.css('marginTop', Math.floor((pH - pInH) / 2));
        setTimeout(function() {
            p.animate({ opacity: 0}, 'fast', function() { p.remove(); });
        }, speed);
    };
    window.ExecutiveGameLib = {
        channels: channels,
        trap: trap,
        balls: balls,
        score: score,
        state: state,
        showPrompt: showPrompt
    };
})();
