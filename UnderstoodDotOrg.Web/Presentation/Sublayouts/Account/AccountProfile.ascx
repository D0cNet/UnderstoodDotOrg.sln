<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountProfile.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountProfile" %>
<%@ Register Src="~/Presentation/Sublayouts/Account/AccountHeader.ascx" TagPrefix="uc1" TagName="AccountHeader" %>
<%@ Register Src="~/Presentation/Sublayouts/Account/AccountNonFriendProfile.ascx" TagPrefix="uc1" TagName="AccountNonFriendProfile" %>
<%@ Register Src="~/Presentation/Sublayouts/Account/AccountFriendProfile.ascx" TagPrefix="uc1" TagName="AccountFriendProfile" %>
<%@ Register Src="~/Presentation/Sublayouts/Account/AccountFriendConnections.ascx" TagPrefix="uc1" TagName="AccountFriendConnections" %>
<%@ Register Src="~/Presentation/Sublayouts/Account/AccountFriendComments.ascx" TagPrefix="uc1" TagName="AccountFriendComments" %>

<uc1:AccountHeader ID="ucAccountHeader" runat="server" />

<uc1:AccountNonFriendProfile ID="ucAccountNonFriendProfile" Visible="false" runat="server" />

<div class="container flush friends-view-tabs-page-header">&nbsp;</div>

<asp:Panel ID="pnlFriends" runat="server" Visible="false" CssClass="container">
    <div class="row">
        <!-- article -->
        <div class="col col-24 offset-1">
            <div class="tab-container friends-view-tabs skiplink-content" aria-role="main">

                 <!-- BEGIN PARTIAL: friends-view-tabs -->
                  <ul class="etabs">
                    <li class="tab profile-tab <%= GetSelectedTabClass(0) %>"><a href="<%= ProfileUrl %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.ProfileLabel %></a></li>
                    <li class="tab connections-tab <%= GetSelectedTabClass(1) %>"><a href="<%= ProfileConnectionsUrl %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.ConnectionsLabel %></a></li>
                    <li class="tab comments-tab <%= GetSelectedTabClass(2) %>"><a href="<%= ProfileCommentsUrl %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.CommentsLabel %> <span class="comment-number"><asp:Literal runat="server" ID="litCommentCount" /></span></a></li>
                  </ul>
                  <div class="friends-view-tabs-select select-inverted-mobile">
                    <div class="etabs-dropdown">
                      <asp:DropDownList ID="ddlMobileTabs" AutoPostBack="true" runat="server" />
                    </div>
                  </div>

                <uc1:AccountFriendProfile ID="ucAccountFriendProfile" runat="server" Visible="false" />
                <uc1:AccountFriendConnections ID="ucAccountFriendConnections" runat="server" Visible="false" />
                <uc1:AccountFriendComments ID="ucAccountFriendComments" runat="server" Visible="false" />
                
            </div>
        </div>
    </div>
</asp:Panel>