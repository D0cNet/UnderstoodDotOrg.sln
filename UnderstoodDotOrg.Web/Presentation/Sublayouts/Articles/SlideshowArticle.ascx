<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SlideshowArticle.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.SlideshowArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<script type="text/javascript">
    (function (d) {
        var f = d.getElementsByTagName('SCRIPT')[0], p = d.createElement('SCRIPT');
        p.type = 'text/javascript';
        p.async = true;
        p.src = '//assets.pinterest.com/js/pinit.js';
        f.parentNode.insertBefore(p, f);
    }(document));
</script>
<script type="text/javascript" src="//assets.pinterest.com/js/pinit.js"></script>

<sc:Sublayout ID="Sublayout1" Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulCountOnly.ascx" runat="server"></sc:Sublayout>

<div class="container article slideshow">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: article-slideshow -->
            <div class="article-slideshow-container">
                <div id="article-slideshow" class="rsDefault slide-show-border" data-random="false">
                    <asp:Repeater ID="rptSlides" runat="server" OnItemDataBound="rptSlides_ItemDataBound">
                        <HeaderTemplate></HeaderTemplate>
                        <ItemTemplate>
                            <!-- BEGIN PARTIAL: article-slideshow-slide -->
                            <asp:Panel ID="pnlSlide" runat="server" CssClass="slide">
                                <%-- OR <div class="slide tall-image"> --%>
                                <div class="slide-inner">
                                    <asp:PlaceHolder ID="phImageSlide" Visible="false" runat="server">
                                        <%-- Slide Image --%>
                                        <sc:FieldRenderer ID="frSlideImage" runat="server" FieldName="Slide Image" />
                                        <div class="content">
                                            <div class="top">
                                                <%--<div id="lblCurrentSlide" class="slide-count">test29292929</div>--%>
                                                <div class="slide-count">
                                                    <asp:Literal ID="lblCurrentSlide" runat="server"></asp:Literal>
                                                </div>
                                                <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/ShareContent.ascx" runat="server"></sc:Sublayout>
                                            </div>
                                            <%-- slide Intro--%>
                                            <h3>
                                                <sc:FieldRenderer ID="frSlideTitle" runat="server" FieldName="Slide Title" />
                                            </h3>
                                            <p>
                                                <sc:FieldRenderer ID="frSlideInto" runat="server" FieldName="Slide Text" />
                                            </p>
                                        </div>
                                        <div class="clearfix"></div>
                                    </asp:PlaceHolder>
                                </div>
                            </asp:Panel>
                            <!-- END PARTIAL: article-slideshow-slide -->
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="slide end">
                                <div class="slide-inner rs_read_this">
                                    <h3><a href="#" class="restart-slideshow">
                                        <asp:Literal ID="ltlSlideshowRestartLabel" runat="server"></asp:Literal></a>
                                        <asp:Literal ID="ltlSlideshowRestartAlternateLabel" runat="server"></asp:Literal></h3>
                                    <asp:PlaceHolder ID="phSlideshow1" Visible="false" runat="server">
                                        <asp:Panel ID="pnlThumbnail1" CssClass="thumbnail" runat="server"></asp:Panel>
                                        <div class="text">
                                            <h4>
                                                <asp:HyperLink ID="hypLink1" runat="server"></asp:HyperLink></h4>
                                            <sc:FieldRenderer ID="frPageSummary1" FieldName="Page Summary" runat="server"></sc:FieldRenderer>
                                        </div>
                                        <div class="clearfix"></div>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phSlideshow2" Visible="false" runat="server">
                                        <asp:Panel ID="pnlThumbnail2" CssClass="thumbnail" runat="server"></asp:Panel>
                                        <div class="text">
                                            <h4>
                                                <asp:HyperLink ID="hypLink2" runat="server"></asp:HyperLink></sc:FieldRenderer></h4>
                                            <sc:FieldRenderer ID="frPageSummary2" FieldName="Page Summary" runat="server"></sc:FieldRenderer>
                                        </div>
                                        <div class="clearfix"></div>
                                    </asp:PlaceHolder>
                                </div>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <asp:Repeater ID="rptSlideButton" runat="server" OnItemDataBound="rptSlideButton_ItemDataBound">
                    <HeaderTemplate>
                        <div class="index-buttons-container">
                            <div class="button prev gray">
                                Prev
                            </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="button gray" data-target="<%# Container.ItemIndex + 1 %>"><%# Container.ItemIndex + 1 %></div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="button next gray">
                            Next
                        </div>
                        <div class="button last gray">
                            Last
                        </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <%-- Show Reviewer Info only on Last suggested article slide --%>
            <div class="slideshow-review">
                <div class="container">
                    <div class="row">
                        <div class="col col-15 offset-2">
                            <sc:Sublayout ID="sbAboutAuthor" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx" />
                            <!-- BEGIN PARTIAL: reviewed-by -->
                            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" />
                            <!-- END PARTIAL: reviewed-by -->
                        </div>
                    </div>
                </div>
            </div>
            <!-- END PARTIAL: article-slideshow -->
        </div>
    </div>
</div>
<style>
    .slide-inner img {
        width: 100%;
        height: auto;
    }

    .tall-image .update-panel {
        vertical-align: top;
    }

    .wide-image .update-panel {
        float: left;
        height: 20px;
    }
</style>
<script>
    $(".icon-email").click(function (e) {
        e.preventDefault();

        $(".email-a-friend-modal").show();
        $(".email-a-friend-modal").css({ "top": "163px", "overflow": "hidden" });
        $(".email-a-friend-modal .modal-dialog").css("opacity", "1");
    })
</script>
<!-- .container -->

<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpful.ascx" runat="server"></sc:Sublayout>
<!-- .container -->




