<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsBehaviorAdvice.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsBehaviorAdvice" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:ScriptManager runat="server" />

<div class="col col-16 <%= HttpUtility.UrlDecode(AdditionalCssClass) %>">
<!-- BEGIN PARTIAL: behavior-advice -->
<div class="behavior-advice-wrapper">
  <div class="behavior-advice">
    <div class="behavior-advice-title"><sc:FieldRenderer ID="frCalloutTitle" runat="server" FieldName="Callout Title" /></div>
    <div class="advice-question-wrapper">
        <asp:Label AssociatedControlID="ddlChallenges" runat="server" CssClass="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.SelectChallenge %></asp:Label>
        <asp:DropDownList ID="ddlChallenges" runat="server" />
    </div>

    <div class="advice-question-bottom clearfix">
      <div class="advice-question-wrapper select-container">
          <asp:Label AssociatedControlID="ddlGrades" runat="server" CssClass="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.Grades.SelectGrade %></asp:Label>
          <asp:DropDownList ID="ddlGrades" runat="server" />
      </div>

      <div class="behavior-advice-actions">
        <asp:Button ID="btnSubmit" runat="server" CssClass="button" />
      </div>
    </div>

    <a href="#" class="advice-more-link"><sc:FieldRenderer ID="frCalloutLinkText" runat="server" FieldName="Callout Suggestions Link Text" /></a>
    <!-- BEGIN PARTIAL: suggest-a-behavior -->
<!-- Suggest a Behavior Modal -->
<div class="modal fade" id="suggest-a-behavior" tabindex="-1" role="dialog" aria-labelledby="suggest-a-behavior-modal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
        <i class="close-overlay" data-dismiss="modal"><%= Close %></i>
      <asp:UpdatePanel ID="pnlSuggest" class="modal-body" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="suggest-a-behavior">
                <div class="alert-message hidden"><asp:Literal ID="litSuggestError" runat="server" /></div>
                <h3><sc:FieldRenderer ID="frSuggestionTitle" runat="server" FieldName="Suggestion Title" /></h3>
                <p><sc:FieldRenderer ID="frSuggestionInstructions" runat="server" FieldName="Suggestion Instructions" /></p>
                <asp:TextBox ID="txtSuggestion" runat="server" TextMode="MultiLine" />
                <input type="submit" class="button" value="<%= UnderstoodDotOrg.Common.DictionaryConstants.SendSuggestionButtonText %>" data-source="<%= txtSuggestion.ClientID %>" data-path="<%= AjaxPath %>" />
            </div>
            <div class="suggest-a-behavior-confirmation hidden">
                <h3><sc:FieldRenderer ID="frSuccessTitle" runat="server" FieldName="Success Title" /></h3>
                <p><sc:FieldRenderer ID="frSuccessText" runat="server" FieldName="Success Text" /></p>
                <input type="submit" data-dismiss="modal" class="button submit-button" value="<%= CloseWindow %>">
                <div class="sign-up"><asp:HyperLink ID="hlSignUp" runat="server"><sc:FieldRenderer ID="frSuccessSignupLink" runat="server" FieldName="Success Sign-Up Text" /></asp:HyperLink></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<!-- END PARTIAL: suggest-a-behavior -->
  </div>
</div>

<!-- END PARTIAL: behavior-advice -->
    </div>