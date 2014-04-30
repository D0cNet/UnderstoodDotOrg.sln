<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Advocacy Article Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy.Advocacy_Article_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container page-topic advocacy-pagetopic advocacy-article-rs-wrapper">
    <div class="row">
        <div class="col col-14 offset-1">

            <a href="REPLACE" class="back-to-previous"><i class="icon-arrow-left-blue"></i>Back to Action Center</a>

            <div>
                <h1 class="rs_read_this"><%--Multi-Tier System of Supports/ Response to Intervention--%>
                    <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                </h1>

                <p class="page-subtitle hidden">Lorem ipsum dolor sit amet, consectetur adipiscing elit nulla egestas</p>

            </div>
        </div>


        <div class="col col-8 partner-image-column">
            <span class="powered-by">Powered by</span>
            <asp:HyperLink ID="hlPartnerLogo" runat="server">
                <sc:FieldRenderer ID="frPartnerLogo" runat="server" FieldName="Logo" />
            </asp:HyperLink>
            <%--<a href="REPLACE" class="partner-image">
                <img src="http://placehold.it/210x55">
            </a>
                 <a href="REPLACE" class="partner-text">National Center for Learning Disabilities
            </a>
            <div class="share-save-pagetopic"></div>--%>
        </div>



        <%--<div class="col col-9">
            <!-- BEGIN PARTIAL: share-save -->
            <div class="share-save-container">
                <div class="share-save-social-icon">
                    <div class="toggle">
                        <a href="REPLACE" class="socicon icon-facebook">Facebook</a><br />
                        <a href="REPLACE" class="socicon icon-twitter">Twitter</a><br />
                        <a href="REPLACE" class="socicon icon-googleplus">Google&#43;</a><br />
                        <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
                    </div>
                </div>
                <div class="share-save-icon">
                    <h3>Share &amp; Save</h3>
                    <!-- leave no white space for layout consistency -->
                    <a href="REPLACE" class="icon icon-share">Share</a><span class="tools"><a href="REPLACE" class="icon icon-email">Email</a><a href="REPLACE" class="icon icon-save">Save</a><a href="REPLACE" class="icon icon-print">Print</a><a href="REPLACE" class="icon icon-remind">Remind</a><a href="REPLACE" class="icon icon-rss">RSS</a></span>
                </div>
            </div>

            <!-- END PARTIAL: share-save -->
        </div> --%>


    </div>
</div>
<!-- .container -->

<!-- END PARTIAL: pagetopic -->
<div class="container l-advocacy-article">
    <div class="row">
        <div class="col col-24 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: advocacy/advocacy-article -->
            <div class="advocacy-article">
                <div class="rs_read_this advocacy-article-rs-wrapper">
                    <section class="article-header clearfix">
                        <div class="col col-9 push-15">
                            <%--<img width="100%" src="http://placehold.it/351x200" /> --%>
                            <sc:FieldRenderer ID="frThumbnailImage" runat="server" FieldName="Thumbnail Image" />
                            <div class="clearfix">
                                <!-- BEGIN PARTIAL: share-save -->
                                <sc:Placeholder ID="Placeholder1" Key="ShareNSave" runat="server" />
                                <%--<sc:Sublayout ID="sbShareNSave" runat="server" Visible="true" Parameters="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" /> --%>
                                <%--<div class="share-save-container">
                                    <div class="share-save-social-icon">
                                        <div class="toggle">
                                            <a href="REPLACE" class="socicon icon-facebook">Facebook</a><br />
                                            <a href="REPLACE" class="socicon icon-twitter">Twitter</a><br />
                                            <a href="REPLACE" class="socicon icon-googleplus">Google&#43;</a><br />
                                            <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
                                        </div>
                                    </div>
                                    <div class="share-save-icon">
                                        <h3>Share &amp; Save</h3>
                                        <!-- leave no white space for layout consistency -->
                                        <a href="REPLACE" class="icon icon-share">Share</a><span class="tools"><a href="REPLACE" class="icon icon-email">Email</a><a href="REPLACE" class="icon icon-save">Save</a><a href="REPLACE" class="icon icon-print">Print</a><a href="REPLACE" class="icon icon-remind">Remind</a><a href="REPLACE" class="icon icon-rss">RSS</a></span>
                                    </div>
                                </div> --%>

                                <!-- END PARTIAL: share-save -->
                            </div>
                        </div>

                        <div class="col col-14 pull-9">
                            <p>
                                <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />
                                <%--Nulla velit quod saepe voluptates ut. repellat perspiciatis voluptatum assumenda iure quae. eaque atque incidunt perspiciatis placeat. et ea occaecati quam aut aut est rerum dolor voluptatem omnis laborum natus quis iusto. id delectus aut delectus laboriosam inventore
        Cumque nam et ratione voluptatum nobis et natus ut id exercitationem doloribus officia. voluptas quae eum occaecati dolores nisi rem voluptates quia. excepturi numquam ratione suscipit minima aut nisi esse est ab. tempore optio corrupti aut sunt dolorem est et reiciendis debitis quasi quia dignissimos. labore quidem cumque rerum maiores et alias illo dignissimos sequi sed
        Molestiae dolores non doloremque autem. in saepe nihil commodi soluta fugiat aut cum sit at iste. consectetur asperiores ut occaecati ducimus cumque officia beatae voluptatum omnis tempore recusandae ipsam ut. aut quo nesciunt debitis--%>
                            </p>
                        </div>

                    </section>

                    <section class="article-callout">
                        <asp:Repeater ID="rptArticleCallouts" runat="server" OnItemDataBound="rptArticleCallouts_ItemDataBound">
                            <ItemTemplate>
                                <div class="article-callout-item">
                                    <h3 class="article-callout-title"><%--adipisci non possimus voluptas possimus possimus repellendus--%>
                                        <sc:FieldRenderer ID="frCalloutTitle" runat="server" FieldName="Content Title" />
                                    </h3>
                                    <p>
                                        <%--Quo quis eum quas libero est nihil earum culpa rem. hic voluptatem sequi tenetur reiciendis autem neque aperiam quis perferendis eaque. asperiores nulla quo omnis dolor sint in explicabo exercitationem facere vero ut et. minus in id aut doloremque dolore velit ipsa praesentium magni pariatur nemo vero soluta. ea ut id cumque itaque facilis unde corrupti. laudantium vel deleniti fugiat repudiandae nulla est perspiciatis explicabo ut. praesentium dignissimos amet repudiandae asperiores hic consectetur ducimus--%>
                                        <sc:FieldRenderer ID="frCalloutDescription" runat="server" FieldName="Content Description" />
                                    </p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <%-- <div class="article-callout-item">
        <h3 class="article-callout-title">sunt earum soluta laboriosam aut nihil repellendus</h3>
        <p>Placeat aut dicta aut eaque quasi est officia. totam deleniti ut rerum dolorem doloremque. perspiciatis nulla expedita sed velit quis iste excepturi omnis labore ratione sit occaecati ut. quis repellat nihil perspiciatis vitae beatae dolorum nesciunt sed. neque consequuntur molestiae sed possimus voluptas sed molestiae nesciunt libero dolore impedit doloribus</p>
      </div>
      <div class="article-callout-item">
        <h3 class="article-callout-title">non id aspernatur nihil odio aut earum</h3>
        <p>Dicta natus eos architecto dolorem eos quidem nobis ut rerum repudiandae in. amet cum voluptas delectus consectetur quas aperiam et. non ratione ut nulla ut qui voluptatem. ut nostrum qui et corrupti est animi porro sequi doloremque labore rerum itaque tempora expedita</p>
      </div>--%>
                    </section>
                </div>

                <section class="article-call-to-action">
                    <!-- BEGIN PARTIAL: sidebar-promos -->
                    <div class="sidebar-promos rs_read_this horizontal">
                        <div class="promo purple-dark">
                            <asp:Button ID="btnLink1" runat="server" OnClick="btnLink1_Click" />
                            <i class="icon-arrow-promo"></i>

                            <%--<a href="REPLACE">
                                <span>Email an Editor</span>
                                <i class="icon-arrow-promo"></i>
                            </a>--%>
                        </div>
                        <!-- end promo -->

                        <div class="promo purple-light">
                            <asp:Button ID="btnLink2" runat="server" OnClick="btnLink2_Click" />
                            <i class="icon-arrow-promo"></i>
                            <%--<a href="REPLACE">
                                <span>Write to Congress</span>
                                <i class="icon-arrow-promo"></i>
                            </a>--%>
                        </div>
                        <!-- end promo -->

                        <div class="promo blue">
                            <asp:Button ID="btnLink3" runat="server" OnClick="btnLink3_Click" />
                            <%--<a href="REPLACE">
                                <span>Sign a Petition</span>
                                <i class="icon-arrow-promo"></i>
                            </a>--%>
                        </div>
                        <!-- end promo -->
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

