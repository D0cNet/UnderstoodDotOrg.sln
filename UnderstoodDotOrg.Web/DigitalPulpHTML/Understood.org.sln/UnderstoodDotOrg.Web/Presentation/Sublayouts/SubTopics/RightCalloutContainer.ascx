<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RightCalloutContainer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics.RightCalloutContainer" %>
<!-- .col col-15 -->
<div class="col col-7 sidebar">

    <!-- BEGIN PARTIAL: featured-event -->
    <div class="featured-event">
        <h4>Experts Live!</h4>
        <h3><a href="REPLACE">Time-Blindness and ADHD: Strategies for Becoming More Aware of Time</a></h3>
        <p>
            <strong>August 31, 2013</strong><br>
            7:00pm EST<br>
            Geraldine Markel, Ph.D.
        </p>
    </div>
    <!-- .featured-event -->
    <!-- END PARTIAL: featured-event -->

    <div class="mini-tools-sidebar">

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
                    <input class="submit-button" type="submit" value="Submit">
                </div>

            </div>
            <!-- .form -->

            <footer class="powered-by">
                <h5>powered by</h5>
                <div class="logo">
                    <img class="logo-img" alt="Common Sense" src="Presentation/includes/img/logo.partner.commonsense.png" />
                </div>
            </footer>

        </section>
        <!-- .module -->
        <!-- END PARTIAL: tool-technology -->

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
                    <input class="submit-button" type="submit" value="Submit">
                </div>

            </div>
            <!-- .form -->

        </section>
        <!-- .module -->
        <!-- END PARTIAL: tool-experts -->

    </div>
    <!-- .mini-tools-sidebar -->

</div>
<!-- .col -->
