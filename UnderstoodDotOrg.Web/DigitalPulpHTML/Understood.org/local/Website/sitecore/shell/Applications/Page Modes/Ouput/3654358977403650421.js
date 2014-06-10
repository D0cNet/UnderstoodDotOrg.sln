if (!("console" in window))
{
  window.console = {};
}

var methods =
{
  assert: function(truth, message)
  {
  },

  clear: function()
  {
  },

  close: function()
  {
  },

  copy: function(text)
  {
  },

  count: function()
  {
  },

  debug: function()
  {
  },

  dir: function(object)
  {
  },

  dirxml: function(node)
  {
  },

  error: function()
  {
  },

  group: function()
  {
  },

  groupStart: function()
  {
  },

  groupEnd: function()
  {
  },

  info: function()
  {
  },
  
  log: function()
  {
  },

  open: function()
  {
  },

  profile: function()
  {
  },

  profileEnd: function()
  {
  },

  time: function(name)
  {
  },

  timeEnd: function(name)
  {
  },

  trace: function()
  {
  },

  warn: function()
  {
  }
};

for (var methodName in methods)
{
  if (!(methodName in console))
  {
    console[methodName] = methods[methodName];
  }
};/*!
 * jQuery JavaScript Library v1.5.1
 * http://jquery.com/
 *
 * Copyright 2011, John Resig
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * Includes Sizzle.js
 * http://sizzlejs.com/
 * Copyright 2011, The Dojo Foundation
 * Released under the MIT, BSD, and GPL Licenses.
 *
 * Date: Wed Feb 23 13:55:29 2011 -0500
 */
(function(a,b){function cg(a){return d.isWindow(a)?a:a.nodeType===9?a.defaultView||a.parentWindow:!1}function cd(a){if(!bZ[a]){var b=d("<"+a+">").appendTo("body"),c=b.css("display");b.remove();if(c==="none"||c==="")c="block";bZ[a]=c}return bZ[a]}function cc(a,b){var c={};d.each(cb.concat.apply([],cb.slice(0,b)),function(){c[this]=a});return c}function bY(){try{return new a.ActiveXObject("Microsoft.XMLHTTP")}catch(b){}}function bX(){try{return new a.XMLHttpRequest}catch(b){}}function bW(){d(a).unload(function(){for(var a in bU)bU[a](0,1)})}function bQ(a,c){a.dataFilter&&(c=a.dataFilter(c,a.dataType));var e=a.dataTypes,f={},g,h,i=e.length,j,k=e[0],l,m,n,o,p;for(g=1;g<i;g++){if(g===1)for(h in a.converters)typeof h==="string"&&(f[h.toLowerCase()]=a.converters[h]);l=k,k=e[g];if(k==="*")k=l;else if(l!=="*"&&l!==k){m=l+" "+k,n=f[m]||f["* "+k];if(!n){p=b;for(o in f){j=o.split(" ");if(j[0]===l||j[0]==="*"){p=f[j[1]+" "+k];if(p){o=f[o],o===!0?n=p:p===!0&&(n=o);break}}}}!n&&!p&&d.error("No conversion from "+m.replace(" "," to ")),n!==!0&&(c=n?n(c):p(o(c)))}}return c}function bP(a,c,d){var e=a.contents,f=a.dataTypes,g=a.responseFields,h,i,j,k;for(i in g)i in d&&(c[g[i]]=d[i]);while(f[0]==="*")f.shift(),h===b&&(h=a.mimeType||c.getResponseHeader("content-type"));if(h)for(i in e)if(e[i]&&e[i].test(h)){f.unshift(i);break}if(f[0]in d)j=f[0];else{for(i in d){if(!f[0]||a.converters[i+" "+f[0]]){j=i;break}k||(k=i)}j=j||k}if(j){j!==f[0]&&f.unshift(j);return d[j]}}function bO(a,b,c,e){if(d.isArray(b)&&b.length)d.each(b,function(b,f){c||bq.test(a)?e(a,f):bO(a+"["+(typeof f==="object"||d.isArray(f)?b:"")+"]",f,c,e)});else if(c||b==null||typeof b!=="object")e(a,b);else if(d.isArray(b)||d.isEmptyObject(b))e(a,"");else for(var f in b)bO(a+"["+f+"]",b[f],c,e)}function bN(a,c,d,e,f,g){f=f||c.dataTypes[0],g=g||{},g[f]=!0;var h=a[f],i=0,j=h?h.length:0,k=a===bH,l;for(;i<j&&(k||!l);i++)l=h[i](c,d,e),typeof l==="string"&&(!k||g[l]?l=b:(c.dataTypes.unshift(l),l=bN(a,c,d,e,l,g)));(k||!l)&&!g["*"]&&(l=bN(a,c,d,e,"*",g));return l}function bM(a){return function(b,c){typeof b!=="string"&&(c=b,b="*");if(d.isFunction(c)){var e=b.toLowerCase().split(bB),f=0,g=e.length,h,i,j;for(;f<g;f++)h=e[f],j=/^\+/.test(h),j&&(h=h.substr(1)||"*"),i=a[h]=a[h]||[],i[j?"unshift":"push"](c)}}}function bo(a,b,c){var e=b==="width"?bi:bj,f=b==="width"?a.offsetWidth:a.offsetHeight;if(c==="border")return f;d.each(e,function(){c||(f-=parseFloat(d.css(a,"padding"+this))||0),c==="margin"?f+=parseFloat(d.css(a,"margin"+this))||0:f-=parseFloat(d.css(a,"border"+this+"Width"))||0});return f}function ba(a,b){b.src?d.ajax({url:b.src,async:!1,dataType:"script"}):d.globalEval(b.text||b.textContent||b.innerHTML||""),b.parentNode&&b.parentNode.removeChild(b)}function _(a){return"getElementsByTagName"in a?a.getElementsByTagName("*"):"querySelectorAll"in a?a.querySelectorAll("*"):[]}function $(a,b){if(b.nodeType===1){var c=b.nodeName.toLowerCase();b.clearAttributes(),b.mergeAttributes(a);if(c==="object")b.outerHTML=a.outerHTML;else if(c!=="input"||a.type!=="checkbox"&&a.type!=="radio"){if(c==="option")b.selected=a.defaultSelected;else if(c==="input"||c==="textarea")b.defaultValue=a.defaultValue}else a.checked&&(b.defaultChecked=b.checked=a.checked),b.value!==a.value&&(b.value=a.value);b.removeAttribute(d.expando)}}function Z(a,b){if(b.nodeType===1&&d.hasData(a)){var c=d.expando,e=d.data(a),f=d.data(b,e);if(e=e[c]){var g=e.events;f=f[c]=d.extend({},e);if(g){delete f.handle,f.events={};for(var h in g)for(var i=0,j=g[h].length;i<j;i++)d.event.add(b,h+(g[h][i].namespace?".":"")+g[h][i].namespace,g[h][i],g[h][i].data)}}}}function Y(a,b){return d.nodeName(a,"table")?a.getElementsByTagName("tbody")[0]||a.appendChild(a.ownerDocument.createElement("tbody")):a}function O(a,b,c){if(d.isFunction(b))return d.grep(a,function(a,d){var e=!!b.call(a,d,a);return e===c});if(b.nodeType)return d.grep(a,function(a,d){return a===b===c});if(typeof b==="string"){var e=d.grep(a,function(a){return a.nodeType===1});if(J.test(b))return d.filter(b,e,!c);b=d.filter(b,e)}return d.grep(a,function(a,e){return d.inArray(a,b)>=0===c})}function N(a){return!a||!a.parentNode||a.parentNode.nodeType===11}function F(a,b){return(a&&a!=="*"?a+".":"")+b.replace(r,"`").replace(s,"&")}function E(a){var b,c,e,f,g,h,i,j,k,l,m,n,o,q=[],r=[],s=d._data(this,"events");if(a.liveFired!==this&&s&&s.live&&!a.target.disabled&&(!a.button||a.type!=="click")){a.namespace&&(n=new RegExp("(^|\\.)"+a.namespace.split(".").join("\\.(?:.*\\.)?")+"(\\.|$)")),a.liveFired=this;var t=s.live.slice(0);for(i=0;i<t.length;i++)g=t[i],g.origType.replace(p,"")===a.type?r.push(g.selector):t.splice(i--,1);f=d(a.target).closest(r,a.currentTarget);for(j=0,k=f.length;j<k;j++){m=f[j];for(i=0;i<t.length;i++){g=t[i];if(m.selector===g.selector&&(!n||n.test(g.namespace))&&!m.elem.disabled){h=m.elem,e=null;if(g.preType==="mouseenter"||g.preType==="mouseleave")a.type=g.preType,e=d(a.relatedTarget).closest(g.selector)[0];(!e||e!==h)&&q.push({elem:h,handleObj:g,level:m.level})}}}for(j=0,k=q.length;j<k;j++){f=q[j];if(c&&f.level>c)break;a.currentTarget=f.elem,a.data=f.handleObj.data,a.handleObj=f.handleObj,o=f.handleObj.origHandler.apply(f.elem,arguments);if(o===!1||a.isPropagationStopped()){c=f.level,o===!1&&(b=!1);if(a.isImmediatePropagationStopped())break}}return b}}function C(a,c,e){var f=d.extend({},e[0]);f.type=a,f.originalEvent={},f.liveFired=b,d.event.handle.call(c,f),f.isDefaultPrevented()&&e[0].preventDefault()}function w(){return!0}function v(){return!1}function g(a){for(var b in a)if(b!=="toJSON")return!1;return!0}function f(a,c,f){if(f===b&&a.nodeType===1){f=a.getAttribute("data-"+c);if(typeof f==="string"){try{f=f==="true"?!0:f==="false"?!1:f==="null"?null:d.isNaN(f)?e.test(f)?d.parseJSON(f):f:parseFloat(f)}catch(g){}d.data(a,c,f)}else f=b}return f}var c=a.document,d=function(){function I(){if(!d.isReady){try{c.documentElement.doScroll("left")}catch(a){setTimeout(I,1);return}d.ready()}}var d=function(a,b){return new d.fn.init(a,b,g)},e=a.jQuery,f=a.$,g,h=/^(?:[^<]*(<[\w\W]+>)[^>]*$|#([\w\-]+)$)/,i=/\S/,j=/^\s+/,k=/\s+$/,l=/\d/,m=/^<(\w+)\s*\/?>(?:<\/\1>)?$/,n=/^[\],:{}\s]*$/,o=/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g,p=/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,q=/(?:^|:|,)(?:\s*\[)+/g,r=/(webkit)[ \/]([\w.]+)/,s=/(opera)(?:.*version)?[ \/]([\w.]+)/,t=/(msie) ([\w.]+)/,u=/(mozilla)(?:.*? rv:([\w.]+))?/,v=navigator.userAgent,w,x=!1,y,z="then done fail isResolved isRejected promise".split(" "),A,B=Object.prototype.toString,C=Object.prototype.hasOwnProperty,D=Array.prototype.push,E=Array.prototype.slice,F=String.prototype.trim,G=Array.prototype.indexOf,H={};d.fn=d.prototype={constructor:d,init:function(a,e,f){var g,i,j,k;if(!a)return this;if(a.nodeType){this.context=this[0]=a,this.length=1;return this}if(a==="body"&&!e&&c.body){this.context=c,this[0]=c.body,this.selector="body",this.length=1;return this}if(typeof a==="string"){g=h.exec(a);if(!g||!g[1]&&e)return!e||e.jquery?(e||f).find(a):this.constructor(e).find(a);if(g[1]){e=e instanceof d?e[0]:e,k=e?e.ownerDocument||e:c,j=m.exec(a),j?d.isPlainObject(e)?(a=[c.createElement(j[1])],d.fn.attr.call(a,e,!0)):a=[k.createElement(j[1])]:(j=d.buildFragment([g[1]],[k]),a=(j.cacheable?d.clone(j.fragment):j.fragment).childNodes);return d.merge(this,a)}i=c.getElementById(g[2]);if(i&&i.parentNode){if(i.id!==g[2])return f.find(a);this.length=1,this[0]=i}this.context=c,this.selector=a;return this}if(d.isFunction(a))return f.ready(a);a.selector!==b&&(this.selector=a.selector,this.context=a.context);return d.makeArray(a,this)},selector:"",jquery:"1.5.1",length:0,size:function(){return this.length},toArray:function(){return E.call(this,0)},get:function(a){return a==null?this.toArray():a<0?this[this.length+a]:this[a]},pushStack:function(a,b,c){var e=this.constructor();d.isArray(a)?D.apply(e,a):d.merge(e,a),e.prevObject=this,e.context=this.context,b==="find"?e.selector=this.selector+(this.selector?" ":"")+c:b&&(e.selector=this.selector+"."+b+"("+c+")");return e},each:function(a,b){return d.each(this,a,b)},ready:function(a){d.bindReady(),y.done(a);return this},eq:function(a){return a===-1?this.slice(a):this.slice(a,+a+1)},first:function(){return this.eq(0)},last:function(){return this.eq(-1)},slice:function(){return this.pushStack(E.apply(this,arguments),"slice",E.call(arguments).join(","))},map:function(a){return this.pushStack(d.map(this,function(b,c){return a.call(b,c,b)}))},end:function(){return this.prevObject||this.constructor(null)},push:D,sort:[].sort,splice:[].splice},d.fn.init.prototype=d.fn,d.extend=d.fn.extend=function(){var a,c,e,f,g,h,i=arguments[0]||{},j=1,k=arguments.length,l=!1;typeof i==="boolean"&&(l=i,i=arguments[1]||{},j=2),typeof i!=="object"&&!d.isFunction(i)&&(i={}),k===j&&(i=this,--j);for(;j<k;j++)if((a=arguments[j])!=null)for(c in a){e=i[c],f=a[c];if(i===f)continue;l&&f&&(d.isPlainObject(f)||(g=d.isArray(f)))?(g?(g=!1,h=e&&d.isArray(e)?e:[]):h=e&&d.isPlainObject(e)?e:{},i[c]=d.extend(l,h,f)):f!==b&&(i[c]=f)}return i},d.extend({noConflict:function(b){a.$=f,b&&(a.jQuery=e);return d},isReady:!1,readyWait:1,ready:function(a){a===!0&&d.readyWait--;if(!d.readyWait||a!==!0&&!d.isReady){if(!c.body)return setTimeout(d.ready,1);d.isReady=!0;if(a!==!0&&--d.readyWait>0)return;y.resolveWith(c,[d]),d.fn.trigger&&d(c).trigger("ready").unbind("ready")}},bindReady:function(){if(!x){x=!0;if(c.readyState==="complete")return setTimeout(d.ready,1);if(c.addEventListener)c.addEventListener("DOMContentLoaded",A,!1),a.addEventListener("load",d.ready,!1);else if(c.attachEvent){c.attachEvent("onreadystatechange",A),a.attachEvent("onload",d.ready);var b=!1;try{b=a.frameElement==null}catch(e){}c.documentElement.doScroll&&b&&I()}}},isFunction:function(a){return d.type(a)==="function"},isArray:Array.isArray||function(a){return d.type(a)==="array"},isWindow:function(a){return a&&typeof a==="object"&&"setInterval"in a},isNaN:function(a){return a==null||!l.test(a)||isNaN(a)},type:function(a){return a==null?String(a):H[B.call(a)]||"object"},isPlainObject:function(a){if(!a||d.type(a)!=="object"||a.nodeType||d.isWindow(a))return!1;if(a.constructor&&!C.call(a,"constructor")&&!C.call(a.constructor.prototype,"isPrototypeOf"))return!1;var c;for(c in a){}return c===b||C.call(a,c)},isEmptyObject:function(a){for(var b in a)return!1;return!0},error:function(a){throw a},parseJSON:function(b){if(typeof b!=="string"||!b)return null;b=d.trim(b);if(n.test(b.replace(o,"@").replace(p,"]").replace(q,"")))return a.JSON&&a.JSON.parse?a.JSON.parse(b):(new Function("return "+b))();d.error("Invalid JSON: "+b)},parseXML:function(b,c,e){a.DOMParser?(e=new DOMParser,c=e.parseFromString(b,"text/xml")):(c=new ActiveXObject("Microsoft.XMLDOM"),c.async="false",c.loadXML(b)),e=c.documentElement,(!e||!e.nodeName||e.nodeName==="parsererror")&&d.error("Invalid XML: "+b);return c},noop:function(){},globalEval:function(a){if(a&&i.test(a)){var b=c.head||c.getElementsByTagName("head")[0]||c.documentElement,e=c.createElement("script");d.support.scriptEval()?e.appendChild(c.createTextNode(a)):e.text=a,b.insertBefore(e,b.firstChild),b.removeChild(e)}},nodeName:function(a,b){return a.nodeName&&a.nodeName.toUpperCase()===b.toUpperCase()},each:function(a,c,e){var f,g=0,h=a.length,i=h===b||d.isFunction(a);if(e){if(i){for(f in a)if(c.apply(a[f],e)===!1)break}else for(;g<h;)if(c.apply(a[g++],e)===!1)break}else if(i){for(f in a)if(c.call(a[f],f,a[f])===!1)break}else for(var j=a[0];g<h&&c.call(j,g,j)!==!1;j=a[++g]){}return a},trim:F?function(a){return a==null?"":F.call(a)}:function(a){return a==null?"":(a+"").replace(j,"").replace(k,"")},makeArray:function(a,b){var c=b||[];if(a!=null){var e=d.type(a);a.length==null||e==="string"||e==="function"||e==="regexp"||d.isWindow(a)?D.call(c,a):d.merge(c,a)}return c},inArray:function(a,b){if(b.indexOf)return b.indexOf(a);for(var c=0,d=b.length;c<d;c++)if(b[c]===a)return c;return-1},merge:function(a,c){var d=a.length,e=0;if(typeof c.length==="number")for(var f=c.length;e<f;e++)a[d++]=c[e];else while(c[e]!==b)a[d++]=c[e++];a.length=d;return a},grep:function(a,b,c){var d=[],e;c=!!c;for(var f=0,g=a.length;f<g;f++)e=!!b(a[f],f),c!==e&&d.push(a[f]);return d},map:function(a,b,c){var d=[],e;for(var f=0,g=a.length;f<g;f++)e=b(a[f],f,c),e!=null&&(d[d.length]=e);return d.concat.apply([],d)},guid:1,proxy:function(a,c,e){arguments.length===2&&(typeof c==="string"?(e=a,a=e[c],c=b):c&&!d.isFunction(c)&&(e=c,c=b)),!c&&a&&(c=function(){return a.apply(e||this,arguments)}),a&&(c.guid=a.guid=a.guid||c.guid||d.guid++);return c},access:function(a,c,e,f,g,h){var i=a.length;if(typeof c==="object"){for(var j in c)d.access(a,j,c[j],f,g,e);return a}if(e!==b){f=!h&&f&&d.isFunction(e);for(var k=0;k<i;k++)g(a[k],c,f?e.call(a[k],k,g(a[k],c)):e,h);return a}return i?g(a[0],c):b},now:function(){return(new Date).getTime()},_Deferred:function(){var a=[],b,c,e,f={done:function(){if(!e){var c=arguments,g,h,i,j,k;b&&(k=b,b=0);for(g=0,h=c.length;g<h;g++)i=c[g],j=d.type(i),j==="array"?f.done.apply(f,i):j==="function"&&a.push(i);k&&f.resolveWith(k[0],k[1])}return this},resolveWith:function(d,f){if(!e&&!b&&!c){c=1;try{while(a[0])a.shift().apply(d,f)}catch(g){throw g}finally{b=[d,f],c=0}}return this},resolve:function(){f.resolveWith(d.isFunction(this.promise)?this.promise():this,arguments);return this},isResolved:function(){return c||b},cancel:function(){e=1,a=[];return this}};return f},Deferred:function(a){var b=d._Deferred(),c=d._Deferred(),e;d.extend(b,{then:function(a,c){b.done(a).fail(c);return this},fail:c.done,rejectWith:c.resolveWith,reject:c.resolve,isRejected:c.isResolved,promise:function(a){if(a==null){if(e)return e;e=a={}}var c=z.length;while(c--)a[z[c]]=b[z[c]];return a}}),b.done(c.cancel).fail(b.cancel),delete b.cancel,a&&a.call(b,b);return b},when:function(a){var b=arguments.length,c=b<=1&&a&&d.isFunction(a.promise)?a:d.Deferred(),e=c.promise();if(b>1){var f=E.call(arguments,0),g=b,h=function(a){return function(b){f[a]=arguments.length>1?E.call(arguments,0):b,--g||c.resolveWith(e,f)}};while(b--)a=f[b],a&&d.isFunction(a.promise)?a.promise().then(h(b),c.reject):--g;g||c.resolveWith(e,f)}else c!==a&&c.resolve(a);return e},uaMatch:function(a){a=a.toLowerCase();var b=r.exec(a)||s.exec(a)||t.exec(a)||a.indexOf("compatible")<0&&u.exec(a)||[];return{browser:b[1]||"",version:b[2]||"0"}},sub:function(){function a(b,c){return new a.fn.init(b,c)}d.extend(!0,a,this),a.superclass=this,a.fn=a.prototype=this(),a.fn.constructor=a,a.subclass=this.subclass,a.fn.init=function b(b,c){c&&c instanceof d&&!(c instanceof a)&&(c=a(c));return d.fn.init.call(this,b,c,e)},a.fn.init.prototype=a.fn;var e=a(c);return a},browser:{}}),y=d._Deferred(),d.each("Boolean Number String Function Array Date RegExp Object".split(" "),function(a,b){H["[object "+b+"]"]=b.toLowerCase()}),w=d.uaMatch(v),w.browser&&(d.browser[w.browser]=!0,d.browser.version=w.version),d.browser.webkit&&(d.browser.safari=!0),G&&(d.inArray=function(a,b){return G.call(b,a)}),i.test(" ")&&(j=/^[\s\xA0]+/,k=/[\s\xA0]+$/),g=d(c),c.addEventListener?A=function(){c.removeEventListener("DOMContentLoaded",A,!1),d.ready()}:c.attachEvent&&(A=function(){c.readyState==="complete"&&(c.detachEvent("onreadystatechange",A),d.ready())});return d}();(function(){d.support={};var b=c.createElement("div");b.style.display="none",b.innerHTML="   <link/><table></table><a href='/a' style='color:red;float:left;opacity:.55;'>a</a><input type='checkbox'/>";var e=b.getElementsByTagName("*"),f=b.getElementsByTagName("a")[0],g=c.createElement("select"),h=g.appendChild(c.createElement("option")),i=b.getElementsByTagName("input")[0];if(e&&e.length&&f){d.support={leadingWhitespace:b.firstChild.nodeType===3,tbody:!b.getElementsByTagName("tbody").length,htmlSerialize:!!b.getElementsByTagName("link").length,style:/red/.test(f.getAttribute("style")),hrefNormalized:f.getAttribute("href")==="/a",opacity:/^0.55$/.test(f.style.opacity),cssFloat:!!f.style.cssFloat,checkOn:i.value==="on",optSelected:h.selected,deleteExpando:!0,optDisabled:!1,checkClone:!1,noCloneEvent:!0,noCloneChecked:!0,boxModel:null,inlineBlockNeedsLayout:!1,shrinkWrapBlocks:!1,reliableHiddenOffsets:!0},i.checked=!0,d.support.noCloneChecked=i.cloneNode(!0).checked,g.disabled=!0,d.support.optDisabled=!h.disabled;var j=null;d.support.scriptEval=function(){if(j===null){var b=c.documentElement,e=c.createElement("script"),f="script"+d.now();try{e.appendChild(c.createTextNode("window."+f+"=1;"))}catch(g){}b.insertBefore(e,b.firstChild),a[f]?(j=!0,delete a[f]):j=!1,b.removeChild(e),b=e=f=null}return j};try{delete b.test}catch(k){d.support.deleteExpando=!1}!b.addEventListener&&b.attachEvent&&b.fireEvent&&(b.attachEvent("onclick",function l(){d.support.noCloneEvent=!1,b.detachEvent("onclick",l)}),b.cloneNode(!0).fireEvent("onclick")),b=c.createElement("div"),b.innerHTML="<input type='radio' name='radiotest' checked='checked'/>";var m=c.createDocumentFragment();m.appendChild(b.firstChild),d.support.checkClone=m.cloneNode(!0).cloneNode(!0).lastChild.checked,d(function(){var a=c.createElement("div"),b=c.getElementsByTagName("body")[0];if(b){a.style.width=a.style.paddingLeft="1px",b.appendChild(a),d.boxModel=d.support.boxModel=a.offsetWidth===2,"zoom"in a.style&&(a.style.display="inline",a.style.zoom=1,d.support.inlineBlockNeedsLayout=a.offsetWidth===2,a.style.display="",a.innerHTML="<div style='width:4px;'></div>",d.support.shrinkWrapBlocks=a.offsetWidth!==2),a.innerHTML="<table><tr><td style='padding:0;border:0;display:none'></td><td>t</td></tr></table>";var e=a.getElementsByTagName("td");d.support.reliableHiddenOffsets=e[0].offsetHeight===0,e[0].style.display="",e[1].style.display="none",d.support.reliableHiddenOffsets=d.support.reliableHiddenOffsets&&e[0].offsetHeight===0,a.innerHTML="",b.removeChild(a).style.display="none",a=e=null}});var n=function(a){var b=c.createElement("div");a="on"+a;if(!b.attachEvent)return!0;var d=a in b;d||(b.setAttribute(a,"return;"),d=typeof b[a]==="function"),b=null;return d};d.support.submitBubbles=n("submit"),d.support.changeBubbles=n("change"),b=e=f=null}})();var e=/^(?:\{.*\}|\[.*\])$/;d.extend({cache:{},uuid:0,expando:"jQuery"+(d.fn.jquery+Math.random()).replace(/\D/g,""),noData:{embed:!0,object:"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000",applet:!0},hasData:function(a){a=a.nodeType?d.cache[a[d.expando]]:a[d.expando];return!!a&&!g(a)},data:function(a,c,e,f){if(d.acceptData(a)){var g=d.expando,h=typeof c==="string",i,j=a.nodeType,k=j?d.cache:a,l=j?a[d.expando]:a[d.expando]&&d.expando;if((!l||f&&l&&!k[l][g])&&h&&e===b)return;l||(j?a[d.expando]=l=++d.uuid:l=d.expando),k[l]||(k[l]={},j||(k[l].toJSON=d.noop));if(typeof c==="object"||typeof c==="function")f?k[l][g]=d.extend(k[l][g],c):k[l]=d.extend(k[l],c);i=k[l],f&&(i[g]||(i[g]={}),i=i[g]),e!==b&&(i[c]=e);if(c==="events"&&!i[c])return i[g]&&i[g].events;return h?i[c]:i}},removeData:function(b,c,e){if(d.acceptData(b)){var f=d.expando,h=b.nodeType,i=h?d.cache:b,j=h?b[d.expando]:d.expando;if(!i[j])return;if(c){var k=e?i[j][f]:i[j];if(k){delete k[c];if(!g(k))return}}if(e){delete i[j][f];if(!g(i[j]))return}var l=i[j][f];d.support.deleteExpando||i!=a?delete i[j]:i[j]=null,l?(i[j]={},h||(i[j].toJSON=d.noop),i[j][f]=l):h&&(d.support.deleteExpando?delete b[d.expando]:b.removeAttribute?b.removeAttribute(d.expando):b[d.expando]=null)}},_data:function(a,b,c){return d.data(a,b,c,!0)},acceptData:function(a){if(a.nodeName){var b=d.noData[a.nodeName.toLowerCase()];if(b)return b!==!0&&a.getAttribute("classid")===b}return!0}}),d.fn.extend({data:function(a,c){var e=null;if(typeof a==="undefined"){if(this.length){e=d.data(this[0]);if(this[0].nodeType===1){var g=this[0].attributes,h;for(var i=0,j=g.length;i<j;i++)h=g[i].name,h.indexOf("data-")===0&&(h=h.substr(5),f(this[0],h,e[h]))}}return e}if(typeof a==="object")return this.each(function(){d.data(this,a)});var k=a.split(".");k[1]=k[1]?"."+k[1]:"";if(c===b){e=this.triggerHandler("getData"+k[1]+"!",[k[0]]),e===b&&this.length&&(e=d.data(this[0],a),e=f(this[0],a,e));return e===b&&k[1]?this.data(k[0]):e}return this.each(function(){var b=d(this),e=[k[0],c];b.triggerHandler("setData"+k[1]+"!",e),d.data(this,a,c),b.triggerHandler("changeData"+k[1]+"!",e)})},removeData:function(a){return this.each(function(){d.removeData(this,a)})}}),d.extend({queue:function(a,b,c){if(a){b=(b||"fx")+"queue";var e=d._data(a,b);if(!c)return e||[];!e||d.isArray(c)?e=d._data(a,b,d.makeArray(c)):e.push(c);return e}},dequeue:function(a,b){b=b||"fx";var c=d.queue(a,b),e=c.shift();e==="inprogress"&&(e=c.shift()),e&&(b==="fx"&&c.unshift("inprogress"),e.call(a,function(){d.dequeue(a,b)})),c.length||d.removeData(a,b+"queue",!0)}}),d.fn.extend({queue:function(a,c){typeof a!=="string"&&(c=a,a="fx");if(c===b)return d.queue(this[0],a);return this.each(function(b){var e=d.queue(this,a,c);a==="fx"&&e[0]!=="inprogress"&&d.dequeue(this,a)})},dequeue:function(a){return this.each(function(){d.dequeue(this,a)})},delay:function(a,b){a=d.fx?d.fx.speeds[a]||a:a,b=b||"fx";return this.queue(b,function(){var c=this;setTimeout(function(){d.dequeue(c,b)},a)})},clearQueue:function(a){return this.queue(a||"fx",[])}});var h=/[\n\t\r]/g,i=/\s+/,j=/\r/g,k=/^(?:href|src|style)$/,l=/^(?:button|input)$/i,m=/^(?:button|input|object|select|textarea)$/i,n=/^a(?:rea)?$/i,o=/^(?:radio|checkbox)$/i;d.props={"for":"htmlFor","class":"className",readonly:"readOnly",maxlength:"maxLength",cellspacing:"cellSpacing",rowspan:"rowSpan",colspan:"colSpan",tabindex:"tabIndex",usemap:"useMap",frameborder:"frameBorder"},d.fn.extend({attr:function(a,b){return d.access(this,a,b,!0,d.attr)},removeAttr:function(a,b){return this.each(function(){d.attr(this,a,""),this.nodeType===1&&this.removeAttribute(a)})},addClass:function(a){if(d.isFunction(a))return this.each(function(b){var c=d(this);c.addClass(a.call(this,b,c.attr("class")))});if(a&&typeof a==="string"){var b=(a||"").split(i);for(var c=0,e=this.length;c<e;c++){var f=this[c];if(f.nodeType===1)if(f.className){var g=" "+f.className+" ",h=f.className;for(var j=0,k=b.length;j<k;j++)g.indexOf(" "+b[j]+" ")<0&&(h+=" "+b[j]);f.className=d.trim(h)}else f.className=a}}return this},removeClass:function(a){if(d.isFunction(a))return this.each(function(b){var c=d(this);c.removeClass(a.call(this,b,c.attr("class")))});if(a&&typeof a==="string"||a===b){var c=(a||"").split(i);for(var e=0,f=this.length;e<f;e++){var g=this[e];if(g.nodeType===1&&g.className)if(a){var j=(" "+g.className+" ").replace(h," ");for(var k=0,l=c.length;k<l;k++)j=j.replace(" "+c[k]+" "," ");g.className=d.trim(j)}else g.className=""}}return this},toggleClass:function(a,b){var c=typeof a,e=typeof b==="boolean";if(d.isFunction(a))return this.each(function(c){var e=d(this);e.toggleClass(a.call(this,c,e.attr("class"),b),b)});return this.each(function(){if(c==="string"){var f,g=0,h=d(this),j=b,k=a.split(i);while(f=k[g++])j=e?j:!h.hasClass(f),h[j?"addClass":"removeClass"](f)}else if(c==="undefined"||c==="boolean")this.className&&d._data(this,"__className__",this.className),this.className=this.className||a===!1?"":d._data(this,"__className__")||""})},hasClass:function(a){var b=" "+a+" ";for(var c=0,d=this.length;c<d;c++)if((" "+this[c].className+" ").replace(h," ").indexOf(b)>-1)return!0;return!1},val:function(a){if(!arguments.length){var c=this[0];if(c){if(d.nodeName(c,"option")){var e=c.attributes.value;return!e||e.specified?c.value:c.text}if(d.nodeName(c,"select")){var f=c.selectedIndex,g=[],h=c.options,i=c.type==="select-one";if(f<0)return null;for(var k=i?f:0,l=i?f+1:h.length;k<l;k++){var m=h[k];if(m.selected&&(d.support.optDisabled?!m.disabled:m.getAttribute("disabled")===null)&&(!m.parentNode.disabled||!d.nodeName(m.parentNode,"optgroup"))){a=d(m).val();if(i)return a;g.push(a)}}if(i&&!g.length&&h.length)return d(h[f]).val();return g}if(o.test(c.type)&&!d.support.checkOn)return c.getAttribute("value")===null?"on":c.value;return(c.value||"").replace(j,"")}return b}var n=d.isFunction(a);return this.each(function(b){var c=d(this),e=a;if(this.nodeType===1){n&&(e=a.call(this,b,c.val())),e==null?e="":typeof e==="number"?e+="":d.isArray(e)&&(e=d.map(e,function(a){return a==null?"":a+""}));if(d.isArray(e)&&o.test(this.type))this.checked=d.inArray(c.val(),e)>=0;else if(d.nodeName(this,"select")){var f=d.makeArray(e);d("option",this).each(function(){this.selected=d.inArray(d(this).val(),f)>=0}),f.length||(this.selectedIndex=-1)}else this.value=e}})}}),d.extend({attrFn:{val:!0,css:!0,html:!0,text:!0,data:!0,width:!0,height:!0,offset:!0},attr:function(a,c,e,f){if(!a||a.nodeType===3||a.nodeType===8||a.nodeType===2)return b;if(f&&c in d.attrFn)return d(a)[c](e);var g=a.nodeType!==1||!d.isXMLDoc(a),h=e!==b;c=g&&d.props[c]||c;if(a.nodeType===1){var i=k.test(c);if(c==="selected"&&!d.support.optSelected){var j=a.parentNode;j&&(j.selectedIndex,j.parentNode&&j.parentNode.selectedIndex)}if((c in a||a[c]!==b)&&g&&!i){h&&(c==="type"&&l.test(a.nodeName)&&a.parentNode&&d.error("type property can't be changed"),e===null?a.nodeType===1&&a.removeAttribute(c):a[c]=e);if(d.nodeName(a,"form")&&a.getAttributeNode(c))return a.getAttributeNode(c).nodeValue;if(c==="tabIndex"){var o=a.getAttributeNode("tabIndex");return o&&o.specified?o.value:m.test(a.nodeName)||n.test(a.nodeName)&&a.href?0:b}return a[c]}if(!d.support.style&&g&&c==="style"){h&&(a.style.cssText=""+e);return a.style.cssText}h&&a.setAttribute(c,""+e);if(!a.attributes[c]&&(a.hasAttribute&&!a.hasAttribute(c)))return b;var p=!d.support.hrefNormalized&&g&&i?a.getAttribute(c,2):a.getAttribute(c);return p===null?b:p}h&&(a[c]=e);return a[c]}});var p=/\.(.*)$/,q=/^(?:textarea|input|select)$/i,r=/\./g,s=/ /g,t=/[^\w\s.|`]/g,u=function(a){return a.replace(t,"\\$&")};d.event={add:function(c,e,f,g){if(c.nodeType!==3&&c.nodeType!==8){try{d.isWindow(c)&&(c!==a&&!c.frameElement)&&(c=a)}catch(h){}if(f===!1)f=v;else if(!f)return;var i,j;f.handler&&(i=f,f=i.handler),f.guid||(f.guid=d.guid++);var k=d._data(c);if(!k)return;var l=k.events,m=k.handle;l||(k.events=l={}),m||(k.handle=m=function(){return typeof d!=="undefined"&&!d.event.triggered?d.event.handle.apply(m.elem,arguments):b}),m.elem=c,e=e.split(" ");var n,o=0,p;while(n=e[o++]){j=i?d.extend({},i):{handler:f,data:g},n.indexOf(".")>-1?(p=n.split("."),n=p.shift(),j.namespace=p.slice(0).sort().join(".")):(p=[],j.namespace=""),j.type=n,j.guid||(j.guid=f.guid);var q=l[n],r=d.event.special[n]||{};if(!q){q=l[n]=[];if(!r.setup||r.setup.call(c,g,p,m)===!1)c.addEventListener?c.addEventListener(n,m,!1):c.attachEvent&&c.attachEvent("on"+n,m)}r.add&&(r.add.call(c,j),j.handler.guid||(j.handler.guid=f.guid)),q.push(j),d.event.global[n]=!0}c=null}},global:{},remove:function(a,c,e,f){if(a.nodeType!==3&&a.nodeType!==8){e===!1&&(e=v);var g,h,i,j,k=0,l,m,n,o,p,q,r,s=d.hasData(a)&&d._data(a),t=s&&s.events;if(!s||!t)return;c&&c.type&&(e=c.handler,c=c.type);if(!c||typeof c==="string"&&c.charAt(0)==="."){c=c||"";for(h in t)d.event.remove(a,h+c);return}c=c.split(" ");while(h=c[k++]){r=h,q=null,l=h.indexOf(".")<0,m=[],l||(m=h.split("."),h=m.shift(),n=new RegExp("(^|\\.)"+d.map(m.slice(0).sort(),u).join("\\.(?:.*\\.)?")+"(\\.|$)")),p=t[h];if(!p)continue;if(!e){for(j=0;j<p.length;j++){q=p[j];if(l||n.test(q.namespace))d.event.remove(a,r,q.handler,j),p.splice(j--,1)}continue}o=d.event.special[h]||{};for(j=f||0;j<p.length;j++){q=p[j];if(e.guid===q.guid){if(l||n.test(q.namespace))f==null&&p.splice(j--,1),o.remove&&o.remove.call(a,q);if(f!=null)break}}if(p.length===0||f!=null&&p.length===1)(!o.teardown||o.teardown.call(a,m)===!1)&&d.removeEvent(a,h,s.handle),g=null,delete t[h]}if(d.isEmptyObject(t)){var w=s.handle;w&&(w.elem=null),delete s.events,delete s.handle,d.isEmptyObject(s)&&d.removeData(a,b,!0)}}},trigger:function(a,c,e){var f=a.type||a,g=arguments[3];if(!g){a=typeof a==="object"?a[d.expando]?a:d.extend(d.Event(f),a):d.Event(f),f.indexOf("!")>=0&&(a.type=f=f.slice(0,-1),a.exclusive=!0),e||(a.stopPropagation(),d.event.global[f]&&d.each(d.cache,function(){var b=d.expando,e=this[b];e&&e.events&&e.events[f]&&d.event.trigger(a,c,e.handle.elem)}));if(!e||e.nodeType===3||e.nodeType===8)return b;a.result=b,a.target=e,c=d.makeArray(c),c.unshift(a)}a.currentTarget=e;var h=d._data(e,"handle");h&&h.apply(e,c);var i=e.parentNode||e.ownerDocument;try{e&&e.nodeName&&d.noData[e.nodeName.toLowerCase()]||e["on"+f]&&e["on"+f].apply(e,c)===!1&&(a.result=!1,a.preventDefault())}catch(j){}if(!a.isPropagationStopped()&&i)d.event.trigger(a,c,i,!0);else if(!a.isDefaultPrevented()){var k,l=a.target,m=f.replace(p,""),n=d.nodeName(l,"a")&&m==="click",o=d.event.special[m]||{};if((!o._default||o._default.call(e,a)===!1)&&!n&&!(l&&l.nodeName&&d.noData[l.nodeName.toLowerCase()])){try{l[m]&&(k=l["on"+m],k&&(l["on"+m]=null),d.event.triggered=!0,l[m]())}catch(q){}k&&(l["on"+m]=k),d.event.triggered=!1}}},handle:function(c){var e,f,g,h,i,j=[],k=d.makeArray(arguments);c=k[0]=d.event.fix(c||a.event),c.currentTarget=this,e=c.type.indexOf(".")<0&&!c.exclusive,e||(g=c.type.split("."),c.type=g.shift(),j=g.slice(0).sort(),h=new RegExp("(^|\\.)"+j.join("\\.(?:.*\\.)?")+"(\\.|$)")),c.namespace=c.namespace||j.join("."),i=d._data(this,"events"),f=(i||{})[c.type];if(i&&f){f=f.slice(0);for(var l=0,m=f.length;l<m;l++){var n=f[l];if(e||h.test(n.namespace)){c.handler=n.handler,c.data=n.data,c.handleObj=n;var o=n.handler.apply(this,k);o!==b&&(c.result=o,o===!1&&(c.preventDefault(),c.stopPropagation()));if(c.isImmediatePropagationStopped())break}}}return c.result},props:"altKey attrChange attrName bubbles button cancelable charCode clientX clientY ctrlKey currentTarget data detail eventPhase fromElement handler keyCode layerX layerY metaKey newValue offsetX offsetY pageX pageY prevValue relatedNode relatedTarget screenX screenY shiftKey srcElement target toElement view wheelDelta which".split(" "),fix:function(a){if(a[d.expando])return a;var e=a;a=d.Event(e);for(var f=this.props.length,g;f;)g=this.props[--f],a[g]=e[g];a.target||(a.target=a.srcElement||c),a.target.nodeType===3&&(a.target=a.target.parentNode),!a.relatedTarget&&a.fromElement&&(a.relatedTarget=a.fromElement===a.target?a.toElement:a.fromElement);if(a.pageX==null&&a.clientX!=null){var h=c.documentElement,i=c.body;a.pageX=a.clientX+(h&&h.scrollLeft||i&&i.scrollLeft||0)-(h&&h.clientLeft||i&&i.clientLeft||0),a.pageY=a.clientY+(h&&h.scrollTop||i&&i.scrollTop||0)-(h&&h.clientTop||i&&i.clientTop||0)}a.which==null&&(a.charCode!=null||a.keyCode!=null)&&(a.which=a.charCode!=null?a.charCode:a.keyCode),!a.metaKey&&a.ctrlKey&&(a.metaKey=a.ctrlKey),!a.which&&a.button!==b&&(a.which=a.button&1?1:a.button&2?3:a.button&4?2:0);return a},guid:1e8,proxy:d.proxy,special:{ready:{setup:d.bindReady,teardown:d.noop},live:{add:function(a){d.event.add(this,F(a.origType,a.selector),d.extend({},a,{handler:E,guid:a.handler.guid}))},remove:function(a){d.event.remove(this,F(a.origType,a.selector),a)}},beforeunload:{setup:function(a,b,c){d.isWindow(this)&&(this.onbeforeunload=c)},teardown:function(a,b){this.onbeforeunload===b&&(this.onbeforeunload=null)}}}},d.removeEvent=c.removeEventListener?function(a,b,c){a.removeEventListener&&a.removeEventListener(b,c,!1)}:function(a,b,c){a.detachEvent&&a.detachEvent("on"+b,c)},d.Event=function(a){if(!this.preventDefault)return new d.Event(a);a&&a.type?(this.originalEvent=a,this.type=a.type,this.isDefaultPrevented=a.defaultPrevented||a.returnValue===!1||a.getPreventDefault&&a.getPreventDefault()?w:v):this.type=a,this.timeStamp=d.now(),this[d.expando]=!0},d.Event.prototype={preventDefault:function(){this.isDefaultPrevented=w;var a=this.originalEvent;a&&(a.preventDefault?a.preventDefault():a.returnValue=!1)},stopPropagation:function(){this.isPropagationStopped=w;var a=this.originalEvent;a&&(a.stopPropagation&&a.stopPropagation(),a.cancelBubble=!0)},stopImmediatePropagation:function(){this.isImmediatePropagationStopped=w,this.stopPropagation()},isDefaultPrevented:v,isPropagationStopped:v,isImmediatePropagationStopped:v};var x=function(a){var b=a.relatedTarget;try{if(b!==c&&!b.parentNode)return;while(b&&b!==this)b=b.parentNode;b!==this&&(a.type=a.data,d.event.handle.apply(this,arguments))}catch(e){}},y=function(a){a.type=a.data,d.event.handle.apply(this,arguments)};d.each({mouseenter:"mouseover",mouseleave:"mouseout"},function(a,b){d.event.special[a]={setup:function(c){d.event.add(this,b,c&&c.selector?y:x,a)},teardown:function(a){d.event.remove(this,b,a&&a.selector?y:x)}}}),d.support.submitBubbles||(d.event.special.submit={setup:function(a,b){if(this.nodeName&&this.nodeName.toLowerCase()!=="form")d.event.add(this,"click.specialSubmit",function(a){var b=a.target,c=b.type;(c==="submit"||c==="image")&&d(b).closest("form").length&&C("submit",this,arguments)}),d.event.add(this,"keypress.specialSubmit",function(a){var b=a.target,c=b.type;(c==="text"||c==="password")&&d(b).closest("form").length&&a.keyCode===13&&C("submit",this,arguments)});else return!1},teardown:function(a){d.event.remove(this,".specialSubmit")}});if(!d.support.changeBubbles){var z,A=function(a){var b=a.type,c=a.value;b==="radio"||b==="checkbox"?c=a.checked:b==="select-multiple"?c=a.selectedIndex>-1?d.map(a.options,function(a){return a.selected}).join("-"):"":a.nodeName.toLowerCase()==="select"&&(c=a.selectedIndex);return c},B=function B(a){var c=a.target,e,f;if(q.test(c.nodeName)&&!c.readOnly){e=d._data(c,"_change_data"),f=A(c),(a.type!=="focusout"||c.type!=="radio")&&d._data(c,"_change_data",f);if(e===b||f===e)return;if(e!=null||f)a.type="change",a.liveFired=b,d.event.trigger(a,arguments[1],c)}};d.event.special.change={filters:{focusout:B,beforedeactivate:B,click:function(a){var b=a.target,c=b.type;(c==="radio"||c==="checkbox"||b.nodeName.toLowerCase()==="select")&&B.call(this,a)},keydown:function(a){var b=a.target,c=b.type;(a.keyCode===13&&b.nodeName.toLowerCase()!=="textarea"||a.keyCode===32&&(c==="checkbox"||c==="radio")||c==="select-multiple")&&B.call(this,a)},beforeactivate:function(a){var b=a.target;d._data(b,"_change_data",A(b))}},setup:function(a,b){if(this.type==="file")return!1;for(var c in z)d.event.add(this,c+".specialChange",z[c]);return q.test(this.nodeName)},teardown:function(a){d.event.remove(this,".specialChange");return q.test(this.nodeName)}},z=d.event.special.change.filters,z.focus=z.beforeactivate}c.addEventListener&&d.each({focus:"focusin",blur:"focusout"},function(a,b){function c(a){a=d.event.fix(a),a.type=b;return d.event.handle.call(this,a)}d.event.special[b]={setup:function(){this.addEventListener(a,c,!0)},teardown:function(){this.removeEventListener(a,c,!0)}}}),d.each(["bind","one"],function(a,c){d.fn[c]=function(a,e,f){if(typeof a==="object"){for(var g in a)this[c](g,e,a[g],f);return this}if(d.isFunction(e)||e===!1)f=e,e=b;var h=c==="one"?d.proxy(f,function(a){d(this).unbind(a,h);return f.apply(this,arguments)}):f;if(a==="unload"&&c!=="one")this.one(a,e,f);else for(var i=0,j=this.length;i<j;i++)d.event.add(this[i],a,h,e);return this}}),d.fn.extend({unbind:function(a,b){if(typeof a!=="object"||a.preventDefault)for(var e=0,f=this.length;e<f;e++)d.event.remove(this[e],a,b);else for(var c in a)this.unbind(c,a[c]);return this},delegate:function(a,b,c,d){return this.live(b,c,d,a)},undelegate:function(a,b,c){return arguments.length===0?this.unbind("live"):this.die(b,null,c,a)},trigger:function(a,b){return this.each(function(){d.event.trigger(a,b,this)})},triggerHandler:function(a,b){if(this[0]){var c=d.Event(a);c.preventDefault(),c.stopPropagation(),d.event.trigger(c,b,this[0]);return c.result}},toggle:function(a){var b=arguments,c=1;while(c<b.length)d.proxy(a,b[c++]);return this.click(d.proxy(a,function(e){var f=(d._data(this,"lastToggle"+a.guid)||0)%c;d._data(this,"lastToggle"+a.guid,f+1),e.preventDefault();return b[f].apply(this,arguments)||!1}))},hover:function(a,b){return this.mouseenter(a).mouseleave(b||a)}});var D={focus:"focusin",blur:"focusout",mouseenter:"mouseover",mouseleave:"mouseout"};d.each(["live","die"],function(a,c){d.fn[c]=function(a,e,f,g){var h,i=0,j,k,l,m=g||this.selector,n=g?this:d(this.context);if(typeof a==="object"&&!a.preventDefault){for(var o in a)n[c](o,e,a[o],m);return this}d.isFunction(e)&&(f=e,e=b),a=(a||"").split(" ");while((h=a[i++])!=null){j=p.exec(h),k="",j&&(k=j[0],h=h.replace(p,""));if(h==="hover"){a.push("mouseenter"+k,"mouseleave"+k);continue}l=h,h==="focus"||h==="blur"?(a.push(D[h]+k),h=h+k):h=(D[h]||h)+k;if(c==="live")for(var q=0,r=n.length;q<r;q++)d.event.add(n[q],"live."+F(h,m),{data:e,selector:m,handler:f,origType:h,origHandler:f,preType:l});else n.unbind("live."+F(h,m),f)}return this}}),d.each("blur focus focusin focusout load resize scroll unload click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup error".split(" "),function(a,b){d.fn[b]=function(a,c){c==null&&(c=a,a=null);return arguments.length>0?this.bind(b,a,c):this.trigger(b)},d.attrFn&&(d.attrFn[b]=!0)}),function(){function u(a,b,c,d,e,f){for(var g=0,h=d.length;g<h;g++){var i=d[g];if(i){var j=!1;i=i[a];while(i){if(i.sizcache===c){j=d[i.sizset];break}if(i.nodeType===1){f||(i.sizcache=c,i.sizset=g);if(typeof b!=="string"){if(i===b){j=!0;break}}else if(k.filter(b,[i]).length>0){j=i;break}}i=i[a]}d[g]=j}}}function t(a,b,c,d,e,f){for(var g=0,h=d.length;g<h;g++){var i=d[g];if(i){var j=!1;i=i[a];while(i){if(i.sizcache===c){j=d[i.sizset];break}i.nodeType===1&&!f&&(i.sizcache=c,i.sizset=g);if(i.nodeName.toLowerCase()===b){j=i;break}i=i[a]}d[g]=j}}}var a=/((?:\((?:\([^()]+\)|[^()]+)+\)|\[(?:\[[^\[\]]*\]|['"][^'"]*['"]|[^\[\]'"]+)+\]|\\.|[^ >+~,(\[\\]+)+|[>+~])(\s*,\s*)?((?:.|\r|\n)*)/g,e=0,f=Object.prototype.toString,g=!1,h=!0,i=/\\/g,j=/\W/;[0,0].sort(function(){h=!1;return 0});var k=function(b,d,e,g){e=e||[],d=d||c;var h=d;if(d.nodeType!==1&&d.nodeType!==9)return[];if(!b||typeof b!=="string")return e;var i,j,n,o,q,r,s,t,u=!0,w=k.isXML(d),x=[],y=b;do{a.exec(""),i=a.exec(y);if(i){y=i[3],x.push(i[1]);if(i[2]){o=i[3];break}}}while(i);if(x.length>1&&m.exec(b))if(x.length===2&&l.relative[x[0]])j=v(x[0]+x[1],d);else{j=l.relative[x[0]]?[d]:k(x.shift(),d);while(x.length)b=x.shift(),l.relative[b]&&(b+=x.shift()),j=v(b,j)}else{!g&&x.length>1&&d.nodeType===9&&!w&&l.match.ID.test(x[0])&&!l.match.ID.test(x[x.length-1])&&(q=k.find(x.shift(),d,w),d=q.expr?k.filter(q.expr,q.set)[0]:q.set[0]);if(d){q=g?{expr:x.pop(),set:p(g)}:k.find(x.pop(),x.length===1&&(x[0]==="~"||x[0]==="+")&&d.parentNode?d.parentNode:d,w),j=q.expr?k.filter(q.expr,q.set):q.set,x.length>0?n=p(j):u=!1;while(x.length)r=x.pop(),s=r,l.relative[r]?s=x.pop():r="",s==null&&(s=d),l.relative[r](n,s,w)}else n=x=[]}n||(n=j),n||k.error(r||b);if(f.call(n)==="[object Array]")if(u)if(d&&d.nodeType===1)for(t=0;n[t]!=null;t++)n[t]&&(n[t]===!0||n[t].nodeType===1&&k.contains(d,n[t]))&&e.push(j[t]);else for(t=0;n[t]!=null;t++)n[t]&&n[t].nodeType===1&&e.push(j[t]);else e.push.apply(e,n);else p(n,e);o&&(k(o,h,e,g),k.uniqueSort(e));return e};k.uniqueSort=function(a){if(r){g=h,a.sort(r);if(g)for(var b=1;b<a.length;b++)a[b]===a[b-1]&&a.splice(b--,1)}return a},k.matches=function(a,b){return k(a,null,null,b)},k.matchesSelector=function(a,b){return k(b,null,null,[a]).length>0},k.find=function(a,b,c){var d;if(!a)return[];for(var e=0,f=l.order.length;e<f;e++){var g,h=l.order[e];if(g=l.leftMatch[h].exec(a)){var j=g[1];g.splice(1,1);if(j.substr(j.length-1)!=="\\"){g[1]=(g[1]||"").replace(i,""),d=l.find[h](g,b,c);if(d!=null){a=a.replace(l.match[h],"");break}}}}d||(d=typeof b.getElementsByTagName!=="undefined"?b.getElementsByTagName("*"):[]);return{set:d,expr:a}},k.filter=function(a,c,d,e){var f,g,h=a,i=[],j=c,m=c&&c[0]&&k.isXML(c[0]);while(a&&c.length){for(var n in l.filter)if((f=l.leftMatch[n].exec(a))!=null&&f[2]){var o,p,q=l.filter[n],r=f[1];g=!1,f.splice(1,1);if(r.substr(r.length-1)==="\\")continue;j===i&&(i=[]);if(l.preFilter[n]){f=l.preFilter[n](f,j,d,i,e,m);if(f){if(f===!0)continue}else g=o=!0}if(f)for(var s=0;(p=j[s])!=null;s++)if(p){o=q(p,f,s,j);var t=e^!!o;d&&o!=null?t?g=!0:j[s]=!1:t&&(i.push(p),g=!0)}if(o!==b){d||(j=i),a=a.replace(l.match[n],"");if(!g)return[];break}}if(a===h)if(g==null)k.error(a);else break;h=a}return j},k.error=function(a){throw"Syntax error, unrecognized expression: "+a};var l=k.selectors={order:["ID","NAME","TAG"],match:{ID:/#((?:[\w\u00c0-\uFFFF\-]|\\.)+)/,CLASS:/\.((?:[\w\u00c0-\uFFFF\-]|\\.)+)/,NAME:/\[name=['"]*((?:[\w\u00c0-\uFFFF\-]|\\.)+)['"]*\]/,ATTR:/\[\s*((?:[\w\u00c0-\uFFFF\-]|\\.)+)\s*(?:(\S?=)\s*(?:(['"])(.*?)\3|(#?(?:[\w\u00c0-\uFFFF\-]|\\.)*)|)|)\s*\]/,TAG:/^((?:[\w\u00c0-\uFFFF\*\-]|\\.)+)/,CHILD:/:(only|nth|last|first)-child(?:\(\s*(even|odd|(?:[+\-]?\d+|(?:[+\-]?\d*)?n\s*(?:[+\-]\s*\d+)?))\s*\))?/,POS:/:(nth|eq|gt|lt|first|last|even|odd)(?:\((\d*)\))?(?=[^\-]|$)/,PSEUDO:/:((?:[\w\u00c0-\uFFFF\-]|\\.)+)(?:\((['"]?)((?:\([^\)]+\)|[^\(\)]*)+)\2\))?/},leftMatch:{},attrMap:{"class":"className","for":"htmlFor"},attrHandle:{href:function(a){return a.getAttribute("href")},type:function(a){return a.getAttribute("type")}},relative:{"+":function(a,b){var c=typeof b==="string",d=c&&!j.test(b),e=c&&!d;d&&(b=b.toLowerCase());for(var f=0,g=a.length,h;f<g;f++)if(h=a[f]){while((h=h.previousSibling)&&h.nodeType!==1){}a[f]=e||h&&h.nodeName.toLowerCase()===b?h||!1:h===b}e&&k.filter(b,a,!0)},">":function(a,b){var c,d=typeof b==="string",e=0,f=a.length;if(d&&!j.test(b)){b=b.toLowerCase();for(;e<f;e++){c=a[e];if(c){var g=c.parentNode;a[e]=g.nodeName.toLowerCase()===b?g:!1}}}else{for(;e<f;e++)c=a[e],c&&(a[e]=d?c.parentNode:c.parentNode===b);d&&k.filter(b,a,!0)}},"":function(a,b,c){var d,f=e++,g=u;typeof b==="string"&&!j.test(b)&&(b=b.toLowerCase(),d=b,g=t),g("parentNode",b,f,a,d,c)},"~":function(a,b,c){var d,f=e++,g=u;typeof b==="string"&&!j.test(b)&&(b=b.toLowerCase(),d=b,g=t),g("previousSibling",b,f,a,d,c)}},find:{ID:function(a,b,c){if(typeof b.getElementById!=="undefined"&&!c){var d=b.getElementById(a[1]);return d&&d.parentNode?[d]:[]}},NAME:function(a,b){if(typeof b.getElementsByName!=="undefined"){var c=[],d=b.getElementsByName(a[1]);for(var e=0,f=d.length;e<f;e++)d[e].getAttribute("name")===a[1]&&c.push(d[e]);return c.length===0?null:c}},TAG:function(a,b){if(typeof b.getElementsByTagName!=="undefined")return b.getElementsByTagName(a[1])}},preFilter:{CLASS:function(a,b,c,d,e,f){a=" "+a[1].replace(i,"")+" ";if(f)return a;for(var g=0,h;(h=b[g])!=null;g++)h&&(e^(h.className&&(" "+h.className+" ").replace(/[\t\n\r]/g," ").indexOf(a)>=0)?c||d.push(h):c&&(b[g]=!1));return!1},ID:function(a){return a[1].replace(i,"")},TAG:function(a,b){return a[1].replace(i,"").toLowerCase()},CHILD:function(a){if(a[1]==="nth"){a[2]||k.error(a[0]),a[2]=a[2].replace(/^\+|\s*/g,"");var b=/(-?)(\d*)(?:n([+\-]?\d*))?/.exec(a[2]==="even"&&"2n"||a[2]==="odd"&&"2n+1"||!/\D/.test(a[2])&&"0n+"+a[2]||a[2]);a[2]=b[1]+(b[2]||1)-0,a[3]=b[3]-0}else a[2]&&k.error(a[0]);a[0]=e++;return a},ATTR:function(a,b,c,d,e,f){var g=a[1]=a[1].replace(i,"");!f&&l.attrMap[g]&&(a[1]=l.attrMap[g]),a[4]=(a[4]||a[5]||"").replace(i,""),a[2]==="~="&&(a[4]=" "+a[4]+" ");return a},PSEUDO:function(b,c,d,e,f){if(b[1]==="not")if((a.exec(b[3])||"").length>1||/^\w/.test(b[3]))b[3]=k(b[3],null,null,c);else{var g=k.filter(b[3],c,d,!0^f);d||e.push.apply(e,g);return!1}else if(l.match.POS.test(b[0])||l.match.CHILD.test(b[0]))return!0;return b},POS:function(a){a.unshift(!0);return a}},filters:{enabled:function(a){return a.disabled===!1&&a.type!=="hidden"},disabled:function(a){return a.disabled===!0},checked:function(a){return a.checked===!0},selected:function(a){a.parentNode&&a.parentNode.selectedIndex;return a.selected===!0},parent:function(a){return!!a.firstChild},empty:function(a){return!a.firstChild},has:function(a,b,c){return!!k(c[3],a).length},header:function(a){return/h\d/i.test(a.nodeName)},text:function(a){return"text"===a.getAttribute("type")},radio:function(a){return"radio"===a.type},checkbox:function(a){return"checkbox"===a.type},file:function(a){return"file"===a.type},password:function(a){return"password"===a.type},submit:function(a){return"submit"===a.type},image:function(a){return"image"===a.type},reset:function(a){return"reset"===a.type},button:function(a){return"button"===a.type||a.nodeName.toLowerCase()==="button"},input:function(a){return/input|select|textarea|button/i.test(a.nodeName)}},setFilters:{first:function(a,b){return b===0},last:function(a,b,c,d){return b===d.length-1},even:function(a,b){return b%2===0},odd:function(a,b){return b%2===1},lt:function(a,b,c){return b<c[3]-0},gt:function(a,b,c){return b>c[3]-0},nth:function(a,b,c){return c[3]-0===b},eq:function(a,b,c){return c[3]-0===b}},filter:{PSEUDO:function(a,b,c,d){var e=b[1],f=l.filters[e];if(f)return f(a,c,b,d);if(e==="contains")return(a.textContent||a.innerText||k.getText([a])||"").indexOf(b[3])>=0;if(e==="not"){var g=b[3];for(var h=0,i=g.length;h<i;h++)if(g[h]===a)return!1;return!0}k.error(e)},CHILD:function(a,b){var c=b[1],d=a;switch(c){case"only":case"first":while(d=d.previousSibling)if(d.nodeType===1)return!1;if(c==="first")return!0;d=a;case"last":while(d=d.nextSibling)if(d.nodeType===1)return!1;return!0;case"nth":var e=b[2],f=b[3];if(e===1&&f===0)return!0;var g=b[0],h=a.parentNode;if(h&&(h.sizcache!==g||!a.nodeIndex)){var i=0;for(d=h.firstChild;d;d=d.nextSibling)d.nodeType===1&&(d.nodeIndex=++i);h.sizcache=g}var j=a.nodeIndex-f;return e===0?j===0:j%e===0&&j/e>=0}},ID:function(a,b){return a.nodeType===1&&a.getAttribute("id")===b},TAG:function(a,b){return b==="*"&&a.nodeType===1||a.nodeName.toLowerCase()===b},CLASS:function(a,b){return(" "+(a.className||a.getAttribute("class"))+" ").indexOf(b)>-1},ATTR:function(a,b){var c=b[1],d=l.attrHandle[c]?l.attrHandle[c](a):a[c]!=null?a[c]:a.getAttribute(c),e=d+"",f=b[2],g=b[4];return d==null?f==="!=":f==="="?e===g:f==="*="?e.indexOf(g)>=0:f==="~="?(" "+e+" ").indexOf(g)>=0:g?f==="!="?e!==g:f==="^="?e.indexOf(g)===0:f==="$="?e.substr(e.length-g.length)===g:f==="|="?e===g||e.substr(0,g.length+1)===g+"-":!1:e&&d!==!1},POS:function(a,b,c,d){var e=b[2],f=l.setFilters[e];if(f)return f(a,c,b,d)}}},m=l.match.POS,n=function(a,b){return"\\"+(b-0+1)};for(var o in l.match)l.match[o]=new RegExp(l.match[o].source+/(?![^\[]*\])(?![^\(]*\))/.source),l.leftMatch[o]=new RegExp(/(^(?:.|\r|\n)*?)/.source+l.match[o].source.replace(/\\(\d+)/g,n));var p=function(a,b){a=Array.prototype.slice.call(a,0);if(b){b.push.apply(b,a);return b}return a};try{Array.prototype.slice.call(c.documentElement.childNodes,0)[0].nodeType}catch(q){p=function(a,b){var c=0,d=b||[];if(f.call(a)==="[object Array]")Array.prototype.push.apply(d,a);else if(typeof a.length==="number")for(var e=a.length;c<e;c++)d.push(a[c]);else for(;a[c];c++)d.push(a[c]);return d}}var r,s;c.documentElement.compareDocumentPosition?r=function(a,b){if(a===b){g=!0;return 0}if(!a.compareDocumentPosition||!b.compareDocumentPosition)return a.compareDocumentPosition?-1:1;return a.compareDocumentPosition(b)&4?-1:1}:(r=function(a,b){var c,d,e=[],f=[],h=a.parentNode,i=b.parentNode,j=h;if(a===b){g=!0;return 0}if(h===i)return s(a,b);if(!h)return-1;if(!i)return 1;while(j)e.unshift(j),j=j.parentNode;j=i;while(j)f.unshift(j),j=j.parentNode;c=e.length,d=f.length;for(var k=0;k<c&&k<d;k++)if(e[k]!==f[k])return s(e[k],f[k]);return k===c?s(a,f[k],-1):s(e[k],b,1)},s=function(a,b,c){if(a===b)return c;var d=a.nextSibling;while(d){if(d===b)return-1;d=d.nextSibling}return 1}),k.getText=function(a){var b="",c;for(var d=0;a[d];d++)c=a[d],c.nodeType===3||c.nodeType===4?b+=c.nodeValue:c.nodeType!==8&&(b+=k.getText(c.childNodes));return b},function(){var a=c.createElement("div"),d="script"+(new Date).getTime(),e=c.documentElement;a.innerHTML="<a name='"+d+"'/>",e.insertBefore(a,e.firstChild),c.getElementById(d)&&(l.find.ID=function(a,c,d){if(typeof c.getElementById!=="undefined"&&!d){var e=c.getElementById(a[1]);return e?e.id===a[1]||typeof e.getAttributeNode!=="undefined"&&e.getAttributeNode("id").nodeValue===a[1]?[e]:b:[]}},l.filter.ID=function(a,b){var c=typeof a.getAttributeNode!=="undefined"&&a.getAttributeNode("id");return a.nodeType===1&&c&&c.nodeValue===b}),e.removeChild(a),e=a=null}(),function(){var a=c.createElement("div");a.appendChild(c.createComment("")),a.getElementsByTagName("*").length>0&&(l.find.TAG=function(a,b){var c=b.getElementsByTagName(a[1]);if(a[1]==="*"){var d=[];for(var e=0;c[e];e++)c[e].nodeType===1&&d.push(c[e]);c=d}return c}),a.innerHTML="<a href='#'></a>",a.firstChild&&typeof a.firstChild.getAttribute!=="undefined"&&a.firstChild.getAttribute("href")!=="#"&&(l.attrHandle.href=function(a){return a.getAttribute("href",2)}),a=null}(),c.querySelectorAll&&function(){var a=k,b=c.createElement("div"),d="__sizzle__";b.innerHTML="<p class='TEST'></p>";if(!b.querySelectorAll||b.querySelectorAll(".TEST").length!==0){k=function(b,e,f,g){e=e||c;if(!g&&!k.isXML(e)){var h=/^(\w+$)|^\.([\w\-]+$)|^#([\w\-]+$)/.exec(b);if(h&&(e.nodeType===1||e.nodeType===9)){if(h[1])return p(e.getElementsByTagName(b),f);if(h[2]&&l.find.CLASS&&e.getElementsByClassName)return p(e.getElementsByClassName(h[2]),f)}if(e.nodeType===9){if(b==="body"&&e.body)return p([e.body],f);if(h&&h[3]){var i=e.getElementById(h[3]);if(!i||!i.parentNode)return p([],f);if(i.id===h[3])return p([i],f)}try{return p(e.querySelectorAll(b),f)}catch(j){}}else if(e.nodeType===1&&e.nodeName.toLowerCase()!=="object"){var m=e,n=e.getAttribute("id"),o=n||d,q=e.parentNode,r=/^\s*[+~]/.test(b);n?o=o.replace(/'/g,"\\$&"):e.setAttribute("id",o),r&&q&&(e=e.parentNode);try{if(!r||q)return p(e.querySelectorAll("[id='"+o+"'] "+b),f)}catch(s){}finally{n||m.removeAttribute("id")}}}return a(b,e,f,g)};for(var e in a)k[e]=a[e];b=null}}(),function(){var a=c.documentElement,b=a.matchesSelector||a.mozMatchesSelector||a.webkitMatchesSelector||a.msMatchesSelector,d=!1;try{b.call(c.documentElement,"[test!='']:sizzle")}catch(e){d=!0}b&&(k.matchesSelector=function(a,c){c=c.replace(/\=\s*([^'"\]]*)\s*\]/g,"='$1']");if(!k.isXML(a))try{if(d||!l.match.PSEUDO.test(c)&&!/!=/.test(c))return b.call(a,c)}catch(e){}return k(c,null,null,[a]).length>0})}(),function(){var a=c.createElement("div");a.innerHTML="<div class='test e'></div><div class='test'></div>";if(a.getElementsByClassName&&a.getElementsByClassName("e").length!==0){a.lastChild.className="e";if(a.getElementsByClassName("e").length===1)return;l.order.splice(1,0,"CLASS"),l.find.CLASS=function(a,b,c){if(typeof b.getElementsByClassName!=="undefined"&&!c)return b.getElementsByClassName(a[1])},a=null}}(),c.documentElement.contains?k.contains=function(a,b){return a!==b&&(a.contains?a.contains(b):!0)}:c.documentElement.compareDocumentPosition?k.contains=function(a,b){return!!(a.compareDocumentPosition(b)&16)}:k.contains=function(){return!1},k.isXML=function(a){var b=(a?a.ownerDocument||a:0).documentElement;return b?b.nodeName!=="HTML":!1};var v=function(a,b){var c,d=[],e="",f=b.nodeType?[b]:b;while(c=l.match.PSEUDO.exec(a))e+=c[0],a=a.replace(l.match.PSEUDO,"");a=l.relative[a]?a+"*":a;for(var g=0,h=f.length;g<h;g++)k(a,f[g],d);return k.filter(e,d)};d.find=k,d.expr=k.selectors,d.expr[":"]=d.expr.filters,d.unique=k.uniqueSort,d.text=k.getText,d.isXMLDoc=k.isXML,d.contains=k.contains}();var G=/Until$/,H=/^(?:parents|prevUntil|prevAll)/,I=/,/,J=/^.[^:#\[\.,]*$/,K=Array.prototype.slice,L=d.expr.match.POS,M={children:!0,contents:!0,next:!0,prev:!0};d.fn.extend({find:function(a){var b=this.pushStack("","find",a),c=0;for(var e=0,f=this.length;e<f;e++){c=b.length,d.find(a,this[e],b);if(e>0)for(var g=c;g<b.length;g++)for(var h=0;h<c;h++)if(b[h]===b[g]){b.splice(g--,1);break}}return b},has:function(a){var b=d(a);return this.filter(function(){for(var a=0,c=b.length;a<c;a++)if(d.contains(this,b[a]))return!0})},not:function(a){return this.pushStack(O(this,a,!1),"not",a)},filter:function(a){return this.pushStack(O(this,a,!0),"filter",a)},is:function(a){return!!a&&d.filter(a,this).length>0},closest:function(a,b){var c=[],e,f,g=this[0];if(d.isArray(a)){var h,i,j={},k=1;if(g&&a.length){for(e=0,f=a.length;e<f;e++)i=a[e],j[i]||(j[i]=d.expr.match.POS.test(i)?d(i,b||this.context):i);while(g&&g.ownerDocument&&g!==b){for(i in j)h=j[i],(h.jquery?h.index(g)>-1:d(g).is(h))&&c.push({selector:i,elem:g,level:k});g=g.parentNode,k++}}return c}var l=L.test(a)?d(a,b||this.context):null;for(e=0,f=this.length;e<f;e++){g=this[e];while(g){if(l?l.index(g)>-1:d.find.matchesSelector(g,a)){c.push(g);break}g=g.parentNode;if(!g||!g.ownerDocument||g===b)break}}c=c.length>1?d.unique(c):c;return this.pushStack(c,"closest",a)},index:function(a){if(!a||typeof a==="string")return d.inArray(this[0],a?d(a):this.parent().children());return d.inArray(a.jquery?a[0]:a,this)},add:function(a,b){var c=typeof a==="string"?d(a,b):d.makeArray(a),e=d.merge(this.get(),c);return this.pushStack(N(c[0])||N(e[0])?e:d.unique(e))},andSelf:function(){return this.add(this.prevObject)}}),d.each({parent:function(a){var b=a.parentNode;return b&&b.nodeType!==11?b:null},parents:function(a){return d.dir(a,"parentNode")},parentsUntil:function(a,b,c){return d.dir(a,"parentNode",c)},next:function(a){return d.nth(a,2,"nextSibling")},prev:function(a){return d.nth(a,2,"previousSibling")},nextAll:function(a){return d.dir(a,"nextSibling")},prevAll:function(a){return d.dir(a,"previousSibling")},nextUntil:function(a,b,c){return d.dir(a,"nextSibling",c)},prevUntil:function(a,b,c){return d.dir(a,"previousSibling",c)},siblings:function(a){return d.sibling(a.parentNode.firstChild,a)},children:function(a){return d.sibling(a.firstChild)},contents:function(a){return d.nodeName(a,"iframe")?a.contentDocument||a.contentWindow.document:d.makeArray(a.childNodes)}},function(a,b){d.fn[a]=function(c,e){var f=d.map(this,b,c),g=K.call(arguments);G.test(a)||(e=c),e&&typeof e==="string"&&(f=d.filter(e,f)),f=this.length>1&&!M[a]?d.unique(f):f,(this.length>1||I.test(e))&&H.test(a)&&(f=f.reverse());return this.pushStack(f,a,g.join(","))}}),d.extend({filter:function(a,b,c){c&&(a=":not("+a+")");return b.length===1?d.find.matchesSelector(b[0],a)?[b[0]]:[]:d.find.matches(a,b)},dir:function(a,c,e){var f=[],g=a[c];while(g&&g.nodeType!==9&&(e===b||g.nodeType!==1||!d(g).is(e)))g.nodeType===1&&f.push(g),g=g[c];return f},nth:function(a,b,c,d){b=b||1;var e=0;for(;a;a=a[c])if(a.nodeType===1&&++e===b)break;return a},sibling:function(a,b){var c=[];for(;a;a=a.nextSibling)a.nodeType===1&&a!==b&&c.push(a);return c}});var P=/ jQuery\d+="(?:\d+|null)"/g,Q=/^\s+/,R=/<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\w:]+)[^>]*)\/>/ig,S=/<([\w:]+)/,T=/<tbody/i,U=/<|&#?\w+;/,V=/<(?:script|object|embed|option|style)/i,W=/checked\s*(?:[^=]|=\s*.checked.)/i,X={option:[1,"<select multiple='multiple'>","</select>"],legend:[1,"<fieldset>","</fieldset>"],thead:[1,"<table>","</table>"],tr:[2,"<table><tbody>","</tbody></table>"],td:[3,"<table><tbody><tr>","</tr></tbody></table>"],col:[2,"<table><tbody></tbody><colgroup>","</colgroup></table>"],area:[1,"<map>","</map>"],_default:[0,"",""]};X.optgroup=X.option,X.tbody=X.tfoot=X.colgroup=X.caption=X.thead,X.th=X.td,d.support.htmlSerialize||(X._default=[1,"div<div>","</div>"]),d.fn.extend({text:function(a){if(d.isFunction(a))return this.each(function(b){var c=d(this);c.text(a.call(this,b,c.text()))});if(typeof a!=="object"&&a!==b)return this.empty().append((this[0]&&this[0].ownerDocument||c).createTextNode(a));return d.text(this)},wrapAll:function(a){if(d.isFunction(a))return this.each(function(b){d(this).wrapAll(a.call(this,b))});if(this[0]){var b=d(a,this[0].ownerDocument).eq(0).clone(!0);this[0].parentNode&&b.insertBefore(this[0]),b.map(function(){var a=this;while(a.firstChild&&a.firstChild.nodeType===1)a=a.firstChild;return a}).append(this)}return this},wrapInner:function(a){if(d.isFunction(a))return this.each(function(b){d(this).wrapInner(a.call(this,b))});return this.each(function(){var b=d(this),c=b.contents();c.length?c.wrapAll(a):b.append(a)})},wrap:function(a){return this.each(function(){d(this).wrapAll(a)})},unwrap:function(){return this.parent().each(function(){d.nodeName(this,"body")||d(this).replaceWith(this.childNodes)}).end()},append:function(){return this.domManip(arguments,!0,function(a){this.nodeType===1&&this.appendChild(a)})},prepend:function(){return this.domManip(arguments,!0,function(a){this.nodeType===1&&this.insertBefore(a,this.firstChild)})},before:function(){if(this[0]&&this[0].parentNode)return this.domManip(arguments,!1,function(a){this.parentNode.insertBefore(a,this)});if(arguments.length){var a=d(arguments[0]);a.push.apply(a,this.toArray());return this.pushStack(a,"before",arguments)}},after:function(){if(this[0]&&this[0].parentNode)return this.domManip(arguments,!1,function(a){this.parentNode.insertBefore(a,this.nextSibling)});if(arguments.length){var a=this.pushStack(this,"after",arguments);a.push.apply(a,d(arguments[0]).toArray());return a}},remove:function(a,b){for(var c=0,e;(e=this[c])!=null;c++)if(!a||d.filter(a,[e]).length)!b&&e.nodeType===1&&(d.cleanData(e.getElementsByTagName("*")),d.cleanData([e])),e.parentNode&&e.parentNode.removeChild(e);return this},empty:function(){for(var a=0,b;(b=this[a])!=null;a++){b.nodeType===1&&d.cleanData(b.getElementsByTagName("*"));while(b.firstChild)b.removeChild(b.firstChild)}return this},clone:function(a,b){a=a==null?!1:a,b=b==null?a:b;return this.map(function(){return d.clone(this,a,b)})},html:function(a){if(a===b)return this[0]&&this[0].nodeType===1?this[0].innerHTML.replace(P,""):null;if(typeof a!=="string"||V.test(a)||!d.support.leadingWhitespace&&Q.test(a)||X[(S.exec(a)||["",""])[1].toLowerCase()])d.isFunction(a)?this.each(function(b){var c=d(this);c.html(a.call(this,b,c.html()))}):this.empty().append(a);else{a=a.replace(R,"<$1></$2>");try{for(var c=0,e=this.length;c<e;c++)this[c].nodeType===1&&(d.cleanData(this[c].getElementsByTagName("*")),this[c].innerHTML=a)}catch(f){this.empty().append(a)}}return this},replaceWith:function(a){if(this[0]&&this[0].parentNode){if(d.isFunction(a))return this.each(function(b){var c=d(this),e=c.html();c.replaceWith(a.call(this,b,e))});typeof a!=="string"&&(a=d(a).detach());return this.each(function(){var b=this.nextSibling,c=this.parentNode;d(this).remove(),b?d(b).before(a):d(c).append(a)})}return this.pushStack(d(d.isFunction(a)?a():a),"replaceWith",a)},detach:function(a){return this.remove(a,!0)},domManip:function(a,c,e){var f,g,h,i,j=a[0],k=[];if(!d.support.checkClone&&arguments.length===3&&typeof j==="string"&&W.test(j))return this.each(function(){d(this).domManip(a,c,e,!0)});if(d.isFunction(j))return this.each(function(f){var g=d(this);a[0]=j.call(this,f,c?g.html():b),g.domManip(a,c,e)});if(this[0]){i=j&&j.parentNode,d.support.parentNode&&i&&i.nodeType===11&&i.childNodes.length===this.length?f={fragment:i}:f=d.buildFragment(a,this,k),h=f.fragment,h.childNodes.length===1?g=h=h.firstChild:g=h.firstChild;if(g){c=c&&d.nodeName(g,"tr");for(var l=0,m=this.length,n=m-1;l<m;l++)e.call(c?Y(this[l],g):this[l],f.cacheable||m>1&&l<n?d.clone(h,!0,!0):h)}k.length&&d.each(k,ba)}return this}}),d.buildFragment=function(a,b,e){var f,g,h,i=b&&b[0]?b[0].ownerDocument||b[0]:c;a.length===1&&typeof a[0]==="string"&&a[0].length<512&&i===c&&a[0].charAt(0)==="<"&&!V.test(a[0])&&(d.support.checkClone||!W.test(a[0]))&&(g=!0,h=d.fragments[a[0]],h&&(h!==1&&(f=h))),f||(f=i.createDocumentFragment(),d.clean(a,i,f,e)),g&&(d.fragments[a[0]]=h?f:1);return{fragment:f,cacheable:g}},d.fragments={},d.each({appendTo:"append",prependTo:"prepend",insertBefore:"before",insertAfter:"after",replaceAll:"replaceWith"},function(a,b){d.fn[a]=function(c){var e=[],f=d(c),g=this.length===1&&this[0].parentNode;if(g&&g.nodeType===11&&g.childNodes.length===1&&f.length===1){f[b](this[0]);return this}for(var h=0,i=f.length;h<i;h++){var j=(h>0?this.clone(!0):this).get();d(f[h])[b](j),e=e.concat(j)}return this.pushStack(e,a,f.selector)}}),d.extend({clone:function(a,b,c){var e=a.cloneNode(!0),f,g,h;if((!d.support.noCloneEvent||!d.support.noCloneChecked)&&(a.nodeType===1||a.nodeType===11)&&!d.isXMLDoc(a)){$(a,e),f=_(a),g=_(e);for(h=0;f[h];++h)$(f[h],g[h])}if(b){Z(a,e);if(c){f=_(a),g=_(e);for(h=0;f[h];++h)Z(f[h],g[h])}}return e},clean:function(a,b,e,f){b=b||c,typeof b.createElement==="undefined"&&(b=b.ownerDocument||b[0]&&b[0].ownerDocument||c);var g=[];for(var h=0,i;(i=a[h])!=null;h++){typeof i==="number"&&(i+="");if(!i)continue;if(typeof i!=="string"||U.test(i)){if(typeof i==="string"){i=i.replace(R,"<$1></$2>");var j=(S.exec(i)||["",""])[1].toLowerCase(),k=X[j]||X._default,l=k[0],m=b.createElement("div");m.innerHTML=k[1]+i+k[2];while(l--)m=m.lastChild;if(!d.support.tbody){var n=T.test(i),o=j==="table"&&!n?m.firstChild&&m.firstChild.childNodes:k[1]==="<table>"&&!n?m.childNodes:[];for(var p=o.length-1;p>=0;--p)d.nodeName(o[p],"tbody")&&!o[p].childNodes.length&&o[p].parentNode.removeChild(o[p])}!d.support.leadingWhitespace&&Q.test(i)&&m.insertBefore(b.createTextNode(Q.exec(i)[0]),m.firstChild),i=m.childNodes}}else i=b.createTextNode(i);i.nodeType?g.push(i):g=d.merge(g,i)}if(e)for(h=0;g[h];h++)!f||!d.nodeName(g[h],"script")||g[h].type&&g[h].type.toLowerCase()!=="text/javascript"?(g[h].nodeType===1&&g.splice.apply(g,[h+1,0].concat(d.makeArray(g[h].getElementsByTagName("script")))),e.appendChild(g[h])):f.push(g[h].parentNode?g[h].parentNode.removeChild(g[h]):g[h]);return g},cleanData:function(a){var b,c,e=d.cache,f=d.expando,g=d.event.special,h=d.support.deleteExpando;for(var i=0,j;(j=a[i])!=null;i++){if(j.nodeName&&d.noData[j.nodeName.toLowerCase()])continue;c=j[d.expando];if(c){b=e[c]&&e[c][f];if(b&&b.events){for(var k in b.events)g[k]?d.event.remove(j,k):d.removeEvent(j,k,b.handle);b.handle&&(b.handle.elem=null)}h?delete j[d.expando]:j.removeAttribute&&j.removeAttribute(d.expando),delete e[c]}}}});var bb=/alpha\([^)]*\)/i,bc=/opacity=([^)]*)/,bd=/-([a-z])/ig,be=/([A-Z])/g,bf=/^-?\d+(?:px)?$/i,bg=/^-?\d/,bh={position:"absolute",visibility:"hidden",display:"block"},bi=["Left","Right"],bj=["Top","Bottom"],bk,bl,bm,bn=function(a,b){return b.toUpperCase()};d.fn.css=function(a,c){if(arguments.length===2&&c===b)return this;return d.access(this,a,c,!0,function(a,c,e){return e!==b?d.style(a,c,e):d.css(a,c)})},d.extend({cssHooks:{opacity:{get:function(a,b){if(b){var c=bk(a,"opacity","opacity");return c===""?"1":c}return a.style.opacity}}},cssNumber:{zIndex:!0,fontWeight:!0,opacity:!0,zoom:!0,lineHeight:!0},cssProps:{"float":d.support.cssFloat?"cssFloat":"styleFloat"},style:function(a,c,e,f){if(a&&a.nodeType!==3&&a.nodeType!==8&&a.style){var g,h=d.camelCase(c),i=a.style,j=d.cssHooks[h];c=d.cssProps[h]||h;if(e===b){if(j&&"get"in j&&(g=j.get(a,!1,f))!==b)return g;return i[c]}if(typeof e==="number"&&isNaN(e)||e==null)return;typeof e==="number"&&!d.cssNumber[h]&&(e+="px");if(!j||!("set"in j)||(e=j.set(a,e))!==b)try{i[c]=e}catch(k){}}},css:function(a,c,e){var f,g=d.camelCase(c),h=d.cssHooks[g];c=d.cssProps[g]||g;if(h&&"get"in h&&(f=h.get(a,!0,e))!==b)return f;if(bk)return bk(a,c,g)},swap:function(a,b,c){var d={};for(var e in b)d[e]=a.style[e],a.style[e]=b[e];c.call(a);for(e in b)a.style[e]=d[e]},camelCase:function(a){return a.replace(bd,bn)}}),d.curCSS=d.css,d.each(["height","width"],function(a,b){d.cssHooks[b]={get:function(a,c,e){var f;if(c){a.offsetWidth!==0?f=bo(a,b,e):d.swap(a,bh,function(){f=bo(a,b,e)});if(f<=0){f=bk(a,b,b),f==="0px"&&bm&&(f=bm(a,b,b));if(f!=null)return f===""||f==="auto"?"0px":f}if(f<0||f==null){f=a.style[b];return f===""||f==="auto"?"0px":f}return typeof f==="string"?f:f+"px"}},set:function(a,b){if(!bf.test(b))return b;b=parseFloat(b);if(b>=0)return b+"px"}}}),d.support.opacity||(d.cssHooks.opacity={get:function(a,b){return bc.test((b&&a.currentStyle?a.currentStyle.filter:a.style.filter)||"")?parseFloat(RegExp.$1)/100+"":b?"1":""},set:function(a,b){var c=a.style;c.zoom=1;var e=d.isNaN(b)?"":"alpha(opacity="+b*100+")",f=c.filter||"";c.filter=bb.test(f)?f.replace(bb,e):c.filter+" "+e}}),c.defaultView&&c.defaultView.getComputedStyle&&(bl=function(a,c,e){var f,g,h;e=e.replace(be,"-$1").toLowerCase();if(!(g=a.ownerDocument.defaultView))return b;if(h=g.getComputedStyle(a,null))f=h.getPropertyValue(e),f===""&&!d.contains(a.ownerDocument.documentElement,a)&&(f=d.style(a,e));return f}),c.documentElement.currentStyle&&(bm=function(a,b){var c,d=a.currentStyle&&a.currentStyle[b],e=a.runtimeStyle&&a.runtimeStyle[b],f=a.style;!bf.test(d)&&bg.test(d)&&(c=f.left,e&&(a.runtimeStyle.left=a.currentStyle.left),f.left=b==="fontSize"?"1em":d||0,d=f.pixelLeft+"px",f.left=c,e&&(a.runtimeStyle.left=e));return d===""?"auto":d}),bk=bl||bm,d.expr&&d.expr.filters&&(d.expr.filters.hidden=function(a){var b=a.offsetWidth,c=a.offsetHeight;return b===0&&c===0||!d.support.reliableHiddenOffsets&&(a.style.display||d.css(a,"display"))==="none"},d.expr.filters.visible=function(a){return!d.expr.filters.hidden(a)});var bp=/%20/g,bq=/\[\]$/,br=/\r?\n/g,bs=/#.*$/,bt=/^(.*?):[ \t]*([^\r\n]*)\r?$/mg,bu=/^(?:color|date|datetime|email|hidden|month|number|password|range|search|tel|text|time|url|week)$/i,bv=/(?:^file|^widget|\-extension):$/,bw=/^(?:GET|HEAD)$/,bx=/^\/\//,by=/\?/,bz=/<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>/gi,bA=/^(?:select|textarea)/i,bB=/\s+/,bC=/([?&])_=[^&]*/,bD=/(^|\-)([a-z])/g,bE=function(a,b,c){return b+c.toUpperCase()},bF=/^([\w\+\.\-]+:)\/\/([^\/?#:]*)(?::(\d+))?/,bG=d.fn.load,bH={},bI={},bJ,bK;try{bJ=c.location.href}catch(bL){bJ=c.createElement("a"),bJ.href="",bJ=bJ.href}bK=bF.exec(bJ.toLowerCase()),d.fn.extend({load:function(a,c,e){if(typeof a!=="string"&&bG)return bG.apply(this,arguments);if(!this.length)return this;var f=a.indexOf(" ");if(f>=0){var g=a.slice(f,a.length);a=a.slice(0,f)}var h="GET";c&&(d.isFunction(c)?(e=c,c=b):typeof c==="object"&&(c=d.param(c,d.ajaxSettings.traditional),h="POST"));var i=this;d.ajax({url:a,type:h,dataType:"html",data:c,complete:function(a,b,c){c=a.responseText,a.isResolved()&&(a.done(function(a){c=a}),i.html(g?d("<div>").append(c.replace(bz,"")).find(g):c)),e&&i.each(e,[c,b,a])}});return this},serialize:function(){return d.param(this.serializeArray())},serializeArray:function(){return this.map(function(){return this.elements?d.makeArray(this.elements):this}).filter(function(){return this.name&&!this.disabled&&(this.checked||bA.test(this.nodeName)||bu.test(this.type))}).map(function(a,b){var c=d(this).val();return c==null?null:d.isArray(c)?d.map(c,function(a,c){return{name:b.name,value:a.replace(br,"\r\n")}}):{name:b.name,value:c.replace(br,"\r\n")}}).get()}}),d.each("ajaxStart ajaxStop ajaxComplete ajaxError ajaxSuccess ajaxSend".split(" "),function(a,b){d.fn[b]=function(a){return this.bind(b,a)}}),d.each(["get","post"],function(a,c){d[c]=function(a,e,f,g){d.isFunction(e)&&(g=g||f,f=e,e=b);return d.ajax({type:c,url:a,data:e,success:f,dataType:g})}}),d.extend({getScript:function(a,c){return d.get(a,b,c,"script")},getJSON:function(a,b,c){return d.get(a,b,c,"json")},ajaxSetup:function(a,b){b?d.extend(!0,a,d.ajaxSettings,b):(b=a,a=d.extend(!0,d.ajaxSettings,b));for(var c in {context:1,url:1})c in b?a[c]=b[c]:c in d.ajaxSettings&&(a[c]=d.ajaxSettings[c]);return a},ajaxSettings:{url:bJ,isLocal:bv.test(bK[1]),global:!0,type:"GET",contentType:"application/x-www-form-urlencoded",processData:!0,async:!0,accepts:{xml:"application/xml, text/xml",html:"text/html",text:"text/plain",json:"application/json, text/javascript","*":"*/*"},contents:{xml:/xml/,html:/html/,json:/json/},responseFields:{xml:"responseXML",text:"responseText"},converters:{"* text":a.String,"text html":!0,"text json":d.parseJSON,"text xml":d.parseXML}},ajaxPrefilter:bM(bH),ajaxTransport:bM(bI),ajax:function(a,c){function v(a,c,l,n){if(r!==2){r=2,p&&clearTimeout(p),o=b,m=n||"",u.readyState=a?4:0;var q,t,v,w=l?bP(e,u,l):b,x,y;if(a>=200&&a<300||a===304){if(e.ifModified){if(x=u.getResponseHeader("Last-Modified"))d.lastModified[k]=x;if(y=u.getResponseHeader("Etag"))d.etag[k]=y}if(a===304)c="notmodified",q=!0;else try{t=bQ(e,w),c="success",q=!0}catch(z){c="parsererror",v=z}}else{v=c;if(!c||a)c="error",a<0&&(a=0)}u.status=a,u.statusText=c,q?h.resolveWith(f,[t,c,u]):h.rejectWith(f,[u,c,v]),u.statusCode(j),j=b,s&&g.trigger("ajax"+(q?"Success":"Error"),[u,e,q?t:v]),i.resolveWith(f,[u,c]),s&&(g.trigger("ajaxComplete",[u,e]),--d.active||d.event.trigger("ajaxStop"))}}typeof a==="object"&&(c=a,a=b),c=c||{};var e=d.ajaxSetup({},c),f=e.context||e,g=f!==e&&(f.nodeType||f instanceof d)?d(f):d.event,h=d.Deferred(),i=d._Deferred(),j=e.statusCode||{},k,l={},m,n,o,p,q,r=0,s,t,u={readyState:0,setRequestHeader:function(a,b){r||(l[a.toLowerCase().replace(bD,bE)]=b);return this},getAllResponseHeaders:function(){return r===2?m:null},getResponseHeader:function(a){var c;if(r===2){if(!n){n={};while(c=bt.exec(m))n[c[1].toLowerCase()]=c[2]}c=n[a.toLowerCase()]}return c===b?null:c},overrideMimeType:function(a){r||(e.mimeType=a);return this},abort:function(a){a=a||"abort",o&&o.abort(a),v(0,a);return this}};h.promise(u),u.success=u.done,u.error=u.fail,u.complete=i.done,u.statusCode=function(a){if(a){var b;if(r<2)for(b in a)j[b]=[j[b],a[b]];else b=a[u.status],u.then(b,b)}return this},e.url=((a||e.url)+"").replace(bs,"").replace(bx,bK[1]+"//"),e.dataTypes=d.trim(e.dataType||"*").toLowerCase().split(bB),e.crossDomain||(q=bF.exec(e.url.toLowerCase()),e.crossDomain=q&&(q[1]!=bK[1]||q[2]!=bK[2]||(q[3]||(q[1]==="http:"?80:443))!=(bK[3]||(bK[1]==="http:"?80:443)))),e.data&&e.processData&&typeof e.data!=="string"&&(e.data=d.param(e.data,e.traditional)),bN(bH,e,c,u);if(r===2)return!1;s=e.global,e.type=e.type.toUpperCase(),e.hasContent=!bw.test(e.type),s&&d.active++===0&&d.event.trigger("ajaxStart");if(!e.hasContent){e.data&&(e.url+=(by.test(e.url)?"&":"?")+e.data),k=e.url;if(e.cache===!1){var w=d.now(),x=e.url.replace(bC,"$1_="+w);e.url=x+(x===e.url?(by.test(e.url)?"&":"?")+"_="+w:"")}}if(e.data&&e.hasContent&&e.contentType!==!1||c.contentType)l["Content-Type"]=e.contentType;e.ifModified&&(k=k||e.url,d.lastModified[k]&&(l["If-Modified-Since"]=d.lastModified[k]),d.etag[k]&&(l["If-None-Match"]=d.etag[k])),l.Accept=e.dataTypes[0]&&e.accepts[e.dataTypes[0]]?e.accepts[e.dataTypes[0]]+(e.dataTypes[0]!=="*"?", */*; q=0.01":""):e.accepts["*"];for(t in e.headers)u.setRequestHeader(t,e.headers[t]);if(e.beforeSend&&(e.beforeSend.call(f,u,e)===!1||r===2)){u.abort();return!1}for(t in {success:1,error:1,complete:1})u[t](e[t]);o=bN(bI,e,c,u);if(o){u.readyState=1,s&&g.trigger("ajaxSend",[u,e]),e.async&&e.timeout>0&&(p=setTimeout(function(){u.abort("timeout")},e.timeout));try{r=1,o.send(l,v)}catch(y){status<2?v(-1,y):d.error(y)}}else v(-1,"No Transport");return u},param:function(a,c){var e=[],f=function(a,b){b=d.isFunction(b)?b():b,e[e.length]=encodeURIComponent(a)+"="+encodeURIComponent(b)};c===b&&(c=d.ajaxSettings.traditional);if(d.isArray(a)||a.jquery&&!d.isPlainObject(a))d.each(a,function(){f(this.name,this.value)});else for(var g in a)bO(g,a[g],c,f);return e.join("&").replace(bp,"+")}}),d.extend({active:0,lastModified:{},etag:{}});var bR=d.now(),bS=/(\=)\?(&|$)|()\?\?()/i;d.ajaxSetup({jsonp:"callback",jsonpCallback:function(){return d.expando+"_"+bR++}}),d.ajaxPrefilter("json jsonp",function(b,c,e){var f=typeof b.data==="string";if(b.dataTypes[0]==="jsonp"||c.jsonpCallback||c.jsonp!=null||b.jsonp!==!1&&(bS.test(b.url)||f&&bS.test(b.data))){var g,h=b.jsonpCallback=d.isFunction(b.jsonpCallback)?b.jsonpCallback():b.jsonpCallback,i=a[h],j=b.url,k=b.data,l="$1"+h+"$2",m=function(){a[h]=i,g&&d.isFunction(i)&&a[h](g[0])};b.jsonp!==!1&&(j=j.replace(bS,l),b.url===j&&(f&&(k=k.replace(bS,l)),b.data===k&&(j+=(/\?/.test(j)?"&":"?")+b.jsonp+"="+h))),b.url=j,b.data=k,a[h]=function(a){g=[a]},e.then(m,m),b.converters["script json"]=function(){g||d.error(h+" was not called");return g[0]},b.dataTypes[0]="json";return"script"}}),d.ajaxSetup({accepts:{script:"text/javascript, application/javascript, application/ecmascript, application/x-ecmascript"},contents:{script:/javascript|ecmascript/},converters:{"text script":function(a){d.globalEval(a);return a}}}),d.ajaxPrefilter("script",function(a){a.cache===b&&(a.cache=!1),a.crossDomain&&(a.type="GET",a.global=!1)}),d.ajaxTransport("script",function(a){if(a.crossDomain){var d,e=c.head||c.getElementsByTagName("head")[0]||c.documentElement;return{send:function(f,g){d=c.createElement("script"),d.async="async",a.scriptCharset&&(d.charset=a.scriptCharset),d.src=a.url,d.onload=d.onreadystatechange=function(a,c){if(!d.readyState||/loaded|complete/.test(d.readyState))d.onload=d.onreadystatechange=null,e&&d.parentNode&&e.removeChild(d),d=b,c||g(200,"success")},e.insertBefore(d,e.firstChild)},abort:function(){d&&d.onload(0,1)}}}});var bT=d.now(),bU,bV;d.ajaxSettings.xhr=a.ActiveXObject?function(){return!this.isLocal&&bX()||bY()}:bX,bV=d.ajaxSettings.xhr(),d.support.ajax=!!bV,d.support.cors=bV&&"withCredentials"in bV,bV=b,d.support.ajax&&d.ajaxTransport(function(a){if(!a.crossDomain||d.support.cors){var c;return{send:function(e,f){var g=a.xhr(),h,i;a.username?g.open(a.type,a.url,a.async,a.username,a.password):g.open(a.type,a.url,a.async);if(a.xhrFields)for(i in a.xhrFields)g[i]=a.xhrFields[i];a.mimeType&&g.overrideMimeType&&g.overrideMimeType(a.mimeType),(!a.crossDomain||a.hasContent)&&!e["X-Requested-With"]&&(e["X-Requested-With"]="XMLHttpRequest");try{for(i in e)g.setRequestHeader(i,e[i])}catch(j){}g.send(a.hasContent&&a.data||null),c=function(e,i){var j,k,l,m,n;try{if(c&&(i||g.readyState===4)){c=b,h&&(g.onreadystatechange=d.noop,delete bU[h]);if(i)g.readyState!==4&&g.abort();else{j=g.status,l=g.getAllResponseHeaders(),m={},n=g.responseXML,n&&n.documentElement&&(m.xml=n),m.text=g.responseText;try{k=g.statusText}catch(o){k=""}j||!a.isLocal||a.crossDomain?j===1223&&(j=204):j=m.text?200:404}}}catch(p){i||f(-1,p)}m&&f(j,k,m,l)},a.async&&g.readyState!==4?(bU||(bU={},bW()),h=bT++,g.onreadystatechange=bU[h]=c):c()},abort:function(){c&&c(0,1)}}}});var bZ={},b$=/^(?:toggle|show|hide)$/,b_=/^([+\-]=)?([\d+.\-]+)([a-z%]*)$/i,ca,cb=[["height","marginTop","marginBottom","paddingTop","paddingBottom"],["width","marginLeft","marginRight","paddingLeft","paddingRight"],["opacity"]];d.fn.extend({show:function(a,b,c){var e,f;if(a||a===0)return this.animate(cc("show",3),a,b,c);for(var g=0,h=this.length;g<h;g++)e=this[g],f=e.style.display,!d._data(e,"olddisplay")&&f==="none"&&(f=e.style.display=""),f===""&&d.css(e,"display")==="none"&&d._data(e,"olddisplay",cd(e.nodeName));for(g=0;g<h;g++){e=this[g],f=e.style.display;if(f===""||f==="none")e.style.display=d._data(e,"olddisplay")||""}return this},hide:function(a,b,c){if(a||a===0)return this.animate(cc("hide",3),a,b,c);for(var e=0,f=this.length;e<f;e++){var g=d.css(this[e],"display");g!=="none"&&!d._data(this[e],"olddisplay")&&d._data(this[e],"olddisplay",g)}for(e=0;e<f;e++)this[e].style.display="none";return this},_toggle:d.fn.toggle,toggle:function(a,b,c){var e=typeof a==="boolean";d.isFunction(a)&&d.isFunction(b)?this._toggle.apply(this,arguments):a==null||e?this.each(function(){var b=e?a:d(this).is(":hidden");d(this)[b?"show":"hide"]()}):this.animate(cc("toggle",3),a,b,c);return this},fadeTo:function(a,b,c,d){return this.filter(":hidden").css("opacity",0).show().end().animate({opacity:b},a,c,d)},animate:function(a,b,c,e){var f=d.speed(b,c,e);if(d.isEmptyObject(a))return this.each(f.complete);return this[f.queue===!1?"each":"queue"](function(){var b=d.extend({},f),c,e=this.nodeType===1,g=e&&d(this).is(":hidden"),h=this;for(c in a){var i=d.camelCase(c);c!==i&&(a[i]=a[c],delete a[c],c=i);if(a[c]==="hide"&&g||a[c]==="show"&&!g)return b.complete.call(this);if(e&&(c==="height"||c==="width")){b.overflow=[this.style.overflow,this.style.overflowX,this.style.overflowY];if(d.css(this,"display")==="inline"&&d.css(this,"float")==="none")if(d.support.inlineBlockNeedsLayout){var j=cd(this.nodeName);j==="inline"?this.style.display="inline-block":(this.style.display="inline",this.style.zoom=1)}else this.style.display="inline-block"}d.isArray(a[c])&&((b.specialEasing=b.specialEasing||{})[c]=a[c][1],a[c]=a[c][0])}b.overflow!=null&&(this.style.overflow="hidden"),b.curAnim=d.extend({},a),d.each(a,function(c,e){var f=new d.fx(h,b,c);if(b$.test(e))f[e==="toggle"?g?"show":"hide":e](a);else{var i=b_.exec(e),j=f.cur();if(i){var k=parseFloat(i[2]),l=i[3]||(d.cssNumber[c]?"":"px");l!=="px"&&(d.style(h,c,(k||1)+l),j=(k||1)/f.cur()*j,d.style(h,c,j+l)),i[1]&&(k=(i[1]==="-="?-1:1)*k+j),f.custom(j,k,l)}else f.custom(j,e,"")}});return!0})},stop:function(a,b){var c=d.timers;a&&this.queue([]),this.each(function(){for(var a=c.length-1;a>=0;a--)c[a].elem===this&&(b&&c[a](!0),c.splice(a,1))}),b||this.dequeue();return this}}),d.each({slideDown:cc("show",1),slideUp:cc("hide",1),slideToggle:cc("toggle",1),fadeIn:{opacity:"show"},fadeOut:{opacity:"hide"},fadeToggle:{opacity:"toggle"}},function(a,b){d.fn[a]=function(a,c,d){return this.animate(b,a,c,d)}}),d.extend({speed:function(a,b,c){var e=a&&typeof a==="object"?d.extend({},a):{complete:c||!c&&b||d.isFunction(a)&&a,duration:a,easing:c&&b||b&&!d.isFunction(b)&&b};e.duration=d.fx.off?0:typeof e.duration==="number"?e.duration:e.duration in d.fx.speeds?d.fx.speeds[e.duration]:d.fx.speeds._default,e.old=e.complete,e.complete=function(){e.queue!==!1&&d(this).dequeue(),d.isFunction(e.old)&&e.old.call(this)};return e},easing:{linear:function(a,b,c,d){return c+d*a},swing:function(a,b,c,d){return(-Math.cos(a*Math.PI)/2+.5)*d+c}},timers:[],fx:function(a,b,c){this.options=b,this.elem=a,this.prop=c,b.orig||(b.orig={})}}),d.fx.prototype={update:function(){this.options.step&&this.options.step.call(this.elem,this.now,this),(d.fx.step[this.prop]||d.fx.step._default)(this)},cur:function(){if(this.elem[this.prop]!=null&&(!this.elem.style||this.elem.style[this.prop]==null))return this.elem[this.prop];var a,b=d.css(this.elem,this.prop);return isNaN(a=parseFloat(b))?!b||b==="auto"?0:b:a},custom:function(a,b,c){function g(a){return e.step(a)}var e=this,f=d.fx;this.startTime=d.now(),this.start=a,this.end=b,this.unit=c||this.unit||(d.cssNumber[this.prop]?"":"px"),this.now=this.start,this.pos=this.state=0,g.elem=this.elem,g()&&d.timers.push(g)&&!ca&&(ca=setInterval(f.tick,f.interval))},show:function(){this.options.orig[this.prop]=d.style(this.elem,this.prop),this.options.show=!0,this.custom(this.prop==="width"||this.prop==="height"?1:0,this.cur()),d(this.elem).show()},hide:function(){this.options.orig[this.prop]=d.style(this.elem,this.prop),this.options.hide=!0,this.custom(this.cur(),0)},step:function(a){var b=d.now(),c=!0;if(a||b>=this.options.duration+this.startTime){this.now=this.end,this.pos=this.state=1,this.update(),this.options.curAnim[this.prop]=!0;for(var e in this.options.curAnim)this.options.curAnim[e]!==!0&&(c=!1);if(c){if(this.options.overflow!=null&&!d.support.shrinkWrapBlocks){var f=this.elem,g=this.options;d.each(["","X","Y"],function(a,b){f.style["overflow"+b]=g.overflow[a]})}this.options.hide&&d(this.elem).hide();if(this.options.hide||this.options.show)for(var h in this.options.curAnim)d.style(this.elem,h,this.options.orig[h]);this.options.complete.call(this.elem)}return!1}var i=b-this.startTime;this.state=i/this.options.duration;var j=this.options.specialEasing&&this.options.specialEasing[this.prop],k=this.options.easing||(d.easing.swing?"swing":"linear");this.pos=d.easing[j||k](this.state,i,0,1,this.options.duration),this.now=this.start+(this.end-this.start)*this.pos,this.update();return!0}},d.extend(d.fx,{tick:function(){var a=d.timers;for(var b=0;b<a.length;b++)a[b]()||a.splice(b--,1);a.length||d.fx.stop()},interval:13,stop:function(){clearInterval(ca),ca=null},speeds:{slow:600,fast:200,_default:400},step:{opacity:function(a){d.style(a.elem,"opacity",a.now)},_default:function(a){a.elem.style&&a.elem.style[a.prop]!=null?a.elem.style[a.prop]=(a.prop==="width"||a.prop==="height"?Math.max(0,a.now):a.now)+a.unit:a.elem[a.prop]=a.now}}}),d.expr&&d.expr.filters&&(d.expr.filters.animated=function(a){return d.grep(d.timers,function(b){return a===b.elem}).length});var ce=/^t(?:able|d|h)$/i,cf=/^(?:body|html)$/i;"getBoundingClientRect"in c.documentElement?d.fn.offset=function(a){var b=this[0],c;if(a)return this.each(function(b){d.offset.setOffset(this,a,b)});if(!b||!b.ownerDocument)return null;if(b===b.ownerDocument.body)return d.offset.bodyOffset(b);try{c=b.getBoundingClientRect()}catch(e){}var f=b.ownerDocument,g=f.documentElement;if(!c||!d.contains(g,b))return c?{top:c.top,left:c.left}:{top:0,left:0};var h=f.body,i=cg(f),j=g.clientTop||h.clientTop||0,k=g.clientLeft||h.clientLeft||0,l=i.pageYOffset||d.support.boxModel&&g.scrollTop||h.scrollTop,m=i.pageXOffset||d.support.boxModel&&g.scrollLeft||h.scrollLeft,n=c.top+l-j,o=c.left+m-k;return{top:n,left:o}}:d.fn.offset=function(a){var b=this[0];if(a)return this.each(function(b){d.offset.setOffset(this,a,b)});if(!b||!b.ownerDocument)return null;if(b===b.ownerDocument.body)return d.offset.bodyOffset(b);d.offset.initialize();var c,e=b.offsetParent,f=b,g=b.ownerDocument,h=g.documentElement,i=g.body,j=g.defaultView,k=j?j.getComputedStyle(b,null):b.currentStyle,l=b.offsetTop,m=b.offsetLeft;while((b=b.parentNode)&&b!==i&&b!==h){if(d.offset.supportsFixedPosition&&k.position==="fixed")break;c=j?j.getComputedStyle(b,null):b.currentStyle,l-=b.scrollTop,m-=b.scrollLeft,b===e&&(l+=b.offsetTop,m+=b.offsetLeft,d.offset.doesNotAddBorder&&(!d.offset.doesAddBorderForTableAndCells||!ce.test(b.nodeName))&&(l+=parseFloat(c.borderTopWidth)||0,m+=parseFloat(c.borderLeftWidth)||0),f=e,e=b.offsetParent),d.offset.subtractsBorderForOverflowNotVisible&&c.overflow!=="visible"&&(l+=parseFloat(c.borderTopWidth)||0,m+=parseFloat(c.borderLeftWidth)||0),k=c}if(k.position==="relative"||k.position==="static")l+=i.offsetTop,m+=i.offsetLeft;d.offset.supportsFixedPosition&&k.position==="fixed"&&(l+=Math.max(h.scrollTop,i.scrollTop),m+=Math.max(h.scrollLeft,i.scrollLeft));return{top:l,left:m}},d.offset={initialize:function(){var a=c.body,b=c.createElement("div"),e,f,g,h,i=parseFloat(d.css(a,"marginTop"))||0,j="<div style='position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;'><div></div></div><table style='position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;' cellpadding='0' cellspacing='0'><tr><td></td></tr></table>";d.extend(b.style,{position:"absolute",top:0,left:0,margin:0,border:0,width:"1px",height:"1px",visibility:"hidden"}),b.innerHTML=j,a.insertBefore(b,a.firstChild),e=b.firstChild,f=e.firstChild,h=e.nextSibling.firstChild.firstChild,this.doesNotAddBorder=f.offsetTop!==5,this.doesAddBorderForTableAndCells=h.offsetTop===5,f.style.position="fixed",f.style.top="20px",this.supportsFixedPosition=f.offsetTop===20||f.offsetTop===15,f.style.position=f.style.top="",e.style.overflow="hidden",e.style.position="relative",this.subtractsBorderForOverflowNotVisible=f.offsetTop===-5,this.doesNotIncludeMarginInBodyOffset=a.offsetTop!==i,a.removeChild(b),a=b=e=f=g=h=null,d.offset.initialize=d.noop},bodyOffset:function(a){var b=a.offsetTop,c=a.offsetLeft;d.offset.initialize(),d.offset.doesNotIncludeMarginInBodyOffset&&(b+=parseFloat(d.css(a,"marginTop"))||0,c+=parseFloat(d.css(a,"marginLeft"))||0);return{top:b,left:c}},setOffset:function(a,b,c){var e=d.css(a,"position");e==="static"&&(a.style.position="relative");var f=d(a),g=f.offset(),h=d.css(a,"top"),i=d.css(a,"left"),j=e==="absolute"&&d.inArray("auto",[h,i])>-1,k={},l={},m,n;j&&(l=f.position()),m=j?l.top:parseInt(h,10)||0,n=j?l.left:parseInt(i,10)||0,d.isFunction(b)&&(b=b.call(a,c,g)),b.top!=null&&(k.top=b.top-g.top+m),b.left!=null&&(k.left=b.left-g.left+n),"using"in b?b.using.call(a,k):f.css(k)}},d.fn.extend({position:function(){if(!this[0])return null;var a=this[0],b=this.offsetParent(),c=this.offset(),e=cf.test(b[0].nodeName)?{top:0,left:0}:b.offset();c.top-=parseFloat(d.css(a,"marginTop"))||0,c.left-=parseFloat(d.css(a,"marginLeft"))||0,e.top+=parseFloat(d.css(b[0],"borderTopWidth"))||0,e.left+=parseFloat(d.css(b[0],"borderLeftWidth"))||0;return{top:c.top-e.top,left:c.left-e.left}},offsetParent:function(){return this.map(function(){var a=this.offsetParent||c.body;while(a&&(!cf.test(a.nodeName)&&d.css(a,"position")==="static"))a=a.offsetParent;return a})}}),d.each(["Left","Top"],function(a,c){var e="scroll"+c;d.fn[e]=function(c){var f=this[0],g;if(!f)return null;if(c!==b)return this.each(function(){g=cg(this),g?g.scrollTo(a?d(g).scrollLeft():c,a?c:d(g).scrollTop()):this[e]=c});g=cg(f);return g?"pageXOffset"in g?g[a?"pageYOffset":"pageXOffset"]:d.support.boxModel&&g.document.documentElement[e]||g.document.body[e]:f[e]}}),d.each(["Height","Width"],function(a,c){var e=c.toLowerCase();d.fn["inner"+c]=function(){return this[0]?parseFloat(d.css(this[0],e,"padding")):null},d.fn["outer"+c]=function(a){return this[0]?parseFloat(d.css(this[0],e,a?"margin":"border")):null},d.fn[e]=function(a){var f=this[0];if(!f)return a==null?null:this;if(d.isFunction(a))return this.each(function(b){var c=d(this);c[e](a.call(this,b,c[e]()))});if(d.isWindow(f)){var g=f.document.documentElement["client"+c];return f.document.compatMode==="CSS1Compat"&&g||f.document.body["client"+c]||g}if(f.nodeType===9)return Math.max(f.documentElement["client"+c],f.body["scroll"+c],f.documentElement["scroll"+c],f.body["offset"+c],f.documentElement["offset"+c]);if(a===b){var h=d.css(f,e),i=parseFloat(h);return d.isNaN(i)?h:i}return this.css(e,typeof a==="string"?a:a+"px")}}),a.jQuery=a.$=d})(window);/*
 * jQuery Templates Plugin 1.0.0pre
 * http://github.com/jquery/jquery-tmpl
 * Requires jQuery 1.4.2
 *
 * Copyright Software Freedom Conservancy, Inc.
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 */
(function (a) { var r = a.fn.domManip, d = "_tmplitem", q = /^[^<]*(<[\w\W]+>)[^>]*$|\{\{\! /, b = {}, f = {}, e, p = { key: 0, data: {} }, i = 0, c = 0, l = []; function g(e, d, g, h) { var c = { data: h || (d ? d.data : {}), _wrap: d ? d._wrap : null, tmpl: null, parent: d || null, nodes: [], calls: u, nest: w, wrap: x, html: v, update: t }; e && a.extend(c, e, { nodes: [], parent: d }); if (g) { c.tmpl = g; c._ctnt = c._ctnt || c.tmpl(a, c); c.key = ++i; (l.length ? f : b)[i] = c } return c } a.each({ appendTo: "append", prependTo: "prepend", insertBefore: "before", insertAfter: "after", replaceAll: "replaceWith" }, function (f, d) { a.fn[f] = function (n) { var g = [], i = a(n), k, h, m, l, j = this.length === 1 && this[0].parentNode; e = b || {}; if (j && j.nodeType === 11 && j.childNodes.length === 1 && i.length === 1) { i[d](this[0]); g = this } else { for (h = 0, m = i.length; h < m; h++) { c = h; k = (h > 0 ? this.clone(true) : this).get(); a(i[h])[d](k); g = g.concat(k) } c = 0; g = this.pushStack(g, f, i.selector) } l = e; e = null; a.tmpl.complete(l); return g } }); a.fn.extend({ tmpl: function (d, c, b) { return a.tmpl(this[0], d, c, b) }, tmplItem: function () { return a.tmplItem(this[0]) }, template: function (b) { return a.template(b, this[0]) }, domManip: function (d, m, k) { if (d[0] && a.isArray(d[0])) { var g = a.makeArray(arguments), h = d[0], j = h.length, i = 0, f; while (i < j && !(f = a.data(h[i++], "tmplItem"))); if (f && c) g[2] = function (b) { a.tmpl.afterManip(this, b, k) }; r.apply(this, g) } else r.apply(this, arguments); c = 0; !e && a.tmpl.complete(b); return this } }); a.extend({ tmpl: function (d, h, e, c) { var i, k = !c; if (k) { c = p; d = a.template[d] || a.template(null, d); f = {} } else if (!d) { d = c.tmpl; b[c.key] = c; c.nodes = []; c.wrapped && n(c, c.wrapped); return a(j(c, null, c.tmpl(a, c))) } if (!d) return []; if (typeof h === "function") h = h.call(c || {}); e && e.wrapped && n(e, e.wrapped); i = a.isArray(h) ? a.map(h, function (a) { return a ? g(e, c, d, a) : null }) : [g(e, c, d, h)]; return k ? a(j(c, null, i)) : i }, tmplItem: function (b) { var c; if (b instanceof a) b = b[0]; while (b && b.nodeType === 1 && !(c = a.data(b, "tmplItem")) && (b = b.parentNode)); return c || p }, template: function (c, b) { if (b) { if (typeof b === "string") b = o(b); else if (b instanceof a) b = b[0] || {}; if (b.nodeType) b = a.data(b, "tmpl") || a.data(b, "tmpl", o(b.innerHTML)); return typeof c === "string" ? (a.template[c] = b) : b } return c ? typeof c !== "string" ? a.template(null, c) : a.template[c] || a.template(null, q.test(c) ? c : a(c)) : null }, encode: function (a) { return ("" + a).split("<").join("&lt;").split(">").join("&gt;").split('"').join("&#34;").split("'").join("&#39;") } }); a.extend(a.tmpl, { tag: { tmpl: { _default: { $2: "null" }, open: "if($notnull_1){_=_.concat($item.nest($1,$2));}" }, wrap: { _default: { $2: "null" }, open: "$item.calls(_,$1,$2);_=[];", close: "call=$item.calls();_=call._.concat($item.wrap(call,_));" }, each: { _default: { $2: "$index, $value" }, open: "if($notnull_1){$.each($1a,function($2){with(this){", close: "}});}" }, "if": { open: "if(($notnull_1) && $1a){", close: "}" }, "else": { _default: { $1: "true" }, open: "}else if(($notnull_1) && $1a){" }, html: { open: "if($notnull_1){_.push($1a);}" }, "=": { _default: { $1: "$data" }, open: "if($notnull_1){_.push($.encode($1a));}" }, "!": { open: ""} }, complete: function () { b = {} }, afterManip: function (f, b, d) { var e = b.nodeType === 11 ? a.makeArray(b.childNodes) : b.nodeType === 1 ? [b] : []; d.call(f, b); m(e); c++ } }); function j(e, g, f) { var b, c = f ? a.map(f, function (a) { return typeof a === "string" ? e.key ? a.replace(/(<\w+)(?=[\s>])(?![^>]*_tmplitem)([^>]*)/g, "$1 " + d + '="' + e.key + '" $2') : a : j(a, e, a._ctnt) }) : e; if (g) return c; c = c.join(""); c.replace(/^\s*([^<\s][^<]*)?(<[\w\W]+>)([^>]*[^>\s])?\s*$/, function (f, c, e, d) { b = a(e).get(); m(b); if (c) b = k(c).concat(b); if (d) b = b.concat(k(d)) }); return b ? b : k(c) } function k(c) { var b = document.createElement("div"); b.innerHTML = c; return a.makeArray(b.childNodes) } function o(b) { return new Function("jQuery", "$item", "var $=jQuery,call,_=[],$data=$item.data;with($data){_.push('" + a.trim(b).replace(/([\\'])/g, "\\$1").replace(/[\r\t\n]/g, " ").replace(/\$\{([^\}]*)\}/g, "{{= $1}}").replace(/\{\{(\/?)(\w+|.)(?:\(((?:[^\}]|\}(?!\}))*?)?\))?(?:\s+(.*?)?)?(\(((?:[^\}]|\}(?!\}))*?)\))?\s*\}\}/g, function (m, l, k, d, b, c, e) { var j = a.tmpl.tag[k], i, f, g; if (!j) throw "Template command not found: " + k; i = j._default || []; if (c && !/\w$/.test(b)) { b += c; c = "" } if (b) { b = h(b); e = e ? "," + h(e) + ")" : c ? ")" : ""; f = c ? b.indexOf(".") > -1 ? b + h(c) : "(" + b + ").call($item" + e : b; g = c ? f : "(typeof(" + b + ")==='function'?(" + b + ").call($item):(" + b + "))" } else g = f = i.$1 || "null"; d = h(d); return "');" + j[l ? "close" : "open"].split("$notnull_1").join(b ? "typeof(" + b + ")!=='undefined' && (" + b + ")!=null" : "true").split("$1a").join(g).split("$1").join(f).split("$2").join(d ? d.replace(/\s*([^\(]+)\s*(\((.*?)\))?/g, function (d, c, b, a) { a = a ? "," + a + ")" : b ? ")" : ""; return a ? "(" + c + ").call($item" + a : d }) : i.$2 || "") + "_.push('" }) + "');}return _;") } function n(c, b) { c._wrap = j(c, true, a.isArray(b) ? b : [q.test(b) ? b : a(b).html()]).join("") } function h(a) { return a ? a.replace(/\\'/g, "'").replace(/\\\\/g, "\\") : null } function s(b) { var a = document.createElement("div"); a.appendChild(b.cloneNode(true)); return a.innerHTML } function m(o) { var n = "_" + c, k, j, l = {}, e, p, h; for (e = 0, p = o.length; e < p; e++) { if ((k = o[e]).nodeType !== 1) continue; j = k.getElementsByTagName("*"); for (h = j.length - 1; h >= 0; h--) m(j[h]); m(k) } function m(j) { var p, h = j, k, e, m; if (m = j.getAttribute(d)) { while (h.parentNode && (h = h.parentNode).nodeType === 1 && !(p = h.getAttribute(d))); if (p !== m) { h = h.parentNode ? h.nodeType === 11 ? 0 : h.getAttribute(d) || 0 : 0; if (!(e = b[m])) { e = f[m]; e = g(e, b[h] || f[h]); e.key = ++i; b[i] = e } c && o(m) } j.removeAttribute(d) } else if (c && (e = a.data(j, "tmplItem"))) { o(e.key); b[e.key] = e; h = a.data(j.parentNode, "tmplItem"); h = h ? h.key : 0 } if (e) { k = e; while (k && k.key != h) { k.nodes.push(j); k = k.parent } delete e._ctnt; delete e._wrap; a.data(j, "tmplItem", e) } function o(a) { a = a + n; e = l[a] = l[a] || g(e, b[e.parent.key + n] || e.parent) } } } function u(a, d, c, b) { if (!a) return l.pop(); l.push({ _: a, tmpl: d, item: this, data: c, options: b }) } function w(d, c, b) { return a.tmpl(a.template(d), c, b, this) } function x(b, d) { var c = b.options || {}; c.wrapped = d; return a.tmpl(a.template(b.tmpl), b.data, c, b.item) } function v(d, c) { var b = this._wrap; return a.map(a(a.isArray(b) ? b.join("") : b).filter(d || "*"), function (a) { return c ? a.innerText || a.textContent : a.outerHTML || s(a) }) } function t() { var b = this.nodes; a.tmpl(null, null, null, this).insertBefore(b[0]); a(b).remove() } })(jQuery || $sc)
﻿/*!
 * jQuery JavaScript Library v1.5.1
 * http://jquery.com/
 *
 * Copyright 2011, John Resig
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * Includes Sizzle.js
 * http://sizzlejs.com/
 * Copyright 2011, The Dojo Foundation
 * Released under the MIT, BSD, and GPL Licenses.
 *
 * Date: Wed Feb 23 13:55:29 2011 -0500
 */

if (typeof(window.$sc) == "undefined") window.$sc = jQuery.noConflict(true);﻿if (typeof(window.$sc) != "undefined") {
  $sc.Event.prototype.stop = function() {    
    this.stopPropagation();
    this.preventDefault();
  };

  $sc.Event.prototype.isLeftButton = function() {
    var button = this.originalEvent.button;
    if (typeof(button) != "undefined") {
      return $sc.browser.msie ? button === 1 : button === 0;
    }
    else {
      return this.originalEvent.which === 1;
    }
  };

  $sc.event.special.elementresize = {
    setup:function() {
      // There's no native 'elementresize' event. Don't allow jQuery to attach it.
      return true;
    },

    add: function(handleObj) {
      if (this && this.attachEvent && handleObj.handler) {      
        this.attachEvent("onresize", handleObj.handler);                         
      }
    },

    remove: function(handleObj) {
      if (this && this.detachEvent && handleObj.handler) {       
        this.detachEvent("onresize", handleObj.handler);        
      }
    }
  };

  $sc.fn.update = function(html) {
    this.get(0).innerHTML = html;
    return this;
  };

  $sc.fn.outerHtml = function(value) {
    if(value) {
      $sc(value).insertBefore(this);
      $sc(this).remove();
    }
    else { 
      // IE has problems with cloning <SCRIPT> nodes. 
      if ($sc.browser.msie) {
        var html = "";
        this.each(function() { html += this.outerHTML; });
        return html;
      }

      return $sc("<div>").append($sc(this).clone()).html(); 
    }
  };

  $sc.extend({
    util: function() {
      return Sitecore.PageModes.Utility;
    },
       
    areEqualStrings: function (string1, string2, ignoreCase) {
      if ($sc.type(string1) !== "string") {
        throw "First parameter must be of a String type";
      }
      
      if ($sc.type(string2) !== "string") {
        throw "Second parameter must be of a String type";
      }
              
      if (ignoreCase) {
        return string1.toLowerCase() === string2.toLowerCase();                    
      }
      
      return string1 === string2; 
    },

    evalJSON: function(json) {
      return eval("("+json+")");
    },
      
    exists: function(_array, callback) {
      var length = _array.length;
      for (var i = 0; i < length; i++) {
        if (callback.call(_array[i], i)) {
          return true;
        }
      }

      return false;
    },

    findIndex: function(_array, callback) {
      var length = _array.length;
      for (var i = 0; i < length; i++) {
        if (callback.call(_array[i], i)) {
          return i;
        }
      }

      return -1;
    },

    first: function(_array, callback) {
      var length = _array.length;
      for (var i = 0; i < length; i++) {
        if (callback.call(_array[i], i)) {
          return _array[i];
        }
      }

      return null;
    },

    formatString: function(str) {
      if (!str) {
        return str;
      }

      for (var i = 1; i < arguments.length; i++) {
        str = str.replace(new RegExp('\\{' + (i - 1) + '\\}', 'gi'), arguments[i]);
      }

      return str;
    },

    last: function(_array, callback) {
      var length = _array.length;
      for (var i = length - 1; i >= 0; i--) {
        if (callback.call(_array[i], i)) {
          return _array[i];
        }
      }

      return null;
    },

    isHtml: function(content) {
      return this.removeTags(content) !== content;
    },

    parseQuery:function(query) {
      var result = {};
      query.replace(/([^?=&]+)(=([^&]*))?/g,
	      function($0, $1, $2, $3) { 
          result[$1] = $3;        
        }
	    );

      return result;
    },

    removeTags:function(html) {
      return html.replace(/<\w+(\s+("[^"]*"|'[^']*'|[^>])+)?>|<\/\w+>/gi, "");
    },

    toShortId:function(id) {
      if (!id) {
        return id;
      }

      return id.replace(/-|{|}/g ,"");
    },

    toId: function(shortId) {
      if (!shortId || shortId.length != 32) return shortId;
      return "{" +shortId.substr(0, 8) + "-" + shortId.substr(8, 4) + "-" + shortId.substr(12, 4) + "-" + shortId.substr(16, 4) + "-" + shortId.substr(20, 12) + "}";
    },

    truncate: function(string, length) {
      if (string.length > length) {
        return string.substr(0, length) + "...";
      }

      return string;
    }
  });
}﻿/* json2.js
 * 2008-01-17
 * Public Domain
 * No warranty expressed or implied. Use at your own risk.
 * See http://www.JSON.org/js.html
*/
if(!this.JSON){JSON=function(){function f(n){return n<10?'0'+n:n;}
Date.prototype.toJSON=function(){return this.getUTCFullYear()+'-'+
f(this.getUTCMonth()+1)+'-'+
f(this.getUTCDate())+'T'+
f(this.getUTCHours())+':'+
f(this.getUTCMinutes())+':'+
f(this.getUTCSeconds())+'Z';};var m={'\b':'\\b','\t':'\\t','\n':'\\n','\f':'\\f','\r':'\\r','"':'\\"','\\':'\\\\'};function stringify(value,whitelist){var a,i,k,l,r=/["\\\x00-\x1f\x7f-\x9f]/g,v;switch(typeof value){case'string':return r.test(value)?'"'+value.replace(r,function(a){var c=m[a];if(c){return c;}
c=a.charCodeAt();return'\\u00'+Math.floor(c/16).toString(16)+
(c%16).toString(16);})+'"':'"'+value+'"';case'number':return isFinite(value)?String(value):'null';case'boolean':case'null':return String(value);case'object':if(!value){return'null';}
if(typeof value.toJSON==='function'){return stringify(value.toJSON());}
a=[];if(typeof value.length==='number'&&!(value.propertyIsEnumerable('length'))){l=value.length;for(i=0;i<l;i+=1){a.push(stringify(value[i],whitelist)||'null');}
return'['+a.join(',')+']';}
if(whitelist){l=whitelist.length;for(i=0;i<l;i+=1){k=whitelist[i];if(typeof k==='string'){v=stringify(value[k],whitelist);if(v){a.push(stringify(k)+':'+v);}}}}else{for(k in value){if(typeof k==='string'){v=stringify(value[k],whitelist);if(v){a.push(stringify(k)+':'+v);}}}}
return'{'+a.join(',')+'}';}}
return{stringify:stringify,parse:function(text,filter){var j;function walk(k,v){var i,n;if(v&&typeof v==='object'){for(i in v){if(Object.prototype.hasOwnProperty.apply(v,[i])){n=walk(i,v[i]);if(n!==undefined){v[i]=n;}}}}
return filter(k,v);}
if(/^[\],:{}\s]*$/.test(text.replace(/\\./g,'@').replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,']').replace(/(?:^|:|,)(?:\s*\[)+/g,''))){j=eval('('+text+')');return typeof filter==='function'?walk('',j):j;}
throw new SyntaxError('parseJSON');}};}();}/*
	Base.js, version 1.1a
	Copyright 2006-2010, Dean Edwards
	License: http://www.opensource.org/licenses/mit-license.php
*/

var Base = function() {
	// dummy
};

Base.extend = function(_instance, _static) { // subclass
	var extend = Base.prototype.extend;
	
	// build the prototype
	Base._prototyping = true;
	var proto = new this;
	extend.call(proto, _instance);
  proto.base = function() {
    // call this method from any other method to invoke that method's ancestor
  };
	delete Base._prototyping;
	
	// create the wrapper for the constructor function
	//var constructor = proto.constructor.valueOf(); //-dean
	var constructor = proto.constructor;
	var klass = proto.constructor = function() {
		if (!Base._prototyping) {
			if (this._constructing || this.constructor == klass) { // instantiation
				this._constructing = true;
				constructor.apply(this, arguments);
				delete this._constructing;
			} else if (arguments[0] != null) { // casting
				return (arguments[0].extend || extend).call(arguments[0], proto);
			}
		}
	};
	
	// build the class interface
	klass.ancestor = this;
	klass.extend = this.extend;
	klass.forEach = this.forEach;
	klass.implement = this.implement;
	klass.prototype = proto;
	klass.toString = this.toString;
	klass.valueOf = function(type) {
		//return (type == "object") ? klass : constructor; //-dean
		return (type == "object") ? klass : constructor.valueOf();
	};
	extend.call(klass, _static);
	// class initialisation
	if (typeof klass.init == "function") klass.init();
	return klass;
};

Base.prototype = {	
	extend: function(source, value) {
		if (arguments.length > 1) { // extending with a name/value pair
			var ancestor = this[source];
			if (ancestor && (typeof value == "function") && // overriding a method?
				// the valueOf() comparison is to avoid circular references
				(!ancestor.valueOf || ancestor.valueOf() != value.valueOf()) &&
				/\bbase\b/.test(value)) {
				// get the underlying method
				var method = value.valueOf();
				// override
				value = function() {
					var previous = this.base || Base.prototype.base;
					this.base = ancestor;
					var returnValue = method.apply(this, arguments);
					this.base = previous;
					return returnValue;
				};
				// point to the underlying method
				value.valueOf = function(type) {
					return (type == "object") ? value : method;
				};
				value.toString = Base.toString;
			}
			this[source] = value;
		} else if (source) { // extending with an object literal
			var extend = Base.prototype.extend;
			// if this object has a customised extend method then use it
			if (!Base._prototyping && typeof this != "function") {
				extend = this.extend || extend;
			}
			var proto = {toSource: null};
			// do the "toString" and other methods manually
			var hidden = ["constructor", "toString", "valueOf"];
			// if we are prototyping then include the constructor
			var i = Base._prototyping ? 0 : 1;
			while (key = hidden[i++]) {
				if (source[key] != proto[key]) {
					extend.call(this, key, source[key]);

				}
			}
			// copy each of the source object's properties to this object
			for (var key in source) {
				if (!proto[key]) extend.call(this, key, source[key]);
			}
		}
		return this;
	}
};

// initialise
Base = Base.extend({
	constructor: function() {
		this.extend(arguments[0]);
	}
}, {
	ancestor: Object,
	version: "1.1",
	
	forEach: function(object, block, context) {
		for (var key in object) {
			if (this.prototype[key] === undefined) {
				block.call(context, object[key], key, object);
			}
		}
	},
		
	implement: function() {
		for (var i = 0; i < arguments.length; i++) {
			if (typeof arguments[i] == "function") {
				// if it's a function, call it
				arguments[i](this.prototype);
			} else {
				// add the interface using the extend method
				this.prototype.extend(arguments[i]);
			}
		}
		return this;
	},
	
	toString: function() {
		return String(this.valueOf());
	}
});
﻿function WordOCX_Initialize(wordObject) {

  // Disabling "Save" button
  wordObject.EnableFileCommand(3) = false; // "Save"
  wordObject.EnableFileCommand(4) = false; // "Save As"
}

function WordOCX_InsertLink(word, link, defaultText) {
  word.Activate();
  var doc = word.ActiveDocument;
  var range = doc.Application.Selection.Range;
  if (!range.Text){
    range.Text = defaultText;
  }
  else{
    var selectedHyperlinks = range.Hyperlinks;
    if (selectedHyperlinks) {
      while(selectedHyperlinks.Count > 0){
        selectedHyperlinks.Item(1).Delete();
      }
    }
  }
  doc.Hyperlinks.Add(range, link, '');
}

function WordOCX_InsertPicture(word, imagePath, alt) {
  var image;
  try {
    word.Activate();
    image = word.ActiveDocument.Application.Selection.InlineShapes.AddPicture(imagePath); //, false /* LinkToFile */, true /*SaveWithDocument*/);
  }
  catch(err) {
    if(err.description.indexOf('This is not a valid file name') > 0) {
       alert('Failed to insert media. \n. Possible reason: Item has not been published.');
    }
    throw err;
  }
  if(alt != null && alt != '') {
    image.AlternativeText = alt;
  }
  return image;
}

function WordOCX_UploadDocument(word, uploadLink, restoreDocument) {
  word.Activate();
  var tempFilePath1 = word.GetTempFilePath();    
  var tempFilePath2 = word.GetTempFilePath();    
  word.ActiveDocument.WebOptions.AllowPNG = true;
  
  word.ActiveDocument.SaveAs(tempFilePath1, 16 /* wdFormatDocumentDefault */, false, '', false, '', false, false, false, false, false);
  word.ActiveDocument.SaveAs(tempFilePath2, 10 /* wdFormatFilteredHTML */, false, '', false, '', false, false, false, false, false);      
  WordOCX_RestoreViewType(word);
  word.Close(); // We cannot upload an opened document
  
  word.HttpInit();
  word.HttpAddPostFile(tempFilePath1, "file.docx");
  word.HttpAddPostFile(tempFilePath2, "file.mhtml"); // we use 'mhtml' extension, since posting with 'html' extension did not work
  word.HttpAddPostRelatedFiles(tempFilePath2); // Adding image files to post data
  
  word.HttpPost(uploadLink);
}

function WordOCX_ToggleToolbar(word){
  word.Activate();
  word.Toolbars = !word.Toolbars;
}

 function WordOCX_RestoreViewType(word){
    if(!word.currentView){
      return;
    }
    if (!word.IsOpened) {
        wordObject.CreateNew("Word.Document");
    }
    word.ActiveDocument.ActiveWindow.View.Type = word.currentView;
  }
﻿if (typeof(Sitecore) == "undefined") Sitecore = {};
if (typeof(Sitecore.PageModes) == "undefined") Sitecore.PageModes = new Object();

Sitecore.PageModes.Utility = new function() {
  this.isIE =  $sc.browser.msie;

  this.elements = function(object) {
    if (object instanceof $sc) {
      return object;
    }

    if (object.elementsAndMarkers) {
      return object.elementsAndMarkers();
    }

    throw "Unexpected object, can accept only jQuery objects or chromes";
  };
       
  //Defines if browser is IE in non-standards mode (standards mode:IE 8 standards mode and higher)
  this.isNoStandardsIE = function() {
    return this.isIE && (!document.documentMode || document.documentMode < 8);
  };
  
  this.addStyleSheet = function(cssRule) {
    var el= document.createElement("style");
    el.type= "text/css";        
    if(el.styleSheet) { 
      el.styleSheet.cssText= cssRule;
    }
    else { 
      el.appendChild(document.createTextNode(cssRule));
    }

    return document.getElementsByTagName("head")[0].appendChild(el);
  };

  this.areEqualPlaceholders = function(lhsPlaceholderKey, rhsPlaceholderKey) {
    var ignoreCase = true;
    if (lhsPlaceholderKey == null || rhsPlaceholderKey == null) {
      return lhsPlaceholderKey == rhsPlaceholderKey;
    }

    var lhsSlashIndex = lhsPlaceholderKey.lastIndexOf('/');
    var rhsSlashIndex = rhsPlaceholderKey.lastIndexOf('/');
    if (lhsSlashIndex >= 0 && rhsSlashIndex >=0)
    {
      return $sc.areEqualStrings(lhsPlaceholderKey, rhsPlaceholderKey, ignoreCase);
    }

    var lhsShortKey = (lhsSlashIndex >= 0) ? lhsPlaceholderKey.substr(lhsSlashIndex + 1) : lhsPlaceholderKey;
    var rhsShortKey = (rhsSlashIndex >= 0) ? rhsPlaceholderKey.substr(rhsSlashIndex + 1) : rhsPlaceholderKey;
    return $sc.areEqualStrings(lhsShortKey, rhsShortKey, ignoreCase);
  };

  this.copyAttributes = function(source, target) {
    var i;
    if (!target || !target.attributes) {
      return;
    }
          
    for (i = 0; i < target.attributes.length; i++) {        
      if (target.attributes.item(i).specified) {
        target.attributes.removeNamedItem(target.attributes.item(i).name);
      }
    }

    if (!source || !source.attributes) {
      return;
    }
               
    var length = source.attributes.length;
    for (i = 0; i < length; i++) {
      if (source.attributes.item(i).specified && source.attributes.item(i).value ) {
        var attrName = source.attributes.item(i).name;
        var attrValue = source.attributes.item(i).value;
        // OT issue #341614              
        if (attrName.toLowerCase() === "class") {
          target.className = attrValue;
          continue;  
        }
             
        target[attrName] = attrValue;       
      }
    }              
  };

  this.getCookie = function(name) {
    name = name + "=";
    var i = 0;
    while(i < document.cookie.length) {
      var j = i + name.length;
      if(document.cookie.substring(i, j) == name) {
        var n = document.cookie.indexOf(";", j);
        if(n == -1) {
          n = document.cookie.length;
        }

        return unescape(document.cookie.substring(j, n));
      }

      i = document.cookie.indexOf(" ", i) + 1;
      if(i == 0) {
        break;
      }
    }

    return null;
  };

  this.getObjectAlternateHtml = function(element) {
    if (!element) {
      return;
    }
    
    var childObject, wrapper = $sc("<div></div>");
    var $element = element.jquery ? element : $sc(element);
    if ($element.is("embed")) {
      var noembed = $element.children("noembed")[0] || $element.next("noembed")[0];
      if (!noembed) {
        return;
      }
             
      return this.unescapeHtml(noembed.innerHTML);     
    }

    if (!$element.is("object")) {
      return;
    }
        
    if (this.isIE && document.documentMode && document.documentMode < 9) {
      wrapper.html($element[0].altHtml);
      childObject = wrapper.children("object")[0];
      if (childObject) {
        return this.getObjectAlternateHtml(childObject);      
      }

      return wrapper.html();      
    }
       
    childObject = $element.children("object")[0];
    if (childObject) {
      return this.getObjectAlternateHtml(childObject);      
    }

    $element.contents().not("param, embed, noembed").clone().appendTo(wrapper);    
    return wrapper.html();
  };

  this.log = function(message) {
    if (!Sitecore.PageModes.PageEditor.debug()) {
      return;
    }

    console.log(message);
  };

  this.parseCommandClick = function(commandClick) {
    var msg = commandClick;
    var commandParams = null;
    var idx1 = commandClick.indexOf("(");
    var idx2 = commandClick.indexOf(")");
    if (idx1 >= 0 && idx2 > idx1) {
      msg = commandClick.substring(0, idx1);
      try {
        commandParams = $sc.evalJSON(commandClick.substring(idx1 + 1, idx2));
      }
      catch (e) {
        console.log("Cannot parse command parameters");
      }
    }

    return { message: msg, params : commandParams};
  };

  this.parsePalleteResponse = function(response) {
    if (!response) {
      return null;
    }

    var tmp = document.createElement("div");
    tmp.innerHTML = response;
    var form = $sc(tmp).find("#scPaletteForm");
    if (form.length < 1) {
      delete tmp;
      return null;
    }
    
    var scripts = [];
    form.find("script").each(function() {
      if (this.src) {
        scripts.push(this.src);
      }
      
      $sc(this).filter("[type!='text/sitecore']").remove();      
    });

    var styleSheets = [];
    form.find("link[rel='stylesheet']").each(function() {
      if (this.href) {
        styleSheets.push(this.href);
      }
      
      $sc(this).remove();
    });
       
    var layout = form.find("#scLayoutDefinitionHolder");
    if (layout.length < 1) {
      delete tmp;
      return null;
    }

    var result = {};
    result.scripts = scripts;
    result.styleSheets = styleSheets;
    result.layout = layout.text();
    
    var url = form.find("#scUrlHolder");
    if (url.length > 0) {
      result.url = url.text();
      delete tmp;
      return result;
    }

    var htmlHolder = form.find("#scHTMLHolder");
    if (htmlHolder.length < 1)
    {
      delete tmp;
      return null;
    }

    result.html = htmlHolder.get(0).innerHTML;   

    delete tmp;
    return result;
  };

  this.renderTemplate = function(templateName, template, data, options) {
    if (!$sc.template[templateName]) {
      $sc.template(templateName, template);
    }

    return $sc.tmpl(templateName, data, options);
  };

  this.removeCookie = function(name, path, domain, secure) {
    if (this.getCookie(name)) {
      var expires = new Date();
      expires.setMonth(expires.getMonth() - 1);
      this.setCookie(name, "", expires, path, domain, secure); 
    }
  }; 

  this.setCookie = function(name, value, expires, path, domain, secure) {
    if (expires == null) {
      expires = new Date();
      expires.setMonth(expires.getMonth() + 3);
    }
    
    if (path == null) {
      path = "/";
    }

    document.cookie = name + "=" + escape(value) +
      (expires ? "; expires=" + expires.toGMTString() : "") +
      (path ? "; path=" + path : "") +
      (domain ? "; domain=" + domain : "") +
      (secure ? "; secure" : "");
  };
  
  this.tryAddScripts = function(scriptUrls) {
    if (!scriptUrls) {
      return;
    }

    if (!scriptUrls.length || scriptUrls.length < 1) {
      return;
    }

    var pageScripts = $sc("script");    
    for (var i = 0; i < scriptUrls.length; i++) {
      var url = scriptUrls[i];
      if (!$sc.exists(pageScripts, function () { return this.src == url; })) {
        try {
          var script = document.createElement('script');
          script.type = 'text/javascript';
          script.src = url;
          var head = document.getElementsByTagName("head")[0];
          if (!head) {
            head = document.createElement("head");
            document.appendChild(head);
          }

          head.appendChild(script);
        }
        catch(ex) {
          console.log("Failed to add script " + url);
        }
      }            
    }
  };

  this.tryAddStyleSheets = function(hrefs) {
    if (!hrefs) {
      return;
    }

    if (!hrefs.length || hrefs.length < 1) {
      return;
    }

    var styleSheets = $sc("link[rel='stylesheet']");    
    for (var i = 0; i < hrefs.length; i++) {
      var url = hrefs[i];
      if (!$sc.exists(styleSheets, function () { return this.href == url; })) {
        try {
          if (document.createStyleSheet) {
            document.createStyleSheet(url);
          }
          else {
            var newSS = document.createElement('link');
            newSS.rel = 'stylesheet';
            newSS.href = url;
            document.getElementsByTagName("head")[0].appendChild(newSS);
          }
        }
        catch(ex) {
          console.log("Failed to add styleshhet " + url);
        }
      }            
    }
  }; 

  this.unescapeHtml = function(html) {
    if (!html) {
      return html;
    }

    return html.replace(/&lt;/gi, "<").replace(/&gt;/gi, ">");
};
};
﻿Sitecore.Event = Base.extend({
  constructor: function() {
    this._callbacks = new Array();
  },
  
  fire: function(args) {
    var length = this._callbacks.length;
    for (var i = 0; i < length; i++) {
      this._callbacks[i](args);
    }    
  },
  
  observe: function(callback) {
    if ($sc.inArray(callback, this._callbacks) > -1) {
      return;
    }
    
    this._callbacks.push(callback);
  },
  
  stopObserving: function(callback) {    
    this._callbacks = $sc.grep(this._callbacks, function(func) { return func !== callback; });    
  }
});﻿if (typeof(Sitecore.PageModes) == "undefined") {
  Sitecore.PageModes = new Object();
}

/**
* @class Reperesents a cache
*/
Sitecore.PageModes.Cache = Base.extend({
  _cacheInstance: {},
  
  /**
  * @description Adds the specified value under the specified key
  * @param {String} key The key
  * @param {} value The value
  */
  setValue: function(key, value) {
    this._cacheInstance[key] = value;
  },

  /**
  * @description Gets the value from the cache
  * @param {String} key The key
  * @returns The value or 'undefined' if the value under the specified key is not in the cache
  */
  getValue: function(key) {
    return this._cacheInstance[key];
  },

  /**
  * @description Removes the value from the cache
  * @param {String} key The key  
  */
  clear: function(key) {
    delete this._cacheInstance[key];
  },

  /**
  * @description Removes all instances from the cache
  */
  clearAll: function() {
    this._cacheInstance = {};
  }
});﻿if (typeof(Sitecore.PageModes) == "undefined") Sitecore.PageModes = new Object();
if (typeof(Sitecore.PageModes.ChromeTypes) == "undefined") Sitecore.PageModes.ChromeTypes = new Object();

Sitecore.PageModes.ChromeTypes.ChromeType = Base.extend({
  constructor: function() {
    this._isReadOnly = false;
  },

  controlId: function() {
    return this.chrome.element.attr("id");
  },
  
  dataNode: function(domElement) {
    if (!domElement) {
      console.warn("no dom element");
    }

    if (domElement.is("code[type='text/sitecore']")) {
      return domElement;
    }

    return domElement.children(".scChromeData");
  },

  elements: function(domElement) {
    return { opening: null, content: domElement, closing: null};
  },
   
  // Return values:
  // * null - the ribbon context item shouldn't be changed
  // * "" - the ribbon context item should be changed to the one of the whole page
  // * non-empty string - the context item should be changed to the one specified by the string uri 
  getContextItemUri: function () {
    var uri = this.chrome.data.contextItemUri;
    return uri == null ? "" : uri;
  },
      
  handleMessage: function(message, params, sender) {
  },

  delegateMessageHandling: function(sender, recipient, message, params)
  {
    if (recipient) {
      recipient.handleMessage(message, params, sender);
    }
    else {
      console.error("delegated message handler not found");
    }
  },
    
  icon: function() {
    return '/sitecore/shell/~/icon/ApplicationsV2/16x16/bullet_square_glass_blue.png.aspx';
  },

  isEnabled: function() {
    return this.chrome && this.chrome.hasDataNode;
  },

  isReadOnly: function() {
    return this._isReadOnly;
  },

  setReadOnly: function() {
    this._isReadOnly = true;
  },

  key: function() {
    return "override chrometype type key";
  },
    
  layoutRoot: function() {        
    return this.chrome.element;
  },

  onShow: function() {
  },

  onHide: function() {
  },
  
  onDelete: function(preserveData) {
    var childChromes = this.chrome.getChildChromes(function() { return this != null;});
    $sc.each(childChromes, function() { this.onDelete(preserveData); });
  },
  
  _getElementsBetweenScriptTags: function(openingScriptNode) {
    var result = new Array();

    var currentNode = openingScriptNode.next();
    
    while(currentNode && !currentNode.is("code[type='text/sitecore'][kind='close'][chromeType='" + this.key() + "']")) {      
      //field value inputs (with scFieldValue class) are moved from their original dom poisition into special "scFieldValue" container.
      //Considering them as part of chrome will cause problems with chrome hierarchies. 
      if (!currentNode.is("code[type='text/sitecore']") && !currentNode.hasClass("scFieldValue")) {
        result.push(currentNode.get(0));
      }

      currentNode = currentNode.next();

      if (currentNode.length == 0) {
        console.error("Malformed page editor <script></script> tags - closing tag not found. Opening tag:");
        console.log(openingScriptNode);
        throw "Failed to parse page editor element demarked by script tags";
      }
    }

    return { opening: openingScriptNode, content:$sc(result), closing: currentNode };
  }
});
﻿if (typeof(Sitecore.PageModes) == "undefined") {
  Sitecore.PageModes = new Object();
}

/**
* @class represents single notification message
*/
Sitecore.PageModes.Notification = Base.extend({
   /**
  * @constructor Creates an instance of a class 
  */
  constructor: function(id, text, options) {
    if (!options) {
      options = {};
    }

    this.id = id.toLowerCase();
    this.text = text;
    this.actionText = options.actionText;
    this.onActionClick = options.onActionClick || $sc.noop();
    this.type = options.type || "warning";
    switch(this.type) {
      case "warning":
        this.notificationTypeCssClass = "scWarning";
        break;
      case "error":
        this.notificationTypeCssClass = "scError";
        break;
      case "info":
        this.notificationTypeCssClass = "scInfo";
        break;
      default:
        this.notificationTypeCssClass = "scWarning";
    }
  }
},
{
  template: [      
      " <div data-notification-id='${id}' class='scNotification  ${notificationTypeCssClass}'>",
      "    <img class='scClose' src='/sitecore/shell/Themes/Standard/Images/Progress/globalsearch_close.png'/>",
      "    <span class='scDescription'>${text}</span>",
      "    {{if actionText}}",
      "    <a class='scAction' href='#'>${actionText}</a>",
      "    {{/if}}",
      " </div>",   
    ].join("\n")
}
);

/**
* @class represents the notification bar
*/
Sitecore.PageModes.NotificationBar = Base.extend({
  /**
  * @constructor Creates an instance of a class 
  */
  constructor: function() {   
    this.position = null;
    this.notifications = [];    
  },

  /**
  * @description Adds new notification unless it is not already in the list
  * @param {Notification} The notification. @see Sitecore.PageModes.Notification
  */
  addNotification: function(notification) {
    var notificationId = notification.id;
    if ($sc.exists(this.notifications, function() { return this.id == notificationId; })) {
      return;
    }

    this.notifications.push(notification);
  },

  /**
  * @description Gets the notification message by id
  * @param {String} id The notification id.
  * @return {Notification} The notification. @see Sitecore.PageModes.Notification
  */
  getNotification:  function(id) {
    return $sc.first(this.notifications, function() { return this.id == id});
  },

  /**
  * @description Removes the specified notification from the list
  * @param {String} id The notification id.
  * @return {Notification} The notification. @see Sitecore.PageModes.Notification
  */
  removeNotification: function(id) {
    var idx = $sc.findIndex(this.notifications, function() { return this.id == id; });
    if (idx < 0) {
      return;
    }

    this.notifications.splice(idx, 1);
  },

  /**
  * @description Create DOM nodes
  */
  create: function() {    
    this.bar = $sc("<div></div>").addClass("scNotificationBar").hide().appendTo(document.body);
    this.bar.click($sc.proxy(this.clickHandler, this));
  },

   /**
  * @description Handles click on notification bar
  * @param {Event} e The event.
  */
  clickHandler: function(e) {
    var sender = $sc(e.target), notification, n;
    if (sender.hasClass("scClose")) {
      notification = sender.closest(".scNotification");
      if (!notification.length) {
        return;
      }

      notification.hide();
      this.removeNotification(notification.attr("data-notification-id").toLowerCase());
      return;
    }

    if (sender.hasClass("scAction")) {
      notification = sender.closest(".scNotification");
      if (!notification.length) {
        return;
      }

      notification = this.getNotification(notification.attr("data-notification-id").toLowerCase());
      if (notification && notification.onActionClick) {
        notification.onActionClick();
      }
    }
  },

  /**
  * @description Defines if position is specifed for the bar
  * @returns {Boolean} Value indication if position is specified
  */
  hasPosition: function() {
    return this.position != null;
  },

  /**
  * @description Hides the bar 
  */
  hide: function() {
    if (this.bar) {
      this.bar.hide();
    }
  },

  /**
  * @description Renders the notification
  */
  render:function() {
    if (!this.bar) {
      this.create();
    }
   
    var template = Sitecore.PageModes.Notification.template;
    this.bar.html("").append($sc.util().renderTemplate("sc-notificationBar", template, this.notifications));
  },

  /**
  * @description Resets the bar 
  */
  resetPosition: function() {
    this.position = null;
  },

  /**
  * @description Sets the position 
  */
  setPosition: function(pos) {
    this.position = pos;
  },

  /**
  * @description Shows the bar 
  */
  show: function() {  
    this.render();
    if (this.hasPosition()) {    
      this.bar.css({top: this.position.top + "px", left: this.position.left + "px"});          
    }
        
    this.bar.show();
  },

  /**
  * @description Defines if bar is visisble
  * @retruns {Boolean} Value indicating if bar is visible 
  */
  visible: function() {
    return this.bar && this.bar.is(":visible");
  }
});
﻿if (typeof(Sitecore.PageModes) == "undefined") {
  Sitecore.PageModes = new Object();
}

// Manages element's positioning inside an available viewport.
Sitecore.PageModes.PositioningManager = function() {
  this.instance = null;

  var getInstance = function() {
    if (!this.instance) {
      this.instance = createInstance();
    }
    return this.instance;
  };
    
  var createInstance = function() {    
    return {

      //Sets  available region inside which elements can be positioned 
      calculateViewportRegion: function() {
        if (!this.$document) {
          this.$document = $sc(document);          
        }

        if (!this.window){
          this.$window = $sc(window);
        }
         
        var dimensions = {width: this.$window.width(), height: this.$window.height()};
        var offset = {top: this.$document.scrollTop(), left: this.$document.scrollLeft()};               
        var ribbon = $sc("#scWebEditRibbon");
        var ribbonHeight = ribbon.hasClass("scFixedRibbon") ? ribbon.outerHeight() : 0;       
        this.viewportRegion = {left: offset.left, right: offset.left + dimensions.width, top: offset.top + ribbonHeight, bottom: offset.top + dimensions.height};
      },
      
      // Returns values indicating in what dimensions element overflows the viewport.
      getElementOverflow: function(top, left, element) {       
        this.calculateViewportRegion();       
        return this._getOverflow(top, left, element.outerWidth(), element.outerHeight());        
      },

      // Returns element's top and left values, that will make element appear inside the viewport
      getFixedElementPosition: function(top, left, element) {        
        var overflow = this.getElementOverflow(top, left, element);
        return { top: top + overflow.deltaY, left: left + overflow.deltaX };
      },

      // Returns element's top and left values, that will make element appear inside the viewport and docked to chrome's border if possible
      getFixedChromeRelativeElementPosition: function(dimensions, chrome) {        
        var bottomMargin = 2;
        var topMargin = -1;
        this.calculateViewportRegion();               
        var chromeOffset = chrome.position.offset();
        var chromeDimensions = chrome.position.dimensions();
        var top = chromeOffset.top - dimensions.height;
        var left = chromeOffset.left + 2;
        if (chrome.type.key() == "word field") {
          if ( this._getOverflow(chromeOffset.top, chromeOffset.left, chromeDimensions.width, chromeDimensions.height).isOutOfViewport) {
            return {top: chromeOffset.top + chromeDimensions.height + bottomMargin, left: -1000};
          }

          return {top: chromeOffset.top + chromeDimensions.height + bottomMargin, left: left};
        }
                
        if (chrome.type.key() == "field" && chrome.type.contentEditable()) {
          left--;
        }

        var overflow = this._getOverflow(top, left, dimensions.width, dimensions.height);
        if (!overflow.hasOverflow) {
          return {top: top, left: left};
        }
        
        var chromeOverflow = this._getOverflow(chromeOffset.top, chromeOffset.left, chromeDimensions.width, chromeDimensions.height);
        if (chromeOverflow.isOutOfViewport) {
          return {top: top, left: -1000};
        }

        var fixedLeft = left;
        var fixedTop = top;                
        //right overflow - dock element to the chrome's right border 
        if (overflow.deltaX < 0) {                                        
          fixedLeft = chromeOffset.left + chromeDimensions.width - dimensions.width;           
        }
        //left overflow - dock element to the chrome's left border
        if (overflow.deltaX > 0) {
          fixedLeft = chromeOffset.left;          
        }
        //top overflow - dock element to the chrome's bottom border
        if (overflow.deltaY > 0) {                    
          fixedTop = chromeOffset.top + chromeDimensions.height + bottomMargin;
        }
        //bottom overflow - dock element to the chrome's top border
        if (overflow.deltaY < 0) {          
          fixedTop = chromeOffset.top - dimensions.height + topMargin;
        }
        
        var fixedOverflow = this._getOverflow(fixedTop, fixedLeft, dimensions.width, dimensions.height);
        //Docking to one of the chrome's borders failed - just position element inside a viewport.
        if (fixedOverflow.hasOverflow) {
          var returnValue = new Object();
          returnValue.left = ( fixedOverflow.deltaX == 0 ) ? fixedLeft : left + overflow.deltaX;
          returnValue.top = ( fixedOverflow.deltaY == 0) ? fixedTop : top + overflow.deltaY;
          return returnValue;
        }

        return { top: fixedTop, left: fixedLeft };
      },
      
      scrollIntoView: function(chrome) {
        this.calculateViewportRegion();               
        var chromeOffset = chrome.position.offset();
        var chromeDimensions = chrome.position.dimensions();
        var overflow = this._getOverflow(chromeOffset.top, chromeOffset.left, chromeDimensions.width, chromeDimensions.height);
        if (!overflow.hasOverflow) {
          return;
        }

        var currentScrollTop = this.$document.scrollTop();
        var currentScrollLeft = this.$document.scrollLeft();
        this.$window.scrollTop(currentScrollTop - overflow.deltaY).scrollLeft(currentScrollLeft - overflow.deltaX);
      },
      
      _getOverflow: function(top, left, width, height) {
        var dX = 0;
        var isOutOfViewport = false;        
        if (left < this.viewportRegion.left) {
          dX = this.viewportRegion.left - left;
          if (left + width < this.viewportRegion.left) {
            isOutOfViewport = true;
          }
        }
        //It's OK if we return the only overflow when element has both right and left one (Element is wider than viewport hence we can't position it correctly anyway)
        if (left + width > this.viewportRegion.right) {
          dX = this.viewportRegion.right - (left + width);
          if (left > this.viewportRegion.right) {
            isOutOfViewport = true;
          }
        }

        var dY = 0;
        if (top < this.viewportRegion.top) {
          dY = this.viewportRegion.top - top;
          if (top + height < this.viewportRegion.top) {
            isOutOfViewport = true;
          }
        }
        
        if (top + height > this.viewportRegion.bottom) {
          dY = this.viewportRegion.bottom - (top + height);
          if (top > this.viewportRegion.bottom) {
            isOutOfViewport = true;
          }
        }

        return {
                  hasOverflow: dX != 0 || dY != 0, 
                  deltaX: dX, 
                  deltaY: dY, 
                  isOutOfViewport: isOutOfViewport                  
               };
      }     
    };
  };
 
  return getInstance();
};﻿if (typeof(Sitecore.PageModes) == "undefined") {
  Sitecore.PageModes = new Object();
}

/**
* The enumeration for availablle page editor's capabilities.
* @enum {String}
*/
Sitecore.PageModes.Capabilities = {
  design: "design",
  edit: "edit",
  personalization: "personalization",
  testing: "testing"
};


/**
* @static
* @class represents Page Editor
*/
Sitecore.PageModes.PageEditor = new function() {
  /** @private */
  this._capabilities = [];  
  this.onSave = new Sitecore.Event();
  this.onWindowScroll = new Sitecore.Event();
  this.onCapabilityChanged = new Sitecore.Event();
  this.onControlBarStateChanged = new Sitecore.Event();
  this.notificationBar = new Sitecore.PageModes.NotificationBar(); 
  this.onLoadComplete = new Sitecore.Event();
    
  /**
  * @description enables/disables Page Editor's capability. @see Sitecore.PageModes.Capabilities
  * @param {String} capability The name of the capability
  * @param {Boolean} enabled Determines if capability should be enabled or disabled
  */
  this.changeCapability = function(capability, enabled) {
    if (!this.editing()) {
        return;
    }
        
    if (!enabled) {         
      var idx = $sc.inArray(capability, this._capabilities);
      if (idx > -1) {
        this._capabilities.splice(idx, 1);
      }
    }
    else {      
      this._capabilities.push(capability);
    }

    this.onCapabilityChanged.fire();
  };

  /**
  * @description enables/disables Page Editor's controls highlight.  
  * @param {Boolean} enabled Determines if highlight should be enabled or disabled
  */
  this.changeShowControls = function(enabled) {
    if (!this.editing()) {
        return;
    }

    if (!enabled) {
      Sitecore.PageModes.ChromeHighlightManager.deactivate();
    }
    else {
      Sitecore.PageModes.ChromeHighlightManager.activate();
    } 
  };

  this.changeVariations = function(combination, selectChrome) {    
    Sitecore.PageModes.ChromeManager.batchChangeVariations(combination, selectChrome);              
  };

  this.debug = function() {
    return window.location.href.indexOf("pedebug=1") >= 0 || this._debug;
  };

  this.editVariationsComplete = function(controlId, params) {
    var component = $sc.first(Sitecore.PageModes.ChromeManager.chromes(), function() { 
      return this.controlId() === controlId;
    });

    if (component) {
      Sitecore.PageModes.ChromeManager.select(component);      
      component.handleMessage("chrome:rendering:editvariationscompleted", params); 
    }
  };

  /**
  * @description Gets the currently enabled capabilities. See @Sitecore.PageModes.Capabilities
  * @returns {String[]} The names of enbled capabilities
  */
  this.getCapabilities = function() {
    return this._capabilities;
  };

  this.getTestingComponents = function() {
    var result = {};
    $sc.each(Sitecore.PageModes.ChromeManager.chromes(), function() {
      if (this.key() === "rendering") {
        var variations = this.type.getVariations();
        if (variations.length > 0) {
          var arr = [];
          $sc.each(variations, function() {
            arr.push({id: this.id, isActive: this.isActive, value: this.value});            
          });

          result[this.type.uniqueId()] = arr;
        }
      }
    });

    return result;
  };

  /**
  * @description Indicates if analytics is enabled
  * @returns {Boolean} The value indicating if analytics is enabled
  */
  this.isAnalyticsEnabled = function() {
    return !!Sitecore.WebEditSettings.anlyticsEnabled;
  };

  /**
  * @description Indicates if the ribbon is displayed in fixed position (on top of the screen), or is running in the legacy placeholder mode. 
  * @return {Boolean} The value indicating if the ribbon is fixed.
  */
  this.isFixedRibbon = function() {
    var ribbon = $sc(this.ribbon());

    return ribbon.hasClass("scFixedRibbon");
  };

  /**
  * @description Indicates if there are unsaved changes in Page Editor
  * @returns {Boolean} The value indicating if there are unsaved changes
  */
  this.isModified = function() {
    var form = this.ribbonForm();
    if (!form) {
      return !!this.modified;
    }

    return form.modified;
  };

  this.isTestRunning = function() {
    if (this._isTestRunning != null) {
      return this._isTestRunning;
    }
        
    var testRunningFlag = document.getElementById("scTestRunningFlag");
    if (!testRunningFlag) {
      this._isTestRunning = false;
      return false;
    }

    this._isTestRunning = testRunningFlag.value === "true";
    return this._isTestRunning;
  };

  /**
  * @description Indicates if Page Editor editing is allowed.
  * @returns {Boolean} The value indicating if Page Editor editing is allowed.
  */
  this.editing = function() {
    return !!Sitecore.WebEditSettings.editing;
  };
  
  this.controlBarStateChange = function() {
     Sitecore.PageModes.ChromeManager.resetSelectionFrame();
     this.onControlBarStateChanged.fire();
  };

  /**
  * @description Defines if personalization bar is visible
  * @returns {Boolean} value indicating whether personalization bar is visisble or not
  */
  this.isControlBarVisible = function() {
    var ribbon = this.ribbon();
    return ribbon && ribbon.contentWindow && ribbon.contentWindow.scControlBar;
  };

  /**
  * @description Defines if Page Editor is loaded
  * @returns {Boolean} value indicating whether Page Editor is loaded or not
  */
  this.isLoaded = function() {
    return !!this._isLoaded;
  }; 

  /**
  * @description Defines if personalization feature is accesible for the user
  * @returns {Boolean} value indicating whether personalization feature is enabled
  */
  this.isPersonalizationAccessible = function() {
     return $sc.inArray(Sitecore.PageModes.Capabilities.personalization, this._capabilities) > -1;
  };

  /**
  * @description Defines if testing feature is accesible for the user
  * @returns {Boolean} value indicating whether testing feature is enabled
  */
  this.isTestingAccessible = function() {
     return $sc.inArray(Sitecore.PageModes.Capabilities.testing, this._capabilities) > -1;
  };

  /**
  * @description Gets the id of the context item
  * @returns {String} The short id
  */
  this.itemId = function() {
    return $sc("#scItemID").val()
  };

   /**
  * @description Gets the content language
  * @returns {String} The language
  */
  this.language = function() {
    return $sc("#scLanguage").val()
  };

  /**
  * @description Gets the language CSS class
  * @returns {String} The language CSS class
  */
  this.languageCssClass = function () {
    return $sc("#scLanguageCssClass").val()
  };

  /**
  * @description Gets the client device id
  * @returns {String} The device id
  */
  this.deviceId = function() {
    return $sc("#scDeviceID").val();
  };

  /**
  * @description Gets the current layout definition
  * @returns {String} The Layout definition (in JSON notation)
  */
  this.layout = function() {
    return $sc("#scLayout").val();
  };

  /**
  * @description Action performed on saving action.  
  */
  this.onSaving = function() {    
    this.notificationBar.removeNotification("fieldchanges");
    this.notificationBar.show();
    this.onSave.fire();
  };

  /**
  * @description Makes a request to Sitecore
  * @param request Request parameters
  * @param {Function} [callback] A callback function to be called after request is complete.
  * @param {Boolean} [async=true] The value indicating if the request should be asynchronous.
  */
  this.postRequest = function(request, callback, async) {
    var form = this.ribbonForm();
    if (!form) {
      return;
    }

    isAsync = (typeof (async) == 'undefined') ? true : async;
    form.postRequest("", "", "", request, callback, isAsync);
  };

  /**
  * @description Refreshes the ribbon  
  */
  this.refreshRibbon = function() {
    this.postRequest("ribbon:update", null, true);
  };

  /**
  * @description Gets the Page Editor's ribbon instance
  * @returns {Node} The iframe containing the ribbon.
  */
  this.ribbon = function() {
    return $sc("#scWebEditRibbon")[0];
  };

  /**
  * @description Gets the ribbon's Sitecore form instance
  * @returns {scSitecore} The sitecore form. @see scSitecore.
  */
  this.ribbonForm = function() {
    var ribbon = this.ribbon();
    if (!ribbon) {
      return null;
    }
    
    if (!ribbon.contentWindow) {
      return null;
    }

    return ribbon.contentWindow.scForm;
  };
    
  /**
  * @description Saves the changes
  * @param {String} postaction The post action to be performed afer saving.
  */
  this.save = function(postaction) {    
    var command = "webedit:save";
    if (postaction) {
      command += "(postaction=" + postaction + ")";
    }
        
    this.onSaving();
    this.postRequest(command, null, false);
  };
  
  this.selectElement = function(id) {
    var element = $sc.first(Sitecore.PageModes.ChromeManager.chromes(), function() { return this.controlId() === id; });
    if (element) {           
      Sitecore.PageModes.ChromeManager.scrollChromeIntoView(element);
      Sitecore.PageModes.ChromeManager.select(element);
      return element;
    }

    return null;
  };

  this.highlightElement = function(id) {
    var element = $sc.first(Sitecore.PageModes.ChromeManager.chromes(), function() { return this.controlId() == id; });
    if (element) {
      element.showHover();
      return element;
    }

    return null;
  };

  this.stopElementHighlighting = function(id) {
    var element = $sc.first(Sitecore.PageModes.ChromeManager.chromes(), function() { return this.controlId() == id; });
    if (element) {
      element.hideHover();
      return element;
    }

    return null;
  };
  
  /**
  * @description Shows the notification bar  
  */
  this.showNotificationBar = function() {    
    if (!this.notificationBar.hasPosition()) {
      var ribbon = this.ribbon();
      if (ribbon) {
        var $ribbon = $sc(ribbon);
        var top = 0;
        if ($ribbon.hasClass("scFixedRibbon")) {
          var height = $ribbon.outerHeight();          
          top = parseInt($ribbon.css("top")) + height;
        }

        this.notificationBar.setPosition({top: top, left: 0});
      }      
    }
        
    this.notificationBar.show();
  };

  /**
  * @description Updates the specified field with specified values
  * @param {String} id - The id. (i.e "fld_ItemId_filedId_lang_ver")
  * @param {String} htmlValue - The field's rendered value
  * @param {String} plainValue - The field's raw value
  * @param {Boolean} [preserveInnerContent] - Instead of setting whole innerHtml only setting needed attributes    
  */
  this.updateField = function(id, htmlValue, plainValue, preserveInnerContent) {
    Sitecore.PageModes.ChromeManager.updateField(id, htmlValue, plainValue, preserveInnerContent);
  };
 
  /**
  * @description Sets a value indicating if Page editor has unsaved  changes or not
  * @param {Boolean} value indicating if Page Editor has unsaved changes
  */
  this.setModified = function(value) {   
    this.modified = value;
    var form = this.ribbonForm();
    if (!form) {
      return;
    }

    form.setModified(value);
  };

  /**
    @description Shows all places in a page where a new rendering can be inserted
  */
  this.showRenderingTargets = function() {
    Sitecore.PageModes.DesignManager.insertionStart();
  };
       
  /** @private */
  this._fixStyles = function() {
    if ($sc.browser.msie) {
      return;
    }

    // min-height and min-width are added to prevent browser form setting height and with of contenteditable elements to 0 when they have no content.        
    $sc.util().addStyleSheet("body .scWebEditInput { display: inline-block;}\r\n.scWebEditInput[contenteditable=\"true\"] { min-height: 1em;}");
  };
  /** @private */
  this._initCapabilities = function() {            
    var capabilities =  document.getElementById("scCapabilities");
    var enabledCapabilities = [];
    if (capabilities && capabilities.value) {
      enabledCapabilities = capabilities.value.split("|");
    }
    
    for (var n in Sitecore.PageModes.Capabilities) {        
      if ($sc.inArray(Sitecore.PageModes.Capabilities[n], enabledCapabilities) > -1) {
        this._capabilities.push(Sitecore.PageModes.Capabilities[n]);
      }
    }    
  };

   /** @private */  
  this.onDocumentClick = function(e) {        
    Sitecore.PageModes.ChromeManager.select(null);
  };
  /** @private */
  this.onDomLoaded = function() {
    if (!this.editing()) {
      return;
    }

    this._fixStyles();
    this._initCapabilities();
    Sitecore.PageModes.ChromeManager.init();
    var $doc = $sc(document);
    $doc.click($sc.proxy(this.onDocumentClick, this));
    $doc.keydown($sc.proxy(this.onKeyDown, this));
    $doc.keyup($sc.proxy(this.onKeyUp, this));
    if ($sc.browser.mozilla) {
       $doc.keypress($sc.proxy(this.onKeyPress, this));      
    }    

    $sc(".scWebEditInput[contenteditable='true']").live("mouseup", function(e) {
      if (e.target.tagName.toUpperCase() === "IMG") {
        fixImageParameters(e.target, Sitecore.WebEditSettings.mediaPrefixes.split("|"));
      }
      else {
        $sc.each($sc(e.target).find("img"), function(index, value) {
          fixImageParameters(value, Sitecore.WebEditSettings.mediaPrefixes.split("|"));
        })
      }
    });
  };
  /** @private */
  this.onKeyDown = function(e) {     
    //Escape    
    if (e.keyCode == 27) {
      Sitecore.PageModes.ChromeManager.hideSelection();
      return;      
    }

    //Ctrl+S
    if (e.keyCode == 83 && e.ctrlKey) {            
      e.preventDefault();            
      this.save();
      return;
    }

    if (e.keyCode == 17 && !this.ctrlPressed) {
      this.ctrlPressed = true;
      Sitecore.PageModes.ChromeManager.hoverFrame().deactivate();
      Sitecore.PageModes.ChromeManager.selectionFrame().deactivate();
      return;
    }
    
    // Workaround for browser's shortcuts, e.q. Ctrl + Shift + Del
    // In such cases keydown event is fired, but keyup is not, hence Ctrl got stuck.
    if (e.ctrlKey && e.keyCode != 17 && this.ctrlPressed) {      
      this.ctrlPressed = false;
      Sitecore.PageModes.ChromeManager.hoverFrame().activate();
      Sitecore.PageModes.ChromeManager.selectionFrame().activate();
      return;
    }    
  };
  /** @private */
  this.onKeyPress = function(e) {         
    // Preventing FF from showing standard "Save as" dialog when clicking <Ctrl>+<S>   
    if (e.ctrlKey && String.fromCharCode(e.which).toLowerCase() == "s") {          
      e.preventDefault();
    }
  };
  /** @private */
  this.onKeyUp = function(e) {
    if (e.keyCode == 17) {
      this.ctrlPressed = false;
      Sitecore.PageModes.ChromeManager.hoverFrame().activate();
      Sitecore.PageModes.ChromeManager.selectionFrame().activate();
    }
        
    if (e.keyCode == 27) {
      if (Sitecore.PageModes.DesignManager.sorting) {
        Sitecore.PageModes.DesignManager.sortingEnd();
      }

      if (Sitecore.PageModes.DesignManager.inserting) {
        Sitecore.PageModes.DesignManager.insertionEnd();
      }
    }    
  };
  /** @private */
  this.onPageLoaded = function() {
    if (Sitecore.WebEditSettings.disableAnimations) {
      $sc.fx.off = true;
    }

    var ribbon = this.ribbon();   
    if (!ribbon) {
      return;
    }        
    
    $sc(ribbon.contentWindow).resize($sc.proxy(this.onRibbonResize, this));
        
    if (this.editing()) {
      $sc(window).bind("scroll", $sc.proxy(this.onWindowScroll.fire, this.onWindowScroll));
      if (typeof(ribbon.contentWindow.scShowControls) != "undefined" && ribbon.contentWindow.scShowControls) {
        setTimeout($sc.proxy(Sitecore.PageModes.ChromeHighlightManager.activate, Sitecore.PageModes.ChromeHighlightManager), 100);      
      }
    }
       
    var $ribbonDoc = $sc(ribbon.contentWindow.document);
    $ribbonDoc.keyup($sc.proxy(this.onKeyUp, this));
    $ribbonDoc.keydown($sc.proxy(this.onKeyDown, this));      
    
    // Hide loading indicator
    $sc("#scPeLoadingIndicator").hide();
    this._isLoaded = true;
    this.onLoadComplete.fire();      
  };
  /** @private */
  this.onRibbonResize = function() {
    if (!this.editing()) {
      return;
    }

    if (this.notificationBar.visible()) {      
      this.notificationBar.resetPosition();
      this.showNotificationBar();
    }
    
    Sitecore.PageModes.ChromeManager.resetSelectionFrame();   
    Sitecore.PageModes.ChromeHighlightManager.planUpdate();
  };

  $sc(document).ready($sc.proxy(this.onDomLoaded, this));
  $sc(window).load($sc.proxy(this.onPageLoaded, this));      
};﻿if (typeof(Sitecore.PageModes) == "undefined") {
  Sitecore.PageModes = new Object();
}

Sitecore.PageModes.ChromeManager = new function() {
  this.overChromes = new Array();        
  this.ignoreDOMChanges = false;
  this.selectionChanged = new Sitecore.Event();
  this.chromeUpdating = new Sitecore.Event(); 
  this.chromeUpdated = new Sitecore.Event();
  this.chromesReseting = new Sitecore.Event();
  this.chromesReseted = new Sitecore.Event();
  this.positioningManager = new Sitecore.PageModes.PositioningManager();
  this._updateVariationsQueue = [];   
      
  this.init = function() {
    Sitecore.PageModes.PageEditor.onCapabilityChanged.observe($sc.proxy(this.onCapabilityChanged, this));
    $sc.each(this.chromes(), function(){ this.load(); });
    this._selectionFrame = new Sitecore.PageModes.SelectionFrame();
    this._hoverFrame = new Sitecore.PageModes.HoverFrame();
    this._moveControlFrame = new Sitecore.PageModes.MoveControlFrame();            
  };
     
  this.addFieldValue = function(fieldValueElement) {
    if (this.fieldValuesContainer == null) {
      this._createFieldValuesContainer();
    }
    
    var elem = null;
    if (!fieldValueElement.jquery) {
      elem = $sc(fieldValueElement);
    }
    else {
      elem = fieldValueElement;
    }
    
    this.fieldValuesContainer.append(elem); 
    elem.bind("setData", $sc.proxy(this.onFieldModified, this));
  };

  this.chromes = function() {
    if (!this._chromes) {
      var chromesToLoad = new Array();
      this._chromes = $sc(".scLooseFrameZone, .scWebEditInput, code[type='text/sitecore'][kind='open']")
                      .map($sc.proxy(function(idx, element) {
                        // preserve existing chromes in case of reset, only create chromes for new dom elements
                        var $domElement = $sc(element);

                        var chrome = this.getChrome($domElement);

                        if (!chrome || this.isElementButNotInitializedYet($domElement)) {
                          var type = this.getChromeType($domElement);
                          chrome = new Sitecore.PageModes.Chrome($domElement, type);

                          if (this._reseted) {
                            chromesToLoad.push(chrome);
                          }
                        }

                        return chrome;
                      }, this));

      this._reseted = false;
      $sc.each(chromesToLoad, function(){ this.load(); });
      this._chromes = $sc.grep(this._chromes, function(c) { return c != null; });
    }

    return this._chromes;
  };

  // Updates current chromes position in array according to DOM changes
  this.rearrangeChromes = function() {
    var l = this._chromes ? this._chromes.length : 0;
    this._chromes = $sc(".scLooseFrameZone, .scWebEditInput, code[type='text/sitecore'][kind='open']")
                      .map($sc.proxy(function(idx, element) {                       
                        var $domElement = $sc(element);
                        var chrome = this.getChrome($domElement);
                        if (chrome) {
                          return chrome;
                        }
                      }, this));

     if (l !== this._chromes.length) {
      console.error(l + " chromes expected." + this._chromes.length + " found");
     } 
  }

  // Not the most elegant of all methods.
  // If the domElement is an editFrame or field root node, but the this.getChrome doesn't return the corresponding chrome, this means that this
  // dom element hasn't been initialized as corrseponding chrome.
  // The reason this method is here, is because the same domElement might have been initialized as a part of placeholder or rendering, which would give it an scChromes 
  // collection.
  this.isElementButNotInitializedYet = function(domElement) {
    var chrome = this.getChrome(domElement);

    if (!chrome) {
      return false;
    }

    if (!domElement.is(".scLooseFrameZone, .scWebEditInput, code[type='text/sitecore'][chromeType='field']")) {        
      return false;
    }

    if (chrome.key() == "editframe" || chrome.key() == "field") {
      return false;
    }

    return true;
  };

  this.getChrome = function(domElement) {
    var chromes = domElement.data("scChromes");
    
    if (!chromes || chromes.length == 0) {
      return null;
    }

    return chromes[chromes.length - 1];
  };

  this.getChromesByType = function(chromeType) {
    return $sc.grep(this.chromes(), function(c) {
      return (c.type instanceof chromeType);
    });
  };

  this.getChromeType = function(domElement) {
    if (domElement.hasClass("scWebEditInput")) {
      if (domElement.hasClass("scWordContainer")) {
        return new Sitecore.PageModes.ChromeTypes.WordField();
      }

      return new Sitecore.PageModes.ChromeTypes.Field();
    }

    if (domElement.is("code[type='text/sitecore'][chromeType='field']")) {
      return new Sitecore.PageModes.ChromeTypes.WrapperlessField();
    }

    if (domElement.hasClass("scLooseFrameZone")) {
      return new Sitecore.PageModes.ChromeTypes.EditFrame();
    }

    if (domElement.is("code[type='text/sitecore'][chromeType='placeholder']")) {
      return new Sitecore.PageModes.ChromeTypes.Placeholder();
    }

    if (domElement.is("code[type='text/sitecore'][chromeType='rendering']")) {
      return new Sitecore.PageModes.ChromeTypes.Rendering();
    }

    console.error("Unknown chrome type:");
    console.log(domElement);

    throw ("Unknown chrome type");
  };

  this.handleMessage = function(msgName, params) {
    var msgHandler = null;
    if (this._commandSender) {
      msgHandler = this._commandSender;
    }
    else if (this.selectedChrome()) {
      msgHandler = this.selectedChrome();
    }

    if (params && params.controlId) {
      if (msgHandler == null || (msgHandler != null && msgHandler.controlId() != params.controlId)) {
        msgHandler = $sc.first(this.chromes(), function() { return this.controlId() == params.controlId; });
      }
    }
    
    if (msgHandler != null) {
      msgHandler.handleMessage(msgName, params);
    }
  };

  this.handleCommonCommands = function (sender, msgName, params) {
    if (msgName == "chrome:common:edititem") {      
      var reGuid = /(\{){0,1}[0-9A-F]{8}\-[0-9A-F]{4}\-[0-9A-F]{4}\-[0-9A-F]{4}\-[0-9A-F]{12}(\}){0,1}/i;
      var matches = reGuid.exec(sender.getContextItemUri());
      if (matches != null && matches.length > 0) {
        var itemid = matches[0];
        Sitecore.PageModes.PageEditor.postRequest(params.command + "(id=" + itemid + ")", null, false);
      }        
    }
    // throw message further in order corresponding chrome could handle it either/
    sender.handleMessage(msgName, params);
  }; 
          
  this.hideSelection = function() {
    if (this._selectedChrome) {
      this._selectedChrome.hideSelection();
      this._selectedChrome = null;
      this.selectionFrame().hide();
    }
  };

  this.hoverActive = function() {
    return !Sitecore.PageModes.DesignManager.sorting;
  };

  this.hoverFrame = function() {
    return this._hoverFrame;
  };

  this.moveControlFrame = function() {
    return this._moveControlFrame;
  };
          
  this.onMouseOver = function(chrome) {
    if (!Sitecore.PageModes.PageEditor.isLoaded()) {
      return;
    }

    if (!this.hoverActive()) {
      return;
    }

    this.overChromes.push(chrome);
    this.updateHoverChrome();
  };

  this.onMouseOut = function(chrome) {
    if (!Sitecore.PageModes.PageEditor.isLoaded()) {
      return;
    }

    var idx = $sc.inArray(chrome, this.overChromes); 
    if (idx > -1) {
      this.overChromes.splice(idx,1);
    }

    this.updateHoverChrome();
  };   
  /**
  * @deprecated since Sitecore 6.5. You should now use @see Sitecore.PageModes.PageEditor#postRequest.
  */  
  this.postRequest = function(request, callback, async) {
    Sitecore.PageModes.PageEditor.postRequest(request, callback, async);    
  };
  
  this.resetChromes = function() {   
    this.chromesReseting.fire();
    $sc.each(this.chromes(), function(){ this.reset();});

    this._chromes = null;
    this._reseted = true;

    // force init of new chromes to attach event handlers
    this.chromes();
    this.chromesReseted.fire();
    Sitecore.PageModes.ChromeHighlightManager.planUpdate();
  };

  this.resetSelectionFrame = function () {
    var selectionFrame = this.selectionFrame();
    if (!selectionFrame) {
      return;
    }

    var selectedChrome = this.selectedChrome();    
    if (selectedChrome) {
      this.hideSelection();
      this.select(selectedChrome);
    }
  };

  this.save = function(postaction) {
    Sitecore.PageModes.PageEditor.save(postaction);
  };
  
  this.select = function(chrome) {       
    if (!Sitecore.PageModes.PageEditor.isLoaded()) {
      return;
    }

    if (!chrome || !chrome.isEnabled()) {
      this.hideSelection();            
      this.selectionChanged.fire(null);
      return;
    }

    this.selectionChanged.fire(chrome);

    if (this._selectedChrome == chrome) {
      this.selectionFrame().show(chrome);
      return;
    }

    if (this._selectedChrome && this._selectedChrome != chrome) {
      this._selectedChrome.hideSelection();
    }

    this._selectedChrome = chrome;
    chrome.showSelection();
    this.selectionFrame().show(chrome);    
  };

  this.selectedChrome = function() {
    return this._selectedChrome;
  };

  this.selectionFrame = function() {
    return this._selectionFrame;
  };

  /**
  * @deprecated since Sitecore 6.5. You should now use @see Sitecore.PageModes.PageEditor#setModified.
  */
  this.setModified = function(value) {   
     Sitecore.PageModes.PageEditor.setModified(value);   
  };

  /**
  * @deprecated since Sitecore 6.5. You should now use @see Sitecore.PageModes.PageEditor#isModified.
  */
  this.isModified = function() {
    return Sitecore.PageModes.PageEditor.isModified();
  };

  this.setCommandSender = function(chrome) {
    this._commandSender = chrome;
  };
    
  this.onCapabilityChanged = function() {
    var selectedChrome =  this.selectedChrome();
    this.hideSelection();    
    this.resetChromes();
    $sc.each(this.chromes(), function() { this.reload();});
    if (selectedChrome && selectedChrome.isEnabled()) {
       this.select(selectedChrome);        
    }    
  };

  /**
  * @description Handles the event when Ajax request was sent to update chrome content (insert rendering, change condition etc.)
  */
  this.onChromeUpdating = function() {    
    this.chromeUpdating.fire(this._commandSender);
  };

  /**
  * @description Handles the event when Ajax request for chrome updating has finished;
  */
  this.onChromeUpdated = function(chrome, reason) {
    this.chromeUpdated.fire();
    var isBatchUpdate = false;
    if (chrome && chrome.key() == "rendering" && reason == "changevariation") {
      var id = chrome.type.uniqueId();
      var idx = $sc.findIndex(this._updateVariationsQueue, function() { return this.componentId == id; });
      if (idx >= 0) {
        this._updateVariationsQueue.splice(idx, 1); 
        isBatchUpdate = true; 
      }
      
      var next = this._updateVariationsQueue[0];
      if (!next) {
        if (isBatchUpdate) {
          if (this._selectChromeAfterBatchUpdate === false) {
            this.select(null);
          }
          else {
            this.scrollChromeIntoView(chrome);           
          }          
        }

        this.selectionFrame().activate();       
        return;
      }

      var component = $sc.first(this.chromes(), function() { 
        return this.key() === "rendering" && this.type.uniqueId() === next.componentId;
      });

      if (!component) {
        return;
      }
      
      Sitecore.PageModes.ChromeManager.select(component);     
      component.handleMessage("chrome:testing:variationchange", {id: next.variationId});      
    }
  };

  this.onFieldModified = function(evt, key, value) {    
    if (key == "modified") {      
      evt.stop();
      modifiedControlId = value;
      $sc.each(this.chromes(), function() { 
        if (this.key() == "field" && this.controlId() != modifiedControlId && this.type.isFieldValueContainer(evt.target)) {
          this.type.setReadOnly();
        } 
      });
    }
  };
  
  this.scrollChromeIntoView = function(chrome) {
     this.positioningManager.scrollIntoView(chrome);
  }; 

  this.updateHoverChrome = function() {
    var result = [], l = this.overChromes.length;

    for (var i = 0; i < l; i++) {
      var isUnique = true;

      if (this.overChromes[i].removed()) {
        continue;
      }

      for (var j = 0; j < result.length; j++) {
        if (result[j] == this.overChromes[i]) {
          isUnique = false;
          break;
        }
      }

      if (isUnique) {
        result.push(this.overChromes[i]);
      }
    }

    this.overChromes = result;
    
    var level = 0;
    var deepestChrome = null;

    $sc.each(this.overChromes, function() {
      if (this.level() > level) {
        level = this.level();
        deepestChrome = this;
      }
    });

    if (this._hoverChrome && this._hoverChrome != deepestChrome) {
      this._hoverChrome.hideHover();
    }

    if (deepestChrome) {
      this._hoverChrome = deepestChrome;
      deepestChrome.showHover();
    }
  };

  this.updateChromeDimensions = function() {    
    if (this._selectedChrome) {     
        this._selectedChrome.position.reset();      
    }
  };

  this.updateField = function(id, htmlValue, plainValue, preserveInnerContent) {
    var fieldToUpdate = $sc.first(this.chromes(), function() { return this.key() == "field" && this.controlId() == id;});
    if (fieldToUpdate) {
      var params = {
          plainValue: plainValue,
          value: htmlValue,
          preserveInnerContent: !!preserveInnerContent 
        };
              
      fieldToUpdate.handleMessage("chrome:field:editcontrolcompleted", params);
      if (!preserveInnerContent) {        
        fieldToUpdate.position.reset();
      }
    }
    else {
      console.error("The field with " + id + "was not found");
    }
  };

  this.batchChangeVariations = function(combination, selectChrome) {
    this._selectChromeAfterBatchUpdate = !!selectChrome
    for (var n in combination) {
      if (!combination.hasOwnProperty(n)) {
        continue;
      }

      var isQueueEmpty = this._updateVariationsQueue.length == 0;                      
      var componentId = n;
      var variationId = combination[n];
      this._updateVariationsQueue.push({componentId:componentId, variationId: variationId});
      if (isQueueEmpty) {
        var component = $sc.first(Sitecore.PageModes.ChromeManager.chromes(), function() { 
          return this.key() === "rendering" && this.type.uniqueId() === componentId;
        });

        if (component) {
          this.selectionFrame().deactivate();
          this.select(component);     
          component.handleMessage("chrome:testing:variationchange", {id: variationId}); 
        }
      }      
    }
  };

  this.getFieldValueContainer = function(itemUri, fieldID) {
    return this._getFieldValueContainer(itemUri, fieldID);
  };

  this.getFieldValueContainerById = function(id) {    
    if (!this.fieldValuesContainer) {
      return null;
    }

    var parts = id.split("_");
    // normalizaed id doesn't contain trailing _revision and _sequencer
    var normalizedId = parts.slice(0, 5).join("_");

    var result = $sc("input", this.fieldValuesContainer).filter(function() {
      return this.id.indexOf(normalizedId) == 0;
    });

    return result[0];    
  };

  this._createFieldValuesContainer = function() {    
    this.fieldValuesContainer = $sc("<div id='scFieldValues'></div>").prependTo(document.body);
  };
    
  this._getFieldValueContainer = function(itemUri, fieldID) {
    var id = "fld_" + itemUri.id + "_" + fieldID + "_" + itemUri.language + "_" + itemUri.version;
    return this.getFieldValueContainerById(id);
  };

  this.getFieldValue = function(itemUri, fieldID) {
    var container = this._getFieldValueContainer(itemUri, fieldID);

    if (!container) {
      return null;
    }

    return container.value;
  };

  this.setFieldValue = function(itemUri, fieldID, value) {    
    value = value.replace(/-,scDQuote,-/g, "\"");
    value = value.replace(/-,scSQuote,-/g, "'");

    var container = this._getFieldValueContainer(itemUri, fieldID, value);    
    if (!container) {
      var revision = itemUri.revision || "#!#Ignore revision#!#";

      var id = "fld_" + itemUri.id + "_" + fieldID + "_" + itemUri.language + "_" + itemUri.version + "_" + revision + "_999";
     
      container = $sc("<input type='hidden' />").attr({
          name: id,
          id: id,
          value: value
        }).get(0);

      if (!this.fieldValuesContainer) {
        this._createFieldValuesContainer();
      }

      this.fieldValuesContainer.append(container); 
      Sitecore.PageModes.PageEditor.setModified(true);
      if (this.selectedChrome() && this.selectedChrome().key() == "editframe") {
        this.selectedChrome().type.fieldsChangedDuringFrameUpdate = true;
      }
      
      return;     
    }

    if (container.value != value) {
      container.value = value;
      Sitecore.PageModes.PageEditor.setModified(true);
      if (this.selectedChrome() && this.selectedChrome().key() == "editframe") {
        this.selectedChrome().type.fieldsChangedDuringFrameUpdate = true;
      }

      $sc.each(this.chromes(), function() { 
        if (this.key() == "field" && this.type.isFieldValueContainer(container)) {
          this.type.refreshValue();
        }
      });
    }          
  };   
};﻿Sitecore.PageModes.DesignManager = new function() {      
  this.inserting = false;
  this.sorting = false;
  Sitecore.PageModes.ChromeManager.chromesReseting.observe($sc.proxy(function() { this._placeholders = null;}, this))

  this.insertionStart = function() {
    Sitecore.PageModes.ChromeManager.hideSelection();
    if (this.inserting) return;

    $sc.each(this.placeholders(), function() {
      this.type.onShow();
    });

    this.inserting = true;
  };

  this.insertionEnd = function() {
     $sc.each(this.placeholders(), function() {
      this.type.onHide();
    });

    this.inserting = false;
  };
  
  this.moveControlTo = function(rendering, placeholder, position) {
    var descendants = rendering.descendants();       
    
    if ($sc.exists(descendants, function() { return this.key() == "word field" && this.type.hasModifications();} )) {
      if (confirm(Sitecore.PageModes.Texts.ThereAreUnsavedChanges)) {
        placeholder.type.insertRenderingAt(rendering, position);        
        Sitecore.LayoutDefinition.moveToPosition(rendering.type.uniqueId(), placeholder.type.placeholderKey(), position);
      }   
    }
    else {
      placeholder.type.insertRenderingAt(rendering, position);        
      Sitecore.LayoutDefinition.moveToPosition(rendering.type.uniqueId(), placeholder.type.placeholderKey(), position);
    }
  };
      
  this.placeholders = function() {
    if (!this._placeholders) {
      this._placeholders = $sc.grep(Sitecore.PageModes.ChromeManager.chromes(), function(chrome) { return chrome.key() == "placeholder" && chrome.isEnabled(); });
    }
    
    return this._placeholders;
  };

  this.onSelectionChanged = function(chrome) {
    if (this.inserting) {
      this.insertionEnd();
    }
  };

  this.canMoveRendering = function(rendering) {    
    var originalPlaceholder, placeholderRenderings, placeholders, renderingId;
            
    if (!rendering) {
      return false;
    }

    originalPlaceholder = rendering.type.getPlaceholder();
    if (!originalPlaceholder) {
      return false;
    }

    // Original placeholder is not editable. Do not allow move rendering away from it
    if (!originalPlaceholder.isEnabled()) {
      return false;
    }

    placeholderRenderings = originalPlaceholder.type.renderings();
    // We can move rendering inside the same placeholder
    if (placeholderRenderings.length > 1) {
      return true;
    }

    placeholders = this.placeholders();
    renderingId = rendering.type.renderingId();
    for (var i = 0, l = placeholders.length; i < l; i++) {
      if (placeholders[i] == originalPlaceholder) {
        continue;
      }

      if (placeholders[i].type.renderingAllowed(renderingId)) {
        return true;
      }
    }

    return false;
  };
  
  this.sortingStart = function(rendering) {
    if (this.sorting) return;

    $sc.each(this.placeholders(), function() {
      this.type.sortingStart(rendering);
    });
    
    this.sorting = true;
    this.sortableRendering = rendering;
    
  };
  
  this.sortingEnd = function() {
    if (!this.sorting) {
      return;
    }
    
    this.sorting = false;
    
    this.sortableRendering.type.sortingEnd();
  
    $sc.each(this.placeholders(), function() {
      this.type.sortingEnd();
    });
  };

  Sitecore.PageModes.ChromeManager.selectionChanged.observe($sc.proxy(this.onSelectionChanged, this));
};﻿Sitecore.LayoutDefinition = new function() {
};

Sitecore.LayoutDefinition.insert = function(placeholderKey, id) {
  var layoutDefinition = this.getLayoutDefinition();
  var device = this.getDevice(layoutDefinition);

  var r = new Object();
  r["@id"] = id;
  r["@ph"] = placeholderKey;

  device.r.splice(0, 0, r);

  this.setLayoutDefinition(layoutDefinition);
};

Sitecore.LayoutDefinition.getRendering = function(uid) {
  var layoutDefinition = this.getLayoutDefinition();
  var device = this.getDevice(layoutDefinition);
  if (!device) {
    return null;
  }

  for (var n = 0; n < device.r.length; n++) {
    if (this.getShortID(device.r[n]["@uid"]) == uid) {
      return device.r[n];            
    }
  }
};

Sitecore.LayoutDefinition.remove = function(uid) {
  var layoutDefinition = this.getLayoutDefinition();
  var device = this.getDevice(layoutDefinition);

  this.removeRendering(device, uid);  
  this.setLayoutDefinition(layoutDefinition);
};

Sitecore.LayoutDefinition.removeRendering = function(device, uid) {
  for (n = 0; n < device.r.length; n++) {
    if (this.getShortID(device.r[n]["@uid"]) == uid) {
      r = device.r[n];
      device.r.splice(n, 1);
      return r;
    }
  }
  return null;
};

Sitecore.LayoutDefinition.moveToPosition = function(uid, placeholderKey, position) {
  var layoutDefinition = this.getLayoutDefinition();
  var device = this.getDevice(layoutDefinition);
  var originalPosition = this._getRenderingPositionInPlaceholder(device, placeholderKey, uid);
  var r = this.removeRendering(device, uid);
  if (r == null) {
    return;
  }
  
  r["@ph"] = placeholderKey;

  if (position == 0) {
     device.r.splice(0, 0, r);
     this.setLayoutDefinition(layoutDefinition);
     return;
  }
  // Rendering is moving down inside the same placeholder. Decrement the real position, because rendering itself is removed 
  // from his original position. 
  if (originalPosition > -1 && originalPosition < position) {
    position--;
  }

  var placeholderWiseCount = 0;
  for (var totalCount = 0; totalCount < device.r.length; totalCount++)
  {
    var rendering = device.r[totalCount];       
    if (Sitecore.PageModes.Utility.areEqualPlaceholders(rendering["@ph"], placeholderKey))
    {
      placeholderWiseCount++;
    }

    if (placeholderWiseCount == position)
    {
      device.r.splice(totalCount + 1, 0, r);
      break;
    }
  }
    
  this.setLayoutDefinition(layoutDefinition);
};

Sitecore.LayoutDefinition.getRenderingConditions = function(renderingUid) {
  if (!Sitecore.PageModes.Personalization) {
    return [];
  }

  var layoutDefinition = this.getLayoutDefinition();
  var device = this.getDevice(layoutDefinition);
  var conditions = [];
  for (var i = 0; i < device.r.length; i++) {
    if (this.getShortID(device.r[i]["@uid"]) == renderingUid && device.r[i].rls) {
      var rules = device.r[i].rls.ruleset;
      if (rules && rules.rule) {
        if(!$sc.isArray(rules.rule)) {
          rules.rule = [rules.rule];
        }

        for (var j = 0; j < rules.rule.length; j++) {
          var conditionId = rules.rule[j]["@uid"];
          var isActive = Sitecore.PageModes.Personalization.ConditionStateStorage.isConditionActive(renderingUid, conditionId);
          conditions.push(new Sitecore.PageModes.Personalization.Condition(
            conditionId,
            rules.rule[j]["@name"],
            isActive
          ));
        }
      }
    }
  }

  return conditions;
};

Sitecore.LayoutDefinition.GetConditionById = function(conditionId) {
  var layoutDefinition = this.getLayoutDefinition();
  var device = this.getDevice(layoutDefinition);  
  for (var i = 0; i < device.r.length; i++) {
     var rules = device.r[i].rls ? device.r[i].rls.ruleset: null;
     if (rules && rules.rule) {
        if(!$sc.isArray(rules.rule)) {
          rules.rule = [rules.rule];
        }

        for (var j = 0; j < rules.rule.length; j++) {
          if (rules.rule[j]["@uid"] == conditionId) {
            return {rule : rules.rule[j]};
          }
        }
     }
  }

  return {};
};

Sitecore.LayoutDefinition.getRenderingIndex = function(placeholderKey, index) {
  var layoutDefinition = this.getLayoutDefinition();
  var device = this.getDevice(layoutDefinition);

  var i = 0;

  for (n = 0; n < device.r.length; n++) {
    if (device.r[n]["@ph"] == placeholderKey) {
      if (i == index) {
        return n;
      }

      i++;
    }
  }

  return -1;
};

Sitecore.LayoutDefinition.getRenderingPositionInPlaceholder = function(placeholderKey, uid) {
  var layoutDefinition = this.getLayoutDefinition();
  var device = this.getDevice(layoutDefinition);
  return this._getRenderingPositionInPlaceholder(device, placeholderKey, uid);
};

Sitecore.LayoutDefinition.getLayoutDefinition = function() {
  return JSON.parse($sc("#scLayout").val());
};

Sitecore.LayoutDefinition.setLayoutDefinition = function(layoutDefinition) {
  var newValue = $sc.type(layoutDefinition) === "string" ? layoutDefinition : JSON.stringify(layoutDefinition);
  if ($sc("#scLayout").val() != newValue) {
    $sc("#scLayout").val(newValue);
    Sitecore.PageModes.PageEditor.setModified(true);
  }
};

Sitecore.LayoutDefinition.getDeviceID = function() {
  return $sc("#scDeviceID").val();
};

Sitecore.LayoutDefinition.getDevice = function(layoutDefinition) {
  var deviceID = this.getDeviceID();

  if (!layoutDefinition.r.d) {
    return null;
  }

  //By serialization behaivour. If there is single element- it would not be serialized as array
  if (!layoutDefinition.r.d.length) {
    layoutDefinition.r.d = [layoutDefinition.r.d];
  }

  var list = layoutDefinition.r.d;

  for (var n = 0; n < list.length; n++) {
    var d = list[n];

    var id = this.getShortID(d["@id"]);

    if (id == deviceID) {
      //By serialization behaivour. If there is single element- it would not be serialized as array
      if (d.r && !d.r.length) {
        d.r = [d.r];
      }
      return d;
    }
  }

  return null;
};

Sitecore.LayoutDefinition.getShortID = function(id) {
  return id.substr(1, 8) + id.substr(10, 4) + id.substr(15, 4) + id.substr(20, 4) + id.substr(25, 12);
};

Sitecore.LayoutDefinition.readLayoutFromRibbon = function() {
  var layout = Sitecore.PageModes.PageEditor.ribbon().contentWindow.$("scLayoutDefinition").value;    
  if (layout && layout.length > 0) {
    this.setLayoutDefinition(layout);
    return true;
  }

  return false;
};

Sitecore.LayoutDefinition._getRenderingPositionInPlaceholder = function(device, placeholderKey, uid) {
  var counter = 0;
  for (var i = 0; i < device.r.length; i++) {
    if (Sitecore.PageModes.Utility.areEqualPlaceholders(device.r[i]["@ph"],placeholderKey)) {
      if (this.getShortID(device.r[i]["@uid"]) == uid) {
        return counter;
      }

      counter++;
    }
  }

  return -1;
};

﻿if (typeof(Sitecore.PageModes) == "undefined") {
  Sitecore.PageModes = new Object();
}

Sitecore.PageModes.Chrome = Base.extend({
  constructor: function(domElement, type) {
    this._originalDOMElement = domElement;
    
    this.type = type;
    type.chrome = this;
    this._parseElements();    
    this._level = -1;
    var dataNode = this.type.dataNode(domElement);
    this.setData(dataNode);
    // force init display name. Chrome data may change(i.e. when changing variations or conditions), but the name 
    // of the chrome should be the same during all the lifetime.
    this.displayName();
    this.position = new Sitecore.PageModes.Position(this);
    this._clickHandler = $sc.proxy(this._clickHandler, this);
    this._mouseEnterHandler = $sc.proxy(this._mouseEnterHandler, this);
    this._mouseLeaveHandler = $sc.proxy(this._mouseLeaveHandler, this);

    $sc.util().log("initialized new chrome: " + this.type.key());
  },

  /* DOM manipulation */

  after: function(chromeOrElements) {
    var elements = $sc.util().elements(chromeOrElements);

    this.closingMarker().after(elements);
  },

  append: function(chromeOrElements) {
    var elements = $sc.util().elements(chromeOrElements);

    this.closingMarker().before(elements);
  },

  before: function(chromeOrElements) {
    var elements = $sc.util().elements(chromeOrElements);

    this.openingMarker().before(elements);
  },

  empty: function() {
    this.element.remove();
  },

  prepend: function(chromeOrElements) {
    var elements = $sc.util().elements(chromeOrElements);

    this.openingMarker().after(elements);
  },

  update: function(elements) {
    if (!(elements instanceof $sc)) {
      throw "Unexpected elements";
    }

    this.empty();
    this.append(elements);
    this.element = elements;
  },

  /* End DOM manipulation */

  ancestors: function() {
    var result = new Array();

    var parent = this.parent();

    while (parent) {
      result.push(parent);
      parent = parent.parent();
    }

    return result;
  },

  attachEvents: function() {
    this.element.click(this._clickHandler);
    this.element.mouseenter(this._mouseEnterHandler);
    this.element.mouseleave(this._mouseLeaveHandler);
  },

  detachEvents: function() {
    this.element.unbind("click", this._clickHandler);
    this.element.unbind("mouseenter", this._mouseEnterHandler);
    this.element.unbind("mouseleave", this._mouseLeaveHandler);
  },

  detachElements: function() {
    this.element.data("scChromes", null);
  },

  // Returns currently enabled child chromes.  
  descendants: function() {          
     var deep = true;
     return this.getChildChromes(function() { return this && this.isEnabled();}, deep);                    
  },

  // Returns currently enabled child chromes, immediate descentants of the current chrome.
  // The returning value is cached.
  children: function() {
    if (!this._children) {      
      this._children = this.getChildChromes(function() { return this && this.isEnabled();});            
    }

    return this._children;
  },
  
  closingMarker: function() {
    return this._closingMarker;
  },

  commands: function() {
    return this.data.commands ? this.data.commands : new Array();
  },

  controlId: function() {
    return this.type.controlId();
  },

  displayName: function() {
    if (this._displayName != null) {
      return this._displayName;
    }

    this._displayName = this.data.displayName ? this.data.displayName : Sitecore.PageModes.Texts.NotSet;
    return this._displayName;
  },

  elementsAndMarkers: function() {
    return this.openingMarker().add(this.element).add(this.closingMarker());
  },

  expand: function() {
    var excludeFakeParents = true;
    var parent = this.parent(excludeFakeParents);
    if (parent) {
      Sitecore.PageModes.ChromeManager.select(parent);
    }
    else {
      console.error("no parent - nowhere to expand");
    }
  },
    
  // Returns child chromes, immediate descentants of the current chrome, which match the specified predicate.
  // If deep = true, all descendant chromes are returned, otherwise only immediate children are returned.
  getChildChromes: function(predicate, deep) {    
    if (typeof(predicate) == "undefined" || !predicate) {
      predicate = function() { return this; };
    }
   
    var result = [];

    /* first checking all DOMElements that are a part of this chrome to see if they have other chromes associated with them */
    for (var i = 0; i < this.element.length; i++) {
      var part = $sc(this.element[i]);

      var chromes = part.data("scChromes");
      if (!chromes || chromes.length == 0) {
        continue;
      }
      
      if (chromes.length < 2) {
        continue;
      }

      var index = $sc.inArray(this, chromes);
      if (index < 0) {
        throw "The chrome must be present in scChrome collections of its DOM elements";
      }

      /* if the chrome is last in collection, it means it doesn't have any children bound to same DOM elements */
      if (index == chromes.length - 1) {
        continue;
      }

      for (var j = index + 1; j < chromes.length; j++) {
        var childChrome = chromes[j];
        
        if (!predicate.call(childChrome, childChrome)) {
          continue;
        }
        
        if ($sc.inArray(childChrome, result) >= 0) {
          continue;
        }
        
        result.push(childChrome);        
      }
    }
    
    /* then we traverse the DOM tree to get child (or descendant) chromes */
    var selector = ".scLooseFrameZone, .scWebEditInput, code[type='text/sitecore'][kind='open']";
    
    var elements = this.element.find(selector);
    var l = elements.length;     
     
    for (var i = 0; i < l; i++) {
      var currentElem = $sc(elements[i]);
      var chrome = Sitecore.PageModes.ChromeManager.getChrome(currentElem);
        
      if (!deep) {
        /* if dom node's parent chrome is not this chrome, it means there is a chrome in between, so we disregard it a descendant, but not a child. */
        if (chrome.parent(false, false) != this) {
          continue;
        }
      }  
      
      if (!chrome || !predicate.call(chrome, chrome)) {
        continue;
      }

      result.push(chrome);
    }
   
    return result;
  },

  handleMessage: function(message, params, sender) {   
    this.type.handleMessage(message, params, sender);
  },

  icon: function() {
    return this.type.icon();
  },

  isEnabled: function() {
    return this.type.isEnabled();
  },

  isReadOnly: function() {
    return this.type.isReadOnly();
  },

  setReadOnly: function() {
    this.type.setReadOnly();
  },
  
  isFake: function() {
    if (this.key() == "field") {
      var childField = $sc.first(this.children(), function() { return this.key() == "field"; });
      return !!childField;
    }

    return false;
  },

  key: function() {
    return this.type.key();
  },

  level: function() {
    if (this._level <= 0) {           
      this._level = this.ancestors().length + 1;
    }

    return this._level;
  },

  load: function() {
    this.attachEvents();       
    if (this.type.load) {
      this.type.load();
    }

    var parent = this.parent(false, false);
    if (parent != null && parent.isReadOnly()) {
      this.setReadOnly();
    }

    this._fixCursor();
  },

  openingMarker: function() {
    return this._openingMarker;
  },

  setData: function(dataNode) {
    if (dataNode && $sc.trim(dataNode.text()) !== "") {
      this.hasDataNode = true;     
      var json = dataNode.get(0).innerHTML;      
      this.data = $sc.evalJSON(json);
    }
    else {
      this.hasDataNode = false;
      this.data = {};
      this.data.custom = {};      
    }
  },

  showHover: function() {
    if (!this._selected) {
      Sitecore.PageModes.ChromeManager.hoverFrame().show(this);
    }
  },
 
  hideHover: function() {
    Sitecore.PageModes.ChromeManager.hoverFrame().hide();
  },
  
  //excludeFake determines if we should consider fake parents (if field chrome A has nested field chrome B, then A is fake parent)
  //enabledOnly - defines if only enabled chromes may be retuned as a parent
  parent: function(excludeFake, enabledOnly) {
    var includeDisabled = false;
    if (typeof(enabledOnly) != "undefined") {
      includeDisabled = !enabledOnly;
    }

    var chrome = null;

    // checks if more then one chrome is associated with a given dom node. if so, return next chrome in stack.
    var chromes = this.element.data("scChromes");

    if (typeof(chromes) == "undefined") {
      if (this.element.length > 0) {
        console.warn("Chrome elements do not have scChrome collection assigned");
        console.log(this.element);
      }

      chromes = new Array();
    }

    if (chromes.length > 1) {
      var index = $sc.inArray(this, chromes);
      if (index < 0) {
        throw new "A chrome must be found in the elements chrome collection";
      }

      if (index > 0) {
        if (includeDisabled) {
          return chromes[index - 1];
        }

        var ancestor = $sc.last(chromes.slice(0 , index), function() { return this.isEnabled(); });
        if (ancestor) {
          return ancestor;
        } 
      }
    }

    // traverses DOM tree to find parent chromes
    var node = this.element.parent();
    var partOf = "";

    while (node.length > 0) {
      partOf = node.attr("sc-part-of");
        
      if (typeof(partOf) != "undefined" && partOf.length > 0) {
        chrome = Sitecore.PageModes.ChromeManager.getChrome(node);
        if (!chrome) {
          console.error("Any [sc-part-of] node is expected to have its scChromes collection");
          console.log(node.data("scChromes"));
          return null;
        }

        if (partOf == "field") {
          if (includeDisabled || chrome.isEnabled()) {
            if (excludeFake) {
              if (!chrome.isFake()) return chrome;
            }
            else return chrome;
          }

        }
        else {
          if (includeDisabled || chrome.isEnabled()) return chrome;
          return chrome.parent(excludeFake, enabledOnly);
        }
      }

      node = node.parent();
    }

    return null;
  },

  showHighlight: function() {
    if (this._selected) return;

    if (!this._highlight) {      
      this._highlight = new Sitecore.PageModes.HighlightFrame();
    }
       
    this._highlight.show(this);    
  },

  hideHighlight: function() {
    if (this._highlight) {      
      this._highlight.hide();
    }
  },
  
  showSelection: function() {
    this._selected = true;
    this.hideHover();
    this.hideHighlight();
        
    if (this.type.onShow) {
      this.type.onShow();
    }
  },

  hideSelection: function() {
    this._selected = false;
    if (Sitecore.PageModes.ChromeHighlightManager.isHighlightActive(this)) {
      this.showHighlight();
    }
        
    if (this.type.onHide) {
      this.type.onHide();
    }
  },

  getContextItemUri: function() {
    return this.type.getContextItemUri();
  },

  previous: function() {
    if (!this.parent()) {
      return;
    }

    var children = this.parent().children();

    var index = $sc.inArray(this, children);
    if (index == 0) {
      return;
    }

    return children[index - 1];
  },

  next: function() {
    if (!this.parent()) {
      return;
    }

    var children = this.parent().children();

    var index = $sc.inArray(this, children);
    if (children.length <= index + 1) {
      return;
    }

    return children[index + 1];
  },

  reload: function() {
    this._fixCursor();

    if (this.type.reload) {
      this.type.reload();
    }
  },
  
  reset: function() {
    this._children = null;
    
    this.detachEvents();

    this._parseElements();
    
    this.attachEvents();
    
    this.position.reset();
  },

  remove: function() {
    this.onDelete();
    this.openingMarker().remove();
    this.element.remove();
    this.closingMarker().remove();
    this._removed = true;    
  },

  removed: function() {
    return this._removed ? true : false;
  },
    
  onDelete: function(preserveData) {
    if (this._highlight) {
      this._highlight.dispose();
    }
        
    this.type.onDelete(preserveData);
  },
  
  _fixCursor: function() {
    var l = this.element.length, 
        i = 0,
        isEnabled = this.isEnabled();
    
    for (i; i < l; i++) {
      var element = $sc(this.element[i]);
      var chrome = Sitecore.PageModes.ChromeManager.getChrome(element);
      if (chrome != this) {
        continue;
      }

      if (isEnabled) {
        element.addClass("scEnabledChrome");
      }
      else {
        element.removeClass("scEnabledChrome");
      }
    }  
  },

  /* event handlers */
  _clickHandler: function(e) {
    if (!this.isEnabled()) {
      return;
    }

    if (e.ctrlKey) return;               
    e.stopPropagation();
        
    if (Sitecore.PageModes.ChromeManager.selectedChrome() != this || this.key() == "field" ) {          
      e.preventDefault();         
    }

    var target = $sc(e.target);
    target = target.closest("[sc-part-of]");

    if (!target.attr("sc-part-of")) {
      console.warn("this element wasn't supposed to get the click event");
      console.log(e.target);
      return;
    }

    var chromes = $sc(target).data("scChromes");
    if (!chromes || chromes.length < 1) {
      console.log(target);
      throw "DOM element is expected to have a non-empty chromes collection.";
    }

    var enabledChrome = $sc.last(chromes, function() { return this.isEnabled(); });
    Sitecore.PageModes.ChromeManager.select(enabledChrome? enabledChrome : this);
  },

  _mouseEnterHandler: function(e) { 
    if (!this.isEnabled()) {
      return;
    }

    Sitecore.PageModes.ChromeManager.onMouseOver(this);
  },

  _mouseLeaveHandler: function() {
    if (!this.isEnabled()) {
      return;
    }

    Sitecore.PageModes.ChromeManager.onMouseOut(this);
  },
  
  /* establishes connection between DOM elements and chrome objects. */
  _markElements: function() {
    var chrome = this;

    if (this.openingMarker() && !this.openingMarker().data("scChromes")) {
      var chromes = new Array();
      chromes.push(this);
      this.openingMarker().data("scChromes", chromes);
    }

    this.element.each(function(index, raw) {
      var element = $sc(raw);

      if (!element.is("[sc-part-of*=" + chrome.type.key() + "]")) {
        var attr = element.attr("sc-part-of");
        if (typeof(attr) == "undefined") {
          attr = "";
        }

        if (attr.length > 0) {
            attr += " ";
        }
      
        attr += chrome.type.key();
        element.attr("sc-part-of", attr);
      }

      var chromes = element.data("scChromes");
      if (!chromes) {
        chromes = new Array();
      }

      if ($sc.inArray(chrome, chromes) < 0) {
        chromes.push(chrome);
      }

      element.data("scChromes", chromes);     
    });
  },

  _parseElements: function() {
    /* if this is an orphan chrome that is being deleted, not do anything */
    if (!this._originalDOMElement || this._originalDOMElement.parent().length == 0) {
      return;
    }

    var elements = this.type.elements(this._originalDOMElement);
    
    this.element = elements.content;
    this._openingMarker = elements.opening;
    this._closingMarker = elements.closing;

    this._markElements();
  }
});﻿Sitecore.PageModes.ChromeControls = Base.extend({
  constructor: function () {
    var cssClass = Sitecore.PageModes.PageEditor.languageCssClass() + (Sitecore.PageModes.Utility.isIE ? " ie" : "");
    this.toolbar = $sc("<div class='scChromeToolbar " + cssClass + "'></div>"); 
   
    // we need this element to calculate real dimensions of toolbar. Since
    // the toolbar will change the position (top and left) on the page 
    // it's dimensions may be calculated incorrectly when it is docked to the page's border. 
    this.dummy = this.toolbar.clone().attr("id", "scDummyToolbar");
    this.dummy.prependTo(document.body);
    
    this.commands = $sc("<div class='scChromeControls'></div>");
    this._overlay = $sc("<div class='scControlsOverlay'></div>")
                    .click(function(e) {e.stop();})
                    .hide()
                    .appendTo(this.toolbar);

    this.commands.hide().click($sc.proxy(function(e) {
        this.hideMoreCommands();
        this.hideAncestors();
        this.triggerEvent("click");
        e.stop();        
      }, this));
                                      
    this.toolbar.append(this.commands);
    this.toolbar.appendTo(document.body);

    this.ancestorList = $sc("<div class='scChromeDropDown " + cssClass + "'></div>");
    this.ancestorList.hide().prependTo(document.body);

    this.moreCommands = $sc("<div class='scChromeDropDown " + cssClass + "'></div>");
    this.moreCommands.hide().prependTo(document.body);            
    
    this.positioningManager = new Sitecore.PageModes.PositioningManager();    
    Sitecore.PageModes.PageEditor.onWindowScroll.observe($sc.proxy(this.scrollHandler, this));
    Sitecore.PageModes.ChromeManager.chromeUpdating.observe($sc.proxy(function() {
        $sc(".scToolbarIndicator", this.commands)
          .delay(Sitecore.PageModes.ChromeOverlay.animationStartDelay)
          .fadeTo(0, 1);
        this.showOverlay();
    }, this));

    Sitecore.PageModes.ChromeManager.chromeUpdated.observe($sc.proxy(function() {
        $sc(".scToolbarIndicator", this.commands).stop(true).fadeTo(0, 0)       
        this.hideOverlay();        
    }, this));
        
    this.eventDispatcher = $sc({});   
  },
      
  activate: function() {
    this.toolbar.removeClass("scInvisible");
  },

  deactivate: function() {
    this.toolbar.addClass("scInvisible");
  },

  getCommandRenderer: function(click, chrome) {
    try {
      var command = Sitecore.PageModes.Utility.parseCommandClick(click);
      if (command && command.message) {
        var key = chrome.key() + ":" + command.message;
        var renderer = Sitecore.PageModes.ChromeControls.commandRenderers[key];
        if (renderer) {
          return renderer;
        }

        return Sitecore.PageModes.ChromeControls.commandRenderers[command.message];
      }
    }
    catch(e) {
      return null;
    }
  },
    
  hide: function() {
    this.chrome = null;
    this.dimensions = null;
    this.commands.hide();
    this.hideMoreCommands();
    this.hideAncestors();
    this.triggerEvent("hide");
    this.hideOverlay();
  },

  hideAncestors: function() {
    if (this.ancestorList.is(":visible")) {
      this.ancestorList.hide();
      this.commands.find(".scChromeComboButton").removeClass("scDdExpanded");      
    }     
  },

  hideMoreCommands: function() {
    if (this.moreCommands.is(":visible")) {
      this.moreCommands.hide();
      this.commands.find(".scChromeMoreSection").removeClass("scDdExpanded");      
    }  
  },

  observe: function(eventName, handler) {
    this.eventDispatcher.bind(Sitecore.PageModes.ChromeControls.eventNameSpace + eventName, handler);
  },

  stopObserving: function(eventName, handler) {
    this.eventDispatcher.unbind(Sitecore.PageModes.ChromeControls.eventNameSpace + eventName, handler);
  },

  triggerEvent: function(eventName) {
    this.eventDispatcher.trigger(Sitecore.PageModes.ChromeControls.eventNameSpace + eventName);
  },
  
  showAncestors: function() {
    if (!this.ancestorList.is(":visible")) {
      this.ancestorList.show();
      this.commands.find(".scChromeComboButton").addClass("scDdExpanded");      
    }
  },

  showMoreCommands: function() {
    if (!this.moreCommands.is(":visible")) {
      this.moreCommands.show();
      this.commands.find(".scChromeMoreSection").addClass("scDdExpanded");      
    }  
  },

  renderAncestors: function() {  
    this.ancestorList.update("");
    var ancestors = this.chrome.ancestors();
    for(var i = ancestors.length - 1; i >= 0; i--) {
      if(!ancestors[i].isFake()) {
        var level = ancestors.length - i - 1;
        this.ancestorList.append(this.renderAncestor(ancestors[i], level));
      }
    }

    return this.ancestorList;
  },

  renderAncestor: function(ancestor, level) {    
    var paddingValue = 16;
    var row = $sc("<a class='scChromeDropDownRow' href='#'></a>");
    if (level > 0) {          
      var levelConnection = $sc("<img src='/sitecore/shell/themes/standard/images/pageeditor/corner.gif' class='scLevelConnection' />");
      levelConnection.css("padding-left", (level - 1) * paddingValue + "px");      
      row.append(levelConnection);
    }   
       
    $sc("<img class='scChromeAncestorIcon' />").attr("src", ancestor.icon()).appendTo(row);                
    $sc("<span></span>").text(ancestor.displayName()).appendTo(row);
              
    row.mouseenter(function() {
      ancestor.showHover("ancestor menu mouseenter");
    });

    row.mouseleave(function() {
      ancestor.hideHover("ancestor menu mouseleave");
    });

    row.click($sc.proxy(function(e) {
      e.stop();      
      this.hideAncestors();
      Sitecore.PageModes.ChromeManager.select(ancestor);
    }, this));
    
    return row;
  },

  /*
  command:
    -- click
    -- header
    -- tooltip
    -- icon
  */
  renderCommand: function(command, chrome, isMoreCommand /*Defines if commnad appears in More dropDown*/ ) {           
    var renderer = this.getCommandRenderer(command.click, chrome.type);
    if (renderer) {
      var result = renderer.call(chrome.type, command, isMoreCommand, this);
      if (result) {
        return result;
      }

      if (result === null) {
        return null;
      }
    }

    return this.renderCommandTag(command, chrome, isMoreCommand);
  },

  renderCommandTag: function(command, chrome, isMoreCommand /*Defines if commnad appears in 'More' dropDown*/) {
    var tag = $sc("<a href='#' ></a>").attr("title", command.tooltip);
    tag.addClass(isMoreCommand ? "scChromeDropDownRow" : "scChromeCommand");
    var isDisabled = (chrome.isReadOnly() || command.disabled) && !command.alwaysEnabled;
    if (!command.click) {
      isDisabled = true;
    }
    var icon = !isDisabled ? command.icon : command.disabledIcon;
    $sc("<img />").attr({ src: icon, alt: command.tooltip }).appendTo(tag);    
    if (isMoreCommand) {
      $sc("<span></span>").text(command.header ? command.header : command.tooltip).appendTo(tag);      
    }

    if (isDisabled) {
      tag.addClass("scDisabledCommand");      
      return tag;
    }

    if (command.click.indexOf("chrome:") == 0) {
      var click = Sitecore.PageModes.Utility.parseCommandClick(command.click);
      if (command.type == "common") {
        tag.click(function(e) {       
          Sitecore.PageModes.ChromeManager.setCommandSender(chrome);
          Sitecore.PageModes.ChromeManager.handleCommonCommands(chrome, click.message, click.params);
        });
      }
      else {
        tag.click(function(e) {       
          Sitecore.PageModes.ChromeManager.setCommandSender(chrome);
          chrome.handleMessage(click.message, click.params);
        });
      }
    }
    else if (command.click.indexOf("javascript:") == 0) {      
      if ($sc.util().isNoStandardsIE()) {
        tag.get(0).onclick = new Function(command.click.replace("javascript:",""));
      }
      else {
        tag.get(0).setAttribute("onclick", command.click);
      }

      tag.mouseup(function(e) {        
        Sitecore.PageModes.ChromeManager.setCommandSender(chrome);        
      });
    }
    else {
      tag.click( function(e) {       
        Sitecore.PageModes.ChromeManager.setCommandSender(chrome);
        eval(command.click);        
      });
    }
    
    return tag;
  },

  renderExpandCommand: function() {
    var excludeFakeParents = true;

    var parent = this.chrome.parent(excludeFakeParents);

    if (!parent) {
      return;
    }

    var container = $sc("<span class='scChromeComboButton' ></span>");

    var tag = $sc("<a href='#' class='scChromeCommand'></a>").attr("title", Sitecore.PageModes.Texts.SelectParentElement.replace("{0}", parent.displayName()) );    
    tag.mouseenter(function() {
      parent.showHover("ancestor menu mouseenter");
    });

    tag.mouseleave(function() {
      parent.hideHover("ancestor menu mouseleave");
    });

    tag.click($sc.proxy(function(e) {
      e.stop();
      this.chrome.expand();
    }, this));

    var icon = $sc("<img />").attr({ src: "/sitecore/shell/~/icon/ApplicationsV2/16x16/nav_up_left_blue.png.aspx", alt: parent.displayName() });    
    tag.append(icon);

    container.append(tag);
    container.append(this.renderExpandDropdown());

    return container;
  },

  renderExpandDropdown: function() {
    var tag = $sc("<a class='scChromeCommand scExpandDropdown' href='#' ></a>").attr("title", Sitecore.PageModes.Texts.ShowAncestors);

    tag.click($sc.proxy(function(e) {
      e.stop();

      var sender = $sc(e.currentTarget);            
      var offset = sender.offset();
      var height = sender.outerHeight(); 
      this.showAncestorList({top: offset.top + height, left: offset.left});
    }, this));

    $sc("<img src='/sitecore/shell/Themes/Standard/Images/menudropdown_black9x8.png' />")
      .attr("alt", Sitecore.PageModes.Texts.ShowAncestors )
      .appendTo(tag);
   
    return tag;
  },

  renderMoreSection: function() {
    var template = [
      "<a href='#' class='scChromeCommand scChromeMoreSection' title='${texts.ShowMoreCommands}'>",
      "  <span class='scChromeCommandText'>${texts.More}</span>",
      "  <img src='/sitecore/shell/Themes/Standard/Images/menudropdown_black9x8.png' alt='${texts.ShowMoreCommands}' />",
      "</a>"
    ].join("\n");

    var tag = $sc.util().renderTemplate("sc-renderMoreSection", template, {
      texts: Sitecore.PageModes.Texts
    });

    tag.click($sc.proxy(function(e) {
      e.stop();
      var sender = $sc(e.currentTarget);
                  
      var offset = sender.offset();
      var height = sender.outerHeight();     
      this.showMoreCommandsList({top: offset.top + height, left:offset.left});
    }, this));
    
    return tag;
  },
   
  renderTitle: function() {
    var container = $sc("<div class='scChromeName'></div>");

    var tooltip = this.chrome.data.expandedDisplayName || this.chrome.displayName();

    var displayName = this.chrome.displayName();
    
    var isReadOnly = this.chrome.isReadOnly();
           
    var title = $sc("<span class='scChromeText'></span>")     
      .text($sc.truncate(displayName, this._maxDisplayNameLength))
      .appendTo(container);

    if (isReadOnly) {
      $sc("<span class='scReadonlyText'></span>").text("["+ Sitecore.PageModes.Texts.ReadOnly +"]").appendTo(container);
    }
    else {
      title.attr("title", tooltip);
    }

    $sc("<img class='scToolbarIndicator' src='/sitecore/shell/Themes/Standard/Images/PageEditor/toolbar_progress.gif' />")
      .css({opacity : 0.0})
      .appendTo(container);
            
    return container;
  },

  renderSeparator: function() {
    return $sc("<span class='scChromeCommandSectionDelimiter'>|</span>");
  },

  updateCommands: function() {
    this.hideOverlay();
    this.commands.show();    
    this.commands.update("");
    
    this.hideMoreCommands();
    this.moreCommands.update("");    

    /* first row - icon and name */   
    this.commands.append(this.renderTitle());

    /* second row - commands */
    var commandsRow = $sc("<div id='commandRow'></div>").appendTo(this.commands);
    var parent = this.chrome.parent();

    var hasCommands = false;
    var commandsCounter = 0;
    
    var commonCommands = [], commands = [], stickyCommands = [];     
    $sc.each(this.chrome.commands(), function () { 
      if (this.type == "common") {
        commonCommands.push(this);
        return;
      }

      if (this.type == "sticky") {
        stickyCommands.push(this);
        return;
      }
        
      commands.push(this);        
    });

    var insertionIdx = this._maxToolbarCommands - stickyCommands.length;
    var nonSeparatorsCount = 0;
    var ii = 0;
    for (ii; ii < commands.length; ii++) {
      if (commands[ii].type === "separator") {
        continue;
      }
      
      if (++nonSeparatorsCount >  insertionIdx) {        
        break;
      }
    }

    var args = [ii, 0].concat(stickyCommands);
    Array.prototype.splice.apply(commands, args);
               
    if (parent != null && parent.key() == "field") {
      var parentCommandsAdded = false;
      var commandClicks = $sc.map(commands, function() { return this.click; });

      $sc.each(parent.commands(), $sc.proxy(function(idx, command) {
        if (command.type != "common" && $sc.inArray(command.click, commandClicks) < 0) {          
          var res = this._addCommand(command, parent, commandsCounter);
          commandsCounter = commandsCounter + res;
          hasCommands = hasCommands || res;
          parentCommandsAdded = true;
        }
      }, this));

      if (parentCommandsAdded 
            && commands.length > 0 
            && commandsCounter < this._maxToolbarCommands /*at least one command will be added to toolbar*/ 
            && this._isSeparatorAcceptible()) {
        commandsRow.append(this.renderSeparator());
      }
    }
   
    $sc.each(commands, $sc.proxy(function(idx, command) {
      if (command.hidden) {
        return;
      }
     
      var res = this._addCommand(command, this.chrome, commandsCounter);
      commandsCounter = commandsCounter +  res;
      hasCommands = hasCommands || res;
    }, this));
        
    /* The "expand" section */
    var expandCommand = this.renderExpandCommand();
    if (expandCommand) {
      if (hasCommands && this._isSeparatorAcceptible()) {
        commandsRow.append(this.renderSeparator());
      }

      commandsRow.append(expandCommand);      
      hasCommands = true; 
    }
    
    /*The "more" section */
    $sc.each(commonCommands, $sc.proxy(function (i, c) {
      var idx = this._maxToolbarCommands;/*The command should appear in "More" dropdown */
      this._addCommand(c, this.chrome, idx); 
    }, this));

    if (this._hasMoreCommands()) {
      if (hasCommands && this._isSeparatorAcceptible()) {
        commandsRow.append(this.renderSeparator());
      }

      commandsRow.append(this.renderMoreSection());
    }

    if (commandsRow.children().length > 0) {
      commandsRow.append($sc("<div class='scClearBoth'></div>"));      
    }   
  },

  scrollHandler: function() {
    if (!this.commands.is(":visible") || this.chrome == null) return;
    this.triggerEvent("scroll");
    this.hideMoreCommands();
    this.hideAncestors();          
    var fixedPosition =  this.positioningManager.getFixedChromeRelativeElementPosition(this.dimensions == null ? this.toolbar.getDimensions() : this.dimensions, this.chrome);
    this.toolbar.css({ left: fixedPosition.left + 'px', top: fixedPosition.top + 'px' });    
  },

  show: function(chrome, duration) {
    if (this.chrome != chrome) {
      this.chrome = chrome;
      this.updateCommands();      
      this.dummy.update(this.toolbar.get(0).innerHTML);
      this.dimensions = {height : this.dummy.outerHeight(), width: this.dummy.outerWidth()};      
    }
        
    this.hideAncestors();
                
    var toolbarDimensions = this.dimensions == null ? 
                              {height: this.toolbar.outerHeight(), width: this.toolbar.outerWidth()} : null;
    var fixedPosition;
    if (duration) {          
      fixedPosition = this.positioningManager.getFixedChromeRelativeElementPosition(this.dimensions == null ? toolbarDimensions : this.dimensions, chrome);            
      this.toolbar.stop(true).animate({ left: fixedPosition.left + "px", top: fixedPosition.top + "px"}, duration);
    }
    else {
      this.commands.show();
      fixedPosition = this.positioningManager.getFixedChromeRelativeElementPosition(this.dimensions == null ? toolbarDimensions : this.dimensions, chrome);                        
      this.toolbar.css({ left: fixedPosition.left + "px", top: fixedPosition.top + "px" });      
    }

    this.triggerEvent("show");
  },

  showAncestorList: function(position) {
    if (this.ancestorList.is(":visible")) return;
    this.triggerEvent("dropdownshown");
    this.renderAncestors();
    this.showAncestors();   
    this.hideMoreCommands();
                  
    var fixedPosition = this.positioningManager.getFixedElementPosition(position.top, position.left, this.ancestorList);    
    this.ancestorList.css({ top: fixedPosition.top + 'px', left: fixedPosition.left + 'px' });     
  },

  showMoreCommandsList: function(position) {                  
    this.showMoreCommands();           
    this.triggerEvent("dropdownshown");
    var fixedPosition = this.positioningManager.getFixedElementPosition(position.top, position.left, this.moreCommands);    
    this.moreCommands.css({ top: fixedPosition.top + 'px', left: fixedPosition.left + 'px' });       
    this.hideAncestors();
  },
 
  _addCommand: function(command, chrome, index) {
    var isMoreCommand;

    if (command.type == "separator") {
      if (index < this._maxToolbarCommands && this._isSeparatorAcceptible()) {
        $sc("#commandRow", this.commands).append(this.renderSeparator());
      }

      return false;      
    }

    if (index >= this._maxToolbarCommands ) {
      isMoreCommand = true;
      var c = this.renderCommand(command, chrome, isMoreCommand);
      if (c) {
        this.moreCommands.append(c);
        return true;
      }
    }
    else {
      isMoreCommand = false;
      var c = this.renderCommand(command, chrome, isMoreCommand);
      if (c) {
        $sc("#commandRow", this.commands).append(c);
        return true;
      }      
    }

    return false;
  },

  _isSeparatorAcceptible: function() {    
    var commandsRow = $sc("#commandRow", this.commands);
    return commandsRow.length > 0
            && commandsRow.children().length > 0 
            && commandsRow.children(".scChromeCommandSectionDelimiter:last-child").length == 0; 
  },

  _maxToolbarCommands: 7,

  _maxDisplayNameLength: 40,

  _hasMoreCommands: function() {
    return this.moreCommands.children().length > 0;
  },

  hideOverlay: function() {
    this._overlay.hide();
  },

  showOverlay: function(dimensions) {
    var dims = dimensions;
    if (!dims) {
      dims = {};
      dims.height = this.commands.innerHeight();
      dims.width = this.commands.innerWidth();
    }
    
    this._overlay.css({width: dims.width + "px", height: dims.height + "px"});
    this._overlay.show();    
  }
},
{
  commandRenderers: {},
  eventNameSpace: "chromecontrols.",
  registerCommandRenderer: function(commandName, renderer, chromeType) {
    var key = chromeType != null ? chromeType.key() + ":" + commandName : commandName;
    Sitecore.PageModes.ChromeControls.commandRenderers[key] = renderer;
  }
});﻿// Hack described here http://www.telerik.com/community/forums/sharepoint-2007/full-featured-editor/paragraph-style-names-don-t-match-config.aspx
function OnClientSelectionChange(editor, args) {
  var tool = editor.getToolByName("FormatBlock");
  if (tool) {
    setTimeout(function () {
      var defaultBlockSets = [
        ["p", "Normal"],
        ["h1", "Heading 1"],
        ["h2", "Heading 2"],
        ["h3", "Heading 3"],
        ["h4", "Heading 4"],
        ["h5", "Heading 5"],
        ["menu", "Menu list"],
        ["pre", "Formatted"],
        ["address", "Address"]];

      var value = tool.get_value();

      var block = Prototype.Browser.IE
        ? defaultBlockSets.find(function (element) { return element[1] == value; })
        : [value];

      if (block) {
        var tag = block[0];
        var correctBlock = editor._paragraphs.find(function (element) { return element[0].indexOf(tag) > -1; });
        if (correctBlock) {
          tool.set_value(correctBlock[1]);
        }
      }
    }, 0);
  }
}

function OnClientModeChange(editor) {
    var url = window.location.protocol + '//' + window.location.hostname;
    var html = editor.get_html();
    var originalHtml = html;

    var lastIndexOf = window.location.pathname.lastIndexOf("/");
    var path = "";
    if (lastIndexOf !== -1) {
        path = window.location.pathname.substring(0, lastIndexOf);
    }

    if (path.indexOf("/") !== 0) {
        path = "/" + path;
    }

    var regexpWithPath = new RegExp(url + path, "gi");
    var regexpWithUrl = new RegExp(url, "gi");

    html = html.replace(regexpWithPath, "");
    html = html.replace(regexpWithUrl, "");

    if (html !== originalHtml) {
        editor.set_html(html);
        editor.saveClientState();
    }
}

function OnClientCommandExecuted(sender, args) {
  if (args.get_commandName() == "SetImageProperties") {
    replaceClearImgeDimensionsFunction();
  }
}

function replaceClearImgeDimensionsFunction(count) {
  if (!count) count = 0;
  setTimeout(function () {
      try {
          var selector = 'iframe[src^="Telerik.Web.UI.DialogHandler.aspx?DialogName=ImageProperties"]';
          $$(selector)[0].contentWindow.Telerik.Web.UI.Widgets.ImageProperties.prototype._clearImgeDimensions = function (image) {
              fixImageParameters(image, prefixes.split('|'));
          };
      } catch (e) {
          if (count < 10) {
              count++;
              replaceClearImgeDimensionsFunction(count);
          }
      }
  }, 500);
}

function fixImageParameters(image, mediaPrefixes) {

    var isMediaLink = false;

    for (var i = 0; i < mediaPrefixes.length; i++) {
        if (mediaPrefixes[i] === undefined || mediaPrefixes[i] === "") {
            continue;
        };

      var imageHost = decodeURI(window.location.protocol + "//" + window.location.hostname);

      if (new RegExp("^" + imageHost + "(.)*/" + decodeURI(mediaPrefixes[i]) + "*", "i").test(decodeURI(image.src))) {
          isMediaLink = true;
          break;
      };
    };

    if (!isMediaLink) { return; };

    _toQueryParams = function(href) {
        var result = {};

        var search = href.split("?")[1];

        if (search !== undefined) {
            var params = search.split("&");
            $sc.each(params, function(index, value) {
                var param = value.split("=");
                result[param[0]] = param[1];
            });
        };

        return result;
    };

    // This code corrects inconsistencies between image sizes set in style attribute, width and height attributes, w and h image parameters.
    var src = image.getAttribute("src");

    var params = _toQueryParams(src);

    var n = src.indexOf("?");
    if (n >= 0) {
        src = src.substr(0, n + 1);
    } else {
        src = src + "?";
    }

    for (var param in params) {
        if (params[param] === undefined || params[param] === "") {
            delete params[param];
        }
    }

    // if style
    if (image.style.height !== undefined && image.style.height !== "") {
        var height = image.style.height.replace("px", "");
        image.removeAttribute("height");
        params["h"] = height;
    }
    // else if attribute
    else if (image.attributes !== undefined && image.attributes["height"] !== undefined && image.attributes["height"] !== "") {
        image.style.height = image.attributes["height"].value + "px";
        params["h"] = image.attributes["height"].value;
    }
    // no style, no attribute
    else {
        delete params["h"];
    }

    // if style
    if (image.style.width !== undefined && image.style.width !== "") {
        var width = image.style.width.replace("px", "");
        image.removeAttribute("width");
        params["w"] = width;
    }
    // else if attribute
    else if (image.attributes !== undefined && image.attributes["width"] !== undefined && image.attributes["width"] !== "") {
        image.style.width = image.attributes["width"].value + "px";
        params["w"] = image.attributes["width"].value;
    }
    // no style, no attribute
    else {
        delete params["w"];
    }

    if ($sc.param(params) === "" && src.endsWith("?")) {
        src = src.substr(0, src.length - 1);
    } else {
        src = src + $sc.param(params);
    }

    image.setAttribute("src", src);
}

// Fix mentioned here http://www.telerik.com/community/forums/aspnet-ajax/editor/html-entity-characters-are-not-escaped-on-hyperlink-editor-email-subject.aspx
function OnClientPasteHtml(sender, args) {
  var commandName = args.get_commandName();
  var value = args.get_value();
  if (Prototype.Browser.IE && (commandName == "LinkManager" || commandName == "SetLinkProperties")) {
    if (/<a[^>]*href=['|"]mailto:.*subject=/i.test(value)) {
      var hrefMarker = 'href=';

      // quote could be ' or " depending on subject content
      var quote = value.charAt(value.indexOf(hrefMarker) + hrefMarker.length);
      var regex = new RegExp(hrefMarker + quote + 'mailto:.*subject=.*' + quote, 'i');
      var fixedValue = value.replace(regex, function (str) { return str.replace(/</g, "&lt;").replace(/>/g, "&gt;"); });
      args.set_value(fixedValue);
    }
} else if (commandName == "Paste") {
    // The StripPathsFilter() method receives as a parameter an array of strings (devided by a white space) that will be stripped from the absolute links.
    var relativeUrl = getRelativeUrl(); //returns the relative url.
    var domainUrl = window.location.protocol + '//' + window.location.host;
    if (relativeUrl) {
      var filter = new Telerik.Web.UI.Editor.StripPathsFilter([relativeUrl, domainUrl]); //strip the domain name from the absolute path

      var contentElement = document.createElement("SPAN");
      contentElement.innerHTML = value;
      var newElement = filter.getHtmlContent(contentElement);
      value = newElement.innerHTML;
      if (scForm.browser.isFirefox) {
        value = value.replace(/%7e\//ig, '~/');
      }

      args.set_value(value);  //set the modified pasted content in the editor
  }
  }

  if (Prototype.Browser.IE) {
    var helperIframe = $$("iframe[title^='Paste helper']:first")[0];
    if (helperIframe) {
        Element.setStyle(helperIframe, { width: 0, height: 0 });
    }
  }
}

function getRelativeUrl() {
  var result = window.location.href;
  if (result) {
    var query = window.location.search;
    if (query) {
      result = result.substring(0, result.length - query.length);
    }

    var slashPosition = result.lastIndexOf('/');
    if (slashPosition > -1) {
      result = result.substring(0, slashPosition + 1);
    }
  }

  return result;
}

function fixIeObjectTagBug() {
  var objects = Element.select($('Editor_contentIframe').contentWindow.document, 'object');
  var i;
  for (i = 0; i < objects.length; i++) {
    if (!objects[i].id || objects[i].id.indexOf('IE_NEEDS_AN_ID_') > -1) {
      objects[i].id = 'IE_NEEDS_AN_ID_' + i;
    }
  }
}﻿Sitecore.PageModes.Position = Base.extend({
  constructor: function(chrome) {
    this.chrome = chrome;
    this.element = chrome.type.layoutRoot();    
    this.onResizeHandler = $sc.proxy(this.onResize, this);
    this.element.bind(this._getResizeEventName(), this.onResizeHandler);        
    this.updated = new Sitecore.Event();
  },
  
  dimensions: function() {
    /*cache only for IE. FF and Chrome are fast enough*/
    var shouldCache = Sitecore.PageModes.Utility.isIE
    if (!shouldCache || !this._dimensions) {           
      Sitecore.PageModes.ChromeManager.ignoreDOMChanges = true;
      this._dimensions = this._calculateDimensions(this.element);
      this._dimensions = this._fixInlineContainerHeight(this._dimensions);
      Sitecore.PageModes.ChromeManager.ignoreDOMChanges = false;     
    }

    return this._dimensions;
  },
  
  offset: function() {
    var minLeft, minTop;
    minLeft = minTop = 100000;

    if (!this._ignoreOffsetTags) {
      this._ignoreOffsetTags = ["br", "hr", "script", "style", "link", "noframes" ];
    }

    var ignoreTags = this._ignoreOffsetTags;

    this.element.each(function(index, part) {
      var offset = $sc(part).offset();

      if ($sc.inArray(part.tagName.toLowerCase(), ignoreTags) >= 0) {
        return;
      }

      if (Sitecore.PageModes.PageEditor.isFixedRibbon() && offset.top == 0) {
        return;
      }

      if ($sc(part).is("input[type='hidden'], .scChromeData")) {
        return;
      }

      if (offset.left < minLeft) minLeft = offset.left;
      if (offset.top < minTop) minTop = offset.top;
    });

    if (minLeft == 100000) {
      minLeft = minTop = 0;
    }

    return { left: minLeft, top: minTop };
  },
  
  onResize: function(e) {           
    if ($sc.util().isIE) {    
      this.reset();
      Sitecore.PageModes.ChromeHighlightManager.planUpdate();
    } 
    else {
      e.stop();
      if (Sitecore.PageModes.ChromeManager.ignoreDOMChanges) return;
      var selectedChrome = Sitecore.PageModes.ChromeManager.selectedChrome();
      if (selectedChrome && selectedChrome == this.chrome) {        
        this.reset();
        Sitecore.PageModes.ChromeHighlightManager.planUpdate();
      }
    }    
  },
  
  reset: function() {
    this._dimensions = null;
    var newRoot = this.chrome.type.layoutRoot();    
    if (this.element) {
      this.element.unbind(this._getResizeEventName());
    }

    this.element = newRoot;      
    this.element.bind(this._getResizeEventName(), this.onResizeHandler);      
    this.updated.fire();
  },

  _calculateDimensions: function(element) {
    var maxRight, maxBottom;
    maxRight = maxBottom = 0;

    var offset = this.offset();

    this.element.each(function(index, partRaw) {
      var part = $sc(partRaw);
      var partOffset = $sc(part).offset();

      var right = partOffset.left + part.outerWidth();
      var bottom = partOffset.top + part.outerHeight();

      if (right > maxRight) maxRight = right;
      if (bottom > maxBottom) maxBottom = bottom;
    });

    return { width: maxRight - offset.left, height: maxBottom  - offset.top };
  },

  _fixInlineContainerHeight: function(dimensions) {
    if (dimensions.height == 0 && this.element.css("display") == "inline") {
      var max = 0;
      this.element.children().each(function() { 
        var h = $sc(this).outerHeight();
        if (h < max) {
          max = h;
        } 
      });

      dimensions.height = max;
    }
    
    return dimensions;
  },

  _getResizeEventName: function() {
    var eventName;
    if (this._resizeEventName) {
      return this._resizeEventName;
    }

    var nameSpace;
    if (this.chrome.key() == "field") {
      nameSpace = "field";
    }
    else {
      nameSpace = this.chrome.controlId();
    }

    if ($sc.util().isIE) {
      eventName = "resize";
      //In IE9 or later, the resize event for element layout changes is deprecated.
      //Registration for the event using addEventListener only works on the window (which fires for window resizes). Resize of element layout cannot be detected using addEventListener registration. 
      // Using special event instead.
      if (parseInt($sc.browser.version) > 8) {
        eventName = "elementresize";
      }
    }
    else {
      eventName = "DOMSubtreeModified"; 
    }
    
    if (nameSpace) {
      eventName += "." + nameSpace;
    }
    
    this._resizeEventName = eventName;
    return eventName;
  }
});﻿Sitecore.PageModes.ChromeFrame = Base.extend({
  constructor: function() {
    this.sides = new Array();
  },
  
  addSidesToDom: function() {       
    $sc.each(this.sides, function() {
      $sc(this).css("display", "none").appendTo(document.body);      
    });
  },

  applyCssClass:function(className) {
    $sc.each(this.sides, function() {
      this.addClass(className);
    });
  },

  removeCssClass:function(className) {
    $sc.each(this.sides, function() {
      this.removeClass(className);
    });
  },

  activate: function() {
    this.removeCssClass("scInvisible");
  },

  deactivate: function() {
    this.applyCssClass("scInvisible");
  },

  horizontalSideClassName: function() {
    return "";
  },

  verticalSideClassName: function() {
    return "";
  },

  createSides: function() {
    this.addSidesToDom();
  },

  hide: function() {
    if (this.sides) {
      var length = this.sides.length;
      for (var i = 0; i < length; i++) {
        this.sides[i].hide();
    }
    }
  },

  show: function(chrome) {
    if (chrome == null) return;

    if (this.sides == null || this.sides.length == 0) {
      this.createSides();
    }
            
    this.showSides(chrome);
  },
  
  showSides: function() {
     var length = this.sides.length;
     for (var i = 0; i < length; i++) {
       this.sides[i].show();
     }
  },

  setSideStyle: function (side, top, left, length) {
    side.css({top: top + "px", left: left + "px" });
    if (typeof(length) == "undefined") return;
    
    if (side.hasClass(this.horizontalSideClassName())) {
      side.css({ width: length < 0 ? "0" : length  + "px" });
      return;
    }

    if (side.hasClass(this.verticalSideClassName())) {
      side.css({ height: length < 0 ? "0" : length + "px"});
      return;
    }

    console.error("Unknown side type");
  } 
});﻿Sitecore.PageModes.SelectionFrame = Sitecore.PageModes.ChromeFrame.extend({
 constructor: function() {
    this.base();
    this.createSides();                
    this.controls = new Sitecore.PageModes.ChromeControls();    
    this._chromeResizeHandler = $sc.proxy(this.onChromeResize, this);
  },

  activate: function() {
    this.controls.activate();
    this.base();
  },

  deactivate: function() {
    this.controls.deactivate();
    this.base();
  },

  horizontalSideClassName: function() {
    return "scFrameSideHorizontal";
  },

  verticalSideClassName: function() {
    return "scFrameSideVertical";
  },
   
  calculateSideLengths: function(dimensions) {
    var horizontal = dimensions.width;
    var vertical = dimensions.height;
    
    return { horizontal: horizontal, vertical: vertical};    
  },

  createSides: function() {
    this.top = $sc("<div></div>").addClass(this.horizontalSideClassName());            
    this.right = $sc("<div></div>").addClass(this.verticalSideClassName());  
    this.bottom = $sc("<div></div>").addClass(this.horizontalSideClassName());
    this.left = $sc("<div></div>").addClass(this.verticalSideClassName());
           
    sides = new Array();
    this.sides = sides;
    
    sides.push(this.top);
    sides.push(this.right);
    sides.push(this.left);
    sides.push(this.bottom);
    
    this.base();  
  },
  
  hide: function() {
    this.base();
    this.controls.hide();
    
    this.visible = false;
    
    this.chrome.position.updated.stopObserving(this._chromeResizeHandler);
  },
  
  onChromeResize: function() {        
    this.show(this.chrome);
  },
  
  show: function(chrome) {
    if (this.chrome) {
      this.chrome.position.updated.stopObserving(this._chromeResizeHandler);
    }

    this.chrome = chrome;    
    this.base(chrome);
  },

  showSides: function(chrome) {              
    var offset = chrome.position.offset();
    var dimensions = chrome.position.dimensions();
       
    var sideLengths = this.calculateSideLengths(dimensions);       
    var duration = 200;    
    if (this.visible) {
      var previousOffset = this.top.offset();
      var distance = Math.sqrt(Math.pow(offset.left - previousOffset.left, 2) + Math.pow(offset.top - previousOffset.top, 2));
      
      duration = distance / 1.5;
      if (duration < 200) duration = 200;
      if (duration > 1000) duration = 1000;
    }
        
    this.controls.show(chrome, this.visible ? duration : false);

    var horizontalTopY = offset.top;
    var horizontalX =  offset.left;
    var horizontalBottomY = offset.top + sideLengths.vertical - 1;

    var verticalLeftX = offset.left;
    var verticalY = offset.top;
    var verticalRightX =  offset.left + sideLengths.horizontal - 1;

    //make selection frame wider for content editable elements in order to make caret visible in the first and last position
    if (chrome.type.key() == "field" && chrome.type.contentEditable()) {
      // Decrease left border coordinates to make cursor visible when it is placed in the first position 
      verticalLeftX--;
      // increase right border coordinates to avoid the lagging right border overlap the text when typing.
      // This also resolves the problem with the first space inserted at the last position doesn't increase the border width(sc:332300)
      var rightShift = chrome.type.fontSize ? chrome.type.fontSize : 1;
      verticalRightX += rightShift;
      
      sideLengths.horizontal += rightShift;
    }
     
    if (!this.visible) {
      this.setSideStyle(this.top, horizontalTopY, horizontalX, sideLengths.horizontal);                 
      this.setSideStyle(this.right, verticalY, verticalRightX, sideLengths.vertical);      
      this.setSideStyle(this.left, verticalY, verticalLeftX , sideLengths.vertical);      
      this.setSideStyle(this.bottom, horizontalBottomY , horizontalX, sideLengths.horizontal);
                  
      this.visible = true;
      this.base(dimensions, offset);
    }
    else {
      this.top.stop(true).animate({ width: sideLengths.horizontal + "px", top: horizontalTopY + "px", left: horizontalX + "px"}, duration);            
      this.right.stop(true).animate({ height: sideLengths.vertical + "px", top: verticalY + "px", left: verticalRightX + "px"}, duration);      
      this.left.stop(true).animate({ height: sideLengths.vertical + "px", top: verticalY + "px", left: verticalLeftX + "px"}, duration);      
      this.bottom.stop(true).animate({ width: sideLengths.horizontal + "px", top: horizontalBottomY + "px", left: horizontalX + "px"}, duration);      
    }
    
    chrome.position.updated.observe(this._chromeResizeHandler);       
  }
});﻿Sitecore.PageModes.HoverFrame = Sitecore.PageModes.ChromeFrame.extend({
  constructor: function() {
    this.base();
    this.cornerSize = {height: 4, width: 4};
    this.createSides();   
  },

  createSides: function() {
    this.top = $sc("<div></div>").addClass(this.horizontalSideClassName());
    this.topLeftCorner = $sc("<div></div>").addClass(this.verticalSideClassName() + " scTlHoverFrameCorner");

    this.topRightCorner = $sc("<div></div>").addClass(this.horizontalSideClassName() + " scTrHoverFrameCorner");
    this.right = $sc("<div></div>").addClass(this.verticalSideClassName());

    this.bottom = $sc("<div></div>").addClass(this.horizontalSideClassName());
    this.bottomLeftCorner = $sc("<div></div>").addClass(this.verticalSideClassName() + " scBlHoverFrameCorner");

    this.bottomRightCorner = $sc("<div></div>").addClass(this.horizontalSideClassName() + " scBrHoverFrameCorner");
    this.left = $sc("<div></div>").addClass(this.verticalSideClassName());
    
    sides = new Array();
    this.sides = sides;
    
    sides.push(this.top);
    sides.push(this.topLeftCorner);
    sides.push(this.topRightCorner);
    sides.push(this.right);
    sides.push(this.bottom);
    sides.push(this.bottomLeftCorner);
    sides.push(this.bottomRightCorner);
    sides.push(this.left);

    this.base();
  },
  
  horizontalSideClassName: function() {
    return "scHoverFrameSideHorizontal";
  },

  verticalSideClassName: function() {
    return "scHoverFrameSideVertical";
  },
  
  calculateSideLengths: function(dimensions) {
    var horizontal = dimensions.width - 2 * this.cornerSize.width;
    var vertical = dimensions.height - 2 * this.cornerSize.height;
    
    return { horizontal: horizontal > 0 ? horizontal : 0, vertical: vertical > 0 ? vertical : 0};    
  },
      
  showSides: function(chrome) {            
    var offset = chrome.position.offset();
    var dimensions = chrome.position.dimensions();
    
    var sideLengths = this.calculateSideLengths(dimensions);

    var leftCornerX = offset.left;    
    var horizontalX = leftCornerX + this.cornerSize.width;    
    var verticalLeftX = leftCornerX;
    var verticalRightX = offset.left + dimensions.width - 1;
    var rightCornerX = verticalRightX - this.cornerSize.width + 1;

    var topY = offset.top;
    var bottomY = offset.top + dimensions.height - 1;
    var verticalY = topY + this.cornerSize.height;
    var bottomCornerY = offset.top + dimensions.height - this.cornerSize.height;

    this.setSideStyle(this.top, topY, horizontalX, sideLengths.horizontal);
    this.setSideStyle(this.topLeftCorner, topY , leftCornerX);
    
    this.setSideStyle(this.topRightCorner, topY, rightCornerX);
    this.setSideStyle(this.right, verticalY, verticalRightX, sideLengths.vertical);

    this.setSideStyle(this.bottom, bottomY, horizontalX, sideLengths.horizontal);
    this.setSideStyle(this.bottomLeftCorner, bottomCornerY, leftCornerX);
    
    this.setSideStyle(this.bottomRightCorner, bottomCornerY, rightCornerX);
    this.setSideStyle(this.left, verticalY, verticalLeftX, sideLengths.vertical);
      
    this.base(chrome);
  }
});﻿Sitecore.PageModes.HighlightFrame = Sitecore.PageModes.HoverFrame.extend({      
  horizontalSideClassName: function() {
    return this.base() + " scHilghlightedChrome";
  },

  verticalSideClassName: function() {
    return this.base() + " scHilghlightedChrome";
  },
   
  dispose: function() {
    if (this.sides) {
      $sc.each(this.sides, function() {
        this.remove();
      });
    }

    this.sides = null;
  }  
});﻿Sitecore.PageModes.ChromeTypes.Placeholder = Sitecore.PageModes.ChromeTypes.ChromeType.extend( {
  constructor: function() {
    this.base();
  },

  controlId: function() {
    var marker = this.chrome.openingMarker();
    if (marker) {
      return marker.attr("id");
    }

    return this.base();
  },

  selectable: function() {
    if (this._selectable != null) {
      return this._selectable;
    }

    var marker = this.chrome.openingMarker();
    this._selectable = marker != null && marker.attr("data-selectable") === "true";
    return this._selectable;
  },

  addControl: function(position) {
    this._insertPosition = position;

    var ribbon = Sitecore.PageModes.PageEditor.ribbon();

    ribbon.contentWindow.$("scLayoutDefinition").value = $sc("#scLayout").val();        
    Sitecore.PageModes.PageEditor.postRequest("webedit:addrendering(placeholder=" + this.placeholderKey() + ")");
  },
  
  addControlResponse: function(id, openProperties, ds) {                       
    var options = Sitecore.PageModes.ChromeTypes.Placeholder.getDefaultAjaxOptions("insert");
    options.context = this;    
    options.data.rendering = id;
    options.data.placeholderKey = this.placeholderKey();
    options.data.position = this._insertPosition;
    options.data.url = window.location.href;                
    
    if (ds) {
      options.data.datasource = ds;
    }

    options.success = function(serverData) {
      var data = Sitecore.PageModes.Utility.parsePalleteResponse(serverData);       
      var persistedLayout;
      if (data.layout) {
        var layoutCtrl = $sc("#scLayout");
        persistedLayout = layoutCtrl.val();
        layoutCtrl.val(data.layout);          
      }

      // sublayout
      if (data.url != null) {
        this._loadRenderingFromUrl(data.url, function(callbackData) {
          if (callbackData.error == null) {                            
            data.html = $sc(callbackData.renderingElement.combined).outerHtml();
            Sitecore.PageModes.ChromeManager.select(null);
            this.insertRendering(data, openProperties);
          }
          else {
            if (persistedLayout) {
              $sc("#scLayout").val(persistedLayout);
            }

            alert(callbackData.error);
          } 
        });                   
      }
      // plain rendering, not a sublayout
      else {
        Sitecore.PageModes.Utility.tryAddStyleSheets(data.styleSheets);
        Sitecore.PageModes.Utility.tryAddScripts(data.scripts);          
        Sitecore.PageModes.ChromeManager.select(null);
        this.insertRendering(data, openProperties);
      }      
    };
      
    $sc.ajax(options);                  
  },
  
  deleteControl: function(chrome) {
    Sitecore.LayoutDefinition.remove(chrome.type.uniqueId());    
    
    Sitecore.PageModes.ChromeManager.select(null);
    Sitecore.PageModes.ChromeHighlightManager.stop();         
    
    var l = chrome.element.length;   
    chrome.element.fadeOut(200, $sc.proxy(function() {      
        if (--l > 0) return;
        this._removeRendering(chrome);                      
        if (this.isEmpty()) {
          this.showEmptyLook();
        }

        Sitecore.PageModes.ChromeHighlightManager.resume();         
      }, this));
  },
  
  editProperties: function(chrome) {
    var ribbon = Sitecore.PageModes.PageEditor.ribbon();

    if (ribbon == null) {
      return;
    }
    
    ribbon.contentWindow.$("scLayoutDefinition").value = $sc("#scLayout").val();
        
    Sitecore.PageModes.PageEditor.postRequest("webedit:editrenderingproperties(uniqueid=" + chrome.type.uniqueId() + ")");
  },
  
  editPropertiesResponse: function(renderingChrome) {
    if (!Sitecore.LayoutDefinition.readLayoutFromRibbon()) {
      return;
    }
    
    var commandName = "preview";        
    var options = Sitecore.PageModes.ChromeTypes.Placeholder.getDefaultAjaxOptions(commandName);
    options.data.renderingUniqueId = renderingChrome.type.uniqueId();       
    options.data.url = window.location.href;
    this._addAnalyticsOptions(renderingChrome, options);
    if (options.data.variationId) {
      options.data.command += "variation";
    }
    else if (options.data.conditionId) {
      options.data.command += "condition";
    }
            
    options.context = this;                    
    options.success = function(serverData) {               
      var data = Sitecore.PageModes.Utility.parsePalleteResponse(serverData);
      
      Sitecore.PageModes.ChromeHighlightManager.stop();                 
            
      if (data.url != null) {          
        this._loadRenderingFromUrl(data.url, function(callbackData) {
          if (callbackData.error == null) {
            Sitecore.PageModes.ChromeManager.select(null);            
            this._doUpdateRenderingProperties(renderingChrome, callbackData.renderingElement.combined.outerHtml());                        
          }
          else {
            console.log(callbackData.error);
          }
        }); 
      }
      else {
        Sitecore.PageModes.ChromeManager.select(null);
        Sitecore.PageModes.Utility.tryAddStyleSheets(data.styleSheets);
        Sitecore.PageModes.Utility.tryAddScripts(data.scripts);                  
        this._doUpdateRenderingProperties(renderingChrome, data.html);                
      }                     
    };
     
    $sc.ajax(options);
  },

  editSettings: function() {
    var ribbon = Sitecore.PageModes.PageEditor.ribbon();
    if (ribbon == null) {
      return;
    }
        
    ribbon.contentWindow.$("scLayoutDefinition").value = $sc("#scLayout").val();  
    Sitecore.PageModes.PageEditor.postRequest("webedit:editplaceholdersettings(key=" + this.placeholderKey() + ")");    
  },

  editSettingsCompleted: function(isEditable, allowedRenderingIds) {
    Sitecore.LayoutDefinition.readLayoutFromRibbon();
    if (this.chrome.hasDataNode) {
      this.chrome.data.custom.editable = isEditable ? "true": "false";
      this.chrome.data.custom.allowedRenderings = allowedRenderingIds;      
    }

    Sitecore.PageModes.ChromeManager.select(null);
    this.reload();
    Sitecore.PageModes.ChromeManager.resetChromes();    
    Sitecore.PageModes.ChromeManager.select(this.chrome);     
  },
  
  /* used when new controls are being inserted (or if they replace other controls) when returned from the server */
  insertRendering: function(data, openProperties) {   
    console.group("insertRendering"); 
    var placeholder = this.chrome;          
    
    if (this.emptyLook()) {
      this.hideEmptyLook();
    }

    Sitecore.PageModes.ChromeHighlightManager.stop();

    var newElement = $sc(data.html);

    var position = this._insertPosition;
    this._insertPosition = null;

    var childRenderings = this.renderings();

    if (position == 0) {
      placeholder.prepend(newElement);
    }
    else if (position < childRenderings.length) {
      var rendering = childRenderings[position - 1];

      rendering.after(newElement);
    }
    else {
      placeholder.append(newElement);
    }

    Sitecore.PageModes.ChromeManager.resetChromes();
        
    var newRenderingUniqueId = newElement.attr("id").substring(2);
    var newRenderingChrome = this._getChildRenderingByUid(newRenderingUniqueId);

    if (!newRenderingChrome) {
      console.error("Cannot find rendering chrome with unique id: " + newRenderingUniqueId);
      Sitecore.PageModes.ChromeHighlightManager.resume();
      return;
    }

    Sitecore.PageModes.PageEditor.setModified(true);
    var l = newRenderingChrome.element.length;   
    newRenderingChrome.element.fadeIn(500, function() {        
      if (--l > 0) return;
      if (!openProperties) {        
        Sitecore.PageModes.ChromeManager.select(newRenderingChrome);
        Sitecore.PageModes.ChromeHighlightManager.resume();          
      }        
    });
                                  
    if (openProperties && newRenderingChrome.isEnabled()) {
      Sitecore.PageModes.ChromeManager.setCommandSender(newRenderingChrome);                        
      this.editProperties(newRenderingChrome);            
    }

    console.groupEnd("insertRendering");
  },

  /* used by design manager while moving controls around on the page */
  insertRenderingAt: function(control, position) { 
    Sitecore.PageModes.ChromeManager.ignoreDOMChanges = true;    
    var originalPlaceholder = control.type.getPlaceholder();
    if (this.emptyLook()) {
      this.hideEmptyLook();
    }

    Sitecore.PageModes.ChromeHighlightManager.stop();

    if (this.isEmpty()) {
      this.chrome.append(control);
    }
    else {
      var renderings = this.renderings();      
      
      if (position < renderings.length) {    
        var rendering = renderings[position];
        rendering.before(control);
      }
      else {
        this.chrome.append(control);
      }
    }
    
    control._placeholder = this;
    var l = control.element.length;   
    control.element.fadeIn(500, function() {     
      if (--l > 0) return;
      $sc.each(control.descendants(), function() { if (this.key() == "word field") this.type.initWord(); });
      control.detachElements();
      // The position of DOM nodes has change.
      // Rearange chromes position in the _chromes array to make the chromes reset method occurr in correct sequence
      Sitecore.PageModes.ChromeManager.rearrangeChromes();
      Sitecore.PageModes.ChromeManager.resetChromes();
      
      if (originalPlaceholder) {
        originalPlaceholder.type.reload();
      }

      Sitecore.PageModes.ChromeHighlightManager.resume();
      Sitecore.PageModes.ChromeManager.select(control);
      Sitecore.PageModes.ChromeManager.ignoreDOMChanges = false;
    });       
  },

  isEmpty: function() {
    return this.chrome.element.length === 0 ||
           this.chrome.element.hasClass(Sitecore.PageModes.ChromeTypes.Placeholder.emptyLookFillerCssClass);
  },

  isEnabled: function() {
    return this.base() &&
            this.selectable() &&
            this.chrome.data.custom.editable === "true" && 
            $sc.inArray(Sitecore.PageModes.Capabilities.design, Sitecore.PageModes.PageEditor.getCapabilities()) > -1;            
  },

  elements: function(domElement) {
    if (!domElement.is("code[type='text/sitecore'][chromeType='placeholder']")) {
      console.error("Unexpected domelement passed to PlaceholderChromeType for initialization:");
      console.log(domElement);
      
      throw "Failed to parse page editor placeholder demarked by script tags";
    }  

    return this._getElementsBetweenScriptTags(domElement);
  },
  
  emptyLook: function() {
    return this.chrome.element.filter(this._emptyLookSelector()).length > 0;
  },
    
  getContextItemUri: function() {
    return "";
  },
  
  handleMessage: function(message, params) {
    switch (message) {
      case "chrome:placeholder:addControl":
        this.addControl();
        break;
      case "chrome:placeholder:editSettings":
        this.editSettings();
        break;
      case "chrome:placeholder:editSettingscompleted":
        this.editSettingsCompleted(params.editable, params.allowedRenderingIds);
        break;
      case "chrome:placeholder:controladded":
        this.addControlResponse(params.id, params.openProperties, params.dataSource);
        break;
    }    
  },
  
  hideEmptyLook: function() {        
    this.chrome.element.filter(this._emptyLookSelector()).remove();
  },
    
  key: function() {
    return "placeholder";
  },
  
  load: function() {
    if (this.isEmpty()) {
      this.showEmptyLook();
    }

    var addCommand = $sc.first(this.chrome.commands(), function() { return this.click.indexOf("chrome:placeholder:addControl") > -1; });
    if (addCommand) {
      this._insertionEnabled = true;
      addCommand.hidden = true;
    }
  },

  loadRenderingFromUrl: function(url, callback) {
    this._loadRenderingFromUrl(url, callback);
  },

  morphRenderings: function(chrome, morphingRenderingsIds) {
    var ribbon = Sitecore.PageModes.PageEditor.ribbon();

    ribbon.contentWindow.$("scLayoutDefinition").value = $sc("#scLayout").val();    
    this._insertPosition = chrome.type.positionInPlaceholder();    
    Sitecore.PageModes.PageEditor.postRequest("webedit:addrendering(placeholder=" + this.placeholderKey() + ",renderingIds=" + 
                                                morphingRenderingsIds.join('|') + ")");
  },

  morphRenderingsResponse: function(renderingChrome, id, openProperties) {            
    if (id == "") {
      return;
    }
    
    var options = Sitecore.PageModes.ChromeTypes.Placeholder.getDefaultAjaxOptions("morph");
    options.data.morphedRenderingUid = renderingChrome.type.uniqueId();
    options.data.rendering =  id; 
    options.data.placeholderKey = this.placeholderKey();
    options.data.url = window.location.href       
    options.context = this;
    this._addAnalyticsOptions(renderingChrome, options, true);
    
    options.success = function(serverData) {               
      var data = Sitecore.PageModes.Utility.parsePalleteResponse(serverData);
      var persistedLayout;
      
      if (data.layout) {
        var layoutCtrl = $sc("#scLayout");
        persistedLayout = layoutCtrl.val();
        layoutCtrl.val(data.layout);  
      }
        
      Sitecore.PageModes.ChromeManager.hideSelection();
        
      if (data.url != null) {          
        this._loadRenderingFromUrl(data.url, function(callbackData) {
          if (callbackData.error == null) {
            data.html = callbackData.renderingElement.combined.outerHtml();
            this._removeRendering(renderingChrome);
            this.insertRendering(data, openProperties);
          }
          else {
            if (persistedLayout) {
              $sc("#scLayout").val(persistedLayout);
            }

            alert(callbackData.error);
          } 
        });                   
      }
      else {
        this._removeRendering(renderingChrome);
        Sitecore.PageModes.Utility.tryAddStyleSheets(data.styleSheets);
        Sitecore.PageModes.Utility.tryAddScripts(data.scripts);          
        this.insertRendering(data, openProperties);
      }

      if (renderingChrome.type.hasVariations()) {        
        Sitecore.PageModes.PageEditor.refreshRibbon();   
      }
    };

    $sc.ajax(options);
  },

  onShow: function() {
    if (!this._insertionEnabled) {
      return;
    }

    if (this.isReadOnly()) {
      return;
    } 
       
    this.inserter = new Sitecore.PageModes.ChromeTypes.PlaceholderInsertion(this.chrome);
    this.inserter.activate();
  },

  onHide: function() {
    if (this.inserter) {
      this.inserter.deactivate();
      this.inserter = null;
    }
  },
        
  placeholderKey: function() {
    return this.chrome.openingMarker().attr("key");
  },
  
  removeChrome: function(chrome) {
    chrome.element.remove();
  },

  renderings: function() {
    return this.chrome.getChildChromes(function() { return this.key() == "rendering" });
  },

  renderingAllowed: function(renderingId) {
    var allowedRenderings = this.chrome.data.custom.allowedRenderings;
    return allowedRenderings.length == 0 || $sc.inArray(renderingId, allowedRenderings) > -1;
  },

  reload: function() {
    if (!this.isEmpty()) {
      return;
    }

    this.isEnabled() ? this.showEmptyLook() : this.hideEmptyLook();
  },
  
  sortingStart: function(rendering) {
    if (!this.renderingAllowed(rendering.type.renderingId())) {
      return;
    }

    if (this.isReadOnly()) {
      return;
    }
  
    this.sorter = new Sitecore.PageModes.ChromeTypes.PlaceholderSorting(this.chrome, rendering);
    this.sorter.activate(); 
  },
  
  sortingEnd: function() {
    if (!this.sorter) {      
      return;
    }
    
    this.sorter.deactivate();
    this.sorter = null;
  },
    
  showEmptyLook: function() {
    if (this.emptyLook()) {
      return;
    }

    if (!this.isEnabled()) {
      return;
    }
    
    var emptyLookFiller = $sc("<div class='scEnabledChrome' />")
                                .addClass(Sitecore.PageModes.ChromeTypes.Placeholder.emptyLookFillerCssClass)
                                .attr("sc-placeholder-id", this.controlId());

    this.chrome.append(emptyLookFiller);
    this.chrome.reset();
  },

  _addAnalyticsOptions: function(renderingChrome, options, useDefault) {
    var activeVariation, activeCondition;
    activeVariation = $sc.first(renderingChrome.type.getVariations(), function() { return useDefault || this.isActive; });
    if (!activeVariation) {              
      activeCondition = $sc.first(renderingChrome.type.getConditions(), function() { return useDefault? this.isDefault() : this.isActive; });      
    } 
           
    if (activeVariation) {
      options.data.variationId = activeVariation.id;
    }

    if (activeCondition) {
      options.data.conditionId = $sc.toShortId(activeCondition.id);
    } 
  },

  _doUpdateRenderingProperties: function(renderingChrome, html) {
    renderingChrome.type.update(html);            
    Sitecore.PageModes.ChromeManager.resetChromes();
    renderingChrome.reload();
    // Changing properies may effect appearance of other conditions or variations
    renderingChrome.type.clearCachedConditions();
    renderingChrome.type.clearCachedVariations();
    var chrome = this._getChildRenderingByUid(renderingChrome.type.uniqueId());
      
    if (chrome) {
      setTimeout(function() {           
        Sitecore.PageModes.ChromeHighlightManager.resume();
        Sitecore.PageModes.ChromeManager.select(chrome);          
      }, 100);
    }
    else {
      Sitecore.PageModes.ChromeHighlightManager.resume();
    }
  },

  _emptyLookSelector: function() {
    // Using only CSS class is not enough, becuase we can get the empty placeholder of some inner rendering by mistake.
    return "." + Sitecore.PageModes.ChromeTypes.Placeholder.emptyLookFillerCssClass + "[sc-placeholder-id='" + this.controlId() + "']";
  },

  _getChildRenderingByUid: function(uid) {
    return this.chrome.getChildChromes(function() { return this.key() == "rendering" && this.type.uniqueId() == uid; })[0];
  },
  
  _loadRenderingFromUrl: function(url, callback) {    
    if (!this._loadingFrame) {
      this._loadingFrame = $sc("<iframe id='scLoadingFrame'></iframe>").attr({ height:"0px", width:"0px"}).appendTo(document.body);
      this._loadingFrame.bind("load", $sc.proxy(this._frameLoaded, this));   
    }

    this._frameLoadedCallback = callback;
    this._loadingFrame[0].src = url + "&rnd=" + Math.random();       
  },

  _frameLoaded: function() {
    if (this._loadingFrame == null) {
      console.error("cannot load data from frame. Frame isn't defined");
      return;    
    }

    var frame = this._loadingFrame.get(0);
    var renderingUniqueId = $sc.parseQuery(frame.contentWindow.location.href)["sc_ruid"];
    var doc = frame.contentDocument || frame.contentWindow.document;
        
    var renderingDomElement = doc.getElementById("r_" + renderingUniqueId);

    var callbackData = new Object();   
    
    if (renderingDomElement != null) {      
      var start = $sc(renderingDomElement);
      
      if (!start.is("code[type='text/sitecore'][chromeType='rendering'][kind='open']")) {
         throw "Loaded unexpected element while trying to get rendering html from server. Expected opening script marker.";
      }

      var middle = start.nextUntil("code[type='text/sitecore'][chromeType='rendering'][kind='close']");
      var end = middle.last().next();
      start = start.clone();
      middle = middle.clone();
      end = end.clone();     
      var elements = start.add(middle).add(end);

      if (!elements.last().is("code[type='text/sitecore'][chromeType='rendering'][kind='close']")) {
        console.error(elements);

        throw "Loaded unexpected element while trying to get rendering html from server. Expecting last tag to be closing script marker";
      }

      callbackData.renderingElement = {opening: start, content: middle, closing: end, combined: elements };
    }
    else
    {
      console.error("Could not find the rendering in the HTML loaded from server");

      if (frame.contentWindow.location.href.toLowerCase().indexOf("pagedesignererror.aspx") > -1) {     
        callbackData.error = Sitecore.PageModes.Texts.SublayoutWasInsertedIntoItself;
      }
      else {
        callbackData.error = Sitecore.PageModes.Texts.ErrorOcurred;
      }
    }
   
    if (this._frameLoadedCallback != null) {
      this._frameLoadedCallback(callbackData);
      this._frameLoadedCallback = null;
    }    
  },
  
  _removeRendering: function(renderingChrome) {
    if (renderingChrome == null || renderingChrome.key() != "rendering") return;
    if (Sitecore.PageModes.Personalization) {
      Sitecore.PageModes.Personalization.ConditionStateStorage.remove(renderingChrome.type.uniqueId());
    }

    renderingChrome.remove();
    Sitecore.PageModes.ChromeManager.resetChromes();
  } 
},
{
  emptyLookFillerCssClass: "scEmptyPlaceholder",
  getDefaultAjaxOptions: function(commandName) {
    var options = {
      type: "POST",
      url: "/sitecore/shell/Applications/WebEdit/Palette.aspx",     
      dataType: "html",
      data: {
        command: commandName,
        itemid: Sitecore.PageModes.PageEditor.itemId(),
        language: Sitecore.PageModes.PageEditor.language(),
        layout: $sc("#scLayout").val(),
        deviceid:$sc("#scDeviceID").val(),
        siteName: $sc("#scSite").val()
      },

      beforeSend: function (xhr) {
        Sitecore.PageModes.ChromeManager.onChromeUpdating();
      },

      complete: function () {
        Sitecore.PageModes.ChromeManager.onChromeUpdated();  
      },
      error: function(xhr, error) {       
        alert(Sitecore.PageModes.Texts.ErrorOcurred);
      },

      global: false
    };

    return options;
  }
});﻿Sitecore.PageModes.ChromeTypes.Rendering = Sitecore.PageModes.ChromeTypes.ChromeType.extend({
  constructor: function() {
    this.base();
  },
  
  deleteControl: function() {
    var placeholder = this.getPlaceholder();
    
    if (placeholder) {     
      placeholder.type.deleteControl(this.chrome);      
    }
  },

  controlId: function() {
    var marker = this.chrome.openingMarker();
    if (marker) {
      return marker.attr("id");
    }

    return this.base();
  },

  selectable: function() {
    if (this._selectable != null) {
      return this._selectable;
    }

    var marker = this.chrome.openingMarker();
    this._selectable = marker != null && marker.attr("data-selectable") === "true";
    return this._selectable;
  },
  
  editProperties: function() {
    var placeholder = this.getPlaceholder();
    
    if (placeholder) {
      placeholder.type.editProperties(this.chrome);
    }
  },

  editPropertiesCompleted: function() {
    var placeholder = this.getPlaceholder();
    
    if (placeholder) {
      placeholder.type.editPropertiesResponse(this.chrome);
    }
  },

  elements: function(domElement) {
    if (!domElement.is("code[type='text/sitecore'][chromeType='rendering']")) {
      console.error("Unexpected domelement passed to RenderingChromeType for initialization:");
      console.log(domElement);
      throw "Failed to parse page editor rendering demarked by script tags";
    }  

    return this._getElementsBetweenScriptTags(domElement);
  },

  clearCachedConditions: function() {
    var conditions = this.getConditions();
    for (var i = 0; i < conditions.length; i++) {
      Sitecore.PageModes.Personalization.RenderingCache.removeCondition(this.chrome, conditions[i]);
    }
  },
  
  clearCachedVariations: function() {
    var chrome = this.chrome;
    $sc.each(this.getVariations(), function() {Sitecore.PageModes.Testing.RenderingCache.removeVariation(chrome, this);});
  }, 
  
  getConditions: function() {
    if (this._conditions) {
      return this._conditions;
    }

    this._conditions = Sitecore.LayoutDefinition.getRenderingConditions(this.uniqueId());        
    var isActiveConditionSpecified = $sc.exists(this._conditions, function(){ return this.isActive})
    if (!isActiveConditionSpecified) {
      var defaultCondition = $sc.first(this._conditions, function(){ return this.isDefault();});
      if (defaultCondition) {
        defaultCondition.isActive = true;
      }
    }
                               
    return this._conditions;
  },

  resetConditions: function() {        
    this._conditions = null;    
  },
  
  getControl: function(placeholder) {
    var element = this.chrome.element;
    
    return $sc.first(placeholder.controls(), function() {
      return this.element == element;
    });
  },
  
  getPlaceholder: function() {
    var result = this.chrome.parent(false, false);

    if (!result) {
      return null;
    }
    
    if (result.type.key() != "placeholder") {
      console.warn(result.element);
      console.log();
      throw "Rendering must have placeholder chrome as its parent. Got '" + result.type.key() + "' instead";
    }

    return result;
  },

  getVariations: function() {
    return this._variations;
  },
     
  handleMessage: function(message, params, sender) {
    switch (message) {
      case "chrome:rendering:sort":
        this.sort();
        break;
      case "chrome:rendering:properties":
        this.editProperties();
        break;
      case "chrome:rendering:propertiescompleted":
        this.editPropertiesCompleted();
        break;
      case "chrome:rendering:delete": 
        this.deleteControl();
        break;
      case "chrome:rendering:morph":
        this.morph(params);
        break;
      case "chrome:rendering:morphcompleted":
        this.morphCompleted(params.id, params.openProperties);
        break;
      case "chrome:rendering:personalize":
        if (Sitecore.PageModes.Personalization) {
          this.personalize(params.command);
        }
        break;
      case "chrome:rendering:personalizationcompleted":
        if (Sitecore.PageModes.Personalization) {
          this.presonalizationCompleted(params, sender);
        }                
        break;
      case "chrome:personalization:conditionchange":
        if (Sitecore.PageModes.Personalization) {
          this.changeCondition(params.id, sender);
        }
        break;      
      case "chrome:rendering:editvariations":
        if (Sitecore.PageModes.Testing) {
          this.editVariations(params.command, sender);
        }
        break;
      case "chrome:rendering:editvariationscompleted":
        if (Sitecore.PageModes.Testing) {
          this.editVariationsCompleted(params, sender);
        }
        break;
      case "chrome:testing:variationchange":
        if (Sitecore.PageModes.Testing) {
          this.changeVariation(params.id, sender);
        }        
        break;         
    }
  },

  editVariations: function(commandName, sender) {
    if (!this.hasVariations()) {      
      if (this.chrome.getChildChromes(function () {return this.key() == "rendering" && this.type.hasVariations();}, true).length) {
        alert(Sitecore.PageModes.Texts.Analytics.TestSetUpOnDescendant);
        return;
      }
      
      var ancestors = this.chrome.ancestors();
      if ($sc.first(ancestors, function() {return this.key() == "rendering" && this.type.hasVariations()})) {
        alert(Sitecore.PageModes.Texts.Analytics.TestSetUpOnAscendant);
        return;
      }
    }

    var ribbon = Sitecore.PageModes.PageEditor.ribbon();
    ribbon.contentWindow.$("scLayoutDefinition").value = $sc("#scLayout").val();
    var controlId = this.controlId();
    if (sender) {
      controlId = sender.controlId(); 
    }

    Sitecore.PageModes.PageEditor.postRequest(commandName + "(uniqueId=" + this.uniqueId() + ",controlId=" + controlId + ")");
  },

  editVariationsCompleted: function(parameters, sender) {
    var variations = parameters.variations;     
    Sitecore.LayoutDefinition.readLayoutFromRibbon(); 
    // reset command
    if (variations.length == 0) {
      var chrome = this.chrome;
      //Clear caches
      $sc.each(this.getVariations(), function() {Sitecore.PageModes.Testing.RenderingCache.removeVariation(chrome, this);});      
      this._variations = [];
      // TODO: change this. Currently changing rendering properties doesn't update chrome data.
      this.editPropertiesCompleted();      
      // Update ribbon controls which display testing components     
      Sitecore.PageModes.PageEditor.refreshRibbon();      
      return;        
    }
 
    var activeVariation = $sc.first(this.getVariations(), function() { return this.isActive;});           
    // By default last variation is active
    variations[variations.length - 1].isActive = true;    
    var activeVariationId;
    if (activeVariation) {
      activeVariationId = activeVariation.id
      for (var i = 0; i < variations.length; i++) {        
        if (variations[i].id === activeVariationId) {
          //Reset default active variation
          variations[variations.length - 1].isActive = false;
          variations[i].isActive = true;
          break;
        }        
      }
    }
    else {
      // Component is testable now.
      // Update ribbon controls which display testing components 
      Sitecore.PageModes.PageEditor.refreshRibbon();
    }

    var isActiveVariationModified = false;
    var modifiedVariations = parameters.modifiedIds;
    for (var i = 0; i < modifiedVariations.length; i++) {
      Sitecore.PageModes.Testing.RenderingCache.removeVariation(this.chrome,  modifiedVariations[i]);
      if (modifiedVariations[i] === activeVariationId) {
        isActiveVariationModified = true;
      }
    }
    
    this._variations = variations;
    if (isActiveVariationModified || activeVariation == null) {
      var newActiveVariation = $sc.first(this.getVariations(), function() { return this.isActive;});
      if (newActiveVariation) {
        var preserveCacheUpdating = true;                            
        this.changeVariation(newActiveVariation.id, sender, preserveCacheUpdating);
        return;
      }        
    }

    if (Sitecore.PageModes.ChromeManager.selectedChrome() != null) {
      Sitecore.PageModes.ChromeManager.resetSelectionFrame();
    }
    else {
      Sitecore.PageModes.ChromeManager.select(this.chrome);
    } 
  },

  isEnabled: function() {
    return  this.base() &&
            this.selectable() &&
            this.chrome.data.custom.editable === "true" &&             
            $sc.inArray(Sitecore.PageModes.Capabilities.design, Sitecore.PageModes.PageEditor.getCapabilities()) > -1;            
  },

  hasVariations: function() {
    return this._variations.length > 0;
  },
  
  key: function() {
    return "rendering";
  },

  morph: function(morphingRenderings) {
    var placeholder = this.getPlaceholder();
    
    if (placeholder) {
      placeholder.type.morphRenderings(this.chrome, morphingRenderings);
    }
  },

  morphCompleted: function(mophedRenderingId, openProperties) {
    var placeholder = this.getPlaceholder();
    
    if (placeholder) {
      placeholder.type.morphRenderingsResponse(this.chrome, mophedRenderingId, openProperties);
    }
  },

  personalize: function(commandName) {
    var ribbon = Sitecore.PageModes.PageEditor.ribbon();
    ribbon.contentWindow.$("scLayoutDefinition").value = $sc("#scLayout").val();         
    Sitecore.PageModes.PageEditor.postRequest(commandName + "(uniqueId=" + this.uniqueId() +")");
  },

  presonalizationCompleted: function(modifiedConditions, sender) {    
    if (!Sitecore.LayoutDefinition.readLayoutFromRibbon()) {
      return;
    }
    var previousActiveCondition = $sc.first(this.getConditions(), function() {return this.isActive;});
    this.resetConditions();
    var activeCondition = $sc.first(this.getConditions(), function() {return this.isActive;});
    var isActivaeConditionModified = false;
    for (var i = 0; i < modifiedConditions.length; i++) {
      Sitecore.PageModes.Personalization.RenderingCache.removeCondition(this.chrome,  modifiedConditions[i]);
      if (modifiedConditions[i] == activeCondition.id) {
        isActivaeConditionModified = true;
      }
    }
                      
    var activaeConditionChanged = previousActiveCondition && activeCondition && previousActiveCondition.id !== activeCondition.id;
    if (activaeConditionChanged || isActivaeConditionModified) {
      var preserveCacheUpdating = true;                            
      this.changeCondition(activeCondition.id, sender, preserveCacheUpdating);
      return;
    }

    if (Sitecore.PageModes.ChromeManager.selectedChrome() != null) {
      Sitecore.PageModes.ChromeManager.resetSelectionFrame();
    }
    else {
      Sitecore.PageModes.ChromeManager.select(this.chrome);
    }          
  },

  load: function() {    
    this.canUpdateRenderingCache = true;

    if (Sitecore.PageModes.Personalization) {        
      Sitecore.PageModes.ChromeControls.registerCommandRenderer("chrome:rendering:personalize", Sitecore.PageModes.ChromeTypes.Rendering.renderPersonalizationCommand, this);
    }

    this._variations = [];
    if (Sitecore.PageModes.Testing) {        
      Sitecore.PageModes.ChromeControls.registerCommandRenderer("chrome:rendering:editvariations", Sitecore.PageModes.ChromeTypes.Rendering.renderEditVariationsCommand, this);
              
      if (this.chrome.hasDataNode && this.chrome.data.custom.testVariations) {
        this._variations = this.chrome.data.custom.testVariations;
        if (Sitecore.PageModes.PageEditor.isTestRunning()) {
          this.setReadOnly();
        }
      }
    }

    this.queryCommands();
    this.saveHandler = $sc.proxy(this.onSave, this);
    this.resetHandler = $sc.proxy(this.onReset, this);
    Sitecore.PageModes.ChromeManager.chromesReseted.observe(this.resetHandler);
    Sitecore.PageModes.PageEditor.onSave.observe(this.saveHandler);    
  },

  queryCommands: function() {
    var morphCommand = $sc.first(this.chrome.commands(), function() { return this.click && this.click.toLowerCase().indexOf("chrome:rendering:morph") > -1; });
    var chrome = this.chrome;
    var placeholder = this.getPlaceholder();
    var hasVariations = this.hasVariations();
    if (morphCommand && placeholder) {
      var hasAllowedMorphingRenderings = false;
      var click = Sitecore.PageModes.Utility.parseCommandClick(morphCommand.click);
      var morphingRenderingsIds = click.params;
      
      for (var i = 0; i < morphingRenderingsIds.length; i++) {
        if (placeholder.type.renderingAllowed(morphingRenderingsIds[i])) {
          hasAllowedMorphingRenderings = true;
          break;
        }
      }
     
      //None of the morphing rendering is not allowed in this placeholder due to its setting. Don't show the morph command.
      if (!hasAllowedMorphingRenderings) {
        morphCommand.disabled = true;
      }       
    }
       
    var isPlaceholderDisabled = placeholder && !placeholder.isEnabled();   
      $sc.each(chrome.commands(), function() { 
        if (!this.click) return;
        var click = this.click.toLowerCase();
        if (click.indexOf("chrome:rendering:sort") > -1) {
          this.disabled = !Sitecore.PageModes.DesignManager.canMoveRendering(chrome);
        }

        if (click.indexOf("chrome:rendering:delete") > -1) {
          this.disabled = isPlaceholderDisabled || hasVariations;
        }
      });    
  },
      
  onHide: function() {
    this.base();
    if (this._sorting) {
      this.sortingEnd();
    }
  },

  onReset: function() {    
    this.queryCommands();
  },

  onSave: function() {
    this.canUpdateRenderingCache = false;
  },

  positionInPlaceholder: function() {    
    var placeholder = this.getPlaceholder();    
    return placeholder ? Sitecore.LayoutDefinition.getRenderingPositionInPlaceholder(placeholder.type.placeholderKey(), this.uniqueId()) : -1;    
  },

  changeCondition: function(id, sender, preserveCacheUpdating) {
    var fieldId;
    if (sender && sender.key() == "field")
    {
      fieldId = sender.type.id();
    }

    var conditions = this.getConditions();
    if (!preserveCacheUpdating) {
      this.updateConditionCache($sc.first(conditions, function() { return this.isActive; }));
    }
                         
    Sitecore.PageModes.ChromeManager.chromeUpdating.fire(this.chrome);
    Sitecore.PageModes.ChromeOverlay.showOverlay(this.chrome);
   
    var cachedElements = Sitecore.PageModes.Personalization.RenderingCache.getCachedCondition(this.chrome, id);
    if (cachedElements) {
      Sitecore.PageModes.ChromeHighlightManager.stop();      
      this.updateOnConditionActivation(id, cachedElements, fieldId);
      Sitecore.PageModes.ChromeHighlightManager.resume();
      return;
    }
        
    var options = Sitecore.PageModes.ChromeTypes.Placeholder.getDefaultAjaxOptions("activatecondition");
    options.data.renderingUniqueId = this.uniqueId(); 
    options.data.conditionId = $sc.toShortId(id);
    options.data.url = window.location.href;       
    options.context = this;
    options.beforeSend = $sc.noop();
    options.complete = $sc.noop();
    options.error = function(xhr, error) {
      console.error(xhr.statusText + ":" + error);
      this._endActivation("changecondition");
      Sitecore.PageModes.ChromeManager.resetSelectionFrame();      
    };

    options.success = function(serverData) {               
        var data = Sitecore.PageModes.Utility.parsePalleteResponse(serverData);        
        Sitecore.PageModes.ChromeHighlightManager.stop();
        if (data.url != null) {          
           this.getPlaceholder().type.loadRenderingFromUrl(data.url, $sc.proxy(function(callbackData) {
              if (callbackData.error == null) {                                                
                this.updateOnConditionActivation(id, callbackData.renderingElement.combined, fieldId);
              }
              else {
                console.error(callbackData.error);
                this._endActivation("changecondition");
                Sitecore.PageModes.ChromeManager.resetSelectionFrame();
              }

              Sitecore.PageModes.ChromeHighlightManager.resume();
            }, this)); 
        }
        else {            
          Sitecore.PageModes.Utility.tryAddStyleSheets(data.styleSheets);
          Sitecore.PageModes.Utility.tryAddScripts(data.scripts);          
          this.updateOnConditionActivation(id, $sc(data.html), fieldId);
          Sitecore.PageModes.ChromeHighlightManager.resume();
        }
    };

    $sc.ajax(options);
  },

  changeVariation: function(id, sender, preserveCacheUpdating) {
    var fieldId;
    if (sender && sender.key() == "field")
    {
      fieldId = sender.type.id();
    }
    
    if (!preserveCacheUpdating) {
      this.updateVariationCache($sc.first(this.getVariations(), function() { return this.isActive; }));
    }

    Sitecore.PageModes.ChromeManager.chromeUpdating.fire(this.chrome);
    Sitecore.PageModes.ChromeOverlay.showOverlay(this.chrome);
    var cachedElems = Sitecore.PageModes.Testing.RenderingCache.getCachedVariation(this.chrome, id);
    if (cachedElems) {
      Sitecore.PageModes.ChromeHighlightManager.stop();      
      this.updateOnVariationActivation(id, cachedElems, fieldId);
      Sitecore.PageModes.ChromeHighlightManager.resume();
      return;
    }

    var options = Sitecore.PageModes.ChromeTypes.Placeholder.getDefaultAjaxOptions("activatevariation");
    options.data.renderingUniqueId = this.uniqueId(); 
    options.data.variationId = $sc.toShortId(id);
    options.data.url = window.location.href;       
    options.context = this;
    options.beforeSend = $sc.noop();
    options.complete = $sc.noop();
    options.error = function(xhr, error) {
      console.error(xhr.statusText + ":" + error);
      this._endActivation("changevariation");
      Sitecore.PageModes.ChromeManager.resetSelectionFrame();      
    };

    options.success = function(serverData) {               
        var data = Sitecore.PageModes.Utility.parsePalleteResponse(serverData);        
        Sitecore.PageModes.ChromeHighlightManager.stop();
        if (data.url != null) {          
           this.getPlaceholder().type.loadRenderingFromUrl(data.url, $sc.proxy(function(callbackData) {
              if (callbackData.error == null) {                                                
                this.updateOnVariationActivation(id, callbackData.renderingElement.combined, fieldId);
              }
              else {
                console.error(callbackData.error);
                this._endActivation("changevariation");
                Sitecore.PageModes.ChromeManager.resetSelectionFrame();
              }

              Sitecore.PageModes.ChromeHighlightManager.resume();
            }, this)); 
        }
        else {            
          Sitecore.PageModes.Utility.tryAddStyleSheets(data.styleSheets);
          Sitecore.PageModes.Utility.tryAddScripts(data.scripts);          
          this.updateOnVariationActivation(id, $sc(data.html), fieldId);
          Sitecore.PageModes.ChromeHighlightManager.resume();
        }
    };

    $sc.ajax(options);
  },

  onDelete: function (preserveData) {
    this.base(preserveData);
    if (!preserveData) {
      if (this.saveHandler) {
        Sitecore.PageModes.PageEditor.onSave.stopObserving(this.saveHandler);
      }

      if (this.resetHandler) {
        Sitecore.PageModes.PageEditor.onSave.stopObserving(this.resetHandler);
      }
    }   
  },
  
  renderingId: function() {
    return this.chrome.data.custom.renderingID;
  },
   
  sort: function() {        
    Sitecore.PageModes.DesignManager.sortingStart(this.chrome);
    this._sorting = true;
    
    Sitecore.PageModes.ChromeManager.selectionFrame().controls.hide();        
    Sitecore.PageModes.ChromeManager.moveControlFrame().show(this.chrome);
  },
  
  sortingEnd: function() {
    Sitecore.PageModes.DesignManager.sortingEnd();
    Sitecore.PageModes.ChromeManager.moveControlFrame().hide();
    this._sorting = false;
  },
  
  uniqueId: function() {
    return this.chrome.openingMarker().attr("id").substring(2);
  },
  
  update: function(data) {
    var html, updateChromeData = false;
    
    if ($sc.type(data) === "string") {
      html = data;
    }
    else {
      html = data.html;
      updateChromeData = data.updateChromeData;
    }
    
    if (!html) {
      throw "Argument 'html' cannot be empty";
    }

    var fragmnet = document.createDocumentFragment();
    var newElements = $sc(html).appendTo(fragmnet);        
    if (!newElements) {
      return;
    }

    var elements = this.elements($sc(newElements[0]));            
    this.chrome.onDelete(true);   
    /* todo: rewrite to avoid going too much into Chrome's responsibility. */
    if (updateChromeData) {
      var dataNode = this.dataNode(elements.opening);
      this.chrome.setData(dataNode);
      var marker = this.chrome.openingMarker();
      if (marker && dataNode) {
        // Dirty hack. Persist the chrome data html into a DOM node in order it could be successfully
        // placed into html cache.
        marker[0].innerHTML = dataNode[0].innerHTML;
      }      
    }
        
    this.chrome.empty();
    this.chrome.append(elements.content);                
    this.canUpdateRenderingCache = true;
  },

  updateConditionCache: function(condition) {
    if (!this.canUpdateRenderingCache) {
      return;
    }

    if (condition) {
      var nodes = this.chrome.elementsAndMarkers().clone(false,false);      
      Sitecore.PageModes.Personalization.RenderingCache.cacheCondition(this.chrome, condition, nodes);
    }
  },
  
  updateVariationCache: function(variation) {
    if (!this.canUpdateRenderingCache) {
      return;
    }

    if (variation) {
      var nodes = this.chrome.elementsAndMarkers().clone(false,false);
      Sitecore.PageModes.Testing.RenderingCache.cacheVariation(this.chrome, variation, nodes);
    }
  }, 
  
  updateOnConditionActivation: function(conditionId, markersAndElements, fieldId) {            
    var conditions = this.getConditions();
    for (var i = 0; i < conditions.length; i++) {
      if (conditions[i].id === conditionId) {
        conditions[i].isActive = true;
        Sitecore.PageModes.Personalization.ConditionStateStorage.setConditionActive(this.uniqueId(), conditionId);        
      }
      else {
        conditions[i].isActive = false;
      }
    }
    
    this._startActivation(markersAndElements, "changecondition", fieldId);       
  },

  updateOnVariationActivation: function(variationId, markersAndElements, fieldId) {
    for (var i = 0; i < this._variations.length; i++) {
      this._variations[i].isActive = this._variations[i].id === variationId;
    }
   
    this._startActivation(markersAndElements, "changevariation", fieldId);
  },

  _endActivation: function(startReason) {
    Sitecore.PageModes.ChromeManager.onChromeUpdated(this.chrome, startReason);
    Sitecore.PageModes.ChromeOverlay.hideOverlay();
  },

  _startActivation: function(markersAndElements, reason, fieldId) {
    var delay = Sitecore.PageModes.ChromeOverlay.getShowingDuration();       
    
    setTimeout($sc.proxy(function() {   
      Sitecore.PageModes.ChromeManager.ignoreDOMChanges = true;
      Sitecore.PageModes.ChromeHighlightManager.stop();          
      Sitecore.PageModes.ChromeManager.select(null);                       
      
      this.update({html: markersAndElements, updateChromeData: this.selectable()});                                                  
      
      Sitecore.PageModes.ChromeManager.resetChromes();
      
      this.chrome.reload();
      if (!fieldId) {
        Sitecore.PageModes.ChromeManager.select(this.chrome); 
      }
           
      // If condition activation was initiated by the the field try to select it.
      if (fieldId) {           
        var deep = true;
        var field = this.chrome.getChildChromes(function() {
                                                return this && this.key() == "field" && 
                                                        this.isEnabled() && this.type.id() == fieldId;
                                                }, deep)[0];
        if (field) {
          Sitecore.PageModes.ChromeManager.select(field);       
        }
        else {
          Sitecore.PageModes.ChromeManager.select(this.chrome);       
        }                                   
      }
                  
      Sitecore.PageModes.ChromeManager.ignoreDOMChanges = false;
      Sitecore.PageModes.ChromeHighlightManager.resume();
      this._endActivation(reason);
    }, this), delay); 
  }
},
{
  renderPersonalizationCommand : function(command, isMoreCommand, chromeControls) {        
    command.enabledWhenReadonly = true;    
    command.disabled = false;
    var hasVariations = this.getVariations().length > 0;
    if (hasVariations || !Sitecore.PageModes.PageEditor.isPersonalizationAccessible()) {
      command.disabled = true;
      if (hasVariations) {
        return false; 
      }          
    }
        
    if (isMoreCommand) {
      return false;
    }

    if (this.getConditions().length <= 1) {
      if (!Sitecore.PageModes.PageEditor.isPersonalizationAccessible()) {
        return null;        
      }

      return false;
    }

    if (!Sitecore.PageModes.ChromeTypes.Rendering.personalizationBar) {      
      Sitecore.PageModes.ChromeTypes.Rendering.personalizationBar = new Sitecore.PageModes.RichControls.Bar(
        new Sitecore.PageModes.Personalization.Panel(),
        new Sitecore.PageModes.Personalization.DropDown()
      );
    }
    
    var context = new Sitecore.PageModes.Personalization.ControlsContext(this.chrome, chromeControls, command);
    if (!Sitecore.PageModes.PageEditor.isControlBarVisible()) {
      return Sitecore.PageModes.ChromeTypes.Rendering.personalizationBar.renderHidden(
        context,        
        Sitecore.PageModes.Texts.Analytics.ChangeCondition, 
        "/sitecore/shell/~/icon/PeopleV2/16x16/users3.png");
    }
    
    var ctrl = Sitecore.PageModes.ChromeTypes.Rendering.personalizationBar.render(context)
    chromeControls.commands.append(ctrl);     
    return false;    
  },

  renderEditVariationsCommand: function (command, isMoreCommand, chromeControls) {
    command.enabledWhenReadonly = true;
    if (Sitecore.PageModes.PageEditor.isTestRunning() || !Sitecore.PageModes.PageEditor.isTestingAccessible()) {
      command.disabled = true;
    }

    if (isMoreCommand) {
      return false;
    }
   
    if (this.getVariations().length <= 1) {      
      if (!Sitecore.PageModes.PageEditor.isTestingAccessible()) {
        return null;        
      }

      return false;
    }

    if (!Sitecore.PageModes.ChromeTypes.Rendering.testingBar) {      
      Sitecore.PageModes.ChromeTypes.Rendering.testingBar = new Sitecore.PageModes.RichControls.Bar(
        new Sitecore.PageModes.Testing.Panel("scTestingPanel"),
        new Sitecore.PageModes.Testing.DropDown()
      );
    }
    
    var context = new Sitecore.PageModes.Testing.ControlsContext(this.chrome, chromeControls, command);
    if (!Sitecore.PageModes.PageEditor.isControlBarVisible()) {
      return Sitecore.PageModes.ChromeTypes.Rendering.testingBar.renderHidden(
        context,
        Sitecore.PageModes.Texts.Analytics.ChangeVariation        
       );
    }
    
    var ctrl = Sitecore.PageModes.ChromeTypes.Rendering.testingBar.render(context)
    chromeControls.commands.append(ctrl);     
    return false;
  }
});﻿Sitecore.PageModes.ChromeTypes.Field = Sitecore.PageModes.ChromeTypes.ChromeType.extend({
  constructor: function() {
    this.base();
    //Key codes which aren't tracked as ones that modify contenteditable fields
    this._ignoreKeyCodes = [16, 17, 18, 27, 35, 36, 37, 38, 39, 40];    
  },

  load: function() {           
    var persistedValue = Sitecore.PageModes.ChromeManager.getFieldValueContainerById(this.controlId());
    var fieldValueInput = this.chrome.element.prev().prev(".scFieldValue");
    if (fieldValueInput.length == 0) {
      fieldValueInput = null;
    }
            
    if (persistedValue) {
      this.fieldValue = $sc(persistedValue);
      if (fieldValueInput) {                                
        fieldValueInput.remove();
      }
    }
    else {      
      if (fieldValueInput) {
        this.fieldValue = fieldValueInput;
        Sitecore.PageModes.ChromeManager.addFieldValue(this.fieldValue);
      }
      else {  
        this.fieldValue = $sc({});
      }
    }
                    
    var modifiedControlId = this.fieldValue.data("modified"); 
    if (modifiedControlId && modifiedControlId !== this.controlId()) {
      this.setReadOnly();
      var notification = new Sitecore.PageModes.Notification("fieldchanges", Sitecore.PageModes.Texts.ContentWasEdited,
        {
          actionText: Sitecore.PageModes.Texts.SaveThePageToSeeTheChanges, 
          onActionClick:  $sc.proxy(Sitecore.PageModes.PageEditor.save, Sitecore.PageModes.PageEditor),
          type: "warning"
        });

      Sitecore.PageModes.PageEditor.notificationBar.addNotification(notification);
      Sitecore.PageModes.PageEditor.showNotificationBar();
    }

    this.initialAttributes = new Object();    
    if (this.chrome.element.attr("sc_parameters")) {
      this.parameters = $sc.parseQuery(this.chrome.element.attr("sc_parameters"));
    }
    else {
      this.parameters = new Object();
    }
    
    this.parentLink = this.chrome.element.closest("a").get(0);
    this.fieldType = this.chrome.element.attr("scfieldtype");
    this.onMouseDownHandler = $sc.proxy(this.onMouseDown, this); 
    this.chrome.element.mousedown(this.onMouseDownHandler);
   
    if (this.contentEditable()) {     
      if (this.chrome.element.attr("scWatermark") == "true") {        
        this.watermarkHTML = this.chrome.element.html();        
      }
     
      this.onKeyDownHandler = $sc.proxy(this.onKeyDown, this);
      this.onKeyUpHandler = $sc.proxy(this.onKeyUp, this);
      this.onCutPasteHandler = $sc.proxy(this.onCutPaste, this);
      this.onClickHandler = $sc.proxy(this.onClick, this);
      this.onBlurHandler = $sc.proxy(this.onBlur, this);     
      this.capabilityChangedHandler = $sc.proxy(this.setContentEditableState, this);
      Sitecore.PageModes.PageEditor.onCapabilityChanged.observe(this.capabilityChangedHandler);      
      this.saveHandler = $sc.proxy(this.onSave, this);
      Sitecore.PageModes.PageEditor.onSave.observe(this.saveHandler);
      this.setContentEditableState();
      // IE doesn't return calculated values for current style.
      if ($sc.util().isIE) {       
        var dummy = $sc("<div style='height:0px;width:1em;position:absolute'></div>");        
        this.chrome.element.parent().append(dummy);
        this.fontSize = dummy.get(0).offsetWidth;
        dummy.remove();
      }
      else {
        this.fontSize = parseInt(this.chrome.element.css("font-size"));       
      }
    }

    if (Sitecore.PageModes.Personalization) {
      Sitecore.PageModes.ChromeControls.registerCommandRenderer(
        "chrome:rendering:personalize",
        Sitecore.PageModes.ChromeTypes.Field.renderPersonalizationCommand,
        this);
    }
    
    if (Sitecore.PageModes.Testing) {
      Sitecore.PageModes.ChromeControls.registerCommandRenderer(
        "chrome:rendering:editvariations",
        Sitecore.PageModes.ChromeTypes.Field.renderEditVariationsCommand,     
        this);
    }    
  },

  // attaches content editable elements specific event handlers
  attachEventHandlers: function() {    
    this.chrome.element.bind("keyup", this.onKeyUpHandler);
    this.chrome.element.bind("keydown", this.onKeyDownHandler);
    this.chrome.element.bind("paste",  this.onCutPasteHandler);
    this.chrome.element.bind("cut", this.onCutPasteHandler);
    this.chrome.element.bind("click", this.onClickHandler);
    this.chrome.element.bind("blur", this.onBlurHandler);    
  },

  contentEditable: function() {
    var attrValue = this.chrome.element.attr(Sitecore.PageModes.ChromeTypes.Field.contentEditableAttrName);
    return attrValue === "true" || attrValue === "false";
  },

  // detaches content editable elements specific event handlers
  detachEventHandlers: function() {    
    this.chrome.element.unbind("keyup", this.onKeyUpHandler);
    this.chrome.element.unbind("keydown", this.onKeyDownHandler);
    this.chrome.element.unbind("paste",  this.onCutPasteHandler);
    this.chrome.element.unbind("cut", this.onCutPasteHandler);
    this.chrome.element.unbind("click", this.onClickHandler);
    this.chrome.element.unbind("blur", this.onBlurHandler);
  },

  dataNode: function(domElement) {
    return domElement.prev(".scChromeData");       
  },
  
  handleMessage: function(message, params) {
    switch (message) {
      case "chrome:field:insertimage":
        this.insertImage();
        break;
      case "chrome:field:imageinserted":
        this.imageInserted(params.html);
        break;
      case "chrome:field:insertlink":
        this.insertLink();
        break;
      case "chrome:field:linkinserted":
        this.linkInserted(params.url);
        break;
      case "chrome:field:editcontrol":             
        var chars = this.characteristics();
        this.editControl(chars.itemId, chars.language, chars.version, chars.fieldId, this.controlId(), params.command);
        break;
      case "chrome:field:editcontrolcompleted":
        this.editControlCompleted(params.value, params.plainValue, params.preserveInnerContent);
        break;
      case "chrome:field:execute":
        this.execute(params.command, params.userInterface, params.value);
        break;     
      case "chrome:personalization:conditionchange": case "chrome:rendering:personalize": case "chrome:rendering:editvariations": case "chrome:testing:variationchange":
        this.delegateMessageHandling(this.chrome, this.parentRendering(), message, params);        
        break;
      case "chrome:rendering:personalizationcompleted": case "chrome:rendering:editvariationscompleted":
        Sitecore.PageModes.ChromeManager.select(this.chrome);
        this.delegateMessageHandling(this.chrome, this.parentRendering(), message, params);               
        break;      
    }
  },
    
  isEnabled: function() {
    return $sc.inArray(Sitecore.PageModes.Capabilities.edit, Sitecore.PageModes.PageEditor.getCapabilities()) > -1 && this.base();
  },

  isFieldValueContainer: function(node) {
    return this.fieldValue && this.fieldValue.get(0) == node;
  },
  
  layoutRoot: function() {
    if (this.contentEditable()) {
      return this.chrome.element;
    }

    var children = this.chrome.element.children();
    if (children.length == 1) {
      return $sc(children[0]);
    }

    return this.chrome.element;
  },

  persistValue: function() {
    if (this.isWatermark()) return;    
       
    var html = this.chrome.element.html();
    if (this._extraLineBreakAdded) {
      var clone = this.chrome.element.clone();
      clone.find(".scExtraBreak").remove();     
      html = clone.html();      
    }
    
    this.fieldValue.val(html);
    this.chrome.element.removeAttr("scWatermark");
  },

  refreshValue: function() {
    if (this.contentEditable()) {
      this.chrome.element.update(this.fieldValue.val());
      this._tryUpdateFromWatermark();
      this.setModified();
    }
  },
  
  // Sets whether content editable elements are editable (depends on the mode(Edit, Design etc.))
  setContentEditableState: function() {
    if (this.contentEditable()) {
      var isEditable = this.isEnabled() && !this.isReadOnly();
      this.chrome.element.attr(Sitecore.PageModes.ChromeTypes.Field.contentEditableAttrName, isEditable.toString());
      if (isEditable) {
        this.attachEventHandlers();
      }
      else {
        this.detachEventHandlers();
      }
    }
  },

  setReadOnly: function() {
    this.base();
    this.setContentEditableState();    
  },
    
  /*--- Helpers section ---*/
  controlId: function() {
    return this.chrome.element.attr("id").replace("_edit", "");
  },

  convertToGuid: function(shortId) {
    return "{" + shortId.substr(0, 8) + "-" + shortId.substr(8, 4) + "-" + shortId.substr(12, 4) + "-" + shortId.substr(16, 4) + "-" + shortId.substr(20, 12) + "}";
  },

  characteristics: function() {
    //ID format:fld_ItemID_FieldID_Language_Version_Revision_edit
    var fieldCharacteristics = this.controlId().split('_');
    return {
      itemId: this.convertToGuid(fieldCharacteristics[1]),
      fieldId: this.convertToGuid(fieldCharacteristics[2]),
      language: fieldCharacteristics[3],
      version: fieldCharacteristics[4]
    };
  },

  id: function() {
    var chars = this.characteristics();
    return chars.fieldId;
  },

  insertHtmlFragment: function(html) {    
    if (document.selection && document.selection.createRange) {//IE
      document.selection.createRange().pasteHTML(html);
      return true;
    }

    if (window.getSelection && window.getSelection().getRangeAt) {//FF
      range = window.getSelection().getRangeAt(0);
      node = range.createContextualFragment(html);
      range.insertNode(node);
      return true;
    }

    return false;
  },

  isWatermark: function() {
    return this.watermarkHTML == this.chrome.element.html();
  },

  /*--- Commands section---*/
  editControl: function(itemid, language, version, fieldid, controlid, message) {
    var control = Sitecore.PageModes.ChromeManager.getFieldValueContainerById(controlid);
    if (control == null) {
      console.error("control with id " + controlid + " not found");
      return;  
    }

    var plainValue = control.value;
    control = $sc("#" + controlid + "_edit");
    var value = control.html();
    var parameters = control.attr("sc_parameters");

    var ribbon = Sitecore.PageModes.PageEditor.ribbon();
    if (ribbon != null) {
      ribbon.contentWindow.scForm.browser.getControl("scHtmlValue").value = value;
      ribbon.contentWindow.scForm.browser.getControl("scPlainValue").value = plainValue;
      Sitecore.PageModes.PageEditor.postRequest(
          message + '(itemid=' + itemid + ',language=' + language + ',version=' + version + ',fieldid=' +
          fieldid + ',controlid=' + controlid + ',webeditparams=' + parameters + ')', null, false);
    }

    return false;
  },

  editControlCompleted: function(value, plainValue, preserveInnerContent) {
    this.fieldValue.val(typeof(plainValue) != "undefined" ? plainValue : value);
    if (!preserveInnerContent) {
      this.chrome.element.update(value);
    }
    else {
      var targetCtl = this.chrome.element.get(0).firstChild;
      var wrapper = document.createElement("span"); 
      wrapper.innerHTML = value;
      var sourceCtl = wrapper.firstChild;
      $sc.util().copyAttributes(sourceCtl, targetCtl);
      delete wrapper;                      
    }           
    
    this.setModified();
  },
  
  execute: function(command, userInterface, value) {
    if ($sc.browser.mozilla) {
      document.execCommand(command, null, null);
    }
    else {
      document.execCommand(command, userInterface, value);
    }

    // OnTime issue #341414
    this.persistValue()
    this.setModified();
    return false;
  },

  hasParentLink: function() {
    return this.parentLink != null;
  },

  insertImage: function() {
    var chars = this.characteristics();
    var parameters = this.chrome.element.attr("sc_parameters");
    Sitecore.PageModes.PageEditor.postRequest(
              "webedit:insertimage" + '(placement=cursor,itemid=' + chars.itemId + ',language=' +
              chars.language + ',version=' + chars.version + ',fieldid=' + chars.fieldId +
              ',controlid=' + this.controlId() + ',webeditparams=' + parameters + ')', null, false);
    
    return false;
  },

  imageInserted: function(html) {
    this.chrome.element.focus();
    if (this.insertHtmlFragment(html)) {
      this.setModified();
    }
  },

  insertLink: function() {
    var selectionText;  
    // MSIE
    if (document.selection && document.selection.createRange) {
      this.selection = document.selection.createRange();
      selectionText = this.selection.text;
    }
    else if (window.getSelection && window.getSelection().getRangeAt) {
      this.selection = window.getSelection().getRangeAt(0);
      selectionText = this.selection.toString();
    }
    
    if ($sc.trim(selectionText) == "") {
      alert(Sitecore.PageModes.Texts.SelectSomeText);
      return;
    }

    var chars = this.characteristics();
    this.editControl(chars.itemId, chars.language, chars.version, chars.fieldId, this.controlId(), "webedit:insertlink");
  },
  
  linkInserted: function(url) {
    var isIE = document.selection && document.selection.createRange;
    
    if (!this.selection) {
      return;
    }

    // TODO: add preserving link contents for FF.
    var data = {
      html: isIE ? this.selection.htmlText : this.selection.toString(),
      url: url
    };

    // If link is selected, replace it with a new one, preserving link contents.
    if (isIE) {      
      // OT issue#338106
      data.html = this._processHtml(data.html);
      var htmlSelection = $sc.trim(data.html.toLowerCase()) || "";
      if (htmlSelection.indexOf("<a ") == 0 && htmlSelection.indexOf("</a>") == (htmlSelection.length - "</a>".length)) {
        htmlSelection = data.html.substring(data.html.indexOf(">") + 1);
        htmlSelection = htmlSelection.substring(0, htmlSelection.length - "</a>".length);
        data.html = htmlSelection;
      }
    }

    var htmlToInsert = "<a href='" + data.url + "'>" + data.html + "</a>";
    if (isIE) {
      this.selection.pasteHTML(htmlToInsert);
    }
    else {
      node = this.selection.createContextualFragment(htmlToInsert);
      this.selection.deleteContents();
      this.selection.insertNode(node);
    }

    this.setModified();
  },

  key: function() {
    return "field";
  },

  parentRendering: function() {
    var excludeFake = true;
    // The designing capablity may be turned off or user may not have designing rights    
    var enabledOnly = false;
    var chrome = this.chrome.parent(excludeFake, enabledOnly);    
    if (!this._parentRendering) {
      while (chrome && chrome.key() != "rendering") {
        chrome = chrome.parent(excludeFake, enabledOnly);
      }

      this._parentRendering = chrome;           
    }

    return this._parentRendering;
  },

  setModified: function() {
    if(!Sitecore.PageModes.PageEditor.isLoaded()) {
      return;
    }

    Sitecore.PageModes.PageEditor.setModified(true);    
    this.fieldValue.data("modified", this.controlId());
  },

  /*---Event handlers section---*/
  onBlur: function(e) {   
    this.persistValue();    
    this._tryUpdateFromWatermark();                
  },

  onClick: function(e) {
    if (!this.active) {          
      return;
    }

    if (this.isWatermark()) {
      this.chrome.element.update("");
      //Trick to make Chrome set focus on content editable element
      if ($sc.browser.webkit) {        
        var range = document.createRange();
        range.selectNodeContents(this.chrome.element.get(0));
        var sel = window.getSelection();
        sel.removeAllRanges();
        sel.addRange(range);        
      }
    }
    // Restore original values saved in MouseDown handler
    this._restoreInitialStyles();
  },

  onCutPaste: function(e) {
    if (!this.active) {
      e.preventDefault();      
      return;
    }
        
    this.setModified();
  },

  onDelete: function() {
    if (this.saveHandler) {
      Sitecore.PageModes.PageEditor.onSave.stopObserving(this.saveHandler);
    }

    if (this.capabilityChangedHandler) {
      Sitecore.PageModes.PageEditor.onCapabilityChanged.stopObserving(this.capabilityChangedHandler);
    }
  },

  onHide: function() {   
    this.active = false;
    if (this.parentLink && this.initialAttributes.linkTextDecoration != null) {
      this.parentLink.style.textDecoration = this.initialAttributes.linkTextDecoration;
    }

    this._restoreInitialStyles();    
  },

  onKeyDown: function(e) {
    if (!this.active) {
      e.preventDefault();
      return;
    }

    if (e.keyCode == 13) {
      if (this.parameters["prevent-line-break"] === "true") {
        e.stop();
        return;
      }
      
      if (this.parameters["linebreak"] == "br") {        
        e.stop();
        this._insertLineBreak();                
      }
    }
  },

  onKeyUp: function(event) {
    if ($sc.inArray(event.keyCode, this._ignoreKeyCodes) > -1) return;
    if (this.fieldValue.val() != event.currentTarget.innerHTML) {
      this.setModified();
      //at least one modification has been done, so we don't need to check for modifications any more
      this.chrome.element.unbind("keyup", this.onKeyUpHanler);
    }
  },

  onMouseDown: function(e) {     
     if (!e.isLeftButton()) {
      return;
     }

     if (e.ctrlKey) {
      if (!this.isEnabled()) {
        return;
      }

      var href = null;
      if (this.hasParentLink()) {        
        href = this.parentLink.href;
        this.parentLink.onclick = function () {return false;};
        // For IE
        this.parentLink.href = "javascript:return false";
      }

      var sender = e.target;
      if (sender.tagName.toUpperCase() == "A") {
        href = sender.href;       
        sender.onclick = function () {return false;};
        // For IE
        sender.href = "javascript:return false";       
      }
       
      if (!href || href.indexOf("javascript:") == 0) {
        return;
      }
      
      e.stop();
      try 
      {
        window.location.href = href;
      }
      catch(ex) {
      //silent
      }
    }
    else if (this.isEnabled() && this.contentEditable() && Sitecore.PageModes.Utility.isNoStandardsIE()) {
      // HACK FOR IE 7 issue with wrong cursor positioning in contentEditableElements
      this.initialAttributes.position = this.chrome.element.css("position");
      this.initialAttributes.zIndex = this.chrome.element.css("z-index");
      this.chrome.element.css("position", "relative");
      this.chrome.element.css("z-index", "9085");      
    }
  },

  onSave: function() {
    if (!this.isReadOnly() && Sitecore.PageModes.ChromeManager.selectedChrome() == this.chrome && this.contentEditable()) {
      this.persistValue();      
    }

    if (this.fieldValue) {
      this.fieldValue.removeData("modified");
    }
  },

  onShow: function() {    
    this.active = true;
    if (this.parentLink) {
      this.initialAttributes.linkTextDecoration = this.parentLink.style.textDecoration;
      this.parentLink.style.textDecoration = 'none';
    }    
  },

  getConditions: function() {
    var r = this.parentRendering();

    if (!r) {
      return [];
    }

    return r.type.getConditions();    
  },

  getVariations: function() {
    var r = this.parentRendering();

    if (!r) {
      return [];
    }

    return r.type.getVariations();    
  },

  _insertLineBreak: function() {
    var range, tmpRange, lineBreak, extraLineBreak, selection;
    // MSIE
    if (document.selection && document.selection.createRange) {
      this.insertHtmlFragment("<br/>");
      // Moving caret to new position
      range = document.selection.createRange();          
      range.select();
      return;
    }
   
    // Unsupported browser
    if (!document.createRange || !window.getSelection) {
      return;
    }

    // W3C compatible browser
    lineBreak = document.createElement("br");              
    range = window.getSelection().getRangeAt(0);      
    tmpRange = document.createRange();      
    tmpRange.selectNodeContents(this.chrome.element[0]);
    tmpRange.collapse(false);      
    tmpRange.setStart(range.startContainer, range.startOffset);
    // Adding 2 <br/> tags in case of pressing 'enter' while cursor is in the last position.
    // This trick forces cursor to move to the new line
    if (!tmpRange.toString() && !this.chrome.element.find(".scExtraBreak").length) {
      var extraLineBreak = document.createElement("br");      
      extraLineBreak.className = "scExtraBreak";
      range.insertNode(extraLineBreak);
      this._extraLineBreakAdded = true;
    } 
      
    range.insertNode(lineBreak);    
    tmpRange = document.createRange();
    tmpRange.selectNode(lineBreak);
    tmpRange.collapse(false);            
    // Moving cursor
    selection = window.getSelection();
    selection.removeAllRanges();
    selection.addRange(tmpRange);
  },

  _processHtml: function(html) {
    if (!html) {
      return html;
    }

    var tmp, fieldContainer;
    try {
      tmp = $sc("<div></div>").html(html);
      fieldContainer = tmp.children(".scWebEditInput").eq(0);
    }
    catch(e) {
      Sitecore.PageModes.Utility.log("Failed to process html: " +  html);
    }

    return fieldContainer && fieldContainer.length ? fieldContainer.html() : html;
  },

  _restoreInitialStyles: function() {
    if (this.initialAttributes.position != null && this.initialAttributes.zIndex != null) {
      this.chrome.element.css("position", this.initialAttributes.position);
      this.chrome.element.css("z-index", this.initialAttributes.zIndex);
      this.initialAttributes.position = null;
      this.initialAttributes.zIndex = null;
    }
  },

  _tryUpdateFromWatermark: function() {
    if (this.watermarkHTML && 
        (this.chrome.element.html() == "" || this.fieldType == "text" && $sc.removeTags(this.chrome.element.html()) == "" )) {
          this.chrome.element.update(this.watermarkHTML);
          this.chrome.element.attr("scWatermark", "true");
    }
  } 
},
{
  contentEditableAttrName: $sc.util().isNoStandardsIE() ? "contentEditable" : "contenteditable",  
  renderPersonalizationCommand : function(command, isMoreCommand, chromeControls) {
    //Avoid duplication of condition personalization controls when there are nested fields.
    if (this.chrome.isFake()) {
      return null;
    }

    var rendering = this.parentRendering();
    if (!rendering) {
      return null;
    }
        
    command.disabled = false;
    var hasVariations = rendering.type.getVariations().length > 0;
    if (hasVariations || !Sitecore.PageModes.PageEditor.isPersonalizationAccessible()) {
      command.disabled = true;
      if (hasVariations) {
        return false;
      }                
    }
    
    // Personalization command should be enabled even for readonly fields
    command.enabledWhenReadonly = true;
    if (isMoreCommand) {
      return false;
    }
    
    var conditions = this.getConditions();
    var tag = null;
    if (conditions.length <=1 ) {
      if (!Sitecore.PageModes.PageEditor.isPersonalizationAccessible()) {
        return null;        
      }
      
      tag = chromeControls.renderCommandTag(command, this.chrome, isMoreCommand);
      if (!tag) {              
        return false;
      }
    }
    
    var retValue;
    if (!tag) {
      var context = new Sitecore.PageModes.Personalization.ControlsContext(this.chrome, chromeControls, command);
      if (!Sitecore.PageModes.ChromeTypes.Rendering.personalizationBar) {      
        Sitecore.PageModes.ChromeTypes.Rendering.personalizationBar = new Sitecore.PageModes.RichControls.Bar(
          new Sitecore.PageModes.Personalization.Panel(),
          new Sitecore.PageModes.Personalization.DropDown());
      }
    
      var context = new Sitecore.PageModes.Personalization.ControlsContext(this.chrome, chromeControls, command);
      if (!Sitecore.PageModes.PageEditor.isControlBarVisible()) {
        tag = Sitecore.PageModes.ChromeTypes.Rendering.personalizationBar.renderHidden(
                context,        
                Sitecore.PageModes.Texts.Analytics.ChangeCondition, 
                "/sitecore/shell/~/icon/PeopleV2/16x16/users3.png");
      }
      else {
        tag = Sitecore.PageModes.ChromeTypes.Rendering.personalizationBar.render(context)
        chromeControls.commands.append(tag);
        retValue = false;             
      }
    }
   
    if (tag) {
      tag.mouseenter($sc.proxy(function() {
          var r = this.parentRendering();
          if (r) {
            r.showHover();
          }
      }, this));

      tag.mouseleave($sc.proxy(function() {
        var r = this.parentRendering();
          if (r) {
            r.hideHover();
          }
      }, this));
    }

    if (typeof(retValue) == "undefined") {
      retValue = tag;  
    }
    
    return retValue;
  },

  renderEditVariationsCommand: function(command, isMoreCommand, chromeControls) {
     if (this.chrome.isFake()) {
      return null;
    }

    var rendering = this.parentRendering();
    if (!rendering) {
      return null;
    }
    
    var tag = null;
    var variations = this.getVariations();
    command.disabled = false;
    if (!Sitecore.PageModes.PageEditor.isTestingAccessible()) {
      command.disabled = true;  
    }
        
    if (variations.length <= 1) {     
      if (!Sitecore.PageModes.PageEditor.isTestingAccessible()) {
        return null;        
      }

      tag = chromeControls.renderCommandTag(command, this.chrome, isMoreCommand);
      if (!tag) {              
        return false;
      }            
    }

    // Personalization command should be enabled even for readonly fields
    command.enabledWhenReadonly = true;
    if (isMoreCommand) {
      return false;
    }
                
    var retValue;
    if (!tag) {
      if (!Sitecore.PageModes.ChromeTypes.Rendering.testingBar) {      
        Sitecore.PageModes.ChromeTypes.Rendering.testingBar = new Sitecore.PageModes.RichControls.Bar(
          new Sitecore.PageModes.Testing.Panel("scTestingPanel"),
          new Sitecore.PageModes.Testing.DropDown()
        );
      }
    
      var context = new Sitecore.PageModes.Testing.ControlsContext(this.chrome, chromeControls, command);
      if (!Sitecore.PageModes.PageEditor.isControlBarVisible()) {
        tag = Sitecore.PageModes.ChromeTypes.Rendering.testingBar.renderHidden(
          context,        
          Sitecore.PageModes.Texts.Analytics.ChangeVariation);
      }
      else {
        tag = Sitecore.PageModes.ChromeTypes.Rendering.testingBar.render(context)
        chromeControls.commands.append(tag);
        retValue = false;             
      }
    }
   
    if (tag) {
      tag.mouseenter($sc.proxy(function() {
          var r = this.parentRendering();
          if (r) {
            r.showHover();
          }
      }, this));

      tag.mouseleave($sc.proxy(function() {
        var r = this.parentRendering();
          if (r) {
            r.hideHover();
          }
      }, this));
    }

    if (typeof(retValue) == "undefined") {
      retValue = tag;  
    }
    
    return retValue;
  }
});
﻿Sitecore.PageModes.ChromeTypes.EditFrame = Sitecore.PageModes.ChromeTypes.ChromeType.extend({
  constructor: function() {
    this.base();
    this._editFrameUpdating = false;
    this.fieldsChangedDuringFrameUpdate = false;
  },
  
  handleMessage: function(message, params) {
    switch (message) {
      case "chrome:editframe:updatestart":
        this.updateStart();
        break;
      case "chrome:editframe:updateend":
        this.updateEnd();
        break;
    }
  },

  isEnabled: function() {
    return $sc.inArray(Sitecore.PageModes.Capabilities.edit, Sitecore.PageModes.PageEditor.getCapabilities()) > -1 && this.base();
  },

  key: function() {
    return "editframe";
  },

  load: function() {
  },

  updateStart: function() {  
    this._editFrameUpdating = true;
    this.fieldsChangedDuringFrameUpdate = false;    
  },

  updateEnd: function() {
    if (this.fieldsChangedDuringFrameUpdate) {
      this.chrome.element.addClass("scWebEditFrameModified");      
    }

    this._editFrameUpdating = false;
    this.fieldsChangedDuringFrameUpdate = false;
  }
});﻿// Class defines logic for Word document field in inline edititng mode
Sitecore.PageModes.ChromeTypes.WordField = Sitecore.PageModes.ChromeTypes.Field.extend({  
  load: function() {    
    try {
      var obj = new ActiveXObject("Edraw.OfficeViewer");
    }
    catch(e) {                                                   
      this.activeXAvailable = false;
      // change the style to make all word html visible, not only inside the frame user had defined.
      var wordObj = this.wordObj();
      if (wordObj) {
        wordObj.style.height = "auto";
        wordObj.style.width = "auto";
        this.chrome.element.css({padding:"0px", margin: "0px", height: "auto", width: "auto" });
      }

      return;
    }

    this.activeXAvailable = true;
    this.initWord();
    // Dirty hack. Can we find modified event in .ocx?   
    this.intervalID = setInterval($sc.proxy(this._checkWordFieldModified, this), 1000);
    this.onSaveHandler = $sc.proxy(function() {
      var word = this.wordObj();
      if (word == null) {                            
        return;
      }

      if (!word.IsDirty && !word.fileWasOpened) {
        return;
      }
                                                   
      this.updateWordField();                         
    }, this);

    Sitecore.PageModes.PageEditor.onSave.observe(this.onSaveHandler);       
    this.adjustSize();
    this.base();
  },
  
  adjustSize: function() {
    var width = this.chrome.data.custom.editorWidth;
    var minHeight = this.chrome.data.custom.editorHeight;
    var maxHeight = this.chrome.data.custom.editorMaxHeight;
    if (width > 0 && minHeight > 0 && maxHeight > 0 && maxHeight > minHeight) {
       var wordBorderHeight = 60;
       if(maxHeight <= wordBorderHeight) {
         return;
       }
   
       var word = this.wordObj();
       if (word == null) {
         return;
       }

       var rawHTMLContainer = $sc("<span />").update(word.innerHTML).find(".scWordHtml");       
       if ( rawHTMLContainer.length < 0) return;

       height = this._getHeight(rawHTMLContainer.html(), width, maxHeight - wordBorderHeight) + wordBorderHeight;
   
       if(height <= minHeight) {
         return;
       }
   
       word.style.height = height + "px";
       var topPadding = parseInt(this.chrome.element.css("padding-top"));
       var bottomPadding = parseInt(this.chrome.element.css("padding-bottom"));
       this.chrome.element.css({height: height + topPadding + bottomPadding + "px"});
    }
  },

  handleMessage: function(message, params) {
    switch (message) {      
      case "chrome:field:word:mediainserted":
        this.insertMediaToWord(params.path, params.alt);
        break;
      case "chrome:field:word:insertLink":
        this.insertLinkToWord(params.link, params.text);
        break;
      case "chrome:field:word:toggletoolbar":
        this.toggleWordToolbar();
        break;
      default:
        this.base(message, params);
        break;      
    }
  },

  isEnabled: function() {
    return this.activeXAvailable && this.base();
  },

  initWord: function() {
    this._wordObj = null;
    var word = this.wordObj();
    if (word) {
      WordOCX_Initialize(word);
      setTimeout($sc.proxy(function() {       
        var obj = this.wordObj();
        if (obj == null) return;
        obj.CreateNew("Word.Document");
        obj.currentView = word.ActiveDocument.ActiveWindow.View.Type;        
        if (this.chrome.data.custom.downloadLink) {
          obj.Open(this.chrome.data.custom.downloadLink, "Word.Document");
        } 
        else {
          obj.CreateNew("Word.Document");
        }          
      }, this), 500);
    }
  },

  insertMediaToWord: function(imagePath, alt) {    
    var word = this.wordObj();
    if(word != null) {
      WordOCX_InsertPicture(word, imagePath, alt);  
    }
  },

  insertLinkToWord: function(link, defaultText) {
    var word = this.wordObj();
    if(word != null) {
      WordOCX_InsertLink(word, link, defaultText);  
    }
  },

  hasModifications: function() {
    var obj = this.wordObj();
    return obj && obj.IsOpened != 'undefined' && obj.IsOpened == true && obj.IsDirty == true; 
  },
  
  key: function() {
    return "word field";
  },

  layoutRoot: function() {    
    return this.chrome.element;
  },

  onDelete: function() {
    if (this.intervalID) {
      clearInterval(this.intervalID);
    }

    if (this.onSaveHandler) {
       Sitecore.PageModes.PageEditor.onSave.stopObserving(this.onSaveHandler); 
    }

    if (this._wordObj && this._wordObj.IsOpened) {
      this._wordObj.Close();
    }

    this._wordObj = null;
  },

  onHide: function() {
  },
  
  onMouseDown: function(e) {
  },   

  onShow: function() { 
  },

  toggleWordToolbar: function() {
    var word = this.wordObj();
    if(word != null) {
      WordOCX_ToggleToolbar(word);  
    }
  },

  updateWordField: function() {
     var word = this.wordObj();  
     if (word == null) {
      return;
     }

     var uploadLink = this.chrome.data.custom.uploadLink;
     if(uploadLink && (word.IsDirty || word.fileWasOpened)){
       WordOCX_UploadDocument(word, uploadLink, true);
     }

     var fieldValue = $sc(word).nextAll("input.scWordBlobValue");
     if (fieldValue.length > 0 && fieldValue[0].id.indexOf("flds_") == 0) {
        var blobID = this.chrome.data.custom.blobID;
        if (blobID) {
          fieldValue[0].value = blobID;
        }
     }
     else {
      console.error("word field value input was not found");
     }
  },

  wordObj: function() {        
    if (!this._wordObj) {
      this._wordObj = this.chrome.element.get(0).firstChild;
    }
    
    return this._wordObj;  
  },

  _checkWordFieldModified: function() {    
    if (this.hasModifications()) {
      Sitecore.PageModes.PageEditor.setModified(true);
    }
  },

  _getHeight: function(html, width, maxHeight) {
      if(html == "") {
        return -1;
      }

      var doc = document;

      var element = doc.createElement("span");
      element.innerHTML = html;
      element.firstChild.style.display = "";
  
      if(typeof(maxHeight) == 'undefined') {
        maxHeight = doc.body.offsetHeight;
      }
  
      
      var div = $sc("<div style=\"position:absolute;left:99999;top:99999;width:" + width + "px;height:" + maxHeight + "px\"></div>")
                .appendTo(doc.body);
          
      var span = doc.createElement("span");
      div.append(span);
 
      span.appendChild(element); 
  
      var height = span.offsetHeight;
      div.remove();
  
      if(height > maxHeight) {
        height = maxHeight;
      }
  
      return height;
   }
});﻿
Sitecore.PageModes.ChromeTypes.WrapperlessField = Sitecore.PageModes.ChromeTypes.Field.extend({ 
  controlId: function() {
    return this.chrome.openingMarker().attr("id").replace("_edit", "");
  },

  dataNode: function(domElement) {
    if (!domElement) {
      $sc.util().log("no dom element");
      return null;
    }

    if (domElement.is("code[type='text/sitecore'][chromeType='field']")) {
      return domElement;
    }
    
    return null;      
  },

  editControlCompleted: function(value, plainValue, preserveInnerContent) {
     this.fieldValue.val(typeof(plainValue) != "undefined" ? plainValue : value);
    if (!preserveInnerContent) {
      var htmlValue = value || "";
      // If a plain text node, wrap it in a span
      if ($sc.removeTags(htmlValue) === htmlValue) {
        htmlValue = "<span class='scTextWrapper'>" + htmlValue + "</span>";  
      }

      var newElements = $sc(htmlValue);
      this.chrome.update(newElements);
    }
    else {
      var targetCtl = this.chrome.element[0];
      var wrapper = document.createElement("span"); 
      wrapper.innerHTML = value;
      var sourceCtl = wrapper.firstChild;
      $sc.util().copyAttributes(sourceCtl, targetCtl);
      delete wrapper;                      
    }           
    
    this.chrome.reset();
    this.setModified();  
  },

  elements: function(domElement) {
    if (!domElement.is("code[type='text/sitecore'][chromeType='field']")) {
      console.error("Unexpected DOM element passed to WrapplessFiled for initialization:");
      $sc.util().log(domElement);
      throw "Failed to parse page editor field demarked by CODE tags";
    }  

    return this._getElementsBetweenScriptTags(domElement);
  },

  layoutRoot: function() {        
    return this.chrome.element;
  }
});﻿Sitecore.PageModes.ChromeTypes.PlaceholderSorting = Base.extend({
  constructor: function(placeholder, rendering) {
    this.placeholder = placeholder;
    this.rendering = rendering;
    this.handles = new Array();
    this.defaultLeftMarginValue = 20;
  },
  
  activate: function() {
    var sorting = this;
    
    var rendering = this.rendering;
    var renderings = this.placeholder.type.renderings();
    var sortableRenderingPosition = $sc.inArray(rendering, renderings);

    var position = 0;    
    var totalPositionCount = renderings.length + 1;

    if (renderings.length == 0) {
       sorting.insertSortingHandle('before', this.placeholder, position, totalPositionCount);
       return;
    }
    
    $sc.each(renderings, function() {
      if (this != rendering && (sortableRenderingPosition < 0 || sortableRenderingPosition != position - 1)) {
        sorting.insertSortingHandle('before', this, position, totalPositionCount);
      }

      position++;
    });

    // if sortable rendering is not the last rendering in the placeholder
    if (renderings.length > 0 && renderings[renderings.length - 1] != rendering) {
      sorting.insertSortingHandle('after', renderings[renderings.length - 1], position, totalPositionCount);
    }
    
    //this.handles[length-1].css("margin-top", -this.handles[length-1].outerHeight() + 2 + "px");
  },
  
  deactivate: function() {
    $sc.each(this.handles, function() {
      this.remove();
    });
  },
    
  insertSortingHandle: function(where, chrome, insertPosition, positionCount) {
    var title = Sitecore.PageModes.Texts.MoveToPositionInPlaceholder.replace("{0}", insertPosition + 1).replace("{1}", positionCount).replace("{2}", this.placeholder.displayName());
    var handle = $sc("<div class='scSortingHandle'></div>").attr("title", title);
    
    $sc("<div class='scInsertionHandleLeft scMoveToHere'> </div>").appendTo(handle);    
    $sc("<div class='scInsertionHandleCenter'></div>").append($sc("<span></span>").text(Sitecore.PageModes.Texts.MoveToHere)).appendTo(handle);    
    $sc("<div class='scInsertionHandleRight'></div>").appendTo(handle);
                
    handle.click($sc.proxy(function(e) {
      e.stop();
      Sitecore.PageModes.DesignManager.sortingEnd();
      Sitecore.PageModes.DesignManager.moveControlTo(this.rendering, this.placeholder, insertPosition);      
    }, this));
           
    var offset = chrome.position.offset();
    var top = left = "";

    if (where == 'before') {
      top = offset.top;
      left = offset.left;
    }
    else if (where == 'after') {
      var dimensions = chrome.position.dimensions();

      top = offset.top + dimensions.height;
      left = offset.left;
    }
    
    top = top + "px";
    left = left - Math.min(this.defaultLeftMarginValue, left) + "px";

    handle.css({ left: left, top: top});

    handle.appendTo(document.body);        
    this.handles.push(handle);
  }
});﻿Sitecore.PageModes.ChromeTypes.PlaceholderInsertion = Base.extend({
  constructor: function(placeholder) {
    this.placeholder = placeholder;
    this.handles = new Array();
    this.defaultLeftMarginValue = 20;

    this.command = $sc.first(this.placeholder.commands, function() { return this.click.indexOf("chrome:placeholder:addControl") > -1; });

    if (!this.command) {
      this.command = new Object();
      this.command.tooltip = Sitecore.PageModes.Texts.AddNewRenderingToPlaceholder;
      this.command.header = Sitecore.PageModes.Texts.AddToHere;
    }
  },

  activate: function() {
    var inserter = this;
    var position = 0;

    var renderings = this.placeholder.type.renderings();

    inserter.addTarget('top', this.placeholder, position);

    $sc.each(renderings, function() {
      position++;
      
      if (position == 1) {
        return;
      }

      inserter.addTarget('before', this, position - 1);
    });

    if (renderings.length > 0) {
      inserter.addTarget('after', renderings[renderings.length - 1], position);
    }
   
    var length = this.handles.length;
    if (length > 1) {        
      this.handles[length-1].css("margin-top", -this.handles[length-1].outerHeight() + 4 + "px");
    }
  },

  addTarget: function (where, chrome, insertPosition) {
    var handle = $sc("<div class='scInsertionHandle'></div>").attr("title", this.command.tooltip.replace("{0}", this.placeholder.displayName()));
    $sc("<div class='scInsertionHandleLeft scAddToHere'> </div>").appendTo(handle);  
    $sc("<div class='scInsertionHandleCenter'></div>").append($sc("<span></span>").text(this.command.header)).appendTo(handle);
    $sc("<div class='scInsertionHandleRight'></div>").appendTo(handle);
          
    handle.click($sc.proxy(function(e) {
      e.stop();
      Sitecore.PageModes.ChromeManager.setCommandSender(this.placeholder);
      this.placeholder.type.addControl(insertPosition);
    }, this));

    var offset = chrome.position.offset();
    var top = left = "";

    if (where == 'top') {
      top = offset.top;
      left = this.placeholder.position.offset().left;
    }
    else if (where == 'before') {
      top = offset.top;
      left = offset.left;
    }
    else if (where == 'after') {
      var dimensions = chrome.position.dimensions();

      top = offset.top + dimensions.height;
      left = offset.left;
    }
    
    top = top + "px";
    left = left - Math.min(this.defaultLeftMarginValue, left) + "px";

    handle.css({ top: top, left: left});

    handle.appendTo(document.body);    
    this.handles.push(handle);
  },

  deactivate: function() {
    $sc.each(this.handles, function() {
      this.remove();
    });
  }
});﻿Sitecore.PageModes.MoveControlFrame = Sitecore.PageModes.ChromeFrame.extend({
  constructor: function() {
    this.base();
    this.bgVerticalPatternSize = {height: 3, width: 8};
    this.bgHorizontalPatternSize = {height: 8, width: 3};       
  },

  horizontalSideClassName: function() {
    return "scMoveControlSideHorizontal";
  },

  verticalSideClassName: function() {
    return "scMoveControlSideVertical";
  },

  calculateSideLengths: function(dimensions) {
    var horizontal = dimensions.width;
    var vertical = dimensions.height - 2 * this.bgHorizontalPatternSize.height;    
    return { horizontal: horizontal, vertical: vertical};    
  },    

  showSides: function(chrome) {    
    var offset = chrome.position.offset();
    var dimensions = chrome.position.dimensions();
            
    var sideLengths = this.calculateSideLengths(dimensions);
    
    var horizontalSideLengthLeft = Math.ceil(sideLengths.horizontal / 2);
    var horizontalSideLengthRight = Math.floor(sideLengths.horizontal / 2);
            
    var verticalSideLengthTop = Math.ceil(sideLengths.vertical / 2);
    var verticalSideLengthBottom = Math.floor(sideLengths.vertical / 2);
    
    var topHorizontalY = offset.top;
    var bottomHorizontalY = offset.top + dimensions.height - this.bgHorizontalPatternSize.height;

    var leftHorizontalX = offset.left;    
    var rightHorizontalX = leftHorizontalX + horizontalSideLengthLeft;

    var verticalRightX = rightHorizontalX + horizontalSideLengthRight - this.bgVerticalPatternSize.width;
    var verticalLeftX = offset.left;

    var verticalTopY = offset.top + this.bgHorizontalPatternSize.height;   
    var verticalBottomY = verticalTopY + verticalSideLengthTop; 
    
       
    this.setSideStyle(this.topLeftHorizontal, topHorizontalY, leftHorizontalX, horizontalSideLengthLeft);    
    this.setSideStyle(this.topRightHorizontal, topHorizontalY, rightHorizontalX, horizontalSideLengthRight);

    this.setSideStyle(this.rightTopVertical, verticalTopY, verticalRightX, verticalSideLengthTop);    
    this.setSideStyle(this.rightBottomVertical, verticalBottomY, verticalRightX, verticalSideLengthBottom);

    this.setSideStyle(this.bottomLeftHorizontal, bottomHorizontalY, leftHorizontalX, horizontalSideLengthLeft);    
    this.setSideStyle(this.bottomRightHorizontal, bottomHorizontalY, rightHorizontalX, horizontalSideLengthRight);

    this.setSideStyle(this.leftTopVertical, verticalTopY, verticalLeftX, verticalSideLengthTop);    
    this.setSideStyle(this.leftBottomVertical, verticalBottomY, verticalLeftX, verticalSideLengthBottom);

    this.base();
  },

  createSides: function() {
    this.topLeftHorizontal = $sc("<div></div>").addClass(this.horizontalSideClassName() + " scLeftPart scTopSide");    
    this.topRightHorizontal = $sc("<div></div>").addClass(this.horizontalSideClassName() + " scRightPart scTopSide");

    this.rightTopVertical = $sc("<div></div>").addClass(this.verticalSideClassName() + " scTopPart scRightSide");    
    this.rightBottomVertical = $sc("<div></div>").addClass(this.verticalSideClassName() + " scBottomPart scRightSide");
    
    this.bottomLeftHorizontal = $sc("<div></div>").addClass(this.horizontalSideClassName() + " scLeftPart scBottomSide");    
    this.bottomRightHorizontal = $sc("<div></div>").addClass(this.horizontalSideClassName() + " scRightPart scBottomSide");

    this.leftTopVertical = $sc("<div></div>").addClass(this.verticalSideClassName() + " scTopPart scLeftSide");    
    this.leftBottomVertical = $sc("<div></div>").addClass(this.verticalSideClassName() + " scBottomPart scLeftSide");

    sides = new Array();
    this.sides = sides;

    sides.push(this.topLeftHorizontal);    
    sides.push(this.topRightHorizontal);

    sides.push(this.bottomLeftHorizontal);    
    sides.push(this.bottomRightHorizontal);

    sides.push(this.rightTopVertical);    
    sides.push(this.rightBottomVertical);

    sides.push(this.leftTopVertical);    
    sides.push(this.leftBottomVertical);
    
    this.base();
  }
});﻿if (typeof(Sitecore.PageModes) == "undefined") Sitecore.PageModes = new Object();

Sitecore.PageModes.ChromeHighlightManager = new function() {
  this.interval = 1000;
  this._intervalID = null;
  this._shouldHighlightChromes = false;
  this._updatePlanned = false;
  
  this.activate = function() {
    this._shouldHighlightChromes = true;
    this._updatePlanned = true;
    this._stopped = false;
    this._intervalID = setInterval($sc.proxy(this._process, this), this.interval);
  };

  this.deactivate = function() {
    this._shouldHighlightChromes = false;
    this.highlightChromes();
    if (this._intervalID != null) {
      clearInterval(this.intervalID);
    }

    this._intervalID = null;
  }; 
  
  this.highlightChromes = function() {   
    var updated = true;
    var length = Sitecore.PageModes.ChromeManager.chromes().length;
    for (var i = 0; i < length; i++) {   
      if (this._stopped) {
        updated = false;
        return;
      }

      var chrome = Sitecore.PageModes.ChromeManager.chromes()[i];
      if (this.isHighlightActive(chrome)) {
        chrome.showHighlight();
      }
      else {
        chrome.hideHighlight();
      }
    }
    
    if (updated) {
      this._updatePlanned = false;  
    }
  };
  
  // Defines if the specified chrome should be highlighted.
  this.isHighlightActive = function(chrome) {
    return this._shouldHighlightChromes && chrome.isEnabled() && !chrome.isFake();
  };

  this.planUpdate = function() {
    this._updatePlanned = true;
  };

  this.resume = function() {
    this._stopped = false;
    this._process();
  };
  
  this.stop = function() {
     this._stopped = true;
  };
  
  this._process = function() {    
    if (this._updatePlanned && !this._stopped) {      
      this.highlightChromes();      
    }
  };    
};﻿if (typeof(Sitecore.PageModes) == "undefined") {
  Sitecore.PageModes = new Object();
}

/**
* @class Represents an overlay for chrome during it's update via Ajax
*/
Sitecore.PageModes.ChromeOverlay = new function() {
  this.overlay = null;
  this.animationStartDelay = 0;
  this.opacity = 0.5;
  this.animationDuration = 100;
  this.overlayVisibleDuration = 150;     
  /**
  * @description Show the overlay  
  * @param {Sitecore.PageModes.Chrome} currentChrome The chrome to show the overlay for. @see Sitecore.PageModes.Chrome
  */
  this.showOverlay = function (currentChrome) {
    var chrome = currentChrome;
    if (!chrome || !chrome.position) {
      return;
    }

    // When condition activation is initiated form a chrome the containing rendering should be overlayed
    if (chrome.key() == "field") {
       var r = chrome.type.parentRendering();
       if (!r) {
          return;
       }

       chrome = r;
    }

    var dimensions = chrome.position.dimensions();
    if (dimensions.width <= 0 || dimensions.height <= 0) {
      return;
    } 

    var offset = chrome.position.offset();    
    if (!this.overlay) {
      this.overlay = $sc("<div class='scChromeOverlay'></div>")
                    .click(function(e) {e.stop();})
                    .hide()
                    .appendTo(document.body);
    }

    this.overlay.stop(true);    
    this.overlay.css(
    {
      top: offset.top + "px",
      left: offset.left + "px",
      height: dimensions.height + "px",
      width: dimensions.width + "px",
      opacity: 0.0
    });
        
    this.overlay.show()
                .delay(this.animationStartDelay)
                .fadeTo(this.animationDuration, this.opacity)
                .delay(this.overlayVisibleDuration);        
  };

  /**
  * @description Hides the overlay
  */
  this.hideOverlay = function() {
    var overlay = this.overlay;
    if (overlay) {
      this.overlay.fadeTo(this.animationDuration, 0.0, function() {overlay.hide();});
    }
  };
  
  /**
   @description Gets the time need for voerlay to bw shown
   @returns {Number} Time in ms
  */
  this.getShowingDuration = function() {
    return this.animationStartDelay + this.animationDuration + this.overlayVisibleDuration;
  };  
};﻿if (typeof(Sitecore) == "undefined") {
  Sitecore = {};
}

(function(jQuery) {
  Sitecore.OutOfFrameGallery = new function() {
  this.frameName = "scOutOfFrameGalleryFrame";
  this._senderId = null,
  this._senderFrameId = null;
  this.frame = function() {
    if (!this._frame) {     
      this._frame = this.createFrameElement();
      this._overlay = this.createOverlayElement();                      
      
      this._attachEventHandler(this._frame, "blur", function() {      
        Sitecore.OutOfFrameGallery.hide();
      });
      
       this._attachEventHandler(this._frame, "load", function() {
        var overlay =  Sitecore.OutOfFrameGallery._overlay;
        if (overlay) {
          overlay.style.display = "none";
        }
      });           
    }
    
    return this._frame;
  };

  this.createFrameElement = function() {
    var element = jQuery("<iframe style=\"box-shadow: 3px 3px 3px 0 rgba(176,176,176, 0.5)\" name='" + 
                    this.frameName + "' id='" + this.frameName +
                     "' src='about:blank'  frameborder='0' scrolling='no' />")
                    .css({zIndex: "99999", position: "fixed"})
                    .hide()                    
                    .appendTo(document.body);
        
    return element.get(0);
  };

  this.createOverlayElement = function() {
     var element =  jQuery("<div>")
                      .css({background: "#fafafa url('/sitecore/shell/Themes/Standard/Images/sitecore-loader24.gif') no-repeat center center", position: "fixed", zIndex: 1000000})
                      .hide()
                      .appendTo(document.body);
     
     return element.get(0);                   
  };

  this.open = function(sender, destination, dimensions, params, httpVerb) {
    if (!sender) {
      return;
    }
    
    this._senderId = sender.id;        
    var gallery = this.getGalleryElement(sender);
    var elementAttachTo = gallery || sender;
    if (!elementAttachTo) {
      return;
    }

    var frame = this.frame();
    frame.src = 'about:blank';
    var url = "/sitecore/shell/default.aspx?xmlcontrol=" + destination;
    var offset = this._getCumulativeOffset(elementAttachTo);
    var doc = elementAttachTo.ownerDocument;    
    if (doc != window.document) {
      // The sender DOM node is inside a frame
      var iframe = this._getElementsFrame(elementAttachTo);
      if (iframe) {
        var frameOffset = this._getCumulativeOffset(iframe);
        offset.top += frameOffset.top;
        offset.left += frameOffset.left;
        if (iframe.id) {
          url += "&senderframe=" + encodeURIComponent(iframe.id);
          this._senderFrameId = iframe.id;
        }
        }
      } 

    this._applySenderStyles();

    // If Gallery attach to top. Otherwise bottom
    if (!gallery) {
      offset.top += elementAttachTo.offsetHeight;
    }
                    
    var frame = this.frame();
    if (typeof(dimensions.height) != "undefined") {
      frame.height = parseInt(dimensions.height) + "px";
      if (jQuery.browser.msie) {
        frame.style.width = "";      
        frame.style.height = "";
    }
    }

    if (typeof(dimensions.width) != "undefined") {
      frame.width = parseInt(dimensions.width) + "px";
      if (jQuery.browser.msie) {
        frame.style.width = "";
    }
    }

    frame.setAttribute("data-gallery-name", destination);    
    this.hide();    
    if (httpVerb === "POST") {            
      var form = this.getFormElement(params);
      form.setAttribute("action", url);               
      this.show(offset);
      form.submit();
      form.parentNode.removeChild(form);                     
    }
    else
    {
      var serializedParameters = this._serialize(params);
      if (serializedParameters) {
        url += "&" + serializedParameters;
      }

      frame.src = url;
      this.show(offset);
    }
  };

  this.getFormElement = function (params) {     
     var form = jQuery("<form style='display:none' method='post'></form>)").attr("target", this.frameName);
     if (params) {              
      for( var n in params) {
        jQuery("<input type='hidden' />").attr("name", n).val(params[n]).appendTo(form);                
      }
     }
               
     form.appendTo(document.body);
     return form.get(0);
  };

  this.getGalleryElement = function(element) {
    return jQuery(element).closest(".scRibbonGallery")[0];    
  };

  this.hide = function() {
    if (!this.isVisible) {
      return;
    }

    try {
      this._clearSenderStyles();
    }
    catch(err) {
      window.console.log("Clearing sender styles failed ", err);      
    }

    this._clearPersistedSender();
    var frame = this.frame();        
    frame.style.display = "none";
    if (jQuery.browser.msie) {
      frame.style.height = "0";
    }

    if (this._overlay) {
      this._overlay.style.display = "none";
    }

    this.isVisible = false;
  };

  this.show = function(position) {    
    var frame = this.frame();    
    frame.style.top = position.top + "px";
    frame.style.left = position.left + "px";        
    frame.style.display = "";       
    if (this._overlay) {    
      this._overlay.style.top = frame.style.top;
      this._overlay.style.left = frame.style.left;
      this._overlay.style.width = parseInt(frame.width) + "px";
      this._overlay.style.height = parseInt(frame.height) + "px";     
      this._overlay.style.display = "";       
    }

    this.isVisible = true;     
  };
  
  this._applySenderStyles = function() {
    var sender = this._getPersistedSender();
    if (!sender) {
      return;
    }

    var $sender = jQuery(sender);    
    if ($sender.is(".scRibbonToolbarLargeGalleryButton")) {
      $sender.addClass("scRibbonToolbarLargeGalleryButtonDown");
    }     
  };

  this._attachEventHandler = function(element, eventName, handler) {
    jQuery(element).bind(eventName, handler);
  };

  this._clearPersistedSender = function() {
    this._senderId = null;
    this._senderFrameId = null;
  };

  this._clearSenderStyles = function() {
    var sender = this._getPersistedSender();
    if (!sender) {
      return;
    }    
    
    jQuery(sender).removeClass("scRibbonToolbarLargeGalleryButtonDown");    
  };

  this._getCumulativeOffset = function(element) {
    var valueT = 0, valueL = 0;
    if (element.parentNode) {
      do {
        valueT += element.offsetTop  || 0;
        valueL += element.offsetLeft || 0;
        element = element.offsetParent;
      } while (element);
    }

    return {left:valueL, top: valueT}; 
  };

  this._getElementsFrame = function (element) {
    var doc = element.ownerDocument;
    var iframes = document.getElementsByTagName("iframe");
    for (var i = 0; i < iframes.length; i++) {
      var frameDoc = iframes[i].contentDocument || iframes[i].contentWindow.document;
      if (frameDoc == doc) {
        return iframes[i];
      }
    }

    return null;
  };

  this._getPersistedSender = function() {
    if (!this._senderId) {
      return;
    }

    var doc = window.document;
    if (this._senderFrameId) {
      var senderFrame = doc.getElementById(this._senderFrameId);
      if (!senderFrame) {
        return;
      }

      doc = senderFrame.contentDocument || senderFrame.contentWindow.document;
    }

    if (!doc) {
      return;
    }

    return doc.getElementById(this._senderId);
  };

  this._serialize = function (object) {
    if (!object) {
      return null;
    }

    if (Object.prototype.toString.call(object).toLowerCase() === "[object string]") {
      return object;
    }

    var result = "";
    for (var n in object) { 
      result += "&" + encodeURIComponent(n);
      result += "=" + encodeURIComponent(object[n]);
    }

    return result.length > 1 ? result.substr(1): null;
  };
};
})($sc || jQuery);if (typeof Sitecore == "undefined") {
  Sitecore = new Object();
}

Sitecore.WebEdit = new function() {
  this.loaded = false;
  this.mouseMoveObservers = new Array();
  this.modified = false;
  this.selectedRendering = "";  
}

Sitecore.WebEdit.disableContentSelecting = function() {
  return Sitecore.WebEditSettings.disableContentSelecting;
}
/* -- FIELD VALUES --*/

Sitecore.WebEdit._getFieldValueContainer = function(itemUri, fieldID) {
  Sitecore.PageModes.ChromeManager.getFieldValueContainer(itemUri, fieldID);
}

Sitecore.WebEdit.getFieldValue = function(itemUri, fieldID) {
  Sitecore.PageModes.ChromeManager.getFieldValue(itemUri, fieldID);
}

Sitecore.WebEdit.setFieldValue = function(itemUri, fieldID, value) { 
  Sitecore.PageModes.ChromeManager.setFieldValue(itemUri, fieldID, value);
}

Sitecore.ItemUri = function(id, language, version, revision) {
  this.id = id;
  this.language = language;
  this.version = version;
  this.revision = revision;
}

/* -- END FIELD VALUES --*/

//For backward compatibility
Sitecore.WebEdit.editControl = function (itemid, language, version, fieldid, controlid, message) {
  var params = new Object();
  params.itemId = itemid;
  params.language = language;
  params.version = version;
  params.fieldId = fieldid;
  params.controlId = controlid;
  params.command = message;
  Sitecore.PageModes.ChromeManager.handleMessage("chrome:field:editcontrol", params);
  return false;
}

Sitecore.WebEdit.postRequest = function(request, async) {
  var ctl = document.getElementById("scWebEditRibbon");
  
  if (ctl != null) {
    async = (async == null ? false : async)
  
    ctl.contentWindow.scForm.postRequest("", "", "", request, null, async);
  }
}

Sitecore.WebEdit.quirksMode = function() {
  return typeof(document.compatMode != "undefined") && document.compatMode == "BackCompat";
}

Sitecore.WebEdit.close = function() {
  var href = window.location.href;
  
  href = href.replace("sc_ce=1", "sc_ce=0");
  
  window.location.href = href;
}

Sitecore.WebEdit.changeContentEditorSize = function(element, evt, sign) {
  var iframe = element.parentNode.previousSibling.previousSibling;
  
  var height = iframe.offsetHeight - 48 * sign;
  
  if (height < 200) {
    height = 200;
  }
  
  iframe.style.height = "" + height + "px";
  
  this.setCookie("sitecore_webedit_contenteditorheight", height);
  
  return false;
}

Sitecore.WebEdit.setCookie = function(name, value, expires, path, domain, secure) {
  if (expires == null) {
    expires = new Date();
    expires.setMonth(expires.getMonth() + 3);
  }
  
  if (path == null) {
    path = "/";
  }

  document.cookie = name + "=" + escape(value) +
    (expires ? "; expires=" + expires.toGMTString() : "") +
    (path ? "; path=" + path : "") +
    (domain ? "; domain=" + domain : "") +
    (secure ? "; secure" : "");
}

/* LAYOUT DEFINITION */

Sitecore.WebEdit.showTooltip = function(element, evt) {
  var tooltip = $(element.lastChild);
  var x = Event.pointerX(evt);
  var y = Event.pointerY(evt);
  
  if (evt.type == "mouseover") {
    if (tooltip.style.display == "none") {
      clearTimeout(this.tooltipTimer);
      
      this.tooltipTimer = setTimeout(function() {
        var html = tooltip.innerHTML;
        
        if (html == "") {
          return;
        }
      
        var t = $("scCurrentTooltip");
        if (t == null) {
          t = new Element("div", { "id":"scCurrentTooltip", "class": "scPalettePlaceholderTooltip", "style": "display:none" });
          document.body.appendChild(t);
        }
        
        t.innerHTML = html;
      
        t.style.left = x + "px";
        t.style.top = y + "px";
        t.style.display = "";
      }, 450);
    }
  }
  else {
    clearTimeout(this.tooltipTimer);
    var t = $("scCurrentTooltip");
    if (t != null) {
      t.style.display = "none";
    }
  }
};
