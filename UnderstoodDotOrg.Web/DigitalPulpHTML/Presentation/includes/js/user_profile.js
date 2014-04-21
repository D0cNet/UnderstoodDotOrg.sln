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
