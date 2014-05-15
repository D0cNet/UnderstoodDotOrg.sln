<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertLandingPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.ExpertLandingPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- styling for .about-pagetopic can be found in about-partners -->

<div class="container flush l-about-experts-intro-carousel">
    <div class="row skiplink-feature">
        <div class="col col-11 offset-1">
            <!-- BEGIN PARTIAL: about/about-experts-introduction -->
            <div class="about-experts-introduction rs_read_this">
                <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />
            </div>
            <!-- END PARTIAL: about/about-experts-introduction -->
        </div>
        <div class="col col-11 offset-1">
            <!-- BEGIN PARTIAL: about/about-experts-event-carousel -->
            <div class="about-experts-event-carousel">
                <h3 class="rs_read_this">Coming up on Experts Live</h3>

                <%--<div class="event-carousel">
                        <asp:Repeater ID="rptEventCarousel" runat="server" OnItemDataBound="rptEventCarousel_ItemDataBound">
                            <HeaderTemplate>
                                <div class="about-expert">
                                    <div class="about-expert-data rs_read_this">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="event-carousel-image">
                                    <sc:Image ID="scExpertImage" runat="server" Field="Expert Image" />
                                    <div class="caption">
                                        <asp:Literal ID="litExpert" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="event-carousel-details">
                                    <p class="date">
                                        <sc:Date ID="scDate" runat="server" Field="Event Date" Format="dd MMM yy" />
                                    </p>
                                    <p class="chat-with">Chat with</p>
                                    <h4>
                                       <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Heading" />
                                    </h4>
                                    <p class="credentials">
                                        <sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="SubHeading" />
                                    </p>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                </div>
                            </div>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>--%>

                <!-- /.event-carousel -->

            </div>
            <!-- /.about-experts-event-carousel -->

            <!-- END PARTIAL: about/about-experts-event-carousel -->
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container .flush -->


<div class="container" aria-role="main">
    <!-- BEGIN PARTIAL: about/about-experts-listing -->
    <div class="about-experts-listing">

        <div class="row">
            <div class="col col-22 offset-1">
                <h3 class="rs_read_this">Learn more about our Experts</h3>
            </div>
            <!-- .col -->
        </div>
        <!-- .row -->

        <asp:Repeater ID="rptListing" runat="server" OnItemDataBound="rptListing_ItemDataBound" Visible="false">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Panel ID="rowSubParentPanel" runat="server" CssClass="col col-6">

                    <div class="about-expert rs_read_this">
                        <div class="expert-listing-image">
                            <sc:Image ID="scExpertImage" runat="server" Field="Expert Image" />
                        </div>
                        <div class="expert-listing-details">
                            <h4>
                                <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Heading" />
                            </h4>
                            <p class="credentials">
                                <sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="SubHeading" />
                            </p>
                            <div class="all-tasks">
                                <p class="tasks">Hosts Webinars</p>
                                <p class="tasks">Blogs</p>
                            </div>
                            <sc:Link ID="scFollowTwittLink" runat="server" Field="Follow on Twitter" CssClass="links rs_skip"></sc:Link>
                            <sc:Link ID="scFollowBlogLink" runat="server" CssClass="links rs_skip" Field="Follow my blog"></sc:Link>
                            <sc:Link ID="scBioLink" runat="server" CssClass="links rs_skip" Field="See my bio"></sc:Link>

                        </div>
                    </div>
                    <!-- .about-expert -->

                </asp:Panel>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>


    </div>
    <!-- .about-experts-listing -->
    <!-- END PARTIAL: about/about-experts-listing -->
</div>
<!-- end .container -->

<!-- Show More -->
<!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more rs_skip">
    <div class="row">
        <div class="col col-24">       
            <a data-count="3" data-item="about-expert" data-container="about-experts-listing" data-path="about/about-experts-listing" href="#" class="show-more-link ">
                <asp:Literal id="litShowMore" runat="server"></asp:Literal>
                <i class="icon-arrow-down-blue"></i>
         </a>
          
        </div>
    </div>
</div>
<!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
<!-- .show-more -->
