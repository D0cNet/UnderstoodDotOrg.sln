<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalloutContainer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic.CalloutContainer" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN ELEMENT: Split Modules -->
<div class="container split-modules">
  <div class="row">
    <div class="col col-12">

      <sc:Sublayout ID="slUpcomingEvent" Path="~/Presentation/Sublayouts/Common/Widgets/UpcomingEvent.ascx" runat="server" />

    </div>
    <div class="col col-12">

      <!-- BEGIN PARTIAL: get-better-recommendations -->
    <div class="get-better-recommendations-container">
      <div class="skiplink-toolbar  rs_read_this get-better-recommendations split">
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
      </div><!-- .get-better-recommendations -->
    </div><!-- .get-better-recommendations-container --> 
    <!-- END PARTIAL: get-better-recommendations -->

    </div>
  </div>
</div>

<!-- END ELEMENT: Split Modules -->