<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsLiveNoWebinar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Experts.ExpertsLiveNoWebinar" %>
<!-- BEGIN PARTIAL: community/experts_sub_nav -->
<div class="container">
    <div class="row">
        <div class="container">
            <div class="experts-nav-form clearfix skiplink-toolbar">
                <div class="dropdown">
                    <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                        <span class="current-page">Filter By: Featured</span>
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
                <!-- BEGIN PARTIAL: community/experts_no_webinars -->
                <div class="no-webinars">
                    <p>Quod Quis Odio Soluta Ut Dicta Ipsum Aut Est Voluptates Et Enim Debitis Et Et Nobis</p>
                    <p>Aut Ipsa Dignissimos Assumenda Similique Quia Et Consequatur Est Nostrum Dolorum Eum Sit Sapiente Maxime Rerum</p>
                </div>
                <!-- END PARTIAL: community/experts_no_webinars -->
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
                                Fri Dec 17 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Aliquam Harum Exercitationem Autem</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-host-title">velit incidunt cum corporis maxime dicta</p>
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
                                Wed Jul 27 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Tempora Amet Nobis Aspernatur</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-host-title">distinctio rem nulla officiis nisi quasi</p>
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
                            <p class="event-card-heading">maiores quaerat eos</p>
                            <p class="event-card-title">Sunt Qui Tempora</a></p>
                            <p>debitis corrupti eveniet aliquid odio saepe</p>



                            <p class="event-card-info-link"><a href="REPLACE">laboriosam velit</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">cupiditate id</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">inventore fugiat</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">error dolor</a></p>
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
                            <p class="event-card-heading">atque rem fugit</p>
                            <p class="event-card-title">Distinctio Similique Ratione</a></p>
                            <p>perferendis rerum fuga ipsa et fugit</p>



                            <p class="event-card-info-link"><a href="REPLACE">temporibus non</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">dolorem magnam</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">quas repellat</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">ad quis</a></p>
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
                            <p class="event-card-heading">velit ex impedit</p>
                            <p class="event-card-title">Eum Reiciendis Maxime</a></p>
                            <p>aut harum sed voluptas blanditiis incidunt</p>



                            <p class="event-card-info-link"><a href="REPLACE">eaque est</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">quia harum</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">voluptatem iusto</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">qui tempora</a></p>
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
                            <p class="event-card-heading">ipsam asperiores qui</p>
                            <p class="event-card-title">Fuga Fugit Et</a></p>
                            <p>maiores et occaecati consequatur doloremque a</p>



                            <p class="event-card-info-link"><a href="REPLACE">ipsa dignissimos</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">expedita fugit</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">laboriosam aspernatur</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">maxime neque</a></p>
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
                            <p class="event-card-heading">nesciunt fugiat enim</p>
                            <p class="event-card-title">Recusandae Suscipit Quasi</a></p>
                            <p>ducimus et maiores rerum alias voluptas</p>



                            <p class="event-card-info-link"><a href="REPLACE">molestiae quidem</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">ipsam rerum</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">beatae rem</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">corrupti exercitationem</a></p>
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
                            <p class="event-card-heading">autem odio repudiandae</p>
                            <p class="event-card-title">Et Quisquam Fuga</a></p>
                            <p>distinctio quos nesciunt dicta suscipit in</p>



                            <p class="event-card-info-link"><a href="REPLACE">dolorum cum</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">consequatur qui</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">est qui</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">ea voluptate</a></p>
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
                <label for="search-archive-text" class="visuallyhidden">Search archive</label>
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
                            <a href="REPLACE">Qui Totam Distinctio Occaecati Expedita Inventore Nihil Tempore Repudiandae Qui</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Topics Covered</p>
                        <p class="event-card-topics">Blanditiis Dolores Et Qui Ipsam Aut Facilis Quia Reprehenderit Voluptas</p>
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
                                Guest Expert
                            </div>
                        </a>
                    </div>
                    <!-- end .event-card-image -->
                    <div class="event-card-details col equalize">
                        <div class="event-card-title">
                            <a href="REPLACE">Enim Expedita Earum Et Odit Cupiditate Eum Inventore Molestiae Dolores</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Top Questions</p>
                        <p class="event-card-topics">Vel Dolorum Ut Vero Ducimus Aspernatur Illum Vero Totam Necessitatibus</p>
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
