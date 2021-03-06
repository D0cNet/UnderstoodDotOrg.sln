/**
 * Definition for the account-notification-tabs javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.accountNotificationTabs();
  });

  U.accountNotificationTabs = function() {
    var self = this;

    /**
     * Initialize module on page load.
     * @return {object} this instance
     */
    this.initialize = function() {

      var uniform_elements = [
        '.account-notification-tabs input[type=textfield]',
        '.account-notification-tabs select',
        '.account-notification-tabs input[type=radio]'
      ].join(',');

      $(uniform_elements).uniform();

      var toggle_switch = $(
        '<div class="switch-wrapper">' +
          '<span class="btn-toggle btn-left"><button>No</button></span>' +
          '<span class="btn-toggle btn-right"><button>Yes</button></span>' +
        '</div>'
      );

      // Add toggle switches.
      $('.toggle-wrapper input[type=checkbox]').ezMark();
      $('.toggle-wrapper .ez-checkbox').append(toggle_switch);

      $('.toggle-wrapper .ez-checkbox').find('.btn-toggle').on('click', function(e) {
        e.preventDefault();

        // This will work in all browsers except ie8
        //$(this).parent().click();

        // This will work in all browsers including ie8
        $(this).parent().parent().toggleClass('ez-checked');
      });

    };



    return this.initialize();
  };

})(jQuery);
/**
 * TYCE Steps
 */

/**
 * responsiveSelection()
 * use a form <select> for mobile selection, and use custom form elements for desktop, with hidden field
 * adapted from guideMeOverlay()
 */

(function($){

  U.responsiveSelection = function(options){

    var self = this;

    defaults = {
      el : ''
    };

    options = $.extend(defaults, options);

    self.init = function(){

      self.$el = $(options.el);

      self.$select = self.$el.find('select.reponsive-select-mobile');
      self.$full_options = self.$el.find('.reponsive-select-full-options');
      self.$full_input = self.$el.find('input.reponsive-select-full-input');

      if (!self.$select.length || !self.$full_options.length || !self.$full_input.length) {
        return false;
      }

      self.whichSelect();
      
      // Grades - Add to Hidden Form Field
      self.$full_options.find('button.grade').on('click', function(e){
        e.preventDefault();
        var $this = $(this);

        // give selected grade active class
        if (!$this.hasClass('active')) {
          self.$full_options.find('button.active').removeClass('active');
          $this.addClass('active');
          // give hidden field the value from the grade ID
          self.$full_input.val($this.attr('id'));
        }
        else {
          $this.removeClass('active');
          // clear hidden field value from the grade ID
          self.$full_input.val('');
        }

       this.blur();
      });
      
    };

    // TO DO: Reattach the detached on resize
    // use a form <select> for mobile grade selector, and use custom form elements for desktop, with hidden field
    // on mobile, detach the hidden field
    // on desktop, detach the select field
    // restore the hidden fields or select in respective viewport size

    self.whichSelect = function(){
      if(Modernizr.mq('(min-width: 650px)')){
        self.$select_detached = self.$el.find('select.reponsive-select-mobile').detach();
      } else {
        self.$full_input_detached = self.$el.find('input.reponsive-select-full-input').detach();
      }
    };

    if (options.el !== '') {
      self.init();
    }

  };

})(jQuery);


$(document).ready(function() {
  new U.responsiveSelection({
    el : '#tyce-step-1'
  });
});
/**
 * TYCE Player
 */


var TYCE = (function(){

  // Create vars
  var opts,
    videotype,
    currentstep,
    currentlang,
    nextstep = 0,
    numberofsteps,
    steps,
    isstarted,
    videoloaded = false,
    _player,
    APIModules,
    VP,
    experienceModule,
    contentModule,
    captionsModule,
    playertype,
    simulation,
    $playpause,
    $volume,
    $fullscreen,
    $steps,
    $tyceplayercontainer,
    $player,
    $modalbegin,
    $modalend,
    $tycemenu;
    

  // Initialize TYCE Experience
  function init(options){
    opts = options;
    videotype = Modernizr.ishardcoded ? 'hardcoded' : 'default';
    currentlang = $('html').attr('lang');
    currentstep = opts.start;
    numberofsteps = opts.steps.length;
    steps = opts.steps;

    $tycemenu = $('.icon-tyce-menu');

    $tycemenu.on('click', function(e){
      e.preventDefault();
      $('#header-page, #header-tyce').toggleClass('is-open');
    })

    // add modals for begin and end
    $modalbegin = $('.modal-begin');
    $modalend = $('.modal-end');
    // set end modal link to next url set in config
    $modalend.find('.button-close').attr('href', opts.next);

    $modalbegin.modal({ backdrop: 'static', show: false });
    $modalend.modal({ backdrop: 'static', show: false });

    // steps for experience
    $steps = $('.steps li');

    // player container 
    $tyceplayercontainer = $('.tyce-player-container');
    $player = $tyceplayercontainer.find('#player');
    $playerContent = $('.player-content');

    // player controls and events
    $playpause = $('.play-pause');
    $volume = $('li.volume');
    $fullscreen = $('li.fullscreen');
    $skip = $tyceplayercontainer.find('.btn-skip');
    $captionswitch = $('.captions .toggle');
    $helpToggle = $('.icon.help');
    $helpClose = $('.help-overlay .close');

    $('.slider').slider({ 
      orientation: "vertical",
      range: "min",
      slide: function( event, ui ) {
        VP.setVolume(ui.value / 100)
        console.log( ui.value / 100 );
      }
    });

    // This is not fully baked, as rules need to be established if we want to allow the user to
    // navigate to any step in the flow.
    // $steps.on('click', function(e){
    //   clicked_step = $steps.index(this);
    //   if(clicked_step !== currentstep){
    //     $steps.eq(currentstep).removeClass('is-active').addClass('has-played');
    //     $steps.eq(clicked_step).addClass('is-active');
    //     stepper(steps[clicked_step]);
    //     currentstep = clicked_step;
    //   }
    // });

    // click on play pause button
    $('.play-pause').on('click', function(){
      if($(this).attr('disabled')){ return false; }
      VP.getIsPlaying(playPauseVideo);
    });

    // volume events
    $volume.on({
      'mouseenter': function(){
        if($(this).hasClass('is-disabled')){ return false; };
        $('.volume-slider').show();
      },
      'mouseleave' : function(){
        if($(this).hasClass('is-disabled')){ return false; };
        $('.volume-slider').hide();
      },
      'click' : function(){
        // VP.mute();
      }
    });

    if($skip.length > 0){
      $skip.on('click', function(e){
        e.preventDefault();
        VP.getIsPlaying(playPauseVideo);
        nextStep();
      })
    }

    //helpOverlay init
    helpOverlay();

    //helpOverlay resize
    $(window).on('resize.player', helpOverlayDetect);

    // click on fullscreen button if browser supports it
    if(Modernizr.fullscreen){
    $fullscreen.on('click', function(e){
      e.stopPropagation();
      e.preventDefault();
      toggleFullScreen();
    });
    }

    $captionswitch.on('change', function(e){
      if($(this).prop('checked')){
        captionsModule.setCaptionsEnabled(true);
      } else {
        captionsModule.setCaptionsEnabled(false);
      }
    });

    // if experience hasn't started 
    if(!isstarted){

      // trigger resize to center modal
      // FIXME : This needs to be fixed as this shouldn't be necessary
      $(window).trigger('resize');

      // show modal
      $modalbegin.modal('show');

      // set active class of current step
      $steps.eq(opts.start).addClass('is-active');

      // run the stepper to start things up
      stepper(steps[currentstep]);


      // attach event to begin modal to hide it and play the video
      $modalbegin.find('.button').on('click', function(e){
        e.preventDefault();
        $modalbegin.modal('hide');
        isstarted = true;
        playVideo();
      });

    }

    // if a touch device is being used
    if(Modernizr.touch && Modernizr.mq('(max-width: 767px)') ) {
      hideAddressBar();
      window.onload = orientationChange;
      window.onorientationchange = orientationChange;
    }
    
  };


  function helpOverlay() {
    
    // detect for screen size, and give height to overlay.  Use this function for resize event.
    helpOverlayDetect();

    // help overlay toggle
    $helpToggle.on('click', function(){
      if ( !$playerContent.hasClass('help-open') ){
        $('.help-overlay').fadeIn();
        $playerContent.addClass('help-open');
        pauseVideo();
      }
      else {
        $('.help-overlay').fadeOut();
        $playerContent.removeClass('help-open');
        playVideo();
      }
    });

    // help overlay close button
    $helpClose.on('click', function(){
      $('.help-overlay').fadeOut();
      $playerContent.removeClass('help-open');
      playVideo();
    });

  };

  function helpOverlayDetect() {
    // only show help overlay over 768px
    if( Modernizr.mq('(min-width: 769px)') || !Modernizr.mq('only all')){
      // give height to help overlay
      $('.help-overlay').css('height', $playerContent.height() );
      // ensure overlay is open
      if ( $playerContent.hasClass('help-open') ){
        $('.help-overlay').show();
      }
    }
    else {
      $('.help-overlay').hide();
    }
  };

  // Determine what type of experience the step paseed is
  function stepper(step){

    switch (step.type) {
     
      // if it's a video
      case 'video' :

        // if video player isn't attached
        if(!videoloaded){
          attachVideo(step.vid[videotype]);
        } else {
          loadNextVideo(step.vid[videotype]);
        }

        $skip.show();

        $playpause.removeClass('is-disabled');
        $volume.removeClass('is-disabled');

        break;

      // if it's a simulation
      case 'sim' :

        if(playertype == 'html' && Modernizr.mq('(max-width: 767px)') ){
          $('html, body, form, #wrapper, #container-sim').css({
            'height': window.innerHeight,
            'overflow' : 'hidden'
          });
        }

        $playpause.addClass('is-disabled');
        $volume.addClass('is-disabled');

        $skip.hide();

        initSimulation();
      
        break;
  
      // if it's nothing
      default :
 
        console.log('Error, not a valid step type');

    }
 
  };

  // initialize and start the simulation
  function initSimulation(){

    if(SSGame){
      simulation = SSGame.current;
      showSimulation();
      startSimulation();
    }

    // attach callback to moveon event to run the next step and hide the sim and show the vid
    simulation.events.on('moveon', function() {
      hideSimulation();
      nextStep();
    });

    $playpause.attr('disabled', true);

  };

  // Attach video player
  function attachVideo(video){
    var playerData = { "playerID" : "3487815387001", "playerKey" : "AQ~~,AAAC6NDP1nE~,dOSiqHy89SmnUx7bUwnOZPk5WVUAmCja", "width" : "100%", "height" : "534", "videoID" : null };
    var playerTemplate = "<div style=\"display:none\"></div><object id=\"myExperience\" class=\"BrightcoveExperience\"><param name=\"bgcolor\" value=\"#FFFFFF\" /><param name=\"width\" value=\"{{width}}\" /><param name=\"height\" value=\"{{height}}\" /><param name=\"playerID\" value=\"{{playerID}}\" /><param name=\"playerKey\" value=\"{{playerKey}}\" /><param name=\"isVid\" value=\"true\" /><param name=\"isUI\" value=\"true\" /><param name=\"dynamicStreaming\" value=\"true\" /><param name=\"@videoPlayer\" value=\"{{videoID}}\"; /><param name=\"includeAPI\" value=\"true\"><param name=\"templateReadyHandler\" value=\"TYCE.onTemplateReady\"><param name=\"templateLoadHandler\" value=\"TYCE.onTemplateLoaded\"></object>";

    playerData.videoID = video;

    // populate the player object template
    var playerHTML = Mark.up(playerTemplate, playerData);

    // append player html to #player
    $('#player').append(playerHTML);

    // instantiate the player
    brightcove.createExperiences();

  };

  // Load next video
  function loadNextVideo(videoID){
    // if we're using the flash player
    if(playertype == 'flash'){
      VP.loadVideoByID(videoID);
    } else {
      var win = document.getElementById("myExperience").contentWindow
      win.postMessage({'funct' : 'loadvideo', 'id' : videoID}, "*");
    }
  };

  // play video currently loaded into player
  function playVideo(){
    // if the flash player is beign used
    if(playertype == 'flash'){

      // hack to hide the display name
      // http://docs.brightcove.com/en/video-cloud/smart-player-api/samples/update-media.html
      VP.getCurrentVideo(function(videoDTO){
        videoDTO.displayName = "";
        contentModule.updateMedia(videoDTO, function(newVideoDTO){
          VP.play();
        });
      });

    } else {
      // todo: need to test on ipad to see which events are possible      
      // var win = document.getElementById('myExperience').contentWindow
      // win.postMessage({'funct' : 'play'}, "*");
    }
  };

  // pause the video 
  function pauseVideo(){
    // if the flash player is beign used
    if(playertype == 'flash'){
      VP.pause();
    } else {
      // todo: need to test on ipad to see which events are possible
      // var win = document.getElementById('myExperience').contentWindow
      // win.postMessage({'funct' : 'pause'}, "*");
    }
  };

  function playPauseVideo(playing){
    if(playing){
      pauseVideo();
    } else {
      playVideo();
    }
  };

  // brightcove templatedLoaded
  function onTemplateLoaded(experienceID){
    // if the flash player is beign used
    if($('object#myExperience').length > 0 ){

      _player = brightcove.api.getExperience(experienceID);

      VP = _player.getModule(brightcove.api.modules.APIModules.VIDEO_PLAYER);
      
      experienceModule = _player.getModule(brightcove.api.modules.APIModules.EXPERIENCE);

      contentModule = _player.getModule(brightcove.api.modules.APIModules.CONTENT);

      captionsModule = _player.getModule(brightcove.api.modules.APIModules.CAPTIONS);

      videoloaded = true;
      
    }

  };

  // brightcove templateReady
  function onTemplateReady(e){
    playertype = e.target.experience.type;

    // if the flash player is beign used
    if(playertype == 'flash'){
      VP.addEventListener(brightcove.api.events.MediaEvent.COMPLETE, onMediaComplete);
      VP.addEventListener(brightcove.api.events.MediaEvent.CHANGE, onMediaChange);
      VP.addEventListener(brightcove.api.events.MediaEvent.PLAY, onMediaPlay);
      VP.addEventListener(brightcove.api.events.MediaEvent.STOP, onMediaStop);

      if(Modernizr.mq('(max-width: 767px)')) {
        $('#container-sim').appendTo('body');
      }

    } else if(playertype == 'html'){
      if(Modernizr.mq('(max-width: 767px)')) {
      $('#container-sim').appendTo('body');
    }
    }

  };

  function onMediaStop(e){
    togglePlayBtn();
  };

  function onMediaPlay(e){
    togglePlayBtn();
  };

  function isPlayingHandler(e){};

  // brightcove mediaComplete
  function onMediaComplete(){
    if(Modernizr.touch && Modernizr.mq('(max-width: 767px)')) {
      orientationChange();
    }
    nextStep();
  };

  function togglePlayBtn(){
    $playpause.toggleClass('is-playing');
  };

  // brightcove mediaChange event
  function onMediaChange(e){
    playVideo();
  }

  // Next step
  function nextStep(){
    nextstep = nextstep + 1;
    $steps.eq(currentstep).removeClass('is-active').addClass('has-played');
    $steps.eq(nextstep).addClass('is-active');
    if(nextstep === numberofsteps ){
      openModal($modalend);
    }
    stepper(steps[nextstep]);
    currentstep = nextstep;
  };

  // Previous step
  function prevStep(){
    nextstep = nextstep - 1;
    if(nextstep < 0){
      nextstep = numberofsteps - 1;
    }
    stepper(steps[nextstep]);
  };

  // show the sim
  function showSimulation(){
    $('#container-sim').addClass('is-visible');
  };

  // hide the sim
  function hideSimulation(){
    $('#container-sim').removeClass('is-visible');
  };

  // start the sim
  function startSimulation(){
    simulation.run({lang : currentlang});
  };

  // open the modal
  function openModal(mod){
    mod.modal('show');
  };

  // close the modal
  function closeModal(mod){
    mod.modal('hide');
  };

  // hide the address bar
  function hideAddressBar(){
    setTimeout(function(){
      // Hide the address bar!
      window.scrollTo(0, 1);
    }, 0);
  };

  // orientation change function
  function orientationChange() {

    // if the orientation is landscape  or if it is undefined
    if (window.orientation == 90 || window.orientation == -90 || window.orientation == undefined) {     

      // remove portrait class and add landscape class
      $('html').removeClass('portrait').addClass('landscape');

      // currently setting height of html, body, form and #wrapper to commpensate for 
      // iOS's addition of space when setting width and height to 100%
      // NOTE: setting all of these may not be necessary 
      $('html, body, form, #wrapper').css({
        'height': window.innerHeight,
        'overflow' : 'hidden'
      });

      // set the height of the rotation overlay div and the two inner divs
      $('#rotation-overlay, #rotation-overlay > div').css({ 'height' : window.innerHeight });

      // when the rotate your phone overlay appears cancel all touchmove events to prevent any scrolling 
      window.ontouchmove = function(event){
        event.preventDefault();
      }

    // else if the orientation isn't landscape
    } else {

      // remove the inline styles set for landscape viewing
      $('html, body, form, #wrapper').removeAttr('style');

      // remove the landscape class and add portrait class
      $('html').addClass('portrait').removeClass('landscape');

      // trigger resize to center modal
      // FIXME : This needs to be fixed as this shouldn't be necessary
      $(window).trigger('resize');
    }

  };

  // function to toggle browser fullscreen mode as see on MDN
  // https://developer.mozilla.org/en-US/docs/Web/Guide/API/DOM/Using_full_screen_mode
  function toggleFullScreen() {
    if (!document.fullscreenElement &&
        !document.mozFullScreenElement && !document.webkitFullscreenElement && !document.msFullscreenElement ) {
      if (document.documentElement.requestFullscreen) {
        document.documentElement.requestFullscreen();
      } else if (document.documentElement.msRequestFullscreen) {
        document.documentElement.msRequestFullscreen();
      } else if (document.documentElement.mozRequestFullScreen) {
        document.documentElement.mozRequestFullScreen();
      } else if (document.documentElement.webkitRequestFullscreen) {
        document.documentElement.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
      }
    } else {
      if (document.exitFullscreen) {
        document.exitFullscreen();
      } else if (document.msExitFullscreen) {
        document.msExitFullscreen();
      } else if (document.mozCancelFullScreen) {
        document.mozCancelFullScreen();
      } else if (document.webkitExitFullscreen) {
        document.webkitExitFullscreen();
      }
    }
  };

  return {
    init: init,
    onTemplateLoaded : onTemplateLoaded,
    onTemplateReady : onTemplateReady,
    playVideo : playVideo,
    nextStep: nextStep
  }

})();

// listeners for messages that come from the iframe
window.addEventListener('message', function(event) {
  if(event.data == 'mediaComplete') {
    TYCE.nextStep();
  }
});

//Add Modernizr test
Modernizr.addTest('isHardCoded', function(){
  return navigator.userAgent.match(/(iPhone|iPod)/i) ? true : false;
});



