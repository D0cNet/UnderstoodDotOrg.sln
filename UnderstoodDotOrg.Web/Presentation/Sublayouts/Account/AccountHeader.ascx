<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ThanksButton.ascx" TagPrefix="uc1" TagName="ThanksButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ConnectButton.ascx" TagPrefix="uc1" TagName="ConnectButton" %>

<div class="container back-to-previous-nav">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <asp:HyperLink id="hlBackToHomepage" runat="server" CssClass="back-to-previous"><i class="icon-arrow-left-blue"></i><%= UnderstoodDotOrg.Common.DictionaryConstants.MyAccount_BackToHomePageLinkText %></asp:HyperLink>
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container">
    <div class="row">
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: account-view-header -->
            <div class="account-view-header <%= CanConnectCss %>">
                <div class="account-top-wrapper">
                    <div class="account-photo">
                        <asp:Image runat="server" ID="imgAvatar" />
                    </div>
                    <div class="account-info">
                        <h1 class="account-username"><%= ScreenName %></h1>
                        <p class="account-location"><asp:Literal ID="litLocation" runat="server" /></p>

                        <asp:Repeater ID="rptChildren" runat="server">
                            <HeaderTemplate>
                                <div class="member-card-specialties">
                                    <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <span class="visuallyhidden">grade level</span>
                                <li class="specialty-long"><a href="#"><asp:Literal ID="litGrade" runat="server" /></a>

                                    <div class="card-child-info popover rs_skip">
                                        <div class="popover-content">
                                            <span class="caret"></span>
                                            <h3><asp:Literal ID="litChild" runat="server" /></h3>
                                            <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                            <div class="arrows child-info-next-prev-menu arrows-gray">
                                                <div class="rsArrow rsArrowLeft">
                                                    <button class="rsArrowIcn"></button>
                                                </div>
                                                <div class="rsArrow rsArrowRight">
                                                    <button class="rsArrowIcn"></button>
                                                </div>
                                            </div>

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
                                    </div>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                        <li class="specialty specialty-final"><span class="visuallyhidden">additional information</span><span tabindex='0' data-tabbable='true'>&nbsp;</span></li>
                                    </ul>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>

                        <sc:Sublayout ID="scNotConnectingWide" Visible="false" runat="server" Parameters="AdditionalCSSClass=wide no-margin" Path="~/Presentation/Sublayouts/Account/Common/NotConnectingMessage.ascx" />

                        <asp:Panel ID="pnlMemberConnectWide" runat="server" Visible="false" CssClass="account-connect-links wide no-margin">
                            <uc1:ConnectButton ID="cbMemberConnectWide" runat="server" />
                        </asp:Panel>

                        <sc:Sublayout ID="scFriendWide" Visible="false" runat="server" Parameters="AdditionalCSSClass=wide no-margin" Path="~/Presentation/Sublayouts/Account/Common/FriendButtons.ascx" />

                    </div>

                    <asp:Panel ID="pnlAnonConnectWide" runat="server" Visible="false" CssClass="account-connect-links wide">
                        <uc1:ConnectButton ID="cbAnonConnectWide" runat="server" />
                    </asp:Panel>

                    <div class="clearfix"></div>

                    <asp:UpdatePanel ID="pnlSupport" Visible="false" runat="server">
                        <ContentTemplate>
                            <div class="account-show-support">
                                <div class="account-support-links">
                                    <asp:LinkButton ID="btnThanks" runat="server"><i class="icon-account-smiley"></i><span><%= UnderstoodDotOrg.Common.DictionaryConstants.ThanksLabel %></span></asp:LinkButton>
                                    <asp:LinkButton ID="btnThinking" runat="server"><i class="icon-account-flower"></i><span><%= UnderstoodDotOrg.Common.DictionaryConstants.ThinkingOfYouLabel %></span></asp:LinkButton>
                                  </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <sc:Sublayout runat="server" ID="scNotConnectingNarrow" Visible="false" Parameters="AdditionalCSSClass=narrow" Path="~/Presentation/Sublayouts/Account/Common/NotConnectingMessage.ascx" />

                    <asp:Panel ID="pnlConnectNarrow" runat="server" Visible="false" CssClass="account-connect-links narrow">
                        <uc1:ConnectButton ID="cbConnectNarrow" runat="server" />
                    </asp:Panel>

                    <sc:Sublayout ID="scFriendNarrow" Visible="false" runat="server" Parameters="AdditionalCSSClass=narrow" Path="~/Presentation/Sublayouts/Account/Common/FriendButtons.ascx" />

                </div>
            </div>

            <!-- END PARTIAL: account-view-header -->
        </div>
    </div>
</div>
