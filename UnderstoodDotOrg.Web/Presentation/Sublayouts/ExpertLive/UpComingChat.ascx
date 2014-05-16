<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpComingChat.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.UpComingChat" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container event">
    <header class="row">
        <div class="event-container skiplink-feature">
            <ul class="breadcrumbs">
                <p>
                    <li><a href="REPLACE">Back to Sit Nobis 1</a></li>
            </ul>

            <h2 class="rs_read_this"><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></h2>
        </div>
    </header>

    <div class="row">
        <div class="event-container">
            <div class="col-18 col event-content rs_read_this">
                <div class="event-image">
                    <div class="thumbnail">
                        <asp:HyperLink ID="hlLink" runat="server">
                            <sc:FieldRenderer ID="scThumbImg" runat="server" FieldName="Expert Image" />
                            <asp:Image runat="server" ID="imgExpertDefault" ImageUrl="http://placehold.it/150x150" Visible="false" />
                            <div class="image-label">
                                <asp:Literal ID="litGuest" runat="server"></asp:Literal>
                            </div>
                        </asp:HyperLink>
                    </div>

                    <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                    <div class="recommended-for">
                        <p>Recommended for</p>
                        <span class="children-key">
                            <ul>
                                <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                    <!-- END PARTIAL: community/experts_recommended_for -->
                </div>
                <!-- end .event-image -->

                <p class="event-date-time"><%--Fri Nov 3 at 12am EST--%>
                    <asp:Literal runat="server" ID="ltEventDate"></asp:Literal>
                </p>
                <p class="event-host-name"> <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Heading" /></p>
                <p class="event-host-title"><sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="SubHeading" /></p>
               <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />

               <sc:Link ID="scLinkRSVP" runat="server" Field="RSVP for Event" CssClass="button event-rsvp rs_skip"></sc:Link>
                <sc:Link ID="scLinkCalendar" runat="server" Field="Add to My Calendar" CssClass="button event-calendar rs_skip"></sc:Link>

            </div>
            <!-- end .event-content -->
            <div class="col-5 col offset-1 event-sidebar rs_read_this">
                <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                <div class="recommended-for">
                    <p>Recommended for</p>
                    <span class="children-key">
                        <ul>
                            <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>
                </div>
                <!-- END PARTIAL: community/experts_recommended_for -->
            </div>
            <!-- end .event-sidebar -->
        </div>
    </div>
</div>
