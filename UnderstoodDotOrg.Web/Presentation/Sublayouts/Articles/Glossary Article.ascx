<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Glossary Article.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Glossary_Article" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- END PARTIAL: pagetopic -->
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <div class="article-intro single">
                <!-- BEGIN PARTIAL: article-intro-text -->
                <div class="article-intro-text">
                    <p>
                        <%--This would be the intro text to the slideshow. It should run about 35 words. Lorem ipsum dolor sit amet, consectetur adipiscing elit vestibulum convallis risus id felis.--%>
                        <sc:FieldRenderer ID="frIntro" runat="server" FieldName="Introduction" />
                    </p>
                </div>
                <!-- END PARTIAL: article-intro-text -->
            </div>
            <!-- BEGIN PARTIAL: glossary-tabs -->
            <div id="glossary-tab">
                <ul>
                    <li class="glossary-tab-browse">
                        <a href="#glossary-browse">Browse by Letter
      </a>
                    </li>
                    <li class="glossary-tab-keyword">
                        <a href="#glossary-search">Search by Keyword
      </a>
                    </li>
                </ul>
                <div id="glossary-browse">
                    <%--<a href="#A" class="active">A</a>
                    <a href="#B">B</a>
                    <a href="#C">C</a>
                    <a href="#D">D</a>
                    <a href="#E">E</a>
                    <a href="#F">F</a>
                    <a href="#G">G</a>
                    <a href="#H">H</a>
                    <a href="#I">I</a>
                    <a href="#J">J</a>
                    <a href="#K">K</a>
                    <a href="#L">L</a>
                    <a href="#M">M</a>
                    <a href="#N">N</a>
                    <a href="#O">O</a>
                    <a href="#P">P</a>
                    <a href="#Q">Q</a>
                    <a href="#R">R</a>
                    <a href="#S">S</a>
                    <a href="#T">T</a>
                    <a href="#U">U</a>
                    <a href="#V">V</a>
                    <a href="#W">W</a>
                    <a href="#X">X</a>
                    <a href="#Y">Y</a>
                    <a href="#Z">Z</a> --%>
                    <asp:Repeater ID="rptAlphabet" runat="server" OnItemCommand="rptAlphabet_ItemCommand">
                        <ItemTemplate>
                            <a>
                                <asp:LinkButton ID="btnTermAnchor" runat="server"  CommandName="AlphabetClick">
                                    <%#Container.DataItem %>
                                </asp:LinkButton>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="glossary-search">
                    <label>
                        <input type="text" name="keyword" placeholder="Keyword">
                    </label>
                    <span>Find</span>
                </div>
            </div>
            <!-- END PARTIAL: glossary-tabs -->
            <!-- BEGIN PARTIAL: glossary -->
            <section class="glossary-listing">
                <asp:Repeater ID="rptTermCollection" runat="server" OnItemDataBound="rptTermCollection_ItemDataBound">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="glossary-container">
                            <a class="glossary-anchor"><%-- name="A">A--%>
                                <asp:LinkButton ID="btnTermAnchor" runat="server">
                                    <%#Container.DataItem %>
                                </asp:LinkButton>
                            </a>
                            <a class="back-to-top" href="#">Back to Top</a>
                        </div>
                        <asp:Repeater ID="rptListTermbyAnchor" runat="server" OnItemDataBound="rptListTermbyAnchor_ItemDataBound">
                            <HeaderTemplate></HeaderTemplate>
                            <ItemTemplate>
                                <div class="glossary-item">
                                    <h2><%--Academic Achievement Standards--%>
                                        <sc:FieldRenderer ID="frTermTitle" runat="server" FieldName="Glossary Term Title" />
                                    </h2>
                                    <p>
                                        <%--Curabitur porta nunc egestas pulvinar elementum. Nam sollicitudin nibh pharetra vehicula rhoncus. Sed tristique neque a metus molestie, eget suscipit massa consequat. Morbi fringilla rhoncus felis, ac fringilla dolor elementum et. Vestibulum--%>
                                        <sc:FieldRenderer ID="frTermDefinition" runat="server" FieldName="Glossary Term Definition" />
                                    </p>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </section>
            <%--
            <section class="glossary-listing">
                <div class="glossary-container">
                    <a class="glossary-anchor" name="A">A</a>
                    <a class="back-to-top" href="#">Back to Top</a>
                </div>
                <div class="glossary-item">
                    <h2>Academic Achievement Standards</h2>
                    <p>Curabitur porta nunc egestas pulvinar elementum. Nam sollicitudin nibh pharetra vehicula rhoncus. Sed tristique neque a metus molestie, eget suscipit massa consequat. Morbi fringilla rhoncus felis, ac fringilla dolor elementum et. Vestibulum</p>
                </div>
                <div class="glossary-item">
                    <h2>Academic Achievement Standards</h2>
                    <p>Curabitur porta nunc egestas pulvinar elementum. Nam sollicitudin nibh pharetra vehicula rhoncus. Sed tristique neque a metus molestie, eget suscipit massa consequat. Morbi fringilla rhoncus felis, ac fringilla dolor elementum et. Vestibulum</p>
                </div>

                <div class="glossary-container">
                    <a class="glossary-anchor" name="B">B</a>
                    <a class="back-to-top" href="#">Back to Top</a>
                </div>
                <div class="glossary-item">
                    <h2>Academic Achievement Standards</h2>
                    <p>Curabitur porta nunc egestas pulvinar elementum. Nam sollicitudin nibh pharetra vehicula rhoncus. Sed tristique neque a metus molestie, eget suscipit massa consequat. Morbi fringilla rhoncus felis, ac fringilla dolor elementum et. Vestibulum</p>
                </div>
                <div class="glossary-item">
                    <h2>Academic Achievement Standards</h2>
                    <p>Curabitur porta nunc egestas pulvinar elementum. Nam sollicitudin nibh pharetra vehicula rhoncus. Sed tristique neque a metus molestie, eget suscipit massa consequat. Morbi fringilla rhoncus felis, ac fringilla dolor elementum et. Vestibulum</p>
                </div>

                <div class="glossary-container">
                    <a class="glossary-anchor" name="C">C</a>
                    <a class="back-to-top" href="#">Back to Top</a>
                </div>
                <div class="glossary-item">
                    <h2>Academic Achievement Standards</h2>
                    <p>Curabitur porta nunc egestas pulvinar elementum. Nam sollicitudin nibh pharetra vehicula rhoncus. Sed tristique neque a metus molestie, eget suscipit massa consequat. Morbi fringilla rhoncus felis, ac fringilla dolor elementum et. Vestibulum</p>
                </div>
                <div class="glossary-item">
                    <h2>Academic Achievement Standards</h2>
                    <p>Curabitur porta nunc egestas pulvinar elementum. Nam sollicitudin nibh pharetra vehicula rhoncus. Sed tristique neque a metus molestie, eget suscipit massa consequat. Morbi fringilla rhoncus felis, ac fringilla dolor elementum et. Vestibulum</p>
                </div>

            </section> --%>

            <!-- END PARTIAL: glossary -->
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

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1">
            <!-- BEGIN PARTIAL: helpful-count -->
            <div class="count-helpful">
                <a href="REPLACE"><span>34</span>Found this helpful</a>
            </div>
            <!-- END PARTIAL: helpful-count -->
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful sidebar">

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
            <!-- BEGIN PARTIAL: keep-reading -->
            <div class="keep-reading">
                <h3>Keep Reading</h3>
                <ul>
                    <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
                    <li><a href="REPLACE">How to Build a Homework Plan</a></li>
                    <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
                </ul>
            </div>
            <!-- END PARTIAL: keep-reading -->
            <!-- BEGIN PARTIAL: sidebar-promos -->
            <div class="sidebar-promos">
                <div class="promo purple-dark">
                    <a href="REPLACE">
                        <span>Get advice</span>
                        <i class="icon-arrow-promo"></i>
                    </a>
                </div>
                <!-- end promo -->

                <div class="promo purple-light">
                    <a href="REPLACE">
                        <span>Find Technology that can Help</span>
                        <i class="icon-arrow-promo"></i>
                    </a>
                </div>
                <!-- end promo -->

                <div class="promo blue">
                    <a href="REPLACE">
                        <span>Navigating Your Child's Healthcare Needs</span>
                        <i class="icon-arrow-promo"></i>
                    </a>
                </div>
                <!-- end promo -->
            </div>
            <!-- end sidebar-promos -->

            <!-- END PARTIAL: sidebar-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
