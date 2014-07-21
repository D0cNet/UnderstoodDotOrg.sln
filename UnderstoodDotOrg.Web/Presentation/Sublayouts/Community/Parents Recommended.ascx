<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parents Recommended.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parents_Recommended" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
    <!-- BEGIN PARTIAL: community/main_header -->


<!-- END PARTIAL: community/main_header -->
 <div class="container community-parents community-parents-recommended">
        <div class="row">
            <div class="container">
                <div class="col col-24 skiplink-content" aria-role="main">
                    <div class="community-parents-rs-wrapper rs_read_this">
                      <a href="REPLACE" id="ref_allParents" runat="server" class="link-back"><i class="icon-arrow-left-blue"></i><%= UnderstoodDotOrg.Common.DictionaryConstants.BackToFragment %> <%= UnderstoodDotOrg.Common.DictionaryConstants.AllParentsLabel %></a>
                      <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.RecommendedForYouLabel %></h2>

                      <div class="community-parents-recommended-wrapper">
                          <sc:FieldRenderer ID="frReccomendedWrapper" FieldName="Get Better Reccomendations Text" runat="server" /> 
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
      <a class="show-more-link " runat="server" id="showmore"  onserverclick="ShowMore_ServerClick" href="#" data-path="community/member-cards" data-container="parents-member-cards" data-item="member-card" data-count="8"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
                  <!-- .show-more -->

                </div>
            </div>
        </div>
    </div>