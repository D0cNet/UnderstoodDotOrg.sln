<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsAdviceVideoPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsAdviceVideoPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article">
  <div class="row row-equal-heights">
    <!-- article -->
    <div class="col col-15 offset-1">
      <a href="REPLACE" class="back-to-previous left-of-first-next-prev-menu"><i class="icon-arrow-left-blue"></i> Back to task-to-task transitions</a>

      <!-- BEGIN PARTIAL: first-next-prev-menu -->
<div class="first-next-prev-menu arrows-gray">
  <span class="next-prev-text">Next Tip</span>
  <div class="rsArrow rsArrowLeft"><div class="rsArrowIcn"></div></div>
  <div class="rsArrow rsArrowRight"><div class="rsArrowIcn"></div></div>
</div><!-- end .first-next-prev-menu -->
<!-- END PARTIAL: first-next-prev-menu -->

      <!-- BEGIN PARTIAL: in-this-video -->
<div class="expert-advice-wrapper">
  <div class="expert-video">
    <h2><sc:FieldRenderer runat="server" FieldName="Tip Title" /></h2>
      <div class="player-container">
        <div class="player">
            <sc:FieldRenderer runat="server" FieldName="Video Embed" />
        </div>
      </div>
  </div> <!-- end expert-video -->
  <div class="in-this-video">
    <h2>In this video</h2>
    <sc:FieldRenderer runat="server" FieldName="Video Description" />
  </div> <!-- end in-this-video -->
</div> <!-- end expert-advice-wrapper -->

<!-- END PARTIAL: in-this-video -->
    </div>

    <div class="col col-1 sidebar-spacer"></div>

    <!-- right bar -->
    <div class="col col-5 offset-1">
      <!-- BEGIN PARTIAL: helpful-count -->
<div class="count-helpful">
  <a href="REPLACE"><span>34</span>Found this helpful</a>
</div>
<!-- END PARTIAL: helpful-count -->
      <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
      <!-- BEGIN PARTIAL: find-helpful -->
<div class="find-this-helpful sidebar">
   
  <h4>Did you find this helpful?</h4>
  <ul>
    <li>
      <button class="helpful-yes">Yes</button>
    </li>
    <li>
      <button class="helpful-no">No</button>
    </li>
  </ul>
  <div class="clearfix"></div>
   
</div>
<!-- END PARTIAL: find-helpful -->
      <!-- BEGIN PARTIAL: keep-reading -->
        <asp:Repeater ID="rptRelatedArticles" runat="server">
            <HeaderTemplate>
                <div class="keep-reading">
                  <h3><sc:FieldRenderer runat="server" FieldName="Related Articles Title" /></h3>
                  <ul>
            </HeaderTemplate>
            <ItemTemplate>
                       <li <%# (Container.ItemIndex + 1 == rptRelatedArticles.Items.Count) ? "last-child" : "" %>><asp:HyperLink ID="hlArticleLink" runat="server" /></li>
            </ItemTemplate>
            <FooterTemplate>
                  </ul>
                </div>
            </FooterTemplate>
        </asp:Repeater>
<!-- END PARTIAL: keep-reading -->
    </div>
  </div><!-- .row -->
</div><!-- .container -->


<div class="container">
  <div class="row row-equal-heights">
    <div class="col col-15 offset-1">
      <!-- BEGIN PARTIAL: find-helpful -->
<div class="find-this-helpful content">
   
  <h4>Did you find this helpful?</h4>
  <ul>
    <li>
      <button class="helpful-yes">Yes</button>
    </li>
    <li>
      <button class="helpful-no">No</button>
    </li>
  </ul>
  <div class="clearfix"></div>
   
</div>
<!-- END PARTIAL: find-helpful -->
    </div>
    <div class="col col-1 sidebar-spacer"></div>
    <div class="col col-5 offset-1">
      <!-- BEGIN PARTIAL: second-next-prev-menu -->
<div class="second-next-prev-menu arrows-gray">
  <span class="next-prev-text">Next Tip</span>
  <div class="second-next-prev-menu-slider">
    <p class="next-prev-title">Start by demonstrating, then shift to supervising</p>
    <p class="next-prev-title">Start by demonstrating, then shift to supervising</p>
    <p class="next-prev-title">Start by demonstrating, then shift to supervising</p>
  </div>
</div><!-- end .second-next-prev-menu -->
<!-- END PARTIAL: second-next-prev-menu -->
    </div>
  </div><!-- .row -->
</div><!-- .container -->









