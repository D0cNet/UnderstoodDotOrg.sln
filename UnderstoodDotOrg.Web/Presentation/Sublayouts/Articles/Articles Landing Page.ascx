<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Articles Landing Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Articles_Landing_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCounts.ascx" runat="server"></sc:Sublayout>

<asp:Repeater ID="rptFeaturedArticles" runat="server" OnItemDataBound="rptFeaturedArticles_ItemDataBound">
    <ItemTemplate>
        <asp:Repeater ID="rptRow" runat="server" OnItemDataBound="rptRow_ItemDataBound">
            <HeaderTemplate>
                <div class="common-questions">
                    <div class="row">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col col-5 offset-1 image-left">
                    <asp:HyperLink ID="hypThumbnail" runat="server">
                        <asp:Image ID="imgThumbnail" runat="server" />
                    </asp:HyperLink>
                </div>
                <div class="col col-5 offset-1 question-right">
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
            <div class="rs_about_author rs_read_this">
                <!-- BEGIN PARTIAL: reviewed-by -->
                <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx"/>
                <!-- END PARTIAL: reviewed-by -->

                <!-- BEGIN PARTIAL: find-helpful -->
                <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpful.ascx" runat="server"></sc:Sublayout>
                <!-- END PARTIAL: find-helpful -->
            </div
        </div>
    </div>
</div>

