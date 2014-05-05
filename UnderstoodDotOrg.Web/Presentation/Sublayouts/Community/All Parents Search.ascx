<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="All Parents Search.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.All_Parents_Search" %>

 <div class="container community-parents">
        <div class="row">
            <div class="col col-24 skiplink-toolbar">
                <h2 class="offset-1">All Parents</h2>
                <a href="REPLACE" class="link-recommended">Just show parents like me</a>

                <div class="options-search">
                    <div class="container-parents-search-zip">
                       <%-- <label for="parents-search-zip" class="label-text">Enter Zip Code:</label>
                        <input name="parents-search-zip" id="parents-search-zip" placeholder="Zip Code" type="text" aria-required="true" />--%>
                        <asp:TextBox ID="txtZipCode" TextMode="Number" MaxLength="5" runat="server" name="parents-search-zip" CssClass="label-text" placeholder="Zip Code"></asp:TextBox>
                    </div>
                    <div class="container-parents-search-distance">
                        <label for="parents-search-distance" class="label-slider">Miles within zip code:</label>
                        <div id="parents-search-distance-slider"></div>
                        <input type="hidden" name="parents-search-distance" id="parents-search-distance" data-start-low="0" data-start-high="20"
                        data-values="0,5,10,15,20,25,30,35,40,45,50" data-labels="0,5,10,15,20,25,30,35,40,45,50+" />
                    </div>
                    <div class="container-parents-search-grade">
                        <label class="label-slider" for="parents-search-grade">Grade range:</label>
                        <div id="parents-search-grade-slider"></div>
                        <input type="hidden" name="parents-search-grade" id="parents-search-grade" data-collision="2" data-start-low="prek" data-start-high="8" data-values="prek,1,2,3,4,5,6,7,8,9,10,11,12,adult" data-labels="Pre-K,Grade 1,Grade 2,Grade 3,Grade 4,Grade 5,Grade 6,Grade 7,Grade 8,Grade 9,Grade 10,Grade 11,Grade 12,Adult"/>
                    </div>
                    <asp:DropDownList name="parents-search-issue"  AppendDataBoundItems="true" DataTextField="Name" DataValueField="Id" ID="ddlChildIssues" aria-required="true" runat="server">
                        <asp:ListItem  Value=""  >Child's Issue</asp:ListItem>
                       
                    </asp:DropDownList>
   
                   
                      
                         <asp:DropDownList name="parents-search-topic" DataTextField="Name" AppendDataBoundItems="true" DataValueField="Id" ID="ddlTopics" aria-required="true" runat="server">
                        <asp:ListItem Value="">Topic</asp:ListItem>
                       
                    </asp:DropDownList>
           
                  
                


                    <div class="checkboxes">
                        <div class="checkbox">
                            
                           <%-- <input type="checkbox" name="search-include-members" id="search-include-members" checked="checked" />
                            <label for="search-include-members" class="label-checkbox">Members</label>--%>
                            <asp:CheckBox runat="server" ID="memberChkbx" name="search-include-members" ClientIDMode="Static" CssClass="label-checkbox" Text="Members" Checked="true" />
                        </div>
                        <div class="checkbox">
                            <%--<input type="checkbox" name="search-include-moderators" id="search-include-moderators" checked="checked" />
                            <label for="search-include-moderators" class="label-checkbox">Moderators</label>--%>
                             <asp:CheckBox runat="server" ID="moderatorChkbx" ClientIDMode="Static" CssClass="label-checkbox" Text="Moderators"  Checked="true" />
                        </div>
                        <div class="checkbox">
                            <%--<input type="checkbox" name="search-include-experts" id="search-include-experts" checked="checked" />
                            <label for="search-include-experts" class="label-checkbox">Experts</label>--%>
                             <asp:CheckBox runat="server" ID="expertChkbx" ClientIDMode="Static" CssClass="label-checkbox" Text="Experts"  Checked="true" />
                        </div>
                    </div>
                    <asp:Button CssClass="button"  Text="Search" OnClick="btnSearch_Click" runat="server" ID="btnSearch" />
                 <%--   <button class="button">Search</button>--%>

                </div>

                <div class="col col-24 parents-member-cards skiplink-content" aria-role="main">
                   <%-- <sc:PlaceHolder key="Sub_Content" runat="server"></sc:PlaceHolder>--%>
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
                                        <div class="member-card-name hyphenate Moderator">
                
                                            <a href="REPLACE" class="name-member"><asp:Literal Text="" ID="UserName" runat="server" /></a>
                                            <p class="location"><asp:Literal Text="" ID="UserLocation" runat="server" /></p>
                
                                        </div><!-- end .member-card-name -->
            
                                        <div class="card-buttons member">
                
                                            <button type="button" class="button">Connect</button>
                
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
                </div>

              <!-- Show More -->
              <!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more">
  <div class="row">
    <div class="col col-24">
      <a class="show-more-link " href="#" data-path="community/member-cards" data-container="parents-member-cards" data-item="member-card" data-count="20">Show More<i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
              <!-- .show-more -->
                
            </div>
        </div>
    </div>
