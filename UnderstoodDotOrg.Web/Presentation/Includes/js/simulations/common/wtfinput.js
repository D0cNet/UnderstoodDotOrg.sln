(function($) {
    $.fn.autoresize = function() {
        var resize = function(n) {
            n.css('height', 'auto');
            n.css('height', n[0].scrollHeight);
        }
        var $me = $(this);
        $me.css({
            overflow: 'hidden',
            resize: 'none'
        }).bind('change', function() {
            resize($me);
        }).bind('cut paste drop keydown', function(e) {
            setTimeout(function() {
                resize($me);
            }, 0);
        });
        return $me;
    };
    //http://stackoverflow.com/a/11077016
    function insertAtCursor(myField, myValue) {
        //IE support
        if (document.selection) {
            sel = document.selection.createRange();
            sel.text = myValue;
        }
        //MOZILLA and others
        else if (myField.selectionStart || myField.selectionStart == '0') {
            var startPos = myField.selectionStart;
            var endPos = myField.selectionEnd;
            myField.value = myField.value.substring(0, startPos)
                + myValue
                + myField.value.substring(endPos, myField.value.length);
            myField.selectionStart = startPos + myValue.length;
            myField.selectionEnd = startPos + myValue.length;
        } else {
            myField.value += myValue;
        }
    }

     
    var internal = {
        input: null,
        ctr: null,
        mirror: null,
        disabled: false,
        defaultConfig: {
            tweakOutputFunction: null,
            mirrorSelector: null,
            onWrite: null
        },
        setup: function(selector, cfg) {
            $(selector).addClass('wtfinput');
            internal.input = $('<textarea></textarea>').autoresize();
            $(selector).append(internal.input); 
        }
    }
    var WTFInput = function(inputSelector, userConfig) {
        var cfg = $.extend(true, internal.defaultConfig, userConfig);
        internal.setup(inputSelector, cfg);

        var ui = {
            getShownContent: function() {
                return internal.input.val();
            },
            stopInput: function() {
                internal.disabled = true;
            },
            startInput: function() {
                internal.disabled = false;
            },
            clear: function() {
                internal.input.val('');
            },
            focus: function() {
                internal.input.focus();
            }
        };
        internal.input.on('keypress', function(e) {
            if(internal.disabled) return false;
            var retVal = true;
            var typedChr = String.fromCharCode(e.which);
            if(typedChr && typedChr.match(/\w/)) {
                var shownChr = (cfg.tweakOutputFunction) ? cfg.tweakOutputFunction(typedChr) : typedChr;
                if(shownChr != typedChr) {
                    insertAtCursor(internal.input[0], shownChr);
                    retVal = false;
                }
            }
            if(cfg.onWrite) {
                //Textarea values don't update synchronously
                setTimeout(function() {
                    cfg.onWrite();
                }, 0);
            }
            return retVal;
        });

        return ui;

    };
    window.WTFInput = WTFInput;
})(jQuery);
