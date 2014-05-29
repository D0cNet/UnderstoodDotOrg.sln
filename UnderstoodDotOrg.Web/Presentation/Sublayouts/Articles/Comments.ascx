<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Comments" %>

<!-- comments -->
<div class="container comments">
    <div class="row">
        <!-- comments col -->
        <div class="col col-23 offset-1">
            <!-- BEGIN PARTIAL: comment-list -->
            <section class="comment-list" id="comment-list">

                <header>
                    <asp:Label CssClass="comment-count" ID="CommentCountDisplay" runat="server" />
                    <select name="comment-sort-option" class="comment-sort">
                        <option value="">Sort by</option>
                        <option>A-Z</option>
                        <option>Z-A</option>
                    </select>
                </header>

                <div class="comment-list-wrapper">
                    <asp:Repeater runat="server" ID="CommentRepeater" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.Comment">
                        <ItemTemplate>
                            <div class="comment-wrapper">
                                <div class="comment-header" id="<%# Item.CommentId %>">
                                    <span class="comment-avatar">
                                        <img style="height: 60px; width: 60px;" alt="60x60 Placeholder" src='<%# Item.AuthorAvatarUrl %>' />
                                    </span>
                                    <span class="comment-info">
                                        <span class="comment-username"><%# Item.AuthorUsername %></span>
                                        <span class="comment-date"><%# Item.PublishedDate %></span>
                                    </span>
                                    <a class="comment-like"><i class="icon-comment-like"></i><%# Item.Likes %></a>
                                </div>
                                <div class="comment-body">
                                    <p>
                                        <%# Item.Body  %>
                                    </p>
                                </div>
                                <div class="comment-actions">
                                    <asp:LinkButton CssClass="comment-reply" OnClick="ReplyButton_Click" ID="ReplyButton" runat="server"><i class="icon-comment-reply"></i>Reply</asp:LinkButton>
                                    <asp:LinkButton OnClick="LikeButton_Click" ID="LikeButton" CommandArgument='<%# Item.CommentId + "&" + Item.CommentContentTypeId %>' class="comment-like" runat="server"><i class="icon-comment-like"></i>This Helped</asp:LinkButton>
                                    <asp:LinkButton CssClass="comment-flag" CommandArgument='<%# Item.CommentId %>' OnClick="FlagButton_Click" ID="FlagButton" runat="server">
                                        <i class="icon-comment-flag"></i>Report as inappropriate</asp:LinkButton>
                                    <!--<a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</--a>-->
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!-- .comment-wrapper -->
                </div>
                <!-- .comment-list-wrapper -->

                <div class="comment-footer" id="comment-submit">
                    <div class="comment-more-wrapper">
                        <a class="comment-more" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-comment-more"></i></a>
                    </div>
                    <div class="comment-form">
                        <textarea name="comment-form-reply" class="comment-form-reply uniform" id="CommentEntryTextField" placeholder="Add your comment..." runat="server"></textarea>
                        <%--<asp:TextBox CssClass="comment-form-reply" ID="CommentEntryTextField" runat="server" />--%>
                        <asp:Button ID="SubmitButton" OnClick="SubmitButton_Click" class="button" runat="server" />
                        <div class="clearfix"></div>
                    </div>
                </div>

            </section>
            <!-- .comment-list -->

            <!-- END PARTIAL: comment-list -->
        </div>
    </div>
    <!-- .row -->
</div><!-- .container -->

