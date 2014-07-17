<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LikeButton.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.LikeButton" %>


<button data-content-id="<%= ContentId %>" data-content-type-id="<%= ContentTypeId %>" data-endpoint="<%= ContentServicePath %>"   class="likes groups-discussion-like-button">
    <i class="thumbs-up-icon"></i>
    <p><%= Text %></p>
</button>
