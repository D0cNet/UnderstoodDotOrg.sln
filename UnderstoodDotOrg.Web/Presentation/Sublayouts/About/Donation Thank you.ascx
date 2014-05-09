<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Donation Thank you.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Donation_Thank_you" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>



<!-- END PARTIAL: header -->

<div class="container flush l-about-hero-intro l-thank-you-intro skiplink-content" aria-role="main">
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
                            <h1><%--Thank you for being so generous!--%>
                                <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                            </h1>
                            <h2><%--Each donation makes a difference.--%>
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

<div class="container l-thank-you-social">
    <div class="row">
        <div class="col col-22 centered rs_read_this skiplink-toolbar rs_read_this">
            <!-- BEGIN PARTIAL: about/about-thank-you-social -->
            <!-- Adding spaces or line breaks here will cause unwanted space between elements -->
            <div class="thank-you-social">
                <a href="REPLACE" class="email-link">
                    <span class="circle">
                        <span class="icon icon-envelope rs_skip" alt="envelope icon"></span>
                    </span><span class="text-link">Tell a Friend</span>
                </a>
                <a href="REPLACE" class="twitter-link">
                    <span class="circle"><span class="icon icon-twitter rs_skip" alt="twitter icon"></span></span><span class="text-link">Follow us on Twitter</span>
                </a>
                <a href="REPLACE" class="facebook-link">
                    <span class="circle"><span class="icon icon-facebook rs_skip" alt="facebook icon"></span></span><span class="text-link">Friend us on Facebook</span>
                </a>
            </div>
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
                        <h2 class="skiplink-feature rs_read_this"><%--Recommended--%>
                            <sc:FieldRenderer ID="frRecommendationHeader" runat="server" FieldName="Recommendation Header" />
                        </h2>
                    </div>
                </div>
            </div>

            <div class="container recommended-grid">

                <asp:Repeater ID="rptRecommendation" runat="server" OnItemDataBound="rptRecommendation_ItemDataBound">
                    <ItemTemplate>
                        <div class="row">
                            <asp:Repeater ID="rptTwoArticle" runat="server" OnItemDataBound="rptTwoArticle_ItemDataBound">
                                <ItemTemplate>
                                    <div class="col col-11 offset-1">
                                        <div class="recommended-item rs_read_this about-thank-you-rs-wrapper clearfix">
                                            <div class="recommended-image">
                                                <asp:HyperLink ID="hlRecommendImage" runat="server">
                                                    <sc:FieldRenderer ID="frRecommendImage" runat="server" FieldName="Thumbnail Image" />
                                                </asp:HyperLink>
                                                <%--<a href="REPLACE">
                                            <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>--%>
                                            </div>
                                            <div class="recommended-title">
                                                <h3><%--<a href="REPLACE">Voluptatum Nobis Dolorum Tempora Laudantium</a>--%>
                                                    <asp:HyperLink ID="hlRecommendTitle" runat="server">
                                                        <sc:FieldRenderer ID="frRecommendTitle" runat="server" FieldName="Page Title" />
                                                    </asp:HyperLink>

                                                </h3>
                                                <div class="children">
                                                    <i class="child-a" title="CHILD NAME HERE"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                            <%--<div class="col col-11 offset-1">
                                <div class="recommended-item rs_read_this about-thank-you-rs-wrapper clearfix">
                                    <div class="recommended-image">
                                        <a href="REPLACE">
                                            <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                                    </div>
                                    <div class="recommended-title">
                                        <h3><a href="REPLACE">Qui Nisi Ab Cumque Deleniti</a></h3>
                                        <div class="children">
                                            <!-- No Children -->
                                        </div>
                                    </div>
                                </div>
                            </div> --%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <%--<div class="row">
    <div class="col col-11 offset-1">
      <div class="recommended-item rs_read_this about-thank-you-rs-wrapper clearfix">
        <div class="recommended-image">
          <a href="REPLACE"><img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
        </div>
        <div class="recommended-title">
          <h3><a href="REPLACE">Placeat Aut Aut Fugiat Quis</a></h3>
          <div class="children">
            <i class="child-a" title="CHILD NAME HERE"></i><i class="child-b" title="CHILD NAME HERE"></i>
          </div>
        </div>
      </div>
    </div>
    <div class="col col-11 offset-1">
      <div class="recommended-item rs_read_this about-thank-you-rs-wrapper clearfix">
        <div class="recommended-image">
          <a href="REPLACE"><img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
        </div>
        <div class="recommended-title">
          <h3><a href="REPLACE">Voluptas Qui Dolorem Officia Voluptas</a></h3>
          <div class="children">
            <i class="child-a" title="CHILD NAME HERE"></i>
          </div>
        </div>
      </div>
    </div>
  </div>--%>


            <!-- BEGIN PARTIAL: children-key -->
            <div class="container child-content-indicator first">
                <!-- Key -->
                <div class="row">
                    <div class="col col-23 offset-1">
                        <div class="children-key" aria-hidden="true">
                            <ul>
                                <li><i class="child-a"></i>for Michael</li>
                                <li><i class="child-b"></i>for Elizabeth</li>
                                <li><i class="child-c"></i>for Ethan</li>
                                <li><i class="child-d"></i>for Jeremy</li>
                                <li><i class="child-e"></i>for Franklin</li>
                            </ul>
                        </div>
                        <!-- .children-key -->
                    </div>
                    <!-- .col -->
                </div>
                <!-- .row -->
            </div>
            <!-- .child-content-indicator -->
            <!-- END PARTIAL: children-key -->
            <!-- END PARTIAL: about/thank-you-recommended -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<!-- BEGIN PARTIAL: footer -->

