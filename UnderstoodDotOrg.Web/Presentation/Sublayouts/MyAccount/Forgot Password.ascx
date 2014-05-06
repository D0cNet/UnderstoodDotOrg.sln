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
                            <h1><%--Forgot Your Password?--%>
                                <sc:Text id="pageHeading" runat="server" field="Page Title"></sc:Text>
                            </h1>
                        </header>
                        <p class="intro-text"><%--No worries. We'll send you an email with a link to reset it.--%>
                            <sc:Text id="directions" runat="server" field="Directions"></sc:Text>
                        </p>
                        <label>
                            <%--<span class="visuallyhidden">Enter email address</span>--%>
                            <%--<input type="text" placeholder="Enter email address">--%>
                            <asp:TextBox runat="server" ID="uxEmailAddress"></asp:TextBox>
                        </label>
                        <%--<button class="button submit">Submit</button>--%>
                        <asp:Button runat="server" ID="uxSubmit" CssClass="button submit" OnClick="uxSubmit_Click" />
                        <%--<button class="button gray">Cancel</button>--%>
                        <asp:Button runat="server" ID="uxCancel" CssClass="button gray" OnClick="uxCancel_Click" />
                        <%--<p>Hint: Understood passwords have 6 or more characters.</p>
                        <p>Remembered it? <a href="REPLACE">Go back to log in.</a></p>--%>
                        <sc:Text runat="server" id="hint" field="Hint Text"></sc:Text>
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
                        <h1><%--Forgot Your Password?--%>
                            <sc:Text id="PageHeadingConfirmation" runat="server" field="Page Title"></sc:Text>
                        </h1>
                    </header>
                    <div class="confirmation-message">
                        <%--<p class="message">We've sent an email to <strong>Johndoe@email.com</strong> with a link to reset your password.</p>
                        <p>If you need additional help, please <a href="REPLACE">contact us</a>.</p>--%>
                        <asp:Literal ID="uxSuccessStory" runat="server"></asp:Literal>
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




