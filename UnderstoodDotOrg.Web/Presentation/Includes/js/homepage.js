/**
 * Definition for the toolkit javascript module.
 */

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
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
    U.toolkit = function () {
        var self = this;

        self.init = function () {

            self.$container = $('#toolkit-slides-container');
            self.$org = self.$container.clone();
            self.isbig = false;

            self.checker();
            $(window).on('resize', self.checker);

        };

        self.initslide = function () {

            self.$rs = self.$container.royalSlider({
                keyboardNavEnabled: false,  // enable keyboard arrows nav
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

            U.carousels.keyboardAccess(self.$container);
        };

        self.destroySlide = function () {

            // remove the rs from the dom
            self.$rs.remove();

            // append the original
            self.$org.appendTo('.tools-container');

            // cache the original again
            self.$container = $('#toolkit-slides-container');

            // clone it
            self.$org = self.$container.clone();

        };

        self.checker = function () {
            // only above 650 viewport or nonresponsive
            if (Modernizr.mq('(min-width: 650px)') && self.isbig === false || !Modernizr.mq('only all')) {
                self.initslide();
                self.isbig = true;
            } else if (Modernizr.mq('(max-width: 649px)') && self.isbig === true) {
                self.destroySlide();
                self.isbig = false;
            }

        };

        self.init();
    };

})(jQuery);
/**
 * Definition for the guideMeOverlay javascript module.
 */

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.guideMeOverlay();
    });

    U.guideMeOverlay = function () {

        var self = this;

        self.init = function () {
            // Start Hero Carousel
            heroCarouselInit();

            // Make vars
            self.$buttonGuideMe = $('.button-guide-me');
            self.$guideMeOverlay = $('.container-guide-me-overlay');
            self.$parentToolkit = $('.parent-toolkit');
            self.$guideMeClose = $('.close-guide');
            self.$guideMeInner = $('.guide-me-inner');
            self.$guideMe = $('.guide-me');
            self.$heroCarousel = $('.hero-carousel');
            self.$slider = $('#hero-carousel-wrapper').data('royalSlider');
            self.$gradeSelect = $('.container-guide-me-overlay .select-grade').find('.grade');
            self.$gradeField = $('#guideme-grade-desktop');
            self.$mobileSelect = $('.container-guide-me-overlay fieldset select');

            if (!self.$buttonGuideMe.length) { return false; }

            // style checkboxes / mobile select
            $('.container-guide-me-overlay fieldset input, .container-guide-me-overlay fieldset select').uniform();

            // make select boxes go 100%
            self.$mobileSelect.siblings('span').css('width', '100%').parent('.selector').css('width', '100%');

            // make select boxes turn purple, or the selected state on valid selection
            self.$mobileSelect.on('change keyup', function () {
                $(this).find('option:selected').each(function () {
                    // if selection is empty, it is not valid
                    if ($(this).val() === "") {
                        $(this).parents('.selector').removeClass('selected');
                    }
                    else {
                        $(this).parents('.selector').addClass('selected');

                    }
                });
            });

            function heroCarouselInit() {
                var carousel = new U.heroCarouselModule();
                carousel.init();
            }

            // TO DO: Reattach the detached on resize
            // use a form <select> for mobile grade selector, and use custom form elements for desktop, with hidden field
            // on mobile, detach the hidden field
            // on desktop, detach the select field
            // restore the hidden fields or select in respective viewport size

            function whichSelect() {
                // only above 650 viewport or nonresponsive
                if (Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')) {
                    self.$mobileSelectDetached = $('.guideme-grade-mobile').detach();
                } else {
                    self.$desktopSelectDetached = $('#guideme-grade-desktop').detach();
                }
            }

            // Open overlay function
            self.openOverlay = function () {

                // Guide Me container height
                self.$guideMeHeight = self.$guideMe.height();
                // Hero Carousel height
                self.$heroCarouselHeight = self.$heroCarousel.height();
                // Guide Me Overlay height
                self.$guideMeOverlayHeight = self.$guideMeOverlay.height();
                // Used during overlay transition
                self.$parentToolKitMarginTop = self.$guideMeOverlayHeight - self.$heroCarouselHeight - self.$guideMeHeight;

                if (self.$guideMeOverlay.css('display') == 'none') { //if overlay is not visible
                    self.$guideMe.height(self.$guideMeHeight);
                    self.$guideMeOverlay.fadeIn();
                    self.$parentToolkit.css('margin-top', self.$parentToolKitMarginTop);
                    self.$guideMeInner.fadeOut();
                    self.$slider.stopAutoPlay(); //stop slider
                }
                whichSelect();

                // scroll to top of overlay when opened
                $('html,body').animate({ scrollTop: $(self.$guideMeOverlay).offset().top }, 500);

                self.$guideMeOverlay.find(':focusable:first').focus();

            };

            // Close overlay function
            self.closeOverlay = function (e) {
                /* 
                *  Detect if the event is a resize and the device supports touch
                *  This is needed because on android when the select box is opened if fires
                *  multiple resize events which in turnclose the module
                */
                if (e.type == 'resize' && Modernizr.touch) {
                    return false;
                }

                self.$guideMe.height('auto');
                self.$guideMeOverlay.fadeOut();
                self.$parentToolkit.css('margin-top', '0px');
                self.$guideMeInner.fadeIn();
                self.$slider.startAutoPlay(); //start slider
            };

            // Trigger overlay open
            self.$buttonGuideMe.on('click', function (e) {
                e.preventDefault();
                self.openOverlay();
            });

            // Trigger overlay close
            self.$guideMeClose.on('click', function (e) {
                e.preventDefault();
                self.closeOverlay(e);
            });

            // Grades - Add to Hidden Form Field
            self.$gradeSelect.on('click', function (e) {
                e.preventDefault();
                var $this = $(this);

                // give selected grade active class and remove active from siblings
                if (!$(this).hasClass('active')) {
                    $(this).addClass('active').siblings('.grade').removeClass('active');
                    // give hidden field the value from the grade ID
                    self.$gradeField.val($(this).attr('id'));
                }
                else {
                    $(this).removeClass('active');
                    // clear hidden field value from the grade ID
                    self.$gradeField.val('');
                }
            });

            // resize event if supporting media queries
            if (Modernizr.mq('only all')) {
                $(window).on('resize.guideMeOverlay', self.closeOverlay);
            }

            document.body.focus();

        };

        self.init();

    };

})(jQuery);
/**
 * Definition for the homepage hero carousel
 */

(function ($) {
    U.heroCarouselModule = function () {
        var self = this;

        self.cacheSelectors = function () {
            self.dom = {};
            self.dom.wrapper = $("#hero-carousel-wrapper");
            self.dom.hfRandomizeSlider = $("#hfRandomizeSlider").val();
            self.dom.parent = self.dom.wrapper.parent();
            self.dom.pagers = self.dom.parent.find('.carousel-pagers');
            self.dom.pagerButtons = self.dom.pagers.find('.rsArrowIcn');
            self.dom.playPause = self.dom.parent.find('.play-pause');
            self.dom.navigation = self.dom.parent.find('.carousel-navigation');
            self.dom.forceCarouselFocus = self.dom.parent.find('.carousel-keyboard-trigger');
            self.dom.toolkitButton = $('#toolkit').find('button').eq(0);
        };

        self.init = function () {

            self.cacheSelectors();
            self.startCarousel();
        };

        self.startCarousel = function () {

            if (!self.dom.wrapper.length) {
                return;
            }

            self.dom.wrapper.royalSlider({
                keyboardNavEnabled: false,  // enable keyboard arrows nav
                loop: true,
                arrowsNav: false,
                randomizeSlides: self.dom.hfRandomizeSlider == "true" ? true : false, // FIXME: needs to be exposed in-page for integration
                controlNavigation: false,
                autoPlay: {
                    delay: 6000,
                    enabled: true,
                    pauseOnHover: true
                },
                slidesSpacing: 0,
                sliderDrag: false
            });

            self.slider = self.dom.wrapper.data('royalSlider');

            U.carousels.attachArrowHandlers(self.dom.pagers, self.slider);
            self.renderNavigation();
            self.attachNavigationHandlers();
            self.attachKeyboardHandlers();
            self.attachHoverEvents();
            self.attachHandlers();
        };

        self.renderNavigation = function () {
            var slides = [];

            for (var i = 0; i < self.slider.slides.length; i++) {
                var slideNum = i + 1;

                slides.push('<li><button class="navigation-link" data-slide-index="' + i + '">Slide ' + slideNum + '</button></li>');
            }

            self.dom.navigation.html(slides.join(''));
            self.dom.navigationItems = self.dom.navigation.find('button');
            self.dom.navigationItems.eq(0).addClass('selected');
        };

        self.attachKeyboardHandlers = function () {
            var controls = self.dom.navigationItems.add(self.dom.pagerButtons),
                lastBullet = self.dom.navigationItems.eq(self.dom.navigationItems.length - 1),
                forceFocus = self.dom.forceCarouselFocus.add(lastBullet);

            new U.keyboard_access({
                focusElements: forceFocus,
                blurElements: controls,
                focusHandler: function (e) {
                    var isFocused = self.dom.pagers.hasClass('active'),
                        newFocus = $(e.currentTarget);

                    if (newFocus.is(lastBullet)) {
                        return;
                    }
                    else if (isFocused) {
                        self.dom.pagers.removeClass('active');
                        self.dom.toolkitButton.trigger('focus');
                    } else {
                        self.dom.pagers.addClass('active');
                        self.dom.pagerButtons.eq(0).trigger('focus');
                    }
                },
                blurHandler: function (e, newTarget) {
                    var newFocus = $(document.activeElement);

                    if (!newFocus.is(controls)) {
                        self.dom.pagers.removeClass('active');
                    }

                    if (newFocus.is(self.dom.forceCarouselFocus)) {
                        self.dom.toolkitButton.trigger('focus');
                    }
                }
            });

            self.arrowControls();
        };

        /* As controls for hero carousel are separate from carousel wrapper */
        /* Adding separate handlers for this instance */
        self.arrowControls = function () {
            var keyActions = {
                37: 'prev',
                39: 'next'
            };

            self.dom.wrapper.parents('.hero-carousel-inner').on('keyup', function (e) {
                var action = keyActions[e.keyCode];

                if (typeof (action) !== 'undefined') {
                    self.slider[action]();
                }
            });
        };

        self.attachNavigationHandlers = function () {
            self.dom.navigationItems = self.dom.navigation.find('.navigation-link');

            self.dom.navigationItems.on('click', function (e) {
                e.preventDefault();

                var index = $(this).data('slideIndex');

                self.slider.goTo(index);
            });

            self.slider.ev.on('rsAfterSlideChange', function (e) {
                self.dom.navigationItems.removeClass('selected');
                self.dom.navigationItems.eq(self.slider.currSlideId).addClass('selected');
            });
        };

        self.attachHoverEvents = function () {
            self.dom.parent.hover(function () {
                self.dom.pagers.addClass('active');
            }, function () {
                self.dom.pagers.removeClass('active');
            });
        };

        self.attachHandlers = function () {
            self.dom.playPause.on('click', self.playPause);
        };

        self.playPause = function (e) {
            e.preventDefault();

            var iconState = self.dom.playPause.hasClass('pause') ? 'play' : 'pause';

            self.dom.playPause.removeClass('play pause').addClass(iconState);

            if (iconState == 'pause') {
                self.slider.startAutoPlay();
            } else {
                self.slider.stopAutoPlay();
            }
        };
    };

})(jQuery);



