<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TycePlayer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TycePlayer" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<%@ Import Namespace="UnderstoodDotOrg.Domain.SitecoreCIG" %>
<!-- BEGIN PARTIAL: header-tyce-player -->
<header id="header-tyce" class="container">
    <div class="row">
        <div class="col col-12">
            <div class="logo-u-main">
                <a href="<%= MainsectionItem.GetHomeItem().GetUrl() %>" class="no-background">
                    <%= Model.HeaderLogo.GetImageUrl() %></a>
            </div>
        </div>
        <style>
            .logo-u-main a.no-background{
                background-image: none !important;
            }
        </style>
        <!-- .col -->
        <div class="col col-12">
            <div class="tyce-menu-container">
                <button class="icon-tyce-menu"><%= Model.MenuText.Rendered %></button>
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
            <a href="<%= Model.TyceBasePage.GetOverviewPage().GetUrl() %>" class="back-to-previous"><i class="icon-arrow-left-blue"></i><%= Model.ExperienceChildsWorldText.Rendered %></a>
            <h1><%= Model.PersonalizedForChildText.Rendered %></h1>
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
                <span><%= Model.HelpText.Rendered %></span>
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
                        <div id="gameboard">
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
                    <h4><%= Model.HowThisWorksTitle.Rendered %></h4>
                    <p>
                        <%= Model.HowThisWorksBody.Rendered %>
                    </p>
                    <a class="button close">OK</a>
                </div>
                <div class="bubble captions">
                    <%= Model.CaptionsBubbleText.Rendered %>
                </div>
                <div class="bubble pause">
                    <%= Model.VolumeBubbleText.Rendered %>
                </div>
                <div class="bubble progress">
                    <%= Model.ProgressBubbleText.Rendered %>
                </div>
                <div class="bubble skip">
                    <%= Model.SkipBubbleText.Rendered %>
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
                                <span id="step-1"><%= Model.StepOneText.Rendered %></span></li>
                            <li>
                                <span id="step-2"><%= Model.StepTwoText.Rendered %></span></li>
                            <li>
                                <span id="step-3"><%= Model.StepThreeText.Rendered %></span></li>
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