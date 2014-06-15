<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConnectTemplate.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Notification_Templates.ConnectTemplate" %>
 <div class="notification-item rs_read_this">
        <div class="notification-header">
          <p class="notification-label">
            <i class="icon-notification-link"></i> 
                <%# Eval("NotificationLink") %>
          </p>
        </div>
        <div class="notification-body">
          <p class="notification-action">
            <%# Eval("Action") %>
          </p>
          <a href="REPLACE" class="button rs_skip">Accept</a>
          <a href="REPLACE" class="button gray rs_skip">Decline</a>
        </div>
      </div>