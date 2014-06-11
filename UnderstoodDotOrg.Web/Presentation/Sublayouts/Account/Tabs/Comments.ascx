<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Tabs.Comments" %>

<div class="container flush friends-view-tabs-page-header">&nbsp;</div>

<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-24 offset-1">
            <div class="tab-container friends-view-tabs friends-activity skiplink-content" aria-role="main">
                <!-- BEGIN PARTIAL: friends-view-tabs -->
                <ul class="etabs">
                    <li class="tab profile-tab "><asp:HyperLink ID="hypProfileTab" runat="server">Profile</asp:HyperLink></li>
                    <li class="tab connections-tab "><asp:HyperLink ID="hypConnectionsTab" runat="server">Connections</asp:HyperLink></li>
                    <li class="tab comments-tab active"><asp:HyperLink ID="hypCommentsTab" runat="server">Comments <span class="comment-number">
                        <asp:Literal ID="litCommentsCount" runat="server"></asp:Literal></span></asp:HyperLink></li>
                </ul>
                <div class="friends-view-tabs-select select-inverted-mobile">
                    <div class="etabs-dropdown">
                        <select class="">
                            <option value="profile">Profile</option>
                            <option value="connections">Connections</option>
                            <option value="comments">Comments</option>
                        </select>
                    </div>
                </div>
                <!-- END PARTIAL: friends-view-tabs -->
                <div class="panel-container comments-panel profile-friend-activity-list">
                    <!-- BEGIN PARTIAL: friends-view-tabs-3 -->
                    <asp:Repeater ID="rptComments" OnItemDataBound="rptComments_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <div class="row repeater-item">
                                <div class="col col-6 comments-col-left" id="divUserInfo" runat="server" visible="false">
                                    <h3>
                                        <asp:Literal ID="litUserName" runat="server"></asp:Literal></h3>
                                    <p>Last updated:</p>
                                    <p><asp:Literal ID="litLastUpdated" runat="server">4:35PM EST on Dec 24 2014</asp:Literal>:</p>
                                </div>
                                <div class="col col-18 comments-col-right" id="divComment" runat="server">
                                    <div class="rs_read_this friends-view-rs-wrapper friends-view-three-rs-wrapper">
                                        <h5>
                                            <asp:HyperLink ID="hypTitle" runat="server">Ritalin Side Effects: What You Should Know</asp:HyperLink>
                                        </h5>
                                        <p>
                                            <asp:Literal ID="litCommentBody" runat="server"></asp:Literal>&hellip;</p>
                                        <footer><asp:Literal ID="litTime" runat="server">30 min ago</asp:Literal>
                                            <button><asp:Literal ID="litLikes" runat="server"></asp:Literal><span class="visuallyhidden">likes</span></button></footer>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!-- END PARTIAL: friends-view-tabs-3 -->
                </div>
                <!-- end .comments-panel -->
                <div class="showmore-footer">
                    <!-- Show More -->
                    <!-- BEGIN PARTIAL: community/show_more -->
                    <!--Show More-->
                    <div class="container show-more rs_skip">
                        <div class="row">
                            <div class="col col-24">
                                <a class="show-more-link show_more" href="#" data-path="my-account/profile.friend.activity" data-container="profile-friend-activity-list" data-item="profile-friend-activity-item" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
                            </div>
                        </div>
                    </div>
                    <!-- .show-more -->
                    <!-- END PARTIAL: community/show_more -->
                    <!-- .show-more -->
                </div>
            </div>
            <!-- end .tab-container.friends-view-tabs -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
