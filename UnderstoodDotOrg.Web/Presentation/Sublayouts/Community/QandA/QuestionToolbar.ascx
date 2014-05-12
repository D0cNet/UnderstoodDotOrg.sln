<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionToolbar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA.QuestionToolbar" %>
<div class="cta-cards skiplink-toolbar">
    <div class="card card-ask">
        <h2>Ask</h2>
        <label class="description" for="ask">
            Get answers to<br />
            your questions.</label>
        <asp:TextBox type="text" ID="AskTextBox" name="ask" placeholder="Enter a question" runat="server" />
        <asp:Button ID="AskQuestionButton" OnClick="AskQuestionButton_Click" runat="server" Text="Submit Your Question" class="button" />
    </div>
    <div class="card card-answer">
        <h2>Answer</h2>
        <span class="description">Got knowledge?<br />
            Help another parent.</span>
        <a class="button" href="REPLACE">See Open Questions</a>
    </div>
    <div class="card card-discover">
        <h2>Discover</h2>
        <span class="description">Learn more! Browse<br />
            the answers</span>
        <a class="button" href="REPLACE">See Answered Questions</a>
    </div>
</div>
