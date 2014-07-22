<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Header" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Literal ID="litAnalytics" runat="server" />

<!-- BEGIN PARTIAL: header -->
<header id="header-page" class="container">
    <div class="row">
        <div class="col col-24">
            <sc:Sublayout runat="server" Cacheable="false" Path="~/Presentation/Sublayouts/Common/HeaderUtilityNav.ascx" />
            <sc:Sublayout runat="server" Cacheable="false" Path="~/Presentation/Sublayouts/Common/HeaderMainNav.ascx" />
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
    <sc:Sublayout runat="server" Cacheable="false" Path="~/Presentation/Sublayouts/Common/HeaderToolKitNav.ascx" />
</header>
<!-- #header-page -->
<!-- END PARTIAL: header -->

