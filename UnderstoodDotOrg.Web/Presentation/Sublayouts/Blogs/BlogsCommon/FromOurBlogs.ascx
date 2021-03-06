﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FromOurBlogs.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.FromOurBlogs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/FollowButton.ascx" TagName="FollowButton" TagPrefix="CommonUC" %>
<div class="community-our-blogs">
    <div class="row">
        <div class="col col-24 container skiplink-content" aria-role="main">
            <h2 class="rs_read_this"><sc:Text Field="From Our Blogs Text" runat="server" /></h2>
            <div class="row blogs-more">
                <asp:UpdatePanel ID="upBlogPosts" runat="server">
                    <%--<Triggers>
                        <asp:AsyncPostBackTrigger ControlID="" EventName="Click" />
                    </Triggers>--%>
                    <ContentTemplate>
                <asp:Repeater ID="BlogPostsRepeater" ItemType="UnderstoodDotOrg.Services.Models.Telligent.BlogPost" OnItemDataBound="BlogPostRepeater_OnItemDataBound" runat="server">
                    <ItemTemplate>
                        <div class="col col-24 blog-card clearfix rs_read_this">
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
                                    <sc:Text  Field="Posted By Text" runat="server" /> <a href="<%# Item.AuthorUrl %>"><%# Item.Author %></a> <%# Item.PublishedDate %>
                                </div>
                                <div class="blog-card-post-excerpt">
                                    <%# Item.Body %> <a href="<%# Item.Url %>" class="link-see-more">See more</a>
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
                                        <a href="<%# Item.AuthorUrl %>" class="author-name"><%# Item.Author %>
                                        </a>
                                        <a href="<%# Item.ParentUrl %>" class="blog-name"><%# Item.BlogName %>
                                        </a>
                                    </div>
                                    <div class="blog-card-button">
                                        <CommonUC:FollowButton ID="follBtn" runat="server" />
<%--                                        <asp:Button ID="btnFollow" CommandArgument="<%# Item.ContentId + '&' + Item.ContentTypeId %>" CssClass="button gray" Text="Follow" runat="server" />--%>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </div>
            <sc:sublayout runat="server" path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
        </div>
    </div>
</div>
