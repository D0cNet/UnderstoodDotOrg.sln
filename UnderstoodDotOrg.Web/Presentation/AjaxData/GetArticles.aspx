<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetArticles.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.GetArticles" %>

<asp:Repeater ID="rptArticleListing" runat="server" OnItemDataBound="rptArticleListing_ItemDataBound">
        <ItemTemplate>
            <asp:Literal runat="server" ID="ltRowListingStart" ></asp:Literal>
            <div class="col col-11 offset-1">
                <!-- BEGIN ELEMENT: Article -->
                <div class="article">
                    <asp:HyperLink runat="server" ID="hlNavLink">
                        <sc:FieldRenderer id="scThumbnailImage" runat="server" Parameters="w=190&h=107&as=1" FieldName="Content Thumbnail" />
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
                <!-- END ELEMENT: Article -->
            </div>
            <asp:Literal runat="server" ID="ltRowListingEnd" ></asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
<asp:Label runat="server" ID="lblmoreArticle" style="display:none;" ClientIDMode="Static" Text="true"></asp:Label>