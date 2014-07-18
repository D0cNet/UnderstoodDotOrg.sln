<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogsAuthorPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsAuthorPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>  
      <div id="community-page" class="community-my-blogs community-blogs-main community-blog-post-list community-blog-posts-author-specific">
    <!-- BEGIN PARTIAL: community/main_header -->
      <%--  <sc:Placeholder ID="Placeholder1" Key="BlogHeader" runat="server" />--%>
    <!-- END PARTIAL: community/main_header -->
                   
        <!-- BEGIN PARTIAL: community/breadcrumb_menu -->
          <div class="row">
                           <!--breadcrumb menu-->
                        <a href="REPLACE" ID="hrefBackLink" runat="server" class="back-to-previous">
                          <i class="icon-arrow-left-blue"></i><asp:Literal ID="litBackLink" runat="server"></asp:Literal>
                        </a>
                        <!-- END PARTIAL: community/breadcrumb_menu -->
          </div>
        <div class="container">
       
            <!-- BEGIN PARTIAL: community/blog_feature_post -->
            <sc:Placeholder ID="BlogFeaturePost" Key="Feature-Post" runat="server" />
    <!-- END PARTIAL: community/blog_feature_post -->
            <div class="row">
              <div class=" col col-24 blog-featured-author clearfix skiplink-feature">
                <div class="rs_read_this">
                  <div class="blog-author-image-card">
                      <sc:Image runat="server" field="avatar" />
                  </div>
                    <div class="blog-author-details">
                      <h2><sc:FieldRenderer id="BlogBody" runat="server" fieldname="Name" /></h2>
                      <p class="blog-about-author"><sc:FieldRenderer id="FieldRenderer2" runat="server" fieldname="Biography" /></p>
                    </div>
                </div>
              </div>
            </div>
            <div class="col-23 blog-post-list-wrapper blog-author-posts clearfix skiplink-content" aria-role="main" aria-role="main">
                <h2 class="rs_read_this"><sc:Text Field="Recent Posts Text" runat="server" /></h2>
               
                  <!-- BEGIN PARTIAL: community/blog_post -->
                <asp:Repeater ID="rptrBlogPosts" runat="server">
                    <HeaderTemplate> <div class="col blog-post-list"></HeaderTemplate>
                    <ItemTemplate>
                         <div class="blog-post rs_read_this">
                            <div class="blog-card-image blog-card-total-comments">
                              <a> <sc:Image id="BlogImg" runat="server"  Field="Blog Image"  ></sc:Image>   <%--<img alt="230x129 Placeholder" src="http://placehold.it/230x129" />--%></a>
      
                            </div>
                            <div class="blog-card-info group">
                              <h3 class="blog-card-title"><a id="hrefBlogLink" runat="server" href="REPLACE"><asp:Literal ID="litBlogPostName" runat="server"></asp:Literal></a></h3>

      

                              <p class="blog-card-post-excerpt"><asp:Literal ID="litBlogExcerpt" runat="server"></asp:Literal></p>
                            <span class="children-key">
                              <ul>
                                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
                              </ul>
                            </span>
                            </div>
    
                            <div class="blog-post-timestamp">
                              <p class="blog-posted"><sc:Text Field="Posted Text" runat="server" /></p>
                              <p class="blog-timestamp-posted"><asp:Literal ID="litBlogPostTime" runat="server"></asp:Literal></p>
                              <p class="blog-time-units"><asp:Literal ID="litBlogAge" runat="server"></asp:Literal></p>
                            </div>
    
                        </div>

                    </ItemTemplate>
                    <FooterTemplate></div></FooterTemplate>
                </asp:Repeater>
               
    <!-- END PARTIAL: community/blog_post -->
                  <!-- BEGIN PARTIAL: community/blog_post -->
   <%-- <div class="blog-post">
        <div class="blog-card-image blog-card-total-comments">
          <a><img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>
      
        </div>
        <div class="blog-card-info group">
          <h3 class="blog-card-title"><a href="REPLACE">Voluptate Voluptas Qui Fugit</a></h3>

      

          <p class="blog-card-post-excerpt">Architecto Qui Et Voluptatum A Dignissimos Qui Et Numquam. Cumque Illo Possimus Est Maxime Soluta Aut Officiis Consequatur Amet</p>
        <span class="children-key">
          <ul>
            <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li>
          </ul>
        </span>
        </div>
    
        <div class="blog-post-timestamp">
          <p class="blog-posted">Posted</p>
          <p class="blog-timestamp-posted">1</p>
          <p class="blog-time-units">day ago</p>
        </div>
    
    </div>
    <!-- END PARTIAL: community/blog_post -->
                  <!-- BEGIN PARTIAL: community/blog_post -->
    <div class="blog-post">
        <div class="blog-card-image blog-card-total-comments">
          <a><img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>
      
        </div>
        <div class="blog-card-info group">
          <h3 class="blog-card-title"><a href="REPLACE">Perferendis Vero Quidem Perferendis</a></h3>

      

          <p class="blog-card-post-excerpt">Error Earum Asperiores Consequatur Dolores Consequatur Est. Est Illum Voluptatem Inventore Blanditiis Voluptatum Deleniti Aperiam Provident Impedit Quia</p>
        <span class="children-key">
          <ul>
            <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
          </ul>
        </span>
        </div>
    
        <div class="blog-post-timestamp">
          <p class="blog-posted">Posted</p>
          <p class="blog-timestamp-posted">1</p>
          <p class="blog-time-units">day ago</p>
        </div>
    
    </div>--%>
    <!-- END PARTIAL: community/blog_post -->
                
            </div>
        </div>

      <!-- Show More -->
      <!-- BEGIN PARTIAL: community/show_more -->
    <!--Show More-->
    <div class="container show-more rs_skip">
      <div class="row">
        <div class="col col-24">
          <asp:LinkButton id="showmore" runat="server"  data-path="blog/recent-posts" data-container="blog-post-list" data-item="blog-list" data-count="2"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></asp:LinkButton>
        </div>
      </div>
    </div><!-- .show-more -->
    <!-- END PARTIAL: community/show_more -->
      <!-- .show-more -->

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

      <div class="community-bloggers-more">
        <div class="row">
          <div class="col col-24 container">
            <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.MoreBloggersLabel %></h3>
            <div class="carousel-arrow-wrapper">
              <!-- BEGIN PARTIAL: community/carousel_arrows -->
    <div class="arrows more-bloggers-next-prev-menu arrows-gray">
    
        <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
        <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
    </div><!-- end .arrows -->
    <!-- END PARTIAL: community/carousel_arrows -->
            </div>
            <div class="row bloggers-more">
              <!-- BEGIN PARTIAL: community/blogger_card -->
    <div class="col blogger-card">
        <div class="blogger-card-info group">
            <div class="blogger-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                </a>
            </div><!-- end .blogger-card-image -->
            <h4 class="blogger-card-name"><a href="REPLACE">inn Robertson</a></h4><!-- end .member-card-name -->
        </div><!-- end .blogger-card-info -->
    </div><!-- end .blogger-card -->
    <!-- END PARTIAL: community/blogger_card -->
              <!-- BEGIN PARTIAL: community/blogger_card -->
    <div class="col blogger-card">
        <div class="blogger-card-info group">
            <div class="blogger-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                </a>
            </div><!-- end .blogger-card-image -->
            <h4 class="blogger-card-name"><a href="REPLACE">Dominick Dunn</a></h4><!-- end .member-card-name -->
        </div><!-- end .blogger-card-info -->
    </div><!-- end .blogger-card -->
    <!-- END PARTIAL: community/blogger_card -->
              <!-- BEGIN PARTIAL: community/blogger_card -->
    <div class="col blogger-card">
        <div class="blogger-card-info group">
            <div class="blogger-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                </a>
            </div><!-- end .blogger-card-image -->
            <h4 class="blogger-card-name"><a href="REPLACE">Noel Starr</a></h4><!-- end .member-card-name -->
        </div><!-- end .blogger-card-info -->
    </div><!-- end .blogger-card -->
    <!-- END PARTIAL: community/blogger_card -->
              <!-- BEGIN PARTIAL: community/blogger_card -->
    <div class="col blogger-card">
        <div class="blogger-card-info group">
            <div class="blogger-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                </a>
            </div><!-- end .blogger-card-image -->
            <h4 class="blogger-card-name"><a href="REPLACE">Kendrick Graves</a></h4><!-- end .member-card-name -->
        </div><!-- end .blogger-card-info -->
    </div><!-- end .blogger-card -->
    <!-- END PARTIAL: community/blogger_card -->
              <!-- BEGIN PARTIAL: community/blogger_card -->
    <div class="col blogger-card">
        <div class="blogger-card-info group">
            <div class="blogger-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                </a>
            </div><!-- end .blogger-card-image -->
            <h4 class="blogger-card-name"><a href="REPLACE">Mohammed Watts</a></h4><!-- end .member-card-name -->
        </div><!-- end .blogger-card-info -->
    </div><!-- end .blogger-card -->
    <!-- END PARTIAL: community/blogger_card -->
              <!-- BEGIN PARTIAL: community/blogger_card -->
    <div class="col blogger-card">
        <div class="blogger-card-info group">
            <div class="blogger-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                </a>
            </div><!-- end .blogger-card-image -->
            <h4 class="blogger-card-name"><a href="REPLACE">inley McAllister</a></h4><!-- end .member-card-name -->
        </div><!-- end .blogger-card-info -->
    </div><!-- end .blogger-card -->
    <!-- END PARTIAL: community/blogger_card -->
              <!-- BEGIN PARTIAL: community/blogger_card -->
    <div class="col blogger-card">
        <div class="blogger-card-info group">
            <div class="blogger-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                </a>
            </div><!-- end .blogger-card-image -->
            <h4 class="blogger-card-name"><a href="REPLACE">Andres Parrott</a></h4><!-- end .member-card-name -->
        </div><!-- end .blogger-card-info -->
    </div><!-- end .blogger-card -->
    <!-- END PARTIAL: community/blogger_card -->
              <!-- BEGIN PARTIAL: community/blogger_card -->
    <div class="col blogger-card">
        <div class="blogger-card-info group">
            <div class="blogger-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                </a>
            </div><!-- end .blogger-card-image -->
            <h4 class="blogger-card-name"><a href="REPLACE">Lynette Heath</a></h4><!-- end .member-card-name -->
        </div><!-- end .blogger-card-info -->
    </div><!-- end .blogger-card -->
    <!-- END PARTIAL: community/blogger_card -->
            </div><!-- end .member-cards -->
          </div><!-- end .col.col-24.container -->
        </div><!-- end .row -->
      </div><!-- end .community-members -->
    </div>