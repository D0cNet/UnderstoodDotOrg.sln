<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsCalendarListView.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Experts.ExpertsCalendarListView" %>
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

            <li><a href="REPLACE">Calendar View</a></li>
            <li>List View</li>

        </ul>
    </header>
</div>
<!-- END PARTIAL: community/calendar/header -->

<!-- BEGIN PARTIAL: community/calendar/list_view -->
<ul class="container calendar calendar-list">
    <!-- BEGIN PARTIAL: community/calendar/list_view_event -->
    <li class="event-card webinar row">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                    Expert
                </div>
            </a>
        </div>
        <!-- end .event-card-image -->

        <div class="event-card-actions">
            <p class="event-card-datetime">Sun Jun 20 at 12am UTC</p>
            <p class="event-card-name">Voluptates Qui Facilis Praesentium Dolorem Non Omnis Qui</p>

            <p class="event-topics-header">Topics Covered</p>
            <p class="event-topics">Illo In Molestiae Quo Consectetur Sunt Laboriosam Et Voluptates Ducimus</p>

            <div class="event-links">
                <a class="event-rsvp" href="REPLACE">RSVP for this event</a>
                <a class="add-to-calendar" href="REPLACE">Add to my calendar</a>
                <a class="event-details-link" href="REPLACE">Event details</a>
            </div>


        </div>

        <div class="event-card-type">
            Webinar
        </div>
    </li>


    <!-- END PARTIAL: community/calendar/list_view_event -->
    <!-- BEGIN PARTIAL: community/calendar/list_view_event -->

    <li class="event-card chat row">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">Dolores</div>
            </a>
        </div>
        <!-- end .event-card-image -->

        <div class="event-card-actions">
            <p class="event-card-datetime">Fri Dec 10 at 12am UTC</p>
            <p class="event-card-name">Ut Cupiditate Occaecati Esse Facere Eum Commodi Quidem</p>
            <p class="event-host-description">Libero Est Adipisci Consequatur Suscipit Totam Et Itaque Impedit Voluptatem</p>

            <div class="event-links">
                <a class="event-rsvp" href="REPLACE">RSVP for this event</a>
                <a class="add-to-calendar" href="REPLACE">Add to my calendar</a>
                <a class="event-details-link" href="REPLACE">Event details</a>
            </div>


            <span class="children-key">
                <ul>
                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>

        </div>

        <div class="event-card-type">
            Chat
        </div>
    </li>

    <!-- END PARTIAL: community/calendar/list_view_event -->
    <!-- BEGIN PARTIAL: community/calendar/list_view_event -->
    <li class="event-card webinar row">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                    Guest Expert
                </div>
            </a>
        </div>
        <!-- end .event-card-image -->

        <div class="event-card-actions">
            <p class="event-card-datetime">Tue Jan 1 at 12am UTC</p>
            <p class="event-card-name">Et Eum Voluptate Voluptatibus Nihil Ut Aliquid Sint</p>

            <p class="event-topics-header">Topics Covered</p>
            <p class="event-topics">Labore Sapiente Et Omnis Nesciunt Mollitia Hic Sed Voluptas Perferendis</p>

            <div class="event-links">
                <a class="event-rsvp" href="REPLACE">RSVP for this event</a>
                <a class="add-to-calendar" href="REPLACE">Add to my calendar</a>
                <a class="event-details-link" href="REPLACE">Event details</a>
            </div>


            <span class="children-key">
                <ul>
                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>

        </div>

        <div class="event-card-type">
            Webinar
        </div>
    </li>


    <!-- END PARTIAL: community/calendar/list_view_event -->
    <!-- BEGIN PARTIAL: community/calendar/list_view_event -->
    <li class="event-card webinar row">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">
                    Expert
                </div>
            </a>
        </div>
        <!-- end .event-card-image -->

        <div class="event-card-actions">
            <p class="event-card-datetime">Sun May 13 at 12am UTC</p>
            <p class="event-card-name">Rerum Et Dolorem Praesentium Aperiam Temporibus Molestias Mollitia</p>

            <p class="event-topics-header">Topics Covered</p>
            <p class="event-topics">Est Pariatur Autem Laborum Placeat Deserunt Cumque Aut Eum Natus</p>

            <div class="event-links">
                <a class="event-rsvp" href="REPLACE">RSVP for this event</a>
                <a class="add-to-calendar" href="REPLACE">Add to my calendar</a>
                <a class="event-details-link" href="REPLACE">Event details</a>
            </div>


        </div>

        <div class="event-card-type">
            Webinar
        </div>
    </li>


    <!-- END PARTIAL: community/calendar/list_view_event -->
    <!-- BEGIN PARTIAL: community/calendar/list_view_event -->

    <li class="event-card chat row">
        <div class="event-card-image">
            <a href="REPLACE">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                <div class="image-label">Ipsam</div>
            </a>
        </div>
        <!-- end .event-card-image -->

        <div class="event-card-actions">
            <p class="event-card-datetime">Sun Aug 13 at 12am UTC</p>
            <p class="event-card-name">Dolor Laboriosam Et Ratione In Quis Cum Temporibus</p>
            <p class="event-host-description">Ut Dolorum Aut Nisi Eum Et Ea Consequatur Rerum Sit</p>

            <div class="event-links">
                <a class="event-rsvp" href="REPLACE">RSVP for this event</a>
                <a class="add-to-calendar" href="REPLACE">Add to my calendar</a>
                <a class="event-details-link" href="REPLACE">Event details</a>
            </div>


            <span class="children-key">
                <ul>
                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                </ul>
            </span>

        </div>

        <div class="event-card-type">
            Chat
        </div>
    </li>

    <!-- END PARTIAL: community/calendar/list_view_event -->
</ul>
<!-- END PARTIAL: community/calendar/list_view -->

<%--<!-- BEGIN PARTIAL: children-key -->
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
<!-- .child-content-indicator -->--%>
<sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
