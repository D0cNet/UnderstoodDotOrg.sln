﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Group Boards.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Group_Boards" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<script type="text/javascript" language="javascript">
    
    jQuery(document).ready(function () {
       
      
       
        jQuery(".col col-11 links:last").addClass("additional-links");
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
              <h3>
                  <asp:Literal ID="litjumpToText" runat="server" /></h3>
                <asp:HiddenField ID="hdSelectText" runat="server" />
      
                <asp:ListView GroupItemCount="3" OnItemDataBound="lvJumpto_ItemDataBound"  GroupPlaceholderID="groupPlaceholder" ItemPlaceholderID="itemPlaceholder"  ID="lvJumpto" runat="server">
                    <LayoutTemplate>
                       
                            <a runat="server" id="groupPlaceholder"></a>
                      
                    </LayoutTemplate>
                    <GroupTemplate>
                         <div class="col col-11 links">
                            <a runat="server" id="itemPlaceholder"></a>
                         </div>
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
         
              <sc:Sublayout ID="sblStartDiscussion" Path="~/Presentation/Sublayouts/Common/Start A Discussion.ascx" runat="server" />
              <!-- end .start-discussion -->
          </div>
        </div><!-- end .discussion-board -->
       
    <!-- END PARTIAL: community/groups_start_discussion -->
        </div>

        <div class="skiplink-content">
       
                <asp:Repeater ID="rptForums"  OnItemDataBound="rptForums_ItemDataBound" runat="server">
                   
                    <ItemTemplate>
                          <div class="row">
	                        <div class="col col-23 individual-group rs_read_this" aria-role="main">
                                <header class="offset-1">
			                        <h3><%# Eval("Name") %></h3>
			                        <a href="" id="hrefStartDiscussion" onclick="openWindow('<%# Eval("Name") %>'); return false;" class="rs_skip start-discussion">
                                        <asp:Literal ID="litstartDiscussion" runat="server" /></a>
		                        </header>
		                        <div>
			                    <div class="discussion-box col col-23 offset-1">
				                    <div class="wrapper">
					                    <header class="rs_skip">
						                    <h4 class="col summary"><asp:Literal ID="litDiscussionLabel" runat ="server"></asp:Literal></h4>
						                    <h4 class="col replies">
                                                <asp:Literal ID="litRepliesLabel" runat="server" /></h4>
						                    <h4 class="col latest-post"> <asp:Literal ID="litLatestPostLabel" runat="server" /></h4>
					                    </header>
                                        <asp:Repeater ID="rptThreads" OnItemDataBound="rptThreads_ItemDataBound" runat="server">
                                            <HeaderTemplate>
                                                <ul class="discussions">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField Value='<%# Eval("ForumID") %>' runat="server" ID="forumId"/>
                                                <asp:HiddenField Value='<%# Eval("ThreadID") %>' runat="server" ID="threadId"/>
                                                <li>
							                        <div class="col summary">
								                        <a href="REPLACE" id="hrefDiscussion" runat="server">
									                        <h4 class="visuallyhidden">
                                                                <asp:Literal ID="litDiscussionLabel" runat="server" /> </h4>
                                                            <%# Eval("Subject") %>

								                        </a>
							                        </div>
							                        <div class="col replies">
								                        <h4><asp:Literal ID="litRepliesLabel" runat="server" /></h4>
								                        <p><%# Eval("ReplyCount") %></p>
							                        </div>
							                        <div class="col latest-post">
								                        <h4><asp:Literal ID="litLatestPostLabel" runat="server" /></h4>
								                        <p><%# Eval("LastPostTime") %></p>
								                        <a href="REPLACE" id="hrefLastPostUser" runat="server"><%#Eval("LastPostUser") %></a>
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
					                    <a href="REPLACE"  id="hrefForumLink" runat="server" class="button rs_skip">
                                            <asp:Literal runat="server" ID="litViewAll" /></a>
				                    </footer>
			                    </div>
		                    </div>
                            </div>
                        </div>
                    </ItemTemplate>
  
                </asp:Repeater>
	
	    
        </div>
    </asp:Panel>
   <asp:Panel ID="pnlSearchSection" runat="server"> 
      <%--  <sc:Placeholder ID="searchResults" runat="server" />--%>
         <sc:Sublayout ID="sbSearchResults" runat="server" Path="~/Presentation/SubLayouts/Community/Parent Group Search Result.ascx" />
   </asp:Panel>
   
       <!-- Show More -->
    <!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<%--<div class="container show-more rs_skip">
  <div class="row">
    <div class="col col-24">
      <a class="show-more-link " href="#" data-path="community/group-summary" data-container="group-summary-container" data-item="row" data-count="6">Show More<i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div>--%>
    <!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->
  </div>
