<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Comments" %>

<!-- comments -->
<div class="container comments">
    <div class="row">
        <!-- comments col -->
        <div class="col col-22 offset-1 skiplink-comments">
            <!-- BEGIN PARTIAL: comment-list -->
            <section class="comment-list" id="count-comments">

                <header>
                    <h2 class="comment-count rs_read_this"><%= UnderstoodDotOrg.Common.DictionaryConstants.CommentsLabel %>(<asp:Literal ID="litCommentCount" runat="server" />)</h2>
                    <div class="select-container select-inverted-mobile">
                      <select name="comment-sort-option" id="comment-sort-option-dropdown" class="comment-sort">
                        <option value="">Sort by</option>
                        <option>A-Z</option>
                        <option>Z-A</option>
                      </select>
                    </div>
                </header>

                <div class="comment-list-wrapper">
                    <asp:Repeater runat="server" ID="CommentRepeater" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.Comment">
                        <ItemTemplate>
                            <div class="comment-wrapper repeater-item">
                                <div class="comment-header" id="<%# Item.CommentId %>">
                                    <span class="comment-avatar">
                                        <img src="<%# Item.AuthorAvatarUrl %>" width="60" height="60" />
                                    </span>
                                    <span class="comment-info">
                                        <span class="comment-username"><%# Item.AuthorUsername %></span>
                                        <span class="comment-date"><%# Item.PublishedDate %></span>
                                    </span>
                                    <a class="comment-like"><i class="icon-comment-like"></i><%# Item.Likes %> <span class="visuallyhidden">Likes</span></a>
                                </div>
                                <div class="comment-body">
                                    <p>
                                        <%# Item.Body  %>
                                    </p>
                                </div>
                                <div class="comment-actions rs_skip">
                                    <a href="#" class="comment-reply" onclick="document.getElementById('<%= txtComment.ClientID %>').focus();return false;" id="ReplyButton"><i class="icon-comment-reply"></i><%= UnderstoodDotOrg.Common.DictionaryConstants.ReplyLabel %></a>
                                    <asp:LinkButton OnClick="LikeButton_Click" ID="LikeButton" CommandArgument='<%# Item.CommentId + "&" + Item.CommentContentTypeId %>' CssClass="comment-like" runat="server"><i class="icon-comment-like"></i><%= UnderstoodDotOrg.Common.DictionaryConstants.ThisHelpedLabel %></asp:LinkButton>
                                    <asp:LinkButton CssClass="comment-flag" CommandArgument='<%# Item.CommentId %>' OnClick="FlagButton_Click" ID="FlagButton" runat="server">
                                        <i class="icon-comment-flag"></i><%= UnderstoodDotOrg.Common.DictionaryConstants.ReportAsInappropriateLabel %></asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!-- .comment-wrapper -->
                </div>
                <!-- .comment-list-wrapper -->

                <div class="comment-footer" id="comment-submit">
                    <div class="comment-more-wrapper">
                        <!--Show More-->
                        <div class="container show-more rs_skip">
                          <div class="row">
                            <div class="col col-24">
                              <a class="show-more-link " href="#" data-path="articles/comments" data-container="comment-list-wrapper" data-item="comment-wrapper" data-count="2"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></a>
                            </div>
                          </div>
                        </div><!-- .show-more -->
                    </div>

                    <div class="comment-form">
                        <asp:Label runat="server" AssociatedControlID="txtComment"></asp:Label>
                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" MaxLength="1000" CssClass="comment-form-reply" />
                        <label for="comment-form-reply-text" class="visuallyhidden">Add your comment</label>
                        <asp:RequiredFieldValidator ForeColor="Red" ValidationGroup="vgSubmitButton" ID="rfvComment" runat="server" ControlToValidate="txtComment" CssClass="validationerror"></asp:RequiredFieldValidator>
                        <%--<asp:TextBox CssClass="comment-form-reply" ID="CommentEntryTextField" runat="server" />--%>
                        <asp:Button ValidationGroup="vgSubmitButton" ID="btnSubmit" OnClick="SubmitButton_Click" CssClass="comment-form-submit button" runat="server" />
                        <div class="clearfix"></div>
                    </div>
 
                </div>

            </section>
            <!-- .comment-list -->

            <!-- END PARTIAL: comment-list -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->