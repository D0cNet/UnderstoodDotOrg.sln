<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecommendedBlogs.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.RecommendedBlogs" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/FollowButton.ascx" TagPrefix="uc1" TagName="FollowButton" %>


<div class="community-blogs">
    <div class="row">
        <div class="col col-24 community-blogs-wrapper">
            <h2 class="rs_read_this">
                <%--Recommended Blogs--%>
                <%= UnderstoodDotOrg.Common.DictionaryConstants.RecommendedBlogsLabel %>
            </h2>
            <div class="carousel-arrow-wrapper">
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows blogs next-prev-menu arrows">

                    <%--<a class="view-all" href="REPLACE">See all blogs</a>--%>
                    <asp:HyperLink ID="hypAllBlogs" runat="server" CssClass="view-all"></asp:HyperLink>

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
                <asp:ListView runat="server" ID="lvBlogCards" OnItemDataBound="lvBlogCards_ItemDataBound">
                    <ItemTemplate>
                        <!-- BEGIN PARTIAL: community/blog_card -->
                        <div class="col col-12 blog-card rs_read_this">
                            <div class="blog-card-info group">
                                <div class="blog-card-contents">
                                    <div class="blog-card-title">
                                        <%--<a href="REPLACE">Illo rerum amet perspiciatis ut officiis et tempore autem sunt ratione</a>--%>
                                        <asp:HyperLink id="hypBlogTitle" runat="server"></asp:HyperLink>
                                    </div>
                                    <!-- end .blog-card-title -->
                                    <div class="blog-card-post-info">
                                        <asp:Literal ID="litBlogDateStamp" runat="server"></asp:Literal>
                                        <%--Posted Jul 4, 1992 from <a href="REPLACE">Giselle Shaffer blog</a>--%>
                                    </div>
                                </div>
                                <div class="card-buttons">
                                    <%--<button type="button" class="button rs_skip">Follow</button>--%>
                                    <uc1:FollowButton runat="server" ID="btnFollowBlog" />
                                    <button class="action-skip-this rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.SkipThisLabel %></button>
                                </div>
                                <!-- end .card-buttons -->
                            </div>
                            <!-- end .blog-card-info -->
                        </div>
                        <!-- end .blog-card -->
                        <!-- END PARTIAL: community/blog_card -->
                    </ItemTemplate>
                </asp:ListView>
                <%--<!-- BEGIN PARTIAL: community/blog_card -->
                <div class="col col-12 blog-card rs_read_this">
                    <div class="blog-card-info group">
                        <div class="blog-card-contents">
                            <div class="blog-card-title">
                                <a href="REPLACE">Illo rerum amet perspiciatis ut officiis et tempore autem sunt ratione</a>
                            </div>
                            <!-- end .blog-card-title -->
                            <div class="blog-card-post-info">
                                Posted Jul 4, 1992 from <a href="REPLACE">Giselle Shaffer blog</a>
                            </div>
                        </div>
                        <div class="card-buttons">
                            <button type="button" class="button rs_skip">Follow</button>
                            <button class="action-skip-this rs_skip">Skip this</button>
                        </div>
                        <!-- end .card-buttons -->
                    </div>
                    <!-- end .blog-card-info -->
                </div>
                <!-- end .blog-card -->
                <!-- END PARTIAL: community/blog_card -->
                <!-- BEGIN PARTIAL: community/blog_card -->
                <div class="col col-12 blog-card rs_read_this">
                    <div class="blog-card-info group">
                        <div class="blog-card-contents">
                            <div class="blog-card-title">
                                <a href="REPLACE">Nesciunt sit reiciendis adipisci beatae quasi quia nulla voluptatem soluta</a>
                            </div>
                            <!-- end .blog-card-title -->
                            <div class="blog-card-post-info">
                                Posted May 29, 2008 from <a href="REPLACE">Guy Graham blog</a>
                            </div>
                        </div>
                        <div class="card-buttons">
                            <button type="button" class="button rs_skip">Follow</button>
                            <button class="action-skip-this rs_skip">Skip this</button>
                        </div>
                        <!-- end .card-buttons -->
                    </div>
                    <!-- end .blog-card-info -->
                </div>
                <!-- end .blog-card -->
                <!-- END PARTIAL: community/blog_card -->
                <!-- BEGIN PARTIAL: community/blog_card -->
                <div class="col col-12 blog-card rs_read_this">
                    <div class="blog-card-info group">
                        <div class="blog-card-contents">
                            <div class="blog-card-title">
                                <a href="REPLACE">Voluptatum nemo numquam ullam sunt reiciendis odio ad est officiis</a>
                            </div>
                            <!-- end .blog-card-title -->
                            <div class="blog-card-post-info">
                                Posted Mar 10, 1996 from <a href="REPLACE">Clyde Weeks blog</a>
                            </div>
                        </div>
                        <div class="card-buttons">
                            <button type="button" class="button rs_skip">Follow</button>
                            <button class="action-skip-this rs_skip">Skip this</button>
                        </div>
                        <!-- end .card-buttons -->
                    </div>
                    <!-- end .blog-card-info -->
                </div>
                <!-- end .blog-card -->
                <!-- END PARTIAL: community/blog_card -->
                <!-- BEGIN PARTIAL: community/blog_card -->
                <div class="col col-12 blog-card rs_read_this">
                    <div class="blog-card-info group">
                        <div class="blog-card-contents">
                            <div class="blog-card-title">
                                <a href="REPLACE">Voluptas nihil non et atque voluptate modi quibusdam</a>
                            </div>
                            <!-- end .blog-card-title -->
                            <div class="blog-card-post-info">
                                Posted Mar 16, 1993 from <a href="REPLACE">Katherine Pittman blog</a>
                            </div>
                        </div>
                        <div class="card-buttons">
                            <button type="button" class="button rs_skip">Follow</button>
                            <button class="action-skip-this rs_skip">Skip this</button>
                        </div>
                        <!-- end .card-buttons -->
                    </div>
                    <!-- end .blog-card-info -->
                </div>
                <!-- end .blog-card -->
                <!-- END PARTIAL: community/blog_card -->
                <!-- BEGIN PARTIAL: community/blog_card -->
                <div class="col col-12 blog-card rs_read_this">
                    <div class="blog-card-info group">
                        <div class="blog-card-contents">
                            <div class="blog-card-title">
                                <a href="REPLACE">Asperiores et eum officia placeat est ut accusamus eum quisquam animi</a>
                            </div>
                            <!-- end .blog-card-title -->
                            <div class="blog-card-post-info">
                                Posted Oct 17, 2005 from <a href="REPLACE">Mohammed Fox blog</a>
                            </div>
                        </div>
                        <div class="card-buttons">
                            <button type="button" class="button rs_skip">Follow</button>
                            <button class="action-skip-this rs_skip">Skip this</button>
                        </div>
                        <!-- end .card-buttons -->
                    </div>
                    <!-- end .blog-card-info -->
                </div>
                <!-- end .blog-card -->
                <!-- END PARTIAL: community/blog_card -->--%>
            </div>
            <!-- end .blog-cards -->
        </div>
        <!-- end .col.col-24.container -->
    </div>
    <!-- end .row -->
</div>
<!-- end .community-blogs -->
