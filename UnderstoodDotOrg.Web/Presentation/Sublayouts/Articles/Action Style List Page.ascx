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
            <!-- BEGIN PARTIAL: about-the-author -->
            <sc:Sublayout ID="sbAboutAuthor" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx"/>

            <!-- END PARTIAL: about-the-author -->
           <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" />

            <div class="find-this-helpful-small">
                <!-- Module within only appears in under 650px window width-->
            </div>
            <!-- BEGIN PARTIAL: keep-reading-mobile -->


            <!-- END PARTIAL: keep-reading-mobile -->
            <!-- BEGIN PARTIAL: article-poll -->
            <section class="article-poll">

                <div class="poll-question">
                    <div class="poll-question-left">
                        <h3>Reader Poll</h3>
                        <img class="foo" alt="FPO content image" src="http://placehold.it/190x107&amp;text=190x107" />
                    </div>
                    <!-- .poll-question-left -->
                    <div class="poll-question-right">
                        <div class="help-me"><a href="REPLACE">Help me decide</a></div>
                        <h4>Are you considering Ritalin for your child?</h4>
                        <label for="article-poll-answer1">
                            <input type="radio" id="article-poll-answer1" name="article-poll-answer">
                            Yes</label>
                        <label for="article-poll-answer2">
                            <input type="radio" id="article-poll-answer2" name="article-poll-answer">
                            No</label>
                    </div>
                    <!-- .poll-question-right -->
                </div>
                <!-- .poll-question -->

                <div class="poll-results">
                    <h3>Are you considering Ritalin for your child?</h3>

                    <div class="row poll-result poll-result-1">
                        <div class="col col-3">
                            <div class="poll-answer poll-answer-1">Yes</div>
                        </div>
                        <div class="col col-18">
                            <div class="poll-bar poll-bar-1" style="width: 16%; background-color: #406aad;">&nbsp;</div>
                        </div>
                        <div class="col col-3">
                            <div class="poll-percent poll-percent-1">16%</div>
                        </div>
                    </div>

                    <div class="row poll-result poll-result-2">
                        <div class="col col-3">
                            <div class="poll-answer poll-answer-2">No</div>
                        </div>
                        <div class="col col-18">
                            <div class="poll-bar poll-bar-2" style="width: 84%; background-color: #59ab7e;">&nbsp;</div>
                        </div>
                        <div class="col col-3">
                            <div class="poll-percent poll-percent-2">84%</div>
                        </div>
                    </div>

                    <hr>
                    <div class="poll-footer">
                        <div class="poll-footer-left">
                            <span>567</span> Responses
     
                        </div>
                        <div class="poll-footer-right">
                            <p>Find Out More</p>
                            <p><a href="REPLACE">10 Tips to Help Kids Get Organized</a></p>
                            <p><a href="REPLACE">How to Build a Homework Plan</a></p>
                        </div>
                    </div>
                    <!-- .poll-footer -->
                </div>
                <!-- .poll-results -->

            </section>
            <!-- .article-poll -->
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




