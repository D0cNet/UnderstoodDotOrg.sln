<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveTool.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Widgets.AssistiveTool" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

 <header>
    <h3><sc:FieldRenderer ID="frWidgetTitle" runat="server" FieldName="Widget Title" /></h3>
    <sc:FieldRenderer ID="frWidgetCopy" runat="server" FieldName="Widget Copy" />
  </header>

  <div class="form select-container">

    <fieldset>

        <asp:Label runat="server" AssociatedControlID="ddlIssues" CssClass="visuallyhidden rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.SelectBehaviorLabel %></asp:Label>
        <asp:DropDownList ID="ddlIssues" runat="server" CssClass="issue-select" />

        <asp:Label  runat="server" AssociatedControlID="ddlGrades" CssClass="visuallyhidden rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.SelectGradeLabel %></asp:Label>
        <asp:DropDownList ID="ddlGrades" runat="server"  CssClass="grade-select" />

        <asp:Label runat="server" AssociatedControlID="ddlTechTypes" CssClass="visuallyhidden rs_skip"></asp:Label>
        <asp:DropDownList ID="ddlTechTypes" runat="server" CssClass="tech-type-select" />

        <input type="hidden" id="hfSelectedPlatform" class="hfSelectedPlatform" runat="server" />
        <asp:Repeater ID="rptrDynPlatformDropdowns" runat="server">
            <ItemTemplate>
                <select data-type-id="<%# Eval("TypeId") %>" class="platform-select" style="display:none;">
                    <option value="">Select Platform</option>
                    <asp:Repeater ID="rptrPlatformOptions" runat="server" 
                        ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData.AssistiveToolsPlatformItem">
                        <ItemTemplate>
                            <option value="<%# Item.ID.ToString() %>"><%# Item.Metadata.ContentTitle %></option>
                        </ItemTemplate>
                    </asp:Repeater>
                </select>
            </ItemTemplate>
        </asp:Repeater>

    </fieldset>

    <div class="submit-button-wrap">
      <asp:Button runat="server" ID="btnSubmit" CssClass="button" />
    </div>

  </div><!-- .form -->

  <footer class="powered-by">
    <h5><sc:FieldRenderer ID="frWidgetFooterHeading" runat="server" FieldName="Widget Footer Heading" /></h5>
    <div class="logo">
      <asp:Image runat="server" ID="imgFooterLogo" CssClass="logo-img" />
    </div>
  </footer>