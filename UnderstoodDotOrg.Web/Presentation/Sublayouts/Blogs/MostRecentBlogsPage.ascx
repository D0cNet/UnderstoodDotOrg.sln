<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MostRecentBlogsPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.MostRecentBlogsPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="community-page" class="community-my-blogs community-blog-post-list author-specific ">
    <!-- BEGIN PARTIAL: community/main_header -->
    <sc:placeholder id="Placeholder1" key="BlogHeader" runat="server" />
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

                                    <li id="Recent" role="presentation" class="filter selected" data-sort-by="date"><a role="menuitem" onserverclick="MostRecent_Click" runat="server">Most recent</a></li>

                                    <li id="Read" role="presentation" class="filter " data-sort-by="read"><a role="menuitem" onserverclick="MostRead_Click" runat="server">Most read</a></li>

                                    <li id="Shared" role="presentation" class="filter " data-sort-by="shared"><a role="menuitem" onserverclick="MostShared_Click" runat="server">Most shared</a></li>

                                    <li id="TalkedAbout" role="presentation" class="filter " data-sort-by="talkedabout"><a role="menuitem" onserverclick="MostTalkedAbout_Click" runat="server">Most talked about</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>

                    <!-- END PARTIAL: community/blog_filter -->
                </div>
            </div>
        </div>

        <div class="col-23 clearfix blog-post-list-wrapper">
            <sc:Sublayout Visible="true" ID="sbMostRecent" runat="server" Path="~/Presentation/SubLayouts/Blogs/SortBlogsRecent.ascx" />
            <sc:Sublayout Visible="false" ID="sbMostRead" runat="server" Path="~/Presentation/SubLayouts/Blogs/SortBlogsRecent.ascx" />
            <sc:Sublayout Visible="false" ID="sbMostShared" runat="server" Path="~/Presentation/SubLayouts/Blogs/SortBlogsRecent.ascx" />
            <sc:Sublayout Visible="false" ID="sbMostTalkedAbout" runat="server" Path="~/Presentation/SubLayouts/Blogs/SortBlogsTalkedAbout.ascx" />
            <!-- BEGIN PARTIAL: community/blog_sidebar -->
            <div id="skipLinkSidebar" class="blog-post-list-sidebar skiplink-sidebar">
                <sc:placeholder id="Sidebar" key="Blogs-Sidebar" runat="server" />
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
    <sc:sublayout runat="server" path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
</div>
<%--<script type="text/javascript">
    var recent = document.getElementById("<%=sbMostRecent.ClientID%>");
    var read = document.getElementById("<%=sbMostRead.ClientID%>");
    var shared = document.getElementById("<%=sbMostShared.ClientID%>");
    var talked = document.getElementById("<%=sbMostTalkedAbout.ClientID%>");
    var recentSelect = document.getElementById("Recent");
    var readSelect = document.getElementById("Read");
    var sharedSelect = document.getElementById("Shared");
    var talkedSelect = document.getElementById("TalkedAbout");
    function ShowMostRecent() {
        if (recent.getAttribute("Visible") == "false") {
            recent.setAttribute("Visible", "true");
            read.setAttribute("Visible", "false");
            shared.setAttribute("Visible", "false");
            talked.setAttribute("Visible", "false");
            recentSelect.className = "filter selected";
            readSelect.className = "filter ";
            sharedSelect.className = "filter ";
            talkedSelect.className = "filter ";
        }
    }
    function ShowMostRead() {
        if (read.getAttribute("Visible") == "false") {
            recent.setAttribute("Visible", "false");
            read.setAttribute("Visible", "true");
            shared.setAttribute("Visible", "false");
            talked.setAttribute("Visible", "false");
            recentSelect.className = "filter ";
            readSelect.className = "filter selected";
            sharedSelect.className = "filter ";
            talkedSelect.className = "filter ";
        }
    }
    function ShowMostShared() {
        if (shared.getAttribute("Visible") == "false") {
            recent.setAttribute("Visible", "false");
            read.setAttribute("Visible", "false");
            shared.setAttribute("Visible", "false");
            talked.setAttribute("Visible", "false");
            recentSelect.className = "filter ";
            readSelect.className = "filter ";
            sharedSelect.className = "filter selected";
            talkedSelect.className = "filter ";
        }
    }
    function ShowMostTalkedAbout() {
        if (talked.getAttribute("Visible") == "false") {
            recent.setAttribute("Visible", "false");
            read.setAttribute("Visible", "false");
            shared.setAttribute("Visible", "false");
            talked.setAttribute("Visible", "false");
            recentSelect.className = "filter ";
            readSelect.className = "filter ";
            sharedSelect.className = "filter ";
            talkedSelect.className = "filter selected";
        }
    }
</script>--%>