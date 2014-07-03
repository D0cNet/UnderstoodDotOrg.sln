<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyFavorites.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets.MyFavorites" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN PARTIAL: account-landing-myfavorites -->
<div class="landing-myfavorites landing-modules rs_read_this">
    <header class="clearfix">
        <h3><sc:FieldRenderer ID="frMyFavorites" runat="server" FieldName="My Favorites Text" /><span class="landing-module-count"><asp:Literal ID="litCount" runat="server"></asp:Literal></span></h3>
    </header>
    <asp:Panel runat="server" ID="pnlFavorites" Visible="false">
        <ul class="landing-module-items">
            <asp:Repeater ID="rptFavorites" runat="server" OnItemDataBound="rptFavorites_ItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="hypFavoritesLink" runat="server"></asp:HyperLink></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="bottom rs_skip">
            <asp:HyperLink ID="hypFavoritesTab" runat="server">See All Favorites</asp:HyperLink>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNoFavorites" Visible="false">
        <p class="empty">
            <sc:FieldRenderer ID="frNoFavorites" runat="server" FieldName="No Favorites Text" />
        </p>
    </asp:Panel>
</div>
<!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-myfavorites -->
