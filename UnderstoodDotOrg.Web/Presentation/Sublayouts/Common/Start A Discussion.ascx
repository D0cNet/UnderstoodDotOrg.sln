<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Start A Discussion.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Start_A_Discussion" %>
<script type="text/javascript">
    function checkValidation() {
        if (!Page_ClientValidate('<%= validation_group %>')) {
            return false;
        }
        
    }

    function loadDialog() {
        var dlg = $(".modal_discussion").dialog({
            autoOpen: false,
            height: 750,
            width: 600,
            modal: true,
            resizable: false,
            scrollable: false,
            buttons: {

                Cancel: function () {
                    $(this).dialog("close");
                }
            },
            appendTo: "form"


        });
    }
    var InitialDropDownText = '<%= InitialDropDownText %>';
    var InitialTextboxText = '<%= InitialTextBoxText %>';
    jQuery(document).ready(function () {
        loadDialog();

        jQuery("#btn_start_discussion").click(
             function () {
                 // jQuery(".modal_discussion").toggle();
                 //  return false;
                 //alert("Discussion button clicked");
                 $(".modal_discussion").dialog("open");
                 return false;
             });


        jQuery("a").click(
            function (evt) {
                if (jQuery(this).attr("href").indexOf("REPLACE") > -1) {

                    alert("Link not implemented!");
                    return false;

                }
            });

        jQuery("input:radio[name*='forum_name']").click(
            function () {
                var txtfnameValidator = document.getElementById("<%=rqdFname.ClientID%>");
                var ddlfnameValidator = document.getElementById("<%=rqdDropDownFName.ClientID%>");
                var ddlist = jQuery("#<%=ddlForums.ClientID%>");
                var txtname = jQuery("#<%=txtFName.ClientID%>");
                if (jQuery(this).val() == 'rqdDropDownFName') {


                    txtname.val("").text(InitialTextboxText);
                    txtname.prop("disabled", true);
                    ddlist.prop("disabled", false);
                    txtfnameValidator.enabled = false;
                    ddlfnameValidator.enabled = true;

                }
                else {

                    $('#<%=ddlForums.ClientID%> option:eq(0)').prop("selected", true);
                    $('.selected span').first().text(InitialDropDownText);
                    // $("#dropDownSelect option[text=" + myText + "]").prop("selected", true);
                    ddlist.prop("disabled", true);
                    txtname.prop("disabled", false);
                    txtfnameValidator.enabled = true;
                    ddlfnameValidator.enabled = false;

                }

            });
    });
</script>

 <div class="col-6 start-discussion">
<p>Got a question?</p>
<p class="want-to-talk">Want to talk?</p>
<a href=""   id="btn_start_discussion"  class="button">Start a Discussion</a>
</div><!-- end .start-discussion -->

<div class="modal_discussion" title="Start a Discussion" runat="server" id="modal_discussion" style="display:none;clear:both;overflow:hidden">
                 <asp:Label Text="" CssClass="error" ID="error_msg"  ForeColor="Red" Visible="false" runat="server" />
                  <asp:Panel ID="Panel1" GroupingText="Name" runat="server"> 
                  
                  <input type="radio"  id="rbddlFname" name="forum_name"  runat="server" value="rqdDropDownFName">
                     <p id="forumSelect" runat="server">
                        <%--   <asp:RadioButton ID="rbddlFname" AutoPostBack="true" OnCheckedChanged="rbddlFname_CheckedChanged" GroupName="forum_name" runat="server" />--%>
                         <asp:DropDownList DataTextField="Name" AppendDataBoundItems="true"    DataValueField="ForumID" ID="ddlForums"  runat="server">
                           <%--  <asp:ListItem Text="<%= InitialDropDownText %>" Value="0" ></asp:ListItem>--%>
                         </asp:DropDownList> 
                         <asp:RequiredFieldValidator ID="rqdDropDownFName"  ControlToValidate="ddlForums" InitialValue="0" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                     </p>
                  </input>
               
               
                <input type="radio" id="rbtxtFname" name="forum_name" runat="server" value="rqdFname">
                    <p runat="server" id="forumName" >
                    <%-- <asp:RadioButton ID="rbtxtFname" AutoPostBack="true" OnCheckedChanged="rbtxtFname_CheckedChanged" GroupName="forum_name" runat="server" />--%>
                        <%--<asp:Label ID="lblFName"  runat="server" Text="Name:" />--%>
                    <asp:TextBox ID="txtFName"    runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqdFname"  ControlToValidate="txtFName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />

                    </p>
                 </input>
                 
                 </asp:Panel>  
                 <p>
                <asp:Label ID="lblSubject"  runat="server" Text="Subject:" />
                <asp:TextBox ID="txtSubject"   runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqdSubject" ControlToValidate="txtSubject" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />
                </p>
                 <p>
                <asp:Label ID="lblBody" runat="server"  Text="Body:" />
                <asp:TextBox ID="txtBody"  runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator  ID="rqdDiscussion" ControlToValidate="txtBody" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />
                </p>
                 <p>
                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="button" OnClientClick="javascript:return checkValidation();" ClientIDMode="Static"  runat="server" Text="Create" />
                
                 </p>
                
            </div>