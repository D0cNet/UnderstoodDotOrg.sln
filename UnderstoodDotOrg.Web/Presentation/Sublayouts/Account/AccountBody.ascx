<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountBody.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountBody" %>
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
                <asp:Repeater ID="rptChildren" runat="server">
                    <HeaderTemplate>
                        <div class="member-view-children">
                            <div class="row">
                                <div class="col col-6 section-label">
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.ChildrenLabel %></h3>
                                </div>
                                <div class="col col-18">

                                    <!-- START Template-->
                                    <div class="row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col col-12 rs_read_this">
                            <h4><asp:Literal ID="litChild" runat="server" /></h4>
                            <asp:Repeater ID="rptIssues" runat="server">
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
                    <FooterTemplate>
                                    </div>
                                <!-- /. row -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.member-view-children -->
                    </FooterTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rptInterests" runat="server">
                    <HeaderTemplate>
                        <hr>

                        <div class="row member-view-interests rs_read_this">
                            <div class="col col-6 section-label">
                                <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.InterestsLabel %></h3>
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

                <hr>

                <asp:Repeater ID="rptGroups" runat="server">
                    <HeaderTemplate>
                        <hr />

                        <div class="row member-view-groups rs_read_this">
                            <div class="col col-6 section-label">
                                <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.GroupsFragment %></h3>
                            </div>
                            <div class="col col-18">
                                <ul>
                    </HeaderTemplate>
                    <ItemTemplate>

                    </ItemTemplate>
                    <FooterTemplate>
                                </ul>
                            </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <!-- /.member-view-groups-->
            <!-- END PARTIAL: member-view-content -->
        </div>
    </div>
    <!-- .row -->
</asp:Panel>
