<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsLiveCalendar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Experts.ExpertsLiveCalendar" %>
<!-- BEGIN PARTIAL: community/experts_sub_nav -->
<div class="container">
    <div class="row">
        <div class="container">
            <div class="experts-nav-form clearfix skiplink-toolbar">
                <div class="dropdown">
                    <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                        <span class="current-page">Filter By: Calendar</span>
                        <span class="dropdown-title">Filter By</span>
                    </a>
                    <ul class="dropdown-menu" role="menu">

                        <li role="presentation" class="">
                            <a role="menuitem" href="REPLACE">Featured</a>
                        </li>

                        <li role="presentation" class="">
                            <a role="menuitem" href="REPLACE">Recommended</a>
                        </li>

                        <li role="presentation" class="current-page">
                            <a role="menuitem" href="REPLACE">Calendar</a>
                        </li>

                        <li role="presentation" class="">
                            <a role="menuitem" href="REPLACE">Archive</a>
                        </li>

                    </ul>
                </div>

                <select name="experts-nav-issue" id="experts-nav-issue" aria-required="true">
                    <option value="">Child's Issue</option>
                    <option>Grade 1</option>
                    <option>Grade 2</option>
                    <option>Grade 3</option>
                    <option>Grade 4</option>
                </select>

                <select name="experts-nav-grade" id="experts-nav-grade" aria-required="true">
                    <option value="">Grade</option>
                    <option>Grade 1</option>
                    <option>Grade 2</option>
                    <option>Grade 3</option>
                    <option>Grade 4</option>
                </select>

                <select name="experts-nav-topic" id="experts-nav-topic" aria-required="true">
                    <option value="">Topic</option>
                    <option>Grade 1</option>
                    <option>Grade 2</option>
                    <option>Grade 3</option>
                    <option>Grade 4</option>
                </select>


            </div>
            <!-- experts-nav-form -->
        </div>
    </div>
</div>
<!-- END PARTIAL: community/experts_sub_nav -->
<!-- BEGIN PARTIAL: community/calendar/header -->
<div class="container">
    <header class="row calendar-header skiplink-content" aria-role="main">
        <ul class="month-controls arrows-gray">
            <li class="rsArrow rsArrowLeft">
                <a class="rsArrowIcn" href="REPLACE" title="August 2014">August 2014</a>
            </li>

            <li class="month-name">
                <h2>September 2014</h2>
            </li>

            <li class="rsArrow rsArrowRight">
                <a class="rsArrowIcn" href="REPLACE" title="October 2014">October 2014</a>
            </li>
        </ul>

        <ul class="calendar-type">

            <li>Calendar View</li>
            <li><a href="REPLACE">List View</a></li>

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
            <p class="date"><span class="month">Sep </span>01</p>
            <p class="day-of-week">Tuesday</p>


            <span class="children-key">
                <ul>
                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>


            <div class="event">
                <div class="event-content">
                    <p class="event-header">Perferendis Eum Et</p>
                    <a href="#" class="event-name">Sint Deleniti Enim Laudantium</a>
                    <p class="event-time">12am UTC</p>

                    <a href="REPLACE" class="button live-now">Live Now</a>
                    <a class="button more-info-toggle">More Info</a>
                    <a class="button more-info-toggle close">Close</a>
                </div>
                <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                <div class="event-card">
                    <div class="event-host-info">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-host-description">
                            <h2>Rerum Laboriosam</h2>
                            <p class="event-card-description">Nulla placeat excepturi rem ut ut nihil maiores</p>
                        </div>
                    </div>
                    <!-- end .event-host-info -->

                    <div class="event-actions">

                        <p class="event-card-datetime"><a href="REPLACE">Dolor Aspernatur at 12am UTC Sun Apr 28 1996</a></p>
                        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                        <span class="children-key">
                            <ul>
                                <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                </div>
                <!-- END PARTIAL: community/calendar/event_detail_card -->
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
            <p class="date"><span class="month">Sep </span>05</p>
            <p class="day-of-week">Saturday</p>

            <ul class="events">



                <li class="event live">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Eligendi Aspernatur Magnam</p>
                        <a href="#" class="event-name truncated">Vel Tenetur Qui Voluptate...</a>
                        <a href="#" class="event-name">Aliquid Nam Quisquam Fugit Eos Impedit</a>
                        <p class="event-time">12am UTC</p>

                        <a href="REPLACE" class="button live-now">Live</a>
                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Guest Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Qui Quam</h2>
                                <p class="event-card-description">Quod in cumque voluptas voluptas id dolor natus</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Ut Quisquam Asperiores</p>

                            <p class="event-card-datetime"><a href="REPLACE">Alias Enim at 12am UTC Thu Sep 2 1993</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>




                <li class="event">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Autem Quia Porro</p>
                        <a href="#" class="event-name truncated">Consequatur Voluptatem Nulla Ullam...</a>
                        <a href="REPLACE" class="event-name">Dolorem Voluptatibus Nobis Aut Aperiam Eius</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Odit Dolorem</h2>
                                <p class="event-card-description">Perferendis quae sapiente sit ipsum ullam amet natus</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Similique Aliquid Est</p>

                            <p class="event-card-datetime"><a href="REPLACE">Beatae Rerum at 12am UTC Mon Sep 18 2000</a></p>
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
        </li>
        <!-- END PARTIAL: community/calendar/grid_multi_events -->
    </ul>

    <ul class="row grid-row">
        <!-- BEGIN PARTIAL: community/calendar/grid_single_event -->

        <li class="single day sunday">
            <p class="date"><span class="month">Sep </span>06</p>
            <p class="day-of-week">Sunday</p>

            <div class="event">


                <div class="event-content">
                    <p class="event-header">Sit Voluptatum Aut</p>
                    <a href="#" class="event-name">Cupiditate Animi Sed Optio</a>
                    <p class="event-time">12am UTC</p>

                    <a class="button more-info-toggle">More Info</a>
                    <a class="button more-info-toggle close">Close</a>
                </div>
                <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                <div class="event-card">
                    <div class="event-host-info">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Guest Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-host-description">
                            <h2>Non Autem</h2>
                            <p class="event-card-description">Sed ullam voluptates nam delectus sit aut sit</p>
                        </div>
                    </div>
                    <!-- end .event-host-info -->

                    <div class="event-actions">

                        <p class="event-card-header">Iure Id Impedit</p>

                        <p class="event-card-datetime"><a href="REPLACE">Sint Qui at 12am UTC Fri Jul 11 1997</a></p>
                        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                        <span class="children-key">
                            <ul>
                                <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                </div>
                <!-- END PARTIAL: community/calendar/event_detail_card -->
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
            <p class="date"><span class="month">Sep </span>09</p>
            <p class="day-of-week">Wednesday</p>

            <div class="event">


                <div class="event-content">
                    <p class="event-header">Aut Quia Aliquid</p>
                    <a href="#" class="event-name">Id Aut Aperiam Voluptatem</a>
                    <p class="event-time">12am UTC</p>

                    <a class="button more-info-toggle">More Info</a>
                    <a class="button more-info-toggle close">Close</a>
                </div>
                <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                <div class="event-card">
                    <div class="event-host-info">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-host-description">
                            <h2>Sapiente Quidem</h2>
                            <p class="event-card-description">Nemo optio blanditiis nesciunt accusamus aperiam est adipisci</p>
                        </div>
                    </div>
                    <!-- end .event-host-info -->

                    <div class="event-actions">

                        <p class="event-card-datetime"><a href="REPLACE">Provident Dolore at 12am UTC Thu Oct 6 1994</a></p>
                        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                        <span class="children-key">
                            <ul>
                                <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                </div>
                <!-- END PARTIAL: community/calendar/event_detail_card -->
            </div>
        </li>

        <!-- END PARTIAL: community/calendar/grid_single_event -->
        <!-- BEGIN PARTIAL: community/calendar/grid_multi_events -->
        <li class="day multiple-events thursday">
            <p class="date"><span class="month">Sep </span>10</p>
            <p class="day-of-week">Thursday</p>

            <ul class="events">


                <li class="event">


                    <div class="event-content">
                        <p class="event-header">Nobis Ut Voluptatem</p>
                        <a href="#" class="event-name truncated">Quae Enim Voluptas Eveniet...</a>
                        <a href="REPLACE" class="event-name">Rerum Quas Consequatur At Odio Qui</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Guest Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Minima Explicabo</h2>
                                <p class="event-card-description">Quia error omnis sed quaerat dolor saepe eaque</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Aspernatur Animi Et</p>

                            <p class="event-card-datetime"><a href="REPLACE">Aut Et at 12am UTC Sun Jul 6 1997</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">


                    <div class="event-content">
                        <p class="event-header">Quis Eos Possimus</p>
                        <a href="#" class="event-name truncated">Alias Dolor Aliquam Qui...</a>
                        <a href="REPLACE" class="event-name">Cupiditate Quibusdam Doloremque Ipsum Sed Repellendus</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Guest Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Quis Fugit</h2>
                                <p class="event-card-description">Provident cum assumenda ut praesentium sit voluptatem unde</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Neque Occaecati Quisquam</p>

                            <p class="event-card-datetime"><a href="REPLACE">Iusto Voluptatem at 12am UTC Wed Apr 22 1998</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>




            </ul>
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
            <p class="date"><span class="month">Sep </span>12</p>
            <p class="day-of-week">Saturday</p>

            <ul class="events">


                <li class="event">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Quisquam Facere Voluptas</p>
                        <a href="#" class="event-name truncated">Illo Aut Qui Magni...</a>
                        <a href="REPLACE" class="event-name">Magnam Cum Explicabo Eum Placeat Et</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Debitis Debitis</h2>
                                <p class="event-card-description">Occaecati fuga tempora earum ut ut adipisci molestias</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-datetime"><a href="REPLACE">Similique Sint at 12am UTC Sat Nov 21 1992</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Harum Velit Aut</p>
                        <a href="#" class="event-name truncated">Officiis Ex Nobis Odio...</a>
                        <a href="REPLACE" class="event-name">Corporis Esse Vel Et Reiciendis Est</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Guest Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Natus Quisquam</h2>
                                <p class="event-card-description">Nemo commodi dolor omnis error fugit consequatur minima</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Quae Quam Eaque</p>

                            <p class="event-card-datetime"><a href="REPLACE">Quas Possimus at 12am UTC Sat Jun 3 2006</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Et Deleniti Quos</p>
                        <a href="#" class="event-name truncated">Earum Cupiditate Veritatis Laboriosam...</a>
                        <a href="REPLACE" class="event-name">Doloribus Consequatur Esse Est Sit Distinctio</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Guest Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Consequatur Quibusdam</h2>
                                <p class="event-card-description">Esse minus commodi ducimus at mollitia voluptatem aperiam</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-datetime"><a href="REPLACE">Beatae Quos at 12am UTC Sat Sep 17 1994</a></p>
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
        </li>
        <!-- END PARTIAL: community/calendar/grid_multi_events -->
    </ul>

    <ul class="row grid-row">
        <!-- BEGIN PARTIAL: community/calendar/grid_single_event -->

        <li class="single day sunday">
            <p class="date"><span class="month">Sep </span>13</p>
            <p class="day-of-week">Sunday</p>

            <div class="event">

                <span class="children-key">
                    <ul>
                        <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                        <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                        <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                    </ul>
                </span>


                <div class="event-content">
                    <p class="event-header">Esse Voluptas Nihil</p>
                    <a href="#" class="event-name">Totam Quasi Quo Suscipit</a>
                    <p class="event-time">12am UTC</p>

                    <a class="button more-info-toggle">More Info</a>
                    <a class="button more-info-toggle close">Close</a>
                </div>
                <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                <div class="event-card">
                    <div class="event-host-info">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Guest Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-host-description">
                            <h2>Quam Minus</h2>
                            <p class="event-card-description">Ut quo quos ducimus impedit omnis incidunt et</p>
                        </div>
                    </div>
                    <!-- end .event-host-info -->

                    <div class="event-actions">

                        <p class="event-card-header">Consectetur Asperiores Laborum</p>

                        <p class="event-card-datetime"><a href="REPLACE">Odio Voluptas at 12am UTC Fri Jul 5 2002</a></p>
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
            </div>
        </li>

        <!-- END PARTIAL: community/calendar/grid_single_event -->
        <!-- BEGIN PARTIAL: community/calendar/grid_multi_events -->
        <li class="day multiple-events monday">
            <p class="date"><span class="month">Sep </span>14</p>
            <p class="day-of-week">Monday</p>

            <ul class="events">


                <li class="event">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Numquam Rem Non</p>
                        <a href="#" class="event-name truncated">Fugit Beatae Distinctio Voluptates...</a>
                        <a href="REPLACE" class="event-name">Voluptatibus Voluptas Quia Vel Ut Quasi</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Ipsum Ratione</h2>
                                <p class="event-card-description">Dolor ut qui nam non qui quia illo</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Id Deserunt Et</p>

                            <p class="event-card-datetime"><a href="REPLACE">Consequatur Debitis at 12am UTC Fri Jul 19 2002</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Facere Rem Architecto</p>
                        <a href="#" class="event-name truncated">Culpa Itaque Officia Ipsa...</a>
                        <a href="REPLACE" class="event-name">Voluptas Nemo Perferendis Id Id Ipsum</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Quibusdam Aut</h2>
                                <p class="event-card-description">Aliquid eligendi id tempore enim fugiat enim expedita</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Est Qui Et</p>

                            <p class="event-card-datetime"><a href="REPLACE">Qui Quia at 12am UTC Sun Mar 27 2005</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Qui Quidem Dolorem</p>
                        <a href="#" class="event-name truncated">Iste Maxime Fugit Repudiandae...</a>
                        <a href="REPLACE" class="event-name">Magnam Aut Ut Delectus Rerum Consequatur</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Quia Aut</h2>
                                <p class="event-card-description">Officia minus ducimus est officiis accusamus sunt repudiandae</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-datetime"><a href="REPLACE">Sequi Non at 12am UTC Thu May 31 2001</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>




            </ul>
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
            <p class="date"><span class="month">Sep </span>17</p>
            <p class="day-of-week">Thursday</p>

            <ul class="events">


                <li class="event">


                    <div class="event-content">
                        <p class="event-header">Voluptas Error Animi</p>
                        <a href="#" class="event-name truncated">Iure Ad Consequatur Laboriosam...</a>
                        <a href="REPLACE" class="event-name">Possimus Quis Enim Laborum Non Officia</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Beatae Voluptatum</h2>
                                <p class="event-card-description">Neque aut sint et eius sit repellat aut</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Nesciunt Dicta Reprehenderit</p>

                            <p class="event-card-datetime"><a href="REPLACE">Iste Fugit at 12am UTC Thu Oct 22 1998</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">


                    <div class="event-content">
                        <p class="event-header">Quia Impedit Architecto</p>
                        <a href="#" class="event-name truncated">Perspiciatis Ipsam Qui Provident...</a>
                        <a href="REPLACE" class="event-name">Vel Consequuntur Nobis Sunt Culpa Temporibus</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Facere Architecto</h2>
                                <p class="event-card-description">Omnis iste incidunt quia et fuga incidunt eos</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Dolore Voluptates Aperiam</p>

                            <p class="event-card-datetime"><a href="REPLACE">Enim Autem at 12am UTC Thu Apr 16 2009</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">


                    <div class="event-content">
                        <p class="event-header">Consequatur Ut Facere</p>
                        <a href="#" class="event-name truncated">Non Corporis Qui Vel...</a>
                        <a href="REPLACE" class="event-name">Enim Repellendus Reprehenderit Rerum Nulla Molestiae</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Et Fugiat</h2>
                                <p class="event-card-description">Qui illum dolorem quibusdam commodi autem officia fugit</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Expedita Et Ratione</p>

                            <p class="event-card-datetime"><a href="REPLACE">Voluptas Maxime at 12am UTC Thu Oct 8 2009</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>




            </ul>
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
            <p class="date"><span class="month">Sep </span>19</p>
            <p class="day-of-week">Saturday</p>

            <ul class="events">


                <li class="event">


                    <div class="event-content">
                        <p class="event-header">Maxime Hic Eius</p>
                        <a href="#" class="event-name truncated">Ratione Molestias Sint Ad...</a>
                        <a href="REPLACE" class="event-name">Qui Sunt Placeat Nam Harum Eos</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Saepe Consequatur</h2>
                                <p class="event-card-description">Optio quisquam voluptatem earum consectetur esse et voluptas</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Enim Et Et</p>

                            <p class="event-card-datetime"><a href="REPLACE">Minus Laborum at 12am UTC Sat May 31 2008</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">


                    <div class="event-content">
                        <p class="event-header">Rerum Vel Ipsa</p>
                        <a href="#" class="event-name truncated">Delectus Quae Beatae Eos...</a>
                        <a href="REPLACE" class="event-name">In Voluptatem Quia Nemo Minima Aut</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Ab Qui</h2>
                                <p class="event-card-description">Et voluptatem et eos nam est dolorem accusantium</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-datetime"><a href="REPLACE">Facere Tempora at 12am UTC Sun Apr 6 2003</a></p>
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
        </li>
        <!-- END PARTIAL: community/calendar/grid_multi_events -->
    </ul>

    <ul class="row grid-row">
        <!-- BEGIN PARTIAL: community/calendar/grid_single_event -->

        <li class="single day sunday">
            <p class="date"><span class="month">Sep </span>20</p>
            <p class="day-of-week">Sunday</p>

            <div class="event">

                <span class="children-key">
                    <ul>
                        <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                        <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                        <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                        <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                    </ul>
                </span>


                <div class="event-content">
                    <p class="event-header">Et Aliquam Accusamus</p>
                    <a href="#" class="event-name">Neque Laborum Et Accusamus</a>
                    <p class="event-time">12am UTC</p>

                    <a class="button more-info-toggle">More Info</a>
                    <a class="button more-info-toggle close">Close</a>
                </div>
                <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                <div class="event-card">
                    <div class="event-host-info">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Guest Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-host-description">
                            <h2>Sed Blanditiis</h2>
                            <p class="event-card-description">Qui iusto voluptas minus omnis veniam inventore odit</p>
                        </div>
                    </div>
                    <!-- end .event-host-info -->

                    <div class="event-actions">

                        <p class="event-card-header">Quas Est Quod</p>

                        <p class="event-card-datetime"><a href="REPLACE">Officiis Quasi at 12am UTC Fri Dec 1 2006</a></p>
                        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                        <span class="children-key">
                            <ul>
                                <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                </div>
                <!-- END PARTIAL: community/calendar/event_detail_card -->
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
            <p class="date"><span class="month">Sep </span>24</p>
            <p class="day-of-week">Thursday</p>

            <ul class="events">


                <li class="event">


                    <div class="event-content">
                        <p class="event-header">Inventore Omnis Non</p>
                        <a href="#" class="event-name truncated">Et Repellat Dolore Est...</a>
                        <a href="REPLACE" class="event-name">Deleniti Sed Aut Rerum Odit Necessitatibus</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Odit In</h2>
                                <p class="event-card-description">Voluptate eum sit et ex facere distinctio beatae</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-datetime"><a href="REPLACE">Harum Occaecati at 12am UTC Tue Apr 16 1996</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">


                    <div class="event-content">
                        <p class="event-header">Voluptatem Et Ab</p>
                        <a href="#" class="event-name truncated">Facere Aspernatur Est Consequatur...</a>
                        <a href="REPLACE" class="event-name">Mollitia Sed Sequi Sed Dolores Sit</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Eveniet Nisi</h2>
                                <p class="event-card-description">Quod quia non excepturi eaque debitis error rerum</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-datetime"><a href="REPLACE">Dolores Earum at 12am UTC Wed Jan 20 1999</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>




            </ul>
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
            <p class="date"><span class="month">Sep </span>26</p>
            <p class="day-of-week">Saturday</p>

            <ul class="events">


                <li class="event">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Consectetur Blanditiis Sit</p>
                        <a href="#" class="event-name truncated">Minima Dolorem Nesciunt Doloremque...</a>
                        <a href="REPLACE" class="event-name">Et Sed Aut Officia Ut Itaque</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Guest Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Iste Earum</h2>
                                <p class="event-card-description">Similique porro assumenda repellat modi numquam tenetur aut</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Perspiciatis Tempora Et</p>

                            <p class="event-card-datetime"><a href="REPLACE">Quisquam Nostrum at 12am UTC Mon May 22 1995</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Deleniti Sed Unde</p>
                        <a href="#" class="event-name truncated">Nisi Et Possimus Ipsam...</a>
                        <a href="REPLACE" class="event-name">Voluptatum Aut Illo Rerum At Omnis</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Voluptatem Officiis</h2>
                                <p class="event-card-description">Voluptatum dolores exercitationem mollitia aut ea earum laudantium</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-datetime"><a href="REPLACE">Dolores Rem at 12am UTC Mon Oct 15 2001</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>





                <li class="event">

                    <span class="children-key">
                        <ul>
                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>


                    <div class="event-content">
                        <p class="event-header">Quia Voluptatem Id</p>
                        <a href="#" class="event-name truncated">Nulla Adipisci Recusandae Ut...</a>
                        <a href="REPLACE" class="event-name">Eaque Hic Quis Praesentium Deserunt Voluptatem</a>
                        <p class="event-time">12am UTC</p>

                        <a class="button more-info-toggle">More Info</a>
                        <a class="button more-info-toggle close">Close</a>
                    </div>
                    <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                    <div class="event-card">
                        <div class="event-host-info">
                            <div class="event-card-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <div class="image-label">
                                        Expert
                                    </div>
                                </a>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-host-description">
                                <h2>Ut Quidem</h2>
                                <p class="event-card-description">Laboriosam autem voluptatibus id minus illum enim optio</p>
                            </div>
                        </div>
                        <!-- end .event-host-info -->

                        <div class="event-actions">

                            <p class="event-card-header">Voluptatum Aut Similique</p>

                            <p class="event-card-datetime"><a href="REPLACE">Blanditiis Ut at 12am UTC Sun Feb 1 2004</a></p>
                            <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                            <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                            <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/calendar/event_detail_card -->
                </li>




            </ul>
        </li>
        <!-- END PARTIAL: community/calendar/grid_multi_events -->
    </ul>

    <ul class="row grid-row">
        <!-- BEGIN PARTIAL: community/calendar/grid_single_event -->

        <li class="single day sunday">
            <p class="date"><span class="month">Sep </span>27</p>
            <p class="day-of-week">Sunday</p>

            <div class="event">

                <span class="children-key">
                    <ul>
                        <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                        <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                        <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                        <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                    </ul>
                </span>


                <div class="event-content">
                    <p class="event-header">Delectus Voluptatem Nihil</p>
                    <a href="#" class="event-name">Et Qui Sit Unde</a>
                    <p class="event-time">12am UTC</p>

                    <a class="button more-info-toggle">More Info</a>
                    <a class="button more-info-toggle close">Close</a>
                </div>
                <!-- BEGIN PARTIAL: community/calendar/event_detail_card -->
                <div class="event-card">
                    <div class="event-host-info">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Guest Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-host-description">
                            <h2>Praesentium Fugit</h2>
                            <p class="event-card-description">Ipsam inventore quidem ad quos voluptatem doloremque labore</p>
                        </div>
                    </div>
                    <!-- end .event-host-info -->

                    <div class="event-actions">

                        <p class="event-card-datetime"><a href="REPLACE">Facere Ratione at 12am UTC Fri Jul 28 1995</a></p>
                        <p><a class="event-rsvp" href="REPLACE">RSVP for this event</a></p>
                        <p><a class="add-to-calendar" href="REPLACE">Add to my calendar</a></p>
                        <p><a class="event-details-link" href="REPLACE">Event details</a></p>

                        <span class="children-key">
                            <ul>
                                <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                </div>
                <!-- END PARTIAL: community/calendar/event_detail_card -->
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
<div class="container child-content-indicator ">
    <!-- Key -->
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
            </div>
            <!-- .children-key -->
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>
<!-- .child-content-indicator -->
<!-- END PARTIAL: children-key -->
