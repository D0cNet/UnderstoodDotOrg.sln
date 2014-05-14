<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsHeroContainer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsHeroContainer" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container flush hero-container-wrap">
  <!-- BEGIN PARTIAL: hero-image -->
<section class="hero-image-container">
  <sc:FieldRenderer ID="frImage" runat="server" FieldName="Hero Image" Parameters="mw=1220&mh=475&class=hero-image" />
  <div class="hero-text-container">
    <div class="row">
      <div class="col col-24">
        <div class="hero-text">
          <header>
            <h1><sc:FieldRenderer ID="frHeading" runat="server" FieldName="Hero Heading" /></h1>
          </header>
          <p><sc:FieldRenderer ID="frSubheading" runat="server" FieldName="Hero Subheading" /></p>
          <sc:FieldRenderer ID="frCta" runat="server" FieldName="Hero Call To Action" />
        </div>
      </div>
    </div>
  </div>
</section>
<!-- END PARTIAL: hero-image -->
</div>