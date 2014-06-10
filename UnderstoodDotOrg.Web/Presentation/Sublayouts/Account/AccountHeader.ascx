<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container back-to-previous-nav">
  <div class="row">
    <!-- article -->
    <div class="col col-22 offset-1">
      <a href="REPLACE" class="back-to-previous"><i class="icon-arrow-left-blue"></i>Back to Homepage</a>
    </div>
  </div><!-- .row -->
</div><!-- .container -->

<asp:Panel ID="pnlPrivateUser" CssClass="container" runat="server" Visible="false">
    <div class="row">
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: account-view-header -->
            <div class="account-view-header">
                <div class="account-top-wrapper">
                    <div class="account-photo">
                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    </div>
                    <div class="account-info">
                        <h1 class="account-username">
                            <%= screenName %>
                        </h1>
                        <p class="account-location"></p>
                        <!-- BEGIN PARTIAL: account-view-header-connect -->
                        <div class="account-connect-links wide no-margin">
                            <p class="no-connect-msg rs_read_this">This user is not connecting with other parents at this time.</p>
                        </div>
                        <!-- END PARTIAL: account-view-header-connect -->
                    </div>
                    <div class="clearfix"></div>
                    <!-- BEGIN PARTIAL: account-view-header-connect -->
                    <div class="account-connect-links narrow">
                        <p class="no-connect-msg rs_read_this">This user is not connecting with other parents at this time.</p>
                    </div>
                    <!-- END PARTIAL: account-view-header-connect -->
                </div>
            </div>
            <!-- END PARTIAL: account-view-header -->
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="pnlNotSignedInView" CssClass="container" runat="server" Visible="false">
    <div class="row">
        <div class="col col-22 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: account-view-header -->
            <div class="account-view-header can-connect">
                <div class="account-top-wrapper">
                    <div class="account-photo">
                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    </div>
                    <div class="account-info">
                        <h1 class="account-username"><%= screenName %></h1>
                        <p class="account-location"></p>
                        <div class="member-card-specialties">
                            <ul>
                                <span class="visuallyhidden">grade level</span>
                                <asp:Repeater ID="rptChildren" runat="server" OnItemDataBound="rptChildren_ItemDataBound">
                                    <ItemTemplate>
                                        <li class=''><a href='REPLACE'>
                                            <asp:Literal ID="litGrade" runat="server"></asp:Literal></a><!-- BEGIN PARTIAL: community/child_info_card -->
                                            <div class="card-child-info popover rs_skip">
                                                <div class="popover-content">
                                                    <span class="caret"></span>
                                                    <h3>Grade <asp:Literal ID="litGrade2" runat="server"></asp:Literal>, 
                                                        <asp:Literal ID="litGender" runat="server">Boy</asp:Literal>
                                                    </h3>
                                                    <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                    <div class="arrows child-info-next-prev-menu arrows-gray">
                                                        <div class="rsArrow rsArrowLeft">
                                                            <button class="rsArrowIcn"></button>
                                                        </div>
                                                        <div class="rsArrow rsArrowRight">
                                                            <button class="rsArrowIcn"></button>
                                                        </div>
                                                    </div>
                                                    <!-- end .arrows -->
                                                    <!-- END PARTIAL: community/carousel_arrows -->
                                                    <ul>
                                                        <asp:Repeater ID="rptChildIssues" runat="server" ItemType="UnderstoodDotOrg.Domain.Membership.Issue">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <%# Eval("Value") %>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                    <div class="card-buttons">
                                                        <button class="button gray">View Profile</button>
                                                        <button class="button blue">See Activity</button>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END PARTIAL: community/child_info_card -->
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <li class="specialty specialty-final"><span class="visuallyhidden">additional information</span><span tabindex='0' data-tabbable='true'>&nbsp;</span></li>
                            </ul>
                        </div>
                    </div>
                    <!-- BEGIN PARTIAL: account-view-header-connect -->
                    <div class="account-connect-links wide">
                        <button class="button">Connect</button>
                    </div>
                    <!-- END PARTIAL: account-view-header-connect -->
                    <div class="clearfix"></div>
                    <!-- BEGIN PARTIAL: account-view-header-support -->
                    <div class="account-show-support">
                        <p>Show your support</p>
                        <div class="account-support-links">
                            <a href="REPLACE"><i class="icon-account-smiley"></i><span>Thanks</span></a>
                            <a href="REPLACE"><i class="icon-account-flower"></i><span>Thinking of You</span></a>
                        </div>
                    </div>
                    <!-- END PARTIAL: account-view-header-support -->
                    <!-- BEGIN PARTIAL: account-view-header-connect -->
                    <div class="account-connect-links narrow">
                        <asp:Button ID="btnConnect" CssClass="button" OnClick="btnConnect_Click" runat="server" Text="Connect" />
                    </div>
                    <!-- END PARTIAL: account-view-header-connect -->
                </div>
            </div>
            <!-- END PARTIAL: account-view-header -->
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="pnlSignedIn" CssClass="container" runat="server" Visible="false">
    <div class="row">
        <div class="col col-22 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: account-view-header -->
            <div class="account-view-header can-connect">
                <div class="account-top-wrapper">
                    <div class="account-photo">
                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    </div>
                    <div class="account-info">
                        <h1 class="account-username"><%= screenName %></h1>
                        <p class="account-location"></p>
                        <!-- BEGIN PARTIAL: account-view-header-connect -->
                        <div class="account-connect-links wide no-margin" id="divNotConnected" runat="server" visible="false">
                            <button class="button">Connect</button>
                        </div>
                        <div class="account-connect-links wide no-margin" id="divConnected" runat="server" visible="false">
                            <button class="button gray unconnect">Unconnect</button>
                            <button class="button">Private Message</button>
                        </div>
                        <!-- END PARTIAL: account-view-header-connect -->
                    </div>
                    <div class="clearfix"></div>
                    <!-- BEGIN PARTIAL: account-view-header-support -->
                    <div class="account-show-support">
                        <p>Show your support</p>
                        <div class="account-support-links">
                            <a href="REPLACE"><i class="icon-account-smiley"></i><span>Thanks</span></a>
                            <a href="REPLACE"><i class="icon-account-flower"></i><span>Thinking of You</span></a>
                        </div>
                    </div>
                    <!-- END PARTIAL: account-view-header-support -->
                    <!-- BEGIN PARTIAL: account-view-header-connect -->
                    <div class="account-connect-links narrow">
                        <button class="button">Connect</button>
                    </div>
                    <!-- END PARTIAL: account-view-header-connect -->
                </div>
            </div>
            <!-- END PARTIAL: account-view-header -->
        </div>
    </div>
</asp:Panel>
