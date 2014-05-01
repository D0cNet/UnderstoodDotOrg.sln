<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="All Parents Search.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.All_Parents_Search" %>

 <div class="container community-parents">
        <div class="row">
            <div class="col col-24 skiplink-toolbar">
                <h2 class="offset-1">All Parents</h2>
                <a href="REPLACE" class="link-recommended">Just show parents like me</a>

                <sc:PlaceHolder key="Search_Content" runat="server"></sc:PlaceHolder>
                <div class="col col-24 parents-member-cards skiplink-content" aria-role="main">
                    <sc:PlaceHolder key="Sub_Content" runat="server"></sc:PlaceHolder>
                </div>

              <!-- Show More -->
              <!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more">
  <div class="row">
    <div class="col col-24">
      <a class="show-more-link " href="#" data-path="community/member-cards" data-container="parents-member-cards" data-item="member-card" data-count="20">Show More<i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
              <!-- .show-more -->
                
            </div>
        </div>
    </div>
