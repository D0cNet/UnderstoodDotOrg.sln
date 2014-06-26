﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TycePlayer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TycePlayer" %>
<!-- BEGIN PARTIAL: header-tyce-player -->
<header id="header-tyce" class="container">
    <div class="row">
        <div class="col col-12">
            <div class="logo-u-main">
                <a href="REPLACE" style="background: none !important;">
                    <img alt="Understood Logo" src="/Presentation/includes/images/logo.u.default.png" /></a>
            </div>
        </div>
        <!-- .col -->
        <div class="col col-12">
            <div class="tyce-menu-container">
                <button class="icon-tyce-menu">Menu</button>
            </div>
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</header>
<!-- #header-page -->
<!-- END PARTIAL: header-tyce-player -->
<!-- BEGIN PARTIAL: tyce-player-header -->
<div class="container tyce-player-header skiplink-tyce-header">
    <div class="row">
        <div class="col col-15 offset-1">
            <a href="REPLACE" class="back-to-previous"><i class="icon-arrow-left-blue"></i>Experience a Child's World</a>
            <h1>Personalized for Your Child</h1>
        </div>
        <!-- .col-15 -->
        <div class="col col-8">
            <div class="captions">
                <span>Captions</span>
                <div class="toggle-wrapper">
                    <label>
                        <input class="toggle" type="checkbox">
                    </label>
                </div>
            </div>
            <!-- .captions -->
            <div class="help">
                <span>Help</span>
                <a class="icon help"></a>
            </div>
        </div>
        <!-- .col-10 -->
    </div>
    <!-- .row -->
</div>
<!-- .tyce-player-header -->
<!-- END PARTIAL: tyce-player-header -->
<div class="container tyce-player-container skiplink-tyce-player">
    <div class="row">
        <div class="col col-24">
            <!-- BEGIN PARTIAL: tyce-player-content -->
            <div class="player-content">
                <div id="player"></div>
                <div id="container-sim">
                    <div class="sim-inner">
                        <div id="gameboard" class="dyslexia_game">
                            <header>Scrambled Letters</header>
                            <article>
                                <div id="dyslexia_article_inner">
                                    <div id="dyslexia_rules">
                                        <p id="dyslexia_rules_swaps"></p>
                                    </div>
                                    <div id="dyslexia_sentence"></div>
                                </div>
                            </article>
                            <footer></footer>
                        </div>
                        <!-- #gameboard -->
                    </div>
                    <!-- .sim-inner -->
                </div>
                <!-- #container-sim -->
            </div>
            <!-- .player-content -->
            <a class="button btn-skip">Skip</a>
            <div class="help-overlay">
                <div class="instructions">
                    <h4>How this works</h4>
                    <p>
                        Here are a few tips on how to manage the process.<br />
                        When you’re done reading, click OK.
                    </p>
                    <a class="button close">OK</a>
                </div>
                <div class="bubble captions">
                    To read text along with the video, turn captions on.
                </div>
                <div class="bubble pause">
                    Pause and adjust the volume here.
                </div>
                <div class="bubble progress">
                    This shows progress and lets you jump between elements.
                </div>
                <div class="bubble skip">
                    To skip a section, click here.
                </div>
            </div>
            <!-- .help-overlay -->
            <!-- END PARTIAL: tyce-player-content -->
            <!-- BEGIN PARTIAL: tyce-controls -->
            <div class="controls skiplink-tyce-controls">
                <ul>
                    <li class="play-pause" tabindex="0"><i class="icon play"></i></li>
                    <li class="volume" tabindex="0">
                        <div class="volume-slider">
                            <div class="slider"></div>
                        </div>
                        <i class="icon volume"></i></li>
                    <li class="steps">
                        <ul>
                            <li>
                                <span id="step-1">Introduction</span></li>
                            <li>
                                <span id="step-2">Simulation</span></li>
                            <li>
                                <span id="step-3">Expert Summary &amp; A Child's Perspective</span></li>
                        </ul>
                    </li>
                    <li class="fullscreen" tabindex="0"><i class="icon fullscreen"></i></li>
                </ul>
            </div>
            <!-- .controls -->
            <!--       <a href="REPLACE" id="nextvideo">NEXT</a>
      <a href="REPLACE" id="prevvideo">PREVIOUS</a> -->
        </div>
        <!-- .col-24 -->
    </div>
    <!-- .row -->
</div>
<!-- .tyce-player-container -->
<!-- Content wrapper for glossary term popovers -->
<!-- BEGIN PARTIAL: glossary-term -->
<!-- This partial is included in the footer.erb file. So this container applies to every glossary term and its contents should dynamically change depending on the glossary link. -->
<!-- popover hidden content -->
<div class="glossary-term-content-wrapper popover-container">
  <blockquote>
    <span>Dyslexia:</span> Difficulty in reading, spelling, writing, and related language skills that results from an impairment in the way the brain processes information &hellip; <a href="REPLACE">View Glossary</a>
  </blockquote>
</div>
<!-- END PARTIAL: glossary-term -->
<script type="text/javascript">
    $(document).ready(function () {
        $("html").addClass("tyce");
    });
</script>