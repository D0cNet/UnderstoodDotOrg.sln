<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Events.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs.Events" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container flush">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <div id="my-events-tabs" class="tab-container my-events-tabs skiplink-content" aria-role="main">

                <!-- BEGIN PARTIAL: my-events-tabs -->
                <ul class="etabs">
                    <li class="tab upcoming-tab active"><a href="#"><sc:FieldRenderer ID="FieldRenderer1" runat="server" FieldName="Upcoming Events Tab" /></a></li>
                </ul>
                <div class="etabs-dropdown">
                    <select>
                        <option value="upcoming"><sc:FieldRenderer ID="frTopicsCovered" runat="server" FieldName="Upcoming Events Tab" /></option>
                    </select>
                </div>

                <!-- END PARTIAL: my-events-tabs -->

                <div class="panel-container my-events-list">
                    <asp:Repeater ID="rptUpcomingEvents" runat="server" OnItemDataBound="rptUpcomingEvents_ItemDataBound">
                        <ItemTemplate>
                            <div class="row rs_read_this events-tabs-one-rs-wrapper">
                                <div class="col col-4 event-data-top event-data rs_skip">
                                    <span class="event-type"><asp:Literal ID="litType" runat="server"></asp:Literal></span>
                                    <span class="event-month-day"><asp:Literal ID="litDate" runat="server"></asp:Literal></span>
                                    <span class="event-time"><asp:Literal ID="litTime" runat="server"></asp:Literal></span>
                                    <span class="event-year"><asp:Literal ID="litYear" runat="server"></asp:Literal></span>
                                </div>
                                <!-- end .col.col-4 -->

                                <div class="col col-4 event-image">
                                    <img class="foo" alt="FPO content image" src="http://placehold.it/150x150&amp;text=150x150" />
                                    <div id="tomorrowDiv" runat="server" class="tomorrow-overlay">Tomorrow</div>
                                </div>
                                <!-- end .col.col-4 -->

                                <div class="col col-15 offset-1 event-content">
                                    <asp:HyperLink ID="hypTitleLink" runat="server" CssClass="event-title"></asp:HyperLink>
                                    <h4><sc:FieldRenderer ID="frTopicsCovered" runat="server" FieldName="Topics Covered Text" /></h4>
                                    <p class="topics-covered-list"><asp:Literal ID="litIssuesCovered" runat="server"></asp:Literal></p>
                                    <p class="event-links rs_skip"><asp:HyperLink ID="hypEventDetails" runat="server" CssClass="event-details"></asp:HyperLink></p>
                                </div>
                                <!-- end .col.col-15 -->

                                <div class="col col-4 event-data-bottom event-data">
                                    <span class="event-type"><asp:Literal ID="litType2" runat="server"></asp:Literal></span>
                                    <span class="event-month-day"><asp:Literal ID="litDate2" runat="server"></asp:Literal></span>
                                    <span class="event-time"><asp:Literal ID="litTime2" runat="server"></asp:Literal></span>
                                    <span class="event-year"><asp:Literal ID="litYear2" runat="server"></asp:Literal></span>
                                </div>
                                <!-- end .col.col-4 -->
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                <!-- end .panel-container -->
                <%--<div class="showmore-footer">
                    <!-- Show More -->
                    <!-- BEGIN PARTIAL: community/show_more -->
                    <!--Show More-->
                    <div class="container show-more rs_skip">
                        <div class="row">
                            <div class="col col-24">
                                <a class="show-more-link show_more" href="#" data-path="my-account/my-events.upcoming" data-container="my-events-list" data-item="my-event-item" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
                            </div>
                        </div>
                    </div>
                    <!-- .show-more -->
                    <!-- END PARTIAL: community/show_more -->
                    <!-- .show-more -->
                </div>--%>

            </div>
            <!-- end #my-events-tabs .tab-container.my-events-tabs -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
