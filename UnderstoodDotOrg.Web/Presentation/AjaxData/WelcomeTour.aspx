<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomeTour.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.WelcomeTour" %>

<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="welcome-tour-modal modal fade">
    <div class="modal-dialog">
        <div class="modal-content">

            <div class="modal-header">
                <div class="modal-close close"><i class="icon-close"></i><span>Close</span></div>
            </div>

            <div class="modal-body">
                <div class="welcome-tour">
                    <header class="rs_read_this">
                        <h1>
                            <sc:FieldRenderer ID="frHeader" runat="server" FieldName="Heading" />
                        </h1>
                        <p class="subhead">
                            <sc:FieldRenderer ID="frSubHeader" runat="server" FieldName="Sub heading" />
                        </p>
                    </header>

                    <div class="welcome-tour-carousel">
                        <!-- BEGIN PARTIAL: community/welcome_carousel -->
                        <ul class="welcome-tour-navigation arrows-gray">
                            <li class="header paging-data">See All</li>
                            <li class="rsArrow rsArrowLeft">
                                <button class="rsArrowIcn"></button>
                            </li>
                            <li class="rsArrow rsArrowRight">
                                <button class="rsArrowIcn"></button>
                            </li>
                        </ul>

                        <div id="welcome-slides-container" class="arrows-gray slides clearfix">
                            <asp:Repeater runat="server" ID="rptWelcomeSlider" OnItemDataBound="rptWelcomeSlider_ItemDataBound">
                                 <ItemTemplate>
                            <div class="slide rs_read_this">
                                    <sc:Image ID="scBackgroundImage" runat="server" Parameters="class=welcome-tour-image rsImg" Field="Background Image" />
                                    <sc:FieldRenderer ID="frContent" runat="server" FieldName="Detail" />
                                <div class="buttons rs_skip">
                                    <sc:Link ID="scLinkJoin" Parameters="class=button" runat="server" Field="Join The Community Button"></sc:Link>
                                    <sc:Link ID="scLinkNotNow" Parameters="class=button gray close" runat="server" Field="Not Now"></sc:Link>
                                </div>
                            </div></ItemTemplate>
                               </asp:Repeater>
                        </div>
                        <!-- #welcome-slides-container-->
                        <!-- END PARTIAL: community/welcome_carousel -->
                    </div>
                    <!-- .welcome-tour-carousel -->
                </div>
            </div>

        </div>
        <!-- .modal-content -->
    </div>
    <!-- .modal-dialog -->
</div>
<!-- modal -->
