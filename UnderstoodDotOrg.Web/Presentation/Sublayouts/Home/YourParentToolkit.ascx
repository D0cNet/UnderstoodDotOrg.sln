<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YourParentToolkit.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Home.YourParentToolkit" %>
<!-- BEGIN MODULE: Your Parent Toolkit -->
<div class="container parent-toolkit">
    <div class="row">
        <div class="col col-24">

            <header class="header-parent-toolkit">
                <h2>Your Parent Toolkit</h2>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. magna aliqua Lorem ipsum dolor sit amet, consectetur adipisicing elit. magna aliqua Lorem ipsum dolor sit amet, consectetur adipisicing elit. magna aliqua.</p>
            </header>
            <!-- .header-parent-toolkit -->

        </div>
        <!-- .col -->
    </div>
    <!-- .row -->

    <div class="row">
        <div class="col col-8 offset-3">

            <!-- BEGIN PARTIAL: behavior-tool -->
            <div class="behavior-tool">
                <div class="behavior-form select-container">

                    <h3>Advice from Behavior Experts</h3>
                    <p>Find practical strategies for handling common behavior challenges.</p>

                    <fieldset>
                        <label for="behaviortool-issue" class="visuallyhidden">Select behavior issue</label>
                        <select name="behaviortool-issue" id="behaviortool-issue" required="required" aria-required="true">
                            <option value="">Select challenge</option>
                            <option>Attention &amp; hyperactivity issues</option>
                            <option>Reading issues</option>
                            <option>Writing issues</option>
                            <option>Math issues</option>
                            <option>Trouble with motor skills</option>
                            <option>Trouble with spoken and written language</option>
                            <option>Trouble understanding visual information</option>
                        </select>

                        <label for="behaviortool-grade" class="visuallyhidden">Select grade</label>
                        <select name="behaviortool-grade" id="behaviortool-grade" required="required" aria-required="true">
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
            </div>

            <!-- END PARTIAL: behavior-tool -->

        </div>
        <!-- .col -->
        <div class="col col-13">

            <!-- BEGIN PARTIAL: toolkit -->
            <div class="tools-container">
                <div id="toolkit-slides-container">
                    <div class="slide">
                        <ul>
                            <li>
                                <div class="icon support-plan"><a href="REPLACE.html">Your Support Plan</a></div>
                            </li>
                            <li>
                                <div class="icon observation-logs"><a href="REPLACE.html">Observation Log</a></div>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <div class="icon childs-world"><a href="REPLACE.html">A Child's World</a></div>
                            </li>
                            <li>
                                <div class="icon rate-schools"><a href="REPLACE.html">Rate Schools</a></div>
                            </li>
                        </ul>
                    </div>
                    <!-- .slide -->
                    <div class="slide">
                        <ul>
                            <li>
                                <div class="icon support-plan"><a href="REPLACE.html">Your Support Plan</a></div>
                            </li>
                            <li>
                                <div class="icon observation-logs"><a href="REPLACE.html">Observation Log</a></div>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <div class="icon childs-world"><a href="REPLACE.html">A Child's World</a></div>
                            </li>
                            <li>
                                <div class="icon rate-schools"><a href="REPLACE.html">Rate Schools</a></div>
                            </li>
                        </ul>
                    </div>
                    <!-- .slide -->
                </div>
                <!-- #toolkit-slides-container -->
            </div>
            <!-- .tools-container -->
            <!-- END PARTIAL: toolkit -->

        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>
<!-- .container.parent-toolkit -->

<!-- END MODULE: Your Parent Toolkit -->
