<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextOnlyTipsArticle.ascx.cs"
    Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.TextOnlyTipsArticle" %>
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

<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCounts.ascx" runat="server"></sc:Sublayout>

<div class="container article">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: text-slides -->
            <div class="article-slideshow-container text-tips">
                <div id="article-slideshow" class="rsDefault slide-show-border" data-random="false">

                    <asp:Repeater ID="rptSlides" Visible="false" runat="server">
                        <ItemTemplate>
                            <asp:Panel ID="pnlSlide" CssClass="slide text-slide" runat="server">
                                <div class="slide-inner">
                                    <div class="content rs_read_this">
                                        <div class="top">
                                            <!-- BEGIN PARTIAL: share-content-dropdown -->
                                            <!-- This file shared on multiple pages -->

                                            <div class="share-dropdown-menu rs_skip">
                                                <button class="social-share-button">Share <i class="icon-arrow"></i></button>
                                                <div class="share-menu">
                                                    <span class="social-share">Share <i class="icon-arrow"></i></span>
                                                    <ul>
                                                        <li class="clearfix">
                                                            <a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a>
                                                        </li>
                                                        <li class="clearfix">
                                                            <a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a>
                                                        </li>
                                                        <li class="clearfix">
                                                            <a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a>
                                                        </li>
                                                        <li class="clearfix">
                                                            <a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <!-- END PARTIAL: share-content-dropdown -->
                                            <!-- BEGIN PARTIAL: article-action-buttons -->
                                            <div class="article-actions buttons-container rs_skip clearfix">

                                                <button class="icon-email">email</button>

                                                <button class="icon-plus">save this</button>

                                                <button class="icon-print">print</button>

                                                <button class="icon-bell">remind me</button>

                                            </div>

                                            <!-- END PARTIAL: article-action-buttons -->
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="slide-count-text"><asp:Label ID="lblCircle" runat="server"><asp:Literal ID="ltlSlideNumber" runat="server"></asp:Literal></asp:Label> of <asp:Literal ID="ltlSlideCount" runat="server"></asp:Literal></div>
                                        <sc:FieldRenderer EnclosingTag="h3" FieldName="Tip title" ID="frTipTitle" runat="server"></sc:FieldRenderer>
                                        <sc:FieldRenderer EnclosingTag="p" FieldName="Tip text" ID="frTipText" runat="server"></sc:FieldRenderer>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="slide end">
                                <div class="slide-inner rs_read_this">
                                    <h3><a href="#" class="restart-slideshow"><asp:Literal ID="ltlSlideshowRestartLabel" runat="server"></asp:Literal></a> <asp:Literal ID="ltlSlideshowRestartAlternateLabel" runat="server"></asp:Literal></h3>
                                    <asp:Placeholder ID="phSlideshow1" Visible="false" runat="server">
                                        <asp:Panel ID="pnlThumbnail1" CssClass="thumbnail" runat="server"></asp:Panel>
                                        <div class="text">
                                            <h4><sc:FieldRenderer ID="frPageTitle1" FieldName="Page Title" runat="server"></sc:FieldRenderer></h4>
                                            <sc:FieldRenderer ID="frPageSummary1" FieldName="Page Summary" runat="server"></sc:FieldRenderer>
                                        </div>
                                        <div class="clearfix"></div>
                                    </asp:Placeholder>
                                    <asp:Placeholder ID="phSlideshow2" Visible="false" runat="server">
                                        <asp:Panel ID="pnlThumbnail2" CssClass="thumbnail" runat="server"></asp:Panel>
                                        <div class="text">
                                            <h4><sc:FieldRenderer ID="frPageTitle2" FieldName="Page Title" runat="server"></sc:FieldRenderer></h4>
                                            <sc:FieldRenderer ID="frPageSummary2" FieldName="Page Summary" runat="server"></sc:FieldRenderer>
                                        </div>
                                        <div class="clearfix"></div>
                                    </asp:Placeholder>
                                </div>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <asp:Repeater ID="rptSlideButtons" Visible="false" runat="server">
                    <HeaderTemplate>
                        <div class="index-buttons-container">
                            <button class="button prev gray"><asp:Literal ID="ltlPrev" runat="server"></asp:Literal></button>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <button class="button gray" id="hgcButton" runat="server"></button>
                    </ItemTemplate>
                    <FooterTemplate>
                            <button class="button next gray"><asp:Literal ID="ltlNext" runat="server"></asp:Literal></button>
                            <button class="button last gray"><asp:Literal ID="ltlLast" runat="server"></asp:Literal></button>
                        </div>
                    </FooterTemplate>   
                </asp:Repeater>
            </div>

            <!-- END PARTIAL: text-slides -->
        </div>
    </div>
</div>
<!-- .container -->

<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpful.ascx" runat="server"></sc:Sublayout>
