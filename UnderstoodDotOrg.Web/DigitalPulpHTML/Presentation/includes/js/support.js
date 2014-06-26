(function($){

  $(document).ready(function() {
    new U.splash();
  });

  U.splash = function() {
    var self = this;

    self.dom = {};

    self.init = function() {};

    self.init();
  };

})(jQuery);
(function($){

  $(document).ready(function() {
    new U.myGoals();
  });

  U.myGoals = function() {
    var self = this;

    self.init = function() {
      self.cacheSelectors();
      self.setModel();
      self.attachHandlers();
      self.initializeDraggable();
      self.initializeSortable();
      self.changeXAxisUnits();
      //self.drawGrid();
    };

    self.cacheSelectors = function() {
      self.dom = {};
      self.dom.graphWrapper = $('.graph-wrapper');
      self.dom.graphBackground = self.dom.graphWrapper.find('.grid-background');
      self.dom.graphKey = $('.graph-key');
      self.dom.showMonthsCheckbox = $('.show-months-checkbox');
      self.dom.checked = self.dom.showMonthsCheckbox.find('.show-months');
      self.dom.actionList = $('.action-plan-list');
      self.dom.actionListItem = self.dom.actionList.find('li');
      self.dom.actionTitle = $('.action-title');
    };

    self.attachHandlers = function() {
      self.dom.checked.on('click', self.changeXAxisUnits);

      self.dom.actionListItem.on('mouseover', function() {
        var element = $(this),
            subMenu = element.find('.list-options');

        subMenu.css({"display": "block"});
      });
      self.dom.actionListItem.on('mouseout', function() {
        var element = $(this),
            subMenu = element.find('.list-options');

        subMenu.css({"display": "none"});
      });
    };


    self.setModel = function() {
      self.model = {
        gridType: 'initial',
        initialGridLength: 8,
        months: ['jan', 'feb', 'march', 'april', 'may', 'june', 'july'],
        storedKey: self.dom.graphKey.html(),
        spacing: undefined
      };
    };

    self.changeXAxisUnits = function() {
      var checkElement = $(this);
      if (checkElement.is(':checked')) {
        self.model.gridType = 'months';
        self.model.spacing = 80 / (self.model.months.length - 1);
      } else {
        self.model.gridType = 'initial';
        self.model.spacing = 90/ self.model.initialGridLength;
      }
      self.setGridKey();
      self.drawGrid();
    };

    self.setGridKey = function() {

      if (self.model.gridType == 'months') {
        self.model.storedKey = self.dom.graphKey.html();
        self.dom.graphKey.html('');
        var xAxisMonth;
        for (var i = 0; i < self.model.months.length; i++) {
          xAxisMonth = self.model.months[i];
          xAxisElement = '<p class='+ xAxisMonth +'>' + xAxisMonth + '</p>';
          $(xAxisElement).appendTo(self.dom.graphKey).css('left', (self.model.spacing * i) + self.model.spacing + '%');
        }
      }

      else if (self.model.gridType == 'initial') {
        self.dom.graphKey.html('');
        self.dom.graphKey.html(self.model.storedKey);
      }

      var xAxis = self.dom.graphKey.find('p');
      for (var i = 0; i < xAxis.length; i++) {
        var element = xAxis[i],
            elementWidth = ($(element).width());

        $(element).css("margin-left", -(elementWidth/2));
      }

    };

    self.drawGrid = function() {
      var tickMark = '<span class="grid-tick-mark"></span>';

      self.dom.graphBackground.html('');


      if (self.model.gridType === 'months') {

        for (var i = 0; i < self.model.months.length; i++) {
          $(tickMark).prependTo(self.dom.graphBackground).css('left', (self.model.spacing * i) + self.model.spacing  + '%');
        }
      }

      else if (self.model.gridType === 'initial') {

        for (var i = 0; i < self.model.initialGridLength; i++) {
          $(tickMark).prependTo(self.dom.graphBackground).css('left', (self.model.spacing * i) + self.model.spacing + '%');
        }
      }

    };


    self.initializeDraggable = function() {

      $('.action-plan-list > li').each( function() {
        var element = $(this),
            maxLength = element.css("width"),
            handler = element.find('.action-title'),
            parentContainer = element.children('.action-element-wrapper'),
            subMenu = element.find('.list-options');


        $(parentContainer).draggable({
          containment: element,
          handle: handler,
          drag: function() {
            subMenu.css({"display": "none"});
          }
        });
      });
    };

    self.initializeSortable = function() {
      $('.action-plan-list > li').each( function() {
        var element = $(this),
            handler = element.find('.action-plan-button');


        $(element).draggable({
          axis: 'y',
          handle: handler
        });
      });
    };

    self.init();
  };

})(jQuery);
(function($){

  $(document).ready(function() {
    new U.helpReading();
  });

  U.helpReading = function() {
    var self = this;

    self.cacheSelectors = function() {
      self.dom = {};
      self.dom.helpList = $('.help-list');
      self.dom.startOver = $('.start-over');
      self.dom.doneThis = $('.done-this');
      self.dom.skipThis = $('.skip-this');
      self.dom.listItem = $('li');
      self.dom.hiddenButton = $('.list-element');
      self.dom.helpCardButton = $('.help-card-button');
      self.dom.listElementWrapper = $('.list-element-wrapper');
    };

    self.init = function() {
      self.cacheSelectors();
      self.attachHandlers();
      self.initializeAccessibility();
    };

    self.attachHandlers = function() {
      self.dom.startOver.on('click touchstart', self.appendClass);
      self.dom.doneThis.on('click touchstart', self.appendClass);
      self.dom.skipThis.on('click touchstart', self.appendClass);
      self.dom.listElementWrapper.on('touchstart mouseenter mouseleave', self.toggleHover);
    };

    self.toggleHover = function(e) {
      e.preventDefault();
      var element = $(this);
      if (element.hasClass('hover')) {
        element.removeClass('hover');
      } else {
        element.addClass('hover');
      }
    };

    self.appendClass = function(e) {
      e.preventDefault();
      var element = $(this),
          elementOuterWrapper = element.parents('li'),
          parentContainer = elementOuterWrapper.find('.list-element-wrapper'),
          elementButton = parentContainer.find('.activity-action'),
          hiddenButton = parentContainer.find('.list-element'),
          nextHiddenButton = parentContainer.nextAll(self.dom.listItem).find('.list-element').first();

      if (element.hasClass('start-over')) {
        parentContainer.removeClass('done');
        elementButton.text('Start This Activity');
        hiddenButton.focus();
      }
      else if (element.hasClass('done-this')) {

        if (parentContainer.hasClass('skipped')) {
          parentContainer.removeClass('skipped');
        }
        parentContainer.addClass('done');
        elementButton.text('View Activity');
        nextHiddenButton.focus();
      }
      else if (element.hasClass('skip-this')) {
        if (parentContainer.hasClass('done')) {
          parentContainer.removeClass('done');
        }
        elementButton.text('Start This Activity');
        parentContainer.addClass('skipped');
        nextHiddenButton.focus();
      }
    };

    self.initializeAccessibility = function() {

      new U.keyboard_access({
        focusElements: self.dom.hiddenButton,
        blurElements: self.dom.hiddenButton,
        focusHandler: function(e) {
          e.preventDefault();
          var element = $(e.currentTarget),
              parentContainer = element.parents('li');

          parentContainer.addClass('accessibility');
        },
        blurHandler: function(e, newTarget) {
          e.preventDefault();
          var element = $(e.currentTarget),
              parentContainer = element.parents('li'),
              elementButtons = parentContainer.find('.help-card-button'),
              itemInHelpCard = newTarget.is(elementButtons);

          if (!itemInHelpCard) {
            parentContainer.removeClass('accessibility');
          }

          if (self.dom.helpCardButton && !itemInHelpCard) {
            var newParentContainer = newTarget.parents('li'),
                nextHiddenButton = newParentContainer.find('.list-element');

            newParentContainer.addClass('accessibility');
            nextHiddenButton.focus();
          }
        }
      });

      new U.keyboard_access ({
        focusElements: self.dom.helpCardButton,
        blurElements: self.dom.helpCardButton,
        focusHandler: function(e) {
          e.preventDefault();
          var element = $(e.currentTarget);
        },
        blurHandler: function(e, newTarget) {
          e.preventDefault();
          var element = $(e.currentTarget),
              parentContainer = element.parents('li'),
              elementButtons = parentContainer.find('.help-card-button'),
              hiddenButton = parentContainer.find('.list-element'),
              buttonInHelpCard = newTarget.is(hiddenButton),
              listItem = newTarget.is(self.dom.hiddenButton);

          if (!elementButtons) {
            parentContainer.removeClass('accessibility');
          }

          if (listItem && !buttonInHelpCard) {
            parentContainer.removeClass('accessibility');
          }
        }
      });


    };

    self.init();
  };

})(jQuery);
(function($){

  $(document).ready(function() {
    new U.printView();
  });

  U.printView = function() {
    var self = this;

    self.cacheSelectors = function() {
      self.dom = {};
    };

    self.init = function() {
      self.cacheSelectors();
    };

    self.init();
  };

})(jQuery);
(function($){

  $(document).ready(function() {
    new U.trackProgress();
  });

  U.trackProgress = function() {
    var self = this;

    self.cacheSelectors = function() {
      self.dom = {};
      self.dom.timelineWrapper = $('.timeline-wrapper');
      self.dom.timeline = $('.timeline');
      self.dom.timelineList = $('.timeline-list');
      self.dom.timelineLabelButton = self.dom.timelineList.find('button');
      self.dom.labelWrapper = $('.label-wrapper');
      self.dom.timelineListItems = $('.timeline-list li');
    };

    self.init = function() {
      self.cacheSelectors();
      self.setModel();
      self.setTimelineParameters();
      self.initializeTimelineDragging();
      self.initializeTimelineAccessiblity();
    };

    self.setModel = function() {
      self.model = {
        endpoint: null
      };
    };

    self.initializeTimelineAccessiblity = function() {
      new U.keyboard_access ({
        focusElements:self.dom.timelineLabelButton,
        blurElements: self.dom.timelineLabelButton,
        focusHandler: function(e) {
          var element = $(e.currentTarget),
              parent = element.parents('.label');
          parent.addClass('focus');
        },
        blurHandler: function(e, newTarget) {
          var element = $(e.currentTarget),
              parent = element.parents('.label');
          parent.removeClass('focus');
        }
      });
    };

    self.setTimelineParameters = function() {
      var listItemWidth = self.dom.timelineListItems.outerWidth(true),
          timelineListLength = self.dom.timelineListItems.length * listItemWidth,
          timelineWrapperWidth = self.dom.timelineWrapper.width(),
          maxLabelHeight = 0;

      self.dom.timeline.css({
             "width": timelineListLength,
             "opacity": "1"
      });
      self.model.endpoint = timelineListLength - timelineWrapperWidth;

      self.dom.labelWrapper.each(function(){
        var curLabelHeight = $(this).height;

        maxLabelHeight = maxLabelHeight > curLabelHeight ? maxLabelHeight : curLabelHeight;
      });

      var  timelineHeight = maxLabelHeight + 114;

      self.dom.timeline.css({"height": timelineHeight });
      self.dom.timelineWrapper.css({"height": timelineHeight });
    };

    self.initializeTimelineDragging = function() {
      self.dom.timeline.draggable({
        axis: "x",
        stop: self.setTimelineEndpoints,
        handle: self.dom.timelineList
      });
    };

    self.setTimelineEndpoints = function(event, ui) {
      var leftCoords = ui.position.left;

      if (leftCoords >= 0) {
        self.dom.timeline.css({"left": "0"});
      } else if (leftCoords <= -(self.model.endpoint)) {
        self.dom.timeline.css({"left": -(self.model.endpoint)});
      }
    };

    self.init();
  };

})(jQuery);
(function($){

  $(document).ready(function() {
    new U.actionPlanToolbar();
  });

  U.actionPlanToolbar = function() {
    var self = this;

    self.cacheSelectors = function() {
      self.dom = {};
      self.dom.body = $(document.body);
      self.dom.toolbarMenu = $('.action-toolbar');
      self.dom.toolbarMenuItem = $('.action-toolbar li a');
      self.dom.progressToggleBox = $('.progress-toggle-wrapper');
      self.dom.emailButton = $('.email');
      self.dom.myProgressButton = $('.my-progress');
      self.dom.myProgressButtonLink = $('.my-progress a');
      self.dom.modal = $('.action-plan-email-modal');
    };

    self.attachHandlers = function() {
      self.dom.emailButton.on('click', self.renderLightbox);
      self.dom.myProgressButton.on('touchstart mouseenter mouseleave', self.addHover);
      self.dom.myProgressButtonLink.on('click touchstart', function(e) {
        e.preventDefault();
      });
    };

    self.init = function() {
      self.cacheSelectors();
      self.toggleSwitch();
      self.cacheToggleSelectors();
      self.initializeAPToolbarAccessibility();
      self.attachHandlers();
    };

    self.cacheToggleSelectors = function() {
      self.dom.toggleButton = self.dom.progressToggleBox.find('button');
    };

    self.initializeAPToolbarAccessibility = function() {
      new U.keyboard_access ({
        focusElements: self.dom.toolbarMenuItem,
        blurElements: self.dom.toolbarMenuItem,
        focusHandler: function(e) {
          e.preventDefault();
          var element = $(e.currentTarget),
              parentListItem = element.parents('li');
          parentListItem.addClass('focus');
        },
        blurHandler: function(e, newTarget) {
          e.preventDefault();
          var element = $(e.currentTarget),
              parentListItem = element.parents('li'),
              itemInToggleBox = newTarget.is(self.dom.toggleButton);
          if (!itemInToggleBox) {
            parentListItem.removeClass('focus');
          }
        }
      });
      new U.keyboard_access ({
        blurElements: self.dom.toggleButton,
        blurHandler: function(e, newTarget) {
          e.preventDefault();
          var element = $(e.currentTarget),
              parentListItem = element.parents('li'),
              myProgressLink = parentListItem.find('a'),
              itemInToggleBox = newTarget.is(self.dom.toggleButton),
              elementMenuItem = newTarget.is(myProgressLink);
          if (!elementMenuItem && !itemInToggleBox) {
            parentListItem.removeClass('focus');
          }
        }
      });
    };

    self.toggleSwitch = function() {
      var toggle_switch = $(
              '<div class="switch-wrapper">' +
              '<span class="btn-toggle btn-left"><button>Off</button></span>' +
              '<span class="btn-toggle btn-right"><button>On</button></span>' +
              '</div>'
      );

      $('.toggle-wrapper input[type=checkbox]').ezMark();
      $('.toggle-wrapper .ez-checkbox').append(toggle_switch);

      $('.toggle-wrapper .ez-checkbox').find('.btn-toggle').on('click', function(e) {
        e.preventDefault();

        $(this).parent().parent().toggleClass('ez-checked');
      });
    };

    self.addHover = function(e) {
      e.preventDefault();
      var element = $(this);
      if (element.hasClass('hover')) {
        element.removeClass('hover');
      } else {
        element.addClass('hover');
      }
    };

    self.renderLightbox = function(e) {
      e.preventDefault();
      self.dom.close = self.dom.modal.find('.close');
      self.dom.body.append(self.dom.modal);
      self.dom.dialog = self.dom.modal.find('.modal-dialog');
      self.attachLightboxHandlers();
      self.dom.modal.modal('show');
    };

    self.attachLightboxHandlers = function() {
      self.dom.body.on('click', '.close', self.closeModal);
      self.dom.close.on('click', self.closeModal);
      self.dom.modal.on('show.bs.modal', function() {
        $(this).find(':focusable').first().focus();
      });
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

    self.closeModal = function() {
      self.dom.modal.modal('hide');
    };

    self.onClose = function() {
      self.dom.body.focus();
      // TODO -- Integration task - set cookie so lightbox isn't displayed once this has been dismissed
    };

    self.init();
  };

})(jQuery);
(function($){

  $(document).ready(function() {
    new U.selectIssues();
  });

  U.selectIssues = function() {
    var self = this;

    self.cacheSelectors = function() {
      self.dom = {};
      self.dom.body = $(document.body);
      self.dom.selectIssuesContainer = $('.support-select-issues');
      self.dom.errorBox = $('.error-box');
      self.dom.checkboxWrapper = $('.goal-checkbox-wrapper');
      self.dom.selectIssuesButton = self.dom.selectIssuesContainer.find('.button');
      self.dom.checkbox = $('.support-select-issues input[type=checkbox]');
      self.dom.letUsKnow = $('.let-us-know');
      self.dom.modal = $('.issues-recommended-modal');
    };

    self.cacheUniformSelector = function() {
      self.dom.checker = self.dom.checkboxWrapper.find('.checker');
    };

    self.model = function() {
      self.model = {
        checkedCount: 0
      };
    };

    self.init = function() {
      self.cacheSelectors();
      self.applyUniform();
      self.cacheUniformSelector();
      self.attachHandlers();
      self.model();
    };

    self.attachHandlers = function() {
      self.dom.checker.on('click', self.findCheckedCount);
      self.dom.selectIssuesButton.on('click', self.checkForErrors);
      self.dom.letUsKnow.on('click', self.renderLightbox);
      self.dom.modal.on('shown.bs.modal', function() {
        $(this).find(':focusable').first().focus();
      });
      self.dom.modal.on('hide.bs.modal', function() {
        document.body.focus();
      });

    };

    self.applyUniform = function() {
      U.uniformSelects(self.dom.checkbox);
    };

    self.findCheckedCount = function(e) {
      var element = $(this),
          checked = element.find('span').hasClass('checked');
      if (checked) {
        self.model.checkedCount ++;
      } else {
        self.model.checkedCount --;
      }
    };

    self.checkForErrors = function (e) {
      self.resetErrorBox();
      var errorContent;

      if (self.model.checkedCount > 5) {
        errorContent = '<p>Please choose up to 5 goals only.</p>';
        self.renderErrorBox(e, errorContent);
      }

      if (self.model.checkedCount <= 0) {
        errorContent = '<p>Please select at least one goal above.</p>';
        self.renderErrorBox(e, errorContent);
      }
    };

    self.renderErrorBox = function (e, errorContent) {
      e.preventDefault();
      self.dom.errorBox.append(errorContent);
      self.dom.errorBox.css({'display': 'block'});
    };

    self.resetErrorBox = function () {
        var validationMessage = self.dom.errorBox.find('p');
        self.dom.errorBox.css({'display': 'none'});
        $(validationMessage).remove();
    };

    self.renderLightbox = function() {
      self.dom.close = self.dom.modal.find('.close');
      self.dom.body.append(self.dom.modal);
      self.dom.dialog = self.dom.modal.find('.modal-dialog');
      self.attachLightboxHandlers();
      self.dom.modal.modal('show');
    };

    self.attachLightboxHandlers = function() {
      self.dom.body.on('click', '.close', self.closeModal);
      self.dom.close.on('click', self.closeModal);
      self.dom.modal.on('show.bs.modal', function() {
        $(this).find(':focusable').first().focus();
      });
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

    self.closeModal = function() {
      self.dom.modal.modal('hide');
    };

    self.onClose = function() {
      self.dom.body.focus();
      // TODO -- Integration task - set cookie so lightbox isn't displayed once this has been dismissed
    };

    self.init();
  };

})(jQuery);
(function($){

  $(document).ready(function(){
    new U.helpAnimateContent();
  });

  U.helpAnimateContent = function() {
    var self = this;

    self.cacheSelectors = function() {
      self.dom = {};
      self.dom.topLevel = $('body, html');
      self.dom.viewActivity = $('.activity-action');
      self.dom.listElementWrapper = $('.list-element-wrapper');
      self.dom.listElementOuterWrapper = $('.list-element-outer-wrapper');
    };

    self.init = function() {
      self.cacheSelectors();
      self.setModel();
      self.attachHandlers();
    };

    self.setModel = function() {
      self.model = {
        indexSelected: undefined,
        initListHeight: undefined,
        newContentHeight: undefined,
        transcriptHeight: undefined,
        nextNewElement: undefined,
        coordsTop: undefined
      };
    };

    self.attachHandlers = function() {
      self.dom.viewActivity.on('click touchstart', self.getPosition);
    };

    self.cacheTranscriptSelectors = function() {
      self.dom.transcriptVideoContainer = $('.webinar-video');
      self.dom.transcriptWrap = self.dom.transcriptVideoContainer.find('.transcript-wrap');
      self.dom.transcriptContainer = self.dom.transcriptVideoContainer.find('.transcript-container');
      self.dom.transcriptButton = self.dom.transcriptContainer.find('.read-more p');
      self.dom.topLevel.on('click', '.read-more p', self.triggerTranscriptHeight);
    };

    self.cacheAnimationBlockSelectors = function() {
      self.dom.outerContentWrapper = $('.help-content-wrapper');
      self.dom.newContent = $('.help-action-content');
      self.dom.newContentSubSection = self.dom.newContent.find('.new-content-section');
      self.dom.newContentHeader = self.dom.newContent.find('header');
      self.dom.newContentMain = self.dom.newContent.find('.new-content-main');
      self.dom.newContentFooter = self.dom.newContent.find('footer');
      self.dom.doneThisNew = self.dom.newContent.find('.done-this');
      self.dom.skipThisNew = self.dom.newContent.find('.skip-this');
    };

    self.attachAnimationHandlers = function() {
      self.dom.doneThisNew.on('click touchstart', self.returnToList);
      self.dom.skipThisNew.on('click touchstart', self.returnToList);
    };

    self.getPosition = function(e) {
      e.preventDefault();
      var element = $(this),
        initialParent = element.parents('.list-element-wrapper'),
        parentOuterWrapper = element.parents('.list-element-outer-wrapper'),
        offset = initialParent.position(),
        coordsLeft = offset.left,
        coordsTop = offset.top;

      self.model.coordsTop = coordsTop;

      self.cacheAnimationBlockSelectors();

      self.setCurrentNewContent();
      self.attachAnimationHandlers();

      self.model.initListHeight = self.dom.outerContentWrapper.height();

      self.model.indexSelected = self.dom.listElementOuterWrapper.index(parentOuterWrapper);

      initialParent.addClass('fadeOutInitContent');
      self.dom.newContent.css({"top": coordsTop, "left": coordsLeft});
      self.dom.newContentWrapper.css({"display": "block"});
    };

    self.setCurrentNewContent = function() {
      self.dom.newContentWrapper = $('.help-action-content-wrapper');
      self.model.nextNewElement = self.dom.newContentWrapper.clone();
      self.getNewContentHeight();
      self.animateBlock();
    };

    self.getNewContentHeight = function() {
      self.dom.newContentWrapper.addClass('get-height');
      var subSectionHeight = self.dom.newContentMain.outerHeight(),
          headerHeight = self.dom.newContentHeader.outerHeight(),
          footerHeight = self.dom.newContentFooter.outerHeight(),
          totalHeight = subSectionHeight + headerHeight + footerHeight + 80;

      self.model.newContentHeight = totalHeight;
      self.dom.newContentWrapper.removeClass('get-height');
    };

    self.animateBlock = function() {
      var tempHeight = self.model.newContentHeight + self.model.coordsTop;

      self.animateOuterWrapper();
      self.dom.newContentWrapper.addClass('initialize-animate');
      self.dom.outerContentWrapper.addClass('resize');
      self.dom.outerContentWrapper.css({"height": tempHeight});
      self.dom.newContent.addClass('animating');

      $('.animating').on('animationend webkitAnimationEnd oAnimationEnd MSAnimationEnd', function() {
        self.setNewContentHeight();
      });

      setTimeout(function(){
        self.dom.newContent.css({"left": 0});
      }, 400);

      self.bridgeToNewContentTransition();

    };

    self.animateOuterWrapper = function() {
      self.dom.outerContentWrapper.addClass('resize');
    };

    self.setNewContentHeight = function() {
      self.dom.outerContentWrapper.css({"height": self.model.newContentHeight});
    };

    self.bridgeToNewContentTransition = function() {
      setTimeout(function() {
        self.removeOldContent(); //after initial animation begins.
      }, 500);

      // new state.
      self.setNewContentState();
    };

    self.removeOldContent = function() {

      self.dom.listElementOuterWrapper.fadeOut('fast');

      self.animateToTop();
    };

    self.setNewContentState = function() {
      self.dom.newContentSubSection.css({"display": "block"});
      self.cacheTranscriptSelectors();

      setTimeout(function() {
        self.setVisibility();
      }, 500);
    };

    self.setVisibility = function() {
      self.dom.newContentWrapper.addClass('show');
      setTimeout(function() {
        self.dom.newContentSubSection.css({"opacity": 1});
      }, 500);
    };

    self.animateToTop = function() {
      var position = self.dom.outerContentWrapper.offset(),
          newPositionTop = position.top - 39;

      self.dom.topLevel.animate({scrollTop: newPositionTop }, 50);
      self.dom.newContent.css({"top": 0});
      self.dom.newContent.addClass('animateToTop');
    };

    self.returnToList = function(e) {
      e.preventDefault();
      var element = $(this),
          currentListItem = self.dom.listElementOuterWrapper[self.model.indexSelected],
          currentItemWrapper = $(currentListItem).find('.list-element-wrapper'),
          currentButton = $(currentItemWrapper).find('.activity-action');

      self.dom.newContentWrapper.hide();
      self.dom.listElementOuterWrapper.show();

      if (element.hasClass('done-this')) {
        $(currentItemWrapper).addClass('done');
        currentButton.text('View Activity');
        if ($(currentItemWrapper).hasClass('skipped')) {
          $(currentItemWrapper).removeClass('skipped');
        }
      }

      if (element.hasClass('skip-this')) {
        $(currentItemWrapper).addClass('skipped');
        currentButton.text('Start This Activity');
        if ($(currentItemWrapper).hasClass('done')) {
          $(currentItemWrapper).removeClass('done');
        }
      }

      if ($(currentItemWrapper).hasClass('hover')) {
        $(currentItemWrapper).removeClass('hover');
      }

      self.dom.outerContentWrapper.css({"height": self.model.initListHeight});

      self.resetAnimationClasses();
      self.replaceNewContentWithClone();
    };

    self.resetAnimationClasses = function() {
      self.dom.listElementWrapper.removeClass('fadeOutInitContent');
      self.dom.outerContentWrapper.removeClass('resize');
    };

    self.replaceNewContentWithClone = function() {
      self.dom.newContentWrapper.replaceWith(self.model.nextNewElement);
    };

    self.triggerTranscriptHeight = function(e) {
      e.preventDefault();
      self.transcriptAnimateHeight();
      var heightWithTranscript = self.model.newContentHeight + self.model.transcriptHeight;

      if (self.dom.transcriptContainer.hasClass('open')) {
        self.transcriptAnimateHeight();
        self.dom.outerContentWrapper.css({"height": heightWithTranscript});
      } else {
        self.dom.outerContentWrapper.css({"height": self.model.newContentHeight});
      }

    };

    self.transcriptAnimateHeight = function() {
      var transcriptHeight = $(self.dom.transcriptWrap).height();
      self.model.transcriptHeight = transcriptHeight;
    };

    self.init();
  };

})(jQuery);
(function($){

  $(document).ready(function() {
    new U.supportHeading();
  });

  U.supportHeading = function() {
    var self = this;

    self.cacheSelectors = function() {
      self.dom = {};
      self.dom.moreActionPlans = $('#more_action_plans');
    };

    self.init = function() {
      self.cacheSelectors();
      self.applyUniform();
    };

    self.applyUniform = function() {
      U.uniformSelects(self.dom.moreActionPlans);
    };

    self.init();
  };

})(jQuery);
(function($) {

  $(document).ready(function() {
    var uniformElements = [
      '.selector',
      '.checker',
      '.checked'
    ];

    new U.Global.readspeakerUniform(uniformElements);
  });

})(jQuery);










