<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventsCalendarView.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.EventsCalendarView" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/ExpertLive/EventFilterNav.ascx" />

<!-- BEGIN PARTIAL: community/calendar/header -->
<div class="container">
    <header class="row calendar-header skiplink-content" aria-role="main">
        <ul class="month-controls arrows-gray">
            <li class="rsArrow rsArrowLeft">
                <asp:HyperLink CssClass="rsArrowIcn" runat="server" ID="hlPreviousMonth" />
            </li>

            <li class="month-name">
                <h2><asp:Literal runat="server" ID="currentMonth" /></h2>
            </li>

            <li class="rsArrow rsArrowRight">
                <asp:HyperLink CssClass="rsArrowIcn" runat="server" ID="hlNextMonth" />
            </li>
        </ul>

        <ul class="calendar-type">
            
            <li>Calendar View</li>
            <!--
            <li><a href="REPLACE">List View</a></li>
            -->
            
        </ul>
    </header>
</div>
<!-- END PARTIAL: community/calendar/header -->


<!-- BEGIN PARTIAL: community/calendar/grid_view -->
<asp:ListView runat="server" ID="EventsLiveCalendarView" GroupItemCount="7" GroupPlaceholderID="weekPlaceholder" ItemPlaceholderID="dayPlaceholder"
        >

    <LayoutTemplate>
        <div class="container calendar calendar-grid rendered">
            <ul class="row month-header">
                <li class="day-header">Sunday</li>
                <li class="day-header">Monday</li>
                <li class="day-header">Tuesday</li>
                <li class="day-header">Wednesday</li>
                <li class="day-header">Thursday</li>
                <li class="day-header">Friday</li>
                <li class="day-header">Saturday</li>
            </ul>

            <ul runat="server" id="weekPlaceholder"></ul>
        </div>
    </LayoutTemplate>

    <GroupTemplate>
        <ul class="row grid-row">
            <li runat="server" id="dayPlaceholder"></li>
        </ul>
    </GroupTemplate>

    <ItemTemplate>
        <li runat="server" id="liDay" class="day desktop">

            <asp:PlaceHolder runat="server" ID="placeholderEventDayContent" Visible="true">
            <p class="date">
                <span class="month"><%# Eval("AbbreviatedMonth") %></span>
                <%# Eval("Day") %>
            </p>
            <p class="day-of-week"><%# Eval("NamedDayOfWeek") %></p>
            </asp:PlaceHolder>

            <asp:Repeater runat="server" ID="RepeaterSingleDayEvents">
                <HeaderTemplate>
                    <ul class="events">
                </HeaderTemplate>

                <ItemTemplate>
                    <li class="event" runat="server" id="itemSingleEvent">
                        <div class="event-content">
                            <p visible="false" runat="server" id="paragraphChatHeading" class="event-header rs_skip"><%# Eval("EventHeading.Rendered") %></p>
                            <%--<a href="#" class="event-name truncated">Ea Rem Est Unde...</a>--%>
                            <asp:HyperLink runat="server" ID="linkEventName" CssClass="event-name rs_skip" />
                            <p class="event-time"><asp:Literal runat="server" ID="literalEventUTCTime" /></p>

                            <asp:PlaceHolder runat="server" ID="placeholderLive" Visible="false">
                                <asp:HyperLink runat="server" ID="linkToLive" CssClass="button live-now">Live</asp:HyperLink>
                                <asp:HyperLink runat="server" ID="linkMoreInfo" CssClass="button more-info-toggle rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.MoreInformationLabel %></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="linkClose" CssClass="button more-info-toggle close rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.CloseButtonText %></asp:HyperLink>
                            </asp:PlaceHolder>
                        </div>
                        
                        <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                        <div class="event-card rs_skip" style="display: none;">
                            <div class="event-host-info">
                                <div class="event-card-image">
                                    <asp:HyperLink runat="server" ID="linkExpert">
                                        <asp:Image runat="server" ID="imageExpert" />
                                        <div class="image-label">Expert</div>
                                    </asp:HyperLink>
                                </div>
                                <!-- end .event-card-image -->
                                <div class="event-card-host-description">
                                    <h2><asp:Literal runat="server" ID="literalExpertName" /></h2>
                                    <p class="event-card-description"><asp:Literal runat="server" ID="literalExpertTitles" /></p>
                                </div>
                            </div>
                            <!-- end .event-host-info -->
                            <div class="event-actions">
                                <p class="event-card-header"><%# Eval("EventHeading.Rendered") %></p>
                                <p class="event-card-datetime">
                                    <asp:HyperLink runat="server" ID="linkEventDate"><asp:Literal runat="server" ID="literalEventTimeDate" /></asp:HyperLink>
                                </p>
                                <p>
                                    <sc:FieldRenderer ID="frRsvpLink" runat="server" FieldName="RSVP for Event Link" />  
                                </p>
                                <p>
                                    <sc:FieldRenderer ID="frAddToCalendar" runat="server" FieldName="Add To Calendar Link" />  
                                </p>
                                <p>
                                    <asp:HyperLink runat="server" ID="linkEventDetails"><%= UnderstoodDotOrg.Common.DictionaryConstants.EventDetailsLabel %></asp:HyperLink>
                                </p>
                            </div>
                        </div>
                        <!-- END PARTIAL: community/calendar/event_detail_card -->

                    </li>
                </ItemTemplate>

                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

        </li>
    </ItemTemplate>

    <EmptyItemTemplate>
        <li runat="server" class="adjacent-month day desktop" />
    </EmptyItemTemplate>

</asp:ListView>
<!-- END PARTIAL: community/calendar/grid_view -->
