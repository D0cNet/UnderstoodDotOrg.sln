<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Action Style List Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Action_Style_List_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- END PARTIAL: pagetopic -->
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->

        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: article-actions-copy -->
            <div class="article-actions-copy">
                <%--<h3>ea dolorem nam sint quia</h3>
                <p>Labore repellendus et et ut. nisi sapiente ratione in recusandae sunt quidem. ipsa animi fuga numquam omnis ipsa dignissimos culpa laboriosam</p>
                --%>
                <sc:FieldRenderer ID="frAtricleIntroText" runat="server" FieldName="Body Content" />
                <asp:Repeater ID="rptAction" runat="server" OnItemDataBound="rptAction_ItemDataBound">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <div>
                            <div class="action-step">
                               
                                    <%-- 4
                                    <sc:FieldRenderer ID="frActionNo" runat="server" FieldName="Action Number" />--%>
                                    <asp:Label ID="lblActionCount" runat="server"></asp:Label>
                                
                            </div>
                            <div class="action-head">
                                <h3><%--Lorem Ipsum--%>
                                    <sc:FieldRenderer ID="frActionTitle" runat="server" FieldName="Title" />
                                </h3>
                            </div>
                            <div class="clearfix"></div>
                            <div class="action-copy">
                                <p>
                                    <%--Exercitationem exercitationem soluta similique libero voluptas. occaecati et est optio ab ut blanditiis et consequatur vero optio. natus aperiam porro blanditiis. et ut consequuntur quam et. est blanditiis sed sit voluptas molestiae odit--%>
                                    <sc:FieldRenderer ID="frActionIntro" runat="server" FieldName="Introduction" />
                                </p>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>

            </div>
            <!-- END PARTIAL: article-actions-copy -->
            <div class="rs_about_author rs_read_this">
                <!-- BEGIN PARTIAL: about-the-author -->
                <sc:Sublayout ID="sbAboutAuthor" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx"/>
                <!-- END PARTIAL: about-the-author -->

                <!-- BEGIN PARTIAL: reviewed-by -->
                <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" />
                <!-- END PARTIAL: reviewed-by  -->

                <div class="find-this-helpful-small rs_skip">
                    <!-- Module within only appears in under 650px window width-->
                </div>
            </div>  
            <!-- BEGIN PARTIAL: keep-reading-mobile -->


            <!-- END PARTIAL: keep-reading-mobile -->
            
            <sc:sublayout id="Sublayout2" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/Article Poll.ascx" Visibile="False"/>
            <!-- END PARTIAL: article-poll -->
        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1 skiplink-sidebar rs_read_this">
            
            <sc:Sublayout ID="Sublayout1" Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCountsSideColumn.ascx" runat="server"></sc:Sublayout>
            
            <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" runat="server"></sc:Sublayout>
            <!-- BEGIN PARTIAL: keep-reading-lg -->
            <div class="keep-reading keep-reading-lg">
                <sc:Sublayout ID="slKeepReading" runat="server" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
            </div>
            <!-- END PARTIAL: keep-reading-lg -->
            <!-- BEGIN PARTIAL: comments-summary -->
            
                <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/CommentsSummary.ascx" />
            
            <!-- END PARTIAL: comments-summary -->
            <!-- BEGIN PARTIAL: sidebar-promos -->
            <div class="sidebar-promos rs_read_this vertical">
                <sc:Sublayout ID="sbSidebarPromo" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/PromotionalsList.ascx" />
            </div>

            <!-- end sidebar-promos -->

            <!-- END PARTIAL: sidebar-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
