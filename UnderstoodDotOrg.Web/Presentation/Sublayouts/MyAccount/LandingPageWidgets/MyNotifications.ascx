<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyNotifications.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets.MyNotifications" %>
<!-- BEGIN PARTIAL: account-landing-notifications -->
<div class="landing-notifications landing-modules rs_read_this">
    <header class="clearfix">
        <h3>Notifications<span class="landing-module-count"><asp:Literal ID="litNotifCount" Text="0" runat="server"></asp:Literal></span></h3>
    </header>
    <asp:ListView  ID="lvNotifications" OnItemDataBound="lvNotifications_ItemDataBound"  runat="server">
        <LayoutTemplate>
            <ul class="landing-module-items">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>

        </ItemTemplate>
        <EmptyDataTemplate>
           
        </EmptyDataTemplate>
       
    </asp:ListView>
    <asp:Panel ID="pnlEmptyText" Visible="false" runat="server">
         <p>
                <asp:Literal Text="" ID="litEmptyText" runat="server" />
            </p>
    </asp:Panel>

   <%-- <ul class="landing-module-items">
        <!-- This template for new connections -->
        <li class="new-connection">
            <p class="timestamp">
                <i class="icon-notification-link"></i>2:48PM <span class="dot"></span>Dec 12 2014
            </p>
            <p class="notification-item">
                Caitlyn Woodard <a href="REPLACE">wants to connect</a> with you.
            </p>
            <p class="clearfix button-wrapper">
                <a href="REPLACE" class="button accept-connection rs_skip">Accept</a>
                <a href="REPLACE" class="button gray decline-connection rs_skip">Decline</a>
            </p>
        </li>

        <!-- This template for new notes -->
        <li class="new-note">
            <p class="timestamp">
                <i class="icon-notification-reminder"></i>2:48PM <span class="dot"></span>Dec 20 2014
            </p>
            <p class="notification-item">
                corporis ad maxime sed nostrum totam eaque similique consequatur id temporibus consequatur debitis pariatur maiores
            </p>
            <p class="clearfix button-wrapper">
                <a href="REPLACE" class="button add-a-note rs_skip">Add a Note</a>
            </p>
        </li>

        <!-- This template for new comments  -->
        <li class="new-comment">
            <p class="timestamp">
                <i class="icon-notification-comment"></i>2:48PM <span class="dot"></span>Dec 16 2014
            </p>
            <p class="notification-item">
                Katie McKenzie <a href="REPLACE">added a comment</a> to a officia explicabo est eveniet aperiam minus omnis et inventore reiciendis optio quis qui et
            </p>
        </li>
    </ul>--%>


    <div class="bottom rs_skip"><a href="" id="hrefNotificationsLink" runat="server" >
        <asp:Literal Text="" ID="litSeeAllNotificationsLabel" runat="server" /></a></div>
</div>
<!-- /.landing-notifications /.landing-modules -->

<!-- END PARTIAL: account-landing-notifications -->
