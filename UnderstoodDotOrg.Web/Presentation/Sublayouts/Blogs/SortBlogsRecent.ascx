<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SortBlogsRecent.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.SortBlogsRecent" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="col blog-post-list skiplink-content" aria-role="main">
    <div class="blog-post-list-inner">
        <asp:Repeater ID="rptBlogInfo" runat="server" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.BlogPost">
            <ItemTemplate>
                <!-- BEGIN PARTIAL: community/blog_post -->
                <div class="blog-post">
                    <div class="blog-card-image blog-card-total-comments">
                        <a>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>

                        <p class="blog-card-comments"><b class="number-of-comments"><%# Item.CommentCount %></b>Comments</p>

                    </div>
                    <div class="blog-card-info group">
                        <h3 class="blog-card-title"><a href="<%# Item.Url %>"><%# Item.Title %></a></h3>


                        <div class="blog-card-post-info">
                            <p class="blog-posted">Posted</p>
                            <p class="blog-post-date"><%# Item.PublishedDate %></p>
                            <p class="blog-by">
                                by
          <a href="<%# Item.AuthorUrl %>" class="author"><%# Item.Author %></a>
                            </p>
                        </div>


                        <p class="blog-card-post-excerpt"><%# Item.Body %></p>
                        <span class="children-key">
                            <ul>
                                <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>

                </div>
                <!-- END PARTIAL: community/blog_post -->
            </ItemTemplate>
        </asp:Repeater>
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
    </div>
    <!-- .show-more -->
    <!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->

</div>
