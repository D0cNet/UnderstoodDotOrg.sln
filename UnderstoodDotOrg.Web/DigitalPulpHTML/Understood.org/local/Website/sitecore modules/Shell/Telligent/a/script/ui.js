
(function ($) {
    var wrap = function (fn, options) {
        return function () {
            try {
                if (options.before) {
                    options.before.apply(this, arguments);
                }
            } catch (e) { }
            var response = fn.apply(this, arguments);
            try {
                if (options.after) {
                    options.after.apply(this, arguments);
                }
            } catch (e) { }
            return response;
        }
    };

    $.each(['html', 'append', 'prepend'], function (i, fn) {
        $.fn[fn] = wrap($.fn[fn], {
            after: function () {
                $.telligent.sitecore.ui.adjustUrls(this);
            }
        });
    });
    $.each(['appendTo', 'prependTo'], function (i, fn) {
        $.fn[fn] = wrap($.fn[fn], {
            after: function (val) {
                $.telligent.sitecore.ui.adjustUrls($(val));
            }
        });
    });
    $.each(['after', 'before'], function (i, fn) {
        $.fn[fn] = wrap($.fn[fn], {
            after: function () {
                $.telligent.sitecore.ui.adjustUrls(this.parent());
            }
        });
    });
    $.each(['insertAfter', 'insertBefore'], function (i, fn) {
        $.fn[fn] = wrap($.fn[fn], {
            after: function (val) {
                $.telligent.sitecore.ui.adjustUrls($(val).parent());
            }
        });
    });
} (jQuery));


(function ($) {
   var sitePattern = null, //fullsitepattern
   redirectUri = null, //handler
   api = {
            configure: function(options){
                sitePattern = options.sitePattern;
                redirectUri = options.redirectUri;
            },
            adjustUrls: function(jq){
                if(sitePattern == null || redirectUri == null ) return;

                $('a',jq).each(function(){
                    var href = $(this).attr('href');
                    if(href != null && href != 'undefined'){
                        if(href.match(sitePattern) != null){
                            $(this).attr('href',redirectUri.replace('{URL}', encodeURIComponent(href)));
                         }
                    }
                    
                });

                $('img',jq).each(function(){
                    var src = $(this).attr('src');
                    if(src != null && src != 'undefined'){
                        if(src.match(sitePattern) != null){
                            $(this).attr('src',redirectUri.replace('{URL}', encodeURIComponent(src)));
                        }
                    }
                });
            }
       
   };

   if(!$.telligent) { $.telligent = {}; }
   if(!$.telligent.sitecore) { $.telligent.sitecore = {}; }
   $.telligent.sitecore.ui = api;

   $(document).ready(function(){
         $.telligent.sitecore.ui.adjustUrls($(document));
   });
} (jQuery));