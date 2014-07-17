<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyFriends.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.MyFriends" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register TagPrefix="uc1" TagName="MemberProfileCard" Src="~/Presentation/Sublayouts/Common/Cards/MemberProfileCard.ascx" %>

<div id="divFriends" class="community-members" runat="server">
    <div class="row">
        <div class="col col-24 community-members-wrapper">
            <h2 class="rs_read_this"><%= UnderstoodDotOrg.Common.DictionaryConstants.MyFriendsLabel %></h2>
            <div class="carousel-arrow-wrapper">
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows members next-prev-menu arrows-gray">

                    <a class="view-all" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeAllMembersLabel %></a>

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
                    ItemType="UnderstoodDotOrg.Services.Models.Telligent.User">
                    <ItemTemplate>
                        <uc1:MemberProfileCard runat="server" ProfileUser="<%# Item %>" />
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
