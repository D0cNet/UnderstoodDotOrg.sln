<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoundHelpfulAndCommentCounts.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.FoundHelpfulAndCommentCounts" %>

<!-- END PARTIAL: pagetopic -->
<div class="count-mobile rs_read_this">
    <!-- BEGIN PARTIAL: helpful-count -->

    <div class="count-helpful">
        <a href="#count-helpful-content">
            <asp:Label ID="lblHelpfulCountMobile" runat="server"></asp:Label><asp:Literal ID="ltlFoundThisHelpfulMobile" runat="server"></asp:Literal></a>
    </div>
    <!-- END PARTIAL: helpful-count -->
    <!-- BEGIN PARTIAL: comments-count -->
    <div class="count-comments">
        <a href="#count-comments">
            <asp:Label ID="lblCommentCountMobile" runat="server"></asp:Label><asp:Literal ID="ltlCommentsMobile" runat="server"></asp:Literal></a>
    </div>
    <!-- END PARTIAL: comments-count -->
</div>
<div class="container article-intro">
    <div class="row">
        <!-- helpful count -->
        <div class="col col-10 article-intro-count multiple">
            <!-- BEGIN PARTIAL: helpful-count -->

            <div class="count-helpful">
                <a href="#count-helpful-content">
                    <asp:Label ID="lblHelpfulCount" runat="server"></asp:Label><asp:Literal ID="ltlFoundThisHelpful" runat="server"></asp:Literal></a>
            </div>
            <!-- END PARTIAL: helpful-count -->
            <!-- BEGIN PARTIAL: comments-count -->
            <div class="count-comments">
                <a href="#count-comments">
                    <asp:Label ID="lblCommentCount" runat="server"></asp:Label><asp:Literal ID="ltlComments" runat="server"></asp:Literal></a>
            </div>
            <!-- END PARTIAL: comments-count -->
        </div>

        <!-- intro-text -->
        <div class="col col-13 offset-1 article-intro-text-wrapper rs_read_this">
            <!-- BEGIN PARTIAL: article-intro-text -->
            <div class="article-intro-text" id="dvIntro" runat="server">
                <sc:fieldrenderer fieldname="Page Summary" runat="server"></sc:fieldrenderer>
            </div>
            <!-- END PARTIAL: article-intro-text -->
        </div>

    </div>
    <!-- .row -->
</div>
<!-- .container -->