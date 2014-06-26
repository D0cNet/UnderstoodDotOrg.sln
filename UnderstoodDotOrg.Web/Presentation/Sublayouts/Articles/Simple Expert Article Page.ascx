<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Simple Expert Article Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Simple_Expert_Article_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<!-- END PARTIAL: pagetopic -->
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <asp:Repeater ID="rptExpertQA" runat="server" OnItemDataBound="rptExpertQA_ItemDataBound">
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>

                    <div class="expert-question">
                        <p>
                            <sc:fieldrenderer id="frQuestion" runat="server" fieldname="Question" />
                        </p>
                    </div>
                    <div class="expert-answer">
                        <div id="divAuthorInfo" runat="server" class="expert-author">
                            <%--<sc:fieldrenderer id="frExpertImage" runat="server" fieldname="Photo" />--%>
                            <asp:HyperLink ID="hypImageLink" runat="server"></asp:HyperLink>
                            <%--<sc:Image id="frExpertImage" runat="server" field="Photo" maxheight="187" maxwidth="294" width="294" height="187" />--%>
                            <div class="expert-author-info">
                                <p class="name">
                                    <strong>
                                        <sc:fieldrenderer id="frExpertName" runat="server" fieldname="Full Name" />
                                    </strong>
                                </p>
                                <p class="title">
                                    <sc:fieldrenderer id="frExpertTitle" runat="server" fieldname="Title and Institution" />
                                </p>
                            </div>
                            <!-- end expert-author-info" -->
                        </div>
                        <!-- end expert-author -->
                        <div class="expert-content">
                            <p>
                                <sc:fieldrenderer id="frAnswer" runat="server" fieldname="Answer" />
                            </p>
                        </div>
                        <!-- end expert-content -->
                    </div>
                    <!-- end expert-answer -->
                </ItemTemplate>
                <FooterTemplate></FooterTemplate>

            </asp:Repeater>
            <style>
                .expert-question{
                    min-height: 66px;
                }
            </style>



            <!-- END PARTIAL: expert-answer -->
            <!-- BEGIN PARTIAL: about-the-author -->
            <sc:sublayout id="sbAboutAuthor" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx" />

            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" />

            <!-- END PARTIAL: about-the-author -->
            <!-- BEGIN PARTIAL: find-helpful -->
            <sc:Sublayout ID="Sublayout2" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulOther.ascx" />
            <!-- END PARTIAL: find-helpful -->
        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1 skiplink-sidebar rs_read_this">
            <!-- BEGIN PARTIAL: helpful-count -->
            <sc:sublayout id="Sublayout1" path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCountsSideColumn.ascx" runat="server"></sc:sublayout>
            <!-- END PARTIAL: comments-count -->
            <!-- BEGIN PARTIAL: find-helpful -->
            <sc:sublayout path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" runat="server"></sc:sublayout>
            <!-- END PARTIAL: find-helpful -->
            <!-- BEGIN PARTIAL: keep-reading -->
            <sc:sublayout id="slKeepReading" runat="server" path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
            <!-- END PARTIAL: keep-reading -->
            <!-- BEGIN PARTIAL: comments-summary -->

                <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/CommentsSummary.ascx" />

            <!-- END PARTIAL: comments-summary -->
            <!-- BEGIN PARTIAL: sidebar-promos -->
            <div class="sidebar-promos rs_read_this vertical">
                <sc:sublayout id="sbSidebarPromo" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/PromotionalsList.ascx" />
            </div>
            <!-- end sidebar-promos -->

            <!-- END PARTIAL: sidebar-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

