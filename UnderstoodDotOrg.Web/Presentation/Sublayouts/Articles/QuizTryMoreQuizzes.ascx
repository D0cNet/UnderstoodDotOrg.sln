<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuizTryMoreQuizzes.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.QuizTryMoreQuizzes" %>

<div class="container try-another-quiz alt-layout">
    <div class="row rs_read_this try-another-quiz-rs-wrapper">
        <!-- BEGIN PARTIAL: try-another-quiz -->
        <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_TryAnotherQuizText %></h2>
        <asp:Repeater ID="rptTryMoreQuizzes" runat="server" OnItemDataBound="rptTryMoreQuizzes_ItemDataBound">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col col-11 offset-1">
                    <div class="quiz clearfix">
                        <div class="quiz-image">
                            <asp:Image ID="imgImage" runat="server" />
                        </div>
                        <div class="quiz-text">
                            <h4><sc:FieldRenderer ID="frQuizName" runat="server" FieldName="Page Title"></sc:FieldRenderer></h4>
                            <span><asp:Hyperlink CssClass="more-link" ID="hypMoreLink" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_TaketheQuizText %></asp:Hyperlink></span>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
