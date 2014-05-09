<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="404Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About._404Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<div id="wrapper">
    <!-- END PARTIAL: header -->

    <div class="container flush l-about-hero-intro">
        <!-- This is a shared module -->
        <!-- BEGIN PARTIAL: about/about-hero-image -->
        <!-- This is a shared module -->
        <section class="about-hero-container">
            <%--<img alt="1200x400 Placeholder" src="http://placehold.it/1200x400" />--%>
            <sc:FieldRenderer ID="frImage" runat="server" FieldName="Image" />
            <div class="text-container">
                <div class="container">
                    <div class="row">
                        <div class="col col-24">
                            <div class="text-wrap rs_read_this">
                                <h1><%--We are so sorry!--%>
                                    <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                                </h1>
                                <h2><%--The page you wanted can’t be found.--%>
                                    <sc:FieldRenderer ID="frPageSummary" runat="server" FieldName="Page Summary" />
                                </h2>
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
                            <input type="text" name="search-term" id="Text1">
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
                <h2><%--We hope you’ll find what you’re looking for on one of these pages.--%>
                    <sc:FieldRenderer ID="frPromoHeader" runat="server" FieldName="Promo Header" />
</h2>

                <div class="container flush page-not-found-promos">
                    <div class="row">
                        <div class="col col-6 offset-1">
                            <!-- BEGIN PARTIAL: about/page-not-found-promo1 -->
                            <div class="promo-single">

                                <asp:HyperLink ID="hlPromo1" runat="server">
                                    <sc:FieldRenderer ID="frPromo1Title" runat="server" FieldName="Page Title" />
                                    <sc:FieldRenderer ID="frPromo1Image" runat="server" FieldName="Image" />
                                </asp:HyperLink>
                                <%--<a href="REPLACE">Et Eos Sunt Tempora Qui Voluptatem Quia</a>
                                <img alt="292x164 Placeholder" src="http://placehold.it/292x164" />--%>
                            </div>
                            <!-- END PARTIAL: about/page-not-found-promo1 -->
                        </div>
                        <div class="col col-6 offset-2">
                            <!-- BEGIN PARTIAL: about/page-not-found-promo2 -->
                            <div class="promo-single">
                                 <asp:HyperLink ID="hlPromo2" runat="server">
                                      <sc:FieldRenderer ID="frPromo2Title" runat="server" FieldName="Page Title" />
                                    <sc:FieldRenderer ID="frPromo2Image" runat="server" FieldName="Promo Image" />
                                </asp:HyperLink>
                                <%--<a href="REPLACE">Maiores Voluptatem Laborum Nulla Quod</a>
                                <img alt="292x164 Placeholder" src="http://placehold.it/292x164" />--%>
                            </div>
                            <!-- END PARTIAL: about/page-not-found-promo2 -->
                        </div>
                        <div class="col col-7 offset-2">
                            <!-- BEGIN PARTIAL: about/page-not-found-promo-list -->
                            <div class="promo-list">
                                <asp:Repeater ID="rptMorePromo" runat="server" OnItemDataBound="rptMorePromo_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlPromoTitle" runat="server">
                                            <sc:FieldRenderer ID="frPromoTitle" runat="server" FieldName="Page Title" />
                                        </asp:HyperLink>
                                        <p>
                                            <sc:FieldRenderer ID="frpromoDesc" runat="server" FieldName="Page Summary" />
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--    <a href="REPLACE">Voluptas Eligendi</a>
                                <p>Nam Qui Sed Doloremque Laboriosam Nam Est</p>

                                <a href="REPLACE">Magni Porro</a>
                                <p>Voluptatem Qui Ut Quam Et Architecto Error</p>

                                <a href="REPLACE">Praesentium Voluptatem</a>
                                <p>Deleniti Assumenda Reprehenderit Dolorem Itaque Sit Animi</p>--%>
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

    <!-- BEGIN PARTIAL: footer -->

</div>
<!-- #wrapper -->

