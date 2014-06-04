<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs.Comments" %>
<div class="container my-account-subheader comments-subheader">
    <div class="row">
        <!-- subheader -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: my-comments-subheader -->
            <h2 class="rs_read_this">My Comments</h2>

            <fieldset>

                <span class="select-container filter">
                    <label for="my-comments-filter" class="visuallyhidden">Filter Comments</label>
                    <select name="my-comments-filter" id="my-comments-filter">
                        <option value="">All</option>
                        <option>architecto voluptatem amet aliquam</option>
                        <option>temporibus molestias similique</option>
                        <option>quas iste recusandae non</option>
                        <option>commodi quia odio</option>
                    </select>
                </span>

                <span class="select-container sort">
                    <label for="my-comments-sort" class="visuallyhidden">Sort Comments</label>
                    <select name="my-comments-sort" id="my-comments-sort">
                        <option value="">Most Recent</option>
                        <option>Oldest To Newest</option>
                        <option>Number Of Comments</option>
                        <option>Recent Comments</option>
                    </select>
                </span>

            </fieldset>
            <!-- END PARTIAL: my-comments-subheader -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: account-mycomments -->
            <asp:Panel ID="pnlComments" Visible="false" runat="server">
                <section class="container account-mycomments">
                    <div class="row mycomment-list skiplink-content" aria-role="main">

                        <asp:Repeater ID="rptComments" runat="server" OnItemDataBound="rptComments_ItemDataBound">
                            <ItemTemplate>
                                <div class="mycomment-item clearfix rs_read_this repeater-item">
                                    <div class="col col-3">
                                        <h3 class="comment-type">
                                            <asp:Literal ID="litSection" runat="server"></asp:Literal>
                                        </h3>
                                    </div>
                                    <div class="col col-21">
                                        <div class="comment-wrap">
                                            <p class="comment-article-title">
                                                <asp:HyperLink ID="hypCommentLink" runat="server"></asp:HyperLink>
                                            </p>
                                            <p class="comment">
                                                &quot;<asp:Literal ID="litCommentBody" runat="server"></asp:Literal>&quot;
                                            </p>
                                            <div class="comment-details">
                                                <span class="comment-group" id="commentGroupSpan" runat="server">In
                                                    <asp:HyperLink ID="hypCommentGroup" runat="server"></asp:HyperLink>
                                                </span>
                                                <span class="dot">&middot;</span>
                                                <span class="timestamp">
                                                    <asp:Literal ID="litCommentTime" runat="server"></asp:Literal>
                                                </span>
                                                <button class="comment-likes">
                                                    <i class="icon-comment-like"></i>
                                                    <span class="comment-likes-count">
                                                        <asp:Literal ID="litLikes" runat="server"></asp:Literal>
                                                    </span>
                                                    <span class="visuallyhidden">likes</span>
                                                </button>
                                            </div>
                                            <!-- /.comment-details -->
                                        </div>
                                        <!-- /.comment-wrap -->
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.mycomment-item -->
                            </ItemTemplate>
                        </asp:Repeater>

                        <!-- TO-DO Show More Button implementation -->
                        <div class="showmore-footer">
                            <!-- Show More -->
                            <!-- BEGIN PARTIAL: community/show_more -->
                            <!--Show More-->
                            <div class="container show-more rs_skip">
                                <div class="row">
                                    <div class="col col-24">
                                        <a class="show-more-link show_more" href="#" data-path="my-account/my-comments" data-container="mycomment-list" data-item="mycomment-item" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
                                    </div>
                                </div>
                            </div>
                            <!-- .show-more -->
                            <!-- END PARTIAL: community/show_more -->
                            <!-- .show-more -->
                        </div>
                </section>
                <!-- END PARTIAL: account-mycomments -->
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlNoComments" Visible="false">
                <p class="empty">You have not made any comments</p>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlNoProfile" Visible="false">
                <p class="empty">You don't have a community profile, to create one please<asp:HyperLink CssClass="comment-link" ID="hypCompleteYourProfile" runat="server">click here.</asp:HyperLink></p>
            </asp:Panel>
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
