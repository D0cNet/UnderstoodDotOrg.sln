ReadSpeaker.ui=function(){var b=null,d=[],k=[],r=!1,m=function(){rspkr.log("[rspkr.ui] Attempting to add click events.");var a=$rs.get("."+rspkr.ui.rsbtnClass+" a.rsbtn_play"),b=null;$rs.isArray(a)||(a=[a]);for(var t=0,c=a.length;t<c;t++)if($rs.unregEvent(a[t],"click",ReadSpeakerDefer.clickhandler),b=a[t]?$rs.getAttr(a[t],"data-rsevent-id"):"_bogus_",rspkr.l.f.eq.store[b]&&rspkr.l.f.eq.store[b].click)rspkr.log("[rspkr.ui] Click event already existed on "+a[t],2);else{$rs.regEvent(a[t],"click",function(a){window.readpage(this);
if(a=a.originalEvent)a.cancelBubble=!0,a.preventDefault&&a.preventDefault(),a.stopPropagation&&a.stopPropagation(),a.returnValue=!1;return!1});rspkr.ui.addFocusHandler(a[t],!0,a[t].parentNode);rspkr.log("[rspkr.ui] Added click event to: "+a[t],1);try{$rs.getAttr(a[t],"role")||$rs.setAttr(a[t],"role","button")}catch(d){rspkr.log("[rspkr.ui] Could not add role attribute.",2)}}},j=function(){rspkr.log("[rspkr.ui] Initiating global callbacks");rspkr.ui.rsbtnClass=rspkr.cfg.item("ui.rsbtnClass")||"rsbtn";
window.readpage=function(a,b){rspkr.ui.initrun&&rspkr.ui.showPlayer(a,b)};window.rshlexit=function(a){(void 0===a||"false"===a)&&b.stop();setTimeout(function(){rspkr.c.dispatchEvent("onAfterSyncExit",window)},1E3)};window.rshlinit=s().sync.init;window.rshlsetContent=s().sync.setContent;window.rshlsetId=s().sync.setId;window.rshlsync=function(a,b){for(var v=a.split(","),c=b.split(","),i=0,n=a.length;i<n;i++)s().sync.execute(v[i],c[i])};var a=rspkr.c.data.browser;a&&(/iphone|ipad|ios|android/i.test(a.OS)||
"android"==a.name.toLowerCase())?$rs.regEvent(document.body,"touchstart",function(a){rspkr.c.data.setSelectedText(a);return!0}):($rs.regEvent(document.body,"mousedown",function(a){rspkr.ui.setPointerPos(a);return!0}),$rs.regEvent(document.body,"mouseup",function(b){"opera"===a.name.toLowerCase()?setTimeout(function(){rspkr.c.data.setSelectedText(b)},50):rspkr.c.data.setSelectedText(b);return!0}),$rs.regEvent(window,"mouseup",function(b){"opera"===a.name.toLowerCase()?setTimeout(function(){rspkr.c.data.setSelectedText(b)},
50):rspkr.c.data.setSelectedText(b);return!0}),$rs.regEvent(document.body,"keydown",rspkr.ui.setPointerPos),$rs.regEvent(document.body,"keyup",function(a){rspkr.c.data.setSelectedText(a);return!0}))},u=function(){document.removeEventListener?document.removeEventListener("click",window.ReadSpeakerDefer.clickhandler,!1):document.detachEvent&&document.detachEvent("onclick",window.ReadSpeakerDefer.clickhandler);if(ReadSpeakerDefer.deferred){var a=ReadSpeakerDefer.deferred,b=null;if("a"!=a.tagName.toLowerCase()){for(b=
a;"body"!=b.tagName.toLowerCase()&&!(b=b.parentNode,"a"==b.tagName.toLowerCase()););a=b}ReadSpeakerDefer.isRSLink(a)&&(rspkr.log("[rspkr.ui] Activating deferred element: "+a),$rs.removeClass(a.parentNode,"rsdeferred"),rspkr.ui.showPlayer(a));ReadSpeakerDefer.deferred=null}},p=null,e=function(){p&&(rspkr.log("[rspkr.ui.updateFocus] "+p.outerHTML),h(p))},h=function(a){$rs.focus&&("function"==typeof $rs.focus&&a)&&$rs.focus(a)},a=function(a){if("iconon"==rspkr.st.get("hlicon")&&!r){var b=k.push(new g)-
1;k[b].id=b;k[b].show(a);r=!0}},c=function(){"iconon"==rspkr.st.get("hlicon")&&r&&(k.pop().hide(),r=!1)},g=function(){var a=0,b=0,c=null,d=52,g=null,i=null,n=null,e=function(a){a=a||c;$rs.addClass(a,rspkr.ui.rsbtnClass+" rspopup");rspkr.cfg.item("general.useCompactPopupButton")&&$rs.addClass(a,"rscompact")},q=function(a){$rs.unregEvent(c,"mouseout",f);window.clearTimeout(g);var b,v=c.clientWidth+10,d;i=rspkr.ui.showPlayer(n,c,!0);d=i.getWidth();b=parseInt($rs.offset(c).left);if((b=rspkr.ui.viewport.width+
$rs.scrollLeft(document)-b)<d)b=parseInt($rs.css(c,"left"))-(d-(v-10)),$rs.css(c,"left",b+"px");r=!1;$rs.unregEvent(n,"click",q);$rs.regEvent(n,"click",function(a){a.originalEvent&&a.originalEvent.preventDefault&&a.originalEvent.preventDefault();a.originalEvent.returnValue=!1;return i.restart()});a.originalEvent&&a.originalEvent.preventDefault&&a.originalEvent.preventDefault();a.originalEvent&&"undefined"!==a.originalEvent.returnValue&&(a.originalEvent.returnValue=!1);return!1},f=function(){g||(g=
window.setTimeout(function(){s()},rspkr.cfg.item("general.popupCloseTime")||2E3))},l=function(){g&&(window.clearTimeout(g),g=null)},j=function(a,b){var i=$rs.offset(document.body);$rs.css(c,{top:b-i.top+"px",left:a-i.left+"px",width:d+"px"})},s=function(){$rs.css(c,{display:"none",top:0,left:0});l();k.splice(null,1);r=!1;c.parentElement.removeChild(c)},h=rspkr.c.findFirstRSButton(),c=document.createElement("div");c.id=rspkr.getID();c.innerHTML=rspkr.cfg.item("ui.popupbutton").join("");e();n=$rs.findIn(c,
"a.rsbtn_play");n.href=h?h.href:null;h||(n.href=rspkr.cfg.item("general.popupHref"));var h=n.href.match(/lang=([^&;]*)/i).pop(),m=$rs.findIn($rs.get(c),"a.rsbtn_play span.rsbtn_text span");m&&(m.textContent=m.innerText=rspkr.cfg.getPhrase("listen",h,"en_us"));$rs.setAttr(n,"title",rspkr.cfg.getPhrase("listentoselectedtext",h,"en_us"));$rs.regEvent(n,"click",q);document.body.appendChild(c);return{setPos:j,show:function(i){l(i);if(i&&"none"==$rs.css(c,"display")){var n=c.cloneNode(!0);n.id=rspkr.getID();
$rs.css(n,{display:"block",position:"absolute",top:0,left:0});document.body.appendChild(n);d=$rs.outerWidth(n)+3;document.body.removeChild(n);n=i.pageX;i=i.pageY;b=i>rspkr.ui.pointerY?i-$rs.scrollTop(document)+36>rspkr.ui.viewport.height-46?i-66:i+30:10>i-$rs.scrollTop(document)-66?i+30:i-51;a=10>n-$rs.scrollLeft(document)?n+10:n-$rs.scrollLeft(document)>rspkr.ui.viewport.width-(d+10)?rspkr.ui.viewport.width+$rs.scrollLeft(document)-(d+10):n+0;j(a,b)}$rs.regEvent(c,"mouseout",f);$rs.regEvent(c,"mouseover",
l);f(null);e();$rs.css(c,"display","block")},hide:s,id:null}},q={update:function(a,c,d){"hlspeed"===a&&c!==d&&(a=a.replace("hl",""),rspkr.c.converter[a]&&"function"==typeof rspkr.c.converter[a]&&(c=rspkr.c.converter[a](c)),rspkr.c.data[a]=c,b&&b.stop(),rspkr.pl.releaseAdapter())}},f=function(a,b,c,d,g,i){$rs.css(a,"background-color","rgb("+b+","+c+","+d+")");d<g?(d+=10,window.setTimeout(function(){f(a,b,c,d,g,i)},50)):i&&"function"===typeof i&&i.apply(a,[])},s=function(){return rspkr.XP?rspkr.XP:
rspkr.HL};_expand=function(a){"string"==typeof a&&(a=$rs.get(a));$rs.isArray(a)||(a=[a]);var b=rspkr.cfg.getPhrases(rspkr.c.data.getParam("lang")),c=rspkr.c.data.browser,d=function(a){return $rs.closest(a,"div."+rspkr.ui.rsbtnClass)},g=function(){q(this)},i=function(){var a=$rs.findIn(d(this),".rsbtn_play");$rs.removeClass(d(this),"rsstopped rsplaying rspaused rsexpanded");q(this);a.click()},n=function(){$rs.removeClass(d(this),"rsstopped rsplaying rspaused rsexpanded");q(this)},e=function(){var a=
d(this);rspkr.ui.Lightbox.show(rspkr.st.getHTML(),rspkr.st.getButtons(),!0,function(){rspkr.c.dispatchEvent("onSettingsLoaded",window,[]);rspkr.cfg.execCallback("cb.ui.settingsopened",a)})},q=function(a){a=d(a);$rs.unregEvent($rs.findIn(a,".rsbtn_pause"),"click",i);$rs.unregEvent($rs.findIn(a,".rsbtn_closer"),"click",n);$rs.unregEvent($rs.findIn(a,".rsbtn_settings"),"click",e);$rs.unregEvent($rs.findIn(a,".rsbtn_play"),"click",g);$rs.removeClass(a,"pre-expanded")},f;for(f in a){$rs.addClass(a[f],
"rsexpanded rsstopped");var l=$rs.findIn(a[f],".rsbtn_powered");if(l){var j=$rs.findIn(l,".rsbtn_btnlabel"),s=b.speechenabled.match(/.*href="([^"]*)"/i).pop(),h=b.newwindow,k=document.createElement("p");k.innerHTML=b.speechenabled;h=(k.innerText||k.textContent)+(h?" ("+h+")":"");j&&(j.innerHTML=b.speechenabled);$rs.setAttr(l,"title",h);$rs.setAttr(l,"data-readspeaker-href",s);j=$rs.getAttr(l,"data-rsevent-id");(!j||rs.l.f.eq.store[j]&&!rs.l.f.eq.store[j].click)&&$rs.regEvent(l,"click",function(){window.open($rs.getAttr(this,
"data-readspeaker-href"))});if(l=$rs.findIn(l,".rsbtn_btnlabel a"))(/Chrome|Safari|Opera/gi.test(c.name)||/Explorer/gi.test(c.name)&&8<=c.version)&&$rs.regEvent(l,"click",function(a){if(a=a.originalEvent)a.cancelBubble=!0,a.stopPropagation&&a.stopPropagation(),a.returnValue=!0}),l.innerHTML='<span class="rsbtn_label_read">Read</span><span class="rsbtn_label_speaker">Speaker</span><span class="rsbtn_label_icon rsimg"></span>'}$rs.addClass(a[f],"pre-expanded");$rs.removeClass($rs.findIn(a[f],".rsbtn_progress_container"),
"rsloading");$rs.regEvent($rs.findIn(a[f],".rsbtn_closer"),"click",n);$rs.regEvent($rs.findIn(a[f],".rsbtn_pause"),"click",i);$rs.regEvent($rs.findIn(a[f],".rsbtn_play"),"click",g);$rs.regEvent($rs.findIn(a[f],".rsbtn_settings"),"click",e)}};return{meta:{revision:"2196"},initrun:!1,init:function(){evt=rspkr.Common.addEvent;ui=rspkr.ui;evt("onAfterModsLoaded",j);evt("onReady",m);evt("onReady",u);evt("onSelectedText",a);evt("onDeselectedText",c);evt("onSettingsChanged",q.update);evt("onAfterSyncInit",
e);this.initrun=!0;rspkr.Common.dispatchEvent("onUIInitialized");rspkr.log("[rspkr.ui] Initialized!")},addFocusHandler:function(a,b,c){var d=b,g=c,g=g||a;void 0===d&&(d=!0);$rs.focusIn&&"function"==typeof $rs.focusIn&&($rs.focusIn(a,function(){$rs.addClass(g,"rsfocus");!0===d&&(p=a);rspkr.Common.dispatchEvent("onFocusIn",window,[a,g])}),$rs.focusOut(a,function(){$rs.removeClass(g,"rsfocus");rspkr.Common.dispatchEvent("onFocusOut",window,[a,g])}))},focus:function(a){h(a)},updateFocus:function(){e()},
showOverlay:function(a,c){var d=a,g;g=c||b.getContainer();var e=$rs.findIn(g,".rsbtn_status");0===e.length&&(e=document.createElement("span"),e.className="rsbtn_status_overlay",e.innerHTML='<span class="rsbtn_status"></span>',$rs.findIn(g,".rsbtn_exp").appendChild(e),e=$rs.findIn(g,".rsbtn_status"));$rs.css($rs.findIn(g,".rsbtn_status_overlay"),"display","block");"nosound"===d?(d='<a class="rsbtn_nosound">'+rspkr.cfg.getPhrase("nosound")+"</a>",e.innerHTML=d,(d=$rs.findIn(g,".rsbtn_nosound"))&&$rs.regEvent(d,
"click",function(){return b.nosound()})):"loaderror"===d?(d=rspkr.c.data.getSaveData("link"),e.innerHTML=rspkr.cfg.getPhrase("loaderror")+' <a class="rsbtn_loaderror" href="'+d+'">[?]</a>'):e.innerHTML=d},settings:q,rsbtnClass:"",addClickEvents:function(){m()},initGlobalCallbacks:function(){j()},showPopupIcon:function(b){a(b)},processDeferred:function(){u()},showPlayer:function(a,c,g){var e;a:{rspkr.log("[rspkr.ui.showPlayer]");var g=g||!1,f;if("string"==typeof a)b:{f=$rs.get("a");for(var i=0,n=f.length;i<
n;i++)if(f[i].href&&f[i].href==a){f=f[i];break b}f=!1}else f=a;i=f;a="string"==typeof a?a:i.href;f=null;rspkr.c.data.setParams(a);void 0!==$rs.getAttr(i,"data-target")&&null!==$rs.getAttr(i,"data-target")&&(f=$rs.getAttr(i,"data-target"),f=$rs.get(f),"object"===typeof f&&(c=f));c&&!g?(f=$rs.get(c),$rs.addClass(f,rspkr.ui.rsbtnClass+" rsfloating"),rspkr.basicMode&&($rs.removeClass(f,"rshidden"),$rs.addClass(f,rspkr.ui.rsbtnClass+" rsvisible"))):f=$rs.closest(i,"div."+rspkr.ui.rsbtnClass);if(!0===rspkr.cfg.item("survey.allowed"))if(c=
rspkr.c.cookie,g=rspkr.cfg.item("survey.cookieName")||"rspkrsurvey",i=rspkr.cfg.item("survey.cookieLifetime")||15552E6,n=rspkr.c.data.params,"1"===c.readKey(g,"nmbrdisplays")){rspkr.ui.Lightbox.show(rspkr.cfg.item("survey.url")+"?customerid="+n.customerid+"&lang="+n.lang,rspkr.st.r().replaceTokens(rspkr.cfg.item("ui.survey.buttons").join(),{rsSURVEY_BUTTON_CLOSErs:rspkr.cfg.getPhrase("close")}),!0,function(){$rs.regEvent($rs.get("#rssurvey_button_close"),"click",rspkr.u.Lightbox.hide)},500);rspkr.log(c.updateKey(g,
"nmbrdisplays","displayed",i),4);e=void 0;break a}else void 0===c.readKey(g,"nmbrdisplays")&&rspkr.log(c.updateKey(g,"nmbrdisplays","1",i),4);b:{c=f;for(e in d)if(d[e]&&d[e].getContainer&&d[e].getContainer()==c){e=d[e];break b}e=new rspkr.ui.Player(c);d.push(e)}if(b&&b!=e||b&&a!==b.getHref())b.close(!0),rspkr.c.dispatchEvent("onUIClosePlayer",b.getContainer(),[0<rspkr.c.data.selectedText.length?"textsel":"nosel"]);c=(c=b)?c.getID():null;rspkr.c.dispatchEvent("onUIShowPlayer",window,[c,e.getID()]);
e.setHref(a);e.show();e=b=e}return e},expand:function(a){_expand(a)},pointerX:0,pointerY:0,setPointerPos:function(a){rspkr.ui.pointerX=a.pageX;rspkr.ui.pointerY=a.pageY;return!0},viewport:{width:$rs.width(window),height:$rs.height(window)},popups:k,hl:function(a,b){window.setTimeout(function(){f(a,255,255,100,255,b)},200)},scroll:{INTERVAL:null,STEPS:25,scrollToElm:function(a){$rs.isVisible(a)&&this.initScroll(a)},scrollToAnchor:function(a){for(var b=$rs.get("a"),c=null,d=0;d<b.length;d++){var g=
b[d];if(g.name&&g.name==a){c=g;break}}this.initScroll(c)},initScroll:function(a){if(a){for(var b=a.offsetTop,c=a;c.offsetParent&&c.offsetParent!=document.body;)c=c.offsetParent,b+=c.offsetTop;b-=50;clearInterval(rspkr.u.scroll.INTERVAL);var c=rspkr.u.scroll.getCurrentYPos(),d=parseInt((b-c)/rspkr.u.scroll.STEPS);rspkr.u.scroll.INTERVAL=setInterval(function(){rspkr.u.scroll.scrollWindow(d,b,a)},10)}else document.location.hash=a},getCurrentYPos:function(){return document.body&&document.body.scrollTop?
document.body.scrollTop:document.documentElement&&document.documentElement.scrollTop?document.documentElement.scrollTop:window.pageYOffset?window.pageYOffset:0},scrollWindow:function(a,b,c){var d=rspkr.u.scroll.getCurrentYPos(),g=d<b;window.scrollTo(0,d+a);a=rspkr.u.scroll.getCurrentYPos();if(g!=a<b||d==a)window.scrollTo(0,b),clearInterval(rspkr.u.scroll.INTERVAL),"string"==typeof c&&(location.hash=c)}},activePlayer:b,getActivePlayer:function(){return b}}}();
ReadSpeaker.ui.Slider=function(){var b=this,d={handleClass:"",width:0,height:0,left:0,top:0,steps:-1,stepsize:-1,dir:"h",initval:-1,drop:null,start:null,dragging:null,click:null,labelDragHandle:"",labelStart:"",labelEnd:"",nudge:1},k={rsid:void 0,parent:void 0,ref:void 0},r=void 0,m=void 0,j=void 0,u=void 0,p=void 0,e=!1,h=0;this.initElement=function(a){if(!e){"string"==typeof a&&(a=document.getElementById(a));a.innerHTML+='<a href="javascript:void(0);" role="slider" class="keyLink" style="display:block; border:0;">&nbsp;</a>';
var b=a.getElementsByTagName("a"),b=b[b.length-1],g=-1<d.steps?d.steps:100;b.relatedElement=a;$rs.setAttr(b,"title",d.labelDragHandle);$rs.setAttr(b,"aria-label",d.labelDragHandle);$rs.setAttr(b,"aria-orientation","h"==d.dir?"horizontal":"vertical");$rs.setAttr(b,"aria-valuemin",0);$rs.setAttr(b,"aria-valuemax",g);$rs.setAttr(b,"aria-valuenow",d.initval||0);h=d.initval;$rs.regEvent(a,"mousedown",this.startDragMouse);$rs.regEvent(b,"keyup",this.startDragKeys);$rs.regEvent(b,"dragstart",function(a){a.originalEvent&&
a.originalEvent.preventDefault&&a.originalEvent.preventDefault();return a.originalEvent.returnValue=!1});$rs.regEvent(a,"touchstart",this.touchStart);$rs.regEvent(k.parent,"mousedown",this.mouseClick)}};this.mouseClick=function(a){if(!e&&!$rs.hasClass(k.ref,"dragged")){var c=b.findPos(a.target),g=a.clientX-(c.left-d.left),a=a.clientY-(c.top-d.top);j=c.left;u=c.top;c=b.getCurrentVal({left:g,top:a});"function"==typeof d.click&&d.click(c,k);return!1}};this.findPos=function(a){var b=curTop=0;if(a.offsetParent){do b+=
a.offsetLeft,curTop+=a.offsetTop;while(a=a.offsetParent);return{left:b,top:curTop}}};this.startDragMouse=function(a){rspkr.log("[rspkr.ui.Slider] startDragMouse");if(!e){b.startDrag(this);var c=a||window.event;r=c.clientX;m=c.clientY;$rs.regEvent(document.body,"mousemove",b.dragMouse);$rs.regEvent(document.body,"mouseup",b.releaseElement)}a.preventDefault&&a.preventDefault();return!1};this.startDragKeys=function(a){a=a||window.event;rspkr.log("[rspkr.ui.Slider] startDragKeys "+a.keyCode);b.startDrag(this.relatedElement);
$rs.regEvent(document.body,"keydown",b.dragKeys);$rs.regEvent(document.body,"keypress",b.switchKeyEvents);$rs.addClass(this.relatedElement,"rskeycontrolled");a.preventDefault&&a.preventDefault();return a.returnValue=!1};this.touchStart=function(a){a=a.originalEvent;rspkr.log("[rspkr.ui.Slider] touchStart");e||(b.startDrag(a.target),r=a.touches[0].pageX,m=a.touches[0].pageY,$rs.regEvent(a.target,"touchmove",b.touchMove),$rs.regEvent(a.target,"touchend",b.releaseElement));return!1};this.startDrag=function(a){rspkr.log("[rspkr.ui.Slider] startDrag");
p&&b.releaseElement();j=a.offsetLeft;u=a.offsetTop;p=a;$rs.addClass(p,"dragged");"function"==typeof d.start&&d.start(k)};this.dragMouse=function(a){a=a||window.event;b.setPosition(a.clientX-r,a.clientY-m);b.valueChanged=!0;return!1};this.touchMove=function(a){a=a.originalEvent;a.preventDefault();b.setPosition(a.touches[0].pageX-r,a.touches[0].pageY-m);b.valueChanged=!0;return!1};this.dragKeys=function(a){a=a||window.event;switch(a.keyCode){case 37:case 63234:b.valueChanged=!0;h-=d.nudge;break;case 38:case 63232:b.valueChanged=
!0;h+=d.nudge;break;case 39:case 63235:b.valueChanged=!0;h+=d.nudge;break;case 40:case 63233:b.valueChanged=!0;h-=d.nudge;break;case 13:case 27:return b.releaseElement(),!1;case 9:return b.releaseElement(),!0;default:return rspkr.log("[rspkr.ui.Slider] return TRUE"),!0}!0===b.valueChanged&&(rspkr.c.dispatchEvent("onUISliderMove"),"function"==typeof d.dragging&&d.dragging(b.getCurrentVal({skipValueCalculation:!0}),k));a.originalEvent&&a.originalEvent.preventDefault&&a.originalEvent.preventDefault();
a.returnValue=!1;rspkr.log("[rspkr.ui.Slider] ready to return!");return!1};this.setPosition=function(a,c){var g,e=!1;g=a;var f=j,h=d.left,m=d.width,r="left";"v"==d.dir&&(g=c,f=u,h=d.top,m=d.height,r="top");g=f+g;-1<d.stepsize&&((g+h)%d.stepsize?g=d.stepsize*Math.ceil(g/d.stepsize)+h:e=!0);g>m+h?g=m+h:g<h&&(g=h);e||(p.style[r]=g+"px","function"==typeof d.dragging&&d.dragging(b.getCurrentVal(),k))};this.switchKeyEvents=function(){$rs.unregEvent(document.body,"keydown",b.dragKeys);$rs.unregEvent(document.body,
"keypress",b.switchKeyEvents);$rs.regEvent(document.body,"keypress",b.dragKeys)};this.releaseElement=function(){rspkr.log("[rspkr.ui.Slider] releaseElement");$rs.unregEvent(document.body,"mousemove",b.dragMouse);$rs.unregEvent(document.body,"mouseup",b.releaseElement);$rs.unregEvent(document.body,"keypress",b.dragKeys);$rs.unregEvent(document.body,"keypress",b.switchKeyEvents);$rs.unregEvent(document.body,"keydown",b.dragKeys);$rs.unregEvent(p,"touchmove",b.touchMove);$rs.unregEvent(p,"touchend",
b.releaseElement);$rs.removeClass(p,"dragged");$rs.removeClass(p,"rskeycontrolled");$rs.removeClass(p,"rsmousecontrolled");var a=b.getCurrentVal();p=null;"function"==typeof d.drop&&!0===b.valueChanged&&d.drop(a,k);return b.valueChanged=!1};this.getCurrentVal=function(a){var b,g=d.width;b="left";var e=d.left;"v"==d.dir&&(g=d.height,b="top",e=d.top);var f=-1<d.steps?d.steps:100,g=-1<d.stepsize?d.stepsize:g/f,a=a?a[b]:$rs.css(k.ref,b).replace(/px/i,"");pos=Math.round(a)-e;b=Math.round(pos/g);"v"==d.dir&&
(b=f-b);rspkr.log("[rspkr.ui.Slider] currentval: "+b);return a&&a.skipValueCalculation||isNaN(b)?h=Math.max(Math.min(h,f),0):h=b};return{init:function(a,c){"string"==typeof a&&(a=document.getElementById(a));if(a){var g=a.id||"data-readspeaker-slider-id-"+Math.floor(2E4*Math.random());a.setAttribute&&a.setAttribute("data-readspeaker-slider-id-","data-readspeaker-slider-parent-"+g);var e={width:function(){return $rs.width(a)},height:function(){return $rs.height(a)}};if("object"==typeof c)for(var f in c)c.hasOwnProperty(f)&&
void 0!==d[f]&&(d[f]=c[f]);f=!1;var h;"rsbtn_volume_slider"===a.className&&("jquery"===rspkr.l.f.currentLib()&&1.5>parseFloat(jQuery.fn.jquery))&&(h=a.parentNode.style.display,a.parentNode.style.display="block",f=!0);d.width=e.width();d.height=e.height();f&&(a.parentNode.style.display=h);-1<d.steps&&(d.stepsize=("h"==d.dir?d.width:d.height)/d.steps);e=document.createElement("span");e.setAttribute("data-readspeaker-slider-id-",g);e.className=d.handleClass||"rsbtn_progress_handle rsimg";a.appendChild(e);
k.rsid=g;k.parent=a;k.ref=e;g=$rs.css(e,"left");null!==g&&(d.left=parseInt(g.replace(/px/i,"")));g=$rs.css(e,"top");null!==g&&(d.top=parseInt(g.replace(/px/i,"")));-1<d.initval&&this.jumpTo(d.initval);d.labelStart&&(g=document.createElement("span"),g.className="slider-label-start",g.innerHTML=d.labelStart,a.appendChild(g));d.labelEnd&&(g=document.createElement("span"),g.className="slider-label-end",g.innerHTML=d.labelEnd,a.appendChild(g));b.initElement(e)}},jumpTo:function(a){if(isNaN(a))return!1;
var b=101,e=a;-1<d.steps&&(a=Math.round(a),b=d.steps+1);if(-1<a&&a<b){var h=d.width,f=d.left,j="left";"v"==d.dir&&(h=d.height,f=d.top,j="top",a=b-1-a);k.ref.style[j]=h/(b-1)*a+f+"px";$rs.setAttr($rs.findIn(k.ref,"a.keyLink"),"aria-valuenow",e)}},setCurrentValue:function(a){h=a},getInstance:function(){return k},getContainer:function(){return k.parent},releaseElement:function(){b.releaseElement()},startDragKeys:function(a,c){b.startDragKeys.call(a,c)},disabled:function(){if(arguments)e=arguments[0];
else return e}}};
ReadSpeaker.ui.Player=function(b){var d=rspkr.getID(),k=this,r=[],m=0,j=!1,u=null,p=!1,e={_play:null,_pause:null,_stop:null,_vol:null,_settings:null,_dl:null,_closer:null,_powered:null,_get:function(a,c){var d,a="_"+a;d=b?this[a]&&0<this[a].length?this[a]:this[a]=$rs.findIn(b,c):null;return d==[]?null:d},play:function(){return this._get("play",".rsbtn_play")},pause:function(){return this._get("pause",".rsbtn_pause")},stop:function(){return this._get("stop",".rsbtn_stop")},vol:function(){return this._get("vol",".rsbtn_volume")},
settings:function(){return this._get("settings",".rsbtn_settings")},dl:function(){return this._get("dl",".rsbtn_dl")},powered:function(){return this._get("powered",".rsbtn_powered")},closer:function(){return this._get("closer",".rsbtn_closer")},nosound:function(){return this._get("nosound",".rsbtn_nosound")},setPlayPause:function(a){rspkr.log("[rspkr.ui.Player.setPlayPause("+a+")]");a=a?$rs.getAttr(this.pause(),"data-rsphrase-play"):$rs.getAttr(this.pause(),"data-rsphrase-pause");$rs.setAttr(this.pause(),
"title",rspkr.c.decodeEntities(a));$rs.findIn(this.pause(),".rsbtn_btnlabel").innerHTML=a}},h=!1,a=[],c={play:function(){rspkr.c.dispatchEvent("onUIBeforePlay");rspkr.log("[rspkr.ui.handlers.play]");a.progress&&a.progress.disabled(!1);c.setStateClass(b,"rsplaying");rspkr.basicMode&&c.setStateClass($rs.findIn(b,".rsbtn_exp"),"rsplaying");$rs.addClass($rs.findIn(b,".rsbtn_progress_container"),"rsloading");e.setPlayPause(!1);rspkr.pl.play();p&&rspkr.pl.getProgress.apply(rspkr.pl,[!0,q,k]);rspkr.c.addEvent("onBeforeSyncInit",
function(){p=!0;rspkr.pl.getProgress.apply(rspkr.pl,[!0,q,k])});"flash"===rspkr.pl.adapter&&!rspkr.displog.onVolumeAdjusted&&rspkr.pl.setVolume(parseInt(rspkr.st.get("hlvol")||"100"));rspkr.c.dispatchEvent("onUIAfterPlay");rspkr.cfg.execCallback("cb.ui.play",b)},pause:function(){rspkr.log("[rspkr.ui.handlers.pause]");c.setStateClass(b,"rspaused");rspkr.basicMode&&c.setStateClass($rs.findIn(b,".rsbtn_exp"),"rspaused");e.setPlayPause(!0);rspkr.pl.pause();rspkr.pl.getProgress(!1);rspkr.c.dispatchEvent("onUIPause");
rspkr.cfg.execCallback("cb.ui.pause",b);rspkr.log("ReadSpeaker.ui.pause")},stop:function(){rspkr.log("[rspkr.ui.handlers.stop]");a.progress&&a.progress.disabled(!0);c.setStateClass(b,"rsstopped");$rs.removeClass($rs.findIn(b,".rsbtn_progress_container"),"rsloading");rspkr.basicMode&&c.setStateClass($rs.findIn(b,".rsbtn_exp"),"rsstopped");e.setPlayPause(!0);$rs.setAttr(b,"data-readspeaker-current",0);a.progress&&(a.progress.jumpTo(0),g(0));rspkr.pl.stop();rspkr.pl.getProgress(!1);rspkr.c.dispatchEvent("onUIStop",
b);rspkr.cfg.execCallback("cb.ui.stop",b);rspkr.log("ReadSpeaker.ui.stop")},setStateClass:function(a,b){a&&($rs.removeClass(a,"rspaused rsstopped rsplaying"),$rs.addClass(a,b))},vol:function(i){var d=$rs.findIn(b,".rsbtn_volume_container"),c=$rs.findIn(b,".rsbtn_volume"),i=i.originalEvent,e=function(a){var b=a.originalEvent,b=$rs.closest(b.srcElement||b.originalTarget,".rsbtn_volume_container");if("none"===$rs.css(d,"display"))return!1;if("click"===a.type){if(void 0===b||$rs.isArray(b)&&!b.length)$rs.css(d,
"display","none"),$rs.unregEvent(document.body,"click",e)}else"keyup"===a.type&&27===a.keyCode&&($rs.css(d,"display","none"),$rs.unregEvent(document.body,"keyup",e))};$rs.css(d,"left",c.offsetLeft+"px");$rs.css(d,"display","none"==$rs.css(d,"display")?"block":"none");"block"===$rs.css(d,"display")&&($rs.regEvent(document.body,"click",e),$rs.regEvent(document.body,"keyup",e));i&&i.stopPropagation&&i.stopPropagation();i.cancelBubble=!0;c=$rs.findIn(d,".keyLink");a.vol.startDragKeys(c,{keyCode:13});
return!1},settings:function(){$rs.hasClass(b,"rsplaying")&&this.pause();rspkr.ui.Lightbox.show(rspkr.st.getHTML(),rspkr.st.getButtons(),!0,function(a){rspkr.c.dispatchEvent("onSettingsLoaded",window,[]);rspkr.cfg.execCallback("cb.ui.settingsopened",a)})},close:function(d){var d=d||!1,c=rspkr.pl,g=!1;d||rspkr.cfg.execCallback("cb.ui.beforeclose",b);c.hasOwnProperty("getProgress")&&rspkr.pl.getProgress(!1);c.hasOwnProperty("releaseAdapter")&&rspkr.pl.releaseAdapter();$rs.setAttr(b,"data-readspeaker-current",
0);a.progress&&a.progress.jumpTo(0);$rs.removeClass(b,"rsstopped rsplaying rspaused rsexpanded");if(rspkr.basicMode){var f;(f=$rs.findIn(b,".rsbtn_play"))&&$rs.removeClass(f,"rsexpanded")}$rs.hasClass(b,"rsfloating")&&($rs.removeClass(b,rspkr.ui.rsbtnClass),rspkr.basicMode&&($rs.removeClass(b,"rsvisible"),$rs.addClass(b,"rshidden")));e.setPlayPause(!0);$rs.hasClass(b,"rspopup")&&(g=!0,$rs.removeClass(b,"rspopup"),$rs.css(b,"display","none"),b.parentNode.removeChild(b));$rs.css(b,"width","auto");delete rspkr.displog.onVolumeAdjusted;
d||(rspkr.c.dispatchEvent("onUIClosePlayer",b,["userclick"]),rspkr.cfg.execCallback("cb.ui.close",b),rspkr.log("ReadSpeaker.ui.close: "+b));!d&&!1===g&&rspkr.ui.focus($rs.findIn($rs.get(b),".rsbtn_play"))},dl:function(){$rs.hasClass(b,"rsplaying")&&this.pause();var a=rspkr.c.data.getSaveData("dialog"),d=!1;rspkr.log("[rspkr.ui.handlers.dl] Savelink: "+a);rspkr.u.Lightbox.show(this.getDlDialog(),this.getDlButtons(),!0,function(){var b=$rs.get("#rsdl_button_accept"),c=$rs.get("#rsdl_button_decline");
b&&$rs.regEvent(b,"click",function(){rspkr.u.Lightbox.hide();d="iOS"!==rspkr.c.data.browser.OS&&0<rspkr.c.data.selectedHTML.length?!0:"iOS"!==rspkr.c.data.browser.OS&&!0===rspkr.cfg.item("general.usePost")?!0:!1;if(!0===d){var c=null;if(document.getElementById("dliframe"))c=document.getElementById("dliframe");else{if(document.selection)try{c=document.createElement('<iframe name="dliframe">')}catch(e){c=document.createElement("iframe")}else c=document.createElement("iframe");c.name="dliframe";c.setAttribute("id",
"dliframe");c.setAttribute("style","display: none; position: absolute;");c.style.display="none";var g=document.getElementsByTagName("body"),f=null;0<g.length&&(f=g.item(0));if(f)f.appendChild(c);else return}c.src=a;return!1}$rs.setAttr(b,"href",a);return!0});c&&($rs.regEvent(c,"click",rspkr.u.Lightbox.hide),setTimeout(function(){rspkr.ui.focus(c)},200))})},getDlDialog:function(){var a=rspkr.cfg.item("ui.dldialog").join("\n"),b={};b.rsTERMS_OF_USE_HEADINGrs=rspkr.cfg.getPhrase("touheading");b.rsTERMS_OF_USE_BODYrs=
rspkr.cfg.getPhrase("toubody");return rspkr.st.r().replaceTokens(a,b)},getDlButtons:function(){var a=rspkr.cfg.item("ui.dlbuttons").join("\n"),b={};b.rsTERMS_OF_USE_ACCEPTrs=rspkr.cfg.getPhrase("touaccept");b.rsTERMS_OF_USE_DECLINErs=rspkr.cfg.getPhrase("toudecline");return rspkr.st.r().replaceTokens(a,b)},nosound:function(){var a=rspkr.c.data.getSaveData("link");$rs.setAttr(e.nosound(),"href",a);return!0}},g=function(a){var a=100<a?100:a,c=$rs.findIn(b,".rsbtn_progress_played");"object"===typeof c&&
$rs.css(c,"width",a+"%");rspkr.cfg.execCallback("cb.ui.progresschanged",b,[a])},q=function(c){if(c.length){var d=parseInt(c[0]),c=parseInt(c[1]),e=0==c?0:Math.round(100*(d/c)),j=$rs.findIn(b,".rsbtn_current_time"),k=$rs.findIn(b,".rsbtn_total_time"),l,m;a.progress&&(a.progress.setCurrentValue(e),h||(a.progress.jumpTo(e),g(e),j&&(j.innerHTML=l=f(d)),k&&(k.innerHTML=m=f(c)),rspkr.cfg.execCallback("cb.ui.timeupdated",b,[l,m])));rspkr.log("[rspkr.player.updateProgress] current time: "+d+" total time: "+
c);$rs.setAttr(b,"data-readspeaker-current",d);$rs.setAttr(b,"data-readspeaker-buffered",c);0<d&&$rs.removeClass($rs.findIn(b,".rsbtn_progress_container"),"rsloading")}},f=function(a){var a=a/1E3,b=parseInt(a%60),c=parseInt(a/60%60),a=parseInt(a/60/60%60);return(10>a?"0"+a:a.toString())+":"+(10>c?"0"+c:c.toString())+":"+(10>b?"0"+b:b.toString())},s=function(){h=!0},v=function(a){rspkr.log("_dropProgress ("+a+")",5);a=a/100*$rs.getAttr(b,"data-readspeaker-buffered")/1E3;rspkr.pl.setProgress(a);h=!1},
w=function(a){v(a)},t=function(c){rspkr.log("_dropVolume, "+c,5);c=0>c?0:20*c;a.vol&&a.vol.jumpTo(c/20);rspkr.pl.setVolume(c);rspkr.st.set("hlvol",c);rspkr.cfg.execCallback("cb.ui.volumechanged",b,[c]);return!1},x=function(c,d){if("keyLink"===c.className){var e="";$rs.hasClass(d,"rsbtn_volume_handle")?e="vol":$rs.hasClass(d,"rsbtn_progress_handle")&&(e="progress");var g={keyCode:13};a[e].startDragKeys(c,g)}else $rs.hasClass(d,"rsbtn_volume")&&(g={keyCode:13},e=$rs.findIn(b,".rsbtn_volume_container"),
e=$rs.findIn(e,".keyLink"),a.vol.startDragKeys(e,g))},y=function(b,c){if("keyLink"===b.className){var d="";$rs.hasClass(c,"rsbtn_volume_handle")?d="vol":$rs.hasClass(c,"rsbtn_progress_handle")&&(d="progress");a[d].releaseElement();h=!1}};return{init:function(){r.push([this.show,[]])},show:function(){$rs.rsid(b);b.id=d=b.id||rspkr.getID();ui=rspkr.ui;$rs.hasClass(b,rspkr.ui.rsbtnClass)||$rs.addClass(b,rspkr.ui.rsbtnClass);var g=null,g=rspkr.cfg,f=rspkr.cfg.getPhrases(rspkr.c.data.getParam("lang"));
if(0==$rs.findIn(b,".rsbtn_exp").length){var h=$rs.hasClass(b,"rspopup")?g.item("ui.popupplayer"):g.item("ui.player"),g=document.createElement("span");g.className="rsbtn_exp rsimg rspart";g.innerHTML+=h.join("\n");b.appendChild(g)}"fallback"===rspkr.pl.adapter&&rspkr.ui.showOverlay("nosound",b);if(f){e.pause()&&($rs.setAttr(e.pause(),"data-rsphrase-pause",f.pause),$rs.setAttr(e.pause(),"data-rsphrase-play",f.play),$rs.setAttr(e.pause(),"title",rspkr.c.decodeEntities(f.pause)));e.stop()&&$rs.setAttr(e.stop(),
"title",rspkr.c.decodeEntities(f.stop));e.vol()&&$rs.setAttr(e.vol(),"title",rspkr.c.decodeEntities(f.volume));e.settings()&&$rs.setAttr(e.settings(),"title",rspkr.c.decodeEntities(f.settings));e.dl()&&$rs.setAttr(e.dl(),"title",rspkr.c.decodeEntities(f.download));if(e.powered()){var g=$rs.findIn(e.powered(),".rsbtn_btnlabel"),h=f.speechenabled.match(/.*href="([^"]*)"/i).pop(),k=f.newwindow,q=document.createElement("p");q.innerHTML=f.speechenabled;k=(q.innerText||q.textContent)+(k?" ("+k+")":"");
g&&(g.innerHTML=f.speechenabled);$rs.setAttr(e.powered(),"title",k);$rs.setAttr(e.powered(),"data-readspeaker-href",h);g=$rs.getAttr(e.powered(),"data-rsevent-id");(!g||rs.l.f.eq.store[g]&&!rs.l.f.eq.store[g].click)&&$rs.regEvent(e.powered(),"click",function(){window.open($rs.getAttr(this,"data-readspeaker-href"))})}e.closer()&&$rs.setAttr(e.closer(),"title",rspkr.c.decodeEntities(f.closeplayer))}f=rspkr.c.data.browser;(!/safari/i.test(f.name)||!/iphone|ipad|ios/i.test(f.OS))&&$rs.addClass(b,"rs-no-touch");
f=$rs.findIn(b,".rsbtn_status_overlay");$rs.isArray(f)||$rs.css(f,"display","none");$rs.addClass(b,"rsexpanded");if(rspkr.basicMode){var l;(l=$rs.findIn(b,".rsbtn_play"))&&$rs.addClass(l,"rsexpanded")}j||(e.stop()&&($rs.regEvent(e.stop(),"click",function(){c.stop()}),ui.addFocusHandler(e.stop())),e.pause()&&($rs.regEvent(e.pause(),"click",function(){$rs.hasClass(b,"rsplaying")?c.pause():($rs.hasClass(b,"rsstopped")||$rs.hasClass(b,"rspaused"))&&c.play()}),ui.addFocusHandler(e.pause())),e.closer()&&
($rs.regEvent(e.closer(),"click",function(){c.close()}),ui.addFocusHandler(e.closer())),e.vol()&&($rs.regEvent(e.vol(),"click",function(a){c.vol(a)}),ui.addFocusHandler(e.vol())),e.dl()&&($rs.regEvent(e.dl(),"click",function(){return c.dl()}),ui.addFocusHandler(e.dl())),e.settings()&&($rs.regEvent(e.settings(),"click",function(){c.settings()}),ui.addFocusHandler(e.settings())),l=rspkr.cfg,$rs.setAttr(b,"data-readspeaker-current",0),$rs.setAttr(b,"data-readspeaker-buffered",0),$rs.isArray($rs.findIn($rs.get(b),
".rsbtn_progress_container"))||(a.progress=new rspkr.ui.Slider,a.progress.init($rs.findIn($rs.get(b),".rsbtn_progress_container"),{handleClass:l.item("ui.progressHandleClass")||"rsbtn_progress_handle rsimg",dir:l.item("ui.progressDir")||"h",nudge:5,start:s,dragging:v,click:w,labelDragHandle:l.getPhrase("sliderseek")}),f=$rs.findIn($rs.get(b),".rsbtn_progress_handle a"),ui.addFocusHandler(f,!1,f.parentNode)),$rs.isArray($rs.findIn($rs.get(b),".rsbtn_volume_slider"))||(f=rspkr.st.get("hlvol")||"100",
f=5*(parseInt(f)/100),a.vol=new rspkr.ui.Slider,a.vol.init($rs.findIn(b,".rsbtn_volume_slider"),{handleClass:l.item("ui.volumeHandleClass")||"rsbtn_volume_handle rsimg",dir:l.item("ui.volumeDir")||"v",steps:5,nudge:1,initval:f,dragging:t,click:t,labelDragHandle:l.getPhrase("slidervolumedesc")}),f=$rs.findIn($rs.get(b),".rsbtn_volume_handle a"),ui.addFocusHandler(f,!1,f.parentNode)),rspkr.Common.addEvent("onFocusIn",x),rspkr.Common.addEvent("onFocusOut",y),rspkr.cfg.execCallback("cb.ui.open",b),j=
!0);if($rs.findIn(b,".rsbtn_powered")&&(l=$rs.findIn(b,".rsbtn_powered .rsbtn_btnlabel a")))(/Chrome|Safari|Opera/gi.test(rs.c.data.browser.name)||/Explorer/gi.test(rs.c.data.browser.name)&&8<=rs.c.data.browser.version)&&$rs.regEvent(l,"click",function(a){if(a=a.originalEvent)a.cancelBubble=!0,a.stopPropagation&&a.stopPropagation(),a.returnValue=!0}),l.innerHTML='<span class="rsbtn_label_read">Read</span><span class="rsbtn_label_speaker">Speaker</span><span class="rsbtn_label_icon rsimg"></span>';
"0"!=$rs.getAttr(b,"data-readspeaker-current")&&(rspkr.pl.releaseAdapter(),$rs.setAttr(b,"data-readspeaker-current",0));"fallback"!==rspkr.pl.adapter&&(c.play(),rspkr.ui.focus(e.pause()));l=(l=b)||b;l=$rs.clone(l,!0,!0);l.id=rspkr.getID();document.body.appendChild(l);$rs.css(l,{position:"absolute",top:"0",left:"0",display:"block",width:"auto"});$rs.css(l,"float","none");$rs.addClass(l,"rsexpanded");f=$rs.outerWidth(l)+3;l.style.display="none";document.body.removeChild(l);m=f;isNaN(m)||$rs.css(b,"width",
m+(/[Ee]xplorer/.test(ReadSpeaker.c.data.browser.name)?1:0)+"px")},close:function(a){c.close(a)},stop:function(){c.stop()},nosound:function(){return c.nosound()},restart:function(){rspkr.log("[rspkr.ui.restart]");c.stop();window.setTimeout(function(){c.play()},500);return!1},updateProgress:function(a){q(a)},setProgress:function(a){v(a)},getContainer:function(){return b},getID:function(){return d},getWidth:function(){return m},setHref:function(a){u=a},getHref:function(){return u}}};
ReadSpeaker.ui.Lightbox=function(){var b=null,d=null,k=null,r=null,m=null,j=null,u,p=function(){$rs.css(j,"display","none");var a=$rs.height(window),b=$rs.height(document),d=parseInt($rs.css(document.documentElement,"width")),h=$rs.width(document),f=$rs.absOffset(document.body),k=0,p=0;isNaN(d)&&(d=$rs.width(window));f.left&&(p=f.left);f.top&&(k=f.top);$rs.css(m,{width:(h>d?h:d)+"px",height:(b>a?b:a)+"px",top:"-"+Math.abs(k)+"px",left:"-"+Math.abs(p)+"px"});$rs.css(j,"display","block");e()},e=function(){var a=
$rs.outerWidth(j),b=$rs.outerHeight(j),d=$rs.width(window),e=$rs.height(window),b=u+80+50<e?u+80:e-50;j.style.height=b+"px";$rs.get("#rslightbox_content").style.height=b-80+"px";b>e?(j.style.top=$rs.scrollTop(document)+"px",j.style.marginTop="10px"):(j.style.top=e/2+"px",j.style.marginTop=-(b/2-$rs.scrollTop(document))+"px");a>d?(j.style.left=$rs.scrollLeft(document)+"px",j.style.marginLeft="0"):(j.style.left="50%",j.style.marginLeft=-(a/2-$rs.scrollLeft(document))+"px")},h=function(a){27===a.keyCode&&
rspkr.ui.Lightbox.hide()};return{init:function(){var a=rspkr.pub.Config;b=a.item("ui.overlay.overlayStyles");d=a.item("ui.overlay.contentStyles");k=a.item("ui.overlay.contentTemplate");rspkr.log("[rspkr.ui.Lightbox] Heartbeat!")},show:function(a,c,e,q,f){a=a||"";e=e||!1;m?(m.style.display="",j.style.display=""):(m=document.createElement("div"),m.id="rslightbox_overlay",j=document.createElement("div"),j.id="rslightbox_contentcontainer",j.innerHTML=rspkr.st.r().replaceTokens(k.join("\n"),{rsLIGHTBOX_CLOSE_LABELrs:rspkr.cfg.getPhrase("close")}),
$rs.setAttr(m,"style",b.join(";")),$rs.setAttr(j,"style",d.join(";")),document.body.appendChild(m),document.body.appendChild(j),rspkr.evt("onSettingsLoaded",{func:rspkr.st.r().handlers.changed.addButtonEvents,context:rspkr.st.r().handlers.changed,params:[this]}));var s=$rs.get("rslightbox_closer");rspkr.ui.addFocusHandler(s,!1);$rs.regEvent(s,"click",rspkr.ui.Lightbox.hide);$rs.regEvent(m,"click",rspkr.ui.Lightbox.hide);$rs.regEvent(document.body,"keyup",h);if((s=document.documentElement)&&document.all)s.style.overflowX=
s.style.overflowY="hidden";if(a!=r||e)$rs.get("#rslightbox_content").innerHTML="",$rs.css("#rslightbox_content","height","auto"),/^http/i.test(a)?$rs.findIn("#rslightbox_content","iframe").length||(e=document.createElement("iframe"),e.src=a,e.className="rslightbox-iframe",void 0===f&&(f=2E3),$rs.get("#rslightbox_content").appendChild(e)):"<"==a.substr(0,1)&&($rs.get("#rslightbox_content").innerHTML=a),$rs.get("#rslightbox_buttons").innerHTML=c,r=a;u=void 0!==f&&!isNaN(f)?f:!rspkr.basicMode?$rs.get("#rslightbox_content").clientHeight:
$rs.get("#rslightbox_content").scrollHeight;a=$rs.findIn("#rslightbox_content",".rsform-row");for(f=0;f<a.length;f++){c=$rs.findIn(a[f],"input, a, select");$rs.isArray(c)||(c=[c]);for(e=0;e<c.length;e++)rspkr.ui.addFocusHandler(c[e],!1,a[f])}var v=$rs.findIn("#rslightbox_buttons",".rssettings-button-close");rspkr.ui.addFocusHandler(v,!1);(a=$rs.findIn("#rsform_wrapper",".rssettings-button-gotobottom"))&&!$rs.isArray(a)&&rspkr.ui.addFocusHandler(a,!1);(a=$rs.findIn("#rslightbox_buttons",".rssettings-button-gototop"))&&
!$rs.isArray(a)&&rspkr.ui.addFocusHandler(a,!1);var w=$rs.findIn("#rslightbox_content","input");$rs.isArray(w)&&0<w.length?setTimeout(function(){rspkr.ui.focus(w[0]);rspkr.Common.addEvent("onFocusIn",function(a){a.className&&$rs.hasClass(a,"rssettings-button-gototop")?rspkr.ui.focus(w[0]):a.className&&$rs.hasClass(a,"rssettings-button-gotobottom")&&rspkr.ui.focus(v)})},200):$rs.isArray(w)||setTimeout(function(){rspkr.ui.focus(w)},200);p();$rs.regEvent(window,"resize",p);"function"==typeof q&&q.apply(this,
[j])},hide:function(){m.style.display="none";j.style.display="none";$rs.unregEvent(window,"resize",p);$rs.unregEvent($rs.get("#rslightbox_closer"),"click",rspkr.ui.Lightbox.hide);$rs.unregEvent(m,"click",rspkr.ui.Lightbox.hide);$rs.unregEvent(document.body,"keyup",h);var a;if((a=document.documentElement)&&document.all)a.style.overflowX=a.style.overflowY="auto";rspkr.ui.updateFocus()},reposition:e}}();