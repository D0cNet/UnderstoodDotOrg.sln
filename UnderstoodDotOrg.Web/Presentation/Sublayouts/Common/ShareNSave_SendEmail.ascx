<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareAndSaveTool.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ShareAndSaveTool" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<script type="text/javascript">
    (function (d) {
        var f = d.getElementsByTagName('SCRIPT')[0], p = d.createElement('SCRIPT');
        p.type = 'text/javascript';
        p.async = true;
        p.src = '//assets.pinterest.com/js/pinit.js';
        f.parentNode.insertBefore(p, f);
    }(document));
</script>
<script type="text/JavaScript">
    function saveIt() {
        document.execCommand("SaveAs")
    }
</script>
      <!-- BEGIN PARTIAL: share-save -->
<div class="share-save-container">
  <div class="share-save-social-icon">
  	<div class="toggle">
	    <a href="https://facebook.com/sharer.php?u=<%= Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item) %>" class="socicon icon-facebook">Facebook</a><br /> <!-- Facebook  href="https://facebook.com/sharer.php?u=YOURURLHERE"-->
	    <a href="https://twitter.com/intent/tweet?url=<%= Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item) %>&text=<%= Sitecore.Context.Item.Name %>&via=YOURTWITTERNAMEHERE" class="socicon icon-twitter">Twitter</a><br /><!-- Twitter href="https://twitter.com/intent/tweet?url=YOURURLHERE&text=YOURPOSTTITLEHERE&via=YOURTWITTERNAMEHERE"  -->
	    <a href="href="https://plus.google.com/share?url=<%= Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item) %>" class="socicon icon-googleplus">Google&#43;</a><br /> <!-- Google +  href="https://plus.google.com/share?url=YOURURLHERE" -->
	    <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
	</div>
  </div>
  <div class="share-save-icon">
    <h3>Share &amp; Save</h3>
    <!-- leave no white space for layout consistency -->
    <a href="REPLACE" class="icon icon-share">Share</a><span class="tools">

        <a href="REPLACE" class="icon icon-email" onclick="">Email</a>
        <a href="javascript:saveIt()" class="icon icon-save">Save</a>
        <a href="REPLACE" class="icon icon-print" onclick="window.print()">Print</a>
        <a href="REPLACE" class="icon icon-remind">Remind</a>
        <a href="REPLACE" class="icon icon-rss">RSS</a></span>
  </div>
</div>

<!-- END PARTIAL: share-save -->