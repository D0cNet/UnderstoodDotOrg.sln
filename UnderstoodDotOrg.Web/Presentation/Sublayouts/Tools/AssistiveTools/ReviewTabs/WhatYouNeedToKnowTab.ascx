<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WhatYouNeedToKnowTab.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.ReviewTabs.WhatYouNeedToKnowTab" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div id="tabs1-what-you-need-to-know" class="panel-container">
    <div class="row">
        <div class="col col-17">
            <section class="rs_read_this what-you-need-to-know-rs-wrapper">
                <h3>What parents need to know</h3>
                <p><%= Model.WhatParentsNeedtoKnow.Rendered %></p>
                <p class="skip_this">
                    <span class="platform-list">
                        <asp:Repeater ID="rptrPlatforms" runat="server" OnItemDataBound="rptrPlatforms_ItemDataBound">
                            <ItemTemplate><asp:Literal ID="litPlatform" runat="server"></asp:Literal></ItemTemplate>
                        </asp:Repeater>
                        <%--<a href="REPLACE">iPhone</a>,
                        <a href="REPLACE">Android</a>--%>
                    </span>
                    <span class="about-platforms">
                        <sc:FieldRenderer ID="frPlatformsLink" runat="server" FieldName="Learn About Platforms Link" /></span>
                </p>
            </section>
            <!-- BEGIN PARTIAL: at-detail-thumb-mobile -->
            <div class="screenshot-wrapper">
                <div class="screenshot-thumbs screenshot-thumbs-mobile">
                    <h2>Screenshots</h2>
                    <div class="screenshot-thumbs-wrapper">
                        <asp:Repeater ID="rptrScreenshots" runat="server">
                            <ItemTemplate>
                                <img alt="<%# Eval("Alt") %>" src="<%# Eval("Url") %>" />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- end screenshot-thumbs-container-->
                    <p class="slide-count">
                        <span class="at-detail-thumb-curr-slide">1</span>
                        &nbsp;of&nbsp;
                        <span class="at-detail-thumb-total-slides">total</span>
                    </p>
                </div>
                <!-- .screenshot-thumbs -->
            </div>
            <!-- .screenshot-wrapper -->
            <!-- END PARTIAL: at-detail-thumb-mobile -->
            <section class="rs_read_this what-you-need-to-know-rs-wrapper">
                <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.WhatKidsCanLearnLabel %></h3>
                <span class="visuallyhidden">learning rating</span>
                <span class="slider-position">
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider purple-<%= SpelledNumbers[Model.Learning.Integer] %>" 
                        aria-label="<%= Model.Learning.Integer %>"><%= Model.Learning.Integer %></div>
                    <!-- END PARTIAL: results-slider -->
                </span>
                <p><%= Model.WhatKidsCanLearn.Rendered %></p>
                <h5><%= UnderstoodDotOrg.Common.DictionaryConstants.SubjectsLabel %></h5>
                <ul class="kids-subjects">
                    <asp:Repeater ID="rptrSubjectsAndSkills" runat="server" 
                        ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General.MetadataItem">
                        <ItemTemplate>
                            <li><%# Item.ContentTitle.Rendered %></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clearfix"></div>
            </section>
            <section class="rs_read_this what-you-need-to-know-rs-wrapper">
                <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.WhatIsItAboutLabel %></h3>
                <p><%= Model.Description.Rendered %></p>
            </section>
            <section class="rs_read_this what-you-need-to-know-rs-wrapper">
                <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.IsItAnyGoodLabel %></h3>
                <span class="visuallyhidden">quality rating</span>
                <span class="slider-position">
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider blue-<%= SpelledNumbers[Model.Quality.Integer] %>" 
                        aria-label="<%= Model.Quality.Integer %>"><%= Model.Quality.Integer %></div>
                    <!-- END PARTIAL: results-slider -->
                </span>
                <p><%= Model.AnyGood.Rendered %></p>
            </section>
            <section class="rs_read_this what-you-need-to-know-rs-wrapper">
                <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.HowParentsCanHelpLabel %></h3>
                <p><%= Model.HowParentsCanHelp.Rendered %></p>
            </section>
            <footer>
                <p>
                    <sc:FieldRenderer ID="frFooterContent" runat="server" FieldName="CSM Item Footer Content" />
                </p>
            </footer>

        </div>
        <!-- end .col.col-17 -->
        <div class="col">
            <!-- BEGIN PARTIAL: at-detail-thumb -->
            <div class="screenshot-wrapper">
                <div class="screenshot-thumbs screenshot-thumbs-lg"></div>
            </div>
            <!-- .screenshot-wrapper -->
            <!-- END PARTIAL: at-detail-thumb -->
        </div>
        <!-- end .col.col-7 -->
    </div>
    <!-- end .row -->
</div>
<style>
    .screenshot-thumbs-wrapper img{
        cursor: pointer;
    }
</style>
