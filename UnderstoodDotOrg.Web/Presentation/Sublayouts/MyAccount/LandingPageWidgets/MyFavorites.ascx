<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyFavorites.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets.MyFavorites" %>
<!-- BEGIN PARTIAL: account-landing-myfavorites -->
<div class="landing-myfavorites landing-modules rs_read_this">
    <header class="clearfix">
        <h3>My Favorites<span class="landing-module-count"><asp:Literal ID="litCount" runat="server"></asp:Literal></span></h3>
    </header>

    <ul class="landing-module-items">
        <asp:Repeater ID="rptFavorites" runat="server" OnItemDataBound="rptFavorites_ItemDataBound">
            <ItemTemplate>
                <li><asp:HyperLink ID="hypFavoritesLink" runat="server">dolorem molestiae reiciendis beatae sed ut quaerat repudiandae sit sit</asp:HyperLink></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="bottom rs_skip">
        <asp:HyperLink ID="hypFavoritesTab" runat="server">See All Favorites</asp:HyperLink>
    </div>

</div>
<!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-myfavorites -->
