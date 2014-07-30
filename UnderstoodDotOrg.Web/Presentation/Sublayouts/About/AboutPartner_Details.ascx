<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutPartner_Details.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.AboutPartner_Details" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div id="fb-root"></div>
<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&appId=<%= FacebookAppId %>&version=v2.0";
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

<div class="container l-partners-detail">
    <div class="row">
        <div class="col col-24 lower-border">
            <!-- added lower-border in partner-detail-header.scss to create hr -->
            <div class="col col-23 offset-1 skiplink-content partner-detail-container" aria-role="main">
                <div class="partner-detail-body">
                    <div class="partner-heading rs_read_this">
                        <span class="return-all-partners"><asp:HyperLink ID="hlPartnersLanding" runat="server" /></span>
                        <h1 class="partner-name">
                            <sc:FieldRenderer ID="frPartnerName" runat="server" FieldName="Partner Name" />
                        </h1>
                       <h2 class="partner-tagline">
                            <sc:FieldRenderer ID="frSubHeadline" runat="server" FieldName="Partner Tagline" />
                        </h2>
                        <span class="partner-link">
                            <sc:Link ID="lnkPartner" runat="server" Field="Partner Link" />
                        </span>
                    </div>
                    <div class="partner-copy rs_read_this">
                        <sc:FieldRenderer ID="frPartnerBio" runat="server" FieldName="Body Content" />
                    </div>
                </div><!-- end body -->

                <div class="partner-detail-sidebar">
                    <div class="partner-logo rs_read_this">
                        <sc:FieldRenderer ID="frPartnerLogo" runat="server" FieldName="Partner Logo" Parameters="mw=270&mh=130" />
                    </div>

                    <asp:Panel ID="pnlNewsletter" runat="server" Visible="false" CssClass="partner-newsletter">
                        <h2><sc:FieldRenderer ID="frNewsletterHeading" FieldName="Partner Newsletter Heading" runat="server" /></h2>
                        <sc:FieldRenderer ID="frNewsletterLink" FieldName="Partner Newsletter Link" Parameters="class=button" runat="server" />
                    </asp:Panel>

                    <asp:Panel ID="pnlDonate" runat="server" Visible="false" CssClass="partner-donate">
                        <h2><sc:FieldRenderer ID="frDonationHeading" FieldName="Partner Donation Heading" runat="server" /></h2>
                        <sc:FieldRenderer ID="frDonationLink" FieldName="Partner Donation Link" Parameters="class=button" runat="server" />
                    </asp:Panel>
                </div><!-- end sidebar -->
            </div><!-- end main -->
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container l-partners-detail -->
<div class="container l-partners-social-columns">
    <div class="row">
        <asp:Repeater ID="rptFeatured" runat="server">
            <HeaderTemplate>
                <div class="col col-7 skiplink-feature rs_read_this partners-detail-rs-featured-wrapper">
                    <!-- BEGIN PARTIAL: about/partners-featured-content -->
                    <div class="featured-content-block">
                        <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.Featured %></h2>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="featured-title">
                    <span class="title-link"><a href="<%# Eval("Url") %>"><%# Eval("Title") %></a></span>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                    </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>

        <div class="col col-7 offset-1 rs_read_this partners-detail-rs-twitter-wrapper">
            <asp:PlaceHolder ID="phTwitter" runat="server" Visible="false">
            <!-- BEGIN PARTIAL: about/partners-twitter -->
            <div class="partner-twitter-container">
                <h2><sc:FieldRenderer ID="frTwitterHeading" runat="server" FieldName="Twitter Heading" /></h2>

                <sc:FieldRenderer ID="frTwitterWidget" runat="server" FieldName="Twitter Widget" />
                <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>

                <div class="twitter-follow-block">
                    <asp:HyperLink ID="hlTwitter" runat="server"><i class="twitter-follow"></i><%= TwitterLinkText %></asp:HyperLink>
                </div>
                <!-- end .twitter-follow-block -->
            </div>
            <!-- end .partner-twitter-container -->

            </asp:PlaceHolder>
        </div>
        <div class="col col-7 offset-2 rs_read_this partners-detail-rs-facebook-wrapper">
            <asp:PlaceHolder ID="phFacebook" runat="server" Visible="false">
            <div class="partner-facebook-container">
                <h2><sc:FieldRenderer ID="frFacebookHeading" runat="server" FieldName="Facebook Heading" /></h2>

                <sc:FieldRenderer ID="frFacebookWidget" runat="server" FieldName="Facebook Widget" />

                <div class="facebook-follow-block">
                    <asp:HyperLink ID="hlFacebook" runat="server"><i class="facebook-follow"></i><%= FacebookLinkText %></asp:HyperLink>
                </div>
                <!-- end .facebook-follow-block -->
            </div>
           </asp:PlaceHolder>

            <!-- END PARTIAL: about/partners-facebook -->
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container l-partners-social-columns -->


