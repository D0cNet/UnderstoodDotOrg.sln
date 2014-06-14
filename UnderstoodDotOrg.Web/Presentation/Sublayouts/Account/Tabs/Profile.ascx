<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Profile.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Tabs.Profile" %>
<div class="container flush friends-view-tabs-page-header">&nbsp;</div>
<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-24 offset-1">
            <div class="tab-container friends-view-tabs skiplink-content" aria-role="main">
                <!-- BEGIN PARTIAL: friends-view-tabs -->
                <sc:sublayout runat="server" path="~/Presentation/Sublayouts/Account/Tabs/TabMenu.ascx" />
                <!-- END PARTIAL: friends-view-tabs -->
                <div class="panel-container profile-panel">
                    <!-- BEGIN PARTIAL: friends-view-tabs-1 -->
                    <div class="children-container">
                        <div class="row">
                            <div class="col col-5">
                                <h3>Children</h3>
                            </div>
                            <div class="col col-19">
                                <asp:Repeater ID="rptChildren" runat="server" OnItemDataBound="rptChildren_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Repeater ID="rptRow" runat="server" OnItemDataBound="rptRow_ItemDataBound">
                                            <HeaderTemplate>
                                                <div class="row">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="col col-11 rs_read_this friends-view-rs-wrapper">
                                                    <h4>
                                                        <asp:Literal ID="litGrade" runat="server"></asp:Literal>, 
                                                        <asp:Literal ID="litGender" runat="server"></asp:Literal>, 
                                                        <asp:Literal ID="litEvaluationStatus" runat="server"></asp:Literal>:
                                                    </h4>
                                                    <ul>
                                                        <asp:Repeater ID="rptChildIssues" runat="server" ItemType="UnderstoodDotOrg.Domain.Membership.Issue">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <%# Eval("Value") %>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </div>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <hr>
                    <div class="row children-interests rs_read_this friends-view-rs-wrapper">
                        <div class="col col-5">
                            <h3>Interests</h3>
                        </div>
                        <div class="col col-19">
                            <ul>
                                <asp:Repeater ID="rptInterests" runat="server" ItemType="UnderstoodDotOrg.Domain.Membership.Interest">
                                    <ItemTemplate>
                                        <li><%# Eval("Value") %></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <hr>
                    <div class="row children-groups rs_read_this friends-view-rs-wrapper">
                        <div class="col col-5">
                            <h3>Groups</h3>
                        </div>
                        <div class="col col-19">
                            <ul>
                                <asp:Repeater ID="rptGroups" runat="server" OnItemDataBound="rptGroups_ItemDataBound">
                                    <ItemTemplate>
                                        <li>
                                            <asp:HyperLink ID="hypGroup" runat="server">Parents of kids with attention issues</asp:HyperLink><%--<a href="REPLACE">--%>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <!-- END PARTIAL: friends-view-tabs-1 -->
                </div>
                <!-- end .profile-panel -->
            </div>
            <!-- end .tab-container.friends-view-tabs -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
