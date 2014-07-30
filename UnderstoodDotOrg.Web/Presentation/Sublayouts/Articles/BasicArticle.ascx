<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasicArticle.ascx.cs"
    Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.BasicArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article">
    <div class="row row-equal-heights article-basic-rs-wrapper">
        <!-- article -->
        <div class="col col-15 offset-1 skiplink-content" aria-role="main" aria-role="main">
            <div class="rs_read_this">
                <!-- BEGIN PARTIAL: at-a-glance -->
                <div id="divAtAGlance" runat="server" class="at-a-glance">

					<div class="article-feature-image">
						<sc:fieldrenderer runat="server" fieldname="Featured Image" Parameters="class=fullDimensions&mw=1178&mh=662" />
					</div>

                    <header class='header-at-a-glance'>
                        <h2><%--At-a-glance--%>
                            <asp:Literal ID="litAtAGlanceHeader" runat="server"></asp:Literal>
                        </h2>
                    </header>
                    <sc:fieldrenderer runat="server" fieldname="At a glance Content" id="frSubHeadlineText" />
                </div>
                <!-- end at-a-glance -->

                <div class="article-copy">
                    <sc:fieldrenderer id="frBodyContent" runat="server" fieldname="Body Content" />
                </div>
                <!-- BEGIN PARTIAL: key-takeaways -->
                <div id="divKeyTakeAways" runat="server" class="key-takeaways">
                    <header class='header-key-takeaways'>
                        <h2><%-- Key Takeaways--%>
                            <asp:Literal ID="litKeyTakeAwayText" runat="server"></asp:Literal>
                        </h2>
                    </header>
                    <sc:fieldrenderer id="frKeyTakeawayData" runat="server" fieldname="Key Takeaway Data" />
                </div>
                <!-- end key-takeaways -->
                <!-- END PARTIAL: key-takeaways -->
            </div>
            <div class="rs_about_author rs_read_this">
              <!-- BEGIN PARTIAL: about-the-author -->
              <sc:sublayout id="sbAboutAuthor" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx" />
              <!-- END PARTIAL: about-the-author -->

              <!-- BEGIN PARTIAL: reviewed-by -->
              <sc:sublayout id="SBReviewedBy" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" />
              <!-- END PARTIAL: reviewed-by -->

              <!-- BEGIN PARTIAL: find-helpful -->
              <sc:sublayout id="Sublayout1" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulOther.ascx" />
              <!-- END PARTIAL: find-helpful -->

              <div class="find-this-helpful-small rs_skip">
                <!-- Module within only appears in under 650px window width-->
              </div>
            </div>

            <!-- BEGIN PARTIAL: keep-reading-mobile -->


            <!-- END PARTIAL: keep-reading-mobile -->
            <sc:sublayout id="Sublayout2" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/Article Poll.ascx"/>
            <!-- END PARTIAL: article-poll -->
        </div>
        <div class="col col-1 sidebar-spacer">
        </div>
        <!-- right bar -->
        <div class="col col-5 offset-1 skiplink-sidebar rs_read_this">

            <sc:sublayout path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCountsSideColumn.ascx" runat="server"></sc:sublayout>

            <!-- END PARTIAL: comments-count -->
            <sc:sublayout path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" runat="server"></sc:sublayout>
            <!-- BEGIN PARTIAL: keep-reading-lg -->
            <div class="keep-reading keep-reading-lg">
                <sc:sublayout id="slKeepReading" runat="server" path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
            </div>
            <!-- END PARTIAL: keep-reading-lg -->
            <!-- BEGIN PARTIAL: comments-summary -->


            <sc:sublayout id="sbCommentsSummary" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/CommentsSummary.ascx" />


            <!-- END PARTIAL: comments-summary -->
            <!-- BEGIN PARTIAL: sidebar-promos -->
            <div class="sidebar-promos rs_read_this vertical">
                <sc:sublayout id="sbSidebarPromo" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/PromotionalsList.ascx" />
            </div>

            <!-- end sidebar-promos -->
            <!-- END PARTIAL: sidebar-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
<!-- More Like This Module -->

<!-- .container -->
<sc:placeholder id="Placeholder1" key="slComment" runat="server" />
<%--<sc:Sublayout ID="slComment" runat="server" Path="~/Presentation/Sublayouts/Articles/Comments.ascx" />--%>
<!-- BEGIN PARTIAL: footer -->
