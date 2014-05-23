<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopicLandingArticles.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.TopicLandingArticles" %>
<%@ Register TagPrefix="udo" TagName="ArticleListing" Src="~/Presentation/Sublayouts/Common/ArticleListings/TopicLandingArticles.ascx" %>

<udo:ArticleListing ID="articleListing" runat="server" />
<asp:HiddenField id="hfMoreResults" runat="server" Visible="false" />      