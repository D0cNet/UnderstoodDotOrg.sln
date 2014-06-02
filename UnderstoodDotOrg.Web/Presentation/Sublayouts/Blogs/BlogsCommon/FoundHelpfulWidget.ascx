<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoundHelpfulWidget.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.FoundHelpfulWidget" %>
<!-- BEGIN PARTIAL: helpful-count -->
<div class="post-meta">
    <div class="count-helpful">
        <a href="#count-helpful-content"><asp:Label ID="LikeCount" runat="server" />Found this helpful</a>
    </div>
    <!-- END PARTIAL: helpful-count -->
    <div class="replies">
        <!-- BEGIN PARTIAL: comments-count -->
        <div class="count-comments">
            <a href="#count-comments"><asp:Label ID="CommentCount" runat="server" />Comments</a>
        </div>
        <!-- END PARTIAL: comments-count -->
    </div>
</div>

<div class="was-this-helpful" id="count-helpful">
    <h5>Did you find this helpful?</h5>
    <asp:LinkButton ID="btnLike" OnClick="btnThisHelped_Click" CssClass="button yes" runat="server">Yes</asp:LinkButton>
    <asp:LinkButton ID="btnUnlike" OnClick="btnDidntHelp_Click" CssClass="button gray no" runat="server">No</asp:LinkButton>
</div>