<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SlideshowArticle.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.SlideshowArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="count-mobile">
    <!-- BEGIN PARTIAL: helpful-count -->
    <div class="count-helpful">
        <a href="REPLACE"><span>34</span>Found this helpful</a>
    </div>
    <!-- END PARTIAL: helpful-count -->
</div>
<div class="container article-intro">
    <div class="row">
        <!-- helpful count -->
        <div class="col col-8 article-intro-count">
            <!-- BEGIN PARTIAL: helpful-count -->
            <div class="count-helpful">
                <a href="REPLACE"><span>34</span>Found this helpful</a>
            </div>
            <!-- END PARTIAL: helpful-count -->
        </div>

        <!-- intro-text -->
        <div class="col col-14 offset-1">
            <!-- BEGIN PARTIAL: article-intro-text -->
            <div class="article-intro-text">
                <p>
                    <%--This would be the intro text to the slideshow. It should run about 35 words. Lorem ipsum dolor sit amet, consectetur adipiscing elit vestibulum convallis risus id felis.--%>
                    <sc:FieldRenderer ID="frIntroText" runat="server" FieldName="Body Content" />
                </p>
            </div>
            <!-- END PARTIAL: article-intro-text -->
        </div>

    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container article slideshow">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: article-slideshow -->
            <div class="article-slideshow-container">
                <div id="article-slideshow" class="rsDefault slide-show-border" data-random="false">
                    <asp:Repeater ID="rptSlides" runat="server" OnItemDataBound="rptSlides_ItemDataBound">
                        <HeaderTemplate></HeaderTemplate>
                        <ItemTemplate>
                            <!-- BEGIN PARTIAL: article-slideshow-slide -->
                            <asp:Panel ID="pnlSlide" runat="server" CssClass="slide">
                                <%-- OR <div class="slide tall-image"> --%>
                                <div class="slide-inner">
                                    <asp:PlaceHolder ID="phImageSlide" Visible="false" runat="server">
                                        <%-- Slide Image --%>
                                        <sc:FieldRenderer ID="frSlideImage" runat="server" FieldName="Slide Image" />
                                        <div class="content">
                                            <div class="top">
                                                <div class="slide-count">
                                                    <%--Slide 2 of 10--%>
                                                    Slide <asp:Label ID="lblCurrentSlide" runat="server"></asp:Label> of <asp:Label ID="lblTotalSlide" runat="server"></asp:Label>
                                                </div>
                                                <div class="share-container">
                                                    <span>Share <i class="arrow"></i></span>
                                                    <div class="share-menu">
                                                        <span>Share <i class="arrow"></i></span>
                                                        <ul>
                                                            <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                            <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                            <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                            <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                <div class="buttons-container">
                                                    <i class="icon-email"></i>
                                                    <i class="icon-plus"></i>
                                                    <i class="icon-print"></i>
                                                    <i class="icon-bell"></i>
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                            <%-- slide Intro--%>
                                            <sc:FieldRenderer ID="frSlideTitle" runat="server" FieldName="Slide Title" />
                                            <sc:FieldRenderer ID="frSlideInto" runat="server" FieldName="Slide Text" />
                                        </div>
                                        <div class="clearfix"></div>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phEnd" Visible="false" runat="server">
                                        <%--  Show Other two SideShow Article Item to start--%>
                                        <h3><a href="#" class="restart-slideshow">&lt; See Slideshow from the Beginning</a> or explore more:</h3>
                                        <div class="thumbnail" style="background-image: url('http://placehold.it/380x220')"></div>
                                        <div class="text">
                                            <h4><a href="REPLACE">facere molestiae eligendi maiores quis voluptatum qui</a></h4>
                                            <p>aspernatur ut impedit voluptatibus aperiam consequatur molestiae autem et eum perferendis provident sunt deleniti asperiores</p>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="thumbnail" style="background-image: url('http://placehold.it/380x220')"></div>
                                        <div class="text">
                                            <h4><a href="REPLACE">nihil et et nulla qui molestias distinctio</a></h4>
                                            <p>praesentium voluptates odio expedita alias deleniti aut maiores accusamus consequatur vitae asperiores sunt omnis eius</p>
                                        </div>
                                        <div class="clearfix"></div>
                                    </asp:PlaceHolder>
                                </div>
                            </asp:Panel>
                            <!-- END PARTIAL: article-slideshow-slide -->

                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>

                    <%--    <!-- BEGIN PARTIAL: article-slideshow-slide -->
                    <div class="slide wide-image">
                        <div class="slide-inner">
                            <img src="http://placehold.it/1740x980" alt="REPLACE" />
                            <div class="content">
                                <div class="top">
                                    <div class="slide-count">Slide 1 of 10</div>
                                    <div class="share-container">
                                        <span>Share <i class="arrow"></i></span>
                                        <div class="share-menu">
                                            <span>Share <i class="arrow"></i></span>
                                            <ul>
                                                <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="buttons-container">
                                        <i class="icon-email"></i>
                                        <i class="icon-plus"></i>
                                        <i class="icon-print"></i>
                                        <i class="icon-bell"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <h3>Nisi Est Id Adipisci Et Rerum</h3>
                                <p>
                                    Reiciendis non omnis culpa earum unde et.
      
        Voluptatem commodi libero eum hic quibusdam est harum alias reiciendis sunt in tenetur.
      
        Ea enim incidunt ipsam voluptate unde doloribus quae et est earum veniam.
      
        Inventore autem eaque rerum perspiciatis.
      
        Autem maiores aut qui et voluptatem tempora consequatur id nobis quia dolorem quo vero.
      
        Iure aut alias repellendus ab reiciendis modi et.
      
     
                                </p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <!-- END PARTIAL: article-slideshow-slide -->

                    <!-- BEGIN PARTIAL: article-slideshow-slide -->
                    <div class="slide wide-image">
                        <div class="slide-inner">

                            <img src="http://placehold.it/1740x980" alt="REPLACE" />
                            <div class="content">
                                <div class="top">
                                    <div class="slide-count">Slide 2 of 10</div>
                                    <div class="share-container">
                                        <span>Share <i class="arrow"></i></span>
                                        <div class="share-menu">
                                            <span>Share <i class="arrow"></i></span>
                                            <ul>
                                                <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="buttons-container">
                                        <i class="icon-email"></i>
                                        <i class="icon-plus"></i>
                                        <i class="icon-print"></i>
                                        <i class="icon-bell"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <h3>Qui At Accusantium Eveniet Et</h3>
                                <p>
                                    Nulla aspernatur qui doloremque tempora nihil placeat ratione tempora nobis sunt voluptatum molestias.
      
        Esse eligendi corrupti nesciunt.
      
        Et explicabo sed nesciunt ad voluptatum libero id voluptatem.
      
        Vero deleniti enim reiciendis consequatur omnis rem voluptas in dolor.
      
        Aut sit dolorem repellat similique consequatur.
      
        Porro ipsum sunt in quis qui esse et at.
      
     
                                </p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <!-- END PARTIAL: article-slideshow-slide -->

                    <!-- BEGIN PARTIAL: article-slideshow-slide -->
                    <div class="slide tall-image">
                        <div class="slide-inner">
                            <img src="http://placehold.it/980x1740" alt="REPLACE" />
                            <div class="content">
                                <div class="top">
                                    <div class="slide-count">Slide 3 of 10</div>
                                    <div class="share-container">
                                        <span>Share <i class="arrow"></i></span>
                                        <div class="share-menu">
                                            <span>Share <i class="arrow"></i></span>
                                            <ul>
                                                <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="buttons-container">
                                        <i class="icon-email"></i>
                                        <i class="icon-plus"></i>
                                        <i class="icon-print"></i>
                                        <i class="icon-bell"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <h3>Sint Rerum Est Consequatur Amet Omnis Unde Accusamus</h3>
                                <p>
                                    Ullam ipsum non cumque sed quia numquam quisquam est voluptatum saepe possimus iure.
      
        Voluptas tempora enim odit omnis voluptas.
      
        Unde ipsam eos sed ut molestiae.
      
        Eaque illo et error dicta aut architecto quos sed facere.
      
        Rerum reiciendis itaque nostrum.
      
        Vero praesentium magnam officiis sunt sed et.
      
     
                                </p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <!-- END PARTIAL: article-slideshow-slide -->

                    <!-- BEGIN PARTIAL: article-slideshow-slide -->
                    <div class="slide wide-image">
                        <div class="slide-inner">

                            <img src="http://placehold.it/1740x980" alt="REPLACE" />
                            <div class="content">
                                <div class="top">
                                    <div class="slide-count">Slide 4 of 10</div>
                                    <div class="share-container">
                                        <span>Share <i class="arrow"></i></span>
                                        <div class="share-menu">
                                            <span>Share <i class="arrow"></i></span>
                                            <ul>
                                                <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="buttons-container">
                                        <i class="icon-email"></i>
                                        <i class="icon-plus"></i>
                                        <i class="icon-print"></i>
                                        <i class="icon-bell"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <h3>Veniam Rerum Et Occaecati Ab Consequatur Totam Ratione</h3>
                                <p>
                                    Illo doloremque explicabo sed omnis.
      
        Sint et sed neque enim accusamus nesciunt aut in autem velit ea perferendis quod.
      
        Aut tempora commodi voluptatem animi non.
      
        Delectus praesentium ea facere libero odit molestiae iusto beatae esse et a voluptate voluptas dolorum.
      
        Quasi quasi sunt magni provident aut sit inventore vel.
      
        Itaque praesentium voluptates aut dolores ipsam et iste perspiciatis sint numquam laboriosam quia aut eaque.
      
     
                                </p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <!-- END PARTIAL: article-slideshow-slide -->

                    <!-- BEGIN PARTIAL: article-slideshow-slide -->
                    <div class="slide wide-image">
                        <div class="slide-inner">

                            <img src="http://placehold.it/1740x980" alt="REPLACE" />
                            <div class="content">
                                <div class="top">
                                    <div class="slide-count">Slide 5 of 10</div>
                                    <div class="share-container">
                                        <span>Share <i class="arrow"></i></span>
                                        <div class="share-menu">
                                            <span>Share <i class="arrow"></i></span>
                                            <ul>
                                                <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="buttons-container">
                                        <i class="icon-email"></i>
                                        <i class="icon-plus"></i>
                                        <i class="icon-print"></i>
                                        <i class="icon-bell"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <h3>Odit Error Ut Ut Sequi Qui Molestiae Impedit</h3>
                                <p>
                                    Et magnam quibusdam aut cupiditate dicta dolorum a ut.
      
        Ut recusandae quod quam.
      
        Accusamus dolorem asperiores nulla ex aut sit nesciunt.
      
        Sunt illo in culpa debitis quod iste in.
      
        Aut officiis doloremque velit a laudantium sit tempora placeat adipisci.
      
        Porro ipsa neque suscipit sed praesentium ut perspiciatis neque ut.
      
     
                                </p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <!-- END PARTIAL: article-slideshow-slide -->

                    <!-- BEGIN PARTIAL: article-slideshow-slide -->
                    <div class="slide tall-image">
                        <div class="slide-inner">

                            <img src="http://placehold.it/980x1740" alt="REPLACE" />
                            <div class="content">
                                <div class="top">
                                    <div class="slide-count">Slide 6 of 10</div>
                                    <div class="share-container">
                                        <span>Share <i class="arrow"></i></span>
                                        <div class="share-menu">
                                            <span>Share <i class="arrow"></i></span>
                                            <ul>
                                                <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="buttons-container">
                                        <i class="icon-email"></i>
                                        <i class="icon-plus"></i>
                                        <i class="icon-print"></i>
                                        <i class="icon-bell"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <h3>Laudantium Hic Ut Non Ipsam</h3>
                                <p>
                                    Sint officia magni laudantium.
      
        Sed labore excepturi laborum mollitia repellat.
      
        Quia nulla officiis recusandae ullam tenetur nesciunt consequuntur sit.
      
        Exercitationem tempore adipisci consectetur.
      
        In illo corporis similique dolor unde unde eaque dolores ut aut aliquid voluptas aut dolor.
      
        At praesentium aspernatur praesentium doloribus esse pariatur ut fugiat aut et ullam.
      
     
                                </p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <!-- END PARTIAL: article-slideshow-slide -->

                    <!-- BEGIN PARTIAL: article-slideshow-slide -->
                    <div class="slide wide-image">
                        <div class="slide-inner">

                            <img src="http://placehold.it/1740x980" alt="REPLACE" />
                            <div class="content">
                                <div class="top">
                                    <div class="slide-count">Slide 7 of 10</div>
                                    <div class="share-container">
                                        <span>Share <i class="arrow"></i></span>
                                        <div class="share-menu">
                                            <span>Share <i class="arrow"></i></span>
                                            <ul>
                                                <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="buttons-container">
                                        <i class="icon-email"></i>
                                        <i class="icon-plus"></i>
                                        <i class="icon-print"></i>
                                        <i class="icon-bell"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <h3>Iste Sed Et Ut Dolor Rerum Qui</h3>
                                <p>
                                    Ut temporibus modi omnis nulla voluptatibus.
      
        Rerum culpa voluptatem eum tenetur atque illum.
      
        Nihil quia reiciendis aliquid velit.
      
        Quas sit aspernatur excepturi velit voluptate ut rem molestiae quia laudantium consectetur sunt.
      
        Velit eius sit possimus et ipsa voluptatem quasi neque.
      
        Aut ut assumenda dicta.
      
     
                                </p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <!-- END PARTIAL: article-slideshow-slide -->

                    <!-- BEGIN PARTIAL: article-slideshow-slide -->
                    <div class="slide wide-image">
                        <div class="slide-inner">

                            <img src="http://placehold.it/1740x980" alt="REPLACE" />
                            <div class="content">
                                <div class="top">
                                    <div class="slide-count">Slide 8 of 10</div>
                                    <div class="share-container">
                                        <span>Share <i class="arrow"></i></span>
                                        <div class="share-menu">
                                            <span>Share <i class="arrow"></i></span>
                                            <ul>
                                                <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="buttons-container">
                                        <i class="icon-email"></i>
                                        <i class="icon-plus"></i>
                                        <i class="icon-print"></i>
                                        <i class="icon-bell"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <h3>Itaque Aut Neque Dolores Suscipit Vero Quia</h3>
                                <p>
                                    Itaque voluptate est excepturi aliquid quibusdam est est quia beatae.
      
        Et sint nam omnis.
      
        Qui et pariatur eos laborum quia unde aut.
      
        Deleniti nesciunt consequatur vero non et veritatis.
      
        Quidem alias itaque ea deserunt aut in eos.
      
        Deleniti perferendis veniam quis.
      
     
                                </p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <!-- END PARTIAL: article-slideshow-slide -->

                    <!-- BEGIN PARTIAL: article-slideshow-slide -->
                    <div class="slide tall-image">
                        <div class="slide-inner">

                            <img src="http://placehold.it/980x1740" alt="REPLACE" />
                            <div class="content">
                                <div class="top">
                                    <div class="slide-count">Slide 9 of 10</div>
                                    <div class="share-container">
                                        <span>Share <i class="arrow"></i></span>
                                        <div class="share-menu">
                                            <span>Share <i class="arrow"></i></span>
                                            <ul>
                                                <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="buttons-container">
                                        <i class="icon-email"></i>
                                        <i class="icon-plus"></i>
                                        <i class="icon-print"></i>
                                        <i class="icon-bell"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <h3>Consectetur Officia Saepe Illo Quis</h3>
                                <p>
                                    Magni aliquam facilis perferendis in deleniti.
      
        Ipsam cumque provident quam quo et assumenda sit.
      
        Dolore reprehenderit omnis sunt nostrum sint aliquam atque at aspernatur nobis magnam.
      
        Ipsam aut odio nihil nostrum cum dicta.
      
        Temporibus consectetur nesciunt et aut consectetur minus sapiente odio libero quia rerum iure.
      
        Quisquam optio fugit quia.
      
     
                                </p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <!-- END PARTIAL: article-slideshow-slide -->

                    <!-- BEGIN PARTIAL: article-slideshow-slide -->
                    <div class="slide wide-image">
                        <div class="slide-inner">

                            <img src="http://placehold.it/1740x980" alt="REPLACE" />
                            <div class="content">
                                <div class="top">
                                    <div class="slide-count">Slide 10 of 10</div>
                                    <div class="share-container">
                                        <span>Share <i class="arrow"></i></span>
                                        <div class="share-menu">
                                            <span>Share <i class="arrow"></i></span>
                                            <ul>
                                                <li><a href="REPLACE" class="facebook"><i class="facebook"></i>Facebook</a></li>
                                                <li><a href="REPLACE" class="twitter"><i class="twitter"></i>Twitter</a></li>
                                                <li><a href="REPLACE" class="google"><i class="google"></i>Google +</a></li>
                                                <li><a href="REPLACE" class="pinterest"><i class="pinterest"></i>Pinterest</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="buttons-container">
                                        <i class="icon-email"></i>
                                        <i class="icon-plus"></i>
                                        <i class="icon-print"></i>
                                        <i class="icon-bell"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <h3>Quo Sed Dolorem A Quibusdam Et</h3>
                                <p>
                                    Incidunt fugiat ipsa blanditiis maxime nam ut maxime aliquid ut eligendi.
      
        At voluptas amet soluta sint aut aut necessitatibus consequatur ducimus.
      
        Nihil quae qui repellendus facere eligendi libero sint officiis aut.
      
        Odio quia dolores laborum laboriosam modi rerum rem rerum.
      
        Laboriosam vitae qui sequi impedit voluptates similique quaerat non.
      
        Illum vitae quo pariatur libero veritatis rerum.
      
     
                                </p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <!-- END PARTIAL: article-slideshow-slide -->


                    <div class="slide end">
                        <div class="slide-inner">
                            <h3><a href="#" class="restart-slideshow">&lt; See Slideshow from the Beginning</a> or explore more:</h3>
                            <div class="thumbnail" style="background-image: url('http://placehold.it/380x220')"></div>
                            <div class="text">
                                <h4><a href="REPLACE">facere molestiae eligendi maiores quis voluptatum qui</a></h4>
                                <p>aspernatur ut impedit voluptatibus aperiam consequatur molestiae autem et eum perferendis provident sunt deleniti asperiores</p>
                            </div>
                            <div class="clearfix"></div>
                            <div class="thumbnail" style="background-image: url('http://placehold.it/380x220')"></div>
                            <div class="text">
                                <h4><a href="REPLACE">nihil et et nulla qui molestias distinctio</a></h4>
                                <p>praesentium voluptates odio expedita alias deleniti aut maiores accusamus consequatur vitae asperiores sunt omnis eius</p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>  --%>
                </div>

                <div class="index-buttons-container">
                    <div class="button prev">
                        Prev
                       
                    </div>

                    <div class="button" data-target="1">1</div>

                    <div class="button" data-target="2">2</div>

                    <div class="button" data-target="3">3</div>

                    <div class="button" data-target="4">4</div>

                    <div class="button" data-target="5">5</div>

                    <div class="button" data-target="6">6</div>

                    <div class="button" data-target="7">7</div>

                    <div class="button" data-target="8">8</div>

                    <div class="button" data-target="9">9</div>

                    <div class="button" data-target="10">10</div>

                    <%--<div class="button prev mobile">Prev</div>--%>
                    <div class="button next">
                        Next
                     

                    </div>
                    <%-- To Jump On Last slide - Two Suggesion --%>
                    <div class="button last">
                        Last
                        
                    </div>

                </div>
            </div>
            <%-- Show Reviewer Info only on Last suggested article slide --%>
            <div class="slideshow-review">
                <div class="container">
                    <div class="row">
                        <div class="col col-15 offset-2">
                            <!-- BEGIN PARTIAL: reviewed-by -->
                            <p class="reviewed-by">
                                <span class="reviewed-by-title">Reviewed&nbsp;by</span> <span class="reviewed-by-author">
                                    <%--<a href="REPLACE">Dr. Samantha Frank</a>--%>
                                    <sc:Link ID="lnkReviewedBy" runat="server" Field="Revierwer Name">
                                    </sc:Link>
                                    <asp:HyperLink ID="HyplnkReviewedBy" runat="server"></asp:HyperLink>
                                </span><span class="dot"></span><span class="reviewed-by-date">
                                    <%--12&nbsp;Dec&nbsp;&apos;13 --%>
                                    <sc:Date ID="dtReviewdDate" Field="Reviewed Date" runat="server" Format="dd MMM yy" />
                                </span>
                            </p>
                            <!-- END PARTIAL: reviewed-by -->
                        </div>
                    </div>
                </div>
            </div>
            <!-- END PARTIAL: article-slideshow -->
        </div>
    </div>
</div>
<!-- .container -->

<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-19 offset-2">
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful content">

                <h4>Did you find this helpful?</h4>
                <ul>
                    <li>
                        <button class="helpful-yes">Yes</button>
                    </li>
                    <li>
                        <button class="helpful-no">No</button>
                    </li>
                </ul>
                <div class="clearfix"></div>

            </div>
            <!-- END PARTIAL: find-helpful -->
        </div>
    </div>
</div>
<!-- .container -->




