<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubtopicArticles.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.SubtopicArticles" %>
<%@ Register TagPrefix="udo" TagName="ArticleListing" Src="~/Presentation/Sublayouts/Common/ArticleListings/SubtopicLandingArticles.ascx" %>

<udo:ArticleListing ID="articleListing" runat="server" />
<asp:Placeholder id="phMoreResults" runat="server" Visible="false"><input type="hidden" /></asp:Placeholder>