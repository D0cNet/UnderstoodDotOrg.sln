<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QandADetails.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Q_and_A.QandADetails" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container community-q-a-details">
    <div class="row skiplink-feature">
        <div class="col col-24">
            <a href="REPLACE" class="link-back"><i class="icon-arrow-left-blue"></i>Back to Q &amp; A</a>
            <!-- BEGIN PARTIAL: community/question_detail_card -->
            <div class="card-question-detail clearfix">
                <div class="question-image">
                    <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                </div>
                <div class="question-answer-info">
                    <span class="question-status">Open Question:</span>
                    <h2 class="title"><sc:Text ID="QuestionTitle" Field="Question Title" runat="server" /></h2>
                    <div class="description">
                        <sc:Text ID="QuestionBody" Field="Question Body" runat="server" />
                    </div>
                    <span class="details">In <a href="REPLACE" class="topic">ipsam velit</a> - Asked by <a href="REPLACE" class="author"><sc:Text ID="Author" Field="Question Author" runat="server" /></a> <span class="bullet">&bull;</span> 6 hours ago</span>
                    <div class="buttons">
                        <a class="button answer" href="REPLACE">Answer Question</a>
                        <a class="button follow" href="REPLACE"><span>Follow This Question</span></a>
                    </div>
                </div>
            </div>
            <!-- END PARTIAL: community/question_detail_card -->
        </div>
    </div>
</div>
<div class="container community-q-a-details-answers">
    <div class="row">
        <sc:Placeholder Key="Answers" runat="server" />
    </div>
</div>
