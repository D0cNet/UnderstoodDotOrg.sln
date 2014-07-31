<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DonationConfirmationPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.DonationConfirmationPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register Src="~/Presentation/Sublayouts/Recommendation/ArticleRecommendationIcons.ascx" TagPrefix="udo" TagName="ArticleRecommendationIcons" %>

<div class="container flush l-about-hero-intro l-thank-you-intro skiplink-content" aria-role="main">
    <!-- This is a shared module -->
    <!-- BEGIN PARTIAL: about/about-hero-image -->
    <!-- This is a shared module -->
    <section class="about-hero-container">
        <%--<img alt="1200x400 Placeholder" src="http://placehold.it/1200x400" />--%>
        <asp:Image ID="imgBanner" runat="server" />
        <div class="text-container">
            <div class="container">
                <div class="row">
                    <div class="col col-24">
                        <div class="text-wrap rs_read_this">
                            <h1><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></h1>
                            <h2><sc:FieldRenderer ID="frPageSummary" runat="server" FieldName="Body Content" /></h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <!-- END PARTIAL: about/about-hero-image -->
</div>
<!-- .container -->

<div class="container l-thank-you-social">
    <div class="row">
        <div class="col col-22 centered rs_read_this skiplink-toolbar rs_read_this">
            <!-- BEGIN PARTIAL: about/about-thank-you-social -->
            <!-- Adding spaces or line breaks here will cause unwanted space between elements -->
            <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/About/Widgets/ThankYouSocial.ascx" />
            <!-- END PARTIAL: about/about-thank-you-social -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container l-thank-you-recommended">
    <div class="row">
        <div class="col col-24">
            <!-- BEGIN PARTIAL: about/thank-you-recommended -->
            <div class="container recommended-grid">
                <div class="row">
                    <div class="col col-11 offset-1">
                        <h2 class="skiplink-feature rs_read_this"><%= UnderstoodDotOrg.Common.DictionaryConstants.RecommendedLabel %></h2>
                    </div>
                </div>
            </div>

            <asp:Repeater ID="rptFeaturedArticles" runat="server" OnItemDataBound="rptFeaturedArticles_ItemDataBound">
                <HeaderTemplate>
                    <div class="container recommended-grid">
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Repeater ID="rptRow" runat="server" OnItemDataBound="rptRow_ItemDataBound">
                        <HeaderTemplate>
                            <div class="row">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col col-11 offset-1">
                                <div class="recommended-item rs_read_this about-thank-you-rs-wrapper clearfix">
                                    <div class="recommended-image">
                                        <asp:HyperLink ID="hypThumbnail" runat="server">
                                            <asp:Image ID="imgThumbnail" runat="server" />
                                        </asp:HyperLink>
                                    </div>
                                    <div class="recommended-title">
                                        <h3><asp:HyperLink ID="hypArticleLink" runat="server"></asp:HyperLink></h3>
                                        <udo:ArticleRecommendationIcons ID="articleRecommendationIcons" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>

            <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
            <!-- END PARTIAL: about/thank-you-recommended -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
