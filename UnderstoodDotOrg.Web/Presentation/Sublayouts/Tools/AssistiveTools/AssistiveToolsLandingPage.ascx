<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsLandingPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsLandingPage" %>

<!-- Hero Carousel Module -->
<div class="container hero-container flush at-hero-container-wrap">
    <!-- BEGIN PARTIAL: at-hero-image -->
    <section class="hero-image-container">
        <img alt="1200x542 Placeholder" src="http://placehold.it/1200x542" />
        <div class="text-container">
            <div class="row">
                <div class="col col-24">
                    <div class="hero-content">
                        <h1>Technology That Can Help</h1>
                        <h2>Find apps, games and websites to help your child</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- END PARTIAL: at-hero-image -->
</div>

<!-- Get Expert Advice -->
<div class="container flush assistive-tech">
    <div class="row">
        <div class="col col-20 centered at-search-tool-wrapper at-search-tool-wrapper-pull">
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
    </div>
</div>
<!-- end What Parents are Saying -->


<!-- What Parents are Saying -->
<!-- BEGIN PARTIAL: parents-are-saying -->
<div class="container parents-are-saying">
    <div class="row">
        <div class="col col-24 header-container">
            <h2>What parents are saying...</h2>
        </div>
    </div>
    <div class="row">
        <div class="col slider-col col-18 offset-4">
            <div class="parents-are-saying-container">
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi Adipisc est un...<a href="REPLACE">read more</a></p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider zero">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">13rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider blue-one">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">23rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider blue-two">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">33rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider blue-three">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">43rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider blue-four">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">53rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider blue-five">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider purple-five">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider purple-four">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider purple-three">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider purple-two">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider purple-one">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                </li>
                <li>
                    <h3>Autism Play</h3>
                    <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider zero">&nbsp;</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>Parent</h4>
                    <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                </li>
            </div>
        </div>
    </div>
</div>
<!-- END PARTIAL: parents-are-saying -->
<!-- end What Parents are Saying -->

<!-- What Parents are Saying -->
<div class="container more-carousel">
    <div class="row">
        <div class="col col-24">
            <h2>Related Articles</h2>
            <!-- BEGIN PARTIAL: more-carousel -->
            <div id="more-carousel-slides-container">
                <ul>
                    <li>
                        <a href="REPLACE">
                            <p>Understand Your Child's Problem: Start a Log</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                    <li>
                        <a href="REPLACE">
                            <p>Does my Child Have Dyslexia? Take the Quiz</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                    <li>
                        <a href="REPLACE">
                            <p>Get Better Recommendations: Create a Profile</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                    <li>
                        <a href="REPLACE">
                            <p>Understand Your Child's Problem: Start a Log</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                    <li>
                        <a href="REPLACE">
                            <p>Does my Child Have Dyslexia? Take the Quiz</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                    <li>
                        <a href="REPLACE">
                            <p>Get Better Recommendations: Create a Profile</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                </ul>
            </div>
            <!-- #more-carousel-slides-container-->

            <!-- END PARTIAL: more-carousel -->
        </div>
    </div>
</div>
<!-- end What Parents are Saying -->
