<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentsSummary.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.CommentsSummary" %>
 <header>
    <h3>Comments <asp:Literal Text="" ID="litNumComments" runat="server" /></h3>
</header>
<div class="quote-container">
    <blockquote>
        <p>
            <asp:Literal Text="" ID="litCommentblurb" runat="server" /></p>
        <i class="arrow-quote-bottom"></i>
    </blockquote>
    <span><strong>
        <asp:Literal Text="" ID="litAuthorName" runat="server" /></strong> &bull; <asp:Literal Text="" ID="litTimeStamp" runat="server" /></span>
</div>

<ul>
    <li><a ID="hlAllComments" href="#comment-list" runat="server"></a> </li>
    <li>
        <a ID="hlAddMyComment" runat="server"></a></li>
</ul>