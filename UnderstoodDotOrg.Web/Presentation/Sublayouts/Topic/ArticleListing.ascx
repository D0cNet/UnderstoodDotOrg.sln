<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic.ArticleListing" %>

<!-- BEGIN PARTIAL: children-key -->
<div class="container child-content-indicator first">
    <!-- Key -->
    <div class="row">
        <div class="col col-23 offset-1">
            <div class="children-key">
                <ul>
                    <li><i class="child-a"></i>for Michael</li>
                    <li><i class="child-b"></i>for Elizabeth</li>
                    <li><i class="child-c"></i>for Ethan</li>
                    <li><i class="child-d"></i>for Jeremy</li>
                    <li><i class="child-e"></i>for Franklin</li>
                </ul>
            </div>
            <!-- .children-key -->
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>
<!-- .child-content-indicator -->
<!-- END PARTIAL: children-key -->

<!-- BEGIN MODULE: Article Listing -->
<div class="container article-listing-container article-listing">
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
</div>
<!-- .container -->

<!-- END MODULE: Article Listing -->

<!-- BEGIN MODULE: More Articles -->
<asp:Panel ID="pnlMoreArticle" runat="server" ClientIDMode="Static" CssClass="container show-more" Visible="false">
    <div class="row">
        <div class="col col-24">
            <a href="REPLACE" class="show-more-link" data-path="articles/g3" data-container="article-listing" data-item="article" data-count="6">More Articles<i class="icon-arrow-down-blue"></i></a>
        </div>
    </div>
</asp:Panel>
<!-- .show-more -->

<!-- END MODULE: More Articles -->
<asp:HiddenField runat="server" ID="hfResultsPerClick" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hfGUID" ClientIDMode="Static" />

