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
                            <sc:FieldRenderer ID="frContentBody" runat="server" FieldName="Appendix Title" />
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

                        <asp:Repeater ID="rptSections" runat="server"
                            ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.DeepDiveArticle.DeepDiveSectionInfoPageItem">
                            <ItemTemplate>
                                <div class="deep-dive-block">
                                    <a name="item<%# Container.ItemIndex %>"></a>
                                    <h2>
                                        <%# Item.Title.Rendered %>
                                    </h2>
                                    <%# Item.Content.Rendered %>
                                    <span class="back-to-top rs_skip"><a href="#top">Back to Top</a></span>
                                </div>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <div class="clearfix"></div>
                            </SeparatorTemplate>
                        </asp:Repeater>

                        <asp:Repeater ID="rptExtraSections" runat="server"
                            ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.DeepDiveArticle.DeepDiveSectionInfoPageItem">
                            <HeaderTemplate>
                                <div class="deep-dive-extra">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="deep-dive-block">
                                    <a name="item<%# Container.ItemIndex %>"></a>
                                    <h2>
                                        <%# Item.Title.Rendered %>
                                    </h2>
                                    <%# Item.Content.Rendered %>
                                    <span class="back-to-top rs_skip"><a href="#top">Back to Top</a></span>
                                </div>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <div class="clearfix"></div>
                            </SeparatorTemplate>
                            <FooterTemplate>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>
                    <!-- END PARTIAL: article-copy -->
                    <div class="deep-dive-more">
                    <a href="REMOVE">More
                        <i class="icon-arrow-down-blue"></i>
                    </a>
                </div>
                </div>
                <!-- BEGIN PARTIAL: key-takeaways -->
                <div id="divKeyTakeaways" runat="server" class="key-takeaways">
                    <header class='header-key-takeaways'>
                        <h2><%--Key Takeaways--%>
                            <asp:Literal ID="litKeyTakeAwayText" runat="server"></asp:Literal>
                        </h2>
                    </header>
                    <sc:FieldRenderer ID="frKeyTakeawayDesc" runat="server" FieldName="Key Takeaways Details" />
                </div>
                <!-- end key-takeaways -->

                <!-- END PARTIAL: key-takeaways -->

                <!-- Sources -->
                <div id="divSources" runat="server" class="key-takeaways">
                    <header class='header-key-takeaways'>
                        <h2>
                            <sc:FieldRenderer ID="FieldRenderer2" runat="server" FieldName="Sources Header" />
                        </h2>
                    </header>
                    <sc:FieldRenderer ID="FieldRenderer1" runat="server" FieldName="Sources Content" />
                </div>
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
                <sc:Sublayout ID="Sublayout1" runat="server" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
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

                <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/CommentsSummary.ascx" />

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

<sc:Placeholder ID="Placeholder1" Key="slComment" runat="server" />
