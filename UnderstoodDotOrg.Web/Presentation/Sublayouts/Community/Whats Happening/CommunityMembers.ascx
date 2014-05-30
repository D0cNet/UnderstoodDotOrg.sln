<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommunityMembers.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.CommunityMembers" %>
<div class="community-members">
    <div class="row">
        <div class="col col-24 community-members-wrapper">
            <h2 class="rs_read_this">Community Moderators</h2>
            <div class="carousel-arrow-wrapper">
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows members next-prev-menu arrows-gray">

                    <a class="view-all" href="REPLACE">See all moderators</a>

                    <div class="rsArrow rsArrowLeft">
                        <button class="rsArrowIcn"></button>
                    </div>
                    <div class="rsArrow rsArrowRight">
                        <button class="rsArrowIcn"></button>
                    </div>
                </div>
                <!-- end .arrows -->
                <!-- END PARTIAL: community/carousel_arrows -->
            </div>
            <div class="row member-cards">
                <asp:Repeater ID="rptModerators" runat="server"
                     ItemType="UnderstoodDotOrg.Domain.Understood.Common.MemberCardModel">
                    <ItemTemplate>
                        <!-- BEGIN PARTIAL: community/member_card -->
                        <div class="member-card-container">
                            <div class="rs_read_this col member-card">
                                <div class="member-card-info group">
                                    <div class="member-card-image">
                                        <a href="REPLACE">
                                            <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                            <div class="image-label">Moderator</div>
                                        </a>
                                    </div>
                                    <!-- end .member-card-image -->
                                    <div class="member-card-name hyphenate Moderator">

                                        <a href="REPLACE" class="name-member"><%# Item.UserName %></a>
                                        <p class="location"><%# Item.UserLocation %></p>

                                    </div>
                                    <!-- end .member-card-name -->

                                    <div class="card-buttons member">

                                        <button type="button" class="button rs_skip">Connect</button>

                                    </div>
                                    <!-- end .member.card-buttons -->

                                </div>
                                <!-- end .member-card-info -->
                                <div class="member-card-specialties">
                                    <ul>
                                        <span class="visuallyhidden">grade level/span>
                <li class='specialty-long'><a href='REPLACE'>PreK</a><!-- BEGIN PARTIAL: community/child_info_card -->

                    <div class="card-child-info popover rs_skip">
                        <div class="popover-content">
                            <span class="caret"></span>
                            <h3>PreK,
            Boy
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
                                <li>Inventore Quasi</li>
                                <li>Ea Consequatur</li>
                                <li>Et Aspernatur</li>
                                <li>Optio Consequatur</li>
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
