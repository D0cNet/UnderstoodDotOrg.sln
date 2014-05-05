<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicPageHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic.TopicPageHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
      <!-- BEGIN PARTIAL: pagetopic -->
<!-- Page Title -->
<div class="container page-topic">
  <div class="row">
    <div class="col col-14 offset-1">
      
        <asp:HyperLink runat="server" ID="hlBreadcrumbNav" CssClass="back-to-previous">
            <i class="icon-arrow-left-blue"></i>
            <asp:Literal runat="server" ID="txtBreadcrumbNav" ></asp:Literal>
            <!--School & Learning-->
        </asp:HyperLink>
      
      <h1><%--Grade School--%>
          <asp:Literal runat="server" ID="scTopicTitle" ></asp:Literal>
      </h1>
      
    </div>
    
    <div class="col col-9">
      <!-- BEGIN PARTIAL: share-save -->
<div class="share-save-container">
  <div class="share-save-social-icon">
  	<div class="toggle">
	    <a href="REPLACE" class="socicon icon-facebook">Facebook</a><br />
	    <a href="REPLACE" class="socicon icon-twitter">Twitter</a><br />
	    <a href="REPLACE" class="socicon icon-googleplus">Google&#43;</a><br />
	    <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
	</div>
  </div>
  <div class="share-save-icon">
    <h3>Share &amp; Save</h3>
    <!-- leave no white space for layout consistency -->
    <a href="REPLACE" class="icon icon-share">Share</a><span class="tools"><a href="REPLACE" class="icon icon-email">Email</a><a href="REPLACE" class="icon icon-save">Save</a><a href="REPLACE" class="icon icon-print">Print</a><a href="REPLACE" class="icon icon-remind">Remind</a><a href="REPLACE" class="icon icon-rss">RSS</a></span>
  </div>
</div>

<!-- END PARTIAL: share-save -->
    </div>
    
  </div>
</div><!-- .container -->

<!-- END PARTIAL: pagetopic -->
<!-- BEGIN MODULE: Secondary Nav -->
<nav class="container nav-secondary">
  <div class="row">
    <div class="col col-24">

      <!-- BEGIN ELEMENT: Menu -->

      <div class="label-menu"><span>Menu</span></div>
      <ul class="menu">
        <li class="title"><span>Overview</span> <i class="icon-hide-show-fff"></i></li>
        <li class="submenu">
          <div class="inner">
            <div class="label-more"><span>More <i class="icon-hide-show-fff"></i></span></div>
            <ul>
                <asp:Repeater runat="server" ID="rptTopicHeader" OnItemDataBound="rptTopicHeader_ItemDataBound" >
                    <ItemTemplate>
                        <li><span><%--<a href="REPLACE" class="selected">Overview</a>--%>
                                <asp:HyperLink runat="server" ID="hlNavigationTitle" ></asp:HyperLink>
                            </span></li>
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