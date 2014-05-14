<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Newsletter_SignUp.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup.Newsletter_SignUp" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
            <!-- BEGIN PARTIAL: header -->
            <!-- #header-page -->
            <!-- END PARTIAL: header -->

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
                            <ul>
                                <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />
                                <%--<li>Get tips, videos, articles and more to support you</li>
                                <li>Hear what our community is talking about and how it can help you</li>
                                <li>Stay updated with alerts for expert webinars and live chats</li>--%>
                            </ul>
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
                                        <input type="text" placeholder="Enter email address" name="signup-newsletter-email" id="signup-newsletter-email">
                                    </div>
                                    <div class="newsletter-button-wrap">
                                        <%--<input id="signup-newsletter-button" class="button newsletter-button disabled" type="submit" value="Subscribe">--%>
                                        <asp:Button ID="btnSignup" runat="server" CssClass="button newsletter-button disabled" Text="Subscribe" />
                                    </div>
                                </fieldset>

                                <div class="safe-information-wrapper">
                                    <div class="popover-trigger-container">
                                        <a href="REPLACE" class="safe-information-link popover-link" data-popover-placement="bottom"><%--Your information is safe with us.--%>
                                            <sc:FieldRenderer ID="frSecureDataTile" runat="server" FieldName="Secure Data Title" />
                                        </a>
                                    </div>
                                    <!-- BEGIN PARTIAL: about/popover-safe-information -->
                                    <div class="safe-information popover-container">
                                        <strong><%--Understood.com--%> <%= Request.Url.Host.ToString() %></strong> <%--is an independent, not-for-profit website. We collect your information so we can make your site experience relevant for you. We will not share your information and are not affiliated with any pharmaceutical or other for-profit company. --%>
                                        <sc:FieldRenderer ID="frSecureDataDetails"  runat="server" FieldName="Secure Data Details"/>
                                        <%--<a href="REPLACE">Read our privacy policy</a>--%>
                                        
                                        <asp:LinkButton ID="lbPrivacyPageLink" runat="server"> Read our privacy policy</asp:LinkButton>
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

            <!-- BEGIN PARTIAL: footer -->



            <!-- BEGIN MODULE: More to Explore -->
            

            <!-- END MODULE: More to Explore -->

            <!-- BEGIN MODULE: Newsletter Signup -->
            
            <!-- .container .newsletter-signup -->

            <!-- END MODULE: Newsletter Signup -->

            <!-- BEGIN MODULE: Partners Carousel -->
            

            <!-- END MODULE: Partners Carousel -->

            <!-- BEGIN MODULE: Footer Nav -->
        
            <!-- .container -->

            <!-- END MODULE: Footer Nav -->

            <!-- Content wrapper for glossary term popovers -->
            <!-- BEGIN PARTIAL: glossary-term -->
            <!-- This partial is included in the footer.erb file. So this container applies to every glossary term and its contents should dynamically change depending on the glossary link. -->
            <!-- popover hidden content -->
        