<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountBody.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountBody" %>

<!-- BEGIN PARTIAL: sign-in-prompt-links -->
<div class="sign-in-prompt-links" id="divNotSignedIn" runat="server" visible="false">
    <div class="rs_read_this row">
        <img alt="Private Profile" src="/Presentation/Includes/images/icon.sign-in-prompt.lock.png" />
        <h3>This User&#39;s Profile is currently private</h3>
        <h5>Parent profiles are only visible to logged-in members</h5>
        <h4><a href="REPLACE">Sign in</a> or <a href="REPLACE">Sign up</a> to view more</h4>
    </div>
</div>
<!-- END PARTIAL: sign-in-prompt-links -->

<!-- BEGIN PARTIAL: sign-in-prompt -->
<div class="sign-in-prompt" id="divPrivateProfile" runat="server" visible="false">
    <img alt="Private Profile" src="/Presentation/Includes/images/icon.sign-in-prompt.lock.png" />
    <h3>This User&#39;s Profile is currently private</h3>
</div>
<!-- END PARTIAL: sign-in-prompt -->

<div class="container" id="divNotConnected" runat="server" visible="false">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: member-view-content -->
            <div class="member-view-content">
                <div class="member-view-children">
                    <div class="row">
                        <div class="col col-6 section-label">
                            <h3>Children</h3>
                        </div>
                        <div class="col col-18">
                            <!-- START Template-->
                            <asp:Repeater ID="rptChildren" runat="server" OnItemDataBound="rptChildren_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Repeater ID="rptRow" runat="server" OnItemDataBound="rptRow_ItemDataBound">
                                        <HeaderTemplate>
                                            <div class="row">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="col col-12 rs_read_this">
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
                                        <AlternatingItemTemplate>
                                            <div class="col col-11 offset-1 rs_read_this">
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
                                        </AlternatingItemTemplate>
                                        <FooterTemplate>
                                            </div>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                            </asp:Repeater>
                            <!-- /. row -->
                            <!-- END Template-->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.member-view-children -->
                <hr>
                <div class="row member-view-interests rs_read_this">
                    <div class="col col-6 section-label">
                        <h3>Interests</h3>
                    </div>
                    <div class="col col-18">
                        <ul>
                            <asp:Repeater ID="rptInterests" runat="server" ItemType="UnderstoodDotOrg.Domain.Membership.Interest">
                                <ItemTemplate>
                                    <li><%# Eval("Value") %></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.member-view-interests-->
                <hr>
                <div class="row member-view-groups rs_read_this">
                    <div class="col col-6 section-label">
                        <h3>Groups</h3>
                    </div>
                    <div class="col col-18">
                        <ul>
                            <asp:Repeater ID="rptGroups" runat="server" OnItemDataBound="rptGroups_ItemDataBound">
                                <ItemTemplate>
                                    <li>
                                        <asp:HyperLink ID="hypGroup" runat="server">Parents of kids with attention issues</asp:HyperLink><a href="REPLACE">
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- /.member-view-groups-->
            <!-- END PARTIAL: member-view-content -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
