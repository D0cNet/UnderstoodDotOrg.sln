<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Forgot_Password.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Forgot_Password" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:MultiView ID="uxView" runat="server" ActiveViewIndex="0">
    <asp:View ID="uxForgotPassword" runat="server">
        <!-- BEGIN PARTIAL: forgot-password -->
        <div class="container forgot-password flush">
            <div class="row skiplink-content" aria-role="main">
                <div class="col col-12 centered">
                    <section>
                        <header>
                            <h1>Forgot Your Password?</h1>
                        </header>
                        <p class="intro-text">No worries. We'll send you an email with a link to reset it.</p>
                        <label>
                            <span class="visuallyhidden">Enter email address</span>
                            <input type="text" placeholder="Enter email address">
                        </label>
                        <button class="button submit">Submit</button>
                        <button class="button gray">Cancel</button>
                        <p>Hint: Understood passwords have 6 or more characters.</p>
                        <p>Remembered it? <a href="REPLACE">Go back to log in.</a></p>
                    </section>
                </div>
            </div>
        </div>
        <!-- END PARTIAL: forgot-password -->
    </asp:View>

    <asp:View ID="uxForgotPasswordConfirmation" runat="server">
        <!-- BEGIN PARTIAL: forgot-password-confirmation -->
        <div class="container forgot-password-confirmation flush">
            <div class="row skiplink-content" aria-role="main">
                <div class="col col-12 centered">
                    <header>
                        <h1>Forgot Your Password?</h1>
                    </header>
                    <div class="confirmation-message">
                        <p class="message">We've sent an email to <strong>Johndoe@email.com</strong> with a link to reset your password.</p>
                        <p>If you need additional help, please <a href="REPLACE">contact us</a>.</p>
                        <!-- end .message -->
                    </div>
                    <!-- end .confirmation-message -->
                </div>
            </div>
        </div>
        <!-- end .forgot-password -->
        <!-- END PARTIAL: forgot-password-confirmation -->
    </asp:View>
</asp:MultiView>




