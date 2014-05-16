<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SectionTools.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Section.SectionTools" %>
<!-- BEGIN PARTIAL: tools -->
<!-- Tools -->

<div class="container mini-tools-wrap" style="background-image: url(/Presentation/includes/img/bg-subtopic-minitools.jpg)">

    <div class="row">

        <div class="col col-8">

            <!-- BEGIN PARTIAL: tool-technology -->
            <section class="mini-tool" id="mini-tool-apps">

                <header>
                    <h3>Apps &amp; Technology</h3>
                    <p>Find technology to help your child.</p>
                </header>

                <div class="form select-container">

                    <fieldset>

                        <label for="tool-tech-issue" class="visuallyhidden">Select behavior issue</label>
                        <select name="tool-tech-issue" id="tool-tech-issue" required aria-required="true">
                            <option value="">Select behavior issue</option>
                            <option>Attention & hyperactivity issues</option>
                            <option>Reading issues</option>
                            <option>Writing issues</option>
                            <option>Math issues</option>
                            <option>Trouble with motor skills</option>
                            <option>Trouble with spoken and written language</option>
                            <option>Trouble understanding visual information</option>
                        </select>

                        <label for="tool-tech-grade" class="visuallyhidden">Select grade</label>
                        <select name="tool-tech-grade" id="tool-tech-grade" required aria-required="true">
                            <option value="">Select grade</option>
                            <option>Grade 1</option>
                            <option>Grade 2</option>
                            <option>Grade 3</option>
                            <option>Grade 4</option>
                        </select>

                        <label for="tool-tech-alltech" class="visuallyhidden">All Technology</label>
                        <select name="tool-tech-alltech" id="tool-tech-alltech" required aria-required="true">
                            <option value="">All technology</option>
                            <option>Apps</option>
                            <option>Games</option>
                            <option>Websites</option>
                        </select>

                        <label for="tool-tech-platforms" class="visuallyhidden">All Platforms &amp; Devices</label>
                        <select name="tool-tech-platforms" id="tool-tech-platforms" required aria-required="true">
                            <option value="">All platforms &amp; devices</option>
                            <option>iPhone</option>
                            <option>iPod Touch</option>
                            <option>iPad</option>
                        </select>

                    </fieldset>

                    <div class="submit-button-wrap">
                        <input class="button" type="submit" value="Submit">
                    </div>

                </div>
                <!-- .form -->

                <footer class="powered-by">
                    <h5>powered by</h5>
                    <div class="logo">
                        <img class="logo-img" alt="Common Sense" src="/Presentation/includes/img/logo.partner.commonsense.png" />
                    </div>
                </footer>

            </section>
            <!-- .module -->
            <!-- END PARTIAL: tool-technology -->

        </div>
        <!-- .col -->

        <div class="col col-8">

            <!-- BEGIN PARTIAL: tool-experts -->
            <section class="mini-tool" id="mini-tool-experts">

                <header>
                    <h3>Advice from Behavior Experts</h3>
                    <p>Find practical strategies for handling common behavior challenges.</p>
                </header>

                <div class="form select-container">

                    <fieldset>

                        <label for="tool-advice-issue" class="visuallyhidden">Select behavior issue</label>
                        <select name="tool-advice-issue" id="tool-advice-issue" required aria-required="true">
                            <option value="">Select challenge</option>
                            <option>Attention & hyperactivity issues</option>
                            <option>Reading issues</option>
                            <option>Writing issues</option>
                            <option>Math issues</option>
                            <option>Trouble with motor skills</option>
                            <option>Trouble with spoken and written language</option>
                            <option>Trouble understanding visual information</option>
                        </select>

                        <label for="tool-advice-grade" class="visuallyhidden">Select grade</label>
                        <select name="tool-advice-grade" id="tool-advice-grade" required aria-required="true">
                            <option value="">Select grade</option>
                            <option>Grade 1</option>
                            <option>Grade 2</option>
                            <option>Grade 3</option>
                            <option>Grade 4</option>
                        </select>

                    </fieldset>

                    <div class="submit-button-wrap">
                        <input class="button" type="submit" value="Submit">
                    </div>

                </div>
                <!-- .form -->

            </section>
            <!-- .module -->
            <!-- END PARTIAL: tool-experts -->

        </div>
        <!-- .col -->

        <div class="col col-8">

            <!-- BEGIN PARTIAL: tool-school-ratings -->
            <section class="mini-tool" id="mini-tool-ratings">

                <header>
                    <h3>School Ratings</h3>
                    <p>Find a new school or rate your child's</p>
                </header>


                <div class="tabs">
                    <!-- NO WHITE SPACE BETWEEN As to PRESERVE LAYOUT -->
                    <a href="#by-location">By Location</a><a href="#by-name">By Name</a>
                </div>

                <ul class="tab-content-wrap">



                    <li class="tab-content" id="by-location">

                        <div class="form">

                            <fieldset>

                                <label for="tool-ratings-zip" class="visuallyhidden"></label>
                                <input type="text" name="tool-ratings-zip" id="tool-ratings-zip" placeholder="Enter zip code or city &amp; state">
                            </fieldset>

                            <div class="submit-button-wrap">
                                <input class="button" type="submit" value="Submit">
                            </div>

                        </div>
                        <!-- .form -->

                    </li>
                    <!-- .by-location -->


                    <li class="tab-content" id="by-name">

                        <div class="form select-container">

                            <fieldset>

                                <label for="tool-ratings-school" class="visuallyhidden"></label>
                                <input type="text" name="tool-ratings-school" id="tool-ratings-school" placeholder="Enter school name">

                                <label for="tool-ratings-state" class="visuallyhidden">Select a state</label>
                                <select name="tool-ratings-state" id="tool-ratings-state" required aria-required="true">
                                    <option value="">Select a state</option>
                                    <option>Alabama</option>
                                    <option>Arizona</option>
                                    <option>Arkansas</option>
                                </select>

                            </fieldset>

                            <div class="submit-button-wrap">
                                <input class="button" type="submit" value="Submit">
                            </div>

                        </div>
                        <!-- .form -->

                    </li>
                    <!-- .by-name -->


                </ul>
                <!-- .tab-content-wrap -->

                <footer class="powered-by">
                    <h5>powered by</h5>
                    <div class="logo">
                        <img class="logo-img" alt="Great Schools" src="/Presentation/includes/img/logo.partner.greatschools.png" />
                    </div>
                </footer>

            </section>
            <!-- .module -->
            <!-- END PARTIAL: tool-school-ratings -->

        </div>
        <!-- .col -->

    </div>
    <!-- .row -->

</div>
<!-- .container -->
<!-- END PARTIAL: tools -->
