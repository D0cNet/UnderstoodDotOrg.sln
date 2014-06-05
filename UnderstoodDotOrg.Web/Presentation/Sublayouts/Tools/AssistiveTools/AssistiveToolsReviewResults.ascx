<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsReviewResults.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsReviewResults" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: pagetopic -->
<!-- FIXME: Documentation needed to explain share on/off functionality in page topic module -->

<!-- Determine variables present and change column width to fit the content available -->


<!-- Page Title -->
<div class="container page-topic no-bottom-margin">
    <div class="row">
        <div class="col col-14 offset-1">
            <div class="rs_read_this">
                <h1><%= Model.AssistiveToolsBasePage.ContentPage.PageTitle %></h1>
                <%= Model.AssistiveToolsBasePage.ContentPage.PageSummary %>
            </div>
        </div>
        <div class="col col-9">
            <!-- BEGIN PARTIAL: share-save -->
            <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />

            <!-- END PARTIAL: share-save -->
        </div>


    </div>
</div>
<!-- .container -->

<!-- END PARTIAL: pagetopic -->
<div class="container flush search-tool-layout-wrapper at2-wrapper">
    <div class="row">
        <!-- article -->
        <div class="col col-15 skiplink-toolbar">
            <sc:Placeholder ID="Placeholder2" Key="Assistive Tool Search" runat="server" />
        </div>

        <div class="col col-9 tool-related-articles-wrap assistive-tool-related-articles-large">
            <!-- This is where assistive-tool-related-articles will move to in desktop (650px+) view-->
        </div>

    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-24">
            <!-- BEGIN PARTIAL: tech-search-results -->
            <section class="tech-search-results multi">
                <header class="row">
                    <div class="col col-10">
                        <h3 class="rs_read_this">Assistive Technologies</h3>
                        <div class="popover-trigger-container assistive-tooltip-trigger">
                            <a href="REPLACE" class="popover-link rs_preserve " data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a>
                        </div>
                        <div class="assistive-tooltip popover-container">
                            <p class="assistive-tooltip-inner">
                                <strong>Assitive Technology</strong> is any device that helps a person with a disability complete an everyday task. If you break your leg, a remote control for TV can be assistive technology.
          <a href="REPLACE">Learn more</a>
                            </p>
                        </div>
                        <!-- .assistive-tooltip -->
                    </div>

                    <div class="col col-6 push-8">
                    </div>

                    <div class="col col-4 pull-6">
                        <span class="result-count">2 of 6 results</span>
                    </div>
                </header>

                <div class="tech-results-wrapper at-top">
                    <div class="search-result row rs_read_this">
                        <div class="result-image screenshots-popover col col-4 offset-1">
                            <div class="result-image-inner">
                                <!-- This hidden span's content matches the alt tag of the image which ReadSpeaker is ignoring -->
                                <span class="visuallyhidden rs_read">150x150 Placeholder</span>
                                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                </a>
                                <span class="icon-search rs_preserve rs_skip">search</span>
                            </div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content rs_skip">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title rs_skip">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray rs_skip">
                                        <span class="count">
                                            <span class="curr">1</span>
                                            of 3</span>
                                        <div class="rsArrow rsArrowRight">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                        <div class="rsArrow rsArrowLeft">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                    </div>
                                    <div class="slide active">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+1" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+2" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+3" />
                                    </div>
                                </section>
                            </div>
                            <!-- END PARTIAL: assistive-tech-screenshots-popover -->
                            <div class="result-type">(App, 2013)</div>
                        </div>
                        <div class="result-details col col-7 offset-1">
                            <h3 class="result-title">1in5 Stories</h3>
                            <div class="result-description">illo voluptatem labore eveniet debitis nihil nesciunt autem ut odit</div>
                            <div class="result-keywords">
                                <ul>
                                    <li>
                                        <a href="REPLACE">Reading</a></li>
                                    <li>
                                        <a href="REPLACE">Math</a></li>
                                    <li>
                                        <a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating rs_skip">
                                <div class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve rs_skip" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">illo vel incidunt autem et qui est aut ut sit</div>
                                    </div>

                                    <div class="result-ratings col col-11 offset-1">
                                        <div class="rating-label">Grade</div>
                                        <div class="grade-scale-wrapper">
                                            <div class="grade-scale">
                                                <div class="selection grade6">6</div>
                                                <span class="grade1 grade red">1</span>
                                                <span class="grade2 grade red">2</span>
                                                <span class="grade3 grade yellow">3</span>
                                                <span class="grade4 grade yellow">4</span>
                                                <span class="grade5 grade yellow">5</span>
                                                <span class="grade6 grade green">6</span>
                                                <span class="grade7 grade green">7</span>
                                                <span class="grade8 grade green">8</span>
                                                <span class="grade9 grade green">9</span>
                                                <span class="grade10 grade green">10</span>
                                                <span class="grade11 grade green">11</span>
                                                <span class="grade12 grade green">12</span>
                                            </div>
                                        </div>

                                        <div class="rating-label">Quality</div>
                                        <div class="quality-scale-wrapper full-width">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                                <a class="quality-review-link-see-rating" href="REPLACE">4 Reviews</a>
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.result-ratings -->
                                    <div class="view-full-detail">
                                        <a href="REPLACE" class="button">View Full Detail</a>
                                    </div>
                                    <!-- /.view-full-detail -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-12">
                            <div class="rating-label">Grade</div>
                            <div class="grade-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="grade-scale">
                                    <div class="selection grade6">6</div>
                                    <span class="grade1 grade red rs_skip" aria-hidden="true" role="presentation">1</span>
                                    <span class="grade2 grade red rs_skip" aria-hidden="true" role="presentation">2</span>
                                    <span class="grade3 grade yellow rs_skip" aria-hidden="true" role="presentation">3</span>
                                    <span class="grade4 grade yellow rs_skip" aria-hidden="true" role="presentation">4</span>
                                    <span class="grade5 grade yellow rs_skip" aria-hidden="true" role="presentation">5</span>
                                    <span class="grade6 grade green rs_skip" aria-hidden="true" role="presentation">6</span>
                                    <span class="grade7 grade green rs_skip" aria-hidden="true" role="presentation">7</span>
                                    <span class="grade8 grade green rs_skip" aria-hidden="true" role="presentation">8</span>
                                    <span class="grade9 grade green rs_skip" aria-hidden="true" role="presentation">9</span>
                                    <span class="grade10 grade green rs_skip" aria-hidden="true" role="presentation">10</span>
                                    <span class="grade11 grade green rs_skip" aria-hidden="true" role="presentation">11</span>
                                    <span class="grade12 grade green rs_skip" aria-hidden="true" role="presentation">12</span>
                                </div>
                            </div>
                            <div class="grade-info-wrapper rs_skip">
                                <div class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a>
                                </div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle green"></span>
                                            </div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle yellow"></span>
                                            </div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle red"></span>
                                            </div>
                                            <div class="rating-info"><strong>Off:</strong> Not appropriate for kids this age.</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .grade-tooltip -->
                                <!-- END PARTIAL: popover-grade-info -->
                            </div>

                            <div class="rating-label">Quality</div>
                            <div class="quality-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-four" aria-label="4">4</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper rs_skip">
                                <span class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five" aria-label="5">5</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two" aria-label="2">2</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one" aria-label="1">1</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Don't Bother</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .quality-tooltip -->
                                <!-- END PARTIAL: popover-quality-info -->
                                <a class="quality-review-link" href="REPLACE">4 Reviews</a>
                            </div>

                            <div class="rating-label">Learning</div>
                            <div class="learning-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-three" aria-label="3">3</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper rs_skip">
                                    <div class="popover-trigger-container">
                                        <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five" aria-label="5">5</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three" aria-label="3">3</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two" aria-label="2">2</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one" aria-label="1">1</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero" aria-label="0">0</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for kids:</strong> Not age-appropriate for kids; not recommended for learning.</div>
                                            </div>
                                        </div>
                                        <!-- .ratings-wrapper -->
                                    </div>
                                    <!-- .learning-tooltip -->
                                    <!-- END PARTIAL: popover-learning-info -->
                                </div>
                            </div>
                        </div>
                        <!-- .result-ratings -->
                    </div>
                    <!-- .search-result -->


                    <div class="search-result row rs_read_this">
                        <div class="result-image screenshots-popover col col-3 offset-1">
                            <div class="result-image-inner">
                                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" /></a>
                                <span class="icon-search rs_preserve rs_skip">search</span>
                            </div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content rs_skip">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title rs_skip">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray rs_skip">
                                        <span class="count">
                                            <span class="curr">1</span>
                                            of 3</span>
                                        <div class="rsArrow rsArrowRight">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                        <div class="rsArrow rsArrowLeft">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                    </div>
                                    <div class="slide active">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+1" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+2" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+3" />
                                    </div>
                                </section>
                            </div>
                            <!-- END PARTIAL: assistive-tech-screenshots-popover -->
                            <div class="result-type">(App, 2013)</div>
                        </div>
                        <div class="result-details col col-7 offset-1">
                            <h3 class="result-title">Autism Play</h3>
                            <div class="result-description">nesciunt ratione excepturi dolores necessitatibus eum et nisi consequatur non</div>
                            <div class="result-keywords">
                                <ul>
                                    <li>
                                        <a href="REPLACE">Reading</a></li>
                                    <li>
                                        <a href="REPLACE">Math</a></li>
                                    <li>
                                        <a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating rs_skip">
                                <div class="popover-trigger-container rs_skip">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">unde quasi aliquam reprehenderit quia rerum excepturi sit minus eos</div>
                                    </div>

                                    <div class="result-ratings col col-11 offset-1">
                                        <div class="rating-label">Grade</div>
                                        <div class="grade-scale-wrapper">
                                            <div class="grade-scale">
                                                <div class="selection grade6">6</div>
                                                <span class="grade1 grade red">1</span>
                                                <span class="grade2 grade red">2</span>
                                                <span class="grade3 grade yellow">3</span>
                                                <span class="grade4 grade yellow">4</span>
                                                <span class="grade5 grade yellow">5</span>
                                                <span class="grade6 grade green">6</span>
                                                <span class="grade7 grade green">7</span>
                                                <span class="grade8 grade green">8</span>
                                                <span class="grade9 grade green">9</span>
                                                <span class="grade10 grade green">10</span>
                                                <span class="grade11 grade green">11</span>
                                                <span class="grade12 grade green">12</span>
                                            </div>
                                        </div>

                                        <div class="rating-label">Quality</div>
                                        <div class="quality-scale-wrapper full-width">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                                <a class="quality-review-link-see-rating" href="REPLACE">4 Reviews</a>
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.result-ratings -->
                                    <div class="view-full-detail">
                                        <a href="REPLACE" class="button">View Full Detail</a>
                                    </div>
                                    <!-- /.view-full-detail -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-10">
                            <div class="rating-label">Grade</div>
                            <div class="grade-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="grade-scale">
                                    <div class="selection grade8">8</div>
                                    <span class="grade1 grade red rs_skip" aria-hidden="true" role="presentation">1</span>
                                    <span class="grade2 grade red rs_skip" aria-hidden="true" role="presentation">2</span>
                                    <span class="grade3 grade red rs_skip" aria-hidden="true" role="presentation">3</span>
                                    <span class="grade4 grade red rs_skip" aria-hidden="true" role="presentation">4</span>
                                    <span class="grade5 grade red rs_skip" aria-hidden="true" role="presentation">5</span>
                                    <span class="grade6 grade yellow rs_skip" aria-hidden="true" role="presentation">6</span>
                                    <span class="grade7 grade yellow rs_skip" aria-hidden="true" role="presentation">7</span>
                                    <span class="grade8 grade green rs_skip" aria-hidden="true" role="presentation">8</span>
                                    <span class="grade9 grade green rs_skip" aria-hidden="true" role="presentation">9</span>
                                    <span class="grade10 grade green rs_skip" aria-hidden="true" role="presentation">10</span>
                                    <span class="grade11 grade green rs_skip" aria-hidden="true" role="presentation">11</span>
                                    <span class="grade12 grade green rs_skip" aria-hidden="true" role="presentation">12</span>
                                </div>
                            </div>
                            <div class="grade-info-wrapper rs_skip">
                                <div class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle green"></span>
                                            </div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle yellow"></span>
                                            </div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle red"></span>
                                            </div>
                                            <div class="rating-info"><strong>Off:</strong> Not appropriate for kids this age.</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .grade-tooltip -->
                                <!-- END PARTIAL: popover-grade-info -->
                            </div>

                            <div class="rating-label">Quality</div>
                            <div class="quality-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-two" aria-label="2">2</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper rs_skip">
                                <span class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five" aria-label="5">5</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two" aria-label="2">2</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one" aria-label="1">1</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Don't Bother</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .quality-tooltip -->
                                <!-- END PARTIAL: popover-quality-info -->
                                <a class="quality-review-link" href="REPLACE">4 Reviews</a>
                            </div>

                            <div class="rating-label">Learning</div>
                            <div class="learning-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper rs_skip">
                                    <div class="popover-trigger-container">
                                        <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five" aria-label="5">5</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three" aria-label="3">3</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two" aria-label="2">2</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one" aria-label="1">1</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero" aria-label="0">0</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for kids:</strong> Not age-appropriate for kids; not recommended for learning.</div>
                                            </div>
                                        </div>
                                        <!-- .ratings-wrapper -->
                                    </div>
                                    <!-- .learning-tooltip -->
                                    <!-- END PARTIAL: popover-learning-info -->
                                </div>
                            </div>
                        </div>
                        <!-- .result-ratings -->
                    </div>
                    <!-- .search-result -->

                </div>
                <!-- .tech-results-wrapper -->

                <footer>
                    <!-- Show More -->
                    <!-- BEGIN PARTIAL: community/show_more -->
                    <!--Show More-->
                    <div class="container show-more rs_skip">
                        <div class="row">
                            <div class="col col-24">
                                <a class="show-more-link " href="#" data-path="assistive-tech/search-results" data-container="at-top" data-item="search-results" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
                            </div>
                        </div>
                    </div>
                    <!-- .show-more -->
                    <!-- END PARTIAL: community/show_more -->
                    <!-- .show-more -->
                </footer>
            </section>
            <!-- END PARTIAL: tech-search-results -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container assistive-tech-results select-inverted-mobile">
    <div class="row">
        <!-- article -->
        <div class="col col-24 instructional skiplink-content" aria-role="main" aria-role="main">
            <!-- BEGIN PARTIAL: tech-search-results -->
            <section class="tech-search-results multi">
                <header class="row">
                    <div class="col col-10">
                        <h3 class="two-lines rs_read_this">Instructional Technologies</h3>
                        <div class="popover-trigger-container assistive-tooltip-trigger">
                            <a href="REPLACE" class="popover-link rs_preserve " data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a>
                        </div>
                        <div class="assistive-tooltip popover-container">
                            <p class="assistive-tooltip-inner">
                                <strong>Assitive Technology</strong> is any device that helps a person with a disability complete an everyday task. If you break your leg, a remote control for TV can be assistive technology.
          <a href="REPLACE">Learn more</a>
                            </p>
                        </div>
                        <!-- .assistive-tooltip -->
                    </div>

                    <div class="col col-6 push-8">

                        <fieldset>
                            <span class="select-container sort">
                                <label class="visuallyhidden">Sort by</label>
                                <select name="tech-search-sort">
                                    <option value="">Sort by</option>
                                    <option>A-Z</option>
                                    <option>Z-A</option>
                                </select>
                            </span>
                        </fieldset>

                    </div>

                    <div class="col col-4 pull-6">
                        <span class="result-count">2 of 6 results</span>
                    </div>
                </header>

                <div class="tech-results-wrapper at-bottom">
                    <div class="search-result row rs_read_this">
                        <div class="result-image screenshots-popover col col-4 offset-1">
                            <div class="result-image-inner">
                                <!-- This hidden span's content matches the alt tag of the image which ReadSpeaker is ignoring -->
                                <span class="visuallyhidden rs_read">150x150 Placeholder</span>
                                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                </a>
                                <span class="icon-search rs_preserve rs_skip">search</span>
                            </div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content rs_skip">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title rs_skip">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray rs_skip">
                                        <span class="count">
                                            <span class="curr">1</span>
                                            of 3</span>
                                        <div class="rsArrow rsArrowRight">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                        <div class="rsArrow rsArrowLeft">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                    </div>
                                    <div class="slide active">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+1" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+2" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+3" />
                                    </div>
                                </section>
                            </div>
                            <!-- END PARTIAL: assistive-tech-screenshots-popover -->
                            <div class="result-type">(App, 2013)</div>
                        </div>
                        <div class="result-details col col-7 offset-1">
                            <h3 class="result-title">1in5 Stories</h3>
                            <div class="result-description">quibusdam possimus eum qui eum error consequatur facere facere sint</div>
                            <div class="result-keywords">
                                <ul>
                                    <li>
                                        <a href="REPLACE">Reading</a></li>
                                    <li>
                                        <a href="REPLACE">Math</a></li>
                                    <li>
                                        <a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating rs_skip">
                                <div class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve rs_skip" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">omnis velit sit eum numquam dolore voluptas voluptatem omnis quae</div>
                                    </div>

                                    <div class="result-ratings col col-11 offset-1">
                                        <div class="rating-label">Grade</div>
                                        <div class="grade-scale-wrapper">
                                            <div class="grade-scale">
                                                <div class="selection grade6">6</div>
                                                <span class="grade1 grade red">1</span>
                                                <span class="grade2 grade red">2</span>
                                                <span class="grade3 grade yellow">3</span>
                                                <span class="grade4 grade yellow">4</span>
                                                <span class="grade5 grade yellow">5</span>
                                                <span class="grade6 grade green">6</span>
                                                <span class="grade7 grade green">7</span>
                                                <span class="grade8 grade green">8</span>
                                                <span class="grade9 grade green">9</span>
                                                <span class="grade10 grade green">10</span>
                                                <span class="grade11 grade green">11</span>
                                                <span class="grade12 grade green">12</span>
                                            </div>
                                        </div>

                                        <div class="rating-label">Quality</div>
                                        <div class="quality-scale-wrapper full-width">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                                <a class="quality-review-link-see-rating" href="REPLACE">4 Reviews</a>
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.result-ratings -->
                                    <div class="view-full-detail">
                                        <a href="REPLACE" class="button">View Full Detail</a>
                                    </div>
                                    <!-- /.view-full-detail -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-12">
                            <div class="rating-label">Grade</div>
                            <div class="grade-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="grade-scale">
                                    <div class="selection grade6">6</div>
                                    <span class="grade1 grade red rs_skip" aria-hidden="true" role="presentation">1</span>
                                    <span class="grade2 grade red rs_skip" aria-hidden="true" role="presentation">2</span>
                                    <span class="grade3 grade yellow rs_skip" aria-hidden="true" role="presentation">3</span>
                                    <span class="grade4 grade yellow rs_skip" aria-hidden="true" role="presentation">4</span>
                                    <span class="grade5 grade yellow rs_skip" aria-hidden="true" role="presentation">5</span>
                                    <span class="grade6 grade green rs_skip" aria-hidden="true" role="presentation">6</span>
                                    <span class="grade7 grade green rs_skip" aria-hidden="true" role="presentation">7</span>
                                    <span class="grade8 grade green rs_skip" aria-hidden="true" role="presentation">8</span>
                                    <span class="grade9 grade green rs_skip" aria-hidden="true" role="presentation">9</span>
                                    <span class="grade10 grade green rs_skip" aria-hidden="true" role="presentation">10</span>
                                    <span class="grade11 grade green rs_skip" aria-hidden="true" role="presentation">11</span>
                                    <span class="grade12 grade green rs_skip" aria-hidden="true" role="presentation">12</span>
                                </div>
                            </div>
                            <div class="grade-info-wrapper rs_skip">
                                <div class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a>
                                </div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle green"></span>
                                            </div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle yellow"></span>
                                            </div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle red"></span>
                                            </div>
                                            <div class="rating-info"><strong>Off:</strong> Not appropriate for kids this age.</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .grade-tooltip -->
                                <!-- END PARTIAL: popover-grade-info -->
                            </div>

                            <div class="rating-label">Quality</div>
                            <div class="quality-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-four" aria-label="4">4</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper rs_skip">
                                <span class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five" aria-label="5">5</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two" aria-label="2">2</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one" aria-label="1">1</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Don't Bother</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .quality-tooltip -->
                                <!-- END PARTIAL: popover-quality-info -->
                                <a class="quality-review-link" href="REPLACE">4 Reviews</a>
                            </div>

                            <div class="rating-label">Learning</div>
                            <div class="learning-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-three" aria-label="3">3</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper rs_skip">
                                    <div class="popover-trigger-container">
                                        <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five" aria-label="5">5</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three" aria-label="3">3</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two" aria-label="2">2</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one" aria-label="1">1</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero" aria-label="0">0</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for kids:</strong> Not age-appropriate for kids; not recommended for learning.</div>
                                            </div>
                                        </div>
                                        <!-- .ratings-wrapper -->
                                    </div>
                                    <!-- .learning-tooltip -->
                                    <!-- END PARTIAL: popover-learning-info -->
                                </div>
                            </div>
                        </div>
                        <!-- .result-ratings -->
                    </div>
                    <!-- .search-result -->


                    <div class="search-result row rs_read_this">
                        <div class="result-image screenshots-popover col col-3 offset-1">
                            <div class="result-image-inner">
                                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" /></a>
                                <span class="icon-search rs_preserve rs_skip">search</span>
                            </div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content rs_skip">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title rs_skip">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray rs_skip">
                                        <span class="count">
                                            <span class="curr">1</span>
                                            of 3</span>
                                        <div class="rsArrow rsArrowRight">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                        <div class="rsArrow rsArrowLeft">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                    </div>
                                    <div class="slide active">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+1" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+2" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+3" />
                                    </div>
                                </section>
                            </div>
                            <!-- END PARTIAL: assistive-tech-screenshots-popover -->
                            <div class="result-type">(App, 2013)</div>
                        </div>
                        <div class="result-details col col-7 offset-1">
                            <h3 class="result-title">Autism Play</h3>
                            <div class="result-description">dolorum corrupti molestiae quia labore nam inventore nostrum debitis pariatur</div>
                            <div class="result-keywords">
                                <ul>
                                    <li>
                                        <a href="REPLACE">Reading</a></li>
                                    <li>
                                        <a href="REPLACE">Math</a></li>
                                    <li>
                                        <a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating rs_skip">
                                <div class="popover-trigger-container rs_skip">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">et deleniti harum ut enim harum laborum animi sit est</div>
                                    </div>

                                    <div class="result-ratings col col-11 offset-1">
                                        <div class="rating-label">Grade</div>
                                        <div class="grade-scale-wrapper">
                                            <div class="grade-scale">
                                                <div class="selection grade6">6</div>
                                                <span class="grade1 grade red">1</span>
                                                <span class="grade2 grade red">2</span>
                                                <span class="grade3 grade yellow">3</span>
                                                <span class="grade4 grade yellow">4</span>
                                                <span class="grade5 grade yellow">5</span>
                                                <span class="grade6 grade green">6</span>
                                                <span class="grade7 grade green">7</span>
                                                <span class="grade8 grade green">8</span>
                                                <span class="grade9 grade green">9</span>
                                                <span class="grade10 grade green">10</span>
                                                <span class="grade11 grade green">11</span>
                                                <span class="grade12 grade green">12</span>
                                            </div>
                                        </div>

                                        <div class="rating-label">Quality</div>
                                        <div class="quality-scale-wrapper full-width">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                                <a class="quality-review-link-see-rating" href="REPLACE">4 Reviews</a>
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.result-ratings -->
                                    <div class="view-full-detail">
                                        <a href="REPLACE" class="button">View Full Detail</a>
                                    </div>
                                    <!-- /.view-full-detail -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-10">
                            <div class="rating-label">Grade</div>
                            <div class="grade-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="grade-scale">
                                    <div class="selection grade8">8</div>
                                    <span class="grade1 grade red rs_skip" aria-hidden="true" role="presentation">1</span>
                                    <span class="grade2 grade red rs_skip" aria-hidden="true" role="presentation">2</span>
                                    <span class="grade3 grade red rs_skip" aria-hidden="true" role="presentation">3</span>
                                    <span class="grade4 grade red rs_skip" aria-hidden="true" role="presentation">4</span>
                                    <span class="grade5 grade red rs_skip" aria-hidden="true" role="presentation">5</span>
                                    <span class="grade6 grade yellow rs_skip" aria-hidden="true" role="presentation">6</span>
                                    <span class="grade7 grade yellow rs_skip" aria-hidden="true" role="presentation">7</span>
                                    <span class="grade8 grade green rs_skip" aria-hidden="true" role="presentation">8</span>
                                    <span class="grade9 grade green rs_skip" aria-hidden="true" role="presentation">9</span>
                                    <span class="grade10 grade green rs_skip" aria-hidden="true" role="presentation">10</span>
                                    <span class="grade11 grade green rs_skip" aria-hidden="true" role="presentation">11</span>
                                    <span class="grade12 grade green rs_skip" aria-hidden="true" role="presentation">12</span>
                                </div>
                            </div>
                            <div class="grade-info-wrapper rs_skip">
                                <div class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle green"></span>
                                            </div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle yellow"></span>
                                            </div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle red"></span>
                                            </div>
                                            <div class="rating-info"><strong>Off:</strong> Not appropriate for kids this age.</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .grade-tooltip -->
                                <!-- END PARTIAL: popover-grade-info -->
                            </div>

                            <div class="rating-label">Quality</div>
                            <div class="quality-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-two" aria-label="2">2</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper rs_skip">
                                <span class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five" aria-label="5">5</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two" aria-label="2">2</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one" aria-label="1">1</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Don't Bother</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .quality-tooltip -->
                                <!-- END PARTIAL: popover-quality-info -->
                                <a class="quality-review-link" href="REPLACE">4 Reviews</a>
                            </div>

                            <div class="rating-label">Learning</div>
                            <div class="learning-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper rs_skip">
                                    <div class="popover-trigger-container">
                                        <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five" aria-label="5">5</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three" aria-label="3">3</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two" aria-label="2">2</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one" aria-label="1">1</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero" aria-label="0">0</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for kids:</strong> Not age-appropriate for kids; not recommended for learning.</div>
                                            </div>
                                        </div>
                                        <!-- .ratings-wrapper -->
                                    </div>
                                    <!-- .learning-tooltip -->
                                    <!-- END PARTIAL: popover-learning-info -->
                                </div>
                            </div>
                        </div>
                        <!-- .result-ratings -->
                    </div>
                    <!-- .search-result -->

                    <div class="search-result row rs_read_this">
                        <div class="result-image screenshots-popover col col-3 offset-1">
                            <div class="result-image-inner">
                                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" /></a>
                                <span class="icon-search rs_preserve rs_skip">search</span>
                            </div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content rs_skip">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title rs_skip">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray rs_skip">
                                        <span class="count">
                                            <span class="curr">1</span>
                                            of 3</span>
                                        <div class="rsArrow rsArrowRight">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                        <div class="rsArrow rsArrowLeft">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                    </div>
                                    <div class="slide active">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+1" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+2" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+3" />
                                    </div>
                                </section>
                            </div>
                            <!-- END PARTIAL: assistive-tech-screenshots-popover -->
                            <div class="result-type">(App, 2013)</div>
                        </div>
                        <div class="result-details col col-7 offset-1">
                            <h3 class="result-title">Autism Play</h3>
                            <div class="result-description">qui expedita voluptatem at expedita et ipsum temporibus et optio</div>
                            <div class="result-keywords">
                                <ul>
                                    <li>
                                        <a href="REPLACE">Reading</a></li>
                                    <li>
                                        <a href="REPLACE">Math</a></li>
                                    <li>
                                        <a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating rs_skip">
                                <div class="popover-trigger-container rs_skip">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">earum eaque eveniet omnis deleniti dolorem incidunt omnis quisquam at</div>
                                    </div>

                                    <div class="result-ratings col col-11 offset-1">
                                        <div class="rating-label">Grade</div>
                                        <div class="grade-scale-wrapper">
                                            <div class="grade-scale">
                                                <div class="selection grade6">6</div>
                                                <span class="grade1 grade red">1</span>
                                                <span class="grade2 grade red">2</span>
                                                <span class="grade3 grade yellow">3</span>
                                                <span class="grade4 grade yellow">4</span>
                                                <span class="grade5 grade yellow">5</span>
                                                <span class="grade6 grade green">6</span>
                                                <span class="grade7 grade green">7</span>
                                                <span class="grade8 grade green">8</span>
                                                <span class="grade9 grade green">9</span>
                                                <span class="grade10 grade green">10</span>
                                                <span class="grade11 grade green">11</span>
                                                <span class="grade12 grade green">12</span>
                                            </div>
                                        </div>

                                        <div class="rating-label">Quality</div>
                                        <div class="quality-scale-wrapper full-width">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                                <a class="quality-review-link-see-rating" href="REPLACE">4 Reviews</a>
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.result-ratings -->
                                    <div class="view-full-detail">
                                        <a href="REPLACE" class="button">View Full Detail</a>
                                    </div>
                                    <!-- /.view-full-detail -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-10">
                            <div class="rating-label">Grade</div>
                            <div class="grade-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="grade-scale">
                                    <div class="selection grade8">8</div>
                                    <span class="grade1 grade red rs_skip" aria-hidden="true" role="presentation">1</span>
                                    <span class="grade2 grade red rs_skip" aria-hidden="true" role="presentation">2</span>
                                    <span class="grade3 grade red rs_skip" aria-hidden="true" role="presentation">3</span>
                                    <span class="grade4 grade red rs_skip" aria-hidden="true" role="presentation">4</span>
                                    <span class="grade5 grade red rs_skip" aria-hidden="true" role="presentation">5</span>
                                    <span class="grade6 grade yellow rs_skip" aria-hidden="true" role="presentation">6</span>
                                    <span class="grade7 grade yellow rs_skip" aria-hidden="true" role="presentation">7</span>
                                    <span class="grade8 grade green rs_skip" aria-hidden="true" role="presentation">8</span>
                                    <span class="grade9 grade green rs_skip" aria-hidden="true" role="presentation">9</span>
                                    <span class="grade10 grade green rs_skip" aria-hidden="true" role="presentation">10</span>
                                    <span class="grade11 grade green rs_skip" aria-hidden="true" role="presentation">11</span>
                                    <span class="grade12 grade green rs_skip" aria-hidden="true" role="presentation">12</span>
                                </div>
                            </div>
                            <div class="grade-info-wrapper rs_skip">
                                <div class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle green"></span>
                                            </div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle yellow"></span>
                                            </div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle red"></span>
                                            </div>
                                            <div class="rating-info"><strong>Off:</strong> Not appropriate for kids this age.</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .grade-tooltip -->
                                <!-- END PARTIAL: popover-grade-info -->
                            </div>

                            <div class="rating-label">Quality</div>
                            <div class="quality-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-two" aria-label="2">2</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper rs_skip">
                                <span class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five" aria-label="5">5</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two" aria-label="2">2</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one" aria-label="1">1</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Don't Bother</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .quality-tooltip -->
                                <!-- END PARTIAL: popover-quality-info -->
                                <a class="quality-review-link" href="REPLACE">4 Reviews</a>
                            </div>

                            <div class="rating-label">Learning</div>
                            <div class="learning-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper rs_skip">
                                    <div class="popover-trigger-container">
                                        <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five" aria-label="5">5</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three" aria-label="3">3</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two" aria-label="2">2</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one" aria-label="1">1</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero" aria-label="0">0</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for kids:</strong> Not age-appropriate for kids; not recommended for learning.</div>
                                            </div>
                                        </div>
                                        <!-- .ratings-wrapper -->
                                    </div>
                                    <!-- .learning-tooltip -->
                                    <!-- END PARTIAL: popover-learning-info -->
                                </div>
                            </div>
                        </div>
                        <!-- .result-ratings -->
                    </div>
                    <!-- .search-result -->

                    <div class="search-result row rs_read_this">
                        <div class="result-image screenshots-popover col col-3 offset-1">
                            <div class="result-image-inner">
                                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" /></a>
                                <span class="icon-search rs_preserve rs_skip">search</span>
                            </div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content rs_skip">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title rs_skip">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray rs_skip">
                                        <span class="count">
                                            <span class="curr">1</span>
                                            of 3</span>
                                        <div class="rsArrow rsArrowRight">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                        <div class="rsArrow rsArrowLeft">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                    </div>
                                    <div class="slide active">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+1" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+2" />
                                    </div>
                                    <div class="slide">
                                        <img alt="270x180 Placeholder" src="http://placehold.it/270x180&amp;text=Shot+3" />
                                    </div>
                                </section>
                            </div>
                            <!-- END PARTIAL: assistive-tech-screenshots-popover -->
                            <div class="result-type">(App, 2013)</div>
                        </div>
                        <div class="result-details col col-7 offset-1">
                            <h3 class="result-title">Autism Play</h3>
                            <div class="result-description">eos iure voluptatum pariatur at adipisci assumenda vel ipsa velit</div>
                            <div class="result-keywords">
                                <ul>
                                    <li>
                                        <a href="REPLACE">Reading</a></li>
                                    <li>
                                        <a href="REPLACE">Math</a></li>
                                    <li>
                                        <a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating rs_skip">
                                <div class="popover-trigger-container rs_skip">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">amet harum voluptatem deserunt dolorem veritatis temporibus est iusto praesentium</div>
                                    </div>

                                    <div class="result-ratings col col-11 offset-1">
                                        <div class="rating-label">Grade</div>
                                        <div class="grade-scale-wrapper">
                                            <div class="grade-scale">
                                                <div class="selection grade6">6</div>
                                                <span class="grade1 grade red">1</span>
                                                <span class="grade2 grade red">2</span>
                                                <span class="grade3 grade yellow">3</span>
                                                <span class="grade4 grade yellow">4</span>
                                                <span class="grade5 grade yellow">5</span>
                                                <span class="grade6 grade green">6</span>
                                                <span class="grade7 grade green">7</span>
                                                <span class="grade8 grade green">8</span>
                                                <span class="grade9 grade green">9</span>
                                                <span class="grade10 grade green">10</span>
                                                <span class="grade11 grade green">11</span>
                                                <span class="grade12 grade green">12</span>
                                            </div>
                                        </div>

                                        <div class="rating-label">Quality</div>
                                        <div class="quality-scale-wrapper full-width">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                                <a class="quality-review-link-see-rating" href="REPLACE">4 Reviews</a>
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.result-ratings -->
                                    <div class="view-full-detail">
                                        <a href="REPLACE" class="button">View Full Detail</a>
                                    </div>
                                    <!-- /.view-full-detail -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-10">
                            <div class="rating-label">Grade</div>
                            <div class="grade-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="grade-scale">
                                    <div class="selection grade8">8</div>
                                    <span class="grade1 grade red rs_skip" aria-hidden="true" role="presentation">1</span>
                                    <span class="grade2 grade red rs_skip" aria-hidden="true" role="presentation">2</span>
                                    <span class="grade3 grade red rs_skip" aria-hidden="true" role="presentation">3</span>
                                    <span class="grade4 grade red rs_skip" aria-hidden="true" role="presentation">4</span>
                                    <span class="grade5 grade red rs_skip" aria-hidden="true" role="presentation">5</span>
                                    <span class="grade6 grade yellow rs_skip" aria-hidden="true" role="presentation">6</span>
                                    <span class="grade7 grade yellow rs_skip" aria-hidden="true" role="presentation">7</span>
                                    <span class="grade8 grade green rs_skip" aria-hidden="true" role="presentation">8</span>
                                    <span class="grade9 grade green rs_skip" aria-hidden="true" role="presentation">9</span>
                                    <span class="grade10 grade green rs_skip" aria-hidden="true" role="presentation">10</span>
                                    <span class="grade11 grade green rs_skip" aria-hidden="true" role="presentation">11</span>
                                    <span class="grade12 grade green rs_skip" aria-hidden="true" role="presentation">12</span>
                                </div>
                            </div>
                            <div class="grade-info-wrapper rs_skip">
                                <div class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle green"></span>
                                            </div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle yellow"></span>
                                            </div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <span class="circle red"></span>
                                            </div>
                                            <div class="rating-info"><strong>Off:</strong> Not appropriate for kids this age.</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .grade-tooltip -->
                                <!-- END PARTIAL: popover-grade-info -->
                            </div>

                            <div class="rating-label">Quality</div>
                            <div class="quality-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-two" aria-label="2">2</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper rs_skip">
                                <span class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five" aria-label="5">5</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three" aria-label="3">3</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two" aria-label="2">2</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one" aria-label="1">1</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Don't Bother</div>
                                        </div>
                                    </div>
                                    <!-- .ratings-wrapper -->
                                </div>
                                <!-- .quality-tooltip -->
                                <!-- END PARTIAL: popover-quality-info -->
                                <a class="quality-review-link" href="REPLACE">4 Reviews</a>
                            </div>

                            <div class="rating-label">Learning</div>
                            <div class="learning-scale-wrapper">
                                <span class="visuallyhidden">rating</span>
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper rs_skip">
                                    <div class="popover-trigger-container">
                                        <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five" aria-label="5">5</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three" aria-label="3">3</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two" aria-label="2">2</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one" aria-label="1">1</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero" aria-label="0">0</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for kids:</strong> Not age-appropriate for kids; not recommended for learning.</div>
                                            </div>
                                        </div>
                                        <!-- .ratings-wrapper -->
                                    </div>
                                    <!-- .learning-tooltip -->
                                    <!-- END PARTIAL: popover-learning-info -->
                                </div>
                            </div>
                        </div>
                        <!-- .result-ratings -->
                    </div>
                    <!-- .search-result -->

                </div>
                <!-- .tech-results-wrapper -->

                <footer>
                    <!-- Show More -->
                    <!-- BEGIN PARTIAL: community/show_more -->
                    <!--Show More-->
                    <div class="container show-more rs_skip">
                        <div class="row">
                            <div class="col col-24">
                                <a class="show-more-link " href="#" data-path="assistive-tech/search-results" data-container="at-bottom" data-item="search-results" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
                            </div>
                        </div>
                    </div>
                    <!-- .show-more -->
                    <!-- END PARTIAL: community/show_more -->
                    <!-- .show-more -->
                </footer>
            </section>
            <!-- END PARTIAL: tech-search-results -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="assistive-tool-related-articles-small">
    <!-- BEGIN PARTIAL: assistive-tool-related-articles -->
    <div class="assistive-tool-related-articles">
        <ul>
            <li>
                <a href="REPLACE">10 Questions to ask about behavior issues</a></li>
            <li>
                <a href="REPLACE">10 Questions to ask about behavior issues</a></li>
            <li>
                <a href="REPLACE">10 Questions to ask about behavior issues</a></li>
            <li>
                <a href="REPLACE">10 Questions to ask about behavior issues</a></li>
        </ul>
    </div>
    <!-- .tool-related-articles -->
    <!-- END PARTIAL: assistive-tool-related-articles -->
    <!-- This is where assistive-tool-related-articles will move to in mobile view-->
</div>
