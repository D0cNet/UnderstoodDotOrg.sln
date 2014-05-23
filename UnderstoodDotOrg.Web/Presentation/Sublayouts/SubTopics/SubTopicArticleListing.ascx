<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubTopicArticleListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics.SubTopicArticleListing" %>

<div class="col col-15 offset-1" aria-live="polite" aria-relevant="additions removals">

    <asp:Repeater ID="rptArticles" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems.DefaultArticlePageItem">
        <HeaderTemplate>
            <div class="article-listing">
        </HeaderTemplate>
        <ItemTemplate>
                <sc:Sublayout id="sbArticleEntry" Cacheable="true" runat="server" Path="~/Presentation/Sublayouts/Common/ArticleListings/ArticleEntry.ascx" /> 
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>


    <asp:Panel ID="pnlShowMore" runat="server" CssClass="show-more">
        <a href="REPLACE" class="show-more-link" data-path="articles/g4" data-container="article-listing" data-item="article" data-count="6">More Articles<i class="icon-arrow-down-blue"></i></a>
    </asp:Panel>

 </div>