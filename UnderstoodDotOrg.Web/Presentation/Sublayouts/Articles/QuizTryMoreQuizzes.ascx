<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuizTryMoreQuizzes.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.QuizTryMoreQuizzes" %>

<div class="container try-another-quiz alt-layout">
    <div class="row rs_read_this try-another-quiz-rs-wrapper">
        <!-- BEGIN PARTIAL: try-another-quiz -->
        <h2>Try Another Quiz</h2>
        <asp:Repeater ID="rptTryMoreQuizzes" runat="server" OnItemDataBound="rptTryMoreQuizzes_ItemDataBound">
            <HeaderTemplate>
                <div class="col col-11 offset-1">
                    <div class="quiz clearfix">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="quiz-image">
                    <sc:FieldRenderer ID="frQuizImage" runat="server" FieldName="Content Thumbnail"></sc:FieldRenderer>
                </div>
                <div class="quiz-text">
                    <h4><sc:FieldRenderer ID="frQuizName" runat="server" FieldName="Page Title"></sc:FieldRenderer></h4>
                    <span><asp:Hyperlink CssClass="more-link" ID="hypMoreLink" runat="server">Take the Quiz</asp:Hyperlink></span>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                   </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
