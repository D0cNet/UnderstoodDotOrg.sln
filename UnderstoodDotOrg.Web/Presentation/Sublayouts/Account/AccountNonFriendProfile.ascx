<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountNonFriendProfile.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountNonFriendProfile" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Panel ID="pnlAnonymousOpen" runat="server" Visible="false" CssClass="sign-in-prompt-links">
    <div class="rs_read_this row">
        <img alt="Private Profile" src="/Presentation/Includes/images/icon.sign-in-prompt.lock.png" />
        <h3>
            <sc:FieldRenderer runat="server" FieldName="Private User Profile Heading" />
        </h3>
        <h5>
            <sc:FieldRenderer runat="server" FieldName="Private User Profile Subheading" />
        </h5>
        <sc:FieldRenderer runat="server" FieldName="Private User Profile Call To Action" />
    </div>
</asp:Panel>

<!-- BEGIN PARTIAL: sign-in-prompt -->
<asp:Panel ID="pnlAnonymousClosed" runat="server" Visible="false" CssClass="sign-in-prompt">
    <img alt="Private Profile" src="/Presentation/Includes/images/icon.sign-in-prompt.lock.png" />
    <h3>
        <sc:FieldRenderer runat="server" FieldName="Private User Profile Heading" />
    </h3>
</asp:Panel>
<!-- END PARTIAL: sign-in-prompt -->

<asp:Panel ID="pnlMemberOpen" runat="server" Visible="false" CssClass="container">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: member-view-content -->
            <div class="member-view-content">
                            
                <asp:ListView ID="lvChildren" runat="server" GroupItemCount="2">
                    <LayoutTemplate>
                        <div class="member-view-children">
                            <div class="row">
                                <div class="col col-6 section-label">
                                    <h3>Children</h3>
                                </div>
                                <div class="col col-18">
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
                        <div class="col col-12 rs_read_this">
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
                        <hr>

                        <div class="row member-view-interests rs_read_this">
                            <div class="col col-6 section-label">
                                <h3>Interests</h3>
                            </div>
                            <div class="col col-18">
                                <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><asp:Literal ID="litInterest" runat="server" /></li>
                    </ItemTemplate>
                    <FooterTemplate>
                                </ul>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.member-view-interests-->
                    </FooterTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rptGroups" runat="server" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.GroupModel">
                    <HeaderTemplate>
                        <hr />

                        <div class="row member-view-groups rs_read_this">
                            <div class="col col-6 section-label">
                                <h3>Groups</h3>
                            </div>
                            <div class="col col-18">
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
            <!-- /.member-view-groups-->
            </div>
            <!-- END PARTIAL: member-view-content -->
        </div>
    </div>
    <!-- .row -->
</asp:Panel>
