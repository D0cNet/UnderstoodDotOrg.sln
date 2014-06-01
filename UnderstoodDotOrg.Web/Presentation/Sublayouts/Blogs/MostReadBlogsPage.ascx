<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MostReadBlogsPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.MostReadBlogsPage" %>
<div id="community-page" class="community-my-blogs community-blog-post-list">
    <!-- BEGIN PARTIAL: community/main_header -->
    <sc:Placeholder ID="Placeholder1" Key="BlogHeader" runat="server" />
    <!-- END PARTIAL: community/main_header -->

    <div class="container">
        <!-- BEGIN PARTIAL: community/blog_feature_post -->
        <sc:Placeholder ID="Placeholder2" Key="Feature-Post" runat="server" />
        <!-- END PARTIAL: community/blog_feature_post -->
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
                                    <span class="current-filter">Most read</span>
                                    <span class="dropdown-title">Sort by</span>
                                </a>
                                <ul class="dropdown-menu" role="menu">

                                    <li role="presentation" class="filter " data-sort-by="date"><a role="menuitem" href="REPLACE">Most recent</a></li>

                                    <li role="presentation" class="filter selected" data-sort-by="read"><a role="menuitem" href="REPLACE">Most read</a></li>

                                    <li role="presentation" class="filter " data-sort-by="shared"><a role="menuitem" href="REPLACE">Most shared</a></li>

                                    <li role="presentation" class="filter " data-sort-by="talkedabout"><a role="menuitem" href="REPLACE">Most talked about</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>

                    <!-- END PARTIAL: community/blog_filter -->
                </div>
            </div>
        </div>
        <div class="col-23 blog-post-list-wrapper clearfix">
            <div class="col blog-post-list skiplink-content" aria-role="main" aria-role="main">

                <div class="blog-post-list-inner">
                    <!-- BEGIN PARTIAL: community/blog_post -->
                    <div class="blog-post">
                        <div class="blog-card-image blog-card-total-comments">
                            <a>
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>

                            <p class="blog-card-comments"><b class="number-of-comments">19</b>Comments</p>

                        </div>
                        <div class="blog-card-info group">
                            <h3 class="blog-card-title"><a href="REPLACE">Laborum Ut Magni Recusandae</a></h3>


                            <div class="blog-card-post-info">
                                <p class="blog-posted">Posted</p>
                                <p class="blog-post-date">June 26, 2013</p>
                                <p class="blog-by">
                                    by
          <a href="REPLACE">Brendan Weeks</a>
                                </p>
                            </div>


                            <p class="blog-card-post-excerpt">Repellat Ad Reiciendis Placeat Aut Deserunt Voluptatem Doloremque Qui Incidunt Similique Quia. Et Voluptas Tenetur Sequi Tempore Expedita Velit Consequuntur Quaerat Dolorem Et Earum</p>
                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>

                    </div>
                    <!-- END PARTIAL: community/blog_post -->
                    <!-- BEGIN PARTIAL: community/blog_post -->
                    <div class="blog-post">
                        <div class="blog-card-image blog-card-total-comments">
                            <a>
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>

                            <p class="blog-card-comments"><b class="number-of-comments">19</b>Comments</p>

                        </div>
                        <div class="blog-card-info group">
                            <h3 class="blog-card-title"><a href="REPLACE">Quo Voluptas Veniam Quia</a></h3>


                            <div class="blog-card-post-info">
                                <p class="blog-posted">Posted</p>
                                <p class="blog-post-date">June 26, 2013</p>
                                <p class="blog-by">
                                    by
          <a href="REPLACE">Vance Barton</a>
                                </p>
                            </div>


                            <p class="blog-card-post-excerpt">Qui Quam Aut Eos Fugit A Eos Aspernatur Cum Quia Atque Quo. Tenetur Architecto Nihil Assumenda Accusantium Earum Repellendus Perspiciatis Nemo Iure Doloremque Architecto Et Reprehenderit</p>
                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>

                    </div>
                    <!-- END PARTIAL: community/blog_post -->
                    <!-- BEGIN PARTIAL: community/blog_post -->
                    <div class="blog-post">
                        <div class="blog-card-image blog-card-total-comments">
                            <a>
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>

                            <p class="blog-card-comments"><b class="number-of-comments">19</b>Comments</p>

                        </div>
                        <div class="blog-card-info group">
                            <h3 class="blog-card-title"><a href="REPLACE">Natus Sunt Est Dicta</a></h3>


                            <div class="blog-card-post-info">
                                <p class="blog-posted">Posted</p>
                                <p class="blog-post-date">June 26, 2013</p>
                                <p class="blog-by">
                                    by
          <a href="REPLACE">Connor Baker</a>
                                </p>
                            </div>


                            <p class="blog-card-post-excerpt">Enim Dolores Molestiae Cumque Aut Culpa Et. Quaerat In Praesentium Quia Possimus Maxime Adipisci Et Voluptas Perspiciatis Quasi</p>
                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>

                    </div>
                    <!-- END PARTIAL: community/blog_post -->
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