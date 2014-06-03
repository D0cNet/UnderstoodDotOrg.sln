(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.user_profile();
    });

    U.user_profile = function () {
        var self = this;

        U.user_profile.showHoverCard = function ($destination, $cardSelector, displayTargetSelector) {
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

                var addCloseEvent = function ($card) {
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
                    $body.on('mousedown.card-close', function (event) {
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
                } else if ((cloneWidth + $displayTarget.offset().left > windowWidth - margin && newLeft < cloneWidth)) {
                    $childInfoClone.addClass('middle');
                    $childInfoClone.css('left', centerLeft);
                    $childInfoClone.css('top', newTop);

                    $caret.css('left', caretLeft - 255);
                } else if (cloneWidth + $displayTarget.offset().left > windowWidth - margin) {
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

                $childInfoClone.on('click', '.rsArrowLeft', function (e) {
                    e.preventDefault();
                    e.stopPropagation();
                    $childInfoClone.hide();
                    cardIndex--;
                    if (cardIndex < 0) {
                        cardIndex = $childInfoClone.length - 1;
                    }
                    var $currentCard = $childInfoClone.eq(cardIndex);
                    $currentCard.show();
                    $currentCard.find(':focusable').first().focus();
                    addCloseEvent($childInfoClone.eq(cardIndex));
                });

                $childInfoClone.on('click', '.rsArrowRight', function (e) {
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

        self.scrollIfOffScreen = function ($target) {
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

            if (requiredScroll > 0) {
                $('html,body').animate({ scrollTop: scrollTop });
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

        self.attachKeyboardHandlers = function ($shownCard, $childInfoClone, $prevFocusable, $nextFocusable) {
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
 * Definition for the account-notification-tabs javascript module.
 */

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.accountNotificationTabs();
    });

    U.accountNotificationTabs = function () {
        var self = this;

        /**
         * Initialize module on page load.
         * @return {object} this instance
         */
        this.initialize = function () {

            //cache selector
            var notificationsSectionDropdownSelect = $('.notifications-section-dropdown select');

            var uniform_elements = [
              '.account-notification-tabs input[type=textfield]',
              '.account-notification-tabs select'
            ].join(',');

            var toggle_switch = $(
              '<div class="switch-wrapper">' +
                '<span class="btn-toggle btn-left"><button>Off</button></span>' +
                '<span class="btn-toggle btn-right"><button>On</button></span>' +
              '</div>'
            );

            // Add toggle switches.
            $('.toggle-wrapper input[type=checkbox]').ezMark();
            $('.toggle-wrapper .ez-checkbox').append(toggle_switch);

            $('.toggle-wrapper .ez-checkbox').find('.btn-toggle').on('click', function (e) {
                e.preventDefault();
                $(this).parent().click();
            });

            // Navigate to new page (or swap content) on change of dropdown
            notificationsSectionDropdownSelect.change(function () {
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
        this.swapSelectCount = function () {
            $('.notifications-section-dropdown .circle').hide();
            var activeOption = '.' + $('.notifications-section-dropdown select').val() + '-count';
            $(activeOption).css('display', 'inline-block');
            return this;
        };

        return this.initialize();
    };

})(jQuery);
/**
 * Definition for the accountMyComments javascript module.
 * Change the cols to be more responsive
 */

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.accountMyComments();

        //perform action on resize, but delay the amount of times this is called while resizing.
        var doTheAction;
        $(window).resize(function () {
            clearTimeout(doTheAction);
            doTheAction = setTimeout(U.accountMyComments, 100);
        });
    });

    U.accountMyComments = function () {
        var self = this;

        //cache containers
        var accountMyCommentsColsFirst = $('.account-mycomments > .mycomment-list > .mycomment-item > div:first-child');
        var accountMyCommentsColsLast = $('.account-mycomments > .mycomment-list > .mycomment-item > div:last-child');

        // only above 960 viewport or nonresponsive
        if (Modernizr.mq('(min-width: 960px)') || !Modernizr.mq('only all')) {
            accountMyCommentsColsFirst.removeClass('col-4').addClass('col-3');
            accountMyCommentsColsLast.removeClass('col-20').addClass('col-21');
        } else {
            accountMyCommentsColsFirst.removeClass('col-3').addClass('col-4');
            accountMyCommentsColsLast.removeClass('col-21').addClass('col-20');
        }

        return this;
    };

})(jQuery);
/**
 * Definition for the AccountMyFavorites javascript module.
 */

(function ($) {
    // Initialize the module on page load.
    $(document).ready(function () {
        new U.AccountMyFavorites();
    });

    U.AccountMyFavorites = function () {

        var container = $('.account-myfavorites .myfavorites-list .tools');

        U.actionButtons(container);

    };

})(jQuery);
/**
 * Definition for the accountMyConnections javascript module.
 */

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.accountMyConnections();
    });

    U.accountMyConnections = function () {
        var self = this;
        var resizeDelay;

        self.init = function () {
            var onCorrectPage = self.initDom();

            if (!onCorrectPage) {
                return;
            }

            self.storeOriginalValues();
            self.truncate();
            self.attachHandlers();
        };

        self.initDom = function () {
            self.dom = {};
            self.dom.$container = $('.my-connections, .my-connections-grid');

            return self.dom.$container.length > 0;
        };

        self.storeOriginalValues = function () {
            self.dom.$container.find('.name-member').each(function (i, element) {
                $(element).data('original-value', $(element).text());
            });
        };

        self.truncate = function () {
            self.dom.$container.find('.name-member').each(function (i, element) {
                $(element).text($(element).data('original-value'));
            });

            self.dom.$container.find('.Moderator, .Expert, .Blogger').find('.name-member').ellipsis({
                row: 2,
                char: '…' // &hellip;
            });

            self.dom.$container.find('.member').find('.name-member').ellipsis({
                row: 1,
                char: '…' // &hellip;
            });
        };

        self.attachHandlers = function () {
            $(window).on('resize', self.resize);

            var $destination = self.dom.$container.find('.member-cards');
            $destination.on('click keypress', '.specialty span',
                U.user_profile.showHoverCard($destination, '.card-child-info', '.specialty-final'));
        };

        self.resize = function () {
            clearTimeout(resizeDelay);
            resizeDelay = setTimeout(function () {
                self.truncate();
            }, 100);
        };

        self.init();

        return this;
    };

})(jQuery);
/**
 * Definition for the accountActivityFeed javascript module.
 */

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.accountActivityFeed();
    });

    U.accountActivityFeed = function () {
        var self = this;

        self.init = function () {
            var onCorrectPage = self.initDom();

            if (!onCorrectPage) {
                return;
            }

            self.attachHandlers();
        };

        self.initDom = function () {
            self.dom = {};
            self.dom.$container = $('.connections-activity-feed');

            return self.dom.$container.length > 0;
        };

        self.attachHandlers = function () {
            var $destination = self.dom.$container;
            $destination.on('click keypress', '.specialty span',
                U.user_profile.showHoverCard($destination, '.card-child-info', '.specialty-final'));
        };

        self.init();

        return this;
    };

})(jQuery);
/**
 * Definition for the accountViewHeader javascript module.
 */

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.accountViewHeader();
    });

    U.accountViewHeader = function () {
        var self = this;

        /**
         * Initialize module on page load.
         * @return {object} this instance
         */
        this.initialize = function () {
            self.dom = {};
            self.dom.$container = $('.account-view-header');

            self.attachHandlers();

            return this;
        };

        self.attachHandlers = function () {
            var $destination = self.dom.$container.find('.account-info');
            $destination.on('click keypress', '.specialty span',
                U.user_profile.showHoverCard($destination, '.card-child-info', '.specialty-final'));
        };

        return this.initialize();
    };

})(jQuery);
/**
 * Definition for the friendsViewTabs javascript tabs module.
 */

(function ($) {

    $(document).ready(function () {

        // Navigate to new page (or swap content) on change of dropdown
        $('.friends-view-tabs .etabs-dropdown select').change(function () {
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

(function ($) {

    $(document).ready(function () {

        // Navigate to new page (or swap content) on change of dropdown
        $('#my-events-tabs .etabs-dropdown select').change(function () {
            // INTEGRATION: navigate to the HREF, or do something else
            var className = '.' + $(this).val() + '-tab a';
            console.log($('.etabs ' + className).attr('href'));
        });

    });

    $('.etabs-dropdown select').uniform();

})(jQuery);
/**
 * Definition for the signUpTerms javascript module.
 */

(function ($) {
    // Initialize the module on page load.
    $(document).ready(function () {
        new U.signUpTerms();
        $('.answer-agree').attr('disabled', 'true');
    });

    U.signUpTerms = function () {
        var self = this;

        jQuery('.terms-content').scroll(function () {
            if ($(this).scrollTop() + $(this).innerHeight() + 2 >= $(this)[0].scrollHeight) {
                $('.answer-agree').removeAttr('disabled');
            }
        });
    };
})(jQuery);
/**
 * Definition for the MyConnections javascript module.
 */


(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.MyConnections();
    });

    U.MyConnections = function () {

        var self = this;

        self.init = function () {
            //add hyphen to user names when name is too big for the container and breaks in the middle.
            self.addHyphen();
        };

        self.addHyphen = function () {

            self.$userName = $('.connections .user .user-name');
            self.lineHeight = parseInt(self.$userName.css('line-height'));

            // Check the height of each container and if it is too big then the name has wrapped
            self.$userName.each(function () {
                var height = $(this).height();
                if (height > self.lineHeight) {
                    $(this).addClass('hyphen-line1');
                }
                if (height > (self.lineHeight * 2)) {
                    $(this).addClass('hyphen-line2');
                }
            });
        };

        self.init();
    };
})(jQuery);
/**
 * Definition for the profile-questions javascript module.
 */

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.profileQuestions();
    });

    U.profileQuestions = function () {
        var self = this;

        // Maximum amount of children the user can add.
        this.MAX_CHILDREN = 4;

        // Current number of children added.
        this.childCount = 1;

        // Converts integers to an adjective.
        this.numberAdjectives = ['', 'second', 'third', 'fourth'];

        // Original child question, before cloning.
        this.$childQuestion = null;

        this.$html = $('html');

        /**
         * Initialize module on page load.
         * @return {object} this instance
         */
        this.initialize = function () {
            var uniform_elements = [
              '.profile-questions input[type=checkbox]:not(.no-uniform)',
              '.profile-questions input[type=textfield]',
              '.profile-questions input[type=radio]'
            ].join(',');
            $(uniform_elements).uniform();

            this.$html.on('equalHeights', this.resizeQuestions);

            // Clone child question on button click.
            var $questionWrapper = $('.profile-questions-child-wrapper');
            if ($questionWrapper.length) {
                $.uniform.restore($($questionWrapper).find('select'));
                this.$childQuestion = $questionWrapper.html();
                $($questionWrapper).find('select').uniform({ selectAutoWidth: false });
                $('.add-more-children').click(this.showNextKid);
            }

            // For all toggle buttons.
            $('.profile-questions').on('click', '.button', function (e) {
                //e.preventDefault();

                $(this).parent().children('.checked').removeClass('checked');
                $(this).addClass('checked');
            });

            // For PP2b "difficulties" info hovers.
            $('.difficulties-question .checkbox-wrapper').hover(function () {
                if ($(window).width() >= U.Global.Breakpoints.MEDIUM) {
                    $(this).find('.info-link').show();
                }
            }, function () {
                if ($(window).width() >= U.Global.Breakpoints.MEDIUM && !$(this).find('.popover').length) {
                    $(this).find('.info-link').hide();
                }
            });

            $('.radiobuttonJourney').on('click', function () {
                $('.radiobuttonJourney').each(function (index) {
                    $(this).find('span').removeClass('checked');
                    $(this).find('input').prop('checked', false);
                });
                $(this).find('span').addClass('checked');
                $(this).find('input').prop('checked', true);
            });

            $('.role-question .button').each(function (index) {
                if ($(this).find("input").attr('checked') == "checked")
                    $(this).addClass("checked");
            });

            // For PP3 "what is your role?" question.
            $('.role-question select').on('change', function () {
                $('.role-question .checked').removeClass('checked');
                $('.role-question input:checked').prop('checked', false);
                return false;
            });
            $('.role-question .button').on('click', function (e) {
                $('.role-question .selected').find("input").trigger('click');
                $('.role-question .selected').removeClass('selected');
                $('.role-question option:selected').prop('selected', false);
                $(this).find("input").trigger('click');
            });

            $(window).resize(function () {
                self.resizeQuestions();
            });


            this.setUpTooltipAccess();

            // Make sure the info link popover containers are hidden properly
            this.hideInfoLinkPopovers();

            return this.resizeQuestions();
        };

        /**
         * TODO: If we do not have all js files compacted into one, this will need to be moved into a global script
         * Adds keyboard accessability to the tooltips. Lets the user tab through/back through the
         * top tips - even if there are links in them
         */
        this.setUpTooltipAccess = function () {

            new U.keyboard_access({
                focusElements: '.checkbox-wrapper.toolTipPresent label',
                blurElements: '.checkbox-wrapper.toolTipPresent label',
                focusHandler: function (e) {
                    var $current = $(e.currentTarget);
                    $('.info-link').removeClass('selected');
                    $current.children('.info-link').addClass('selected');
                }
            });

            new U.keyboard_access({
                focusElements: '.popover-link',
                blurElements: '.popover-link, .popover-link + .popover .popover-content a',
                focusHandler: function (e) {
                    $(e.currentTarget).removeClass('active');
                },
                blurHandler: function (e, newTarget) {
                    var $current = $(e.currentTarget),
                      popover = newTarget.parent('.popover-content'); //if exists, then it's inside a popover
                    if (popover.length === 0) {
                        var $popOverElement = $current.parents('.popover'); //will exist if inside the tooltip
                        if ($popOverElement.length === 0) {
                            $popOverElement = $current.find('.popover'); //in a popover-link
                            if ($popOverElement.length === 0) { //Not in a label
                                $popOverElement = $current.siblings('.popover');
                            }
                            $current.removeClass('active');
                        } else {
                            $popOverElement.siblings('.popover-link').removeClass('active');
                        }
                        $popOverElement.hide();
                    }
                }
            });
        };

        /**
         * Add equal heights to columns on resize event.
         * @return {object} this instance
         */
        this.resizeQuestions = function () {
            $('.column-wrapper').each(function () {
                // only above 768 viewport or nonresponsive
                if (Modernizr.mq('(min-width: 769px)') || !Modernizr.mq('only all')) {
                    $(this).find('.question-wrapper').css('height', 'auto').equalHeights();
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
        this.copyChildForm = function () {
            var clone = $(self.$childQuestion);
            $('.profile-questions-child-wrapper').append(clone);

            // Increment count and adjust wording on question.
            self.childCount++;
            $('.child-count-question span').html(self.numberAdjectives[self.childCount]);

            if (self.childCount == self.MAX_CHILDREN) {
                $('.child-count-question').hide();
            }

            // Fixes 'selected' class never added to selects after clone.
            clone.find('select').uniform({ selectAutoWidth: false }).change(function () {
                $(this).parent().addClass('selected');
            });

            return false;
        };
        var kidCount = 1;
        this.showNextKid = function () {
            $(".profile-questions-child-wrapper").eq(kidCount).removeClass("hidden");
            kidCount++;
            // Increment count and adjust wording on question.
            self.childCount++;
            $('.child-count-question span').html(self.numberAdjectives[self.childCount]);
            return false;
        }
        /**
         * Hide .info-link popover containers when
         */
        this.hideInfoLinkPopovers = function () {
            if ($(window).width() >= U.Global.Breakpoints.MEDIUM) {
                // Hide info links when not clicking on popover or popover links
                $(window).bind("click touchstart", function () {
                    /*if (!jQuery(".popover:hover").length && !jQuery(".popover-link:hover").length) {
                      $('.info-link').hide();
                    }*/
                });
                // Hide other info links when clicking an info link
                $('.info-link').click(function () {
                    popoverSelf = this;
                    $('.difficulties-question .checkbox-wrapper').find('.info-link').each(function () {
                        if (this != popoverSelf) {
                            $(this).hide();
                        }
                    });
                });
            }
        };

        return this.initialize();
    };

})(jQuery);
/**
 * Definition for the profile-questions javascript module.
 */

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.registrationProfile();
    });

    U.registrationProfile = function () {
        var self = this;

        /**
         * Initialize module on page load.
         * @return {object} this instance
         */
        this.initialize = function () {
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
 * Definition for the connections list
 */

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.connectionsList();

        // var doTheAction;
        // $(window).resize(function() {
        //   clearTimeout(doTheAction);
        //   doTheAction = setTimeout(U.connectionsList, 1000);
        // });

    });

    U.connectionsList = function () {
        var self = this;

        /**
         * Use snippet to resize my connections boxes
         * The intention here is so that the circular buttons line up on a row by row basis
         * Used on m17, M23, M6 layouts
         */

        var currentTallest = 0,
              currentRowStart = 0,
              rowDivs = [],
              $el,
              topPosition = 0;

        $('#user_equal_heights .user-equal-height').each(function () {
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


(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.facebook();
    });

    U.facebook = function () {
        var self = this;

        $(".fb-sign-in").click(
            function () {
                FB.getLoginStatus(function (response) {
                    if (typeof response !== "undefined") {
                        if (response.status == "connected") {
                            U.handleResponse(response);
                        } else {
                            FB.login(
                                function (response) {
                                    if (typeof response !== "undefined") {
                                        U.handleResponse(reponse);
                                    }
                                },
                                { scope: 'email' });
                        }
                    }
                });
            });
    };

    U.handleResponse = function (response) {
        if (response.status == "connected") {
            // user logged into FB and has authorized app
            U.addSessionToken(response.authResponse.accessToken)
        }
    };

    U.addSessionToken = function (accessToken) {
        console.log(accessToken)

        var form = document.createElement("form");
        form.setAttribute("method", 'post');
        form.setAttribute("action", '/handlers/facebooklogin.ashx');

        var token = document.createElement("input");
        token.setAttribute("type", "hidden");
        token.setAttribute("name", 'accessToken');
        token.setAttribute("value", accessToken);
        form.appendChild(token);

        document.body.appendChild(form);
        form.submit();
    };
})(jQuery);

window.fbAsyncInit = function () {
    FB.init({
        //appId: '284669011701311', // App ID
        appId: fbAppId, // App ID
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML
    });

    //FB.login(function (response) {
    //    if (response.authResponse) {
    //        // user sucessfully logged in
    //        var accessToken = response.authResponse.accessToken;
    //    }
    //}, { scope: 'email' });

    // Additional initialization code here
    //FB.Event.subscribe('auth.authResponseChange', function (response) {
    //    if (response.status === 'connected') {
    //        // the user is logged in and has authenticated your
    //        // app, and response.authResponse supplies
    //        // the user's ID, a valid access token, a signed
    //        // request, and the time the access token 
    //        // and signed request each expire
    //        var uid = response.authResponse.userID;
    //        var accessToken = response.authResponse.accessToken;

    //        console.log("uid: " + uid);
    //        console.log("token: " + accessToken);

    //        // TODO: Handle the access token
    //        var token = $("#fbtoken").val();
    //        console.log("aspnet session token: " + token);
    //        // Do a post to the server to finish the logon
    //        // This is a form post since we don't want to use AJAX
    //        if (token === "") {
    //            var form = document.createElement("form");
    //            form.setAttribute("method", 'post');
    //            //form.setAttribute("action", '/fb1.aspx');
    //            form.setAttribute("action", '/handlers/facebooklogin.ashx');

    //            var field = document.createElement("input");
    //            field.setAttribute("type", "hidden");
    //            field.setAttribute("name", 'accessToken');
    //            field.setAttribute("value", accessToken);
    //            form.appendChild(field);

    //            document.body.appendChild(form);
    //            form.submit();
    //        }

    //    } else if (response.status === 'not_authorized') {
    //        // the user is logged in to Facebook, 
    //        // but has not authenticated your app
    //    } else {
    //        // the user isn't logged in to Facebook.
    //    }
    //}, { scope: 'email' });
};

// Load the FB SDK Asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));




