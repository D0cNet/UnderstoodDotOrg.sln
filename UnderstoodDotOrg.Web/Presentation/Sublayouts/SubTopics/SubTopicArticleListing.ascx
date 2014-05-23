<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubTopicArticleListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics.SubTopicArticleListing" %>
<%@ Register TagPrefix="udo" TagName="ArticleListing" Src="~/Presentation/Sublayouts/Common/ArticleListings/SubtopicLandingArticles.ascx" %>

<div class="col col-15 offset-1" aria-live="polite" aria-relevant="additions removals">
    <div id="subtopic-article-listings" class="article-listing">
        <udo:ArticleListing ID="articleListing" runat="server" />
    </div>

    <asp:Panel ID="pnlShowMore" runat="server" CssClass="container show-more rs_skip">
        <div class="row">
            <div class="col col-24">
                <a href="#" class="topic-subtopic-articles-show-more-link" data-path="<%= AjaxEndpoint %>" data-container="subtopic-article-listings" data-item="article" data-topic="<%= Model.ID.ToString() %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></a>
            </div>
        </div>
    </asp:Panel>

 </div>