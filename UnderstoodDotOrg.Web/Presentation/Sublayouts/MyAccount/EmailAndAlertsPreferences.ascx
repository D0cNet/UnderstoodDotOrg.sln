<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailAndAlertsPreferences.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.EmailAndAlertsPreferences" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="account-body-wrapper">
          <!-- BEGIN PARTIAL: account-notification-tab-email -->
<div class="account-notifications-tab-email rs_read_this">
  <h2><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></h2>
  <div class="toggles-wrapper">
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frWeeklyPersonalizedNewsletter" runat="server" FieldName="Weekly Personalized Newsletter" /></span>
          <asp:CheckBox class="toggle rs_preserve" type="checkbox" id="ux_weekly_personalized_newsletter" value="true"   runat="server" />
      </label>
    </div>
    <fieldset>
      <div class="toggle-wrapper">
        <label>
          <span><sc:FieldRenderer ID="frNotificationsDigest" runat="server" FieldName="Notifications Digest" /></span>
          <asp:CheckBox runat="server" class="toggle rs_preserve" type="checkbox"  id="ux_notifications_digest" checked="false"/>
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
        <asp:CheckBox runat="server" id="ux_support_plan_reminders" class="toggle rs_preserve" type="checkbox" value="true" />
      </label>
    </div>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frObservationLogReminders" runat="server" FieldName="Observation Log Reminders" /></span>
        <asp:CheckBox runat="server" id="ux_observation_log_reminders" class="toggle rs_preserve" type="checkbox" value="true"  />
      </label>
    </div>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frEventReminders" runat="server" FieldName="Event Reminders" /></span>
        <asp:CheckBox runat="server" id="ux_event_reminders" class="toggle rs_preserve" type="checkbox" value="true" />
      </label>
    </div>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frContentReminders" runat="server" FieldName="Content Reminders" /></span>
        <asp:CheckBox runat="server" id="ux_content_reminders" class="toggle rs_preserve" type="checkbox" value="true" />
      </label>
    </div>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frAdvocacyAlerts" runat="server" FieldName="Advocacy Alerts" /></span>
        <asp:CheckBox runat="server" id="ux_advocacy_alerts" class="toggle rs_preserve" type="checkbox" value="true" />
      </label>
    </div>
    <div class="toggle-wrapper">
      <label>
        <span><sc:FieldRenderer ID="frPrivateMessageAlerts" runat="server" FieldName="Private Message Alerts" /></span>
        <asp:CheckBox runat="server" id="ux_private_message_alerts" class="toggle rs_preserve" type="checkbox" value="true" />
      </label>
    </div>    
  </div><!-- .toggles-wrapper -->
          

</div>
        <%--<button class="button">Save</button>--%>
          <asp:Button runat="server" ID="uxSave" OnClick="uxSave_Click" CssClass="button" text="Submit"/>
          <asp:Literal ID="uxMessage" runat="server"></asp:Literal>
      
</div>
