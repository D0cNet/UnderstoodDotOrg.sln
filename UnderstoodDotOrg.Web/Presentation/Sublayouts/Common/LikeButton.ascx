<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LikeButton.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.LikeButton" %>


<button data-content-id="<%= ContentId %>" data-content-type-id="<%= ContentTypeId %>" data-endpoint="<%= ContentServicePath %>"   class="likes groups-discussion-like-button count-helped">
    <i class="thumbs-up-icon icon-comment-like"></i>
    <p><%= Text %></p>
    <span class="visuallyhidden">likes</span>
</button>
