<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventArchiveListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards.EventArchiveListing" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Repeater ID="rptEvents" runat="server">
    <ItemTemplate>
        <sc:Sublayout ID="slEventArchive" runat="server" Path="~/Presentation/Sublayouts/Common/Cards/EventArchive.ascx" />
    </ItemTemplate>
</asp:Repeater>