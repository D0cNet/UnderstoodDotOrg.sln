<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Assisitive Tools Search.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.Assisitive_Tools_Search" %>

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
                    <input class="submit-button" type="submit" value="Find">
                </div>
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
                    <input class="submit-button" type="submit" value="Find">
                </div>
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