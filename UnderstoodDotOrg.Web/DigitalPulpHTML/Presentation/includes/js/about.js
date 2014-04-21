/**
 * Definition for the aboutDonatejavascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.aboutDonate();
  });

  U.aboutDonate= function() {
      var self = this,
          $toggleButtons = $('.choose-gift-section, .gift-for-wrapper').find('button');


      $toggleButtons.on('click', function(e) {
          e.preventDefault();

          var label = $(this).parents('label');

          label.click();

        // Hide/show functionality on click of "Other" gift amount
        if( $(this).parent().siblings('input').attr('name') === 'gift-amount' ){
          if( $(this).parent().siblings('input').data('other') ){
            $('.other-amount-form').show();
          }else{
            $('.other-amount-form').hide();
          }
        }else if( $(this).parent().siblings('input').attr('name') === 'gift-card' ){
          if( $(this).parent().siblings('input').data('e-card') ){
            $('.ecard-form-wrapper').show();
          }else{
            $('.ecard-form-wrapper').hide();
          }
        }

      });

    $('.how-pay-option-wrapper .radio-wrapper label').on('click', function(e){
      if( $(this).find('input').data('credit-card') ){
        $('.pay-by-credit').show();
        $('.pay-by-check').hide();
      }else{
        $('.pay-by-credit').hide();
        $('.pay-by-check').show();
      }
    });

    // Hide gift amount on ready
    $('.other-amount-form').hide();
    $('.ecard-form-wrapper').hide();
    $('.pay-by-check').hide();

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      var uniform_elements = [
        '.gift-occurance-wrapper input[type=radio]',
        '.radio-wrapper input[type=radio]'
      ].join(',');

      // Build uniform components.
      $(uniform_elements).uniform();

    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the AboutExpertsEventCarousel module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.AboutExpertsEventCarousel();
  });

  U.AboutExpertsEventCarousel= function() {
    var self = this;

    self.initialize = function(){

      //initialize carousel
      self.initEventCarousel();
      // change arrow color to gray on desktop
      self.eventCarouselArrowsGray();

      //perform action on resize, but delay the amount of times this is called while resizing.
      var doTheAction;
      $(window).resize(function() {
        clearTimeout(doTheAction);
        doTheAction = setTimeout(self.eventCarouselArrowsGray, 300);
      });

    };

    self.initEventCarousel = function(){

      // Cache slider element
      var $slider = $(".event-carousel");

      // Get window width
      var windowWidth = $(window).width();
      var autoHeightVal = (windowWidth > U.Global.Breakpoints.SMALL_PLUS); //returns true or false

      $slider.royalSlider({
        keyboardNavEnabled: false,  // enable keyboard arrows nav
        autoScaleSlider: false,
        imageAlignCenter: false,
        autoHeight: autoHeightVal,
        loop: true,
        arrowsNav: true,
        arrowsNavAutoHide: false,
        sliderDrag: false,
        navigateByClick: false,
        autoPlay: {
          delay: 4000,
          enabled: false
        }
      });

      // Accessibility
      U.carousels.keyboardAccess($slider, true);

    };

    self.eventCarouselArrowsGray = function(){

      //cache slider element
      var $slider = $(".about-experts-event-carousel");
      var windowWidth = $(window).width();

      if(windowWidth > U.Global.Breakpoints.SMALL_PLUS){
        $slider.removeClass('arrows-gray').addClass('arrows-gray');
      }else{
        $slider.removeClass('arrows-gray');
      }

    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the aboutDonatejavascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.aboutNewsletter();
  });

  U.aboutNewsletter= function() {
    var self = this;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {

      var newsletterEmail = $( "#signup-newsletter-email" );
      var newsletterButton = $( "#signup-newsletter-button" );

      function validateEmail(email) {
        var re = /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/;
        return re.test(email);
      }

      newsletterEmail.keyup(function() {
        if ( validateEmail( newsletterEmail.val() )) {
          newsletterButton.removeClass('disabled');
        } else{
          newsletterButton.addClass('disabled');
        }
      });

    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the AboutTools javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.AboutTools();
  });

  U.AboutTools = function() {
    var self = this;

    detect();
    jQuery(window).resize(detect);

    function detect(){
      // only above 650 viewport or nonresponsive
      if(Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
        jQuery('.about-tools .mini-tool').equalHeights();
      }else{
        jQuery('.about-tools .mini-tool').height('');
      }
    }

    return this;
  };

})(jQuery);
/**
 * Definition for the foundingCarousel javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.foundingCarousel();
  });

  U.foundingCarousel = function() {
    var self = this;

    // Turns an array of li elements into a grouped items based on numOfSlides
    var parseHtmlSlides = function(globalSlidesArr, numOfSlides){
      var html = '';
      var slideCount = 0;
      var slidesArr = globalSlidesArr.slice(0);
      var itemCount = Math.ceil(slidesArr.length/numOfSlides);
      while( itemCount > 0 ){
        slideCount++;
        html += '<div class="m-featured-slide"><div class="rsContent"><ul>';
        for(var i=0; i<numOfSlides; i++){
          html += slidesArr.shift() || "";
        }
        html += '</ul></div></div>';
        itemCount--;
      }
      return html;
    };

    var printArrFoundingSlider = function(arr){
      var html = '<ul>';
      var cloneArr = arr.slice(0);
      for(var i=0; i<cloneArr.length; i++){
        html += cloneArr[i];
      }
      html+='</ul>';
      return html;
    };

    var waitForFinalEvent = (function () {
      var timers = {};
      return function (callback, ms, uniqueId) {
        if (!uniqueId) {
          uniqueId = "Don't call this twice without a uniqueId";
        }
        if (timers[uniqueId]) {
          clearTimeout (timers[uniqueId]);
        }
        timers[uniqueId] = setTimeout(callback, ms);
      };
    })();

    // On Load founding carousel Array with all the elements
    var foundingCarouselArr = [];
    var foundingSliderObj = jQuery('.founding-slides-wrapper');

    // Pushes founding carousel items into an array on load
    jQuery(".founding-slides-wrapper li").each(function(){
      foundingCarouselArr.push( '<li>' + jQuery(this).html() + '</li>' );
    });

    // Clears founding carousel Contents
    foundingSliderObj.html('');

    // Initializes founding Slider
//    ( partnersSliderArr, false, jQuery('#partners-slides-container'), 6, false, 1000, false, 4, 2);

    var foundingCarouselInit = function(firstRun, foundingSliderObj, foundingCarouselArr){
      if( Modernizr.mq('(max-width: 479px)') ){
        if(!firstRun){
          foundingSliderObj.royalSlider('destroy');
          foundingSliderObj.html('');
        }
        foundingSliderObj.royalSlider({
          keyboardNavEnabled: false,  // enable keyboard arrows nav
          autoScaleSlider: true,
          autoScaleSliderWidth: 400, // base slider width. slider will autocalculate the ratio based on these values.
          autoHeight: true,
          imageScaleMode: 'none',
          imageAlignCenter: false,
          loop: true,
          controlNavigation: 'none',
          arrowsNav: true,
          arrowsNavAutoHide: false,
          navigateByClick: false,
          sliderDrag: false,
          slides: parseHtmlSlides(foundingCarouselArr, 2),
          autoPlay: {
            delay: 4000,
            enabled: false
          }
        });

        U.carousels.keyboardAccess(foundingSliderObj);
      }else{
        if(!firstRun){
          foundingSliderObj.royalSlider('destroy');
          foundingSliderObj.html('');
        }
        foundingSliderObj.html(printArrFoundingSlider(foundingCarouselArr));
      }
    };

    foundingCarouselInit(true, foundingSliderObj, foundingCarouselArr);

    $(window).on('resize', function(){

      waitForFinalEvent(function(){
        foundingCarouselInit(false, foundingSliderObj, foundingCarouselArr);
      }, 500, 'foundingCarousel');

    });


    // Handle moving sidebar find-this-helpful module around depending on window width
    var $module = $('.donate-advice-sidebar');
    // if module exists on the page
    if(!$module.length) { return; }

    var $aboutLarge = $('.about-large-block');
    var $aboutSmall = $('.about-small-block-after');

    // calls function on load and on resize
    detect();
    jQuery(window).resize(detect);

    function detect(){
      // only above 650 viewport or nonresponsive
      if(Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
        $module.appendTo($aboutLarge);
      } else {
        $module.insertAfter($aboutSmall);
      }
    }

    return this;
  };

})(jQuery);
/**
 * Definition for the pageNotFoundPromo javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.pageNotFoundPromo();
  });

  U.pageNotFoundPromo = function() {
    var self = this;

    // only above 650 viewport or nonresponsive
    if (Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
        $('.promo-single a')
          .css('height', 'auto')
          .equalHeights();
      }
      else {
        $('.promo-single a')
          .css('height', 'auto');
      }

    return this;
  };

})(jQuery);
/**
 * Definition for the EmailItemizeContent javascript module.
 */

(function($){

// Initialize the module on page load.
  $(document).ready(function() {
    new U.EmailItemizeContent();
  });

  U.EmailItemizeContent = function() {
    var self = this;

    // page ab7b
    $('.email-itemize-content .needs-help-with .needs-help-with-options .checkbox-wrapper input[type=checkbox]').uniform();

    // page ab7d
    var container = '.personalize-interests-content';
    var checkboxes = '.checkbox-wrapper input[type=checkbox]';
    var radios = '.radio-wrapper input[type=radio]';
    $(container + ' .school-issues .school-issues-options ' + checkboxes).uniform();
    $(container + ' .ways-to-help ' + checkboxes).uniform();
    $(container + ' .home-life ' + checkboxes).uniform();
    $(container + ' .growing-up ' + checkboxes).uniform();
    $(container + ' .social-emotional-issues ' + checkboxes).uniform();
    $(container + ' .preferred-language ' + radios).uniform();

    return this;
  };

})(jQuery);







