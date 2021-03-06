window.rsConf || (window.rsConf = {});
window.rsConf.ui || (window.rsConf.ui = {});
window.rsConf.general || (window.rsConf.general = {});
window.rsConf.settings || (window.rsConf.settings = {});
window.rsConf.phrases || (window.rsConf.phrases = {});
window.rsConf.cb || (window.rsConf.cb = {});
window.rsConf.toggle = {
  customerParams: {
    customerid: "7171",
    lang: ["en_us", "es_es"],
    voice: null,
    readid: null,
    url: null
  },
  addPreserve: [""],
  addSkip: [""],
  readids: [""],
  useIcons: !0
};
window.rsConf.ui.rsbtnClass = "rsbtn_player";
window.rsConf.ui.popupplayer = window.rsConf.ui.player = ['<a class="rsbtn_pause rsimg rspart" href="javascript:void(0);" title="Pause"><i class="icon icon-pause"></i><span class="rsbtn_btnlabel">Pause</span></a>'];
window.rsConf.general.usePost = !0;
window.rsConf.settings.hlicon = "iconon";
window.rsConf.phrases.en_us = {
  readingassist: "Reading assist",
  activate: "Activate ReadSpeaker",
  deactivate: "Deactivate ReadSpeaker",
  listentoselection: "Listen to the selected text",
  listenwith: "Activate/Deactivate ReadSpeaker",
  moveplayer: "Move player",
  pleaseselect: "Please select the text you want to listen to.",
  readabout: "Read about the Listening-service.",
  textupup: "Change to Large font",
  textup: "Change to Medium font",
  textdown: "Change to Small font",
  lowspeed: "Slow speed.",
  medspeed: "Medium speed.",
  fastspeed: "Fast speed.",
  toggleclose: "Close the toolbar.",
  speechenabled: 'Speech-enabled by <a href="http://www.readspeaker.com/?ref=' + encodeURIComponent(document.location.href) + '" target="_blank">ReadSpeaker</a>',
  off: "Off",
  on: "On",
  slow: "Slow",
  medium: "Med",
  fast: "Fast",
  textsize: "Text Size",
  info: "Info"
};
window.rsConf.phrases.es_es = {
  readingassist: "Lectura Asistida",
  activate: "Activar ReadSpeaker.",
  deactivate: "Desactivar ReadSpeaker.",
  listentoselection: "Escuchar el texto seleccionado.",
  listenwith: "Activar/Desactivar ReadSpeaker.",
  moveplayer: "Desplazar reproductor.",
  pleaseselect: "Por favor, seleccione el texto que desea escuchar.",
  readabout: "Lea acerca del servicio de Escucha.",
  textupup: decodeURIComponent("Cambio%20del%20tama%C3%B1o%20de%20fuente%3A%20grande"),
  textup: decodeURIComponent("Cambio%20del%20tama%C3%B1o%20de%20fuente%3A%20medio"),
  textdown: decodeURIComponent("Cambio%20del%20tama%C3%B1o%20de%20fuente%3A%20peque%C3%B1o"),
  lowspeed: "Velocidad lenta.",
  medspeed: "Velocidad media.",
  fastspeed: "Velocidad alta.",
  toggleclose: "Cerrar la barra de herramientas.",
  speechenabled: window.rsConf.phrases.en_us.speechenabled,
  off: "Off",
  on: "On",
  slow: "Lento",
  medium: "Mediano",
  fast: decodeURIComponent("R%C3%A1pido"),
  textsize: decodeURIComponent("Tama%C3%B1o%20del%20Texto"),
  info: "Ayuda"
};
ReadSpeaker.Toggle = function() {
  var l = {
    buttonHref: "",
    defaultSetting: "rsoff",
    readids: [],
    rsbtnClass: "rsbtn_player",
    addPreserve: [],
    addSkip: [],
    useIcons: !1,
    isFixed: !0,
    insertToggleInside: "",
    insertToggleBefore: "",
    togglePosition: {
      top: null,
      right: null,
      bottom: null,
      left: null
    },
    playerPosition: {
      top: null,
      right: null,
      bottom: null,
      left: null
    }
  },
      e = null,
      i = null,
      p = !1,
      t = !1,
      v = !1,
      q = window,
      w = 0,
      B = '<a href="JavaScript: void(0);" title="%MOVEPLAYER%" class="rsbtn_move"><i class="icon icon-draggable"></i><span class="rsbtn_label">%MOVEPLAYER%</span></a>,<div class="rsStatusIndicator"><i class="icon icon-circle"></i></div>,<div class="rsToggle_close rsToggle_close_left"><span class="rsbtn_label">%READINGASSIST%</span></div>,<div class="rsToggleButton">,\t<div class="rsActivatorHolder rsToggleContainer">,\t\t<a href="JavaScript: void(0)" class="rsbtn_toggle rsActive rsimg" title="%ACTIVATE%">,\t\t\t<span class="rsTopFold">,\t\t\t\t<span class="rsSwitcher">,\t\t\t\t\t<span class="rsSwitchHandle"></span>,\t\t\t\t</span>,\t\t\t</span>,\t\t\t<span class="rsBottomFold">,\t\t\t\t<span class="rsbtn_title rsbtn_title_left">%OFF%</span>,\t\t\t\t<span class="rsbtn_title rsbtn_title_right">%ON%</span>,\t\t\t</span>,\t\t\t<span class="rsbtn_label">%DEACTIVATE%</span>,\t\t</a>,\t</div>,\t<div class="rsSpeedHolder rsToggleContainer">,\t\t<span class="rsTopFold">,\t\t\t<a class="rsLowSpd" title="%LOWSPEED%" href="javascript:void(0)"><span class="rsbtn_pill">%SLOW%</span></a>,\t\t\t<a class="rsMedSpd" title="%MEDSPEED%" href="javascript:void(0)"><span class="rsbtn_pill">%MEDIUM%</span></a>,\t\t\t<a class="rsHigSpd" title="%FASTSPEED%" href="javascript:void(0)"><span class="rsbtn_pill">%FAST%</span></a>,\t\t</span>,\t\t<span class="rsBottomFold">,\t\t\t<span class="rsbtn_title">%SPEED%</span>,\t\t</span>,\t</div>,\t<div class="rsTxtHolder rsToggleContainer">,\t\t<span class="rsTopFold">,\t\t\t<a class="rsTxtDec" title="%TEXTDOWN%" href="javascript:void(0)">,\t\t\t\t<span class="rsbtn_pill">,\t\t\t\t\t<span class="rsTxtSmall">A</span>,\t\t\t\t</span>,\t\t\t\t<span class="rsbtn_label">%TEXTDOWN%</span>,\t\t\t</a>,\t\t\t<a class="rsTxtInc" title="%TEXTUP%" href="javascript:void(0)">,\t\t\t\t<span class="rsbtn_pill">,\t\t\t\t\t<span class="rsTxtMed">A</span>,\t\t\t\t</span>,\t\t\t\t<span class="rsbtn_label">%TEXTUP%</span>,\t\t\t</a>,\t\t\t<a class="rsTxtIncLarge" title="%TEXTUPUP%" href="javascript:void(0)">,\t\t\t\t<span class="rsbtn_pill">,\t\t\t\t\t<span class="rsTxtBig">A</span>,\t\t\t\t</span>,\t\t\t\t<span class="rsbtn_label">%TEXTUP%</span>,\t\t\t</a>,\t\t</span>,\t\t<span class="rsBottomFold">,\t\t\t<span class="rsbtn_title">%TEXTSIZE%</span>,\t\t</span>,\t</div>,\t<div class="rsInfoHolder rsToggleContainer">,\t\t<span class="rsTopFold">,\t\t\t<a href="JavaScript: void(0)" class="rsbtn_about" title="%READABOUT%"><span class="rsbtn_pill">?</span></a>,\t\t</span>,\t\t<span class="rsBottomFold">,\t\t\t<span class="rsbtn_title">%INFO%</span>,\t\t</span>,\t</div>,</div>,<a href="javascript: void(0);" class="rsToggle_close rsToggle_close_right" title="%TOGGLECLOSE%"><span class="rsbtn_label">%TOGGLECLOSE%</span></a>'.split(","),
      m = ['<a class="rsbtn_play" accesskey="L" title="%LISTEN%" href="">', '\t<span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">%LISTEN%<span></span></span></span>', '\t<span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>', "</a>"],
      k = function(a) {
      return "undefined" !== typeof rspkr.cfg.item("toggle." + a) ? rspkr.cfg.item("toggle." + a) : l.hasOwnProperty(a) ? l[a] : ""
      },
      x = function() {
      null === e && (e = $rs.get("#rsToggle"));
      return e
      },
      y = function() {
      return i = $rs.get("." + l.rsbtnClass)
      },
      n = {
      _toggle: null,
      _listenwith: null,
      _get: function(a, c) {
        var b, a = "_" + a;
        b = x() ? this[a] && 0 < this[a].length ? this[a] : this[a] = $rs.findIn(x(), c) : null;
        return b == [] ? null : b
      },
      toggle: function() {
        return this._get("toggle", ".rsbtn_toggle")
      },
      listenwith: function() {
        return this._get("listenwith", ".rsbtn_icon")
      },
      close: function() {
        return this._get("toggle", "#rsToggle .rsToggle_close")
      }
      },
      C = function(a) {
      var c = document.location.protocol + "//app.readspeaker.com/cgi-bin/rsent?",
          b = !0,
          d = k("customerParams"),
          e;
      for (e in d) null !== d[e] && "readid" !== e && (!0 === b ? (c += e + "=" + d[e], b = !1) : c += "&" + e + "=" + d[e]);
      a.id ? c += "&readid=" + a.id : (b = function() {
        return Math.floor(65536 * (1 + Math.random())).toString(16).substring(1)
      }, b = [b(), b(), "-", b(), "-", b(), "-", b(), "-", b(), b(), b()].join(""), $rs.setAttr(a, "id", b), c += "&readid=" + b);
      return c += "&url=" + encodeURIComponent(document.location.href)
      },
      r = function() {
      p = !1;
      i = q.document.createElement("div");
      i.id = "readspeaker_button";
      var a = k("customerParams"),
          c = "en_us";
      "" !== a && a.hasOwnProperty("lang") && (c = a.lang);
      for (a = 0; a < m.length; a++) m[a] = m[a].replace("%LISTEN%", rspkr.cfg.getPhrase("listen", c, "en_us")), m[a] = m[a].replace("%MOVEPLAYER%", rspkr.cfg.getPhrase("moveplayer", c, "en_us")), m[a] = m[a].replace("%LISTENTOSELECTED%", rspkr.cfg.getPhrase("listentoselection", c, "en_us"));
      i.innerHTML = m.join("\n");
      $rs.addClass(i, k("rsbtnClass") + " rs_skip rs_preserve");
      "iconoff" == rspkr.cfg.item("settings.hlicon") && $rs.addClass(i, "rshidden");
      c = $rs.get(".rs_read_this");
      c = $rs.isArray(c) ? c : [c];
      for (a = 0; a < c.length; a++) if (!(0 < ($rs.isArray($rs.findIn(c[a], "." + l.rsbtnClass)) ? $rs.findIn(c[a], "." + l.rsbtnClass) : [$rs.findIn(c[a], "." + l.rsbtnClass)]).length)) {
        var b = $rs.findIn(i, ".rsbtn_play");
        $rs.setAttr(b, "href", C(c[a]));
        $rs.setAttr(i, "id", "readspeaker_button" + w);
        w++;
        c[a].childNodes[0] ? c[a].insertBefore(i.cloneNode(!0), c[a].childNodes[0]) : c[a].appendChild(i.cloneNode(!0))
      }
      rspkr.ui.addClickEvents()
      },
      u = function(a, c) {
      c = c || !0;
      if ((a = a || k("defaultSetting")) && "rson" === a || "" === a) {
        t || r();
        $rs.removeClass(n.toggle(), "rsActive");
        $rs.addClass(n.toggle(), "rsActive");
        $rs.addClass(e, "rsActive");
        var b = k("customerParams"),
            d = "en_us";
        "" !== b && b.hasOwnProperty("lang") && (d = b.lang);
        b = rspkr.cfg.getPhrase("deactivate", d, "en_us");
        $rs.setAttr(n.toggle(), "title", b);
        b = y();
        b = $rs.isArray(b) ? b : [b];
        for (d = 0; d < b.length; d++) $rs.removeClass(b[d], "rshidden");
        rspkr.cfg.item("settings.hlicon", "iconon")
      } else if (a && "rsoff" === a) {
        $rs.removeClass(n.toggle(), "rsActive");
        $rs.removeClass(e, "rsActive");
        b = k("customerParams");
        d = "en_us";
        "" !== b && b.hasOwnProperty("lang") && (d = b.lang);
        b = rspkr.cfg.getPhrase("activate", d, "en_us");
        $rs.setAttr(n.toggle(), "title", b);
        b = y();
        b = $rs.isArray(b) ? b : [b];
        for (d = 0; d < b.length; d++) $rs.addClass(b[d], "rshidden");
        rspkr.ui.getActivePlayer() && rspkr.ui.getActivePlayer().stop();
        rspkr.cfg.item("settings.hlicon", "iconoff")
      }!0 === c && z("rstoggle", a)
      },
      A = function(a) {
      return rspkr.Common.cookie.readKey(rspkr.pub.Config.item("general.cookieName"), a) || ""
      },
      z = function(a, c) {
      rspkr.c.cookie.updateKey(rspkr.cfg.item("general.cookieName"), a, c)
      };
  return {
    createPlayer: function() {
      r()
    },
    init: function() {
      t = !1;
      ReadSpeaker && ReadSpeaker.windowRef && (q = ReadSpeaker.windowRef);
      var a = rspkr.c.data.browser;
      if (a && (/iphone|ipad|ios|android/i.test(a.OS) || "android" == a.name.toLowerCase())) v = !0;
      var a = {
        ar_ar: ["ar-SA"],
        en_us: ["en"],
        en_uk: ["en-GB"],
        pt_br: ["pt-BR"],
        zh_cn: ["zh-CN"],
        da_dk: ["da-DK"],
        nl_nl: ["nl-NL"],
        fr_fr: ["fr-FR"],
        de_de: ["de-DE"],
        it_it: ["it-IT"],
        ja_jp: ["ja-JP"],
        ko_ko: ["ko-KO"],
        ru_ru: ["ru-RU"],
        es_es: ["es-ES", "es"],
        sv_se: ["sv-SE"],
        tr_tr: ["tr-TR"],
        cy_cy: ["cy-CY"]
      },
          c = q.document.documentElement.lang,
          b = k("customerParams"),
          d = "en_us";
      "" !== b && b.hasOwnProperty("lang") && (d = b.lang, d = $rs.isArray(d) ? d : [d]);
      var i = null;
      "" !== b && b.hasOwnProperty("voice") && (i = b.voice, $rs.isArray(i));
      var i = !1,
          g;
      for (g in a) {
        if (a.hasOwnProperty(g)) for (var h = a[g], h = $rs.isArray(h) ? h : [h], l = 0; l < h.length; l++) {
          if (h[l] == c) for (var s = 0; s < d.length; s++) if (g == d[s]) {
            d = d[s];
            i = !0;
            break
          }
          if (i) break
        }
        if (i) break
      }
      i || (d = $rs.isArray(h) ? d[0] : d);
      b.lang = d;
      rspkr.c.data.params.lang = d;
      r();
      if (!document.getElementById("rsToggle")) {
        g = "moveplayer readingassist activate deactivate lowspeed medspeed fastspeed textdown textup textupup readabout toggleclose off on slow medium fast speed textsize info".split(" ");
        h = B.join("\n");
        c = 0;
        for (b = g.length; c < b; c++) a = RegExp("%" + g[c] + "%", "gi"), h = h.replace(a, rspkr.cfg.getPhrase(g[c], j, "en_us"));
        e = document.createElement("div");
        e.id = "rsToggle";
        e.className = "rs_skip rs_preserve rsClosed";
        e.innerHTML = h;
        j = document.body;
        j.appendChild(e);
        j || document.body.appendChild(e);
        !0 === k("useIcons") && (e.className += " rsIcons");
        !0 === k("isFixed") && $rs.css(e, "position", "fixed");
        var j = k("togglePosition"),
            f;
        for (f in j) j.hasOwnProperty(f) && null !== j[f] && $rs.css(e, f, j[f]);
        f = k("customerParams");
        var j = "en_us";
        "" !== f && f.hasOwnProperty("lang") && (j = f.lang);
        f = rspkr.cfg.getPhrase("listenwith", j, "en_us");
        n.listenwith() && $rs.setAttr(n.listenwith(), "title", f);
        $rs.regEvent(n.toggle(), "mousedown", function() {
          $rs.hasClass(n.toggle(), "rsActive") ? u("rsoff") : u("rson")
        });
        $rs.regEvent($rs.get("#rsToggle .rsToggle_close"), "click", function() {
          $rs.hasClass($rs.get("#rsToggle"), "rsClosed") ? $rs.removeClass($rs.get("#rsToggle"), "rsClosed") : $rs.addClass($rs.get("#rsToggle"), "rsClosed")
        });
        $rs.regEvent($rs.get("#rsToggle .rsSpeedHolder .rsLowSpd"), "click", function() {
          $rs.removeClass($rs.get("#rsToggle .rsSpeedHolder a"), "rsSelected");
          $rs.addClass(this, "rsSelected");
          rspkr.st.set("hlspeed", "slow")
        });
        $rs.regEvent($rs.get("#rsToggle .rsSpeedHolder .rsMedSpd"), "click", function() {
          $rs.removeClass($rs.get("#rsToggle .rsSpeedHolder a"), "rsSelected");
          $rs.addClass(this, "rsSelected");
          rspkr.st.set("hlspeed", "medium")
        });
        $rs.regEvent($rs.get("#rsToggle .rsSpeedHolder .rsHigSpd"), "click", function() {
          $rs.removeClass($rs.get("#rsToggle .rsSpeedHolder a"), "rsSelected");
          $rs.addClass(this, "rsSelected");
          rspkr.st.set("hlspeed", "fast")
        });
        "slow" == rspkr.st.get("hlspeed") ? $rs.addClass($rs.get("#rsToggle .rsSpeedHolder .rsLowSpd"), "rsSelected") : "medium" == rspkr.st.get("hlspeed") ? $rs.addClass($rs.get("#rsToggle .rsSpeedHolder .rsMedSpd"), "rsSelected") : "fast" == rspkr.st.get("hlspeed") && $rs.addClass($rs.get("#rsToggle .rsSpeedHolder .rsHigSpd"), "rsSelected");
        $rs.regEvent($rs.get("#rsToggle .rsTxtHolder .rsTxtDec"), "click", function() {
          $rs.removeClass($rs.get("#rsToggle .rsTxtHolder a"), "rsSelected");
          $rs.addClass(this, "rsSelected");
          rspkr.st.set("dpTextSize", 0);
          rspkr.c.dispatchEvent("dpTxtDec", window)
        });
        $rs.regEvent($rs.get("#rsToggle .rsTxtHolder .rsTxtInc"), "click", function() {
          $rs.removeClass($rs.get("#rsToggle .rsTxtHolder a"), "rsSelected");
          $rs.addClass(this, "rsSelected");
          rspkr.st.set("dpTextSize", 1);
          rspkr.c.dispatchEvent("dpTxtInc", window)
        });
        $rs.regEvent($rs.get("#rsToggle .rsTxtHolder .rsTxtIncLarge"), "click", function() {
          $rs.removeClass($rs.get("#rsToggle .rsTxtHolder a"), "rsSelected");
          $rs.addClass(this, "rsSelected");
          rspkr.st.set("dpTextSize", 2);
          rspkr.c.dispatchEvent("dpTxtIncLarge", window)
        });
        (undefined == rspkr.st.get("dpTextSize")) || (0 == rspkr.st.get("dpTextSize")) ? 
          ($rs.addClass($rs.get("#rsToggle .rsTxtHolder .rsTxtDec"), "rsSelected"), rspkr.c.dispatchEvent("dpTxtDec", window)) : 
          1 == rspkr.st.get("dpTextSize") ? 
            ($rs.addClass($rs.get("#rsToggle .rsTxtHolder .rsTxtInc"), "rsSelected"), rspkr.c.dispatchEvent("dpTxtInc", window)) : 
            2 == rspkr.st.get("dpTextSize") && ($rs.addClass($rs.get("#rsToggle .rsTxtHolder .rsTxtIncLarge"), "rsSelected"), rspkr.c.dispatchEvent("dpTxtIncLarge", window));

        $rs.regEvent($rs.get("#rsToggle .rsbtn_about"), "click", function() {
          rspkr.c.dispatchEvent("dpInfoClick", window)
        })
      }
      f = A("rstoggle");
      u(f, !1);
      f = k("addPreserve");
      j = k("addSkip");
      if (0 < f.length) for (h = 0; h < f.length; h++) if ((g = $rs.get(f[h])) && $rs.isArray(g) && 0 < g.length) for (a = 0; a < g.length; a++) $rs.addClass(g[a], "rs_preserve");
      else g && $rs.addClass(g, "rs_preserve");
      if (0 < j.length) for (h = 0; h < j.length; h++) if ((g = $rs.get(j[h])) && $rs.isArray(g) && 0 < g.length) for (a = 0; a < g.length; a++) $rs.addClass(g[a], "rs_skip");
      else g && $rs.addClass(g, "rs_skip");
      rs.cfg.item("ui.popupbutton", m);
      $rs.regEvent(q, "resize", function() {
        ReadSpeaker.Toggle.Drag.setPosition("resize");
        0 < $rs.get("#rslightbox_aboutframe").length && $rs.css($rs.get("#rslightbox_aboutframe"), "height", $rs.get("#rslightbox_aboutframe").parentNode.style.height)
      });
      rspkr.c.addEvent("onUIShowPlayer", function() {
        setTimeout(function() {
          p = !0;
          ReadSpeaker.Toggle.Drag.setPosition()
        }, 100)
      });
      rspkr.c.addEvent("onUIClosePlayer", function() {
        setTimeout(function() {
          p = !1;
          ReadSpeaker.Toggle.Drag.setPosition("closeplayer")
        }, 100)
      });
      ReadSpeaker.Toggle.Drag.initDragDrop();
      ReadSpeaker.Toggle.Drag.setPosition();
      rspkr.c.e.dpTxtDec || (rspkr.c.e.dpTxtDec = []);
      rspkr.c.e.dpTxtInc || (rspkr.c.e.dpTxtInc = []);
      rspkr.c.e.dpTxtIncLarge || (rspkr.c.e.dpTxtIncLarge = []);
      rspkr.c.e.dpInfoClick || (rspkr.c.e.dpInfoClick = []);
      ReadSpeaker.Common.addEvent("dpTxtDec", function() {
        rspkr.st.set("dpTxtSize", 0);
        window.rsConf.Custom.txtDec && window.rsConf.Custom.txtDec()
      });
      ReadSpeaker.Common.addEvent("dpTxtInc", function() {
        rspkr.st.set("dpTxtSize", 1);
        window.rsConf.Custom.txtInc && window.rsConf.Custom.txtInc()
      });
      ReadSpeaker.Common.addEvent("dpTxtIncLarge", function() {
        rspkr.st.set("dpTxtSize", 2);
        window.rsConf.Custom.txtInc && window.rsConf.Custom.txtIncLarge()
      });
      f = (f = rspkr.st.get("dpTxtSize")) ? parseInt(f) : 2;
      0 == f ? rspkr.c.dispatchEvent("dpTxtDec", window) : 1 == f ? rspkr.c.dispatchEvent("dpTxtInc", window) : 2 == f && rspkr.c.dispatchEvent("dpTxtIncLarge", window)
    },
    checkPlayerLoaded: function() {
      t || r()
    },
    getSetting: function(a) {
      return A(a)
    },
    getConfig: function(a) {
      return k(a)
    },
    setSetting: function(a, c) {
      z(a, c)
    },
    getWindowRef: function() {
      return q
    },
    setPlayerOpen: function(a) {
      p = a
    },
    isPlayerOpen: function() {
      return p
    },
    isTouch: function() {
      return v
    }
  }
}();
ReadSpeaker.Toggle.Drag = function() {
  return {
    initDragDrop: function() {},
    setPosition: function() {}
  }
}();
ReadSpeaker.q(function() {
  ReadSpeaker.Toggle.init()
});
