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
        
        <!-- my HTML  -->


        <sc:Sublayout runat="server" ID="slLiveChat" Path="~/Presentation/Sublayouts/ExpertLive/SingleLiveChat.ascx" />



        <!-- my html -->


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
                            <asp:Image runat="server" ID="imgDefaultImage" src="http://placehold.it/230x230&amp;text=230x230" alt="FPO content image" />
                        </div>
                        <div class="expert-listing-details">
                            <h4>
                                <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Expert Name" />
                            </h4>
                            <p class="credentials">
                                <sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="SubHeading" />
                            </p>
                            <%--<div class="all-tasks">
                                <p class="tasks">Hosts Webinars</p>
                                <p class="tasks">Blogs</p>
                            </div>--%>
                            <sc:Link ID="scFollowTwittLink" runat="server" Field="Follow on Twitter" CssClass="links rs_skip"></sc:Link>
                            <sc:Link ID="scFollowBlogLink" runat="server" CssClass="links rs_skip" Field="Follow my blog"></sc:Link>
                            <asp:HyperLink runat="server" CssClass="links rs_skip" ID="hlBioLink" ></asp:HyperLink>
                            <%--<sc:Link ID="scBioLink" runat="server" CssClass="links rs_skip" Field="See my bio"></sc:Link>--%>

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
<asp:Panel runat="server" ID="pnlShowMore" ClientIDMode="Static" CssClass="container show-more rs_skip" Visible="false">
    <div class="row">
        <div class="col col-24">
            <a class="show-more-link" id="expertListing"  href="#" data-path="about/about-experts-listing" data-container="about-experts-listing" data-item="about-expert" data-count="3">Show More<i class="icon-arrow-down-blue"></i></a>
        </div>
    </div>
</asp:Panel>
<asp:HiddenField runat="server" ID="hfResultsPerClick" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hfGUID" ClientIDMode="Static" />

<!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
<!-- .show-more -->
