<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Group Board.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Group_Board" %>

<div class="container">
    <div class="row">
        <div class="container">
            <header class="groups-heading rs_read_this">
                <!-- BEGIN PARTIAL: community/breadcrumb_menu -->
                <!--breadcrumb menu-->
                <a href="REPLACE" runat="server" id="hrfBack" class="back-to-previous rs_skip">
                        <i class="icon-arrow-left-blue"></i>
                        <asp:Literal ID="litBack" Text="" runat="server" />
                    </a>
                <!-- END PARTIAL: community/breadcrumb_menu -->
                <div class="col col-24 title">
                    <h2>
                        <asp:Literal Text="" ID="litForumName" runat="server" /></h2>
                </div>
                <!-- BEGIN PARTIAL: community/groups_private_heading -->
                <!--groups private partial-->
                <div class="col groups-private">
                    <p class="col"><%= UnderstoodDotOrg.Common.DictionaryConstants.OnlyMembersCanSeeLabel %></p>
                    <i class="icon"></i>
                </div>
                <!-- END PARTIAL: community/groups_private_heading -->
            </header>

            <!-- BEGIN PARTIAL: community/groups_start_discussion -->
            <!--discussion board-->

            <div class="col col-24 search-board">
                <div class="rs_read_this discussion-board-rs-wrapper">
                    <div class="col-16 discussion-boards mobile-group-search-form offset-1 skiplink-toolbar">
                        <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.SearchThisBoardLabel %></h3>


                        <!-- BEGIN PARTIAL: community/groups_search_form -->
                        <!--groups search form-->
                        <asp:Panel runat="server" DefaultButton="btnSearch">
                            <fieldset class="group-search-form mobile-group-search-form">
                                <label for="group-search-text" class="visuallyhidden" aria-hidden="true"><%= UnderstoodDotOrg.Common.DictionaryConstants.SearchLabel %></label>
                                <asp:TextBox ID="txtSearch" CssClass="group-search" runat="server" placeholder="Enter conversation" />
                                <asp:Button type="submit" CssClass="group-search-button" ID="btnSearch" OnClick="btnSearch_Click" runat="server" />
                            </fieldset>
                        </asp:Panel>
                        <!-- END PARTIAL: community/groups_search_form -->




                    </div>
                    <!-- end .discussion-boards -->
                   <%-- <div class="col-6 start-discussion">
                        <p>Got a question?</p>
                        <p class="want-to-talk">Want to talk?</p>
                        <a href="#" class="button">Start a Discussion</a>
                    </div>--%>
                    <!-- end .start-discussion -->
                     <sc:Sublayout ID="sblStartDiscussion" Path="~/Presentation/Sublayouts/Common/Start A Discussion.ascx" runat="server" />
                </div>
            </div>
            <!-- end .discussion-board -->
            <!-- END PARTIAL: community/groups_start_discussion -->

           

            <div class="col col-23 individual-group skiplink-content" aria-role="main">
                <!-- BEGIN PARTIAL: community/groups_table -->
                <div class="discussion-box col col-23 offset-1">
                          <header class="rs_skip">

    

    
                    <h4 class="col summary"><%= UnderstoodDotOrg.Common.DictionaryConstants.DiscussionLabel %></h4>
                    <h4 class="col started-by"><%= UnderstoodDotOrg.Common.DictionaryConstants.StartedByLabel %></h4>
                    <h4 class="col replies"><%= UnderstoodDotOrg.Common.DictionaryConstants.RepliesLabel %></h4>
                    <h4 class="col latest-post-tabular"><%= UnderstoodDotOrg.Common.DictionaryConstants.LatestPostLabel %></h4>
    

                  </header>
                    <asp:UpdatePanel ID="upThread" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="linkShowMore" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Repeater ID="rptThread" OnItemDataBound="rptThread_ItemDataBound" runat="server">
                                <HeaderTemplate>
                                    <ul class="discussions table-discussions search-results rs_read_this">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div class="col summary">
                                            <asp:HiddenField Value='<%# Eval("Subject") %>' runat="server" ID="hdSubject" />
                                            <h4><%= UnderstoodDotOrg.Common.DictionaryConstants.DiscussionLabel %>:</h4>
                                            <a href="REPLACE" id="hrefDiscussion" runat="server"><%# Eval("Snippet") %></a>
                                        </div>
                                        <div class="col latest-post rs_skip">
                                            <h4><%= UnderstoodDotOrg.Common.DictionaryConstants.LatestPostLabel %>:</h4>
                                            <p class="mins-ago"><%# Eval("LastPostTime") %></p>
                                            <a runat="server" id="hrefProfile2" href="REPLACE"><%# Eval("LastPostUser") %></a>
                                            <p><%# Eval("LastPostBody") %></p>
                                        </div>
                                        <div class="col started-by">
                                            <h4><%= UnderstoodDotOrg.Common.DictionaryConstants.StartedByLabel %>:</h4>
                                            <a runat="server" id="hrefProfile" href="REPLACE"><%# Eval("StartedBy") %></a>
                                        </div>

                                        <div class="col replies">
                                            <h4><%= UnderstoodDotOrg.Common.DictionaryConstants.RepliesLabel %>:</h4>
                                            <p><%# Eval("ReplyCount") %></p>
                                        </div>
                                        <div class="col latest-post-tabular">
                                            <h4><%= UnderstoodDotOrg.Common.DictionaryConstants.LatestPostLabel %>:</h4>
                                            <p><%# Eval("LastPostTime") %></p>
                                            <a runat="server" id="hrefProfile3" href="REPLACE"><%# Eval("LastPostUser") %></a>
                                            <p><%# Eval("LastPostBody") %></p>
                                        </div>

                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- end .discussions -->
                </div>
                <!-- END PARTIAL: community/groups_table -->
            </div>
            <!-- end .individual-group -->
        </div>
    </div>
</div>
<div class="container show-more rs_skip">
    <div class="row">
        <div class="col col-24">
            <asp:LinkButton runat="server" id="linkShowMore" OnClick="linkShowMore_ServerClick" ><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreLabel %><i class="icon-arrow-down-blue"></i></asp:LinkButton>
        </div>
    </div>
</div>
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.8;">
            <span style="border-width: 0px; position: fixed; padding: 50px; background-color: #FFFFFF; font-size: 36px; left: 40%; top: 40%;">Loading...</span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

<!-- END PARTIAL: community/main_header -->
