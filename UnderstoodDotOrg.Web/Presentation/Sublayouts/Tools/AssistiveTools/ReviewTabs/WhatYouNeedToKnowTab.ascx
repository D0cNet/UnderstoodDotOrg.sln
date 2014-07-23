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
                        <asp:Repeater ID="rptrPlatforms" runat="server"
                            ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData.AssistiveToolsPlatformItem">
                            <ItemTemplate>
                                <%# Item.Metadata.ContentTitle.Rendered %>
                            </ItemTemplate>
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
                                <a href="REPLACE">
                                    <img alt="<%# Eval("Alt") %>" src="<%# Eval("Url") %>" />
                                </a>
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
                <h3>What can kids learn</h3>
                <span class="visuallyhidden">learning rating</span>
                <span class="slider-position">
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider purple-<%= SpelledNumbers[Model.Learning.Integer] %>" 
                        aria-label="<%= Model.Learning.Integer %>"><%= Model.Learning.Integer %></div>
                    <!-- END PARTIAL: results-slider -->
                </span>
                <p><%= Model.WhatKidsCanLearn.Rendered %></p>
                <h5>Subjects</h5>
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
                <h3>What is it about?</h3>
                <p><%= Model.Description.Rendered %></p>
            </section>
            <section class="rs_read_this what-you-need-to-know-rs-wrapper">
                <h3>Is it any good?</h3>
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
                <h3>How parents can help</h3>
                <p><%= Model.HowParentsCanHelp.Rendered %></p>
            </section>
            <footer>
                <p>
                    Curabitur porta
                                    <a href="REPLACE">nunc egestas</a>
                    pulvinar elementum. Nam sollicitudin nibh pharetra vehicula rhoncus.
                                    Sed tristique neque a metus molestie, eget suscipit massa consequat.
                                    <a href="REPLACE">Morbi fringilla rhoncu</a>.
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
