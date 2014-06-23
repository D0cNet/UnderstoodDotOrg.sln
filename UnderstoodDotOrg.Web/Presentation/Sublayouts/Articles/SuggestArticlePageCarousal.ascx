<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuggestArticlePageCarousal.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.SuggestArticlePageCarousal" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- More Like This Module -->
<asp:Repeater ID="rptArticles" runat="server">
    <HeaderTemplate>
        <div class="container more-carousel more-carousel-no-border-bottom">
            <div class="row">
                <div class="col col-24">
                    <div class="rs_read_this more-carousel-heading-rs-wrapper">
                        <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.MoreLikeThisLabel %></h2>
                    </div>
                    <div class="more-carousel-container">
                        <!-- BEGIN PARTIAL: more-carousel -->
                        <div id="featured-slides-container" class="arrows-gray">
                            <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <div class="rs_read_this">
                <asp:HyperLink ID="hlArticleDetail" runat="server">
                    <p><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></p>
                    <asp:Image ID="imgThumbnail" runat="server" />
                </asp:HyperLink>
            </div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
                            </ul>
                        </div>
                        <!-- #more-carousel-slides-container-->

                        <!-- END PARTIAL: more-carousel -->
                    </div>
                    <!-- .more-carousel-container -->
                </div>
            </div>
        </div>
    </FooterTemplate>
</asp:Repeater>