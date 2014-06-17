<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorTool.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Widgets.BehaviorTool" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

    <header>
      <h3><sc:FieldRenderer ID="frWidgetTitle" runat="server" FieldName="Widget Title" /></h3>
      <sc:FieldRenderer ID="frWidgetCopy" runat="server" FieldName="Widget Copy" />
    </header>

    <div class="form select-container">

      <fieldset>

        <asp:Label AssociatedControlID="ddlChallenges" runat="server" CssClass="visuallyhidden rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.SelectChallengeLabel %></asp:Label>
        <asp:DropDownList ID="ddlChallenges" runat="server" />

        <asp:Label AssociatedControlID="ddlGrades" runat="server" CssClass="visuallyhidden rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.SelectGradeLabel %></asp:Label>
        <asp:DropDownList ID="ddlGrades" runat="server" />

      </fieldset>

      <div class="submit-button-wrap">
          <asp:Button ID="btnSubmit" runat="server" CssClass="button" />
      </div>

    </div><!-- .form -->
