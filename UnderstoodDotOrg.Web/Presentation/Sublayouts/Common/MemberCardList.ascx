<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberCardList.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.MemberCardList" %>
<style type="text/css">
   .community-badges ul {
        margin: 0;
        padding: 0;
        list-style-type: none;
    }

       .community-badges ul li {
            display: inline;
        }

        .community-badges ul li a {
            text-decoration: none;
            padding: .2em 1em;
        }
</style>

<%-- Used another repeater because of dynamic datasourcing--%>
<asp:ListView ID="rptMemberCards" ClientIDMode="Static"  runat="server">
    <EmptyDataTemplate>
        <asp:Label  ID="txtEmpty" runat="server"></asp:Label>
    </EmptyDataTemplate>
                        
        <ItemTemplate  >
        <div class="member-card-container">
            <div class="col member-card">
                <div class="member-card-info group">
                    <div class="member-card-image">
                        <a href="REPLACE">
                            <%--<img alt="150x150 Placeholder" src="http://placehold.it/150x150" />--%>
                            <asp:Image ImageUrl="#" Width="126px" Height="126px" ID="UserAvatar" runat="server" />
                            <div class="image-label" id="lblImg" visible="false" runat="server">
                                <asp:Literal Text="" ID="UserLabel" runat="server" /></div>
                        </a>
                    </div><!-- end .member-card-image -->
                   <div class="community-badges">
                     <%--    <ul>
                            <li>
                                <img src="/Presentation/Includes/img/platinum.png"  width="20px" height="20px" alt="Alternate Text" />
                            </li>
                            <li>
                                <img src="/Presentation/Includes/img/platinum.png"  width="20px" height="20px" alt="Alternate Text" />
                            </li>
                        </ul>--%>
                        <asp:Repeater ID="rptrBadges" runat="server">
                            <HeaderTemplate><ul class="user-badges"></HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <asp:Image ImageUrl='<%# Eval("ImageUrl") %>' Width="20px" Height="20px" ID="imgBadgeIcon" AlternateText='<%# Eval("Name")%> ' runat="server" />
                                </li>
                            </ItemTemplate>
                            <FooterTemplate></ul></FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="member-card-name hyphenate Moderator">
                
                        <a href="REPLACE" class="name-member"><asp:Literal Text="" ID="UserName" runat="server" /></a>
                        <p class="location"><asp:Literal Text="" ID="UserLocation" runat="server" /></p>
                
                    </div><!-- end .member-card-name -->
            
                    <div class="card-buttons member">
                
                        <%--<button type="button" runat="server" class="button">Connect</button>--%>
                        <asp:Button Text="Connect" ID="btnConnect" CssClass="button" Visible="false"  runat="server" />
                
                    </div><!-- end .member.card-buttons -->
            
                </div><!-- end .member-card-info -->  
                <div class="member-card-specialties">
                        
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
                </div><!-- end .member-card -->
        </div>
        </ItemTemplate>

</asp:ListView>
