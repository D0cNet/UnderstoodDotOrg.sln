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

<div class="find-this-helpful sidebar rs_read_thi" id="count-helpful-sidebar">
    <h4>Did you find this helpful?</h4>
    <asp:LinkButton ID="btnLike" OnClick="btnThisHelped_Click" CssClass="button yes rs_skip" runat="server">Yes</asp:LinkButton>
    <asp:LinkButton ID="btnUnlike" OnClick="btnDidntHelp_Click" CssClass="button no gray rs_skip" runat="server">No</asp:LinkButton>
</div>