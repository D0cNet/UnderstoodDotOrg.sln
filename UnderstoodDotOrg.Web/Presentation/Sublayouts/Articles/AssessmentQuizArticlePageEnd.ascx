<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssessmentQuizArticlePageEnd.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.AssessmentQuizArticlePageEnd" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: pagetopic -->

<!-- END PARTIAL: pagetopic -->
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: assessment-quiz-3 -->
            <div class="container assessment-quiz">
                <div class="assessment-quiz-form">

                    <div class="assessment-quiz-result">
                        <p class="assessment-result-intro"><%--Your child's learning style is:--%>
                            <sc:FieldRenderer ID="frQuizIntro" runat="server" FieldName="Quiz Headline" />
                        </p>
                        <h2 class="assessment-result-title"><%--VisualResult Title--%>
                            <sc:FieldRenderer ID="frResultTitle" runat="server" FieldName="Result Title" />
                        </h2>
                        <p class="assessment-result-description"><%--hic ut quasi quia veritatis esse est commodi sapiente soluta sed quidem tempora ab delectus ducimus voluptatem sit ipsum facere et eaque aliquid nulla facere quos dicta ea ex eius et quia distinctio reprehenderit doloribus sit harum odit accusantium quia dolorem ipsum recusandae ex quam enim ipsum magni est debitis ducimus dolores quis nemo recusandae voluptatem velit illum non ut aut inventore repudiandae et cupiditate et qui eius et voluptatem sint quaerat qui dolores ut quam exercitationem deleniti id consequatur aut vel voluptatibus dolor autem fugit aut enim unde dolores eos mollitia repellendus dolor eaque eum veniam dolorum suscipit et--%>
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
        <div class="col col-5 offset-1">

            <sc:placeholder id="Placeholder1" key="Quiz-Sidebar" runat="server" />

        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container try-another-quiz">
    <div class="row">
        <!-- BEGIN PARTIAL: try-another-quiz -->
        <sc:placeholder id="Placeholder2" key="Try-More-Quizzes" runat="server" />
    </div>
</div>

 <sc:placeholder id="Placeholder3" key="Mini-Tools-Container" runat="server" />
