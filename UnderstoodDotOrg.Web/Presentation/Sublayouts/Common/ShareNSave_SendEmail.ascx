<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareNSave_SendEmail.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ShareNSave_SendEmail" %>

<div class="email-a-friend-modal modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlForm" runat="server">
                    <h4 class="title">Send to a Friend</h4>
                    <p id="validWarning" runat="server" visible="false" style="color: red;">Please fill out all fields</p>
                    <p><asp:TextBox ID="txtYourname" runat="server"></asp:TextBox></p>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1"
                        controltovalidate="txtYourname"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>
                    <p><asp:TextBox ID="txtYourEMailID" runat="server"></asp:TextBox></p>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator2"
                        controltovalidate="txtYourEMailID"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>
                    <p><asp:TextBox ID="txtRecipentEMailID" runat="server"></asp:TextBox></p>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator3"
                        controltovalidate="txtRecipentEMailID"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>
                    <p><asp:TextBox ID="txtThoughts" runat="server"></asp:TextBox></p>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator4"
                        controltovalidate="txtThoughts"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>
                    <div class="buttons">
                        <button type="button" runat="server" id="btnShowResults" onserverclick="btnSend_Click" class="button" >Send</button>
                        <button type="button" class="button cancel-button" onclick="$('.email-a-friend-modal').hide();">Cancel</button>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlConfirmation" runat="server" Visible="false">
                    <h4 class="title">Email Sent!</h4>
                    <p>Thank you for sharing this content with friends and family</p>
                    <div class="buttons">
                        <button type="button" class="button cancel-button" onclick="$('.email-a-friend-modal').hide();">Close Window</button> 
                    </div>
                </asp:Panel>
          </ContentTemplate>
        </asp:UpdatePanel>
      </div><!-- .modal-body -->
    </div><!-- .modal-content -->
  </div><!-- .modal-dialog -->
</div><!-- .assessment-quiz-modal -->
<style>
    .buttons{
        display: block;
    }
    .buttons button{
        display: inline-block;
        width: 30%;
    }
</style>