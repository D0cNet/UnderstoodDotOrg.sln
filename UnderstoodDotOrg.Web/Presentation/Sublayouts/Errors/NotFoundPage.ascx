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
                            <h1><sc:FieldRenderer ID="frHeroTitle" runat="server" FieldName="Hero Title" /></h1>
                            <h2><sc:FieldRenderer ID="frHeroSubtitle" runat="server" FieldName="Hero Subtitle" /></h2>
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
            <asp:Panel runat="server" DefaultButton="btnSubmit" CssClass="page-not-found-search skiplink-content" aria-role="main">
                <h2><sc:FieldRenderer ID="frSearchBoxTitle" runat="server" FieldName="Search Box Title" /></h2>
                <fieldset>
                    <div class="search-input-wrap">
                        <asp:Label AssociatedControlID="txtSearch" runat="server" CssClass="visuallyhidden" />
                        <asp:TextBox ID="txtSearch" runat="server" />
                    </div>
                    <div class="search-button-wrap">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="button search-button" />
                    </div>
                </fieldset>
            </asp:Panel>
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
            <h2><sc:FieldRenderer ID="frPromoAreaHeading" runat="server" FieldName="Promo Area Heading" /></h2>

            <div class="container flush page-not-found-promos">
                <div class="row">
                    <div class="col col-6 offset-1">
                        <!-- BEGIN PARTIAL: about/page-not-found-promo1 -->
                        <div class="promo-single">
                            <sc:Link ID="scPromo1Link" runat="server" Field="Promo 1 Link"><sc:FieldRenderer ID="frPromo1Title" runat="server" FieldName="Promo 1 Title" /></sc:Link>
                            <sc:FieldRenderer ID="frPromo1Image" runat="server" FieldName="Promo 1 Image" Parameters="mw=292&mh=164" />
                        </div>
                        <!-- END PARTIAL: about/page-not-found-promo1 -->
                    </div>
                    <div class="col col-6 offset-2">
                        <!-- BEGIN PARTIAL: about/page-not-found-promo2 -->
                        <div class="promo-single">
                            <sc:Link ID="scPromo2Link" runat="server" Field="Promo 2 Link"><sc:FieldRenderer ID="frPromo2Title" runat="server" FieldName="Promo 2 Title" /></sc:Link>
                            <sc:FieldRenderer ID="frPromo2Image" runat="server" FieldName="Promo 2 Image" Parameters="mw=292&mh=164" />
                        </div>
                        <!-- END PARTIAL: about/page-not-found-promo2 -->
                    </div>
                    <div class="col col-7 offset-2">
                        <!-- BEGIN PARTIAL: about/page-not-found-promo-list -->
                        <div class="promo-list">
                            <sc:FieldRenderer ID="frPromo3Content" runat="server" FieldName="Promo 3 Content" />
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
