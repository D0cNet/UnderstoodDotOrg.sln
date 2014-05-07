<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogsPostPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsPostPage" %>
<div id="community-page" class="blog-post community-my-blogs community-blogs-main community-blog-post-list community-blog-posts-author-specific">
    <!-- BEGIN PARTIAL: community/main_header -->
    <sc:Placeholder ID="Placeholder1" Key="BlogHeader" runat="server" />
    <!-- END PARTIAL: community/main_header -->

    <!-- BEGIN PARTIAL: community/blog_feature_post -->
    <sc:Placeholder ID="BlogFeaturePost" Key="FeaturePost" runat="server" />
    <!-- END PARTIAL: community/blog_feature_post -->

    <div class="container">
        <div class="row blog-container">
            <sc:Placeholder Key="BlogBody" runat="server" />
            <!-- BEGIN PARTIAL: community/blog-post-sidebar -->
            <div class="col col-6 blog-post-sidebar skiplink-sidebar">
                    
                    <sc:Placeholder key="FoundHelpful" runat="server" />

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
    <sc:Placeholder Key="blogComments" runat="server" />
    <!-- END PARTIAL: community/blog_comments -->
</div>
