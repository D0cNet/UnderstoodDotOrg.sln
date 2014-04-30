<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignUp.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.SignUp" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: sign-up -->
<div class="container sign-in-link flush">
    <div class="row">
        <div class="col col-23">
            <p>Already signed up? <a href="REPLACE">Sign In</a></p>
        </div>
    </div>
</div>
<div class="container sign-up">
    <div class="row skiplink-content" aria-role="main">
        <div class="col col-16 offset-5">
            <h1><%--Sign Up--%>
                <sc:Text ID="pageTitle" runat="server" Field="Page Title" />
            </h1>
            <a class="fb-sign-in" href="REPLACE">
                <img alt="facebook" src="/Presentation/includes/images/icon.fb-sign-in@2x.png" /> <%--wire up to FB--%>
            </a>
            <%--<p>Or create an account using your email address</p>--%>
            <p>
                <sc:Text ID="pageDirections" runat="server" Field="Directions" />
            </p>
            <div class="sign-up-inputs">
                <label class="first-name error">
                    <%--<input type="text" placeholder="First name" aria-required="true">--%>
                    <asp:TextBox runat="server" ID="uxFirstName" aria-required="true"></asp:TextBox>
                    <span><%--* Please enter your first name--%>
                        <%= UnderstoodDotOrg.Common.DictionaryConstants.FirstNameErrorMessage %>
                    </span>
                </label>
                <%--<p>we only need your first name</p>--%>
                <p>
                    <%= UnderstoodDotOrg.Common.DictionaryConstants.FirstNameMessage %>
                </p>
                <label class="email-address error">
                    <%--<input type="text" placeholder="Enter email address" aria-required="true">--%>
                    <asp:TextBox runat="server" ID="uxEmailAddress" aria-required="true"></asp:TextBox>
                    <span><%--* It looks like you mistyped your email address. Please try again.--%>
                        <%= UnderstoodDotOrg.Common.DictionaryConstants.FirstNameErrorMessage %>
                    </span>
                </label>
                <label class="enter-password error">
                    <%--<input type="text" placeholder="Enter password" aria-required="true">--%>
                    <asp:TextBox runat="server" ID="uxPassword" aria-required="true" TextMode="Password"></asp:TextBox>
                    <span><%--* Please create a password that has 6 or more characters. You can use letters and/or numbers.--%>
                        <%= UnderstoodDotOrg.Common.DictionaryConstants.PasswordErrorMessage %>
                    </span>
                </label>
                <p><%--password must be at least 6 characters--%>
                    <%= UnderstoodDotOrg.Common.DictionaryConstants.PasswordMessage %>
                </p>
                <label class="re-enter-password error">
                    <%--<input type="text" placeholder="Re-enter Password" aria-required="true">--%>
                    <asp:TextBox runat="server" ID="uxPasswordConfirm" aria-required="true" TextMode="Password"></asp:TextBox>
                    <span><%--* Please retype your password to match your password above--%>
                        <%= UnderstoodDotOrg.Common.DictionaryConstants.ConfirmPasswordErrorMessage %>
                    </span>
                </label>
                <div class="zip-code error">
                    <label>
                        <%--<input type="text" placeholder="Zip code (optional)">--%>
                        <asp:TextBox runat="server" ID="uxZipCode"></asp:TextBox>
                    </label>
                    <p class="why-do-we-ask-container"><%--optional--%><%= UnderstoodDotOrg.Common.DictionaryConstants.OptionalMessage %> <a class="why-do-we-ask popover-link" href="REPLACE" data-popover-placement="bottom">Why do we ask?</a></p>

                    <div class="why-do-we-ask-popover popover-container">
                        <div class="why-do-we-ask-content">
                            <%--We ask for a screenname so other parents in the community can offer you support and get connected with you. You can always choose not to connect with other parents.--%>
                            Lorem Ipsum Insert Content About Zipcodes
                        </div>
                    </div>
                    <span><%--* It looks like you mistyped your zip code. Please try again.--%>
                        <%= UnderstoodDotOrg.Common.DictionaryConstants.ZipCodeErrorMessage %>
                    </span>
                </div>
            </div>

            <div class="sign-up-newsletter">
                <label for="email-checkbox">
                    <%--<input type="checkbox" id="email-checkbox" checked>--%>
                    <asp:CheckBox runat="server" ID="uxNewsletterSignup" Checked="true" />
                    <span><%--Yes, send me my email newsletter, customized for me and my family.--%>
                        <sc:Text ID="newsletterDescription" runat="server" Field="Newsletter Description" />
                    </span>
                </label>

                <p>
                    <%--By signing up for Understood.org I acknowledge that I reside in the United States and am at least 13 years old.--%>
                    <sc:Text ID="acknowledgeMessage" runat="server" Field="Acknowledge message" />
                </p>

                <%--<button class="button">Sign Up</button>--%>
                <asp:Button runat="server" ID="uxSubmit" CssClass="button" OnClick="uxSubmit_Click" />

                <div class="we-take-your-privacy-seriously-container">
                    <a class="we-take-your-privacy-seriously popover-link" href="REPLACE" data-popover-placement="bottom"><%--We take your privacy seriously--%>
                        <sc:Text ID="privacyLink" runat="server" Field="Privacy link text" />
                    </a>
                </div>

                <div class="we-take-your-privacy-seriously-popover popover-container">
                    <div class="we-take-your-privacy-seriously-content">
                        <strong>Understood.com</strong> is an independent, not-for-profit website. We collect your information so we can make your site experience relevant for you. We will not share your information and are not affiliated with any pharmaceutical or other for-profit company. <a href="REPLACE">Read our privacy policy</a>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>
<!-- END PARTIAL: sign-up -->
