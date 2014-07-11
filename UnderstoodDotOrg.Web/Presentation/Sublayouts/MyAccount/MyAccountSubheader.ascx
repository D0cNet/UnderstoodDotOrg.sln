<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyAccountSubheader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.MyAccountSubheader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container my-account-subheader notifications-subheader">
    <div class="row">
        <!-- subheader -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: my-notifications-subheader -->
            <h2 class="rs_read_this"><sc:FieldRenderer ID="frMyNotifications" FieldName="My Notifications" runat="server"/></h2>
            <!-- END PARTIAL: my-notifications-subheader -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
