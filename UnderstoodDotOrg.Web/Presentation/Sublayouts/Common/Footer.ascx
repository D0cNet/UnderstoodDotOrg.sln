<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Footer" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN MODULE: Newsletter Signup -->
<div class="container">
    <div class="row">

        <!-- FIXME: discard this div and move the .newsletter-signup class to div.container element for consistency -->
        <div class="newsletter-signup">

            <div class="col col-12">

                <header>
                    <h2><%--Personalized Email--%>
                        <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Personalized Email Label" />
                    </h2>
                    <p>
                        <%--Stay connected with us by signing up for our weekly personalized emails.--%>
                        <sc:FieldRenderer ID="frEmailAbstract" runat="server" FieldName="Email Abstract" />
                    </p>
                </header>

            </div>
            <!-- .col -->

            <div class="col col-12">

                <div class="form personalized-email-form">
                    <fieldset class="input-wrap">
                        <label for="personalized-email-email" class="visuallyhidden">Enter Email Address</label>
                        <input type="email" name="personalized-email" id="personalized-email-email" placeholder="Enter email address" aria-required="true">
                    </fieldset>
                    <div class="submit-button-wrap">
                        <input type="submit" class="button" value="Sign Up">
                    </div>
                </div>

            </div>
            <!-- .col -->

        </div>
        <!-- .newsletter-signup -->

    </div>
    <!-- .row -->
</div>
<!-- .container -->

<!-- END MODULE: Newsletter Signup -->

<!-- BEGIN MODULE: Partners Carousel -->

<div class="container partners-carousel">
    <div class="row">
        <div class="col col-24">

            <!-- BEGIN PARTIAL: partners-carousel -->
            <h2>In Partnership with</h2>
            <div class="arrows-gray rsAutoHeight rsHor" id="partners-slides-container" style="height: 380px;">
                <div class="rsOverflow" style="width: 950px; height: 186px; transition: height 600ms ease-in-out 0s;">
                    <div class="rsContainer" style="transition-duration: 0s; transform: translate3d(0px, 0px, 0px);">
                        <%-- <div class="rsSlide " style="left: 0px;">
                            <div class="m-featured-slide" style="visibility: visible; opacity: 1; transition: opacity 400ms ease-in-out 0s;">
                                <div class="rsContent">
                                    <ul>
                                      
                                    </ul>
                                </div>
                            </div>
                        </div>--%>
                        <div class="rsSlide " style="left: 958px;">
                            <%--<div class="m-featured-slide">
                                <div class="rsContent">--%>
                            <%--    <ul>
                                          <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                        <li>
                                            <a href="REPLACE">
                                                <img src="Presentation/includes/img/icon.logo.partnership-carousel.png" alt="Partner Logo FPO"></a>
                                        </li>
                                    </ul>--%>
                             <h2>
                <sc:FieldRenderer ID="frPartnership" runat="server" FieldName="Partnership Label" />
            </h2>
                            <asp:Repeater ID="rptPartnerships" runat="server" OnItemDataBound="rptPartnerships_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="m-featured-slide">
                                        <div class="rsContent">
                                            <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <asp:HyperLink ID="hlLink" runat="server">
                                            <sc:Image ID="scImage" runat="server" Field="Image" />
                                        </asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                    </div>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <%--   </div>
                    </div>--%>
                        </div>
                    </div>
                    <div class="rsArrow rsArrowLeft rsArrowDisabled" style="display: block;">
                        <div class="rsArrowIcn"></div>
                    </div>
                    <div class="rsArrow rsArrowRight" style="display: block;">
                        <div class="rsArrowIcn"></div>
                    </div>
                </div>
                <div style="clear: both; float: none;"></div>
            </div>
            <!-- end partners-carousel-container -->
            <a href="REPLACE" class="viewAll">View All</a>
            <!-- END PARTIAL: partners-carousel -->

        </div>
    </div>
</div>

<div class="container partners-carousel" runat="server" id="sfds" visible="false">
    <div class="row">
        <div class="col col-24">

            <!-- BEGIN PARTIAL: partners-carousel -->
            <h2><%--In Partnership with--%>
               <%-- <sc:FieldRenderer ID="frPartnership" runat="server" FieldName="Partnership Label" />--%>
            </h2>
            <%--<asp:Repeater runat="server" ID="rptPartnerships" OnItemDataBound="rptPartnerships_ItemDataBound">
                <HeaderTemplate>
                    <div id="partners-slides-container" class="arrows-gray">
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="hlLink">
                        <sc:Image runat="server" ID="scImage" Field="Image" />
                    </asp:HyperLink>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                    </div>
                </FooterTemplate>
            </asp:Repeater>--%>
            <!-- end partners-carousel-container -->
            <a class="viewAll" href="REPLACE.html">View All</a>
            <!-- END PARTIAL: partners-carousel -->

        </div>
    </div>
</div>

<!-- END MODULE: Partners Carousel -->
<!-- BEGIN MODULE: Footer Nav -->
<asp:Repeater runat="server" ID="rptFooterNav" OnItemDataBound="rptFooterNav_ItemDataBound">
    <HeaderTemplate>
        <div class="container">
            <div class="row">
                <div class="col col-24" role="navigation">

                    <ul id="footer-nav" role="menu">
    </HeaderTemplate>
    <ItemTemplate>
        <li role="menuitem"><%--<a href="REPLACE.html"><span>About Us</span></a>--%>
            <sc:FieldRenderer runat="server" ID="frLink" FieldName="Link" />
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
            <!-- #footer-nav -->
        </div>
    </div>
    <!-- .row -->
        </div>
    </FooterTemplate>
</asp:Repeater>

<!-- .container -->

<!-- END MODULE: Footer Nav -->

<!-- Content wrapper for glossary term popovers -->
<!-- BEGIN PARTIAL: glossary-term -->
<!-- This partial is included in the footer.erb file. So this container applies to every glossary term and its contents should dynamically change depending on the glossary link. -->
<!-- popover hidden content -->
<div class="glossary-term-content-wrapper popover-container">
    <blockquote>
        <span>Dyslexia:</span> Difficulty in reading, spelling, writing, and related language skills that results from an impairment in the way the brain processes information &hellip; <a href="REPLACE.html">View Glossary</a>
    </blockquote>
</div>
<!-- END PARTIAL: glossary-term -->
<!-- BEGIN MODULE: Footer -->
<footer class="container" id="footer-page">
    <div class="row footer-social">

        <asp:Repeater runat="server" ID="rptSocialMedias" OnItemDataBound="rptSocialMedias_ItemDataBound">
            <HeaderTemplate>
                <div class="col col-7 push-17">
                    <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li><%--<a href="REPLACE.html" class="icon icon-facebook">Facebook</a>--%>
                    <sc:FieldRenderer runat="server" ID="frSocialMediaLink" FieldName="" />
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
        </div>
            </FooterTemplate>
        </asp:Repeater>

        <div class="col col-17 pull-7" role="navigation">
            <asp:Repeater runat="server" ID="rptFooterUtilityNav" OnItemDataBound="rptFooterUtilityNav_ItemDataBound">
                <HeaderTemplate>
                    <ul class="footer-nav-utility" role="menu">
                </HeaderTemplate>
                <ItemTemplate>
                    <li role="menuitem"><%--<a href="REPLACE.html">Sitemap</a>--%>
                        <sc:FieldRenderer runat="server" ID="frLink" FieldName="Link" />
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
            <p>
                <%--All contents copyright © 2013 Understood.  All rights reserved.--%>
                <sc:FieldRenderer ID="frCopyrightText" runat="server" FieldName="Copyright Text" />
            </p>
            <p>
                <%--Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum id congue nibh, sit amet aliquet nisi. Donec velit nunc, semper a faucibus at, varius sit amet metus. Maecenas id magna condimentum, vehicula sapien ac, laoreet elit. In hac habitasse platea dictumst.--%>
                <sc:FieldRenderer ID="frAbstract" runat="server" FieldName="Abstract" />
            </p>
        </div>
        <!-- .col -->

    </div>
    <!-- .row .footer-social -->

    <div class="row">
        <div class="col col-24">

            <%-- <img class="logo-u-footer" alt="Understood U Logo" src="/Presentation/includes/img/logo.u.footer.png" />--%>
            <sc:FieldRenderer runat="server" ID="scLogoImage" FieldName="Logo" Parameters="class=logo-u-footer&w=24&h=47&as=1" />
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</footer>
<!-- footer .container -->

<!-- END MODULE: Footer -->
<!-- END PARTIAL: footer -->
