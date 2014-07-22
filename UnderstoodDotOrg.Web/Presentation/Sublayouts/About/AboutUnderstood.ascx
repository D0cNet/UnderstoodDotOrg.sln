<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutUnderstood.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.AboutUnderstood" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container l-about-understood">
    <div class="row">
        <div class="col col-15 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: about-understood-video -->
            <div class="about-video-container rs_read_this about-understood-video-rs-wrapper">
                <p>
                    <%--Et fugit consequatur explicabo quasi autem corrupti consequatur ab deserunt minima ea quas eum. et saepe omnis et dolorem distinctio tempore excepturi numquam et ut consequatur aut. qui aut facere nisi ut voluptas eveniet voluptates ea omnis. eligendi itaque architecto eum ut qui culpa fuga ratione ut nihil quia et aut quae. debitis minus commodi sapiente sit blanditiis--%>
                    <sc:FieldRenderer ID="frSummary" runat="server" FieldName="Body Content" />
                </p>
                <div class="about-video-frame">
                    <sc:FieldRenderer ID="frVideoEmbed" runat="server" FieldName="Video Embed" />
                </div>
                <!-- end about-video-frame -->
            </div>
            <!-- end about-video-container -->
            <!-- END PARTIAL: about-understood-video -->
            <!-- BEGIN PARTIAL: transcript-control -->
            <asp:Panel ID="pnlTranscript" runat="server" Visible="false" CssClass="transcript-container Video">
                <%--<div class="read-more mobile-close">
                    <a href="REMOVE">Close Transcript<i class="icon-arrow-up-blue"></i></a>
                </div> --%>
                <div class="transcript-wrap">
                    <div>

                        <sc:FieldRenderer ID="FrVideoTranscript" runat="server" FieldName="Video Transcript" />
                    </div>
                </div>
                <div class="read-more read-more-bottom"></div>
            </asp:Panel>
            <!-- END PARTIAL: transcript-control -->
            <!-- BEGIN PARTIAL: about-understood-listing -->
            <asp:Repeater ID="rptSectionPages" runat="server">
                <HeaderTemplate>
                    <div class="listing-container">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="listing-content rs_read_this about-understood-rs-wrapper">
                        <h2><sc:FieldRenderer ID="frNavigationSectionTitle" runat="server" FieldName="Navigation Section Title" /></h2>
                        <sc:FieldRenderer ID="frNavigationSectionImage" FieldName="Navigation Section Image" runat="server" Parameters="mw=289&mh=164" />
                        <p>
                            <sc:FieldRenderer ID="frNavigationSectionSummary" runat="server" FieldName="Navigation Section Summary" />
                            <asp:HyperLink ID="hlReadMore" runat="server" />
                        </p>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <!-- end listing-container -->
            <!-- END PARTIAL: about-understood-listing -->
        </div>
        <div class="about-large-block">
            <div class="col col-7 offset-1 donate-advice-sidebar skiplink-sidebar">
                <!-- BEGIN PARTIAL: donate -->
                <sc:sublayout ID="Sublayout2" runat="server" path="~/Presentation/Sublayouts/About/Widgets/Donate.ascx" />
                <!-- END PARTIAL: donate -->
                <!-- BEGIN PARTIAL: get-advice -->
                <div class="get-advice">
                    <h4>Get Advice
                        <br>
                        Just For You</h4>
                    <p>Has your child had a formal evaluation for learning &amp; attention issues?</p>
                    <ul>
                        <li><a href="REPLACE" class="button">Yes</a></li>
                        <li><a href="REPLACE" class="button">No</a></li>
                        <li class="in-progress"><a href="REPLACE" class="button">In Progress</a></li>
                        <li class="complete-profile"><a href="REPLACE">Complete My Profile</a></li>
                    </ul>
                </div>
                <!-- .get-advice -->
                <!-- END PARTIAL: get-advice -->
                <!-- BEGIN PARTIAL: about-contact-us -->
                <sc:sublayout ID="Sublayout1" runat="server" path="~/Presentation/Sublayouts/About/Widgets/ContactUs.ascx" />
                <!-- END PARTIAL: about-contact-us -->
            </div>
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container -->
<div class="container flush l-founding-partners-carousel">
    <div class="row">
        <div class="col col-24 about-small-block-after skiplink-feature">
            <!-- BEGIN PARTIAL: founding-carousel -->
            <div class="founding-container">
                <header>
                    <h2><%--Our Coalition of Founding Partners--%>
                        <sc:FieldRenderer ID="frPartnersListHeadline" runat="server" FieldName="Partner List Headline" />
                    </h2>
                    <p>
                        <%--inventore rem nisi qui sit rerum minima culpa quia ratione vel facilis quis qui quisquam.--%>
                        <sc:FieldRenderer ID="frPartnerListSummary" runat="server" FieldName="Partner List Summary" />
                    </p>
                </header>

                <asp:Repeater ID="rptPartnerList" runat="server">
                    <HeaderTemplate>
                        <div class="founding-carousel-outer-rs-wrapper">
                            <div class="founding-carousel-outer">
                                <div class="founding-slides-wrapper arrows-gray">
                                <div class="row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col col-4">
                            <ul>
                                <li>
                                    <asp:HyperLink ID="hlPartnerLogo" runat="server">
                                        <sc:FieldRenderer ID="frPartnerLogo" runat="server" FieldName="Partner Logo" Parameters="mw=150&mh=89" />
                                    </asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                                </div>
                                </div>
                            </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>

            </div>        
            <!-- end founding-container -->
            <!-- END PARTIAL: founding-carousel -->
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container  flush -->

