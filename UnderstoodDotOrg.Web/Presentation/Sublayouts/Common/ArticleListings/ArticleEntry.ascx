<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleEntry.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ArticleListings.ArticleEntry" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register Src="~/Presentation/Sublayouts/Recommendation/ArticleRecommendationIcons.ascx" TagPrefix="udo" TagName="ArticleRecommendationIcons" %>


<div class="article skiplink-content rs_read_this" aria-role="main">
    <asp:HyperLink ID="hlThumbnail" runat="server"><asp:Image ID="imgThumbnail" runat="server" /></asp:HyperLink>
    <div class="article-title-container">
        <h3><asp:HyperLink ID="hlTitle" runat="server"><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></asp:HyperLink></h3>
        <udo:ArticleRecommendationIcons ID="articleRecommendationIcons" runat="server" />
    </div>
</div>