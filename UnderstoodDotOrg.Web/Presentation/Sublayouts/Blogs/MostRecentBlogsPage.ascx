<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MostRecentBlogsPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.MostRecentBlogsPage" %>
      <div id="community-page" class="community-my-blogs community-blog-post-list author-specific ">
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
          <span class="current-filter">Most recent</span>
          <span class="dropdown-title">Sort by</span>
      </a>
      <ul class="dropdown-menu" role="menu">
      
        <li role="presentation" class="filter selected" data-sort-by="date"><a role="menuitem" href="REPLACE">Most recent</a></li>
      
        <li role="presentation" class="filter " data-sort-by="read"><a role="menuitem" href="REPLACE">Most read</a></li>
      
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

        <div class="col-23 clearfix blog-post-list-wrapper">
          <div class="col blog-post-list skiplink-content" aria-role="main" aria-role="main">

            <div class="blog-post-list-inner">
             <!-- BEGIN PARTIAL: community/blog_post -->
<div class="blog-post">
    <div class="blog-card-image blog-card-total-comments">
      <a><img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>
      
      <p class="blog-card-comments"><b class="number-of-comments">19</b>Comments</p>
      
    </div>
    <div class="blog-card-info group">
      <h3 class="blog-card-title"><a href="REPLACE">Consequatur Rerum Omnis Dolor</a></h3>

      
      <div class="blog-card-post-info">
        <p class="blog-posted">Posted</p>
        <p class="blog-post-date">June 26, 2013</p>
        <p class="blog-by">by
          <a href="REPLACE">Gayle Shaffer</a>
        </p>
      </div>
      

      <p class="blog-card-post-excerpt">Voluptatibus Ut Sed Modi Quia Corporis Molestias Quidem. Quos Quisquam Error Itaque Nihil Et Distinctio Dicta Asperiores</p>
    <span class="children-key">
      <ul>
        <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
      </ul>
    </span>
    </div>
    
</div>
<!-- END PARTIAL: community/blog_post -->
             <!-- BEGIN PARTIAL: community/blog_post -->
<div class="blog-post">
    <div class="blog-card-image blog-card-total-comments">
      <a><img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>
      
      <p class="blog-card-comments"><b class="number-of-comments">19</b>Comments</p>
      
    </div>
    <div class="blog-card-info group">
      <h3 class="blog-card-title"><a href="REPLACE">Consectetur Pariatur Qui Quod</a></h3>

      
      <div class="blog-card-post-info">
        <p class="blog-posted">Posted</p>
        <p class="blog-post-date">June 26, 2013</p>
        <p class="blog-by">by
          <a href="REPLACE">Luis Goldstein</a>
        </p>
      </div>
      

      <p class="blog-card-post-excerpt">Eos Libero Porro Esse Quis. Praesentium Dolores Fugit Voluptas Distinctio Accusantium Error Ut Sunt Et Quia Impedit Ea</p>
    <span class="children-key">
      <ul>
        <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
      </ul>
    </span>
    </div>
    
</div>
<!-- END PARTIAL: community/blog_post -->
             <!-- BEGIN PARTIAL: community/blog_post -->
<div class="blog-post">
    <div class="blog-card-image blog-card-total-comments">
      <a><img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>
      
      <p class="blog-card-comments"><b class="number-of-comments">19</b>Comments</p>
      
    </div>
    <div class="blog-card-info group">
      <h3 class="blog-card-title"><a href="REPLACE">Culpa Earum Non Est</a></h3>

      
      <div class="blog-card-post-info">
        <p class="blog-posted">Posted</p>
        <p class="blog-post-date">June 26, 2013</p>
        <p class="blog-by">by
          <a href="REPLACE">Kyra Watkins</a>
        </p>
      </div>
      

      <p class="blog-card-post-excerpt">Adipisci Consequatur Quaerat Tempora. Natus Sequi Non Tempore Voluptatem Et Molestiae Nostrum Rerum Quae Et</p>
    <span class="children-key">
      <ul>
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
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
          <!-- .show-more -->

          </div>
          <!-- BEGIN PARTIAL: community/blog_sidebar -->
<div id="skipLinkSidebar"class="blog-post-list-sidebar skiplink-sidebar">
  <sc:Placeholder ID="Sidebar" Key="Blogs-Sidebar" runat="server" />
</div>

<!-- END PARTIAL: community/blog_sidebar -->
        </div>
    </div>

    <!-- BEGIN PARTIAL: children-key -->
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
      </div><!-- .children-key --> 
    </div><!-- .col --> 
  </div><!-- .row --> 
</div><!-- .child-content-indicator --> 
<!-- END PARTIAL: children-key -->
</div>