(function($){

    // Initialize the module on page load.
    $(document).ready(function() {
      new U.user_profile();
    });

   U.user_profile = function() {
    var self = this;

    U.user_profile.showHoverCard = function($destination, $cardSelector, displayTargetSelector) {
      return function (event) {
        var $body = $('body');
        $body.trigger('click.card-close');
        event.preventDefault();
        event.stopPropagation();

        if (event.keyCode && event.keyCode != 13 && event.keyCode != 32) {
          return;
        }

        var $target = $(event.target);
        var $childInfo = $target.closest('.member-card-specialties').find($cardSelector);
        var $displayTarget = $target.closest('.member-card-specialties').find(displayTargetSelector);
        var $currentCard = $target.parent().find('.card-child-info');
        var cardIndex = $childInfo.index($currentCard);
        if (cardIndex < 0) {
          cardIndex = 0;
        }

        var $allFocusable = $body.find(':focusable');
        var $prevFocusable = $displayTarget.find(':focusable').first();
        var $nextFocusable = $allFocusable.eq($allFocusable.index($prevFocusable) + 1);

        var $childInfoClone = $childInfo.clone();
        $childInfoClone.addClass('childInfoClone');
        if ($childInfoClone.length < 2) {
          $childInfoClone.find('.child-info-next-prev-menu').hide();
        }

        var addCloseEvent = function($card) {
          var hideCard = function (event) {
            $card.hide();
            $childInfoClone.remove();
            $body.off('mousedown.card-close');
            $(window).off('resize.card-close');
            self.keyboardAccessInCard.detachHandlers();
            self.keyboardAccessOutsideCard.detachHandlers();
          };

          // Use mousedown instead of click so that it is fired before focus()
          // This was causing an issue when clicking between items
          $body.on('mousedown.card-close', function(event) {
            var $target = $(event.target);
            if (!$target.is($childInfoClone) &&
                $childInfoClone.has($target).length === 0) {
              hideCard(event);
            }
          }).on('keyup.card-close', function (e3) {
              if (e3.which == 27) { // Esc
                  $body.off('keyup.card-close');
                  hideCard(e3);

                  // If the event that received the keypress within the card, then we will refocus to the link that opened the card
                  if ($(e3.target).parents('.card-child-info').length !== 0) {
                      $target.focus();
                  }
              }
          });

          $(window).on('resize.card-close', hideCard);
        };

        $destination.append($childInfoClone);

        var margin = 5;
        var newLeft = $displayTarget.offset().left - $destination.offset().left - parseInt($childInfoClone.find('.popover-content').css('padding-left'), 10) - 30;
        var newTop = $displayTarget.offset().top - $destination.offset().top + $displayTarget.outerHeight() + 16;

        var $shownCard = $childInfoClone.eq(cardIndex);
        $shownCard.show();
        $shownCard.find('.rsArrowLeft').addClass('rsArrowDisabled');
        addCloseEvent($shownCard);

        var windowWidth = Math.max($(window).width(), window.innerWidth);
        var cloneWidth = $childInfoClone.width();
        var centerLeft = self.getCenterLeftValue($displayTarget, $childInfoClone, $destination, windowWidth, margin);
        var $caret = $childInfoClone.find('.caret');
        var caretLeft = $displayTarget.offset().left - centerLeft + (($displayTarget.width() - 22) / 2) - $destination.offset().left;

        if (Modernizr.mq('(max-width: 321px)')) {
          $childInfoClone.addClass('mobile');
          $childInfoClone.css('top', newTop);

          caretLeft = $displayTarget.offset().left - ($shownCard.position().left) + (($displayTarget.width() - 22) / 2) - 16;
          $caret.css('left', caretLeft - 255);
        } else if ( (cloneWidth + $displayTarget.offset().left > windowWidth - margin && newLeft < cloneWidth)) {
          $childInfoClone.addClass('middle');
          $childInfoClone.css('left', centerLeft);
          $childInfoClone.css('top', newTop);

          $caret.css('left', caretLeft - 255);
        } else if (cloneWidth + $displayTarget.offset().left > windowWidth - margin){
          $childInfoClone.addClass('right');
          $childInfoClone.css('left', newLeft);
          $childInfoClone.css('top', newTop);
        } else if ($destination.offset().left + newLeft < 0) {
          $childInfoClone.css('left', 0);
          $childInfoClone.css('top', newTop);

          caretLeft = $displayTarget.offset().left - ($shownCard.position().left) + (($displayTarget.width() - 22) / 2) - 16;
          $caret.css('left', caretLeft - 255);
        } else {
          $childInfoClone.css('left', newLeft);
          $childInfoClone.css('top', newTop);
        }

        self.scrollIfOffScreen($shownCard);
        self.attachKeyboardHandlers($shownCard, $childInfoClone, $prevFocusable, $nextFocusable);

        $childInfoClone.on('click', '.rsArrowLeft', function(e) {
          e.preventDefault();
          e.stopPropagation();
          var currentElement = $(e.currentTarget);

          currentElement.parents('.member-cards').find('.rsArrow').removeClass('rsArrowDisabled');

          cardIndex--;

          var $currentCard = $childInfoClone.eq(cardIndex);

          if ( cardIndex <= -1 ) {
            cardIndex = 0;
            $currentCard = $childInfoClone.eq(cardIndex);
            currentElement.addClass('rsArrowDisabled');
          }

            $childInfoClone.hide();
            $currentCard.show();
            $currentCard.find(':focusable').first().focus();
            addCloseEvent($childInfoClone.eq(cardIndex));

          if ( cardIndex <= 0 ) {
            $currentCard.find('.rsArrowLeft').addClass('rsArrowDisabled');
          }

        });

        $childInfoClone.on('click', '.rsArrowRight', function(e) {
          e.preventDefault();
          e.stopPropagation();
          var currentElement = $(e.currentTarget);

          currentElement.parents('.member-cards').find('.rsArrow').removeClass('rsArrowDisabled');

          cardIndex++;

          if (cardIndex >= $childInfoClone.length) {
            cardIndex = $childInfoClone.length-1;
          }

          var $currentCard = $childInfoClone.eq(cardIndex);

          if (cardIndex == $childInfoClone.length-1) {
            cardIndex = $childInfoClone.length-1;
            $currentCard = $childInfoClone.eq(cardIndex);
          }

          $childInfoClone.eq(cardIndex).hide();
          $currentCard.show();
          $currentCard.find(':focusable').eq(1).focus();
          addCloseEvent($childInfoClone.eq(cardIndex));

          if (cardIndex == $childInfoClone.length-1) {
            $currentCard.find('.rsArrowRight').addClass('rsArrowDisabled');
          }

        });
      };
    };

    self.scrollIfOffScreen = function($target) {
      var $window = $(window);
      var margin = 10;
      var top = $target.offset().top;
      var height = $target.outerHeight();
      var windowTop = $window.scrollTop();
      var windowHeight = $window.height();
      var requiredScroll = (top + height) - (windowTop + windowHeight);

      var scrollTop = windowTop + requiredScroll + margin;
      if (scrollTop > top) {
        scrollTop = top - margin;
      }

      if (requiredScroll > 0){
        $('html,body').animate({scrollTop: scrollTop});
      }
    };

    self.getCenterLeftValue = function ($displayTarget, $childInfoClone, $container, windowWidth, margin) {
          var centerLeft = $displayTarget.offset().left + ($displayTarget.outerWidth() / 2) - ($childInfoClone.outerWidth() / 2) - $container.offset().left - 30;
          centerLeft = Math.max(0, centerLeft);

          if (centerLeft + $childInfoClone.outerWidth() > windowWidth) {
            centerLeft = 0;
          }

          return centerLeft;
    };

    self.attachKeyboardHandlers = function($shownCard, $childInfoClone, $prevFocusable, $nextFocusable) {
      var $focusable = $shownCard.find(':focusable');
      $focusable.eq(0).focus();

      self.keyboardAccessInCard = new U.keyboard_access({
          blurElements: '.childInfoClone :focusable',
          blurHandler: function (e, newTarget) {
            var $maybeFocusable = $childInfoClone.find(':focusable');
            if (newTarget.closest($childInfoClone).length === 0) {
              if ($maybeFocusable.index($(e.target)) > 0) {
                $nextFocusable.first().focus();
              } else {
                $prevFocusable.first().focus();
              }
            }
          },
          blurDelay: 0,
          eventNamespace: 'profileCard'
        });

      self.keyboardAccessOutsideCard = new U.keyboard_access({
          blurElements: $prevFocusable.add($nextFocusable),
          blurHandler: function (e, newTarget) {
            var $maybeFocusable = $childInfoClone.find(':focusable');
            if (newTarget.is($prevFocusable)) {
              $maybeFocusable.filter(':visible').last().focus();
            } else if (newTarget.is($nextFocusable)) {
              $maybeFocusable.filter(':visible').eq(0).focus();
            }
          },
          blurDelay: 0,
          eventNamespace: 'profileCard'
        });
      };
  };
})(jQuery);
/**
 * Definition for the Recos javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.Recos();
  });

  U.Recos = function() {
    var self = this;

    self.init = function() {
      self.$body = $(document.body);
      self.$recosCarousels = $('.carousel-recos');
      self.attachHandlers();
      self.applyKeyboardAccess();
    };

    self.attachHandlers = function() {
      self.$body.on('click', '.popover-content .close', self.closePopover);
      self.$recosCarousels.on('click', '.icon-skip', self.skipRecommendation);
      self.$body.on('click', '.group-cards .action-skip-this', self.skipGroup);
    };

    self.closePopover = function(e) {
      var clicked = $(e.currentTarget),
          link = clicked.parents('.popover').prev();

      link.trigger('click');
    };

    self.skipRecommendation = function(e) {
      e.preventDefault();

      var clicked = $(e.currentTarget),
          item = clicked.parents('li');

      $.get('/data/recommendations/recommendation-item.html', self.newRecommendationCallback(item), 'html');
    };

    self.skipGroup = function(e) {
      e.preventDefault();

      var clicked = $(e.currentTarget),
          item = clicked.parents('.group-card');

      $.get('/data/recommendations/group-item.html', self.newGroupItemCallback(item), 'html');
    };

    self.newGroupItemCallback = function(item) {
      return function(res) {
        var wrapper = item.wrap('<div />');

        wrapper.fadeOut(function() {
          item.replaceWith(res);

          wrapper.fadeIn(function() {
            wrapper.replaceWith(res);
          });
        });
      };
    };

    self.newRecommendationCallback = function(item) {
      return function(res) {
        var parent = item.parents('ul');

        item.fadeOut(function() {
          item.remove();
          parent.append(res);
          var items = parent.children();

          items.height('').equalHeights();
        });
      };
    };

    self.applyKeyboardAccess = function() {
      new U.keyboard_access({
        focusElements: '.carousel-recos .rsContainer a, .carousel-recos .rsContainer button',
        blurElements: '.carousel-recos .rsContainer a, .carousel-recos .rsContainer button',
        forceBlur: true,
        focusHandler: function (e) {
          var el = $(e.currentTarget),
              item = el.parents('li');

          item.addClass('focused');
        },
        blurHandler: function(e, newTarget) {
          var el = $(e.currentTarget),
              item = el.parents('li'),
              targetParentItem = newTarget.parents('li');

          if (!item.is(targetParentItem)) {
            item.removeClass('focused');
          }
        }
      });
    };

    // carousel for you / turn on action buttons
    U.actionButtons($('.recos-for-you .buttons-container'));

    // carousel for you / make equal height items
    if (Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all') ){
      $('.recos-for-you li').equalHeights();

    } else {
      $('.recos-for-you li').height('');
    }

    self.init();

    return self;
  };

})(jQuery);
(function($){

    $(document).ready(function() {
      new U.upcomingEvents();
    });

    U.upcomingEvents = function() {
      var self = this;

      self.dom = {};

      self.init = function(){

        self.dom.container = $('.recos-upcoming-events');

        if (self.dom.container.length === 0) {
          return;
        }

        self.initializeEventCards();

      };

      self.initializeEventCards = function() {
        var container = $('.recos-upcoming-events .event-cards');
        var slideSelector = '.event-card';
        var navigation = $('.recos-upcoming-events .more-upcoming-events.next-prev-menu');

        if (container.length === 0) {
          return;
        }

        U.carousels.initializeSlider(container, slideSelector, navigation, 2, 2, 1);
      };

      

      self.init();
  };

})(jQuery);
(function($){

    $(document).ready(function() {
      new U.askParents();
    });

    U.askParents = function() {
      var self = this;

      self.dom = {};

      self.init = function(){

        self.dom.container = $('.recos-ask-parents');

        if (self.dom.container.length === 0) {
          return;
        }

        self.initializeAskParents();
        self.truncate();
        self.equalizeHeights();


        
      };

      self.equalizeHeights = function() {

        var askParentsContainer = $('.recos-ask-parents .parents-wrapper');

        // only above 960 viewport or nonresponsive
        if(Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
          askParentsContainer.equalHeights();
        }
      };


      self.initializeAskParents = function() {
        var container = $('.recos-ask-parents .parents-cards');
        var slideSelector = '.parents-card';
        var navigation = $('.recos-ask-parents .more-ask-parents.next-prev-menu');

        if (container.length === 0) {
          return;
        }

        U.carousels.initializeSlider(container, slideSelector, navigation, 2, 2, 1, self.resize);
      };

      self.truncate = function() {
        $('.recos-ask-parents .parents-question h3').ellipsis({
          row: 1,
          char: '…' // &hellip;
        });
        $('.recos-ask-parents .parents-question p').ellipsis({
          row: 3,
          char: '…' // &hellip;
        });
      };

      self.resize = function() {
        self.truncate();
        self.equalizeHeights();
      };


      self.init();
      
  };

})(jQuery);
/**
 * Definition for the reco tabs javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.recosTabs();
  });

  U.recosTabs = function() {
    var self = this;

    $('#recos-tabs').easytabs();

    return this;
  };

})(jQuery);
(function($){

  $(document).ready(function() {
    new U.connectWithParents();
  });

  U.connectWithParents = function() {

    var self = this;

    self.init = function() {

      self.initializeChildGradeLightbox();
      self.truncate();
    };

    self.initializeChildGradeLightbox = function() {
      var $destination = $('.discussion-list');

      if ($destination.length === 0) {
        $destination = $('.parents-member-cards');
      }

      $('.parents-member-cards').on('click keypress', '.specialty span',
          U.user_profile.showHoverCard($destination, '.card-child-info', '.specialty-final'));
    };

    self.truncate = function() {
      $('.name-member').ellipsis({
        row: 2,
        char: '…' // &hellip;
      });
    };

    self.init();
  };

})(jQuery);
/**
 * Definition for the behaviorTool javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.recosBlogs();
  });

  U.recosBlogs = function() {
    var self = this;

    self.dom = {};

    self.init = function(){

      self.dom.container = $('.recos-blogs');
      self.dom.html = $('html');

      // exit if module not existing, or IE8
      if (self.dom.container.length === 0 || !Modernizr.mq('only all')) {
        return;
      }

      self.initializeBlogSlider();

    };

    self.initializeBlogSlider = function() {
      var container = $('.recos-blogs .group-cards');
      var slideSelector = '.group-card';
      var navigation = $('.recos-blogs .blogs.next-prev-menu');

      if (container.length === 0) {
        return;
      }

      U.carousels.initializeSlider(container, slideSelector, navigation, 2, 2, 1, self.resize);
    };

    // on tab click, make sure Royalslider can calculate height/width of the slides.  Use delay.
    $('#tab-follow-blog').on('click', function(e) {
      e.preventDefault();
      setTimeout(function(){
        $('.recos-blogs .group-cards').royalSlider('updateSliderSize', true);
      },500);
    });

    self.init();
  };

})(jQuery);
/**
 * Definition for the tabToolkit javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    
    // no carousel for IE8
    if ( Modernizr.mq('only all')) {
      new U.tabToolkit();
    }

  });

  /*
   * Parent Toolkit in Header Module
   *
   */
  U.tabToolkit = function(){

    var self = this;

    function init() {

      self.$toolkit_wrapper = $('.tab-toolkit-wrapper');
      self.$toolkit_container = self.$toolkit_wrapper.find('div.tab-toolkit-header-container');
      self.$slides_container = $('.tab-toolkit-slides-container');
      self.$slides_org = self.$slides_container.find('div.slide').clone();
      self.$items = self.$slides_container.find('li');
      self.is_desktop = false; 

      tabToolkitKeyboardAccess();

      // on window resize run resize()
      $(window).on('resize.tabToolkit', resize);

      // on init run resize()
      resize();

    };

    function tabToolkitKeyboardAccess() {
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
          var itemInToolkit = newTarget.is('.toolkit-element') || newTarget.is('.rsArrowIcn'),
          itemIsBody = newTarget.is('body');

          // If not IE8 - IE8 was closing overlay when clicking arrows 
          if (!itemInToolkit && !itemIsBody && Modernizr.mq('only all')) {
            close();
            self.is_open = false;
          }
        }
      });
    }

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

      U.carousels.keyboardAccess(self.$slides_container, true, false, false);
    };

    // destroy the sliders events
    function destroySlider() {
      self.$rs.royalSlider('destroy');
    };

    // initialize the toolkit
    init();

    // on tab click, make sure Royalslider can calculate height/width of the slides.  Use delay.
    $('#tab-parent-toolkit').on('click', function(e) {
      e.preventDefault();
      setTimeout(function(){
        self.$slides_container.royalSlider('updateSliderSize', true);
      },500);
    }); 


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









