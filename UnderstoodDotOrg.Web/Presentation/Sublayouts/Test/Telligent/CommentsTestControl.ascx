<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentsTestControl.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent.CommentsTestControl" %>

<!-- comments -->
<div class="container comments">
    <div class="row">
        <!-- comments col -->
        <div class="col col-23 offset-1">
            <!-- BEGIN PARTIAL: comment-list -->
            <section class="comment-list">

                <header>
                    <asp:Label CssClass="comment-count" ID="CommentCountDisplay" runat="server" />
                    <select name="comment-sort-option" class="comment-sort">
                        <option value="">Sort by</option>
                        <option>A-Z</option>
                        <option>Z-A</option>
                    </select>
                </header>
                
                <div class="comment-list-wrapper">
                    <asp:Repeater runat="server" ID="CommentRepeater">
                        <ItemTemplate>
                            <div class="comment-wrapper">
                                <div class="comment-header">
                                    <span class="comment-avatar">
                                        <img style="height:60px; width:60px;" alt="60x60 Placeholder" src='<%# Eval("_authorAvatarUrl") %>' />
                                    </span>
                                    <span class="comment-info">
                                        <span class="comment-username"><%# Eval("_authorUsername") %></span>
                                        <span class="comment-date"><%# Eval("_publishedDate") %></span>
                                    </span>
                                    <a class="comment-like"><i class="icon-comment-like"></i><%# Eval("_likes") %></a>
                                </div>
                                <div class="comment-body">
                                    <p>
                                        <%# Eval("_body")  %>
                                    </p>
                                </div>
                                <div class="comment-actions">
                                    <asp:LinkButton CssClass="comment-reply" OnClick="ReplyButton_Click" ID="ReplyButton" runat="server"><i class="icon-comment-reply"></i>Reply</asp:LinkButton>
                                    <asp:LinkButton OnClick="LikeButton_Click" ID="LikeButton" CommandArgument='<%# Eval("_commentId") + "&" + Eval("_commentContentTypeId") %>' class="comment-like" runat="server"><i class="icon-comment-like"></i>This Helped</asp:LinkButton>
                                    <asp:LinkButton CssClass="comment-flag" CommandArgument='<%# Eval("_commentId") %>' OnClick="FlagButton_Click" ID="FlagButton" runat="server">
                                        <i class="icon-comment-flag"></i>Report as inappropriate</asp:LinkButton>
                                    <!--<a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</--a>-->
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!-- .comment-wrapper -->
                </div>
                <!-- .comment-list-wrapper -->

                <div class="comment-footer">
                    <div class="comment-more-wrapper">
                        <a class="comment-more" href="REPLACE">More Comments<i class="icon-comment-more"></i></a>
                    </div>
                    <div class="comment-form">
                        <form>
                            <asp:TextBox onfocus="if (this.value == 'Add your comment...') this.value = '';" onblur="if (this.value == '') this.value = 'Add your comment...';"
                                name="comment-form-reply" class="comment-form-reply" ID="CommentEntryTextField" Style="color: #555; text-align: left; font-size:15px;"
                                runat="server" />
                            <asp:Button ID="SubmitButton" OnClick="SubmitButton_Click" class="comment-form-submit submit-button" runat="server" />
                        </form>
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
