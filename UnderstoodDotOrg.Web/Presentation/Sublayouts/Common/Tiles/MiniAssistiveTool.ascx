<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MiniAssistiveTool.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Tiles.MiniAssistiveTool" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="rs_read_this more-to-explore-tools">
    <sc:Sublayout runat="server" ID="slHeader" Path="~/Presentation/Sublayouts/Common/Tiles/ToolTileHeader.ascx" />

    <div class="form select-container">
        <fieldset>
            <asp:Label AssociatedControlID="ddlIssues" CssClass="visuallyhidden rs_skip" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.SelectBehaviorLabel %></asp:Label>
            <asp:DropDownList ID="ddlIssues" runat="server" />

            <asp:Label AssociatedControlID="ddlGrades" CssClass="visuallyhidden rs_skip" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.SelectGradeLabel %></asp:Label>
            <asp:DropDownList ID="ddlGrades" runat="server" />

            <asp:Label AssociatedControlID="ddlTechTypes" CssClass="visuallyhidden rs_skip" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.AllTechnologyLabel %></asp:Label>
            <asp:DropDownList ID="ddlTechTypes" runat="server" />

            <div class="rs_skip">
                <asp:Label CssClass="visuallyhidden rs_skip" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.AllPlatformsLabel %></asp:Label>
                <input type="hidden" id="hfSelectedPlatform" class="hfSelectedPlatform" runat="server" />
                <asp:Repeater ID="rptrDynPlatformDropdowns" runat="server">
                    <ItemTemplate>
                        <select data-type-id="<%# Eval("TypeId") %>" class="platform-select" style="display:none;">
                            <option value=""><%= UnderstoodDotOrg.Common.DictionaryConstants.AllPlatformsLabel %></option>
                            <asp:Repeater ID="rptrPlatformOptions" runat="server" 
                                ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData.AssistiveToolsPlatformItem">
                                <ItemTemplate>
                                    <option value="<%# Item.ID.ToString() %>"><%# Item.Metadata.ContentTitle %></option>
                                </ItemTemplate>
                            </asp:Repeater>
                        </select>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </fieldset>

        <div class="submit-button-wrap">
            <asp:Button ID="btnSubmit" CssClass="button" runat="server" />
        </div>
    </div>
</div>