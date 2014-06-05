/*
Keyboard Access Module is a wrapper for focus and blur events needed for keyboard accessibility and triggers
the callbacks passed to the module.
 */


(function($){
    U.keyboard_access = function(options) {
        var self = this;

        self.settings = {
            focusElements: null, // Accepts jQuery object or selector for handling delegated events
            blurElements: null, // Accepts jQuery object or selector for handling delegated events
            focusHandler: function() {},
            blurHandler: function() {},
            forceBlur: false,
            blurDelay: 100,
            body: $(document.body),
            eventNamespace: null
        };

        self.init = function(){
            self.settings = $.extend(self.settings, options);
            self.attachHandlers();
        };

        self.attachHandlers = function() {
            var focusEvent = self.getEventName('focus');
            var blurEvent = self.getEventName('blur');

            // Though one element type should always be passed, both arguments are optional
            // If a selector is passed, we delegate the event handler off of the body.
            if (typeof(self.settings.focusElements) === 'string') {
                self.settings.body.on(focusEvent, self.settings.focusElements, self.focusHandler);
            } else if (self.settings.focusElements) {
                self.settings.focusElements.on(focusEvent, self.focusHandler);
            }

            if (typeof(self.settings.blurElements) === 'string') {
                self.settings.body.on(blurEvent, self.settings.blurElements, self.blurHandler);
            } else if (self.settings.blurElements) {
                self.settings.blurElements.on(blurEvent, self.blurHandler);
            }
        };

        self.focusHandler = function(e) {
            self.settings.focusHandler(e);
        };

        self.getEventName = function(eventBaseName) {
            return self.settings.eventNamespace ? eventBaseName + '.' + self.settings.eventNamespace : eventBaseName;
        };

        // The blur handler wraps the passed callback in a 100ms timeout
        // This allows us to identify the next focused element (and pass it to the callback)
        // The callback is not triggered if the blurred element is the body.
        self.blurHandler = function(e) {

            setTimeout(function() {
                var newTarget = $(document.activeElement);

                if (self.settings.forceBlur || !newTarget.is('body')) {
                    self.settings.blurHandler(e, newTarget);
                }
            }, self.settings.blurDelay);
        };

        self.detachHandlers = function() {
            var focusEvent = self.getEventName('focus');
            var blurEvent = self.getEventName('blur');

            // Though one element type should always be passed, both arguments are optional
            // If a selector is passed, we delegate the event handler off of the body.
            if (typeof(self.settings.focusElements) === 'string') {
                self.settings.body.off(focusEvent, self.settings.focusElements, self.focusHandler);
            } else if (self.settings.focusElements) {
                self.settings.focusElements.off(focusEvent, self.focusHandler);
            }

            if (typeof(self.settings.blurElements) === 'string') {
                self.settings.body.off(blurEvent, self.settings.blurElements, self.blurHandler);
            } else if (self.settings.blurElements) {
                self.settings.blurElements.off(blurEvent, self.blurHandler);
            }
        };

        self.init();
    };

})(jQuery);
/**
 * Definition for the shareSave javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.shareSave();
  });

  U.shareSave = function() {
    var self = this;

    $('.icon-share').click(function() {

      jQuery('.share-save-social-icon .toggle').toggle();
      jQuery(this).toggleClass('active');
      jQuery(this).parent('.share-save-icon').toggleClass('is-open');
    });

    $('.icon-share-dd').click(function() {

      jQuery('.share-save-dd-social-icon .toggle-dd').toggle();
      jQuery(this).toggleClass('active-dd');
      jQuery(this).parent('.share-save-dd-icon').toggleClass('is-open-dd');
    });
    
    return this;
  };
})(jQuery);
/**
 * Abstracts application of uniform styling and related change events
 */

(function($){
    U.uniformSelects = function($selects, options, changeCallback){
        var options = options || {};

        self.cacheSelectors = function() {
            self.dom = {};
            self.dom.selects = $selects;
        };

        self.init = function() {
            self.cacheSelectors();
            self.dom.selects.uniform(options);

            self.attachHandlers();
        };

        self.attachHandlers = function() {
            self.dom.selects.on('change keyup', self.selectChange);
        };

        self.selectChange = function(e) {
            var el = $(e.currentTarget);

            if (typeof(changeCallback) === 'function') {
                changeCallback();
            }

            el.find('option:selected').each(function(){
                if ( el.val() === "" ){
                    el.parents('.selector').removeClass('selected');
                }
                else {
                    el.parents('.selector').addClass('selected');
                }
            });
        };

        self.init();
    };
})(jQuery);
/**
 * Created by cat on 3/17/14.
 */

(function($){

  $(document).ready(function(){
    new U.skipLink();
  });

  U.skipLink = function() {
      var self = this;

      self.pageSections = ['Dashboard', 'Feature', 'Toolbar', 'Sidebar', 'Content', 'Comments'];

      self.init = function() {
        self.cacheDom();
        self.setModel();
        self.buildSkipList();
        self.cacheDelegatedDom();
        self.attachHandlers();
      };

      self.setModel = function() {
        selectors = [];
        self.model = {};
        self.model.skipLinks = [];

        for (var i = 0; i < self.pageSections.length; i++) {
          var item = {};

          item.contentType = self.pageSections[i];
          item.selector = '.skiplink-' + item.contentType.toLowerCase();
          item.element = $(item.selector);
          item.linkId = item.contentType + 'link';
          item.linkHref = '#' + item.linkId;
          item.subNavText = 'Skip to ' + item.contentType;

          /* Storing index on element so we can quickly find skiplink data for each element when building list */
          item.element.data('skipLinkIndex', i);
          self.model.skipLinks.push(item);

          if (item.element.length) {
            selectors.push(item.selector);
          }
        }

        /* Building separate query for collected skip link elements on page */
        /* This guarantees order will match order that items appear in the DOM */
        self.model.skipLinkCollection = $(selectors.join(','));
      };

      self.cacheDom = function() {
        self.dom = {};
        self.dom.body = $(document.body);
      };

      self.cacheDelegatedDom = function() {
        self.dom.skipList = $('.skip-list');
      };

      self.attachHandlers = function() {
        self.dom.body.on('click', '.secondary-navigation-link', self.skipBackToMainLinkMenu);
      };

      self.buildSkipList = function() {
        var skipList = $('<ul class="skip-list"></ul>');

        self.dom.body.prepend(skipList);


        self.model.skipLinkCollection.each(function(i) {
          var el = $(this),
              index = el.data('skipLinkIndex'),
              item = self.model.skipLinks[index];

          skipList.append('<li><a class="skip-link" href="'+ item.linkHref +'" tabindex="1">' + item.subNavText + '</li>');
          item.element.prepend('<div class="skip-link-secondary"><a href="#" class="skip-link secondary-navigation-link" id="'+ item.linkId +'">Back to Navigation</a></div>');
        });
      };

      self.skipBackToMainLinkMenu = function(e) {
          self.dom.skipList.find(':focusable').eq(0).focus();
      };

      self.init();
  };

})(jQuery);
(function($){

  U.actionButtons = function(container){
    var self = this,
      buttons = container.find('button'),
      buttonOne = container.find('button.icon-plus'),
      buttonTwo = container.find('button.icon-bell'),
      buttonCopy = $('.action-button-hidden'),
      prevFocus = null,
      iconBell = null,
      iconPlus = null,
      nextNonButtonFocusableElement = null,
      findNextFocus = function(e) {
        var nextFocus = prevFocus.next();

        if (prevFocus.is(iconBell)){
          $(iconBell).focus();
        }
        else if (prevFocus.is(iconPlus)){
          $(iconPlus).focus();
        }
      },
      deferFocus = function(e) {
        var element = $(e.currentTarget),
            buttonCopy = $('<button class="action-button-hidden" tabindex="1"></button>');
        e.preventDefault();
        element.after(buttonCopy);
        var buttonContainer = element.parent(),
            nextMainElement = buttonContainer.next();
        nextNonButtonFocusableElement = nextMainElement.find(':focusable');

        iconPlus = element.parent().find('.icon-plus');
        iconBell = element.parent().find('.icon-bell');
        prevFocus = $(document.activeElement);
        buttonCopy.focus();
      },
      toggleActiveClass = function(e) {
        element = $(e.currentTarget);
        e.preventDefault();

        if (element.hasClass('active')) {
          element.removeClass('active');
        } else {
          element.addClass('active');
        }
        deferFocus(e);
      };

    buttonTwo.on('click', toggleActiveClass);
    buttonOne.on('click', toggleActiveClass);
    container.on('blur', '.action-button-hidden', function(e) {
      $(this).remove();
      findNextFocus();
    });

  };

})(jQuery);
/**
 * Definition for the formRefactor javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.formRefactor();
  });

  U.formRefactor = function() {
    var self = this;

    // Check for .convio-form - Only runs if convio form exists
    if( jQuery('.convio-form').length !== 0){

      // Calls uniform on the form elements
      jQuery('input[type=text], input[type=radio], input[type=button], input[type=submit], input[type=reset], textarea, select').uniform();

      // Check for .action-alert - Only runs on AD 10
      if( jQuery('.action-alert').length !== 0){

        // Loops through each label element, grabs label text and puts it in input placeholder, then hides label
        jQuery('.label-field-wrap').each(function(i, el){

          // Get placeholder text from corresponding label
          var labelWrapper = jQuery(this);
          var labelEl = labelWrapper.find('.label-text');
          var labelText = labelEl.html();

          // Get input/select elements
          var inputEl = labelWrapper.find('.field-wrap input');
          var selectEl = labelWrapper.find('.field-wrap .selector select');

          // Get inputs requiring Convio messaging
          var subjectLine = labelWrapper.find('#subject');
          var personalized = labelWrapper.find('#middle');


          // Apply label text as placeholders
          if(inputEl.length !== 0){
            inputEl.attr('placeholder', labelText);
          }else if(selectEl.length !== 0){
            if(selectEl.prev('span').html() === ''){
              selectEl.prev('span').html(labelText);
              selectEl.find('option:first').html(labelText);
            }
          }

          // Restore 'Subject' message on correct loop through
          if(subjectLine.length > 0) {
            labelWrapper.find('.label-text').css({
              'display' : 'block',
              'margin-bottom' : '10px'
            });
          }
          // Restore 'Personalize your message' message on correct loop through
          if(personalized.length > 0) {
            labelWrapper.find('.label-text').css({
              'display' : 'block',
              'margin-bottom' : '10px'
            });
          }
        });



        // Add question numbers to the left of form
        var formNumCount = 0;
        jQuery('h3.styled').each(function(){
          formNumCount++;
          jQuery('<span class="form-number">' + formNumCount + '</span>').insertBefore(jQuery(this));
        });

      } // Only on AD 10

      // Check for .petition-form - Only runs on AD 4
      if( jQuery('.petition-form').length !== 0){

        jQuery(".convio-content .uniform-input, .selector").not('.button').each(function(){

          // Get placeholder text from corresponding label
          var uniformInput = jQuery(this);
          var uniformInputName = uniformInput.attr('name');
          var inputLabel = jQuery("label[for=" + uniformInputName + "]");
          inputLabel.children('span').remove();
          var labelText = inputLabel.text();

          // If input, fill placeholder with label text
          if( uniformInput.hasClass('uniform-input') ){

            // Replaces Placeholder with Label
            uniformInput.attr('placeholder', labelText);

            // Removes predefined values such as in Email, to show placeholder
            uniformInput.val('');

            // If dropdown list, fill text and first option with label text
          }else{
            if(uniformInput.children('span').html() === ''){
              // Change Label to grab correct item
              uniformInputName = uniformInput.children('select').attr('name');
              inputLabel = jQuery("label[for=" + uniformInputName + "]");
              inputLabel.children('span').remove();
              labelText = inputLabel.text();

              // Apply changes to first Select element (in Uniform)
              uniformInput.children('span').html(labelText);
              uniformInput.children('select').find("option:first").html(labelText);
            }
          }
          // Keep robot checker hidden
          jQuery('#denySubmit').hide();

          // Move input items out of table structure to apply css formatting
          //--> jQuery('.convio-form form').append(uniformInput);
        });

        // Move button out of table structure
        jQuery('.convio-form form').append(jQuery('#uniform-ACTION_SUBMIT_SURVEY_RESPONSE'));

        // Hide labels and extra table markup
        //--> jQuery('.convio-form table').hide();

      } // Only on AD 4

      // Check for .petition-sign-email - Only runs on AD 3
      if( jQuery('.petition-sign-email').length !== 0){
        var consEmailLabel = jQuery('label[for="cons_email"]');
        consEmailLabel.find('span').remove();
        jQuery('#cons_email').attr('placeholder', consEmailLabel.text());
        jQuery('.petition-sign-email form').append(jQuery('#cons_email'));
        jQuery('.petition-sign-email form').append(jQuery('#uniform-ACTION_SUBMIT_SURVEY_RESPONSE'));
        //jQuery('.petition-sign-email table').hide();
      } // Only on AD 3

      // Check for .survey-form - Only runs on AD 7
      if( jQuery('.survey-form').length !== 0){

        // Set class for container that holds table and enclosed input elements to be extracted
        jQuery('#cons_first_name').parents('.old-school').addClass('input-container');

        // Loop through each input element on the page
        jQuery(".convio-content .uniform-input").not('.button').each(function(){

          // Set this to uniformInput variable
          var uniformInput = jQuery(this);

          // Set uniformInput name (used for getting corresponding label)
          var uniformInputName = uniformInput.attr('name');

          // Get corresponding label
          var inputLabel = jQuery("label[for=" + uniformInputName + "]");

          // Check if input is the one item that doesn't fit below structure mold
          if( !uniformInput.is('#2003_1981_34_2086') ){

            // Get placeholder text from corresponding label
            inputLabel.children('span').remove();

            // Retrieve label text
            var labelText = inputLabel.text();

            // Replaces Placeholder with Label
            uniformInput.attr('placeholder', labelText);
          }

          // Removes predefined values such as in Email, to show placeholder
          uniformInput.val('');

          // Keep robot checker hidden
          jQuery('#denySubmit').hide();

          if( !uniformInput.is('#2003_1981_34_2086') ){
            // Move input items out of table structure to apply css formatting
            jQuery('.input-container').append(uniformInput);
          }
        });

        // Select select object, label, and label text
        var selectStateEl = jQuery('#cons_state');
        var stateName = selectStateEl.attr('name');
        var stateLabel = jQuery("label[for=" + stateName + "]");
        stateLabel.children('span').remove();
        var stateLabelText = stateLabel.text();

        // Apply placeholder
        selectStateEl.find("option:first").html(stateLabelText);
        selectStateEl.parents('.selector').children('span').html(stateLabelText);

        // Append after city input
        selectStateEl.parents('.selector').insertAfter('#cons_city');

        // Hide labels and extra table markup
        jQuery('.input-container table').hide();

        // Hide extra buttons
        jQuery('#uniform-reset, #uniform-ACTION_CANCEL_RESPONSE_SUBMIT').hide();

        // Add question numbers to the left of form
        var questionNumCount = 0;
        var questionGroup = jQuery('.surveyLegend.Explicit');
        questionGroup.each(function(){
          questionNumCount++;
          jQuery('<div class="question-number"><span>' + questionNumCount + '</span></div>').insertBefore(jQuery(this).children('span'));
        });

        questionGroup.parents('fieldset').find('input[type=checkbox]').uniform();

      } // Only on AD 7

      // Check for .letter-editor-zip-form - Only runs on AD 15
      if( jQuery('.letter-editor-zip-form').length !== 0){

        // Set zipcode to uniformInput variable
        var zipInput = jQuery('#zipCode');
        var zipEl = zipInput.parents('#zipcode-wrap');
        var zipForm = zipInput.parents('form');

        // Add placeholder to zipcode element
        zipInput.attr({placeholder: 'Zip Code'});

        // Move label text to form root into an h3
        zipForm.append('<h3>' + jQuery("label[for=" + zipInput.attr('name') + "]").children('.label-text').text() + '</h3>');

        // Move Zipcode fieldset out to form root
        zipForm.append(zipEl);

        // Move submit button to form root
        zipForm.append(jQuery('#uniform-pstep_next'));

        // Hide rest of non form markup
        //zipElForm.children('div').hide();

      } // Only on AD 15

    } // End .convio-form check / Convio Form Functions

    // Check for .spread-word-form - Only runs on AD 5
    if (jQuery('.spread-word-form').length !== 0){

      // Set form root
      var formRoot = jQuery('.spread-word-form form');

      // Loop through each input element on the page
      jQuery(".convio-content .uniform-input, .uniform").not('.button').each(function(){

        // Set this to uniformInput variable
        var uniformInput = jQuery(this);

        // Set uniformInput name (used for getting corresponding label)
        var uniformInputName = uniformInput.attr('name');

        // Get corresponding label
        var inputLabel = jQuery("label[for=" + uniformInputName + "]");

        // Get placeholder text from corresponding label
        inputLabel.children('span').remove();

        // Retrieve label text
        var labelText = inputLabel.text();

        // Replaces Placeholder with Label
        uniformInput.attr('placeholder', labelText);

        // Removes predefined values such as in Email, to show placeholder
        uniformInput.val('');

        // Keep robot checker hidden
        jQuery('#denySubmit').hide();

        // If instruction NoteText exists, put that into placeholder
        if( uniformInput.is('#taf_send') ){

          // Set notetext before input is moved away
          var noteText = uniformInput.siblings('.NoteText');

          // Retrieve label text
          labelText = noteText.text();

          // Replaces Placeholder with Label
          uniformInput.attr('placeholder', labelText);

          // Move input item out to form root
          formRoot.append(uniformInput);

        // If there's no notetext, just move the input item to form root
        }else{

          // Move input item out to form root
          formRoot.append(uniformInput);
        }
      });

      // Move submit button out of table
      formRoot.append(jQuery('#uniform-send'));

      // Hide extra table structure (table)
      formRoot.children('table').hide();

      // Hide close button
      jQuery(".Button[name=close_preview]").parents('.button').hide();

    } // Only on AD 5

    // Check for .spread-word-form - Only runs on AD 13
    if (jQuery('.resource-form').length !== 0){

      // Set form root
      var resourceFormRoot = jQuery('.resource-form form');

      // Loop through each input element on the page
      jQuery(".convio-content .uniform-input").not('.button').each(function(){

        // Set this to uniformInput variable
        var uniformInput = jQuery(this);

        // Set uniformInput name (used for getting corresponding label)
        var uniformInputName = uniformInput.attr('name');

        // Get corresponding label
        var inputLabel = jQuery("label[for=" + uniformInputName + "]");

        // Get placeholder text from corresponding label
        inputLabel.children('span').remove();

        // Retrieve label text
        var labelText = inputLabel.text();

        // Replaces Placeholder with Label
        uniformInput.attr('placeholder', labelText);

        // Removes predefined values such as in Email, to show placeholder
        uniformInput.val('');

        // Keep robot checker hidden
        jQuery('#denySubmit').hide();

        // Move input item out to form root
        //resourceFormRoot.append(uniformInput);
      });

      // Move Checkbox and Associated Label out of table
      var resourceCheckBox = jQuery('.checker');
      resourceFormRoot.append(resourceCheckBox);
      resourceFormRoot.append( jQuery("label[for=" + resourceCheckBox.find('input').attr('name') + "]") );

      // Move submit button out of table
      resourceFormRoot.append(jQuery('#uniform-ACTION_SUBMIT_SURVEY_RESPONSE'));

      // Move form to root of convio-form
      var convioFormRoot = jQuery('.convio-form');
      convioFormRoot.append(resourceFormRoot);

      // Hide extra table structures
      //resourceFormRoot.find('table').hide();
      //convioFormRoot.find('table').hide();

      // Hide Title
      //resourceFormRoot.find('.ObjTitle').hide();

    } // Only on AD 13

    // Check for .send-letter - Only runs on AD 16
    if (jQuery('.send-letter').length !== 0){

      jQuery('.uniform-input.text, .selector, textarea').each(function(){

        // Set this to uniformInput variable
        var uniformInput = jQuery(this);

        var uniformInputName;
        // uniformInput is select dropdown
        if( uniformInput.hasClass('selector')){

          // Set uniformInput name (used for getting corresponding label)
          uniformInputName = uniformInput.find('select').attr('name');

        // uniformInput is text input or textarea
        }else{

          // Set uniformInput name (used for getting corresponding label)
          uniformInputName = uniformInput.attr('name');

        }

        // Get corresponding label
        var inputLabel = jQuery("label[for=" + uniformInputName + "]");

        // Get placeholder text from corresponding label
        var labelText = inputLabel.children('.label-text').text();

        // uniformInput is select dropdown
        if( uniformInput.hasClass('selector')){

          // Apply placeholder
          uniformInput.find('select').attr('placeholder', labelText);
          uniformInput.find("option:first").html(labelText);
          uniformInput.children('span').html(labelText);

        // uniformInput is text input
        }else{

          // Replaces Placeholder with Label
          uniformInput.attr('placeholder', labelText);

        }

      });

      // Add question numbers to the left of form
      var firstGroup = jQuery('#recipients');
      var secondGroup = jQuery('#info');
      var thirdGroup = jQuery('#letter-talking-points-wrap');

      jQuery('<div class="title-number"><span>1</span></div>').insertBefore(firstGroup);
      jQuery('<div class="title-number"><span>2</span></div>').insertBefore(secondGroup);
      jQuery('<div class="title-number"><span>3</span></div>').insertBefore(thirdGroup);

      // titleGroup.each(function(){
      //   titleCount++;
      //   jQuery('<div class="title-number"><span>' + titleCount + '</span></div>').insertBefore(jQuery(this));
      // });

    } // Only on AD 16

    // Call uniformSelects on this page
    U.uniformSelects(jQuery('.convio-form').find('select'));

    // IE 9 placeholder fallback
    $('input, textarea').placeholder();

    // Check if hero text was placed outside of the hero from WYSIWYG
    // If so, move it to the proper location
    if( jQuery('.understood_alert-title').length !== 0){
      var heroTitle = jQuery('.understood_alert-title');
      var heroTextArea = jQuery('.text-container');
      heroTextArea.append(heroTitle);
    }

    jQuery('.checker input[type=checkbox]').each(function(){
      var checkboxlabelEl = jQuery("label[for=" + jQuery(this).attr('id') + "]");
      checkboxlabelEl.addClass('checkbox-label');
    });


    return this;
  };
})(jQuery);
/**
 * Definition for the progressmeter javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.progressMeter();
  });

  U.progressMeter = function() {
    var self = this,
      convioProgressHTML= '',
      uProgressHTML;
    // identify HTML block
    $('img').each(function(i, el){
      var thisSource = $(el).attr('src');
      if(thisSource.indexOf('progress') !== -1) {
        $(el).parent().addClass('convio_progress-block');
        convioProgressHTML = $(el).parent().html();
      }
    });
    // get values from convio output
    if(convioProgressHTML.length !== 0) {
      var firstBlock = convioProgressHTML.split('Progress:')[2],
        percentStringSymbol = firstBlock.split('<br>')[0],
        percentString = percentStringSymbol.split('%')[0],
        firstRemainder = firstBlock.split('<br>')[1],
        secondBlock = firstRemainder.split(':')[1],
        completeString = secondBlock.split('&nbsp;')[0],
        goalString = firstRemainder.split(':')[2],
        meterWidth = 90; // css 90% = 0% complete
      // insert values in new HTML
      uProgressHTML = [
        '<!-- progress meter html -->',
        '<h4>Petition Signatures</h4>',
        '<div class="convio_progress-graphic">',
          '<ul class="graphic-background">',
            '<li class="graphic-left-block">',
              '<div class="graphic-left"></div>',
            '</li>',
            '<li class="graphic-center-block">',
              '<div class="graphic-center"></div>',
            '</li>',
            '<li class="graphic-right-block">',
              '<div class="graphic-right"></div>',
            '</li>',
          '</ul>',
          '<div class="graphic-slide">',
            '<div class="graphic-slide-marker">',
              '<span id="marker-data">',
                percentString,
                '<span class="marker-symbol">%</span>',
              '</span>',
            '</div>',
            '<div class="graphic-slide-bar"></div>',
          '</div>',
        '</div>',
        '<div class="convio_progress-stats">',
          '<ul class="stats-list">',
            '<li class="stats-item percent">',
              '<span class="stats-data">',
                percentString,
                '<span class="marker-symbol">%</span>',
              '</span>',
              '<span class="stats-detail">Progress</span>',
            '</li>',
            '<li class="stats-item total">',
              '<span class="stats-data">',
                completeString,
              '</span>',
              '<span class="stats-detail">Signatures</span>',
            '</li>',
            '<li class="stats-item goal">',
              '<span class="stats-data">',
                goalString,
              '</span>',
              '<span class="stats-detail">Goal</span>',
            '</li>',
          '</ul>',
        '</div>'
      ].join('\n');
      // replace with new HTML
      $('.convio_progress-block').html(uProgressHTML);
      // position according to percentage
      if(percentString > 92 ) {
        meterWidth = 8; // css 5% = 100% complete view
      } else if(percentString > 5 ) {
        meterWidth = (100 - percentString);
      }
      $('.graphic-slide').css('width', meterWidth + '%');
      // replace caption if alert page
      $('#action-alert .stats-item.total').find('.stats-detail').html('Alerts taken');
    }
    return this;
  };
})(jQuery);









/**
 * Uses sprockets to load individual module files (must be first line of file).
 * @see {@link https://digitalpulp.atlassian.net/browse/UN-1559}
 */

;
