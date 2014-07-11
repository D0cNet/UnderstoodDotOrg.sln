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
   
    jQuery(document).ready(function () {
        loadDialog();
       
      
        jQuery("#btn_start_discussion").click(
             function () {
                
                 var InitialDropDownText = '<%= InitialDropDownText %>';
                 var InitialTextboxText = '<%= InitialTextBoxText %>';
                 
                 var ddlfnameValidator = jQuery("#<%=rqdDropDownFName.ClientID%>");
                 var ddlist = $("#<%=ddlForums.ClientID%>");
                 var txtname = jQuery("#<%=txtFName.ClientID%>");
            
                 ddlfnameValidator.enabled = true;
                 jQuery(ddlist).show();
                 jQuery('.selected span').show();
                 jQuery('.selected').show();
                 jQuery("#forumSelect").show();
                 ddlist.prop("disabled", false);
                 if (ddlist.css("display") == "inline-block" || ddlist.css("display") == "block")
                     txtname.hide();
                 else
                    txtname.show();
                 jQuery(".modal_discussion").dialog("open");
                 return false;
             });

        
          
        jQuery("a").click(
            function (evt) {
                if (jQuery(this).attr("href").indexOf("REPLACE") > -1) {

                    alert("Link not implemented!");
                    return false;

                }
            });

        
    });
</script>

 <div class="col-6 start-discussion">
<p>
    <asp:Literal ID="litGotAQuestionLabel" runat="server" /></p>
<p class="want-to-talk">
    <asp:Literal ID="litWantToTalkLabel" runat="server" /></p>
<a href=""   id="btn_start_discussion"  class="button">
    <asp:Literal ID="litStartADiscussionLabel" runat="server" /></a>
</div><!-- end .start-discussion -->
<asp:HiddenField ID="hdSelectedText" runat="server" />
<div class="modal_discussion" title="Start a Discussion" runat="server" id="modal_discussion" style="display:none;clear:both;overflow:hidden">
                 <asp:Label Text="" CssClass="error" ID="error_msg"  ForeColor="Red" Visible="false" runat="server" />
                  <asp:Panel ID="Panel1" GroupingText="Name" runat="server"> 
                  
                 <%-- <input type="radio"  id="rbddlFname" name="forum_name"  runat="server" value="rqdDropDownFName">--%>
                     <div id="forumSelect" >
                        <%--   <asp:RadioButton ID="rbddlFname" AutoPostBack="true" OnCheckedChanged="rbddlFname_CheckedChanged" GroupName="forum_name" runat="server" />--%>
                         <asp:DropDownList DataTextField="Name" AppendDataBoundItems="true"    DataValueField="ForumID" ID="ddlForums"  runat="server">
                           <%--  <asp:ListItem Text="<%= InitialDropDownText %>" Value="0" ></asp:ListItem>--%>
                         </asp:DropDownList> 
                         <asp:RequiredFieldValidator ID="rqdDropDownFName"  ControlToValidate="ddlForums" InitialValue="0" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                     </div>
                 <%-- </input>--%>
               
               
               <%-- <input type="radio" id="rbtxtFname" name="forum_name" runat="server" value="rqdFname">--%>
                    <div  id="forumName" >
                    <%-- <asp:RadioButton ID="rbtxtFname" AutoPostBack="true" OnCheckedChanged="rbtxtFname_CheckedChanged" GroupName="forum_name" runat="server" />--%>
                        <%--<asp:Label ID="lblFName"  runat="server" Text="Name:" />--%>
                    <asp:TextBox ID="txtFName"    runat="server"></asp:TextBox>
                   <%-- <asp:RequiredFieldValidator ID="rqdFname"  ControlToValidate="txtFName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />--%>

                    </div>
            <%--     </input>--%>
                 
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