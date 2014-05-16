<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Header" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN PARTIAL: header -->
<sc:FieldRenderer ID="frGlobalGoogleAnalytics" runat="server" FieldName="Google Analytics"/>
<sc:FieldRenderer ID="frPageGoogleAnalytics" runat="server" FieldName="Google Analytics" />

<header id="header-page" class="container">
    <div class="row">
        <div class="col col-24">

            <div class="logo-u-main">
                <asp:HyperLink runat="server" ID="hlLogoLink">
                    <span class="visuallyhidden">Understood for learning and attention issues</span>
                    <sc:FieldRenderer runat="server" ID="scLogoImage" FieldName="Company Logo" Parameters="w=230&h=73&as=1" />
                </asp:HyperLink>
            </div>
            <!-- logo-u-main -->
            <asp:Repeater runat="server" ID="rptLanguage" OnItemDataBound="rptLanguage_ItemDataBound">
                <HeaderTemplate>
                    <ul class="language-selection">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink runat="server" ID="hypLanguageLink"></asp:HyperLink>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

            <div class="l-bar">
                <asp:Repeater runat="server" ID="rptNavUtility" OnItemDataBound="rptNavUtility_ItemDataBound">
                    <HeaderTemplate>
                          <nav class="nav-utility">
                            <ul role="menu">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li role="menuitem" aria-haspopup="true">
                            <sc:FieldRenderer ID="frUtilityLink" runat="server" FieldName="Link" />
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                </nav>
                    </FooterTemplate>
                </asp:Repeater>
                <!-- .nav-utility -->

                <!-- BEGIN PARTIAL: user-state -->
                <div class="sign-in" aria-haspopup="true">
                    <sc:FieldRenderer runat="server" ID="scLinkSignIn" FieldName="Sign In" Parameters="class=link-sign-in" />
                </div>

                <!-- END PARTIAL: user-state -->
                <div id="search-site">
                    <fieldset>
                        <legend>
                            <sc:FieldRenderer ID="frSearchLabel1" runat="server" FieldName="Link" />
                        </legend>
                        <span class="field">
                            <label for="search-term" class="visuallyhidden" aria-hidden="true">
                                <sc:FieldRenderer ID="frSearchLabel2" runat="server" FieldName="Link" />
                            </label>
                            <input type="text" id="search-term" placeholder="Enter Search Term" data-path="<%= SearchPath %>">
                            <input type="submit" value="Go">
                        </span>
                    </fieldset>
                </div>
                <!-- #search-site -->
            </div>
            <!-- .l-bar -->

            <!-- BEGIN PARTIAL: nav-main -->
            <asp:Repeater runat="server" ID="rptMainNavigation" OnItemDataBound="rptMainNavigation_ItemDataBound">
                <HeaderTemplate>
                    <nav class="nav-main">
                        <ul role="menu" aria-role="navigation" aria-label="main-navigation">
                </HeaderTemplate>
                <ItemTemplate>
                    <li class="menu-list-item" role="menuitem" aria-haspopup="true">
                        <span>
                            <sc:FieldRenderer ID="frMainNavigationLink" runat="server" FieldName="Link" />
                        </span>
                        <asp:Repeater runat="server" ID="rptPrimaryNavigation" OnItemDataBound="rptPrimaryNavigation_ItemDataBound">
                            <HeaderTemplate>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li role="menuitem"><span>
                                    <sc:FieldRenderer ID="frPrimaryNavigationLink" runat="server" FieldName="Link" />
                                </span></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
            </nav>
                </FooterTemplate>
            </asp:Repeater>
            <!-- END PARTIAL: nav-main -->

            <div id="toolkit" class="toolkit-element" aria-haspopup="true">
                <button>
                    <%--Your Parent Toolkit--%>
                    <sc:FieldRenderer ID="frParentToolKitHeading" runat="server" FieldName="Heading" />
                </button>
            </div>
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->

    <!-- toolkit header row -->
    <div class="row toolkit-row">
        <div class="col col-24">
            <!-- BEGIN PARTIAL: toolkit-header -->
            <div class="parent-toolkit-wrapper">
                <div class="parent-toolkit-header-container arrows-gray">

                    <h2>Your Parent Toolkit</h2>

                    <span class="button-close"><i class="icon-close-toolkit"></i>Close</span>
                    <asp:Repeater runat="server" ID="rptParentToolkit" OnItemDataBound="rptParentToolkit_ItemDataBound">
                        <HeaderTemplate>
                            <div class="slides-container">
                                <div class="slide">
                                    <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:Panel runat="server" ID="pnlParentToolKit" CssClass="icon">
                                    <sc:FieldRenderer ID="frNavLink" runat="server" FieldName="Link" />
                                    <%--<div class="coming-soon">Coming Soon</div>--%>
                                </asp:Panel>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                            </div>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <!-- .parent-toolkit-header-container -->
            </div>
            <!-- #parent-toolkit-wrapper -->
            <!-- END PARTIAL: toolkit-header -->
        </div>
    </div>
</header>
<!-- #header-page -->
<!-- END PARTIAL: header -->

