<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyGroups.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets.MyGroups" %>
<!-- BEGIN PARTIAL: account-landing-mygroups -->
<div class="landing-mygroups landing-modules rs_read_this">
    <header class="clearfix">
        <h3><sc:FieldRenderer ID="frMyGroupHeaderText" runat="server" FieldName="My Group Header Text"></sc:FieldRenderer><span class="landing-module-count"><asp:Literal ID="litCount" runat="server"></asp:Literal></span></h3>
    </header>
    <asp:Panel runat="server" ID="pnlGroups" Visible="false">
        <ul class="landing-module-items">
            <asp:Repeater ID="rptGroups" runat="server" OnItemDataBound="rptGroups_ItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="hypGroupsLink" runat="server"></asp:HyperLink></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="bottom rs_skip">
            <asp:HyperLink ID="hypGroupsTab" runat="server"></asp:HyperLink>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNoGroups" Visible="false">
        <p class="empty">
            You have not yet joined any groups. Our private discussion groups are a great way to get advice for your situation and to help other parents in need.
            <asp:HyperLink ID="hypAllGroups" runat="server">See all discussion groups.</asp:HyperLink>
        </p>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNoProfile" Visible="false">
        <p class="empty">You don't have a community profile, to create one please
            <asp:HyperLink CssClass="comment-link" ID="hypCompleteYourProfile" runat="server">click here.</asp:HyperLink></p>
    </asp:Panel>
</div>
<!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-mygroups -->
