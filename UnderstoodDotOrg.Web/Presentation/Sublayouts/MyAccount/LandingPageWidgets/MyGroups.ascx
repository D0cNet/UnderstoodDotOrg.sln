<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyGroups.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets.MyGroups" %>
<!-- BEGIN PARTIAL: account-landing-mygroups -->
<div class="landing-mygroups landing-modules rs_read_this">
    <header class="clearfix">
        <h3>My Groups<span class="landing-module-count"><asp:Literal ID="litCount" runat="server"></asp:Literal></span></h3>
    </header>

    <ul class="landing-module-items">
        <asp:Repeater ID="rptGroups" runat="server" OnItemDataBound="rptGroups_ItemDataBound">
            <ItemTemplate>
                <li><asp:HyperLink ID="hypGroupsLink" runat="server"></asp:HyperLink></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="bottom rs_skip">
        <asp:HyperLink ID="hypGroupsTab" runat="server">See All Favorites</asp:HyperLink>
    </div>

</div>
<!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-mygroups -->
