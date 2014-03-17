<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsReviewResults.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsReviewResults" %>

<!-- BEGIN PARTIAL: pagetopic -->
<!-- Page Title -->
<div class="container page-topic no-bottom-margin">
    <div class="row">
        <div class="col col-14 offset-1">

            <h1>Lorem ipsum dolar</h1>

            <p class="page-subtitle">Lorem ipsum dolor sit amet, consectetur adipiscing elit nulla egestas</p>

        </div>

        <div class="col col-9">
            <!-- BEGIN PARTIAL: share-save -->
            <div class="share-save-container">
                <div class="share-save-social-icon">
                    <div class="toggle">
                        <a href="REPLACE" class="socicon icon-facebook">Facebook</a><br />
                        <a href="REPLACE" class="socicon icon-twitter">Twitter</a><br />
                        <a href="REPLACE" class="socicon icon-googleplus">Google&#43;</a><br />
                        <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
                    </div>
                </div>
                <div class="share-save-icon">
                    <h3>Share &amp; Save</h3>
                    <!-- leave no white space for layout consistency -->
                    <a href="REPLACE" class="icon icon-share">Share</a><span class="tools"><a href="REPLACE" class="icon icon-email">Email</a><a href="REPLACE" class="icon icon-save">Save</a><a href="REPLACE" class="icon icon-print">Print</a><a href="REPLACE" class="icon icon-remind">Remind</a><a href="REPLACE" class="icon icon-rss">RSS</a></span>
                </div>
            </div>

            <!-- END PARTIAL: share-save -->
        </div>

    </div>
</div>
<!-- .container -->

<!-- END PARTIAL: pagetopic -->
<div class="container flush search-tool-layout-wrapper">
    <div class="row">
        <!-- article -->
        <div class="col col-15">
            <!-- BEGIN PARTIAL: at-search-tool -->
            <div id="search-by-tool-tabs">
                <ul>
                    <li class="browse-by-tab">
                        <a href="#browse-by">Browse By</a>
                        <!-- Needs to be on one line to prevent whitespace -->
                    </li>
                    <li class="search-by-tab">
                        <a href="#search-by">Search By</a>
                    </li>
                </ul>

                <div id="browse-by">
                    <div class="form">
                        <fieldset>
                            <select name="at-browse-by-issues" id="at-browse-by-issues" required aria-required="true">
                                <option>Select Issue</option>
                                <option>Issue Value 1</option>
                                <option>Issue Value 2</option>
                                <option>Issue Value 3</option>
                            </select>
                            <select name="at-browse-by-grade" id="at-browse-by-grade" required aria-required="true">
                                <option>Select Grade</option>
                                <option>Pre-K - K</option>
                                <option>3 - 5</option>
                                <option>6 - 8</option>
                                <option>9 - 12</option>
                            </select>
                            <select name="at-browse-by-technology" id="at-browse-by-technology" class="tech parent small-width" required aria-required="true">
                                <option>Select Technology</option>
                                <option value="at-browse-by-app">Apps</option>
                                <option value="at-browse-by-games">Games</option>
                                <option>Websites</option>
                                <option>Assistive Technology</option>
                            </select>
                            <select name="at-browse-by-app" id="at-browse-by-app" class="tech child small-width" style="display: none;">
                                <option>Select Platform</option>
                                <option>all platforms</option>
                                <option>iPhone</option>
                                <option>iPod Touch</option>
                                <option>iPad</option>
                                <option>Android</option>
                                <option>Kindle Fire</option>
                                <option>Nook HD</option>
                            </select>
                            <select name="at-browse-by-games" id="at-browse-by-games" class="tech child small-width" style="display: none;">
                                <option>Select Platform</option>
                                <option>[List of Games]</option>
                                <option>
                                    <!-- retrive games from website -->
                                </option>
                            </select>
                            <div class="submit-button-container">
                                <input class="submit-button" type="submit" value="Find"></div>
                        </fieldset>
                    </div>
                </div>
                <!-- /.browse-by -->
                <div id="search-by">
                    <div class="form">
                        <fieldset>
                            <label for="at-search-by" class="visuallyhidden"></label>
                            <input type="text" name="at-search-by" id="at-search-by">
                            <div class="submit-button-container2">
                                <input class="submit-button" type="submit" value="Find"></div>
                        </fieldset>
                    </div>
                    <!-- .form -->
                </div>
                <div class="powered-by-logo-container">
                    <div class="powered-by-logo">
                        <span>Powered by</span>
                    </div>
                </div>
            </div>
            <!-- END PARTIAL: at-search-tool -->
        </div>

        <div class="col col-9 tool-related-articles-wrap assistive-tool-related-articles-large">
            <!-- This is where behavior-tool-related-articles will move to in desktop (650px+) view-->
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
            <section class="tech-search-results">
                <header>
                    <h3>Assistive Technologies</h3>
                    <div class="popover-trigger-container assistive-tooltip-trigger">
                        <a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip"></i></a>
                    </div>
                    <div class="assistive-tooltip popover-container">
                        <p class="assistive-tooltip-inner">
                            <strong>Assitive Technology</strong> is any device that helps a person with a disability complete an everyday task. If you break your leg, a remote control for TV can be assistive technology.
       
                            <a href="REPLACE">Learn more</a>
                        </p>
                    </div>
                    <!-- .assistive-tooltip -->


                    <span class="result-count">2 of 6 results</span>
                </header>

                <div class="tech-results-wrapper">
                    <div class="search-result row">
                        <div class="result-image screenshots-popover col col-4 offset-1">
                            <div>
                                <a href="REPLACE" class="popover-link" data-popover-placement="bottom">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                </a>
                            </div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray">
                                        <span class="count"><span class="curr">1</span> of 3</span>
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
                            <div class="result-title">1in5 Stories</div>
                            <div class="result-description">iure praesentium tempore quam autem consequuntur enim qui repellendus occaecati</div>
                            <div class="result-keywords">
                                <ul>
                                    <li><a href="REPLACE">Reading</a></li>
                                    <li><a href="REPLACE">Math</a></li>
                                    <li><a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating">
                                <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">est sit sit est est est facilis eos consequatur alias</div>
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
                                        <div class="quality-scale-wrapper">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- .result-ratings -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-10">
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
                            <div class="grade-info-wrapper">
                                <div class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a>
                                </div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle green"></span></div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle yellow"></span></div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle red"></span></div>
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
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-four">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper">
                                <span class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one">&nbsp;</div>
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
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-three">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper">
                                    <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero">&nbsp;</div>
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


                    <div class="search-result row">
                        <div class="result-image screenshots-popover col col-3 offset-1">
                            <div><a href="REPLACE" class="popover-link" data-popover-placement="bottom">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" /></a></div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray">
                                        <span class="count"><span class="curr">1</span> of 3</span>
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
                            <div class="result-title">Autism Play</div>
                            <div class="result-description">repellat ut animi voluptatibus dolores asperiores vel nulla voluptatem quas</div>
                            <div class="result-keywords">
                                <ul>
                                    <li><a href="REPLACE">Reading</a></li>
                                    <li><a href="REPLACE">Math</a></li>
                                    <li><a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating">
                                <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">nobis sunt ad reprehenderit rerum unde debitis et ut provident</div>
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
                                        <div class="quality-scale-wrapper">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- .result-ratings -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-10">
                            <div class="rating-label">Grade</div>
                            <div class="grade-scale-wrapper">
                                <div class="grade-scale">
                                    <div class="selection grade8">8</div>
                                    <span class="grade1 grade red">1</span>
                                    <span class="grade2 grade red">2</span>
                                    <span class="grade3 grade red">3</span>
                                    <span class="grade4 grade red">4</span>
                                    <span class="grade5 grade red">5</span>
                                    <span class="grade6 grade yellow">6</span>
                                    <span class="grade7 grade yellow">7</span>
                                    <span class="grade8 grade green">8</span>
                                    <span class="grade9 grade green">9</span>
                                    <span class="grade10 grade green">10</span>
                                    <span class="grade11 grade green">11</span>
                                    <span class="grade12 grade green">12</span>
                                </div>
                            </div>
                            <div class="grade-info-wrapper">
                                <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle green"></span></div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle yellow"></span></div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle red"></span></div>
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
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-two">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper">
                                <span class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one">&nbsp;</div>
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
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-four">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper">
                                    <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero">&nbsp;</div>
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
                    <a class="results-more-link" href="REPLACE"><span>More Results</span><i class="icon-results-more"></i></a>
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
        <div class="col col-24 instructional">
            <!-- BEGIN PARTIAL: tech-search-results -->
            <section class="tech-search-results">
                <header>
                    <h3 class="two-lines">Instructional Technologies</h3>
                    <div class="popover-trigger-container assistive-tooltip-trigger">
                        <a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip"></i></a>
                    </div>
                    <div class="assistive-tooltip popover-container">
                        <p class="assistive-tooltip-inner">
                            <strong>Assitive Technology</strong> is any device that helps a person with a disability complete an everyday task. If you break your leg, a remote control for TV can be assistive technology.
       
                            <a href="REPLACE">Learn more</a>
                        </p>
                    </div>
                    <!-- .assistive-tooltip -->


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

                    <span class="result-count">2 of 6 results</span>
                </header>

                <div class="tech-results-wrapper">
                    <div class="search-result row">
                        <div class="result-image screenshots-popover col col-4 offset-1">
                            <div>
                                <a href="REPLACE" class="popover-link" data-popover-placement="bottom">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                </a>
                            </div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray">
                                        <span class="count"><span class="curr">1</span> of 3</span>
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
                            <div class="result-title">1in5 Stories</div>
                            <div class="result-description">adipisci omnis ut rerum perferendis repellat dolores quia et exercitationem</div>
                            <div class="result-keywords">
                                <ul>
                                    <li><a href="REPLACE">Reading</a></li>
                                    <li><a href="REPLACE">Math</a></li>
                                    <li><a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating">
                                <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">in non vel voluptatem amet iure molestias fugit assumenda quas</div>
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
                                        <div class="quality-scale-wrapper">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- .result-ratings -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-10">
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
                            <div class="grade-info-wrapper">
                                <div class="popover-trigger-container">
                                    <a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a>
                                </div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle green"></span></div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle yellow"></span></div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle red"></span></div>
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
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-four">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper">
                                <span class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one">&nbsp;</div>
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
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-three">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper">
                                    <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero">&nbsp;</div>
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


                    <div class="search-result row">
                        <div class="result-image screenshots-popover col col-3 offset-1">
                            <div><a href="REPLACE" class="popover-link" data-popover-placement="bottom">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" /></a></div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray">
                                        <span class="count"><span class="curr">1</span> of 3</span>
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
                            <div class="result-title">Autism Play</div>
                            <div class="result-description">nihil cumque aut suscipit optio eveniet asperiores impedit dolor in</div>
                            <div class="result-keywords">
                                <ul>
                                    <li><a href="REPLACE">Reading</a></li>
                                    <li><a href="REPLACE">Math</a></li>
                                    <li><a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating">
                                <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">cumque adipisci et non atque et facere quia similique fuga</div>
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
                                        <div class="quality-scale-wrapper">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- .result-ratings -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-10">
                            <div class="rating-label">Grade</div>
                            <div class="grade-scale-wrapper">
                                <div class="grade-scale">
                                    <div class="selection grade8">8</div>
                                    <span class="grade1 grade red">1</span>
                                    <span class="grade2 grade red">2</span>
                                    <span class="grade3 grade red">3</span>
                                    <span class="grade4 grade red">4</span>
                                    <span class="grade5 grade red">5</span>
                                    <span class="grade6 grade yellow">6</span>
                                    <span class="grade7 grade yellow">7</span>
                                    <span class="grade8 grade green">8</span>
                                    <span class="grade9 grade green">9</span>
                                    <span class="grade10 grade green">10</span>
                                    <span class="grade11 grade green">11</span>
                                    <span class="grade12 grade green">12</span>
                                </div>
                            </div>
                            <div class="grade-info-wrapper">
                                <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle green"></span></div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle yellow"></span></div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle red"></span></div>
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
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-two">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper">
                                <span class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one">&nbsp;</div>
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
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-four">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper">
                                    <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero">&nbsp;</div>
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

                    <div class="search-result row">
                        <div class="result-image screenshots-popover col col-3 offset-1">
                            <div><a href="REPLACE" class="popover-link" data-popover-placement="bottom">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" /></a></div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray">
                                        <span class="count"><span class="curr">1</span> of 3</span>
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
                            <div class="result-title">Autism Play</div>
                            <div class="result-description">quia harum dolore aut ut in sequi ea non distinctio</div>
                            <div class="result-keywords">
                                <ul>
                                    <li><a href="REPLACE">Reading</a></li>
                                    <li><a href="REPLACE">Math</a></li>
                                    <li><a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating">
                                <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">ipsa repellendus deserunt rerum laudantium accusantium quo nihil enim vel</div>
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
                                        <div class="quality-scale-wrapper">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- .result-ratings -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-10">
                            <div class="rating-label">Grade</div>
                            <div class="grade-scale-wrapper">
                                <div class="grade-scale">
                                    <div class="selection grade8">8</div>
                                    <span class="grade1 grade red">1</span>
                                    <span class="grade2 grade red">2</span>
                                    <span class="grade3 grade red">3</span>
                                    <span class="grade4 grade red">4</span>
                                    <span class="grade5 grade red">5</span>
                                    <span class="grade6 grade yellow">6</span>
                                    <span class="grade7 grade yellow">7</span>
                                    <span class="grade8 grade green">8</span>
                                    <span class="grade9 grade green">9</span>
                                    <span class="grade10 grade green">10</span>
                                    <span class="grade11 grade green">11</span>
                                    <span class="grade12 grade green">12</span>
                                </div>
                            </div>
                            <div class="grade-info-wrapper">
                                <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle green"></span></div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle yellow"></span></div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle red"></span></div>
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
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-two">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper">
                                <span class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one">&nbsp;</div>
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
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-four">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper">
                                    <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero">&nbsp;</div>
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

                    <div class="search-result row">
                        <div class="result-image screenshots-popover col col-3 offset-1">
                            <div><a href="REPLACE" class="popover-link" data-popover-placement="bottom">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" /></a></div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title">Autism Play</div>
                                    <div class="change-slide-buttons arrows-gray">
                                        <span class="count"><span class="curr">1</span> of 3</span>
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
                            <div class="result-title">Autism Play</div>
                            <div class="result-description">similique totam ut neque labore quia aut odio accusantium omnis</div>
                            <div class="result-keywords">
                                <ul>
                                    <li><a href="REPLACE">Reading</a></li>
                                    <li><a href="REPLACE">Math</a></li>
                                    <li><a href="REPLACE">Writing</a></li>
                                </ul>
                            </div>
                            <div class="see-rating">
                                <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom">See Rating</a></div>
                                <!-- BEGIN PARTIAL: popover-see-rating -->
                                <div class="search-result row popover-container">
                                    <div class="result-image">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        <div class="result-type">(App, 2013)</div>
                                    </div>
                                    <div class="result-details">
                                        <div class="result-title">1in5 Stories</div>
                                        <div class="result-description">magni et totam molestias reiciendis qui et earum quisquam veniam</div>
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
                                        <div class="quality-scale-wrapper">
                                            <div class="quality-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>

                                        <div class="rating-label">Learning</div>
                                        <div class="learning-scale-wrapper">
                                            <div class="learning-scale">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider purple-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- .result-ratings -->
                                </div>
                                <!-- .search-result -->
                                <!-- END PARTIAL: popover-see-rating -->
                            </div>
                        </div>

                        <div class="result-ratings show-popover col col-10">
                            <div class="rating-label">Grade</div>
                            <div class="grade-scale-wrapper">
                                <div class="grade-scale">
                                    <div class="selection grade8">8</div>
                                    <span class="grade1 grade red">1</span>
                                    <span class="grade2 grade red">2</span>
                                    <span class="grade3 grade red">3</span>
                                    <span class="grade4 grade red">4</span>
                                    <span class="grade5 grade red">5</span>
                                    <span class="grade6 grade yellow">6</span>
                                    <span class="grade7 grade yellow">7</span>
                                    <span class="grade8 grade green">8</span>
                                    <span class="grade9 grade green">9</span>
                                    <span class="grade10 grade green">10</span>
                                    <span class="grade11 grade green">11</span>
                                    <span class="grade12 grade green">12</span>
                                </div>
                            </div>
                            <div class="grade-info-wrapper">
                                <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></div>
                                <!-- BEGIN PARTIAL: popover-grade-info -->
                                <div class="grade-tooltip popover-container">
                                    <div class="tooltip-title">About our rating system</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle green"></span></div>
                                            <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle yellow"></span></div>
                                            <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon"><span class="circle red"></span></div>
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
                                <div class="quality-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider blue-two">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                            </div>
                            <div class="quality-info-wrapper">
                                <span class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></span>
                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                <div class="quality-tooltip popover-container">
                                    <div class="tooltip-title">Quality Rating</div>
                                    <div class="ratings-wrapper">
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-five">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">The best!</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-four">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Really Good</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-three">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Just Fine</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-two">&nbsp;</div>
                                                <!-- END PARTIAL: results-slider -->
                                            </div>
                                            <div class="rating-info">Disappointing</div>
                                        </div>
                                        <div class="rating">
                                            <div class="rating-icon">
                                                <!-- BEGIN PARTIAL: results-slider -->
                                                <div class="results-slider blue-one">&nbsp;</div>
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
                                <div class="learning-scale">
                                    <!-- BEGIN PARTIAL: results-slider -->
                                    <div class="results-slider purple-four">&nbsp;</div>
                                    <!-- END PARTIAL: results-slider -->
                                </div>
                                <div class="learning-info-wrapper">
                                    <div class="popover-trigger-container"><a href="REPLACE" class="popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></div>
                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                    <div class="learning-tooltip popover-container">
                                        <div class="tooltip-title">Learning Rating</div>
                                        <div class="ratings-wrapper">
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-five">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-four">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-three">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-two">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-one">&nbsp;</div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                                            </div>
                                            <div class="rating">
                                                <div class="rating-icon">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider zero">&nbsp;</div>
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
                    <a class="results-more-link" href="REPLACE"><span>More Results</span><i class="icon-results-more"></i></a>
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
            <li><a href="REPLACE">10 Questions to ask about behavior issues</a></li>
            <li><a href="REPLACE">10 Questions to ask about behavior issues</a></li>
            <li><a href="REPLACE">10 Questions to ask about behavior issues</a></li>
            <li><a href="REPLACE">10 Questions to ask about behavior issues</a></li>
        </ul>
    </div>
    <!-- .tool-related-articles -->
    <!-- END PARTIAL: assistive-tool-related-articles -->
    <!-- This is where behavior-tool-related-articles will move to in mobile view-->
</div>
