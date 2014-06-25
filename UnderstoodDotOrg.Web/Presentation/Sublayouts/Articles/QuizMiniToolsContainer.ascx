<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuizMiniToolsContainer.ascx.cs"
    Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.QuizMiniToolsContainer" %>
<!-- BEGIN PARTIAL: tools -->
<!-- Tools -->
<div class="container mini-tools-wrap" style="background-image: url(Presentation/includes/img/bg-subtopic-minitools.jpg)">
    <div class="row">
        <div class="col col-8 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: tool-technology -->
            <section class="mini-tool rs_read_this" id="mini-tool-apps">

                <header>
                    <h3>Apps &amp; Technology</h3>
                    <p>Find technology to help your child.</p>
                </header>

                <div class="form select-container">

                    <fieldset>

                        <label for="tool-tech-issue" class="visuallyhidden rs_skip">Select behavior issue</label>
                        <select name="tool-tech-issue" id="tool-tech-issue" aria-required="true">
                            <option value="">Select behavior issue</option>
                            <option>Attention & hyperactivity issues</option>
                            <option>Reading issues</option>
                            <option>Writing issues</option>
                            <option>Math issues</option>
                            <option>Trouble with motor skills</option>
                            <option>Trouble with spoken and written language</option>
                            <option>Trouble understanding visual information</option>
                        </select>

                        <label for="tool-tech-grade" class="visuallyhidden rs_skip">Select grade</label>
                        <select name="tool-tech-grade" id="tool-tech-grade" aria-required="true">
                            <option value="">Select grade</option>
                            <option>Grade 1</option>
                            <option>Grade 2</option>
                            <option>Grade 3</option>
                            <option>Grade 4</option>
                        </select>

                        <label for="tool-tech-alltech" class="visuallyhidden rs_skip">All Technology</label>
                        <select name="tool-tech-alltech" id="tool-tech-alltech" aria-required="true">
                            <option value="">All technology</option>
                            <option>Apps</option>
                            <option>Games</option>
                            <option>Websites</option>
                        </select>

                        <label for="tool-tech-platforms" class="visuallyhidden">All Platforms &amp; Devices</label>
                        <select name="tool-tech-platforms" id="tool-tech-platforms" aria-required="true">
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
                        <img class="logo-img" alt="Common Sense Media" src="Presentation/includes/img/logo.partner.commonsense.png" />
                    </div>
                </footer>

            </section>
            <!-- .module -->
            <!-- END PARTIAL: tool-technology -->
        </div>
        <!-- .col -->
        <div class="col col-8">
            <!-- BEGIN PARTIAL: tool-experts -->
            <section class="mini-tool rs_read_this" id="mini-tool-experts">

                <header>
                    <h3>Advice from Behavior Experts</h3>
                    <p>Find practical strategies for handling common behavior challenges.</p>
                </header>

                <div class="form select-container">

                    <fieldset>

                        <label for="tool-advice-issue" class="visuallyhidden rs_skip">Select behavior issue</label>
                        <select name="tool-advice-issue" id="tool-advice-issue" aria-required="true">
                            <option value="">Select challenge</option>
                            <option>Attention & hyperactivity issues</option>
                            <option>Reading issues</option>
                            <option>Writing issues</option>
                            <option>Math issues</option>
                            <option>Trouble with motor skills</option>
                            <option>Trouble with spoken and written language</option>
                            <option>Trouble understanding visual information</option>
                        </select>

                        <label for="tool-advice-grade" class="visuallyhidden rs_skip">Select grade</label>
                        <select name="tool-advice-grade" id="tool-advice-grade" aria-required="true">
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
            <!-- BEGIN PARTIAL: tool-decision-guide -->
            <section class="mini-tool rs_read_this" id="mini-tool-decision-guide">

                <header>
                    <h3>Decision Guide</h3>
                    <p>Key questions to help you weigh your options</p>
                </header>

                <ul class="decision-guide">
                    <li>Is he ready?</li>
                    <li>Which is best?</li>
                    <li>Should I...</li>
                </ul>

                <div class="submit-button-wrap">
                    <button class="button">Try It</button>
                </div>

            </section>
            <!-- .module -->
            <!-- END PARTIAL: tool-decision-guide -->
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>
<!-- .container -->
<!-- END PARTIAL: tools -->
