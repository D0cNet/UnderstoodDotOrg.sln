<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountFriendProfile.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountFriendProfile" %>

<div class="panel-container profile-panel">
    <asp:ListView ID="lvChildren" runat="server" GroupItemCount="2">
        <LayoutTemplate>
            <div class="children-container">
                <div class="row">
                    <div class="col col-5">
                        <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.ChildrenLabel %></h3>
                    </div>
                    <div class="col col-19">
                        <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
                    </div>
                </div>
            </div>
        </LayoutTemplate>
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col col-11 rs_read_this friends-view-rs-wrapper">
                <h4><asp:Literal ID="litChild" runat="server" /></h4>
                <asp:Repeater ID="rptIssues" runat="server" OnItemDataBound="rptIssues_ItemDataBound">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><asp:Literal ID="litIssue" runat="server" /></li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:Repeater ID="rptInterests" runat="server">
        <HeaderTemplate>
            <hr/>

            <div class="row children-interests rs_read_this friends-view-rs-wrapper">
                <div class="col col-5">
                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.InterestsLabel %></h3>
                </div>
                <div class="col col-19">
                    <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><asp:Literal ID="litInterest" runat="server" /></li>
        </ItemTemplate>
        <FooterTemplate>
                    </ul>
                </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    

    <asp:Repeater ID="rptGroups" runat="server" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.GroupModel">
        <HeaderTemplate>

            <hr />
            <div class="row children-groups rs_read_this friends-view-rs-wrapper">
                <div class="col col-5">
                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.GroupsFragment %></h3>
                </div>
                <div class="col col-19">
                    <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><a href="<%# Item.Url %>"><%# Item.Title %></a></li>
        </ItemTemplate>
        <FooterTemplate>
                    </ul>
                </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>

</div>
<!-- end .profile-panel -->
