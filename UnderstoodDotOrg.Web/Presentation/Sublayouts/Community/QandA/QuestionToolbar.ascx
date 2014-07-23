<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionToolbar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA.QuestionToolbar" %>
<div class="cta-cards skiplink-toolbar">
    <div class="card card-ask rs_read_this">
        <h2><asp:Literal ID="litAsk" runat="server" /></h2>
        <label class="description" for="ask"><sc:Text Field="Ask Description" runat="server" /></label>
        <input type="text" id="ask" name="ask" placeholder="Enter a question" />
        <input runat="server" type="submit" value="<%# UnderstoodDotOrg.Common.DictionaryConstants.SubmitYourQuestionLabel %>" class="button rs_preserve" />
    </div>
    <div class="card card-answer rs_read_this">
        <h2><asp:Literal ID="litAnswer" runat="server" /></h2>
        <span class="description"><sc:Text Field="Answer Description" runat="server" /></span>
        <a class="button rs_preserve" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeOpenQuestionsLabel %></a>
    </div>
    <div class="card card-discover rs_read_this">
        <h2><asp:Literal ID="litDiscover" runat="server" /></h2>
        <span class="description"><sc:Text Field="Discover Description" runat="server" /><br />
            <%= UnderstoodDotOrg.Common.DictionaryConstants.TheAnswersLabel %></span>
        <a class="button rs_preserve" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeAnsweredQuestionsLabel %></a>
    </div>
</div>
