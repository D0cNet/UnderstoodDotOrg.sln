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
      $(window).on('resize', this.resizeColumns);
      return this.resizeColumns();
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


  


})(jQuery);
