<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubTopicHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics.SubTopicHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container page-topic with-share offset-1">
    <div class="row  header-wrapper">
        <div class="col col-14 offset-1 header-title rs_read_this">
            <asp:HyperLink runat="server" ID="hlBreadcrumbNav" CssClass="back-to-previous"><i class="icon-arrow-left-blue"></i><asp:Literal runat="server" ID="litPreviousLink"/></asp:HyperLink>

            <h1><asp:Literal runat="server" ID="litTitle" /></h1>
        </div>

        <div class="col col-9 header-share-save">
            <!-- BEGIN PARTIAL: share-save -->
            <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />

            <!-- END PARTIAL: share-save -->
        </div>
    </div>
</div>

<!-- BEGIN MODULE: Secondary Nav -->
<nav id="subtopic-nav-filter" class="container nav-secondary">
  <div class="row">
    <div class="col col-24">

    <!-- BEGIN ELEMENT: Menu -->

      <div class="label-menu"><span><%= UnderstoodDotOrg.Common.DictionaryConstants.FilterByLabel %></span></div>
      <ul class="menu" aria-role="navigation" aria-label="secondary-navigation">
        <li class="title"><span><asp:Literal ID="litFirstFilter" runat="server" /></span> <i class="icon-hide-show-fff"></i></li>
        <li class="submenu">
          <div class="inner">
            <div class="label-more"><button><%= UnderstoodDotOrg.Common.DictionaryConstants.MoreButtonText %> <i class="icon-hide-show-fff"></i></button></div>
            <ul>
                <asp:Repeater ID="rptFilters" runat="server">
                    <ItemTemplate>
                        <li><span><asp:HyperLink href="#" ID="hlFilter" runat="server" /></span></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
          </div><!-- .inner -->
        </li><!-- .submenu -->
      </ul><!-- .menu -->
      
<!-- END ELEMENT: Menu -->

    </div><!-- .col -->
  </div><!-- .row -->
</nav><!-- .container.nav-secondary -->

<!-- END MODULE: Secondary Nav -->