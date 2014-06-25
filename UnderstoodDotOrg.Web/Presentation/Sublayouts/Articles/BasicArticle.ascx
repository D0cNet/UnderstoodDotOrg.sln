<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasicArticle.ascx.cs"
    Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.BasicArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1 skiplink-content" aria-role="main" aria-role="main">

            <!-- BEGIN PARTIAL: at-a-glance -->
            <div id="divAtAGlance" runat="server" class="at-a-glance">
                <header class='header-at-a-glance'>
                    <h2><%--At-a-glance--%>
                        <asp:Literal ID="litAtAGlanceHeader" runat="server"></asp:Literal>
                    </h2>
                </header>
                <sc:FieldRenderer runat="server" FieldName="At a glance Content" ID="frSubHeadlineText" />
            </div>
            <!-- end at-a-glance -->

            <div class="article-copy">
                <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />
            </div>
            <!-- BEGIN PARTIAL: key-takeaways -->
            <div id="divKeyTakeAways" runat="server" class="key-takeaways">
                <header class='header-key-takeaways'>
                    <h2><%-- Key Takeaways--%>
                        <asp:Literal ID="litKeyTakeAwayText" runat="server"></asp:Literal>
                    </h2>
                </header>
           <sc:FieldRenderer ID="frKeyTakeawayData" runat="server" FieldName="Key Takeaway Data" />
            </div>
            <!-- end key-takeaways -->
            <!-- END PARTIAL: key-takeaways -->
            <!-- BEGIN PARTIAL: about-the-author -->
            <sc:Sublayout ID="sbAboutAuthor" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx" Visible="false" />            

            <!-- END PARTIAL: about-the-author -->
            <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" Visible="false" />

            <!-- END PARTIAL: reviewed-by -->
            <!-- BEGIN PARTIAL: find-helpful -->
            <sc:Sublayout ID="Sublayout1" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulOther.ascx" />
            <!-- END PARTIAL: find-helpful -->
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
        <div class="col col-1 sidebar-spacer">
        </div>
        <!-- right bar -->
        <div class="col col-5 offset-1">
            
            <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCountsSideColumn.ascx" runat="server"></sc:Sublayout>

            <!-- END PARTIAL: comments-count -->
            <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" runat="server"></sc:Sublayout>
            <!-- BEGIN PARTIAL: keep-reading-lg -->
            <div class="keep-reading keep-reading-lg">
                <sc:Sublayout ID="slKeepReading" runat="server" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
            </div>
            <!-- END PARTIAL: keep-reading-lg -->
            <!-- BEGIN PARTIAL: comments-summary -->
            
            
            <section class="comments-summary">
               <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/CommentsSummary.ascx" />
             </section>


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
<!-- More Like This Module -->

<!-- .container -->
<sc:Placeholder ID="Placeholder1" Key="slComment" runat="server" />
<%--<sc:Sublayout ID="slComment" runat="server" Path="~/Presentation/Sublayouts/Articles/Comments.ascx" />--%>
<!-- BEGIN PARTIAL: footer -->
