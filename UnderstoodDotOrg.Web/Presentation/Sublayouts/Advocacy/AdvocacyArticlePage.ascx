<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvocacyArticlePage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy.AdvocacyArticlePage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container l-advocacy-article">
    <div class="row">
        <div class="col col-23 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: advocacy/advocacy-article -->
            <div class="advocacy-article">
                <div class="rs_read_this advocacy-article-rs-wrapper">
                    <section class="article-header clearfix">

                        <div class="col col-9 push-15">
                            <%= Model.DefaultArticlePage.FeaturedImage.Rendered %>
                            <div class="share-save-inline clearfix"></div>
                        </div>

                        <div class="col col-14 pull-9">
                            <%= Model.DefaultArticlePage.ContentPage.BodyContent.Rendered %>
                        </div>

                    </section>

                    <section class="article-callout">
                        <%= Model.ArticleContent.Rendered %>
                    </section>
                </div>

                <section class="article-call-to-action">
                    <!-- BEGIN PARTIAL: sidebar-promos -->
                    <div class="sidebar-promos rs_read_this horizontal">
                        <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/PromotionalsList.ascx" />
                    </div>
                    <!-- end sidebar-promos -->

                    <!-- END PARTIAL: sidebar-promos -->
                </section>
            </div>
            <!-- END PARTIAL: advocacy/advocacy-article -->
        </div>
    </div>
    <!-- .row -->
</div>
<style>
    .article-header .push-15 img{
        width: 100%;
        height: auto;
    }
</style>
<!-- .container -->

<!-- BEGIN PARTIAL: footer -->
