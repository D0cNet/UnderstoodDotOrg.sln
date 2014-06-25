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
                    <asp:Image ID="imgThumbnail" runat="server" />
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
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" Visible="false"/>
            <!-- END PARTIAL: reviewed-by -->
        </div>
    </div>
</div>

<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpful.ascx" runat="server"></sc:Sublayout>
