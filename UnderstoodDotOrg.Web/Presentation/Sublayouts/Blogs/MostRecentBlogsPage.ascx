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
                            <fieldset class="group-search-form mobile-group-search-form">
                                <label for="blog-group-search-text" class="visuallyhidden" aria-hidden="true">Search this blog</label>
                                <input type="text" class="group-search" id="blog-group-search-text" name="group-search" placeholder="Search this blog"></input>
                                <input class="group-search-button" type="submit" value="Go"></input>
                            </fieldset>
                        </div>
                        <div class="filters">
                            <div class="dropdown">
                                <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                                    <span class="current-filter">Most recent</span>
                                    <span class="dropdown-title">Sort by</span>
                                </a>
                                <ul class="dropdown-menu" role="menu">

                                    <li id="Recent" role="presentation" class="filter selected" data-sort-by="date"><a role="menuitem" onclick="showRecent();" runat="server">Most recent</a></li>

                                    <li id="Read" role="presentation" class="filter " data-sort-by="read"><a role="menuitem" onclick="" runat="server">Most read</a></li>

                                    <li id="Shared" role="presentation" class="filter " data-sort-by="shared"><a role="menuitem" onclick="" runat="server">Most shared</a></li>

                                    <li id="TalkedAbout" role="presentation" class="filter " data-sort-by="talkedabout"><a role="menuitem" onclick="showTalkedAbout();" runat="server">Most talked about</a></li>

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
                    <asp:Repeater ID="rptRecentBlogInfo" runat="server" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.BlogPost">
                        <ItemTemplate>
                            <!-- BEGIN PARTIAL: community/blog_post -->
                            <div class="blog-post">
                                <div class="blog-card-image blog-card-total-comments">
                                    <a>
                                        <img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>

                                    <p class="blog-card-comments"><b class="number-of-comments"><%# Item.CommentCount %></b>Comments</p>

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
                </div>
            </div>

            <%--<sc:Sublayout CssStyle="display: none" ID="sbMostRead" runat="server" Path="~/Presentation/SubLayouts/Blogs/SortBlogsRecent.ascx" />
            <sc:Sublayout CssStyle="display: none" ID="sbMostShared" runat="server" Path="~/Presentation/SubLayouts/Blogs/SortBlogsRecent.ascx" />--%>

            <div style="display: none" id="sbMostTalkedAbout" class="col blog-post-list skiplink-content" aria-role="main">
                <div class="blog-post-list-inner">
                    <asp:Repeater ID="rptMostTalkedBlogInfo" runat="server" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.BlogPost">
                        <ItemTemplate>
                            <!-- BEGIN PARTIAL: community/blog_post -->
                            <div class="blog-post">
                                <div class="blog-card-image blog-card-total-comments">
                                    <a>
                                        <img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>

                                    <p class="blog-card-comments"><b class="number-of-comments"><%# Item.CommentCount %></b>Comments</p>

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
                </div>

                <!-- Show More -->
                <!-- BEGIN PARTIAL: community/show_more -->
                <!--Show More-->
                <div class="container show-more">
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
            <!-- BEGIN PARTIAL: community/blog_sidebar -->
            <div id="skipLinkSidebar" class="blog-post-list-sidebar skiplink-sidebar">
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
<div style="display:none" id="hide"></div>
<%--<script type="text/javascript">
    var recent = document.getElementById("sbMostRecent");
    <%--var read = document.getElementById("<%=sbMostRead.ClientID%>");
    var shared = document.getElementById("<%=sbMostShared.ClientID%>");-->
    var talked = document.getElementById("sbMostTalkedAbout");
    var recentSelect = document.getElementById("Recent");
    var readSelect = document.getElementById("Read");
    var sharedSelect = document.getElementById("Shared");
    var talkedSelect = document.getElementById("TalkedAbout");
    function ShowMostRecent() {
        if (recent.style.display = "none") {
            recent.style.display = "block";
            //read.setAttribute("Visible", "false");
            //shared.setAttribute("Visible", "false");
            talked.style.display = "none";
            recentSelect.className = "filter selected";
            readSelect.className = "filter ";
            sharedSelect.className = "filter ";
            talkedSelect.className = "filter ";
        }
    }
    //function ShowMostRead() {
    //    if (read.getAttribute("Visible") == "false") {
    //        recent.setAttribute("Visible", "false");
    //        //read.setAttribute("Visible", "true");
    //        //shared.setAttribute("Visible", "false");
    //        talked.setAttribute("Visible", "false");
    //        recentSelect.className = "filter ";
    //        readSelect.className = "filter selected";
    //        sharedSelect.className = "filter ";
    //        talkedSelect.className = "filter ";
    //    }
    //}
    //function ShowMostShared() {
    //    if (shared.getAttribute("Visible") == "false") {
    //        recent.setAttribute("Visible", "false");
    //        //read.setAttribute("Visible", "false");
    //        //shared.setAttribute("Visible", "false");
    //        talked.setAttribute("Visible", "false");
    //        recentSelect.className = "filter ";
    //        readSelect.className = "filter ";
    //        sharedSelect.className = "filter selected";
    //        talkedSelect.className = "filter ";
    //    }
    //}
    function ShowMostTalkedAbout() {
        if (talked.style.display = "none") {
            recent.style.display = "none";
            //read.setAttribute("Visible", "false");
            //shared.setAttribute("Visible", "false");
            talked.style.display = "block";
            recentSelect.className = "filter ";
            readSelect.className = "filter ";
            sharedSelect.className = "filter ";
            talkedSelect.className = "filter selected";
        }
    }
</script>--%>

<script type="text/javascript">
    function showRecent() {
        $('#sbMostTalkedAbout').detach().appendTo('#hide');
        $('#sbMostRecent').detach().prependTo('#sort');
    }
    function showTalkedAbout() {
        $('#sbMostRecent').detach().appendTo('#hide');
        $('#sbMostTalkedAbout').detach().prependTo('#sort');
    }
</script>