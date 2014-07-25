<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsReviewResults.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsReviewResults" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: pagetopic -->
<!-- FIXME: Documentation needed to explain share on/off functionality in page topic module -->

<!-- Determine variables present and change column width to fit the content available -->


<!-- Page Title -->
<div class="container page-topic assistive-tech-topic-wrapper no-bottom-margin">
    <div class="row">
        <div class="col col-14 offset-1">
            <div class="rs_read_this">
                <h1><%= Model.AssistiveToolsBasePage.ContentPage.PageTitle %></h1>
                <%= Model.AssistiveToolsBasePage.ContentPage.BodyContent %>
            </div>
        </div>
        <div class="col col-9">
            <!-- BEGIN PARTIAL: share-save -->
            <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />
            <!-- END PARTIAL: share-save -->
        </div>
    </div>
</div>
<!-- .container -->
<!-- END PARTIAL: pagetopic -->
<div class="container flush search-tool-layout-wrapper at2-wrapper">
    <div class="row">
        <!-- article -->
        <div class="col col-15 skiplink-toolbar">
            <sc:Placeholder ID="Placeholder2" Key="Assistive Tool Search" runat="server" />
        </div>
        <div class="col col-9 tool-related-articles-wrap assistive-tool-related-articles-large">
            <!-- This is where assistive-tool-related-articles will move to in desktop (650px+) view-->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
<asp:HiddenField ID="hfAssistiveTechResultsIssueId" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hfAssistiveTechResultsGradeId" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hfAssistiveTechResultsTechTypeId" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hfAssistiveTechResultsPlatformId" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hfAssistiveTechResultsKeyword" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hfAssistiveTechResultsSortOption" runat="server" ClientIDMode="Static" />
<asp:Repeater ID="rptrSearchResultsSections" runat="server">
    <ItemTemplate>
        <div class="container select-inverted-mobile<%# Container.ItemIndex % 2 == 0 ? string.Empty : " assistive-tech-results" %>">
            <div class="row">
                <!-- article -->
                <div class="col col-24 skiplink-content<%# Container.ItemIndex % 2 == 0 ? string.Empty : " instructional" %>" aria-role="main">
                    <!-- BEGIN PARTIAL: tech-search-results -->
                    <section class="tech-search-results multi">
                        <header class="row">
                            <div class="col col-10">
                                <h3 class="two-lines rs_read_this"><%# Eval("CategoryTitle") %></h3>
                                <div class="popover-trigger-container assistive-tooltip-trigger"<%# (bool)Eval("ShowHelpModal") ? string.Empty : " style=\"display:none;\"" %>>
                                    <a href="REPLACE" class="popover-link rs_preserve " data-popover-placement="bottom"><i class="icon-tooltip"><%= UnderstoodDotOrg.Common.DictionaryConstants.MoreInformationLabel %></i></a>
                                </div>
                                <div class="assistive-tooltip popover-container"<%# (bool)Eval("ShowHelpModal") ? string.Empty : " style=\"display:none;\"" %>>
                                    <%# Eval("HelpModalContent") %>
                                </div>
                                <!-- .assistive-tooltip -->
                            </div>
                            <div class="col col-6 push-8">
                                <fieldset>
                                    <span class="select-container sort">
                                        <label class="visuallyhidden">Sort by</label>
                                        <asp:DropDownList ID="ddlSortOptions" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSortOptions_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </span>
                                </fieldset>
                            </div>
                            <div class="col col-4 pull-6">
                                <span class="result-count">
                                    <span class="category-display-count" data-category-id="<%# Eval("CategoryId") %>"><%# Eval("CategoryResultDisplayCount") %></span> 
                                    of
                                    <%# Eval("CategoryResultTotalCount") %> results
                                </span>
                            </div>
                        </header>
                        <div class="tech-results-wrapper at-bottom container<%# Eval("CategoryId") %>">
                            <asp:Repeater ID="rptrResults" runat="server" 
                                ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.AssistiveToolsReviewPageItem">
                                <ItemTemplate>
                                    <sc:Sublayout runat="server" DataSource="<%# Item.ID.ToString() %>" Path="~/Presentation/Sublayouts/Tools/AssistiveTools/AssistiveToolsResultListing.ascx" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!-- .tech-results-wrapper -->

                        <footer>
                            <!-- Show More -->
                            <!-- BEGIN PARTIAL: community/show_more -->
                            <!--Show More-->
                            <div class="container show-more rs_skip">
                                <div class="row"<%# (bool)Eval("HasMoreResults") ? string.Empty : " style=\"display:none;\"" %>>
                                    <div class="col col-24">
                                        <a class="at-show-more-link " href="#" data-path="AssistiveTechResults" data-category-id="<%# Eval("CategoryId") %>" 
                                            data-item="search-results" data-page-id="<%= Model.ID.Guid.ToString() %>" data-count="1" 
                                            data-container="container<%# Eval("CategoryId") %>" data-max-results="<%# Eval("CategoryResultTotalCount") %>"
                                            data-results-per-click="<%= UnderstoodDotOrg.Common.Constants.ASSISTIVE_TECH_ENTRIES_PER_PAGE %>">
                                            <%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreLabel %>
                                            <i class="icon-arrow-down-blue"></i>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <!-- .show-more -->
                            <!-- END PARTIAL: community/show_more -->
                            <!-- .show-more -->
                        </footer>
                    </section>
                    <!-- END PARTIAL: tech-search-results -->
                </div>
            </div>
            <!-- .row -->
        </div>
        <!-- .container -->
    </ItemTemplate>
</asp:Repeater>
<asp:Panel ID="pnlNoResults" runat="server" CssClass="container partners-carousel" Visible="false">
    <div class="row">
        <h2><sc:FieldRenderer ID="frNoResultsLabel" runat="server" FieldName="No Results Label" /></h2>
    </div>
</asp:Panel>
<style>
    .tech-search-results .result-image img {
        width: 100%;
        height: auto;
    }
</style>
<div class="assistive-tool-related-articles-small">
    <!-- BEGIN PARTIAL: assistive-tool-related-articles -->
    <div class="assistive-tool-related-articles">
        <asp:Repeater ID="rptRelatedArticles" runat="server" OnItemDataBound="rptRelatedArticles_ItemDataBound">
            <HeaderTemplate>
                    <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="hypArticle" runat="server"></asp:HyperLink>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                    </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <!-- .tool-related-articles -->
    <!-- END PARTIAL: assistive-tool-related-articles -->
    <!-- This is where assistive-tool-related-articles will move to in mobile view-->
</div>

