<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Newsletter_SignUp.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup.Newsletter_SignUp" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<div class="container flush signup-intro-container">
    <div class="row">
        <div class="col col-22 centered skiplink-content rs_read_this" aria-role="main">
            <!-- About Sign Up Intro -->
            <!-- BEGIN PARTIAL: about/about-signup-intro -->
            <div class="icon-newsletter-wrap">
                <div class="icon-newsletter-signup rs_skip" alt="Envelope Icon"></div>
            </div>

            <header class="about-signup-header">
                <h1><%--Stay Informed--%>
                    <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                </h1>
            </header>

            <div class="about-signup-intro">
                <h3><%--Subscribe to your weekly newsletter - info and advice personalized just for you--%>
                    <sc:FieldRenderer ID="frSectionTitle" runat="server" FieldName="Section Title" />
                </h3>
                <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />
       
            </div>
            <!-- END PARTIAL: about/about-signup-intro -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container flush signup-newsletter-container">
    <div class="row">
        <div class="col col-24">
            <!-- About Sign Up Newsletter -->
            <!-- BEGIN PARTIAL: about/about-signup-newsletter -->
            <div class="signup-newsletter-form">
                <div class="form">

                    <fieldset>
                        <div class="newsletter-input-wrap">
                            <label for="signup-newsletter-email" class="visuallyhidden"></label>
                            <asp:TextBox ID="txtEmail" runat="server" />
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Static" />
                        </div>
                        <div class="newsletter-button-wrap">
                            <asp:Button ID="btnSignup" runat="server" CssClass="button newsletter-button disabled" />
                        </div>
						<div>
							<asp:Label runat="server" ID="lblEmailFail" Text="" />
						</div>
                    </fieldset>

                    <div class="safe-information-wrapper">
                        <div class="popover-trigger-container">
                            <a href="#" class="safe-information-link popover-link" data-popover-placement="bottom">
                                <sc:FieldRenderer ID="frSecureDataTile" runat="server" FieldName="Secure Data Title" />
                            </a>
                        </div>
                        <!-- BEGIN PARTIAL: about/popover-safe-information -->
                        <div class="safe-information popover-container">
                            <sc:FieldRenderer ID="frSecureDataDetails"  runat="server" FieldName="Secure Data Details"/>
                        </div>
                        <!-- END PARTIAL: about/popover-safe-information -->
                    </div>


                </div>
                <!-- .form -->
            </div>
            <!-- END PARTIAL: about/about-signup-newsletter -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
