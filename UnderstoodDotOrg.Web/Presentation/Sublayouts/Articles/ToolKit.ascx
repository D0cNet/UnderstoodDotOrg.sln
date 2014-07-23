<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolKit.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.ToolKit" %>

<sc:sublayout path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCounts.ascx" runat="server"></sc:sublayout>

<div class="container article">
    <div class="row">
        <!-- article -->
        <!-- BEGIN PARTIAL: article-toolkit-intro -->
        <div class="toolkit-overlay">
            <div class="col col-13 offset-1">
                <p>
                    <sc:fieldrenderer fieldname="Featured Image" runat="server"></sc:fieldrenderer>
                </p>
            </div>
            <div class="col col-9  offset-1">
                <sc:fieldrenderer fieldname="Next To Image Text" runat="server"></sc:fieldrenderer>
            </div>
        </div>
        <style>
            .toolkit-overlay .offset-1 img{
                width: 100% !important;
                height: auto;
            }
        </style>
        <!-- END toolkit-overlay -->
        <!-- END PARTIAL: article-toolkit-intro -->
    </div>
</div>
<!-- .container -->

<!-- BEGIN PARTIAL: toolkit-thumbnails -->
<div class="container toolkit-thumbnails-container">
    <div class="row">
        <div class="col col-24">
            <div class="inner-container rs_read_this">
                <div id="toolkit-thumbnails">
                    <i id="iconType" runat="server"></i>
                    <asp:Repeater ID="rptDownloads" runat="server" OnItemDataBound="rptDownloads_ItemDataBound">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="thumbnail skiplink-content rs_read_this" aria-role="main">
                                <h4>
                                    <asp:HyperLink ID="hypTitle" runat="server">
                                        <sc:fieldrenderer id="frTitle" runat="server" fieldname="Title"></sc:fieldrenderer>
                                    </asp:HyperLink>
                                </h4>
                                <div class="bottom">
                                    <i id="iconType" runat="server"></i>
                                    <asp:HyperLink ID="hypActionLink" runat="server"></asp:HyperLink>
                                    <%--this has to be wired up--%>
                                    <span id="fileSize" runat="server"><asp:Literal ID="litFileSize" runat="server"></asp:Literal></span>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col col-15 offset-2">

            <sc:sublayout id="SBReviewedBy" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" />

        </div>
    </div>
</div>

<!-- END PARTIAL: toolkit-thumbnails -->


<sc:sublayout id="Sublayout1" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpful.ascx" />
