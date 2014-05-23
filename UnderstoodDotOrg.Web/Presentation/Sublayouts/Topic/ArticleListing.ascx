<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic.ArticleListing" %>
<%@ Register TagPrefix="udo" TagName="ArticleListing" Src="~/Presentation/Sublayouts/Common/ArticleListings/TopicLandingArticles.ascx" %>

<!-- BEGIN PARTIAL: children-key -->
<div class="container child-content-indicator first">
    <!-- Key -->
    <div class="row">
        <div class="col col-23 offset-1">
            <div class="children-key">
                <ul>
                    <li><i class="child-a"></i>for Michael</li>
                    <li><i class="child-b"></i>for Elizabeth</li>
                    <li><i class="child-c"></i>for Ethan</li>
                    <li><i class="child-d"></i>for Jeremy</li>
                    <li><i class="child-e"></i>for Franklin</li>
                </ul>
            </div>
            <!-- .children-key -->
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>
<!-- .child-content-indicator -->
<!-- END PARTIAL: children-key -->

<!-- BEGIN MODULE: Article Listing -->
<div id="topic-articles-results" class="container article-listing-container article-listing">

    <udo:ArticleListing ID="articleListing" runat="server" /> 

</div>
<!-- .container -->

<!-- END MODULE: Article Listing -->

<!-- BEGIN MODULE: More Articles -->
<asp:Panel ID="pnlMoreArticle" runat="server" CssClass="container show-more" Visible="false">
    <div class="row">
        <div class="col col-24">
            <a href="#" class="topic-articles-show-more-link" data-path="<%= AjaxEndpoint %>" data-container="topic-articles-results" data-topic="<%= Model.ID.ToString() %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></a>
        </div>
    </div>
</asp:Panel>
<!-- .show-more -->

