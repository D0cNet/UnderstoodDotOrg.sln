/*
 * jQuery UI Touch Punch 0.2.2
 *
 * Copyright 2011, Dave Furfero
 * Dual licensed under the MIT or GPL Version 2 licenses.
 *
 * Depends:
 *  jquery.ui.widget.js
 *  jquery.ui.mouse.js
 */

(function(b){b.support.touch="ontouchend" in document;if(!b.support.touch){return;}var c=b.ui.mouse.prototype,e=c._mouseInit,a;function d(g,h){if(g.originalEvent.touches.length>1){return;}g.preventDefault();var i=g.originalEvent.changedTouches[0],f=document.createEvent("MouseEvents");f.initMouseEvent(h,true,true,window,1,i.screenX,i.screenY,i.clientX,i.clientY,false,false,false,false,0,null);g.target.dispatchEvent(f);}c._touchStart=function(g){var f=this;if(a||!f._mouseCapture(g.originalEvent.changedTouches[0])){return;}a=true;f._touchMoved=false;d(g,"mouseover");d(g,"mousemove");d(g,"mousedown");};c._touchMove=function(f){if(!a){return;}this._touchMoved=true;d(f,"mousemove");};c._touchEnd=function(f){if(!a){return;}d(f,"mouseup");d(f,"mouseout");if(!this._touchMoved){d(f,"click");}a=false;};c._mouseInit=function(){var f=this;f.element.bind("touchstart",b.proxy(f,"_touchStart")).bind("touchmove",b.proxy(f,"_touchMove")).bind("touchend",b.proxy(f,"_touchEnd"));e.call(f);};})(jQuery);
(function() {

    var critters = {
        types: [
            'monkey', 'elephant', 'shark',
            'rhino', 'bird', 'snake',
            'kangaroo', 'octopus', 'camel'
        ]
    };

    var grid = {
        game: null,
        cfg: null,
        panels: {},
        init: function(game, cfg) {
            this.game = game;
            this.cfg = cfg;
        },
        draw: function() {
            var i, critter, panel;
            for(i = 0; i < 9; i ++) {
                critter = critters.types[i];
                panel = $('<div></div>')
                    .addClass('panel panel_' + critter)
                    .data('panel', critter);
                this.panels[critter] = panel;
                this.game.nodes.grid.append(panel);
            }
        },
        reset: function() {
        }

    };

    var pieces = {
        minZ: 2,
        game: null,
        cfg: null,
        pieces: [],
        gridBoundary: null, //Only needed for phone
        init: function(game, cfg) {
            this.game = game;
            this.cfg = cfg;
        },
        setGridBoundary: function() {
            this.gridBoundary = this.getBound(this.game.nodes.grid);
        },
        getBound: function(n) {
            var off = n.offset(), w = n.width(), h = n.height();
            return [
                [off.left, off.top], [off.left + w, off.top],
                [off.left, off.top + h], [off.left + w, off.top + h]
            ]
        },
        cmpPoint: function(b1, b2) {
            var retVal = [];
            for(var i = 0; i < b1.length; i ++) {
                retVal.push([
                    b2[i][0] - b1[i][0],
                    b2[i][1] - b1[i][1]
                ]);
            }
            return retVal;
        },
        inGrid: function(n) {
            var bound = this.getBound(n);
            var d = this.cmpPoint(this.gridBoundary, bound);

            //0 would make it need to be 100% inside to count.
            var pslop = 50;
            var nslop = pslop * -1;
            return true &&
                //Top-left should both be +
                d[0][0] >= nslop && d[0][1] >= nslop &&
                //Top-right should be - +
                d[1][0] <= pslop && d[1][1] >= nslop &&
                //Bottom-left should be + -
                d[2][0] >= nslop && d[2][1] <= pslop &&
                //Bottom-right should both be -
                d[3][0] <= pslop && d[3][1] <= pslop
                ;
        },
        deal: function() {
            this.game.playSound('deal');
            var types = critters.types.slice();
            SSGame.shuffle(types);
            this.setGridBoundary();
            var ctrDim = {
                width: this.game.nodes.pieces1.width(),
                height: this.game.nodes.pieces1.height()
            };
            var layout = this.game.board.getCurrentBreakpoint()[2];
            if(layout == 'phone') this.dealPhone(types, ctrDim);
            else this.dealStandard(types, ctrDim);
            this.pieces = this.game.board.board.find('.piece');
        },
        dealPhone: function(types, ctrDim) {
            var ctr = this.game.nodes.pieces1;
            var ctrHorizCenter = ctrDim.width / 2;
            var pieceSpec = { width: 50, height: 50 };
            var padding = 5;
            var i, lPos, lOff, animDir, moveTo, moveFrom;
            for(i = 0; i < types.length; i ++) {
                lPos = (i <= 4) ? i : i - 5;
                lOff = (i <= 4) ? 0 : pieceSpec.width / 2;
                moveTo = {
                    top: (i <= 4) ? 0 : pieceSpec.height + padding,
                    left: lOff + (lPos * pieceSpec.width) + (lPos * padding)
                };
                moveFrom = {
                    top: 200,
                    left: ctrHorizCenter - (((moveTo.left + (pieceSpec.width / 2)) - ctrHorizCenter) * 5)
                };
                this.place(types[i], moveFrom, moveTo, this.minZ + i, ctr);
            }
        },
        dealStandard: function(types, ctrDim) {
            var i, ctr, animDir, moveTo, moveFrom;
            var pieceSpec = { width: 108, height: 108 };
            var pieceSpecs = [];
			var pieces1 = [];
			var pieces2 = [];
			var activePieces;
			var rows;
            for(i = 0; i < types.length; i ++) {
                if(i < types.length / 2) {
                    ctr = this.game.nodes.pieces1;
                    animDir = 1;
					activePieces = pieces1;
					rows = 5;
                } else {
                    ctr = this.game.nodes.pieces2;
                    animDir = -1;
					activePieces = pieces2;
					rows = 4;
                }
                moveTo = SSGame.getRandomPosition(pieceSpec, activePieces, ctrDim, 'some',rows,1);
				activePieces.push(pieceSpec);
                //Start 10x away in the same direction as the offset from center
                moveFrom = {
                    left: (0 - (ctrDim.width / 2) + moveTo.left) * 10 * animDir,
                    top: (0 - (ctrDim.height / 2) + moveTo.top) * 10 * animDir
                };
                this.place(types[i], moveFrom, moveTo, this.minZ + i, ctr);
            }
        },
        place: function(type, moveFrom, moveTo, z, ctr) {
            //console.log('From %o to %o in %s', moveFrom, moveTo, ctr.attr('id'));
            var piece = $('<div></div>')
                .addClass('piece piece_' + type)
                .draggable({
                    containment: this.game.board.board,
                    snap: '.panel',
                    snapMode: 'inner',
                    stack: '.piece',
                    drag: $.proxy(this.phoneDragResize, this),
                    start: $.proxy(function(e) {
                        this.game.playSound('pickup');
                    }, this),
                    stop: $.proxy(function(e) {
                        this.game.playSound('placed');
                        this.phoneDragResize(e);
                    }, this)
                })
                .css({
                    position: 'absolute', //Draggable resets this
                    left: moveFrom.left,
                    top: moveFrom.top,
                    zIndex: z
                })
                .animate(moveTo, 'slow');
            ctr.append(piece);
        },
        phoneDragResize: function(e, ui) {
            var n = $(e.target);
            if(this.inGrid(n)) {
                n.addClass('over_grid');
            } else {
                n.removeClass('over_grid');
            }
        },
        toggleFace: function() {
            this.game.playSound('solved');
            var pieceW = this.pieces.first().outerWidth();
            var animIn = (this.game.canUse3d) ? { rotateY: '90deg' } : { width: 0, marginLeft: (pieceW / 2) };
            var animOut = (this.game.canUse3d) ? { rotateY: '0deg' } : { width: pieceW, marginLeft: 0 };
            $(this.pieces).animate(animIn, 'slow', $.proxy(function() {
                this.pieces
                    .toggleClass('back_visible')
                    .animate(animOut);
            }, this));
        }
    };

    window.AttentionGame = SSGame.extend({
        success: null,
        timer: null,
        started: false,
        init: function() {
            this._super('AttentionGame', null);
            grid.init(this, this.cfg);
            pieces.init(this, this.cfg);
        },
        reset: function() {
            this._super();
            var intro = new SSGameModal({
                showDuration: this.config.introDurationInSeconds * 1000,
                title: this.getText(this.config.title),
                text: SSGameModal.textToParagraphs(this.config.introText),
            });
            intro.setButtons([{
                text: 'Start',
                click: function() {
                    intro.close();
                    SSGame.current.start();
                }

            }]);
            intro.open();
            this.started = false;
        },
        draw: function() {
            this._super({
                grid: 'attention_grid',
                pieces1: 'attention_pieces1',
                pieces2: 'attention_pieces2'
            });
            grid.draw();
        },
        loadSounds: function() {
            var effectRoot = '/Presentation/includes/audio/simulations/attention/effects/';
            var voRoot = '/Presentation/includes/audio/simulations/attention/vo/%lang%/'
            this._super({
                deal: effectRoot + 'Attention_Cards_In_Play',
                solved: effectRoot + 'Attention_Flipping_Cards',
                pickup: effectRoot + 'Attention_Object_Pick_Up',
                placed: effectRoot + 'Attention_Object_Put_Down'
            }, {
                instructions: voRoot + 'instructions'
            });
        },
        start: function() {
            this.events.trigger('start');
            this.started = true;
            pieces.deal();
            this.playVO('instructions', {
                ended: $.proxy(function() {
                    pieces.toggleFace();
                    setTimeout($.proxy(function() {
                        this.stop();
                    }, this), this.config.timing.pauseBeforeStopDialog);
                }, this)
            });
        },
        stop: function() {
            var done = new SSGameModal({
                showDuration: 0,
                text: this.getText(this.config.finalText)
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
            console.log('Stopped');
            this.events.trigger('stop');
        },
        run: function(localCfg) {
            if(!this._super(localCfg)) return;
            this.reset();
            this.addCheat($('<button></button').text('Show backs').click($.proxy(function(e) {
                e.preventDefault();
                pieces.toggleFace();
                var newText = ($(this).text() == 'Show backs') ? 'Show fronts' : 'Show backs';
                $(this).text(newText);
            }, this)));
        }
    });

    SSGame.current = new AttentionGame();
})();
