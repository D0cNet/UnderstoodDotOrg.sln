<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Private Message Tool.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.MyAccount.Private_Message_Tool" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<%--<style>
    .ui-dialog
    {
        z-index: 101;
    }

</style>--%>
<script type="text/javascript">

    $(document).ready(function () {

        loadDialog();
        $(".messages-tab > ")
    });

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {

        loadDialog();

    });

    function loadDialog()
    {
        var dlg=$("#dialog-form").dialog({
            autoOpen: false,
            height: 620,
            width: 600,
            modal: true,
            resizable: false,
            buttons: {

                Cancel: function () {
                    $(this).dialog("close");
                }
            },
            appendTo: "form"


        });

        $('#btn-new-message')
            .button()
            .click(function () {
                $("#dialog-form").dialog("open");

            });



    }




</script>

<div class="account-body-wrapper">
			<!-- BEGIN PARTIAL: account-notification-tab-messages -->
		<section class="account-notifications-tab-messages">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
            <div id="dialog-form" class="telligent-wysiwyg" title="Send Private Message">
                <asp:Label ID="Label1" Text="Recipients" runat="server" /><br />
                <asp:DropDownList ID="ddlUserNames" AppendDataBoundItems="true" ValidationGroup="NewMessage" DataTextField="Username" DataValueField="Username" runat="server">

                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ValidationGroup="NewMessage" ControlToValidate="ddlUserNames" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator> <br />
                <asp:Label ID="lblSubject" Text="Subject" runat="server" /><br />
                <asp:TextBox runat="server"  ValidationGroup="NewMessage" ID="txtSubject"/><asp:RequiredFieldValidator  ValidationGroup="NewMessage" ID="RequiredFieldValidator2" ControlToValidate="txtSubject" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator> <br />
                <asp:Label Text="Message" ID="lblMsg" runat="server" /><br />
                <CKEditor:CKEditorControl ID="CKEditorControl1"  runat="server" Enabled="true"   ValidationGroup="NewMessage" BasePath="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor" ContentsCss="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor/contents.css" Height="127px" ResizeEnabled="False" TemplatesFiles="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor/plugins/templates/templates/default.js" Toolbar="Basic"
                     ToolbarBasic="Bold|Italic|-|NumberedList|BulletedList|-|Link|Unlink|-|About" UIColor="#CC99FF" BasicEntities="True"></CKEditor:CKEditorControl><asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="NewMessage" ControlToValidate="CKEditorControl1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />
                <div><asp:Button Text="Send Message"  UseSubmitBehavior="false" ID="btnSendNewMessage"  ValidationGroup="NewMessage"  OnClick="btnSendNewMessage_Click"  runat="server" /></div>
            </div>

            <asp:Panel ID="pnlTool" runat="server">

                <div id="left_pane" class="telligent-inbox">

                    <div class="telligent-inbox-title" ><span>
                        <asp:Literal ID="litInboxText" runat="server" /> <span class="telligent-inbox-total"><asp:Literal Text="" ID="litMsgs" runat="server" /></span></span>

                        <input type="button" title="New Message" id="btn_new_message" value="New Message" runat="server" ClientIDMode="Static" class="telligent-new-message-button"  />

                    </div>


                        <asp:ListView   OnSelectedIndexChanging="lvLastMessages_SelectedIndexChanging"   OnSelectedIndexChanged="lvLastMessages_SelectedIndexChanged" ID="lvLastMessages"  runat="server">


                            <LayoutTemplate >
                                <div class="telligent-inbox-container" id="contact_messages">

                                     <div runat="server" id="itemPlaceholder"></div>

                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfConvID" Value='<%# Eval("ConversationID") %>' runat="server" />
                                 <asp:Panel id="bkDiv" runat="server"  class="telligent-inbox-item">
                                    <div class="telligent-avatar-wrap" id="avatarImg">

                                        <asp:ImageButton  CommandName="Select" runat="server" ID="imgBtn1"   class="telligent-avatar" ImageUrl='<%# Eval("AuthorAvatar") %>' AlternateText ='<%# Eval("AuthorName")%>' />


                                    </div>
                                    <div class="telligent-inbox-summary">
                                        <h6 class="telligent-inbox-subject"><%# Eval("Subject") %></h6>
                                        <span class="telligent-inbox-timestamp"><%# Eval("HowLong") %></span>
                                    </div>
                                  </asp:Panel>
                            </ItemTemplate>

                            <AlternatingItemTemplate>
                                 <asp:HiddenField ID="hfConvID" Value='<%# Eval("ConversationID") %>' runat="server" />

                                 <asp:Panel  id="bkDiv" runat="server"  class="telligent-inbox-item alt">
                                    <div class="telligent-avatar-wrap" id="avatarImg">
                                         <asp:ImageButton ID="imgBtn1" CommandName="Select"  runat="server"   class="telligent-avatar" ImageUrl='<%# Eval("AuthorAvatar") %>' AlternateText ='<%# Eval("AuthorName")%>' />


                                    </div>
                                    <div>
                                        <h6 class="telligent-inbox-subject"><%# Eval("Subject") %></h6>
                                        <span class="telligent-inbox-timestamp"><%# Eval("HowLong") %></span>
                                    </div>
                                </asp:Panel>
                            </AlternatingItemTemplate>

                            <SelectedItemTemplate>
                                   <asp:HiddenField ID="hfConvID" Value='<%# Eval("ConversationID") %>' runat="server" />

                                 <div runat="server" class="telligent-inbox-item selected">
                                    <div class="telligent-avatar-wrap" id="avatarImg">
                                        <asp:ImageButton ID="imgBtn1" CommandName="Select"  runat="server"  class="telligent-avatar"  ImageUrl='<%# Eval("AuthorAvatar") %>' AlternateText ='<%# Eval("AuthorName")%>' />


                                    </div>
                                    <div>
                                        <h6 class="telligent-inbox-subject"><%# Eval("Subject") %></h6>
                                        <span class="telligent-inbox-timestamp"><%# Eval("HowLong") %></span>
                                    </div>
                                </div>

                            </SelectedItemTemplate>
                        </asp:ListView>


                </div>


                <div id="right_pane" class="telligent-conversation">
                   <div class="telligent-conversation-delete" > <span><asp:Label ID="lblName" Text="" runat="server"></asp:Label>

                    <asp:Button Text="Delete"  ID="btnDelete" OnClientClick="javascript:return confirm('<%= DeleteConversationMessage %>');" OnClick="btnDelete_Click"  class="telligent-conversation-delete-button" runat="server" /></span>


                    </div>
                    <div id="messages_view" class="telligent-conversation-wrapper"  >

                        <asp:Repeater ID="rptMessages" runat="server">
                            <ItemTemplate>
                                 <div id="Div1"  runat="server"  class="telligent-conversation-item">
                                    <div class="telliget-avatar-wrap" id="avatarImg">

                                        <asp:Image  runat="server" ID="imgBtn1"   class="telligent-avatar" ImageUrl='<%# Eval("AuthorAvatar") %>' AlternateText ='<%# Eval("AuthorName")%>' />

                                    </div>
                                     <div class="telligent-timestamp"><span><%# Eval("Time") %></span></div>
                                    <div>
                                       <h1 class="telligent-conversation-author"><%# Eval("AuthorName") %></h1>
                                        <span class="telligent-conversation-body"><%# Eval("Body") %></span>
                                    </div>
                                  </div>
                                <div class="telligent-clearing-div"></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div >
                    <div class="telligent-reply-editor">
                        <CKEditor:CKEditorControl ID="CKEditor1"  runat="server"  BasePath="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor" ContentsCss="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor/contents.css" Height="127px" ResizeEnabled="False" TemplatesFiles="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor/plugins/templates/templates/default.js" Toolbar="Basic"
                          ToolbarBasic="Bold|Italic|-|NumberedList|BulletedList|-|Link|Unlink|-|About" UIColor="#CC99FF"></CKEditor:CKEditorControl>


                    <asp:Button Text="Submit Reply" ID="btnReply" runat="server"  class="telligent-reply-button" OnClick="btnReply_Click" />

                    </div>
              </div>
        </asp:Panel>
           </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnReply" />
            </Triggers>
            </asp:UpdatePanel>

		</section>

<!-- END PARTIAL: account-notification-tab-messages -->
</div>
<!-- .account-body-wrapper -->

