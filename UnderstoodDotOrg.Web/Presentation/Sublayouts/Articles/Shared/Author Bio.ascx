<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Author Bio.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Author_Bio" %>
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
                                <p class="post-meta"><%= UnderstoodDotOrg.Common.DictionaryConstants.PostedByLabel %> <asp:HyperLink ID="hypAuthor" runat="server"></asp:HyperLink> <%= UnderstoodDotOrg.Common.DictionaryConstants.Onfragment %> <asp:Literal ID="litDatePosted" runat="server"></asp:Literal></p>
                                <p class="excerpt"><asp:Literal ID="litAbstract" runat="server"></asp:Literal> <asp:Hyperlink ID="hypReadMore" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.ReadMoreLabel %></asp:Hyperlink></p>
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
