<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyConnections.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets.MyConnections" %>
<%@ Register TagPrefix="uc1" TagName="MemberProfileCard" Src="~/Presentation/Sublayouts/Common/Cards/MemberProfileCard.ascx" %>

<!-- BEGIN PARTIAL: account-landing-my-connections -->
<div class="row">
    <div class="landing-modules my-connections">
        <header>
            <h3><sc:FieldRenderer ID="frMyConnections" runat="server" FieldName="My Connections Header Text" /><span class="landing-module-count"><asp:Label ID="ltFriendCount" runat="server" /></span></h3>
        </header>
        <section class="connections group" id="user_equal_heights">
            <div class="row member-cards">
                <asp:Repeater ID="rptFriends" runat="server"
                    ItemType="UnderstoodDotOrg.Services.Models.Telligent.User">
                    <ItemTemplate>
                        <uc1:MemberProfileCard ID="ucMemberProfileCard" runat="server" ProfileUser="<%# Item %>" ColumnCss="col-8" />
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
