<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Multiple Children.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation.Multiple_Children" %>
<!DOCTYPE html>

<!-- Re: "lang" attribute 
	- The "lang" attribute affects how ReadSpeaker functions. It changes the UI from english to spanish as well as tells  RS to use a different voice.
	- The "lang attribute on the HTML tag is required for the Hyphenator.js plugin to work properly - SEE UN-4020
	- TODO: Integration Task - Language changes should update the "lang" attribute - SEE UN-3673
-->

<!--[if lte IE 8]><html class="no-js nonresponsive old-ie" lang="en"><![endif]-->
<!--[if gte IE 9]><!--><html class="no-js" lang="en"><!--<![endif]-->

<!-- BEGIN PARTIAL: head -->
<head>
  <meta charset="utf-8">
  <title>Recommendations - Multiple Children (R3)</title>

  <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
  
  <meta name="apple-mobile-web-app-capable" content="yes">

  <link rel="icon" type="image/x-icon" href="favicon.ico">
  

  
  
  <link href="Presentation/includes/css/vendor/bootstrap.css" rel="stylesheet" />
<link href="Presentation/includes/css/vendor/normalize.css" rel="stylesheet" />
<link href="Presentation/includes/css/vendor/boilerplate.css" rel="stylesheet" />
<link href="Presentation/includes/css/vendor/royalslider.css" rel="stylesheet" />
<link href="Presentation/includes/css/vendor/jplayer-blue-monday.css" rel="stylesheet" />
<link href="Presentation/includes/css/vendor/ui-lightness/jquery-ui-1.10.4.custom.css" rel="stylesheet" />

  
  <!--[if gte IE 9]><!-->
    <link href="Presentation/includes/css/base.css" rel="stylesheet" />
<link href="Presentation/includes/css/grid.css" rel="stylesheet" />
<link href="Presentation/includes/css/layout.css" rel="stylesheet" />
<link href="Presentation/includes/css/globals.css" rel="stylesheet" />
<link href="Presentation/includes/css/modules.css" rel="stylesheet" />
<link href="Presentation/includes/css/recommendations.css" rel="stylesheet" />
<link href="Presentation/includes/css/uniform-understood.css" rel="stylesheet" />
  <!--<![endif]-->

  
  <!--[if lte IE 8]>
    <link href="Presentation/includes/css/base.css" rel="stylesheet" />
<link href="Presentation/includes/css/grid-nonresponsive.css" rel="stylesheet" />
<link href="Presentation/includes/css/layout-nonresponsive.css" rel="stylesheet" />
<link href="Presentation/includes/css/globals-nonresponsive.css" rel="stylesheet" />
<link href="Presentation/includes/css/modules-nonresponsive.css" rel="stylesheet" />
<link href="Presentation/includes/css/recommendations-nonresponsive.css" rel="stylesheet" />
<link href="Presentation/includes/css/uniform-understood-nonresponsive.css" rel="stylesheet" />
  <![endif]-->

  
  

  
  <script src="Presentation/includes/js/vendor/modernizr.custom.js"></script>

</head>

<!-- END PARTIAL: head -->
<body>
  <form>

    <!-- BEGIN PARTIAL: language-selector -->
<div id="language-selector-bar">

  <span class="button-close ir">Close</span>

  <dl>
    <dt>Language?</dt>
    <dd><a href="REPLACE" class="button">English</a></dd>
    <dd><a href="REPLACE" class="button">Espa&ntilde;ol</a></dd>
  </dl>

</div>
<!-- END PARTIAL: language-selector -->
    
    <div id="wrapper">

      <!-- BEGIN PARTIAL: header -->
<header id="header-page" class="container">
  <div class="row">
    <div class="col col-24">
      
      <div class="logo-u-main">
        <a href="REPLACE">
          <span class="visuallyhidden">Understood for learning and attention issues</span> 
          <img alt="Understood – for learning and attention issues" src="Presentation/includes/images/logo.u.default.png" />
        </a>
      </div><!-- logo-u-main -->

      <ul class="language-selection">
        <li><a href="REPLACE" title="English" class="is-active">Eng</a></li>
        <li><a href="REPLACE" title="Espa&ntilde;ol">Esp</a></li>
      </ul><!-- .language-selection -->
      
      <div class="l-bar">
        
        <nav class="nav-utility">
          <ul role="menu">
            <li role="menuitem" aria-haspopup="true"><a href="REPLACE">About</a></li>
            <li role="menuitem" aria-haspopup="true"><a href="REPLACE">Take Action</a></li>
            <li role="menuitem" aria-haspopup="true"><a href="REPLACE">Donate</a></li>
          </ul>
        </nav><!-- .nav-utility -->

        <!-- BEGIN PARTIAL: user-state -->
<div class="sign-in" aria-haspopup="true">
  <a href="REPLACE" class="link-sign-in">Sign In</a>
</div>

<!-- END PARTIAL: user-state -->

        <div id="search-site">
          <fieldset>
            <legend>Search</legend>

            <span class="field">
              <label for="search-term" class="visuallyhidden" aria-hidden="true">Search</label>
              <input type="text" id="search-term" placeholder="Enter Search Term">
              <input type="submit" value="Go">
            </span>
          </fieldset>
        </div><!-- #search-site -->

      </div><!-- .l-bar -->

      <!-- BEGIN PARTIAL: nav-main -->
<nav class="nav-main">
  <ul role="menu" aria-role="navigation" aria-label="main-navigation">
    <li class="menu-list-item " role="menuitem" aria-haspopup="true">
      <span><a class="top-level-link" href="REPLACE">Learning &amp;<br> Attention Issues</a></span>
      <ul>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit amet consectetuer</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit amet</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor</a></span></li>
      </ul>
    </li>
    <li class="menu-list-item " role="menuitem" aria-haspopup="true">
      <span><a class="top-level-link" href="REPLACE">School &amp;<br> Learning</a></span>
      <ul>
        <li role="menuitem"><span><a href="REPLACE">Partnering with your child's school</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Evaluations</a></span></li>
        <li role="menuitem" ><span><a href="REPLACE">Special Services</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Your child's rights</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Choosing or changing schools</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Learning at home</a></span></li>
      </ul>
    </li>
    <li class="menu-list-item " role="menuitem" aria-haspopup="true">
      <span><a class="top-level-link" href="REPLACE">Friends &amp;<br> Feelings</a></span>
      <ul>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit amet consectetuer</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit amet</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor</a></span></li>
      </ul>
    </li>
    <li class="menu-list-item " role="menuitem" aria-haspopup="true">
      <span><a class="top-level-link" href="REPLACE">You &amp;<br> Your Family</a></span>
      <ul>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit amet consectetuer</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit amet</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor</a></span></li>
      </ul>
    </li>
    <li class="menu-list-item " role="menuitem" aria-haspopup="true">
      <span><a class="top-level-link" href="REPLACE">Community &amp;<br> Events</a></span>
      <ul>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit amet consectetuer</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor sit amet</a></span></li>
        <li role="menuitem"><span><a href="REPLACE">Lorem ipsum dolor</a></span></li>
      </ul>
    </li>
  </ul>
</nav>
<!-- END PARTIAL: nav-main -->

      <div id="toolkit" class="toolkit-element" aria-haspopup="true"><button>Your Parent Toolkit</button></div>

    </div><!-- .col -->
  </div><!-- .row -->

  <!-- toolkit header row -->
  <div class="row toolkit-row">
    <div class="col col-24">
      <!-- BEGIN PARTIAL: toolkit-header -->
<div class="parent-toolkit-wrapper">
  <div class="parent-toolkit-header-container arrows-gray">

    <h2>Your Parent Toolkit</h2>

    <span class="button-close"><i class="icon-close-toolkit"></i>Close</span>

    <div class="slides-container">

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

  </div><!-- .parent-toolkit-header-container --> 
</div><!-- #parent-toolkit-wrapper --> 
<!-- END PARTIAL: toolkit-header -->
    </div>
  </div>

</header><!-- #header-page -->
<!-- END PARTIAL: header -->

      <!-- BEGIN PARTIAL: pagetopic -->
<!-- FIXME: Documentation needed to explain share on/off functionality in page topic module -->

<!-- Determine variables present and change column width to fit the content available -->


<!-- Page Title -->
<div class="container page-topic recommendations with-share">
  <div class="row" >
    <div class="col col-14 offset-1">
      
      <div>
        <h1 class="rs_read_this">Just For You</h1>
        
          <p class="page-subtitle">Customized advice and interactive tools</p>
        
      </div>
    </div>

    

    
    <div class="col col-9">
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
    </div>
    

  </div>
</div><!-- .container -->

<!-- END PARTIAL: pagetopic -->

<div class="recos-for-you-carousels">

  <div class="container recos-for-you-container">

    <div class="row">
      <div class="col col-24">
        <h2>For Michael</h2>
      </div>
    </div>

    <div class="row carousel-container">
      <div class="col col-24">
        <!-- BEGIN PARTIAL: recommendations/carousel-for-you -->

<div class="recos-for-you carousel-recos arrows-gray">

  <ul>

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Facere Quod Dicta Ut Saepe Voluptate Fugit</a></h3>
          <p>Grade 5</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Aut Perferendis Cumque Saepe Exercitationem Dignissimos Eligendi</a></h3>
          <p>Spoken Language</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Aliquid Provident Quod Mollitia Accusantium Natus Ducimus</a></h3>
          <p>Siblings</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Ut Quo Et Exercitationem Sequi Totam Facilis</a></h3>
          <p>Essentials</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Eligendi Beatae Ullam Quia Voluptatem Sit Quod</a></h3>
          <p>Grade 5</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Voluptates Repellat Totam Quae Tenetur Omnis Nostrum</a></h3>
          <p>Spoken Language</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Suscipit Excepturi Laboriosam Aperiam Nesciunt Eaque In</a></h3>
          <p>Siblings</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Ut Quia Voluptatem Voluptas Quas Sit Dolorem</a></h3>
          <p>Essentials</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

  </ul><!-- .slide -->

</div>

<!-- END PARTIAL: recommendations/carousel-for-you -->

        <div class="why-link popover-trigger-container why1-tooltip-trigger">
          <a href="REPLACE" class="popover-link" data-popover-placement="bottom">Why these recommendations? <i class="icon-tooltip"></i></a>
        </div>

        <div class="why1-tooltip popover-container">
          <div class="why1-tooltip-inner">
            <div class="col1">
              <ul class="tags">
                <li>Grade 3</li>
                <li>Boy</li>
              </ul>
            </div>
            <div class="col2">
              <h4>Recommendations match what you told us about Michael:</h4>
              <ul class="list">
                <li>Spoken Language</li>
                <li>Listening comprehension</li>
                <li>Social skills, including conversation</li>
                <li>Motor skills</li>
                <li><a href="REPLACE" class="edit">Edit this list</a></li>
              </ul>
              <a class="button close">Close</a>
            </div>
          </div>
        </div><!-- .why1-tooltip -->

      </div>
    </div>

  </div>

  <div class="container recos-for-you-container">

  <div class="row">
      <div class="col col-24">
        <h2>For Sally</h2>
      </div>
    </div>

    <div class="row carousel-container">
      <div class="col col-24">
        <!-- BEGIN PARTIAL: recommendations/carousel-for-you -->

<div class="recos-for-you carousel-recos arrows-gray">

  <ul>

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Totam Quam Unde Sint Laudantium Aperiam Est</a></h3>
          <p>Grade 5</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Numquam Suscipit Asperiores Est Qui Ut Culpa</a></h3>
          <p>Spoken Language</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Et Laborum Magni Sed Aut Rerum Impedit</a></h3>
          <p>Siblings</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Rerum Accusamus Consequatur Harum Sapiente Est Voluptas</a></h3>
          <p>Essentials</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Autem Veritatis Quis Porro Quis Commodi Facere</a></h3>
          <p>Grade 5</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Cum Quasi Dolores Culpa Modi Voluptas Quia</a></h3>
          <p>Spoken Language</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Inventore Aliquid Similique Corrupti Provident Deserunt Omnis</a></h3>
          <p>Siblings</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

    <li class="article">
        <a class="article-photo" href="REPLACE"><img alt="150x85 Placeholder" src="http://placehold.it/150x85" /></a>
        <div class="article-title">
          <h3><a href="REPLACE">Magnam Exercitationem Beatae Voluptatem Temporibus Facilis Temporibus</a></h3>
          <p>Essentials</p>
          <div class="buttons-container">
            <button class="icon-plus">save this</button>
            <button class="icon-skip">skip</button>
            <button class="icon-bell">remind</button>
          </div>
        </div>
    </li><!-- .article -->

  </ul><!-- .slide -->

</div>

<!-- END PARTIAL: recommendations/carousel-for-you -->

        <div class="why-link popover-trigger-container why2-tooltip-trigger">
          <a href="REPLACE" class="popover-link" data-popover-placement="bottom">Why these recommendations? <i class="icon-tooltip"></i></a>
        </div>

        <div class="why2-tooltip popover-container">
          <div class="why2-tooltip-inner">
            <div class="col1">
              <ul class="tags">
                <li>Grade 2</li>
                <li>Girl</li>
              </ul>
            </div>
            <div class="col2">
              <h4>Recommendations match what you told us about Sally:</h4>
              <ul class="list">
                <li>Spoken Language</li>
                <li>Listening comprehension</li>
                <li>Social skills, including conversation</li>
                <li>Motor skills</li>
                <li><a href="REPLACE" class="edit">Edit this list</a></li>
              </ul>
              <a class="button close">Close</a>
            </div>
          </div>
        </div><!-- .why2-tooltip -->

      </div>
    </div>

  </div><!-- .container -->
</div><!-- .recos-for-you-carousels -->

<div class="recos-upcoming-events container">
  <div class="row">
      <div class="col col-24">
          <h2>Upcoming Events</h2>
          <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows more-upcoming-events next-prev-menu arrows">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
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
        <a href="REPLACE">
          Eos Necessitatibus Facilis Qui Est Atque Ut Et Quaerat
        </a>
      </div>
      <div class="event-card-author">
        Geraldine Markel, Ph.D.
      </div>
      <div class="children">
        <i class="child-a" title="CHILD NAME HERE"></i>
      </div>
    </div><!-- end .event-card-info -->
  </div><!--  end .event-wrapper -->
</div><!-- end .event-card -->
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
        <a href="REPLACE">
          Sit Voluptas In Nulla Autem Sit Et At Inventore
        </a>
      </div>
      <div class="event-card-author">
        Geraldine Markel, Ph.D.
      </div>
      <div class="children">
        <i class="child-a" title="CHILD NAME HERE"></i>
      </div>
    </div><!-- end .event-card-info -->
  </div><!--  end .event-wrapper -->
</div><!-- end .event-card -->
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
        <a href="REPLACE">
          Dolore Saepe Sit Voluptas Consectetur Culpa Maiores Distinctio Fugiat
        </a>
      </div>
      <div class="event-card-author">
        Geraldine Markel, Ph.D.
      </div>
      <div class="children">
        <i class="child-a" title="CHILD NAME HERE"></i>
      </div>
    </div><!-- end .event-card-info -->
  </div><!--  end .event-wrapper -->
</div><!-- end .event-card -->
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
        <a href="REPLACE">
          Voluptas Eum Dolorem Rerum Nostrum Reiciendis Et Est Reiciendis
        </a>
      </div>
      <div class="event-card-author">
        Geraldine Markel, Ph.D.
      </div>
      <div class="children">
        <i class="child-a" title="CHILD NAME HERE"></i>
      </div>
    </div><!-- end .event-card-info -->
  </div><!--  end .event-wrapper -->
</div><!-- end .event-card -->
<!-- END PARTIAL: recommendations/upcoming-event -->
          </div>
      </div>
  </div>
</div><!-- .recos-upcoming-events -->

<div class="recos-ask-parents container">
  <div class="row">
      <div class="col col-24">
          <h2>Ask Our Parents</h2>
          <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows more-ask-parents next-prev-menu arrows">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
          <div class="row parents-cards">
              <!-- BEGIN PARTIAL: recommendations/ask-parents -->
<div class="col col-24 parents-card">
  <div class="parents-wrapper">

    <div class="parents-question">
      <h3>
        Saepe Blanditiis Vero Eos Eaque Facilis Inventore Aut Mollitia
      </h3>
      <p>
        Est Atque Ullam Soluta Odio Illo Et Laboriosam Dolores Temporibus Repudiandae Corrupti Laudantium Quidem In Eum Dolorem Corrupti Rerum Consequatur Optio Adipisci Recusandae Quae
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
  <div class="parents-wrapper">

    <div class="parents-question">
      <h3>
        Praesentium Dignissimos Voluptatem Aut Quisquam Ea Iure Facere Corporis
      </h3>
      <p>
        Maiores Quo Ratione Amet Perferendis Vitae Neque Nemo Sunt Maiores Esse Vel Nihil Eaque Velit Necessitatibus Id Adipisci Dolorum Voluptatem Perspiciatis Consequatur Necessitatibus Dolorem
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
  <div class="parents-wrapper">

    <div class="parents-question">
      <h3>
        Quis Aspernatur Dolor Et Est Aut Voluptatem Ea Sed
      </h3>
      <p>
        Eaque Facilis Consequatur Aut Itaque Sint Voluptas Corrupti Veniam Dolores Sint Est Quisquam Labore Velit Quasi Animi Eius Iure Ratione Officiis Et Quia Nam
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
  <div class="parents-wrapper">

    <div class="parents-question">
      <h3>
        Rerum Quia Et Accusamus Doloremque Aut Sunt Inventore Alias
      </h3>
      <p>
        Consequatur Aspernatur Eos Eum Minima Accusamus Provident Debitis Delectus Eos Praesentium Ad Ex Deleniti Et Et Consequuntur Dolorum Alias Sed Voluptas Ut Quas Molestiae
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
      </div><!-- .children-key --> 
    </div><!-- .col --> 
  </div><!-- .row --> 
</div><!-- .child-content-indicator --> 
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
     <div class="col col-24 parents-member-cards skiplink-content" aria-role="main">

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
                
                    <a href="REPLACE" class="name-member">Gordon73</a>
                    <p class="location">magnam</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button rs_skip">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
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
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
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
                
                    <a href="REPLACE" class="name-member">Jordyn62</a>
                    <p class="location">qui</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button rs_skip">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
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
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
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
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>12th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 12,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
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
                
                    <a href="REPLACE" class="name-member">Nia35</a>
                    <p class="location">quia</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button rs_skip">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
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
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
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
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>11th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 11,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
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
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>12th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
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
                
                    <a href="REPLACE" class="name-member">Kailey93</a>
                    <p class="location">aut</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button rs_skip">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
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
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
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
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>10th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 10,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
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
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>11th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
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
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>12th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover rs_skip">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 12,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
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
  </div><!-- end .group-card-image -->
  <div class="group-card-info group  col col-16">
    <a href="REPLACE" class="group-card-name">Voluptate Et Qui Velit</a><br />
    <span class="group-card-members">682 Members</span><br />
    <span class="group-card-posts">18,844 Posts</span><br />
    <div class="card-buttons">
        <span><button type="button" class="button rs_skip">Join</button></span>
        <span><button class="action-skip-this rs_skip">I am not<br />interested</button></span>
    </div><!-- end .card-buttons -->
  </div><!-- end .group-card-info -->
</div><!-- end .group-card -->
<!-- END PARTIAL: recommendations/group-card -->
        <!-- BEGIN PARTIAL: recommendations/group-card -->
<div class="col col-12 group-card rs_read_this">
  <div class="group-card-image">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group  col col-16">
    <a href="REPLACE" class="group-card-name">Culpa Quis Et Non</a><br />
    <span class="group-card-members">383 Members</span><br />
    <span class="group-card-posts">16,697 Posts</span><br />
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
  <div class="group-card-image">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group  col col-16">
    <a href="REPLACE" class="group-card-name">Ut Sint Nesciunt Voluptas</a><br />
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
  <div class="group-card-image">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group  col col-16">
    <a href="REPLACE" class="group-card-name">Magnam Modi Placeat Quisquam</a><br />
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
  <div class="group-card-image">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group  col col-16">
    <a href="REPLACE" class="group-card-name">Natus Iusto Molestiae Vel</a><br />
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
  <div class="group-card-image">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group  col col-16">
    <a href="REPLACE" class="group-card-name">Debitis Perspiciatis Hic Numquam</a><br />
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
  <div class="group-card-image">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group  col col-16">
    <a href="REPLACE" class="group-card-name">Officia Mollitia Quidem Deleniti</a><br />
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
  <div class="group-card-image">
    <a href="REPLACE">
        <img alt="150x85 Placeholder" src="http://placehold.it/150x85" />
    </a>
  </div><!-- end .group-card-image -->
  <div class="group-card-info group  col col-16">
    <a href="REPLACE" class="group-card-name">Et Est Ut Voluptatibus</a><br />
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
</div><!-- .recos-ask-parents -->



      <!-- BEGIN PARTIAL: footer -->





<!-- BEGIN MODULE: Newsletter Signup -->
<div class="container newsletter-signup">
  <div class="row">

    <div class="col col-12 newsletter-signup-rs-wrapper rs_read_this">

      <header>
        <h2>Personalized Email</h2>
        <p>Stay connected with us by signing up for our weekly personalized emails.</p>
      </header>

    </div><!-- .col -->

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

    </div><!-- .col -->

  </div><!-- .row -->
</div><!-- .container .newsletter-signup -->

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
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
    <li>
      <a href="REPLACE"><img alt="FPO Content image" src="Presentation/includes/images/icon.logo.partnership-carousel.png" /></a>
    </li>
  </ul>
</div><!-- end partners-carousel-container -->
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
      </ul><!-- #footer-nav -->

    </div>
  </div><!-- .row -->
</div><!-- .container -->

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
<footer class="container" id="footer-page" aria-role="content info">
  <div class="row footer-social">

    <div class="col col-7 push-17">
      <ul>
        <!-- NO WHITE SPACE BETWEEN LIs to PRESERVE LAYOUT -->
        <li><a href="REPLACE" class="icon icon-facebook">Facebook</a></li><li><a href="REPLACE" class="icon icon-twitter">Twitter</a></li><li><a href="REPLACE" class="icon icon-google">Google +</a></li><li><a href="REPLACE" class="icon icon-pinterest">Pinterest</a></li>
      </ul>
    </div><!-- /.col -->

    <div class="col col-17 pull-7" role="navigation">
      <ul class="footer-nav-utility" role="menu">
        <!-- NO WHITE SPACE BETWEEN LIs to PRESERVE LAYOUT -->
        <li role="menuitem"><a href="REPLACE">Sitemap</a></li><li role="menuitem"><a href="REPLACE">Terms &amp; Conditions</a></li><li role="menuitem"><a href="REPLACE">Contact Us</a></li><li role="menuitem"><a href="REPLACE">About</a></li>
      </ul>
      <p>All contents copyright © 2013 Understood.  All rights reserved.</p>
      <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum id congue nibh, sit amet aliquet nisi. Donec velit nunc, semper a faucibus at, varius sit amet metus. Maecenas id magna condimentum, vehicula sapien ac, laoreet elit. In hac habitasse platea dictumst.</p>
    </div><!-- .col -->

  </div><!-- .row .footer-social -->

  <div class="row">
    <div class="col col-24">

      <img class="logo-u-footer" alt="Understood U Logo" src="Presentation/includes/images/logo.u.footer.png" />

    </div><!-- .col -->
  </div><!-- .row -->
</footer><!-- footer .container -->

<!-- END MODULE: Footer -->
<!-- END PARTIAL: footer -->

    </div><!-- #wrapper --> 

    <!-- BEGIN PARTIAL: footerjs -->
<script src="Presentation/includes/js/vendor/jquery-1.10.2.min.js" type="text/javascript"></script>
<!--[if lte IE 8]>
<script src="Presentation/includes/js/vendor/selectivizr.js"></script><![endif]-->



<script src="Presentation/includes/js/vendor/jquery.uniform.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.validate.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.royalslider.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.hoverIntent.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.equalheights.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.easytabs.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.jplayer.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery-ui-1.10.4.custom.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.ui.touch-punch.min.js"></script>
<script src="Presentation/includes/js/vendor/bootstrap.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.ezmark.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.mobile.custom.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.placeholder.min.js"></script>
<script src="Presentation/includes/js/vendor/jquery.ellipsis.min.js"></script>
<script src="Presentation/includes/js/vendor/hyphenate.min.js"></script>
<script src="http://misc.readspeaker.com/user/richard/customers/7171/_MIN/ReadSpeaker.js?pids=embhl,custom"></script>
<script src="Presentation/includes/js/site.js"></script>
<script src="Presentation/includes/js/modules.js"></script>
<script src="Presentation/includes/js/recommendations.js"></script>
<script src="Presentation/includes/js/global.js"></script>

<!-- END PARTIAL: footerjs -->

  </form>
</body>

</html>