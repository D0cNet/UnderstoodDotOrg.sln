<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupDiscussionList.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.GroupDiscussionList" %>
<asp:Repeater ID="rptDiscussionList" OnItemDataBound="rptDiscussionList_ItemDataBound" runat="server">
    <HeaderTemplate>
     <div class="discussion-post clearfix rs_read_this">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col col-4 discussion-contributer">
            <div class="contributer-image">
                <img alt="150x150 Placeholder" src="<%#Eval("Author.AvatarUrl") %>" />

            </div>
                <a class="name" href="REPLACE"><%#Eval("AuthorName") %></a>
                <p class="location"><%#Eval("Author.UserLocation") %></p>
                <a href="REPLACE" class="button rs_skip">Connect</a>
            <div class="member-card-specialties parents-member-cards">
                <asp:Repeater ID="rptChildCard" OnItemDataBound="rptChildCard_ItemDataBound"  ClientIDMode="Static" runat="server">
                <HeaderTemplate>
                    <ul>
                    <span class="visuallyhidden">grade level</span>
                </HeaderTemplate>
                <ItemTemplate>
                    <li class='specialty '><!-- BEGIN PARTIAL: community/child_info_card -->
                    <span tabindex='0' data-tabbable='true'>
                        <%#Eval("Grade") %>th</span>
 
				    <div class="card-child-info popover">
					    <div class="popover-content">
							    <span class="caret"></span>
							    <h3>Grade <%#Eval("Grade") %>,
								    <%#Eval("Gender") %>
							    </h3>
							    <!-- BEGIN PARTIAL: community/carousel_arrows -->
							    <div class="arrows child-info-next-prev-menu arrows-gray">
									
								    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
								    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
							    </div><!-- end .arrows -->
								    <!-- END PARTIAL: community/carousel_arrows -->
                                <asp:Repeater ID="rptChildIssues"   ClientIDMode="Static" runat="server" >
                                    <HeaderTemplate>
                                        <ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li><%#Eval("IssueName") %></li>
                                    </ItemTemplate>
                                    <FooterTemplate></ul></FooterTemplate>
                                </asp:Repeater>
							    <%-- <ul>
								    <li>Illo Fuga</li>
								    <li>Voluptas Repudiandae</li>
								    <li>Nostrum Maiores</li>
								    <li>Temporibus Sit</li>
							    </ul>--%>
							    <div class="card-buttons">
								    <button class="button gray">View Profile</button>
								    <button class="button blue">See Activity</button>
							    </div>
					    </div>
				    </div>
				    <!-- END PARTIAL: community/child_info_card -->

                </li>

                <li class="specialty specialty-final">
                    <span class="visuallyhidden">additional information</span>
                    <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>

                </ItemTemplate>

                <FooterTemplate>
                    </ul>

                </FooterTemplate>
            </asp:Repeater>
                      
            </div>
            </div>
        <div class="discussion-comment">
            <p><%# Eval("Body") %></p>
        </div>
        <footer class="discussion-footer rs_skip">
            <h4>Show your support</h4>
            <ul class="support-menu">
                <li>
                <button class="thanks">
                    <i class="smiley-icon"></i>
                    <p>Thanks</p>
                </button>
                </li>
                <li>
                <button class="thinking-of-you">
                    <i class="flower-icon"></i>
                    <p>Thinking of You</p>
                </button>
                </li>
                <li>
                <button class="likes">
                    <i class="thumbs-up-icon"></i>
                    <p>15</p>
                </button>
                </li>
            </ul>
        </footer>
    </ItemTemplate>
    <FooterTemplate>
      </div>
    </FooterTemplate>
</asp:Repeater>      


                  
    
