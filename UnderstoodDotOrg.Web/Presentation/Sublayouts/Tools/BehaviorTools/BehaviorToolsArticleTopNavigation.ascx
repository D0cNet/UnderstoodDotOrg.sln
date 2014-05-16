<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsArticleTopNavigation.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsArticleTopNavigation" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:HyperLink ID="hlBackToSearch" Visible="false" runat="server" CssClass="back-to-previous left-of-first-next-prev-menu"><i class="icon-arrow-left-blue"></i> <asp:Literal ID="litSearchChallenge" runat="server" /></asp:HyperLink>

<asp:PlaceHolder ID="phResultNav" Visible="false" runat="server">
<div class="first-next-prev-menu arrows-gray">
    <asp:PlaceHolder ID="phNavLabel" runat="server" Visible="false">
        <span class="next-prev-text"><%= UnderstoodDotOrg.Common.DictionaryConstants.PrevTipButtonText %></span>
    </asp:PlaceHolder>
    <asp:HyperLink ID="hlPrev" runat="server" Visible="false" CssClass="rsArrow rsArrowLeft"><div class="rsArrowIcn"></div></asp:HyperLink>
    <asp:HyperLink ID="hlNext" runat="server" Visible="false" CssClass="rsArrow rsArrowRight"><div class="rsArrowIcn"></div></asp:HyperLink>
</div>
</asp:PlaceHolder>