<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsRelatedArticles.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsRelatedArticles" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Repeater ID="rptLinks" runat="server">
<HeaderTemplate>
    <div class="col col-8 tool-related-articles-wrap behavior-tool-related-articles-large" style="height: 268px;">
        <!-- This is where behavior-tool-related-articles will move to in desktop (650px+) view-->
        <div class="behavior-tool-related-articles">
            <ul>
</HeaderTemplate>
<ItemTemplate>
    <li><sc:FieldRenderer ID="frLink" FieldName="Link" runat="server" /></li>
</ItemTemplate>
<FooterTemplate>
            </ul>
        </div>
    </div>
</FooterTemplate>
</asp:Repeater>