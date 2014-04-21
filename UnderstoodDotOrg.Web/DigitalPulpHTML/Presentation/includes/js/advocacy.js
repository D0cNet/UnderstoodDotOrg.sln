/**
 * Definition for the TakeAction javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.TakeAction();
  });

  U.TakeAction = function() {
    var self = this;

    // Handle moving sidebar find-this-helpful module around depending on window width
    var $module = $('.take-action-module');
    // if module exists on the page
    if(!$module.length) { return; }

    var $findHelpfulLarge = $('.take-action-large');
    var $findHelpfulSmall = $('.take-action-small');

    detect();
    jQuery(window).resize(detect);

    function detect(){
      // only above 650 viewport or nonresponsive
      if(Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
        $module.appendTo($findHelpfulLarge);
      } else {
        $module.appendTo($findHelpfulSmall);
      }
    }

    return this;
  };

})(jQuery);
