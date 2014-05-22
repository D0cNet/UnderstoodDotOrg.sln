<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FromOurBlogs.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.FromOurBlogs" %>
<div class="community-our-blogs">
    <div class="row">
        <div class="col col-24 container skiplink-content" aria-role="main" aria-role="main">
            <h2>From Our Blogs</h2>
            <div class="row blogs-more">
                <asp:Repeater ID="BlogPostsRepeater" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.BlogPost" runat="server">
                    <ItemTemplate>
                        <div class="col col-24 blog-card clearfix">
                            <div class="blog-card-image">
                                <a href="<%# Item.Url %>">
                                    <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                                </a>
                            </div>
                            <!-- end .group-card-image -->
                            <div class="blog-card-info group">
                                <div class="blog-card-title">
                                    <a href="<%# Item.Url %>"><%# Item.Title %></a>
                                </div>
                                <!-- end .blog-card-title -->
                                <div class="blog-card-post-info">
                                    Posted by <a href="REPLACE"><%# Item.Author %></a> <%# Item.PublishedDate %>
                                </div>
                                <div class="blog-card-post-excerpt">
                                    <!--<%# Item.Body %> --><a href="<%# Item.Url %>" class="link-see-more">See more</a>
                                </div>
                                <span class="children-key clearfix">
                                    <ul>
                                        <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                        <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                    </ul>
                                </span>
                            </div>
                            <!-- end .blog-card-info -->
                            <div class="blog-card-author-info-container">
                                <div class="blog-card-author-info">
                                    <a href="REPLACE" class="author-image">
                                        <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                                    </a>
                                    <div class="author-and-blog-name">
                                        <a href="REPLACE" class="author-name"><%# Item.Author %>
                                        </a>
                                        <a href="REPLACE" class="blog-name"><%# Item.BlogName %>
                                        </a>
                                    </div>
                                    <div class="blog-card-button">
                                        <button class="button gray">Unfollow</button>
                                    </div>
                                    <!-- end .blog-card-button -->
                                </div>
                                <!-- end .blog-card-author-info -->
                            </div>
                            <!-- end .blog-card-author-info-container -->
                        </div>
                        <!-- end .blog-card -->
                        <!-- END PARTIAL: community/our_blogs_card -->
                    </ItemTemplate>
                </asp:Repeater>
                <!-- END PARTIAL: community/our_blogs_card -->
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
                        </div>
                        <!-- .children-key -->
                    </div>
                    <!-- .col -->
                </div>
                <!-- .row -->
            </div>
            <!-- .child-content-indicator -->
            <!-- END PARTIAL: children-key -->
            <a href="REPLACE" class="button-view-all">See all blogs</a>
        </div>
    </div>
</div>