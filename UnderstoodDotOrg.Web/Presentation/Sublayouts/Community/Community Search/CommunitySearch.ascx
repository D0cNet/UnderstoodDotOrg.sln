<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommunitySearch.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Community_Search.CommunitySearch" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div style="background-color:white" class="container l-search-box-container skiplink-toolbar">
    <div class="row">
        <div class="col col-22 offset-1">
            <!-- UN-154 - Search Box Module -->
            <!-- BEGIN PARTIAL: about/search-box-module -->
            <div class="search-box-module">
                <fieldset>
                    <legend>Search</legend>
                    <span class="field">
                        <asp:Panel runat="server" DefaultButton="btnSearch">
                            <label for="search-term" class="visuallyhidden">Search</label>
                            <asp:TextBox ID="txtSearch" CssClass="search-term" runat="server" placeholder="Search the Understood Community" />
                            <asp:Button type="submit" id="btnSearch" value="Go" OnClick="SearchButton_Click" runat="server" />
                        </asp:Panel>
                    </span>
                </fieldset>
            </div>
            <!-- END PARTIAL: about/search-box-module -->
        </div>
    </div>
</div>
<div class="container l-results-and-filter">
    <div class="row">
        <div class="col col-24 rs_read_this">
            <!-- UN-1741 - # of Results & Filter -->
            <!-- BEGIN PARTIAL: about/results-and-filter -->
            <div id="divResults" class="results" runat="server">
                <h1>
                    <asp:Literal ID="litResultCount" runat="server" />
                    Results for <span>&ldquo;<asp:Literal ID="litResultName" runat="server" />&rdquo;</span> in <span><asp:Literal ID="litFilter" runat="server" /></span></h1>
            </div>
            <label id="searchFilter" runat="server">
                <asp:DropDownList ID="ddlFilterSearch" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlFilterSearch_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="">Filter by</asp:ListItem>
                    <asp:ListItem Value="all">Show All</asp:ListItem>
                    <asp:ListItem Value="blog">Blogs</asp:ListItem>
                    <asp:ListItem Value="group">Groups</asp:ListItem>
                    <asp:ListItem Value="question">Q&A</asp:ListItem>
                    <asp:ListItem Value="expert">Experts</asp:ListItem>
                </asp:DropDownList>
            </label>
            <div class="clearfix"></div>
            <!-- END PARTIAL: about/results-and-filter -->
        </div>
    </div>
</div>
<div id="divResultsList" class="container about-search-results-container" runat="server">
    <div class="row">
        <div class="col col-24">
            <div class="about-search-results skiplink-content" aria-role="main">
                <asp:Repeater ID="rptResults" runat="server"
                    ItemType="UnderstoodDotOrg.Services.Models.Telligent.SearchResult">
                    <ItemTemplate>
                        <!-- BEGIN PARTIAL: about/about-search-results -->
                        <div class="row search-result-container rs_read_this repeater-item">
                            <%--<div class="col col-6 search-image">
                                <img class="foo" alt="FPO content image" src="http://placehold.it/230x129&amp;text=230x129" />
                            </div>--%>

                            <div class="col col-11 offset-1 search-content">
                                <h4><a href="<%# Item.Url %>"><%# Item.BestMatchTitle %></a></h4>
                                <p><%# Item.BestMatchBody %></p>
                            </div>
                            <div class="col search-content" style="display:inline-block; margin-left:35px; margin-top:35px">
                                <p><%# Item.Date %></p>
                            </div>

                            <div class="col col-5 search-category">
                                <span><%# Item.TypeTransformed %></span>
                            </div>
                            <!-- end .col.col-5 -->
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <!-- .about-search-results -->
            <div class="about-search-results-more">
                <!-- Show More -->
                <!-- BEGIN PARTIAL: community/show_more -->
                <!--Show More-->
                <div class="container show-more rs_skip">
                    <div class="row">
                        <div class="col col-24">
                            <a class="show-more-link " href="#" data-path="about/search-results" data-container="about-search-results" data-item="search-result-container" data-count="5">Show More<i class="icon-arrow-down-blue"></i></a>
                        </div>
                    </div>
                </div>
                <!-- .show-more -->
                <!-- END PARTIAL: community/show_more -->
                <!-- .show-more -->
            </div>
            <!-- .about-search-results-more -->

        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>
<!-- .container -->
