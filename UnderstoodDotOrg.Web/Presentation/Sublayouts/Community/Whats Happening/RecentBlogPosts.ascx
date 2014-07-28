<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentBlogPosts.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.RecentBlogPosts" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="community-blogs">
    <div class="row">
        <div class="col col-24 community-blogs-wrapper">
            <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.RecentBlogPostsLabel %></h2>
            <div class="carousel-arrow-wrapper">
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows blogs next-prev-menu arrows">

                    <a class="view-all" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeAllBlogsLabel %></a>
                    
                    <div class="rsArrow rsArrowLeft">
                        <button class="rsArrowIcn"></button>
                    </div>
                    <div class="rsArrow rsArrowRight">
                        <button class="rsArrowIcn"></button>
                    </div>
                </div>
                <!-- end .arrows -->
                <!-- END PARTIAL: community/carousel_arrows -->
            </div>
            <div class="row blog-cards">
                <asp:Repeater ID="BlogsRepeater" ItemType="UnderstoodDotOrg.Services.Models.Telligent.BlogPost" runat="server">
                    <ItemTemplate>
                        <!-- BEGIN PARTIAL: community/blog_card -->
                        <div class="col col-12 blog-card">
                            <div class="blog-card-info group">
                                <div class="blog-card-contents">
                                    <div class="blog-card-title">
                                        <a href="<%# Item.Url %>"><%# Item.Title %></a>
                                    </div>
                                    <!-- end .blog-card-title -->
                                    <div class="blog-card-post-info">
                                        <%# Item.PublishedDate %> from <a href="<%# Item.ParentUrl %>"><%# Item.BlogName %></a>
                                    </div>
                                </div>
                                <div class="card-buttons">
                                    <button type="button" class="button"><%= UnderstoodDotOrg.Common.DictionaryConstants.FollowBlogPost %></button>
                                    <button class="action-skip-this"><%= UnderstoodDotOrg.Common.DictionaryConstants.SkipThisLabel %></button>
                                </div>
                                <!-- end .card-buttons -->
                            </div>
                            <!-- end .blog-card-info -->
                        </div>
                        <!-- end .blog-card -->
                        <!-- END PARTIAL: community/blog_card -->
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <!-- end .blog-cards -->
        </div>
        <!-- end .col.col-24.container -->
    </div>
    <!-- end .row -->
</div><!-- end .community-blogs -->