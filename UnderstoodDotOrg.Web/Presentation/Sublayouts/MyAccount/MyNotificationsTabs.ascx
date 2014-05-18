<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyNotificationsTabs.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.MyNotificationsTabs" %>

<!-- BEGIN PARTIAL: account-notification-tabs -->
<header>
    <div class="notification-tabs-wrapper select-inverted-mobile">
        <div class="notifications-section-dropdown tab-widget">
            <span class="select-container">
                <label for="notifications-tab-dropdown" class="visuallyhidden">Filter Notifications</label>
                <select name="notifications-tab-dropdown">
                    <%--<option value="notifications">What's Been Happening</option>
                    <option value="messages">Private Messages</option>--%>
                    <option value="email">Email & Alert Preferences</option>
                </select>
            </span>
            <span class="notifications-count circle purple">0</span>
            <span class="messages-count circle purple">0</span>
        </div>
        <div class="notifications-section-tabs tab-widget tab-container">
            <ul>
                <%--<li class="notifications-tab ">
                    <a href="REPLACE">What's Been Happening<span class="circle">0</span></a>
                </li>
                <li class="messages-tab ">
                    <a href="REPLACE">Private Messages<span class="circle">0</span></a>
                </li>--%>
                <li class="email-tab last active">
                    <a href="REPLACE">Email & Alert Preferences</a>
                </li>
                <li class="dummy"><a href="#nowhere">&nbsp;</a></li>
            </ul>
        </div>
    </div>
    <!-- .notification-tabs-wrapper -->
</header>

<!-- END PARTIAL: account-notification-tabs -->
