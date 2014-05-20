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
<script type="text/javascript" src="//assets.pinterest.com/js/pinit.js"></script>
<%--<script type="text/JavaScript">
    function saveIt() {
        //check for browser

        if (hdnBrowser.value == 'InternetExplorer/') {
            document.execCommand('SaveAs');
        }
        if (hdnBrowser.value == 'Firefox/') {
            alert('Firefox');
        }
        if (hdnBrowser.value == 'Chrome/') {
            alert('Chrome');
        }
        else {
            alert(hdnBrowser.value);
        }
    }
</script>--%>

<%--<script >
    function sendemail()
    {
        
        window.open('~/Presentation/Sublayouts/Common/ShareNSave_SendEmail.ascx','1398860309009','width=700,height=500,toolbar=0,menubar=0,location=0,status=1,scrollbars=1,resizable=0,left=0,top=0');return false;"
    }
</script>--%>
<%--<script runat="server">
    public void ImgbtnSave1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write(Request.Browser.Browser);
    }
</script>--%>
<!-- BEGIN PARTIAL: share-save -->

<div class="share-save-container">
    <div class="share-save-social-icon">
        <div class="toggle">
            <asp:HyperLink ID="hlFacebook" CssClass="socicon icon-facebook" runat="server"></asp:HyperLink><br />
            <asp:HyperLink ID="hlTwitter" CssClass="socicon icon-twitter" runat="server"></asp:HyperLink><br />
            <asp:HyperLink ID="hlGooglePlus" CssClass="socicon icon-googleplus" runat="server"></asp:HyperLink><br />
            <a href="//www.pinterest.com/pin/create/button/" data-pin-do="buttonPin"><img src="//assets.pinterest.com/images/pidgets/pinit_fg_en_round_red_16.png" /></a>
        </div>
    </div>

    <div class="share-save-icon">
        <h3>Share &amp; Save</h3>
        <!-- leave no white space for layout consistency -->
        <a href="REPLACE" class="icon icon-share">Share</a><span class="tools">
            <span class="tools">
                <a href="#" class="icon icon-email">Email</a>
                <a href="#" class="icon icon-save">Save</a><%--<a href="javascript:saveIt()" class="icon icon-save">Save</a>--%>
                <a href="#" class="icon icon-print" onclick="window.print()">Print</a>
                <%--OOS for this release--%>
                <%--<a href="#" class="icon icon-remind">Remind</a>--%>
                <a href="#" class="icon icon-rss">RSS</a></span>
        </span>

    </div>
</div>


<!-- END PARTIAL: share-save -->
