﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareNSave_SendEmail.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ShareNSave_SendEmail" %>

<div class="share-email-modal modal fade">
  <div class="modal-dialog">
    <div class="modal-content">

        <div class="modal-header">
                <div class="modal-close close" data-dismiss="modal"><i class="icon-close"></i><span><%=  UnderstoodDotOrg.Common.DictionaryConstants.CloseButtonText %></span></div>
        </div>

      <div class="modal-body">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlForm" runat="server" CssClass="share-email-form rs_read_this">
                    <h1>Send to a Friend</h1>
                    <p id="validWarning" runat="server" visible="false" style="color: red;"><asp:Literal ID="litValidationMessage" runat="server"></asp:Literal></p>

                    <asp:Label runat="server" AssociatedControlID="txtYourName" CssClass="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.EnterNameLabel %></asp:Label>
                    <asp:TextBox ID="txtYourName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1"
                        controltovalidate="txtYourName"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>

                    <asp:Label runat="server" AssociatedControlID="txtYourEmail" CssClass="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.EnterEmailLabel %></asp:Label>
                    <asp:TextBox ID="txtYourEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator2"
                        controltovalidate="txtYourEmail"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>
                    
                    <asp:Label runat="server" AssociatedControlID="txtRecipientEmail" CssClass="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.FriendsEmailLabel %></asp:Label>
                    <asp:TextBox ID="txtRecipientEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator3"
                        controltovalidate="txtRecipientEmail"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>

                    <asp:Label runat="server" AssociatedControlID="txtThoughts" CssClass="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.EmailTextPlaceholder %></asp:Label>
                    <asp:TextBox ID="txtThoughts" runat="server" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator id="RequiredFieldValidator4"
                        controltovalidate="txtThoughts"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>

                    <div class="buttons">
                        <button type="button" runat="server" id="btnShowResults" onserverclick="btnSend_Click" class="button send rs_preserve" >Send</button>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlConfirmation" runat="server" Visible="false" CssClass="rs_read_this">
                    <h1>Email Sent!</h1>
                    <p><asp:Literal ID="litThankYouMessage" runat="server"></asp:Literal></p>
                    <div class="buttons">
                        <a class="button close" data-dismiss="modal"><%= UnderstoodDotOrg.Common.DictionaryConstants.CloseWindowButtonText %></a>
                    </div>
                </asp:Panel>
          </ContentTemplate>
        </asp:UpdatePanel>
      </div><!-- .modal-body -->
    </div><!-- .modal-content -->
  </div><!-- .modal-dialog -->
</div><!-- .assessment-quiz-modal -->