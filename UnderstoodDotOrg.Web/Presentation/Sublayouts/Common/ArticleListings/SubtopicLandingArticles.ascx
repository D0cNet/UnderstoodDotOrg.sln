<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubtopicLandingArticles.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ArticleListings.SubtopicLandingArticles" %>

<asp:Repeater ID="rptArticles" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems.DefaultArticlePageItem">
    <ItemTemplate>
            <sc:Sublayout id="sbArticleEntry" runat="server" Path="~/Presentation/Sublayouts/Common/ArticleListings/ArticleEntry.ascx" /> 
    </ItemTemplate>
</asp:Repeater>