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
                        <p>
                            <sc:fieldrenderer id="frQuestion" runat="server" fieldname="Question" />
                        </p>
                    </div>
                    <div class="expert-answer">
                        <div class="expert-author">
                            <%--<sc:fieldrenderer id="frExpertImage" runat="server" fieldname="Photo" />--%>
                            <sc:Image id="frExpertImage" runat="server" field="Photo" maxheight="187" maxwidth="294" width="294" height="187" />
                            <div class="expert-author-info">
                                <p class="name">
                                    <strong>
                                        <sc:fieldrenderer id="frExpertName" runat="server" fieldname="Full Name" />
                                    </strong>
                                </p>
                                <p class="title">
                                    <sc:fieldrenderer id="frExpertTitle" runat="server" fieldname="Title and Institution" />
                                </p>
                            </div>
                            <!-- end expert-author-info" -->
                        </div>
                        <!-- end expert-author -->
                        <div class="expert-content">
                            <p>
                                <sc:fieldrenderer id="frAnswer" runat="server" fieldname="Answer" />
                            </p>
                        </div>
                        <!-- end expert-content -->
                    </div>
                    <!-- end expert-answer -->
                </ItemTemplate>
                <FooterTemplate></FooterTemplate>

            </asp:Repeater>



            <!-- END PARTIAL: expert-answer -->
            <!-- BEGIN PARTIAL: about-the-author -->
            <sc:sublayout id="sbAboutAuthor" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx" visible="false" />

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
            <sc:sublayout id="Sublayout1" path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCountsSideColumn.ascx" runat="server"></sc:sublayout>
            <!-- END PARTIAL: comments-count -->
            <!-- BEGIN PARTIAL: find-helpful -->
            <sc:sublayout path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" runat="server"></sc:sublayout>
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
            <sc:sublayout id="slKeepReading" runat="server" path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
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
                <sc:sublayout id="sbSidebarPromo" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/Promotionals List.ascx" />
            </div>
            <!-- end sidebar-promos -->

            <!-- END PARTIAL: sidebar-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

