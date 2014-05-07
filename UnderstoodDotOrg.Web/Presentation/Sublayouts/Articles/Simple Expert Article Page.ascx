<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Simple Expert Article Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Simple_Expert_Article_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<!-- END PARTIAL: pagetopic -->
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <asp:Repeater ID="rptExpertQA" runat="server" OnItemDataBound="rptExpertQA_ItemDataBound">
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>

                    <div class="expert-question">
                        <sc:FieldRenderer ID="frQuestion" runat="server" FieldName="Question" />
                    </div>
                    <div class="expert-answer">
                        <div class="expert-author">
                            <sc:FieldRenderer ID="frExpertImage" runat="server" FieldName="Expert Image" />
                            <div class="expert-author-info">
                                <p class="name">
                                    <strong>
                                        <sc:FieldRenderer ID="frExpertName" runat="server" FieldName="Expert Name" />
                                    </strong>
                                </p>
                                <p class="title">
                                    <sc:FieldRenderer ID="frExpertTitle" runat="server" FieldName="Expert Title" />
                                </p>
                            </div>
                            <!-- end expert-author-info" -->
                        </div>
                        <!-- end expert-author -->
                        <div class="expert-content">
                            <sc:FieldRenderer ID="frAnswer" runat="server" FieldName="Answer" />
                        </div>
                        <!-- end expert-content -->
                    </div>
                    <!-- end expert-answer -->
                </ItemTemplate>
                <FooterTemplate></FooterTemplate>

            </asp:Repeater>
            <%-- <!-- BEGIN PARTIAL: expert-question -->
<div class="expert-question">
 <%-- <p>Adipisci illum aut animi voluptatem nobis repudiandae velit non quo. quia sit aliquam voluptas placeat ratione quisquam. voluptate aspernatur consequatur consequatur sed earum nisi nihil modi est accusantium repellendus sit similique. dolores hic est quasi suscipit provident. voluptas fugiat perferendis rerum voluptatem dolores voluptate dignissimos sit ut nulla quae mollitia et. ut rem debitis earum qui ducimus voluptas consequuntur vel ea. et iste est distinctio placeat minus voluptatem error et id nihil</p>
  <p>Et recusandae doloribus rerum sunt nihil ea qui. impedit et dolorum fuga optio quibusdam quia eveniet deleniti mollitia non. debitis aut ipsam quae. numquam corporis et provident officia sapiente cumque ullam et quasi laborum omnis. laudantium commodi quis quis modi harum vel et</p>
  <p>Eaque vel corrupti delectus est molestiae corrupti illo odit mollitia. aut consequatur necessitatibus quis vitae. rem impedit id alias nam quibusdam voluptatem eum omnis unde id consequatur vitae. vel minus sit aperiam

  </p>
           
       
        <!-- end expert-question -->

        <!-- END PARTIAL: expert-question -->
        <!-- BEGIN PARTIAL: expert-answer -->
          <div class="expert-answer">
            <div class="expert-author">
                <img alt="294x187 Placeholder" src="http://placehold.it/294x187" />
                <div class="expert-author-info">
                    <p class="name"><strong>Dr Mark Mycolin,</strong></p>
                    <p class="title">Director of Speech Pathology</p>
                </div>
                <!-- end expert-author-info" -->
            </div>
            <!-- end expert-author -->
            <div class="expert-content">
                <p>Odio aut minus impedit libero mollitia aliquam. numquam praesentium enim sequi voluptatem ea voluptatem temporibus error est. nihil culpa tempore expedita veritatis aut itaque. praesentium qui aperiam sit</p>
                <p>Et harum mollitia quis sunt non. rerum sunt repellendus et inventore accusantium repellat quidem vel sit nisi doloribus qui vero ut. ut ratione et laboriosam. provident qui iste iusto et neque dolorum et vero dolorem. explicabo quia unde aut qui consequatur facilis rerum saepe ut. labore recusandae corporis eligendi delectus est iusto vero praesentium numquam doloremque tenetur. vel voluptate consequuntur ducimus est quasi illo tempora nemo veritatis maxime ad</p>
                <p>Consequatur soluta illo adipisci officiis aut voluptatem neque non id laudantium totam. aperiam cumque molestias earum perspiciatis. mollitia impedit nam et laudantium itaque quidem asperiores repudiandae id. enim omnis voluptas a rerum sit qui earum incidunt aliquid hic eos deserunt temporibus. iure et odio ut accusamus rerum voluptatem eius fuga voluptas sint ipsum eaque. aut ut consequatur nulla quaerat blanditiis recusandae minima</p>
            </div>
            <!-- end expert-content -->
        </div>
        <!-- end expert-answer -->
            --%>


            <!-- END PARTIAL: expert-answer -->
            <!-- BEGIN PARTIAL: about-the-author -->
            <sc:Sublayout ID="sbAboutAuthor" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx" Visible="false" />
            <%--<section class="about-the-author">
                <header>
                    <h2>About the Author Main</h2>
                </header>
                <%--<img src="http://placehold.it/60x60" alt="REPLACE">
                <asp:HyperLink ID="hlAuthorImage" runat="server">
                    <sc:FieldRenderer ID="frAuthorImage" FieldName="Author Image" runat="server" Width="60px" Height="60px" />
                </asp:HyperLink>

                <div class="author-text">
                    <h3><%-- Christine Flagler
                        <!--<sc:Text ID="txAuthorName" runat="server" Field="Author Name" />-->
                        <sc:FieldRenderer ID="frAuthorName" runat="server" FieldName="Author Name" />
                    </h3>
                    <p>
                        <%--Lorem ipsum dolor sit amet, consectetuer laoreet dolore adipiscing elit, sed diam nonummy nibh euismod tincidunt ut dolore.
                        <sc:FieldRenderer ID="frAuthorBio" runat="server" FieldName="Author Biodata" />
                    </p>
                    <asp:HyperLink ID="hlAuthorMorePost" runat="server" Text="More Posts by this Author">
                    </asp:HyperLink>
                    <%--<a href="REPLACE">More Posts by this Author</a>
                </div>
            </section>--%>
            <!-- END PARTIAL: about-the-author -->
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
            <%--<div class="keep-reading">
            <h3>Keep Reading</h3>
            <ul>
                <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
                <li><a href="REPLACE">How to Build a Homework Plan</a></li>
                <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
            </ul>
        </div>--%>
            <sc:Sublayout ID="slKeepReading" runat="server" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
            <!-- END PARTIAL: keep-reading -->
            <!-- BEGIN PARTIAL: comments-summary -->
            <section class="comments-summary">
                <header>
                    <h3>Comments (19)</h3>
                </header>
                <div class="quote-container">
                    <blockquote>
                        <p>Maiores pariatur recusandae omnis sint provident fuga maxime non maiores consectetur. perferendis et suscipit sit ut dolor. commodi sunt qui ea harum molestiae autem nemo et incidunt sapiente molestias soluta ut voluptatem. exercitationem rerum minima quisquam sed veniam natus laudantium et sit molestiae. optio voluptatem exercitationem enim iusto ex ut delectus. asperiores est explicabo maiores et repudiandae dolore earum est praesentium quos vel officiis ut. rem autem ut vero sed voluptatem beatae alias ea</p>
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
            <div class="sidebar-promos rs_read_this vertical">
                <sc:Sublayout ID="sbSidebarPromo" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/Promotionals List.ascx" />
            </div>
            <%--<div class="sidebar-promos">
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
            </div> --%>
            <!-- end sidebar-promos -->

            <!-- END PARTIAL: sidebar-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

