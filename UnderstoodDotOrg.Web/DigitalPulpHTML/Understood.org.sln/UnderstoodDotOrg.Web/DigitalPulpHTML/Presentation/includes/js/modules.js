/*
Keyboard Access Module is a wrapper for focus and blur events needed for keyboard accessibility and triggers
the callbacks passed to the module.
 */


(function($){
    U.keyboard_access = function(options) {
        var self = this;

        self.settings = {
            focusElements: null, // Accepts jQuery object or selector for handling delegated events
            blurElements: null, // Accepts jQuery object or selector for handling delegated events
            focusHandler: function() {},
            blurHandler: function() {},
            forceBlur: false,
            blurDelay: 100,
            body: $(document.body),
            eventNamespace: null
        };

        self.init = function(){
            self.settings = $.extend(self.settings, options);
            self.attachHandlers();
        };

        self.attachHandlers = function() {
            var focusEvent = self.getEventName('focus');
            var blurEvent = self.getEventName('blur');

            // Though one element type should always be passed, both arguments are optional
            // If a selector is passed, we delegate the event handler off of the body.
            if (typeof(self.settings.focusElements) === 'string') {
                self.settings.body.on(focusEvent, self.settings.focusElements, self.focusHandler);
            } else if (self.settings.focusElements) {
                self.settings.focusElements.on(focusEvent, self.focusHandler);
            }

            if (typeof(self.settings.blurElements) === 'string') {
                self.settings.body.on(blurEvent, self.settings.blurElements, self.blurHandler);
            } else if (self.settings.blurElements) {
                self.settings.blurElements.on(blurEvent, self.blurHandler);
            }
        };

        self.focusHandler = function(e) {
            self.settings.focusHandler(e);
        };

        self.getEventName = function(eventBaseName) {
            return self.settings.eventNamespace ? eventBaseName + '.' + self.settings.eventNamespace : eventBaseName;
        };

        // The blur handler wraps the passed callback in a 100ms timeout
        // This allows us to identify the next focused element (and pass it to the callback)
        // The callback is not triggered if the blurred element is the body.
        self.blurHandler = function(e) {

            setTimeout(function() {
                var newTarget = $(document.activeElement);

                if (self.settings.forceBlur || !newTarget.is('body')) {
                    self.settings.blurHandler(e, newTarget);
                }
            }, self.settings.blurDelay);
        };

        self.detachHandlers = function() {
            var focusEvent = self.getEventName('focus');
            var blurEvent = self.getEventName('blur');

            // Though one element type should always be passed, both arguments are optional
            // If a selector is passed, we delegate the event handler off of the body.
            if (typeof(self.settings.focusElements) === 'string') {
                self.settings.body.off(focusEvent, self.settings.focusElements, self.focusHandler);
            } else if (self.settings.focusElements) {
                self.settings.focusElements.off(focusEvent, self.focusHandler);
            }

            if (typeof(self.settings.blurElements) === 'string') {
                self.settings.body.off(blurEvent, self.settings.blurElements, self.blurHandler);
            } else if (self.settings.blurElements) {
                self.settings.blurElements.off(blurEvent, self.blurHandler);
            }
        };

        self.init();
    };

})(jQuery);
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

      // only above 650 viewport or nonresponsive
      if(Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){

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
      // only above 850 viewport or nonresponsive
      if(Modernizr.mq('(min-width: 850px)') || !Modernizr.mq('only all')){
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
      self.$submenu_btn = self.$submenu.find('div.label-more button');

      self.$previousFocus = null;

      self.breakpointActions();
      // Secondary menu starts off hidden while we adjust it for the current size, so now we have to show it.
      self.$navsecondary.css('visibility', 'visible');
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

      self.$submenu_btn.on('click touchstart', function(e) {
        e.stopPropagation();
        e.preventDefault();
      });
    };

    self.breakpointActions = function() {

      // mobile
      if (Modernizr.mq('(max-width: 649px)') && self.viewport_size !== 'small') {

        // attach events for dropdown functionality
        if (Modernizr.touch) {
          self.attachMobileEvents('touchstart');
        } else {
          self.attachMobileEvents('click');
        }
        self.attachMobileFocusEvents();

        // resized down from tablet or desktop
        // move items back where they came from and unbind events for those viewports.
        if (self.viewport_size !== null) {
          self.itemsDown(0,6);
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
        if (self.viewport_size == 'small' || self.viewport_size === null) {
          self.itemsUp(4);
          self.attachSubmenuEvents();
        }

        // page resized from desktop
        // move back one item from top level to submenu
        if (self.viewport_size == 'large') {
          self.itemsDown(4,6);
        }

        self.viewport_size = 'medium';
      }

      // desktop and nonresponsive
      else if (Modernizr.mq('(min-width: 960px)') && self.viewport_size !== 'large' || !Modernizr.mq('only all')){
        if (self.viewport_size == 'small') {
          self.resetFromSmall();
        }

        // page resized from tablet
        // move one additional item from submenu to top level
        if (self.viewport_size == 'medium') {
          self.itemsUp(2);
        }

        // page opened at desktop size or resized from moblie
        // move items from submenu to top level, attach events
        if (self.viewport_size == 'small' || self.viewport_size === null) {
          self.itemsUp(6);
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

    self.attachMobileFocusEvents = function() {
      new U.keyboard_access({
            focusElements: self.$menu.find('> li.title button'),
            blurElements: self.$submenu_list.find('a'),
            focusHandler: function(e) {
              e.preventDefault();
              if (!self.$menu.hasClass('is-open')) {
                e.stopPropagation();
                self.$menu.addClass('is-open');
                self.$submenu_list.find('a').eq(0).focus();
              }
            },
            blurHandler: function(e, newTarget) {
              if (!self.$submenu_list.has(newTarget).length) {
                self.$menu.removeClass('is-open');
              }
            }
        });
    };

    self.attachMobileEvents = function(event) {
      self.$menu.find('> li.title').on(event, function(e) {
        e.preventDefault();
        if (!self.$menu.hasClass('is-open')) {
          e.stopPropagation();
          self.$menu.addClass('is-open');
          $(document).one(event, function() {
            self.$menu.removeClass('is-open');
          });
        }
      });
    };

    self.attachSubmenuEvents = function() {
      if (Modernizr.touch) {
        self.$submenu_btn.on('touchstart', function(e) {
          e.preventDefault();

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
        self.attachFocusEvents();
      } else {
        self.$submenu.hover(self.submenuShow, self.submenuHide);
        self.attachFocusEvents();
      }
    };

    self.attachFocusEvents = function() {

      new U.keyboard_access({
            focusElements: self.$submenu_btn,
            blurElements: self.$submenu_btn,
            focusHandler: self.submenuShowAndFocus,
            blurHandler: self.delaySubmenuHide
        });

      new U.keyboard_access({
            blurElements: '.nav-secondary li.submenu ul a',
            blurHandler: self.delaySubmenuHide
        });
    };

    self.submenuShowAndFocus = function(e) {
      e.preventDefault();
      if (self.$previousFocus === null || !self.$submenu.has(self.$previousFocus).length) {
        self.submenuShow();
        self.$submenu_list.find('a').eq(0).focus();
      } else {
        self.submenuHide();
        self.$menu.find('a').not(self.$submenu_list.find('a')).last().focus();
      }
    };

    self.delaySubmenuHide = function(e, newTarget) {
      e.preventDefault();
      self.$previousFocus = $(e.currentTarget);

      if (newTarget !== self.$submenu_btn && !self.$submenu.has(newTarget).length) {
        self.$submenu_list.hide();
        self.$previousFocus = null;
      }
    };

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

    // path for data
    var $dataPAth = '/data/';

    var $body = $(document.body);


    // init
    function init() {
      showHideMore();
    }

    // request more items
    function requestMore(event) {

      // show more button container
      var $showMoreContainer = $(this);
      // show more button class

      var $showMore = $(event.currentTarget);

      // data container class name to populate (from button data attribute)
      var $dataContainer = $("." + $showMore.data('container'));

      // data class name for each item (for counting) (from button data attribute)
      var $dataItem = $("." + $showMore.data('item'));

      // data file (from button data attribute)
      var $dataFile = $showMore.data('path');

      // data count (from button data attribute)
      var $dataCount = $showMore.data('count');

      // scroll to top of newly loaded items
      $('html,body').animate({scrollTop: $showMoreContainer.offset().top - 40}, 500);

      // Ajax load items
      $.get($dataPAth + $dataFile + '.html' ,function(data){
        var newContent = $(data);

        $dataContainer.append(newContent);
        newContent.find(':focusable').eq(0).focus();
      },'html');  

      return false;
    }

    // show / hide more button
    // we're delegating this because the show-more function isn't always loaded on initial page load.
    function showHideMore(){
      $body.on('click', '.show-more-link' , requestMore);
    }

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
        $(this).find('a:first').addClass('active');
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

        // Commenting this out to retain focus for keyboard visibility
        //this.blur();
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

    U.carousels.keyboardAccess = function(carouselWrapper, separatePagination, nestedCarouselContainer, arrowsBeforeContent) {
      U.carousels.accessibleControls(carouselWrapper, arrowsBeforeContent);

      if (nestedCarouselContainer) {
        U.carousels.accessibleSlides(nestedCarouselContainer);
      } else {
        U.carousels.accessibleSlides(carouselWrapper);
      }

      if (!separatePagination) {
        U.carousels.accessiblePagination(carouselWrapper);
      }

      /* Keyboard Navigation is disabled in royal sliders as it triggers animation on */
      /* All visible sliders - this will re-attach navigation for each instance */
      var sliderEl = nestedCarouselContainer ? nestedCarouselContainer : carouselWrapper,
          slider = sliderEl.data('royalSlider');
          keyActions = {
            37: 'prev',
            39: 'next'
          };

      carouselWrapper.parent().off('keyup.arrows');
      carouselWrapper.parent().on('keyup.arrows', function(e) {
        var action = keyActions[e.keyCode];

        if (slider && typeof(action) !== 'undefined') {
          slider[action]();
        }
      });
    };

    // This method replaced the non-accessible pager elements created by RoyalSlider and
    // Moves them higher in the dom so they are accessible before the carousel contents
    U.carousels.accessibleControls = function(carouselWrapper, arrowsBeforeContent) {
      var rsOverflow = carouselWrapper.find('.rsOverflow'),
          arrowWrappers = carouselWrapper.find('.rsArrow').not('.rsContent .rsArrow'),
          pagers = carouselWrapper.find('.rsArrowIcn');

      pagers.each(function(i) {
        var pager = $(this),
            newPager = $('<button />').attr('class', 'rsArrowIcn');

        pager.replaceWith(newPager);
      });

      if (arrowsBeforeContent) {
        rsOverflow.before(arrowWrappers);
      } else {
        rsOverflow.prepend(arrowWrappers);
      }
    };

    // This method ensures that only focusable elements within visible slides
    // can accept focus (Non-visible elements receive tabindex="-1"
    U.carousels.accessibleSlides = function(carouselWrapper) {
      var slider = carouselWrapper.data('royalSlider');

      if (slider) {
        U.carousels.accessibleSlide(carouselWrapper);
        U.carousels.pauseOnFocus(slider);

        slider.ev.on('rsAfterSlideChange', function() {
          U.carousels.accessibleSlide(carouselWrapper);
        });
      }
    };

    // This method handles allowing/disallowing keyboard focus for
    // each individual slide within a carousel.
    U.carousels.accessibleSlide = function(carouselWrapper) {
      var slider = carouselWrapper.data('royalSlider'),
          slides = slider.slides,
          len = slides.length,
          current_slide = slider.currSlide.content;

      for (var i = 0; i < len; i++) {
        var obj = slides[i],
            slide = obj.content,
            focusable = slide.find(':focusable');

        focusable.removeAttr('tabindex');
        focusable.filter('[data-tabbable]').attr('tabindex', '0');
        if (!slide.is(current_slide)) {
          focusable.attr('tabindex', '-1');
        }
      }
    };

    U.carousels.accessiblePagination = function(carouselWrapper) {
      var buttons = carouselWrapper.find('.rsBullet > span');

      buttons.each(function(i) {
        var newPage = i + 1;
            newButton = $('<button />').text('Page ' + newPage);

        buttons.eq(i).replaceWith(newButton);

        // Preventing the new button from triggering form submission
        newButton.on('click', function(e) {
          e.preventDefault();
        });
      });
    };

    U.carousels.pauseOnFocus = function(slider) {
      var wrapper = slider.slidesJQ[0].parent(),
          focusable = wrapper.find(':focusable');

       focusable.on('focus', function() {
        slider.stopAutoPlay();
       });
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
          keyboardNavEnabled: false,  // enable keyboard arrows nav
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
          keyboardNavEnabled: false,  // enable keyboard arrows nav
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
            keyboardNavEnabled: false,  // enable keyboard arrows nav
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
            keyboardNavEnabled: false,  // enable keyboard arrows nav
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

      U.carousels.keyboardAccess(sliderObj);
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

      if( Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
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
          keyboardNavEnabled: false,
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
          keyboardNavEnabled: false,
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

      var slider = topicCarousel.data('royalSlider'),
          buttons = topicCarousel.find('.rsTmb'),
          playPauseButton = topicCarousel.parent().find('.play-pause'),
          playPause = function(e) {
            e.stopPropagation();
            e.preventDefault();

            var iconState = playPauseButton.hasClass('pause') ? 'play' : 'pause';

            playPauseButton.removeClass('play pause').addClass(iconState);

            if (iconState == 'pause') {
              slider.startAutoPlay();
            } else {
              slider.stopAutoPlay();
            }
          };

      playPauseButton.on('click', playPause);

      buttons.on('click', function(e) {
        e.preventDefault();

        var button = $(this),
            index = buttons.index(button);

        button.focus();
        slider.goTo(index);
      });

      self.attachHandlers = function() {
        self.dom.playPause.on('click', self.playPause);
      };

      U.carousels.keyboardAccess(topicCarousel);
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
        // only above 960 viewport or nonresponsive
        if(Modernizr.mq('(min-width: 960px)') || !Modernizr.mq('only all')){
          jQuery("#partners-slides-container .rsArrowLeft").after(partnersAnchor);
        }

      }, 500, 'partnersSlider');

        for (var i = onResizeEvent.length - 1; i >= 0; i--) {
            waitForFinalEvent(onResizeEvent[i][0], 50, onResizeEvent[i][1]);
        }
    });

    // Initialize Carousels outside of document.ready
      U.carousels.attachArrowHandlers = function(navigation, slider) {
          navigation.on('click', '.rsArrow', function (e) {
              e.preventDefault();

              var $this = $(this);
              if ($this.hasClass('rsArrowLeft')) {
                  slider.prev();
              } else if ($this.hasClass('rsArrowRight')) {
                  slider.next();
              }
          });
      };

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

          U.carousels.keyboardAccess(container, true);

          return slider;
      };

      var resetSlider = function(container, sliderArr, slideSelector, navigation, itemsPerSlide, itemsPerSlideMedium, itemsPerSlideMobile, sliderExists) {
          responsiveSliderChange( sliderArr, sliderExists, container, itemsPerSlide, false, 500, 350, itemsPerSlideMedium || 1, itemsPerSlideMobile || 1);
          container.height(container.find(slideSelector).eq(0).height());
          container.find(".rsArrow").not('.arrows .rsArrow').remove();
          container.css('visibility', 'visible').fadeIn();

          var slider = container.data('royalSlider');

          U.carousels.attachArrowHandlers(navigation, slider);

          var updateNavArrows = function() {
              var $leftArrow = navigation.find('.rsArrowLeft');
              var $rightArrow = navigation.find('.rsArrowRight');
              $leftArrow.removeClass('rsArrowDisabled').removeAttr('disabled');
              $rightArrow.removeClass('rsArrowDisabled').removeAttr('disabled');

              if (slider.currSlideId === 0) {
                  $leftArrow.addClass('rsArrowDisabled').attr('disabled');
              }

              if (slider.currSlideId === slider.numSlides - 1) {
                  $rightArrow.addClass('rsArrowDisabled').attr('disabled');
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
      self.$toolkitButton = self.$toolkit.children('button');
      self.$toolkit_wrapper = $('#parent-toolkit-wrapper');
      self.$toolkit_container = self.$toolkit_wrapper.find('div.parent-toolkit-header-container');
      self.$slides_container = $('.slides-container');
      self.$slides_org = self.$slides_container.find('div.slide').clone();
      self.$items = self.$slides_container.find('li');
      self.$toolkitLinks = self.$toolkitButton.add(self.$toolkit_container.find('a'));
      self.is_desktop = false; 
      self.is_open = false;

      self.$toolkitButton.on('click', function(e){
        e.preventDefault();

        if(self.is_open){
          self.is_open = false;
          close(self.$toolkit);
        } else {
          self.is_open = true;
          open(self.$toolkit);
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

      toolkitKeyboardAccess();

      // on window resize run resize()
      $(window).on('resize.yourParentToolkit', resize);

      // on init run resize()
      resize();


      // IE8 only Javascript (IE8 had been picking up resize bugs.)
      if(!Modernizr.mq('only all')){
        desktopSlides();
      }

    };

    function toolkitKeyboardAccess() {
      new U.keyboard_access({
        blurElements: '.toolkit-element',
        focusHandler: function(e) {
          var focused = $(e.currentTarget),
              listItem = focused.parents('.menu-list-item'),
              isActive = listItem.hasClass('is-active');

          if (!isActive) {
            listItem.siblings().removeClass('is-active');
          }
          listItem.addClass('is-active');
        },
        blurHandler: function(e, newTarget) {
          var itemInToolkit = newTarget.is('.toolkit-element'),
          itemIsBody = newTarget.is('body');

          // If not IE8 - IE8 was closing overlay when clicking arrows 
          if (!itemInToolkit && !itemIsBody && Modernizr.mq('only all')) {
            close();
            self.is_open = false;
          }
        }
      });
    }

    // show the toolkit and update the slider size
    function open() {
      self.$toolkit_wrapper.show();
      self.$toolkit_container.hide().fadeIn();
      self.$toolkit.addClass('is-open');
      self.$rs.royalSlider('updateSliderSize');
    };

    function desktopSlides() {
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
    }


    function noSlides() {
      self.$slides_container.empty();

      self.$slides_container.append(self.$slides_org);

      self.is_desktop = false;       

      destroySlider();
    }


    // hide the toolkit
    function close() {
      self.$toolkit_container.fadeOut('normal', function() {
        self.$toolkit_wrapper.hide();
      });
      
      self.$toolkit.removeClass('is-open');

      if ($(document.activeElement).is(self.$toolkitButton)) {
        self.$toolkitButton.trigger('blur');
      }
    };

    // on resize detect the viewport width
    // if viewport > 768 (or nonresponsive) sort the slides in groups of 4
    function resize() {
      if(Modernizr.mq('(min-width: 769px)') && self.is_desktop == false){
        desktopSlides();
      // if < 768 empty out the container and append the original markup
      } else if(Modernizr.mq('(max-width: 768px)') && self.is_desktop == true) {
        noSlides();
      }
    };

    // create the royalSlider
    function initSlider(){
      self.$rs = self.$slides_container.royalSlider({
        keyboardNavEnabled: false,  // enable keyboard arrows nav
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
        '.comment-form-reply'
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
 * Definition for the transcriptControl javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.transcriptControl();
  });

  U.transcriptControl = function() {
    var self = this;

    if( $('.transcript-container').length ){
      var $readMore = $('.transcript-container').find('.read-more-bottom');
      var $wrap = $('.transcript-wrap');
      var $tc = $('.transcript-container');
      var $prevContainer = (function() {
        var parentContainer = $tc.parents('.container'),
            container = parentContainer.prev('.container');

        return !container.is('.community-main-header') ? container : parentContainer;
      })();
      var $mobileClose = $('.mobile-close');

      // Initially hide transcript and add read transcript button
      $wrap.slideUp();
      $readMore.append('<a href="REMOVE">Read Transcript<i class="icon-arrow-down-blue"></i></a>');
      var $readMoreBtn = $readMore.children('a');

      // click functionality for site
      var transcriptClick = function(event) {

        if( $tc.hasClass('open') ){

          // If it's closed, it has class open, open transcript; make close transcripts
          $tc.removeClass('open');

          // Hide content
          $wrap.slideUp();

          // Add Read button
          $readMoreBtn.html('Read Transcript<i class="icon-arrow-down-blue"></i>');

          // Hide mobile close button just in case it's shown
          $mobileClose.slideUp();

          // Scroll to top of newly loaded items
          $('html,body').animate({scrollTop: $prevContainer.offset().top - 40}, 500);

        }else{

          // If it's open, it doesn't have class open, close transcript; make read transcripts
          $tc.addClass('open');

          // Display content
          $wrap.slideDown();

          // Add Close button(s)
          $readMoreBtn.html('Close Transcript<i class="icon-arrow-up-blue"></i>');

          // On mobile show close transcript on top as well
          if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) {
            $mobileClose.slideDown();
          }

          // Scroll to top of newly loaded items
          $('html,body').animate({scrollTop: $tc.offset().top - 40}, 500);

        }

        return false;
      };

      // Bind transcriptClick to read-more-bottom button
      $readMoreBtn.bind("click", transcriptClick);

      // Bind transcriptClick to mobile-close button
      $mobileClose.children("a").bind("click", transcriptClick);
      $mobileClose.hide();
    }

    return this;
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
          keyboardNavEnabled: false,
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

    $('.icon-share-dd').click(function() {

      jQuery('.share-save-dd-social-icon .toggle-dd').toggle();
      jQuery(this).toggleClass('active-dd');
      jQuery(this).parent('.share-save-dd-icon').toggleClass('is-open-dd');
    });
    
    return this;
  };
})(jQuery);
jQuery(document).ready(function(){

  //trigger for embed overlay modal
  jQuery('.infographic-zoom-icon-embed').click(function(){
    jQuery('#embed-overlay').appendTo("body").modal('show');
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

      // disable sibling buttons when selected
      jQuery(this).removeClass('disabled').parent('li').siblings('li').find('button').addClass('disabled');

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

    // only above 650 viewport or nonresponsive
    if(Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
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
 * Definition for the shareContentDropdown javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.shareContentDropdown();
  });

  U.shareContentDropdown = function() {
    var self = this,
      $shareDropdownMenu = $('.share-dropdown-menu'),
      $shareMenuButton = $shareDropdownMenu.find('.social-share-button'),
      $socialShareItems = $shareDropdownMenu.find('.share-icon'),
      $previousFocus = null;

    new U.keyboard_access({
      focusElements: $shareMenuButton,
      blurElements: $shareMenuButton,
//      after reset of all focused menu dropdowns (select class removed to close any previously opened)
//      on focus of button, selected class is added to the container div that holds the button
//      which opens menu dropdown.
      focusHandler: function(e) {
        e.preventDefault();
        var element = $(e.currentTarget),
            tooltip = element.parent(),
            selected = element.parents().is('.selected');

        if (!selected) {
          $shareDropdownMenu.removeClass('selected');
        }

        tooltip.addClass('selected');

      },
//        when the blur event is called on the button and you are moving outside of the share menu container, then the select class
//        is removed from the dropdown container, triggering the menu to be removed.
      blurHandler: function(e, newTarget) {
        e.preventDefault();

          var itemInNavigation = newTarget.parents().is($shareDropdownMenu);

          if (!itemInNavigation) {
            $shareDropdownMenu.removeClass('selected');
          }

      }
    });

    new U.keyboard_access({
      blurElements: $socialShareItems,
//      when the blur event is triggered on an item in the share menu container, and the new target is not in the container, and
//      not the button, itself, the selected class is removed and the menu disappears.  If it is the button, the container
//      gets the selected class and is visible.
      blurHandler: function(e, newTarget) {
        e.preventDefault();

          var itemInNavigation = newTarget.parents().is($shareDropdownMenu);

          if (!itemInNavigation && newTarget !== $shareMenuButton) {
            $shareDropdownMenu.removeClass('selected');
            $shareDropdownMenu.removeClass('selected');
          }

          if ( itemInNavigation && newTarget == $shareMenuButton) {
            $shareDropdownMenu.addClass('selected');
          }

      }
    });


    $shareDropdownMenu.on('click touchstart', function(){
      var tooltip = $(this);
      tooltip.toggleClass('selected');
      self.toggleArrowsOnSocialShare();
      return false;
    });

    $('body').on('click touchstart', function(){
      self.showArrowsOnSocialShare();
      $shareDropdownMenu.removeClass('selected');
    });


    // Hide arrows when share button is selected. Show them when unselected
    self.toggleArrowsOnSocialShare = function(){
      var $shareDropdown = $('.article-slideshow-container.text-tips .share-dropdown-menu');
      if(!$shareDropdown.length)return;
      var $arrows = $('.article-slideshow-container.text-tips .rsArrow');

      if($shareDropdownMenu.hasClass('selected')){
        $arrows.hide();
      }else{
        $arrows.show();
      }

    };

    // Show arrows when body is clicked
    self.showArrowsOnSocialShare = function(){
      var $shareDropdown = $('.article-slideshow-container.text-tips .share-dropdown-menu');
      if(!$shareDropdown.length)return;
      var $arrows = $('.article-slideshow-container.text-tips .rsArrow');

      $arrows.show();

    };

    return this;
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
 * Created by cat on 3/17/14.
 */

(function($){

  $(document).ready(function(){
    new U.skipLink();
  });

  U.skipLink = function() {
      var self = this;

      self.pageSections = ['Dashboard', 'Feature', 'Toolbar', 'Sidebar', 'Content', 'Comments'];

      self.init = function() {
        self.cacheDom();
        self.setModel();
        self.buildSkipList();
        self.cacheDelegatedDom();
        self.attachHandlers();
      };

      self.setModel = function() {
        selectors = [];
        self.model = {};
        self.model.skipLinks = [];

        for (var i = 0; i < self.pageSections.length; i++) {
          var item = {};

          item.contentType = self.pageSections[i];
          item.selector = '.skiplink-' + item.contentType.toLowerCase();
          item.element = $(item.selector);
          item.linkId = item.contentType + 'link';
          item.linkHref = '#' + item.linkId;
          item.subNavText = 'Skip to ' + item.contentType;

          /* Storing index on element so we can quickly find skiplink data for each element when building list */
          item.element.data('skipLinkIndex', i);
          self.model.skipLinks.push(item);

          if (item.element.length) {
            selectors.push(item.selector);
          }
        }

        /* Building separate query for collected skip link elements on page */
        /* This guarantees order will match order that items appear in the DOM */
        self.model.skipLinkCollection = $(selectors.join(','));
      };

      self.cacheDom = function() {
        self.dom = {};
        self.dom.body = $(document.body);
      };

      self.cacheDelegatedDom = function() {
        self.dom.skipList = $('.skip-list');
      };

      self.attachHandlers = function() {
        self.dom.body.on('click', '.secondary-navigation-link', self.skipBackToMainLinkMenu);
      };

      self.buildSkipList = function() {
        var skipList = $('<ul class="skip-list"></ul>');

        self.dom.body.prepend(skipList);


        self.model.skipLinkCollection.each(function(i) {
          var el = $(this),
              index = el.data('skipLinkIndex'),
              item = self.model.skipLinks[index];

          skipList.append('<li><a class="skip-link" href="'+ item.linkHref +'" tabindex="1">' + item.subNavText + '</li>');
          item.element.prepend('<div class="skip-link-secondary"><a href="#" class="skip-link secondary-navigation-link" id="'+ item.linkId +'">Back to Navigation</a></div>');
        });
      };

      self.skipBackToMainLinkMenu = function(e) {
          self.dom.skipList.find(':focusable').eq(0).focus();
      };

      self.init();
  };

})(jQuery);
(function ($){

  $(document).ready(function(){
    new U.keyboardresultsSlider();
  });

  U.keyboardresultsSlider = function() {
    var self = this,
        sliderButton = $('.results-slider.blue .slider-button');


    sliderButton.on('focus click', function(e) {
      e.preventDefault();
      var element = $(e.currentTarget),
          currentButton = element.index(),
          slider = element.parent();

      setTimeout(function(){
        if (currentButton === 0 && !element.hasClass('.blue-one')) {
          slider.attr('class', 'blue results-slider blue-one');
        } else if (currentButton === 1 && !element.hasClass('.blue-two')) {
          slider.attr('class', 'blue results-slider blue-two');
        } else if (currentButton === 2 && !element.hasClass('.blue-three')) {
          slider.attr('class', 'blue results-slider blue-three');
        } else if (currentButton === 3 && !element.hasClass('.blue-four')) {
          slider.attr('class', 'blue results-slider blue-four');
        } else if (currentButton === 4 && !element.hasClass('.blue-five')) {
          slider.attr('class', 'blue results-slider blue-five');
        }

        element.removeAttr('aria-hidden', 'role');
        var siblings = element.siblings();
        siblings.attr('aria-hidden', 'true');
        siblings.attr('role', 'presentation');

      }, 0);



    });

    sliderButton.on('click', function(e) {
      e.preventDefault();
      var element = $(e.currentTarget),
          nextFocusableElement = $('.for-kids #rate-for-kids');
      nextFocusableElement.focus();
    });

  return this;
  };

})(jQuery);
(function($){

  U.actionButtons = function(container){
    var self = this,
      buttons = container.find('button'),
      buttonOne = container.find('button.icon-plus'),
      buttonTwo = container.find('button.icon-bell'),
      buttonCopy = $('.action-button-hidden'),
      prevFocus = null,
      iconBell = null,
      iconPlus = null,
      nextNonButtonFocusableElement = null,
      findNextFocus = function(e) {
        var nextFocus = prevFocus.next();

        if (prevFocus.is(iconBell)){
          $(iconBell).focus();
        }
        else if (prevFocus.is(iconPlus)){
          $(iconPlus).focus();
        }
      },
      deferFocus = function(e) {
        var element = $(e.currentTarget),
            buttonCopy = $('<button class="action-button-hidden" tabindex="1"></button>');
        e.preventDefault();
        element.after(buttonCopy);
        var buttonContainer = element.parent(),
            nextMainElement = buttonContainer.next();
        nextNonButtonFocusableElement = nextMainElement.find(':focusable');

        iconPlus = element.parent().find('.icon-plus');
        iconBell = element.parent().find('.icon-bell');
        prevFocus = $(document.activeElement);
        buttonCopy.focus();
      },
      toggleActiveClass = function(e) {
        element = $(e.currentTarget);
        e.preventDefault();

        if (element.hasClass('active')) {
          element.removeClass('active');
        } else {
          element.addClass('active');
        }
        deferFocus(e);
      };

    buttonTwo.on('click', toggleActiveClass);
    buttonOne.on('click', toggleActiveClass);
    container.on('blur', '.action-button-hidden', function(e) {
      $(this).remove();
      findNextFocus();
    });

  };

})(jQuery);


























/**
 * Uses sprockets to load individual module files (must be first line of file).
 * @see {@link https://digitalpulp.atlassian.net/browse/UN-1559}
 */

;
