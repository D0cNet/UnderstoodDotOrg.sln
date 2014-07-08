<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignUp.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.SignUp" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: sign-up -->
<div class="container sign-in-link flush">
    <div class="row">
        <div class="col col-23">
            <p>Already signed up? <%--<a href="\My Account\Sign In">Sign In</a>--%><asp:HyperLink ID="uxSignIn" runat="server"></asp:HyperLink></p>
        </div>
    </div>
</div>
<div class="container sign-up">
    <div class="row skiplink-content" aria-role="main">
        <div class="col col-16 offset-5">
            <h1><%--Sign Up--%>
                <sc:text id="pageTitle" runat="server" field="Page Title" />
            </h1>
            <a class="fb-sign-in" href="#">
                <img alt="facebook" src="/Presentation/includes/images/icon.fb-sign-in@2x.png" />
                <%--wire up to FB--%>
            </a>
            <div id="fb-root"></div>
            <%--<p>Or create an account using your email address</p>--%>
            <p>
                <sc:text id="pageDirections" runat="server" field="Directions" />
            </p>
            <div class="sign-up-inputs">
                <%--TODO: add .error to the labels to show validation error messages--%>
                <label class="first-name">
                    <%--<input type="text" placeholder="First name" aria-required="true">--%>
                    <asp:TextBox runat="server" ID="uxFirstName" aria-required="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valFirstName" ControlToValidate="uxFirstName" runat="server" CssClass="validationerror"></asp:RequiredFieldValidator>
                    <%--<span>--%><%--* Please enter your first name--%>
                    <%--<%= UnderstoodDotOrg.Common.DictionaryConstants.FirstNameErrorMessage %>--%>
                    <%--</span>--%>
                </label>
                <%--<p>we only need your first name</p>--%>
                <p>
                    <%= UnderstoodDotOrg.Common.DictionaryConstants.FirstNameMessage %>
                </p>
                <label class="email-address">
                    <%--<input type="text" placeholder="Enter email address" aria-required="true">--%>
                    <asp:TextBox runat="server" ID="uxEmailAddress" aria-required="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="uxEmailAddress" CssClass="validationerror"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valRegEmail" runat="server" ControlToValidate="uxEmailAddress" CssClass="validationerror"></asp:RegularExpressionValidator>
                    <%--<span>* It looks like you mistyped your email address. Please try again.
                        <%= UnderstoodDotOrg.Common.DictionaryConstants.FirstNameErrorMessage %>
                    </span>--%>
                </label>
                <label class="enter-password">
                    <%--<input type="text" placeholder="Enter password" aria-required="true">--%>
                    <asp:TextBox runat="server" ID="uxPassword" aria-required="true" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="uxPassword" CssClass="validationerror"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valRegPassword" runat="server" ControlToValidate="uxPassword" CssClass="validationerror"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="valCompPassword" runat="server" ControlToValidate="uxPassword" ControlToCompare="uxPasswordConfirm" CssClass="validationerror"></asp:CompareValidator>
                    <%--<span>* Please create a password that has 6 or more characters. You can use letters and/or numbers.
                        <%= UnderstoodDotOrg.Common.DictionaryConstants.PasswordErrorMessage %>
                    </span>--%>
                </label>
                <p>
                    <%--password must be at least 6 characters--%>
                    <%= UnderstoodDotOrg.Common.DictionaryConstants.PasswordMessage %>
                </p>
                <label class="re-enter-password">
                    <%--<input type="text" placeholder="Re-enter Password" aria-required="true">--%>
                    <asp:TextBox runat="server" ID="uxPasswordConfirm" aria-required="true" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valPasswordConfirm" runat="server" ControlToValidate="uxPasswordConfirm" CssClass="validationerror"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valRegPasswordConfirm" runat="server" ControlToValidate="uxPasswordConfirm" CssClass="validationerror"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="valCompPasswordConfirm" runat="server" ControlToValidate="uxPasswordConfirm" ControlToCompare="uxPassword" CssClass="validationerror"></asp:CompareValidator>
                    <%--<span>* Please retype your password to match your password above
                        <%= UnderstoodDotOrg.Common.DictionaryConstants.ConfirmPasswordErrorMessage %>
                    </span>--%>
                </label>
                <div class="zip-code">
                    <label>
                        <%--<input type="text" placeholder="Zip code (optional)">--%>
                        <asp:TextBox runat="server" ID="uxZipCode"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="valZipCode" runat="server" ControlToValidate="uxZipCode" CssClass="validationerror"></asp:RegularExpressionValidator>
                    </label>
                    <p class="why-do-we-ask-container">
                        <%--optional--%><%= UnderstoodDotOrg.Common.DictionaryConstants.OptionalMessage %> <a class="why-do-we-ask popover-link" href="REPLACE" data-popover-placement="bottom">
                            <sc:text id="zipLinkText" runat="server" field="Zip Code Link Text" />
                        </a>
                    </p>

                    <div class="why-do-we-ask-popover popover-container">
                        <div class="why-do-we-ask-content">
                            <%--We ask for a screenname so other parents in the community can offer you support and get connected with you. You can always choose not to connect with other parents.--%>
                            <%--Lorem Ipsum Insert Content About Zipcodes--%>
                            <sc:text id="zipMessage" runat="server" field="Zip Code Message" />
                        </div>
                    </div>
                    <%--<span>* It looks like you mistyped your zip code. Please try again.
                        <%= UnderstoodDotOrg.Common.DictionaryConstants.ZipCodeErrorMessage %>
                    </span>--%>
                </div>
            </div>

            <div class="sign-up-newsletter">
                <asp:Label runat="server" AssociatedControlID="uxNewsletterSignup">
                    <%--<input type="checkbox" id="email-checkbox" checked>--%>
                    <asp:CheckBox runat="server" ID="uxNewsletterSignup" Checked="true" />
                    <span><%--Yes, send me my email newsletter, customized for me and my family.--%>
                        <sc:text id="newsletterDescription" runat="server" field="Newsletter Description" />
                    </span>
                </asp:Label>

                <p>
                    <%--By signing up for Understood.org I acknowledge that I reside in the United States and am at least 13 years old.--%>
                    <sc:text id="acknowledgeMessage" runat="server" field="Acknowledge message" />
                </p>

                <%--<button class="button">Sign Up</button>--%>
                <asp:Button runat="server" ID="uxSubmit" CssClass="button" OnClick="uxSubmit_Click" CausesValidation="false" OnClientClick="return validate();" />

                <div>
                    <asp:Literal ID="uxErrorMessage" runat="server"></asp:Literal>
                </div>


                <div class="we-take-your-privacy-seriously-container">
                    <a class="we-take-your-privacy-seriously popover-link" href="REPLACE" data-popover-placement="bottom"><%--We take your privacy seriously--%>
                        <sc:text id="privacyLink" runat="server" field="Privacy link text" />
                    </a>
                </div>

                <div class="we-take-your-privacy-seriously-popover popover-container">
                    <div class="we-take-your-privacy-seriously-content">
                        <strong><%= UnderstoodDotOrg.Common.DictionaryConstants.UnderstoodText %></strong> <sc:FieldRenderer ID="frWeTakePrivacySeriously" runat="server" FieldName="We Take Privacy Seriously Text"></sc:FieldRenderer> <sc:Link ID="linkPrivacy" runat="server" Field="Privacy Policy Link"></sc:Link>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>
<!-- END PARTIAL: sign-up -->
