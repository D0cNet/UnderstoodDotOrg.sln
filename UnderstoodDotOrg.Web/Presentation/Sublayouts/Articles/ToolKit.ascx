<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolKit.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.ToolKit" %>

<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCounts.ascx" runat="server"></sc:Sublayout>

  <div class="container article">
    <div class="row">
      <!-- article -->
      <!-- BEGIN PARTIAL: article-toolkit-intro -->
        <div class="toolkit-overlay">
          <div class="col col-13 offset-1">
            <p><sc:FieldRenderer FieldName="Featured Image" runat="server"></sc:FieldRenderer></p>
          </div>
          <div class="col col-9  offset-1">
            <sc:FieldRenderer FieldName="Body Content" runat="server"></sc:FieldRenderer>
          </div>
        </div><!-- END toolkit-overlay -->
        <!-- END PARTIAL: article-toolkit-intro -->
    </div>
  </div><!-- .container -->

  <!-- BEGIN PARTIAL: toolkit-thumbnails -->
<div class="container toolkit-thumbnails-container">
  <div class="row">
    <div class="col col-24">
      <div class="inner-container rs_read_this">
        <div id="toolkit-thumbnails">
            <i id="iconType" runat="server"></i>
            <asp:Repeater ID="rptDownloads" runat="server" OnItemDataBound="rptDownloads_ItemDataBound">
                <HeaderTemplate>

                </HeaderTemplate>
                <ItemTemplate>
                    <div class="thumbnail skiplink-content rs_read_this" aria-role="main">
                        <h4><a href="REPLACE"><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title"></sc:FieldRenderer></a></h4>
                        <div class="bottom">
                            <i id="iconType" runat="server"></i>
                            <asp:HyperLink ID="hypDownloadLink" runat="server"></asp:HyperLink>
                            <span id="fileSize" runat="server">125K</span>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>

                </FooterTemplate>
            </asp:Repeater>
          <div class="clearfix"></div>
        </div>
      </div>
    </div>
  </div>
  <div class="row">
    <div class="col col-15 offset-2">
      
        <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx"/>

    </div>
  </div>
</div>

<!-- END PARTIAL: toolkit-thumbnails -->


<sc:Sublayout ID="Sublayout1" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpful.ascx"/>