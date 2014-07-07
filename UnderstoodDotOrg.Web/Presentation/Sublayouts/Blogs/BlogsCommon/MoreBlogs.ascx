<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoreBlogs.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.MoreBlogs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="community-blogs-more">
    <div class="row">
        <div class="col col-24 container">
            <h2><sc:Text Field="More Blogs Text" runat="server" /></h2>
            <!-- BEGIN PARTIAL: community/carousel_arrows -->
            <div class="arrows more-blogs next-prev-menu arrows">

                <div class="rsArrow rsArrowLeft">
                    <button class="rsArrowIcn"></button>
                </div>
                <div class="rsArrow rsArrowRight">
                    <button class="rsArrowIcn"></button>
                </div>
            </div>
            <!-- end .arrows -->
            <!-- END PARTIAL: community/carousel_arrows -->
            <div class="row blogs-more">
                <!-- BEGIN PARTIAL: community/more_blogs_card -->
                <asp:Repeater ID="BlogRepeater" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.Blog" runat="server">
                    <ItemTemplate>
                        <div class="col col-24 blog-card">
                            <div class="blog-card-wrapper">
                                <div class="author-image">
                                    <a href="<%# Item.Url %>">
                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    </a>
                                </div>
                                <!-- end .group-card-image -->
                                <div class="blog-card-info group">
                                    <div class="blog-card-title">
                                        <a href="<%# Item.Url %>"><%# Item.Title %></a>
                                    </div>
                                    <!-- end .blog-card-title -->
                                    <div class="blog-card-post-excerpt">
                                        <%# Item.Description %>
                                    </div>
                                    <a href="<%# Item.Url %>" class="link-see-more">Read <%# Item.Title %></a>
                                </div>
                                <!-- end .blog-card-info -->
                            </div>
                        </div>
                        <!-- end .blog-card -->
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>