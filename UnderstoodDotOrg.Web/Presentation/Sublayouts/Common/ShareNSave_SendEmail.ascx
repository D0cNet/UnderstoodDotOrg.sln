<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareNSave_SendEmail.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ShareNSave_SendEmail" %>

<div class="email-a-friend-modal modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body">
        <h4 class="title">Send to a Friend</h4>
        <p><asp:TextBox ID="txtYourname" runat="server"></asp:TextBox></p>
        <p><asp:TextBox ID="txtYourEMailID" runat="server"></asp:TextBox></p>
        <p><asp:TextBox ID="txtRecipentEMailID" runat="server"></asp:TextBox></p>
        <p><asp:TextBox ID="txtThoughts" runat="server"></asp:TextBox></p>
        <div class="buttons">
            <button type="button" runat="server" id="btnShowResults" onserverclick="btnSend_Click" class="button" >Send</button>
            <button type="button" class="button cancel-button">Cancel</button>
        </div>
      </div><!-- .modal-body -->
    </div><!-- .modal-content -->
  </div><!-- .modal-dialog -->
</div><!-- .assessment-quiz-modal -->
<script>
    $(".email-a-friend-modal .cancel-button").click(function () {
        $(".email-a-friend-modal").hide();
    })
</script>
<style>
    .buttons{
        display: block;
    }
    .buttons button{
        display: inline-block;
        width: 30%;
    }
</style>