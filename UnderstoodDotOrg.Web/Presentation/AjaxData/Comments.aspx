<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.Comments" %>
<%@ Register TagPrefix="udo" TagName="Comments" Src="~/Presentation/Sublayouts/Common/Comments/Entries.ascx" %>

<udo:Comments runat="server" ID="commentsControl" />
<asp:Placeholder id="phMoreResults" runat="server" Visible="false"><input type="hidden" /></asp:Placeholder>