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
                        <div class="article-callout-item">
                            <h3 class="article-callout-title">et nihil assumenda odio reprehenderit quia sequi</h3>
                            <p>Nemo expedita doloremque quo sit et sit et necessitatibus fuga a quis quo. qui qui minima dolor debitis natus blanditiis ad. voluptas consequatur eos at autem vel odio illo cumque. est voluptatibus iste doloremque rerum. consequuntur quaerat cumque et voluptatem sequi occaecati minus ea voluptatem officia. omnis nostrum eaque sed voluptas molestiae ipsum occaecati enim minima voluptas quo quam temporibus</p>
                        </div>
                        <div class="article-callout-item">
                            <h3 class="article-callout-title">laudantium illum nulla voluptas quo explicabo deserunt</h3>
                            <p>Explicabo suscipit molestiae quasi nihil. quam ipsum eos dolorem occaecati et possimus ut a quo ea itaque inventore dignissimos. vel aut nisi architecto. quasi alias voluptas repellendus ad. maxime hic et non dolore est quis animi eum</p>
                        </div>
                        <div class="article-callout-item">
                            <h3 class="article-callout-title">nulla aut sit tempora aspernatur et quidem</h3>
                            <p>Fugiat tempore corrupti qui aliquid praesentium animi assumenda rerum sed dolores recusandae similique culpa ea. doloremque velit vel saepe sunt veritatis accusantium consequatur vel voluptas ipsum est itaque. fugit qui est debitis aspernatur porro cum</p>
                        </div>
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
<!-- .container -->

<!-- BEGIN PARTIAL: footer -->
