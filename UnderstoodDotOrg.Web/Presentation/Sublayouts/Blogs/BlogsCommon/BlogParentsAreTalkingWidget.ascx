<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogParentsAreTalkingWidget.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.BlogParentsAreTalkingWidget" %>
<div class="blog-parents-talking">
    <h3>Parents Are Talking About</h3>
    <h4 class="first"><a href="REPLACE"><asp:Literal ID="litTitle" runat="server" /></a></h4>
    <div class="blog-comment-snippet-box">
        <p class="blog-snippet"><asp:Literal ID="litCommentSnippet" runat="server" /></p>
        <a href="REPLACE">Read more</a>
    </div>
    <p class="blog-comment-author"><asp:Literal ID="litAuthor" runat="server" /></p>
    <p class="blog-comment-timelapsed"><asp:Literal ID="litDateTime" runat="server" /></p>
</div>