<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountFriendConnections.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountFriendConnections" %>
<%@ Register TagPrefix="uc1" TagName="MemberProfileCard" Src="~/Presentation/Sublayouts/Common/Cards/MemberProfileCard.ascx" %>

<div class="my-connections-grid profile-connections">
    <div class="row">
        <section class="connections group" id="user_equal_heights">
            <div id="profile-connections-list" class="row member-cards">
                <asp:Repeater ID="rptConnections"
                    ItemType="UnderstoodDotOrg.Services.Models.Telligent.User"
                    runat="server">
                    <ItemTemplate>
                        <uc1:MemberProfileCard ID="ucMemberProfileCard" ProfileUser="<%# Item %>" ColumnCss="col-6" runat="server" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>
    </div>
</div>

<asp:Panel ID="pnlShowMore" runat="server" Visible="false" CssClass="showmore-footer">
    <div class="container show-more rs_skip">
        <div class="row">
            <div class="col col-24">
                <a id="show-more-account-connections" href="#" data-path="<%= AjaxPath %>" data-container="profile-connections-list" data-screenname="<%= ProfileMember.ScreenName %>" data-lang="<%= Sitecore.Context.Language.Name %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></a>
            </div>
        </div>
    </div>
</asp:Panel>
