<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventArchive.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards.EventArchive" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="row">
    <div class="event-card rs_read_this">
        <div class="event-card-info group">
            <div class="event-card-image col equalize">
                <a href="<%= EventUrl %>">
                    <asp:Image runat="server" ID="imgExpert" />
                    <%--<asp:PlaceHolder ID="phPlayIcon" runat="server" Visible="false">
                    <span class="play">play button</span>
                    </asp:PlaceHolder>--%>
                    <div class="image-label">
                        <asp:Literal runat="server" ID="litExpertType" />
                    </div>
                </a>
            </div>
            <!-- end .event-card-image -->
            <div class="event-card-details col equalize">
                <div class="event-card-title">
                    <a href="<%= EventUrl %>">
                        <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                    </a>
                </div>
                <!-- end .event-card-title -->
                <p class="event-card-topics-head">
                    <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Event Heading" />
                </p>
                <p class="event-card-topics">
                    <sc:FieldRenderer ID="frSubheading" runat="server" FieldName="Event Subheading" />
                </p>
                <%-- Phase 2
                <span class="children-key">
                    <ul>
                        <li><i title="CHILD NAME HERE" class="child-a"></i></li>
                        <li><i title="CHILD NAME HERE" class="child-b"></i></li>
                    </ul>
                </span> --%>
            </div>
            <!-- end .event-card-details -->
            <div class="event-card-date-details col equalize">
                <p class="event-type"><asp:Literal runat="server" ID="litEventType" /></p>
                <p class="event-date"><asp:Literal runat="server" ID="litEventDate" /></p>
                <p class="event-date-sub"><asp:Literal runat="server" ID="litEventSubDate" /></p>
            </div>
        </div>
        <!-- end .event-card-info -->
    </div>
</div>