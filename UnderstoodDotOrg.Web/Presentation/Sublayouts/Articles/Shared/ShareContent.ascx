<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareContent.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.ShareContent" %>

<div class="share-dropdown-menu rs_skip">
    <button class="social-share-button">Share <i class="icon-arrow"></i></button>
    <div class="share-menu">
        <span class="social-share">Share <i class="icon-arrow"></i></span>
        <ul>
            <li class="clearfix">
                <asp:HyperLink ID="hlFacebook" CssClass="icon-facebook share-icon" runat="server"><i class="icon-facebook"></i>
                    <asp:Literal ID="ltlFacebook" runat="server"></asp:Literal></asp:HyperLink>
            </li>
            <li class="clearfix">
                <asp:HyperLink ID="hlTwitter" CssClass="icon-twitter share-icon" runat="server"><i class="icon-twitter"></i>
                    <asp:Literal ID="ltlTwitter" runat="server"></asp:Literal></asp:HyperLink>
            </li>
            <li class="clearfix">
                <asp:HyperLink ID="hlGooglePlus" CssClass="icon-google share-icon" runat="server"><i class="icon-google"></i>
                    <asp:Literal ID="ltlGooglePlus" runat="server"></asp:Literal></asp:HyperLink>
            </li>
            <li class="clearfix">
                <a href="//www.pinterest.com/pin/create/button/" data-pin-do="buttonPin">
                    <img src="//assets.pinterest.com/images/pidgets/pinit_fg_en_round_red_16.png" /></a>
            </li>
        </ul>
    </div>
</div>
<!-- END PARTIAL: share-content-dropdown -->
<!-- BEGIN PARTIAL: article-action-buttons -->
<div class="article-actions buttons-container rs_skip clearfix">
    <button class="icon-email">email</button>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="update-panel">
        <ContentTemplate>
            <button id="lbSave" runat="server" class="icon-plus" onserverclick="lbSave_Click"></button>
        </ContentTemplate>
    </asp:UpdatePanel>
    <button class="icon-print" onclick="window.print()">print</button>
    <%--OOS for this release--%>
    <%--<button class="icon-bell">remind me</button>--%>
    <%--When You need it check MembershipManager.LogMemberActivity(x,y,z,q). Sample usage is in Sandbox.ascx.cs--%>
</div>

<!-- END PARTIAL: article-action-buttons -->
<div class="clearfix"></div>
