<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleEntry.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ArticleListings.ArticleEntry" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="article  rs_read_this">
    <asp:HyperLink ID="hlThumbnail" runat="server"><asp:Image ID="imgThumbnail" runat="server" /></asp:HyperLink>
    <div class="article-title-container">
        <h3><asp:HyperLink ID="hlTitle" runat="server"><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></asp:HyperLink></h3>
        <div class="children">
        <i class="child-a" title="CHILD NAME HERE"></i><i class="child-b" title="CHILD NAME HERE"></i><i class="child-c" title="CHILD NAME HERE"></i><i class="child-e" title="CHILD NAME HERE"></i>
        </div>
    </div>
</div>