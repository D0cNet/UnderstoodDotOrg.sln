<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogsPostPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsPostPage" %>
<div id="community-page" class="blog-post community-my-blogs community-blogs-main community-blog-post-list community-blog-posts-author-specific">
    <!-- BEGIN PARTIAL: community/main_header -->
    <sc:Placeholder ID="Placeholder1" Key="BlogHeader" runat="server" />
    <!-- END PARTIAL: community/main_header -->

    <!-- BEGIN PARTIAL: community/blog_feature_post -->
    <sc:Placeholder ID="BlogFeaturePost" Key="FeaturePost" runat="server" />
    <!-- END PARTIAL: community/blog_feature_post -->

    <div class="container">
        <div class="row blog-container row-equal-heights">
            <div class="col col-15 offset-1 blog-post-content skiplink-content" aria-role="main">
                <sc:Placeholder Key="BlogBody" runat="server" />
            </div>
            <div class="col col-1 sidebar-spacer" style="height: 1006px;"></div>
            <!-- BEGIN PARTIAL: community/blog-post-sidebar -->
            <div class="col col-5 offset-1 blog-post-sidebar skiplink-sidebar rs_read_this">
                    
                    <sc:Placeholder key="FoundHelpful" runat="server" />

                <sc:Sublayout Path="~/Presentation/Sublayouts/Tools/BehaviorTools/Widgets/KeepReading.ascx" runat="server"></sc:Sublayout>
            </div>
            <!-- END PARTIAL: community/blog-post-sidebar -->
        </div>
    </div>

    <!-- BEGIN PARTIAL: community/blog_comments -->
    <sc:Placeholder Key="blogComments" runat="server" />
    <!-- END PARTIAL: community/blog_comments -->
</div>
