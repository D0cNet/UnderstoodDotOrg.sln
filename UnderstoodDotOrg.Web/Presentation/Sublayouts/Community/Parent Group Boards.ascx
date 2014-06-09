<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Group Boards.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Group_Boards" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<script type="text/javascript">
    function checkValidation() {
        if (!Page_ClientValidate('<%= validation_group %>')) {
            return false;
        }
        else {
            return confirm('<%= confirmationMessage %>');
        }
    }

    jQuery(document).ready(function () {


        jQuery("#btn_start_discussion").click(
             function () {
                 jQuery(".modal_discussion").toggle();
                 return false;
                 //alert("Discussion button clicked");
             });
        jQuery("a").click(
            function (evt) {
                if (jQuery(this).attr("href").indexOf("REPLACE") >-1)  {
               
                        alert("Link not implemented!");
                        return false;
               
                }
            });

        jQuery('input:radio[name=forum_name]').click(
            function () {
                var txtfnameValidator = document.getElementById("<%=rqdFname.ClientID%>");
                var ddlfnameValidator = document.getElementById("<%=rqdDropDownFName.ClientID%>");
                var ddlist = jQuery("#<%=ddlForums.ClientID%>");
                var txtname = jQuery("#<%=txtFName.ClientID%>");
                if (jQuery(this).val() == 'rqdDropDownFName') {
                   
                  
                    txtname.val("");
                    txtname.prop("disabled", true);
                    ddlist.prop("disabled", false);
                    txtfnameValidator.enabled = false;
                    ddlfnameValidator.enabled = true;
                    
                }
                else {
                   
                
                    ddlist.val("");
                    ddlist.prop("disabled", true);
                    txtname.prop("disabled", false);
                    txtfnameValidator.enabled = true;
                    ddlfnameValidator.enabled = false;
                  
                }

            });
    });
</script>
<div class="container">
    <!-- BEGIN PARTIAL: community/featured_group -->
<!--featured group header -->
<sc:Sublayout ID="sbGroupModelHeader"  Path="~/Presentation/SubLayouts/Common/GroupCardModelView.ascx" runat="server" />
<!-- END PARTIAL: community/featured_group -->
    <asp:Panel ID="pnlDefaultSection" runat="server">
        <div class="row">
          <!-- BEGIN PARTIAL: community/groups_start_discussion -->
    <!--discussion board-->

        <div class="col col-24 jump-to">
          <div class="rs_read_this discussion-board-rs-wrapper">
            <div class="col-16 discussion-boards  offset-1 skiplink-toolbar">
              <h3>Jump to</h3>

      
                <asp:ListView GroupItemCount="3" OnItemDataBound="lvJumpto_ItemDataBound"  ID="lvJumpto" runat="server">
                    <LayoutTemplate>
                        <div class="col col-11 links">
                            <a runat="server" id="groupPlaceholder"></a>
                        </div>
                    </LayoutTemplate>
                    <GroupTemplate>
                         <a runat="server" id="itemPlaceholder"></a>
                    </GroupTemplate>
                    <ItemTemplate>
                       <%--  <asp:HiddenField Value='<%# Eval("ID") %>' runat="server" ID="hdSubject"/>--%>
                         <a href="REPLACE" runat="server" id="hrefForum" ><%# Eval("Name") %></a>
                    </ItemTemplate>
                
                </asp:ListView>
      
              <%--<div class="col col-11 links">
                <a href="REPLACE">Title of Discussion Board</a>
                <a href="REPLACE">Title of Discussion Board</a>
                <a href="REPLACE">Title of Discussion Board</a>
              </div><!-- end .links -->
              <div class="col col-11 links additional-links">
                <a href="REPLACE">Title of Discussion Board</a>
                <a href="REPLACE">Title of Discussion Board</a>
                <a href="REPLACE">Title of Discussion Board</a>
              </div><!-- end .links and .additional-links -->--%>
      

            </div><!-- end .discussion-boards -->
            <div class="col-6 start-discussion">
            <p>Got a question?</p>
            <p class="want-to-talk">Want to talk?</p>
            <a href=""   id="btn_start_discussion"  class="button">Start a Discussion</a>
          </div><!-- end .start-discussion -->
          </div>
        </div><!-- end .discussion-board -->
             <div class="modal_discussion" runat="server" id="modal_discussion" style="display:none;clear:both">
                 <asp:Panel GroupingText="Name" runat="server"> 
                   
                  <input type="radio"  id="rbddlFname" name="forum_name" value="rqdDropDownFName">
                     <p id="forumSelect" runat="server">
                        <%--   <asp:RadioButton ID="rbddlFname" AutoPostBack="true" OnCheckedChanged="rbddlFname_CheckedChanged" GroupName="forum_name" runat="server" />--%>
                         <asp:DropDownList DataTextField="Name" AppendDataBoundItems="true"    DataValueField="ForumID" ID="ddlForums"  runat="server">
                             <asp:ListItem Text="Select a Forum" Value="" />
                         </asp:DropDownList> 
                         <asp:RequiredFieldValidator ID="rqdDropDownFName" ControlToValidate="ddlForums" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                     </p>
                  </input>
               
               
                <input type="radio" id="rbtxtFname" name="forum_name" value="rqdFname">
                    <p runat="server" id="forumName" >
                    <%-- <asp:RadioButton ID="rbtxtFname" AutoPostBack="true" OnCheckedChanged="rbtxtFname_CheckedChanged" GroupName="forum_name" runat="server" />--%>
                        <%--<asp:Label ID="lblFName"  runat="server" Text="Name:" />--%>
                    <asp:TextBox ID="txtFName"  placeholder="Create a new Forum"    runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqdFname"  ControlToValidate="txtFName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />

                    </p>
                 </input>
                 <p>
                 </asp:Panel>  
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
                <asp:Label Text="" CssClass="error" ID="error_msg"  ForeColor="Red" Visible="false" runat="server" />
                 </p>
                
            </div>
    <!-- END PARTIAL: community/groups_start_discussion -->
        </div>

        <div class="skiplink-content">
         <div class="row">
	        <div class="col col-23 individual-group rs_read_this" aria-role="main">
                <asp:Repeater ID="rptForums"  OnItemDataBound="rptForums_ItemDataBound" runat="server">
         
                    <ItemTemplate>
                        <header class="offset-1">
			                <h3><%# Eval("Name") %></h3>
			                <%--<a href="REPLACE" class="rs_skip start-discussion">Start a Discussion</a>--%>
		                </header>
		                <div>
			                <div class="discussion-box col col-23 offset-1">
				                <div class="wrapper">
					                <header class="rs_skip">
						                <h4 class="col summary">Discussion</h4>
						                <h4 class="col replies">Replies</h4>
						                <h4 class="col latest-post">Latest Post</h4>
					                </header>
                                    <asp:Repeater ID="rptThreads" OnItemDataBound="rptThreads_ItemDataBound" runat="server">
                                        <HeaderTemplate>
                                            <ul class="discussions">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField Value='<%# Eval("Subject") %>' runat="server" ID="hdSubject"/>
                                            <li>
							                    <div class="col summary">
								                    <a href="REPLACE" id="hrefDiscussion" runat="server">
									                    <h4 class="visuallyhidden">Discussion</h4>
                                                        <%# Eval("Subject") %>

								                    </a>
							                    </div>
							                    <div class="col replies">
								                    <h4>Replies</h4>
								                    <p><%# Eval("ReplyCount") %></p>
							                    </div>
							                    <div class="col latest-post">
								                    <h4>Latest Post</h4>
								                    <p><%# Eval("LastPostTime") %></p>
								                    <a href="REPLACE"><%#Eval("LastPostUser") %></a>
							                    </div>
						                    </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                             </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
					        
					                <!-- end .discussions -->
				                </div>
				                <footer>
					                <a href="REPLACE" class="button rs_skip">View All</a>
				                </footer>
			                </div>
		                </div>

                    </ItemTemplate>
  
                </asp:Repeater>
	
	        </div>
         </div>
        </div>
    </asp:Panel>
   <asp:Panel ID="pnlSearchSection" runat="server"> 
      <%--  <sc:Placeholder ID="searchResults" runat="server" />--%>
         <sc:Sublayout ID="sbSearchResults" runat="server" Path="~/Presentation/SubLayouts/Community/Parent Group Search Result.ascx" />
   </asp:Panel>
   
       <!-- Show More -->
    <!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more rs_skip">
  <div class="row">
    <div class="col col-24">
      <a class="show-more-link " href="#" data-path="community/group-summary" data-container="group-summary-container" data-item="row" data-count="6">Show More<i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->
  </div>
