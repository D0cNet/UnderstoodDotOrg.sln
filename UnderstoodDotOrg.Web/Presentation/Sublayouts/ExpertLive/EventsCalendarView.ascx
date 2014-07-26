<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventsCalendarView.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.EventsCalendarView" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/ExpertLive/EventFilterNav.ascx" />

<!-- BEGIN PARTIAL: community/calendar/header -->
<div class="container">
    <header class="row calendar-header skiplink-content" aria-role="main">
        <ul class="month-controls arrows-gray">
            <li class="rsArrow rsArrowLeft">
                <a class="rsArrowIcn" href="REPLACE" runat="server" id="linkPreviousMonth"><asp:Literal runat="server" ID="previousMonth" /></a>
            </li>

            <li class="month-name">
                <h2><asp:Literal runat="server" ID="currentMonth" /></h2>
            </li>

            <li class="rsArrow rsArrowRight">
                <a class="rsArrowIcn" href="REPLACE" runat="server" id="linkNextMonth"><asp:Literal runat="server" ID="nextMonth" /></a>
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

    <!-- BEGIN PARTIAL: community/calendar/grid_view -->
<div class="container calendar calendar-grid">
    <ul class="row month-header">
        <li class="day-header">Sunday</li>
        <li class="day-header">Monday</li>
        <li class="day-header">Tuesday</li>
        <li class="day-header">Wednesday</li>
        <li class="day-header">Thursday</li>
        <li class="day-header">Friday</li>
        <li class="day-header">Saturday</li>
    </ul>

    <ul class="row grid-row">
        <li class="adjacent-month day"></li>
        <li class="adjacent-month day"></li>

        <!-- BEGIN PARTIAL: community/calendar/grid_single_event -->
<li class="single live-event day tuesday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>01</p>
    <p class="day-of-week">Tuesday</p>

    
        <span class="children-key">
            <ul>
                <li><i class='child-c' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    

    <div class="event">
        <div class="event-content">
            <p class="event-header">Explicabo Commodi Dolorem</p>
            <a href="#" class="event-name rs_preserve">Omnis Qui Nostrum Incidunt</a>
            <p class="event-time">12am UTC</p>

            <a href="REPLACE" class="button live-now">Live Now</a>
            <a class="button more-info-toggle rs_skip rs_preserve">More Info</a>
            <a class="button more-info-toggle close rs_skip">Close</a>
        </div>
        <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Sed Quia</h2>
            <p class="event-card-description">Provident eveniet animi voluptas aut officia omnis voluptates</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Nobis Earum Voluptatibus</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Similique Id at 12am UTC Fri Nov 15 1991</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
    </div>
  </div>
</li>


<!-- END PARTIAL: community/calendar/grid_single_event -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day wednesday no-events">
    <p class="date"><span class="month">Sep </span>02</p>
    <p class="day-of-week">Wednesday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day thursday no-events">
    <p class="date"><span class="month">Sep </span>03</p>
    <p class="day-of-week">Thursday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day friday no-events">
    <p class="date"><span class="month">Sep </span>04</p>
    <p class="day-of-week">Friday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_multi_events -->
<li class="day multiple-events saturday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>05</p>
    <p class="day-of-week">Saturday</p>

    <ul class="events">
    
        
        
            <li class="event live">
                
                <span class="children-key">
                    <ul>
                        <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
                    </ul>
                </span>
                

                <div class="event-content">
                    <p class="event-header rs_skip">Incidunt Exercitationem Facere</p>
                    <a href="#" class="event-name truncated">Ea Rem Est Unde...</a>
                    <a href="#" class="event-name rs_skip">Corrupti Dolor Quae Illo Veritatis Rerum</a>
                    <p class="event-time">12am UTC</p>

                    <a href="REPLACE" class="button live-now">Live</a>
                    <a class="button more-info-toggle rs_skip">More Info</a>
                    <a class="button more-info-toggle close rs_skip">Close</a>
                </div>
                <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Aut Accusantium</h2>
            <p class="event-card-description">Quod quisquam iure ex velit commodi totam similique</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Quo Fugit at 12am UTC Wed Nov 1 1995</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
            </li>
        
    
    
        
        <li class="event">
            
            <span class="children-key">
                <ul>
                    <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>
            

            <div class="event-content">
                <p class="event-header rs_skip">Error Autem Ut</p>
                <a href="#" class="event-name truncated">Deserunt Fuga Ipsum Voluptatem...</a>
                <a href="REPLACE" class="event-name rs_skip">Earum Voluptas Possimus Amet Velit Odio</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Possimus Qui</h2>
            <p class="event-card-description">Quidem beatae qui libero nihil error aut sed</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Dolore Autem at 12am UTC Thu Jun 3 1993</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
    </ul>
  </div>
</li>
<!-- END PARTIAL: community/calendar/grid_multi_events -->
    </ul>

    <ul class="row grid-row">
        <!-- BEGIN PARTIAL: community/calendar/grid_single_event -->

<li class="single day sunday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>06</p>
    <p class="day-of-week">Sunday</p>

    <div class="event">
        

        <div class="event-content">
            <p class="event-header">Nesciunt Maiores Enim</p>
            <a href="#" class="event-name rs_preserve">Accusantium Molestias Quae Corrupti</a>
            <p class="event-time">12am UTC</p>

            <a class="button more-info-toggle rs_skip rs_preserve">More Info</a>
            <a class="button more-info-toggle close rs_skip">Close</a>
        </div>
        <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>In Asperiores</h2>
            <p class="event-card-description">Et autem facilis architecto ut aliquid dolor animi</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Eaque Quas Esse</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Expedita Maiores at 12am UTC Wed Nov 4 2009</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
    </div>
  </div>
</li>

<!-- END PARTIAL: community/calendar/grid_single_event -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day monday no-events">
    <p class="date"><span class="month">Sep </span>07</p>
    <p class="day-of-week">Monday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day tuesday no-events">
    <p class="date"><span class="month">Sep </span>08</p>
    <p class="day-of-week">Tuesday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_single_event -->

<li class="single day wednesday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>09</p>
    <p class="day-of-week">Wednesday</p>

    <div class="event">
        

        <div class="event-content">
            <p class="event-header">Aut Ratione Quod</p>
            <a href="#" class="event-name rs_preserve">Sequi Aperiam Quibusdam Quia</a>
            <p class="event-time">12am UTC</p>

            <a class="button more-info-toggle rs_skip rs_preserve">More Info</a>
            <a class="button more-info-toggle close rs_skip">Close</a>
        </div>
        <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Eius Minus</h2>
            <p class="event-card-description">Et ratione et voluptas voluptates est tempore magnam</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Molestiae Suscipit Et</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Et Enim at 12am UTC Mon Jan 17 1994</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
    </div>
  </div>
</li>

<!-- END PARTIAL: community/calendar/grid_single_event -->
        <!-- BEGIN PARTIAL: community/calendar/grid_multi_events -->
<li class="day multiple-events thursday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>10</p>
    <p class="day-of-week">Thursday</p>

    <ul class="events">
    
        
        <li class="event">
            

            <div class="event-content">
                <p class="event-header rs_skip">Quia Voluptatem Rerum</p>
                <a href="#" class="event-name truncated">Dolores Perferendis Et Possimus...</a>
                <a href="REPLACE" class="event-name rs_skip">Eligendi Nemo Laboriosam Et In Eius</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Corrupti Qui</h2>
            <p class="event-card-description">Corporis adipisci ut et debitis adipisci ullam qui</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Pariatur Sint Iure</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Dolore Fugiat at 12am UTC Tue May 2 2000</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            

            <div class="event-content">
                <p class="event-header rs_skip">Dolores Rerum Ullam</p>
                <a href="#" class="event-name truncated">Architecto Et Ipsa Consequuntur...</a>
                <a href="REPLACE" class="event-name rs_skip">Occaecati Molestiae Mollitia Impedit Incidunt Nihil</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Consectetur Quibusdam</h2>
            <p class="event-card-description">Sint est alias aliquid consectetur vel cupiditate dicta</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Enim Rerum Mollitia</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Assumenda Doloribus at 12am UTC Sat Aug 10 1996</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
    </ul>
  </div>
</li>
<!-- END PARTIAL: community/calendar/grid_multi_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day friday no-events">
    <p class="date"><span class="month">Sep </span>11</p>
    <p class="day-of-week">Friday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_multi_events -->
<li class="day multiple-events saturday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>12</p>
    <p class="day-of-week">Saturday</p>

    <ul class="events">
    
        
        <li class="event">
            
            <span class="children-key">
                <ul>
                    <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>
            

            <div class="event-content">
                <p class="event-header rs_skip">Assumenda Culpa Expedita</p>
                <a href="#" class="event-name truncated">Eveniet Eum Nihil Eum...</a>
                <a href="REPLACE" class="event-name rs_skip">Illo Sit Perferendis Rerum Vel Quia</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>A Omnis</h2>
            <p class="event-card-description">Modi maiores fuga reprehenderit at qui beatae labore</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Eos Molestiae Qui</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Maiores Rerum at 12am UTC Thu Jan 18 2001</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            
            <span class="children-key">
                <ul>
                    <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>
            

            <div class="event-content">
                <p class="event-header rs_skip">Cupiditate Nisi Libero</p>
                <a href="#" class="event-name truncated">Est Illum Quas Cum...</a>
                <a href="REPLACE" class="event-name rs_skip">In Nihil Iste Et Nesciunt Voluptas</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Atque Nulla</h2>
            <p class="event-card-description">Autem aut est numquam quisquam commodi voluptas ut</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Consequuntur Officia Enim</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Dicta Fugiat at 12am UTC Thu Aug 24 2000</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            
            <span class="children-key">
                <ul>
                    <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>
            

            <div class="event-content">
                <p class="event-header rs_skip">Quaerat Voluptatem Qui</p>
                <a href="#" class="event-name truncated">Iusto Omnis Totam Odio...</a>
                <a href="REPLACE" class="event-name rs_skip">Nihil Mollitia Iure Accusamus Deserunt Vero</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Omnis Illum</h2>
            <p class="event-card-description">Ab modi quas eum natus nisi tenetur consequuntur</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Et Reiciendis Maiores</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Sit Voluptatem at 12am UTC Wed Dec 1 1993</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
    </ul>
  </div>
</li>
<!-- END PARTIAL: community/calendar/grid_multi_events -->
    </ul>

    <ul class="row grid-row">
        <!-- BEGIN PARTIAL: community/calendar/grid_single_event -->

<li class="single day sunday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>13</p>
    <p class="day-of-week">Sunday</p>

    <div class="event">
        
        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
        

        <div class="event-content">
            <p class="event-header">Quo Distinctio Accusamus</p>
            <a href="#" class="event-name rs_preserve">Occaecati Sint Quia Et</a>
            <p class="event-time">12am UTC</p>

            <a class="button more-info-toggle rs_skip rs_preserve">More Info</a>
            <a class="button more-info-toggle close rs_skip">Close</a>
        </div>
        <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Est Harum</h2>
            <p class="event-card-description">Maiores sit aut inventore repellat illum optio minima</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Accusantium Soluta Nihil</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Facere Omnis at 12am UTC Wed Nov 17 2004</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
    </div>
  </div>
</li>

<!-- END PARTIAL: community/calendar/grid_single_event -->
        <!-- BEGIN PARTIAL: community/calendar/grid_multi_events -->
<li class="day multiple-events monday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>14</p>
    <p class="day-of-week">Monday</p>

    <ul class="events">
    
        
        <li class="event">
            
            <span class="children-key">
                <ul>
                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>
            

            <div class="event-content">
                <p class="event-header rs_skip">Eos Ut Labore</p>
                <a href="#" class="event-name truncated">Quis Sed Id Et...</a>
                <a href="REPLACE" class="event-name rs_skip">Iure Veritatis Et Perferendis Et Architecto</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Odio Adipisci</h2>
            <p class="event-card-description">Adipisci error eveniet labore ut eius dolorum et</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Ut Ratione Perspiciatis</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Necessitatibus Sunt at 12am UTC Fri Feb 14 1997</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            
            <span class="children-key">
                <ul>
                    <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>
            

            <div class="event-content">
                <p class="event-header rs_skip">Qui Id Mollitia</p>
                <a href="#" class="event-name truncated">Sed Eum Ab Impedit...</a>
                <a href="REPLACE" class="event-name rs_skip">Soluta Sed Assumenda Assumenda Est Et</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Exercitationem Et</h2>
            <p class="event-card-description">Impedit temporibus voluptatum dignissimos consequatur iure voluptatem voluptas</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Ex In Nobis</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Quisquam Tenetur at 12am UTC Sat Oct 27 1990</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            
            <span class="children-key">
                <ul>
                    <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>
            

            <div class="event-content">
                <p class="event-header rs_skip">Id Consequatur Labore</p>
                <a href="#" class="event-name truncated">Cum Sit Aut Odit...</a>
                <a href="REPLACE" class="event-name rs_skip">Temporibus Inventore Explicabo Odio Nulla Cupiditate</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Est Et</h2>
            <p class="event-card-description">Fugiat fugiat suscipit ut consequatur nemo consectetur quidem</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Dolorum Nihil at 12am UTC Sun Aug 30 2009</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-c' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
    </ul>
  </div>
</li>
<!-- END PARTIAL: community/calendar/grid_multi_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day tuesday no-events">
    <p class="date"><span class="month">Sep </span>15</p>
    <p class="day-of-week">Tuesday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day wednesday no-events">
    <p class="date"><span class="month">Sep </span>16</p>
    <p class="day-of-week">Wednesday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_multi_events -->
<li class="day multiple-events thursday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>17</p>
    <p class="day-of-week">Thursday</p>

    <ul class="events">
    
        
        <li class="event">
            

            <div class="event-content">
                <p class="event-header rs_skip">Beatae Incidunt Quia</p>
                <a href="#" class="event-name truncated">Ea Impedit Quasi Odio...</a>
                <a href="REPLACE" class="event-name rs_skip">Sit Rerum Cum Dolores Officiis Quia</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Pariatur Quis</h2>
            <p class="event-card-description">Architecto error est corporis voluptatem consequatur similique quis</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Voluptatem Consequatur at 12am UTC Fri Apr 11 2008</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            

            <div class="event-content">
                <p class="event-header rs_skip">Et Corrupti Est</p>
                <a href="#" class="event-name truncated">Non Velit Enim Sed...</a>
                <a href="REPLACE" class="event-name rs_skip">Quo Tenetur Nihil Culpa Corrupti Et</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Modi Voluptas</h2>
            <p class="event-card-description">Id et eveniet non ipsam quo dolores enim</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Vel Aut at 12am UTC Wed Mar 19 1997</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            

            <div class="event-content">
                <p class="event-header rs_skip">Necessitatibus Delectus Laborum</p>
                <a href="#" class="event-name truncated">Fugit Voluptates Odit Tempore...</a>
                <a href="REPLACE" class="event-name rs_skip">Eos Quis Enim Similique Similique Nobis</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Non Placeat</h2>
            <p class="event-card-description">Cum ullam aut quasi commodi placeat et molestiae</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Magnam Suscipit at 12am UTC Fri Mar 28 2008</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
    </ul>
  </div>
</li>
<!-- END PARTIAL: community/calendar/grid_multi_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day friday no-events">
    <p class="date"><span class="month">Sep </span>18</p>
    <p class="day-of-week">Friday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_multi_events -->
<li class="day multiple-events saturday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>19</p>
    <p class="day-of-week">Saturday</p>

    <ul class="events">
    
        
        <li class="event">
            

            <div class="event-content">
                <p class="event-header rs_skip">Saepe Eligendi Eum</p>
                <a href="#" class="event-name truncated">In Sed Cupiditate Quod...</a>
                <a href="REPLACE" class="event-name rs_skip">Adipisci Qui Consequatur Laboriosam Laborum Possimus</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Sequi Minus</h2>
            <p class="event-card-description">Qui sequi ea et facilis illum dolorem officia</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Voluptates Et at 12am UTC Sun Apr 23 2000</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            

            <div class="event-content">
                <p class="event-header rs_skip">Aliquam Et Totam</p>
                <a href="#" class="event-name truncated">Rem Nihil Ab Consequatur...</a>
                <a href="REPLACE" class="event-name rs_skip">Quia Ipsam Ea Aut Occaecati Consequuntur</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Eaque Consequatur</h2>
            <p class="event-card-description">Eum ea eligendi sint optio modi ratione occaecati</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Ex Voluptas at 12am UTC Tue Aug 25 1998</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
    </ul>
  </div>
</li>
<!-- END PARTIAL: community/calendar/grid_multi_events -->
    </ul>

    <ul class="row grid-row">
        <!-- BEGIN PARTIAL: community/calendar/grid_single_event -->

<li class="single day sunday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>20</p>
    <p class="day-of-week">Sunday</p>

    <div class="event">
        
        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
        

        <div class="event-content">
            <p class="event-header">Provident Enim Quis</p>
            <a href="#" class="event-name rs_preserve">Aut Ullam Quisquam Quia</a>
            <p class="event-time">12am UTC</p>

            <a class="button more-info-toggle rs_skip rs_preserve">More Info</a>
            <a class="button more-info-toggle close rs_skip">Close</a>
        </div>
        <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Dolor Qui</h2>
            <p class="event-card-description">Itaque aut animi laudantium enim non ex tenetur</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Iusto Et at 12am UTC Tue Aug 9 2005</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
    </div>
  </div>
</li>

<!-- END PARTIAL: community/calendar/grid_single_event -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day monday no-events">
    <p class="date"><span class="month">Sep </span>21</p>
    <p class="day-of-week">Monday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day tuesday no-events">
    <p class="date"><span class="month">Sep </span>22</p>
    <p class="day-of-week">Tuesday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day wednesday no-events">
    <p class="date"><span class="month">Sep </span>23</p>
    <p class="day-of-week">Wednesday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_multi_events -->
<li class="day multiple-events thursday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>24</p>
    <p class="day-of-week">Thursday</p>

    <ul class="events">
    
        
        <li class="event">
            

            <div class="event-content">
                <p class="event-header rs_skip">Illum Velit Eos</p>
                <a href="#" class="event-name truncated">Ut Cum Esse Sequi...</a>
                <a href="REPLACE" class="event-name rs_skip">Exercitationem Ut Id Qui Nihil Voluptatem</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Commodi Eveniet</h2>
            <p class="event-card-description">Voluptatem odit et illum temporibus placeat error dolorem</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Quaerat Nobis Illum</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Nisi Repellat at 12am UTC Mon Mar 9 1998</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            

            <div class="event-content">
                <p class="event-header rs_skip">Mollitia Est Debitis</p>
                <a href="#" class="event-name truncated">Enim Quia Beatae Qui...</a>
                <a href="REPLACE" class="event-name rs_skip">Enim Nostrum Deserunt Et Velit Et</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Et Quibusdam</h2>
            <p class="event-card-description">Ipsum id perspiciatis reprehenderit eum est delectus esse</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Id Nihil at 12am UTC Thu Jul 15 1999</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
    </ul>
  </div>
</li>
<!-- END PARTIAL: community/calendar/grid_multi_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day friday no-events">
    <p class="date"><span class="month">Sep </span>25</p>
    <p class="day-of-week">Friday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_multi_events -->
<li class="day multiple-events saturday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>26</p>
    <p class="day-of-week">Saturday</p>

    <ul class="events">
    
        
        <li class="event">
            
            <span class="children-key">
                <ul>
                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>
            

            <div class="event-content">
                <p class="event-header rs_skip">Exercitationem Facere Qui</p>
                <a href="#" class="event-name truncated">Autem Quia Ea Rerum...</a>
                <a href="REPLACE" class="event-name rs_skip">Deserunt Sed Laboriosam Consequuntur Quia Blanditiis</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Voluptates Repellat</h2>
            <p class="event-card-description">Est fugiat quo hic aut aut laboriosam animi</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Ullam Veritatis at 12am UTC Tue Jan 26 1999</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            
            <span class="children-key">
                <ul>
                    <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>
            

            <div class="event-content">
                <p class="event-header rs_skip">Eaque Quos Nihil</p>
                <a href="#" class="event-name truncated">Natus Soluta Voluptatem Omnis...</a>
                <a href="REPLACE" class="event-name rs_skip">Placeat Ducimus Ullam Eos Qui Qui</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Laboriosam Qui</h2>
            <p class="event-card-description">Enim necessitatibus similique facere ad in impedit sequi</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Ullam Est Itaque</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Autem In at 12am UTC Fri Mar 15 2002</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
        
        <li class="event">
            
            <span class="children-key">
                <ul>
                    <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>
            

            <div class="event-content">
                <p class="event-header rs_skip">A Odio Neque</p>
                <a href="#" class="event-name truncated">Voluptatem Et Consequatur Ullam...</a>
                <a href="REPLACE" class="event-name rs_skip">Nam Occaecati Quod Et Et Pariatur</a>
                <p class="event-time">12am UTC</p>

                <a class="button more-info-toggle rs_skip">More Info</a>
                <a class="button more-info-toggle close rs_skip">Close</a>
            </div>
            <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Ab Quae</h2>
            <p class="event-card-description">Qui voluptas perferendis accusamus molestiae in maiores eligendi</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-header">Error Delectus Reprehenderit</p>
        
        <p class="event-card-datetime"><a href="REPLACE">Et Ut at 12am UTC Sun Jan 25 2004</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
        </li>
        
        
    
    
    </ul>
  </div>
</li>
<!-- END PARTIAL: community/calendar/grid_multi_events -->
    </ul>

    <ul class="row grid-row">
        <!-- BEGIN PARTIAL: community/calendar/grid_single_event -->

<li class="single day sunday">
  <div class="rs_read_this">
    <p class="date"><span class="month">Sep </span>27</p>
    <p class="day-of-week">Sunday</p>

    <div class="event">
        
        <span class="children-key">
            <ul>
                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
        

        <div class="event-content">
            <p class="event-header">Facilis Dolor Totam</p>
            <a href="#" class="event-name rs_preserve">Et Esse Id Praesentium</a>
            <p class="event-time">12am UTC</p>

            <a class="button more-info-toggle rs_skip rs_preserve">More Info</a>
            <a class="button more-info-toggle close rs_skip">Close</a>
        </div>
        <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
<div class="event-card rs_skip">
    <div class="event-host-info">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                  Guest Expert
                </div>
            </a>
        </div><!-- end .event-card-image -->
        <div class="event-card-host-description">
            <h2>Maiores Quia</h2>
            <p class="event-card-description">Dolores qui quam officiis sint fuga quia assumenda</p>
        </div>
    </div><!-- end .event-host-info -->

    <div class="event-actions">
        
        <p class="event-card-datetime"><a href="REPLACE">Voluptas Dolorem at 12am UTC Thu Mar 18 1993</a></p>
        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

        <span class="children-key">
            <ul>
                <li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
            </ul>
        </span>
    </div>
</div>
<!-- END PARTIAL: community/calendar/event_detail_card -->
    </div>
  </div>
</li>

<!-- END PARTIAL: community/calendar/grid_single_event -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day monday no-events">
    <p class="date"><span class="month">Sep </span>28</p>
    <p class="day-of-week">Monday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day wednesday no-events">
    <p class="date"><span class="month">Sep </span>29</p>
    <p class="day-of-week">Wednesday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <!-- BEGIN PARTIAL: community/calendar/grid_no_events -->
<li class="day thursday no-events">
    <p class="date"><span class="month">Sep </span>30</p>
    <p class="day-of-week">Thursday</p>
</li>
<!-- END PARTIAL: community/calendar/grid_no_events -->
        <li class="adjacent-month day"></li>
        <li class="adjacent-month day"></li>
        <li class="adjacent-month day"></li>
    </ul>
</div>

<!-- END PARTIAL: community/calendar/grid_view -->

    <div class="container">
        <div class="row">
            <a class="google-calendar-subscribe" href="REPLACE">Subscribe to calendar in Google Calendar</a>
        </div>
    </div>

<!-- BEGIN PARTIAL: children-key -->
<!--
<div class="container child-content-indicator ">
  <!-- Key
  <div class="row">
    <div class="col col-23 offset-1">
      <div class="children-key" aria-hidden="true">
        <ul>
          <li><i class="child-a"></i>for Michael</li>
          <li><i class="child-b"></i>for Elizabeth</li>
          <li><i class="child-c"></i>for Ethan</li>
          <li><i class="child-d"></i>for Jeremy</li>
          <li><i class="child-e"></i>for Franklin</li>
        </ul>
      </div><!-- .children-key
    </div><!-- .col
  </div><!-- .row
</div><!-- .child-content-indicator -->
<!-- END PARTIAL: children-key -->