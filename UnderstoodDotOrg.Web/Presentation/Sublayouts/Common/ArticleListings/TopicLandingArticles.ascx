<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicLandingArticles.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ArticleListings.TopicLandingArticles" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:ListView ID="lvArticles" GroupItemCount="2" runat="server">
    <LayoutTemplate>
        <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
    </LayoutTemplate>
    <GroupTemplate>
        <div class="row listing-row">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </div>
    </GroupTemplate>
    <ItemTemplate>
        <div class="col col-11 offset-1">
            <sc:Sublayout id="sbArticleEntry" runat="server" Path="~/Presentation/Sublayouts/Common/ArticleListings/ArticleEntry.ascx" /> 
        </div>
    </ItemTemplate>
</asp:ListView>