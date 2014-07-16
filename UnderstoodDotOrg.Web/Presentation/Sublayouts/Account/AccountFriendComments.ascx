<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountFriendComments.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountFriendComments" %>
<%@ Register TagPrefix="uc1" TagName="CommentList" Src="~/Presentation/Sublayouts/Account/Common/CommentList.ascx" %>

<div id="profile-comment-activity" class="panel-container comments-panel profile-friend-activity-list">

    <uc1:CommentList runat="server" ID="ucCommentList" />
    
</div>
<!-- end .comments-panel -->

<asp:Panel ID="pnlShowMore" runat="server" Visible="false" CssClass="showmore-footer">
    <!-- Show More -->
    <!-- BEGIN PARTIAL: community/show_more -->
    <!--Show More-->
    <div class="container show-more rs_skip">
        <div class="row">
            <div class="col col-24">
                <a id="profile-comment-activity-show-more" href="#" data-path="<%= AjaxPath %>" data-container="profile-comment-activity" data-screenname="<%= ProfileMember.ScreenName %>" data-lang="<%= Sitecore.Context.Language.Name %>">Show More<i class="icon-arrow-down-blue"></i></a>
            </div>
        </div>
    </div>
    <!-- .show-more -->
    <!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->
</asp:Panel>