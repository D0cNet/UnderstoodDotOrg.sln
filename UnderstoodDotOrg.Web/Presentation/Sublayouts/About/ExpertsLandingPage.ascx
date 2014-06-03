<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsLandingPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.ExpertsLandingPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container flush l-about-experts-intro-carousel">
  <div class="row skiplink-feature">
    <div class="col col-11 offset-1">
      <!-- BEGIN PARTIAL: about/about-experts-introduction -->
<div class="about-experts-introduction rs_read_this">
    <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />  
</div>
<!-- END PARTIAL: about/about-experts-introduction -->
    </div>
    <div class="col col-11 offset-1">
      <!-- BEGIN PARTIAL: about/about-experts-event-carousel -->
<div class="about-experts-event-carousel">
  <h3 class="rs_read_this"><sc:FieldRenderer ID="frEventCarouselHeading" runat="server" /></h3>

<asp:Repeater ID="rptEvents" runat="server">
    <HeaderTemplate>
        <div class="event-carousel">
            <div class="about-expert">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="about-expert-data rs_read_this">
            <div class="event-carousel-image">
              <img alt="FPO content image" src="http://placehold.it/150x150&amp;text=150x150" />
              <div class="caption">Expert</div>
            </div>
            <div class="event-carousel-details">
              <p class="date">Tue Aug 23 8pm EST</p>
              <p class="chat-with">Chat with</p>
              <h4>Dr. Mangru</h4>
              <p class="credentials">Director of Speech Pathology</p>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
            </div>
        </div>
    </FooterTemplate>
</asp:Repeater>

    </div><!-- /.about-expert -->

  </div><!-- /.event-carousel -->

</div><!-- /.about-experts-event-carousel -->

<!-- END PARTIAL: about/about-experts-event-carousel -->
    </div>
  </div> <!-- end .row -->
</div> <!-- end .container .flush -->


<div class="container" aria-role="main">
  <!-- BEGIN PARTIAL: about/about-experts-listing -->
<div class="about-experts-listing">

  <div class="row">
    <div class="col col-22 offset-1">
      <h3 class="rs_read_this">Learn more about our Experts</h3>
    </div><!-- .col -->
  </div><!-- .row -->

  <div class="row about-expert-row  skiplink-content">
    <div class="col col-6 offset-1">

      <div class="about-expert rs_read_this">
        <div class="expert-listing-image">
          <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
        </div>
        <div class="expert-listing-details">
          <h4>Dr. Axxx</h4>
          <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
          <div class="all-tasks">
            <p class="tasks">Hosts Webinars</p>
            <p class="tasks">Blogs</p>
          </div>
          <a href="REPLACE" class="links">Follow on Twitter</a>
          <a href="REPLACE" class="links">See my bio</a>
        </div>
      </div><!-- .about-expert -->

    </div><!-- .col -->

    <div class="col col-6 offset-2">

      <div class="about-expert rs_read_this">
        <div class="expert-listing-image">
          <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
        </div>
        <div class="expert-listing-details">
          <h4>Dr. Bxxx</h4>
          <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
          <div class="all-tasks">
            <p class="tasks">Hosts Webinars</p>
          </div>
          <a href="REPLACE" class="links">Follow on Twitter</a>
          <a href="REPLACE" class="links">Follow my blog</a>
          <a href="REPLACE" class="links">See my bio</a>
        </div>
      </div><!-- .about-expert -->

    </div><!-- .col -->

    <div class="col col-6 offset-2">

      <div class="about-expert rs_read_this">
        <div class="expert-listing-image">
          <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
        </div>
        <div class="expert-listing-details">
          <h4>Dr. Robert Aunningham</h4>
          <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
          <div class="all-tasks">
            <p class="tasks">Hosts Office Hours &amp; Webinars</p>
          </div>
          <a href="REPLACE" class="links">Follow on Twitter</a>
          <a href="REPLACE" class="links">See my bio</a>
        </div>
      </div><!-- .about-expert -->

    </div><!-- .col -->

  </div><!-- .row -->

  <div class="row about-expert-row">
    <div class="col col-6 offset-1">

      <div class="about-expert rs_read_this">
        <div class="expert-listing-image">
          <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
        </div>
        <div class="expert-listing-details">
          <h4>Dr. Axxx</h4>
          <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
          <div class="all-tasks">
            <p class="tasks">Hosts Webinars</p>
            <p class="tasks">Blogs</p>
          </div>
          <a href="REPLACE" class="links">Follow on Twitter</a>
          <a href="REPLACE" class="links">See my bio</a>
        </div>
      </div><!-- .about-expert -->

    </div><!-- .col -->

    <div class="col col-6 offset-2">

      <div class="about-expert rs_read_this">
        <div class="expert-listing-image">
          <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
        </div>
        <div class="expert-listing-details">
          <h4>Dr. Bxxx</h4>
          <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
          <div class="all-tasks">
            <p class="tasks">Hosts Webinars</p>
          </div>
          <a href="REPLACE" class="links">Follow on Twitter</a>
          <a href="REPLACE" class="links">Follow my blog</a>
          <a href="REPLACE" class="links">See my bio</a>
        </div>
      </div><!-- .about-expert -->

    </div><!-- .col -->

    <div class="col col-6 offset-2">

      <div class="about-expert rs_read_this">
        <div class="expert-listing-image">
          <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
        </div>
        <div class="expert-listing-details">
          <h4>Dr. Robert Aunningham</h4>
          <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
          <div class="all-tasks">
            <p class="tasks">Hosts Office Hours &amp; Webinars</p>
          </div>
          <a href="REPLACE" class="links">Follow on Twitter</a>
          <a href="REPLACE" class="links">See my bio</a>
        </div>
      </div><!-- .about-expert -->

    </div><!-- .col -->

  </div><!-- .row -->

  <div class="row about-expert-row">
    <div class="col col-6 offset-1">

      <div class="about-expert rs_read_this">
        <div class="expert-listing-image">
          <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
        </div>
        <div class="expert-listing-details">
          <h4>Dr. Axxx</h4>
          <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
          <div class="all-tasks">
            <p class="tasks">Hosts Webinars</p>
            <p class="tasks">Blogs</p>
          </div>
          <a href="REPLACE" class="links">Follow on Twitter</a>
          <a href="REPLACE" class="links">See my bio</a>
        </div>
      </div><!-- .about-expert -->

    </div><!-- .col -->

    <div class="col col-6 offset-2">

      <div class="about-expert rs_read_this">
        <div class="expert-listing-image">
          <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
        </div>
        <div class="expert-listing-details">
          <h4>Dr. Bxxx</h4>
          <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
          <div class="all-tasks">
            <p class="tasks">Hosts Webinars</p>
          </div>
          <a href="REPLACE" class="links">Follow on Twitter</a>
          <a href="REPLACE" class="links">Follow my blog</a>
          <a href="REPLACE" class="links">See my bio</a>
        </div>
      </div><!-- .about-expert -->

    </div><!-- .col -->

    <div class="col col-6 offset-2">

      <div class="about-expert rs_read_this">
        <div class="expert-listing-image">
          <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
        </div>
        <div class="expert-listing-details">
          <h4>Dr. Robert Aunningham</h4>
          <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
          <div class="all-tasks">
            <p class="tasks">Hosts Office Hours &amp; Webinars</p>
          </div>
          <a href="REPLACE" class="links">Follow on Twitter</a>
          <a href="REPLACE" class="links">See my bio</a>
        </div>
      </div><!-- .about-expert -->

    </div><!-- .col -->

  </div><!-- .row -->

</div><!-- .about-experts-listing -->
<!-- END PARTIAL: about/about-experts-listing -->
</div><!-- end .container -->

<!-- Show More -->
<!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more rs_skip">
  <div class="row">
    <div class="col col-24">
      <a class="show-more-link " href="#" data-path="about/about-experts-listing" data-container="about-experts-listing" data-item="about-expert" data-count="3">Show More<i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more --><!-- .show-more -->
