<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsLandingPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsLandingPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<!-- Hero Carousel Module -->
<div class="container hero-container flush at-hero-container-wrap">
    <!-- BEGIN PARTIAL: at-hero-image -->
    <section class="hero-image-container">
        <%= Model.Hero.Rendered %>
        <div class="text-container">
            <div class="row">
                <div class="col col-24">
                    <div class="hero-content rs_read_this">
                        <h1><%= Model.AssistiveToolsBasePage.ContentPage.PageTitle %></h1>
                        <%= Model.AssistiveToolsBasePage.ContentPage.BodyContent %>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <style>
        .hero-image-container img {
            height: auto;
        }
    </style>
    <!-- END PARTIAL: at-hero-image -->
</div>

<!-- Get Expert Advice -->
<div class="container flush assistive-tech">
    <div class="row">
        <div class="col col-20 centered at-search-tool-wrapper at-search-tool-wrapper-pull skiplink-content" aria-role="main">
            <sc:Placeholder ID="Placeholder2" Key="Assistive Tool Search" runat="server" />
        </div>
    </div>
</div>
<!-- end What Parents are Saying -->


<!-- What Parents are Saying -->
<!-- BEGIN PARTIAL: parents-are-saying -->
<div class="container parents-are-saying">
    <div class="row">
        <div class="col col-24 header-container rs_read_this parents-are-saying-heading-rs-wrapper">
            <h2>
                <asp:Label runat="server" Text="" ID="lblWhatParentsAreSaying" /></h2>
        </div>
    </div>
    <div class="row ie-padding">
        <div class="col slider-col col-18 offset-4">
            <div class="parents-are-saying-container">
                <asp:Repeater ID="rptrWhatParentsAreSaying" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="rs_read_this parents-are-saying-rs-wrapper">
                                <h3><%# Eval("Title") %></h3>
                                <%# Eval("ReviewText") %>
                                <!-- BEGIN PARTIAL: results-slider -->
                                <%# Eval("RatingHtml") %>
                                <!-- END PARTIAL: results-slider -->
                                <h4>Parent</h4>
                                <a href="<%# Eval("Url") %>"><%# Eval("LinkText") %></a>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>
<!-- END PARTIAL: parents-are-saying -->
<!-- end What Parents are Saying -->

<!-- What Parents are Saying -->
<div class="container more-carousel">
    <div class="row">
        <div class="col col-24">
            <h2>
                <asp:Label ID="lblRelatedArticles" runat="server" Text="" /></h2>
            <!-- BEGIN PARTIAL: more-carousel -->
            <div id="featured-slides-container" class="arrows-gray">
                <ul>
                    <asp:Repeater ID="rptrFeaturedArticles" runat="server" 
                        ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems.DefaultArticlePageItem">
                        <ItemTemplate>
                            <li>
                                <div class="rs_read_this">
                                    <a href="<%# Item.GetUrl() %>">
                                        <p><%# Item.ContentPage.BasePageNEW.NavigationTitle.Rendered %></p>
                                        <sc:FieldRenderer ID="frArticleImage" runat="server" Parameters="W=230&H=129" />
                                        <%--<%# Item.ContentThumbnail.MediaItem != null ? Item.ContentThumbnail.Rendered : Item.FeaturedImage.Rendered %>--%>
                                    </a>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <!-- #more-carousel-slides-container-->

            <!-- END PARTIAL: more-carousel -->
        </div>
    </div>
</div>
<!-- end What Parents are Saying -->
