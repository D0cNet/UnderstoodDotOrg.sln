<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsLandingPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsLandingPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
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


<!-- end What Parents are Saying -->
