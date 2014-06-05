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
        jQuery('.l-take-action-share').prependTo($findHelpfulLarge);
      } else {
        $module.appendTo($findHelpfulSmall);
        jQuery('.l-take-action-share').appendTo('.page-topic .row');
      }
    }

    return this;
  };

})(jQuery);
/**
 * Definition for the AdvocacyArticle javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.AdvocacyArticle();
  });

  U.AdvocacyArticle = function() {
    var self = this;

    if( jQuery('.l-advocacy-article').length !== 0){
      // Handle moving share and save module around depending on window width
      var $module = $('.share-save-container');
      // if module exists on the page
      if(!$module.length) { return; }

      var $ShareSavePagetopic = $('.share-save-pagetopic');
      var $ShareSaveInline = $('.share-save-inline');

      detect();
      jQuery(window).resize(detect);

      function detect(){
        // only above 650 viewport or nonresponsive
        if(Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
          $module.appendTo($ShareSaveInline);
        } else {
          $module.appendTo($ShareSavePagetopic );
        }
      }
    }

    return this;
  };

})(jQuery);
(function($) {

  $(document).ready(function() {
    var uniformElements = [
      '.selector',
      '.radio'
    ];

    new U.Global.readspeakerUniform(uniformElements);
  });

})(jQuery);



