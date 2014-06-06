<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountBody.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountBody" %>

<!-- BEGIN PARTIAL: sign-in-prompt-links -->
<div class="sign-in-prompt-links" id="divNotSignedIn" runat="server" visible="false">
    <div class="rs_read_this row">
        <img alt=" " src="../images/icon.sign-in-prompt.lock.png" />
        <h3>This User&#39;s Profile is currently private</h3>
        <h5>Parent profiles are only visible to logged-in members</h5>
        <h4><a href="REPLACE">Sign in</a> or <a href="REPLACE">Sign up</a> to view more</h4>
    </div>
</div>
<!-- END PARTIAL: sign-in-prompt-links -->

<!-- BEGIN PARTIAL: sign-in-prompt -->
<div class="sign-in-prompt" id="divPrivateProfile" runat="server" visible="false">
    <img alt=" " src="../images/icon.sign-in-prompt.lock.png" />
    <h3>This User&#39;s Profile is currently private</h3>
</div>
<!-- END PARTIAL: sign-in-prompt -->