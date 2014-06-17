<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QandADetails.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Q_and_A.QandADetails" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container community-q-a-details">
    <div class="row skiplink-feature">
        <div class="col col-24">
            <a href="/en/Community%20and%20Events/Q%20and%20A.aspx" class="link-back"><i class="icon-arrow-left-blue"></i>Back to Q &amp; A</a>
            <!-- BEGIN PARTIAL: community/question_detail_card -->
            <div class="card-question-detail clearfix">
                <div class="question-image">
                    <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                </div>
                <div class="question-answer-info">
                    <span class="question-status">Open Question:</span>
                    <h2 class="title"><asp:Label ID="QuestionTitleLabel" runat="server" /></h2>
                    <div class="description">
                        <asp:Label ID="QuestionBodyLabel" runat="server" />
                    </div>
                    <span class="details">In <a href="REPLACE" class="topic"><asp:Label ID="GroupLabel" runat="server" /></a> - Asked by <a href="REPLACE" class="author"><asp:Label ID="AuthorLabel" runat="server" /></a> <span class="bullet">&bull;</span> <asp:Label ID="DateLabel" runat="server" /></span>
                    <div class="buttons">
                        <a class="button answer" href="javascript:void" onclick="DisplayForm();">Answer Question</a>
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
        <div style="display: none; margin:40px;" id="commentsForm" class="comment-form" runat="server">
            <textarea style="margin-top:20px;" name="comment-form-reply" class="comment-form-reply uniform" id="CommentEntryTextField" placeholder="Add your answer..." runat="server"></textarea>
            <asp:RequiredFieldValidator ValidationGroup="vgSubmitButton" ID="valComment" runat="server" ControlToValidate="CommentEntryTextField" CssClass="validationerror"></asp:RequiredFieldValidator><br /><br />
            <%--<asp:TextBox CssClass="comment-form-reply" ID="CommentEntryTextField" runat="server" />--%>
            <asp:Button width="225px" ValidationGroup="vgSubmitButton" ID="SubmitButton" OnClick="SubmitButton_Click" class="button" Text="Submit Answer" runat="server" />
            <div class="clearfix"></div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function DisplayForm() {
        var form = document.getElementById("<%=commentsForm.ClientID%>");
        if (form.style.display == "none") {
            var text = document.getElementById("<%=CommentEntryTextField.ClientID%>");
            form.style.display = "block";
            text.focus();
        }
        else
            form.style.display = "none";
    }
</script>
