<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpcomingEvents.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.UpcomingEvents" %>
<div class="upcoming-events">
    <div class="row">
        <div class="col col-24">
            <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.UpcomingEventsLabel %></h2>
            <div class="carousel-arrow-wrapper">
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows events next-prev-menu arrows-gray">

                    <%--<a class="view-all" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeAllExpertLiveEventsLabel %></a>--%>
                    <asp:HyperLink runat="server" ID="hypAllEvents" CssClass="view-all">
                    </asp:HyperLink>
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
                                    <asp:HyperLink ID="hlExpertPicture" runat="server">
                                        <asp:Image ID="imgExpert" runat="server" />
                                        <div class="image-label">
                                            Expert
                                        </div>
                                    </asp:HyperLink>
                                </div>
                                <!-- end .event-card-image -->
                                <div class="event-card-content">
                                    <div class="event-card-datetime">
                                        <asp:Literal ID="litEventDate" runat="server" />
                                    </div>
                                    <!-- end .event-card-datetime -->
                                    <div class="event-card-title">
                                        <asp:HyperLink ID="hlEventDetail" runat="server"><sc:FieldRenderer ID="frExpertName" FieldName="Event Heading" runat="server" /></asp:HyperLink>
                                    </div>
                                    <!-- end .event-card-title -->
                                    <div class="card-buttons">
                                        <%--<button type="button" class="button"><asp:Literal ID="litRSVPText" runat="server"></asp:Literal></button>--%>
                                        <button class="action-skip-this"><asp:Literal ID="litSkipThisText" runat="server"></asp:Literal></button>
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
