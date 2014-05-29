<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyAccountHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.MyAccountHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register Src="~/Presentation/Sublayouts/Tools/MyAccount/Private Message Tool.ascx" TagPrefix="uc1" TagName="PrivateMessageTool" %>

<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<div class="container">
    <div class="row back-to-previous-nav">
        <!-- article -->
        <div class="col col-22 offset-1">
            <a href="REPLACE" class="back-to-previous"><i class="icon-arrow-left-blue"></i>Back to Homepage</a>
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
<!-- BEGIN PARTIAL: my-account-nav -->

<div class="container my-account-nav">
    <div class="row account-top-wrapper">
        <div class="col col-23 offset-1">
            <div class="account-photo skiplink-dashboard">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
            </div>
            <div class="account-info">
                <h1 class="account-username"><%= CurrentMember.ScreenName %></h1>
                <p class="account-location"> </p>
            </div>
            <div class="account-links">
                <a class="profile-link button" href="<%= MyProfilePage.GetUrl() %>"><%= MyProfilePage.MyAccountBase.ContentPage.BasePageNEW.NavigationTitle.Rendered %></a>
                <span class="button-wrapper">
                    <a class="notifications-link button" href="/My Account/My Notifications/Private Message Tool.aspx">Notifications<span class="notification-count">3</span></a>
                </span>
            </div>
        </div>
    </div>
    <div class="account-nav-wrapper">
        <div class="row">
            <nav class="account-nav">
                <asp:Repeater ID="rptrAccountNav" runat="server" 
                    ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.MyAccountBaseItem">
                    <ItemTemplate>
                        <a href="<%# Item.GetUrl() %>">
                            <div class="icon-wrapper">
                                <i class="<%# Item.IconCssClass.Rendered %>"></i>
                                <span><%# Item.AccountNavigationTitle.Rendered %></span>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </nav>
        </div>
    </div>
</div>
<!-- END PARTIAL: my-account-nav -->
