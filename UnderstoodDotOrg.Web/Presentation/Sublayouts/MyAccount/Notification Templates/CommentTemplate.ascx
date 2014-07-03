﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentTemplate.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Notification_Templates.CommentTemplate" %>
<div class="notification-item rs_read_this">
    <div class="notification-header">
                              
    <p class="notification-label">

    <i class="icon-notification-comment"></i> <%# Eval("CommentHeading") %>
    <span class="timestamp"><%# Eval("TimeStamp") %></span>
    <a class="notification-link rs_skip" href='<%# Eval("NotificationLink") %>'><%# Eval("BlogTitle") %></a>
                              
    </p>
</div>
<div class="notification-body">
    <p class="notification-action"><%# Eval("Action") %></p>
    <p class="notification-comment"><%# Eval("Text") %></p>
</div>
</div>