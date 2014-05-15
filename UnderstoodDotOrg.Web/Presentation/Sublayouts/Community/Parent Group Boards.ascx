<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Group Boards.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Group_Boards" %>

<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

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

      

      
              <div class="col col-11 links">
                <a href="REPLACE">Title of Discussion Board</a>
                <a href="REPLACE">Title of Discussion Board</a>
                <a href="REPLACE">Title of Discussion Board</a>
              </div><!-- end .links -->
              <div class="col col-11 links additional-links">
                <a href="REPLACE">Title of Discussion Board</a>
                <a href="REPLACE">Title of Discussion Board</a>
                <a href="REPLACE">Title of Discussion Board</a>
              </div><!-- end .links and .additional-links -->
      

            </div><!-- end .discussion-boards -->
            <div class="col-6 start-discussion">
            <p>Got a question?</p>
            <p class="want-to-talk">Want to talk?</p>
            <a href="REPLACE" class="button">Start a Discussion</a>
          </div><!-- end .start-discussion -->
          </div>
        </div><!-- end .discussion-board -->
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
                                            <li>
							                    <div class="col summary">
								                    <a href="REPLACE">
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
