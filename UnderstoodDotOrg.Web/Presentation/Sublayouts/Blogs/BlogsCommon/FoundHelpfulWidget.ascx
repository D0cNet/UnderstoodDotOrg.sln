<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoundHelpfulWidget.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Widgets.FoundHelpfulWidget" %>
<!-- BEGIN PARTIAL: helpful-count -->
<div class="post-meta">
    <div class="count-helpful">
        <a href="#count-helpful-content"><asp:Label ID="LikeCount" runat="server" /><%= UnderstoodDotOrg.Common.DictionaryConstants.FoundThisHelpful %></a>
    </div>
    <!-- END PARTIAL: helpful-count -->
    <div class="replies">
        <!-- BEGIN PARTIAL: comments-count -->
        <div class="count-comments">
            <a href="#count-comments"><asp:Label ID="CommentCount" runat="server" /><%= UnderstoodDotOrg.Common.DictionaryConstants.CommentsLabel %></a>
        </div>
        <!-- END PARTIAL: comments-count -->
    </div>
</div>
<div class="find-this-helpful-large">
    <div class="find-this-helpful sidebar rs_skip" id="count-helpful-sidebar">
        <h4><%= UnderstoodDotOrg.Common.DictionaryConstants.DidYouFindThisHelpful %></h4>
        <asp:LinkButton ID="btnLike" OnClick="btnThisHelped_Click" CssClass="button yes rs_skip" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.YesButtonText %></asp:LinkButton>
        <asp:LinkButton ID="btnUnlike" OnClick="btnDidntHelp_Click" CssClass="button no gray rs_skip" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.NoButtonText %></asp:LinkButton>
    </div>
</div>