<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Comments" %>
<%@ Register TagPrefix="udo" TagName="Comments" Src="~/Presentation/Sublayouts/Common/Comments/Entries.ascx" %>

<!-- comments -->
<div class="container comments">
    <div class="row">
        <!-- comments col -->
        <div class="col col-22 offset-1 skiplink-comments">
            <!-- BEGIN PARTIAL: comment-list -->
            <section id="comment-list" class="comment-list" data-endpoint="<%= ContentServicePath %>" data-path="<%= AjaxPath %>" data-blog="<%= BlogId %>" data-post="<%= BlogPostId %>" data-container="comment-listing-wrapper">

                <header>
                    <h2 class="comment-count rs_read_this"><%= UnderstoodDotOrg.Common.DictionaryConstants.CommentsLabel %> (<asp:Literal ID="litCommentCount" runat="server" />)</h2>
                    <div class="select-container select-inverted-mobile">
                      <select name="comment-sort-option" id="comment-sort-option-dropdown" class="comment-sort">
                        <asp:Repeater ID="rptSortOptions" runat="server" ItemType="UnderstoodDotOrg.Domain.Understood.Services.CommentSortOption">
                            <ItemTemplate>
                                <option value="<%# (Container.ItemIndex == 0) ? string.Empty : Container.ItemIndex.ToString() %>"><%# Item.Description %></option>
                            </ItemTemplate>
                        </asp:Repeater>
                      </select>
                    </div>
                </header>

                <div id="comment-listing-wrapper" class="comment-list-wrapper">
                    
                    <udo:Comments ID="commentsControl" runat="server" />
                    
                </div>
                <!-- .comment-list-wrapper -->

                <div class="comment-footer" id="comment-submit">
                    <asp:Panel ID="pnlShowMore" runat="server" Visible="false" CssClass="comment-more-wrapper">
                        <!--Show More-->
                        <div class="container show-more rs_skip">
                          <div class="row">
                            <div class="col col-24">
                              <a id="show-more-comments" href="#"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></a>
                            </div>
                          </div>
                        </div><!-- .show-more -->
                    </asp:Panel>

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