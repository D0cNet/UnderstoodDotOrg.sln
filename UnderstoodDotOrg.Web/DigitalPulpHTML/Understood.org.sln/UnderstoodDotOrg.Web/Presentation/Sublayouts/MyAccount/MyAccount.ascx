<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.MyAccount" %>
<<%@ Register Src="~/Presentation/Sublayouts/Test/Telligent/MyCommentsTest.ascx" TagName="myComments" TagPrefix="mct" %>

<div class="container">

  <div class="row back-to-previous-nav">
    <!-- article -->
    <div class="col col-22 offset-1">
      <a href="REPLACE" class="back-to-previous"><i class="icon-arrow-left-blue"></i> Back to Homepage</a>
    </div>
  </div><!-- .row -->
</div><!-- .container -->

<!-- BEGIN PARTIAL: my-account-nav -->


<div class="container flush my-account-nav">
  <div class="row account-top-wrapper">
    <div class="col col-23 offset-1">
      <div class="account-photo skiplink-dashboard">
        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
      </div>
      <div class="account-info">
        <h1 class="account-username">SonyasMom65</h1>
        <p class="account-location">Colorado</p>
      </div>
      <div class="account-links">
        <a class="profile-link button" href="REPLACE">My Profile</a>
        <span class="button-wrapper">
          <a class="notifications-link button" href="REPLACE">Notifications<span class="notification-count">3</span></a>
        </span>
      </div>
    </div>
  </div>
  <div class="account-nav-wrapper">
    <div class="row">
      <nav class="account-nav">
        <a class="groups-link" href="REPLACE">
          <div class="icon-wrapper">
            <i class="icon-account-groups"></i>
            <span>Groups</span>
          </div>
        </a>
        <a class="events-link" href="REPLACE">
          <div class="icon-wrapper">
            <i class="icon-account-events"></i>
            <span>Events</span>
          </div>
        </a>
        <a class="comments-link" href="REPLACE">
          <div class="icon-wrapper">
            <i class="icon-account-comments"></i>
            <span>Comments</span>
          </div>
        </a>
        <a class="saved-link" href="REPLACE">
          <div class="icon-wrapper">
            <i class="icon-account-saved"></i>
            <span>Saved</span>
          </div>
        </a>
        <a class="connections-link" href="REPLACE">
          <div class="icon-wrapper">
            <i class="icon-account-connections"></i>
            <span>Connections</span>
          </div>
        </a>
      </nav>
    </div>
  </div>
</div>

<!-- END PARTIAL: my-account-nav -->
<!-- Margins are set in wrapper instead of using flush class to avoid important css -->
<div class="container account-landing-wrapper">
  <div class="row">
    <!-- article -->
    <div class="col col-7 offset-1 large-landing-module skiplink-content" aria-role="main">
      <!-- BEGIN PARTIAL: account-landing-notifications -->
<div class="landing-notifications landing-modules">
  <header class="clearfix">
    <h3>Notifications<span class="landing-module-count">100</span></h3>
  </header>
  
    <ul class="landing-module-items">
      <!-- This template for new connections -->
      <li class="new-connection">
        <p class="timestamp">
          <i class="icon-notification-link"></i>2:48PM <span class="dot"></span> Dec 12 2014
        </p>
        <p class="notification-item">
          Alma Eason <a href="REPLACE">wants to connect</a> with you.
        </p>
        <p class="clearfix button-wrapper">
          <a href="REPLACE" class="button accept-connection">Accept</a>
          <a href="REPLACE" class="button gray decline-connection">Decline</a>
        </p>
      </li>

      <!-- This template for new notes -->
      <li class="new-note">
        <p class="timestamp">
          <i class="icon-notification-reminder"></i>2:48PM <span class="dot"></span> Dec 20 2014
        </p>
        <p class="notification-item">
          iusto minima cum est possimus est rerum doloribus qui incidunt recusandae accusamus recusandae aliquid est
        </p>
        <p class="clearfix button-wrapper">
          <a href="REPLACE" class="button add-a-note">Add a Note</a>
        </p>
      </li>

      <!-- This template for new comments  -->
      <li class="new-comment">
        <p class="timestamp">
          <i class="icon-notification-comment"></i>2:48PM <span class="dot"></span> Dec 16 2014
        </p>
        <p class="notification-item">
          Tonia Walton <a href="REPLACE">added a comment</a> to cumque quis recusandae culpa fugit est beatae mollitia aperiam quaerat omnis impedit ratione officia id
        </p>
      </li>
    </ul>
    <div class="bottom"><a href="REPLACE">See All Notifications</a></div>
  

</div><!-- /.landing-notifications /.landing-modules -->

<!-- END PARTIAL: account-landing-notifications -->
    </div>
    <div class="col col-15 small-landing-modules">

      <div class="row">
        <div class="col col-12">
          <!-- BEGIN PARTIAL: account-landing-mygroups -->
<div class="landing-mygroups landing-modules">
  <header class="clearfix">
    <h3>My Groups<span class="landing-module-count">100</span></h3>
  </header>
  
    <ul class="landing-module-items">
      <li><a href="REPLACE">quis nemo a sit inventore voluptas odit voluptatibus incidunt</a></li>
      <li><a href="REPLACE">et cupiditate dolor alias sit minus ut eos fugit minus</a></li>
      <li><a href="REPLACE">id molestias in aut nihil rerum animi et fugit</a></li>
    </ul>
    <div class="bottom"><a href="REPLACE">See All Groups</a></div>
  
</div><!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-mygroups -->
        </div>
        <div class="col col-12">
          <!-- BEGIN PARTIAL: account-landing-events -->
<div class="landing-events landing-modules">
  <header class="clearfix">
    <h3>Upcoming Events</h3>
  </header>
  <ul class="landing-module-items">
    <li>
      <span class="event-wrap">
        <a href="REPLACE">et ad cum ad doloremque molestias odio earum voluptas porro</a>
        <a href="REPLACE" class="event-type">Webinar</a>
        <span class="timestamp">
          Dec 12 2014 <span class="dot"></span> 2:48PM
        </span>
      </span>
    </li>
    <li>
      <span class="event-wrap">
        <a href="REPLACE">itaque natus sapiente ab labore accusamus velit illo eos ut</a>
        <a href="REPLACE" class="event-type">Q&A</a>
        <span class="timestamp">
          Dec 20 2014 <span class="dot"></span> 2:48PM
        </span>
      </span>
    </li>
  </ul>
  <div class="bottom"><a href="REPLACE">See All Upcoming Events</a></div>
</div><!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-events -->
        </div>
      </div>

      <div class="row">
        <div class="col col-12">
          <!-- BEGIN PARTIAL: account-landing-mycomments -->
<%--<div class="landing-mycomments landing-modules">
  <header class="clearfix">
    <h3>My Comments<span class="landing-module-count">100</span></h3>
  </header>
  
    <ul class="landing-module-items">
      <li>
        <span class="comment-wrap">
          <a href="REPLACE" class="comment-link">sapiente nostrum laborum</a>
          <p class="comment-description">maxime dolor esse et est praesentium laboriosam vel et unde aliquam at vel omnis voluptatem</p>
        </span>
      </li>
      <li>
        <span class="comment-wrap">
          <a href="REPLACE" class="comment-link">veniam ut a</a>
          <p class="comment-description">modi quia labore consectetur ipsa id magnam nam velit aspernatur consectetur dignissimos corrupti voluptate placeat</p>
        </span>
      </li>
    </ul>
    <div class="bottom"><a href="REPLACE">See All Comments</a></div>
  
</div>--%><!-- /.landing-notifications /.landing-modules -->
         <sc:Placeholder key="Content" runat="server" />
            
<!-- END PARTIAL: account-landing-mycomments -->
        </div>
        <div class="col col-12">
          <!-- BEGIN PARTIAL: account-landing-myfavorites -->
<div class="landing-myfavorites landing-modules">
  <header class="clearfix">
    <h3>My Favorites<span class="landing-module-count">100</span></h3>
  </header>
  
    <ul class="landing-module-items">
      <li><a href="REPLACE">velit nisi suscipit iste aspernatur natus fugit nobis ea fugit</a></li>
      <li><a href="REPLACE">iure et dolores sit maxime illum aut praesentium cupiditate vitae</a></li>
      <li><a href="REPLACE">ipsam sed nobis repudiandae facere magni magni sunt dolor natus</a></li>
    </ul>
    <div class="bottom"><a href="REPLACE">See All Favorites</a></div>
  
</div><!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-myfavorites -->
        </div>
      </div>

    </div>
  </div><!-- .row -->
  <div class="row">
    <!-- article -->
    <div class="col col-22 offset-1">
      <!-- BEGIN PARTIAL: account-landing-my-connections -->
<div class="row">
  <div class="landing-modules my-connections">
    <header>
      <h3>My Connections<span class="landing-module-count">102</span></h3>
    </header>
    <section class="connections group" id="user_equal_heights">
      <div class="row member-cards">
        <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="col member-card col-8">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate member">
                
                    <a href="REPLACE" class="name-member">Freya13</a>
                    <p class="location">eveniet</p>
                
            </div><!-- end .member-card-name -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty '><span tabindex='0' data-tabbable='true'>8th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 8,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Molestias Aut</li>
            <li>Fugit Non</li>
            <li>Expedita Velit</li>
            <li>Inventore Eos</li>
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
    <div class="col member-card col-8">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate member">
                
                    <a href="REPLACE" class="name-member">Geraldine61</a>
                    <p class="location">velit</p>
                
            </div><!-- end .member-card-name -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty '><span tabindex='0' data-tabbable='true'>11th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 11,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Incidunt Cupiditate</li>
            <li>Ea Nihil</li>
            <li>Officiis Sit</li>
            <li>Atque Dignissimos</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty specialty-long'><span tabindex='0' data-tabbable='true'>Adult</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Adult,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Voluptatem Quo</li>
            <li>Blanditiis Non</li>
            <li>Rerum Quisquam</li>
            <li>Quae Iste</li>
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
    <div class="col member-card col-8">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate member">
                
                    <a href="REPLACE" class="name-member">Kieran77</a>
                    <p class="location">quia</p>
                
            </div><!-- end .member-card-name -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty '><span tabindex='0' data-tabbable='true'>2nd</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
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
            <li>Aspernatur Consequatur</li>
            <li>Id Repudiandae</li>
            <li>Est Voluptatem</li>
            <li>Enim Dolore</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>10th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
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
            <li>Dolore Nihil</li>
            <li>Beatae Aut</li>
            <li>Culpa Laborum</li>
            <li>Et Explicabo</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>12th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 12,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Et Dolore</li>
            <li>Provident Sed</li>
            <li>Quaerat Laborum</li>
            <li>Distinctio Occaecati</li>
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
      </div>
    </section>
    <div class="bottom"><a href="REPLACE">See All Connections</a></div>
  </div> <!-- /.landing-my-connections.landing-modules -->
</div>
<!-- END PARTIAL: account-landing-my-connections -->
    </div>
  </div><!-- .row -->
</div> <!-- .container -->