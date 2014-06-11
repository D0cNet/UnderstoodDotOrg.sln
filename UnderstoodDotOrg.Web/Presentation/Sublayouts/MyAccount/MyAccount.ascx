<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.MyAccount" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- Margins are set in wrapper instead of using flush class to avoid important css -->
<div class="container account-landing-wrapper">
    <div class="row">
        <!-- article -->
        <div class="col col-7 offset-1 large-landing-module skiplink-content" aria-role="main">
            <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/MyAccount/LandingPageWidgets/MyNotifications.ascx" />
        </div>
        <div class="col col-15 small-landing-modules">

            <div class="row">
                <div class="col col-12">
                    <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/MyAccount/LandingPageWidgets/MyGroups.ascx" />
                </div>
                <div class="col col-12">
                    <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/MyAccount/LandingPageWidgets/MyUpcomingEvents.ascx" />
                </div>
            </div>

            <div class="row">
                <div class="col col-12">
                    <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/MyAccount/LandingPageWidgets/MyComments.ascx" />
                </div>
                <div class="col col-12">
                    <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/MyAccount/LandingPageWidgets/MyFavorites.ascx" />
                </div>
            </div>

        </div>
    </div>
    <!-- .row -->
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/MyAccount/LandingPageWidgets/MyConnections.ascx" />
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
