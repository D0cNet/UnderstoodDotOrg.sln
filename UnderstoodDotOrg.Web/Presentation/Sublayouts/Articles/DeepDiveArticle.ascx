<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeepDiveArticle.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.DeepDiveArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1 skiplink-content" aria-role="main" aria-role="main">
            <div class="rs_read_this">

                <!-- BEGIN PARTIAL: article-deep-dive-copy -->
                <div class="deep-dive-article-container">
                    <div class="whats-covered-deep-dive" id="top">
                        <h2><%--What&rsquo;s covered--%>
                            <sc:FieldRenderer ID="frContentBody" runat="server" FieldName="Section Title" />
                        </h2>
                        <asp:ListView ID="rptSectionList" runat="server" ItemPlaceholderID="itemPlaceholder" 
                            ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.DeepDiveArticle.DeepDiveSectionInfoPageItem">
                            <LayoutTemplate>
                                <ul>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                </ul>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <li>
                                    <a href="#item<%# Container.DisplayIndex %>">
                                        <%# Item.Title.Rendered %>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>

                    </div>
                    <!-- END whats-covered -->
                    <!-- END PARTIAL: whats-covered -->
                    <!-- FIXME: add correct article content for A8a here. see speckle. -->
                    <!-- BEGIN PARTIAL: article-copy -->
                    <div class="deep-dive-copy">

                        <asp:ListView ID="uxSections" runat="server"
                            ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.DeepDiveArticle.DeepDiveSectionInfoPageItem">
                            <ItemTemplate>
                                <div class="deep-dive-block">
                                    <a name="item<%# Container.DisplayIndex %>"></a>
                                    <h2>
                                        <%# Item.Title.Rendered %>
                                    </h2>
                                    <%# Item.Content.Rendered %>
                                    <span class="back-to-top rs_skip"><a href="#top">Back to Top</a></span>
                                </div>
                            </ItemTemplate>
                            <ItemSeparatorTemplate>
                                <div class="clearfix"></div>
                            </ItemSeparatorTemplate>
                        </asp:ListView>

                    </div>
                    <!-- END PARTIAL: article-copy -->
                </div>
                <!-- BEGIN PARTIAL: key-takeaways -->
                <div class="key-takeaways">
                    <header class='header-key-takeaways'>
                        <h2><%--Key Takeaways--%>
                            <sc:FieldRenderer ID="frKeyTakeawaytitle" runat="server" FieldName="KeyTake away Title" />
                        </h2>
                    </header>
                    <sc:FieldRenderer ID="frKeyTakeawayDesc" runat="server" FieldName="Key Take away Details" />
                    <%-- <ul>
                    <li>
                        <p>This article talks about lorem ipsum malesuada do</p>
                    </li>
                    <li>
                        <p>This article talks about lorem ipsum malesuada</p>
                    </li>
                    <li>
                        <p>This article talks about lorem ipsum</p>
                    </li>
                </ul> --%>
                </div>
                <!-- end key-takeaways -->

                <!-- END PARTIAL: key-takeaways -->
            </div>
            <!-- BEGIN PARTIAL: about-the-author -->
            <div class="rs_about_author rs_read_this">
                <sc:Sublayout ID="sbAboutAuthor" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx" Visible="false" />
            </div>

            <!-- END PARTIAL: about-the-author -->
            <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" Visible="false" />

            <!-- END PARTIAL: reviewed-by -->
            <div class="find-this-helpful-small">
                <!-- Module within only appears in under 650px window width-->
            </div>
            <!-- BEGIN PARTIAL: keep-reading-mobile -->
            <div class="keep-reading keep-reading-mobile">
                <h3>Keep Reading</h3>
                <ul>
                    <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
                    <li><a href="REPLACE">How to Build a Homework Plan</a></li>
                    <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
                </ul>
            </div>


            <!-- END PARTIAL: keep-reading-mobile -->
        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1 skiplink-sidebar rs_read_this">

            <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCountsSideColumn.ascx" runat="server"></sc:Sublayout>

            <!-- END PARTIAL: comments-count -->
            <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" runat="server"></sc:Sublayout>
            <!-- BEGIN PARTIAL: keep-reading-lg -->
            <div class="keep-reading keep-reading-lg">
                <sc:Sublayout ID="slKeepReading" runat="server" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
            </div>
            <!-- END PARTIAL: keep-reading-lg -->
            <!-- BEGIN PARTIAL: comments-summary -->
            <section class="comments-summary">
                <header>
                    <h3>Comments (19)</h3>
                </header>
                <div class="quote-container">
                    <blockquote>
                        <p>Inventore et qui quis quis veritatis. doloribus odio ut nam. rerum eos earum sed sed optio fugiat cupiditate atque velit id doloremque voluptatem</p>
                        <i class="arrow-quote-bottom"></i>
                    </blockquote>
                    <span><strong>Carrie S</strong> &bull; 30 min ago</span>
                </div>

                <ul>
                    <li><a href="REPLACE">See All Comments</a></li>
                    <li><a href="REPLACE">Add My Comment</a></li>
                </ul>
            </section>
            <!-- END PARTIAL: comments-summary -->
            <!-- BEGIN PARTIAL: sidebar-promos -->
            <div class="sidebar-promos rs_read_this vertical">
                <sc:Sublayout ID="sbSidebarPromo" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/PromotionalsList.ascx" />
            </div>

            <!-- end sidebar-promos -->

            <!-- END PARTIAL: sidebar-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
</div>

<!-- comments -->
<div class="container comments">
    <div class="row">
        <!-- comments col -->
        <div class="col col-23 offset-1">
            <div class="col col-23 offset-1 skiplink-comments">
                <!-- BEGIN PARTIAL: comment-list -->
                <section class="comment-list" id="count-comments">

                    <header>
                        <span class="comment-count">Comments (19)</span>
                        <select name="comment-sort-option" class="comment-sort">
                            <option value="">Sort by</option>
                            <option>A-Z</option>
                            <option>Z-A</option>
                        </select>
                    </header>

                    <div class="comment-list-wrapper">

                        <div class="comment-wrapper">
                            <div class="comment-header">
                                <span class="comment-avatar">
                                    <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                                </span>
                                <span class="comment-info">
                                    <span class="comment-username">Patricia S</span>
                                    <span class="comment-date">3 days ago</span>
                                </span>
                                <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                            </div>
                            <div class="comment-body">
                                <p>
                                    Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                                </p>
                            </div>
                            <div class="comment-actions">
                                <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                                <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                                <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                            </div>
                        </div>
                        <!-- .comment-wrapper -->

                        <div class="comment-wrapper">
                            <div class="comment-header">
                                <span class="comment-avatar">
                                    <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                                </span>
                                <span class="comment-info">
                                    <span class="comment-username">Patricia S</span>
                                    <span class="comment-date">3 days ago</span>
                                </span>
                                <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                            </div>
                            <div class="comment-body">
                                <p>
                                    Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                                </p>
                            </div>
                            <div class="comment-actions">
                                <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                                <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                                <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                            </div>
                        </div>
                        <!-- .comment-wrapper -->

                        <div class="comment-wrapper">
                            <div class="comment-header">
                                <span class="comment-avatar">
                                    <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                                </span>
                                <span class="comment-info">
                                    <span class="comment-username">Patricia S</span>
                                    <span class="comment-date">3 days ago</span>
                                </span>
                                <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                            </div>
                            <div class="comment-body">
                                <p>
                                    Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                                </p>
                            </div>
                            <div class="comment-actions">
                                <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                                <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                                <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                            </div>
                        </div>
                        <!-- .comment-wrapper -->

                        <div class="comment-wrapper">
                            <div class="comment-header">
                                <span class="comment-avatar">
                                    <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                                </span>
                                <span class="comment-info">
                                    <span class="comment-username">Patricia S</span>
                                    <span class="comment-date">3 days ago</span>
                                </span>
                                <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                            </div>
                            <div class="comment-body">
                                <p>
                                    Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                                </p>
                            </div>
                            <div class="comment-actions">
                                <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                                <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                                <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                            </div>
                        </div>
                        <!-- .comment-wrapper -->
                    </div>
                    <!-- .comment-list-wrapper -->

                    <div class="comment-footer">
                        <div class="comment-more-wrapper">
                            <a class="comment-more" href="REPLACE">More Comments<i class="icon-comment-more"></i></a>
                        </div>
                        <div class="comment-form">
                            <textarea name="comment-form-reply" class="comment-form-reply" placeholder="Add your comment..."></textarea>
                            <input type="submit" value="Submit" class="comment-form-submit submit-button" />
                            <div class="clearfix"></div>
                        </div>
                    </div>

                </section>
                <!-- .comment-list -->

                <!-- END PARTIAL: comment-list -->
            </div>
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
