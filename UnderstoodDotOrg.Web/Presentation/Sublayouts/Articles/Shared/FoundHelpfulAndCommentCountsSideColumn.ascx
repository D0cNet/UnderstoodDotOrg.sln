<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoundHelpfulAndCommentCountsSideColumn.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.FoundHelpfulAndCommentCountsSideColumn" %>
<!-- END PARTIAL: pagetopic -->
<div class="count-mobile rs_read_this">
    <!-- BEGIN PARTIAL: helpful-count -->

    <div class="count-helpful">
        <a href="#count-helpful-content"><asp:Label ID="lblHelpfulCountMobile" runat="server"></asp:Label><asp:Literal ID="ltlFoundThisHelpfulMobile" runat="server"></asp:Literal></a>
    </div>
    <!-- END PARTIAL: helpful-count -->
    <!-- BEGIN PARTIAL: comments-count -->
    <div class="count-comments">
        <a href="#count-comments"><asp:Label ID="lblCommentCountMobile" runat="server"></asp:Label><asp:Literal ID="ltlCommentsMobile" runat="server"></asp:Literal></a>
    </div>
    <!-- END PARTIAL: comments-count -->
</div>

<!-- helpful count -->
<!-- BEGIN PARTIAL: helpful-count -->

<div class="count-helpful">
    <a href="#count-helpful-content"><asp:Label ID="lblHelpfulCount" runat="server"></asp:Label><asp:Literal ID="ltlFoundThisHelpful" runat="server"></asp:Literal></a>
</div>
<!-- END PARTIAL: helpful-count -->
<!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
    <a href="#count-comments"><asp:Label ID="lblCommentCount" runat="server"></asp:Label><asp:Literal ID="ltlComments" runat="server"></asp:Literal></a>
</div>
<!-- END PARTIAL: comments-count -->