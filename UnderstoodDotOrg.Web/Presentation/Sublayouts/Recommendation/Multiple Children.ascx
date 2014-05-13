<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Multiple Children.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation.Multiple_Children" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>



<!--[if lte IE 8]><html class="no-js nonresponsive old-ie" lang="en"><![endif]-->
<!--[if gte IE 9]><!-->

<!--<![endif]-->

<!-- BEGIN PARTIAL: head -->


<!-- END PARTIAL: head -->


<!-- BEGIN PARTIAL: language-selector -->

<!-- END PARTIAL: language-selector -->

<div id="wrapper">

    <!-- BEGIN PARTIAL: header -->
    <!-- #header-page -->
    <!-- END PARTIAL: header -->

    <!-- BEGIN PARTIAL: pagetopic -->
    <!-- FIXME: Documentation needed to explain share on/off functionality in page topic module -->

    <!-- Determine variables present and change column width to fit the content available -->


    <!-- Page Title -->
    <div class="container page-topic recommendations with-share">
        <div class="row">
            <div class="col col-14 offset-1">

                <div>
                    <h1 class="rs_read_this"><%--Just For You--%>
                        <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                    </h1>

                    <p class="page-subtitle">
                        <%--Customized advice and interactive tools--%>
                        <sc:FieldRenderer ID="frPageSummary" runat="server" FieldName="Page Summary" />
                    </p>

                </div>
            </div>
            <sc:Placeholder ID="Placeholder1" Key="ShareNSave" runat="server" />
            <%--    <div class="col col-9">
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
    </div>--%>
        </div>
    </div>
    <% %>
    <!-- .container -->

    <!-- END PARTIAL: pagetopic -->

    <div class="recos-for-you-carousels">

        <div class="container recos-for-you-container">
            <asp:Repeater ID="rptChildBasicInfo" runat="server" OnItemDataBound="rptChildBasicInfo_ItemDataBound">
                <ItemTemplate>
                    <div class="row">
                        <div class="col col-24">
                            <h2><%--For Michael--%>
                                <sc:FieldRenderer ID="frChildName" runat="server" FieldName="Child Name" />
                            </h2>
                            <div class="row carousel-container">
                                <div class="col col-24">
                                    <!-- BEGIN PARTIAL: recommendations/carousel-for-you -->

                                    <div class="recos-for-you carousel-recos arrows-gray">

                                        <ul>
                                            <asp:Repeater ID="rptChildRelatedArticles" runat="server" OnItemDataBound="rptChildRelatedArticles_ItemDataBound">
                                                <ItemTemplate>
                                                    <li class="article">
                                                        <%--<a class="article-photo" href="REPLACE">
                                                                   
                                                                    <img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>--%>
                                                        <asp:HyperLink ID="hlArticleImage" CssClass="article-photo" runat="server">
                                                            <sc:FieldRenderer ID="frArticleImage" runat="server" FieldName="Thumbnail Image" />
                                                        </asp:HyperLink>
                                                        <div class="article-title">
                                                            <h3>
                                                                <%-- <a href="REPLACE">Facere Quod Dicta Ut Saepe Voluptate Fugit</a>--%>
                                                                <asp:HyperLink ID="hlArtcielTitle" runat="server">
                                                                    <sc:FieldRenderer ID="frArticleTitle" runat="server" FieldName="Page Title" />
                                                                </asp:HyperLink>
                                                            </h3>
                                                            <p>
                                                                <%--Grade 5--%>
                                                                <sc:FieldRenderer ID="frArticleGrade" runat="server" FieldName="Grade Level" />
                                                            </p>
                                                            <%--<h3><a href="REPLACE">Facere Quod Dicta Ut Saepe Voluptate Fugit</a></h3>
                                                                    <p>Grade 5</p>--%>
                                                            <div class="buttons-container">
                                                                <button class="icon-plus">save this</button>
                                                                <button class="icon-skip">skip</button>
                                                                <button class="icon-bell">remind</button>
                                                            </div>
                                                        </div>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <%--<li class="article">
                                                        <a class="article-photo" href="REPLACE">
                                                            <img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
                                                        <div class="article-title">
                                                            <h3><a href="REPLACE">Facere Quod Dicta Ut Saepe Voluptate Fugit</a></h3>
                                                            <p>Grade 5</p>
                                                            <div class="buttons-container">
                                                                <button class="icon-plus">save this</button>
                                                                <button class="icon-skip">skip</button>
                                                                <button class="icon-bell">remind</button>
                                                            </div>
                                                        </div>
                                                    </li>--%>
                                            <!-- .article -->
                                        </ul>
                                        <!-- .slide -->

                                    </div>

                                    <!-- END PARTIAL: recommendations/carousel-for-you -->

                                    <div class="why-link popover-trigger-container why1-tooltip-trigger">
                                        <a href="REPLACE" class="popover-link" data-popover-placement="bottom">Why these recommendations? <i class="icon-tooltip"></i></a>
                                    </div>

                                    <div class="why1-tooltip popover-container">
                                        <div class="why1-tooltip-inner">
                                            <div class="col1">
                                                <ul class="tags">
                                                    <li><%--Grade 3--%>
                                                        <sc:FieldRenderer ID="frWhyGrade" runat="server" FieldName="Childs Grade" />
                                                    </li>
                                                    <li><%--Boy--%>
                                                        <sc:FieldRenderer ID="frWhyChildGender" runat="server" FieldName="Childs Gender" />
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="col2">
                                                <h4><%--Recommendations match what you told us about Michael:--%>
                                                    <asp:Label ID="lblCHildNameRecommendText" runat="server"></asp:Label>
                                                </h4>
                                                <ul class="list">
                                                    <asp:Repeater ID="rptChildIssuesList" runat="server" OnItemDataBound="rptChildIssuesList_ItemDataBound">
                                                        <ItemTemplate>
                                                            <li>
                                                                <sc:FieldRenderer ID="frChildIssue" runat="server" FieldName="Childs Matching Issue" />
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <li>
                                                        <asp:HyperLink ID="hlReplaceMatchingIssues" runat="server" CssClass="edit">
                                                                    Edit this list
                                                        </asp:HyperLink>
                                                    </li>
                                                    <%--<li>Spoken Language</li>
                                                            <li>Listening comprehension</li>
                                                            <li>Social skills, including conversation</li>
                                                            <li>Motor skills</li>
                                                            <li><a href="REPLACE" class="edit">Edit this list</a></li>--%>
                                                </ul>
                                                <a class="button close">Close</a>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- .why1-tooltip -->

                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>




        </div>


        <!-- .container -->
    </div>
    <!-- .recos-for-you-carousels -->

    <div class="recos-upcoming-events container">
        <div class="row">
            <div class="col col-24">
                <h2>Upcoming Events</h2>
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows more-upcoming-events next-prev-menu arrows">

                    <div class="rsArrow rsArrowLeft">
                        <button class="rsArrowIcn"></button>
                    </div>
                    <div class="rsArrow rsArrowRight">
                        <button class="rsArrowIcn"></button>
                    </div>
                </div>
                <!-- end .arrows -->
                <!-- END PARTIAL: community/carousel_arrows -->
                <div class="row event-cards">
                    <!-- BEGIN PARTIAL: recommendations/upcoming-event -->
                    <div class="col col-24 event-card">
                        <div class="event-wrapper">
                            <div class="author-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <span class="label">Expert</span>
                                </a>
                            </div>
                            <div class="event-card-info">
                                <div class="event-card-date">
                                    Tue Aug 23 at 8pm EST
     
                                </div>
                                <div class="event-card-title">
                                    <a href="REPLACE">Eos Necessitatibus Facilis Qui Est Atque Ut Et Quaerat
        </a>
                                </div>
                                <div class="event-card-author">
                                    Geraldine Markel, Ph.D.
     
                                </div>
                                <div class="children">
                                    <i class="child-a" title="CHILD NAME HERE"></i>
                                </div>
                            </div>
                            <!-- end .event-card-info -->
                        </div>
                        <!--  end .event-wrapper -->
                    </div>
                    <!-- end .event-card -->
                    <!-- END PARTIAL: recommendations/upcoming-event -->
                    <!-- BEGIN PARTIAL: recommendations/upcoming-event -->
                    <div class="col col-24 event-card">
                        <div class="event-wrapper">
                            <div class="author-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <span class="label">Expert</span>
                                </a>
                            </div>
                            <div class="event-card-info">
                                <div class="event-card-date">
                                    Tue Aug 23 at 8pm EST
     
                                </div>
                                <div class="event-card-title">
                                    <a href="REPLACE">Sit Voluptas In Nulla Autem Sit Et At Inventore
        </a>
                                </div>
                                <div class="event-card-author">
                                    Geraldine Markel, Ph.D.
     
                                </div>
                                <div class="children">
                                    <i class="child-a" title="CHILD NAME HERE"></i>
                                </div>
                            </div>
                            <!-- end .event-card-info -->
                        </div>
                        <!--  end .event-wrapper -->
                    </div>
                    <!-- end .event-card -->
                    <!-- END PARTIAL: recommendations/upcoming-event -->
                    <!-- BEGIN PARTIAL: recommendations/upcoming-event -->
                    <div class="col col-24 event-card">
                        <div class="event-wrapper">
                            <div class="author-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <span class="label">Expert</span>
                                </a>
                            </div>
                            <div class="event-card-info">
                                <div class="event-card-date">
                                    Tue Aug 23 at 8pm EST
     
                                </div>
                                <div class="event-card-title">
                                    <a href="REPLACE">Dolore Saepe Sit Voluptas Consectetur Culpa Maiores Distinctio Fugiat
        </a>
                                </div>
                                <div class="event-card-author">
                                    Geraldine Markel, Ph.D.
     
                                </div>
                                <div class="children">
                                    <i class="child-a" title="CHILD NAME HERE"></i>
                                </div>
                            </div>
                            <!-- end .event-card-info -->
                        </div>
                        <!--  end .event-wrapper -->
                    </div>
                    <!-- end .event-card -->
                    <!-- END PARTIAL: recommendations/upcoming-event -->
                    <!-- BEGIN PARTIAL: recommendations/upcoming-event -->
                    <div class="col col-24 event-card">
                        <div class="event-wrapper">
                            <div class="author-image">
                                <a href="REPLACE">
                                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                    <span class="label">Expert</span>
                                </a>
                            </div>
                            <div class="event-card-info">
                                <div class="event-card-date">
                                    Tue Aug 23 at 8pm EST
     
                                </div>
                                <div class="event-card-title">
                                    <a href="REPLACE">Voluptas Eum Dolorem Rerum Nostrum Reiciendis Et Est Reiciendis
        </a>
                                </div>
                                <div class="event-card-author">
                                    Geraldine Markel, Ph.D.
     
                                </div>
                                <div class="children">
                                    <i class="child-a" title="CHILD NAME HERE"></i>
                                </div>
                            </div>
                            <!-- end .event-card-info -->
                        </div>
                        <!--  end .event-wrapper -->
                    </div>
                    <!-- end .event-card -->
                    <!-- END PARTIAL: recommendations/upcoming-event -->
                </div>
            </div>
        </div>
    </div>
    <!-- .recos-upcoming-events -->

    <div class="recos-ask-parents container">
        <div class="row">
            <div class="col col-24">
                <h2>Ask Our Parents</h2>
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows more-ask-parents next-prev-menu arrows">

                    <div class="rsArrow rsArrowLeft">
                        <button class="rsArrowIcn"></button>
                    </div>
                    <div class="rsArrow rsArrowRight">
                        <button class="rsArrowIcn"></button>
                    </div>
                </div>
                <!-- end .arrows -->
                <!-- END PARTIAL: community/carousel_arrows -->
                <div class="row parents-cards">
                    <!-- BEGIN PARTIAL: recommendations/ask-parents -->
                    <div class="col col-24 parents-card">
                        <div class="parents-wrapper">

                            <div class="parents-question">
                                <h3>Saepe Blanditiis Vero Eos Eaque Facilis Inventore Aut Mollitia
      </h3>
                                <p>
                                    Est Atque Ullam Soluta Odio Illo Et Laboriosam Dolores Temporibus Repudiandae Corrupti Laudantium Quidem In Eum Dolorem Corrupti Rerum Consequatur Optio Adipisci Recusandae Quae
     
                                </p>
                            </div>
                            <!--  end .parents-question -->

                            <div class="toolbar">
                                <div class="links">
                                    <a href="REPLACE" class="link">5 answers</a>
                                    <a href="REPLACE" class="link">Answer this question</a>
                                </div>
                                <div class="children">
                                    <i class="child-a" title="CHILD NAME HERE"></i>
                                    <i class="child-c" title="CHILD NAME HERE"></i>
                                    <i class="child-a" title="CHILD NAME HERE"></i>

                                </div>
                            </div>
                        </div>
                        <!--  end .parents-wrapper -->
                    </div>
                    <!-- end .parents-card -->
                    <!-- END PARTIAL: recommendations/ask-parents -->
                    <!-- BEGIN PARTIAL: recommendations/ask-parents -->
                    <div class="col col-24 parents-card">
                        <div class="parents-wrapper">

                            <div class="parents-question">
                                <h3>Praesentium Dignissimos Voluptatem Aut Quisquam Ea Iure Facere Corporis
      </h3>
                                <p>
                                    Maiores Quo Ratione Amet Perferendis Vitae Neque Nemo Sunt Maiores Esse Vel Nihil Eaque Velit Necessitatibus Id Adipisci Dolorum Voluptatem Perspiciatis Consequatur Necessitatibus Dolorem
     
                                </p>
                            </div>
                            <!--  end .parents-question -->

                            <div class="toolbar">
                                <div class="links">
                                    <a href="REPLACE" class="link">5 answers</a>
                                    <a href="REPLACE" class="link">Answer this question</a>
                                </div>
                                <div class="children">
                                    <i class="child-a" title="CHILD NAME HERE"></i>
                                    <i class="child-c" title="CHILD NAME HERE"></i>
                                    <i class="child-a" title="CHILD NAME HERE"></i>

                                </div>
                            </div>
                        </div>
                        <!--  end .parents-wrapper -->
                    </div>
                    <!-- end .parents-card -->
                    <!-- END PARTIAL: recommendations/ask-parents -->
                    <!-- BEGIN PARTIAL: recommendations/ask-parents -->
                    <div class="col col-24 parents-card">
                        <div class="parents-wrapper">

                            <div class="parents-question">
                                <h3>Quis Aspernatur Dolor Et Est Aut Voluptatem Ea Sed
      </h3>
                                <p>
                                    Eaque Facilis Consequatur Aut Itaque Sint Voluptas Corrupti Veniam Dolores Sint Est Quisquam Labore Velit Quasi Animi Eius Iure Ratione Officiis Et Quia Nam
     
                                </p>
                            </div>
                            <!--  end .parents-question -->

                            <div class="toolbar">
                                <div class="links">
                                    <a href="REPLACE" class="link">5 answers</a>
                                    <a href="REPLACE" class="link">Answer this question</a>
                                </div>
                                <div class="children">
                                    <i class="child-a" title="CHILD NAME HERE"></i>
                                    <i class="child-c" title="CHILD NAME HERE"></i>
                                    <i class="child-a" title="CHILD NAME HERE"></i>

                                </div>
                            </div>
                        </div>
                        <!--  end .parents-wrapper -->
                    </div>
                    <!-- end .parents-card -->
                    <!-- END PARTIAL: recommendations/ask-parents -->
                    <!-- BEGIN PARTIAL: recommendations/ask-parents -->
                    <div class="col col-24 parents-card">
                        <div class="parents-wrapper">

                            <div class="parents-question">
                                <h3>Rerum Quia Et Accusamus Doloremque Aut Sunt Inventore Alias
      </h3>
                                <p>
                                    Consequatur Aspernatur Eos Eum Minima Accusamus Provident Debitis Delectus Eos Praesentium Ad Ex Deleniti Et Et Consequuntur Dolorum Alias Sed Voluptas Ut Quas Molestiae
     
                                </p>
                            </div>
                            <!--  end .parents-question -->

                            <div class="toolbar">
                                <div class="links">
                                    <a href="REPLACE" class="link">5 answers</a>
                                    <a href="REPLACE" class="link">Answer this question</a>
                                </div>
                                <div class="children">
                                    <i class="child-a" title="CHILD NAME HERE"></i>
                                    <i class="child-c" title="CHILD NAME HERE"></i>
                                    <i class="child-a" title="CHILD NAME HERE"></i>

                                </div>
                            </div>
                        </div>
                        <!--  end .parents-wrapper -->
                    </div>
                    <!-- end .parents-card -->
                    <!-- END PARTIAL: recommendations/ask-parents -->
                </div>
            </div>
        </div>
    </div>
    <!-- .recos-ask-parents -->

    <!-- BEGIN PARTIAL: children-key -->
    <div class="container child-content-indicator recos">
        <!-- Key -->
        <div class="row">
            <div class="col col-23 offset-1">
                <div class="children-key" aria-hidden="true">
                    <ul>
                        <li><i class="child-a"></i>for Michael</li>
                        <li><i class="child-b"></i>for Elizabeth</li>
                        <li><i class="child-c"></i>for Ethan</li>
                        <li><i class="child-d"></i>for Jeremy</li>
                        <li><i class="child-e"></i>for Franklin</li>
                    </ul>
                </div>
                <!-- .children-key -->
            </div>
            <!-- .col -->
        </div>
        <!-- .row -->
    </div>
    <!-- .child-content-indicator -->
    <!-- END PARTIAL: children-key -->

    <div class="container recos-tab-content">
        <div class="row">
            <div class="col col-24">
                <div id="recos-tabs">
                    <ul>
                        <li><a href="#connect-with-parents" id="tab-connect-parents">Connect with Parents</a></li>
                        <li><a href="#find-group" id="tab-find-group">Find a Group</a></li>
                        <li><a href="#follow-blog" id="tab-follow-blog">Follow a Blog</a></li>
                        <li><a href="#parent-toolkit" id="tab-parent-toolkit">Your Parent Toolkit</a></li>
                    </ul>
                    <div class="tab-content" id="connect-with-parents">
                        <!-- BEGIN PARTIAL: recommendations/tab-connect -->
                        <section class="recos-tab-connect">
                            <header class="row">
                                <div class="col col-17">
                                    <h3>When you select Find Parents Like Me, we'll match you with parents who share your interests, have kids the same age and/or live in your area.
      </h3>
                                </div>
                                <div class="col col-6 offset-1">
                                    <a class="button">Find Parents Like You
      </a>
                                </div>
                            </header>
                            <div class="row">
                                <div class="col col-24 parents-member-cards skiplink-content" aria-role="main">

                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate parent">

                                                    <a href="REPLACE" class="name-member">Gordon73</a>
                                                    <p class="location">magnam</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button rs_skip">Connect</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class='specialty '><span tabindex='0' data-tabbable='true'>1st</span><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 1,
            Girl
        </h3>
                                                                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                                <div class="arrows child-info-next-prev-menu arrows-gray">

                                                                    <div class="rsArrow rsArrowLeft">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                    <div class="rsArrow rsArrowRight">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                </div>
                                                                <!-- end .arrows -->
                                                                <!-- END PARTIAL: community/carousel_arrows -->
                                                                <ul>
                                                                    <li>Id Consequatur</li>
                                                                    <li>Numquam Quis</li>
                                                                    <li>Occaecati Veniam</li>
                                                                    <li>Ipsa Tempore</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate parent">

                                                    <a href="REPLACE" class="name-member">Jordyn62</a>
                                                    <p class="location">qui</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button rs_skip">Connect</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class='specialty '><span tabindex='0' data-tabbable='true'>4th</span><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 4,
            Girl
        </h3>
                                                                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                                <div class="arrows child-info-next-prev-menu arrows-gray">

                                                                    <div class="rsArrow rsArrowLeft">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                    <div class="rsArrow rsArrowRight">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                </div>
                                                                <!-- end .arrows -->
                                                                <!-- END PARTIAL: community/carousel_arrows -->
                                                                <ul>
                                                                    <li>Molestias Eos</li>
                                                                    <li>Et Maiores</li>
                                                                    <li>Et Eaque</li>
                                                                    <li>Nulla In</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty '><span tabindex='0' data-tabbable='true'>12th</span><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 12,
            Boy
        </h3>
                                                                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                                <div class="arrows child-info-next-prev-menu arrows-gray">

                                                                    <div class="rsArrow rsArrowLeft">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                    <div class="rsArrow rsArrowRight">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                </div>
                                                                <!-- end .arrows -->
                                                                <!-- END PARTIAL: community/carousel_arrows -->
                                                                <ul>
                                                                    <li>Aut Eum</li>
                                                                    <li>Veritatis Laborum</li>
                                                                    <li>Ut Molestiae</li>
                                                                    <li>Fugit Dolores</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate parent">

                                                    <a href="REPLACE" class="name-member">Nia35</a>
                                                    <p class="location">quia</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button rs_skip">Connect</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class='specialty '><span tabindex='0' data-tabbable='true'>2nd</span><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 2,
            Boy
        </h3>
                                                                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                                <div class="arrows child-info-next-prev-menu arrows-gray">

                                                                    <div class="rsArrow rsArrowLeft">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                    <div class="rsArrow rsArrowRight">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                </div>
                                                                <!-- end .arrows -->
                                                                <!-- END PARTIAL: community/carousel_arrows -->
                                                                <ul>
                                                                    <li>Enim A</li>
                                                                    <li>Dolor Ea</li>
                                                                    <li>Officiis Fugit</li>
                                                                    <li>Ex Magni</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty '><span tabindex='0' data-tabbable='true'>11th</span><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 11,
            Girl
        </h3>
                                                                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                                <div class="arrows child-info-next-prev-menu arrows-gray">

                                                                    <div class="rsArrow rsArrowLeft">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                    <div class="rsArrow rsArrowRight">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                </div>
                                                                <!-- end .arrows -->
                                                                <!-- END PARTIAL: community/carousel_arrows -->
                                                                <ul>
                                                                    <li>Et Doloremque</li>
                                                                    <li>Neque Quam</li>
                                                                    <li>Ab Eos</li>
                                                                    <li>Pariatur Doloremque</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty '><span tabindex='0' data-tabbable='true'>12th</span><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 12,
            Girl
        </h3>
                                                                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                                <div class="arrows child-info-next-prev-menu arrows-gray">

                                                                    <div class="rsArrow rsArrowLeft">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                    <div class="rsArrow rsArrowRight">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                </div>
                                                                <!-- end .arrows -->
                                                                <!-- END PARTIAL: community/carousel_arrows -->
                                                                <ul>
                                                                    <li>Harum Nisi</li>
                                                                    <li>Nobis Perferendis</li>
                                                                    <li>In Eveniet</li>
                                                                    <li>Eveniet Doloribus</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate parent">

                                                    <a href="REPLACE" class="name-member">Kailey93</a>
                                                    <p class="location">aut</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button rs_skip">Connect</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class='specialty '><span tabindex='0' data-tabbable='true'>7th</span><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 7,
            Boy
        </h3>
                                                                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                                <div class="arrows child-info-next-prev-menu arrows-gray">

                                                                    <div class="rsArrow rsArrowLeft">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                    <div class="rsArrow rsArrowRight">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                </div>
                                                                <!-- end .arrows -->
                                                                <!-- END PARTIAL: community/carousel_arrows -->
                                                                <ul>
                                                                    <li>Ad Rerum</li>
                                                                    <li>Consectetur Quae</li>
                                                                    <li>Voluptatem Quo</li>
                                                                    <li>Aliquid Molestias</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty '><span tabindex='0' data-tabbable='true'>10th</span><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 10,
            Boy
        </h3>
                                                                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                                <div class="arrows child-info-next-prev-menu arrows-gray">

                                                                    <div class="rsArrow rsArrowLeft">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                    <div class="rsArrow rsArrowRight">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                </div>
                                                                <!-- end .arrows -->
                                                                <!-- END PARTIAL: community/carousel_arrows -->
                                                                <ul>
                                                                    <li>Facere Rerum</li>
                                                                    <li>Fuga Necessitatibus</li>
                                                                    <li>Voluptatem Enim</li>
                                                                    <li>Suscipit Non</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty '><span tabindex='0' data-tabbable='true'>11th</span><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 11,
            Boy
        </h3>
                                                                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                                <div class="arrows child-info-next-prev-menu arrows-gray">

                                                                    <div class="rsArrow rsArrowLeft">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                    <div class="rsArrow rsArrowRight">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                </div>
                                                                <!-- end .arrows -->
                                                                <!-- END PARTIAL: community/carousel_arrows -->
                                                                <ul>
                                                                    <li>Esse Totam</li>
                                                                    <li>Dolorum Mollitia</li>
                                                                    <li>Aut Ad</li>
                                                                    <li>Velit Eaque</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty '><span tabindex='0' data-tabbable='true'>12th</span><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 12,
            Boy
        </h3>
                                                                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                                                <div class="arrows child-info-next-prev-menu arrows-gray">

                                                                    <div class="rsArrow rsArrowLeft">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                    <div class="rsArrow rsArrowRight">
                                                                        <button class="rsArrowIcn"></button>
                                                                    </div>
                                                                </div>
                                                                <!-- end .arrows -->
                                                                <!-- END PARTIAL: community/carousel_arrows -->
                                                                <ul>
                                                                    <li>Autem Adipisci</li>
                                                                    <li>Voluptas Perspiciatis</li>
                                                                    <li>Voluptate Voluptas</li>
                                                                    <li>Soluta Libero</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                </div>
                                <!-- end .col.col-24.container -->
                        </section>
                        <!-- END PARTIAL: recommendations/tab-connect -->
                    </div>
                    <div class="tab-content" id="find-group">
                        <!-- BEGIN PARTIAL: recommendations/tab-groups -->
                        <div class="recos-groups">
                            <div class="row">
                                <div class="col col-24 community-groups-wrapper">
                                    <div class="disclaimer">
                                        These groups are a private place for you to connect with other parents. Only members can see the conversations. <i class="icon lock"></i>
                                    </div>
                                    <div class="row group-cards">
                                        <!-- BEGIN PARTIAL: recommendations/group-card -->
                                        <div class="col col-12 group-card rs_read_this">
                                            <div class="group-card-image">
                                                <a href="REPLACE">
                                                    <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
                                                </a>
                                            </div>
                                            <!-- end .group-card-image -->
                                            <div class="group-card-info group  col col-16">
                                                <a href="REPLACE" class="group-card-name">Voluptate Et Qui Velit</a><br />
                                                <span class="group-card-members">682 Members</span><br />
                                                <span class="group-card-posts">18,844 Posts</span><br />
                                                <div class="card-buttons">
                                                    <span>
                                                        <button type="button" class="button rs_skip">Join</button></span>
                                                    <span>
                                                        <button class="action-skip-this rs_skip">
                                                            I am not<br />
                                                            interested</button></span>
                                                </div>
                                                <!-- end .card-buttons -->
                                            </div>
                                            <!-- end .group-card-info -->
                                        </div>
                                        <!-- end .group-card -->
                                        <!-- END PARTIAL: recommendations/group-card -->
                                        <!-- BEGIN PARTIAL: recommendations/group-card -->
                                        <div class="col col-12 group-card rs_read_this">
                                            <div class="group-card-image">
                                                <a href="REPLACE">
                                                    <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
                                                </a>
                                            </div>
                                            <!-- end .group-card-image -->
                                            <div class="group-card-info group  col col-16">
                                                <a href="REPLACE" class="group-card-name">Culpa Quis Et Non</a><br />
                                                <span class="group-card-members">383 Members</span><br />
                                                <span class="group-card-posts">16,697 Posts</span><br />
                                                <div class="card-buttons">
                                                    <span>
                                                        <button type="button" class="button rs_skip">Join</button></span>
                                                    <span>
                                                        <button class="action-skip-this rs_skip">
                                                            I am not<br />
                                                            interested</button></span>
                                                </div>
                                                <!-- end .card-buttons -->
                                            </div>
                                            <!-- end .group-card-info -->
                                        </div>
                                        <!-- end .group-card -->
                                        <!-- END PARTIAL: recommendations/group-card -->
                                    </div>
                                    <!-- end .group-cards -->
                                </div>
                                <!-- end .col.col-24.container -->
                            </div>
                            <!-- end .row -->
                        </div>
                        <!-- end .community-groups -->
                        <!-- END PARTIAL: recommendations/tab-groups -->
                    </div>
                    <div class="tab-content" id="follow-blog">
                        <!-- BEGIN PARTIAL: recommendations/tab-blogs -->
                        <div class="recos-blogs">
                            <div class="row">
                                <div class="col col-24 community-groups-wrapper">
                                    <div class="carousel-arrow-wrapper">
                                        <!-- BEGIN PARTIAL: community/carousel_arrows -->
                                        <div class="arrows blogs next-prev-menu arrows-gray">

                                            <a class="view-all" href="REPLACE">All Blogs</a>

                                            <div class="rsArrow rsArrowLeft">
                                                <button class="rsArrowIcn"></button>
                                            </div>
                                            <div class="rsArrow rsArrowRight">
                                                <button class="rsArrowIcn"></button>
                                            </div>
                                        </div>
                                        <!-- end .arrows -->
                                        <!-- END PARTIAL: community/carousel_arrows -->
                                    </div>
                                    <div class="row group-cards">
                                        <!-- BEGIN PARTIAL: recommendations/blog-card -->
                                        <div class="col col-12 group-card rs_read_this">
                                            <div class="group-card-image">
                                                <a href="REPLACE">
                                                    <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
                                                </a>
                                            </div>
                                            <!-- end .group-card-image -->
                                            <div class="group-card-info group  col col-16">
                                                <a href="REPLACE" class="group-card-name">Ut Sint Nesciunt Voluptas</a><br />
                                                <span class="group-card-date">Posted June 26, 2013</span><br />
                                                <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
                                                <div class="card-buttons">
                                                    <span>
                                                        <button type="button" class="button rs_skip">Follow</button></span>
                                                    <span>
                                                        <button class="action-skip-this rs_skip">
                                                            I am not<br />
                                                            interested</button></span>
                                                </div>
                                                <!-- end .card-buttons -->
                                            </div>
                                            <!-- end .group-card-info -->
                                        </div>
                                        <!-- end .group-card -->
                                        <!-- END PARTIAL: recommendations/blog-card -->
                                        <!-- BEGIN PARTIAL: recommendations/blog-card -->
                                        <div class="col col-12 group-card rs_read_this">
                                            <div class="group-card-image">
                                                <a href="REPLACE">
                                                    <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
                                                </a>
                                            </div>
                                            <!-- end .group-card-image -->
                                            <div class="group-card-info group  col col-16">
                                                <a href="REPLACE" class="group-card-name">Magnam Modi Placeat Quisquam</a><br />
                                                <span class="group-card-date">Posted June 26, 2013</span><br />
                                                <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
                                                <div class="card-buttons">
                                                    <span>
                                                        <button type="button" class="button rs_skip">Follow</button></span>
                                                    <span>
                                                        <button class="action-skip-this rs_skip">
                                                            I am not<br />
                                                            interested</button></span>
                                                </div>
                                                <!-- end .card-buttons -->
                                            </div>
                                            <!-- end .group-card-info -->
                                        </div>
                                        <!-- end .group-card -->
                                        <!-- END PARTIAL: recommendations/blog-card -->
                                        <!-- BEGIN PARTIAL: recommendations/blog-card -->
                                        <div class="col col-12 group-card rs_read_this">
                                            <div class="group-card-image">
                                                <a href="REPLACE">
                                                    <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
                                                </a>
                                            </div>
                                            <!-- end .group-card-image -->
                                            <div class="group-card-info group  col col-16">
                                                <a href="REPLACE" class="group-card-name">Natus Iusto Molestiae Vel</a><br />
                                                <span class="group-card-date">Posted June 26, 2013</span><br />
                                                <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
                                                <div class="card-buttons">
                                                    <span>
                                                        <button type="button" class="button rs_skip">Follow</button></span>
                                                    <span>
                                                        <button class="action-skip-this rs_skip">
                                                            I am not<br />
                                                            interested</button></span>
                                                </div>
                                                <!-- end .card-buttons -->
                                            </div>
                                            <!-- end .group-card-info -->
                                        </div>
                                        <!-- end .group-card -->
                                        <!-- END PARTIAL: recommendations/blog-card -->
                                        <!-- BEGIN PARTIAL: recommendations/blog-card -->
                                        <div class="col col-12 group-card rs_read_this">
                                            <div class="group-card-image">
                                                <a href="REPLACE">
                                                    <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
                                                </a>
                                            </div>
                                            <!-- end .group-card-image -->
                                            <div class="group-card-info group  col col-16">
                                                <a href="REPLACE" class="group-card-name">Debitis Perspiciatis Hic Numquam</a><br />
                                                <span class="group-card-date">Posted June 26, 2013</span><br />
                                                <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
                                                <div class="card-buttons">
                                                    <span>
                                                        <button type="button" class="button rs_skip">Follow</button></span>
                                                    <span>
                                                        <button class="action-skip-this rs_skip">
                                                            I am not<br />
                                                            interested</button></span>
                                                </div>
                                                <!-- end .card-buttons -->
                                            </div>
                                            <!-- end .group-card-info -->
                                        </div>
                                        <!-- end .group-card -->
                                        <!-- END PARTIAL: recommendations/blog-card -->
                                        <!-- BEGIN PARTIAL: recommendations/blog-card -->
                                        <div class="col col-12 group-card rs_read_this">
                                            <div class="group-card-image">
                                                <a href="REPLACE">
                                                    <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
                                                </a>
                                            </div>
                                            <!-- end .group-card-image -->
                                            <div class="group-card-info group  col col-16">
                                                <a href="REPLACE" class="group-card-name">Officia Mollitia Quidem Deleniti</a><br />
                                                <span class="group-card-date">Posted June 26, 2013</span><br />
                                                <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
                                                <div class="card-buttons">
                                                    <span>
                                                        <button type="button" class="button rs_skip">Follow</button></span>
                                                    <span>
                                                        <button class="action-skip-this rs_skip">
                                                            I am not<br />
                                                            interested</button></span>
                                                </div>
                                                <!-- end .card-buttons -->
                                            </div>
                                            <!-- end .group-card-info -->
                                        </div>
                                        <!-- end .group-card -->
                                        <!-- END PARTIAL: recommendations/blog-card -->
                                        <!-- BEGIN PARTIAL: recommendations/blog-card -->
                                        <div class="col col-12 group-card rs_read_this">
                                            <div class="group-card-image">
                                                <a href="REPLACE">
                                                    <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
                                                </a>
                                            </div>
                                            <!-- end .group-card-image -->
                                            <div class="group-card-info group  col col-16">
                                                <a href="REPLACE" class="group-card-name">Et Est Ut Voluptatibus</a><br />
                                                <span class="group-card-date">Posted June 26, 2013</span><br />
                                                <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
                                                <div class="card-buttons">
                                                    <span>
                                                        <button type="button" class="button rs_skip">Follow</button></span>
                                                    <span>
                                                        <button class="action-skip-this rs_skip">
                                                            I am not<br />
                                                            interested</button></span>
                                                </div>
                                                <!-- end .card-buttons -->
                                            </div>
                                            <!-- end .group-card-info -->
                                        </div>
                                        <!-- end .group-card -->
                                        <!-- END PARTIAL: recommendations/blog-card -->
                                    </div>
                                    <!-- end .group-cards -->
                                </div>
                                <!-- end .col.col-24.container -->
                            </div>
                            <!-- end .row -->
                        </div>
                        <!-- end .community-groups -->
                        <!-- END PARTIAL: recommendations/tab-blogs -->
                    </div>
                    <div class="tab-content" id="parent-toolkit">
                        <!-- BEGIN PARTIAL: recommendations/tab-toolkit -->
                        <div class="tab-toolkit-wrapper">
                            <div class="tab-toolkit-header-container arrows-gray">

                                <div class="tab-toolkit-slides-container">

                                    <div class="slide">
                                        <ul>
                                            <li>
                                                <div class="icon support-plan">
                                                    <a class="toolkit-element" href="REPLACE">My Support Plan</a>
                                                    <div class="coming-soon">Coming Soon</div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="icon observation-logs">
                                                    <a class="toolkit-element" href="REPLACE">Observation Log</a>
                                                </div>
                                            </li>

                                            <li>
                                                <div class="icon childs-world">
                                                    <a class="toolkit-element" href="REPLACE">A Childs World</a>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                    <!-- .slide -->

                                    <div class="slide">
                                        <ul>
                                            <li>
                                                <div class="icon find">
                                                    <a class="toolkit-element" href="REPLACE">Find Technology</a>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="icon decisions">
                                                    <a class="toolkit-element" href="REPLACE">My Decisions</a>
                                                </div>
                                            </li>

                                            <li>
                                                <div class="icon rate-schools">
                                                    <a class="toolkit-element" href="REPLACE">Rate Schools</a>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                    <!-- .slide -->
                                    <div class="slide">
                                        <ul>
                                            <li>
                                                <div class="icon observation-logs">
                                                    <a class="toolkit-element" href="REPLACE">Icon Title Here</a>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="icon find">
                                                    <a class="toolkit-element" href="REPLACE">Icon Title Here</a>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                    <!-- .slide -->
                                </div>
                                <!-- .slides-container -->

                            </div>
                            <!-- .tab-toolkit-header-container -->
                        </div>
                        <!-- .tab-toolkit-wrapper -->
                        <!-- END PARTIAL: recommendations/tab-toolkit -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- .recos-ask-parents -->



    <!-- BEGIN PARTIAL: footer -->





    <!-- BEGIN MODULE: Newsletter Signup -->
    <div class="container newsletter-signup">
        <div class="row">

            <div class="col col-12 newsletter-signup-rs-wrapper rs_read_this">

                <header>
                    <h2>Personalized Email</h2>
                    <p>Stay connected with us by signing up for our weekly personalized emails.</p>
                </header>

            </div>
            <!-- .col -->

            <div class="col col-12">

                <div class="form personalized-email-form">
                    <fieldset class="input-wrap">
                        <label for="personalized-email-email" class="visuallyhidden" aria-hidden="true">Enter Email Address</label>
                        <input type="email" name="personalized-email" id="personalized-email-email" placeholder="Enter email address" aria-required="true">
                    </fieldset>
                    <div class="submit-button-wrap">
                        <input type="submit" class="button" value="Sign Up">
                    </div>
                </div>

            </div>
            <!-- .col -->

        </div>
        <!-- .row -->
    </div>
    <!-- .container .newsletter-signup -->

    <!-- END MODULE: Newsletter Signup -->

    <!-- BEGIN MODULE: Partners Carousel -->
    <div class="container partners-carousel">
        <div class="row">
            <div class="col col-24">
                <h2>In Partnership with</h2>
                <!-- BEGIN PARTIAL: partners-carousel -->
                <div id="partners-slides-container" class="arrows-gray">
                    <ul>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                        <li>
                            <a href="REPLACE">
                                <img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
                        </li>
                    </ul>
                </div>
                <!-- end partners-carousel-container -->
                <a class="viewAll" href="REPLACE">View All</a>
                <!-- END PARTIAL: partners-carousel -->

            </div>
        </div>
    </div>

    <!-- END MODULE: Partners Carousel -->

    <!-- BEGIN MODULE: Footer Nav -->
    <div class="container">
        <div class="row">
            <div class="col col-24" role="navigation">

                <ul id="footer-nav" role="menu">
                    <li role="menuitem"><a href="REPLACE"><span>About Us</span></a></li>
                    <li role="menuitem"><a href="REPLACE"><span>Learning &amp; Attention Issues</span></a></li>
                    <li role="menuitem"><a href="REPLACE"><span>School &amp; Learning</span></a></li>
                    <li role="menuitem"><a href="REPLACE"><span>Friends &amp; Feelings</span></a></li>
                    <li role="menuitem"><a href="REPLACE"><span>You &amp; Your Family</span></a></li>
                    <li role="menuitem"><a href="REPLACE"><span>Community &amp; Events</span></a></li>
                </ul>
                <!-- #footer-nav -->

            </div>
        </div>
        <!-- .row -->
    </div>
    <!-- .container -->

    <!-- END MODULE: Footer Nav -->

    <!-- Content wrapper for glossary term popovers -->
    <!-- BEGIN PARTIAL: glossary-term -->
    <!-- This partial is included in the footer.erb file. So this container applies to every glossary term and its contents should dynamically change depending on the glossary link. -->
    <!-- popover hidden content -->
    <div class="glossary-term-content-wrapper popover-container">
        <blockquote>
            <span>Dyslexia:</span> Difficulty in reading, spelling, writing, and related language skills that results from an impairment in the way the brain processes information &hellip; <a href="REPLACE">View Glossary</a>
        </blockquote>
    </div>
    <!-- END PARTIAL: glossary-term -->

    <!-- BEGIN MODULE: Footer -->

    <!-- footer .container -->

    <!-- END MODULE: Footer -->
    <!-- END PARTIAL: footer -->

</div>
<!-- #wrapper -->

<!-- BEGIN PARTIAL: footerjs -->

<!--[if lte IE 8]>
<script src="Presentation/includes/js/vendor/selectivizr.js"></script><![endif]-->





<!-- END PARTIAL: footerjs -->

