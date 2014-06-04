<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsReviewDescription.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsReviewDescription" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container flush at3-wrapper">
    <div class="row">
        <div class="col col-22 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: what-you-need-to-know-tabs -->
            <div id="tab-container" class="tab-container what-you-need-to-know-tabs">
                <ul class='etabs'>
                    <li class='tab'>
                        <a href="#tabs1-what-you-need-to-know">What You Need To Know</a></li>
                    <li class='tab rs_skip'>
                        <a href="#tabs2-parent-reviews">Parent Reviews</a></li>
                </ul>
                <div class="tab-container rs_read_this">
                    <span class="visuallyhidden">What You Need To Know</span>
                    <span class="visuallyhidden">Parent Reviews</span>
                </div>
                <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Tools/AssistiveTools/ReviewTabs/WhatYouNeedToKnowTab.ascx" />
                <!-- end .tabs1-what-you-need-to-know -->
                <!-- END WHAT YOU NEED TO KNOW TAB SECTION -->
                <!-- START PARENT REVIEWS TAB SECTION -->
                <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Tools/AssistiveTools/ReviewTabs/ParentReviewsTab.ascx" />
                <!-- end .tabs2-parent-reviews -->
            </div>
            <!-- END PARTIAL: what-you-need-to-know-tabs -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
