<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogFeaturePostControl.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogFeaturePostControl" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/FollowButton.ascx" TagName="FollowButton" TagPrefix="CommonUC" %>
<!--blog feature post-->
<div class="row">
    <div class="col-24 blog-feature skiplink-feature">
        <div class="col col-20 blog-feature-info">
            <div class="blog-feature-image">
                <a href="REPLACE">




                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" /></a>


            </div>
            <div class="blog-feature-description">


                <h2>Sequi Dolores Beatae</h2>




                <p class="blog-description-blurb">Ratione Velit Itaque Dicta Repellat. Quaerat Maiores Atque Corporis Quidem Laborum. Quo Ipsum Sunt Provident Minus. Beatae Enim Inventore Consequatur Velit Est Ullam Quia Quia</p>
            </div>
        </div>
        <div class="col col-4 blog-feature-follow-blog">
            <%--<a href="REPLACE" class="button">Follow-blog</a>--%>
            <CommonUC:FollowButton ID="follBtn" runat="server" />
            <a class="rss icon" href="REPLACE">RSS Feed</a>
        </div>
    </div>
</div>