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
                        <asp:DropDownList ID="ddlIssues" runat="server" required aria-required="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlGrades" runat="server" required aria-required="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlTechTypes" runat="server" CssClass="tech parent small-width" required aria-required="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlPlatforms" runat="server" CssClass="tech child small-width" style="display: none;">
                        </asp:DropDownList>
                        <div class="submit-button-container">
                            <input type="button" id="btnBrowseFind" runat="server" onserverclick="btnFindSubmit_Click" class="button" value="Find">
                        </div>
                    </fieldset>
                </div>
            </div>
            <!-- /.browse-by -->
            <div id="search-by">
                <div class="form rs_read_this">
                    <span class="visuallyhidden">Browse By</span>
                    <fieldset>
                        <label for="at-search-by" class="visuallyhidden">Search by</label>
                        <input type="text" id="tbKeywordSearch" runat="server" name="at-search-by">
                        <div class="submit-button-container2 rs_skip">
                            <input type="button" id="btnSearchFind" runat="server" onserverclick="btnFindSubmit_Click" class="button" value="Find">
                        </div>
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
