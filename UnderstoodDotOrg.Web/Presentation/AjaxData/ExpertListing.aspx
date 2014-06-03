<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpertListing.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.ExpertListing" %>
<%@ Register TagPrefix="udo" TagName="ExpertListing" Src="~/Presentation/Sublayouts/About/ExpertListing.ascx" %>

<udo:ExpertListing ID="expertListing" runat="server" />
<asp:Placeholder id="phMoreResults" runat="server" Visible="false"><input type="hidden" /></asp:Placeholder>