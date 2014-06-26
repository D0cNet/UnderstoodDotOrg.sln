<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsLandingPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsLandingPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- Hero Carousel Module -->
<div class="container hero-container flush at-hero-container-wrap">
    <!-- BEGIN PARTIAL: at-hero-image -->
    <section class="hero-image-container">
        <%= Model.Hero.Rendered %>
        <div class="text-container">
            <div class="row">
                <div class="col col-24">
                    <div class="hero-content rs_read_this">
                        <h1><%= Model.AssistiveToolsBasePage.ContentPage.PageTitle %></h1>
                        <%= Model.AssistiveToolsBasePage.ContentPage.BodyContent %>
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
        <div class="col col-20 centered at-search-tool-wrapper at-search-tool-wrapper-pull skiplink-content" aria-role="main">
            <sc:Placeholder ID="Placeholder2" Key="Assistive Tool Search" runat="server" />
        </div>
    </div>
</div>
<!-- end What Parents are Saying -->


<!-- What Parents are Saying -->
<!-- BEGIN PARTIAL: parents-are-saying -->
<div class="container parents-are-saying">
    <div class="row">
        <div class="col col-24 header-container rs_read_this parents-are-saying-heading-rs-wrapper">
            <h2>What parents are saying...</h2>
        </div>
    </div>
    <div class="row ie-padding">
        <div class="col slider-col col-18 offset-4">
            <div class="parents-are-saying-container">
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi Adipisc est un...<a href="REPLACE">read more</a></p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider zero" aria-label=" "></div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">13rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider blue-one" aria-label="Quality Rating: 1">Quality Rating: 1</div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">23rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider blue-two" aria-label="Quality Rating: 2">Quality Rating: 2</div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">33rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider blue-three" aria-label="Quality Rating: 3">Quality Rating: 3</div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">43rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider blue-four" aria-label="Quality Rating: 4">Quality Rating: 4</div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">53rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider blue-five" aria-label="Quality Rating: 5">Quality Rating: 5</div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider blue-five" aria-label="Quality Rating: 5">Quality Rating: 5</div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider blue-four" aria-label="Quality Rating: 4">Quality Rating: 4</div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider blue-three" aria-label="Quality Rating: 3">Quality Rating: 3</div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider blue-two" aria-label="Quality Rating: 2">Quality Rating: 2</div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider blue-one" aria-label="Quality Rating: 1">Quality Rating: 1</div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                    </div>
                </li>
                <li>
                    <div class="rs_read_this parents-are-saying-rs-wrapper">
                        <h3>Autism Play</h3>
                        <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
                        <!-- BEGIN PARTIAL: results-slider -->
                        <div class="results-slider zero" aria-label=" "></div>
                        <!-- END PARTIAL: results-slider -->
                        <h4>Parent</h4>
                        <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
                    </div>
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
            <div id="featured-slides-container" class="arrows-gray">
                <ul>
                    <li>
                        <div class="rs_read_this">
                            <a href="REPLACE">
                                <p>Understand Your Child's Problem: Start a Log</p>
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                            </a>
                        </div>
                    </li>
                    <li>
                        <div class="rs_read_this">
                            <a href="REPLACE">
                                <p>Does my Child Have Dyslexia? Take the Quiz</p>
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                            </a>
                        </div>
                    </li>
                    <li>
                        <div class="rs_read_this">
                            <a href="REPLACE">
                                <p>Get Better Recommendations: Create a Profile</p>
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                            </a>
                        </div>
                    </li>
                    <li>
                        <div class="rs_read_this">
                            <a href="REPLACE">
                                <p>Understand Your Child's Problem: Start a Log</p>
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                            </a>
                        </div>
                    </li>
                    <li>
                        <div class="rs_read_this">
                            <a href="REPLACE">
                                <p>Does my Child Have Dyslexia? Take the Quiz</p>
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                            </a>
                        </div>
                    </li>
                    <li>
                        <div class="rs_read_this">
                            <a href="REPLACE">
                                <p>Get Better Recommendations: Create a Profile</p>
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                            </a>
                        </div>
                    </li>
                </ul>
            </div>
            <!-- #more-carousel-slides-container-->

            <!-- END PARTIAL: more-carousel -->
        </div>
    </div>
</div>
<!-- end What Parents are Saying -->
