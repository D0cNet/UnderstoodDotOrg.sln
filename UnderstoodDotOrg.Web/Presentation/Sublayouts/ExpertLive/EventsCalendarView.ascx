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
            
            <li style="border-right: 0px !important;">Calendar View</li>
            <!--
            <li><a href="REPLACE">List View</a></li>
            -->
            
        </ul>
    </header>
</div>
<!-- END PARTIAL: community/calendar/header -->

<style type="text/css">
    li.day {
        height: 237px !important;
    }
</style>

<!-- BEGIN PARTIAL: community/calendar/grid_view -->
<asp:ListView runat="server" ID="EventsLiveCalendarView" GroupItemCount="7" GroupPlaceholderID="weekPlaceholder" ItemPlaceholderID="dayPlaceholder"
        ItemDataBound="EventsLiveCalendarView_ItemDataBound">

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
                    <li class="event" runat="server" id="eventItem">
                        <div class="event-content">
                            <p class="event-header rs_skip"><%# Eval("EventHeading") %></p>
                            <a href="#" class="event-name truncated">Ea Rem Est Unde...</a>
                            <a href="#" class="event-name rs_skip">Corrupti Dolor Quae Illo Veritatis Rerum</a>
                            <p class="event-time"><asp:Literal runat="server" ID="literalEventUTCTime" /></p>
                            <a href="REPLACE" class="button live-now">Live</a>
                            <a class="button more-info-toggle rs_skip">More Info</a>
                            <a class="button more-info-toggle close rs_skip">Close</a>
                        </div>
                        
                        <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                        <div class="event-card rs_skip" style="display: none;">
                            <div class="event-host-info">
                                <div class="event-card-image">
                                    <a href="REPLACE">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="image-label"><%# Eval("Expert.Rendered") %></div>
                                    </a>
                                </div>
                                <!-- end .event-card-image -->
                                <div class="event-card-host-description">
                                    <h2><%# Eval("ContentPage.PageTitle.Rendered") %></h2>
                                    <p class="event-card-description"><%# Eval("ContentPage.BodyContent.Rendered") %></p>
                                </div>
                            </div>
                            <!-- end .event-host-info -->
                            <div class="event-actions">
                                <p class="event-card-header"><%# Eval("EventHeading") %></p>
                                <p class="event-card-datetime">
                                    <a href="REPLACE"><asp:Literal runat="server" ID="literalEventTimeDate" /></a>
                                </p>
                                <p>
                                  <a class="event-rsvp" href="<%# Eval("RSVPforEventLink") %>">RSVP for this event</a>
                                </p>
                                <p>
                                    <a class="add-to-calendar" href="<%# Eval("AddToCalendarLink") %>">Add to my calendar</a>
                                </p>
                                <p>
                                    <a class="event-details-link" href="REPLACE">Event details</a>
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
