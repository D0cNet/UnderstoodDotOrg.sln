/* Simple JavaScript Inheritance By John Resig http://ejohn.org/ MIT Licensed. */

(function(){var initializing=false,fnTest=/xyz/.test(function(){xyz})?/\b_super\b/:/.*/;this.Class=function(){};Class.extend=function(prop){var _super=this.prototype;initializing=true;var prototype=new this();initializing=false;for(var name in prop){prototype[name]=typeof prop[name]=="function"&&typeof _super[name]=="function"&&fnTest.test(prop[name])?(function(name,fn){return function(){var tmp=this._super;this._super=_super[name];var ret=fn.apply(this,arguments);this._super=tmp;return ret}})(name,prop[name]):prop[name]}function Class(){if(!initializing&&this.init)this.init.apply(this,arguments)}Class.prototype=prototype;Class.prototype.constructor=Class;Class.extend=arguments.callee;return Class}})();
/*! sprintf.js | Copyright (c) 2007-2013 Alexandru Marasteanu <hello at alexei dot ro> | 3 clause BSD license */
(function(e){function r(e){return Object.prototype.toString.call(e).slice(8,-1).toLowerCase()}function i(e,t){for(var n=[];t>0;n[--t]=e);return n.join("")}var t=function(){return t.cache.hasOwnProperty(arguments[0])||(t.cache[arguments[0]]=t.parse(arguments[0])),t.format.call(null,t.cache[arguments[0]],arguments)};t.format=function(e,n){var s=1,o=e.length,u="",a,f=[],l,c,h,p,d,v;for(l=0;l<o;l++){u=r(e[l]);if(u==="string")f.push(e[l]);else if(u==="array"){h=e[l];if(h[2]){a=n[s];for(c=0;c<h[2].length;c++){if(!a.hasOwnProperty(h[2][c]))throw t('[sprintf] property "%s" does not exist',h[2][c]);a=a[h[2][c]]}}else h[1]?a=n[h[1]]:a=n[s++];if(/[^s]/.test(h[8])&&r(a)!="number")throw t("[sprintf] expecting number but found %s",r(a));switch(h[8]){case"b":a=a.toString(2);break;case"c":a=String.fromCharCode(a);break;case"d":a=parseInt(a,10);break;case"e":a=h[7]?a.toExponential(h[7]):a.toExponential();break;case"f":a=h[7]?parseFloat(a).toFixed(h[7]):parseFloat(a);break;case"o":a=a.toString(8);break;case"s":a=(a=String(a))&&h[7]?a.substring(0,h[7]):a;break;case"u":a>>>=0;break;case"x":a=a.toString(16);break;case"X":a=a.toString(16).toUpperCase()}a=/[def]/.test(h[8])&&h[3]&&a>=0?"+"+a:a,d=h[4]?h[4]=="0"?"0":h[4].charAt(1):" ",v=h[6]-String(a).length,p=h[6]?i(d,v):"",f.push(h[5]?a+p:p+a)}}return f.join("")},t.cache={},t.parse=function(e){var t=e,n=[],r=[],i=0;while(t){if((n=/^[^\x25]+/.exec(t))!==null)r.push(n[0]);else if((n=/^\x25{2}/.exec(t))!==null)r.push("%");else{if((n=/^\x25(?:([1-9]\d*)\$|\(([^\)]+)\))?(\+)?(0|'[^$])?(-)?(\d+)?(?:\.(\d+))?([b-fosuxX])/.exec(t))===null)throw"[sprintf] huh?";if(n[2]){i|=1;var s=[],o=n[2],u=[];if((u=/^([a-z_][a-z_\d]*)/i.exec(o))===null)throw"[sprintf] huh?";s.push(u[1]);while((o=o.substring(u[0].length))!=="")if((u=/^\.([a-z_][a-z_\d]*)/i.exec(o))!==null)s.push(u[1]);else{if((u=/^\[(\d+)\]/.exec(o))===null)throw"[sprintf] huh?";s.push(u[1])}n[2]=s}else i|=2;if(i===3)throw"[sprintf] mixing positional and named placeholders is not (yet) supported";r.push(n)}t=t.substring(n[0].length)}return r};var n=function(e,n,r){return r=n.slice(0),r.splice(0,0,e),t.apply(null,r)};e.sprintf=t,e.vsprintf=n})(typeof exports!="undefined"?exports:window);
if(!window.console) {
    window.console = { log: function(){}, error: function(){}, dir: function(){} };
}
/* 3D support test: http://stackoverflow.com/questions/5661671/detecting-transform-translate3d-support/12621264#12621264 */
function has3d(){var e=document.createElement("p"),t,n={webkitTransform:"-webkit-transform",OTransform:"-o-transform",msTransform:"-ms-transform",MozTransform:"-moz-transform",transform:"transform"};document.body.insertBefore(e,null);for(var r in n){if(e.style[r]!==undefined){e.style[r]="translate3d(1px,1px,1px)";t=window.getComputedStyle(e).getPropertyValue(n[r])}}document.body.removeChild(e);return t!==undefined&&t.length>0&&t!=="none"}

(function() {

    /**
     * Manage the nodes that the game resides in 
     */
    var Gameboard = Class.extend({
        /**
         * The outer shell of the board
         */
        boardContainer: null,
        /**
         * Selector for the inner shell of the board
         */
        boardSelector: '#gameboard',
        /**
         * The inner shell of the board
         */
        board: null,
        /**
         * Which breakpoint is being used (idx, not values) 
         */
        currentBreakpointIndex: null,
        /**
         * Which class defines the current breakpoint
         */
        currentBreakpointClass: '',
        /**
         * Possible gameboard sizes.  We use the one that best fits the container size.
         * [board_width, board_height, name, [dialog_width, dialog_height]]
         */
        breakpoints: [
            [950,534, 'desktop', [ 510, 330 ]], //Desktop
            [768,432, 'tablet', [ 510, 330 ]], //Big tablet
            [320,416, 'phone', [ 300, 400 ]]
        ],
        /**
         * Get the current breakpoint settings
         */
        getCurrentBreakpoint: function() {
            return this.breakpoints[this.currentBreakpointIndex];
        },
        /**
         * Adjust the gameboard size to the closest breakpoint and alert listeners if the size changes
         */
        sizeToFit: function() {
            var ctrsize = [Math.ceil(this.boardContainer.outerWidth()), Math.ceil(this.boardContainer.outerHeight())];
            //Starting at the smallest breakpoint, find largest game size that'll hold our game
            var target = this.breakpoints[this.breakpoints.length - 1];
            var idx = null;
            $.each(this.breakpoints, function(i, bp) {
                //If we care about width & height...
                //if(ctrsize[0] >= bp[0] && ctrsize[1] >= bp[1]) {
                if(ctrsize[0] >= bp[0]) {
                    idx = i;
                    target = bp;
                    return false;
                }
            });
            console.log('Board now %sx%s, new target breakpoint %s is %sx%s',
                    ctrsize[0],
                    ctrsize[1],
                    idx,
                    target[0],
                    target[1]
                    );
            this.board.width(target[0]);
            this.board.height(target[1]);
            //Do a little CSS vertical centering
            var vmarg = Math.floor((ctrsize[1] - target[1]) / 2) + 'px';
            this.board.css({ marginTop: vmarg, marginBottom: vmarg });
            var cls = 'breakpoint_' + target[2];
            this.board.removeClass(this.currentBreakpointClass);
            this.board.addClass(cls);
            this.currentBreakpointClass = cls;

            if(idx != this.currentBreakpointIndex) {
                this.board.trigger('breakpointChange', [idx, target]);
                this.currentBreakpointIndex = idx;
            }
        },
        /**
         * Set up our gameboard
         */
        init: function() {
            this.board = $(this.boardSelector);
            if(!this.board) {
                console.error('No gameboard found');
                return;
            }
            this.boardContainer = this.board.parent();
            //We now only do this once
            //this.boardContainer.resize($.proxy(this.sizeToFit, this));
        }
    });

    window.SSGame = Class.extend({
        /**
         * An instance of the current Gameboard 
         */
        board: null,
        /**
         * Name of the game (defined by child classes)
         */
        name: '',
        /**
         * Named nodes important to the game's operation
         */
        nodes: null,
        /**
         * A pre-page-load list of subselectors to map out when the game first runs 
         */
        nodeMap: null,
        /**
         * Container for the events our simulation tracks 
         */
        events: null,
        /**
         * True if the current browser supports 3d transforms
         */
        canUse3d: false,
        /**
         * Initialize the game.
         * Note that Class only uses init()...the child class must call this parent using init(name)
         */
        init: function(name, nodes) {
            this.name = name;
            this.board = new Gameboard();
            this.events = $({});
            this.events.on('start', function() { console.log('Start triggered') });
            this.events.on('stop', function() { console.log('Stop triggered') });
            this.events.on('initialized', $.proxy(function() { console.log(this.name + ' initialized') }, this));
            this.events.on('moveon', function() { console.log('Stop triggered') });
            this.events.trigger('initialized');
            this.board.board.css('visibility', 'hidden');
            this.nodeMap = nodes;
        },
        draw: function(newIds) {
            var ctr = $('#gameboard');
            this.nodes = {};
            $.each(newIds, $.proxy(function(key, id) {
                this.nodes[key] = $('<div></div>').attr('id', id);
                ctr.append(this.nodes[key]);
            }, this));
        },
        /**
         * Start the game
         */
        run: function(localCfg) {
            if(!localCfg) localCfg = {};
            console.log('Running SSGame %s, local config %o', this.name, localCfg);
            this.board.sizeToFit();
            if(this.bindConfig(localCfg)) {
                this.canUse3d = has3d();
                if(!this.nodeMap) {
                    this.draw(); //@TODO Get rid of the check once all games are converted
                } else {
                    this.mapNodes();
                }
                this.board.board.css('visibility', '');
                this.addCheat($('<button></button').text('Reset').click($.proxy(function(e) {
                    e.preventDefault();
                    this.reset();
                }, this)));
                return true;
            } else {
                return false;
            }
        },
        reset: function() {
            SSGameModal.destroyAll();
        },
        /**
         * Hook confguration elements up to the game
         */
        bindConfig: function(localCfg) {
            var globalKey = this.name + 'Config';
            if(!window[globalKey]) {
                console.error('No config found for %s', this.name);
                return false;
            } else {
                this.config = $.extend(true, {}, window[globalKey], localCfg);
                return true;
            }
        },
        /**
         * Build our standing list of nodes important to the game 
         */
        mapNodes: function() {
            if(!this.nodes) {
                console.log('Napping nodes from %o', this.nodeMap);
                this.nodes = {};
                $.each(this.nodeMap, $.proxy(function(name, sel) {
                    this.nodes[name] = this.board.board.find(sel);
                    if(!this.nodes[name]) console.error('Node %s not found (%s)', name, sel);
                }, this));
            }
        },
        addCheat: function(n) {
            $('#gameboard_cheats').append(n);
        }
    });
    //Give our base class some static properties
    $.extend(window.SSGame, {
        /**
         * This gets set to the current game inside that game's definition file 
         */
        current: null,
        /**
         * Pick a random number in range
         */
        rnd: function(min, max) {
            if(typeof max === 'object') {
                max = max.length;
            }
            return Math.floor(Math.random() * (max - min)) + min;
        },
        /**
         * Pick an element from an array, ignoring certain elements if necessary.
         */
        pick: function(arr, exclude) {
            exclude.sort();
            var len = arr.length - exclude.length;
            var idx = SSGame.rnd(0, len);
            var orig = idx;
            for(var i = 0; i < exclude.length; i ++) {
                if(exclude[i] <= idx) idx ++;
            }
            //console.log('Choose idx %s from %o excluding %o.  Final: %s', orig, arr, exclude, idx);
            if(idx >= arr.length) return null;
            else return arr[idx];
        },
        /**
         * Randomly organize an array
         */
        shuffle: function(array) {
            var currentIndex = array.length
                , temporaryValue
                , randomIndex
                ;

            // While there remain elements to shuffle...
            while (0 !== currentIndex) {
                // Pick a remaining element...
                randomIndex = Math.floor(Math.random() * currentIndex);
                currentIndex -= 1;

                // And swap it with the current element.
                temporaryValue = array[currentIndex];
                array[currentIndex] = array[randomIndex];
                array[randomIndex] = temporaryValue;
            }

            return array;
        }
    });
    
    /**
     * Manage success states of the game in the form of open boxes that are checked off on success
     */
    window.SSGameSuccess = Class.extend({
        responseUnknownClass: '',
        responseCorrectClass: 'correct',
        correct: 0,
        count: 0,
        cfg: null,
        ctr: null,
        init: function(cfg) {
            this.cfg = cfg;
            this.ctr = cfg.node;
            this.count = cfg.count;
            for(var i = 0; i < cfg.count; i ++) {
                if(cfg.numbers) {
                    this.ctr.append($('<span></span>').addClass('response').text(i + 1));
                    this.responseUnknownClass = 'unknown';
                    this.responseCorrectClass = 'correct';
                } else {
                    this.ctr.append($('<span></span>')
                       .addClass('response fa'));
                    this.responseUnknownClass = 'fa-question';
                    this.responseCorrectClass = 'fa-check correct';
                }
            }
            this.reset();
        },
        reset: function() {
            this.correct = 0;
            this.ctr.find('.response')
                .addClass(this.responseUnknownClass)
                .removeClass(this.responseCorrectClass);
        },
        increment: function() {
            var target = this.ctr.find('.' + this.responseUnknownClass).first();
            target.removeClass(this.responseUnknownClass).addClass(this.responseCorrectClass);
            this.correct ++;
        },
        getScore: function() {
            return {
                correct: this.correct,
                max: this.count
            };
        }
    });
    window.SSGameTimer = Class.extend({
        ctr: null,
        node: null,
        onTick: null,
        maxTime: null,
        lastTime: null,
        started: null,
        timeLeft: null,
        paused: false,
        decrements: 0,
        init: function(cfg) {
            console.log(cfg);
            if(cfg.useContainer) {
                this.node = cfg.container;
            } else {
                this.ctr = cfg.container;
                this.node = $('<div></div>')
                    .addClass('timer');
                this.ctr.append(this.node);
            }
            this.maxTime = cfg.maxTime;
            this.onTick = $.Callbacks();
            this.onStop = $.Callbacks();
        },
        start: function() {
            this.timeLeft = this.maxTime * 1000;
            this.lastTime = new Date().getTime();
            this.interval = setInterval($.proxy(this.tick, this), 1000);
            this.show(this.maxTime);
        },
        stop: function() {
            clearInterval(this.interval);
            this.onStop.fire();
        },
        reset: function() {
            clearInterval(this.interval);
            this.clear();
        },
        pause: function() {
            this.paused = true;
        },
        resume: function() {
            this.lastTime = new Date().getTime();
            this.paused = false;
        },
        penalty: function(amt) {
            this.timeLeft -= amt;
            this.decrements += amt;
        },
        tick: function() {
            if(!this.paused) {
                this.onTick.fire();
                var tock = new Date().getTime();
                var diff = tock - this.lastTime;
                this.timeLeft -= diff;
                if(this.timeLeft < 0) this.timeLeft = 0;
                this.show(Math.round(this.timeLeft / 1000));
                if(this.timeLeft == 0) this.stop();
                this.lastTime = tock;
            }
        },
        show: function(time) {
            var timeStr = Math.floor(time / 60) + ':' + sprintf('%02d', Math.floor(time % 60));
            this.node.html('<span>' + timeStr.split('').join('</span><span>') + '</span>');
        },
        clear: function() {
            this.node.text('');
        }
    });

    window.SSGameModal = Class.extend({
        body: null,
        mask: null,
        settings: null,
        watcher: null,
        init: function(cfg) {
            if(!cfg) cfg = {};
            var defaultFadeSpeed = 500;
            var defaultContainer = SSGame.current.board.board;
            var defaults = {
                reusable: false,
                showDuration: 3000,
                onClose: null,
                dialog: {
                    appendTo: defaultContainer,
                    autoOpen: false,
                    closeOnEscape: false,
                    draggable: false,
                    //modal: true,
                    position: { my: 'center', at: 'center', of: defaultContainer },
                    resizable: false,
                    show: { effect: 'fade', duration: defaultFadeSpeed },
                    hide: { effect: 'fade', duration: defaultFadeSpeed }
                }
            };
            this.settings = $.extend(true, {}, defaults, cfg);
            var html = [];
            if(this.settings.title) html.push('<div class="SSGame_modal_title">' + this.settings.title + '</div>');
            if(this.settings.text) html.push(this.settings.text);
            this.body = $('<div></div>')
                .html('<div class="dialog_text_wrapper">' + html.join('') + '</div>')
                .addClass('SSGame_dialog');
            this.body.dialog(this.settings.dialog);
            this.watcher = $.proxy(function(e, idx, specs) {
                this.body.dialog('option', 'width', specs[3][0]);
                this.body.dialog('option', 'height', specs[3][1]);
                this.body.dialog('option', 'position', this.settings.dialog.position);
                //setTimeout($.proxy(this.alignContent, this), 100);
                var el = this.settings.dialog.appendTo;
                var elOff = el.offset();
                this.mask
                    .width(el.outerWidth())
                    .height(el.outerHeight());

            }, this);
            SSGame.current.board.board.on('breakpointChange', this.watcher);
        },
        alignContent: function() {
            var t = this.body.find('.dialog_text_wrapper');
            var p = t.parent();
            var th = t.height();
            var ph = p.height();
            t.css('marginTop', Math.floor((ph - th) / 2));
        },
        setButtons: function(buttons) {
            this.body.dialog('option', 'buttons', buttons);
        },
        open: function() {
            this.body.dialog('open');
            this.alignContent();
            if(this.settings.showDuration) {
                setTimeout($.proxy(this.close, this), this.settings.showDuration);
            }
            var el = this.settings.dialog.appendTo;
            var elOff = el.offset();
            var mask = $('<div></div>')
                .addClass('SSGameModalMask')
                .width(el.outerWidth())
                .height(el.outerHeight())
                .css({
                    position: 'absolute',
                    top: 0,
                    left: 0
                });
            SSGame.current.board.board.append(mask);
            this.mask = mask;
        },
        close: function() {
            this.body.dialog('close');
            setTimeout($.proxy(function() {
                if(typeof this.settings.onClose == 'function') this.settings.onClose();
                if(!this.settings.reusable) this.cleanup();
                this.mask.remove();
                this.mask = null;
            }, this), this.settings.dialog.hide.duration);
        },
        cleanup: function() {
            console.log('Cleanup');
            this.body.dialog('destroy');
            SSGame.current.board.board.off('breakpointChange', this.watcher);
            this.watcher = null;
        }
    });
    window.SSGameModal.textToParagraphs = function(s) {
        return '<p>' + s.split("\n").join('</p><p>') + '</p>';
    }
    window.SSGameModal.destroyAll = function() {
        $(".SSGame_dialog").dialog("close");
    }


})();
