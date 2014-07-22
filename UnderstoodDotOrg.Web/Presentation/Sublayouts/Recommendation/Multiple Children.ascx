<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Multiple Children.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation.Multiple_Children" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

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
                        <sc:FieldRenderer ID="frPageSummary" runat="server" FieldName="Section Title" />
                    </p>

                </div>
            </div>
            <sc:Placeholder ID="Placeholder1" Key="ShareNSave" runat="server" />

        </div>
    </div>
    <!-- .container -->

    <!-- END PARTIAL: pagetopic -->

    <div class="recos-for-you-carousels">

         <div class="container recos-for-you-container">
                  <!-- ***** Begin TestComponent - This Div is for Testing Purposes Only and must be removed after the feature is validated -->
            <div style="border: 1px #8299a1 solid; 
                width: 250px; 
                background-color: #daf6fb; 
                margin-left:10px; 
                margin-right:0; 
                margin:0px; 
                padding:0px; 
                text-align: center;">            
                (For Testing) Date to Impersonate: 
             <asp:Calendar ID="uxCal" runat="server"></asp:Calendar>
             <asp:Button ID="btnRunPersonalied" runat="server" OnClick="btnRunPersonalied_Click" Text="Recalculate Recomendations" />
        </div>
       <!-- ***** End TestComponent -->
               <asp:Repeater ID="rptChildBasicInfo" runat="server" ItemType="UnderstoodDotOrg.Domain.Membership.Child" OnItemDataBound="rptChildBasicInfo_ItemDataBound">
                <ItemTemplate>
                    <div class="row">
                        <div class="col col-24">
                            <h2><%--For Michael--%>
                                <%= UnderstoodDotOrg.Common.DictionaryConstants.ForFragment %> <%# Item.Nickname %>
                            </h2>
                            <div class="row carousel-container">
                                <div class="col col-24">
                                    <!-- BEGIN PARTIAL: recommendations/carousel-for-you -->

                                    <div class="recos-for-you carousel-recos arrows-gray">

                                        <ul>
                                            <asp:Repeater ID="rptChildRelatedArticles" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems.DefaultArticlePageItem" OnItemDataBound="rptChildRelatedArticles_ItemDataBound">
                                                <ItemTemplate>
                                                    <li class="article">
                                                        <%--<a class="article-photo" href="REPLACE">
                                                                   
                                                                    <img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>--%>
                                                        <%--<sc:FieldRenderer ID="frArticleImage" runat="server" FieldName="Thumbnail Image" />--%>
                                                        <asp:HyperLink ID="hlArticleImage" CssClass="article-photo" runat="server">
                                                            <asp:Image ID="imgThumbnail" runat="server" />
                                                        </asp:HyperLink>
                                                        <div class="article-title">
                                                            <h3>
                                                                <asp:HyperLink ID="hlArticleTitle" runat="server">
                                                                    <%# Item.ContentPage.PageTitle %>
                                                                </asp:HyperLink>
                                                            </h3>
                                                            <%--<p>Grade 5</p>--%>
                                                            <%--<h3><a href="REPLACE">Facere Quod Dicta Ut Saepe Voluptate Fugit</a></h3>
                                                                    <p>Grade 5</p>--%>
                                                            <div class="buttons-container">
                                                                <button class="icon-plus"><%= UnderstoodDotOrg.Common.DictionaryConstants.SaveThisButtonText %></button>
                                                                <button class="icon-skip">skip<%= UnderstoodDotOrg.Common.DictionaryConstants.SkipButtonText %></button>
                                                                <button class="icon-bell">remind<%= UnderstoodDotOrg.Common.DictionaryConstants.RemindButtonText %></button>
                                                            </div>
                                                        </div>
                                                        
                                                        <asp:Literal ID="litDebugTag" runat="server" />
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

                                    <div class="why-link popover-trigger-container why<%# Container.ItemIndex %>-tooltip-trigger">
                                        <a href="#" class="popover-link" data-popover-placement="bottom"><%= UnderstoodDotOrg.Common.DictionaryConstants.WhytheserecommendationsButtonText %><i class="icon-tooltip"></i></a>
                                    </div>

                                    <div class="why<%# Container.ItemIndex %>-tooltip popover-container">
                                        <div class="why<%# Container.ItemIndex %>-tooltip-inner">
                                            <div class="col1">
                                                <ul class="tags">
                                                    <li>
                                                        <asp:Literal ID="litChildGrade" runat="server" />
                                                    </li>
                                                    <li>
                                                        <asp:Literal ID="litChildGender" runat="server" />
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="col2">
                                                <h4>
                                                    <%= UnderstoodDotOrg.Common.DictionaryConstants.RecommendationsMatchFragment %>
                                                    <%# Item.Nickname %>:
                                                </h4>
                                                <ul class="list">
                                                    <asp:Repeater ID="rptChildIssuesList" DataSource="<%# Item.Issues %>" ItemType="UnderstoodDotOrg.Domain.Membership.Issue" runat="server">
                                                        <ItemTemplate>
                                                            <li>
                                                                <%# Item.Value %>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <li>
                                                        <asp:HyperLink ID="hlReplaceMatchingIssues" runat="server" CssClass="edit">
                                                                    <%= UnderstoodDotOrg.Common.DictionaryConstants.EditthislistButtonText %>
                                                        </asp:HyperLink>
                                                    </li>
                                                    <%--<li>Spoken Language</li>
                                                            <li>Listening comprehension</li>
                                                            <li>Social skills, including conversation</li>
                                                            <li>Motor skills</li>
                                                            <li><a href="REPLACE" class="edit">Edit this list</a></li>--%>
                                                </ul>
                                                <a class="button close"><%= UnderstoodDotOrg.Common.DictionaryConstants.CloseButtonText %></a>
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
          <h2 class="rs_read_this">Ask Our Parents</h2>
          <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows more-ask-parents next-prev-menu arrows">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
          <div class="row parents-cards">
              <!-- BEGIN PARTIAL: recommendations/ask-parents -->
<div class="col col-24 parents-card">
  <div class="parents-wrapper rs_read_this">

    <div class="parents-question">
      <h3>
        Laudantium Iusto Dolorum Quam In Rerum Distinctio Quia Inventore
      </h3>
      <p>
        Repellat Sit Voluptas Accusamus In Blanditiis Vel Et Placeat Deserunt Ipsum Nesciunt Adipisci Amet Molestiae Asperiores Fugit Nam Delectus Voluptas Odio Consequatur Deserunt Dolore
      </p>
    </div><!--  end .parents-question -->

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
  </div><!--  end .parents-wrapper -->
</div><!-- end .parents-card -->
<!-- END PARTIAL: recommendations/ask-parents -->
              <!-- BEGIN PARTIAL: recommendations/ask-parents -->
<div class="col col-24 parents-card">
  <div class="parents-wrapper rs_read_this">

    <div class="parents-question">
      <h3>
        Aliquid Aliquid Quaerat Mollitia Nostrum Est Consectetur Dolorem Quia
      </h3>
      <p>
        Est Veniam In Dolorem Commodi Quam Corrupti Voluptatem Ut Quas Voluptas Iste Doloribus Earum Nemo Est Quia Nostrum Accusantium Odit Et Molestiae Repellat Sed
      </p>
    </div><!--  end .parents-question -->

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
  </div><!--  end .parents-wrapper -->
</div><!-- end .parents-card -->
<!-- END PARTIAL: recommendations/ask-parents -->
              <!-- BEGIN PARTIAL: recommendations/ask-parents -->
<div class="col col-24 parents-card">
  <div class="parents-wrapper rs_read_this">

    <div class="parents-question">
      <h3>
        Blanditiis Inventore Voluptatum Nemo Ex Reiciendis Similique Adipisci Dolores
      </h3>
      <p>
        Culpa Officiis Facere Sequi Qui Ut Nostrum Ipsa Velit Aut Ad Consequatur Praesentium Officiis Sit Totam Nobis Ducimus Autem Amet Totam Explicabo Cum Dolor
      </p>
    </div><!--  end .parents-question -->

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
  </div><!--  end .parents-wrapper -->
</div><!-- end .parents-card -->
<!-- END PARTIAL: recommendations/ask-parents -->
              <!-- BEGIN PARTIAL: recommendations/ask-parents -->
<div class="col col-24 parents-card">
  <div class="parents-wrapper rs_read_this">

    <div class="parents-question">
      <h3>
        Maxime Et Culpa Expedita Repellendus Nostrum Illum Aut Velit
      </h3>
      <p>
        Laborum Omnis Sunt Dolorum Expedita Commodi Eum Odit Aut Tenetur Qui Quibusdam Veritatis Eveniet Assumenda Voluptas Atque Eius Expedita Ullam Qui Similique Magnam Rem
      </p>
    </div><!--  end .parents-question -->

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
  </div><!--  end .parents-wrapper -->
</div><!-- end .parents-card -->
<!-- END PARTIAL: recommendations/ask-parents -->
          </div>
      </div>
  </div>
</div><!-- .recos-ask-parents -->

   
<%--<!-- BEGIN PARTIAL: children-key -->
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
      </div><!-- .children-key --> 
    </div><!-- .col --> 
  </div><!-- .row --> 
</div><!-- .child-content-indicator --> 
<!-- END PARTIAL: children-key -->--%>
<sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />

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
      <h3>
        When you select Find Parents Like Me, we'll match you with parents who share your interests, have kids the same age and/or live in your area.
      </h3>
    </div>
    <div class="col col-6 offset-1">
      <a class="button">
        Find Parents Like You
      </a>
    </div>
  </header>

  <div class="row">
    <div class="col col-24 parents-member-cards" aria-role="main">

        <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="rs_read_this col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate parent">
                
                    <a href="REPLACE" class="name-member">Laila73</a>
                    <p class="location">eius</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button rs_skip">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class=''><a href='REPLACE'>9th</a><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 9,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Rerum Sapiente</li>
            <li>Quidem Aut</li>
            <li>Voluptatum Tempora</li>
            <li>Et Corporis</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
        <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="rs_read_this col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate parent">
                
                    <a href="REPLACE" class="name-member">Sydney57</a>
                    <p class="location">ex</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button rs_skip">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class=''><a href='REPLACE'>3rd</a><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 3,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Inventore Aut</li>
            <li>Est Qui</li>
            <li>Nobis Quisquam</li>
            <li>Sunt Id</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class=''><a href='REPLACE'>10th</a><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 10,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Deserunt Non</li>
            <li>Et Ut</li>
            <li>Dicta Sapiente</li>
            <li>Animi Corrupti</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
        <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="rs_read_this col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate parent">
                
                    <a href="REPLACE" class="name-member">Sienna43</a>
                    <p class="location">sint</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button rs_skip">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty-long'><a href='REPLACE'>PreK</a><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>PreK,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Quis Et</li>
            <li>Provident Ad</li>
            <li>Laudantium Non</li>
            <li>Voluptatum Est</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class=''><a href='REPLACE'>2nd</a><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 2,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Temporibus Dolorem</li>
            <li>Itaque Voluptate</li>
            <li>Nobis Non</li>
            <li>Reiciendis Inventore</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class=''><a href='REPLACE'>9th</a><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 9,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Et Qui</li>
            <li>Eveniet Non</li>
            <li>Alias Alias</li>
            <li>Similique Labore</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
        <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="rs_read_this col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate parent">
                
                    <a href="REPLACE" class="name-member">Daren76</a>
                    <p class="location">esse</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button rs_skip">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty-long'><a href='REPLACE'>PreK</a><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>PreK,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Aliquid Voluptates</li>
            <li>Illo Quia</li>
            <li>Beatae Soluta</li>
            <li>Vel Porro</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class=''><a href='REPLACE'>3rd</a><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 3,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Cumque Occaecati</li>
            <li>Reprehenderit Est</li>
            <li>Accusamus Eaque</li>
            <li>Nemo Similique</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class=''><a href='REPLACE'>7th</a><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 7,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Porro Et</li>
            <li>Nam Praesentium</li>
            <li>Beatae Nulla</li>
            <li>Ratione Et</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class=''><a href='REPLACE'>9th</a><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 9,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Placeat Qui</li>
            <li>Delectus Dolore</li>
            <li>Quia Aut</li>
            <li>Iure Quia</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->

    </div><!-- end .col.col-24.container -->
  </div>

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
  <div class="group-card-image col col-8">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group col col-16">
    <a href="REPLACE" class="group-card-name">Dolores Quis Maiores Aliquam</a><br />
    <span class="group-card-members">1,196 Members</span><br />
    <span class="group-card-posts">18,329 Posts</span><br />
    <div class="card-buttons">
        <span><button type="button" class="button rs_skip">Join</button></span>
        <span><button class="action-skip-this rs_skip">I am not<br />interested</button></span>
    </div><!-- end .card-buttons -->
  </div><!-- end .group-card-info -->
</div><!-- end .group-card -->
<!-- END PARTIAL: recommendations/group-card -->
        <!-- BEGIN PARTIAL: recommendations/group-card -->
<div class="col col-12 group-card rs_read_this">
  <div class="group-card-image col col-8">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group col col-16">
    <a href="REPLACE" class="group-card-name">Optio Laborum Qui Autem</a><br />
    <span class="group-card-members">768 Members</span><br />
    <span class="group-card-posts">3,762 Posts</span><br />
    <div class="card-buttons">
        <span><button type="button" class="button rs_skip">Join</button></span>
        <span><button class="action-skip-this rs_skip">I am not<br />interested</button></span>
    </div><!-- end .card-buttons -->
  </div><!-- end .group-card-info -->
</div><!-- end .group-card -->
<!-- END PARTIAL: recommendations/group-card -->
      </div><!-- end .group-cards -->
    </div><!-- end .col.col-24.container -->
  </div><!-- end .row -->
</div><!-- end .community-groups -->
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
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
      </div>
      <div class="row group-cards">
        <!-- BEGIN PARTIAL: recommendations/blog-card -->
<div class="col col-12 group-card rs_read_this">
  <div class="group-card-image" col col-8">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group col col-16">
    <a href="REPLACE" class="group-card-name">Perferendis Eius Voluptate Ducimus</a><br />
    <span class="group-card-date">Posted June 26, 2013</span><br />
    <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
    <div class="card-buttons">
        <span><button type="button" class="button rs_skip">Follow</button></span>
        <span><button class="action-skip-this rs_skip">I am not<br />interested</button></span>
    </div><!-- end .card-buttons -->
  </div><!-- end .group-card-info -->
</div><!-- end .group-card -->
<!-- END PARTIAL: recommendations/blog-card -->
        <!-- BEGIN PARTIAL: recommendations/blog-card -->
<div class="col col-12 group-card rs_read_this">
  <div class="group-card-image" col col-8">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group col col-16">
    <a href="REPLACE" class="group-card-name">Accusamus Nihil Ut Iure</a><br />
    <span class="group-card-date">Posted June 26, 2013</span><br />
    <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
    <div class="card-buttons">
        <span><button type="button" class="button rs_skip">Follow</button></span>
        <span><button class="action-skip-this rs_skip">I am not<br />interested</button></span>
    </div><!-- end .card-buttons -->
  </div><!-- end .group-card-info -->
</div><!-- end .group-card -->
<!-- END PARTIAL: recommendations/blog-card -->
        <!-- BEGIN PARTIAL: recommendations/blog-card -->
<div class="col col-12 group-card rs_read_this">
  <div class="group-card-image" col col-8">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group col col-16">
    <a href="REPLACE" class="group-card-name">Aut Repudiandae Atque Magni</a><br />
    <span class="group-card-date">Posted June 26, 2013</span><br />
    <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
    <div class="card-buttons">
        <span><button type="button" class="button rs_skip">Follow</button></span>
        <span><button class="action-skip-this rs_skip">I am not<br />interested</button></span>
    </div><!-- end .card-buttons -->
  </div><!-- end .group-card-info -->
</div><!-- end .group-card -->
<!-- END PARTIAL: recommendations/blog-card -->
        <!-- BEGIN PARTIAL: recommendations/blog-card -->
<div class="col col-12 group-card rs_read_this">
  <div class="group-card-image" col col-8">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group col col-16">
    <a href="REPLACE" class="group-card-name">Nisi Quae Placeat Consectetur</a><br />
    <span class="group-card-date">Posted June 26, 2013</span><br />
    <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
    <div class="card-buttons">
        <span><button type="button" class="button rs_skip">Follow</button></span>
        <span><button class="action-skip-this rs_skip">I am not<br />interested</button></span>
    </div><!-- end .card-buttons -->
  </div><!-- end .group-card-info -->
</div><!-- end .group-card -->
<!-- END PARTIAL: recommendations/blog-card -->
        <!-- BEGIN PARTIAL: recommendations/blog-card -->
<div class="col col-12 group-card rs_read_this">
  <div class="group-card-image" col col-8">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group col col-16">
    <a href="REPLACE" class="group-card-name">Omnis Aut At Ea</a><br />
    <span class="group-card-date">Posted June 26, 2013</span><br />
    <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
    <div class="card-buttons">
        <span><button type="button" class="button rs_skip">Follow</button></span>
        <span><button class="action-skip-this rs_skip">I am not<br />interested</button></span>
    </div><!-- end .card-buttons -->
  </div><!-- end .group-card-info -->
</div><!-- end .group-card -->
<!-- END PARTIAL: recommendations/blog-card -->
        <!-- BEGIN PARTIAL: recommendations/blog-card -->
<div class="col col-12 group-card rs_read_this">
  <div class="group-card-image" col col-8">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group col col-16">
    <a href="REPLACE" class="group-card-name">Accusamus Dignissimos Porro Est</a><br />
    <span class="group-card-date">Posted June 26, 2013</span><br />
    <span class="group-card-source">From <a href="REPLACE">"Family Matters Blog"</a></span><br />
    <div class="card-buttons">
        <span><button type="button" class="button rs_skip">Follow</button></span>
        <span><button class="action-skip-this rs_skip">I am not<br />interested</button></span>
    </div><!-- end .card-buttons -->
  </div><!-- end .group-card-info -->
</div><!-- end .group-card -->
<!-- END PARTIAL: recommendations/blog-card -->
      </div><!-- end .group-cards -->
    </div><!-- end .col.col-24.container -->
  </div><!-- end .row -->
</div><!-- end .community-groups -->
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
      </div><!-- .slide -->

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
      </div><!-- .slide -->
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
      </div><!-- .slide -->
    </div><!-- .slides-container -->

  </div><!-- .tab-toolkit-header-container --> 
</div><!-- .tab-toolkit-wrapper --> 
<!-- END PARTIAL: recommendations/tab-toolkit -->
          </div>
        </div>
      </div>
  </div>
</div>

