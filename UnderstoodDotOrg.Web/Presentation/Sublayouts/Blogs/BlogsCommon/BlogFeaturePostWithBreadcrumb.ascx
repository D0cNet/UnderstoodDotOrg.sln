<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogFeaturePostWithBreadcrumb.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.BlogFeaturePostWithBreadcrumb" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/FollowButton.ascx" TagName="FollowButton" TagPrefix="CommonUC" %>
<!--blog feature post-->
<div class="row">
  <div class="col-24 blog-feature ">
    <div class="col col-20 blog-feature-info">
      <div class="blog-feature-image">
        <a href="REPLACE">

          
            <img alt="72x72 Placeholder" src="http://placehold.it/72x72" /></a>
          

          

      </div>
      <div class="blog-feature-description">

        

        
        <!-- BEGIN PARTIAL: community/breadcrumb_menu -->
<!--breadcrumb menu-->
<a href="REPLACE" ID="hrefBackLink" runat="server" class="back-to-previous">
  <i class="icon-arrow-left-blue"></i><asp:Literal ID="litBackLink" runat="server"></asp:Literal>
</a>
<!-- END PARTIAL: community/breadcrumb_menu -->
        

        <p class="blog-description-blurb">Ratione Temporibus Quae Itaque Magnam Id Accusantium Qui At Non Numquam Minima Saepe Ea. Et Natus Amet Placeat Delectus. Qui Tempora Cupiditate Dolorum Deserunt Delectus Animi Non Quos Sit Unde Consequatur. Rerum Optio Qui Dicta Architecto Praesentium Incidunt Eligendi Dolorem Sed</p>
      </div>
    </div>
    <div class="col col-4 blog-feature-follow-blog">
      <%--<a href="REPLACE" class="button">Follow-blog</a>--%>
        <CommonUC:FollowButton ID="follBtn" runat="server" />
      <a class="rss icon" href="REPLACE">RSS Feed</a>
    </div>
  </div>
</div>