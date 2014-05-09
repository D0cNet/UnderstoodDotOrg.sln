<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsLive.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Experts.ExpertsLive" %>
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

                        <li role="presentation" class="current-page">
                            <a role="menuitem" href="REPLACE">Featured</a>
                        </li>

                        <li role="presentation" class="">
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
            <div class="col col-12 event-cards skiplink-feature">
                <h2>Upcoming Webinars</h2>
                <p class="subhead">Get info direct from thought leaders</p>
                <!-- BEGIN PARTIAL: community/experts_event_card -->
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
                                Sat May 31 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Perspiciatis Vero Consequatur In Quod Eligendi Necessitatibus Aut Id Fuga</a>
                            </div>
                            <!-- end .event-card-title -->
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
                                    Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <div class="event-card-datetime">
                                Sat Jun 12 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Quae Qui Cupiditate Quisquam Enim Laboriosam Voluptatem Atque Rerum Et</a>
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

            <div class="col col-12 event-cards">
                <h2>Chat with an Expert</h2>
                <p class="subhead">Ask questions and get answers live!</p>
                <!-- BEGIN PARTIAL: community/experts_chat_card -->
                <div class="event-card first col-22 offset-2">
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
                                Tue Aug 22 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Quos Voluptates Maiores Aut</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-host-title">doloribus inventore sed similique ipsa et</p>
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
                                    Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <div class="event-card-datetime">
                                Thu Dec 26 at 12am UTC
                            </div>
                            <!-- end .event-card-datetime -->
                            <div class="event-card-title">
                                <a href="REPLACE">Molestias Eos Ea Iusto</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-host-title">sapiente esse est ullam non voluptas</p>
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

    <div class="row">
        <a class="col-4 button offset-20" href="REPLACE">See Calendar</a>
    </div>
</div>
<!-- end .events-chat -->

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
                                    Guest Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <p class="event-card-heading">accusantium omnis consequatur</p>
                            <p class="event-card-title">Consequatur Libero Illo</a></p>
                            <p>voluptas aut aut assumenda numquam sit</p>



                            <p class="event-card-info-link"><a href="REPLACE">et aut</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">soluta illum</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">iusto maxime</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">et dolorem</a></p>
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
                            <p class="event-card-heading">harum omnis ut</p>
                            <p class="event-card-title">Voluptatem Magni Porro</a></p>
                            <p>ea eum accusantium explicabo fugit non</p>



                            <p class="event-card-info-link"><a href="REPLACE">minima velit</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">error optio</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">eligendi earum</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">neque a</a></p>
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
                            <p class="event-card-heading">nobis quia ut</p>
                            <p class="event-card-title">Quis Labore Voluptatem</a></p>
                            <p>vel tenetur dolore vel ea totam</p>



                            <p class="event-card-info-link"><a href="REPLACE">est quia</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">atque necessitatibus</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">reprehenderit ut</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">non veniam</a></p>
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
                            <p class="event-card-heading">totam sed cum</p>
                            <p class="event-card-title">Ipsa Nesciunt Consequatur</a></p>
                            <p>vel illum voluptas dolore alias accusamus</p>



                            <p class="event-card-info-link"><a href="REPLACE">et enim</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">et ipsam</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">necessitatibus praesentium</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">quasi cupiditate</a></p>
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
                            <p class="event-card-heading">quod animi saepe</p>
                            <p class="event-card-title">Ratione Totam Ut</a></p>
                            <p>id inventore dolor consequatur ad fugit</p>



                            <p class="event-card-info-link"><a href="REPLACE">explicabo illo</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">id ipsa</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">doloremque quo</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">voluptatum eos</a></p>
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
                            <p class="event-card-heading">qui laboriosam dolores</p>
                            <p class="event-card-title">Ipsa Et Aut</a></p>
                            <p>rerum impedit omnis quia omnis ut</p>



                            <p class="event-card-info-link"><a href="REPLACE">optio molestiae</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">qui necessitatibus</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">aliquid atque</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">nam et</a></p>
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
                <label for="search-archive" class="visuallyhidden" aria-hidden="true">Search Archive</label>
                <input type="text" class="archive-search" name="search-archive" placeholder="Search archive" />
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
                            <a href="REPLACE">Ducimus Cupiditate Atque Voluptate Quas Magni Nemo Magni Et Nihil</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Topics Covered</p>
                        <p class="event-card-topics">Quo Impedit Corrupti Odio Voluptates Odit Qui Sit Earum Ut</p>
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
                            <a href="REPLACE">Sequi Commodi Rem Recusandae Itaque Adipisci Ut Ut Rerum Quos</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Top Questions</p>
                        <p class="event-card-topics">Molestiae Ullam Natus Porro Debitis Possimus Quia Eveniet Perferendis Ut</p>
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
    <div class="row">


        <div class="container child-content-indicator">
            <!-- Key -->
            <div class="row">
                <div class="col col-24">
                    <a href="REPLACE" class="button see-archive">See Archive</a>
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

    </div>

</div>