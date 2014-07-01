<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsMoreCarousel.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsMoreCarousel" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- More Like This Module -->
<div class="container more-carousel">
    <div class="row">
        <div class="col col-24">
            <div class="rs_read_this more-carousel-heading-rs-wrapper">
                <h2><sc:FieldRenderer ID="frCarouselTitle" runat="server" FieldName="Carousel Related Articles Title" /></h2>
            </div>
            <asp:Repeater ID="rptArticles" runat="server">
                <HeaderTemplate>
                    <div class="more-carousel-container">
                        <!-- BEGIN PARTIAL: more-carousel -->
                        <div id="featured-slides-container" class="arrows-gray">
                            <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <div class="rs_read_this">
                            <asp:HyperLink runat="server" ID="hlArticleLink">
                                <p><asp:Literal ID="litArticleTitle" runat="server" /></p>
                                <sc:FieldRenderer ID="frContentThumbnail" runat="server" FieldName="Content Thumbnail" Parameters="mw=230&mh=129" />
                            </asp:HyperLink>
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                            </ul>
                        </div>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
   
        </div>
    </div>
</div>
