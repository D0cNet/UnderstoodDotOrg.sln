<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuggestArticlePageCarousal.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.SuggestArticlePageCarousal" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container more-carousel">
    <div class="row">
        <div class="col col-24">
            <h2>
                <%--More Like This:--%>
                <sc:FieldRenderer ID="frRelatedLinkTitle" runat="server" FieldName="Related Link Header Title" />
            </h2>
            <div id="more-carousel-slides-container">
                <ul>
                    <asp:Repeater ID="rptMoreArticle" runat="server" OnItemDataBound="rptMoreArticle_ItemDataBound">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink runat="server" ID="hlLinkTitle">
                                    <sc:FieldRenderer ID="frLinkTitle" runat="server" FieldName="Page Title" />
                                    <sc:FieldRenderer runat="server" ID="frLinkImage" FieldName="Content Thumbnail" />
                                </asp:HyperLink>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <!-- .more-carousel-container -->
    </div>
</div>
