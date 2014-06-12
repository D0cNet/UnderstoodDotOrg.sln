<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssistiveTechResults.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.AssistiveTechResults" %>


<asp:Repeater ID="rptrResults" runat="server" 
    ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.AssistiveToolsReviewPageItem">
    <ItemTemplate>
        <sc:Sublayout runat="server" DataSource="<%# Item.ID.ToString() %>" Path="~/Presentation/Sublayouts/Tools/AssistiveTools/AssistiveToolsResultListing.ascx" />
    </ItemTemplate>
</asp:Repeater>