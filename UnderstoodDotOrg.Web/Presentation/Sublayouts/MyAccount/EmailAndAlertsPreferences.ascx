<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailAndAlertsPreferences.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.EmailAndAlertsPreferences" %>

<div class="account-body-wrapper">
          <!-- BEGIN PARTIAL: account-notification-tab-email -->
<div class="account-notifications-tab-email rs_read_this">
  <h2><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></h2>
  <div class="toggles-wrapper">
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frWeeklyPersonalizedNewsletter" runat="server" FieldName="Weekly Personalized Newsletter" /></span>
        <input class="toggle rs_preserve" type="checkbox" name="weekly-personalized-newsletter" id="weekly-personalized-newsletter" value="true" checked="checked">
      </label>
    </div>
    <fieldset>
      <div class="toggle-wrapper">
        <label>
          <span><sc:FieldRenderer ID="frNotificationsDigest" runat="server" FieldName="Notifications Digest" /></span>
          <input class="toggle rs_preserve" type="checkbox" name="notifications-digest" id="notifications-digest" value="true" checked="checked">
        </label>
      </div>
      <div class="checkbox-wrapper">
        <label class="daily-digest" for="digest-email-daily">
          <input type="radio" name="digest-email-option" id="digest-email-daily" value="" checked>
          <span><sc:FieldRenderer ID="frDaily" runat="server" FieldName="Daily" /></span>
        </label>
        <label class="weekly-digest" for="digest-email-weekly">
          <input type="radio" name="digest-email-option" id="digest-email-weekly" value="">
          <span><sc:FieldRenderer ID="frWeekly" runat="server" FieldName="Weekly" /></span>
        </label>
      </div>
    </fieldset>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frSupportPlanReminders" runat="server" FieldName="Support Plan Reminders" /></span>
        <input class="toggle rs_preserve" type="checkbox" value="true" checked="checked">
      </label>
    </div>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frObservationLogReminders" runat="server" FieldName="Observation Log Reminders" /></span>
        <input class="toggle rs_preserve" type="checkbox" value="true" checked="checked">
      </label>
    </div>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frEventReminders" runat="server" FieldName="Event Reminders" /></span>
        <input class="toggle rs_preserve" type="checkbox" value="true" checked="checked">
      </label>
    </div>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frContentReminders" runat="server" FieldName="Content Reminders" /></span>
        <input class="toggle rs_preserve" type="checkbox" value="true" checked="checked">
      </label>
    </div>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frAdvocacyAlerts" runat="server" FieldName="Advocacy Alerts" /></span>
        <input class="toggle rs_preserve" type="checkbox" value="true" checked="checked">
      </label>
    </div>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frPrivateMessageAlerts" runat="server" FieldName="Private Message Alerts" /></span>
        <input class="toggle rs_preserve" type="checkbox" value="true" checked="checked">
      </label>
    </div>
  </div><!-- .toggles-wrapper -->
</div>
