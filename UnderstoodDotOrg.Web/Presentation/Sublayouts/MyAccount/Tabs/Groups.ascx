<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Groups.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs.Groups" %>
<div class="container my-account-subheader groups-subheader">
    <div class="row">
        <!-- subheader -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: my-groups-subheader -->
            <div class="row">
                <!-- subheader -->
                <div class="col col-8">
                    <h2 class="rs_read_this">My Groups</h2>
                </div>
                <div class="col col-16">
                    <div class="row">

                        <div class="col push-5 offset-1 my-groups-dropdown-label">
                            <label for="subheadergroups">
                                <span>My Groups:</span>
                            </label>
                        </div>
                        <div class="col push-5">
                            <div class="select-container filter-group">
                                <fieldset>
                                   <asp:DropDownList name="my-groups-dropdown" ID="ddlGroups" runat="server" OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged" AutoPostBack="true">
                                   </asp:DropDownList>
                                </fieldset>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <!-- END PARTIAL: my-groups-subheader -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container groups-discussion">
    <div class="row">
        <div class="col col-22 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: account-mygroups -->
            <section class="account-mygroups rs_read_this">
                <div class="row mygroups-header-wrap">
                    <div class="col col-12">
                        <header>
                            <h2>Recent Discussions in Parents of Kids with Attention Issues</h2>
                        </header>
                    </div>
                    <div class="col col-6 offset-6">
                        <a href="REPLACE" class="button start-discussion rs_skip">Start a Discussion</a>
                    </div>
                </div>

                <div class="row mygroup-grid-header clearfix">
                    <h3 class="col col-15">Discussions</h3>
                    <h3 class="col col-3 offset-1">Replies</h3>
                    <h3 class="col col-4 offset-1">Latest Post</h3>
                </div>

                <div class="row mygroup-list clearfix">
                    <asp:Repeater ID="rptComments" runat="server" OnItemDataBound="rptComments_ItemDataBound">
                        <ItemTemplate>
                            <div class="row mygroup-item clearfix">
                                <p class="col col-15 mygroup-title">
                                    <asp:HyperLink ID="hypCommentLink" runat="server"></asp:HyperLink>
                                </p>
                                <div class="col col-3 offset-1 reply-count-wrapper">
                                    <span class="reply-count">
                                        <asp:Literal ID="litRepliesCount" runat="server"></asp:Literal>
                                    </span> <span class="reply-label">Replies</span>
                                </div>
                                <div class="col col-4 offset-1">
                                    <p class="timestamp">
                                        <span class="lastest-post">Latest post </span>
                                        <asp:Literal ID="litCommentTime" runat="server"></asp:Literal>
                                    </p>
                                    <p class="posted-by-name">
                                        <asp:HyperLink ID="hypCommentAuthor" runat="server">Vance Floyd</asp:HyperLink>
                                    </p>
                                </div>
                            </div>
                            <!-- .mygroup-item -->
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                <!-- .mygroup-list -->

                <div class="showmore-footer">
                    <!-- Show More -->
                    <!-- BEGIN PARTIAL: community/show_more -->
                    <!--Show More-->
                    <div class="container show-more rs_skip">
                        <div class="row">
                            <div class="col col-24">
                                <a class="show-more-link show_more" href="#" data-path="my-account/my-groups" data-container="mygroup-list" data-item="mygroup-item" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
                            </div>
                        </div>
                    </div>
                    <!-- .show-more -->
                    <!-- END PARTIAL: community/show_more -->
                    <!-- .show-more -->
                </div>

            </section>
            <!-- .account-mygroups container -->

            <!-- END PARTIAL: account-mygroups -->
        </div>
    </div>
    <!-- .row -->
    <div class="row">
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: my-groups-discussion-form -->
            <section class="my-groups-discussion-form clearfix rs_read_this">
                <header>
                    <h2>Start a Discussion in Parents of Kids<br />
                        with Attention Issues</h2>
                </header>
                <label>
                    <span class="visuallyhidden">Title of discussion</span>
                    <input type="text" placeholder="Title of discussion">
                </label>
                <label>
                    <span class="visuallyhidden">More detail</span>
                    <textarea placeholder="More detail"></textarea>
                </label>
                <button class="button rs_skip">Submit</button>
            </section>

            <!-- END PARTIAL: my-groups-discussion-form -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
