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
                <div id="glossary-browse" id="top">
                    <asp:Repeater ID="rptAlphabet" runat="server" OnItemCommand="rptAlphabet_ItemCommand">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnTermAnchor" runat="server" CommandName="AlphabetClick" CommandArgument="<%#Container.DataItem%>">
                                    <%#Container.DataItem %>
                                </asp:LinkButton>
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
                             <a class="glossary-anchor" name="<%#Container.DataItem %>">
                              <%#Container.DataItem %>
                            </a>
                            <a class="back-to-top" href="#top">Back to Top</a>
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


            <!-- END PARTIAL: glossary -->
            <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" Visible="false" />

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
        <div class="col col-5 offset-1 skiplink-sidebar rs_read_this">
            
            <sc:Sublayout ID="Sublayout1" Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulCountOnlySideColumn.ascx" runat="server"></sc:Sublayout>

            <!-- BEGIN PARTIAL: find-helpful -->
            <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" runat="server"></sc:Sublayout>
            <!-- END PARTIAL: find-helpful -->
            <!-- BEGIN PARTIAL: keep-reading -->

            <div class="keep-reading keep-reading-lg">
                <sc:Sublayout ID="slKeepReading" runat="server" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
            </div>
            <!-- END PARTIAL: keep-reading -->
            <!-- BEGIN PARTIAL: sidebar-promos -->
            <div class="sidebar-promos rs_read_this vertical">
                <sc:Sublayout ID="sbSidebarPromo" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/Promotionals List.ascx" />
            </div>

            <!-- end sidebar-promos -->

            <!-- END PARTIAL: sidebar-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
