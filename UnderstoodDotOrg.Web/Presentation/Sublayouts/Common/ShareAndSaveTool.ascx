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

<%--<script >
    function sendemail()
    {
        window.open('/sitecore/content/Home/Email to Friend.aspx', '1398860309009', 'width=700,height=500,toolbar=0,menubar=0,location=0,status=1,scrollbars=1,resizable=0,left=0,top=0');
    }
</script>
<!-- BEGIN PARTIAL: share-save -->--%>
<div class="share-save-container">
    <div class="share-save-social-icon">
        <div class="toggle">
            <asp:HyperLink ID="hlFacebook" CssClass="socicon icon-facebook" runat="server"></asp:HyperLink><br />
            <asp:HyperLink ID="hlTwitter" CssClass="socicon icon-twitter" runat="server"></asp:HyperLink><br />
            <asp:HyperLink ID="hlGooglePlus" CssClass="socicon icon-googleplus" runat="server"></asp:HyperLink><br />
            <a href="//www.pinterest.com/pin/create/button/" data-pin-do="buttonPin"><img src="//assets.pinterest.com/images/pidgets/pinit_fg_en_round_red_16.png" /></a>
        </div>
    </div>
    <style>
        .share-save-container div.share-save-icon .icon {
            vertical-align: top;
        }
        .share-save-container div.share-save-icon .icon-save.active, .share-save-container div.share-save-icon .icon-save.active:hover {
            background-position: -360px 0;
        }
    </style>
    <div class="share-save-icon">
        <h3>Share &amp; Save</h3>
        <!-- leave no white space for layout consistency -->
        <a href="REPLACE" class="icon icon-share">Share</a>
            <span class="tools">
                <a href="#" class="icon icon-email">Email</a>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbSave" runat="server" CssClass="icon icon-save" OnClick="lbSave_Click" OnClientClick="changeIcon();"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <script>
                    function changeIcon() {
                        if ("<%= this.LoggedInStatus %>" == "True")
                            $(".icon-save").addClass("active");
                    }

                    $(".icon-email").click(function () {
                        $(".email-a-friend-modal").show();
                        $(".email-a-friend-modal").css({ "top": "-475px", "overflow": "hidden" });
                        $(".email-a-friend-modal .modal-dialog").css("opacity", "1");
                    })
                </script>
                <a href="#" class="icon icon-print" onclick="window.print()">Print</a>
                <%--OOS for this release--%>
                <%--<a href="#" class="icon icon-remind">Remind</a>--%>
                <%--When You need it check MembershipManager.LogMemberActivity(x,y,z,q). Sample usage is in Sandbox.ascx.cs--%>

                <%--<a href="#" class="icon icon-rss">RSS</a></span>--%>
        </span>

    </div>
</div>

<sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Common/ShareNSave_SendEmail.ascx" />


<!-- END PARTIAL: share-save -->
