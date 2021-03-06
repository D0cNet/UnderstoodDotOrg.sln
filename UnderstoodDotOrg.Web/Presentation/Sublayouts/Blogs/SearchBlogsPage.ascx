﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBlogsPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.SearchBlogsPage" %>
<div id="community-page" class="community-my-blogs community-blog-post-list community-blog-search">
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
      <label for="blog-group-search-text" class="visuallyhidden" aria-hidden="true"><%= UnderstoodDotOrg.Common.DictionaryConstants.SearchThisBlogLabel %></label>
      <input type="text" class="group-search" id="blog-group-search-text" name="group-search" placeholder="Search this blog"></input>
      <input class="group-search-button" type="submit" value="<%# UnderstoodDotOrg.Common.DictionaryConstants.GoButtonText %>"></input>
    </fieldset>
  </div>
  <div class="filters">
    <div class="dropdown">
      <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
          <span class="current-filter"><%= UnderstoodDotOrg.Common.DictionaryConstants.SortByLabel %></span>
          <span class="dropdown-title"><%= UnderstoodDotOrg.Common.DictionaryConstants.SortByLabel %></span>
      </a>
      <ul class="dropdown-menu" role="menu">
      
        <li role="presentation" class="filter " data-sort-by="date"><a role="menuitem" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.MostRecentLabel %></a></li>
      
        <li role="presentation" class="filter " data-sort-by="read"><a role="menuitem" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.MostReadLabel %></a></li>
      
        <li role="presentation" class="filter " data-sort-by="shared"><a role="menuitem" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.MostSharedLabel %></a></li>
      
        <li role="presentation" class="filter " data-sort-by="talkedabout"><a role="menuitem" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.MostTalkedLabel %></a></li>
      
      </ul>
    </div>
  </div>
</div>

<!-- END PARTIAL: community/blog_filter -->
        </div>

      </div>
    </div>
    <div class="col-23 clearfix blog-post-list-wrapper blogs-search">
      <span class="results-for">78 Results for <h3>"Advocate"</h3></span>
      <div class="col blog-post-list skiplink-content" aria-role="main">

        <div class="blog-post-list-inner">
          <!-- BEGIN PARTIAL: community/blog_post -->
<div class="blog-post">
    <div class="blog-card-image blog-card-total-comments">
      <a><img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>
      
      <p class="blog-card-comments"><b class="number-of-comments">19</b>Comments</p>
      
    </div>
    <div class="blog-card-info group">
      <h3 class="blog-card-title"><a href="REPLACE">Impedit Nemo Nesciunt Dolorem</a></h3>

      
      <div class="blog-card-post-info">
        <p class="blog-posted">Posted</p>
        <p class="blog-post-date">June 26, 2013</p>
        <p class="blog-by">by
          <a href="REPLACE">Brendon Barton</a>
        </p>
      </div>
      

      <p class="blog-card-post-excerpt">Aperiam Autem Explicabo Voluptatum Et Temporibus Illum Distinctio. Iste Debitis Quis Vero Iste Odit Rerum</p>
    <span class="children-key">
      <ul>
        <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
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
      <h3 class="blog-card-title"><a href="REPLACE">Dolor Quia Et Dolorum</a></h3>

      
      <div class="blog-card-post-info">
        <p class="blog-posted">Posted</p>
        <p class="blog-post-date">June 26, 2013</p>
        <p class="blog-by">by
          <a href="REPLACE">Bianca Heath</a>
        </p>
      </div>
      

      <p class="blog-card-post-excerpt">Fuga Et Quos Quia Consequuntur Blanditiis Neque Quo. Sequi In Modi Aut Voluptatem Facere Neque Eveniet Sit Rerum Et Impedit Et Qui Enim</p>
    <span class="children-key">
      <ul>
        <li><i class='child-d' title='CHILD NAME HERE'></i></li>
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
      <h3 class="blog-card-title"><a href="REPLACE">Velit Eum Impedit Quis</a></h3>

      
      <div class="blog-card-post-info">
        <p class="blog-posted">Posted</p>
        <p class="blog-post-date">June 26, 2013</p>
        <p class="blog-by">by
          <a href="REPLACE">Judith Snyder</a>
        </p>
      </div>
      

      <p class="blog-card-post-excerpt">Placeat Aut Voluptate Id Dicta Fuga Qui. Est Et Deserunt Vitae Et Voluptatem Quo Commodi Laudantium Porro Voluptatibus Enim Iusto Quae Consequatur</p>
    <span class="children-key">
      <ul>
        <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
      </ul>
    </span>
    </div>
    
</div>
<!-- END PARTIAL: community/blog_post -->
        </div>

        <!-- Show More -->
        <!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more rs_skip">
  <div class="row">
    <div class="col col-24">
      <a class="show-more-link " href="#" data-path="blog/posts" data-container="blog-post-list-inner" data-item="blog-list" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
        <!-- .show-more -->

      </div>
      <!-- BEGIN PARTIAL: community/blog_sidebar_recent -->
<!--first class is added to the first h4 in each section-->
<div class="blog-post-list-sidebar skiplink-sidebar">
<div class="blog-most-recent">
  <h3>Most Recent</h3>
  <h4 class="first"><a href="REPLACE">Tempore Odit Cumque Deserunt Aspernatur Ducimus</a></h4>
  <h4><a href="REPLACE">Inventore Ut Ut Aut</a></h4>
  <h4><a href="REPLACE">Iste Qui Nesciunt Et</a></h4>
</div>

<div class="blog-most-shared">
  <h3>Most Shared This Week</h3>
  <h4 class="first"><a href="REPLACE">Asperiores Eum Qui Eveniet Recusandae Enim</a></h4>
  <h4><a href="REPLACE">Distinctio Soluta Recusandae Molestiae</a></h4>
  <h4><a href="REPLACE">Sed Perspiciatis Rerum Ab</a></h4>
</div>
</div>

<!-- END PARTIAL: community/blog_sidebar_recent -->
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
      </div><!-- .children-key --> 
    </div><!-- .col --> 
  </div><!-- .row --> 
</div><!-- .child-content-indicator --> 
<!-- END PARTIAL: children-key -->--%>
    <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
</div>
