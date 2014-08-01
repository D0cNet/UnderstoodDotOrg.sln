<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Recommendations.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Section.Recommendations" %>
<div class="get-better-recommendations-container">
  <div class="skiplink-toolbar  rs_read_this get-better-recommendations ">
    <div class="get-recommendations">
          <h4><asp:Literal ID="litQuestionHeader" runat="server"></asp:Literal> <button class="popover-link rs_preserve"><i class="icon-question-mark tooltip rs_skip">more information</i></button></h4>
          <div class="popover-container rs_skip">
            <p><strong><asp:Literal ID="litWhyAskHeader" runat="server"></asp:Literal> </strong> <asp:Literal ID="litWhyAskContent" runat="server"></asp:Literal></p>
          </div>
          <h3><asp:Literal ID="litQuestion" runat="server"></asp:Literal></h3>
          <ul>
            <li><asp:HyperLink ID="hypCompleteProfile" runat="server" CssClass="button rs_skip"></asp:HyperLink></li>
          </ul>
        </div><!-- .get-recommendations -->
    <!-- .get-recommendations -->
    <div class="thank-you rs_skip">
      <h4>Thank You!</h4>
      <p>You've completed <span class="total-completed">3</span> out of <span class="total-questions">100</span> questions.</p>
      <a href="REPLACE" class="button">Complete my full profile</a>
    </div><!-- .thank-you -->

 </div><!-- .get-better-recommendations -->
</div><!-- .get-better-recommendations-container --> 
<!-- END PARTIAL: get-better-recommendations -->