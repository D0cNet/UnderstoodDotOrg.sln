<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailAndAlertsPreferences.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.EmailAndAlertsPreferences" %>

<div class="account-body-wrapper">
    <!-- BEGIN PARTIAL: account-notification-tab-email -->
    <div class="account-notifications-tab-email rs_read_this">
        <h2>Email Alerts</h2>
		<div class="checkbox-wrapper">
            <label class="daily-digest" for="daily-digest-option">
                <input type="radio" name="digest-option" id="Radio1" value="" checked>
                <span>English</span>
            </label>
            <label class="weekly-digest" for="weekly-digest-option">
                <input type="radio" name="digest-option" id="Radio2" value="">
                <span>Spanish</span>
            </label>
        </div>
        <div class="toggles-wrapper">
            <div class="toggle-wrapper">
                <label>
                    <span>Weekly Personalized Newsletter</span>
                    <input class="toggle" type="checkbox" name="weekly-personalized-newsletter" id="weekly-personalized-newsletter" value="true" checked="checked">
                </label>
            </div>
        </div>
        <!-- .toggles-wrapper -->
    </div>
    <!-- END PARTIAL: account-notification-tab-email -->
</div>
<!-- .account-body-wrapper -->
