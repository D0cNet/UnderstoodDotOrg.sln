<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Action Style List Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Action_Style_List_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- END PARTIAL: pagetopic -->
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
            <!-- BEGIN PARTIAL: article-actions-copy -->
            <div class="article-actions-copy">
                <%--<h3>ea dolorem nam sint quia</h3>
                <p>Labore repellendus et et ut. nisi sapiente ratione in recusandae sunt quidem. ipsa animi fuga numquam omnis ipsa dignissimos culpa laboriosam</p>
                --%>
                <sc:FieldRenderer ID="frAtricleIntroText" runat="server" FieldName="Body Content" />
                <asp:Repeater ID="rptAction" runat="server" OnItemDataBound="rptAction_ItemDataBound">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <div>
                            <div class="action-step">
                               
                                    <%-- 4
                                    <sc:FieldRenderer ID="frActionNo" runat="server" FieldName="Action Number" />--%>
                                    <asp:Label ID="lblActionCount" runat="server"></asp:Label>
                                
                            </div>
                            <div class="action-head">
                                <h3><%--Lorem Ipsum--%>
                                    <sc:FieldRenderer ID="frActionTitle" runat="server" FieldName="Title" />
                                </h3>
                            </div>
                            <div class="clearfix"></div>
                            <div class="action-copy">
                                <p>
                                    <%--Exercitationem exercitationem soluta similique libero voluptas. occaecati et est optio ab ut blanditiis et consequatur vero optio. natus aperiam porro blanditiis. et ut consequuntur quam et. est blanditiis sed sit voluptas molestiae odit--%>
                                    <sc:FieldRenderer ID="frActionIntro" runat="server" FieldName="Introduction" />
                                </p>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
                <%-- <div>
                    <div class="action-step"><span>1</span></div>
                    <div class="action-head">
                        <h3>Make Notes</h3>
                    </div>
                    <div class="clearfix"></div>
                    <div class="action-copy">
                        <p>Autem dolorem non quam eum et vero esse excepturi. pariatur repellendus eos cupiditate et amet nihil voluptatem sit nihil id consectetur quibusdam voluptas. delectus rerum ad vel vero dolores et et pariatur. perferendis quaerat iure pariatur autem sequi et aut consequatur</p>
                    </div>
                </div>
                <div>
                    <div class="action-step"><span>2</span></div>
                    <div class="action-head">
                        <h3>Draft a Letter</h3>
                    </div>
                    <div class="clearfix"></div>
                    <div class="action-copy">
                        <p>Vel autem quas ipsam et numquam non voluptate ipsam. id et sit iusto. reprehenderit fuga repellat voluptatem sequi. modi hic voluptatum quis omnis quam</p>
                    </div>
                </div>
                <div>
                    <div class="action-step"><span>3</span></div>
                    <div class="action-head">
                        <h3>Make an Appointment</h3>
                    </div>
                    <div class="clearfix"></div>
                    <div class="action-copy">
                        <p>Voluptatum quis consequuntur illum voluptatem doloribus saepe culpa repellat. sit ut accusamus architecto est. ullam aliquid facere voluptas et explicabo enim sint aut enim explicabo architecto quis eum. rerum quibusdam possimus quia deleniti quae quia. accusantium ut facere aut fuga vel accusamus et debitis dolorum cupiditate</p>
                    </div>
                </div>
                <div>
                    <div class="action-step"><span>4</span></div>
                    <div class="action-head">
                        <h3>Lorem Ipsum</h3>
                    </div>
                    <div class="clearfix"></div>
                    <div class="action-copy">
                        <p>Exercitationem exercitationem soluta similique libero voluptas. occaecati et est optio ab ut blanditiis et consequatur vero optio. natus aperiam porro blanditiis. et ut consequuntur quam et. est blanditiis sed sit voluptas molestiae odit</p>
                    </div>
                </div> --%>
            </div>
            <!-- END PARTIAL: article-actions-copy -->
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
           <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" Visible="false" />
            <%--<p class="reviewed-by">
                <span class="reviewed-by-title">Reviewed&nbsp;by</span> <span class="reviewed-by-author">
                   <%--<a href="REPLACE">Dr. Samantha Frank</a>
                   <asp:HyperLink ID="hlReviewdby" runat="server">
                       <sc:FieldRenderer ID="frReviewedby" runat="server" FieldName="Revierwer Name" />
                    </asp:HyperLink>
                </span><span class="dot"></span><span class="reviewed-by-date">
                    <%--12&nbsp;Dec&nbsp;&apos;13
                    <sc:Date ID="dtReviewdDate" Field="Reviewed Date" runat="server" Format="dd MMM yy" />
                </span>
            </p>--%>
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
            <%--<div class="keep-reading keep-reading-mobile">
                <h3>Keep Reading</h3>
                <ul>
                    <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
                    <li><a href="REPLACE">How to Build a Homework Plan</a></li>
                    <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
                </ul>
            </div>--%>

            <!-- END PARTIAL: keep-reading-mobile -->
            <!-- BEGIN PARTIAL: article-poll -->
            <section class="article-poll">

                <div class="poll-question">
                    <div class="poll-question-left">
                        <h3>Reader Poll</h3>
                        <img class="foo" alt="FPO content image" src="http://placehold.it/190x107&amp;text=190x107" />
                    </div>
                    <!-- .poll-question-left -->
                    <div class="poll-question-right">
                        <div class="help-me"><a href="REPLACE">Help me decide</a></div>
                        <h4>Are you considering Ritalin for your child?</h4>
                        <label for="article-poll-answer1">
                            <input type="radio" id="article-poll-answer1" name="article-poll-answer">
                            Yes</label>
                        <label for="article-poll-answer2">
                            <input type="radio" id="article-poll-answer2" name="article-poll-answer">
                            No</label>
                    </div>
                    <!-- .poll-question-right -->
                </div>
                <!-- .poll-question -->

                <div class="poll-results">
                    <h3>Are you considering Ritalin for your child?</h3>

                    <div class="row poll-result poll-result-1">
                        <div class="col col-3">
                            <div class="poll-answer poll-answer-1">Yes</div>
                        </div>
                        <div class="col col-18">
                            <div class="poll-bar poll-bar-1" style="width: 16%; background-color: #406aad;">&nbsp;</div>
                        </div>
                        <div class="col col-3">
                            <div class="poll-percent poll-percent-1">16%</div>
                        </div>
                    </div>

                    <div class="row poll-result poll-result-2">
                        <div class="col col-3">
                            <div class="poll-answer poll-answer-2">No</div>
                        </div>
                        <div class="col col-18">
                            <div class="poll-bar poll-bar-2" style="width: 84%; background-color: #59ab7e;">&nbsp;</div>
                        </div>
                        <div class="col col-3">
                            <div class="poll-percent poll-percent-2">84%</div>
                        </div>
                    </div>

                    <hr>
                    <div class="poll-footer">
                        <div class="poll-footer-left">
                            <span>567</span> Responses
     
                        </div>
                        <div class="poll-footer-right">
                            <p>Find Out More</p>
                            <p><a href="REPLACE">10 Tips to Help Kids Get Organized</a></p>
                            <p><a href="REPLACE">How to Build a Homework Plan</a></p>
                        </div>
                    </div>
                    <!-- .poll-footer -->
                </div>
                <!-- .poll-results -->

            </section>
            <!-- .article-poll -->
            <!-- END PARTIAL: article-poll -->
        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1 skiplink-sidebar rs_read_this">
            
            <sc:Sublayout ID="Sublayout1" Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCountsSideColumn.ascx" runat="server"></sc:Sublayout>
            
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
            <div class="keep-reading keep-reading-lg">
                <sc:Sublayout ID="slKeepReading" runat="server" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
            </div>
            <!-- END PARTIAL: keep-reading-lg -->
            <!-- BEGIN PARTIAL: comments-summary -->
            <section class="comments-summary">
                <header>
                    <h3>Comments (19)</h3>
                </header>
                <div class="quote-container">
                    <blockquote>
                        <p>Incidunt officia voluptate consectetur odit. optio culpa rem iure ut vitae numquam alias porro eos. mollitia voluptatem laborum sequi expedita</p>
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




