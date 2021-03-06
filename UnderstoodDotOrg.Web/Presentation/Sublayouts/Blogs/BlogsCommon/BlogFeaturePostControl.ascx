﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogFeaturePostControl.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogFeaturePostControl" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/FollowButton.ascx" TagName="FollowButton" TagPrefix="CommonUC" %>
<!--blog feature post-->
<div class="row">
    <div class="col-24 blog-feature skiplink-feature">
        <div class="rs_read_this">
            <div class="col col-20 blog-feature-info">
                <div class="blog-feature-image">
                    <a href="REPLACE">




                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" /></a>


                </div>
                <div class="blog-feature-description">


                    <h2>
                        <asp:Literal Text="" ID="litBlogtitle" runat="server" /></h2>




                    <p class="blog-description-blurb">
                        <asp:Literal Text="" ID="litBlogDescription" runat="server" /></p>
                </div>
            </div>
            <div class="col col-4 blog-feature-follow-blog">
                <%--<a href="REPLACE" class="button">Follow-blog</a>--%>
                <CommonUC:FollowButton ID="follBtn" runat="server" />
                <a class="rss icon" href="REPLACE" class="rs_skip">RSS Feed</a>
            </div>
        </div>
    </div>
</div>