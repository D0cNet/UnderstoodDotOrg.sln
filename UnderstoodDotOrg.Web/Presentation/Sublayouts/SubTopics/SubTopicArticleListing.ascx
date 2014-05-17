<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubTopicArticleListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics.SubTopicArticleListing" %>

<div class="col col-15 offset-1" aria-live="polite" aria-relevant="additions removals">

    <asp:Repeater ID="rptArticles" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems.DefaultArticlePageItem">
        <HeaderTemplate>
            <div class="article-listing">
        </HeaderTemplate>
        <ItemTemplate>
                <div class="article">
                    <asp:HyperLink ID="hlThumbnail" runat="server"><asp:Image ID="imgThumbnail" runat="server" /></asp:HyperLink>
                    <div class="article-title-container">
                        <h3><asp:HyperLink ID="hlTitle" runat="server"><%# Item.ContentPage.PageTitle %></asp:HyperLink></h3>
                        <!--<div class="children">
                            <i class="child-a" title="CHILD NAME HERE"></i><i class="child-b" title="CHILD NAME HERE"></i><i class="child-c" title="CHILD NAME HERE"></i><i class="child-e" title="CHILD NAME HERE"></i>
                        </div>-->
                    </div>
                </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>


    <div class="show-more">
        <a href="REPLACE" class="show-more-link" data-path="articles/g4" data-container="article-listing" data-item="article" data-count="6">More Articles<i class="icon-arrow-down-blue"></i></a>
    </div>

 </div>