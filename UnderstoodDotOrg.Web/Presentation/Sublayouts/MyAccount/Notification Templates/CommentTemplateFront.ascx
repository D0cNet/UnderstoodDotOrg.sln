<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentTemplateFront.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Notification_Templates.CommentTemplateFront" %>
 <li class="new-comment">
            <p class="timestamp">
                <i class="icon-notification-comment"></i><%# Eval("TimeStamp") %><span class="dot"></span><%# Eval("FriendlyDate") %>
            </p>
            <p class="notification-item">
                <%# Eval("ActionFront") %>
            </p>
        </li>