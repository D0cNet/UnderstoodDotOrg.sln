<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MiniBehaviorTool.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Tiles.MiniBehaviorTool" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="rs_read_this more-to-explore-tools">
    <sc:Sublayout runat="server" ID="slHeader" Path="~/Presentation/Sublayouts/Common/Tiles/ToolTileHeader.ascx" />

    <div class="form select-container behavior-tool-widget">
        <fieldset>

            <asp:Label runat="server" AssociatedControlID="ddlChallenges" CssClass="visuallyhidden rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.SelectBehaviorLabel %></asp:Label>
            <asp:DropDownList ID="ddlChallenges" runat="server" />

            <asp:Label runat="server" AssociatedControlID="ddlGrades" CssClass="visuallyhidden rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.SelectGradeLabel %></asp:Label>
            <asp:DropDownList ID="ddlGrades" runat="server" />

        </fieldset>

        <div class="submit-button-wrap">
            <asp:Button ID="btnSubmit" CssClass="button" runat="server" />
        </div>
    </div>
</div>