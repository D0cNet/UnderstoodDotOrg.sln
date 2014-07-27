<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogsIFollow.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.BlogsIFollow" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="community-my-blogs">
    <div class="row">
        <div class="col col-24 community-my-blogs-wrapper">
            <h2 class="rs_read_this">Blogs I Follow</h2>
            <asp:HyperLink CssClass="button-view-all" ID="lnkSeeAll" runat="server" >See all blogs</asp:HyperLink>
            <div class="row blog-cards">
                <asp:Repeater ID="rptBlogCards" runat="server" ItemType="UnderstoodDotOrg.Services.Models.Telligent.BlogPost">
                    <ItemTemplate>
                        <div class="blog-card-image">
                            <a href="<%# Item.ItemUrl %>" class="rs_skip">
                                <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                            </a>
                        </div>
                        <!-- end .group-card-image -->
                        <div class="blog-card-info group">
                            <div class="blog-card-title">
                                <a href="<%# Item.ItemUrl %>"><%# Item.Title %></a>
                            </div>
                            <!-- end .blog-card-title -->
                            <div class="blog-card-post-info">
                                Posted by <a href="REPLACE"><%# Item.Author %></a> <%# Item.PublishedDate %>
                            </div>
                            <div class="blog-card-post-excerpt">
                                <%# Item.Body %><a href="<%# Item.ItemUrl %>" class="link-see-more">See more</a>
                            </div>
                        </div>
                        <!-- end .blog-card-info -->
                        <div class="blog-card-author-info">
                            <a href="REPLACE" class="rs_skip">
                                <img alt="70x70 Placeholder" src="http://placehold.it/70x70" /><br />
                                <span class="author-name"><%# Item.Author %></span></a><br />
                            <a href="REPLACE" class="blog-name-wrapper">
                                <span class="blog-name"><%# Item.BlogName %></span>
                            </a>
                            <button type="button" class="button rs_skip">Unfollow</button>
                        </div>
                        <!-- end .blog-card-author-info -->
                <!-- end .blog-card -->
                        <!-- END PARTIAL: community/my_blog_card -->
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <!-- end .blog-cards -->
        </div>
        <!-- end .col.col-24.container -->
    </div>
    <!-- end .row -->
</div>
<!-- end .community-blogs -->