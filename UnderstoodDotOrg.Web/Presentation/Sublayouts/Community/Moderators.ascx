<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Moderators.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Moderators" %>
    

<asp:Repeater ID="rptMemberCards"  runat="server">
       
        <ItemTemplate  >
        <div class="member-card-container">
            <div class="col member-card">
                <div class="member-card-info group">
                    <div class="member-card-image">
                        <a href="REPLACE">
                            <%--<img alt="150x150 Placeholder" src="http://placehold.it/150x150" />--%>
                            <asp:Image ImageUrl="#" Width="126px" Height="126px" ID="UserAvatar" runat="server" />
                            <div class="image-label" runat="server" id="lblImg" visible="false">
                                <asp:Literal Text="" ID="UserLabel" runat="server" /></div>
                        </a>
                    </div><!-- end .member-card-image -->
                    <div class="member-card-name hyphenate Moderator">
                
                        <a href="REPLACE" class="name-member"><asp:Literal Text="" ID="UserName" runat="server" /></a>
                        <p class="location"><asp:Literal Text="" ID="UserLocation" runat="server" /></p>
                
                    </div><!-- end .member-card-name -->
            
                    <div class="card-buttons member">
                
                        <button type="button" class="button">Connect</button>
                
                    </div><!-- end .member.card-buttons -->
            
                </div><!-- end .member-card-info -->  
                    <div class="member-card-specialties">
                        
                        <asp:Repeater runat="server">
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
                                         <asp:Repeater ID="rptChildIssues" runat="server" >
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
            </div><!-- end .member-card -->
        </div>
        </ItemTemplate>

</asp:Repeater>
