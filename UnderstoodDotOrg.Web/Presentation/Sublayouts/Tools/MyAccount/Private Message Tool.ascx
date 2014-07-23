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
            height: 650,
            width: 600,
            modal: true,
            resizable: false,
            title: '<%= PopUpTitleText %>',
            buttons: {

                '<%= CancelButtonText %> ': function () {
                    $(this).dialog("close");
                }
            },
            appendTo: "form"


        });

        $('#btn_new_message')
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
            <div id="dialog-form" title="Send Private Message">
                <asp:Label ID="Label1" Text="Recipients" runat="server" /><br />
               <%-- <asp:DropDownList ID="ddlUserNames" AppendDataBoundItems="true" ValidationGroup="NewMessage" DataTextField="Username" DataValueField="Username" runat="server">

                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ValidationGroup="NewMessage" ControlToValidate="ddlUserNames" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator> <br />--%>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                    <asp:Panel ScrollBars="Vertical"  ID="pnlUserNames" runat="server" Height="84px">
                       <asp:CheckBoxList ID="chklUsernames"  runat="server" AppendDataBoundItems="true"  DataTextField="Username" DataValueField="Username" RepeatColumns="3" RepeatDirection="Horizontal" Width="500px">
                       
                        </asp:CheckBoxList>
                     </asp:Panel>
                    <asp:LinkButton   ID="lbLoadMore" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lbLoadMore"  />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Label ID="lblSubject" Text="Subject" runat="server" /><br />
                <asp:TextBox runat="server"  ValidationGroup="NewMessage" ID="txtSubject"/><asp:RequiredFieldValidator  ValidationGroup="NewMessage" ID="RequiredFieldValidator2" ControlToValidate="txtSubject" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator> <br />
                <asp:Label Text="Message" ID="lblMsg" runat="server" /><br />
                <CKEditor:CKEditorControl ID="CKEditorControl1"  runat="server" Enabled="true"   ValidationGroup="NewMessage" BasePath="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor" ContentsCss="../../Presentation/includes/css/contents.css" Height="127px" ResizeEnabled="False" TemplatesFiles="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor/plugins/templates/templates/default.js" Toolbar="Basic" 
                     ToolbarBasic="Bold|Italic|-|NumberedList|BulletedList|-|Link|Unlink|-|About" UIColor="#CC99FF" BasicEntities="True"></CKEditor:CKEditorControl><asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="NewMessage" ControlToValidate="CKEditorControl1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />
                <div><asp:Button Text="Send Message"  UseSubmitBehavior="false" ID="btnSendNewMessage"  ValidationGroup="NewMessage"  OnClick="btnSendNewMessage_Click"  runat="server" /></div>
            </div>

            <asp:Panel ID="pnlTool" runat="server">

                <div id="left_pane" style="width:300px;height:615px; float:left;">
                    <div style="float:left;height:50px; width:100%;" ><span>
                        <asp:Literal ID="litInboxText" runat="server" /> (<asp:Literal Text="" ID="litMsgs" runat="server" />)</span> 

                        <input type="button" title="New Message" id="btn_new_message" value="New Message" runat="server" ClientIDMode="Static"  style="float:right;margin-right:20px;"  /> 

                    </div>


                        <asp:ListView   OnSelectedIndexChanging="lvLastMessages_SelectedIndexChanging"   OnSelectedIndexChanged="lvLastMessages_SelectedIndexChanged" ID="lvLastMessages"  runat="server">


                            <LayoutTemplate >
                                <div style="margin-top:10px;width:100%;height:100%; overflow-y:scroll;" id="contact_messages">

                                     <div runat="server" id="itemPlaceholder"></div>

                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfConvID" Value='<%# Eval("ConversationID") %>' runat="server" />
                                 <asp:Panel id="bkDiv" runat="server"  style="width:100%;height:60px">
                                    <div style="float:left;" id="avatarImg">
                                        <asp:ImageButton  CommandName="Select" runat="server" ID="imgBtn1"   style="height:30px;width:30px;" ImageUrl='<%# Eval("AuthorAvatar") %>' AlternateText ='<%# Eval("AuthorName")%>' />

                                    </div>
                                    <div>
                                        <span><%# Eval("Subject") %></span><br />
                                        <span><%# Eval("HowLong") %></span>
                                    </div>
                                  </asp:Panel>
                            </ItemTemplate>

                            <AlternatingItemTemplate>
                                 <asp:HiddenField ID="hfConvID" Value='<%# Eval("ConversationID") %>' runat="server" />
                                 <asp:Panel  id="bkDiv" runat="server"  style="width:100%;height:60px;background-color:ButtonFace">
                                    <div style="float:left;" id="avatarImg">
                                         <asp:ImageButton ID="imgBtn1" CommandName="Select"  runat="server"   style="height:30px;width:30px;" ImageUrl='<%# Eval("AuthorAvatar") %>' AlternateText ='<%# Eval("AuthorName")%>' />

                                    </div>
                                    <div>
                                        <span><%# Eval("Subject") %></span><br />
                                        <span><%# Eval("HowLong") %></span>
                                    </div>
                                </asp:Panel>
                            </AlternatingItemTemplate>

                            <SelectedItemTemplate>
                                   <asp:HiddenField ID="hfConvID" Value='<%# Eval("ConversationID") %>' runat="server" />
                                 <div runat="server" style="width:100%;height:60px;background-color:lightblue">
                                    <div style="float:left;" id="avatarImg">
                                        <asp:ImageButton ID="imgBtn1" CommandName="Select"  runat="server"   style="height:30px;width:30px;" ImageUrl='<%# Eval("AuthorAvatar") %>' AlternateText ='<%# Eval("AuthorName")%>' />

                                    </div>
                                    <div>
                                        <span><%# Eval("Subject") %></span><br />
                                        <span><%# Eval("HowLong") %></span>
                                    </div>
                                </div>

                            </SelectedItemTemplate>
                        </asp:ListView>


                </div>

                <div id="right_pane" style="height:455px; float:right;width:580px;">
                   <div style="top:0px;clear:both;height:50px;" > <span><asp:Label ID="lblName" Text="" runat="server"></asp:Label> 
                    <asp:Button Text="Delete"  ID="btnDelete" OnClientClick="javascript:return confirm('<%= DeleteConversationMessage %>');" OnClick="btnDelete_Click" style="float:right;padding-right:5px;" runat="server" /></span>

                    </div>
                    <div id="messages_view" style="height:350px;overflow-y:scroll;" >
                        <asp:Repeater ID="rptMessages" runat="server">
                            <ItemTemplate>
                                 <div id="Div1"  runat="server"  style="width:100%;min-height:60px;margin:auto;border-bottom-color:lightgrey;border-bottom-style:solid">
                                    <div style="float:left;" id="avatarImg">
                                        <asp:Image  runat="server" ID="imgBtn1"   style="height:30px;width:30px;" ImageUrl='<%# Eval("AuthorAvatar") %>' AlternateText ='<%# Eval("AuthorName")%>' />

                                    </div>
                                     <div style="float:right;"><span><%# Eval("Time") %></span></div>
                                    <div>
                                       <h1> <span><%# Eval("AuthorName") %></span></h1><br />
                                        <span><%# Eval("Body") %></span>
                                    </div>
                                  </div>
                                <div style="clear:both;padding-top:10px;"></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div >
                    <div style="bottom:0px;">
                        <CKEditor:CKEditorControl ID="CKEditor1"  runat="server"  BasePath="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor" ContentsCss="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor/contents.css" Height="127px" ResizeEnabled="False" TemplatesFiles="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor/plugins/templates/templates/default.js" Toolbar="Basic"
                          ToolbarBasic="Bold|Italic|-|NumberedList|BulletedList|-|Link|Unlink|-|About" UIColor="#CC99FF"></CKEditor:CKEditorControl>

                   
                    </div>
                    <asp:Button Text="Submit Reply" ID="btnReply" runat="server"  OnClick="btnReply_Click" />
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

