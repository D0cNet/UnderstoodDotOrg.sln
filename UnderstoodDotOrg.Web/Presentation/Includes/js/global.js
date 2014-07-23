/**
 * Definitions for template-level Javascript functionality.
 */


(function($){

  U.Global = U.Global || {};

  /**
   * Definition for breakpoints (taken from _config.scss).
   * @static
   * @enum
   */
  U.Global.Breakpoints = {
    SMALL: 480,
    SMALL_PLUS: 650,
    MEDIUM: 769,
    LARGE: 960
  };

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.Global.Carousels();
    new U.Global.GridSpacers();
//    new U.Global.Tooltips();
    // @todo Append global modules here?
    // @todo Do we like this pattern?
    // @todo Consider splitting with sprockets like modules.js?
  });

  /**
   * A global implementation of Twitter boostrap tooltips.
   * @memberof U.Global
   */
  U.Global.Tooltips = function() {
    var self = this;

    // Tooltip icon contexts.
    this.tooltips = {
      assistive: $('.tech-search-results h3 .icon-tooltip'),
      grade: $('.grade-info-wrapper .icon-tooltip'),
      quality: $('.quality-info-wrapper .icon-tooltip'),
      learning: $('.learning-info-wrapper .icon-tooltip'),
      recommendation: $('.get-recommendations .icon-question-mark.tooltip')
    };

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      // Bind tooltip icon click events to tooltip popovers.
      for (var tooltip in this.tooltips) {
        // Hide tooltips by default.
        $('#' + tooltip + '-tooltip').hide();

        // Closure preserves iterator scope.
        (function(t) {
          self.tooltips[t].on('click', function() {
            self.toggleTooltipEvent(this, t);
            return false;
          }).css('cursor', 'pointer');
        })(tooltip);
      }

      return this;
    };

    /**
     * Event handler for showing/hiding tooltips on click events.
     * @param {jQuery} context
     *   the icon that was clicked
     * @param {string} tooltip
     *   the "key" name from this.tooltips
     *   note this is used to create an ID name that must match the key
     *   (ex. this.tooltips.assistive displays #assistive-tooltip)
     * @return {boolean} false
     */
    this.toggleTooltipEvent = function(context, tooltip) {
      var wrapper = $('#' + tooltip + '-tooltip');
      if (!wrapper.length) return false;

      if (!context.showingTooltip) {
        self.showTooltip(context, wrapper.html());

        // Click anywhere to close.
        $(document).one('click', function() {
          if (context.showingTooltip) {
            self.hideTooltip(context);
          }
          return false;
        });
      }
      else {
        self.hideTooltip(context);
        return false;
      }
    };

    /**
     * Show a tooltip popover.
     * @param {jQuery} context
     *   the info icon to popover
     * @param {string} content
     *   the HTML content of the tooltip
     * @return {object} this instance
     */
    this.showTooltip = function(context, content) {
      $(context).popover({
        html: true,
        placement: 'bottom',
        trigger: 'manual',
        content: content
      }).popover('show');
      context.showingTooltip = true;

      return this;
    };

    /**
     * Hide a tooltip popover.
     * @param {jQuery} context
     *   the info icon to popover
     * @return {object} this instance
     */
    this.hideTooltip = function(context) {
      $(context).popover('hide');
      context.showingTooltip = false;
      return this;
    };

    return this.initialize();
  };


  /**
   * Provides global resizing of grid spacers for sidebars.
   */
  U.Global.GridSpacers = function() {

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      $html = $('html');
      $(window).on('resize', this.resizeColumns);
      $html.on('equalHeights', this.resizeColumns);
    };

    /**
     * Resize columns to equal heights on resize.
     * @return {object} this instance
     */
    this.resizeColumns = function() {
      if (!$('.row-equal-heights').length) {
        return;
      }

      if ($('#wrapper').width() > U.Global.Breakpoints.SMALL_PLUS) {
        $('.row-equal-heights').each(function() {
          // Make all columns the same height.
          $(this).children('.col').css('height', 'auto');
          $(this).children('.col').equalHeights();

          // Spacer columns have additional height based on page-topic margin.
          if ($(this).children('.sidebar-spacer').length) {
            var spacerHeight = $(this).height();
            $(this).children('.sidebar-spacer').height(spacerHeight + 45);
          }
        });
      }
      else {
        $('.row-equal-heights .col').css('height', 'inherit');
      }

      return this;
    };

    return this.initialize();
  };


  /**
   * A global implementation of RoyalSlider carousels.
   * @memberof U.Global
   */
  U.Global.Carousels = function() {
    return this;
  };

  U.Global.readspeakerUniform = function(uniformElements) {
    var self = this;

    self.init = function() {

      uniformElements = $(uniformElements.join(', '));

      uniformElements.addClass('rs_preserve');
    };

    self.init();
  };


  /* From MDN -- https://developer.mozilla.org/en-US/docs/Web/API/document.cookie */
  U.Global.Cookies = (function() {
    var docCookies = {
      getItem: function (sKey) {
        return decodeURIComponent(document.cookie.replace(new RegExp("(?:(?:^|.*;)\\s*" + encodeURIComponent(sKey).replace(/[\-\.\+\*]/g, "\\$&") + "\\s*\\=\\s*([^;]*).*$)|^.*$"), "$1")) || null;
      },
      setItem: function (sKey, sValue, vEnd, sPath, sDomain, bSecure) {
        if (!sKey || /^(?:expires|max\-age|path|domain|secure)$/i.test(sKey)) { return false; }
        var sExpires = "";
        if (vEnd) {
          switch (vEnd.constructor) {
            case Number:
              sExpires = vEnd === Infinity ? "; expires=Fri, 31 Dec 9999 23:59:59 GMT" : "; max-age=" + vEnd;
              break;
            case String:
              sExpires = "; expires=" + vEnd;
              break;
            case Date:
              sExpires = "; expires=" + vEnd.toUTCString();
              break;
          }
        }
        document.cookie = encodeURIComponent(sKey) + "=" + encodeURIComponent(sValue) + sExpires + (sDomain ? "; domain=" + sDomain : "") + (sPath ? "; path=" + sPath : "") + (bSecure ? "; secure" : "");
        return true;
      },
      removeItem: function (sKey, sPath, sDomain) {
        if (!sKey || !this.hasItem(sKey)) { return false; }
        document.cookie = encodeURIComponent(sKey) + "=; expires=Thu, 01 Jan 1970 00:00:00 GMT" + ( sDomain ? "; domain=" + sDomain : "") + ( sPath ? "; path=" + sPath : "");
        return true;
      },
      hasItem: function (sKey) {
        return (new RegExp("(?:^|;\\s*)" + encodeURIComponent(sKey).replace(/[\-\.\+\*]/g, "\\$&") + "\\s*\\=")).test(document.cookie);
      },
      keys: /* optional method: you can safely remove it! */ function () {
        var aKeys = document.cookie.replace(/((?:^|\s*;)[^\=]+)(?=;|$)|^\s*|\s*(?:\=[^;]*)?(?:\1|$)/g, "").split(/\s*(?:\=[^;]*)?;\s*/);
        for (var nIdx = 0; nIdx < aKeys.length; nIdx++) { aKeys[nIdx] = decodeURIComponent(aKeys[nIdx]); }
        return aKeys;
      }
    };

    return docCookies;
  })();

  /* From MDN - Polyfill for array.prototype.indexOf in IE8 */
  /* https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/indexOf */
  if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (searchElement, fromIndex) {
      if ( this === undefined || this === null ) {
        throw new TypeError( '"this" is null or not defined' );
      }

      var length = this.length >>> 0;
      fromIndex = +fromIndex || 0;

      if (Math.abs(fromIndex) === Infinity) {
        fromIndex = 0;
      }

      if (fromIndex < 0) {
        fromIndex += length;
        if (fromIndex < 0) {
          fromIndex = 0;
        }
      }

      for (;fromIndex < length; fromIndex++) {
        if (this[fromIndex] === searchElement) {
          return fromIndex;
        }
      }

      return -1;
    };
  }

  U.Global.Readspeaker = function() {
    var self = this;

    self.dom = {
      html: $('html')
    };

    self.classes = ['rsTextNormal', 'rsTextLarger', 'rsTextLarge'];

    self.init = function() {
      ReadSpeaker.q(function() {
        self.firstLoad();
        self.attachHandlers();
      });
      self.configureTooltips();
    };

    /* Set Defaults if Readspeaker Cookie Hasn't been set */
    self.firstLoad = function() {
      var cookie = U.Global.Cookies.getItem('ReadSpeakerSettings'),
          initialValue = 'rstoggle=rsoff&dpTxtSize=0';

      if (!cookie) {
        U.Global.Cookies.setItem('ReadSpeakerSettings', initialValue);
      }
    };

    self.removeTextSizeClasses = function() {
      var selector = self.classes.join(' ');

      self.dom.html.removeClass(selector);
    };

    self.attachHandlers = function() {
      if (! window.rsConf) { window.rsConf = {}; }
      if (! window.rsConf.Custom) { window.rsConf.Custom = {}; }

      window.rsConf.Custom.txtDec = function() {
        self.removeTextSizeClasses();
        self.dom.html.addClass(self.classes[0]).trigger('equalHeights');
      };

      window.rsConf.Custom.txtInc = function() {
        self.removeTextSizeClasses();
        self.dom.html.addClass(self.classes[1]).trigger('equalHeights');
      };

      window.rsConf.Custom.txtIncLarge = function() {
        self.removeTextSizeClasses();
        self.dom.html.addClass(self.classes[2]).trigger('equalHeights');
      };
    };

    self.configureTooltips = function() {
      var selectors = $('.selector');
      selectors.addClass('rs_preserve');
    };

    // UN-4512 - Reading Assist loses its fixed position on input focus
    // this is a known iOS bug, not easily solved, this fix will work until we find a more elegant solution:
    $('.touch input, .touch select, .touch textarea').on('focus',function() {
      $('#rsToggle').hide()
    });
    $('.touch input, .touch select, .touch textarea').on('blur',function() {
      $('#rsToggle').show()
    });


    self.init();
  };

  U.Global.Readspeaker();
})(jQuery);
