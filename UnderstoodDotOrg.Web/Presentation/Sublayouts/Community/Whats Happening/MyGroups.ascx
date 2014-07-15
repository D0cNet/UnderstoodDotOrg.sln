<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyGroups.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.MyGroups" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/GroupJoinButton.ascx" TagPrefix="uc1" TagName="GroupJoinButton" %>

<div class="community-my-groups">
    <div class="row">
        <div class="col col-24 community-my-groups-wrapper skiplink-content" aria-role="main">
            <h2 class="rs_read_this">
                <asp:Literal ID="litMyGroupsLabel" runat="server" /></h2>
            <asp:HyperLink CssClass="button-view-all" ID="hrefSeeAllGroup" runat="server" >
            
                <asp:Literal ID="litSeeAllGroups" runat="server" />
                </asp:HyperLink>
            <div class="row group-cards">
                <!-- BEGIN PARTIAL: community/my_group_card -->
                <asp:Repeater ID="rptMyGroups" runat="server">
                    <ItemTemplate>
                        <div class="col col-24 group-card rs_read_this">
                    <div class="group-card-image">
                        <a href="REPLACE">
                            <img alt="190x107 Placeholder" src="http://placehold.it/190x107" />
                        </a>
                    </div><!-- end .group-card-image -->
                    <div class="group-card-info group">
                        <div class="group-card-title">
                            <asp:HyperLink  ID="hrefGroupTitleUrl" CssClass="group-card-name" runat="server" >
                                <%# Eval("Title") %>
                            </asp:HyperLink>
                        </div>
                        <div class="group-card-excerpt">
                            <asp:HyperLink  ID="hrefDiscussionLink" runat="server" >
                                <asp:Literal ID="litDiscussionExcerpt" runat="server" />
                            </asp:HyperLink>
                            
                        </div>
                        <div class="group-card-replies">
                            <div class="replies"><span class="reply-count">
                                <asp:Literal ID="litNumReplies" runat="server" /></span> <asp:Literal ID="litRepliesLabel" runat="server" /></div>
                        </div>
                        <div class="group-card-post-info">
                            <asp:Literal ID="litPostedByLabel" runat="server" /> <asp:HyperLink ID="hrefPostUser" runat="server" >
                                <asp:Literal ID="litPostUserName" runat="server" /></asp:HyperLink> <span class="bullet">&bull;</span> <asp:Literal ID="litPostTime" runat="server" />
                        </div>
                        <div class="card-buttons rs_skip">
                           <%-- <button type="button" class="button rs_skip">
                                <asp:Literal ID="litViewDiscussionLabel" runat="server" /></button>--%>
                            <uc1:GroupJoinButton runat="server" ID="btnJoin" />
                        </div><!-- end .card-buttons -->
                    </div><!-- end .group-card-info -->
                </div>
                    </ItemTemplate>
                </asp:Repeater>
                
                <!-- end .group-card -->
                <!-- END PARTIAL: community/my_group_card -->
                <!-- BEGIN PARTIAL: community/my_group_card -->
              <%--  <div class="col col-24 group-card rs_read_this">
                    <div class="group-card-image">
                        <a href="REPLACE">
                            <img alt="190x107 Placeholder" src="http://placehold.it/190x107" />
                        </a>
                    </div><!-- end .group-card-image -->
                    <div class="group-card-info group">
                        <div class="group-card-title">
                            <a href="REPLACE" class="group-card-name">Animi Eligendi Iste Odio Aperiam Unde</a>
                        </div>
                        <div class="group-card-excerpt">
                            <a href="REPLACE">Accusamus occaecati illum vel voluptas. Consequatur ea et fugiat culpa aperiam expedita vero ipsam. Et quam est et amet esse perferendis</a>
                        </div>
                        <div class="group-card-replies">
                            <div class="replies"><span class="reply-count">39</span> replies</div>
                        </div>
                        <div class="group-card-post-info">
                            Posted by <a href="REPLACE">Dwayne116</a> <span class="bullet">&bull;</span> 1 hour ago
                        </div>
                        <div class="card-buttons rs_skip">
                            <button type="button" class="button rs_skip">View Discussions</button>
                        </div><!-- end .card-buttons -->
                    </div><!-- end .group-card-info -->
                </div>--%>
                <!-- end .group-card -->
                <!-- END PARTIAL: community/my_group_card -->
            </div><!-- end .group-cards -->
        </div><!-- end .col.col-24.container -->
    </div><!-- end .row -->
</div><!-- end .community-groups -->
 