<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderMainNav.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.HeaderMainNav" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
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
                    <li role="menuitem">
                        <span>
                            <sc:FieldRenderer ID="frPrimaryNavigationLink" runat="server" FieldName="Link" />
                        </span>
                    </li>
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
