<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Footer" %>

<!-- BEGIN MODULE: Newsletter Signup -->
<div class="container">
    <div class="row">

        <!-- FIXME: discard this div and move the .newsletter-signup class to div.container element for consistency -->
        <div class="newsletter-signup">

            <div class="col col-12">

                <header>
                    <h2>Personalized Email</h2>
                    <p>Stay connected with us by signing up for our weekly personalized emails.</p>
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
                        <input type="submit" class="submit-button" value="Sign Up">
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
            <div id="partners-slides-container" class="arrows-gray">
                <ul>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                    <li>
                        <a href="REPLACE.html">
                            <img alt="Partner Logo FPO" src="/Presentation/includes/img/icon.logo.partnership-carousel.png" /></a>
                    </li>
                </ul>
            </div>
            <!-- end partners-carousel-container -->
            <a class="viewAll" href="REPLACE.html">View All</a>
            <!-- END PARTIAL: partners-carousel -->

        </div>
    </div>
</div>

<!-- END MODULE: Partners Carousel -->
<!-- BEGIN MODULE: Footer Nav -->
<div class="container">
    <div class="row">
        <div class="col col-24" role="navigation">

            <ul id="footer-nav" role="menu">
                <li role="menuitem"><a href="REPLACE.html"><span>About Us</span></a></li>
                <li role="menuitem"><a href="REPLACE.html"><span>Learning &amp; Attention Issues</span></a></li>
                <li role="menuitem"><a href="REPLACE.html"><span>School &amp; Learning</span></a></li>
                <li role="menuitem"><a href="REPLACE.html"><span>Friends &amp; Feelings</span></a></li>
                <li role="menuitem"><a href="REPLACE.html"><span>You &amp; Your Family</span></a></li>
                <li role="menuitem"><a href="REPLACE.html"><span>Community &amp; Events</span></a></li>
            </ul>
            <!-- #footer-nav -->

        </div>
    </div>
    <!-- .row -->
</div>
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

        <div class="col col-7 push-17">
            <ul>
                <!-- NO WHITE SPACE BETWEEN LIs to PRESERVE LAYOUT -->
                <li><a href="REPLACE.html" class="icon icon-facebook">Facebook</a></li>
                <li><a href="REPLACE.html" class="icon icon-twitter">Twitter</a></li>
                <li><a href="REPLACE.html" class="icon icon-google">Google +</a></li>
                <li><a href="REPLACE.html" class="icon icon-pinterest">Pinterest</a></li>
            </ul>
        </div>
        <!-- /.col -->

        <div class="col col-17 pull-7" role="navigation">
            <ul class="footer-nav-utility" role="menu">
                <!-- NO WHITE SPACE BETWEEN LIs to PRESERVE LAYOUT -->
                <li role="menuitem"><a href="REPLACE.html">Sitemap</a></li>
                <li role="menuitem"><a href="REPLACE.html">Terms &amp; Conditions</a></li>
                <li role="menuitem"><a href="REPLACE.html">Contact Us</a></li>
                <li role="menuitem"><a href="REPLACE.html">About</a></li>
            </ul>
            <p>All contents copyright © 2013 Understood.  All rights reserved.</p>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum id congue nibh, sit amet aliquet nisi. Donec velit nunc, semper a faucibus at, varius sit amet metus. Maecenas id magna condimentum, vehicula sapien ac, laoreet elit. In hac habitasse platea dictumst.</p>
        </div>
        <!-- .col -->

    </div>
    <!-- .row .footer-social -->

    <div class="row">
        <div class="col col-24">

            <img class="logo-u-footer" alt="Understood U Logo" src="/Presentation/includes/img/logo.u.footer.png" />

        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</footer>
<!-- footer .container -->

<!-- END MODULE: Footer -->
<!-- END PARTIAL: footer -->
