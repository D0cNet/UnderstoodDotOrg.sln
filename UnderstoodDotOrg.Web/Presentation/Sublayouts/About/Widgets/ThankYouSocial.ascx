<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThankYouSocial.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Widgets.ThankYouSocial" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

 <div class="thank-you-social">
    <a href="#" class="email-link">
        <span class="circle"><span class="icon icon-envelope rs_skip" alt="envelope icon"></span></span><span class="text-link"><asp:Literal ID="litTellAFriend" runat="server" /></span>
    </a>
    <asp:HyperLink ID="hlTwitter" CssClass="twitter-link" runat="server">
        <span class="circle"><span class="icon icon-twitter rs_skip" alt="twitter icon"></span></span><span class="text-link"><asp:Literal ID="litTwitter" runat="server" /></span>
    </asp:HyperLink>
    <asp:HyperLink ID="hlFacebook" CssClass="facebook-link" runat="server">
        <span class="circle"><span class="icon icon-facebook rs_skip" alt="facebook icon"></span></span><span class="text-link"><asp:Literal ID="litFacebook" runat="server" /></span>
    </asp:HyperLink>
</div>