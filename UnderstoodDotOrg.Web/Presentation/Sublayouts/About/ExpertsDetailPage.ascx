<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsDetailPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.ExpertsDetailPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register Src="~/Presentation/Sublayouts/Recommendation/ArticleRecommendationIcons.ascx" TagPrefix="udo" TagName="ArticleRecommendationIcons" %>

<div class="container skiplink-feature">
    <!-- BEGIN PARTIAL: about/expert-bio -->
    <div class="expert-bio">

        <div class="row rs_read_this expert-bio-rs-wrapper">
            <div class="col col-5 offset-1">

                <div class="expert-bio-details">
                    <div class="expert-bio-image">
                        <asp:Image ID="imgExpert" runat="server" />
                    </div>
                    <div class="expert-bio-detail">
                        <p class="hours-intro"><%= UnderstoodDotOrg.Common.DictionaryConstants.OnlineOfficeHours %></p>
                        <p class="hours"><sc:FieldRenderer ID="frHours" runat="server" FieldName="Online Office Hours" /></p>
                        <sc:Link ID="lnkTwitter" runat="server" Field="Twitter Link" CssClass="links rs_skip" />
                        <sc:Link ID="lnkBlog" runat="server" Field="Blog Link" CssClass="links rs_skip" />
                    </div>
                </div>
                <!-- .expert-bio-details -->

            </div>
            <!-- .col -->

            <div class="col col-16 offset-1">

                <div class="expert-bio-text">
                    <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />   
                </div>
                <!-- .expert-bio-text -->

            </div>
            <!-- .col -->

        </div>
        <!-- .row -->

    </div>
    <!-- .expert-bio -->
    <!-- END PARTIAL: about/expert-bio -->
</div>
<!-- end .container -->

<asp:PlaceHolder ID="phEvents" runat="server">
<div class="container skiplink-content" aria-role="main">
    <!-- BEGIN PARTIAL: about/expert-events -->
    <div class="expert-events <%= EventTimeframe %>">

        <div class="row expert-events-title">

            <div class="col col-18 offset-1">
                <h3 class="rs_read_this"><sc:FieldRenderer ID="frExpertEventsHeading" runat="server" FieldName="Expert Events Heading" /></h3>
            </div>
            <%--<div class="col col-3 offset-1 expert-events-see-more">
                <a href="REPLACE" class="see-more">See more</a>
            </div>--%>
            <!-- /.col -->

        </div>
        <!-- /.row /.expert-events-title -->

        <div class="expert-event-container">

            <asp:Repeater ID="rptEvents" runat="server">
                <ItemTemplate>
                    <div class="row expert-event rs_read_this">

                        <div class="col col-6 offset-1">
                            <div class="expert-event-image">
                                <asp:HyperLink ID="hlExpertImage" runat="server">
                                    <asp:Image ID="imgExpert" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <!-- /.expert-event-image -->
                        </div>
                        <!-- /.col -->

                        <div class="col col-3 push-13">
                            <div class="expert-event-type">
                                <h4><asp:Literal ID="litEventType" runat="server" /></h4>
                                <p class="time-past"><asp:Literal ID="litEventDatePast" runat="server" /></p>
                            </div>
                            <!-- /.expert-event-type -->
                        </div>
                        <!-- /.col -->

                        <div class="col col-1 push-9 border-col">
                            <div>&nbsp;</div>
                        </div>

                        <div class="col col-11 offset-1 pull-4">
                            <div class="expert-event-details">
                                <p class="date-<%= EventTimeframe %>"><asp:Literal ID="litEventDate" runat="server" /></p>
                                <asp:HyperLink ID="hlEventTitle" runat="server" CssClass="event-title">
                                    <sc:FieldRenderer ID="frEventTitle" runat="server" FieldName="Page Title" />
                                </asp:HyperLink>
                                <h5><sc:FieldRenderer ID="frEventHeading" runat="server" FieldName="Event Heading" /></h5>
                                <p class="topics-covered"><sc:FieldRenderer ID="frEventSubheading" runat="server" FieldName="Event Subheading" /></p>
                                <asp:PlaceHolder ID="phLinksCta" runat="server" Visible="false">
                                    <div class="links-future">
                                        <asp:HyperLink ID="hlEventDetails" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.EventDetailsLabel %></asp:HyperLink>
                                        <sc:FieldRenderer ID="frRsvpLink" runat="server" FieldName="RSVP for Event Link" />
                                        <sc:FieldRenderer ID="frAddToCalendar" runat="server" FieldName="Add To Calendar Link" />       
                                    </div>
                                </asp:PlaceHolder>
                            </div>
                            <!-- /.expert-event-details -->
                        </div>
                        <!-- /.col -->

                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
        <!-- /.expert-event-container -->

    </div>
    <!-- /.expert-events -->

    <!-- END PARTIAL: about/expert-events -->
</div>
<!-- end .container -->
</asp:PlaceHolder>

<div id="relatedArticlesDiv" runat="server" class="container">
    <!-- BEGIN PARTIAL: about/expert-blog-posts -->
    <div class="expert-blog-posts">

        <div class="row expert-blog-posts-title">

            <div class="col col-18 offset-1">
                <h3 class="rs_read_this"><sc:FieldRenderer ID="frExpertBlogsHeading" runat="server" FieldName="Expert Blogs Heading" /></h3>
            </div>
            <div class="col col-3 offset-1 expert-events-see-more">
                <a href="REPLACE" class="see-more"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeMoreLabel %></a>
            </div>
            <!-- /.col -->

        </div>
        <!-- /.row /.expert-blog-posts-title -->

        <div class="expert-blog-post-container">

            <asp:Repeater ID="rptAuthorArticles" runat="server" OnItemDataBound="rptAuthorArticles_ItemDataBound">
                <HeaderTemplate>

                </HeaderTemplate>
                <ItemTemplate>
                    <div class="row expert-blog-post rs_read_this">

                        <div class="col col-6 offset-1">
                            <div class="expert-blog-post-image">
                                <asp:HyperLink ID="hypImageLink" runat="server"></asp:HyperLink>
                            </div>
                            <!-- /.expert-blog-post-image -->
                        </div>
                        <!-- /.col -->

                        <div class="col col-3 push-13">
                            <div class="expert-blog-post-type">
                                <h4><asp:Literal ID="litCommentCount" runat="server"></asp:Literal></h4>
                                <p class="comments"><%= UnderstoodDotOrg.Common.DictionaryConstants.CommentsLabel %></p>
                            </div>
                            <!-- /.expert-blog-post-type -->
                        </div>
                        <!-- /.col -->

                        <div class="col col-1 push-9 border-col">
                            <div>&nbsp;</div>
                        </div>

                        <div class="col col-11 offset-1 pull-4">
                            <div class="expert-blog-post-details">
                                <a href="REPLACE" class="event-title"><asp:Literal ID="litArticleTitle" runat="server"></asp:Literal></a>
                                <p class="post-meta">Posted by <asp:HyperLink ID="hypAuthor" runat="server"></asp:HyperLink> on <asp:Literal ID="litDatePosted" runat="server"></asp:Literal></p>
                                <p class="excerpt"><asp:Literal ID="litAbstract" runat="server"></asp:Literal> <asp:Hyperlink ID="hypReadMore" runat="server">Read More</asp:Hyperlink></p>
                                <udo:ArticleRecommendationIcons ID="articleRecommendationIcons" runat="server" />
                            </div>
                            <!-- /.expert-blog-post-details -->
                        </div>
                        <!-- /.col -->
                    </div>
                </ItemTemplate>
                <FooterTemplate>

                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!-- /.expert-blog-post-container -->

        <sc:Sublayout ID="Sublayout1" runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
        <!-- /.row /.shapes -->

    </div>
    <!-- /.expert-blog-posts -->
    <!-- END PARTIAL: about/expert-blog-posts -->
</div>
<!-- end .container -->
