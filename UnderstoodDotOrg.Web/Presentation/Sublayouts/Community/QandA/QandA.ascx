<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QandA.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Q_and_A.QandA" %>
<div class="container community-q-a">
    <div class="row">
        <div class="col col-24">
            <sc:Placeholder Key="QuestionToolbar" runat="server" />
            <div class="box-search clearfix">
                <div class="dropdown-container">
                    <div class="dropdown">
                        <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                            <span class="current-page">Featured</span>
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
                </div>
                <label for="question-search-issue" class="visuallyhidden">Child's Issue</label>
                <select name="question-search-issue" id="question-search-issue" aria-required="true">
                    <option value="">Child's Issue</option>
                    <option>Issue 1</option>
                    <option>Issue 2</option>
                    <option>Issue 3</option>
                    <option>Issue 4</option>
                </select>

                <label for="question-search-grade" class="visuallyhidden">Grade</label>
                <select name="question-search-grade" id="question-search-grade" aria-required="true">
                    <option value="">Grade</option>
                    <option>Grade 1</option>
                    <option>Grade 2</option>
                    <option>Grade 3</option>
                    <option>Grade 4</option>
                </select>

                <label for="question-search-topic" class="visuallyhidden">Topic</label>
                <select name="question-search-topic" id="question-search-topic" aria-required="true">
                    <option value="">Topic</option>
                    <option>Topic 1</option>
                    <option>Topic 2</option>
                    <option>Topic 3</option>
                    <option>Topic 4</option>
                </select>

                <fieldset class="question-search-form">
                    <label for="question-search-text" class="visuallyhidden">Search</label>
                    <input type="text" class="question-search" id="question-search-text" name="search-term" placeholder="Search" />
                    <input class="search-button" type="submit" value="Go">
                </fieldset>
            </div>
            <div class="col col-24 featured-parent-questions skiplink-content" aria-role="main">
                <h2>Featured Parent Questions</h2>

                <div class="parent-questions">
                    <!-- BEGIN PARTIAL: community/parent_question_card -->
                    <div class="card-parent-question clearfix">
                        <div class="question-image">
                            <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                        </div>
                        <div class="question-info">
                            <a href="REPLACE" class="title">Veniam Autem Quidem Est Commodi Et?</a>
                            <span class="details">In <a href="REPLACE" class="topic">rerum sit</a> - Asked by <a href="REPLACE" class="author">Maisie</a> <span class="bullet">&bull;</span> 7 hours ago</span>
                            <a class="button" href="REPLACE">Follow This Question</a>
                        </div>
                        <div class="question-reply-container">
                            <div class="question-replies"><span class="count-replies">8</span> replies</div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/parent_question_card -->
                    <!-- BEGIN PARTIAL: community/parent_question_card -->
                    <div class="card-parent-question clearfix">
                        <div class="question-image">
                            <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                        </div>
                        <div class="question-info">
                            <a href="REPLACE" class="title">Ut Eum Molestias Maxime Ut Voluptatem?</a>
                            <span class="details">In <a href="REPLACE" class="topic">modi accusamus</a> - Asked by <a href="REPLACE" class="author">Omar</a> <span class="bullet">&bull;</span> 11 hours ago</span>
                            <a class="button" href="REPLACE">Follow This Question</a>
                        </div>
                        <div class="question-reply-container">
                            <div class="question-replies"><span class="count-replies">3</span> replies</div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/parent_question_card -->
                    <!-- BEGIN PARTIAL: community/parent_question_card -->
                    <div class="card-parent-question clearfix">
                        <div class="question-image">
                            <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                        </div>
                        <div class="question-info">
                            <a href="REPLACE" class="title">Dolorem Voluptas Ab Non In Reprehenderit?</a>
                            <span class="details">In <a href="REPLACE" class="topic">maiores expedita</a> - Asked by <a href="REPLACE" class="author">Alonzo</a> <span class="bullet">&bull;</span> 5 hours ago</span>
                            <a class="button" href="REPLACE">Follow This Question</a>
                        </div>
                        <div class="question-reply-container">
                            <div class="question-replies"><span class="count-replies">13</span> replies</div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/parent_question_card -->
                    <!-- BEGIN PARTIAL: community/parent_question_card -->
                    <div class="card-parent-question clearfix">
                        <div class="question-image">
                            <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                        </div>
                        <div class="question-info">
                            <a href="REPLACE" class="title">Architecto Soluta Quis Qui Laudantium Atque?</a>
                            <span class="details">In <a href="REPLACE" class="topic">qui officia</a> - Asked by <a href="REPLACE" class="author">Denis</a> <span class="bullet">&bull;</span> 9 hours ago</span>
                            <a class="button" href="REPLACE">Follow This Question</a>
                        </div>
                        <div class="question-reply-container">
                            <div class="question-replies"><span class="count-replies">7</span> replies</div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/parent_question_card -->
                    <!-- BEGIN PARTIAL: community/parent_question_card -->
                    <div class="card-parent-question clearfix">
                        <div class="question-image">
                            <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                        </div>
                        <div class="question-info">
                            <a href="REPLACE" class="title">Sit Ad Laborum Maxime Eaque Et?</a>
                            <span class="details">In <a href="REPLACE" class="topic">hic ducimus</a> - Asked by <a href="REPLACE" class="author">Danielle</a> <span class="bullet">&bull;</span> 5 hours ago</span>
                            <a class="button" href="REPLACE">Follow This Question</a>
                        </div>
                        <div class="question-reply-container">
                            <div class="question-replies"><span class="count-replies">6</span> replies</div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/parent_question_card -->
                    <!-- BEGIN PARTIAL: community/parent_question_card -->
                    <div class="card-parent-question clearfix">
                        <div class="question-image">
                            <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                        </div>
                        <div class="question-info">
                            <a href="REPLACE" class="title">Eligendi Rem Quis Dolorum Esse Error?</a>
                            <span class="details">In <a href="REPLACE" class="topic">asperiores omnis</a> - Asked by <a href="REPLACE" class="author">Jerald</a> <span class="bullet">&bull;</span> 6 hours ago</span>
                            <a class="button" href="REPLACE">Follow This Question</a>
                        </div>
                        <div class="question-reply-container">
                            <div class="question-replies"><span class="count-replies">9</span> replies</div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/parent_question_card -->
                    <!-- BEGIN PARTIAL: community/parent_question_card -->
                    <div class="card-parent-question clearfix">
                        <div class="question-image">
                            <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                        </div>
                        <div class="question-info">
                            <a href="REPLACE" class="title">Voluptatem Earum Ea Molestiae Illum Delectus?</a>
                            <span class="details">In <a href="REPLACE" class="topic">reiciendis ipsam</a> - Asked by <a href="REPLACE" class="author">Omar</a> <span class="bullet">&bull;</span> 9 hours ago</span>
                            <a class="button" href="REPLACE">Follow This Question</a>
                        </div>
                        <div class="question-reply-container">
                            <div class="question-replies"><span class="count-replies">2</span> replies</div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/parent_question_card -->
                    <!-- BEGIN PARTIAL: community/parent_question_card -->
                    <div class="card-parent-question clearfix">
                        <div class="question-image">
                            <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                        </div>
                        <div class="question-info">
                            <a href="REPLACE" class="title">Sint Consequuntur Mollitia Dolore Quis Vitae?</a>
                            <span class="details">In <a href="REPLACE" class="topic">officiis autem</a> - Asked by <a href="REPLACE" class="author">Giselle</a> <span class="bullet">&bull;</span> 3 hours ago</span>
                            <a class="button" href="REPLACE">Follow This Question</a>
                        </div>
                        <div class="question-reply-container">
                            <div class="question-replies"><span class="count-replies">4</span> replies</div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/parent_question_card -->
                    <!-- BEGIN PARTIAL: community/parent_question_card -->
                    <div class="card-parent-question clearfix">
                        <div class="question-image">
                            <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                        </div>
                        <div class="question-info">
                            <a href="REPLACE" class="title">Qui Sed Eum Eum Aperiam Officiis?</a>
                            <span class="details">In <a href="REPLACE" class="topic">vel et</a> - Asked by <a href="REPLACE" class="author">Phil</a> <span class="bullet">&bull;</span> 2 hours ago</span>
                            <a class="button" href="REPLACE">Follow This Question</a>
                        </div>
                        <div class="question-reply-container">
                            <div class="question-replies"><span class="count-replies">6</span> replies</div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/parent_question_card -->
                    <!-- BEGIN PARTIAL: community/parent_question_card -->
                    <div class="card-parent-question clearfix">
                        <div class="question-image">
                            <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                        </div>
                        <div class="question-info">
                            <a href="REPLACE" class="title">Officia Labore Non Soluta Quis Ea?</a>
                            <span class="details">In <a href="REPLACE" class="topic">voluptatem est</a> - Asked by <a href="REPLACE" class="author">Alexis</a> <span class="bullet">&bull;</span> 11 hours ago</span>
                            <a class="button" href="REPLACE">Follow This Question</a>
                        </div>
                        <div class="question-reply-container">
                            <div class="question-replies"><span class="count-replies">9</span> replies</div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/parent_question_card -->
                </div>

                <!-- Show More -->
                <!-- BEGIN PARTIAL: community/show_more -->
                <!--Show More-->
                <div class="container show-more">
                    <div class="row">
                        <div class="col col-24">
                            <a class="show-more-link " href="#" data-path="community/parent-questions" data-container="parent-questions" data-item="card-parent-question" data-count="6">Show More<i class="icon-arrow-down-blue"></i></a>
                        </div>
                    </div>
                </div>
                <!-- .show-more -->
                <!-- END PARTIAL: community/show_more -->
                <!-- .show-more -->

            </div>

        </div>
    </div>
</div>
