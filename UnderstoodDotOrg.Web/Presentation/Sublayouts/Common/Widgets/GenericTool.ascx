<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenericTool.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Widgets.GenericTool" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


  <header>
    <h3><sc:FieldRenderer ID="frWidgetTitle" runat="server" FieldName="Widget Title" /></h3>
    <sc:FieldRenderer ID="frWidgetCopy" runat="server" FieldName="Widget Copy" />
  </header>

  <sc:FieldRenderer ID="frWidgetContent" runat="server" FieldName="Widget Body Content" />

   <div class="submit-button-wrap">
      <asp:Button ID="btnSubmit" runat="server" CssClass="button" />
   </div>
