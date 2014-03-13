/**
 * Definition for the getRecommendations javascript module.
 * popover module JS is found in tech-search-results.js
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.getRecommendations();
  });

  /**
   * Checks whether the get-better-recommendations module exists on the page and inits if it does
   * If the viewport is >= 769 then pop the module into the page-topic container
   *
   * spec/issue : https://digitalpulp.atlassian.net/browse/UN-178
   */
  U.getRecommendations = function() {

    var $module = $('.get-better-recommendations');
    // if get-better-recommendations module exists on the page
    if(!$module.length) { return; } 

    // call splitModules function if elemet exists, resize event
    if ($('.split-modules'.length)) {
      splitModules();
      $(window).on('resize.getRecommends', splitModules);
    }

    // make the Get Recommendations module and the Featured Event module the same height, using setAllToMaxHeight function
    function splitModules() {

      // clear properties (for resize): remove height style and set-height class
      $('.split-modules .get-better-recommendations, .split-modules .featured-event').removeAttr('style').removeClass('set-height');

      // only above 650 viewport
      if(Modernizr.mq('(min-width: 650px)')){

        // give set-height class to 2 modules
        $('.split-modules .get-better-recommendations, .split-modules .featured-event').addClass('set-height');

        // give set-height class items same height
        $('.set-height').equalHeights();

      }
    }

    var $modulecontainer = $('.get-better-recommendations-container');
    var $getrecommends = $module.find('.get-recommendations');
    var $thankyou = $module.find('.thank-you');
    var $tooltip = $module.find('.tooltip');
    var $topiccontainer = $('.page-topic');
    var $topiccontainerrow = $topiccontainer.find('.row');
    var $childcontentindicator = $('.child-content-indicator:first');

    // button click event
    $getrecommends.find('.button').on('click', submitQuestion);

    // if the seconday nav is on the page attach events for moving it around
    if(!$('.nav-secondary').length){
      $(window).on('resize.getRecommends', detect);
      detect();
    }

    function detect(){
      if(Modernizr.mq('(min-width: 850px)')){
        $topiccontainer.addClass('has-recommendations');
        $childcontentindicator.addClass('has-recommendations');
        $module.appendTo($topiccontainerrow);
      } else {
        $topiccontainer.removeClass('has-recommendations');
        $childcontentindicator.removeClass('has-recommendations');
        $module.appendTo($modulecontainer);
      }
    }

    // submit answer to question
    function submitQuestion(e){
      e.preventDefault();
      $thankyou.fadeIn();

      // hide tool tip launcher and popover
      $tooltip.fadeOut();
      $module.find('.popover').fadeOut();
    }

  };

})(jQuery);
/**
 * Definition for the secondaryMenu javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.secondaryMenu();
  });

  U.secondaryMenu = function(){
    var self = this;

    self.$navsecondary = $('.nav-secondary');

    self.init = function(){

      self.viewport_size = null;

      self.$menu = self.$navsecondary.find('ul.menu');
      self.$submenu = self.$navsecondary.find('li.submenu');
      self.$submenu_list = self.$submenu.find('ul');
      self.$submenu_btn = self.$submenu.find('div.label-more');

      self.breakpointActions();
      // FIXME Candidate for inclusion in future unified resize event framework
      var resizeDelay;
      $(window).bind('resize', function() {
        clearTimeout(resizeDelay);
        resizeDelay = setTimeout(function() {
          self.breakpointActions();
        }, 100);
      });

      // when dropdown is opened, an event is attached to document to close it.
      // stop event propogation to dropdown itself
      self.$submenu_list.on('click touchstart', function(e) {
        e.stopPropagation();
      });
    }


    self.breakpointActions = function() {

      // TODO needs to handle delivering desktop content to IE8
      // mobile
      if (Modernizr.mq('(max-width: 649px)') && self.viewport_size !== 'small') {

        // attach events for dropdown functionality
        if (Modernizr.touch) {
          self.attachMobileEvents('touchstart');
        } else {
          self.attachMobileEvents('click');
        }

        // resized down from tablet or desktop
        // move items back where they came from and unbind events for those viewports.
        if (self.viewport_size !== null) {
          self.itemsDown(0,5);
          self.$submenu_list.show();
          self.$submenu_btn.off();
          self.$submenu.unbind('mouseenter').unbind('mouseleave');
        }

        self.viewport_size = 'small';
      }

      // tablet
      else if (Modernizr.mq('(min-width: 650px)') && Modernizr.mq('(max-width: 959px)') && self.viewport_size !== 'medium') {
        if (self.viewport_size == 'small') {
          self.resetFromSmall();
        }

        // page opened at tablet size or resized from moblie
        // move items from submenu to top level, attach events
        if (self.viewport_size == 'small' || self.viewport_size == null) {
          self.itemsUp(4);
          self.attachSubmenuEvents();
        }

        // page resized from desktop
        // move back one item from top level to submenu
        if (self.viewport_size == 'large') {
          self.itemsDown(4,5);
        }

        self.viewport_size = 'medium';
      }

      // desktop
      else if (Modernizr.mq('(min-width: 960px)') && self.viewport_size !== 'large') {
        if (self.viewport_size == 'small') {
          self.resetFromSmall();
        }

        // page resized from tablet
        // move one additional item from submenu to top level
        if (self.viewport_size == 'medium') {
          self.itemsUp(1);
        }

        // page opened at desktop size or resized from moblie
        // move items from submenu to top level, attach events
        if (self.viewport_size == 'small' || self.viewport_size == null) {
          self.itemsUp(5);
          self.attachSubmenuEvents();
        }

        self.viewport_size = 'large';
      }

    };

    self.resetFromSmall = function(){
      self.$menu.off();
      self.$menu.removeClass('is-open');
      self.$submenu_list.hide();
    };

    // move n number of items from the submenu into the top level
    self.itemsUp = function(n){
      var submenu_items = self.$submenu_list.find('li');
      submenu_items
          .slice(0,n)
          .detach()
          .insertBefore(self.$submenu);

      // nothing left behind, hide 'more' button
      if (n >= submenu_items.length) {
        self.$submenu.hide();
      }
    };

    // move items from the top level into the submenu
    self.itemsDown = function(a,b){
      var toplevel_items = self.$menu.find('> li').not('.title').not('.submenu');
      toplevel_items
          .slice(a,b)
          .detach()
          .prependTo(self.$submenu_list);

      // if submenu is no longer empty, show 'more' button
      // by removing style applied on hiding.
      if (self.$submenu.is(':hidden')) {
        if (self.$submenu_list.find('li').length) {
          self.$submenu.removeAttr('style');
        }
      }
    };

    self.attachMobileEvents = function(event) {
      self.$menu.find('> li.title').on(event, function(e) {
        if (!self.$menu.hasClass('is-open')) {
          e.stopPropagation();
          self.$menu.addClass('is-open');
          $(document).one(event, function() {
            self.$menu.removeClass('is-open');
          });
        }
      });
    }

    self.attachSubmenuEvents = function() {
      if (Modernizr.touch) {
        self.$submenu_btn.on('touchstart', function(e) {
          if (self.$submenu_list.is(':hidden')) {
            self.$submenu_list.show();
            e.stopPropagation();
            $(document).one('touchstart', function() {
              self.$submenu_list.hide();
            });
          }
        });
      } else if ($.fn.hoverIntent) {
        var config = {
          over: self.submenuShow,
          timeout: 500,
          out: self.submenuHide
        };
        self.$submenu.hoverIntent(config);
      } else {
        self.$submenu.hover(self.submenuShow, self.submenuHide);
      }
    }

    self.submenuShow = function() {
      self.$submenu_list.show();
    };

    self.submenuHide = function() {
      self.$submenu_list.hide();
    };


    if (self.$navsecondary.length) {
      self.init();
    }
  };

})(jQuery);
/**
 * Definition for the Show More javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.showMore();
  });


  /*
   *  Show More Functionality
   *
   *  Use this link markup with data attributes
   *
   *  <a href="REPLACE" class="show-more-link" data-path="articles/g3" data-container="article-listing" data-item="article" data-count="6">More Articles<i class="icon-arrow-down-blue"></i></a>
   *  
   *  @TODO
   *  As the backend functionality is not in place yet to load the content for these buttons, we are temporarily using this method to show the look and feel of loading more content.
   *  Each button will have a dummy HTML file associated with it to "show more" content.
   *  The HTML files live in /data/.
   *
   *  Data Atributes on the link
   *
   *  data-path:      HTML path/file (doesn't need to start with /data/ and end with .html)
   *  data-container: class name of container that will be populated (show more link usually lives directly under this container)
   *  data-item:      class name of individual content sections inside the container (@TODO: not being used yet)
   *  data-count:     number of new items to show (@TODO: not being used yet)
   *
   *
   *  @TODO
   *   This will need to be adjusted to receive a count of items when the page loads
   *   and to update the count while showing more artilces where the show more link would dissappear when 
   *   there are no more items to show
   */


  U.showMore = function(options) {

    // show more button container
    var $showMoreContainer = $('.show-more');
    // show more button class
    var $showMore = $('.show-more-link');

    // path for data
    var $dataPAth = '/data/';

    // data container class name to populate (from button data attribute)
    var $dataContainer = $("." + $showMore.data('container'));

    // data class name for each item (for counting) (from button data attribute)
    var $dataItem = $("." + $showMore.data('item'));

    // data file (from button data attribute)
    var $dataFile = $showMore.data('path');

    // data count (from button data attribute)
    var $dataCount = $showMore.data('count');


    // init
    function init() {
      showHideMore();
    };

    // request more items
    function requestMore() {

      // scroll to top of newly loaded items
      $('html,body').animate({scrollTop: $showMoreContainer.offset().top - 40}, 500);

      // Ajax load items
      $.get($dataPAth + $dataFile + '.html' ,function(data){
        $dataContainer.append($(data));
      },'html');  

    };

    // show / hide more button
    function showHideMore(){
      $showMore.on('click', requestMore);
    };

    init();

  };

})(jQuery);
/**
 * Definition for the miniTools javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.miniTools();
  });

  U.miniTools = function(){

    var self = this;

    self.init = function(){

      // get form vars
      self.$miniToolsWrap = $('.mini-tool');
      self.$miniToolsTabWrap = self.$miniToolsWrap.find('.tabs');
      self.$miniToolsTab = self.$miniToolsTabWrap.find('a');
      self.$miniToolsTabContent = self.$miniToolsWrap.find('.tab-content-wrap');


  
      // TABS FOR MODULES

      // show active state for first tab
      self.$miniToolsTabWrap.each(function() {
        $(this).find('a:first').addClass('active')
      });

      // show content for first tab
      self.$miniToolsTabContent.each(function() {
        $(this).find('li:first').addClass('active').show();
      });

      // click event for tabs to switch
      self.$miniToolsTab.on('click', function(e){

        e.preventDefault();

        var $this = $(this);

        if (!$(this).hasClass('active')) {
          $(this).addClass('active').siblings('a').removeClass('active');
          $($(this).attr('href')).show().siblings('li').hide();
        }
        
        this.blur();
      });


      // TECH MODULE - Show Platform menu when tech menu is active

      $('#tool-tech-alltech').on('change keyup', function() {
        if ( $(this).val() === "" ){
          $('#uniform-tool-tech-platforms').fadeOut('fast');
        }
        else {
          $('#uniform-tool-tech-platforms').fadeIn('fast');
        }
      });

    };

    self.init();

  };

})(jQuery);
/**
 * Definition for the contentFilter javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.contentFilter();
  });

  U.contentFilter = function(){
    var self = this;

    self.$filter = $('.content-filter');

    self.init = function(){

      self.$menu = self.$filter.find('div.menu');
      self.$list = self.$menu.find('ul');

      if (Modernizr.touch) {
        self.attachToggleEvent('touchstart');
      } else {
        self.attachToggleEvent('click');
      }

      // when dropdown is opened, an event is attached to document to close it.
      // stop event propogation to dropdown itself
      self.$list.on('click touchstart', function(e) {
        e.stopPropagation();
      });

    }

    self.attachToggleEvent = function(event) {
      self.$menu.find('> div.selected').on(event, function(e) {
        if (!self.$menu.hasClass('is-open')) {
          e.stopPropagation();
          self.$menu.addClass('is-open');
          $(document).one(event, function() {
            self.$menu.removeClass('is-open');
          });
        }
      });
    }

    if (self.$filter.length) {
      self.init();
    }

  };

})(jQuery);
/**
 * Definition for the toolkit javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.toolkit();
  });

  /**
   *
   * @TODO:
   *   need to simplify the cloning of the original object 
   *   tweak the resize event to be more robust 
   *   tweak naming conventions
   *   fix how this is being initialize
   *   equal height of containers
   *   buttons need to be responsive (they grow and shrink based on breakpoint)
   */
  U.toolkit = function(){
    var self = this;

    self.init = function(){

      self.$container = $('#toolkit-slides-container');
      self.$org = self.$container.clone();
      self.isbig = false;

      self.checker();
      $(window).on('resize', self.checker);

    };

    self.initslide = function(){

      self.$rs = self.$container.royalSlider({
        keyboardNavEnabled: true,  // enable keyboard arrows nav
        loop: false,
        controlNavigation: 'bullets',
        arrowsNav: true,
        arrowsNavAutoHide: false,
        slidesSpacing: 50,
        autoPlay: {
          delay: 4000,
          enabled: false
        },
        sliderDrag: false
      });

    };

    self.destroySlide = function(){

      // remove the rs from the dom
      self.$rs.remove();

      // append the original
      self.$org.appendTo('.tools-container');

      // cache the original again
      self.$container = $('#toolkit-slides-container');

      // clone it
      self.$org = self.$container.clone();

    };

    self.checker = function(){
      if ( Modernizr.mq('(min-width: 650px)') && self.isbig == false ) {
        self.initslide();
        self.isbig = true;
      } else if ( Modernizr.mq('(max-width: 649px)') && self.isbig == true ) {
        self.destroySlide();
        self.isbig = false;
      }

    };
    
    self.init();
  };

})(jQuery);
/**
 * Definition for the carousels javascript module.
 * @todo Remove dependencies between various carousels (one module/carousel).
 * @todo This needs to be refactored to match existing module patterns:
 * @see {@link https://digitalpulp.atlassian.net/browse/UN-921}
 */

(function($){

  U.carousels = function() {
    // Saves initial page load html for carousel
    var saveSliderHtml;
    var featuredSliderArr = [];
    var moreSliderArr = [];
    var exploreSliderArr = [];
    var partnersSliderArr = [];
    var commentGallerySliderArr = [];
    var parentsAreSayingSliderArr = [];
    var partnersAnchor;
    var topicSliderHtml = [];
    var topicTitles = [];
    var onResizeEvent = [];

    // Causes delay to prevent multiple firings on events such as window resize
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

    // Turns array into a string
    var printArr = function(arr){
      var html = '';
      var cloneArr = arr.slice(0);
      for(var i=0; i<cloneArr.length; i++){
        html += cloneArr[i];
      }
      return html;
    };

    // Creates slider based on window width, and slider array, and jQuery slider Object
    var responsiveSliderChange = function(sliderArr, sliderExists, sliderObj, numOfSlides, loopBool, scaleWidth, scaleWidthMobile, numOfSlidesMedium, numOfSlidesSmall){
      if(sliderExists){
        sliderObj.royalSlider('destroy');
      }
      sliderObj.html('');
      if( (numOfSlidesSmall) && Modernizr.mq('(max-width: 479px)') ){
        sliderObj.html(parseHtmlSlides(sliderArr, numOfSlidesSmall));
        sliderObj.royalSlider({
          keyboardNavEnabled: true,  // enable keyboard arrows nav
          autoScaleSlider: true,
          autoScaleSliderWidth: scaleWidthMobile, // base slider width. slider will autocalculate the ratio based on these values.
          autoHeight: true,
          imageScaleMode: 'none',
          imageAlignCenter: false,
          loop: loopBool,
          controlNavigation: 'none',
          arrowsNav: true,
          arrowsNavAutoHide: false,
          navigateByClick: false,
          sliderDrag: false,
          autoPlay: {
            delay: 4000,
            enabled: false
          }
        });
      }else if( Modernizr.mq('(max-width: 479px)') ){
        sliderObj.royalSlider({
          keyboardNavEnabled: true,  // enable keyboard arrows nav
          autoScaleSlider: true,
          autoScaleSliderWidth: scaleWidthMobile, // base slider width. slider will autocalculate the ratio based on these values.
          autoHeight: true,
          imageScaleMode: 'none',
          imageAlignCenter: false,
          loop: loopBool,
          controlNavigation: 'none',
          arrowsNav: true,
          arrowsNavAutoHide: false,
          navigateByClick: false,
          sliderDrag: false,
          autoPlay: {
            delay: 4000,
            enabled: false
          },
          slides: parseHtmlSlides(sliderArr, 1)
        });
      }else{
        // If an inbetween state is set for 480px >
        if( (numOfSlidesMedium) && ( Modernizr.mq('(min-width: 480px)') && Modernizr.mq('(max-width: 959px)') ) ){
          sliderObj.html(parseHtmlSlides(sliderArr, numOfSlidesMedium));
          sliderObj.royalSlider({
            keyboardNavEnabled: true,  // enable keyboard arrows nav
            autoScaleSlider: true,
            autoScaleSliderWidth: scaleWidth, // base slider width. slider will autocalculate the ratio based on these values.
            autoHeight: true,
            imageScaleMode: 'none',
            imageAlignCenter: false,
            loop: loopBool,
            numImagesToPreload:99,
            controlNavigation: 'none',
            arrowsNav: true,
            arrowsNavAutoHide: false,
            navigateByClick: false,
            sliderDrag: false,
            autoPlay: {
              delay: 4000,
              enabled: false
            }
          });
        }else{
          sliderObj.html(parseHtmlSlides(sliderArr, numOfSlides));
          sliderObj.royalSlider({
            keyboardNavEnabled: true,  // enable keyboard arrows nav
            autoScaleSlider: true,
            autoScaleSliderWidth: scaleWidth, // base slider width. slider will autocalculate the ratio based on these values.
            autoHeight: true,
            imageScaleMode: 'none',
            imageAlignCenter: false,
            loop: loopBool,
            numImagesToPreload:99,
            controlNavigation: 'none',
            arrowsNav: true,
            arrowsNavAutoHide: false,
            navigateByClick: false,
            sliderDrag: false,
            autoPlay: {
              delay: 4000,
              enabled: false
            }
          });
        }
      }
    };

    var topicCarousel = function(topicCarousel, sliderExists, sliderHtml){
      if(sliderExists){
        topicCarousel.royalSlider('destroy');
        topicCarousel.html(sliderHtml);
      }
      var topicCount = 0;
      jQuery("#topic-carousel .title").each(function(){
        jQuery(this).html( topicTitles[topicCount] );
        topicCount++;
      });
      if( Modernizr.mq('(min-width: 650px)') ){
        topicCarousel.royalSlider({
          arrowsNav: false,
          arrowsNavAutoHide: false,
          navigateByClick: false,
          fadeinLoadedSlide: true,
          controlNavigationSpacing: 0,
          controlNavigation: 'thumbnails',
          thumbs: {
            autoCenter: false,
            fitInViewport: true,
            orientation: 'vertical',
            spacing: 0,
            drag: false,
            paddingBottom: 0
          },
          autoPlay: {
            // autoplay options go gere
            enabled: true,
            pauseOnHover: true,
            delay: 2000
          },
          keyboardNavEnabled: true,
          imageScaleMode: 'fill',
          imageAlignCenter: true,
          slidesSpacing: 0,
          loop: true,
          loopRewind: true,
          numImagesToPreload: 4,
          autoScaleSlider: true,
          autoScaleSliderHeight: 354,
          imgWidth: 630,
          imgHeight: 354,
          sliderDrag: false
        });
      }else{
        topicCarousel.royalSlider({
          arrowsNav: true,
          arrowsNavAutoHide: false,
          arrowsNavHideOnTouch: false,
          navigateByClick: false,
          fadeinLoadedSlide: true,
    //      controlNavigationSpacing: 0,
          keyboardNavEnabled: true,
          imageScaleMode: 'fill',
          imageAlignCenter: false,
          slidesSpacing: 18,
          loop: true,
          loopRewind: true,
          numImagesToPreload: 4,
          autoScaleSlider: true,
    //      autoScaleSliderHeight: 354,
          autoPlay: {
            // autoplay options go gere
            enabled: false,
            pauseOnHover: true,
            delay: 2000
          },
          sliderDrag: false
        });
      }
    };

    // On Document Ready: Destroy carousel if window width under 480
    $(document).ready(function(){


      ///////////////////////////////// Featured Slider /////////////////////////////////

      // Pushes Featured Slider items into an array
      jQuery("#featured-slides-container li").each(function(){
        featuredSliderArr.push( '<li>' + jQuery(this).html() + '</li>' );
      });

      // Clears Featured Slider Contents
      $("#featured-slides-container").html('');

      // Initializes Featured Slider
      responsiveSliderChange( featuredSliderArr, false, jQuery('#featured-slides-container'), 3, false, 1000, false );

      ///////////////////////////////// End Featured Slider /////////////////////////////////


      ///////////////////////////////// More Carousel Slider /////////////////////////////////

      // Pushes More Carousel Slider items into an array
      jQuery("#more-carousel-slides-container li").each(function(){
        moreSliderArr.push( '<li>' + jQuery(this).html() + '</li>' );
      });

      // Clears More Carousel Slider Contents
      $("#more-carousel-slides-container").html('');

      // Initializes More Carousel Slider
      responsiveSliderChange( moreSliderArr, false, jQuery('#more-carousel-slides-container'), 3, false, 1100, 500 );

      ///////////////////////////////// End More Carousel Slider /////////////////////////////////


      ///////////////////////////////// More to Explore Slider /////////////////////////////////

      // Pushes More to Explore Slider items into an array
      jQuery(".more-to-explore-container li").each(function(){
        exploreSliderArr.push( '<li>' + jQuery(this).html() + '</li>' );
      });

      // Clears More to Explore Slider Contents
      $(".more-to-explore-container").html('');

      // Initializes More to Explore Slider
      responsiveSliderChange( exploreSliderArr, false, jQuery('.more-to-explore-container'), 3, true, 500, false, 2);

      ///////////////////////////////// End More to Explore Slider /////////////////////////////////


      ///////////////////////////////// Comment Gallery Slider /////////////////////////////////

      // Pushes Comment Gallery Slider items into an array
      jQuery(".comment-gallery-container li").each(function(){
        commentGallerySliderArr.push( '<li>' + jQuery(this).html() + '</li>' );
      });

      // Clears Comment Gallery Slider Contents
      $(".comment-gallery-container").html('');

      // Initializes Comment Gallery Slider
      responsiveSliderChange( commentGallerySliderArr, false, jQuery('.comment-gallery-container'), 3, true, 500, 150, 2);

      ///////////////////////////////// End Comment Gallery Slider /////////////////////////////////


      ///////////////////////////////// Parents are Saying Slider /////////////////////////////////

      // Pushes Parents are Saying Slider items into an array
      jQuery(".parents-are-saying-container li").each(function(){
        parentsAreSayingSliderArr.push( '<li>' + jQuery(this).html() + '</li>' );
      });

      // Clears Parents are Saying Slider Contents
      $(".parents-are-saying-container").html('');

      // Initializes Parents are Saying Slider
      responsiveSliderChange( parentsAreSayingSliderArr, false, jQuery('.parents-are-saying-container'), 3, true, 500, 150, 2);

      ///////////////////////////////// End Parents are Saying Slider /////////////////////////////////


      ///////////////////////////////// Partners Slider /////////////////////////////////

      // Pushes Partners Slider items into an array
      jQuery("#partners-slides-container li").each(function(){
        partnersSliderArr.push( '<li>' + jQuery(this).html() + '</li>' );
      });

      // Clears Partners Slider Contents
      $("#partners-slides-container").html('');

      // Saves 'View All' anchor element and removes it from the DOM
      partnersAnchor = $("#partners-slides-container").next('a.view-all');
      $("#partners-slides-container").next('a.view-all').remove();

      // Initializes Partners Slider
      responsiveSliderChange( partnersSliderArr, false, jQuery('#partners-slides-container'), 6, false, 1000, false, 4, 2);
      jQuery("#partners-slides-container .rsArrowLeft").after(partnersAnchor);

      ///////////////////////////////// End Partners Slider /////////////////////////////////


      ///////////////////////////////// Topic Slider /////////////////////////////////

      // Pushes Partners Slider items into an array
      topicSliderHtml = jQuery("#topic-carousel").html();

      // Clears Partners Slider Contents
      //  $("#topic-carousel").html('');
      jQuery("#topic-carousel .rsTmb").each(function(){
        topicTitles.push( jQuery(this).html() );
      });

      // Call topic carousel
      topicCarousel(jQuery('#topic-carousel'), false, topicSliderHtml);

    });


    // On Window Resize: Delay, then call responsiveSliderSize function to initialize or destroy slider

    $(window).on('resize', function(){

      waitForFinalEvent(function(){
        responsiveSliderChange( featuredSliderArr, true, jQuery('#featured-slides-container'), 3, false, 1000, false );
      }, 500, 'featuredSlider');

      waitForFinalEvent(function(){
        responsiveSliderChange( moreSliderArr, true, jQuery('#more-carousel-slides-container'), 3, false, 1200, 400 );
      }, 500, 'moreSlider');

      waitForFinalEvent(function(){
        topicCarousel(jQuery('#topic-carousel'), true, topicSliderHtml);
      }, 500, 'topicSlider');

      waitForFinalEvent(function(){
        responsiveSliderChange( exploreSliderArr, true, jQuery('.more-to-explore-container'), 3, true, 700, false, 2);
        new U.moreToExploreForm();
      }, 500, 'exploreSlider');

      waitForFinalEvent(function(){
        responsiveSliderChange( commentGallerySliderArr, true, jQuery('.comment-gallery-container'), 3, true, 700, 150, 2);
      }, 500, 'commentGallerySlider');

      waitForFinalEvent(function(){
        responsiveSliderChange( parentsAreSayingSliderArr, true, jQuery('.parents-are-saying-container'), 3, true, 700, 150, 2);
      }, 500, 'parentsAreSayingSlider');

      waitForFinalEvent(function(){
        responsiveSliderChange( partnersSliderArr, true, jQuery('#partners-slides-container'), 6, false, 1000, false, 4, 2);
        if(Modernizr.mq('(min-width: 960px)')){
          jQuery("#partners-slides-container .rsArrowLeft").after(partnersAnchor);
        }
      }, 500, 'partnersSlider');

        for (var i = onResizeEvent.length - 1; i >= 0; i--) {
            waitForFinalEvent(onResizeEvent[i][0], 50, onResizeEvent[i][1]);
        }
    });

    // Initialize Carousels outside of document.ready

    $("#hero-carousel-wrapper").royalSlider({
      keyboardNavEnabled: true,  // enable keyboard arrows nav
      loop: true,
      arrowsNav: true,
      arrowsNavHideOnTouch: true,
      randomizeSlides: true, // FIXME: needs to be exposed in-page for integration
      autoPlay: {
        delay: 6000,
        enabled: true,
        pauseOnHover: true
      },
      slidesSpacing: 0,
      sliderDrag: false
    });

      U.carousels.initializeSlider = function(container, slideSelector, navigation, itemsPerSlide, itemsPerSlideMedium, itemsPerSlideMobile, resizeCallback, destroyOnResize) {
          var sliderArr = [];
          destroyOnResize = typeof(destroyOnResize) !== 'undefined' ? destroyOnResize : true;

          // Pushes Featured Slider items into an array
          container.find(slideSelector).each(function(){
              var html = jQuery(this).get(0).outerHTML;
              if (html) {
                  sliderArr.push( '<li>' + html + '</li>' );
              }
          });

          // Clears Featured Slider Contents
          container.html('');

          var slider = resetSlider(container, sliderArr, slideSelector, navigation, itemsPerSlide, itemsPerSlideMedium, itemsPerSlideMobile, false);

          onResizeEvent.push([
              function () {
                  if (destroyOnResize) {
                      navigation.off('click');

                      resetSlider(container, sliderArr, slideSelector, navigation, itemsPerSlide, itemsPerSlideMedium, itemsPerSlideMobile, true);
                  }

                  if (resizeCallback) {
                      resizeCallback();
                  }
              },
              onResizeEvent.length + 'responsiveSlider']);

          return slider;
      };

      var resetSlider = function(container, sliderArr, slideSelector, navigation, itemsPerSlide, itemsPerSlideMedium, itemsPerSlideMobile, sliderExists) {
          responsiveSliderChange( sliderArr, sliderExists, container, itemsPerSlide, false, 500, 350, itemsPerSlideMedium || 1, itemsPerSlideMobile || 1);
          container.height(container.find(slideSelector).eq(0).height());
          container.find(".rsArrow").not('.arrows .rsArrow').remove();
          container.css('visibility', 'visible').fadeIn();

          var slider = container.data('royalSlider');

          navigation.on('click', '.rsArrow', function (e) {
              var $this = $(this);
              if ($this.hasClass('rsArrowLeft')) {
                  slider.prev();
              } else if ($this.hasClass('rsArrowRight')) {
                  slider.next();
              }
          });

          var updateNavArrows = function() {
              var $leftArrow = navigation.find('.rsArrowLeft');
              var $rightArrow = navigation.find('.rsArrowRight');
              $leftArrow.removeClass('rsArrowDisabled');
              $rightArrow.removeClass('rsArrowDisabled');

              if (slider.currSlideId === 0) {
                  $leftArrow.addClass('rsArrowDisabled');
              }

              if (slider.currSlideId === slider.numSlides - 1) {
                  $rightArrow.addClass('rsArrowDisabled');
              }
          };

          updateNavArrows();
          slider.ev.on('rsAfterSlideChange', updateNavArrows);

          return slider;
      };

  };
  

  // Initialize the module on page load.
  // FIXME: this was moved to the bottom of the file and outside of a doc.ready context in order to fix UN-2281. it needs to be revisited.
  new U.carousels();


})(jQuery);


/**
 * Definition for the behaviorTool javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.selectMenu();
  });

  U.selectMenu = function(){

    var self = this;

    self.init = function(){

      // get vars
      self.$selectWrap = $('.select-container');
      self.$select = $('select');

      // set width of select
      function setWidth() {
        self.$selectWrap.each(function() {
          if ($(this).is(':visible')) {
            $(this).find('.selector').css('width', $(this).width());
          }
        });
      }

      self.$select.each(function() {

        // style form elements
        $(this).uniform()

        // style the select boxes upon valid selection
        .on('change keyup', function() {

          $(this).find('option:selected').each(function(){
            // if selection is empty, it is not valid
            if ( $(this).val() === "" ){
              $(this).parents('.selector').removeClass('selected');
            }
            else {
              $(this).parents('.selector').addClass('selected');
            }
          });

          setWidth();
        })

        //make select boxes go 100%
        .siblings('span').css('width', '100%').parent('.selector').css('width', '100%');
        
        // make selects stretch to fit parent container
        setWidth();

      });

      $(window).on('resize.selectMenu', setWidth);

    };

    self.init();

  };

})(jQuery);
/**
 * Definition for the moreToExploreForm javascript module.
 */


(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.moreToExploreForm();
  });

  U.moreToExploreForm = function(){

    var self = this;

    self.init = function(){

      self.$exploreForm = $('.more-to-explore-form');

      if(!self.$exploreForm.length) { return false; }

      // get form vars
      self.$module = self.$exploreForm.find('li');
      self.$fieldset = self.$exploreForm.find('fieldset');
      self.$select = self.$exploreForm.find('select');

      function setWidth() {
        self.$moduleWidth = self.$fieldset.width();
        self.$select.parent('.selector').css('width', self.$moduleWidth);
      }

      // style form elements
      self.$select.uniform();

      // make select boxes go 100%
      self.$select.siblings('span').css('width', '100%').parent('.selector').css('width', '100%');

      // style the select boxes upon valid selection
      self.$select.on('change keyup', function() {

        setWidth();

        $(this).find('option:selected').each(function(){
          // if selection is empty, it is not valid
          if ( $(this).val() === "" ){
            $(this).parents('.selector').removeClass('selected');
          }
          else {
            $(this).parents('.selector').addClass('selected');
          }
        });
      });

      $(window).on('resize.moreToExplore', setWidth);

    };

    self.init();

  };
})(jQuery);
/**
 * Definition for the guideMeOverlay javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.guideMeOverlay();
  });

  U.guideMeOverlay = function(){

    var self = this;

    self.init = function(){

      // Make vars
      self.$buttonGuideMe = $('.button-guide-me');
      self.$guideMeOverlay = $('.container-guide-me-overlay');
      self.$parentToolkit = $('.parent-toolkit');
      self.$guideMeClose = $('.close-guide');
      self.$guideMeInner = $('.guide-me-inner');
      self.$guideMe = $('.guide-me');
      self.$heroCarousel = $('.hero-carousel');
      self.$slider = $('#hero-carousel-wrapper').data('royalSlider');
      self.$gradeSelect = $('.container-guide-me-overlay .select-grade').find('a');
      self.$gradeField = $('#guideme-grade-desktop');
      self.$mobileSelect = $('.container-guide-me-overlay fieldset select');

      if(!self.$buttonGuideMe.length) { return false; }

      // style checkboxes / mobile select
      $('.container-guide-me-overlay fieldset input, .container-guide-me-overlay fieldset select').uniform();

      // make select boxes go 100%
      self.$mobileSelect.siblings('span').css('width', '100%').parent('.selector').css('width', '100%');

      // make select boxes turn purple, or the selected state on valid selection
      self.$mobileSelect.on('change keyup', function() {
        $(this).find('option:selected').each(function(){
          // if selection is empty, it is not valid
          if ( $(this).val() === "" ){
            $(this).parents('.selector').removeClass('selected');
          }
          else {
            $(this).parents('.selector').addClass('selected');

          }
        });
      });

      // TO DO: Reattach the detached on resize
      // use a form <select> for mobile grade selector, and use custom form elements for desktop, with hidden field
      // on mobile, detach the hidden field
      // on desktop, detach the select field
      // restore the hidden fields or select in respective viewport size

      function whichSelect(){
        if(Modernizr.mq('(min-width: 650px)')){
          self.$mobileSelectDetached = $('.guideme-grade-mobile').detach();
        } else {
          self.$desktopSelectDetached = $('#guideme-grade-desktop').detach();
        }
      };

      // Open overlay function
      self.openOverlay = function() {

        // Guide Me container height
        self.$guideMeHeight = self.$guideMe.height();
        // Hero Carousel height
        self.$heroCarouselHeight = self.$heroCarousel.height();
        // Guide Me Overlay height
        self.$guideMeOverlayHeight = self.$guideMeOverlay.height();
        // Used during overlay transition
        self.$parentToolKitMarginTop = self.$guideMeOverlayHeight - self.$heroCarouselHeight - self.$guideMeHeight;

        if (self.$guideMeOverlay.css('display') == 'none'){ //if overlay is not visible
          self.$guideMe.height(self.$guideMeHeight);
          self.$guideMeOverlay.fadeIn();
          self.$parentToolkit.css('margin-top', self.$parentToolKitMarginTop);
          self.$guideMeInner.fadeOut();
          self.$slider.stopAutoPlay(); //stop slider
        }
        whichSelect();

        // scroll to top of overlay when opened
        $('html,body').animate({scrollTop: $(self.$guideMeOverlay).offset().top}, 500);
      };

      // Close overlay function
      self.closeOverlay = function(e) {
        /* 
        *  Detect if the event is a resize and the device supports touch
        *  This is needed because on android when the select box is opened if fires
        *  multiple resize events which in turnclose the module
        */
        if(e.type == 'resize' && Modernizr.touch){
          return false;
        }
      
        self.$guideMe.height('auto');
        self.$guideMeOverlay.fadeOut();
        self.$parentToolkit.css('margin-top', '0px');
        self.$guideMeInner.fadeIn();
        self.$slider.startAutoPlay(); //start slider
      };

      // Trigger overlay open
      self.$buttonGuideMe.on('click', function(e){
        e.preventDefault();
        self.openOverlay();
      });

      // Trigger overlay close
      self.$guideMeClose.on('click', function(e){
        e.preventDefault();
        self.closeOverlay(e);    
      });

      // Grades - Add to Hidden Form Field
      self.$gradeSelect.on('click', function(e){
        e.preventDefault();
        var $this = $(this);

        // give selected grade active class and remove active from siblings
        if (!$(this).hasClass('active')) {
          $(this).addClass('active').siblings('a').removeClass('active');
          // give hidden field the value from the grade ID
          self.$gradeField.val($(this).attr('id'));
        }
        else {
          $(this).removeClass('active');
          // clear hidden field value from the grade ID
          self.$gradeField.val('');
        }

        this.blur();
      });

      // resize event
      $(window).on('resize.guideMeOverlay', self.closeOverlay);

    };

    self.init();

  };

})(jQuery);
/**
 * Definition for the yourParentToolkit javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.yourParentToolkit();
  });

  /*
   * Parent Toolkit in Header Module
   *
   */
  U.yourParentToolkit = function(){

    var self = this;

    function init() {
      self.$toolkit = $('#toolkit');
      self.$toolkit_wrapper = $('#parent-toolkit-wrapper');
      self.$toolkit_container = self.$toolkit_wrapper.find('div.parent-toolkit-header-container');
      self.$slides_container = $('.slides-container');
      self.$slides_org = self.$slides_container.find('div.slide').clone();
      self.$items = self.$slides_container.find('li');
      self.is_desktop = false; 
      self.is_open = false;

      self.$toolkit.on('click', function(){
        var $this = $(this);
        if(self.is_open){
          self.is_open = false;
          close($this);
        } else {
          self.is_open = true;
          open($this);
        }
      });

      if(!Modernizr.touch){

        self.$toolkit_wrapper.find('.button-close').hide();

        var toolkit_delay;
        self.$toolkit_container.hover(
          function() {
            clearTimeout(toolkit_delay);
          }, function() {
            toolkit_delay = setTimeout(function() {
              close();
              self.is_open = false;
            }, 3000);
          }
        );
      }

      self.$toolkit_wrapper.find('.button-close').on('click', function(){
        close();
        self.is_open = false;
      });

      // on window resize run resize()
      $(window).on('resize.yourParentToolkit', resize);

      // on init run resize()
      resize();

    };

    // show the toolkit and update the slider size
    function open() {
      self.$toolkit_wrapper.show();
      self.$toolkit_container.hide().fadeIn();
      self.$toolkit.addClass('is-open');
      self.$rs.royalSlider('updateSliderSize');
    };

    // hide the toolkit
    function close() {
      self.$toolkit_container.fadeOut('normal', function() {
        self.$toolkit_wrapper.hide();
    });
      self.$toolkit.removeClass('is-open');
    };


    // on resize detect the viewport width
    // if > 768 sort the slides in groups of 4
    function resize() {
      if(Modernizr.mq('(min-width: 769px)') && self.is_desktop == false){
        // empty out the slides container
        self.$slides_container.empty();
        // loop through all of the items and inject 4 at a time inside <div class="slide"><ul></ul></div>
        self.$items.each(function(i, el){
          if(i%4 == 0){
            var tmp =  self.$items.slice(i, i+4);
            var $slide_wrapper = $('<div class="slide">');
            var $li_wrapper = $('<ul>');
            var slide = $slide_wrapper.append($li_wrapper.append(tmp));
            self.$slides_container.append(slide);
          }
        });
        initSlider();
        self.is_desktop = true;
      // if < 768 empty out the container and append the original markup
      } else if(Modernizr.mq('(max-width: 768px)') && self.is_desktop == true) {

        /* FIXME
        *
        *  Getting an error related to destroying and recalling the slider in the parent toolkit in header
        *  Uncaught TypeError: Cannot call method 'width' of null 
        *
        */
        self.$slides_container.empty();

        self.$slides_container.append(self.$slides_org);

        self.is_desktop = false;       

        destroySlider();
      }
    };

    // create the royalSlider
    function initSlider(){
      self.$rs = self.$slides_container.royalSlider({
        keyboardNavEnabled: true,  // enable keyboard arrows nav
        loop: false,
        autoHeight: true,
        arrowsNav: true,
        arrowsNavAutoHide: false,
        autoPlay: {
          delay: 4000,
          enabled: false
        },
        sliderDrag: false
      });
    };

    // destroy the sliders events
    function destroySlider() {
      self.$rs.royalSlider('destroy');
    };

    // initialize the toolkit
    init();

  };

})(jQuery);
/**
 * Definition for the article slideshow javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.articleSlideshow();


    // Hover states for the icons below slideshow
    $('.article-slideshow-container .buttons-container .icon-plus').click(function(){
      if($(this).hasClass('active')){
        $(this).removeClass('active');
      }else{
        $(this).addClass('active');
      }
    });

    $('.article-slideshow-container .buttons-container .icon-bell').click(function(){
      if($(this).hasClass('active')){
        $(this).removeClass('active');
      }else{
        $(this).addClass('active');
      }
    });
  });



  U.articleSlideshow = function(){
    var self = this;

    self.init = function(){
      self.$container = $('#article-slideshow');
      if (self.$container.length) {
        self.$org = self.$container.clone();
        self.initslide();
        $(window).on('resize', self.checker);
      }

      $('.index-buttons-container .button').click(self.indexButtonClick);
      $('#article-slideshow .restart-slideshow').click(self.restartSlideshow);
    };
    self.initslide = function(){
      self.$rs = self.$container.royalSlider({
        keyboardNavEnabled: true,
        loop: false,
        controlNavigation: 'bullets',
        autoScaleSlider: false,
        navigateByClick: false,
        arrowsNav: true,
        arrowsNavAutoHide: false,
        autoHeight: true,
        addActiveClass: true,
        autoPlay: {
          delay: 4000,
          enabled: false
        },
        deeplinking: {
          enabled: true,
          change: true,
          prefix: 'slide-'
        },
        sliderDrag: false
      });

      $('.article-slideshow-container').prepend( $('#article-slideshow .rsArrowRight') );
      $('.article-slideshow-container').prepend( $('#article-slideshow .rsArrowLeft') );

      self.updateActiveSlide();
      self.$rs.data('royalSlider').ev.on('rsAfterSlideChange', self.updateActiveSlide);
      self.$rs.data('royalSlider').ev.on('rsBeforeAnimStart', self.hideArrows);

    };

    self.destroySlide = function(){
      // remove the rs from the dom
      self.$rs.destroy();
      self.$rs.remove();

      // append the original
      self.$org.prependTo('.article-slideshow-container');

      // cache the original again
      self.$container = $('#article-slideshow');

      // clone it
      self.$org = self.$container.clone();
    };

    self.checker = function(){
      if (self.$rs.destroy) {
        self.destroySlide();
        self.initslide();
      }
    };

    self.indexButtonClick = function() {
      var slider = self.$rs.data('royalSlider');

      if ($(this).hasClass('disabled')) {
        return;
      }
      else if ($(this).hasClass('first')) {
        slider.goTo(0);
      }
      else if ($(this).hasClass('last')) {
        slider.goTo(slider.numSlides-1);
      }
      else if ($(this).hasClass('next')) {
        slider.next();
      }
      else if ($(this).hasClass('prev')) {
        slider.prev();
      }
      else {
        var slideId = $(this).attr('data-target');
        if (slideId) {
          slider.goTo(slideId-1);
        }
      }
    };

    self.restartSlideshow = function(e) {
      e.preventDefault();
      var slider = self.$rs.data('royalSlider');
      slider.goTo(0);
    };

    self.updateActiveSlide = function(event) {
      var slider = self.$rs.data('royalSlider');
      $('.index-buttons-container .button.active').removeClass('active');
      // add 1 to skip the prev button
      $('.index-buttons-container .button').eq(slider.currSlideId + 1).addClass('active');

      if (slider.currSlideId === 0) {
        $('.index-buttons-container .button.prev').addClass('disabled');
      }
      else {
        $('.index-buttons-container .button.prev').removeClass('disabled');
      }

      if (slider.currSlideId == slider.numSlides-1) {
        $('.index-buttons-container .button.last').html('Start Over');
        $('.index-buttons-container .button.last').addClass('first');
        $('.index-buttons-container .button.next').addClass('disabled');
      }
      else {
        $('.index-buttons-container .button.last').html('Last');
        $('.index-buttons-container .button.last').removeClass('first');
        $('.index-buttons-container .button.next').removeClass('disabled');
      }

      self.repositionArrows();
    };

    self.repositionArrows = function() {
      var currSlide = $('#article-slideshow .rsActiveSlide .slide');
      if (currSlide.hasClass('end')) {
        $('.slideshow-review').css({display: "block"});
      }
      else {
      $('.slideshow-review').css({display: "none"});
      }
      // we have to wait until rsActiveSlide is set
      if (!currSlide.length) {
        setTimeout(self.repositionArrows, 100);
        return;
      }

      if (currSlide.hasClass('wide-image')) {
        if (Modernizr.mq('(max-width: 480px)')) {
          $('#article-slideshow .rsArrowIcn').css('top', '35px');
        }
        else if (Modernizr.mq('(max-width: 650px)')) {
          $('#article-slideshow .rsArrowIcn').css('top', '70px');
        }
        else {
          $('#article-slideshow .rsArrowIcn').css('top', '225px');
        }
      }
      else if (currSlide.hasClass('tall-image')) {
        if (Modernizr.mq('(max-width: 650px)')) {
          $('#article-slideshow .rsArrowIcn').css('top', '240px');
        }
        else {
          $('#article-slideshow .rsArrowIcn').css('top', '320px');
        }
      }
      else if (currSlide.hasClass('end')) {
        if (Modernizr.mq('(max-width: 650px)')) {
          $('#article-slideshow .rsArrowIcn').css('top', '40%');
        }
        else {
          $('#article-slideshow .rsArrowIcn').css('top', '190px');
        }
      }
      else if (currSlide.hasClass('text-slide')) {
        if (Modernizr.mq('(max-width: 650px)')) {
          $('#article-slideshow .rsArrowIcn').css('top', '20%');
        }
        else {
          $('#article-slideshow .rsArrowIcn').css('top', '38%');
        }
      }

      $('#article-slideshow .rsArrowIcn').fadeIn('fast');
    };

    // this makes the repositioning of the arrows less jarring
    self.hideArrows = function(event) {
      $('#article-slideshow .rsArrowIcn').hide();
    };

    self.init();
  };

})(jQuery);
/**
 * Definition for the commentList javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.commentList();
  });

  U.commentList = function() {
    var self = this;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      var uniform_components = [
        '.comment-sort',
        '.comment-form-reply',
        '.comment-form-submit'
      ].join(',');

      // Build uniform components.
      $(uniform_components).uniform();

      // Attach events.
      $(window).resize(function() { self.resizeElements(); });

      return this.resizeElements();
    };

    /**
     * Fire resize events for select boxes and actions.
     * @return {object} this instance
     */
    this.resizeElements = function() {
      return this.resizeSelect().resizeActions();
    };

    /**
     * Dynamically resize "Sort By" select box.
     * @return {object} this instance
     */
    this.resizeSelect = function() {
      var resize_selectors = [
        '.comment-list .selector',
        '.comment-list .selector span'
      ].join(',');

      var MAX_SELECT_WIDTH = (Modernizr.mq('(min-width: 480px)')) ? 190 : 480;
      var width = $('#wrapper').css('width').split('px')[0] * 0.833333;
      $(resize_selectors).css({
        'max-width': (width < MAX_SELECT_WIDTH) ? width : MAX_SELECT_WIDTH,
        'width': '100%'
      });

      return this;
    };

    /**
     * Dynamically equalize comment action button heights.
     * @return {object} this instance
     */
    this.resizeActions = function() {
      $('.comment-actions a').equalHeights();
      return this;
    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the at search tool conditions.
 */

 (function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.searchTool();
    new U.searchToolFindButton();

    $(window).resize(function(){
      U.searchToolFindButton();
    });
  });

  U.searchTool = function(){
    var self = this;

    // style checkboxes / mobile select
    // initiate uniform before selecting containers generated by uniform.
    $('#search-by-tool-tabs input[type=text], #search-by-tool-tabs select').uniform({'selectedClass':'selected'});

    // cache selectors
    var searchByToolTabs = $('#search-by-tool-tabs');
    var atBrowseByTechnology = $('#at-browse-by-technology');
    var atBrowseByApp = $('#at-browse-by-app');
    var uniformAtBrowseByApp = $('#uniform-at-browse-by-app');
    var atBrowseByGames = $('#at-browse-by-games');
    var uniformAtBrowseByGames = $('#uniform-at-browse-by-games');

    // initiate easytabs for the 'browse by', 'search by' buttons
    searchByToolTabs.easytabs();

    self.atSearchSelect = $('#browse-by select');

    // make select boxes go 100%
    self.atSearchSelect.siblings('span').css('width', '100%').parent('.selector').css('width', '100%');

    //NOTE - uniform will auto hide elements with inline display:none;

    searchByToolTabs.on('change', function() {
      if( atBrowseByTechnology.val() == "at-browse-by-app" ){
        atBrowseByGames.hide();
        uniformAtBrowseByGames.hide();
        atBrowseByApp.show();
        uniformAtBrowseByApp.show();
      }else if( atBrowseByTechnology.val() == "at-browse-by-games" ){
        atBrowseByApp.hide();
        uniformAtBrowseByApp.hide();
        atBrowseByGames.show();
        uniformAtBrowseByGames.show();
      }else{
        atBrowseByApp.hide();
        uniformAtBrowseByApp.hide();
        atBrowseByGames.hide();
        uniformAtBrowseByGames.hide();
      }
    });

    return this;
  };

  U.searchToolFindButton = function(){
    var self = this;

    //cache selectors
    var searchByToolTabsFind = $('#search-by-tool-tabs input[type=submit]');

    if(Modernizr.mq('(min-width: 769px)')){
      searchByToolTabsFind.val('Find');
    }else{
      searchByToolTabsFind.val('Go');
    }

    return this;
  }

})(jQuery);
// @TODO: this code is a test. this is incomplete

/**
 * Definition for the Transcript Control javascript module.
 */

$(function(){
var slideheight = 310;
$(".transcript-container").each(function() {
  var $this = $(this);
  var $wrap = $this.children(".transcript-wrap");
  var defheight = $wrap.height();
  $wrap.css('height', 0);
      var $readmore = $this.find(".read-more");
      $readmore.append('<a href="REMOVE">Read Transcript<i class="icon-arrow-down-blue"></i></a>');
      $readmore.children("a").bind("click", function(event) {
        var curheight = $wrap.height();
        if (defheight < slideheight) {
          if (curheight != defheight) {
            $wrap.animate({
              height: defheight
              }, "normal");
            $(this).html("<a href='REMOVE'>Close Transcript<i class='icon-arrow-up-blue'></i></a>");
          } else {
            $wrap.animate({
            height: 0
            }, "normal");
            $(this).html("<a href='REMOVE'>Read Transcript<i class='icon-arrow-down-blue'></i></a>");
          } 
        }
        else {
           if (curheight == slideheight) {
            $wrap.animate({
            height: defheight
            }, "normal");
            $(this).html("<a href='REMOVE'>Close Transcript<i class='icon-arrow-up-blue'></i></a>");
          } else if (curheight == defheight) {
            $wrap.animate({
              height: 0
            }, "normal");
            $(this).html("<a href='REMOVE'>Read Transcript<i class='icon-arrow-down-blue'></i></a>");
          } else {
            $wrap.animate({
              height: slideheight
            }, "normal");
            $(this).html("<a href='REMOVE'>More<i class='icon-arrow-down-blue'></i></a>");
          }
        }
        return false;
      });
});
});
/**
 * Definition for the glossaryTabs javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.glossaryTabs();
  });

  U.glossaryTabs = function() {
    var self = this;

    $('#glossary-tab').easytabs();

    return this;
  };

})(jQuery);
jQuery(document).ready(function(){
  var knowledgeQuizFormElements = [
    '.knowledge-quiz select',
    '.knowledge-quiz input'
  ].join(',');

  // Build uniform components.
  jQuery(knowledgeQuizFormElements).uniform();
});
$(document).ready(function() {


  var article_poll_uniform_components = [
    '.article-poll .poll-question-right select',
    '.article-poll .poll-question-right input',
    '.article-poll .poll-question-right a.button',
    '.article-poll .poll-question-right button'
  ].join(',');

  // Build uniform components.
  jQuery(article_poll_uniform_components).uniform();
}); //end document ready
;
jQuery(document).ready(function(){
  jQuery("#audio-player-1").jPlayer({
    ready: function () {
      jQuery(this).jPlayer("setMedia", {
        m4a: "http://www.jplayer.org/audio/m4a/Miaow-07-Bubble.m4a",
        oga: "http://www.jplayer.org/audio/ogg/Miaow-07-Bubble.ogg"
      });
    },
    cssSelectorAncestor: '#audio-player-interface-1',
    swfPath: "/../../js/vendor",
    supplied: "m4a, oga",
    fullWindow: false,
    audioFullScreen: false,
    smoothPlayBar: false
  });
});
/**
 * Definition for the assessmentQuiz javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.assessmentQuiz();
  });

  U.assessmentQuiz = function() {
    var self = this;

    // The modal window DOM element.
    this.$modalWindow = null;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      var uniform_elements = [
        '.assessment-quiz input[type=radio]'
      ].join(',');

      this.$modalWindow = $('.assessment-quiz-modal');
      if (this.$modalWindow.length) {
        this.$modalWindow.detach();

        // Add modal window to end of body.
        $('body').append(this.$modalWindow);
        $('.assessment-quiz-modal').modal({
          backdrop: 'static',
          show: false
        });

        $('.assessment-quiz-next').click(this.openModal);
        $('.assessment-quiz-modal .button').click(this.closeModal);
      }


      // Build uniform components.
      $(uniform_elements).uniform();

      // Attach events.
      $(window).resize(function() {
        self.resizeSelect();
      });

      return this.resizeSelect();
    };

    /**
     * Open the modal window.
     * @return {object} this instance
     */
    this.openModal = function(e) {
      e.preventDefault();
      $('.assessment-quiz-modal').modal('show');
    };

    /**
     * Close the modal window.
     * @return {object} this instance
     */
    this.closeModal = function(e) {
      e.preventDefault();
      $('.assessment-quiz-modal').modal('hide');
    };

    /**
     * Dynamically resize "Sort By" select box.
     * @todo Consider refactor/merge with U.commentList::resizeSelect().
     * @return {object} this instance
     */
    this.resizeSelect = function() {
      var resize_selectors = [
        '.assessment-quiz .selector',
        '.assessment-quiz .selector span'
      ].join(',');

      var MAX_SELECT_WIDTH = 390;
      var width = $('#wrapper').css('width').split('px')[0] * 0.833333;
      $(resize_selectors).css({
        'max-width': (width < MAX_SELECT_WIDTH) ? width : MAX_SELECT_WIDTH,
        'width': '100%'
      });

      return this;
    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the toolkit thumbnails javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.toolkitThumbnails();
  });


  U.toolkitThumbnails = function(){
    var self = this;

    self.init = function(){
      self.$container = $('#toolkit-thumbnails');
      if (self.$container.length) {
        self.$org = self.$container.clone();
        self.setupSlider();
        $(window).on('resize', self.resize);
      }
    };

    self.setupSlider = function(){
      if (self.$rs && self.$rs.length) {
        self.destroySlide();
      }
      if (Modernizr.mq('(max-width: 959px)')) {
        self.$rs = self.$container.royalSlider({
          arrowsNav: true,
          arrowsNavAutoHide: false,
          arrowsNavHideOnTouch: false,
          fadeinLoadedSlide: true,
          keyboardNavEnabled: true,
          imageAlignCenter: false,
          slidesSpacing: 1,
          loop: true,
          loopRewind: true,
          numImagesToPreload: 4,
          autoScaleSlider: true,
          autoPlay: {
            enabled: false,
            pauseOnHover: true,
            delay: 2000
          },
          sliderDrag: false
        });

        // remove the clearfix
        self.$rs.data('royalSlider').removeSlide(self.$rs.data('royalSlider').numSlides-1);
      }
    };

    self.resize = function() {
        self.waitForFinalEvent(function(){
          self.setupSlider();
        }, 500, 'toolkitThumbnails');
    };

    self.destroySlide = function(){
      // remove the rs from the dom
      self.$rs.remove();
      self.$rs = null;

      // append the original
      self.$org.prependTo('.toolkit-thumbnails-container .inner-container');

      // cache the original again
      self.$container = $('#toolkit-thumbnails');

      // clone it
      self.$org = self.$container.clone();
    };

    self.init();

    self.waitForFinalEvent = (function () {
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
  };



})(jQuery);
/**
 * Definition for the personalizeChecklist javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.personalizeChecklist();
  });

  U.personalizeChecklist = function() {
    var self = this;

    /**
     * The modal window DOM element.
     */
    this.$modalWindow = $('.personalize-checklist-modal');

    if (!this.$modalWindow.length) {
      // If no modal exists, we're done here.
      return this;
    }
    else {
      // Temporarily move component out of DOM.
      this.$modalWindow.detach();
    }

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      var uniform_components = [
        '.personalize-checklist input',
        '.personalize-checklist select'
      ].join(',');

      // Add modal window to end of body.
      $('body').append(this.$modalWindow);

      // Build uniform components.
      $(uniform_components).uniform();

      $('.checklist-close').click(this.closeModal);

      $('.personalize-checklist-modal').modal({
        backdrop: 'static',
        show: false
      });

      return this.resizeElements().openModal();
    };

    /**
     * Open the modal window.
     * @return {object} this instance
     */
    this.openModal = function() {
      $('.personalize-checklist-modal').modal('show');
    };

    /**
     * Open the modal window.
     * @return {object} this instance
     */
    this.closeModal = function() {
      $('.personalize-checklist-modal').modal('hide');
    };

    /**
     * Resize form elements to fit full width.
     */
    this.resizeElements = function() {
      var resize_selectors = [
        '.personalize-checklist .selector',
        '.personalize-checklist .selector span',
        '.personalize-checklist input.text'
      ].join(',');

      $(resize_selectors).css({
        'max-width': '250px',
        'width': '100%'
      });

      return this;
    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the articleChecklist javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.articleChecklist();
  });

  U.articleChecklist = function() {
    var self = this;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      var uniform_elements = [
        '.article-checklist input[type=checkbox]',
        '.checklist-form-save',
        '.checklist-form-download'
      ].join(',');

      // Build uniform components.
      $(uniform_elements).uniform();

      // Attach events.
      $(window).resize(function() {
        self.resizeActions();
      });

      // Auto-check all checkboxes if question is clicked.
      $('.checklist-question').click(function() {
        $(this).siblings('.checkboxes-wrapper').each(function() {
          $(this).find('.checked input').click();
          $(this).find('input').click();
        });
      });

      return this.resizeActions();
    };

    /**
     * Dynamically change width/margin of checklist action buttons.
     * @return {object} this instance
     */
    this.resizeActions = function() {
      var resize_selectors = [
        '.article-checklist .button',
        '.article-checklist .button span'
      ].join(',');

      var MAX_BUTTON_WIDTH = (Modernizr.mq('(min-width: 650px)')) ? 250 : 650;
      var width = $('#wrapper').css('width').split('px')[0] * 0.833333;
      $(resize_selectors).css({
        'border-right': 'none',
        'max-width': (width < MAX_BUTTON_WIDTH) ? width : MAX_BUTTON_WIDTH,
        'width': '100%'
      });

      return this;
    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the tryAnotherQuiz javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.tryAnotherQuiz();
  });

  U.tryAnotherQuiz = function() {
    var self = this;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {

      // only above 650 viewport
      if(Modernizr.mq('(min-width: 650px)')){

        // give set-height class to 2 modules
        $('.quiz').addClass('set-height');

        // give set-height class items same height
        $('.set-height').equalHeights();

      }
      return this;
    };

    return this.initialize();
  };

})(jQuery);
jQuery(document).ready(function(){

  // cache comments summary text container
  var commentsSummary = jQuery('.comments-summary blockquote > p');
  //limit text to 100 characters.
  CommentsSummaryTextLimit(commentsSummary, 100);

}); //end document ready

/*
 * Limits the number of characters in a field
 */
function CommentsSummaryTextLimit(limitField, limitNum) {
  if (limitField.text().length > limitNum) {
    limitField.html(limitField.text().substring(0, limitNum) + ' &hellip; <a href="REPLACE">Read more</a>');
  }
}
;
/**
 * Definition for the behaviorAdvice javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.behaviorAdvice();
  });

  U.behaviorAdvice = function() {
    var self = this;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {

    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the shareSave javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.shareSave();
  });

  U.shareSave = function() {
    var self = this;

    $('.icon-share').click(function() {

      jQuery('.share-save-social-icon .toggle').toggle();
      jQuery(this).toggleClass('active');
      jQuery(this).parent('.share-save-icon').toggleClass('is-open');
    });
    
    return this;
  };
})(jQuery);
jQuery(document).ready(function(){

  ////////////// First Next Prev Menu //////////////
  //cache elements
  var firstNextPrevMenuArrowLeft = jQuery('.first-next-prev-menu .rsArrowLeft'); //left arrow
  var firstNextPrevMenuArrowRight = jQuery('.first-next-prev-menu .rsArrowRight'); //right arrow
  var firstNextPrevMenuText = jQuery('.first-next-prev-menu .next-prev-text'); //text

  //change text when hovering over the arrows
  firstNextPrevMenuArrowLeft.hover(function(){
    firstNextPrevMenuText.text('Prev Tip');
  });
  firstNextPrevMenuArrowRight.hover(function(){
    firstNextPrevMenuText.text('Next Tip');
  });
  jQuery('.first-next-prev-menu .rsArrowLeft, .first-next-prev-menu .rsArrowRight').mouseout(function(){
    firstNextPrevMenuText.text('Next Tip');
  });

});
/**
 * Definition for the article secondNextPrevMenu javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.secondNextPrevMenu();
  });


  U.secondNextPrevMenu = function(){
    var self = this;

    self.init = function(){
      self.$container = $('.second-next-prev-menu-slider');
      if (self.$container.length) {
        self.$org = self.$container.clone();
        self.initslide();
        $(window).on('resize', self.checker);
      }

    };

    self.initslide = function(){
      self.$rs = self.$container.royalSlider({
        keyboardNavEnabled: true,
        loop: false,
        controlNavigation: 'bullets',
        autoScaleSlider: false,
        arrowsNav: true,
        arrowsNavAutoHide: false,
        autoHeight: true,
        addActiveClass: true,
        autoPlay: {
          delay: 4000,
          enabled: false
        },
        deeplinking: {
          enabled: true,
          change: true,
          prefix: 'slide-'
        },
        sliderDrag: false
      });

      ////////////// second Next Prev Menu //////////////
      //cache elements
      var secondNextPrevMenuArrowLeft = jQuery('.second-next-prev-menu .rsArrowLeft'); //left arrow
      var secondNextPrevMenuArrowRight = jQuery('.second-next-prev-menu .rsArrowRight'); //right arrow
      var secondNextPrevMenuText = jQuery('.second-next-prev-menu .next-prev-text'); //text

      //change text when hovering over the arrows
      secondNextPrevMenuArrowLeft.hover(function(){
        secondNextPrevMenuText.text('Prev Tip');
      });
      secondNextPrevMenuArrowRight.hover(function(){
        secondNextPrevMenuText.text('Next Tip');
      });
      jQuery('.second-next-prev-menu .rsArrowLeft, .second-next-prev-menu .rsArrowRight').mouseout(function(){
        secondNextPrevMenuText.text('Next Tip');
      });
    };

    self.destroySlide = function(){
      // remove the rs from the dom
      self.$rs.destroy();
      self.$rs.remove();

      // append the original
      self.$org.prependTo('.second-next-prev-menu-slider');

      // cache the original again
      self.$container = $('.second-next-prev-menu-slider');

      // clone it
      self.$org = self.$container.clone();
    };

    self.checker = function(){
      if (self.$rs.destroy) {
        self.destroySlide();
        self.initslide();
      }
    };

    self.init();
  };

})(jQuery);
/**
 * Definition for the Assistive Technology Detail Thumb javascript module.
 * U.AtDetailThumb function is called from _what-you-need-to-know-tabs.js
 */

(function($){

  U.AtDetailThumb = function() {
    var self = this;

    //cache slider element
    var sliderElement = jQuery(".screenshot-thumbs-wrapper");

    sliderElement.royalSlider({
      keyboardNavEnabled: true,  // enable keyboard arrows nav
      autoScaleSlider: false,
      autoScaleSliderWidth: 191, // base slider width. slider will autocalculate the ratio based on these values.
      autoHeight: false,
      imageScaleMode: 'none',
      imageAlignCenter: false,
      loop: true,
      controlNavigation: 'none',
      arrowsNav: true,
      arrowsNavAutoHide: false,
      sliderDrag:false,
      autoPlay: {
        delay: 4000,
        enabled: false
      }
    });

    var screenshotThumbsCarousel = sliderElement.data('royalSlider');

    if(screenshotThumbsCarousel){
      jQuery('.at-detail-thumb-total-slides').html( screenshotThumbsCarousel.numSlides );
      screenshotThumbsCarousel.ev.on('rsAfterSlideChange', function(event) {
        jQuery('.at-detail-thumb-curr-slide').html( 1 + ( screenshotThumbsCarousel.currSlideId ) );
      });
    }

    return this;
  };
})(jQuery);
/**
 * Definition for the adviceResults javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.adviceResults();
  });

  U.adviceResults = function() {
    var self = this;

    // The window width where the slider will be created/destroyed.
    var SLIDER_BREAKPOINT = 650;

    // The width of the slider navigation arrows.
    var SLIDER_NAV_WIDTH = 100;

    // A royal slider object.
    this.$slider = null;

    // The original markup, before building slider.
    this.$html = null;

    // The outer wrapper, for adding/removing slider content.
    this.$wrapper = null;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      $('.search-result .result-tip').equalHeights();
      this.$html = $('.advice-results .results-outer-wrapper').html();
      this.$wrapper = $('.advice-results .results-outer-wrapper');

      $(window).resize(function() { self.resizeHandler(); });

      $('.advice-results .result-body').hover(function() {
        $(this).find('.result-hover').css('display', 'block');
      }, function() {
        $(this).find('.result-hover').hide();
      });

      return this.resizeHandler();
    };

    /**
     * Add or remove slider depending on page width.
     * @return {object} this instance
     */
    this.resizeHandler = function() {
      var width = $(window).width();

      if (width >= SLIDER_BREAKPOINT) {
        this.destroySlider();
      }
      else if (width < SLIDER_BREAKPOINT) {
        this.buildSlider();
      }

      return this.repositionArrows().resizeOverlays();
    };

    /**
     * Build a slider out of search results.
     * @return {object} this instance
     */
    this.buildSlider = function() {
      if (this.$slider !== null) {
        return this;
      }

      // The centerArea percent should flex with window size.
      var width = $(window).width();
      var center =  0.5;
      if (width < 525) {
        center = 0.7;
      }
      if (width < 350) {
        center = 0.8;
      }

      this.$slider = $('.advice-results .results-wrapper').royalSlider({
        addActiveClass: true,
        arrowsNav: true,
        arrowsNavAutoHide: false,
        arrowsNavHideOnTouch: false,
        fadeinLoadedSlide: true,
        keyboardNavEnabled: true,
        imageAlignCenter: false,
        loop: true,
        loopRewind: true,
        numImagesToPreload: 4,
        autoPlay: {
          enabled: false,
          pauseOnHover: true,
          delay: 2000
        },
        visibleNearby: {
          enabled: true,
          centerArea: center
        },
        sliderDrag: false
      });

//      $('.rsVisibleNearbyWrap').css('min-height', '411px');

      // Wrap arrows in a container.
      $('.advice-results .rsArrow').wrapAll('<div class="rsArrowWrapper" />');

      // Resize view port of slider.
      var viewHeight = this.overflowHeight();
      $('.advice-results .rsOverflow, .advice-results .results-wrapper').css('min-height', viewHeight);

      return this;
    };

    /**
     * Destroy the search result slider.
     * @return {object} this instance
     */
    this.destroySlider = function() {
      if (this.$slider === null) {
        return this;
      }

      this.$slider.remove();
      this.$slider = null;
      this.$wrapper.append(this.$html);
      return this;
    };

    /**
     * Determine min-height for slider overflow.
     * @return {int}
     *   the tallest result height in pixels
     */
    this.overflowHeight = function() {
      var tallest = 0;
      $('.advice-results .search-result').each(function() {
        var height = $(this).height() + 125;
        if (height > tallest) {
          tallest = height;
        }
      });

      return tallest;
    };

    /**
     * Determine min-height for slider overflow.
     * @return {int}
     *   the tallest result height in pixels
     */
    this.resultHeight = function() {
      var tallest = 0;
      $('.advice-results .result-body').each(function() {
        var height = $(this).height();
        if (height > tallest) {
          tallest = height;
        }
      });

      return tallest;
    };

    /**
     * Dynamically reposition the royal slider nav buttons.
     * @return {object} this instance
     */
    this.repositionArrows = function() {
      var width = this.$wrapper.width();
      var offset = ((width / 2) - (SLIDER_NAV_WIDTH / 2) +8);
      $('.rsArrowWrapper').css('left', -offset);

      return this;
    };

    /**
     * Resize result overlays to match height of container.
     * @return {object} this instance
     */
    this.resizeOverlays = function() {
      var height = this.resultHeight() + 45;
      $('.advice-results .result-hover a').css('height', height / 2);
      return this;
    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the suggestABehavior javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.suggestABehavior();
  });

  U.suggestABehavior = function() {
    var self = this;

    //trigger the modal when the "don't see your child's challenge?" link is clicked
    jQuery('.advice-more-link').click(function(){
      jQuery('#suggest-a-behavior').modal('show');
    });

    //cache modal element for suggest a behavior
    var suggestABehaviorModal = jQuery('#suggest-a-behavior');
    //prevent overlay from obstructing the modal.
    suggestABehaviorModal.on('show.bs.modal', function (e) {
      jQuery('#wrapper').css('position', 'static');
    });
    suggestABehaviorModal.on('hide.bs.modal', function (e) {
      jQuery('#wrapper').css('position', 'relative');
    });

    //check that the textarea has content before submission
    jQuery('.suggest-a-behavior input[type=submit]').click(function(e){
      if (!jQuery.trim(jQuery('.suggest-a-behavior textarea').val())) {
        //the textarea is empty so show an alert message
        jQuery('.suggest-a-behavior .alert-message.hidden').removeClass('hidden');
        e.preventDefault(); //prevent form submission
      }else{
        //make sure alert message is hidden
        jQuery('.suggest-a-behavior .alert-message').addClass('hidden');

        ////////////////////////////////////////////////////////////////////////
        //This next bit is temporary. The confirmation message would normally //
        // be done after an ajax call to submit the text.                     //
        ////////////////////////////////////////////////////////////////////////

        //hide form and show the confirmation text
        jQuery('#suggest-a-behavior .suggest-a-behavior').hide();
        jQuery('#suggest-a-behavior .suggest-a-behavior-confirmation').show();
        e.preventDefault(); //prevent form submission
      }
    });

    return this;
  };

})(jQuery);
/**
 * Definition for the rateThisApp javascript module.
 */

(function($){

// Initialize the module on page load.
  $(document).ready(function() {
    new U.rateThisApp();
  });

  U.rateThisApp = function() {
    var self = this;

    $(".rate-this-app input").uniform();
    $(".rate-this-app select").uniform();

    return this;
  };

})(jQuery);
/**
 * Definition for the whatYouNeedToKnow javascript module.
 */

(function($){

  $(document).ready(function(){
    $('#tab-container').easytabs();

    new U.WhatYouNeedToKnow();
  });

  U.WhatYouNeedToKnow = function() {
    var self = this;

    //cache containers
    var whatYouNeedToKnowMobile = $('.screenshot-thumbs.screenshot-thumbs-mobile');
    var whatYouNeedToKnow = $('.screenshot-thumbs.screenshot-thumbs-lg');
    //cache keep reading html
    var whatYouNeedToKnowHTML = whatYouNeedToKnowMobile.html();

    if(Modernizr.mq('(min-width: 650px)')){
      whatYouNeedToKnowMobile.hide().empty();
      whatYouNeedToKnow.empty().html(whatYouNeedToKnowHTML).show();

      new U.AtDetailThumb();
    }else{
      whatYouNeedToKnow.hide().empty();
      whatYouNeedToKnowMobile.empty().html(whatYouNeedToKnowHTML + '<hr>').show();

      new U.AtDetailThumb();
    }

    return this;
  };

})(jQuery);
/**
 * Definition for the friendsViewTabs javascript tabs module.
 */

(function($){

  $(document).ready(function(){

    // Navigate to new page (or swap content) on change of dropdown
    $('.friends-view-tabs .etabs-dropdown select').change(function() {
      // INTEGRATION: navigate to the HREF, or do something else
      var className = '.' + $(this).val() + '-tab a';
      console.log($('.etabs ' + className).attr('href'));
    });

  });

  $('.etabs-dropdown select').uniform();

})(jQuery);
/**
 * Definition for the myEventsTabs javascript tabs module.
 */

(function($){

  $(document).ready(function(){

    // Navigate to new page (or swap content) on change of dropdown
    $('#my-events-tabs .etabs-dropdown select').change(function() {
      // INTEGRATION: navigate to the HREF, or do something else
      var className = '.' + $(this).val() + '-tab a';
      console.log($('.etabs ' + className).attr('href'));
    });

  });

  $('.etabs-dropdown select').uniform();

})(jQuery);
/**
 * My Connections popover javascript module.
 */

(function($){
  // Initialize the module on page load.
  $(document).ready(function() {
    new U.connectionsPopover();
  });

  U.connectionsPopover = function(){
    var self = this;

    self.init = function(){
      $('.user-child-details-toggle').click(function() {
        // we have to add these after the popover is created
        var $container = $(this).parent();
        setTimeout(function() {
          $container.find('.rsArrowRight .rsArrowIcn').click(self.nextSlide);
          $container.find('.rsArrowLeft .rsArrowIcn').click(self.prevSlide);
        }, 250);
      });
    };

    self.changeSlide = function(context, direction) {
      var $pop = $(context).parent().parent().parent();
      var currSlide = 0;
      var numSlides = $pop.find('.slide').length;
      $pop.find('.slide').each(function() {
        if ($(this).hasClass('active')) {
          $(this).removeClass('active');
          return false; // break
        }
        currSlide++;
      });
      $pop.find('.slide').eq((currSlide+direction)%numSlides).addClass('active');
    };

    self.nextSlide = function() {
      self.changeSlide(this, 1);
    };

    self.prevSlide = function() {
      self.changeSlide(this, -1);
    };

    self.init();
  };

})(jQuery);
/**
 * Definition for the account-notification-tabs javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.accountNotificationTabs();
  });

  U.accountNotificationTabs = function() {
    var self = this;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {

      //cache selector
      var notificationsSectionDropdownSelect = $('.notifications-section-dropdown select');

      var uniform_elements = [
        '.account-notification-tabs input[type=textfield]',
        '.account-notification-tabs select'
      ].join(',');

      var toggle_switch = $(
        '<div class="switch-wrapper">' +
          '<span class="off">Off</span>' +
          '<span class="on">On</span>' +
        '</div>'
      );

      // Add toggle switches.
      $('.toggle-wrapper input[type=checkbox]').ezMark();
      $('.toggle-wrapper .ez-checkbox').append(toggle_switch);

      // Navigate to new page (or swap content) on change of dropdown
      notificationsSectionDropdownSelect.change(function() {
        self.swapSelectCount();

        // INTEGRATION: navigate to the HREF, or do something else
        var className = '.' + $(this).val() + '-tab a';
      });

      return this.swapSelectCount();
    };

    /**
     * Overlay the correct counter over dropdown select.
     * @return {object} this instance
     */
    this.swapSelectCount = function() {
      $('.notifications-section-dropdown .circle').hide();
      var activeOption = '.' + $('.notifications-section-dropdown select').val() + '-count';
      $(activeOption).css('display', 'inline-block');
      return this;
    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the signUpTerms javascript module.
 */

(function($){
  // Initialize the module on page load.
  $(document).ready(function() {
    new U.signUpTerms();
    $('.answer-agree').attr('disabled', 'true');
  });

  U.signUpTerms = function() {
    var self = this;

    jQuery('.terms-content').scroll(function() {
      if ($(this).scrollTop() + $(this).innerHeight() +2 >= $(this)[0].scrollHeight) {
        $('.answer-agree').removeAttr('disabled');
      }
    });
  };
})(jQuery);
/**
 * Definition for the accountViewHeader javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.accountViewHeader();
  });

  U.accountViewHeader = function() {
    var self = this;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      $('.account-view-header .user-child-details-toggle').popover({
        html: true,
        placement: 'bottom',
        trigger: 'click',
        content: function() {
          return $(this).parent().next(".popover-container").html();
        }
      });

      return this;
    };

    return this.initialize();
  };

})(jQuery);
jQuery(document).ready(function(){

  //trigger for embed overlay modal
  jQuery('.infographic-zoom-icon-embed').click(function(){
    jQuery('#embed-overlay').modal();
  });

  //cache modal element for embed overlay
  var embedOverlayModal = jQuery('#embed-overlay');
  //prevent overlay from obstructing the modal.
  embedOverlayModal.on('show.bs.modal', function (e) {
    jQuery('#wrapper').css('position', 'static');
  });
  embedOverlayModal.on('hide.bs.modal', function (e) {
    jQuery('#wrapper').css('position', 'relative');
  });

});
/**
 * Definition for the findHelpful javascript module.
 */

(function($){

// Initialize the module on page load.
  $(document).ready(function() {
    new U.findHelpful();
  });

  U.findHelpful = function() {
    var self = this;

    jQuery('.find-this-helpful ul li button').click(function(){
      var tempCount = parseInt(jQuery('.count-helpful a span').html(), 10);

      if( jQuery(this).hasClass('helpful-yes') ){ // Yes is clicked
        if( !jQuery(this).hasClass('selected') ){
          // Yes not selected
          jQuery('.count-helpful a span').html( tempCount + 1 );
        }
      }else{
        if( jQuery('.helpful-yes').hasClass('selected') ){ // No is clicked
          // No is clicked, yes is selected
          jQuery('.count-helpful a span').html( tempCount - 1 );
        }
      }

      jQuery('.find-this-helpful ul li button').removeClass('selected');
      jQuery(this).addClass('selected');
      return false;
    });

    // Handle moving sidebar find-this-helpful module around depending on window width
    var $module = $('.find-this-helpful.sidebar');
    // if module exists on the page
    if(!$module.length) { return; }

    var $findHelpfulLarge = $('.find-this-helpful-large');
    var $findHelpfulSmall = $('.find-this-helpful-small');

    // calls function on load and on resize
    detect();
    jQuery(window).resize(detect);

    function detect(){
      if(Modernizr.mq('(min-width: 650px)')){
        $module.appendTo($findHelpfulLarge);
      } else {
        $module.appendTo($findHelpfulSmall);
      }
    }

    return this;
  };

})(jQuery);
/**
 * Definition for the profile-questions javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.profileQuestions();
  });

  U.profileQuestions = function() {
    var self = this;

    // Maximum amount of children the user can add.
    this.MAX_CHILDREN = 4;

    // Current number of children added.
    this.childCount = 1;

    // Converts integers to an adjective.
    this.numberAdjectives = ['', 'second', 'third', 'fourth'];

    // Original child question, before cloning.
    this.$childQuestion = null;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      var uniform_elements = [
        '.profile-questions input[type=checkbox]:not(.no-uniform)',
        '.profile-questions input[type=textfield]',
        '.profile-questions input[type=radio]'
      ].join(',');
      $(uniform_elements).uniform();

      // Clone child question on button click.
      var $questionWrapper = $('.profile-questions-child-wrapper');
      if ($questionWrapper.length) {
        $.uniform.restore($($questionWrapper).find('select'));
        this.$childQuestion = $questionWrapper.html();
        $($questionWrapper).find('select').uniform();
        $('.add-more-children').click(this.copyChildForm);
      }

      // For all toggle buttons.
      $('.profile-questions').on('click', '.button', function() {
        $(this).parent().children('.checked').removeClass('checked');
        $(this).addClass('checked');
      });

      // For PP2b "difficulties" info hovers.
      $('.difficulties-question .checkbox-wrapper').hover(function() {
        if ($(window).width() >= U.Global.Breakpoints.MEDIUM) {
          $(this).find('.info-link').show();
        }
      }, function() {
        if ($(window).width() >= U.Global.Breakpoints.MEDIUM) {
          $(this).find('.info-link').hide();
        }
      });

      // For PP3 "what is your role?" question.
      $('.role-question select').on('change', function() {
        $('.role-question .checked').removeClass('checked');
        $('.role-question input:checked').prop('checked', false);
        return false;
      });
      $('.role-question .button').on('click', function() {
        $('.role-question .selected').removeClass('selected');
        $('.role-question option:selected').prop('selected', false);
        $('.role-question select').val('').trigger('click');
      });

      $(window).resize(function() {
        self.resizeQuestions();
      });

      return this.resizeQuestions();
    };

    /**
     * Add equal heights to columns on resize event.
     * @return {object} this instance
     */
    this.resizeQuestions = function() {
      $('.column-wrapper').each(function() {
        if(Modernizr.mq('(min-width: 769px)')){
          $(this).find('.question-wrapper').equalHeights();
        }
        else {
          $(this).find('.question-wrapper').css('height', 'auto');
        }
      });

      if ($(window).width() >= U.Global.Breakpoints.MEDIUM) {
        $('.difficulties-question .info-link').hide();
      }
      else {
        $('.difficulties-question .info-link').show();
      }

      return this;
    };

    /**
     * Duplicate child form elements when user adds another.
     * @return {boolean} false
     */
    this.copyChildForm = function() {
      var clone = $(self.$childQuestion);
      $('.profile-questions-child-wrapper').append(clone);

      // Increment count and adjust wording on question.
      self.childCount++;
      $('.child-count-question span').html(self.numberAdjectives[self.childCount]);

      if (self.childCount == self.MAX_CHILDREN) {
        $('.child-count-question').hide();
      }

      // Fixes 'selected' class never added to selects after clone.
      clone.find('select').uniform().change(function() {
        $(this).parent().addClass('selected');
      });

      return false;
    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the profile-questions javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.registrationProfile();
  });

  U.registrationProfile = function() {
    var self = this;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {
      var uniform_elements = [
        '.registration-profile input[type=checkbox]:not(.no-uniform)',
        '.registration-profile input[type=textfield]'
      ].join(',');

      $(uniform_elements).uniform();

      return this;
    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the keepReadingMobile javascript module.
 * put keep reading component below find-this-helpful component on mobile screens
 */

(function($){

// Initialize the module on page load.
  $(document).ready(function() {
    new U.keepReadingMobile();

    //perform action on resize, but delay the amount of times this is called while resizing.
    var doTheAction;
    $(window).resize(function() {
      clearTimeout(doTheAction);
      doTheAction = setTimeout(U.keepReadingMobile, 100);
    });
  });

  U.keepReadingMobile = function() {
    var self = this;

    //cache containers
    var keepReadingMobile = $('.keep-reading.keep-reading-mobile');
    var keepReading = $('.keep-reading.keep-reading-lg');
    //cache keep reading html
    var keepReadingHTML = keepReadingMobile.html();

    if(Modernizr.mq('(min-width: 650px)')){
      keepReadingMobile.hide();
      keepReading.html(keepReadingHTML);
      keepReading.show();
    }else{
      keepReading.hide();
      keepReadingMobile.html(keepReadingHTML);
      keepReadingMobile.show();
    }

    return this;
  };

})(jQuery);
/**
 * Assistive tech javascript module.
 */

(function($){
  $(document).ready(function() {
    new U.assistiveTech();

    new U.SeeRating();

    //perform action on resize, but delay the amount of times this is called while resizing.
    var doTheAction;
    $(window).resize(function() {
      clearTimeout(doTheAction);
      doTheAction = setTimeout(U.SeeRating, 100);
    });

  });

  U.SeeRating = function() {
    var self = this;

    //cache containers
    var resultKeywords = $('.tech-search-results .result-keywords');
    var seeRating = $('.tech-search-results .see-rating');
    var resultRating = $('.tech-search-results .result-ratings.show-popover');

    if(Modernizr.mq('(min-width: 650px)')){
      seeRating.hide();
      resultKeywords.show();
      resultRating.show();
    }else{
      resultKeywords.hide();
      resultRating.hide();
      seeRating.show();
    }

    return this;
  };

  U.assistiveTech = function(){
    var self = this;

    self.init = function(){
//      $('.result-keywords a').popover({
//        html: true,
//        placement: 'bottom',
//        trigger: 'click',
//        content: function() {
//          $this = $(this);
//          var $container = $this.parent().parent().parent().parent().parent();
//          setTimeout(function() {
//            $container.find('.close').click(function() {
//              $this.popover('hide');
//              $container.find('.popover').hide();
//            });
//          }, 250);
//          var c = '<div class="close"><span>X</span>Close</div>';
//          c += $(this).parent().parent().parent().parent().parent().html();
//          c += '<a href="REPLACE" class="button">View Full Detail</a>';
//          return c;
//        }
//      });

      $('.result-image.screenshots-popover img').popover({
        html: true,
        placement: 'bottom',
        trigger: 'click',
        content: function() {
          $this = $(this);
          var $container = $this.parent().parent();
          setTimeout(function() {
            if (!$container.find('.change-slide-buttons').hasClass('lock')) {
              $container.find('.change-slide-buttons').addClass('lock');
              $container.find('.rsArrowRight .rsArrowIcn').click(self.nextSlide);
              $container.find('.rsArrowLeft .rsArrowIcn').click(self.prevSlide);
              $('body').click(function(e) {
                if ($(e.target).hasClass('rsArrowIcn')) {
                  return;
                }
                $this.popover('hide');
                $container.find('.popover').hide();
              });
            }
          }, 250);
          return $(this).parent().find('.popover-container').html();
        }
      });
    };

    self.changeSlide = function(context, direction) {
      var $pop = $(context).parent().parent().parent();
      var currSlide = 0;
      var numSlides = $pop.find('.slide').length;
      $pop.find('.slide').each(function() {
        if ($(this).hasClass('active')) {
          $(this).removeClass('active');
          return false; // break
        }
        currSlide++;
      });
      var next = (currSlide+direction)%numSlides;
      $pop.find('.count .curr').html(next+1 ? next+1 : 3);
      $pop.find('.slide').eq(next).addClass('active');
    };

    self.nextSlide = function() {
      self.changeSlide(this, 1);
    };

    self.prevSlide = function() {
      self.changeSlide(this, -1);
    };

    self.init();
  };

})(jQuery);
/**
 * Definition for the accountMyComments javascript module.
 * Change the cols to be more responsive
 */

(function($){

// Initialize the module on page load.
  $(document).ready(function() {
    new U.accountMyComments();

    //perform action on resize, but delay the amount of times this is called while resizing.
    var doTheAction;
    $(window).resize(function() {
      clearTimeout(doTheAction);
      doTheAction = setTimeout(U.accountMyComments, 100);
    });
  });

  U.accountMyComments = function() {
    var self = this;

    //cache containers
    var accountMyCommentsColsFirst = $('.account-mycomments > .mycomment-list > .mycomment-item > div:first-child');
    var accountMyCommentsColsLast = $('.account-mycomments > .mycomment-list > .mycomment-item > div:last-child');

    if(Modernizr.mq('(min-width: 960px)')){
      accountMyCommentsColsFirst.removeClass('col-4').addClass('col-3');
      accountMyCommentsColsLast.removeClass('col-20').addClass('col-21');
    }else{
      accountMyCommentsColsFirst.removeClass('col-3').addClass('col-4');
      accountMyCommentsColsLast.removeClass('col-21').addClass('col-20');
    }

    return this;
  };

})(jQuery);
/**
 * Definition for the behaviorToolRelatedArticles javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.behaviorToolRelatedArticles();
  });

  /**
   * Checks whether the tool-related-articles module exists on the page and inits if it does
   * If the viewport is >= 650 then pop the module into the page-topic container
   *
   * spec/issue : https://digitalpulp.atlassian.net/browse/UN-2575 & UN-2635
   */
  U.behaviorToolRelatedArticles = function() {

    var $module = $('.behavior-tool-related-articles');
    // if get-better-recommendations module exists on the page
    if(!$module.length) { return; }

    // Run once on window load
    repositionElement();
    // Run on resize
    jQuery(window).resize(repositionElement);

    // repositions tool based on size of window
    function repositionElement() {

      var toolRelatedArticles = $('.behavior-tool-related-articles');
      var largePosition = $('.behavior-tool-related-articles-large');
      var smallPosition = $('.behavior-tool-related-articles-small');

      if (Modernizr.mq('(min-width: 650px)')) {
        largePosition.append(toolRelatedArticles);
        $('.behavior-tool-related-articles-large').show();
        $('.behavior-advice-wrapper, .behavior-tool-related-articles-large')
          .css('height', 'auto')
          .equalHeights();
      }
      else {
        smallPosition.append(toolRelatedArticles);
        $('.behavior-tool-related-articles-large').hide();
        $('.behavior-advice-wrapper, .behavior-tool-related-articles-large')
          .css('height', 'auto');
      }
    }
  };

})(jQuery);
/**
 * Definition for the assistiveToolRelatedArticles javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.assistiveToolRelatedArticles();
  });

  /**
   * Checks whether the tool-related-articles module exists on the page and inits if it does
   * If the viewport is >= 650 then pop the module into the page-topic container
   *
   * spec/issue : https://digitalpulp.atlassian.net/browse/UN-2575 & UN-2635
   */
  U.assistiveToolRelatedArticles = function() {

    var $module = $('.assistive-tool-related-articles');
    // if get-better-recommendations module exists on the page
    if(!$module.length) { return; }

    // Run once on window load
    repositionElement();
    // Run on resize
    jQuery(window).resize(repositionElement);

    // repositions tool based on size of window
    function repositionElement() {

      var toolRelatedArticles = $('.assistive-tool-related-articles');
      var largePosition = $('.assistive-tool-related-articles-large');
      var smallPosition = $('.assistive-tool-related-articles-small');

      if(Modernizr.mq('(min-width: 650px)')){
        largePosition.append(toolRelatedArticles);
        $('.assistive-tool-related-articles-large').show();
      }else{
        smallPosition.append(toolRelatedArticles);
        $('.assistive-tool-related-articles-large').hide();
      }

    }

    $('.search-tool-layout-wrapper .col').equalHeights();

    // On change of Select by Technology drop call equalHeights again
    // Function gets called but equalHeights does not update
    // Same issue happening on resize
    $('#at-browse-by-technology').change(function() {
      $('.search-tool-layout-wrapper .col').css('height', 'auto');
      // Slight delay to fix race-condition bug with equalHeights.
      setTimeout(function() {
        $('.search-tool-layout-wrapper .col').equalHeights();
      }, 25);
    });

  };

})(jQuery);
/**
 * Definition for the shareContentDropdown javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.shareContentDropdown();
  });

  U.shareContentDropdown = function() {
    var self = this;

    var $shareMenu = $('.share-dropdown-menu');

    $shareMenu.on('click touchstart', function(){
      var tooltip = $(this);
      tooltip.toggleClass('selected');
      return false;
    });

    $('body').on('click touchstart', function(){
        $shareMenu.removeClass('selected');
    });

    return this;
  };

})(jQuery);
/**
 * Definition for the connections list
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.connectionsList();

    // var doTheAction;
    // $(window).resize(function() {
    //   clearTimeout(doTheAction);
    //   doTheAction = setTimeout(U.connectionsList, 1000);
    // });

  });

  U.connectionsList = function() {
    var self = this;

    /**
     * Use snippet to resize my connections boxes
     * The intention here is so that the circular buttons line up on a row by row basis
     */

      var currentTallest = 0,
            currentRowStart = 0,
            rowDivs = [],
            $el,
            topPosition = 0;

      $('.my-connections.page .user-equal-height').each(function() {
         $el = $(this);
         topPostion = $el.offset().top;
         if (currentRowStart != topPostion) {

           // we just came to a new row.  Set all the heights on the completed row
           for (currentDiv = 0 ; currentDiv < rowDivs.length ; currentDiv++) {
             rowDivs[currentDiv].height(currentTallest);
           }

           // set the variables for the new row
           rowDivs.length = 0; // empty the array
           currentRowStart = topPostion;
           currentTallest = $el.height();
           rowDivs.push($el);

         } else {

           // another div on the current row.  Add it to the list and check if it's taller
           rowDivs.push($el);
           currentTallest = (currentTallest < $el.height()) ? ($el.height()) : (currentTallest);

        }

        // do the last row
         for (currentDiv = 0 ; currentDiv < rowDivs.length ; currentDiv++) {
           rowDivs[currentDiv].height(currentTallest);
         }

      });


  };

})(jQuery);
/**
 * Temporary module for resizing brightcove iframe
 * this will likely need an overhaul once we aren't using placeholder video
 */

(function($){

    // Initialize the module on page load.
    $(document).ready(function() {
        new U.brightcoveIframe();
    });

    U.brightcoveIframe = function() {
        var self = this;

        self.heightRatio = 9 / 16;
        self.maxWidth = 960;

        self.cacheSelectors = function() {
            self.dom = {};
            self.dom.window = $(window);
            self.dom.brightcoveContainer = $('#brightcove-container');
            self.dom.videoIframe = $('#brightcoveIframe');
        };

        self.init = function() {
            self.cacheSelectors();

            if (self.dom.videoIframe.length) {
                self.resize();
                self.attachHandlers();
            }
        };

        self.attachHandlers = function() {
            self.dom.window.on('resize', self.resize);
        };

        self.resize = function() {
            var winWidth = self.dom.window.width(),
                width =  self.dom.brightcoveContainer.width(),
                height = width * self.heightRatio;

            self.dom.videoIframe.css({height: height, width: width});
        };

        return self.init();
    };

})(jQuery);
/**
 * Abstracts application of uniform styling and related change events
 */

(function($){
    U.uniformSelects = function($selects, options, changeCallback){
        var options = options || {};

        self.cacheSelectors = function() {
            self.dom = {};
            self.dom.selects = $selects;
        };

        self.init = function() {
            self.cacheSelectors();
            self.dom.selects.uniform(options);

            self.attachHandlers();
        };

        self.attachHandlers = function() {
            self.dom.selects.on('change keyup', self.selectChange);
        };

        self.selectChange = function(e) {
            var el = $(e.currentTarget);

            if (typeof(changeCallback) === 'function') {
                changeCallback();
            }

            el.find('option:selected').each(function(){
                if ( el.val() === "" ){
                    el.parents('.selector').removeClass('selected');
                }
                else {
                    el.parents('.selector').addClass('selected');
                }
            });
        };

        self.init();
    };
})(jQuery);
(function($){

    // Initialize the module on page load.
    $(document).ready(function() {
      new U.community_common();
    });

   U.community_common = function() {

    U.community_common.showHoverCard = function($destination, $cardSelector) {
      return function (event) {
        var $target = $(event.target);
        var $childInfo = $target.parent().find($cardSelector);
        var $childInfoClone = $childInfo.clone();
        var cardIndex = 0;

        var addMouseLeaveEvent = function($card) {
          $card.on('mouseleave',
            function (event) {
              $card.hide();
              $childInfoClone.remove();
          });
          $card.find('.card-close').on('click',
              function (event) {
              $card.hide();
              $childInfoClone.remove();
          });
        };

        var removeMouseLeaveEvent = function($card) {
          $card.off('mouseleave');
        };

        $destination.append($childInfoClone);

        var newLeft = $target.offset().left - $destination.offset().left - parseInt($childInfoClone.css('padding-left'), 10) - 10;
        var newTop = $target.offset().top - $destination.offset().top + $target.outerHeight()+ 16;

        $childInfoClone.eq(cardIndex).show();
        addMouseLeaveEvent($childInfoClone.eq(cardIndex));

        var windowWidth = Math.max($(window).width(), window.innerWidth);

        if(Modernizr.mq('(max-width: 479px)')){
          $childInfoClone.css('left', 5);
        } else if(Modernizr.mq('(max-width: 649px)')){
          $childInfoClone.css('left', -11);
        } else if(Modernizr.mq('(max-width: 768px)')){
          $childInfoClone.css('left', 8);
        } else if ($childInfoClone.width() + $target.offset().left > windowWidth - 16){
          $childInfoClone.addClass('right');
          $childInfoClone.css('left', newLeft);
          $childInfoClone.css('top', newTop);
        } else {
          $childInfoClone.css('left', newLeft);
          $childInfoClone.css('top', newTop);
        }

        $childInfoClone.on('click', '.rsArrowLeft', function(e) {
          removeMouseLeaveEvent($childInfoClone.eq(cardIndex));
          $childInfoClone.hide();
          cardIndex--;
          if (cardIndex < 0) {
            cardIndex = $childInfoClone.length-1;
          }
          $childInfoClone.eq(cardIndex).show();
          addMouseLeaveEvent($childInfoClone.eq(cardIndex));
        });

        $childInfoClone.on('click', '.rsArrowRight', function(e) {
          removeMouseLeaveEvent($childInfoClone.eq(cardIndex));
          $childInfoClone.eq(cardIndex).hide();
          cardIndex++;
          if (cardIndex >= $childInfoClone.length) {
            cardIndex = 0;
          }
          $childInfoClone.eq(cardIndex).show();
          addMouseLeaveEvent($childInfoClone.eq(cardIndex));
        });

        var resizeDelay;
        $target.on('mouseleave',
          function (event) {
            clearTimeout(resizeDelay);
            resizeDelay = setTimeout(function() {
              if (!$childInfoClone.eq(0).is(':hover')){
                $childInfoClone.remove();
              }
              $target.off('mouseleave');
            }, 100);
          });
      };
    };
  };
})(jQuery);
/**
 * Definition for the behaviorTool javascript module.
 */

(function($){

    // Initialize the module on page load.
    $(document).ready(function() {
        new U.communityWelcome();
    });

    U.communityWelcome = function(){

        var self = this;

        self.init = function(){
            self.cacheSelectors();
            self.setModel();
            self.fetch();
        };

        self.cacheSelectors = function() {
            self.dom = {};
            self.dom.body = $(document.body);
            self.dom.communityPage = $('#community-page');
        };

        self.setModel = function() {
            self.model = {
                tourEnabled: self.dom.communityPage.data('showWelcomeTour')
            };
        };

        self.fetch = function() {
            if (self.model.tourEnabled) {
                $.get('/modal.welcome-tour.c1a.html').done(self.renderLightbox);
            }
        };

        self.renderLightbox = function(res) {
            var modal = $(res);
            self.dom.carousel = modal.find('#welcome-slides-container');
            self.dom.carouselNav = modal.find('.welcome-tour-navigation');
            self.dom.carouselImages = self.dom.carousel.find('.welcome-tour-image');
            self.dom.close = modal.find('.close');
            self.dom.pagingData = modal.find('.paging-data');
            self.dom.body.append(modal);
            self.dom.modal = $('.welcome-tour-modal');

            self.fireCarousel();
            self.updatePagingData();
            self.attachHandlers();

            self.dom.carouselImages.load(function() {
                self.dom.modal.modal('show');
            });
        };

        self.fireCarousel = function() {
            self.model.carousel = U.carousels.initializeSlider(self.dom.carousel, '.slide', self.dom.carouselNav, 1, 1, 1, self.resize, false);
        };

        self.attachHandlers = function() {
            self.model.carousel.ev.on('rsAfterSlideChange', self.slideChange);
            self.dom.modal.on('hide.bs.modal', self.onClose);
            self.dom.close.on('click', self.closeModal);
        };

        self.slideChange = function(e) {
            self.updatePagingData();
        };

        self.updatePagingData = function() {
            self.model.paging = {
                currentSlide: self.model.carousel.staticSlideId + 1,
                totalSlides: self.model.carousel.numSlides
            };
            self.model.paging.text = self.model.paging.currentSlide + ' of ' + self.model.paging.totalSlides;

            self.dom.pagingData.text(self.model.paging.text);
        };

        self.closeModal= function() {
            self.dom.modal.modal('hide');
        };

        self.onClose = function() {
            // TODO -- Integration task - set cookie so lightbox isn't displayed once this has been dismissed
        };

        self.resize = function() {

        };

        self.init();
    };

})(jQuery);
/**
 * Definition for the Experts Page Sub Navigation javascript module.
 */

(function($){

    // Initialize the module on page load.
    $(document).ready(function() {
        new U.expertsNav();
    });

    U.expertsNav = function(){

        var self = this;

        self.init = function(){

            var setWidth = function() {
                self.$containerWidth = $('.behavior-form').width();
                self.$expertsSelects.parent('.selector').css('width', self.$containerWidth);
            };

            // get form vars
            self.$navForm = $('.experts-nav-form');
            self.$expertsSelects = self.$navForm.find('select');

            // style form elements
            U.uniformSelects(self.$expertsSelects, {}, setWidth);

            // get form vars after uniform happens
            self.$navSubmit = self.$navForm.find('.submitButton span');

            $(window).on('resize.expertsNav', setWidth);
        };

        self.init();

    };

})(jQuery);
(function($){

  $(document).ready(function() {
    new U.parentGroupsTool();
  });

  U.parentGroupsTool = function() {

    var self = this;

    self.init = function() {

      self.initializeFilters();
      self.initializeChildGradeLightbox();

    };

    self.initializeChildGradeLightbox = function() {
      var container = $('.parents-member-cards') ;
      var lightboxButton = '.specialty-final a';
      var slideSelector = $('.card-child-info');

      if (container.length === 0) {
        return;
      }

      U.childGradeLightbox.initializeLightbox(container, lightboxButton, slideSelector);
    };

    self.initializeFilters = function() {
      function setWidth() {
        self.$containerWidth = $('.parentgroups-form').width();
      }

      self.$behaviorForm = $('.parentgroups-form');
      self.$behaviorFormSelect = self.$behaviorForm.find('select');

      U.uniformSelects(self.$behaviorFormSelect, {selectAutoWidth: false}, self.setWidth);

      self.$behaviorFormSubmit = self.$behaviorForm.find('.submitButton span');
    };

    self.init();
  };

})(jQuery);
/**
 * Definition for the behaviorTool javascript module.
 */

(function($){

  $(document).ready(function() {
    var self = this;

    self.dom = {};

    self.init = function(){

      self.dom.container = $('.whats-happening-page');

      if (self.dom.container.length === 0) {
        return;
      }

      self.equalizeHeights();
      self.initializeEventsSlider();
      self.initializeQuestionsSlider();
      self.initializeMembersSlider();
      self.initializeGroupsSlider();
      self.initializeBlogSlider();
      self.attachHandlers();
    };

    self.equalizeHeights = function() {

      if(Modernizr.mq('(min-width: 321px)')){
        self.dom.container.find('.event-card-info').equalHeights();

        self.dom.container.find('.question-card-title-and-text').equalHeights();
      }

      self.dom.container.find('.question-card-info').equalHeights();

      self.dom.container.find('.member-card-name').equalHeights();

      if(Modernizr.mq('(min-width: 321px)')){
        self.dom.container.find('.group-card-name').equalHeights();
        self.dom.container.find('.group-card-info').equalHeights();
      }

      if(Modernizr.mq('(min-width: 960px)')){
        self.dom.container.find('.community-my-groups .group-card-info')
          .each(function(i, element) {
            var $element =  $(element);
            $element.find('.group-card-excerpt')
              .add($element.find('.group-card-replies'))
              .equalHeights();
          });
      }

      if(Modernizr.mq('(min-width: 650px)')){
        self.dom.container.find('.community-blogs .blog-card-title').equalHeights();
        self.dom.container.find('.community-my-blogs .blog-card')
          .each(function (i, element) {
            var $element =  $(element);
            $element.find('.rsContent .blog-card-info')
              .add($element.find('.blog-card-author-info'))
              .equalHeights();
          });
      }
    };

    self.resize = function() {
      self.dom.container.find('.event-card-info').height('auto');

      self.dom.container.find('.question-card-title-and-text').height('auto');
      self.dom.container.find('.question-card-info').height('auto');

      self.dom.container.find('.member-card-name').height('auto');

      self.dom.container.find('.group-card-name').height('auto');
      self.dom.container.find('.group-card-info').height('auto');

      self.dom.container.find('.group-card-excerpt')
        .add(self.dom.container.find('.group-card-replies'))
        .height('auto');

      self.dom.container.find('.community-blogs .blog-card-title').height('auto');
      self.dom.container
        .find('.blog-card-author-info')
        .add(self.dom.container.find('.rsContent .blog-card-info'))
        .height('auto');

      self.equalizeHeights();
    };

    self.attachHandlers = function() {
      self.dom.container
        .find('.event-cards')
        .on('click', 'a.action-skip-this', self.skipItem('.event-card', self.eventSkipped));

      self.dom.container
        .find('.group-cards')
        .on('click', 'a.action-skip-this', self.skipItem('.group-card', self.groupSkipped));

      self.dom.container
        .find('.blog-cards')
        .on('click', 'a.action-skip-this', self.skipItem('.blog-card', self.blogSkipped));

      var $destination = $('.member-cards');
      $destination.on('mouseenter', '.specialty-final a',
        U.community_common.showHoverCard($destination, '.card-child-info'));
    };

    self.skipItem = function(selector, callback) {
      return function(e) {
        var $target = $(e.target);
        e.preventDefault();

        var $elements = $(selector);
        var $elementToRemove = $target.closest(selector);

        var currentIndex = $elements.index($elementToRemove);
        var $currentContainer = $elementToRemove.parent();

        $elementToRemove.fadeOut(function() {
          $(this).remove();

          for (var i = currentIndex + 1; i < $elements.length; i++) {
            var $nextItem = $elements.eq(i);
            var $newContainer = $nextItem.parent();
            $currentContainer.append($nextItem);
            $currentContainer = $newContainer;
          }

          callback($currentContainer, $elementToRemove);
        });
      };
    };

    self.eventSkipped = function(destination, elementToRemove) {
      var $destination = $(destination);
      var $elementToRemove = $(elementToRemove);

      // TODO Remove this and get data from the backend.
      // This is just so we don't exhaust the available cards in
      // the prototype
      $destination.append($elementToRemove);
      $elementToRemove.show();

      // TODO - backend integration - notify backend of removed event
      // and add a fresh event
    };

    self.groupSkipped = function(destination, elementToRemove) {
      var $destination = $(destination);
      var $elementToRemove = $(elementToRemove);

      // TODO Remove this and get data from the backend.
      // This is just so we don't exhaust the available cards in
      // the prototype
      $destination.append($elementToRemove);
      $elementToRemove.show();

      // TODO - backend integration - notify backend of removed event
      // and add a fresh event
    };

    self.blogSkipped = function(destination, elementToRemove) {
      var $destination = $(destination);
      var $elementToRemove = $(elementToRemove);

      // TODO Remove this and get data from the backend.
      // This is just so we don't exhaust the available cards in
      // the prototype
      $destination.append($elementToRemove);
      $elementToRemove.show();

      // TODO - backend integration - notify backend of removed event
      // and add a fresh event
    };

    self.initializeEventsSlider = function() {
      var container = $('.upcoming-events .event-cards');
      var slideSelector = ".event-card";
      var navigation = $('.upcoming-events .events.next-prev-menu');

      if (container.length === 0) {
        return;
      }

      U.carousels.initializeSlider(container, slideSelector, navigation, 2, 2, 2, self.resize);
    };

    self.initializeQuestionsSlider = function() {
      var container = $('.recent-questions .question-cards');
      var slideSelector = ".question-card";
      var navigation = $('.recent-questions .questions.next-prev-menu');

      if (container.length === 0) {
        return;
      }

      U.carousels.initializeSlider(container, slideSelector, navigation, 2, 1, 1, self.resize);
    };

    self.initializeMembersSlider = function() {
      var container = $('.community-members .member-cards');
      var slideSelector = ".member-card";
      var navigation = $('.community-members .members.next-prev-menu');

      if (container.length === 0) {
        return;
      }

      U.carousels.initializeSlider(container, slideSelector, navigation, 4, 2, 2, self.resize);
    };

    self.initializeGroupsSlider = function() {
      var container = $('.community-groups .group-cards');
      var slideSelector = ".group-card";
      var navigation = $('.community-groups .groups.next-prev-menu');

      if (container.length === 0) {
        return;
      }

      U.carousels.initializeSlider(container, slideSelector, navigation, 2, 2, 2, self.resize);
    };

    self.initializeBlogSlider = function() {
      var container = $('.community-blogs .blog-cards');
      var slideSelector = ".blog-card";
      var navigation = $('.community-blogs .blogs.next-prev-menu');

      if (container.length === 0) {
        return;
      }

      U.carousels.initializeSlider(container, slideSelector, navigation, 2, 1, 1, self.resize);
    };

    self.init();
  });

})(jQuery);
/**
 * Definition for the Experts Page javascript module.
 */

(function($){

    // Initialize the module on page load.
    $(document).ready(function() {
        new U.experts();
    });

    U.experts = function(){

        var self = this;

        self.cacheSelectors = function() {
            self.dom = {};
            self.dom.window = $(window);
            self.dom.container = $('#community-page');
            self.dom.chatCarousel = self.dom.container.find('.live-chat .event-cards');
            self.dom.chatCarouselNav = self.dom.container.find('.live-chat-navigation');
        };

        self.setModel = function() {
            self.model = {
                carousels: {}
            };
        };

        self.init = function(){
            self.cacheSelectors();

            if (self.dom.container.hasClass('experts-page')) {
                self.setModel();
                self.equalizeHeights();
                self.fireCarousel();
            }
        };

        self.equalizeHeights = function() {
            self.equalizeEventsChatModule();
            self.equalizeLiveChatModule();
        };

        self.equalizeEventsChatModule = function() {
            var applyResize = Modernizr.mq('(min-width: 650px)'),
                items = self.dom.container.find('.events-chat .event-card'),
                firstColumnItems = items.parent().find('.first'),
                secondColumnItems = items.not('.first');

            items.css('height', 'auto');

            if (applyResize) {
                firstColumnItems.equalHeights();
                secondColumnItems.equalHeights();
            }
        };

        self.equalizeLiveChatModule = function() {
            var items = self.dom.container.find('.live-chat .event-card-info');

            items.css('height', 'auto');
            items.equalHeights();
        };

        self.fireCarousel = function() {
            if (self.dom.chatCarousel.length) {
                U.carousels.initializeSlider(self.dom.chatCarousel, '.event-card', self.dom.chatCarouselNav, 2, 2, 1, self.equalizeHeights);
            }
        };

        self.init();

    };

})(jQuery);
/**
 * Definition for the Experts Page javascript module.
 */

(function($){

    // Initialize the module on page load.
    $(document).ready(function() {
        new U.calendar();
    });

    U.calendar = function(){

        var self = this;

        self.settings = {
            openDetailClass: 'detail-view-open',
            breakpoint: '(min-width: 769px)'
        };

        self.cacheSelectors = function() {
            self.dom = {};
            self.dom.topLevel = $('body, html');
            self.dom.window = $(window);
            self.dom.calendarContainer = $('.container.calendar');
            self.dom.gridRows = self.dom.calendarContainer.find('.grid-row');
            self.dom.moreInfoToggles = self.dom.calendarContainer.find('.more-info-toggle');
        };


        self.init = function(){
            self.cacheSelectors();
            self.setModel();
            self.render();
            self.attachHandlers();
        };

        self.attachHandlers = function() {
            if (self.model.gridView) {
                self.dom.window.on('resize', self.resize);
                self.dom.moreInfoToggles.on('click', self.toggleDetailView);
            }
        };

        self.setModel = function() {
            self.model = {
                gridView: self.dom.gridRows.length,
                desktop: Modernizr.mq(self.settings.breakpoint),
                breakpointChange: false
            }
        };

        self.updateModel = function() {
            var desktop = Modernizr.mq(self.settings.breakpoint);

            self.model.breakpointChange = desktop !== self.model.desktop;
            self.model.desktop = desktop;
        };

        self.render = function() {
            self.equalizeHeights();
            self.dom.calendarContainer.addClass('rendered');
        };

        self.resize = function() {
            self.updateModel();
            self.closeOpenDetailViews();
            self.equalizeHeights();
        };

        self.equalizeHeights = function() {
            if (self.model.desktop) {
                self.dom.gridRows.each(function(i,row) {
                    var days = $(row).find('.day');

                    days.addClass('desktop');
                    days.css('height', 'auto');
                    days.equalHeights();
                });
            } else {
                var days = self.dom.gridRows.find('.day');

                days.removeClass('desktop');
                days.css('height', 'auto');
            }
        };

        self.closeOpenDetailViews = function(force) {
            if (force || self.model.breakpointChange) {
                self.dom.calendarContainer.find('.' + self.settings.openDetailClass)
                    .removeClass(self.settings.openDetailClass);
            }
        };

        self.toggleDetailView = function(e) {
            e.preventDefault();

            var clicked = $(e.currentTarget),
                event = clicked.parents('.event'),
                isOpen = event.hasClass(self.settings.openDetailClass);

            self.closeOpenDetailViews(true);

            if (!isOpen) {
                self.scrollToPosition(clicked, 10);
                event.addClass(self.settings.openDetailClass);
            }
        };

        self.scrollToPosition = function(element, padding, duration) {
            var padding = typeof(padding) !== 'undefined' ? padding : 50,
                duration = duration || 300,
                position = element.offset().top - padding;

            window.el = element;

            self.dom.topLevel.animate({scrollTop: position}, duration);
        };

        self.init();

    };

})(jQuery);
(function($){

  U.childGradeLightbox = function() {

    U.childGradeLightbox.initializeLightbox = function(container, lightboxButton, slideSelector) {
      container.on('mouseenter', lightboxButton,
          function (event) {
            var addMouseLeaveEvent = function($card) {
              $card.on('mouseleave',
                  function (event) {
                    $card.hide();
                  });
              $card.find('.card-close').on('click',
                  function (event) {
                    $card.hide();
                  });
            };


            var removeMouseLeaveEvent = function($card) {
              $card.off('mouseleave');
            };

            var $target = $(event.target);
            var cardIndex = 0;
            var $childInfoCards = $target.parent().find(slideSelector);

            var windowWidth = $(window).width();
            
            if(Modernizr.mq('(max-width: 768px)')){
              $childInfoCards.css('left', 16-$target.offset().left);
            } else if ($childInfoCards.width() + $target.offset().left > windowWidth - 16){
              $childInfoCards.addClass('right');
            }

            $childInfoCards.eq(cardIndex).show();
            addMouseLeaveEvent($childInfoCards.eq(cardIndex));

            $childInfoCards.on('click', '.rsArrowLeft', function(e) {
              removeMouseLeaveEvent($childInfoCards.eq(cardIndex));
              $childInfoCards.eq(cardIndex).hide();
              cardIndex--;
              if (cardIndex < 0) {
                cardIndex = $childInfoCards.length-1;
              }
              $childInfoCards.eq(cardIndex).show();
              addMouseLeaveEvent($childInfoCards.eq(cardIndex));
            });

            $childInfoCards.on('click', '.rsArrowRight', function(e) {
              removeMouseLeaveEvent($childInfoCards.eq(cardIndex));
              $childInfoCards.eq(cardIndex).hide();
              cardIndex++;
              if (cardIndex >= $childInfoCards.length) {
                cardIndex = 0;
              }
              $childInfoCards.eq(cardIndex).show();
              addMouseLeaveEvent($childInfoCards.eq(cardIndex));
            });

            var resizeDelay;
            $target.on('mouseleave',
                function (event) {
                  clearTimeout(resizeDelay);
                  resizeDelay = setTimeout(function() {
                    if (!$childInfoCards.eq(0).is(':hover')){
                      $childInfoCards.eq(0).hide();
                    }
                    $target.off('mouseleave');
                  }, 100);
                });
          });
    };

  };

  new U.childGradeLightbox();

})(jQuery);
(function($){

  $(document).ready(function() {
    var self = this;

    self.dom = {};

    self.init = function(){
      self.dom.container = $('.community-parents');

      if (self.dom.container.length === 0) {
        return;
      }

      self.initForms();
      self.initializeMembersSlider();
      self.attachHandlers();
      self.initializeChildGradeLightbox();
    };

    self.initForms = function() {
      U.uniformSelects(self.dom.container.find('select'));

      self.createSlider('#parents-search-distance', '#parents-search-distance-slider');
      self.createSlider('#parents-search-grade', '#parents-search-grade-slider');
    };

    self.createSlider = function(inputSelector, sliderContainer) {
      var $input = $(inputSelector);

      var min = $input.data('min');
      var max = $input.data('max');
      var startLow = $input.data('start-low');
      var startHigh = $input.data('start-high');
      var values = $input.data('values');
      var labels = $input.data('labels');
      var collisionDistance = parseInt($input.data('collision'), 10) || 0;

      var labelHandles = function(first, second, firstSpanClass, secondSpanClass) {
          var $handles = $(sliderContainer).find(".ui-slider-handle");
          $handles.eq(0).html("<span class='" + firstSpanClass +"'>" + first + "</span>");
          $handles.eq(1).html("<span class='" + secondSpanClass +"'>" + second + "</span>");
      };

      var applyHandleLabels = function (ui, labelsArr) {
        var firstSpanClass = "";
        var secondSpanClass = "";

        var inputDistance = ui.values[1] - ui.values[0];
        if (inputDistance <= collisionDistance && inputDistance !== 0) {
          secondSpanClass += " collide ";
        } else if (inputDistance === 0) {
          firstSpanClass += " hidden ";
        }

        if (ui.values[1] >= valuesArr.length-2) {
            secondSpanClass += " right-side ";

            if (inputDistance <= collisionDistance + 1) {
              firstSpanClass += " right-side ";
            }
        }

        labelHandles(labelsArr[ui.values[0]], labelsArr[ui.values[1]], firstSpanClass, secondSpanClass);
      };

      if (!values) {
        $(sliderContainer).slider({
          range: true,
          min: min,
          max: max,
          values: [ startLow, startHigh ],
          slide: function(event, ui) {
            $input.val(ui.values[0] + "," + ui.values[1]);
            labelHandles(ui.values[0], ui.values[1]);
          },
          change: function(event, ui) {
            labelHandles(ui.values[0], ui.values[1]);
          }
        });

        labelHandles(startLow, startHigh);
      } else {
        var valuesArr = values.split(',');
        var labelsArr = labels.split(',');

        var valueLow = valuesArr.indexOf(startLow.toString());
        var valueHigh = valuesArr.indexOf(startHigh.toString());

        $(sliderContainer).slider({
          range: true,
          min: 0,
          max: valuesArr.length - 1,
          step: 1,
          values: [valueLow, valueHigh],
          slide: function(event, ui) {
            $input.val(valuesArr[ui.values[0]] + "," + valuesArr[ui.values[1]]);
            applyHandleLabels(ui, labelsArr);
          },
          change: function(event, ui) {
            applyHandleLabels(ui, labelsArr);
          }
        });

        labelHandles(labelsArr[valueLow], labelsArr[valueHigh]);
      }
    };

    self.attachHandlers = function () {
      var $destination = $('.community-parents-carousel .member-cards');
      if ($destination.length) {
        $destination.on('mouseenter', '.specialty-final a',
          U.community_common.showHoverCard($destination, '.card-child-info'));
      }
    };

    self.initializeChildGradeLightbox = function() {
      var container = $('.parents-member-cards') ;
      var lightboxButton = '.specialty-final a';
      var slideSelector = $('.card-child-info');

      if (container.length === 0) {
        return;
      }

      U.childGradeLightbox.initializeLightbox(container, lightboxButton, slideSelector);
    };

    self.initializeMembersSlider = function() {
      var container = $('.community-parents-carousel .member-cards');
      var slideSelector = ".member-card";
      var navigation = jQuery('.community-parents-carousel .members.next-prev-menu');

      if (container.length === 0) {
        return;
      }

      U.carousels.initializeSlider(container, slideSelector, navigation, 4, 3, 2, self.resize);
    };

    self.init();
  });

})(jQuery);
(function($){

    $(document).ready(function() {
      new U.blogs();
    });

    U.blogs = function() {
      var self = this;

      self.dom = {};

      self.init = function(){

        self.dom.container = $('.community-blogs-main');
        self.dom.filter = $('.blog-filter');

        if (self.dom.filter.length > 0) {
          self.initFilter();
        }

        if (self.dom.container.length === 0) {
          return;
        }

        self.equalizeHeights();
        self.initializeMoreBlogSlider();

        self.initializeMoreBloggersSlider();

      };

      self.equalizeHeights = function() {

        var moreBlogsContainer = $('.community-blogs-more');

        if(Modernizr.mq('(min-width: 960px)')){
          moreBlogsContainer.find('.blog-card-title').equalHeights();
          moreBlogsContainer.find('.blog-card-post-excerpt').equalHeights();
          moreBlogsContainer.find('.blog-card-info').equalHeights();

          moreBlogsContainer.find('.blogger-card-info').equalHeights();
        }
      };

      self.resize = function() {
        self.dom.container.find('.blogger-card-info').height('auto');
        self.dom.container.find('.blogger-card-title').height('auto');

        self.equalizeBloggerCardHeights();
      };

      self.initializeMoreBlogSlider = function() {
        var container = $('.community-blogs-more .blogs-more');
        var slideSelector = ".blog-card";
        var navigation = $('.community-blogs-more .more-blogs.next-prev-menu');

        if (container.length === 0) {
          return;
        }

        U.carousels.initializeSlider(container, slideSelector, navigation, 2, 1, 1);
      };

      self.initializeMoreBloggersSlider = function() {
        var container = $('.community-bloggers-more .bloggers-more');
        var slideSelector = ".blogger-card";
        var navigation = $('.community-bloggers-more .more-bloggers-next-prev-menu');

        if (container.length === 0) {
          return;
        }

        U.carousels.initializeSlider(container, slideSelector, navigation, 4, 3, 2, self.resize);
      };

      self.initFilter = function() {
        var $dropdownMenu = self.dom.filter.find('.dropdown-menu');

        var resize = function() {

          if(Modernizr.mq('(min-width: 960px)')){
            $dropdownMenu.removeClass('dropdown-menu');
          } else {
            $dropdownMenu.addClass('dropdown-menu');
          }
        };

        resize();
        $(window).on('resize', resize);

        self.dom.filter.on('click', '.filter', self.updateFilter);
      };

      self.updateFilter = function(event) {
        var $target = $(event.target);
        self.dom.filter.find('.current-filter').text($target.text());
        self.dom.filter.find('.filter.selected').removeClass('selected');
        var $closest = $target.closest('.filter');
        $closest.addClass('selected');
        self.sortBy($closest.data('sort-by'));
      };

      self.sortBy = function(sortBy) {
        var $postList = $('.blog-post-list');
        $postList.fadeOut(function() {
          // TODO - Sort the blogs
          $postList.fadeIn();
        });
      };

      self.init();
  };

})(jQuery);
(function($){

    $(document).ready(function() {
        new U.blogpost();
    });

    U.blogpost = function() {

        self.cacheSelectors = function() {
            self.dom = {};
            self.dom.container = $('#community-page.blog-post');
            self.dom.commentsSortBy = $('#comments_sort_by');
        };

        self.init = function() {
            self.cacheSelectors();

            if (self.dom.container.length) {
                self.applyUniform();
                self.attachHandlers();
            }
        };

        self.attachHandlers = function() {
            self.dom.commentsSortBy.on('change keyup', self.sortBy);
            self.dom.container.on('click', '.comment-inappropriate', self.flagComment);
            self.dom.container.on('click', '.thanks button', self.thanksComment);
            self.dom.container.on('click', '.thinking-of-you button', self.thinkingOfComment);
            self.dom.container.on('click', '.helpful-count button', self.likeComment);
        };

        self.sortBy = function(e) {
            var el = $(e.currentTarget);
            // TODO: Integration Task - Sort Comments
        };

        self.flagComment = function(e) {
            e.preventDefault();
            // TODO: Integration Task -- Flag Comment
        };

        self.thanksComment = function(e) {
            e.preventDefault();
            // TODO: Integration Task -- Send Thanks For Comment
        };

        self.thinkingOfComment = function(e) {
            e.preventDefault();
            // TODO: Integration Task -- Send Thinking of You For Comment
        };

        self.likeComment = function(e) {
            e.preventDefault();
            // TODO: Integration Task -- Like Comment
        };

        self.applyUniform = function() {
            U.uniformSelects(self.dom.commentsSortBy, {}, self.sortBy);
        };

        self.init();
    };
})(jQuery);
(function($){

  $(document).ready(function() {
    new U.questions();
  });

  U.questions = function() {
    var self = this;
    self.dom = {};

    // Questions and Answers

    self.initQA = function(){

      self.dom.container = $('.community-q-a');

      if (self.dom.container.length === 0) {
        return;
      }

      self.initForms();

    };

    self.initForms = function() {
      self.dom.container.find('select').uniform();
    };

    // Question detail
    self.initQuestionDetail = function(){

      self.dom.detailContainer = $('.community-q-a-details, .community-q-a-details-answers');

      if (self.dom.detailContainer.length === 0) {
        return;
      }

      self.attachDetailHandlers();
      self.initAnswerSorting();
    };

    self.attachDetailHandlers = function () {

      self.dom.detailContainer.on('click', '.button.follow', function(event) {
        // TODO Send user preference to the server
        var $target = $(event.target);
        var $button = $target.closest('.button');
        var $span = $button.find('span');

        $span.fadeOut(function (){
          $span.text('You are following');
          $span.fadeIn();
        });
      });

      self.dom.detailContainer.on('click', '.helped', function(event) {
        // TODO Send user preference to the server
        var $target = $(event.target);

        $target.fadeOut(function (){
          $target.text('Helpful');
          $target.fadeIn();
        });
      });

      self.dom.detailContainer.on('click', '.report', function(event) {
        // TODO Send user preference to the server
        var $target = $(event.target);

        $target.fadeOut(function (){
          $target.text('Flagged');
          $target.fadeIn();
        });
      });
    };

    self.initAnswerSorting = function() {
      $('.sort-options').on('click', '.filter', self.updateSort);
    };

    self.updateSort = function(event) {
      var $target = $(event.target);
      var $options = $('.sort-options');
      $options.find('.current-filter').text($target.text());
      $options.find('.filter.selected').removeClass('selected');
      var $closest = $target.closest('.filter');
      $closest.addClass('selected');
      self.sortBy($closest.data('sort-by'));
    };

    self.sortBy = function(sortBy) {
      var $answerList = $('.answer-list');
      $answerList.fadeOut(function() {
        // TODO - Sort the answers
        $answerList.fadeIn();
      });
    };

    self.initQA();
    self.initQuestionDetail();
  };

})(jQuery);
/**
 * Definition for the behaviorTool javascript module.
 */

(function($){

    // Initialize the module on page load.
    $(document).ready(function() {
        new U.communitySubmitQuestion();
    });

    U.communitySubmitQuestion = function(){

        var self = this;

        self.init = function(){
            self.cacheSelectors();
            self.attachHandlers();
        };

        self.cacheSelectors = function() {
            self.dom = {};
            self.dom.body = $(document.body);
            self.dom.topLevel = $('html, body');
            self.dom.questionButton = $('.card-ask .button');
        };

        self.attachHandlers = function() {
            self.dom.questionButton.on('click', self.fetch);
        };

        self.attachModalHandlers = function() {
            self.dom.close.on('click', self.closeModal);
            self.dom.modal.on('hide.bs.modal', self.onClose);
            self.dom.continueButton.on('click', self.showQuestion);
        };

        self.closeModal= function(e) {
            if (typeof(e) !== 'undefined') {
                e.preventDefault();
            }

            self.dom.modal.modal('hide');
        };

        self.onClose = function() {
            self.dom.body.removeClass('modal-open');
            self.dom.modal.remove();
        };

        self.fetch = function(e) {
            if (typeof(e) !== 'undefined') {
                e.preventDefault();
            }

            $.get('community.qa.question-asked.html').done(self.renderLightbox);
        };

        self.renderLightbox = function(res) {
            var modal = $(res);

            self.dom.close = modal.find('.close');
            self.dom.body.append(modal);
            self.dom.modal = $('.submit-question-modal');
            self.dom.continueButton = modal.find('.continue');
            self.dom.alreadyAsked = modal.find('.already-asked');
            self.dom.submitQuestion = modal.find('.submit-question');
            self.dom.modalSelects = modal.find('select');

            modal.find('input[type=checkbox]').uniform();
            U.uniformSelects(self.dom.modalSelects);

            self.attachModalHandlers();
            self.dom.modal.modal('show');
        };

        self.showQuestion = function(e) {
            e.preventDefault();

            self.dom.alreadyAsked.fadeOut(300, function() {
                self.dom.submitQuestion.fadeIn(300);
                self.dom.modal.animate({scrollTop: 0}, 500);
            });
        };

        self.init();
    };

})(jQuery);
/**
 * Definition for the ArticleTips javascript module.
 */

(function($){
  // Initialize the module on page load.
  $(document).ready(function() {
    new U.ArticleTips();
  });

  U.ArticleTips = function() {

    $('.article-tips-container .article-tips-item .buttons-container .icon-plus').click(function(){
      if($(this).hasClass('active')){
        $(this).removeClass('active');
      }else{
        $(this).addClass('active');
      }
    });

  };
})(jQuery);
/**
 * Definition for the GlossaryTerm javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.GlossaryTerm();
  });

  U.GlossaryTerm = function() {
    var self = this;

    //hide glossary term popover content on document ready
    $('.glossary-term-content-wrapper').hide();

    return this;
  };

})(jQuery);
/**
 * Definition for the AccountMyFavorites javascript module.
 */

(function($){
  // Initialize the module on page load.
  $(document).ready(function() {
    new U.AccountMyFavorites();
  });

  U.AccountMyFavorites = function() {

    $('.account-myfavorites .myfavorites-list .tools .icon-plus').click(function(){
      if($(this).hasClass('active')){
        $(this).removeClass('active');
      }else{
        $(this).addClass('active');
      }
    });

    $('.account-myfavorites .myfavorites-list .tools .icon-bell').click(function(){
      if($(this).hasClass('active')){
        $(this).removeClass('active');
      }else{
        $(this).addClass('active');
      }
    });

  };
})(jQuery);







































































/**
 * Uses sprockets to load individual module files (must be first line of file).
 * @see {@link https://digitalpulp.atlassian.net/browse/UN-1559}
 */

;
