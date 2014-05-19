<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUtilityNav.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.HeaderUtilityNav" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

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
                <sc:FieldRenderer ID="frUtilityLink" runat="server" Visible="false" FieldName="Link" />
                <asp:LinkButton ID="lbSignout" OnClick="lbSignout_Click" Visible="false" runat="server"></asp:LinkButton>
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
