<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Newsletter_Thankyou.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup.Newsletter_Thankyou" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<div class="container l-sign-up-confirm">
    <div class="row">
        <div class="col col-22 centered rs_read_this email-sign-up-rs-wrapper">
            <!-- BEGIN PARTIAL: about/about-sign-up-confirm -->
            <header>
                <h1><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></h1>
                <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />
            </header>

            <div class="social-wrap centered skiplink-content" aria-role="main">
                <!-- BEGIN PARTIAL: about/about-thank-you-social -->
                <!-- Adding spaces or line breaks here will cause unwanted space between elements -->
               <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/About/Widgets/ThankYouSocial.ascx" />
                <!-- END PARTIAL: about/about-thank-you-social -->
            </div>
            <!-- END PARTIAL: about/about-sign-up-confirm -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container flush l-sign-up-recommended">
    <div class="row">
        <div class="col col-24 skiplink-feature">
            <!-- BEGIN PARTIAL: about/sign-up-recommended -->
            <div class="container recommended-intro">
                <div class="row">
                    <div class="col col-11 offset-1">
                        <h2 class="rs_read_this">Just For You</h2>
                    </div>
                </div>
            </div>

            <div class="container recommended-grid">

                <div class="row">
                    <div class="col col-11 offset-1 recommended-column">
                        <div class="recommended-item clearfix rs_read_this">
                            <div class="recommended-image">
                                <a href="REPLACE">
                                    <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                            </div>
                            <div class="recommended-title">
                                <h3><a href="REPLACE">Ab Nisi Qui Rerum Atque</a></h3>
                            </div>
                        </div>
                    </div>
                    <div class="col col-11 offset-1 recommended-column">
                        <div class="recommended-item clearfix rs_read_this">
                            <div class="recommended-image">
                                <a href="REPLACE">
                                    <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                            </div>
                            <div class="recommended-title">
                                <h3><a href="REPLACE">Veniam Possimus Ratione Harum Et</a></h3>
                            </div>
                        </div>
                    </div>
                    <div class="col col-11 offset-1 recommended-column">
                        <div class="recommended-item clearfix rs_read_this">
                            <div class="recommended-image">
                                <a href="REPLACE">
                                    <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                            </div>
                            <div class="recommended-title">
                                <h3><a href="REPLACE">Enim Qui Earum Cupiditate Odit</a></h3>
                            </div>
                        </div>
                    </div>
                    <div class="col col-11 offset-1 recommended-column">
                        <div class="recommended-item clearfix rs_read_this">
                            <div class="recommended-image">
                                <a href="REPLACE">
                                    <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                            </div>
                            <div class="recommended-title">
                                <h3><a href="REPLACE">Est Error Sint Velit Deleniti</a></h3>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!-- END PARTIAL: about/sign-up-recommended -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
