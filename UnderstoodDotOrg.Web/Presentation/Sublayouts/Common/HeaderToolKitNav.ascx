<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderToolKitNav.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.HeaderToolKitNav" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- toolkit header row -->
<div class="row toolkit-row">
    <div class="col col-24">
        <!-- BEGIN PARTIAL: toolkit-header -->
        <div class="parent-toolkit-wrapper">
            <div class="parent-toolkit-header-container arrows-gray">

                <h2>Your Parent Toolkit</h2>

                <span class="button-close"><i class="icon-close-toolkit"></i><%= UnderstoodDotOrg.Common.DictionaryConstants.CloseButtonText %></span>

                <asp:ListView ID="lvParentToolkit" runat="server" GroupItemCount="3">
                    <LayoutTemplate>
                        <div class="slides-container">
                            <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
                        </div>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <div class="slide">
                            <ul>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </ul>
                        </div>
                    </GroupTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:Panel runat="server" ID="pnlParentToolKit" CssClass="icon">
                                <sc:FieldRenderer ID="frNavLink" runat="server" FieldName="Link" Parameters="class=toolkit-element" />
                                <%--<div class="coming-soon">Coming Soon</div>--%>
                            </asp:Panel>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <!-- .parent-toolkit-header-container -->
        </div>
        <!-- #parent-toolkit-wrapper -->
        <!-- END PARTIAL: toolkit-header -->
    </div>
</div>
