<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TermsAndConditions.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.TermsAndConditions" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container sign-up-link flush">
    <div class="row">
        <div class="col col-23">
            <p class="signed-up">Already signed up? <asp:HyperLink ID="hypSignIn" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.SignInButtonText%></asp:HyperLink></p>
        </div>
    </div>
</div>
<div class="container sign-up-terms flush">
    <div class="row">
        <!-- article -->
        <div class="col col-24 centered">
            <!-- BEGIN PARTIAL: sign-up-terms -->
            <div class="terms-wrapper skiplink-content" aria-role="main">
                <div class="terms-container">
                    <div class="rs_read_this terms-container-rs-wrapper">
                        <div class="terms-head">
                            <h1>
                                <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                            </h1>
                            <h2>
                                <sc:FieldRenderer ID="frTermsandConditionsTitle" runat="server" FieldName="Terms and Conditions Title" />
                            </h2>
                        </div>
                        <div class="terms-content" tabindex="0">
                            <sc:FieldRenderer ID="frTermsandConditionsText" runat="server" FieldName="Terms and Conditions Text" />
                        </div>
                        <div class="terms-buttons">
                            <asp:Button ID="btnAgree" CssClass="button answer-agree rs_skip" runat="server" OnClick="btnAgree_Click" />
                            <asp:Button ID="btnNotAgree" CssClass="button gray answer-do-not-agree rs_skip" runat="server" OnClick="btnNotAgree_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- END PARTIAL: sign-up-terms -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
