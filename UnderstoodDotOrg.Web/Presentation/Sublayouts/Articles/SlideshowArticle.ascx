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
                                                <div class="slide-count">
                                                    <%--Slide 2 of 10--%>
                                                    Slide
                                                    <asp:Label ID="lblCurrentSlide" runat="server"></asp:Label>
                                                    of
                                                    <asp:Label ID="lblTotalSlide" runat="server"></asp:Label>
                                                </div>
                                                <!-- BEGIN PARTIAL: share-content-dropdown -->
                                                <!-- This file shared on multiple pages -->
                                                <div class="share-dropdown-menu rs_skip">
                                                    <button class="social-share-button">Share<i class="icon-arrow"></i></button>
                                                    <div class="share-menu">
                                                        <span class="social-share">Share<i class="icon-arrow"></i></span>
                                                        <ul>
                                                            <li class="clearfix">
                                                                <a class="icon-facebook share-icon" href="https://facebook.com/sharer.php?u=<%= Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item) %>"><i class="icon-facebook"></i>Facebook</a>
                                                            </li>
                                                            <li class="clearfix">
                                                                <a class="icon-twitter share-icon" href="https://twitter.com/intent/tweet?url=<%= Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item) %>&text=<%= Sitecore.Context.Item.Name %>&via=YOURTWITTERNAMEHERE"><i class="icon-twitter"></i>Twitter</a>
                                                            </li>
                                                            <li class="clearfix">
                                                                <a class="icon-google share-icon" href="https://plus.google.com/share?url=<%= Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item) %>"><i class="icon-google"></i>Google +</a>
                                                            </li>
                                                            <li class="clearfix">
                                                                <a class="icon-pinterest share-icon" href="https://www.pinterest.com/pin/create/button/?url=http%3A%2F%2Fwww.flickr.com%2Fphotos%2Fkentbrew%2F6851755809%2F&media=http%3A%2F%2Ffarm8.staticflickr.com%2F7027%2F6851755809_df5b2051c9_z.jpg&description=Next%20stop%3A%20Pinterest" data-pin-do="buttonPin" data-pin-config="above" ><i class="icon-pinterest"></i>Pinterest</a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                <!-- END PARTIAL: share-content-dropdown -->
                                                <!-- BEGIN PARTIAL: article-action-buttons -->
                                                <div class="article-actions buttons-container rs_skip clearfix">
                                                    <button class="icon-email">email</button>
                                                    <button class="icon-plus">save this</button>
                                                    <button class="icon-print" onclick="window.print()">print</button>
                                                    <button class="icon-bell">remind me</button>
                                                </div>
                                                <!-- END PARTIAL: article-action-buttons -->
                                                <div class="clearfix"></div>
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
                                    <asp:PlaceHolder ID="phEnd" Visible="false" runat="server">
                                        <%--  Show Other two SideShow Article Item to start--%>
                                        <h3><a href="#" class="restart-slideshow">&lt; See Slideshow from the Beginning</a> or explore more:</h3>
                                        <div class="thumbnail" style="background-image: url('http://placehold.it/380x220')"></div>
                                        <div class="text">
                                            <h4><a href="REPLACE">facere molestiae eligendi maiores quis voluptatum qui</a></h4>
                                            <p>aspernatur ut impedit voluptatibus aperiam consequatur molestiae autem et eum perferendis provident sunt deleniti asperiores</p>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="thumbnail" style="background-image: url('http://placehold.it/380x220')"></div>
                                        <div class="text">
                                            <h4><a href="REPLACE">nihil et et nulla qui molestias distinctio</a></h4>
                                            <p>praesentium voluptates odio expedita alias deleniti aut maiores accusamus consequatur vitae asperiores sunt omnis eius</p>
                                        </div>
                                        <div class="clearfix"></div>
                                    </asp:PlaceHolder>
                                </div>
                            </asp:Panel>
                            <!-- END PARTIAL: article-slideshow-slide -->

                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                    <style>
                        .slide-inner img{
                            width: 100%;
                            height: auto;
                        }
                    </style>
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
                            <sc:Sublayout ID="sbAboutAuthor" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx"/>  
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
<!-- .container -->

<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpful.ascx" runat="server"></sc:Sublayout>
<!-- .container -->




