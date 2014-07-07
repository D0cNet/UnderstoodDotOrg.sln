<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogParentsAreTalkingWidget.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.BlogParentsAreTalkingWidget" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="blog-parents-talking">
    <h3><sc:Text Field="Parents Are Talking Text" runat="server" /></h3>
    <h4 class="first"><a id="linkTitle" runat="server"><asp:Literal ID="litTitle" runat="server" /></a></h4>
    <div class="blog-comment-snippet-box">
        <p class="blog-snippet"><asp:Literal ID="litCommentSnippet" runat="server" /></p>
        <a id="linkReadMore" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.ReadMoreLabel %></a>
    </div>
    <p class="blog-comment-author"><asp:Literal ID="litAuthor" runat="server" /></p>
    <p class="blog-comment-timelapsed"><asp:Literal ID="litDateTime" runat="server" /></p>
</div>