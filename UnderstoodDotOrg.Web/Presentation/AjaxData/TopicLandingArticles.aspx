<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopicLandingArticles.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.TopicLandingArticles" %>
<%@ Register TagPrefix="udo" TagName="ArticleListing" Src="~/Presentation/Sublayouts/Common/ArticleListings/TopicLandingArticles.ascx" %>

<udo:ArticleListing ID="articleListing" runat="server" />
<asp:Placeholder id="phMoreResults" runat="server" Visible="false"><input type="hidden" /></asp:Placeholder>    