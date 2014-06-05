﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpcomingEvents.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.UpcomingEvents" %>
<div class="upcoming-events">
    <div class="row">
        <div class="col col-24">
            <h2>Upcoming Events</h2>
            <div class="carousel-arrow-wrapper">
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows events next-prev-menu arrows-gray">

                    <a class="view-all" href="REPLACE">See all expert live events</a>

                    <div class="rsArrow rsArrowLeft">
                        <button class="rsArrowIcn"></button>
                    </div>
                    <div class="rsArrow rsArrowRight">
                        <button class="rsArrowIcn"></button>
                    </div>
                </div>
                <!-- end .arrows -->
                <!-- END PARTIAL: community/carousel_arrows -->
            </div>
            <div class="row event-cards">
                <asp:Repeater ID="rptEvents" runat="server">
                    <ItemTemplate>
                        <!-- BEGIN PARTIAL: community/event_card -->
                        <div class="col col-11 event-card">
                            <div class="event-card-info group">
                                <div class="event-card-image">
                                    <a href="REPLACE">
                                        <asp:Image ID="imgExpert" runat="server" />
                                        <div class="image-label">
                                            Expert
                                        </div>
                                    </a>
                                </div>
                                <!-- end .event-card-image -->
                                <div class="event-card-content">
                                    <div class="event-card-datetime">
                                        <asp:Literal ID="litEventDate" runat="server" />
                                    </div>
                                    <!-- end .event-card-datetime -->
                                    <div class="event-card-title">
                                        <asp:HyperLink ID="hlEventDetail" runat="server">Chat with<br /><sc:FieldRenderer ID="frExpertName" FieldName="Expert Name" runat="server" /></asp:HyperLink>
                                    </div>
                                    <!-- end .event-card-title -->
                                    <div class="card-buttons">
                                        <button type="button" class="button">RSVP</button>
                                        <button class="action-skip-this">Skip this</button>
                                    </div>
                                    <!-- end .card-buttons -->
                                </div>
                                <!-- end .event-card-content -->
                            </div>
                            <!-- end .event-card-info -->
                        </div>
                        <!-- end .event-card -->
                        <!-- END PARTIAL: community/event_card -->
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <!-- end .event-cards -->
        </div>
        <!-- end .upcoming-events -->
    </div>
    <!-- end .row -->
</div>
<!-- end .upcoming-events -->
