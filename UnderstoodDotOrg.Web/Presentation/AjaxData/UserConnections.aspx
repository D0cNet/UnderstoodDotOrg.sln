<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserConnections.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.UserConnections" %>
<%@ Register TagPrefix="uc1" TagName="MemberProfileCard" Src="~/Presentation/Sublayouts/Common/Cards/MemberProfileCard.ascx" %>

<asp:Repeater id="rptConnections" 
    ItemType="UnderstoodDotOrg.Services.Models.Telligent.User"
    runat="server">
    <ItemTemplate>
        <uc1:MemberProfileCard ID="ucMemberProfileCard" runat="server" ProfileUser="<%# Item %>" ColumnCss="col-6" />
    </ItemTemplate>
</asp:Repeater>
<asp:Placeholder id="phMoreResults" runat="server" Visible="false"><input type="hidden" /></asp:Placeholder>
