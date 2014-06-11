<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TabMenu.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Tabs.TabMenu" %>
<ul class="etabs">
    <li class="tab profile-tab " id="profileTab" runat="server">
        <asp:HyperLink ID="hypProfileTab" runat="server">Profile</asp:HyperLink></li>
    <li class="tab connections-tab " id="connectionsTab" runat="server">
        <asp:HyperLink ID="hypConnectionsTab" runat="server">Connections</asp:HyperLink></li>
    <li class="tab comments-tab " id="commentsTab" runat="server">
        <asp:HyperLink ID="hypCommentsTab" runat="server">
            Comments <span class="comment-number">
                <asp:Literal ID="litCommentsCount" runat="server"></asp:Literal></span>
        </asp:HyperLink></li>
</ul>
<div class="friends-view-tabs-select select-inverted-mobile">
    <div class="etabs-dropdown">
        <select class="">
            <option value="profile">Profile</option>
            <option value="connections">Connections</option>
            <option value="comments">Comments</option>
        </select>
    </div>
</div>
