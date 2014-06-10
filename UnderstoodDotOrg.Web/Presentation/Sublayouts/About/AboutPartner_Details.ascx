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
            <div class="col col-23 offset-1 skiplink-content" aria-role="main">
                <!-- BEGIN PARTIAL: about/partners-detail-header -->
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

                 <div class="partner-logo rs_read_this">
                    <sc:FieldRenderer ID="frPartnerLogo" runat="server" FieldName="Partner Logo" Parameters="mw=270&mh=130" />
                </div>

                <div class="partner-copy rs_read_this">
                    <sc:FieldRenderer ID="frPartnerBio" runat="server" FieldName="Partner Bio" />
                </div>

                <div class="partner-newsletter">
                    <h2><sc:FieldRenderer ID="frNewsletterHeading" FieldName="Partner Newsletter Heading" runat="server" /></h2>
                    <sc:FieldRenderer ID="frNewsletterLink" FieldName="Partner Newsletter Link" Parameters="class=button" runat="server" />
                </div>

                <div class="partner-donate">
                    <h2><sc:FieldRenderer ID="frDonationHeading" FieldName="Partner Donation Heading" runat="server" /></h2>
                    <sc:FieldRenderer ID="frDonationLink" FieldName="Partner Donation Link" Parameters="class=button" runat="server" />
                </div>

                <!-- END PARTIAL: about/partners-donate -->
            </div>
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container l-partners-detail -->
<div class="container l-partners-social-columns">
    <div class="row">
        <div class="col col-7 skiplink-feature rs_read_this partners-detail-rs-featured-wrapper">
            <!-- BEGIN PARTIAL: about/partners-featured-content -->
            <div class="featured-content-block">
                <h2>Featured</h2>
                <div class="featured-title">
                    <span class="title-link"><asp:HyperLink ID="hlFeaturedFirst" runat="server" /></span>
                </div>
                <div class="featured-title">
                    <span class="title-link"><asp:HyperLink ID="hlFeaturedSecond" runat="server" /></span>
                </div>
            </div>
            <!-- end .featured-content-block -->

            <!-- END PARTIAL: about/partners-featured-content -->
        </div>
        <div class="col col-7 offset-1 rs_read_this partners-detail-rs-twitter-wrapper">
            <asp:PlaceHolder ID="phTwitter" runat="server" Visible="false">
            <!-- BEGIN PARTIAL: about/partners-twitter -->
            <div class="partner-twitter-container">
                <h2><sc:FieldRenderer ID="frTwitterHeading" runat="server" FieldName="Twitter Heading" /></h2>

                <div class="partner-feed-single">
                    <div class="avatar">
                        <img alt="50x50 Placeholder" src="http://placehold.it/50x50" />
                    </div>
                    <div class="tweet-block">
                        <div class="message-head">
                            <span class="username">PLOS</span><span class="handle">@PLOS</span><span class="timestamp">3h</span>
                        </div>
                        <!-- end div.message-head -->
                        <div class="message-body">
                            <a href="REPLACE">@PLOSONE</a> Discovering age of indiv carnivorous dinosaue tooth 76 vs 60 mil -- via 1200 shared data points <a href="REPLACE">@AndyFarke</a> <a href="REPLACE">http://bit.ly/WSICLn</a>
                        </div>
                        <!-- end div.message-body -->
                    </div>
                    <!-- end div.tweet-block -->
                </div>
                <!-- end .partner-feed-single -->

                <div class="partner-feed-single">
                    <div class="avatar">
                        <img alt="50x50 Placeholder" src="http://placehold.it/50x50" />
                    </div>
                    <div class="tweet-block">
                        <div class="message-head">
                            <span class="username">James McInerney</span><span class="handle">@jomcinemey</span><span class="timestamp">3h</span>
                        </div>
                        <!-- end div.message-head -->
                        <div class="message-body">
                            Paper uses TIGER <a href="REPLACE">http://bioinf.nuim.ie/tiger</a> : Reconstruction of Family-Level Phylogenetic Relationships within
     
                        </div>
                        <!-- end div.message-body -->
                    </div>
                    <!-- end div.tweet-block -->
                </div>
                <!-- end .partner-feed-single -->

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

                <div class="fb-like-box" data-href="<%= FacebookUrl %>" data-colorscheme="light" data-show-faces="false" data-header="false" data-stream="true" data-show-border="false" data-width="292"></div>

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

<!-- BEGIN PARTIAL: footer -->


