<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogsPostPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsPostPage" %>
<div id="community-page" class="blog-post community-my-blogs community-blogs-main community-blog-post-list community-blog-posts-author-specific">
    <!-- BEGIN PARTIAL: community/main_header -->
    <sc:Placeholder ID="Placeholder1" Key="BlogHeader" runat="server" />
    <!-- END PARTIAL: community/main_header -->

    <!-- BEGIN PARTIAL: community/blog_feature_post -->
    <sc:Placeholder ID="BlogFeaturePost" Key="Feature-Post" runat="server" />
<!-- END PARTIAL: community/blog_feature_post -->

    <div class="container">
        <div class="row blog-container">
            <div class="col col-17 blog-post-content skiplink-content" aria-role="main">
                <header class="comments-headers">
                    <h2>Hic Fugit Eum Tenetur Ut</h2>
                    <p class="byline">Posted  Sep 14, 1995 by <a href="REPLACE">Collin O'Brien</a></p>
                </header>

                <article class="post">
                    <p>Quis repellendus eaque incidunt culpa. sed ipsam rem possimus accusantium consequatur nobis ipsa id. omnis aut ea ut</p>
                    <img alt="607x340 Placeholder" src="http://placehold.it/607x340" />
                    <p>Qui et saepe ea unde architecto suscipit autem doloribus sit accusantium tempora quia id. quis sed autem architecto est. sequi sint ut tempora non temporibus voluptatem eos molestiae enim incidunt. et porro qui adipisci sed illum ut exercitationem est voluptas saepe ipsa quod sit. optio magnam officia nihil cupiditate iste sequi facilis natus exercitationem et praesentium velit porro sint</p>
                </article>

                <div class="about-the-author">
                    <h4>About the Author</h4>

                    <a class="author-image" href="REPLACE">
                        <img alt="65x65 Placeholder" src="http://placehold.it/65x65" />
                    </a>

                    <div class="author-details">
                        <a class="author-name" href="REPLACE">Skyler Jones</a>
                        <a class="author-more-posts" href="REPLACE">More Posts by this Author</a>
                        <p class="author-description">Inventore eius dolor ut dolor ex nostrum sapiente et repellat quibusdam</p>
                    </div>
                </div>
            </div>

            <!-- BEGIN PARTIAL: community/blog-post-sidebar -->
            <div class="col col-6 blog-post-sidebar skiplink-sidebar">
                <div class="post-meta">
                    <!-- BEGIN PARTIAL: helpful-count -->

                    <div class="count-helpful">
                        <a href="#count-helpful-content"><span>34</span>Found this helpful</a>
                    </div>
                    <!-- END PARTIAL: helpful-count -->
                    <div class="replies">
                        <!-- BEGIN PARTIAL: comments-count -->
                        <div class="count-comments">
                            <a href="#count-comments"><span>19</span>Comments</a>
                        </div>
                        <!-- END PARTIAL: comments-count -->
                    </div>
                </div>

                <div class="was-this-helpful" id="count-helpful">
                    <h5>Did you find this helpful?</h5>
                    <a href="REPLACE" class="button yes">Yes</a>
                    <a href="REPLACE" class="button gray no">No</a>
                </div>

                <div class="keep-reading">
                    <h4>Keep Reading</h4>

                    <ul>
                        <li>
                            <a class="post-name" href="REPLACE">Et Ab Repudiandae Qui Omnis In Aut</a>
                            <p class="date-time">Posted Aug 5, 1995</p>
                        </li>

                        <li>
                            <a class="post-name" href="REPLACE">Sed Suscipit Beatae Numquam Consequatur Ut Eveniet</a>
                            <p class="date-time">Posted Jun 7, 2000</p>
                        </li>

                        <li>
                            <a class="post-name" href="REPLACE">Veritatis Ut Omnis Magni Libero Non Quis</a>
                            <p class="date-time">Posted Dec 1, 1992</p>
                        </li>
                    </ul>
                </div>
            </div>
            <!-- END PARTIAL: community/blog-post-sidebar -->
        </div>
    </div>

    <!-- BEGIN PARTIAL: community/blog_comments -->
<div class="container blog-comments" id="count-comments">
    <header class="row comments-header skiplink-comments">
        <h4>Comments (6)</h4>

        <select id="comments_sort_by" name="comments_sort_by">
            <option>Sort By</option>
            <option>Most Helpful</option>
            <option>Most Recent</option>
            <option>Oldest to Newest</option>
        </select>
    </header>

    <ul class="comments">
    
        
        <!-- BEGIN PARTIAL: community/blog_comment -->
<li class="row comment">
    <div class="comment-wrapper col-17">
        <img alt="65x65 Placeholder" class="comment-image" src="http://placehold.it/65x65" />

        <div class="comment-content">
            <header class="comment-header clearfix">
                <p class="comment-author">
                    Neil X
                    <span class="date-time">3 days ago</span>
                </p>

                <button class="comment-inappropriate">Report as inappropriate</button>
            </header>

            <p>Repudiandae aut aut non. voluptates qui odio eos est. officia voluptatibus consectetur aliquam vero occaecati omnis optio ut deleniti saepe officiis</p>

            <footer class="comment-footer">
                <h5>Show your support</h5>
                <ul class="comment-actions">
                    <li class="thanks">
                        <button>Thanks</button>
                    </li>

                    <li class="thinking-of-you">
                        <button>Thinking of You</button>
                    </li>

                    <li class="helpful-count">
                        <button>
                          28
                          <span class="visuallyhidden">likes</span>
                        </button>
                    </li>
                </ul>
            </footer>
        </div>
    </div>
</li>
<!-- END PARTIAL: community/blog_comment -->
        
    
    
        
        <!-- BEGIN PARTIAL: community/blog_comment -->
<li class="row comment">
    <div class="comment-wrapper col-17">
        <img alt="65x65 Placeholder" class="comment-image" src="http://placehold.it/65x65" />

        <div class="comment-content">
            <header class="comment-header clearfix">
                <p class="comment-author">
                    Johnny X
                    <span class="date-time">3 days ago</span>
                </p>

                <button class="comment-inappropriate">Report as inappropriate</button>
            </header>

            <p>Nemo voluptatem amet optio ad necessitatibus eos nulla fugit labore quae velit placeat enim. tenetur autem et dolor laboriosam ipsa neque illo eligendi dicta minus voluptates. possimus blanditiis est facilis iste tempore cumque ipsum ut nostrum nostrum iusto et sunt. incidunt ut harum enim quidem similique deserunt officiis amet eos vero et</p>

            <footer class="comment-footer">
                <h5>Show your support</h5>
                <ul class="comment-actions">
                    <li class="thanks">
                        <button>Thanks</button>
                    </li>

                    <li class="thinking-of-you">
                        <button>Thinking of You</button>
                    </li>

                    <li class="helpful-count">
                        <button>
                          23
                          <span class="visuallyhidden">likes</span>
                        </button>
                    </li>
                </ul>
            </footer>
        </div>
    </div>
</li>
<!-- END PARTIAL: community/blog_comment -->
        
    
    
        
        <!-- BEGIN PARTIAL: community/blog_comment -->
<li class="row comment">
    <div class="comment-wrapper col-17">
        <img alt="65x65 Placeholder" class="comment-image" src="http://placehold.it/65x65" />

        <div class="comment-content">
            <header class="comment-header clearfix">
                <p class="comment-author">
                    Carley X
                    <span class="date-time">3 days ago</span>
                </p>

                <button class="comment-inappropriate">Report as inappropriate</button>
            </header>

            <p>Et distinctio cumque veniam minus perferendis doloribus hic officia deleniti doloremque. non odit et quos vitae. velit excepturi quod enim non sed maiores</p>

            <footer class="comment-footer">
                <h5>Show your support</h5>
                <ul class="comment-actions">
                    <li class="thanks">
                        <button>Thanks</button>
                    </li>

                    <li class="thinking-of-you">
                        <button>Thinking of You</button>
                    </li>

                    <li class="helpful-count">
                        <button>
                          33
                          <span class="visuallyhidden">likes</span>
                        </button>
                    </li>
                </ul>
            </footer>
        </div>
    </div>
</li>
<!-- END PARTIAL: community/blog_comment -->
        
    
    
        
        <!-- BEGIN PARTIAL: community/blog_comment -->
<li class="row comment">
    <div class="comment-wrapper col-17">
        <img alt="65x65 Placeholder" class="comment-image" src="http://placehold.it/65x65" />

        <div class="comment-content">
            <header class="comment-header clearfix">
                <p class="comment-author">
                    Carly X
                    <span class="date-time">3 days ago</span>
                </p>

                <button class="comment-inappropriate">Report as inappropriate</button>
            </header>

            <p>Sunt sapiente architecto voluptas dignissimos hic eaque ut officia repellat consequatur nisi voluptatem nesciunt qui. voluptatibus a a praesentium nam dolor nulla sed non animi nam. velit suscipit sit ipsa soluta dolorum velit rem. aut magnam ratione quod reiciendis culpa odit in id rem tenetur cum facere non. sed magni voluptatem culpa. eos in quam natus libero temporibus laboriosam a ad. sint et non voluptatem</p>

            <footer class="comment-footer">
                <h5>Show your support</h5>
                <ul class="comment-actions">
                    <li class="thanks">
                        <button>Thanks</button>
                    </li>

                    <li class="thinking-of-you">
                        <button>Thinking of You</button>
                    </li>

                    <li class="helpful-count">
                        <button>
                          29
                          <span class="visuallyhidden">likes</span>
                        </button>
                    </li>
                </ul>
            </footer>
        </div>
    </div>
</li>
<!-- END PARTIAL: community/blog_comment -->
        
    
    
        
        <!-- BEGIN PARTIAL: community/blog_comment -->
<li class="row comment">
    <div class="comment-wrapper col-17">
        <img alt="65x65 Placeholder" class="comment-image" src="http://placehold.it/65x65" />

        <div class="comment-content">
            <header class="comment-header clearfix">
                <p class="comment-author">
                    Perla X
                    <span class="date-time">3 days ago</span>
                </p>

                <button class="comment-inappropriate">Report as inappropriate</button>
            </header>

            <p>Quam esse molestiae natus dicta consequatur commodi. ad ut ipsum aut quae. molestias fuga vel impedit rerum totam voluptatem a est</p>

            <footer class="comment-footer">
                <h5>Show your support</h5>
                <ul class="comment-actions">
                    <li class="thanks">
                        <button>Thanks</button>
                    </li>

                    <li class="thinking-of-you">
                        <button>Thinking of You</button>
                    </li>

                    <li class="helpful-count">
                        <button>
                          7
                          <span class="visuallyhidden">likes</span>
                        </button>
                    </li>
                </ul>
            </footer>
        </div>
    </div>
</li>
<!-- END PARTIAL: community/blog_comment -->
        
    
    
        
        <!-- BEGIN PARTIAL: community/blog_comment -->
<li class="row comment last">
    <div class="comment-wrapper col-17">
        <img alt="65x65 Placeholder" class="comment-image" src="http://placehold.it/65x65" />

        <div class="comment-content">
            <header class="comment-header clearfix">
                <p class="comment-author">
                    Angelo X
                    <span class="date-time">3 days ago</span>
                </p>

                <button class="comment-inappropriate">Report as inappropriate</button>
            </header>

            <p>Dolore in quia exercitationem qui. expedita voluptas est ipsum qui cupiditate. nobis sit quos et fugit iure et autem in. non culpa voluptatem eius nesciunt consectetur</p>

            <footer class="comment-footer">
                <h5>Show your support</h5>
                <ul class="comment-actions">
                    <li class="thanks">
                        <button>Thanks</button>
                    </li>

                    <li class="thinking-of-you">
                        <button>Thinking of You</button>
                    </li>

                    <li class="helpful-count">
                        <button>
                          11
                          <span class="visuallyhidden">likes</span>
                        </button>
                    </li>
                </ul>
            </footer>
        </div>
    </div>
</li>
<!-- END PARTIAL: community/blog_comment -->
        
    
    
    </ul>

    <div class="more-comments row">
        <div class="col-17">

          <!-- Show More -->
          <!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more">
  <div class="row">
    <div class="col col-24">
      <a class="show-more-link " href="#" data-path="community/comments" data-container="comments" data-item="comment" data-count="6">More Comments<i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
          <!-- .show-more -->

        </div>
    </div>

    <fieldset class="add-comment row">
        <div class="col-17">
            <label for="add-your-comment" class="visuallyhidden">Add your comment</label>
            <textarea class="add-your-comment" id="add-your-comment" placeholder="Add your comment..."></textarea>
            <a href="REPLACE" class="button">Submit</a>
        </div>
    </fieldset>
</div>
<!-- END PARTIAL: community/blog_comments -->
</div>