<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupDiscussionList.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.GroupDiscussionList" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ConnectButton.ascx" TagPrefix="uc1" TagName="ConnectButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ThanksButton.ascx" TagPrefix="uc1" TagName="ThanksButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ThinkingOfYouButton.ascx" TagPrefix="uc1" TagName="ThinkingOfYouButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/LikeButton.ascx" TagPrefix="uc1" TagName="LikeButton" %>




<asp:Repeater ID="rptDiscussionList" OnItemDataBound="rptDiscussionList_ItemDataBound"  runat="server">
    <HeaderTemplate>
     <div class="discussion-post clearfix rs_read_this">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col col-4 discussion-contributer">
            <div class="contributer-image">
                <img alt="150x150 Placeholder" src="<%#Eval("Author.AvatarUrl") %>" />

            </div>
                <a class="name" runat="server" id="hrefName" href="REPLACE"><%#Eval("AuthorName") %></a>
                <p class="location"><%#Eval("Author.UserLocation") %></p>
               <%-- <a href="REPLACE" class="button rs_skip">Connect</a>--%>
            <uc1:ConnectButton runat="server" ID="btnConnect" />
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
                    <uc1:ThanksButton runat="server" ID="ThanksButton" />
                    
                </li>
                <li>
                    <uc1:ThinkingOfYouButton runat="server" id="ThinkingOfYouButton" />
                </li>
                <li>
                    <uc1:LikeButton runat="server" id="LikeButton" />
                </li>
            </ul>
        </footer>
    </ItemTemplate>
    <FooterTemplate>
      </div>
    </FooterTemplate>
</asp:Repeater>      


                  
    
