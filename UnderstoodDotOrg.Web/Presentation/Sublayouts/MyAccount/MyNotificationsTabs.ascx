<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyNotificationsTabs.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.MyNotificationsTabs" %>

<!-- BEGIN PARTIAL: account-notification-tabs -->
  <header>
    <div class="notification-tabs-wrapper select-inverted-mobile">

      <div class="notifications-section-tabs tab-widget tab-container">
        <ul>
          <li id="liNotificationsTab" runat="server" class="notifications-tab ">
            <asp:HyperLink ID="hypWhatsHappening" runat="server" >What's Been Happening</asp:HyperLink>
            <span class="circle"><asp:Literal ID="litNotifsCount" runat="server"></asp:Literal></span>
          </li>
          <li id="liMessagesTab" runat="server" class="messages-tab ">
            <asp:HyperLink ID="hypPrivateMessages" runat="server">Private Messages</asp:HyperLink>
            <span class="circle">0</span>
          </li>
          <li id="liEmailPreferencesTab" runat="server" class="email-tab last ">
            <asp:HyperLink ID="hypEmailAndAlertPreferences" runat="server">Email & Alert Preferences</asp:HyperLink>
          </li>
        </ul>
      </div>
      
    </div><!-- .notification-tabs-wrapper -->
  </header>

<!-- END PARTIAL: account-notification-tabs -->