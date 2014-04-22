<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsBehaviorAdvice.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsBehaviorAdvice" %>
<div class="col col-16 <%= HttpUtility.UrlDecode(AdditionalCssClass) %>">
<!-- BEGIN PARTIAL: behavior-advice -->
<div class="behavior-advice-wrapper">
  <div class="behavior-advice">
    <div class="behavior-advice-title">Get Expert Advice</div>
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
        <input class="submit-button" type="submit" value="Go">
      </div>
    </div>

    <a href="REPLACE" class="advice-more-link">Don't see your child's challenge?</a>
    <!-- BEGIN PARTIAL: suggest-a-behavior -->
<!-- Suggest a Behavior Modal -->
<div class="modal fade" id="suggest-a-behavior" tabindex="-1" role="dialog" aria-labelledby="suggest-a-behavior-modal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body">
        <div class="suggest-a-behavior">
          <div class="alert-message hidden">We're sorry. We don't see your suggestion. Please type in the behavior issues that you would like us to include in the future.</div>
          <div class="checklist-close" data-dismiss="modal"><i class="icon-close"></i><span>Close</span></div>
          <h3>Suggest a challenge</h3>
          <p>Our experts want to know the issues that are important to youso we can continue to develop new strategies.</p>
          <textarea name="" placeholder="Enter your suggestion&hellip;"></textarea>
          <input type="submit" name="" class="submit-button" value="Send Suggestion">
        </div><!-- /.suggest a behavior -->
        <div class="suggest-a-behavior-confirmation" style="display:none;">
          <div class="checklist-close" data-dismiss="modal"><i class="icon-close"></i><span>Close</span></div>
          <h3>Thank you!</h3>
          <p>Parent feedback is very important to us! Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <input type="submit" name="" data-dismiss="modal" class="submit-button" value="Close Window">
          <div class="sign-up"><a href="REPLACE">Sign up with Understood.</a></div>
        </div><!-- /.suggest-a-behavior-confirmation -->
      </div><!-- /.modal-body -->
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<!-- END PARTIAL: suggest-a-behavior -->
  </div>
</div>

<!-- END PARTIAL: behavior-advice -->
    </div>