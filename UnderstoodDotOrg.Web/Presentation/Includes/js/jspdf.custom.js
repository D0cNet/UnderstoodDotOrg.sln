/* Zachary Kniebel
 * Custom override of the jsPDF plugin's .addHTML function, in order to improve cropping scaling and quality. 
 **/

jsPDF.API.addHTML = function (element, x, y, options, callback) {
    'use strict';

    if (typeof html2canvas === 'undefined' && typeof rasterizeHTML === 'undefined') throw new Error('You need either ' + 'https://github.com/niklasvh/html2canvas' + ' or https://github.com/cburgmer/rasterizeHTML.js');

    if (typeof x !== 'number') {
        options = x;
        callback = y;
    }

    if (typeof options === 'function') {
        callback = options;
        options = null;
    }

    var I = this.internal,
        K = I.scaleFactor,
        W = I.pageSize.width,
        H = I.pageSize.height;

    options = options || {};
    options.onrendered = function (obj) {
        var context = this;
        $("#checklist-article-downloading-modal").modal('show')
        $(window).trigger("resize").delay(500).promise().done(function () {
            x = parseInt(x) || 0;
            y = parseInt(y) || 0;
            var dim = options.dim || {};
            var h = dim.h || 0;
            var w = dim.w || Math.min(W, obj.width / K) - x;

            var format = 'JPEG';
            if (options.format) format = options.format;
            if (obj.height > H && options.pagesplit) {
                var crop = function () {
                    var canvasHeight = H * K;
                    var canvasWidth = Math.min(W * K, obj.width);
                    var ratio = canvasWidth / obj.width;
                    var displayHeight = ratio * canvasHeight;
                    var cy = y;
                    while (1) {
                        var args = [obj, x, -cy, w, h, format, null, 'SLOW'];
                        context.addImage.apply(context, args);
                        cy += displayHeight;
                        if (cy >= canvasHeight) break;
                        context.addPage();
                    }
                    callback(w, cy, null, args);
                }.bind(context);
                if (obj.nodeName === 'CANVAS') {
                    var img = new Image();
                    img.onload = crop;
                    img.src = obj.toDataURL("image/png");
                    obj = img;
                } else {
                    crop();
                }
            } else {
                var alias = Math.random().toString(35);
                var args = [obj, x, y, w, h, format, alias, 'SLOW'];

                context.addImage.apply(context, args);

                callback(w, h, alias, args);
            }
        });
    }.bind(this);
    if (typeof html2canvas !== 'undefined' && !options.rstz) {
        return html2canvas(element, options);
    }

    if (typeof rasterizeHTML !== 'undefined') {
        var meth = 'drawDocument';
        if (typeof element === 'string') {
            meth = /^http/.test(element) ? 'drawURL' : 'drawHTML';
        }
        options.width = options.width || (W * K);
        return rasterizeHTML[meth](element, void 0, options).then(function (r) {
            options.onrendered(r.image);
        }, function (e) {
            callback(null, e);
        });
    }

    return null;
};