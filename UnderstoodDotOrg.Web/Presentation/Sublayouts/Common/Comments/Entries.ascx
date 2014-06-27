<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Entries.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Comments.Entries" %>
<asp:Repeater runat="server" ID=rptComments ItemType="UnderstoodDotOrg.Services.Models.Telligent.Comment">
    <ItemTemplate>
        <div class="comment-wrapper" data-comment-id="<%# Item.CommentId %>">
            <div class="comment-header">
                <span class="comment-avatar">
                    <img src="<%# Item.AuthorAvatarUrl %>" width="60" height="60" />
                </span>
                <span class="comment-info">
                    <span class="comment-username"><%# Item.AuthorUsername %></span>
                    <span class="comment-date"><%# Item.PublishedDate %></span>
                </span>
                <a class="comment-like"><i class="icon-comment-like"></i><span class="comment-like-count"><%# Item.Likes %></span> <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.LikesLabel %></span></a>
            </div>
            <div class="comment-body">
                <%# Item.Body  %>
            </div>
            <div class="comment-actions rs_skip">
                <a href="#" class="comment-reply"><i class="icon-comment-reply"></i><%= UnderstoodDotOrg.Common.DictionaryConstants.ReplyLabel %></a>
                <a href="#" class="comment-like" data-content-type-id="<%# Item.CommentContentTypeId %>"><i class="icon-comment-like"></i><%= UnderstoodDotOrg.Common.DictionaryConstants.ThisHelpedLabel %></a>
                <a href="#" class="comment-flag"><i class="icon-comment-flag"></i><span class="comment-flag-label"><%= UnderstoodDotOrg.Common.DictionaryConstants.ReportAsInappropriateLabel %></span></a>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>