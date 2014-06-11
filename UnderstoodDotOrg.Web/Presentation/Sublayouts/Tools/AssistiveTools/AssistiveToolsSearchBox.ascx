<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsSearchBox.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsSearchBox" %>
<!-- BEGIN PARTIAL: at-search-tool -->
<div class="">
    <div class="">

        <div id="search-by-tool-tabs">
            <ul>
                <li class="browse-by-tab">
                    <a href="#browse-by">
                        Browse By
                    </a>
                    <!-- Needs to be on one line to prevent whitespace -->
                </li>
                <li class="search-by-tab">
                    <a href="#search-by">
                        Search By
                    </a>
                </li>
            </ul>

            <div id="browse-by">
                <div class="form rs_read_this">
                    <span class="visuallyhidden">Browse By</span>
                    <span class="visuallyhidden">Search By</span>
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
                            <option value="at-browse-by-websites">Websites</option>
                            <option value="at-browse-by-technology">Assistive Technology</option>
                        </select>
                        <select name="at-browse-by-app" id="at-browse-by-app" class="tech child small-width" style="display: none;">
                            <option value>Select Platform</option>
                            <option value="1">all platforms</option>
                            <option value="2">iPhone</option>
                            <option value="3">iPod Touch</option>
                            <option value="4">iPad</option>
                            <option value="5">Android</option>
                            <option value="6">Kindle Fire</option>
                            <option value="7">Nook HD</option>
                        </select>
                        <select name="at-browse-by-games" id="at-browse-by-games" class="tech child small-width" style="display: none;">
                            <option value>Select Platform</option>
                            <option value="1">[List of Games]</option>
                            <option value="2">
                                <!-- retrive games from website -->
                            </option>
                        </select>
                        <div class="submit-button-container">
                            <input class="button" type="submit" value="Find"></div>
                    </fieldset>
                </div>
            </div>
            <!-- /.browse-by -->

            <div id="search-by">
                <div class="form rs_read_this">
                    <span class="visuallyhidden">Browse By</span>
                    <fieldset>
                        <label for="at-search-by" class="visuallyhidden">Search by</label>
                        <input type="text" name="at-search-by" id="at-search-by">
                        <div class="submit-button-container2 rs_skip">
                            <input id="btnFindSubmit" runat="server" onserverclick="" class="button" type="submit" value="Find"></div>
                    </fieldset>
                </div>
                <!-- .form -->
            </div>

            <div class="powered-by-logo-container">
                <div class="powered-by-logo">
                    <span>Powered by</span>
                    <span class="visuallyhidden">Common Sense Media</span>
                </div>
            </div>
        </div>

    </div>
</div>

<!-- END PARTIAL: at-search-tool -->
