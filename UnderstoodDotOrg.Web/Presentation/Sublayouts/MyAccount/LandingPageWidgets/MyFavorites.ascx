<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyFavorites.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets.MyFavorites" %>
<!-- BEGIN PARTIAL: account-landing-myfavorites -->
<div class="landing-myfavorites landing-modules rs_read_this">
    <header class="clearfix">
        <h3>My Favorites<span class="landing-module-count"><asp:Literal ID="litCount" runat="server"></asp:Literal></span></h3>
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
            You have not saved any
            <asp:HyperLink ID="hypArticles" runat="server">favorite articles</asp:HyperLink>,
            <asp:HyperLink ID="hypBehaviourTool" runat="server">behavior tips</asp:HyperLink>, or
            <asp:HyperLink ID="hypExpertsLive" runat="server">expert answers</asp:HyperLink>
            yet. When you do, your favorites will appear here.
        </p>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNoProfile" Visible="false">
        <p class="empty">You don't have a community profile, to create one please 
            <asp:HyperLink CssClass="comment-link" ID="hypCompleteYourProfile" runat="server">click here.</asp:HyperLink></p>
    </asp:Panel>
</div>
<!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-myfavorites -->
