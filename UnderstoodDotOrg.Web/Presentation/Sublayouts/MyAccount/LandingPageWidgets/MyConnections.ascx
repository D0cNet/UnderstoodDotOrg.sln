<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyConnections.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets.MyConnections" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN PARTIAL: account-landing-my-connections -->
<div class="row">
    <div class="landing-modules my-connections">
        <header>
            <h3>My Connections<span class="landing-module-count"><asp:Label ID="ltFriendCount" runat="server" /></span></h3>
        </header>
        <section class="connections group" id="user_equal_heights">
            <div class="row member-cards">
                <asp:Repeater ID="rptFriends" runat="server"
                    ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.User"
                    OnItemDataBound="rptFriends_ItemDataBound">
                    <ItemTemplate>
                        <!-- BEGIN PARTIAL: community/member_card -->
                        <div class="member-card-container">
                            <div class="rs_read_this col member-card col-8">
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

                                </div>
                                <!-- end .member-card-info -->
                                <div class="member-card-specialties">
                                    <ul>
                                        <span class="visuallyhidden">grade level</span>
                                        <li class=''><a href='REPLACE'>9th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                            <div class="card-child-info popover rs_skip">
                                                <div class="popover-content">
                                                    <span class="caret"></span>
                                                    <h3>Grade 9,
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
                                                        <li>Optio Sit</li>
                                                        <li>Tempore Eius</li>
                                                        <li>Fuga Quia</li>
                                                        <li>Ducimus Consectetur</li>
                                                    </ul>
                                                    <div class="card-buttons">
                                                        <button class="button gray"><sc:FieldRenderer ID="frSeeProfile" runat="server" FieldName="Connections See Profile Button Text" /></button>
                                                        <button class="button blue"><sc:FieldRenderer ID="frSeeActivity" runat="server" FieldName="Connections See Activity Button Text" /></button>
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
        </section>
        <div class="bottom rs_skip">
            <asp:HyperLink ID="hypConnectionsTab" runat="server"></asp:HyperLink>
        </div>
    </div>
    <!-- /.landing-my-connections.landing-modules -->
</div>
<!-- END PARTIAL: account-landing-my-connections -->
