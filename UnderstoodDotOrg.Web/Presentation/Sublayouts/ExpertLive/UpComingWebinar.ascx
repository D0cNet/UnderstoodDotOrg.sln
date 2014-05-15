<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpComingWebinar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.UpComingWebinar" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<div class="container event">
    <header class="row">
        <div class="event-container skiplink-feature">
            <ul class="breadcrumbs">
                <p>
                    <li><a href="REPLACE">Back to Ut Fugit</a></li>
            </ul>

            <h2 class="rs_read_this">
                <sc:FieldRenderer ID="frPageTItle" runat="server" FieldName="Page Title" />
            </h2>
        </div>
    </header>

    <div class="row">
        <div class="event-container">
            <div class="col-18 col event-content rs_read_this">
                <div class="event-image">
                    <div class="thumbnail">
                        <asp:HyperLink ID="hlLink" runat="server">
                            <sc:Image ID="scThumbImg" runat="server" />
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
                                <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                    <!-- END PARTIAL: community/experts_recommended_for -->
                </div>
                <!-- end .event-image -->

                <sc:Date ID="scDate" runat="server" Field="Event Date" />
                <p class="event-host-name">
                    <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Heading" />
                </p>

                <p class="event-host-title">
                    <sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="SubHeading" />
                </p>
                <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body" />

                <asp:HyperLink ID="hlRSVPLink" runat="server" CssClass="button event-rsvp rs_skip"></asp:HyperLink>
                <asp:HyperLink ID="hlCalendarLink" runat="server" CssClass="button event-calendar rs_skip"></asp:HyperLink>

            </div>
            <!-- end .event-content -->
            <div class="col-5 col offset-1 event-sidebar">
                <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                <div class="recommended-for">
                    <p>Recommended for</p>
                    <span class="children-key">
                        <ul>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>
                </div>
                <!-- END PARTIAL: community/experts_recommended_for -->
            </div>
            <!-- end .event-sidebar -->
        </div>
    </div>
</div>

<div class="container events-chat">
    <div class="row skiplink-content" aria-role="main">
        <div class="container">
            <div class="col col-11 offset-1 event-cards">
                <div class="rs_read_this event-cards-heading-rs-wrapper">
                    <h2>Upcoming Webinars</h2>
                    <p class="subhead">Get info direct from thought leaders</p>
                </div>
                <!-- BEGIN PARTIAL: community/experts_event_card -->

                <div class="event-card col-22 offset-2">
                    <div class="event-card-info group rs_read_this">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Expert
               
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <div class="event-card-datetime">
                                Mon Dec 12 at 12am EST
           
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Eaque Minima Dolorum Eos Minima Quia Eos Necessitatibus Aut Sed</a>
                            </div>
                            <!-- end .event-card-title -->
                        </div>
                        <!-- end .event-card-details -->
                    </div>
                    <!-- end .event-card-info -->
                </div>
                <!-- end .event-card -->
                <!-- END PARTIAL: community/experts_event_card -->
            </div>
            <!-- end .event-cards -->

            <div class="col col-11 offset-1 event-cards">
                <div class="rs_read_this event-cards-heading-rs-wrapper">
                    <h2>Chat with an Expert</h2>
                    <p class="subhead">Ask questions and get answers live!</p>
                </div>
                <!-- BEGIN PARTIAL: community/experts_chat_card -->

                <div class="event-card col-22 offset-2">
                    <div class="event-card-info group rs_read_this">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Expert
               
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <div class="event-card-datetime">
                                Wed Oct 12 at 12am EDT
           
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Illo Iusto Est Vitae</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-host-title">est nihil est qui porro ex</p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>
                    <!-- end .event-card-info -->
                </div>
                <!-- end .event-card -->
                <!-- END PARTIAL: community/experts_chat_card -->
            </div>
            <!-- end .event-cards -->
        </div>
    </div>

    <div class="row calendar-button">
        <a class="button rs_skip" href="REPLACE">See Calendar</a>
    </div>
</div>
<!-- end .events-chat -->

<div class="container archive upcoming-webinar">
    <div class="row">
        <header class="col col-24 rs_read_this">
            <h2>From the Archive</h2>

            <fieldset class="archive-search-form">
                <label for="search-archive-text" class="visuallyhidden" aria-hidden="true">Search archive</label>
                <input type="text" class="archive-search" id="search-archive-text" name="search-archive" placeholder="Search archive" />
                <input class="search-button" type="submit" value="Go">
            </fieldset>
        </header>
    </div>

    <!-- BEGIN PARTIAL: community/experts_archive_card -->
    <div class="event-cards">
        <div class="row">
            <div class="event-card rs_read_this">
                <div class="event-card-info group">
                    <div class="event-card-image col equalize   ">
                        <a href="REPLACE">
                            <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                            <span class="visuallyhidden">play button</span>
                            <div class="image-label">
                                Expert
                       
                            </div>
                        </a>
                    </div>
                    <!-- end .event-card-image -->
                    <div class="event-card-details col equalize">
                        <div class="event-card-title">
                            <a href="REPLACE">Nisi Neque Quia Cumque Molestiae Aut Perspiciatis Minima Tempore Consectetur</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Topics Covered</p>
                        <p class="event-card-topics">Itaque Qui Voluptatem Sunt Aspernatur Nesciunt Adipisci Doloremque Quis Eos</p>
                        <span class="children-key">
                            <ul>
                                <li><i class="child-a" title="CHILD NAME HERE"></i></li>
                                <li><i class="child-b" title="CHILD NAME HERE"></i></li>
                            </ul>
                        </span>
                    </div>
                    <!-- end .event-card-details -->
                    <div class="event-card-date-details col equalize">
                        <p class="event-type">Webinar</p>
                        <p class="event-date">2</p>
                        <p class="event-date-sub">days ago</p>
                    </div>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
        </div>

        <div class="row">
            <div class="event-card rs_read_this">
                <div class="event-card-info group">
                    <div class="event-card-image col equalize   ">
                        <a href="REPLACE">
                            <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                            <span class="visuallyhidden">play button</span>
                            <div class="image-label">
                                Expert
                       
                            </div>
                        </a>
                    </div>
                    <!-- end .event-card-image -->
                    <div class="event-card-details col equalize">
                        <div class="event-card-title">
                            <a href="REPLACE">Sit Minima Illum Occaecati Dolorem Nobis Quae Vel Ab Consequatur</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Top Questions</p>
                        <p class="event-card-topics">Modi Mollitia Veritatis Et Et Optio Non Et Voluptas Sed</p>
                        <span class="children-key">
                            <ul>
                                <li><i class="child-a" title="CHILD NAME HERE"></i></li>
                                <li><i class="child-b" title="CHILD NAME HERE"></i></li>
                            </ul>
                        </span>
                    </div>
                    <!-- end .event-card-details -->
                    <div class="event-card-date-details col equalize">
                        <p class="event-type">Chat</p>
                        <p class="event-date">Sept 30</p>
                        <p class="event-date-sub">2014</p>
                    </div>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
        </div>
    </div>
    <!-- end .event-cards -->
    <!-- END PARTIAL: community/experts_archive_card -->

    <div class="container child-content-indicator">
        <!-- Key -->
        <div class="row">
            <a href="REPLACE" class="button see-archive rs_skip">See Archive</a>

            <div class="children-key" aria-hidden="true">
                <ul>
                    <li><i class="child-a"></i>for Michael</li>
                    <li><i class="child-b"></i>for Elizabeth</li>
                    <li><i class="child-c"></i>for Ethan</li>
                    <li><i class="child-d"></i>for Jeremy</li>
                </ul>
            </div>
            <!-- .children-key -->
        </div>
        <!-- .row -->
    </div>
    <!-- .child-content-indicator -->

</div>
<!-- BEGIN PARTIAL: footer -->


