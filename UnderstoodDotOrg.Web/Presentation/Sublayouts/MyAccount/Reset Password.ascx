<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reset_Password.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Reset_Password" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: reset-password -->
<div class="container reset-password flush">
    <div class="row skiplink-content" aria-role="main">
        <div class="col col-12 centered">
            <header>
                <h1>Reset Your Password</h1>
            </header>

            <p>Please create a new password. Understood passwords must have 6 characters. You can use letters and/or numbers.</p>

            <label>
                <span class="visuallyhidden">Enter new password</span>
                <input type="text" placeholder="Enter new password" aria-required="true">
            </label>

            <label>
                <span class="visuallyhidden">Re-enter new password</span>
                <input type="text" placeholder="Re-enter new password" aria-required="true">
            </label>

            <button class="button">Save</button>

        </div>
    </div>
</div>
<!-- end .forgot-password -->

<!-- END PARTIAL: reset-password -->
