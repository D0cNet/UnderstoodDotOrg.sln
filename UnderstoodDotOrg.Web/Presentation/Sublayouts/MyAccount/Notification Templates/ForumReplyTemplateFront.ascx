<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ForumReplyTemplateFront.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Notification_Templates.ForumReplyTemplateFront" %>
 <li class="new-comment">
            <p class="timestamp">
                <i class="icon-notification-comment"></i><%# Eval("TimeStamp") %><span class="dot"></span><%# Eval("FriendlyDate") %>
            </p>
            <p class="notification-item">
                <%# Eval("ActionFront") %>
            </p>
        </li>