<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUtilityNav.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.HeaderUtilityNav" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>

<%-- Logo is content managed, override default stylesheet with inline CSS block --%>
<style type="text/css">
    @media (min-width: 769px) {
        .logo-u-main a {
            background-image: (<%= MainLogoUrl %>) !important;
        }
    }
</style>
<div class="logo-u-main">
    <asp:HyperLink runat="server" ID="hlLogoLink">
        <span class="visuallyhidden">Understood for learning and attention issues</span>
        <asp:Image ID="imgMobileLogo" runat="server" />
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
<% if (IsUserLoggedIn) { %>
<style type="text/css">
    div.user-info-bar {
        position: absolute;
        right: 208px;
        text-align: right;
        max-width: 752px;
        font-size: 0.875rem;
        line-height: 1.429;
        color: rgb(122, 65, 131);
    }
    div.user-info-bar > a:link,
    div.user-info-bar > a:visited {        
        color: rgb(105, 105, 105);
    }
    div.user-info-bar > a:hover,
    div.user-info-bar > a:active {   
        text-decoration: none;
        color: rgb(66, 109, 169);
    }
</style>
<div class="user-info-bar">Welcome, <a href="<%= MyAccountPageItem.GetUrl() %>"><%= UserDisplayName %></a>!</div>
<% } %>
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
        <asp:LinkButton ID="lbSignout" OnClick="lbSignout_Click" CssClass="link-sign-in" Visible="false" runat="server"/>
        <sc:FieldRenderer runat="server" ID="scLinkSignIn" FieldName="Login Link" Parameters="class=link-sign-in" />
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
                <input type="text" id="search-term" placeholder='<%= SearchLabel %>' data-path="<%= SearchPath %>">
                <input type="submit" value="Go">
            </span>
        </fieldset>
    </div>
    <!-- #search-site -->
</div>
<!-- .l-bar -->
