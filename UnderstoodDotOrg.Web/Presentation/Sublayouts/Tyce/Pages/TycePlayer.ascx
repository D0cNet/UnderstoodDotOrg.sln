<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TycePlayer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TycePlayer" %>

<div class="container tyce-player-container skiplink-tyce-player">
    <div class="row">
        <div class="col col-24">
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
                    </div>
                </div>
            </div>
            <!-- .player-content -->
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
        <span>Dyslexia:</span>
        Difficulty in reading, spelling, writing, and related language skills that results from an impairment in the way the brain processes information &hellip;
        <a href="REPLACE">View Glossary</a>
    </blockquote>
</div>
<!-- END PARTIAL: glossary-term -->
