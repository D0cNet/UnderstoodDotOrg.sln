<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyFriends.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.MyFriends" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="divFriends" class="community-members" runat="server">
    <div class="row">
        <div class="col col-24 community-members-wrapper">
            <h2 class="rs_read_this">My Friends</h2>
            <div class="carousel-arrow-wrapper">
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows members next-prev-menu arrows-gray">

                    <a class="view-all" href="REPLACE">See all members</a>

                    <div id="arrowLeft" class="rsArrow rsArrowLeft" runat="server">
                        <button class="rsArrowIcn"></button>
                    </div>
                    <div id="arrowRight" class="rsArrow rsArrowRight" runat="server">
                        <button class="rsArrowIcn"></button>
                    </div>
                </div>
                <!-- end .arrows -->
                <!-- END PARTIAL: community/carousel_arrows -->
            </div>
            <div class="row member-cards">
                <asp:Repeater ID="rptFriends" runat="server"
                    ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.User"
                    OnItemDataBound="rptFriends_ItemDataBound">
                    <ItemTemplate>
                <!-- BEGIN PARTIAL: community/member_card -->
                <div class="member-card-container">
                    <div class="rs_read_this col member-card">
                        <div class="member-card-info group">
                            <div class="member-card-image">
                                <%--<asp:HyperLink ID="hypUserAvatar" CssClass="name-member" runat="server">--%>
                                    <asp:Image ID="imgUserAvatar" AlternateText="150x150 Placeholder" ImageUrl="<%# Item.AvatarUrl %>" runat="server" />
                                <%--</asp:HyperLink>--%>
                            </div>
                            <!-- end .member-card-image -->
                            <div class="member-card-name hyphenate member">

                                <asp:HyperLink ID="hypUserProfileLink" CssClass="name-member" runat="server"><%# Item.Username %></asp:HyperLink>
                                <p class="location"><%# Item.DisplayName %></p>

                            </div>
                            <!-- end .member-card-name -->

                            <div class="card-buttons member">

                                <button type="button" class="button blue rs_skip">See Activity</button>

                            </div>
                            <!-- end .member.card-buttons -->

                        </div>
                        <!-- end .member-card-info -->
                        <div class="member-card-specialties">
                            <ul>
                                <span class="visuallyhidden">grade level</span>
                                <li class='specialty-long'><a href='REPLACE'>PreK</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                    <div class="card-child-info popover rs_skip">
                                        <div class="popover-content">
                                            <span class="caret"></span>
                                            <h3>PreK,
            Girl
                                            </h3>
                                            <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                            <div class="arrows child-info-next-prev-menu arrows-gray">

                                                <div class="rsArrow rsArrowLeft">
                                                    <button class="rsArrowIcn"></button>
                                                </div>
                                                <div class="rsArrow rsArrowRight">
                                                    <button class="rsArrowIcn"></button>
                                                </div>
                                            </div>
                                            <!-- end .arrows -->
                                            <!-- END PARTIAL: community/carousel_arrows -->
                                            <ul>
                                                <li>Nobis Ex</li>
                                                <li>Aut Recusandae</li>
                                                <li>Magnam Porro</li>
                                                <li>Asperiores Ipsum</li>
                                            </ul>
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
                            </ul>
                        </div>
                    </div>
                    <!-- end .member-card -->
                </div>
                <!-- end .member-card-container  -->
                <!-- END PARTIAL: community/member_card -->
                        </ItemTemplate>
                    </asp:Repeater>
            </div>
            <!-- end .member-cards -->
        </div>
        <!-- end .col.col-24.container -->
    </div>
    <!-- end .row -->
</div>
<!-- end .community-members -->
