<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetArticles.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.GetArticles" %>
<asp:Repeater ID="rptArticleListing" runat="server" OnItemDataBound="rptArticleListing_ItemDataBound">
    <HeaderTemplate>
        <div class="row listing-row">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col col-11 offset-1">
            <div class="article">
                    <asp:HyperLink runat="server" ID="hlNavLink">
                    <sc:image id="scThumbnailImage" runat="server" field="Content Thumbnail" Visible="false" />
                    <asp:Image runat="server" ID="defaultImage" Visible="false" ImageUrl="http://placehold.it/190x107" />
                </asp:HyperLink>
                <div class="article-title-container">
                    <h3>
                        <asp:HyperLink runat="server" ID="hlLinkText"></asp:HyperLink>
                    </h3>
                    <div class="children">
                        <i class="child-a" title="CHILD NAME HERE"></i><i class="child-b" title="CHILD NAME HERE"></i><i class="child-c" title="CHILD NAME HERE"></i><i class="child-e" title="CHILD NAME HERE"></i>
                    </div>
                </div>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
