<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeepDiveArticle.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.DeepDiveArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <div class="count-mobile">
                <!-- BEGIN PARTIAL: helpful-count -->
                <div class="count-helpful">
                    <a href="REPLACE"><span>34</span>Found this helpful</a>
                </div>
                <!-- END PARTIAL: helpful-count -->
                <!-- BEGIN PARTIAL: comments-count -->
                <div class="count-comments">
                    <a href="REPLACE"><span>19</span>Comments</a>
                </div>
                <!-- END PARTIAL: comments-count -->
            </div>
            <!-- BEGIN PARTIAL: whats-covered -->
            <div class="whats-covered">
                <h2><%--What&rsquo;s covered--%>
                    <sc:FieldRenderer ID="frContentBody" runat="server" FieldName="Body Content" />
                </h2>
                <asp:Repeater ID="rptSectionList" runat="server" OnItemDataBound="rptSectionList_ItemDataBound">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <ul>
                            <li>
                                <asp:HyperLink ID="hlSectionTitle" runat="server">
                                    <sc:FieldRenderer runat="server" ID="frSectionTitle" FieldName="Title" />
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
                <%--<ul>
    <li><a href="REPLACE">IEP Basics</a></li>
    <li><a href="REPLACE">What is in an IEP?</a></li>
    <li><a href="REPLACE">Who makes an IEP?</a></li>
    <li><a href="REPLACE">What is the Parent&rsquo;s Role?</a></li>
    <li><a href="REPLACE">IEP Basics</a></li>
    <li><a href="REPLACE">What is in an IEP?</a></li>
    <li><a href="REPLACE">Who makes an IEP?</a></li>
    <li><a href="REPLACE">What is the Parent&rsquo;s Role?</a></li>
  </ul> --%>
            </div>
            <!-- END whats-covered -->
            <!-- END PARTIAL: whats-covered -->
            <!-- FIXME: add correct article content for A8a here. see speckle. -->
            <!-- BEGIN PARTIAL: article-copy -->
            <div class="article-copy">
                <asp:Repeater ID="rptSectionPage" runat="server" OnItemDataBound="rptSectionPage_ItemDataBound">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <p>
                            <h3>
                                <sc:FieldRenderer ID="frSectionTitle" runat="server" FieldName="Title" />
                            </h3>
                            <sc:FieldRenderer ID="frSectionSubTitle" runat="server" FieldName="SubTitle" />
                            <sc:FieldRenderer ID="frSectionContent" runat="server" FieldName="Content" />
                        </p>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
                <%--
                <p>
                    Deserunt ut animi non quibusdam fugiat doloribus sed et. facilis est ipsam placeat omnis totam qui repudiandae maiores molestiae. quod voluptatibus cum minus et autem autem eveniet nam. non amet sequi unde dolorum repellendus id quos. dolores cupiditate veniam distinctio autem illum omnis cupiditate voluptates non. nam neque repellat voluptas ut ipsam corporis reiciendis dignissimos maiores sapiente quisquam sint
   
                    <span class="glossary-term-popover">
                        <a href="REPLACE" class="glossary-term-link popover-link" data-popover-placement="top">glossaryTerm1</a>
                    </span>
                    Et sed occaecati sint. est tempora quisquam enim veniam quia quo ea illum similique. nihil consectetur ipsam consequatur facere incidunt culpa labore esse unde dolores dicta eaque velit esse. eaque ratione iure aperiam inventore aperiam quis molestiae eos sit eaque. fuga aut commodi aut nam saepe nisi est repudiandae sed omnis beatae ut. veritatis quia optio dicta blanditiis nisi qui molestiae accusantium velit sit repellat corrupti. sint iure aliquam ipsum
                </p>
                <p>Qui et quisquam quibusdam architecto voluptatem non voluptatem reiciendis veritatis doloremque animi vero. animi autem qui qui qui natus in natus quo. aspernatur et est perferendis qui hic odit ducimus expedita aliquid autem sequi soluta quia. necessitatibus dolores reiciendis dolorem nisi velit neque sit. hic et est ut quae laboriosam error fuga laudantium beatae nostrum quas libero quo. ullam et veniam delectus voluptas voluptatem praesentium tempora cum fugit. quidem libero incidunt ut assumenda laborum autem</p>
                <p>Beatae voluptas aut id sint placeat voluptas veritatis est nulla maxime dolorem fugit omnis sed. excepturi temporibus qui cupiditate voluptatem ducimus sint consequatur rem praesentium inventore consectetur tempore est. quis vel a ratione odio</p>
                <!-- BEGIN PARTIAL: quotes-layout-1 -->
                <div class="quote-layout-1">
                    <blockquote>"We have to expect the very best from our students and tell the truth about student performance, to prepare them for college and career."</blockquote>
                    <img src="http://placehold.it/60x60" alt="REPLACE">
                    <div class="quote-name">
                        <h3>Rosemary Grifton,</h3>
                        <p>Guidance Counselor</p>
                    </div>
                </div>
                <!-- END PARTIAL: quotes-layout-1 -->
                <p>Non aut odio enim est dolor. quibusdam in numquam aspernatur numquam sunt qui amet reiciendis harum dolores quas dolorum. earum cupiditate doloremque reiciendis quo ducimus et. et eos est praesentium eius in velit optio accusantium</p>
                <p>Ducimus quisquam sint voluptatem repellat et temporibus dolorem est laboriosam vero voluptatem ut tenetur quo. molestiae aut aut odio facilis ratione sint. aspernatur tempora accusantium delectus voluptas incidunt nisi in qui id reiciendis autem vel. reiciendis qui harum quidem occaecati nesciunt magni occaecati fuga. voluptas molestias rerum dolores nesciunt sunt eos quam</p>
                <!-- BEGIN PARTIAL: quotes-layout-2 -->
                <div class="quote-layout-2">
                    <blockquote>"We have to expect the very best from our students and tell the truth about student performance, to prepare them for college and career."</blockquote>
                    <img src="http://placehold.it/60x60" alt="REPLACE">
                    <div class="quote-name">
                        <h3>Rosemary Grifton,</h3>
                        <p>Guidance Counselor</p>
                    </div>
                </div>
                <!-- END PARTIAL: quotes-layout-2 -->
                <p>Sed praesentium ut est accusantium provident eius incidunt soluta quasi molestias porro. autem eos natus architecto eum nihil perferendis ullam et corrupti exercitationem. ullam eveniet iste maxime iure possimus reprehenderit. perferendis quia porro vitae qui et. dignissimos atque est assumenda voluptates quia accusantium consequatur magnam architecto ad voluptate eum culpa. velit assumenda aut laboriosam culpa consectetur deleniti quia</p>
                <p>Voluptas doloribus ullam quo accusantium. dolorem facere dolorum ea est veritatis aperiam ex quidem dolorum molestiae ut. ea incidunt ut voluptas est</p>
                <p>Aperiam amet in doloribus. ullam quisquam velit earum porro tempore vel. cupiditate qui minus autem qui porro dolorem ut consequatur nisi nostrum dolores ea pariatur corrupti. sit repudiandae nemo unde quia ut amet consectetur. sit saepe dolorem quo aliquam nihil ut dolorum doloremque unde. ut nam ut enim provident vitae ut deserunt deleniti</p>
                <!-- BEGIN PARTIAL: quotes-layout-3 -->
                <div class="quote-layout-3">
                    <blockquote>"We have to expect the very best from our students and tell the truth about student performance, to prepare them for college and career."</blockquote>
                    <img src="http://placehold.it/60x60" alt="REPLACE">
                    <div class="quote-name">
                        <h3>Rosemary Grifton,</h3>
                        <p>Guidance Counselor</p>
                    </div>
                </div>
                <!-- END PARTIAL: quotes-layout-3 -->
                <p>Laboriosam est maxime quia explicabo placeat deserunt quam. vero fuga repellat nobis doloribus ut vitae eveniet earum unde quas. beatae aliquid quis voluptatum atque eaque omnis vel ut illum odio itaque ipsa iste</p>
                <p>Dicta et voluptatem molestiae quae autem est voluptas aut quibusdam. non in ipsa reiciendis sint. id officia temporibus a. accusantium omnis blanditiis porro ullam deleniti nihil est nemo porro earum omnis nihil. corporis ut et sequi</p>
                --%>
            </div>
            <!-- END PARTIAL: article-copy -->

            <!-- BEGIN PARTIAL: key-takeaways -->
            <div class="key-takeaways">
                <header class='header-key-takeaways'>
                    <h2><%--Key Takeaways--%>
                        <sc:FieldRenderer ID="frKeyTakeawaytitle" runat="server" FieldName="KeyTake away Title" />
                    </h2>
                </header>
                <sc:FieldRenderer ID="frKeyTakeawayDesc" runat="server" FieldName="Key Take away Details" />
                <%-- <ul>
                    <li>
                        <p>This article talks about lorem ipsum malesuada do</p>
                    </li>
                    <li>
                        <p>This article talks about lorem ipsum malesuada</p>
                    </li>
                    <li>
                        <p>This article talks about lorem ipsum</p>
                    </li>
                </ul> --%>
            </div>
            <!-- end key-takeaways -->

            <!-- END PARTIAL: key-takeaways -->
            <!-- BEGIN PARTIAL: about-the-author -->
            <section class="about-the-author">
                <header>
                    <h2>About the Author</h2>
                </header>
                <%--<img src="http://placehold.it/60x60" alt="REPLACE">--%>
                <asp:HyperLink ID="hlAuthorImage" runat="server">
                    <sc:FieldRenderer ID="frAuthorImage" FieldName="Author Image" runat="server"  Width="60px" Height="60px" />
                </asp:HyperLink>
                <div class="author-text">
                    <h3><%-- Christine Flagler--%>
                        <!--<sc:Text ID="txAuthorName" runat="server" Field="Author Name" />-->
                        <sc:FieldRenderer ID="frAuthorName" runat="server" FieldName="Author Name" />
                    </h3>
                    <p>
                        <%--Lorem ipsum dolor sit amet, consectetuer laoreet dolore adipiscing elit, sed diam nonummy nibh euismod tincidunt ut dolore.--%>
                        <sc:FieldRenderer ID="frAuthorBio" runat="server" FieldName="Author Biodata" />
                    </p>
                    <a href="REPLACE">More Posts by this Author</a>
                </div>
            </section>
            <!-- END PARTIAL: about-the-author -->
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
            <div class="find-this-helpful-small">
                <!-- Module within only appears in under 650px window width-->
            </div>
            <!-- BEGIN PARTIAL: keep-reading-mobile -->
            <div class="keep-reading keep-reading-mobile">
                <h3>Keep Reading</h3>
                <ul>
                    <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
                    <li><a href="REPLACE">How to Build a Homework Plan</a></li>
                    <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
                </ul>
            </div>
            <!-- END PARTIAL: keep-reading-mobile -->
        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1">
            <!-- BEGIN PARTIAL: helpful-count -->
            <div class="count-helpful">
                <a href="REPLACE"><span>34</span>Found this helpful</a>
            </div>
            <!-- END PARTIAL: helpful-count -->
            <!-- BEGIN PARTIAL: comments-count -->
            <div class="count-comments">
                <a href="REPLACE"><span>19</span>Comments</a>
            </div>
            <!-- END PARTIAL: comments-count -->
            <div class="find-this-helpful-large">
                <!-- Module within only appears in over 650px window width-->
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
            </div>
            <!-- BEGIN PARTIAL: keep-reading-lg -->
            <div class="keep-reading keep-reading-lg"></div>
            <!-- END PARTIAL: keep-reading-lg -->
            <!-- BEGIN PARTIAL: comments-summary -->
            <section class="comments-summary">
                <header>
                    <h3>Comments (19)</h3>
                </header>
                <div class="quote-container">
                    <blockquote>
                        <p>Inventore et qui quis quis veritatis. doloribus odio ut nam. rerum eos earum sed sed optio fugiat cupiditate atque velit id doloremque voluptatem</p>
                        <i class="arrow-quote-bottom"></i>
                    </blockquote>
                    <span><strong>Carrie S</strong> &bull; 30 min ago</span>
                </div>

                <ul>
                    <li><a href="REPLACE">See All Comments</a></li>
                    <li><a href="REPLACE">Add My Comment</a></li>
                </ul>
            </section>
            <!-- END PARTIAL: comments-summary -->
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


<!-- comments -->
<div class="container comments">
    <div class="row">
        <!-- comments col -->
        <div class="col col-23 offset-1">
            <!-- BEGIN PARTIAL: comment-list -->
            <section class="comment-list">

                <header>
                    <span class="comment-count">Comments (19)</span>
                    <select name="comment-sort-option" class="comment-sort">
                        <option value="">Sort by</option>
                        <option>A-Z</option>
                        <option>Z-A</option>
                    </select>
                </header>

                <div class="comment-list-wrapper">

                    <div class="comment-wrapper">
                        <div class="comment-header">
                            <span class="comment-avatar">
                                <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                            </span>
                            <span class="comment-info">
                                <span class="comment-username">Patricia S</span>
                                <span class="comment-date">3 days ago</span>
                            </span>
                            <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                        </div>
                        <div class="comment-body">
                            <p>
                                Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                            </p>
                        </div>
                        <div class="comment-actions">
                            <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                            <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                            <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                        </div>
                    </div>
                    <!-- .comment-wrapper -->

                    <div class="comment-wrapper">
                        <div class="comment-header">
                            <span class="comment-avatar">
                                <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                            </span>
                            <span class="comment-info">
                                <span class="comment-username">Patricia S</span>
                                <span class="comment-date">3 days ago</span>
                            </span>
                            <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                        </div>
                        <div class="comment-body">
                            <p>
                                Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                            </p>
                        </div>
                        <div class="comment-actions">
                            <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                            <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                            <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                        </div>
                    </div>
                    <!-- .comment-wrapper -->

                    <div class="comment-wrapper">
                        <div class="comment-header">
                            <span class="comment-avatar">
                                <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                            </span>
                            <span class="comment-info">
                                <span class="comment-username">Patricia S</span>
                                <span class="comment-date">3 days ago</span>
                            </span>
                            <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                        </div>
                        <div class="comment-body">
                            <p>
                                Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                            </p>
                        </div>
                        <div class="comment-actions">
                            <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                            <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                            <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                        </div>
                    </div>
                    <!-- .comment-wrapper -->

                    <div class="comment-wrapper">
                        <div class="comment-header">
                            <span class="comment-avatar">
                                <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                            </span>
                            <span class="comment-info">
                                <span class="comment-username">Patricia S</span>
                                <span class="comment-date">3 days ago</span>
                            </span>
                            <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                        </div>
                        <div class="comment-body">
                            <p>
                                Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                            </p>
                        </div>
                        <div class="comment-actions">
                            <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                            <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                            <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                        </div>
                    </div>
                    <!-- .comment-wrapper -->
                </div>
                <!-- .comment-list-wrapper -->

                <div class="comment-footer">
                    <div class="comment-more-wrapper">
                        <a class="comment-more" href="REPLACE">More Comments<i class="icon-comment-more"></i></a>
                    </div>
                    <div class="comment-form">
                        <textarea name="comment-form-reply" class="comment-form-reply" placeholder="Add your comment..."></textarea>
                        <input type="submit" value="Submit" class="comment-form-submit submit-button" />
                        <div class="clearfix"></div>
                    </div>
                </div>

            </section>
            <!-- .comment-list -->

            <!-- END PARTIAL: comment-list -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->


