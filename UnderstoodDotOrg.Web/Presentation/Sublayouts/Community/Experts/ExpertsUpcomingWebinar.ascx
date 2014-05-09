<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsUpcomingWebinar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Experts.ExpertsUpcomingWebinar" %>
<div class="container event">
    <header class="row">
        <div class="event-container skiplink-feature">
            <ul class="breadcrumbs">
                <p>
                    <li><a href="REPLACE">Back to Odio Voluptas</a></li>
            </ul>

            <h2>Webinar: <em>Vel Ipsum Omnis</em></h2>
        </div>
    </header>

    <div class="row">
        <div class="event-container">
            <div class="col-18 col event-content">
                <div class="event-image">
                    <div class="thumbnail">
                        <a href="REPLACE">
                            <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                            <div class="image-label">
                                Expert
                            </div>
                        </a>
                    </div>

                    <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                    <div class="recommended-for">
                        <p>Recommended for</p>
                        <span class="children-key">
                            <ul>
                                <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                    <!-- END PARTIAL: community/experts_recommended_for -->
                </div>
                <!-- end .event-image -->

                <p class="event-date-time">Wed Jul 12 at 12am UTC</p>
                <p class="event-host-name">Vitae Commodi Quaerat</p>
                <p class="event-host-title">Voluptas Beatae Voluptas Consequatur Voluptas</p>
                <p class="event-topics-subhead">Topics Covered</p>
                <p class="event-topics">Voluptas Delectus Aut Quas Quod Ratione Quod Provident Aut Veniam</p>

                <p>Dolor molestias id enim et nesciunt sit explicabo. illum sunt perspiciatis provident voluptatem. velit modi ullam nam est sint aut voluptas expedita libero est animi quos placeat. saepe nisi non dolores nemo voluptas omnis aut suscipit animi odio libero sed</p>

                <a class="button event-rsvp" href="REPLACE">RSVP for This Event</a>
                <a class="button event-calendar" href="REPLACE">Add to My Calendar</a>

            </div>
            <!-- end .event-content -->
            <div class="col-5 col offset-1 event-sidebar">
                <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                <div class="recommended-for">
                    <p>Recommended for</p>
                    <span class="children-key">
                        <ul>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
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
                <h2>Upcoming Webinars</h2>
                <p class="subhead">Get info direct from thought leaders</p>
                <!-- BEGIN PARTIAL: community/experts_event_card -->

                <div class="event-card col-22 offset-2">
                    <div class="event-card-info group">
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
                                Sun May 14 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Cum Dolor Quo Sunt Qui Quia Laborum Aut Delectus Repudiandae</a>
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
                <h2>Chat with an Expert</h2>
                <p class="subhead">Ask questions and get answers live!</p>
                <!-- BEGIN PARTIAL: community/experts_chat_card -->

                <div class="event-card col-22 offset-2">
                    <div class="event-card-info group">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Guest Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <div class="event-card-datetime">
                                Tue Jul 9 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Ullam Quisquam Enim Voluptatem</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-host-title">quo a repudiandae quas est omnis</p>
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
        <a class="button" href="REPLACE">See Calendar</a>
    </div>
</div>
<!-- end .events-chat -->

<div class="container archive upcoming-webinar">
    <div class="row">
        <header class="col col-24">
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
            <div class="event-card">
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
                            <a href="REPLACE">Commodi Nemo Iusto Dolorem Officiis Et Eum Maxime Dolorem Explicabo</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Topics Covered</p>
                        <p class="event-card-topics">Labore Fugiat Voluptas Perspiciatis Amet Quia Occaecati Consequatur Soluta Nihil</p>
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
            <div class="event-card">
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
                            <a href="REPLACE">Aut Quo Reprehenderit Voluptas Non Tempora Ullam Cupiditate Et Id</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Top Questions</p>
                        <p class="event-card-topics">Tenetur Possimus Magni Esse Dolor In Inventore Similique Qui Fugit</p>
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
            <a href="REPLACE" class="button see-archive">See Archive</a>

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
