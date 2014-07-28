<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Assessment Quiz Modal.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Modals.Assessment_Quiz_Modal" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="assessment-quiz-modal modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body">
        <h4 class="title"><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h4>
        <sc:FieldRenderer ID="frContent" runat="server" FieldName="Content" />
        <p class="button-container group"><a href="#" class="button"><sc:FieldRenderer ID="frButtton" runat="server" FieldName="Return to Quiz Button" /></a></p>
      </div><!-- .modal-body -->
    </div><!-- .modal-content -->
  </div><!-- .modal-dialog -->
</div><!-- .assessment-quiz-modal -->