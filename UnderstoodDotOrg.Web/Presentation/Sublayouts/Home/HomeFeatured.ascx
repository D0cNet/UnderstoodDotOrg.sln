<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeFeatured.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Home.HomeFeatured" %>

<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN MODULE: Featured / Recommended -->
<div class="container featured-recommended">
    <div class="row">
        <div class="col col-24">

            <h2>
                <asp:Literal Text="" ID="litFeatured" runat="server" />
            </h2>
            <div class="featured-recommended-container">
                <!-- BEGIN PARTIAL: featured-carousel -->
                <div id="featured-slides-container" class="arrows-gray">
                    <asp:Repeater ID="rptFeaturedArticles" runat="server" OnItemDataBound="rptFeaturedArticles_ItemDataBound">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <div class="rs_read_this">
                                    <asp:HyperLink ID="hypArticleLink" runat="server">
                                        <p>
                                            <asp:Literal ID="ltArticleText" runat="server"></asp:Literal></p>
                                        <sc:image id="frArticleImage" runat="server" field="Featured Image" parameters="mw=230&mh=129"></sc:image>
                                    </asp:HyperLink>
                                </div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <!-- #featured-slides-container-->
                <!-- END PARTIAL: featured-carousel -->
            </div>
            <!-- .feature-recommended-container -->

        </div>
    </div>
</div>
<!-- .container.featured-recommended -->

<!-- END MODULE: Featured / Recommended -->
