<%@ Page Language="c#" CodePage="65001" AutoEventWireup="true" CodeBehind="Browser.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Layouts.Browser" %>

<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<%@ OutputCache Location="None" VaryByParam="none" %>
<!DOCTYPE html>
<!--[if lte IE 8]><html class="no-js nonresponsive old-ie" lang="<%= ContextLanguage.InnerItem["Iso"] %>"><![endif]-->
<!--[if gte IE 9]><!--><html class="no-js" lang="<%= ContextLanguage.InnerItem["Iso"] %>"><!--<![endif]-->

<!-- BEGIN PARTIAL: head -->
<head runat="server">
    <meta charset="utf-8">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <meta name="apple-mobile-web-app-capable" content="yes">

    <link rel="icon" type="image/x-icon" href="/favicon.ico">




    <link href="/Presentation/includes/css/vendor/bootstrap.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/vendor/normalize.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/vendor/boilerplate.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/vendor/royalslider.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/vendor/jplayer-blue-monday.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/vendor/ui-lightness/jquery-ui-1.10.4.custom.css" rel="stylesheet" />


    <!--[if gte IE 9]><!-->
    <link href="/Presentation/includes/css/base.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/grid.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/layout.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/globals.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/modules.css" rel="stylesheet" />
    <asp:Literal ID="headerSectionCSS" runat="server"></asp:Literal>
    <link href="/Presentation/includes/css/uniform-understood.css" rel="stylesheet" />
	<link href="/Presentation/includes/css/oasis.css" rel="stylesheet" />
    <!--<![endif]-->


    <!--[if lte IE 8]>
    <link href="/Presentation/includes/css/base.css" rel="stylesheet" />
<link href="/Presentation/includes/css/grid-nonresponsive.css" rel="stylesheet" />
<link href="/Presentation/includes/css/layout-nonresponsive.css" rel="stylesheet" />
<link href="/Presentation/includes/css/globals-nonresponsive.css" rel="stylesheet" />
<link href="/Presentation/includes/css/modules-nonresponsive.css" rel="stylesheet" />
<link href="/Presentation/includes/css/homepage-nonresponsive.css" rel="stylesheet" />
<link href="/Presentation/includes/css/uniform-understood-nonresponsive.css" rel="stylesheet" />
  <![endif]-->

    <link href="/Presentation/includes/css/print.css" media="print" rel="stylesheet" />
    
    <script src="/Presentation/includes/js/vendor/modernizr.custom.js"></script>
</head>

<!-- END PARTIAL: head -->
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1"  runat="server" />
        <asp:PlaceHolder ID="phWelcomeTour" runat="server" Visible="false">
            <div data-show-welcome-tour="true" id="community-page" data-lang="<%= Sitecore.Context.Language.Name %>"></div>
        </asp:PlaceHolder>


        <%--<sc:sublayout id="scHeader" runat="server" path="~/Presentation/SubLayouts/Containers/Header.ascx" />--%>
        <!-- BEGIN PARTIAL: language-selector -->
        <div id="language-selector-bar">

            <span class="button-close ir"><asp:Literal ID="litClose" runat="server" /></span>

            <dl>
                <dt><asp:Literal ID="litLanguage" runat="server" /></dt>
                <asp:Repeater runat="server" ID="rptLanguage">
                    <ItemTemplate>
                        <dd>
                            <asp:HyperLink ID="hlLanguage" runat="server" CssClass="button" />
                        </dd>
                    </ItemTemplate>
                </asp:Repeater>
            </dl>

        </div>
        <!-- END PARTIAL: language-selector -->

        <div id="wrapper">

            <sc:Placeholder ID="Placeholder1" Key="Header" runat="server" />
            <sc:Placeholder ID="Placeholder2" Key="Main" runat="server" />
            <sc:Placeholder ID="Placeholder3" Key="Footer" runat="server" />
        </div>
        <!-- #wrapper -->

        <%-- Currently update panel and requires to be on body to display properly --%>
        <sc:Sublayout ID="sbShareEmailModal" runat="server" Path="~/Presentation/Sublayouts/Common/ShareNSave_SendEmail.ascx" />

        <!-- BEGIN PARTIAL: footerjs -->
        <script src="/Presentation/includes/js/vendor/jquery-1.10.2.min.js" type="text/javascript"></script>
        <!--[if lte IE 8]>
<script src="/Presentation/includes/js/vendor/selectivizr.js"></script><![endif]-->



        <script src="/Presentation/includes/js/vendor/jquery.uniform.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.validate.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.royalslider.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.hoverIntent.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.equalheights.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.easytabs.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.jplayer.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery-ui-1.10.4.custom.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.ui.custom.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.ui.touch-punch.min.js"></script>
        <script src="/Presentation/includes/js/vendor/bootstrap.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.ezmark.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.mobile.custom.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.placeholder.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.ellipsis.min.js"></script>
        <script src="/Presentation/includes/js/vendor/jquery.zclip.min.js"></script>
        <script src="/Presentation/includes/js/vendor/hyphenate.min.js"></script>
        <script src="/Presentation/includes/js/vendor/json2.js"></script>
        <script src="/Presentation/includes/js/vendor/handlebars-v1.3.0.js"></script>
        <script src="/Presentation/includes/js/vendor/readspeaker/ReadSpeaker.js?pids=embhl,custom"></script>
        <script src="/Presentation/includes/js/site.js"></script>
        <script src="/Presentation/includes/js/modules.js"></script>
        <asp:literal runat="server" id="footerSectionJS"></asp:literal>
        <script src="/Presentation/includes/js/global.js"></script>
		<script src="/Presentation/includes/js/oasis.js"></script>
<script src="/Presentation/includes/js/vendor/jquery.fs.zoomer.min.js"></script>
<script src="/Presentation/includes/js/vendor/imagesloaded.min.js"></script>
<script src="/Presentation/includes/js/infographic-zoom.js"></script>
        <%--<script type="text/javascript" async src="//assets.pinterest.com/js/pinit.js"></script>--%>
        <script src="/Presentation/includes/js/html2canvas.js"></script>
        <script src="/Presentation/includes/js/jspdf.min.js"></script>
        <script src="/Presentation/includes/js/jspdf.custom.js"></script>
    <script src="/Presentation/includes/js/vendor/buzz.js"></script>
    <script src="/Presentation/includes/js/vendor/jquery.transit.min.js"></script>
        <sc:Placeholder runat="server" Key="AfterResources" />
        <sc:sublayout id="SBReviewedBy" runat="server" path="~/Presentation/Sublayouts/Articles/Article Entry Message Page.ascx" />
        
        <asp:Literal ID="litAnalytics" runat="server" />

        <!-- END PARTIAL: footerjs -->
        
    </form>

    <sc:Placeholder runat="server" Key="AfterFormModal" />
    <div class="modal fade modal-standard" id="checklist-article-downloading-modal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    Downloading, please wait...
                </div>
                <!-- /.modal-body -->
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
</body>


</html>
