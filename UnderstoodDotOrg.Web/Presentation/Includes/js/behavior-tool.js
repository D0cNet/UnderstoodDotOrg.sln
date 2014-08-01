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

      // Get the slide number to start on (counting from 0)
      self.slideToStartAt = $('.second-next-prev-menu').attr('data-start-slide-number');

      self.$rs = self.$container.royalSlider({
        keyboardNavEnabled: false,
        loop: false,
        controlNavigation: 'none',
        autoScaleSlider: true,
        autoScaleSliderWidth: 1000, // base slider width. slider will autocalculate the ratio based on these values.
        arrowsNav: true,
        arrowsNavAutoHide: false,
        autoHeight: true,
        startSlideId: parseInt(self.slideToStartAt),
        addActiveClass: true,
        autoPlay: {
          delay: 4000,
          enabled: false
        },
        sliderDrag: false
      });

      U.carousels.keyboardAccess(self.$container);
    };
    //note - deeplinking could conflict with other instances of royalslider
    //using data attribute instead.

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
      var $searchResultsWrapper = $('.results-wrapper'),
      		$searchResultButton = $('.result-body'),
          $searchResultItems = $searchResultButton.find('.hover-link-wrapper a'),
          $htmlEl = $('html');

      $htmlEl.on('equalHeights', this.equalizeHeights);
      this.$html = $('.advice-results .results-outer-wrapper').html();
      this.$wrapper = $('.advice-results .results-outer-wrapper');

      $(window).resize(function() { self.resizeHandler(); });

      // button hovers
      $searchResultsWrapper.on('mouseenter', '.result-body', function(){
          $(this).find('.result-hover').show();
	    });
      $searchResultsWrapper.on('mouseleave', '.result-body', function(){
          $(this).find('.result-hover').hide();
      });

      new U.keyboard_access ({
        focusElements: $searchResultButton,
        blurElements: $searchResultButton,
        focusHandler: function(e) {
          e.preventDefault();
          var element = $(e.currentTarget);
          element.addClass('open');
        },
        blurHandler: function(e, newTarget) {
          e.preventDefault();
          var itemInNavigation = newTarget.is($searchResultItems);
          if (!itemInNavigation) {
            $searchResultButton.removeClass('open');
          }
        }
      });

      new U.keyboard_access ({
        focusElements: $searchResultItems,
        blurElements: $searchResultItems,
        focusHandler: function(e) {
          e.preventDefault();
          var element = $(e.currentTarget);

          element.parents('.result-body').addClass('open');
        },
        blurHandler: function(e, newTarget) {
          e.preventDefault();
          var itemInNavigation = newTarget.parents().is($searchResultButton),
              mainElement = newTarget.is($searchResultButton);

          if (!itemInNavigation && newTarget !== $searchResultButton ) {
            $searchResultButton.removeClass('open');
          }
          if (mainElement) {
            newTarget.addClass('open');
          }
        }
      });


      this.adviceResultsIcons();

      return this.resizeHandler();
    };

    this.equalizeHeights = function() {
      $('.search-result .result-tip').equalHeights();
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
        keyboardNavEnabled: false,
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

    /**
     * Add click/hover events to icons
     */
    this.adviceResultsIcons = function(){
      var $tipSaveAnchor = $('.advice-results .search-result .result-hover a.tip-save');
      var $tipRemindMeAnchor = $('.advice-results .search-result .result-hover a.tip-remind-me');

      //on hover of anchor, trigger hover of icon
      $tipSaveAnchor.hover(function(){
        self.adviceResultsHoverStates($(this).children('.icon-advice-save'), 'is-hover');
      });

      //on hover of anchor, trigger hover of icon
      $tipRemindMeAnchor.hover(function(){
        self.adviceResultsHoverStates($(this).children('.icon-advice-bell'), 'is-hover');
      });

      //on click of anchor, trigger click of icon
      $tipSaveAnchor.click(function(){
        self.adviceResultsHoverStates($(this).children('.icon-advice-save'), 'active');
      });

      //on click of anchor, trigger click of icon
      $tipRemindMeAnchor.click(function(){
        self.adviceResultsHoverStates($(this).children('.icon-advice-bell'), 'active');
      });

    };

    self.adviceResultsHoverStates = function(element, elementClass){
      if(element.hasClass(elementClass)){
        element.removeClass(elementClass);
      }else{
        element.addClass(elementClass);
      }
    };

    return this.initialize();
  };

})(jQuery);
/**
 * Definition for the suggestABehavior javascript module.
 */

(function($){
  var inProgress = false;
  
  // Initialize the module on page load.
  $(document).ready(function() {
    new U.suggestABehavior();
  });

  U.suggestABehavior = function() {
    var self = this;

    //trigger the modal when the "don't see your child's challenge?" link is clicked
    jQuery('.advice-more-link').click(function(){
      jQuery('#suggest-a-behavior').appendTo("body").modal('show');
    });

    //check that the textarea has content before submission
    jQuery('.suggest-a-behavior input[type=submit]').click(function(e){
	  e.preventDefault();
	  
	  if (inProgress) {
	    return;
	  }
	  
      if (!jQuery.trim(jQuery('.suggest-a-behavior textarea').val())) {
        //the textarea is empty so show an alert message
        jQuery('.suggest-a-behavior .alert-message.hidden').removeClass('hidden');
      }else{
        //make sure alert message is hidden
        jQuery('.suggest-a-behavior .alert-message').addClass('hidden');

        ////////////////////////////////////////////////////////////////////////
        //This next bit is temporary. The confirmation message would normally //
        // be done after an ajax call to submit the text.                     //
        ////////////////////////////////////////////////////////////////////////

        //hide form and show the confirmation text
		inProgress = true;
		
		var $dataPath = $(this).data('path');
		var $dataSource = $(this).data('source');
		
		var message = $("#" + $dataSource).val();
		
		var data = {
			message: message
		};
		
		$.ajax({
			url: $dataPath,
			dataType: 'json',
			contentType: 'application/json; charset=utf-8',
			data: JSON.stringify(data),
			method: 'POST'
		}).done(function (data) {
			
			var result = data.d;
			
			if (!result.IsValid) {
				jQuery('.suggest-a-behavior .alert-message.hidden').removeClass('hidden');
				return;
			}
			
			jQuery('#suggest-a-behavior .suggest-a-behavior').hide();
			jQuery('#suggest-a-behavior .suggest-a-behavior-confirmation').removeClass("hidden").show();
		}).always(function() {
			inProgress = false;
		});
      }
    });

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

    var $module = $('.behavior-tool-related-articles'),
        $html = $('html');
    // if get-better-recommendations module exists on the page
    if(!$module.length) { return; }

      // OASIS: force page load - equal height not firing
    repositionElement();

    // Run once on window load
    $html.on('equalHeights', repositionElement);

    // Run on resize
    jQuery(window).resize(repositionElement);

    // repositions tool based on size of window
    function repositionElement() {

      var toolRelatedArticles = $('.behavior-tool-related-articles');
      var largePosition = $('.behavior-tool-related-articles-large');
      var smallPosition = $('.behavior-tool-related-articles-small');

      // only above 650 viewport or nonresponsive
      if (Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
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
 * Definition for the meetTheExperts javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.meetTheExperts();
  });

  U.meetTheExperts = function() {
    var self = this;

    // THE MODAL
    //trigger the meet the experts modal when trigger is clicked
    jQuery('#meet-the-experts-link').click(function(){
      jQuery('#meet-the-experts').modal('show');
    });

    //cache modal element for meet-the-experts
    var meetTheExpertsModal = jQuery('#meet-the-experts');
    //prevent overlay from obstructing the modal
    meetTheExpertsModal.on('show.bs.modal', function (e) {
      jQuery('#wrapper').css('position', 'static');
    });
    meetTheExpertsModal.on('hide.bs.modal', function (e) {
      jQuery('#wrapper').css('position', 'relative');
    });

    // THE SLIDER
    self.init = function(){
      $('#meet-the-experts-link').click(function() {
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
 * Definition for the behaviorSearch javascript module.
 */
(function($){
  // Initialize the module on page load.
  $(document).ready(function() {
    new U.behaviorSearch();
  });

  U.behaviorSearch = function() {
    var self = this;
	var inProgress = false;
	var page = 1;
	var $trigger = $("a.show-more-behavior-results-link");
	
	if ($trigger.length == 0) {
		return;
	}
	
	var dataPath = $trigger.data('path'),
		dataGrade = $trigger.data('grade'),
        dataLang = $trigger.data('lang'),
		dataChallenge = $trigger.data('challenge'),
		dataContainer = $trigger.data('container'),
		dataTemplate = $trigger.data('template');
	
	var $container = $("#" + dataContainer);
	var $showMoreContainer = $trigger.closest(".show-more");
	
	var templateSource = $("#" + dataTemplate).html();
	var template = Handlebars.compile(templateSource);	
	
	self.trigger_clickHandler = function(e) {
		e.preventDefault();
		
		if (inProgress) {
			return;
		}
		
		inProgress = true;
		
		// scroll to top of newly loaded items
		$('html,body').animate({scrollTop: $showMoreContainer.offset().top - 40}, 500);
		
		var data = {
			grade: dataGrade,
			challenge: dataChallenge,
			page: page + 1,
            lang: dataLang
		};
		
		$.ajax({
			url: dataPath,
			dataType: 'json',
			contentType: 'application/json; charset=utf-8',
			data: JSON.stringify(data),
			method: 'POST'
		}).done(function (data) {
			
			var result = data.d;
			
			if (!result.HasMoreResults) {
				$trigger.hide();
			}
			
			var entries = result.Matches;
			
			for (var i = 0, j = entries.length; i < j; i++) {
				$container.append(template(entries[i]));
			}

			ReadSpeaker.q(function () { rspkr.Toggle.createPlayer() });
			
			page++;
		
		}).always(function() {
			inProgress = false;
      this.$wrapper = $('.advice-results .results-outer-wrapper');

      var tallest = 0;
      $('.advice-results .result-body').each(function() {
        var height = $(this).height();
        if (height > tallest) {
          tallest = height;
        }
      });
      var height = tallest + 45;
      $('.advice-results .result-hover a').css('height', height / 2);
		});
	};

    self.init = function() {
		$trigger.on("click", self.trigger_clickHandler);
	};
	
	self.init();

    return this;
  };

})(jQuery);



