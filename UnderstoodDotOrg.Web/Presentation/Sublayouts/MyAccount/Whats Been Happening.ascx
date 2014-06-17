<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Whats Been Happening.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Whats_Been_Happening" %>
 <div class="account-body-wrapper">
          <!-- BEGIN PARTIAL: account-notification-tab-notifications -->
<section class="account-notifications-tab-notifications">

    <asp:ListView runat="server"  ItemType="UnderstoodDotOrg.Domain.Models.TelligentCommunity.NotificationFeed" ID="lvNotificationFeed">
        
        <LayoutTemplate>
            <div class="notification-feed-wrapper">

                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
                          <h3><%# Eval("FriendlyDate") %></h3>
                <asp:Repeater  ClientIDMode="Static" ID="rptNotifications"    OnItemDataBound="rptNotifications_ItemDataBound"  ItemType="INotification" runat="server">
                    <HeaderTemplate>
                        <div class="notification-items">
                    </HeaderTemplate>
                    <ItemTemplate>
                         
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
        </ItemTemplate>
        <EmptyDataTemplate>

        </EmptyDataTemplate>
    </asp:ListView>
<%--  <div class="notification-feed-wrapper">
    <h3>Yesterday</h3>
    <div class="notification-items">
      <div class="notification-item rs_read_this">
        <div class="notification-header">
          <p class="notification-label">
            <i class="icon-notification-comment"></i> New comment added to
            <span class="visuallyhidden" >My Child Has a Learning Disability</span>
            <span class="timestamp">2:48PM</span>
            <a class="notification-link rs_skip" href="REPLACE">My Child Has a Learning Disability</a>
          </p>
        </div>
        <div class="notification-body">
          <p class="notification-action">SandysDad65 <a href="REPLACE">added&hellip;</a></p>
          <p class="notification-comment">Eum placeat quia quo hic perferendis. nulla eos omnis ab quo distinctio. commodi ipsa beatae soluta autem vel nam consequatur. assumenda omnis iure eum consequuntur et molestias et consectetur. reiciendis error inventore quibusdam ut itaque est in consequatur aliquid placeat repellat nihil sed dignissimos. cupiditate provident dolor vero quia dolorum facilis blanditiis provident provident. voluptatem laborum necessitatibus neque deleniti libero aut omnis</p>
        </div>
      </div>

      <div class="notification-item rs_read_this">
        <div class="notification-header">
          <p class="notification-label">
            <i class="icon-notification-comment"></i> New comment added to
            <span class="visuallyhidden" >My Child Has a Learning Disability</span>
            <span class="timestamp">2:48PM</span>
            <a class="notification-link rs_skip" href="REPLACE">My Child Has a Learning Disability</a>
          </p>
        </div>
        <div class="notification-body">
          <p class="notification-action">BettysMom13 <a href="REPLACE">added&hellip;</a></p>
          <p>Odit minus quos velit debitis perferendis qui commodi libero quia ducimus dolorum. hic illo illo aut velit et adipisci labore molestias. consequatur natus quaerat consequatur facilis similique alias</p>
        </div>
      </div>

      <div class="notification-item rs_read_this">
        <div class="notification-header">
          <p class="notification-label">
            <i class="icon-notification-link"></i> Parent Connection
            <span class="timestamp">2:48PM</span>
          </p>
        </div>
        <div class="notification-body">
          <p class="notification-action">
            MarysDad97 <a href="REPLACE">wants to connect</a> with you.
          </p>
          <a href="REPLACE" class="button rs_skip">Accept</a>
          <a href="REPLACE" class="button gray rs_skip">Decline</a>
        </div>
      </div>

      <div class="notification-item rs_read_this">
        <div class="notification-header">
          <p class="notification-label">
            <i class="icon-notification-reminder"></i> Reminder
            <span class="timestamp">2:48PM</span>
          </p>
        </div>
        <div class="notification-body">
          <p class="notification-action">
            It's been a week since the last observation note was added to your observation log for <a href="REPLACE">Michael</a>
          </p>
          <a href="REPLACE" class="button rs_skip">Add a Note</a>
        </div>
      </div>
    </div><!-- .notification-items -->

    <h3>June  2</h3>
    <div class="notification-items notification-items-bottom">
      <div class="notification-item rs_read_this">
        <div class="notification-header">
          <p class="notification-label">
            <i class="icon-notification-comment"></i>
            New comment added to
            <span class="visuallyhidden" >My Child Has a Learning Disability</span>
            <span class="timestamp">2:48PM</span>
            <a class="notification-link" href="REPLACE">My Child Has a Learning Disability</a>
          </p>
        </div>
        <div class="notification-body">
          <p class="notification-action">
            SandysDad65 <a href="REPLACE">added&hellip;</a>
          </p>
          <p>Suscipit perspiciatis sunt sit. tempore vel repellendus possimus quos id molestiae vitae impedit minus voluptas aut. necessitatibus dicta facilis in repudiandae esse dolore eveniet voluptatum quo aspernatur soluta. sit et eaque maiores et cum sunt quo magnam saepe occaecati</p>
        </div>
      </div>
    </div><!-- .notification-items -->
  </div><!-- .notification-feed-wrapper -->--%>

</section>
<!-- END PARTIAL: account-notification-tab-notifications -->

</div>
 <div class="showmore-footer">
        <!-- Show More -->
        <!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more rs_skip">
    <div class="row">
    <div class="col col-24">
        <a class="show-more-link show_more" href="#" data-path="my-account/notifications" data-container="notification-items-bottom" data-item="notification-item" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
    </div>
    </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
        <!-- .show-more -->
</div>
