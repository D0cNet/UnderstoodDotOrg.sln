<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsLandingPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.ExpertsLandingPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register TagPrefix="udo" TagName="ExpertListing" Src="~/Presentation/Sublayouts/About/ExpertListing.ascx" %>

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
  <h3 class="rs_read_this"><sc:FieldRenderer ID="frEventCarouselHeading" FieldName="Event Carousel Heading" runat="server" /></h3>

<asp:Repeater ID="rptEvents" runat="server">
    <HeaderTemplate>
        <div class="event-carousel">   
    </HeaderTemplate>
    <ItemTemplate>
        <div class="about-expert">
            <div class="about-expert-data rs_read_this">
                <div class="event-carousel-image">
                  <asp:HyperLink ID="hlEventDetail1" runat="server"><asp:Image ID="imgExpert" runat="server" />
                  <div class="caption"><asp:Literal ID="litExpertType" runat="server" /></div></asp:HyperLink>
                </div>
                <div class="event-carousel-details">
                  <asp:HyperLink ID="hlEventDetail3" runat="server"><p class="date"><asp:Literal ID="litEventDate" runat="server" /></p></asp:HyperLink>
                  <p class="chat-with"><%= UnderstoodDotOrg.Common.DictionaryConstants.ChatWithLabel %></p>
                  <h4><asp:HyperLink ID="hlEventDetail2" runat="server"><sc:FieldRenderer ID="frExpertName" FieldName="Expert Name" runat="server" /></asp:HyperLink></h4>
                  <p class="credentials"><sc:FieldRenderer ID="frExpertSubheading" FieldName="Expert Subheading" runat="server" /></p>
                </div>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>      
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
<div id="about-experts-listing-results" class="about-experts-listing">

  <div class="row">
    <div class="col col-22 offset-1">
      <h3 class="rs_read_this"><sc:FieldRenderer ID="frExpertListHeading" runat="server" FieldName="Expert List Heading" /></h3>
    </div><!-- .col -->
  </div><!-- .row -->

    <udo:ExpertListing ID="expertListing" runat="server" />

</div><!-- .about-experts-listing -->
<!-- END PARTIAL: about/about-experts-listing -->
</div><!-- end .container -->

<!-- Show More -->
<!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<asp:PlaceHolder ID="phShowMore" runat="server" Visible="false">
<div class="container show-more rs_skip">
  <div class="row">
    <div class="col col-24">
      <a id="experts-show-more-results" href="#" data-path="<%= AjaxEndpoint %>" data-container="about-experts-listing-results" data-lang="<%= Sitecore.Context.Language.Name %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more --><!-- .show-more -->
</asp:PlaceHolder>