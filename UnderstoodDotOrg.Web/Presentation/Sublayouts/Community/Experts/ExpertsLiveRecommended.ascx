<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsLiveRecommended.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Experts.ExpertsLiveRecommended" %>
<!-- BEGIN PARTIAL: community/experts_sub_nav -->
<div class="container">
    <div class="row">
        <div class="container">
            <div class="experts-nav-form clearfix skiplink-toolbar">
                <div class="dropdown">
                    <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                        <span class="current-page">Filter By: Recommended</span>
                        <span class="dropdown-title">Filter By</span>
                    </a>
                    <ul class="dropdown-menu" role="menu">

                        <li role="presentation" class="">
                            <a role="menuitem" href="REPLACE">Featured</a>
                        </li>

                        <li role="presentation" class="current-page">
                            <a role="menuitem" href="REPLACE">Recommended</a>
                        </li>

                        <li role="presentation" class="">
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

<div class="container events-chat">
    <div class="row">
        <div class="container">
            <div class="col col-11 offset-1 event-cards skiplink-feature">
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
                                Sat May 28 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Est Et Ut Rerum Doloremque Cumque Aspernatur A Quia Repellendus</a>
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
                <div class="event-card first col-22 offset-2">
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
                                Tue Jan 12 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Beatae Et Nihil Sit</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-host-title">beatae et pariatur voluptatem odit qui</p>
                            <span class="children-key">
                                <ul>
                                    <li><i class="child-a" title="CHILD NAME HERE"></i></li>
                                </ul>
                            </span>
                        </div>
                        <!-- end .event-card-details -->
                    </div>
                    <!-- end .event-card-info -->
                </div>
                <!-- end .event-card -->

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
                                Mon Feb 19 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Quasi Et Illo Magni</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-host-title">est repellat placeat molestiae voluptas aliquam</p>
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
    <!-- end .events-chat -->

    <div class="row">
        <a class="col-4 button offset-20" href="REPLACE">See Calendar</a>
    </div>
</div>

<div class="container live-chat">
    <div class="live-chat-content row">
        <header class="col col-24">
            <h2>Live Chat: Expert Office Hours</h2>
            <p class="subhead">Your chance to ask the expert in one of our daily online chats</p>

            <ul class="live-chat-navigation">
                <li class="header"><a href="REPLACE">See All</a></li>
                <li class="rsArrow rsArrowLeft">
                    <button class="rsArrowIcn"></button>
                </li>
                <li class="rsArrow rsArrowRight">
                    <button class="rsArrowIcn"></button>
                </li>
            </ul>
        </header>

        <div class="event-cards row">
            <!-- BEGIN PARTIAL: community/experts_live_chat_card -->
            <div class="col col-12 event-card">
                <div class="event-card-info group">
                    <div class="event-card-upper">
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
                            <p class="event-card-heading">assumenda quaerat officia</p>
                            <p class="event-card-title">Incidunt Qui Aut</a></p>
                            <p>magnam enim qui quas ea optio</p>



                            <p class="event-card-info-link"><a href="REPLACE">dolorem amet</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">provident ullam</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">id labore</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">veniam expedita</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
            <div class="col col-12 event-card">
                <div class="event-card-info group">
                    <div class="event-card-upper">
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
                            <p class="event-card-heading">in et at</p>
                            <p class="event-card-title">Cumque Sed Et</a></p>
                            <p>id assumenda at veniam ab adipisci</p>



                            <p class="event-card-info-link"><a href="REPLACE">odio eligendi</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">dolor aut</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">id cumque</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">non debitis</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
            <div class="col col-12 event-card">
                <div class="event-card-info group">
                    <div class="event-card-upper">
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
                            <p class="event-card-heading">amet quisquam et</p>
                            <p class="event-card-title">Neque Voluptate Minus</a></p>
                            <p>mollitia ut nesciunt porro id laborum</p>



                            <p class="event-card-info-link"><a href="REPLACE">natus laborum</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">quae doloribus</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">quasi totam</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">exercitationem aut</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
            <div class="col col-12 event-card">
                <div class="event-card-info group">
                    <div class="event-card-upper">
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
                            <p class="event-card-heading">ut voluptas ut</p>
                            <p class="event-card-title">Est Similique Recusandae</a></p>
                            <p>explicabo saepe omnis alias nihil quia</p>



                            <p class="event-card-info-link"><a href="REPLACE">unde aut</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">voluptatem ad</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">ipsam nostrum</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">ut praesentium</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
            <div class="col col-12 event-card">
                <div class="event-card-info group">
                    <div class="event-card-upper">
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
                            <p class="event-card-heading">praesentium ut sit</p>
                            <p class="event-card-title">Laboriosam Dolor Nam</a></p>
                            <p>recusandae et culpa non et iure</p>



                            <p class="event-card-info-link"><a href="REPLACE">et harum</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">et repellat</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">consectetur ipsam</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">id quibusdam</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
            <div class="col col-12 event-card">
                <div class="event-card-info group">
                    <div class="event-card-upper">
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
                            <p class="event-card-heading">eaque alias eveniet</p>
                            <p class="event-card-title">Laborum Est Quis</a></p>
                            <p>fugiat id quasi harum et mollitia</p>



                            <p class="event-card-info-link"><a href="REPLACE">aut earum</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">eligendi neque</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">labore vel</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">sint itaque</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->

            <!-- END PARTIAL: community/experts_live_chat_card -->
        </div>
        <!-- end .event-cards -->
    </div>
</div>

<div class="container archive">
    <div class="row skiplink-content" aria-role="main">
        <header class="col col-24">
            <h2>Recently Added to the Archive</h2>

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
                            <a href="REPLACE">Quisquam Nobis Ex Molestiae Vitae Quae Et Ullam Dolor Eum</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Topics Covered</p>
                        <p class="event-card-topics">Repellendus Quisquam Aut Sed Aut Consequatur Non Quia Vel Voluptates</p>
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
                            <a href="REPLACE">Velit Non Veritatis Deleniti Et Incidunt Delectus Modi Voluptas Nihil</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Top Questions</p>
                        <p class="event-card-topics">Nemo Repudiandae Minima Exercitationem Quo Animi Consequatur Iusto Ipsa Vero</p>
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
