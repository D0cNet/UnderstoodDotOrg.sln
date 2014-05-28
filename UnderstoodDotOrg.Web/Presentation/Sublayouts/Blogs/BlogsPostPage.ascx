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

                <sc:Sublayout Path="~/Presentation/Sublayouts/Tools/BehaviorTools/Widgets/KeepReading.ascx" runat="server"></sc:Sublayout>
            </div>
            <!-- END PARTIAL: community/blog-post-sidebar -->
        </div>
    </div>

    <!-- BEGIN PARTIAL: community/blog_comments -->
    <sc:Placeholder Key="blogComments" runat="server" />
    <!-- END PARTIAL: community/blog_comments -->
</div>
