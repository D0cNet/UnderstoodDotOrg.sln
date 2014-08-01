<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Groups Search.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Groups_Search" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="community-page" class="parent-groups search">
    <div class="container">
        <!-- BEGIN PARTIAL: community/featured_group -->
        <!--featured group header -->
        <div class="row skiplink-feature">
            <header class="groups-heading">
                <div class="col col-24 rs_read_this">
                    <div class="col col-18 title">
                        <h2>
                            <asp:Literal runat="server" ID="litGroupName" /></h2>
                    </div>
                    <!-- BEGIN PARTIAL: community/groups_private_heading -->
                    <!--groups private partial-->
                    <div class="col groups-private">
                        <p class="col">Only members can see the conversations</p>
                        <i class="icon"></i>
                    </div>
                    <!-- END PARTIAL: community/groups_private_heading -->
                </div>
            </header>
            <!-- end .main-header -->
        </div>
        <div class="row">
            <div class="col col-24 featured-group group-summary clearfix rs_read_this">
                <div class="topic col col-17">
                    <div class="feature-image col col-4">
                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    </div>
                    <div class="description col col-17">
                        <p>
                            <asp:Literal runat="server" ID="litGroupDesc" /></p>
                        <p><span class="leader">Rerum</span>, Group Leader</p>
                    </div>
                </div>
                <div class="statistics col col-5">
                    <div class="meta">
                        <p class="members">
                            <asp:Literal runat="server" ID="litMemberCount" />
                            Members</p>
                        <p class="discussions">
                            <asp:Literal runat="server" ID="litDiscussionCount" />
                            Discussions</p>
                    </div>
                    <div class="mobile-search-box">
                        <h3>Find a conversation</h3>
                        <!-- BEGIN PARTIAL: community/groups_search_form -->
                        <!--groups search form-->
                        <asp:Panel runat="server" DefaultButton="btnSearch">
                            <fieldset class="group-search-form mobile-group-search-form">
                                <label for="group-search-text" class="visuallyhidden" aria-hidden="true">Search</label>
                                <asp:TextBox CssClass="group-search" ID="txtSearch" placeholder="Search" runat="server" />
                                <asp:Button CssClass="group-search-button" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />
                            </fieldset>
                        </asp:Panel>
                        <!-- END PARTIAL: community/groups_search_form -->
                    </div>
                </div>
                <!-- end .statistics -->
            </div>
            <!-- end .featured-group and .group-summary -->
        </div>
        <!-- END PARTIAL: community/featured_group -->
        <div class="row">
            <div class="col col-23 individual-group skiplink-content" aria-role="main">
                <header class="search-results  offset-1 rs_read_this">
                    <span class="results-for">
                        <asp:Literal runat="server" ID="litResultCount" />
                        Results for
                    <h3>"<asp:Literal runat="server" ID="litSearchItem" />"</h3>
                    </span>
                </header>
                <!-- end header -->
                <!-- BEGIN PARTIAL: community/groups_table -->
                <div class="discussion-box col col-23 offset-1">
                    <header class="rs_skip">
                        <h4 class="col summary">Discussion</h4>
                        <h4 class="col board">Board</h4>
                        <h4 class="col started-by">Started by</h4>
                        <h4 class="col replies">Replies</h4>
                        <h4 class="col latest-post-tabular">Latest Post</h4>
                    </header>
                    <asp:UpdatePanel runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnShowMore" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Repeater ID="rptResults" runat="server"
                                ItemType="UnderstoodDotOrg.Services.Models.Telligent.SearchResult"
                                OnItemDataBound="rptResults_ItemDataBound">
                                <HeaderTemplate>
                                    <ul class="discussions table-discussions search-results rs_read_this">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <!-- BEGIN PARTIAL: community/conversation_list_item -->
                                    <!--section.container.conversation-list-item-->
                                    <li>
                                        <div class="col summary">
                                            <h4>Discussion:</h4>
                                            <asp:Hyperlink ID="hypDiscussion" runat="server"><%# Item.BestMatchTitle %></asp:Hyperlink>
                                        </div>
                                        <div class="col latest-post rs_skip">
                                            <h4>Latest Post:</h4>
                                            <p class="mins-ago"><%# Item.Date %></p>
                                            <a href="REPLACE">At</a>
                                            <p><%# Item.BestMatchBody %></p>
                                        </div>
                                        <div class="col board">
                                            <h4>Board:</h4>
                                            <asp:Hyperlink ID="hypBoard" runat="server"><%# Item.Board %></asp:Hyperlink>
                                        </div>
                                        <div class="col started-by">
                                            <h4>Started by:</h4>
                                            <asp:Hyperlink runat="server" ID="hypStartedBy" ><asp:Literal ID="litStartedBy" runat="server" /></asp:Hyperlink>
                                        </div>

                                        <div class="col replies">
                                            <h4>Replies:</h4>
                                            <p><asp:Literal ID="litReplies" runat="server" /></p>
                                        </div>
                                        <div class="col latest-post-tabular">
                                            <h4>Latest Post:</h4>
                                            <p><%# Item.Date %></p>
                                            <a href="<%# Item.AuthorUrl %>"><%# Item.Author %></a>
                                            <p><%# Item.BestMatchBody %></p>
                                        </div>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- END PARTIAL: community/conversation_list_item -->
                    <!-- end .discussions -->
                </div>
                <!-- END PARTIAL: community/groups_table -->
            </div>
            <!-- end .individual-group -->
        </div>
    </div>
    <!-- .container -->

    <!-- Show More -->
    <!-- BEGIN PARTIAL: community/show_more -->
    <!--Show More-->
    <div class="container show-more rs_skip">
        <div class="row">
            <div class="col col-24">
                <asp:LinkButton ID="btnShowMore" runat="server" OnClick="btnShowMore_Click">Show More<i class="icon-arrow-down-blue"></i></asp:LinkButton>
            </div>
        </div>
    </div>
    <!-- .show-more -->
    <!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->
</div>
