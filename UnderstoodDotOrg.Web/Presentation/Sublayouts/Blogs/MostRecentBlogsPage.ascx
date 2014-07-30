<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MostRecentBlogsPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.MostRecentBlogsPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="community-page" class="community-my-blogs community-blog-post-list author-specific ">
    <!-- BEGIN PARTIAL: community/main_header -->
    <sc:Placeholder ID="Placeholder1" Key="BlogHeader" runat="server" />
    <!-- END PARTIAL: community/main_header -->

    <div class="container">
        <sc:Placeholder Key="FeaturePost" runat="server" />
        <div class="container">
            <div class="row">
                <div class="col blog-filter-wrapper col-24">
                    <!-- BEGIN PARTIAL: community/blog_filter -->
                    <div class="blog-filter clearfix skiplink-toolbar">
                        <div class="mobile-search-box">
                            <asp:Panel runat="server" DefaultButton="btnSearch">
                                <fieldset class="group-search-form mobile-group-search-form">
                                    <label for="blog-group-search-text" class="visuallyhidden" aria-hidden="true">
                                        <sc:Text Field="Search This Blog Text" runat="server" />
                                    </label>
                                    <asp:TextBox CssClass="group-search" ID="txtSearch" placeholder="Search this blog" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnSearch" CssClass="group-search-button" OnClick="btnSearch_Click" runat="server"></asp:Button>
                                </fieldset>
                            </asp:Panel>
                        </div>
                        <div class="filters">
                            <div class="dropdown">
                                <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                                    <span class="current-filter"><%= UnderstoodDotOrg.Common.DictionaryConstants.MostRecentLabel %></span>
                                    <span class="dropdown-title"><%= UnderstoodDotOrg.Common.DictionaryConstants.SortByLabel %></span>
                                </a>
                                <ul class="dropdown-menu" role="menu">

                                    <li id="Recent" role="presentation" class="filter selected" data-sort-by="date">
                                        <asp:LinkButton role="menuitem" ID="btnMostRecent" OnClick="btnMostRecent_Click" Text="<%# UnderstoodDotOrg.Common.DictionaryConstants.MostRecentLabel %>" runat="server" /></li>

                                    <li id="Read" role="presentation" class="filter " data-sort-by="read">
                                        <asp:LinkButton role="menuitem" ID="btnMostRead" OnClick="btnMostRead_Click" runat="server" Text="<%# UnderstoodDotOrg.Common.DictionaryConstants.MostReadLabel %>" /></li>

                                    <li id="Shared" role="presentation" class="filter " data-sort-by="shared">
                                        <asp:LinkButton role="menuitem" ID="btnMostShared" OnClick="btnMostShared_Click" runat="server" Text="<%# UnderstoodDotOrg.Common.DictionaryConstants.MostSharedLabel %>" /></li>

                                    <li id="TalkedAbout" role="presentation" class="filter " data-sort-by="talkedabout">
                                        <asp:LinkButton role="menuitem" ID="btnMostTalked" OnClick="btnMostTalked_Click" runat="server" Text="<%# UnderstoodDotOrg.Common.DictionaryConstants.MostTalkedLabel %>" /></li>

                                </ul>
                            </div>
                        </div>
                    </div>

                    <!-- END PARTIAL: community/blog_filter -->
                </div>
            </div>
        </div>

        <div id="sort" class="col-23 clearfix blog-post-list-wrapper">
            <div id="sbMostRecent" class="col blog-post-list skiplink-content" aria-role="main">
                <div class="blog-post-list-inner">
                    <asp:UpdatePanel runat="server" ID="upBlogPosts">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnMostRecent" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnMostRead" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnMostShared" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnMostTalked" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Panel ID="panResultText" runat="server" Visible="false">
                                <span class="results-for">
                                    <asp:Literal ID="litResultCount" runat="server" />
                                    Results for
                                    <h3>"<asp:Literal ID="litSearchTerm" runat="server" />"</h3>
                                </span>
                            </asp:Panel>
                            <asp:Repeater ID="rptRecentBlogInfo" runat="server" ItemType="UnderstoodDotOrg.Services.Models.Telligent.BlogPost">
                                <ItemTemplate>
                                    <!-- BEGIN PARTIAL: community/blog_post -->
                                    <div class="blog-post rs_read_this">
                                        <div class="blog-card-image blog-card-total-comments">
                                            <a>
                                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>

                                            <p class="blog-card-comments"><b class="number-of-comments"><%# Item.CommentCount %></b><sc:Text Field="Comments Text" runat="server" />
                                            </p>

                                        </div>
                                        <div class="blog-card-info group">
                                            <h3 class="blog-card-title"><a href="<%# Item.Url %>"><%# Item.Title %></a></h3>


                                            <div class="blog-card-post-info">
                                                <p class="blog-posted">
                                                    <sc:Text Field="Posted Text" runat="server" />
                                                </p>
                                                <p class="blog-post-date"><%# Item.PublishedDate %></p>
                                                <p class="blog-by">
                                                    <sc:Text Field="By Text" runat="server" />
                                                    <a href="<%# Item.AuthorUrl %>" class="author"><%# Item.Author %></a>
                                                </p>
                                            </div>


                                            <p class="blog-card-post-excerpt"><%# Item.Body %></p>
                                            <span class="children-key">
                                                <ul>
                                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                                </ul>
                                            </span>
                                        </div>

                                    </div>
                                    <!-- END PARTIAL: community/blog_post -->
                                </ItemTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <asp:UpdateProgress ID="updateProgress" runat="server">
                <ProgressTemplate>
                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.8;">
                        <span style="border-width: 0px; position: fixed; padding: 50px; background-color: #FFFFFF; font-size: 36px; left: 40%; top: 40%;">Loading...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <%--<sc:Sublayout CssStyle="display: none" ID="sbMostRead" runat="server" Path="~/Presentation/SubLayouts/Blogs/SortBlogsRecent.ascx" />
            <sc:Sublayout CssStyle="display: none" ID="sbMostShared" runat="server" Path="~/Presentation/SubLayouts/Blogs/SortBlogsRecent.ascx" />--%>

            <!-- BEGIN PARTIAL: community/blog_sidebar -->
            <div id="skipLinkSidebar" class="blog-post-list-sidebar skiplink-sidebar rs_read_this">
                <sc:Placeholder ID="Sidebar" Key="Blogs-Sidebar" runat="server" />
            </div>

            <!-- END PARTIAL: community/blog_sidebar -->
        </div>
    </div>

    <%--<!-- BEGIN PARTIAL: children-key -->
    <div class="container child-content-indicator ">
        <!-- Key -->
        <div class="row">
            <div class="col col-23 offset-1">
                <div class="children-key" aria-hidden="true">
                    <ul>
                        <li><i class="child-a"></i>for Michael</li>
                        <li><i class="child-b"></i>for Elizabeth</li>
                        <li><i class="child-c"></i>for Ethan</li>
                        <li><i class="child-d"></i>for Jeremy</li>
                        <li><i class="child-e"></i>for Franklin</li>
                    </ul>
                </div>
                <!-- .children-key -->
            </div>
            <!-- .col -->
        </div>
        <!-- .row -->
    </div>
    <!-- .child-content-indicator -->
    <!-- END PARTIAL: children-key -->--%>
    <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
</div>
<%--<div style="display: none" id="hide">
    <div id="sbMostTalkedAbout" class="col blog-post-list skiplink-content" aria-role="main">
        <div class="blog-post-list-inner">
            <asp:Repeater ID="rptMostTalkedBlogInfo" runat="server" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.BlogPost">
                <ItemTemplate>
                    <!-- BEGIN PARTIAL: community/blog_post -->
                    <div class="blog-post rs_read_this">
                        <div class="blog-card-image blog-card-total-comments">
                            <a>
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>

                            <p class="blog-card-comments"><b class="number-of-comments"><%# Item.CommentCount %></b><sc:Text Field="CommentsText" runat="server" /></p>

                        </div>
                        <div class="blog-card-info group">
                            <h3 class="blog-card-title"><a href="<%# Item.Url %>"><%# Item.Title %></a></h3>


                            <div class="blog-card-post-info">
                                <p class="blog-posted">Posted</p>
                                <p class="blog-post-date"><%# Item.PublishedDate %></p>
                                <p class="blog-by">
                                    by
          <a href="<%# Item.AuthorUrl %>" class="author"><%# Item.Author %></a>
                                </p>
                            </div>


                            <p class="blog-card-post-excerpt"><%# Item.Body %></p>
                            <span class="children-key">
                                <ul>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>

                    </div>
                    <!-- END PARTIAL: community/blog_post -->
                </ItemTemplate>
            </asp:Repeater>
        </div>--%>

<!-- Show More -->
<!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more rs_skip">
    <div class="row">
        <div class="col col-24">
            <a class="show-more-link " href="#" data-path="blog/posts" data-container="blog-post-list-inner" data-item="blog-list" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
        </div>
    </div>
</div>
<!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
<!-- .show-more -->

</div>
</div>
