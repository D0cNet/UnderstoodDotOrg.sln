<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Group Boards.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Group_Boards" %>

<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<script type="text/javascript">
    function checkValidation() {
        if (!Page_ClientValidate("newDiscussion")) {
            return false;
        }
        else {
            return confirm('Items created by end user cannot be modified until published. Are you sure you want to create a thread?');
        }
    }

    jQuery(document).ready(function () {


        jQuery("#btn_start_discussion").click(
             function () {
                 jQuery(".modal_discussion").toggle();
                 //alert("Discussion button clicked");
             });
    });
</script>
<div class="container community-main-header ">
    <header>
        <div class="row header-wrapper">
            <div class="col col-14 offset-1 header-title rs_read_this">
                <h1>Welcome to the Understood Community</h1>
                <p class="subhead">A private parent community with expert guidance and support</p>
            </div>

            <div class="col col-9 header-share-save">
                <!-- BEGIN PARTIAL: share-save -->
<div class="share-save-container">
  <div class="share-save-social-icon">
  	<div class="toggle">
	    <a href="REPLACE" class="socicon icon-facebook">Facebook</a><br />
	    <a href="REPLACE" class="socicon icon-twitter">Twitter</a><br />
	    <a href="REPLACE" class="socicon icon-googleplus">Google&#43;</a><br />
	    <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
	</div>
  </div>
  <div class="share-save-icon">
    <h3>Share &amp; Save</h3>
    <!-- leave no white space for layout consistency -->
    <a href="REPLACE" class="icon icon-share">Share</a><span class="tools"><a href="REPLACE" class="icon icon-email">Email</a><a href="REPLACE" class="icon icon-save">Save</a><a href="REPLACE" class="icon icon-print">Print</a><a href="REPLACE" class="icon icon-remind">Remind</a><a href="REPLACE" class="icon icon-rss">RSS</a></span>
  </div>
</div>

<!-- END PARTIAL: share-save -->
            </div>
        </div>
    </header>
    <nav class="container nav-secondary">
        <div class="row">
            <div class="col col-24">
                <div class="label-menu"><span>Menu</span></div>
                <ul class="menu" aria-role="navigation" aria-label="secondary-navigation">
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    <li class="title">
                      <p class="select-topic">Select a topic:</p>
                      <button>Groups</button>
                      <i class="icon-hide-show-fff"></i>
                    </li>
                    
                    
                    
                    
                    <li class="submenu">
                        <div class="inner">
                            <div class="label-more"><button>More <i class="icon-hide-show-fff"></i></button></div>
                            <ul>
                                
                                
                                
                                <li><span><a href="REPLACE">What's Happening Now</a></span></li>
                                
                                
                                
                                
                                <li><span><a href="REPLACE">Experts Live</a></span></li>
                                
                                
                                
                                
                                <li><span><a href="REPLACE">Q&nbsp;&amp;&nbsp;A</a></span></li>
                                
                                
                                
                                
                                <li><span><a href="REPLACE">Parents Like Me</a></span></li>
                                
                                
                                
                                <li><span><a href="REPLACE" class="selected">Groups</a></span></li>
                                
                                
                                
                                
                                
                                <li><span><a href="REPLACE">Blogs</a></span></li>
                                
                                
                            </ul>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</div>
<div class="container">
    <!-- BEGIN PARTIAL: community/featured_group -->
<!--featured group header -->
<sc:Sublayout ID="sbGroupModelHeader"  Path="~/Presentation/SubLayouts/Common/GroupCardModelView.ascx" runat="server"></sc:Sublayout>
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
                         <asp:HiddenField Value='<%# Eval("Name") %>' runat="server" ID="hdSubject"/>
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
            <a href="REPLACE" id="btn_start_discussion"  class="button">Start a Discussion</a>
          </div><!-- end .start-discussion -->
          </div>
        </div><!-- end .discussion-board -->
             <div class="modal_discussion" runat="server" id="modal_discussion" style="display:none;clear:both">

                 <asp:DropDownList DataTextField="Name" AppendDataBoundItems="true" DataValueField="ForumID" ID="ddlForums"  runat="server">
                     <asp:ListItem Text="" Value=" " />
                 </asp:DropDownList>
            <asp:Label ID="lblSubject"  runat="server" Text="Subject:" />
            <asp:TextBox ID="txtSubject" ValidationGroup="newDiscussion"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqdSubject" ValidationGroup="newDiscussion" ControlToValidate="txtSubject" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />
            
            <asp:Label ID="lblBody" runat="server"  Text="Body:" />
            <asp:TextBox ID="txtBody" ValidationGroup="newDiscussion" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="newDiscussion" ID="rqdDiscussion" ControlToValidate="txtBody" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />
     
            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="button" OnClientClick="javascript:return checkValidation();" ClientIDMode="Static" ValidationGroup="newDiscussion" runat="server" Text="Create" />
            <asp:Label Text="" CssClass="error" ID="error_msg"  ForeColor="Red" Visible="false" runat="server" />

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
			                <a href="REPLACE" class="rs_skip start-discussion">Start a Discussion</a>
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
