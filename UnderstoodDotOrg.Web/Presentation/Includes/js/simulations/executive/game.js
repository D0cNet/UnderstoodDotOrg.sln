(function() {

    window.ExecutiveGame = SSGame.extend({
        maxChannels: 0,
        currentLevel: 0,
        firstDropped: false,
        pause: function() {
            for(var idx in this.lib.balls.balls) {
                this.lib.balls.balls[idx].pause();
            }
            this.lib.trap.nodes.pause();
            this.timer.pause();
            this.lib.state.paused = true;
        },
        resume: function() {
            for(var idx in this.lib.balls.balls) {
                this.lib.balls.balls[idx].resume();
            }
            this.lib.trap.nodes.resume();
            this.timer.resume();
            this.lib.state.paused = false;
        },
        init: function() {
            this._super('ExecutiveGame', null);
        },
        draw: function() {
            this._super({
                timer: 'SSGame_timer',
                body: 'executive_board',
                score: 'executive_score'
            });
        },
        loadSounds: function() {
            var effectRoot = '/Presentation/includes/audio/simulations/executive/effects/';
            var voRoot = '/Presentation/includes/audio/simulations/executive/vo/%lang%/';
            this._super({
                caughtwrong: effectRoot + 'Executive_CaughtIncorrectShape',
                pickcolumn: effectRoot + 'Executive_ColumnSelect',
                missedright: effectRoot + 'Executive_MissedItem',
                bounce: effectRoot + 'Executive_ObjectHitsBar',
                caughtright: effectRoot + 'Executive_PointAwarded'
            }, {
                backgroundTrack: voRoot + 'backgroundTrack',
                avoidEverything: voRoot + 'avoidEverything',
                catchAllShapes: voRoot + 'catchAllShapes',
                catchEveryOtherCircle: voRoot + 'catchEveryOtherCircle',
                catchEveryOtherSquare: voRoot + 'catchEveryOtherSquare',
                catchEveryOtherTriangle: voRoot + 'catchEveryOtherTriangle',
                catchEverything: voRoot + 'catchEverything',
                catchOnlyCirclesAndHearts: voRoot + 'catchOnlyCirclesAndHearts',
                catchOnlyCirclesAndSquares: voRoot + 'catchOnlyCirclesAndSquares',
                catchOnlyCirclesAndTriangles: voRoot + 'catchOnlyCirclesAndTriangles',
                catchOnlyCircles: voRoot + 'catchOnlyCircles',
                catchOnlyHearts: voRoot + 'catchOnlyHearts',
                catchOnlySquaresAndHearts: voRoot + 'catchOnlySquaresAndHearts',
                catchOnlySquaresAndTriangles: voRoot + 'catchOnlySquaresAndTriangles',
                catchOnlySquares: voRoot + 'catchOnlySquares',
                catchOnlyTriangles: voRoot + 'catchOnlyTriangles',
                catchOnlyTrianglesAndHearts: voRoot + 'catchOnlyTrianglesAndHearts',
                catchOnlyTriangles: voRoot + 'catchOnlyTriangles',

                catchOnlySquaresAndCircles: voRoot + 'catchOnlySquaresAndCircles',
                catchOnlyTrianglesAndCircles: voRoot + 'catchOnlyTrianglesAndCircles'
            });
        },
        setSize: function() {
            var bp = SSGame.current.board.getCurrentBreakpoint();
            this.bodySize = [this.nodes.body.outerWidth(), this.nodes.body.outerHeight()];
            this.maxChannels = 6; //Used to change on smaller screens, now fixed.
            if(this.lib) {
                this.lib.channels.updateSize(bp);
                this.lib.trap.updateSize(bp);
            }
        },
        reset: function() {
            this._super();
            SSGameModal.intro(this, $.proxy(function() {
                if(this.isAudioLimited) this.playVO('backgroundTrack', true);
            }, this));
            this.lib.balls.reset();
            this.currentLevel = 0;
            this.firstDropped = false;
            this.lib.state.reset();
            this.timer.reset();
            this.lib.channels.reset();
            this.lib.trap.reset();
            this.lib.score.reset();
            this.started = new Date().getTime();
            clearInterval(this.interval);
            this.interval = null;
        },
        start: function() {
            this.timer.start();
            this.started = new Date().getTime();
            this.lib.state.onTick();
            this.interval = setInterval($.proxy(function() {
                this.lib.state.onTick();
                if(this.lib.state.done) {
                    this.stop();
                }
            }, this), 50);
            this.events.trigger('start');
        },
        stop: function() {
            this.timer.stop();
            var success = this.lib.score.val > 0;
            if(success) {
                this.playSound('gameOverSuccess', false)
            } else {
                this.playSound('gameOverFail', false);
            }
            SSGameModal.outro(this, false);
            this.lib.trap.nodes.stop();
            this.lib.balls.reset();
            clearInterval(this.interval);
            this.interval = null;
            this.events.trigger('stop');
        },
        run: function(localCfg) {
            if(!this._super(localCfg)) return;
            this.setSize();
            this.lib = ExecutiveGameLib;
            this.board.board.on('breakpointChange', $.proxy(this.setSize, this));
            this.lib.channels.init();
            this.lib.trap.init();
            this.lib.score.init();
            this.lib.state.init();
            this.lib.balls.init();
            this.timer = new SSGameTimer({
                container: this.nodes.timer,
                maxTime: this.config.timeInSeconds,
                soundLag: this.config.timerSoundDelay,
            });
            this.reset();
            //Cheater!!
            this.addCheat(
                $('<button></button>')
                    .attr('type', 'button')
                    .text('+5 seconds')
                    .click($.proxy(function() {
                        $.each(this.balls, function(channel, ball) {
                            ball.remove();
                        });
                        this.balls = {};
                        this.started -= 5000;
                    }, this))
            );
        }
   });
    SSGame.current = new ExecutiveGame();
})();
