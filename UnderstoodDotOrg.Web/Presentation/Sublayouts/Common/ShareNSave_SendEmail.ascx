<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareNSave_SendEmail.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ShareNSave_SendEmail" %>

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
                    <h1><%= UnderstoodDotOrg.Common.DictionaryConstants.Core_SendtoafriendLabel %></h1>
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
                    <asp:RequiredFieldValidator id="valEmail"
                        controltovalidate="txtYourEmail"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valRegEmail" runat="server" ControlToValidate="txtYourEmail" CssClass="validationerror"></asp:RegularExpressionValidator>
                    
                    <asp:Label runat="server" AssociatedControlID="txtRecipientEmail" CssClass="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.FriendsEmailLabel %></asp:Label>
                    <asp:TextBox ID="txtRecipientEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator id="valEmail2"
                        controltovalidate="txtRecipientEmail"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valRegEmail2" runat="server" ControlToValidate="txtRecipientEmail" CssClass="validationerror"></asp:RegularExpressionValidator>

                    <asp:Label runat="server" AssociatedControlID="txtThoughts" CssClass="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.EmailTextPlaceholder %></asp:Label>
                    <asp:TextBox ID="txtThoughts" runat="server" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator id="RequiredFieldValidator4"
                        controltovalidate="txtThoughts"
                        validationgroup="vlgEmailForm"
                        runat="server">
                    </asp:RequiredFieldValidator>

                    <div class="buttons">
                        <button type="button" runat="server" id="btnShowResults" onserverclick="btnSend_Click" class="button send rs_preserve" ><%= UnderstoodDotOrg.Common.DictionaryConstants.SendButtonText %></button>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlConfirmation" runat="server" Visible="false" CssClass="rs_read_this">
                    <h1><%= UnderstoodDotOrg.Common.DictionaryConstants.Core_EmailSentLabel %></h1>
                    <p><asp:Literal ID="litThankYouMessage" runat="server"></asp:Literal></p>
                    <div class="buttons">
                        <button type="button" class="button close" id="closeButton" runat="server" onserverclick="closeButton_ServerClick" data-dismiss="modal"><%= UnderstoodDotOrg.Common.DictionaryConstants.CloseWindowButtonText %></button>
                    </div>
                </asp:Panel>
          </ContentTemplate>
        </asp:UpdatePanel>
      </div><!-- .modal-body -->
    </div><!-- .modal-content -->
  </div><!-- .modal-dialog -->
</div><!-- .assessment-quiz-modal -->