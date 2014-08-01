//(function() {

//    // listeners for messages that come from the TYCE object
//    window.addEventListener('message', function(event){
//        if(event.data.funct == 'loadvideo'){
//            VP.loadVideo(event.data.id);
//        }
//    }, false);

//  // vars for experience, video player, experience module, and html player element
//    var experience,
//        VP,
//        modExp,
//        html_player;

//    // player ready callback - register necessary event listeners for playback authorization, and create the overlay
//    function onPlayerReady(evt) {
//        html_player = document.getElementById('player');
//    VP.addEventListener(brightcove.api.events.MediaEvent.COMPLETE, onMediaComplete);
//    // VP.addEventListener(brightcove.api.events.MediaEvent.STOP, onMediaStop);
//    // VP.addEventListener(brightcove.api.events.MediaEvent.PLAY, onMediaPlay);
//    // VP.addEventListener(brightcove.api.events.MediaEvent.BEGIN, onMediaBegin);
//    // VP.addEventListener(brightcove.api.events.MediaEvent.CHANGE, onMediaChange);
//    }

//    function onMediaComplete(evt) {
//        parent.postMessage('mediaComplete', '*');
//    }

//  // TODO : add fullscreen 
//  // media change event - need to re-authorize the user
//  // function onMediaChange(evt) { }
//  // function onMediaStop(evt) {
//  //   parent.postMessage('mediaStop', '*');
//  // }

//    // Register the plugin and get necessary modules
//    experience = brightcove.api.getExperience();
//    VP = experience.getModule(brightcove.api.modules.APIModules.VIDEO_PLAYER);
//    modExp = experience.getModule(brightcove.api.modules.APIModules.EXPERIENCE);
    
//    // Continue if ready, or wait for ready event
//    if (modExp.getReady()) {
//        onPlayerReady();
//    } else {
//        modExp.addEventListener(brightcove.player.events.ExperienceEvent.TEMPLATE_READY, onPlayerReady);
//    }

//}());
