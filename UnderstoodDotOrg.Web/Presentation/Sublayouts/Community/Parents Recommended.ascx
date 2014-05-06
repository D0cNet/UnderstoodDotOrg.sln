﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parents Recommended.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parents_Recommended" %>

 <div class="container community-parents community-parents-recommended">
        <div class="row">
            <div class="container">
                <div class="col col-24 skiplink-content" aria-role="main">
                    <div class="community-parents-rs-wrapper rs_read_this">
                      <a href="REPLACE" class="link-back"><i class="icon-arrow-left-blue"></i>Back to All Parents</a>
                      <h2>Recommended for You</h2>

                      <div class="community-parents-recommended-wrapper">
                      <p class="explanation">Numquam iusto earum qui dolorem voluptas quas ut laborum. Nemo libero quo non. Fuga aperiam sint rerum velit omnis sit aliquam.</p>
                      <p class="explanation">For better recommendations, <a href="REPLACE">complete your full profile</a>.</p>
                    </div>
                    </div>
                    
                    <div class="col col-24 parents-member-cards">
                                   <%-- Used another repeater because of dynamic datasourcing--%>
                        <asp:PlaceHolder ID="memberList" runat="server"></asp:PlaceHolder>
                       <%-- <mcl:membercardlist id="rptMemberCards" runat="server"></mcl:membercardlist>--%>
                    </div>

                  <!-- Show More -->
                  <!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more rs_skip">
  <div class="row">
    <div class="col col-24">
      <a class="show-more-link " runat="server" id="showmore"  onserverclick="ShowMore_ServerClick" href="#" data-path="community/member-cards" data-container="parents-member-cards" data-item="member-card" data-count="8">Show More<i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
                  <!-- .show-more -->

                </div>
            </div>
        </div>
    </div>