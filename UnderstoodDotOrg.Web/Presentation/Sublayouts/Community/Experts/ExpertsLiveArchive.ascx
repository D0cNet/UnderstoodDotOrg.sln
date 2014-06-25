<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsLiveArchive.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Experts.ExpertsLiveArchive" %>
<!-- BEGIN PARTIAL: community/experts_sub_nav -->
<div class="container">
    <div class="row">
        <div class="container">
            <div class="experts-nav-form clearfix skiplink-toolbar">
                <div class="dropdown">
                    <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                        <span class="current-page">Filter By: Archive</span>
                        <span class="dropdown-title">Filter By</span>
                    </a>
                    <ul class="dropdown-menu" role="menu">

                        <li role="presentation" class="">
                            <a role="menuitem" href="REPLACE">Featured</a>
                        </li>

                        <li role="presentation" class="">
                            <a role="menuitem" href="REPLACE">Recommended</a>
                        </li>

                        <li role="presentation" class="">
                            <a role="menuitem" href="REPLACE">Calendar</a>
                        </li>

                        <li role="presentation" class="current-page">
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


                <fieldset class="archive-search-form">
                    <label for="search-archive-text" class="visuallyhidden" aria-hidden="true">Search archive</label>
                    <input type="text" class="archive-search" id="search-archive-text" name="search-archive" placeholder="Search archive" />
                    <input class="search-button" type="submit" value="Go">
                </fieldset>

            </div>
            <!-- experts-nav-form -->
        </div>
    </div>
</div>
<!-- END PARTIAL: community/experts_sub_nav -->

<div class="container archive">
    <div class="row skiplink-content" aria-role="main">
        <header class="col col-24">
            <h2>Experts Live: Archive</h2>
        </header>
    </div>

    <div class="event-cards-container">
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
                                <a href="REPLACE">Aut Reiciendis Aut Aut Deserunt Inventore Et Consequatur Perspiciatis Iure</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Topics Covered</p>
                            <p class="event-card-topics">Fugit Nam Porro Qui Sapiente Voluptatem Voluptates Illo Libero Voluptatem</p>
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
                                <a href="REPLACE">Natus Sapiente Quidem Non Velit Vero Hic Rem Recusandae Dolor</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Top Questions</p>
                            <p class="event-card-topics">Aperiam Laboriosam Reiciendis Dolorem Asperiores Incidunt Odit Voluptatibus Nobis Omnis</p>
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
                                    Guest Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details col equalize">
                            <div class="event-card-title">
                                <a href="REPLACE">Non Facilis Atque Et Eaque Rem Non Tempore Voluptatem Soluta</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Topics Covered</p>
                            <p class="event-card-topics">Aut Est Voluptate Amet Ad Consequuntur Velit Sit Vero Sunt</p>
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
                                <a href="REPLACE">Non Est Repellendus Deserunt Nam Nostrum Culpa Animi Omnis Enim</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Top Questions</p>
                            <p class="event-card-topics">Distinctio Doloribus Impedit Placeat Quo Ut Similique Hic Ex Fugit</p>
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
                                <a href="REPLACE">Voluptas Dolor Quisquam Earum Corporis Corporis Omnis Amet Minima Commodi</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Topics Covered</p>
                            <p class="event-card-topics">Sint Voluptatibus Et Voluptates Placeat Ut Vero Minima Velit Ut</p>
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
                                <a href="REPLACE">Tempora Repellendus Dolorum Qui Praesentium Atque Est Dolor Dolorem Blanditiis</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Top Questions</p>
                            <p class="event-card-topics">Voluptatem Dolores Quaerat Alias Tempore Nesciunt Perferendis Voluptatem Delectus Incidunt</p>
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
                                <a href="REPLACE">Quo Corporis Aliquid Aut Reiciendis Rerum Optio Officiis Neque Autem</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Topics Covered</p>
                            <p class="event-card-topics">Perspiciatis Laudantium Cupiditate Expedita Aut Accusantium Dignissimos Ipsum Dolore Hic</p>
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
                                <a href="REPLACE">Molestias Atque Et Velit Tenetur Iste Nobis Officiis Repudiandae Amet</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Top Questions</p>
                            <p class="event-card-topics">Optio Id Aut Aut Ut Dolor Veniam Rerum Ut Nostrum</p>
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
                                    Guest Expert
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details col equalize">
                            <div class="event-card-title">
                                <a href="REPLACE">Id Qui Corporis Culpa Ex Perspiciatis Quam Ducimus Quis Et</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Topics Covered</p>
                            <p class="event-card-topics">Provident Non Consequatur Libero Dicta Ut Provident Optio Eaque Aliquam</p>
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
                                <a href="REPLACE">Laborum Inventore Quam Eaque Sit Minima Aliquid Facilis Voluptatibus Aut</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Top Questions</p>
                            <p class="event-card-topics">Vel Rerum Sapiente Tempore Eum Quasi Voluptate Expedita Soluta Odit</p>
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
    </div>
</div>


<!-- Show More -->
<!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more rs_skip">
    <div class="row">
        <div class="col col-24">
            <a class="show-more-link " href="#" data-path="community/event-cards" data-container="event-cards-container" data-item="event-cards" data-count="6">Show More<i class="icon-arrow-down-blue"></i></a>
        </div>
    </div>
</div>
<!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
<!-- .show-more -->

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
<!-- .child-content-indicator -->
<!-- END PARTIAL: children-key -->--%>
<sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
<!-- BEGIN PARTIAL: community/experts_suggest_webinar -->
<div class="suggest-webinar-form">
    <div class="row">
        <div class="form-wrapper">

            <header>
                <h3>Suggest a Webinar</h3>
            </header>

            <fieldset class="col col-24">
                <label for="enter-your-topic-text" class="visuallyhidden" aria-hidden="true">Enter your topic</label>
                <input type="text" class="suggest-webinar-field" id="enter-your-topic-text" placeholder="Enter your topic" />
                <input type="submit" class="button suggest-webinar-submit" value="Submit Topic" />
            </fieldset>

        </div>
    </div>
</div>
<!-- END PARTIAL: community/experts_suggest_webinar -->
