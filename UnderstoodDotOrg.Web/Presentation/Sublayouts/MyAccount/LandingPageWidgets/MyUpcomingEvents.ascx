<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyUpcomingEvents.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets.MyUpcomingEvents" %>
<!-- BEGIN PARTIAL: account-landing-events -->
<div class="landing-events landing-modules rs_read_this">
    <header class="clearfix">
        <h3><sc:FieldRenderer ID="frUpcomingEventsHeaderText" runat="server" FieldName="Upcoming Events Header Text"></sc:FieldRenderer></h3>
    </header>
    <%--DONE--%>
    <ul class="landing-module-items">
        <asp:Repeater ID="rptEvents" runat="server" OnItemDataBound="rptEvents_ItemDataBound">
            <ItemTemplate>
                <li>
                    <span class="event-wrap">
                        <asp:HyperLink ID="hypEventLink" runat="server"></asp:HyperLink>
                        <asp:HyperLink ID="hypEventTypeLink" CssClass="event-type" runat="server"></asp:HyperLink>
                        <span class="timestamp">
                            <asp:Literal ID="litDate" runat="server"></asp:Literal>
                            <span class="dot"></span>
                            <asp:Literal ID="litTime" runat="server"></asp:Literal>
                        </span>
                    </span>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <%--DONE--%>
    <div class="bottom rs_skip">
        <asp:HyperLink ID="hypEventsTab" runat="server"></asp:HyperLink>
    </div>
</div>
<!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-events -->
