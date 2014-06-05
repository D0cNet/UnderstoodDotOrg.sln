var U = {};


U.drawerMenu = function(){

  var self = this;

  self.init = function(){

    self.$hdr_page = $('#header-page');
    self.$wrapper = $('#wrapper');

    //Check status of viewport & drawermenu, now and following resize
    // FIXME Candidate for inclusion in future unified resize event framework
    self.headerStatus();
    var resizeDelay;
    $(window).bind('resize', function() {
      clearTimeout(resizeDelay);
      resizeDelay = setTimeout(function() {
        self.headerStatus();
      }, 100);
    });

  };

  // Detect breakpoint by checking visibility of #header-page .nav-main, This is only visible on desktop
  // Check if JS-inserted menu button is present
  //  * if not desktop & menu button is not present - build drawermenu & insert menu button
  //  * if not desktop & menu button is present - do nothing
  //  * if desktop & menu button is present - remove drawermenu & menu button
  //  * if desktop & menu button is not present - do nothing
  self.headerStatus = function() {
    var viewport_small = self.$hdr_page.find('nav.nav-main').is(':hidden') ? true : false;
    var menu_present = $('#button-drawermenu').length ? true : false;
    if (viewport_small && !menu_present) {
      self.build();
    }
    else if (!viewport_small && menu_present) {
      self.destroy();
    }
  };

  self.build = function() {

    //insert menu button
    self.$drawer_but = $('<div id="button-drawermenu">Menu</div>').on('click', function() {
      if (!self.$drawer_but.hasClass('is-active')) {
        self.open();
      }
    }); // TODO needs aria
    self.$drawer_but.prependTo(self.$hdr_page);

    // drawermenu element
    self.$drawer_menu = $('<div id="drawermenu" />'); // TODO needs aria
    self.$drawer_menu_content = $('<div class="content" />');
    self.$drawer_menu_content.appendTo(self.$drawer_menu);

    // clone & append logo to drawermenu
    var $logo = self.$hdr_page.find('div.logo-u-main').clone();
    $logo.appendTo(self.$drawer_menu_content);

    // clone & append language selector to drawermenu
    var $lang_select = self.$hdr_page.find('ul.language-selection').clone();
    $lang_select.appendTo(self.$drawer_menu_content);

    // clone main nav
    self.$main_nav = self.$hdr_page.find('nav.nav-main').clone();
    // modify main nav
    self.menuModify();
    // append main nav to drawermenu
    self.$main_nav.appendTo(self.$drawer_menu_content);

    // clone & append utility nav to drawermenu
    var $nav_util = self.$hdr_page.find('nav.nav-utility').clone();
    $nav_util.appendTo(self.$drawer_menu_content);

    // insert drawer menu
    self.$wrapper.before(self.$drawer_menu);

    // cache selectors of elements created/modified in self.menuModify
    self.$main_nav_slider = self.$main_nav.find('div.slider');
    self.$main_nav_menus = self.$main_nav_slider.find('ul.level-2');

    // reveal current section menu
    var current = self.$main_nav_menus.find('li.is-current');
    if (current.length) {
      self.childListShow(current.eq(0).parent('ul').data('menu-item'));
    }

    // swipe to close - requires jQuery mobile
    if ($.isFunction($.fn.swipeleft)) {
      self.$drawer_menu.swipeleft(function() {
        self.close();
        self.$wrapper.unbind('click.drawermenu');
      });
    }
  };

  // Modify main nav for use in drawermenu
  self.menuModify = function() {
    // top level UL
    self.$topLevel = self.$main_nav.find('> ul');
    // top level LIs
    var $topLevelItems = self.$topLevel.find('> li');

    $topLevelItems.each(function(i) {
      $this_item = $(this);

      // insert button (right arrow), used to reveal child (2nd level) menu
      // nested ULs (2nd level menus) will be detached and will no longer be children of top level LIs
      // attach data to button, value to match data attribute that will be added to 2nd level menu to associate button to menu
      var $but_more = $('<div class="button-more" />').data('menu-item', i).on('click', function() {
        self.childListShow($(this).data('menu-item'));
      });
      $this_item.find('> span').append($but_more);

      // 2nd level menu
      var $this_menu = $this_item.find('ul');

      // create new list item
      // This will be added as the 1st item on 2nd level menu, containing text of parent (top level) LI ($this_item)
      var $new_item = $('<li class="title" />');

      // add 'back' icon (left arrow) to it
      $('<i class="icon-back" />').on('click', function() {
        self.childListHide();
      }).appendTo($new_item);
      // add text
      $new_item.append('<span>' + $this_item.find('> span a').text() + '</span>');

      // if $this_item is the current section
      // and none of it's child items are the current topic
      // then this new 'title' item should be highlighted with the 'you are here' flag
      if ($this_item.hasClass('is-current') && !($this_item.find('li.current-topic').length)) {
        $new_item.addClass('is-current');
      }
      // insert into 2nd level menu
      $this_menu.prepend($new_item);

      // Add class names to 2nd level menu and append to 'nav' element
      // 2nd level menu is now sibling of top level menu
      $this_menu.addClass('level-2').attr('data-menu-item', i).appendTo(self.$main_nav);
    });

    // insert new 'menu title' LI in 1st position in top level menu
    self.$topLevel.prepend('<li class="title"><span>Menu</span></li>');

    // wrap all ULs (menus) in new div that is necessary for sliding animation
    self.$main_nav.wrapInner('<div class="slider" />');
  };

  // slide 2nd level menu into view
  // activated by right arrow button on top level menu
  // ref = right arrow button (.button-more) data store
  self.childListShow = function(ref) {
    // find menu whose data attribute matches button's data store and show it
    self.$main_nav.find('ul[data-menu-item="' + ref + '"]').show();
    // move it into view
    self.$main_nav_slider.animate({
      right: '100%'
    }, 'fast');
  };

  // slide 2nd level menu out of view
  // activated by 1st item on 2nd level menu (has 'back' arrow)
  self.childListHide = function() {
    self.$main_nav_slider.animate({
        right: '0'
      }, 'fast', function() {
        // hide all 2nd level menus
        self.$main_nav_menus.hide();
    });
  };

  // drawermemu open
  self.open = function() {
    self.$drawer_but.addClass('is-active');
    // Get width of #wrapper (100% of viewport) and set it in inline style to prevent it collapsing when moving out of view
    self.$wrapper.css('width', self.$wrapper.outerWidth());
    self.$drawer_menu.addClass('is-wide');
    self.$wrapper.animate({
        left: '84.4%'
      }, 'fast', function() {
        self.$drawer_menu.addClass('is-open');
        // close by clicking outside of drawermenu
        self.$wrapper.one('click.drawermenu', function() {
          self.close();
        });
      }
    );
      // apply position fixed tp #wrapper to prevent it scrolling
    self.$wrapper.addClass('is-offscreen');
    // push logo to the right so it's not butted up against the close menu button
    self.$hdr_page.find('.logo-u-main').css('margin-left', '12px');
  };

  // drawermemu open
  self.close = function() {
    // Reset #wrapper styles applied when opening
    self.$wrapper.removeClass('is-offscreen').css({'width': 'auto'});
    self.$drawer_but.removeClass('is-active');
    self.$wrapper.animate({
      left: '0'
    }, 'fast', function() {
      self.$drawer_menu.scrollTop(0).removeClass('is-wide');
    });
    self.$drawer_menu.removeClass('is-open');
    // pull logo back flush left
    self.$hdr_page.find('.logo-u-main').css('margin-left', '0px');
  };

  // Remove drawermenu & menu button
  // Reset #wrapper styles added in self.move
  self.destroy = function() {
    $('#button-drawermenu').remove();
    self.$drawer_menu.remove();
    self.$wrapper.removeClass('is-offscreen').css({
      'width': 'auto',
      'left': 'auto'
    });
    self.$wrapper.unbind('click.drawermenu');
  };

  self.init();

};


U.hoverDropdown = function(options){

  var self = this;

  defaults = {
    container : '',
    hclass : 'is-active',
    el : '> li'
  };
  options = $.extend(defaults, options);

  self.init = function(){

    if ($.fn.hoverIntent) {

      var config = {
        over: self.show,
        out: self.hide,
        interval: 50,
        sensitivity: 7,
        timeout: 150
      };

      $(options.container).find(options.el).hoverIntent(config);

    } else {

      $(options.container).find(options.el).hover(self.show, self.hide);

    }

  };

  self.show = function() {
    if (!($('#toolkit').hasClass('is-open')) ) {
      $(this).addClass(options.hclass)
      .siblings().removeClass(options.hclass);
    }
  };

  self.hide = function() {
    $(this).removeClass(options.hclass);
  };

  if (options.container !== '') {
    self.init();
  }

};


/* This module is responsible for keyboard navigation for the main menu dropdowns */
U.focusDropdown = function() {
    var menuItems = $('#header-page .menu-list-item'),
        topLevelLinks = $('#header-page .top-level-link'),
        dropdownLinks = menuItems.find('a');

    new U.keyboard_access({
        focusElements: topLevelLinks,
        blurElements: dropdownLinks,
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
            var itemInNavigation = newTarget.parents().is('.menu-list-item');

            if (!itemInNavigation) {
                menuItems.removeClass('is-active');
            }
        }
    });
};

U.searchSite = function(){

  var self = this;

  self.init = function(){

    self.$hdr_page = $('#header-page');
    self.$search_site = $('#search-site');
    self.$logo =  self.$hdr_page.find('.logo-u-main img');
    self.input_text = self.$search_site.find('input[placeholder]');
    self.input_submit = self.$search_site.find('input[type="submit"]');
    self.viewport_size = null;
    self.placeholder_text_default = 'Enter Search Term';
    self.placeholder_text_large = 'Search';
    self.submit_value_default = 'Go';
    self.submit_value_medium = 'Submit';

    self.detectBreakpoint();
    // FIXME Candidate for inclusion in future unified resize event framework
    var resizeDelay;
    $(window).bind('resize', function() {
      clearTimeout(resizeDelay);
      resizeDelay = setTimeout(function() {
        self.detectBreakpoint();
      }, 100);
    });

    self.$search_site.find('legend').on('click', function() {
      self.searchDisplay();
    });

    self.input_text.on('focus', function() {
      self.$search_site.addClass('is-focused');
    });

    self.input_text.on('blur', function() {
      self.$search_site.removeClass('is-focused');
    });

  };

  self.detectBreakpoint = function() {

    // mobile
    if (Modernizr.mq('(max-width: 649px)') && self.viewport_size !== 'small') {
      // switch out submit value
      self.input_submit.val(self.submit_value_default);

      // viewport has been reiszed from desktop size
      if (self.viewport_size == 'large') {
        // switch out placeholder text
        self.input_text.attr('placeholder', self.placeholder_text_default);
      }

      self.viewport_size = "small";
    }

    // tablet
    else if (Modernizr.mq('(min-width: 650px)') && Modernizr.mq('(max-width: 768px)') && self.viewport_size !== 'medium') {
      // switch out submit value
      self.input_submit.val(self.submit_value_medium);

      // viewport has been reiszed from desktop size
      if (self.viewport_size == 'large') {
        // switch out placeholder text
        self.input_text.attr('placeholder', self.placeholder_text_default);

      }
      self.viewport_size = "medium";
    }

    // desktop and nonresponsive
    else if (Modernizr.mq('(min-width: 769px)') && self.viewport_size !== 'large' || !Modernizr.mq('only all')){
      // switch out placeholder text
      self.input_text.attr('placeholder', self.placeholder_text_large);

      // remove class used to display search dropdown
      self.$hdr_page.removeClass('is-search-active');

      self.viewport_size = "large";
    }
  };

  self.searchDisplay = function() {
    self.$hdr_page.toggleClass('is-search-active');
  };

  self.init();

};

U.languageSelector = function(){

  var self = this;

  self.$lang_select = $('#language-selector-bar');

  self.init = function(){

    self.$lang_select.show();
    $('body').addClass('language-selector-visible');


    self.$lang_select.find('.button').on('click', function() {
       self.close();
    });

    self.$lang_select.find('.button-close').on('click', function() {
      self.close();
    });

  };

  self.close = function() {
    self.$lang_select.remove();
    $('body').removeClass('language-selector-visible');
  };

  if (self.$lang_select.length) {
    self.init();
  }

};

U.popovers = function () {

  var self = this;
  self.$pop_links = $('.popover-link');

  self.init = function () {

    // Initial Setup of all Popovers
    self.create();

    // Track the click of the link
    self.$pop_links.on('click', function (e) {
      e.preventDefault();
      if (!$(this).hasClass('active')) {
        $('.popover-link').popover('hide').removeClass('active');
        var parent = this;
        setTimeout(function () {
          $(parent).popover('show').addClass('active');
        }, 150);
      }else{
        $(this).popover('hide').removeClass('active');
      }
    });

    // Track window clicks outside the popover
    $(window).bind("click touchstart", function () {
      if (!jQuery(".popover:hover").length && !jQuery(".popover-link:hover").length) {
        $('.popover-link').popover('hide').removeClass('active');
      }
    }).on('resize', function() {
      $('.popover-link').popover('hide').removeClass('active');
    });
  };

  self.create = function () {
    self.$pop_links.each(function (index, element) {

      //hide popover content containers on load
      $("body").find(element).parent().next('.popover-container').hide();

      //check the placement setting
      self.placement = $(element).attr('data-popover-placement');
      if (!self.placement || self.placement === '') {
        self.placement = 'bottom';
      }

      //initiate popovers
      $(element).popover({
        html: true,
        placement: self.placement,
        trigger: 'manual', // We will add the event handler later
        content: function () {
          // Grab the content from the next popover content element
          // Check if the term is a glossary term because there is only one container for all glossary terms
          if($(element).attr('class') == 'glossary-term-link popover-link'){
            return $('.glossary-term-content-wrapper.popover-container').html();
          }else{ //if not a glossary term
            return $("body").find(element).parent().next('.popover-container').html();
          }
        }
      });

      // Adjust the popover when it is shown
      $(element).on('shown.bs.popover', function (e) {

        // Fix width based on viewport
        self.mobileWidthFix();
        //fix popover horizontal position on mobile.
        self.mobilePositionFix();
        // When the popover is positioned at top, sometimes it will lay on top of the trigger.
        // This usually happens on mobile when the trigger is on the left half of the screen.
        self.positionTopVerticalFix(element);
        // Fix popover if it hangs off the right side of the screen
        self.rightSideFix();
        // Fix for arrows on the horizontal plain
        self.arrowHorizontalFix(e);

      });
    });
  };

  self.mobileWidthFix = function () {
    var windowWidth = $(window).width(); //width of the window
    var $popoverElement = $('.popover'); //popover element
    var popoverWidth = $popoverElement.outerWidth(); //width of the popover (including padding/border)
    var defaultWidth = 362; //minimum popover width
    var defaultMargin = 15;

    //increase popover width to 362
    if(popoverWidth < defaultWidth){
      $popoverElement.css('min-width', '362px');
      $popoverElement.css('width', '362px');
      popoverWidth = defaultWidth;
    }

    // If popover width is greater than window width, make it window width, minus the margins
    if(popoverWidth >= windowWidth - (defaultMargin * 2)){
      $popoverElement.css('min-width', windowWidth - (defaultMargin * 2));
      $popoverElement.css('width', windowWidth - (defaultMargin * 2));
      $popoverElement.css('left', defaultMargin);
    }

    // If min-width of the popover is > 362 and < window width then leave it alone.
  };

  self.arrowHorizontalFix = function (e) {
    var body = $('body'); //body element
    var arrow = body.find('.arrow');
    var triggerOffsetLeft = $(e.target).offset().left; //trigger offset on left
    var arrowOffsetLeft = arrow.offset().left; //arrow offset on left
    var arrowWidth = arrow.outerWidth(); //arrow width
    var arrowPositionLeft = arrow.position().left; //arrow position on left
    var triggerWidth = $(e.target).outerWidth(); //trigger width

    var difference = triggerOffsetLeft - arrowOffsetLeft;
    var leftCss = arrowPositionLeft + difference + (triggerWidth/2 - arrowWidth/2);

    arrow.css({'left': parseInt(leftCss, 10) + 'px'});
  };

  self.mobilePositionFix = function () {
    // Get the device type, cannot use Modernizer or jQuery for this...
    var device = (/android|iphone|ipod|blackberry|iemobile|opera mini/i.test(navigator.userAgent.toLowerCase()));

    var bodyWidth = $('body').innerWidth(); //width of the body

    // Check if we are on a mobile device and the screen is big as or bigger than 1024
    if (device !== true || bodyWidth >= 1024)return;

    var popoverElement = $('.popover'); //popover element
    var popoverWidth = popoverElement.outerWidth(); //width of the popover (including padding/border)
    var popoverPositionLeft = popoverElement.position().left; //distance from popover to its container on left side

    var popoverAdjustLeft = (popoverPositionLeft < 0) ? parseInt(popoverPositionLeft, 10) : 0;
    var leftPos = (bodyWidth - popoverWidth)/2;
    popoverElement.css({'left': (leftPos + popoverAdjustLeft) + 'px'});
  };

  self.positionTopVerticalFix = function (element) {

    //this only applies for top placement of a popover
    if($(element).attr('data-popover-placement') != 'top')return;

    var popoverElement = $('.popover'); //popover element
    var popoverHeight = popoverElement.outerHeight(); //height of the popover (including padding/border)
    var popoverPositionTop = popoverElement.position().top; //distance from popover to its container on top
    var popoverTriggerPositionTop = $(element).parent().position().top; //distance from popover trigger to its container on top
    var TriggerToContainerDifference = (popoverTriggerPositionTop - popoverPositionTop);

    if(TriggerToContainerDifference < popoverHeight){
      var topPos = popoverPositionTop - (popoverHeight - TriggerToContainerDifference);
      popoverElement.css({'top': topPos + 'px'});
    }
  };

  self.rightSideFix = function () {

    var popoverElement = $('.popover'); //popover element
    var bodyWidth = $('body').innerWidth(); //width of the body
    var popoverWidth = popoverElement.outerWidth(); //width of the popover (including padding/border)
    var popoverPositionLeft = popoverElement.position().left; //distance from popover to its container on left side
    var popoverOffsetLeft = popoverElement.offset().left; //distance from popover to document on left side
    var defaultMargin = 15;

    var bodyPopoverDifference = bodyWidth - popoverWidth - (defaultMargin);

    //if the position of the popover is off the screen to the right
    if(bodyPopoverDifference < popoverOffsetLeft){
      var arrowAdjustLeft = popoverOffsetLeft - bodyPopoverDifference;
      popoverElement.css({'left': (popoverPositionLeft - arrowAdjustLeft) + 'px'});
    }
  };

  if (self.$pop_links.length) {
    self.init();
  }
};

/**
 * Sets the styling (adds/removes classes) for elements in uniform
 * Styling for selects
 */
U.uniformStyling = function () {

  //for select
  new U.keyboard_access({
    focusElements: 'select',
    blurElements: 'select',
    focusHandler: function(e) {
      var $current = $(e.currentTarget);
      $current.parent().addClass('focused');
    },
    blurHandler: function(e, newTarget) {
      var $current = $(e.currentTarget);
      $current.parent().removeClass('focused');
    }
  });

  new U.keyboard_access({
    focusElements: 'input[type=radio], input[type=checkbox]',
    blurElements: 'input[type=radio], input[type=checkbox]',
    forceBlur: true,
    focusHandler: function(e) {
      var $current = $(e.currentTarget);
      $current.parent().addClass('focused');
    },
    blurHandler: function(e, newTarget) {
      var $current = $(e.currentTarget);
      $current.parent().removeClass('focused');
    }
  });
};

/**
 * Modal Windows (Bootstrap 3 modal vertical position center)
 * http://stackoverflow.com/questions/18422223/bootstrap-3-modal-vertical-position-center
 * 
*/
function adjustModalMaxHeightAndPosition(){
  $('.modal').each(function(){
    if($(this).hasClass('in') === false){
      $(this).show(); /* Need this to get modal dimensions */
    };

    var contentHeight = $(window).height() - 140;  //140 is sum of modal's top and bottom margin
  
    $(this).find('.modal-content').css({
      'max-height': function () {
        return contentHeight;
      }
    });

    $(this).find('.modal-dialog').addClass('modal-dialog-center').css({
      'margin-top': function () {
        return -($(this).outerHeight() / 2);
      },
      'margin-left': function () {
        return -($(this).outerWidth() / 2);
      }
    });
    if($(this).hasClass('in') === false){
      $(this).hide(); /* Hide modal */
    }
  });
}
 // only above 320 viewport or nonresponsive
if( Modernizr.mq('(min-width: 320px)') || !Modernizr.mq('only all')){
  $(window).resize(adjustModalMaxHeightAndPosition).trigger('resize');
}

/**
 * ReadSpeaker functions
 */
U.readSpeaker = function () {

  var self = {};

  self.carousels = [];

  self.queueCarousel = function(c) {
    self.carousels.push(c);
  };

  self.renderCarouselFocusables = function() {
    ReadSpeaker.q(function() {
      $.each(self.carousels, function(i,e) {
        U.carousels.accessibleSlide(e);
      });
    });
  };

  //Runs when the dom is ready
  self.init = function() {
    ReadSpeaker.q(function () {
      //Method adds a random guid to every element that has a class of rs_read_this (to comply with the documentation)
      $('.rs_read_this').each(function (index, value) {
        var $value = $(value);
        if (!$value.attr('id')) {
          $value.attr('id', guid());
        }
      });

      /**
       * Guid generator function found here: http://stackoverflow.com/a/16693578/524874
       * @returns {*}
       */
      function guid() {
        function _p8(s) {
          var p = (Math.random().toString(16) + "000000000").substr(2, 8);
          return s ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
        }
        return '_' + _p8() + _p8(true) + _p8(true) + _p8();
      }

    });
  };

  return self;
};

$(document).ready(function() {

  var drawerMenu = new U.drawerMenu();

  var searchSite = new U.searchSite();

  var popovers = new U.popovers();

  var navMain = new U.hoverDropdown({
    container : "#header-page .nav-main > ul"
  });

  var navKeyboardHandler = new U.focusDropdown();

  var languageSelector = new U.languageSelector();

  new U.uniformStyling();

  new U.readSpeaker().init();

  // input placeholder fix for IE
  $('input:text').placeholder();
  $('textarea').placeholder();

  // event handler for FPO URLs to prevent navigating to 404s
  // FIXME: this is temporary and needs to be removed during integration
  jQuery('a[href=REPLACE]').on('click', function(){ return false; });

  
});



