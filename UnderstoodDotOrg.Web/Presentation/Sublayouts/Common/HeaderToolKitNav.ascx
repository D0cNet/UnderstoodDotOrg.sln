<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderToolKitNav.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.HeaderToolKitNav" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- toolkit header row -->
<div class="row toolkit-row">
    <div class="col col-24">
        <!-- BEGIN PARTIAL: toolkit-header -->
        <div class="parent-toolkit-wrapper">
            <div class="parent-toolkit-header-container arrows-gray">

                <h2>Your Parent Toolkit</h2>

                <span class="button-close"><i class="icon-close-toolkit"></i>Close</span>
                <asp:Repeater runat="server" ID="rptParentToolkit" OnItemDataBound="rptParentToolkit_ItemDataBound">
                    <HeaderTemplate>
                        <div class="slides-container">
                            <div class="slide">
                                <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:Panel runat="server" ID="pnlParentToolKit" CssClass="icon">
                                <sc:FieldRenderer ID="frNavLink" runat="server" FieldName="Link" />
                                <%--<div class="coming-soon">Coming Soon</div>--%>
                            </asp:Panel>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                            </div>
                            </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <!-- .parent-toolkit-header-container -->
        </div>
        <!-- #parent-toolkit-wrapper -->
        <!-- END PARTIAL: toolkit-header -->
    </div>
</div>
