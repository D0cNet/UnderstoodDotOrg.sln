<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutPartner_Details.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.AboutPartner_Details" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- END PARTIAL: pagetopic -->
<!-- styling for .about-pagetopic can be found in about-partners -->

<div class="container l-partners-detail">
    <div class="row">
        <div class="col col-24 lower-border">
            <!-- added lower-border in partner-detail-header.scss to create hr -->
            <div class="col col-23 offset-1 skiplink-content" aria-role="main">
                <!-- BEGIN PARTIAL: about/partners-detail-header -->
                <div class="partner-heading">
                    <span class="return-all-partners"><a href="REPLACE">Our Partners</a></span>
                    <h1 class="partner-name"><%--Common Sense Media--%>
                        <sc:FieldRenderer ID="frpartnerName" runat="server" FieldName="Partner Name" />
                    </h1>
                   <h2 class="partner-tagline"><%--Providing technology and application recomendations to Understood.--%>
                        <sc:FieldRenderer ID="frSubHeadline" runat="server" FieldName="Sub Headline" />
                    </h2>
                    <span class="partner-link"><%--<a href="REPLACE">http://www.commonsensemedia.org</a>--%>
                        <asp:HyperLink ID="hlPartnerSiteLink" runat="server">
                            
                        </asp:HyperLink>
                    </span>
                </div>
                <!-- end .partner-heading -->
                <!-- END PARTIAL: about/partners-detail-header -->
                <!-- BEGIN PARTIAL: about/partners-detail-logo -->
                 <div class="partner-logo">
                    <%--<sc:Image ID="ImgLogo" runat="server" Field="Thumbnail Image" />--%>
                    <sc:FieldRenderer ID="frPartnerLogo" runat="server" FieldName="Thumbnail Image" />
                    <%--<img alt="270x130 Placeholder" src="http://placehold.it/270x130" />--%>
                </div>
                <!-- END PARTIAL: about/partners-detail-logo -->
                <!-- BEGIN PARTIAL: about/partners-detail-copy -->
                <div class="partner-copy">

                    <p>
                        <%--Common Sense media is Sint et esse natus. qui aspernatur tempora labore. consectetur inventore doloremque non deserunt dolor repellendus unde reiciendis et deserunt ut. nihil alias quae aut numquam earum ut dolorem ut molestias et. consequatur nesciunt quod atque voluptate illo voluptates natus error et consectetur aperiam aperiam. aut voluptatum explicabo soluta ea quod. consequatur in soluta repellat at</p>
                    <p>Voluptas aliquid voluptas quae non. iste facilis in ex. magnam cumque sint blanditiis repellat illo enim tempore esse qui</p>
                    <p>Maiores voluptatum repellat reiciendis quo delectus ut suscipit eum ut corporis. minus delectus et ea optio quia veritatis. impedit qui sit quia et qui vitae at illum iusto deleniti dolor deserunt voluptate. ut sunt quia necessitatibus sunt sapiente eum qui dicta aliquam cupiditate eum mollitia incidunt. aut molestiae nesciunt aut possimus odio ea reprehenderit reiciendis placeat--%>
                        <sc:FieldRenderer ID="frPartnerDescription" runat="server" FieldName="Short Description" />
                    </p>
                </div>
                <!-- end .partner-copy -->
                <!-- END PARTIAL: about/partners-detail-copy -->
                <!-- BEGIN PARTIAL: about/partners-newsletter-signup -->
                <div class="partner-newsletter skiplink-sidebar">
                    <h2>Sign up for Common Sense Media Newsletter</h2>
                    <a href="REPLACE" class="button">Sign Up</a>
                </div>
                <!-- END PARTIAL: about/partners-newsletter-signup -->
                <!-- BEGIN PARTIAL: about/partners-donate -->
                <div class="partner-donate">
                    <h2>Donate to Common Sense Media</h2>
                    <a href="REPLACE" class="button">Donate</a>
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
        <div class="col col-7 skiplink-feature">
            <!-- BEGIN PARTIAL: about/partners-featured-content -->
            <div class="featured-content-block">
                <h2>Featured</h2>
                <div class="featured-title">
                    <span class="title-link"><a href="REPLACE">Find Technology that Can Help</a></span>
                </div>
                <div class="featured-title">
                    <span class="title-link"><a href="REPLACE">What is Assistive Technology?</a></span>
                </div>
            </div>
            <!-- end .featured-content-block -->

            <!-- END PARTIAL: about/partners-featured-content -->
        </div>
        <div class="col col-7 offset-1">
            <!-- BEGIN PARTIAL: about/partners-twitter -->
            <div class="partner-twitter-container">
                <h2>Common Sense Media on Twitter</h2>

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
                    <a href="REPLACE"><i class="twitter-follow"></i>Follow Common Sense Media on Twitter</a>
                </div>
                <!-- end .twitter-follow-block -->
            </div>
            <!-- end .partner-twitter-container -->

            <!-- END PARTIAL: about/partners-twitter -->
        </div>
        <div class="col col-7 offset-2">
            <!-- BEGIN PARTIAL: about/partners-facebook -->
            <div class="partner-facebook-container">
                <h2>Common Sense Media on Facebook</h2>

                <div class="partner-feed-single">
                    <div class="avatar">
                        <img alt="50x50 Placeholder" src="http://placehold.it/50x50" />
                    </div>
                    <div class="like-block">
                        <div class="message-head">
                            <span class="username">Rian Lee</span>
                        </div>
                        <!-- end div.message-head -->
                        <div class="message-body">
                            Amazing! Cool!
     
                        </div>
                        <!-- end div.message-body -->
                        <div class="link-bar">
                            <ul>
                                <li><a href="REPLACE">Reply</a></li>
                                <li><a href="REPLACE">Like</a></li>
                                <li><a href="REPLACE">Follow Post</a></li>
                            </ul>
                        </div>
                        <div class="datestamp">
                            24 December 2013 at 19:00
     
                        </div>
                    </div>
                    <!-- end div.like-block -->
                </div>
                <!-- end .partner-feed-single -->

                <div class="partner-feed-single">
                    <div class="avatar">
                        <img alt="50x50 Placeholder" src="http://placehold.it/50x50" />
                    </div>
                    <div class="like-block">
                        <div class="message-head">
                            <span class="username">Rian Lee</span>
                        </div>
                        <!-- end div.message-head -->
                        <div class="message-body">
                            Amazing! carnivorous dinosaur tooth -- 76 vs 60 mil -- via 1200 shared data points lorem ipsum dolor.
     
                        </div>
                        <!-- end div.message-body -->
                        <div class="link-bar">
                            <ul>
                                <li><a href="REPLACE">Reply</a></li>
                                <li><a href="REPLACE">Like</a></li>
                                <li><a href="REPLACE">Follow Post</a></li>
                            </ul>
                        </div>
                        <div class="datestamp">
                            24 December 2013 at 19:00
     
                        </div>
                    </div>
                    <!-- end div.like-block -->
                </div>
                <!-- end .partner-feed-single -->

                <div class="facebook-follow-block">
                    <a href="REPLACE"><i class="facebook-follow"></i>Follow Common Sense Media on Facebook</a>
                </div>
                <!-- end .facebook-follow-block -->
            </div>
            <!-- end .partner-facebook-container -->

            <!-- END PARTIAL: about/partners-facebook -->
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container l-partners-social-columns -->

<!-- BEGIN PARTIAL: footer -->


