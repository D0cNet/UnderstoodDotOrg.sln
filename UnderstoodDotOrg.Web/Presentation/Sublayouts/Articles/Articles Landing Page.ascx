<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Articles Landing Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Articles_Landing_Page" %>

<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCounts.ascx" runat="server"></sc:Sublayout>

<asp:Repeater ID="rptFeaturedArticles" runat="server" OnItemDataBound="rptFeaturedArticles_ItemDataBound">
    <ItemTemplate>
        <asp:Repeater ID="rptRow" runat="server" OnItemDataBound="rptRow_ItemDataBound">
            <HeaderTemplate>
                <div class="container common-questions">
                    <div class="row">
            </HeaderTemplate>
            <ItemTemplate>
                <figure class="col col-5 offset-<%# Container.ItemIndex + 1 %>">
                    <sc:FieldRenderer ID="frThumbnail" runat="server" FieldName="Content Thumbnail"></sc:FieldRenderer>
                </figure>
                <div class="col col-4 offset-1 question">
                    <asp:HyperLink ID="hypArticleLink" runat="server"></asp:HyperLink>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                    </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </ItemTemplate>
</asp:Repeater>


<div class="container article">
    <div class="row">
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx"/>
            <!-- END PARTIAL: reviewed-by -->
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful content" id="count-helpful-content rs_read_this">

                <h4><asp:Literal ID="ltlDidYouFindThisHelpful" runat="server"></asp:Literal></h4>
                <ul>
                    <li>
                        <button class="button yes rs_skip"><asp:Literal ID="ltlYes" runat="server"></asp:Literal></button>
                    </li>
                    <li>
                        <button class="button no gray rs_skip"><asp:Literal ID="ltlNo" runat="server"></asp:Literal></button>
                    </li>
                </ul>
                <div class="clearfix"></div>

            </div>
            <!-- END PARTIAL: find-helpful -->
        </div>
    </div>
</div>
