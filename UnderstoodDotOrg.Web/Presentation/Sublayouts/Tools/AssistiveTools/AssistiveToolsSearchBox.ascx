<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsSearchBox.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsSearchBox" %>
<!-- BEGIN PARTIAL: at-search-tool -->
<div class="">
    <div class="">
        <div id="search-by-tool-tabs">
            <ul class="search-by-tool-tab-links">
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
            <div id="browse-by" >
                <asp:Panel runat="server" CssClass="form rs_read_this" DefaultButton="btnBrowseFind">
                    <span class="visuallyhidden">Browse By</span>
                    <span class="visuallyhidden">Search By</span>
                    <fieldset>
                        <asp:DropDownList ID="ddlIssues" runat="server" ValidationGroup="vgLearningToolBrowse" CssClass="issue-select">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlGrades" runat="server" ValidationGroup="vgLearningToolBrowse" CssClass="grade-select">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlTechTypes" runat="server" CssClass="tech parent small-width tech-type-select" 
                            ValidationGroup="vgLearningToolBrowse">
                        </asp:DropDownList>
                        <input type="hidden" id="hfSelectedPlatform" class="hfSelectedPlatform" runat="server" />
                        <asp:Repeater ID="rptrDynPlatformDropdowns" runat="server">
                            <ItemTemplate>
                                <select data-type-id="<%# Eval("TypeId") %>" class="tech child small-width platform-select" style="display:none;">
                                    <option value="">Select Platform</option>
                                    <asp:Repeater ID="rptrPlatformOptions" runat="server" 
                                        ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData.AssistiveToolsPlatformItem">
                                        <ItemTemplate>
                                            <option value="<%# Item.ID.ToString() %>" <%#: (Item.ID.ToString() == PlatformId) ? "selected=\"selected\"" : "" %>><%# Item.Metadata.ContentTitle %></option>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </select>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="submit-button-container">
                            <asp:Button ID="btnBrowseFind" runat="server" OnClick="btnFindSubmit_Click" CssClass="button" Text="Find"
                                ValidationGroup="vgLearningToolBrowse"></asp:Button>
                        </div>
                    </fieldset>
                </asp:Panel>
            </div>
            <!-- /.browse-by -->
            <div id="search-by">
                <asp:Panel runat="server" DefaultButton="btnSearchFind" CssClass="form rs_read_this">
                    <span class="visuallyhidden">Browse By</span>
                    <fieldset>
                        <label for="at-search-by" class="visuallyhidden">Search by</label>
                        <input type="text" id="tbKeywordSearch" runat="server" name="at-search-by" class="tbKeywordSearch" 
                            ValidationGroup="vgLearningToolSearch">
                        <div class="submit-button-container2 rs_skip">
                            <asp:Button ID="btnSearchFind" runat="server" OnClick="btnFindSubmit_Click" CssClass="button" Text="Find"
                                ValidationGroup="vgLearningToolSearch"></asp:Button>
                        </div>
                    </fieldset>
                </asp:Panel>
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
