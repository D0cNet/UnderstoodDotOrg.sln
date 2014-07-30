/**
 * Definition for the article slideshow javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.articleSlideshow();

    // Hover states for the icons below slideshow
    var container = $('.article-slideshow-container .buttons-container');

    U.actionButtons(container);

  });

  U.articleSlideshow = function(){
      var self = this;
      var $articleIntroText = $(".article-intro-text");

    self.focusedElement = [];
    self.readSpeakerReady = false;

    self.init = function(){
      self.$container = $('#article-slideshow');
      if (self.$container.length) {
        self.$org = self.$container.clone();
        self.initslide();
        $(window).on('resize', self.checker);
      }

      $('.index-buttons-container .button').click(self.indexButtonClick);

      //ReadSpeaker.q(function () {
      //  self.readSpeakerReady = true;
      //});

      self.overflowToggleActions();
    };

    // Prevent the actions list from getting clipped on hover for wide images
    self.overflowToggleActions = function(){
       $('#article-slideshow .slide.wide-image .content .share-dropdown-menu').hover(function(){
         $('.container.article.slideshow').toggleClass('overflowToggleActions');
       });
    };

    self.initslide = function(){
      self.$rs = self.$container.royalSlider({
        keyboardNavEnabled: false,
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

      U.carousels.keyboardAccess($('.article-slideshow-container'), false, self.$container, true);

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

    self.indexButtonClick = function(e) {
      e.preventDefault();

      var slider = self.$rs.data('royalSlider');
      var $this = $(this);  

      if ($this.hasClass('disabled')) {
        return;
      }
      else if ($this.hasClass('first')) {
          slider.goTo(0);
          $articleIntroText.show();
      }
      else if ($this.hasClass('last')) {
          slider.goTo(slider.numSlides - 1);
          $articleIntroText.hide();
      }
      else if ($this.hasClass('next')) {
          slider.next();
          if (slider.currSlideId == slider.numSlides - 1) {
              $articleIntroText.hide();
          }
      }
      else if ($this.hasClass('prev')) {
          slider.prev();
          $articleIntroText.show();
      }
      else {
        var slideId = $this.attr('data-target');
        if (slideId) {
            slider.goTo(slideId - 1);
            $articleIntroText.show();
        }
      }
    };

    self.restartSlideshow = function(e) {
      e.preventDefault();
      var slider = self.$rs.data('royalSlider');
      slider.goTo(0);
      $articleIntroText.show();
    };

    self.updateActiveSlide = function(event) {
      $('#article-slideshow .restart-slideshow').click(self.restartSlideshow);

      // Moves Arrows up or down to center to match tall or wide images
      setTimeout(function(){
        if( $('#article-slideshow .rsActiveSlide .slide').hasClass('tall-image') ){
          $('.article-slideshow-container').addClass('tall-image-arrows');
        }else{
          $('.article-slideshow-container').removeClass('tall-image-arrows');
        }
      }, 100);


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

      /* Re-Fire Readspeaker when current item doesn't have a play button */
      if (self.readSpeakerReady && !slider.currSlide.content.find('.rsbtn_play').length) {
        rspkr.Toggle.createPlayer();
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

      $('#article-slideshow .rsArrowIcn').fadeIn('fast', function() {
        if (self.focusedElement.length) {
          self.focusedElement.trigger('focus');
        }
      });
    };

    // this makes the repositioning of the arrows less jarring
    self.hideArrows = function(event) {
      self.focusedElement = $(document.activeElement);
      $('#article-slideshow .rsArrowIcn').hide();
    };

    self.init();
  };

})(jQuery);
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
/**
 * Definition for the KnowledgeQuiz javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.KnowledgeQuiz();
  });

  U.KnowledgeQuiz = function() {
    var self = this;

    var knowledgeQuizFormElements = [
      '.knowledge-quiz select',
      '.knowledge-quiz input'
    ].join(',');

    // Build uniform components.
    jQuery(knowledgeQuizFormElements).uniform();

    jQuery('.knowledge-quiz .answer-choices button').click(function(){
      var thisBtn = jQuery(this);
      if( !thisBtn.hasClass('selected') ){
        thisBtn.addClass('selected').removeClass('disabled');
        thisBtn.siblings('button').removeClass('selected').addClass('disabled');
      }
    });

    return this;
  };

})(jQuery);
/**
 * Definition for the articleAudioPlayer jQuery plugin.
 */

(function($){

  $(document).ready(function() {
    // Audio players
    var $audioPlayers = jQuery(".audio-player");
    // Instantiate jPlayer
    if($audioPlayers.length){
      $audioPlayers.articleAudioPlayer();
    }
  });

  $.fn.articleAudioPlayer = function() {

    // Div containing audio player formats and their URLs
    var $audioPlayerFormatData = this.children('.audio-player-data');
    // Hide audio player format data div
    $audioPlayerFormatData.hide();

    // NOTE - Essential Audio formats: mp3 or m4a. (http://jplayer.org/latest/developer-guide/#jPlayer-option-supplied)
    // Object of audio formats and their urls
    var audioPlayerSetMedia = {}; //object

    jQuery.each($audioPlayerFormatData.find('a'), function() {
      audioPlayerSetMedia[$(this).attr('data-audio-format')] = this.href;
    });

    this.jPlayer({
      ready: function () {
        jQuery(this).jPlayer("setMedia", audioPlayerSetMedia);
      },
      solution: "html, flash", //this is default. Switch to test swfPath
      cssSelectorAncestor: '.audio-player-interface',
      swfPath: "/js/vendor", //location of the jPlayers Jplayer.swf file
      supplied: Object.keys(audioPlayerSetMedia).toString(),
      fullWindow: false,
      audioFullScreen: false,
      smoothPlayBar: false
    });
  };

})(jQuery);
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

        this.attachModalHandlers();
      }


      // Build uniform components.
      $(uniform_elements).uniform();

      // Attach events.
      $(window).resize(function() {
        self.resizeSelect();
      });

      return this.resizeSelect();
    };

      this.attachModalHandlers = function() {
          var $modal = $('.assessment-quiz-modal');
          $modal.on('shown.bs.modal', function() {
              $(this).find(':focusable').first().focus();
          });
          $modal.on('hide.bs.modal', function() {
              document.body.focus();
          });

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
 * Definition for the tryAnotherQuiz javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.tryAnotherQuiz();
  });

  U.tryAnotherQuiz = function() {
    var self = this;

    self.$html = $('html');

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    self.initialize = function() {

      self.$html.on('equalHeights', self.equalizeHeights);
      return this;
    };

    self.equalizeHeights = function() {
      // only above 650 viewport or nonresponsive
      if(Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){

        // give set-height class to 2 modules
        $('.quiz').addClass('set-height');

        // give set-height class items same height
        $('.set-height').equalHeights();

      }
    };

    return this.initialize();
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
        '.personalize-checklist input[type=checkbox]'
      ].join(',');

      // Add modal window to end of body.
      $('form').append(this.$modalWindow);

      // Build uniform components.
      $(uniform_components).uniform();

      $('.personalize-checklist-modal').modal({
        backdrop: 'static',
        show: false
      });

      this.attachHandlers();

      // Switch modal content or close modal
      this.checklistModalContent();

      return this.resizeElements().openModal();
    };

    this.attachHandlers = function() {
        var $modal = $('.personalize-checklist-modal');
        $modal.on('shown.bs.modal', function() {
            $(this).find(':focusable').first().focus();
        });
        $modal.on('hide.bs.modal', function() {
           document.body.focus();
        });

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

    /**
     * Change modal content on user decision, or close modal..
     */
    this.checklistModalContent = function(){

      var personalizeChecklistModal = '.personalize-checklist-modal';
      var checklistModalContainer = $(personalizeChecklistModal + ' > .personalize-checklist');
      var checklistModalContent = $(personalizeChecklistModal + ' > .personalize-checklist > .modal-content');

      // Hide part2 on page load
      checklistModalContent.children('.part2').hide();

      // If the 'yes' button is clicked
      checklistModalContent.find('.part1 .checklist-buttons > button.advance').click(function(){
        checklistModalContent.find('.part1').hide();
        checklistModalContainer.addClass('part2');
        checklistModalContent.find('.part2').show();
      });

      // If the 'no, thank you' button is clicked
      checklistModalContent.find('.part1 .checklist-buttons > button.close').click(function(){
        $(personalizeChecklistModal).modal('hide');
      });

    };

    return this.initialize();
  };

})(jQuery);

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
    this.initialize = function () {
      var allChecked = false;
      var uniform_elements = [
        '.article-checklist input[type=checkbox]'
      ].join(',');

      // Build uniform components.
      $(uniform_elements).uniform();

      // Auto-check all checkboxes if question is clicked, toggle.
      $('.checklist-question').click(function () {
          if (allChecked == false) {
              $(this).siblings('.checkboxes-wrapper').each(function () {
                  $(this).find('.checked input').click();
                  $(this).find('input').click();
                  allChecked = true;
              });
          } else {
              $(this).siblings('.checkboxes-wrapper').each(function () {
                  $(this).find('.checked input').click();
                  allChecked = false;
              });
          }
      });

      return this;
    };

    return this.initialize();
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

    var container =  $('.article-tips-container .tools .buttons-container');

    U.actionButtons(container);

    var carouselWrapper = $('.article-slideshow-container');

    carouselWrapper.on('click', '.plus-button, .bell-button', function(e){
      e.preventDefault();
      var clicked = $(this);
      if (clicked.hasClass('active')) {
        clicked.removeClass('active');
      } else {
        clicked.addClass('active');
      }
    });


  };
})(jQuery);
/**
 * Definition for the ArticleDeepDiveCopy javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.ArticleDeepDiveCopy();
  });

  U.ArticleDeepDiveCopy = function() {
    var self = this;

  $('.deep-dive-more').bind('click', false);

    var $deepDiveMore = $('.deep-dive-more');
    var $deepDiveExtra = $('.deep-dive-extra');
    var $whatsCoveredDeepDive = $('.whats-covered-deep-dive');

    $deepDiveMore.click(function() {
      $deepDiveMore.css('display', 'none');
      $deepDiveExtra.css('display', 'block');
    });

    $whatsCoveredDeepDive.click(function() {
      $deepDiveMore.css('display', 'none');
      $deepDiveExtra.css('display', 'block');
    });

    return this;
  };

})(jQuery);
/**
 * Definition for the article table script, for mobile and accessibility purposes
 * Goal is to change table from row-based to column-based on mobile
 * This script strips cells out of the original table and moves them into mobile-only tables that are 1 cell wide.
 * The new tables are essentially columns that can be stacked on mobile 
 * Uses CSS to hide or show tables depending on breakpoint
 * UN-3101, UN-2377
 *
 *  TODO: Address Accessbility Concerns
 */




(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.articleTable();
  });

  U.articleTable = function() {
    var self = this;

    this.initialize = function() {
      
      // get var for original table, add original class
      $articleTable = $('.article table').addClass('original');

      // exit script if tables don't exist
      if(!$articleTable.length) { return; }

      // for each table on page...
      $articleTable.each(function() {

        // for each table, create a new table from each column

        // wrap table
        $(this).wrap( '<div class="table-container"></div>' );

        // count number of columns
        $columnCount = $(this).find('tr:first').children().length;

        for ( $j = 0; $j < $columnCount; $j++ ) {

          // create new table 
          $(this).after('<table class="mobile-only"></table>');
        
        }


        // for each cell in the original table, move them to their newly created table in an individual row
        // all cells in original column 1 go into new table 1,  all cells in original column 2 go into new table 2, etc...

        // add th class to original table (if not using <th>) and add scope="col" for accessibility (UN-3688)      
        if ( $(this).find('th').length ) {
            $(this).find('th').attr('scope','col');
            return;
        }
        else {
          $(this).find('tr:first td').addClass('th').attr('scope','col');
        }

      });

      $('.table-container').each(function() {

        // loop through each column and assign cells
        for ( $index = 0; $index < $columnCount; $index++ ) {

          $(this).find('td, th').each(function() {

            // if cell is in this child (or column) position {
            if ( $(this).is(':nth-child('+ ($index + 1) +')') ) {

              // clone it, and insert it into new table, wrap with <tr> 
              $(this).clone().appendTo( $(this).parents('.table-container').find('.mobile-only:eq('+ $index +')') ).wrap('<tr></tr>');
          
            }
          });

        }

        // clone original caption and prepend to new table
        $(this).find('caption').clone().prependTo( $(this).find('.mobile-only:first') );
          
      });    

      return this;
    };

    return this.initialize();
  };

})(jQuery);

(function ($) {

    // Initialize the module on page load.
    $(document).ready(function () {
        new U.infographic();
    });

    U.infographic = function () {
        var self = this;

        this.initialize = function () {
            //set click-to-select on text area

            $("#embed-overlay").on('shown.bs.modal', function (e) {
                //alert('done modal load');

                //attach "click-to-select" to modal text body
                $(".modal-body textarea").click(function () {
                    $(this).select();
                });

                //attach zClip "click-to-copy" to modal copy button
                $(".copy-button-container a").zclip(
                    {
                        path: "/Presentation/Includes/js/vendor/ZeroClipboard.swf",
                        copy: $(".modal-body textarea").text(),
                        afterCopy: function () {
                            //show message saying stuff was copied?

                            $("#copyAlert").removeClass("hidden").addClass("show");
                            window.setTimeout(function () { $("#copyAlert").removeClass("show").addClass("hidden"); }, 2000);
                            //return false to prevent an alert from showing up
                            return false;
                        }
                    });
            });

            $("#embed-overlay").on('hide.bs.modal', function (e) {
                //detach zClip from button
                $(".copy-button-container a").zclip('remove');
            });
        };

        return this.initialize();
    };
})(jQuery);