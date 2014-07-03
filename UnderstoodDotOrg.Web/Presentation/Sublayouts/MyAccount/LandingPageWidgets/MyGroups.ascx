<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyGroups.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets.MyGroups" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN PARTIAL: account-landing-mygroups -->
<div class="landing-mygroups landing-modules rs_read_this">
    <header class="clearfix">
        <h3><sc:FieldRenderer ID="frMyGroupHeaderText" runat="server" FieldName="My Groups Header Text"></sc:FieldRenderer><span class="landing-module-count"><asp:Literal ID="litCount" runat="server"></asp:Literal></span></h3>
    </header>
    <asp:Panel runat="server" ID="pnlGroups" Visible="false">
        <ul class="landing-module-items">
            <asp:Repeater ID="rptGroups" runat="server" OnItemDataBound="rptGroups_ItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="hypGroupsLink" runat="server"></asp:HyperLink>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="bottom rs_skip">
            <asp:HyperLink ID="hypGroupsTab" runat="server"></asp:HyperLink>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNoGroups" Visible="false">
        <p class="empty">asd
            <sc:FieldRenderer ID="frNoGroup" runat="server" FieldName="No Groups Text"></sc:FieldRenderer>
            <sc:Link ID="scAllGroups" Field="No Groups Link" runat="server"></sc:Link>
        </p>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNoProfile" Visible="false">
        <p class="empty"><sc:FieldRenderer ID="frNoProfileText" runat="server" FieldName="Complete Profile Text"></sc:FieldRenderer>
            <sc:Link ID="scLink" runat="server" Field="Complete Profile Link" CssClass="comment-link"></sc:Link>
    </asp:Panel>
</div>
<!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-mygroups -->
