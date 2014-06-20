<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotFoundPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Errors.NotFoundPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container flush l-about-hero-intro">
    <!-- This is a shared module -->
    <!-- BEGIN PARTIAL: about/about-hero-image -->
    <!-- This is a shared module -->
    <section class="about-hero-container">
        <sc:FieldRenderer ID="frHeroImage" runat="server" FieldName="Hero Image" Parameters="mw=1200&mh=400" />

        <div class="text-container">
            <div class="container">
                <div class="row">
                    <div class="col col-24">
                        <div class="text-wrap rs_read_this">
                            <h1>We are so sorry!</h1>
                            <h2>The page you wanted can’t be found.</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <!-- END PARTIAL: about/about-hero-image -->
</div>
<!-- .container -->

<div class="container l-page-not-found-search">
    <div class="row">
        <div class="col col-16 centered rs_read_this">
            <!-- BEGIN PARTIAL: about/page-not-found-search -->
            <div class="page-not-found-search skiplink-content" aria-role="main">
                <h2>Looking for something specific?</h2>
                <fieldset>
                    <div class="search-input-wrap">
                        <label for="search-term" class="visuallyhidden"></label>
                        <input type="text" name="search-term" id="search-term">
                    </div>
                    <div class="search-button-wrap">
                        <input id="search-term-button" class="button search-button" type="submit" value="Search">
                    </div>
                </fieldset>
            </div>
            <!-- END PARTIAL: about/page-not-found-search -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container l-page-not-found-promos">
    <div class="row">
        <div class="col col-24 skiplink-feature rs_read_this">
            <!-- BEGIN PARTIAL: about/page-not-found-promos -->
            <h2>We hope you’ll find what you’re looking for on one of these pages.
            </h2>

            <div class="container flush page-not-found-promos">
                <div class="row">
                    <div class="col col-6 offset-1">
                        <!-- BEGIN PARTIAL: about/page-not-found-promo1 -->
                        <div class="promo-single">
                            <a href="REPLACE">Labore Doloribus Sed Fugiat Eveniet Est Nobis</a>
                            <img alt="292x164 Placeholder" src="http://placehold.it/292x164" />
                        </div>
                        <!-- END PARTIAL: about/page-not-found-promo1 -->
                    </div>
                    <div class="col col-6 offset-2">
                        <!-- BEGIN PARTIAL: about/page-not-found-promo2 -->
                        <div class="promo-single">
                            <a href="REPLACE">Voluptatibus Enim Eos Debitis Qui</a>
                            <img alt="292x164 Placeholder" src="http://placehold.it/292x164" />
                        </div>
                        <!-- END PARTIAL: about/page-not-found-promo2 -->
                    </div>
                    <div class="col col-7 offset-2">
                        <!-- BEGIN PARTIAL: about/page-not-found-promo-list -->
                        <div class="promo-list">
                            <a href="REPLACE">At Aut</a>
                            <p>Molestiae Quia Sed Autem Inventore Distinctio Optio</p>

                            <a href="REPLACE">In Perferendis</a>
                            <p>Sunt Consectetur Quo At Ut Eveniet Accusantium</p>

                            <a href="REPLACE">Temporibus Iste</a>
                            <p>Sunt Nisi Eveniet Cum Debitis Itaque Ipsam</p>
                        </div>
                        <!-- END PARTIAL: about/page-not-found-promo-list -->
                    </div>
                </div>
                <!-- .row -->
            </div>
            <!-- .container -->
            <!-- END PARTIAL: about/page-not-found-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
