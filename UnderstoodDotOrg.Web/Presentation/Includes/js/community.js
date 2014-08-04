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
          $childInfoClone.hide();
          cardIndex--;
          if (cardIndex < 0) {
            cardIndex = $childInfoClone.length-1;
          }
          var $currentCard = $childInfoClone.eq(cardIndex);
          $currentCard.show();
          $currentCard.find(':focusable').first().focus();
          addCloseEvent($childInfoClone.eq(cardIndex));
        });

        $childInfoClone.on('click', '.rsArrowRight', function(e) {
          e.preventDefault();
          e.stopPropagation();
          $childInfoClone.eq(cardIndex).hide();
          cardIndex++;
          if (cardIndex >= $childInfoClone.length) {
            cardIndex = 0;
          }
          var $currentCard = $childInfoClone.eq(cardIndex);
          $currentCard.show();
          $currentCard.find(':focusable').eq(1).focus();
          addCloseEvent($childInfoClone.eq(cardIndex));
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
                ///modal.welcome-tour.c1a.html
            	$.get('/Presentation/AjaxData/WelcomeTour.aspx?lang=' + self.dom.communityPage.data("lang")).done(self.renderLightbox);
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
            self.dom.dialog = self.dom.modal.find('.modal-dialog');

            self.fireCarousel();
            self.updatePagingData();
            self.attachHandlers();

            self.dom.modal.modal('show');
        };

        self.fireCarousel = function() {
            self.model.carousel = U.carousels.initializeSlider(self.dom.carousel, '.slide', self.dom.carouselNav, 1, 1, 1, self.resize, false);
        };

        self.attachHandlers = function() {
            self.model.carousel.ev.on('rsAfterSlideChange', self.slideChange);
            self.dom.modal.on('show.bs.modal', self.positionModal);
            self.dom.modal.on('hide.bs.modal', self.onClose);
            self.dom.body.on('click', '.close' , self.closeModal);
            self.dom.modal.on('show.bs.modal', function() {
                $(this).find(':focusable').first().focus();
            });
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

        self.closeModal = function() {
            self.dom.modal.modal('hide');
        };

        self.onClose = function() {
            self.dom.body.focus();
            // TODO -- Integration task - set cookie so lightbox isn't displayed once this has been dismissed
        };

        self.resize = function() {
          self.positionModal();
        };

        /* TODO - This is a temporary fix, should be refactored to use global modal positioning method */
        self.positionModal = function() {
          var leftMargin = (self.dom.dialog.width() / 2) * -1,
              topMargin = ((self.dom.dialog.height() - $(window).height()) / 2);

          self.dom.dialog.css({
            'margin-left': leftMargin,
            'margin-top': topMargin
          });
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

    self.initializeFilters = function() {
      function setWidth() {
        self.$containerWidth = $('.parentgroups-form').width();
      }

      self.$behaviorForm = $('.parentgroups-form');
      self.$behaviorFormSelect = self.$behaviorForm.find('select');

      U.uniformSelects(self.$behaviorFormSelect, {selectAutoWidth: false}, self.setWidth);

      self.$behaviorFormSubmit = self.$behaviorForm.find('.submitButton span');
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
            self.dom.html = $('html');
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
                self.fireCarousel();
                self.dom.html.on('equalHeights', self.equalizeHeights);
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

            // only above 650 viewport or nonresponsive
            if (applyResize || !Modernizr.mq('only all')){
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
            self.dom.html = $('html');
            self.dom.window = $(window);
            self.dom.calendarContainer = $('.container.calendar');
            self.dom.gridRows = self.dom.calendarContainer.find('.grid-row');
            self.dom.moreInfoToggles = self.dom.calendarContainer.find('.more-info-toggle');
            self.dom.eventHeaderLinks = self.dom.calendarContainer.find('.event-name');
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
                self.dom.eventHeaderLinks.on('click', self.showEvent);
            }

            self.dom.html.on('equalHeights', self.equalizeHeights);
            self.setKeyboardAccess();
        };

        self.setKeyboardAccess = function() {
          new U.keyboard_access({
            blurElements: '.calendar-grid .event-card a',
            blurHandler: function (e, newTarget) {
              var $eventCard = $(e.currentTarget).parents('.event-card');
              if (newTarget.parents('.event-card').length === 0) {
                $eventCard.hide();
              }
            }
          });
        };

        self.setModel = function() {
            self.model = {
                gridView: self.dom.gridRows.length,
                desktop: Modernizr.mq(self.settings.breakpoint),
                breakpointChange: false
            };
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
            self.closeEventPopovers();
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

        self.closeEventPopovers = function() {
            self.dom.calendarContainer.find('.event-card').hide();
        };

        self.showEvent = function(e) {
            e.preventDefault();
            e.stopPropagation();

            if (!self.model.desktop) {
                self.toggleDetailView(e);
                return;
            }

            var clicked = $(e.currentTarget),
                eventCard = clicked.parents('.event').find('.event-card'),
                isOpen = eventCard.is(':visible');

            self.dom.calendarContainer.find('.event-card').hide();

            if (!isOpen) {
                self.scrollToPosition(clicked, 10);
                eventCard.show();

                self.dom.topLevel.on('click.hide-calendar touchstart.hide-calendar', function (e2) {
                    if ($(e2.target).parents('.event-card').length === 0) {
                        self.dom.calendarContainer.find('.event-card').hide();
                        self.dom.topLevel.off('click.hide-calendar touchstart.hide-calendar');
                    }
                }).on('keyup.hide-calendar', function (e3) {
                    if (e3.which == 27) {
                        self.dom.calendarContainer.find('.event-card').hide();
                        self.dom.topLevel.off('keyup.hide-calendar');

                        // If the event that received the keypress within the card, then we will refocus to the link that opened the card
                        if ($(e3.target).parents('.event-card').length !== 0) {
                            $(e.target).focus();
                        }
                    }
                });
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

        self.scrollToPosition = function(element, paddingIn, durationIn) {
            var padding = typeof(paddingIn) !== 'undefined' ? paddingIn : 50,
                duration = durationIn || 300,
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
      container.on('click', lightboxButton,
          function (event) {
            var $body = $('body');
            $body.trigger('click.card-close');
            event.preventDefault();
            event.stopPropagation();

            var addMouseLeaveEvent = function($card) {
              var hideCard = function (event) {
                  $card.hide();
                  $body.off('click.card-close');
              };

              $card.find('.card-close').on('click', hideCard);
              var $body = $('body');
              $body.on('click.card-close', function(event) {
                var $target = $(event.target);
                if (!$target.is($card) && $card.has($target).length === 0) {
                  hideCard(event);
                }
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
              e.preventDefault();
              e.stopPropagation();
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
              e.preventDefault();
              e.stopPropagation();
              removeMouseLeaveEvent($childInfoCards.eq(cardIndex));
              $childInfoCards.eq(cardIndex).hide();
              cardIndex++;
              if (cardIndex >= $childInfoCards.length) {
                cardIndex = 0;
              }
              $childInfoCards.eq(cardIndex).show();
              addMouseLeaveEvent($childInfoCards.eq(cardIndex));
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
      self.truncate();
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

        var spacing = 100 / (valuesArr.length - 1);
        for (var i = 1; i < valuesArr.length - 1; i++) {
          $('<span class="ui-slider-tick-mark"></span>')
            .css('left', (spacing * i) +  '%')
            .appendTo($(sliderContainer));
        }

        labelHandles(labelsArr[valueLow], labelsArr[valueHigh]);
      }
    };

    self.attachHandlers = function () {
      var $destination = $('.community-parents-carousel .member-cards');
      $destination.on('click keypress', '.specialty span',
          U.user_profile.showHoverCard($destination, '.card-child-info', '.specialty-final'));
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

    self.truncate = function() {
      $('.name-member').ellipsis({
        row: 2,
        char: '…' // &hellip;
      });
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

        self.dom.html = $('html');
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

        // only above 960 viewport or nonresponsive
        if(Modernizr.mq('(min-width: 960px)') || !Modernizr.mq('only all')){
          self.dom.html.on('equalHeights', function() {
            self.triggerEqualHeights();
          });
        }
      };

      self.triggerEqualHeights = function() {
        moreBlogsContainer.find('.blog-card-title').equalHeights();
        moreBlogsContainer.find('.blog-card-post-excerpt').equalHeights();
        moreBlogsContainer.find('.blog-card-info').equalHeights();
        moreBlogsContainer.find('.blogger-card-info').equalHeights();
      };

      self.resize = function() {
        self.dom.container.find('.blogger-card-info').height('auto');
        self.dom.container.find('.blogger-card-title').height('auto');
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

          // only above 960 viewport or nonresponsive
          if(Modernizr.mq('(min-width: 960px)') || !Modernizr.mq('only all')){
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

        // TODO - Sort the blogs
        //self.sortBy($closest.data('sort-by'));
      };

      //self.sortBy = function(sortBy) {
      //  var $postList = $('.blog-post-list');
      //  $postList.fadeOut(function() {
      //    $postList.fadeIn();
      //  });
      //};

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
      $('.sort-options').on('change', 'select', self.updateSort);
    };

    self.updateSort = function(event) {
      var $target = $(event.target);
      self.sortBy($target.val());
    };

    self.sortBy = function(selectedValue) {
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
      self.dom.modal.on('show.bs.modal', function() {
        $(this).find(':focusable').first().focus();
      });
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
      
      var name = $('#ask')[0].value;

      var encName = encodeURIComponent(name);

      $.get('/modals/community-qa-question-asked?search=' + encName).done(self.renderLightbox);

      //self.showQuestion();
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

      // vertically align modal
      adjustModalMaxHeightAndPosition();

      // only above 320 viewport or nonresponsive
      if( Modernizr.mq('(min-width: 320px)') || !Modernizr.mq('only all')){
        $(window).resize(adjustModalMaxHeightAndPosition).trigger('resize');
      }

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
 * Definition for the whatsHappening what javascript module.
 */
(function ($) {

    $(document).ready(function () {
        new U.whatsHappening();
    });

    U.whatsHappening = function () {
        var self = this;

        self.dom = {};

        self.init = function () {

            self.dom.container = $('.whats-happening-page');
            self.dom.html = $('html');

            if (self.dom.container.length === 0) {
                return;
            }

            self.initializeEventsSlider();
            self.initializeQuestionsSlider();
            self.initializeMembersSlider();

            // this JS if not IE8 (too many carousels causes IE8 to function poorly)
            if (Modernizr.mq('only all')) {
                self.initializeGroupsSlider();
                self.initializeBlogSlider();
                self.attachHandlers();
            }

            self.truncate();
        };

        self.equalizeHeights = function () {
            // only above 320 viewport or nonresponsive
            if (Modernizr.mq('(min-width: 321px)') || !Modernizr.mq('only all')) {
                self.dom.container.find('.event-card-title').equalHeights();
                self.dom.container.find('.event-card-info').equalHeights();

                self.dom.container.find('.question-card-title-and-text').equalHeights();
            }

            //self.dom.container.find('.question-card-info').equalHeights();

            self.dom.container.find('.member-card-name').equalHeights();

            // only above 320 viewport or nonresponsive
            if (Modernizr.mq('(min-width: 321px)') || !Modernizr.mq('only all')) {
                self.dom.container.find('.group-card-name').equalHeights();

                self.dom.container.find('.group-card-info')
                    .not(self.dom.container.find('.community-my-groups .group-card-info'))
                    .equalHeights();
            }

            // only above 480 viewport or nonresponsive
            if (Modernizr.mq('(min-width: 480px)') || !Modernizr.mq('only all')) {
                self.dom.container.find('.community-blogs .blog-card-contents').equalHeights();
            }

            // only above 650 viewport or nonresponsive
            if (Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')) {
                self.dom.container.find('.community-my-blogs .blog-card')
                    .each(function (i, element) {
                        var $element = $(element);
                        $element.find('.rsContent .blog-card-info')
                            .add($element.find('.blog-card-author-info'))
                            .equalHeights();
                    });
            }
        };

        self.resize = function () {
            self.dom.container.find('.event-card-info').height('auto');

            self.dom.container.find('.question-card-title-and-text').height('auto');
            self.dom.container.find('.question-card-info').height('auto');

            self.dom.container.find('.member-card-name').height('auto');

            self.dom.container.find('.group-card-name').height('auto');
            self.dom.container.find('.group-card-info').height('auto');

            self.dom.container.find('.group-card-excerpt')
                .add(self.dom.container.find('.group-card-replies'))
                .height('auto');

            self.dom.container.find('.community-blogs .blog-card-contents').height('auto');
            self.dom.container.find('.community-blogs .blog-card').height('auto');
            self.dom.container
                .find('.blog-card-author-info')
                .add(self.dom.container.find('.rsContent .blog-card-info'))
                .height('auto');

            self.equalizeHeights();
        };

        self.attachHandlers = function () {
            self.dom.container
                .find('.event-cards')
                .on('click', '.action-skip-this', self.skipItem('.event-card', self.eventSkipped));

            self.dom.container
                .find('.group-cards')
                .on('click', '.action-skip-this', self.skipItem('.group-card', self.groupSkipped));

            self.dom.container
                .find('.blog-cards')
                .on('click', '.action-skip-this', self.skipItem('.blog-card', self.blogSkipped));

            self.dom.html.on('equalHeights', self.equalizeHeights);

            var $destination = $('.member-cards');
            $destination.on('click keypress', '.specialty span',
                U.user_profile.showHoverCard($destination, '.card-child-info', '.specialty-final'));
        };

        self.skipItem = function (selector, callback) {
            return function (e) {
                e.preventDefault();

                var $target = $(e.target);

                var $elements = $(selector);
                var $elementToRemove = $target.closest(selector);
                var $nextSlideIndex = $elements.index($elementToRemove) + 1;

                if ($nextSlideIndex >= $elements.length) {
                    $nextSlideIndex -= 2;
                }

                var $nextSlide = $elements.eq($nextSlideIndex);
                var $newFocusElement = $nextSlide.find('a').eq(0);

                var currentIndex = $elements.index($elementToRemove);
                var $currentContainer = $elementToRemove.parent();



                $elementToRemove.fadeOut(function () {
                    $(this).remove();

                    for (var i = currentIndex + 1; i < $elements.length; i++) {
                        var $nextItem = $elements.eq(i);
                        var $newContainer = $nextItem.parent();
                        $currentContainer.append($nextItem);
                        $currentContainer = $newContainer;
                    }

                    $newFocusElement.focus();

                    callback($currentContainer, $elementToRemove);
                });
            };
        };

        self.eventSkipped = function (destination, elementToRemove) {
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

        self.groupSkipped = function (destination, elementToRemove) {
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

        self.blogSkipped = function (destination, elementToRemove) {
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

        self.initializeEventsSlider = function () {
            var container = $('.upcoming-events .event-cards');
            var slideSelector = ".event-card";
            var navigation = $('.upcoming-events .events.next-prev-menu');

            if (container.length === 0) {
                return;
            }

            U.carousels.initializeSlider(container, slideSelector, navigation, 2, 2, 2, self.resize);
        };

        self.initializeQuestionsSlider = function () {
            var container = $('.recent-questions .question-cards');
            var slideSelector = ".question-card";
            var navigation = $('.recent-questions .questions.next-prev-menu');

            if (container.length === 0) {
                return;
            }

            U.carousels.initializeSlider(container, slideSelector, navigation, 2, 2, 1, self.resize);
        };

        self.initializeMembersSlider = function () {
            var container = $('.community-members .member-cards');
            var slideSelector = ".member-card";
            var navigation = $('.community-members .members.next-prev-menu');

            if (container.length === 0) {
                return;
            }

            U.carousels.initializeSlider(container, slideSelector, navigation, 4, 3, 2, self.resize);
        };

        self.initializeGroupsSlider = function () {
            var container = $('.community-groups .group-cards');
            var slideSelector = ".group-card";
            var navigation = $('.community-groups .groups.next-prev-menu');

            if (container.length === 0) {
                return;
            }

            U.carousels.initializeSlider(container, slideSelector, navigation, 2, 2, 2, self.resize);
        };

        self.initializeBlogSlider = function () {
            var container = $('.community-blogs .blog-cards');
            var slideSelector = ".blog-card";
            var navigation = $('.community-blogs .blogs.next-prev-menu');

            if (container.length === 0) {
                return;
            }

            U.carousels.initializeSlider(container, slideSelector, navigation, 2, 2, 1, self.resize);
        };

        self.truncate = function () {
            $('.name-member').ellipsis({
                row: 2,
                char: '…' // &hellip;
            });
            $('.event-card-title').ellipsis({
                row: 4,
                char: '…' // &hellip;
            });
        };

        self.init();
    };

})(jQuery);