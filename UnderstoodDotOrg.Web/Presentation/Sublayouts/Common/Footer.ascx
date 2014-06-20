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
                        <label for="personalized-email-email" class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.EnterEmailAddressWatermark %></label>
                        <input id="personalized-email-email" name="personalized-email-email" type="text" placeholder="<%= UnderstoodDotOrg.Common.DictionaryConstants.EnterEmailAddressWatermark %>" aria-required="true" />
                    </fieldset>
                    <div class="submit-button-wrap">
                        <input type="submit" class="button" data-path="<%= NewsletterSignUpUrl %>" value="<%= UnderstoodDotOrg.Common.DictionaryConstants.FooterNewsletterButtonText %>" />
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
            <h2><%--In Partnership with--%>
               <sc:FieldRenderer ID="frPartnership" runat="server" FieldName="Partnership Label" />
            </h2>
            <asp:Repeater runat="server" ID="rptPartnerships" OnItemDataBound="rptPartnerships_ItemDataBound">
                <HeaderTemplate>
                    <div id="partners-slides-container" class="arrows-gray">
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><asp:HyperLink runat="server" ID="hlLink">
                        <sc:Image runat="server" ID="scImage" Field="Partner Logo" Parameters="mw=214&mh=100" />
                    </asp:HyperLink></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <!-- end partners-carousel-container -->
            <asp:HyperLink ID="hlViewAllPartners" CssClass="viewAll" runat="server"><%= ViewAllLabel %></asp:HyperLink>
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
                    <asp:HyperLink ID="hypSocialLink" runat="server"></asp:HyperLink>
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
