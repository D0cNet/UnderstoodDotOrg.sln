<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssessmentQuizArticlePageEnd.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.AssessmentQuizArticlePageEnd" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: pagetopic -->

<!-- END PARTIAL: pagetopic -->
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1 skiplink-content rs_read_this article-assessment-quiz-rs-wrapper " aria-role="main" aria-role="main">
            <!-- BEGIN PARTIAL: assessment-quiz-3 -->
            <div class="container assessment-quiz">
                <div class="assessment-quiz-form">

                    <div class="assessment-quiz-result">
                        <h3 class="assessment-result-intro"><%--Your child's learning style is:--%>
                            <sc:FieldRenderer ID="frQuizIntro" runat="server" FieldName="Quiz Headline" />
                        </h3>
                        <h2 class="assessment-result-title"><%--VisualResult Title--%>
                            <sc:FieldRenderer ID="frResultTitle" runat="server" FieldName="Result Title" />
                        </h2>
                        <p class="assessment-result-description">
                            <%--hic ut quasi quia veritatis esse est commodi sapiente soluta sed quidem tempora ab delectus ducimus voluptatem sit ipsum facere et eaque aliquid nulla facere quos dicta ea ex eius et quia distinctio reprehenderit doloribus sit harum odit accusantium quia dolorem ipsum recusandae ex quam enim ipsum magni est debitis ducimus dolores quis nemo recusandae voluptatem velit illum non ut aut inventore repudiandae et cupiditate et qui eius et voluptatem sint quaerat qui dolores ut quam exercitationem deleniti id consequatur aut vel voluptatibus dolor autem fugit aut enim unde dolores eos mollitia repellendus dolor eaque eum veniam dolorum suscipit et--%>
                            <sc:FieldRenderer ID="frResultDesc" runat="server" FieldName="Result Description" />
                        </p>
                    </div>

                </div>
                <!-- .assessment-quiz-form -->
            </div>
            <!-- .assessment-quiz -->

            <!-- END PARTIAL: assessment-quiz-3 -->
            <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" Visible="false" />
            <%--<p class="reviewed-by">
                <span class="reviewed-by-title">Reviewed&nbsp;by</span> <span class="reviewed-by-author">
                   <%--<a href="REPLACE">Dr. Samantha Frank</a>
                   <asp:HyperLink ID="hlReviewdby" runat="server">
                       <sc:FieldRenderer ID="frReviewedby" runat="server" FieldName="Revierwer Name" />
                    </asp:HyperLink>
                </span><span class="dot"></span><span class="reviewed-by-date">
                    <%--12&nbsp;Dec&nbsp;&apos;13
                    <sc:Date ID="dtReviewdDate" Field="Reviewed Date" runat="server" Format="dd MMM yy" />
                </span>
            </p>--%>
            <!-- END PARTIAL: reviewed-by -->
        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1 skiplink-sidebar rs_read_this">
            
                <%-- <sc:Placeholder ID="Placeholder1" Key="Quiz-Sidebar" runat="server" />--%>
            
                <div class="count-helpful">
                    <a href="#count-helpful-sidebar"><span>34</span>Found this helpful</a>
                </div>
                <!-- END PARTIAL: helpful-count -->
                <!-- BEGIN PARTIAL: find-helpful -->
                <div class="find-this-helpful sidebar" id="count-helpful-sidebar rs_read_this">
                    <h4>Did you find this helpful?</h4>
                    <ul>
                        <li>
                            <button class="button yes rs_skip">Yes</button>
                        </li>
                        <li>
                            <button class="button no gray rs_skip">No</button>
                        </li>
                    </ul>
                    <div class="clearfix"></div>

                </div>

                <!-- END PARTIAL: find-helpful -->
                <!-- BEGIN PARTIAL: keep-reading -->
                <%-- <div class="keep-reading">
                    <sc:Sublayout ID="slKeepReading" runat="server" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
                    <h3>Keep Reading</h3>
                <ul>
                    <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
                    <li><a href="REPLACE">How to Build a Homework Plan</a></li>
                    <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
                </ul>
                </div>--%>
                <!-- END PARTIAL: keep-reading -->
            
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container try-another-quiz">
    <div class="row rs_read_this try-another-quiz-rs-wrapper">
        <!-- BEGIN PARTIAL: try-another-quiz -->
        <sc:Placeholder ID="Placeholder2" Key="Try-More-Quizzes" runat="server" />
    </div>
</div>

<sc:Placeholder ID="Placeholder3" Key="Mini-Tools-Container" runat="server" />
