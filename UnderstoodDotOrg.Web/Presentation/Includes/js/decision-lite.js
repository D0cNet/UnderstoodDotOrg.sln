(function($){

  $(document).ready(function() {
    new U.decisionQuiz();

      var $hfAnswerIndex = $(".hfAnswerIndex");
      var $nextQuestion = $(".next-question");

      var $answerWrapper = $(".answer-wrapper");
      var $answerControl = $answerWrapper.find("button, input[type='radio']");

      $answerControl.on("click", function () {
          var $this = $(this);
          $hfAnswerIndex.val($this.attr("data-answer-index"));
          $answerWrapper.hide();
          $("." + $this.attr("data-indication-answer-id")).show();
          $nextQuestion.show();
      });
  });

  U.decisionQuiz = function() {
    var self = this;

    self.init = function() {
      var uniform_elements = $('.dl-quiz input[type=radio]');

      uniform_elements.uniform();
    };

    self.init();
  };


})(jQuery);
(function(){

  $(document).ready(function(){
    new U.decisionResults();
  });

  U.decisionResults = function() {
    var self = this;
    self.init = function() {
      self.cacheDom();
      self.setModel();
      self.attachHandlers();
      self.enableKeyboardAccess();
    };

    self.cacheDom = function() {
      self.dom = {};
      self.dom.topLevel = $('body, html');
      self.dom.innerWrapperFormEval = $('.result-section .results-wrapper');
      self.dom.window = $(window);
      self.dom.slider = null;
    };

    self.setModel = function() {
      self.model = {};
      self.defineResponsiveView();
      self.model.hasSlider = 'initial';
      self.model.arrowWrapperWidth = 100;
      self.model.pageSectionMap = [];

      self.dom.innerWrapperFormEval.each(function(index, element){
        var sectionMarkup = {};
        sectionMarkup.element = $(element);
        sectionMarkup.dataId = sectionMarkup.element.data('sectionNumber');
        sectionMarkup.content = $.trim(sectionMarkup.element.html());
        self.model.pageSectionMap.push(sectionMarkup);
      });
      self.repositionElement();
    };

    self.enableKeyboardAccess = function() {
      var $searchResultButton = $('.result-body'),
          $searchResultItems = $searchResultButton.find('.hover-link-wrapper a'),
          $htmlEl = $('html'),
          fromHoverLink = null;
          fromButton = null;


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
          var itemInNavigation = newTarget.is($searchResultItems),
              $buttonTarget = newTarget.is($searchResultButton);

          if (!itemInNavigation) {
            $searchResultButton.removeClass('open');
          }
          fromHoverLink = false;
          fromButton = true;

          if(fromButton && newTarget.is($searchResultButton)) {
            newTarget.addClass('open');
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
          fromHoverLink = true;
          fromButton = false;

        }
      });
    };

    self.attachHandlers = function() {
      self.dom.window.on('resize', self.repositionElement);
    };

    self.repositionElement = function () {
      self.defineResponsiveView();
      var initialDesktop = (self.model.isDesktop && self.model.hasSlider === 'initial'),
          desktopChange = (self.model.isDesktop && self.model.hasSlider),
          mobileChange = (!self.model.isDesktop && !self.model.hasSlider) || (!self.model.isDesktop && self.model.hasSlider === 'initial');

      if (initialDesktop) {
        self.model.hasSlider = false;
      } else if (desktopChange) {
        self.destroySliders();
      } else if (mobileChange) {
        self.buildSliders();
      }

      self.repositionArrows();

    };

    self.repositionArrows = function() {
      var width = self.dom.innerWrapperFormEval.width();
      var offset = ((width / 2) - (self.model.arrowWrapperWidth/2) + 8);
      $('.rsArrowWrapper').css('left', -offset);
    };

    self.defineResponsiveView = function () {

      self.model.isDesktop = (Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all'));

    };

    self.buildSliders = function () {

      self.model.hasSlider = true;

      self.dom.innerWrapperFormEval.each(function(index, element) {
        $(element).royalSlider({
          addActiveClass: true,
          arrowsNav: true,
          arrowsNavAutoHide: false,
          arrowsNavHideOnTouch: false,
          fadeinLoadedSlide: true,
          keyboardNavEnabled: false,
          imageAlignCenter: true,
          loop: false,
          loopRewind: false,
          numImagesToPreload: 4,
          autoPlay: {
            enabled: false,
            pauseOnHover: true,
            delay: 2000
          },
          visibleNearby: {
            enabled: true,
            centerArea:0.9
          },
          sliderDrag: false
        });
      });

      for (var i=0; i < self.dom.innerWrapperFormEval.length; i++) {
        var mainElementWrapper = $(self.dom.innerWrapperFormEval[i]),
            rsArrows = mainElementWrapper.find('.rsArrow');

        rsArrows.wrapAll('<div class="rsArrowWrapper" />');
      }

    };

    self.destroySliders = function() {

      self.dom.innerWrapperFormEval.removeClass('rsHor').removeClass('rsWithBullets');
      self.model.hasSlider = false;

      for (var i=0; i < self.dom.innerWrapperFormEval.length; i++) {

        var mainElementWrapper = $(self.dom.innerWrapperFormEval[i]);
        var wrapperDataTag = mainElementWrapper.data('section-number');

        for (var x=0; x < self.model.pageSectionMap.length; x++) {
          var dataObject = $(self.model.pageSectionMap[x]);
          var dataContent = self.model.pageSectionMap[x].content;
          var storedDataID = self.model.pageSectionMap[x].dataId;

          if (storedDataID == wrapperDataTag) {

            var sliders = mainElementWrapper.data('royalSlider');
            sliders.destroy();

            mainElementWrapper.html('');

            mainElementWrapper.append(dataContent);
            continue;
          }
        }
      }
    };

    self.init();

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




