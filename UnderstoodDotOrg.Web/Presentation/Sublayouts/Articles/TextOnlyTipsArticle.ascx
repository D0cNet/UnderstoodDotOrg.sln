<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextOnlyTipsArticle.ascx.cs"
    Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.TextOnlyTipsArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<script type="text/javascript">
    (function (d) {
        var f = d.getElementsByTagName('SCRIPT')[0], p = d.createElement('SCRIPT');
        p.type = 'text/javascript';
        p.async = true;
        p.src = '//assets.pinterest.com/js/pinit.js';
        f.parentNode.insertBefore(p, f);
    }(document));
</script>
<script type="text/javascript" src="//assets.pinterest.com/js/pinit.js"></script>
<div class="count-mobile">
    <!-- BEGIN PARTIAL: helpful-count -->
    <div class="count-helpful">
        <a href="#count-helpful-content"><span>34</span>Found this helpful</a>
    </div>
    <!-- END PARTIAL: helpful-count -->
    <!-- BEGIN PARTIAL: comments-count -->
    <div class="count-comments">
        <a href="#count-comments"><span>19</span>Comments</a>
    </div>
    <!-- END PARTIAL: comments-count -->
</div>
<div class="container article-intro">
    <div class="row">
        <!-- helpful count -->
        <div class="col col-10 article-intro-count multiple">
            <!-- BEGIN PARTIAL: helpful-count -->
            <div class="count-helpful">
                <a href="#count-helpful-content"><span>34</span>Found this helpful</a>
            </div>
            <!-- END PARTIAL: helpful-count -->
            <!-- BEGIN PARTIAL: comments-count -->
            <div class="count-comments">
                <a href="#count-comments"><span>19</span>Comments</a>
            </div>
            <!-- END PARTIAL: comments-count -->
        </div>
        <!-- intro-text -->
        <div class="col col-13 offset-1">
            <!-- BEGIN PARTIAL: article-intro-text -->
            <div class="article-intro-text">
                <p>
                    <sc:FieldRenderer ID="frArticleIntro" runat="server" FieldName="Body Content" />
                    <%--This would be the intro text to the slideshow. It should run about 35 words. Lorem ipsum dolor sit amet, consectetur adipiscing elit vestibulum convallis risus id felis.
                    --%>
                </p>
            </div>
            <!-- END PARTIAL: article-intro-text -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
<div class="container article">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: text-slides -->
            <div class="article-slideshow-container text-tips">
                <div id="article-slideshow" class="rsDefault slide-show-border" data-random="false">
                    <asp:Repeater ID="rptAllTips" runat="server" OnItemDataBound="rptAllTips_ItemDataBound">
                        <HeaderTemplate></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Panel ID="pnlTips" runat="server" CssClass="slide">
                                <%--class="slide text-slide light-blue-background"   or <div class="slide end">--%>
                                <div class="slide-inner">
                                    <asp:PlaceHolder ID="phSlide" Visible="false" runat="server">

                                        <div class="content">
                                            <div class="top">
                                                <!-- BEGIN PARTIAL: share-content-dropdown -->
                                                <!-- This file shared on multiple pages -->
                                                <div class="share-dropdown-menu">
                                                    <button class="social-share-button">
                                                        Share <i class="icon-arrow"></i>
                                                    </button>
                                                    <div class="share-menu">
                                                        <span class="social-share">Share <i class="icon-arrow"></i></span>
                                                        <ul>
                                                            <li class="clearfix"><a class="icon-facebook share-icon" href="https://facebook.com/sharer.php?u=<%= Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item) %>"><i class="icon-facebook"></i>Facebook</a> </li>
                                                            <li class="clearfix"><a class="icon-twitter share-icon" href="https://twitter.com/intent/tweet?url=<%= Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item) %>&text=<%= Sitecore.Context.Item.Name %>&via=YOURTWITTERNAMEHERE"><i class="icon-twitter"></i>Twitter</a> </li>
                                                            <li class="clearfix"><a class="icon-google share-icon" href="https://plus.google.com/share?url=<%= Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item) %>"><i class="icon-google"></i>Google +</a> </li>
                                                            <li class="clearfix"><a class="icon-pinterest share-icon" href="https://www.pinterest.com/pin/create/button/?url=http%3A%2F%2Fwww.flickr.com%2Fphotos%2Fkentbrew%2F6851755809%2F&media=http%3A%2F%2Ffarm8.staticflickr.com%2F7027%2F6851755809_df5b2051c9_z.jpg&description=Next%20stop%3A%20Pinterest" data-pin-do="buttonPin" data-pin-config="above" class="socicon icon-pinterest"><i class="icon-pinterest"></i>Pinterest</a> </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                <!-- END PARTIAL: share-content-dropdown -->
                                                <!-- BEGIN PARTIAL: article-action-buttons -->
                                                <div class="article-actions buttons-container clearfix">
                                                    <button class="icon-email">
                                                        email</button>
                                                    <button class="icon-plus">
                                                        save this</button>
                                                    <button class="icon-print" onclick="window.print()">
                                                        print</button>
                                                    <button class="icon-bell">
                                                        remind me</button>
                                                </div>
                                                <!-- END PARTIAL: article-action-buttons -->
                                                <div class="clearfix">
                                                </div>
                                            </div>
                                            <div class="slide-count-text">
                                                <span class="light-blue-span"><%--1--%><asp:Label ID="lblCurrentTip" runat="server"></asp:Label></span> of <%--9--%><asp:Label ID="lblTotalTips" runat="server"></asp:Label>
                                            </div>
                                            <h3>
                                                <sc:FieldRenderer ID="frTipTitle" runat="server" FieldName="Tip Title" />
                                            </h3>
                                            <p>
                                                <sc:FieldRenderer ID="frTipText" runat="server" FieldName="Tip Text" />
                                            </p>
                                        </div>

                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phEnd" Visible="false" runat="server">
                                        <h3>
                                            <a href="#" class="restart-slideshow">&lt; See Slideshow from the Beginning</a>
                                            or explore more:</h3>
                                        <div class="thumbnail" style="background-image: url('http://placehold.it/380x220')">
                                        </div>
                                        <div class="text">
                                            <asp:HyperLink ID="hlRandomArticle1" runat="server">
                                                <h4>
                                                    <%--<a href="REPLACE">vitae optio ut rem consequuntur ducimus sequi</a>--%>
                                                    <sc:FieldRenderer ID="frRandomTipArticleTitle1" runat="server" FieldName="Page Title" />
                                                </h4>
                                                <p>
                                                    <%--et assumenda dolore laborum dignissimos iure cupiditate esse ut sed enim aliquam
                                    cupiditate voluptas minima--%>
                                                    <sc:FieldRenderer ID="frRandomTipsArticleIntro1" runat="server" FieldName="Body Content" />
                                                </p>
                                            </asp:HyperLink>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div class="thumbnail" style="background-image: url('http://placehold.it/380x220')">
                                        </div>
                                        <div class="text">
                                            <asp:HyperLink ID="hlRandomArticle2" runat="server">
                                                <h4>
                                                    <%--<a href="REPLACE">vitae optio ut rem consequuntur ducimus sequi</a>--%>
                                                    <sc:FieldRenderer ID="frRandomTipArticleTitle2" runat="server" FieldName="Page Title" />
                                                </h4>
                                                <p>
                                                    <%--et assumenda dolore laborum dignissimos iure cupiditate esse ut sed enim aliquam
                                    cupiditate voluptas minima--%>
                                                    <sc:FieldRenderer ID="frRandomTipsArticleIntro2" runat="server" FieldName="Body Content" />
                                                </p>
                                            </asp:HyperLink>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </asp:PlaceHolder>

                                </div>
                            </asp:Panel>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>




                    <%--  <div class="slide text-slide light-blue-background">
                        <div class="slide-inner">
                            <div class="content">
                                <div class="top">
                                    <!-- BEGIN PARTIAL: share-content-dropdown -->
                                    <!-- This file shared on multiple pages -->
                                    <div class="share-dropdown-menu">
                                        <button class="social-share-button">
                                            Share <i class="icon-arrow"></i>
                                        </button>
                                        <div class="share-menu">
                                            <span class="social-share">Share <i class="icon-arrow"></i></span>
                                            <ul>
                                                <li class="clearfix"><a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a> </li>
                                                <li class="clearfix"><a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a> </li>
                                                <li class="clearfix"><a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a> </li>
                                                <li class="clearfix"><a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a> </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- END PARTIAL: share-content-dropdown -->
                                    <!-- BEGIN PARTIAL: article-action-buttons -->
                                    <div class="article-actions buttons-container clearfix">
                                        <button class="icon-email">
                                            email</button>
                                        <button class="icon-plus">
                                            save this</button>
                                        <button class="icon-print">
                                            print</button>
                                        <button class="icon-bell">
                                            remind me</button>
                                    </div>
                                    <!-- END PARTIAL: article-action-buttons -->
                                    <div class="clearfix">
                                    </div>
                                </div>
                                <div class="slide-count-text">
                                    <span class="light-blue-span">1</span> of 9
                                </div>
                                <h3>Ullam Cupiditate Consequatur Architecto Est</h3>
                                <p>
                                    Maxime repellat distinctio facere. Similique itaque ut explicabo inventore quod
                                    et. Corporis voluptas molestiae eos. Qui est laborum voluptatem molestiae. Perspiciatis
                                    molestiae dolor corrupti harum. Qui natus harum alias nulla rem sint ea harum cumque
                                    soluta et amet.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="slide text-slide blue-background">
                        <div class="slide-inner">
                            <div class="content">
                                <div class="top">
                                    <!-- BEGIN PARTIAL: share-content-dropdown -->
                                    <!-- This file shared on multiple pages -->
                                    <div class="share-dropdown-menu">
                                        <button class="social-share-button">
                                            Share <i class="icon-arrow"></i>
                                        </button>
                                        <div class="share-menu">
                                            <span class="social-share">Share <i class="icon-arrow"></i></span>
                                            <ul>
                                                <li class="clearfix"><a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a> </li>
                                                <li class="clearfix"><a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a> </li>
                                                <li class="clearfix"><a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a> </li>
                                                <li class="clearfix"><a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a> </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- END PARTIAL: share-content-dropdown -->
                                    <!-- BEGIN PARTIAL: article-action-buttons -->
                                    <div class="article-actions buttons-container clearfix">
                                        <button class="icon-email">
                                            email</button>
                                        <button class="icon-plus">
                                            save this</button>
                                        <button class="icon-print">
                                            print</button>
                                        <button class="icon-bell">
                                            remind me</button>
                                    </div>
                                    <!-- END PARTIAL: article-action-buttons -->
                                    <div class="clearfix">
                                    </div>
                                </div>
                                <div class="slide-count-text">
                                    <span class="blue-span">2</span> of 9
                                </div>
                                <h3>Eius Consequatur Consequatur Ullam Ipsa Qui Laudantium</h3>
                                <p>
                                    Corporis dolorem dolores aut distinctio accusamus corrupti placeat quasi dolor eius
                                    non nobis. Consectetur est et consequuntur id ut. Aspernatur non vitae ut. Repudiandae
                                    nemo et ea eum quia. Qui aut vel blanditiis dolor fugit ullam. Sed nihil est molestiae
                                    nisi occaecati blanditiis.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="slide text-slide light-purple-background">
                        <div class="slide-inner">
                            <div class="content">
                                <div class="top">
                                    <!-- BEGIN PARTIAL: share-content-dropdown -->
                                    <!-- This file shared on multiple pages -->
                                    <div class="share-dropdown-menu">
                                        <button class="social-share-button">
                                            Share <i class="icon-arrow"></i>
                                        </button>
                                        <div class="share-menu">
                                            <span class="social-share">Share <i class="icon-arrow"></i></span>
                                            <ul>
                                                <li class="clearfix"><a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a> </li>
                                                <li class="clearfix"><a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a> </li>
                                                <li class="clearfix"><a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a> </li>
                                                <li class="clearfix"><a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a> </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- END PARTIAL: share-content-dropdown -->
                                    <!-- BEGIN PARTIAL: article-action-buttons -->
                                    <div class="article-actions buttons-container clearfix">
                                        <button class="icon-email">
                                            email</button>
                                        <button class="icon-plus">
                                            save this</button>
                                        <button class="icon-print">
                                            print</button>
                                        <button class="icon-bell">
                                            remind me</button>
                                    </div>
                                    <!-- END PARTIAL: article-action-buttons -->
                                    <div class="clearfix">
                                    </div>
                                </div>
                                <div class="slide-count-text">
                                    <span class="light-purple-span">3</span> of 9
                                </div>
                                <h3>Tempora Maiores Delectus Labore Quis Nihil</h3>
                                <p>
                                    Incidunt provident ipsum et culpa inventore velit quod et quia provident quos. Eaque
                                    quos facere id atque ea. Exercitationem qui dolor et voluptate amet quas optio provident
                                    sint quos. Eum laborum non enim dolor libero et maiores id fugiat sed. Corporis
                                    quod dolor autem corrupti neque dicta nihil quis dolorem deleniti dolores repellendus
                                    accusantium et. Iusto ut ipsa placeat vel expedita odit qui vero.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="slide text-slide purple-background">
                        <div class="slide-inner">
                            <div class="content">
                                <div class="top">
                                    <!-- BEGIN PARTIAL: share-content-dropdown -->
                                    <!-- This file shared on multiple pages -->
                                    <div class="share-dropdown-menu">
                                        <button class="social-share-button">
                                            Share <i class="icon-arrow"></i>
                                        </button>
                                        <div class="share-menu">
                                            <span class="social-share">Share <i class="icon-arrow"></i></span>
                                            <ul>
                                                <li class="clearfix"><a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a> </li>
                                                <li class="clearfix"><a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a> </li>
                                                <li class="clearfix"><a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a> </li>
                                                <li class="clearfix"><a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a> </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- END PARTIAL: share-content-dropdown -->
                                    <!-- BEGIN PARTIAL: article-action-buttons -->
                                    <div class="article-actions buttons-container clearfix">
                                        <button class="icon-email">
                                            email</button>
                                        <button class="icon-plus">
                                            save this</button>
                                        <button class="icon-print">
                                            print</button>
                                        <button class="icon-bell">
                                            remind me</button>
                                    </div>
                                    <!-- END PARTIAL: article-action-buttons -->
                                    <div class="clearfix">
                                    </div>
                                </div>
                                <div class="slide-count-text">
                                    <span class="purple-span">4</span> of 9
                                </div>
                                <h3>Reprehenderit Sunt Molestias Non Sunt Explicabo Similique</h3>
                                <p>
                                    Ea officiis qui maiores explicabo voluptas nobis laborum quas ut asperiores ea ut
                                    et. Et omnis mollitia repellendus voluptatibus dolor. Magnam autem ab consequatur.
                                    Nemo quisquam tempora illo fugiat perspiciatis exercitationem. Amet animi et assumenda
                                    sed magnam quae. Amet voluptas eum sed.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="slide text-slide light-blue-background">
                        <div class="slide-inner">
                            <div class="content">
                                <div class="top">
                                    <!-- BEGIN PARTIAL: share-content-dropdown -->
                                    <!-- This file shared on multiple pages -->
                                    <div class="share-dropdown-menu">
                                        <button class="social-share-button">
                                            Share <i class="icon-arrow"></i>
                                        </button>
                                        <div class="share-menu">
                                            <span class="social-share">Share <i class="icon-arrow"></i></span>
                                            <ul>
                                                <li class="clearfix"><a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a> </li>
                                                <li class="clearfix"><a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a> </li>
                                                <li class="clearfix"><a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a> </li>
                                                <li class="clearfix"><a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a> </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- END PARTIAL: share-content-dropdown -->
                                    <!-- BEGIN PARTIAL: article-action-buttons -->
                                    <div class="article-actions buttons-container clearfix">
                                        <button class="icon-email">
                                            email</button>
                                        <button class="icon-plus">
                                            save this</button>
                                        <button class="icon-print">
                                            print</button>
                                        <button class="icon-bell">
                                            remind me</button>
                                    </div>
                                    <!-- END PARTIAL: article-action-buttons -->
                                    <div class="clearfix">
                                    </div>
                                </div>
                                <div class="slide-count-text">
                                    <span class="light-blue-span">5</span> of 9
                                </div>
                                <h3>Blanditiis Omnis Necessitatibus Assumenda Et Facere Dolorem</h3>
                                <p>
                                    Mollitia ex molestiae beatae delectus possimus corrupti at modi aut. Sint est consequatur
                                    optio est voluptas dolorem eum a rerum velit quas consequatur. Quibusdam et voluptatibus
                                    facilis deserunt et qui neque at omnis voluptatem. Quidem et unde quo ex eos voluptatem.
                                    Voluptatibus quia ut laboriosam dolores ullam maiores debitis. Non quis aut vero
                                    fuga vel sit.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="slide text-slide blue-background">
                        <div class="slide-inner">
                            <div class="content">
                                <div class="top">
                                    <!-- BEGIN PARTIAL: share-content-dropdown -->
                                    <!-- This file shared on multiple pages -->
                                    <div class="share-dropdown-menu">
                                        <button class="social-share-button">
                                            Share <i class="icon-arrow"></i>
                                        </button>
                                        <div class="share-menu">
                                            <span class="social-share">Share <i class="icon-arrow"></i></span>
                                            <ul>
                                                <li class="clearfix"><a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a> </li>
                                                <li class="clearfix"><a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a> </li>
                                                <li class="clearfix"><a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a> </li>
                                                <li class="clearfix"><a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a> </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- END PARTIAL: share-content-dropdown -->
                                    <!-- BEGIN PARTIAL: article-action-buttons -->
                                    <div class="article-actions buttons-container clearfix">
                                        <button class="icon-email">
                                            email</button>
                                        <button class="icon-plus">
                                            save this</button>
                                        <button class="icon-print">
                                            print</button>
                                        <button class="icon-bell">
                                            remind me</button>
                                    </div>
                                    <!-- END PARTIAL: article-action-buttons -->
                                    <div class="clearfix">
                                    </div>
                                </div>
                                <div class="slide-count-text">
                                    <span class="blue-span">6</span> of 9
                                </div>
                                <h3>Est Pariatur Aut Ex Quo Aspernatur Quasi</h3>
                                <p>
                                    Officia aut nam qui placeat maiores voluptatum consequuntur provident exercitationem
                                    illo aliquid maxime. Qui eius et ut. Cupiditate aut ut cupiditate voluptas impedit.
                                    Voluptatem aut optio adipisci sint voluptatem ipsam sed et voluptatibus voluptatibus
                                    vero sint ipsum et. Quam eum explicabo mollitia aliquid ipsum facere doloribus occaecati
                                    vel occaecati dolore amet quam velit. Eum harum eaque minima recusandae.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="slide text-slide light-purple-background">
                        <div class="slide-inner">
                            <div class="content">
                                <div class="top">
                                    <!-- BEGIN PARTIAL: share-content-dropdown -->
                                    <!-- This file shared on multiple pages -->
                                    <div class="share-dropdown-menu">
                                        <button class="social-share-button">
                                            Share <i class="icon-arrow"></i>
                                        </button>
                                        <div class="share-menu">
                                            <span class="social-share">Share <i class="icon-arrow"></i></span>
                                            <ul>
                                                <li class="clearfix"><a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a> </li>
                                                <li class="clearfix"><a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a> </li>
                                                <li class="clearfix"><a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a> </li>
                                                <li class="clearfix"><a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a> </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- END PARTIAL: share-content-dropdown -->
                                    <!-- BEGIN PARTIAL: article-action-buttons -->
                                    <div class="article-actions buttons-container clearfix">
                                        <button class="icon-email">
                                            email</button>
                                        <button class="icon-plus">
                                            save this</button>
                                        <button class="icon-print">
                                            print</button>
                                        <button class="icon-bell">
                                            remind me</button>
                                    </div>
                                    <!-- END PARTIAL: article-action-buttons -->
                                    <div class="clearfix">
                                    </div>
                                </div>
                                <div class="slide-count-text">
                                    <span class="light-purple-span">7</span> of 9
                                </div>
                                <h3>Rerum Id In Veniam Dolorem Voluptates</h3>
                                <p>
                                    Consectetur magni laboriosam dolores laboriosam recusandae eius delectus ipsa. Quia
                                    optio et voluptatibus provident explicabo eos voluptatem dolores quasi earum impedit
                                    quis asperiores. Ullam iusto ea adipisci enim delectus. Ut quo cupiditate cum optio
                                    dolor sit est eligendi delectus ad numquam. Cum culpa pariatur quidem blanditiis.
                                    Dolor sed non autem.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="slide text-slide purple-background">
                        <div class="slide-inner">
                            <div class="content">
                                <div class="top">
                                    <!-- BEGIN PARTIAL: share-content-dropdown -->
                                    <!-- This file shared on multiple pages -->
                                    <div class="share-dropdown-menu">
                                        <button class="social-share-button">
                                            Share <i class="icon-arrow"></i>
                                        </button>
                                        <div class="share-menu">
                                            <span class="social-share">Share <i class="icon-arrow"></i></span>
                                            <ul>
                                                <li class="clearfix"><a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a> </li>
                                                <li class="clearfix"><a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a> </li>
                                                <li class="clearfix"><a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a> </li>
                                                <li class="clearfix"><a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a> </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- END PARTIAL: share-content-dropdown -->
                                    <!-- BEGIN PARTIAL: article-action-buttons -->
                                    <div class="article-actions buttons-container clearfix">
                                        <button class="icon-email">
                                            email</button>
                                        <button class="icon-plus">
                                            save this</button>
                                        <button class="icon-print">
                                            print</button>
                                        <button class="icon-bell">
                                            remind me</button>
                                    </div>
                                    <!-- END PARTIAL: article-action-buttons -->
                                    <div class="clearfix">
                                    </div>
                                </div>
                                <div class="slide-count-text">
                                    <span class="purple-span">8</span> of 9
                                </div>
                                <h3>Sapiente Quia Dolores Unde Soluta Eligendi Voluptatem</h3>
                                <p>
                                    Culpa corrupti et doloremque doloribus consequatur facilis. Voluptas veritatis voluptatum
                                    est in minus atque nostrum tempore. Autem et unde eligendi incidunt quidem reprehenderit
                                    corrupti non voluptas ex delectus placeat vel. Eligendi autem at laborum. Pariatur
                                    sit autem laborum quos rerum ea harum nihil eum aut. Et dolore ipsum perferendis
                                    non veniam necessitatibus.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="slide text-slide light-blue-background">
                        <div class="slide-inner">
                            <div class="content">
                                <div class="top">
                                    <!-- BEGIN PARTIAL: share-content-dropdown -->
                                    <!-- This file shared on multiple pages -->
                                    <div class="share-dropdown-menu">
                                        <button class="social-share-button">
                                            Share <i class="icon-arrow"></i>
                                        </button>
                                        <div class="share-menu">
                                            <span class="social-share">Share <i class="icon-arrow"></i></span>
                                            <ul>
                                                <li class="clearfix"><a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a> </li>
                                                <li class="clearfix"><a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a> </li>
                                                <li class="clearfix"><a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a> </li>
                                                <li class="clearfix"><a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a> </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- END PARTIAL: share-content-dropdown -->
                                    <!-- BEGIN PARTIAL: article-action-buttons -->
                                    <div class="article-actions buttons-container clearfix">
                                        <button class="icon-email">
                                            email</button>
                                        <button class="icon-plus">
                                            save this</button>
                                        <button class="icon-print">
                                            print</button>
                                        <button class="icon-bell">
                                            remind me</button>
                                    </div>
                                    <!-- END PARTIAL: article-action-buttons -->
                                    <div class="clearfix">
                                    </div>
                                </div>
                                <div class="slide-count-text">
                                    <span class="light-blue-span">9</span> of 9
                                </div>
                                <h3>Est Est Nihil Voluptas Dicta Sed</h3>
                                <p>
                                    Est asperiores excepturi aut quidem aperiam modi veritatis sequi consequuntur dolores
                                    reprehenderit aliquid alias. Eum vitae expedita nesciunt impedit et ea. Assumenda
                                    sunt molestiae quo aut quisquam beatae et quia quia recusandae voluptates. Temporibus
                                    repudiandae doloribus rem ea sit aut maiores cum et officia. Odio nam non debitis
                                    omnis in a ducimus placeat fugiat nihil veniam voluptates. Animi dolor voluptatem
                                    et eum voluptas.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="slide end">
                        <div class="slide-inner">
                            <h3>
                                <a href="#" class="restart-slideshow">&lt; See Slideshow from the Beginning</a>
                                or explore more:</h3>
                            <div class="thumbnail" style="background-image: url('http://placehold.it/380x220')">
                            </div>
                            <div class="text">
                                <h4>
                                    <a href="REPLACE">vitae optio ut rem consequuntur ducimus sequi</a></h4>
                                <p>
                                    et assumenda dolore laborum dignissimos iure cupiditate esse ut sed enim aliquam
                                    cupiditate voluptas minima
                                </p>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="thumbnail" style="background-image: url('http://placehold.it/380x220')">
                            </div>
                            <div class="text">
                                <h4>
                                    <a href="REPLACE">quidem quas et quaerat eveniet vero ut</a></h4>
                                <p>
                                    ut rerum quae nisi quas aliquid quis doloremque dolor maxime id explicabo consequatur
                                    est qui
                                </p>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                    </div> --%>
                </div>
                <div class="index-buttons-container">
                    <button class="button prev gray">
                        Prev</button>
                    <asp:ListView runat="server" ID="uxSliderButtonGroup">
                        <ItemTemplate>
                            <button class="button gray" data-target="<%# ((ListViewDataItem)Container).DisplayIndex + 1 %>">
                                <%# ((ListViewDataItem)Container).DisplayIndex + 1 %>
                            </button>
                        </ItemTemplate>
                    </asp:ListView>
                    <%--<button class="button gray" data-target="1">
                        1</button>
                    <button class="button gray" data-target="2">
                        2</button>
                    <button class="button gray" data-target="3">
                        3</button>
                    <button class="button gray" data-target="4">
                        4</button>
                    <button class="button gray" data-target="5">
                        5</button>
                    <button class="button gray" data-target="6">
                        6</button>
                    <button class="button gray" data-target="7">
                        7</button>
                    <button class="button gray" data-target="8">
                        8</button>
                    <button class="button gray" data-target="9">
                        9</button>--%>
                    <button class="button next gray">
                        Next</button>
                    <button class="button last gray">
                        Last</button>
                </div>
            </div>
            <!-- END PARTIAL: text-slides -->
        </div>
    </div>
</div>
<!-- .container -->
<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-19 offset-2">
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful content" id="count-helpful-content">
                <h4>Did you find this helpful?</h4>
                <ul>
                    <li>
                        <button class="button yes">
                            Yes</button>
                    </li>
                    <li>
                        <button class="button no gray">
                            No</button>
                    </li>
                </ul>
                <div class="clearfix">
                </div>
            </div>
            <!-- END PARTIAL: find-helpful -->
            <div class="find-this-helpful-small">
                <!-- Module within only appears in under 650px window width-->
                <!-- BEGIN PARTIAL: find-helpful -->
                <div class="find-this-helpful sidebar no-margin" id="count-helpful-sidebar">
                    <h4>Did you find this helpful?</h4>
                    <ul>
                        <li>
                            <button class="button yes">
                                Yes</button>
                        </li>
                        <li>
                            <button class="button no gray">
                                No</button>
                        </li>
                    </ul>
                    <div class="clearfix">
                    </div>
                </div>
                <!-- END PARTIAL: find-helpful -->
            </div>
            <div class="find-this-helpful-large" style="display: none;">
                <!-- Module within only appears in over 650px window width-->
            </div>
        </div>
    </div>
</div>
<!-- .container -->

