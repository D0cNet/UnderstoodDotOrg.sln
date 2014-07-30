<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebinarDetails.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.WebinarDetails" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register Src="~/Presentation/Sublayouts/Recommendation/CommunityRecommendationIcons.ascx" TagPrefix="uc1" TagName="CommunityRecommendationIcons" %>
<div class="container event">

    <header class="row">
      <div class="event-container skiplink-feature">
        <ul class="breadcrumbs">
          <li><asp:HyperLink ID="hlBackExperts" runat="server" /></li>
        </ul>

        <h2 class="rs_read_this">Webinar: <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></h2>
      </div>
    </header>

    <div class="row">
      <div class="event-container">
        <div class="col-18 col event-content rs_read_this">
          <div class="event-image">
            <div class="thumbnail">
              <asp:HyperLink ID="hlExpertDetail" runat="server">
                <asp:Image ID="imgExpert" runat="server" />
                <div class="image-label">
                  <asp:Literal ID="litExpertType" runat="server" />
                </div>
              </asp:HyperLink>
            </div>

            <!-- BEGIN PARTIAL: community/experts_recommended_for -->
            
             <!--Phase 2 --> 
             <%-- --%><div class="recommended-for">
                <p><%= UnderstoodDotOrg.Common.DictionaryConstants.RecommendedForLabel %></p>
                 <uc1:CommunityRecommendationIcons runat="server" ID="CommunityRecommendationIcons2" />
           
            </div>
             
            <!-- END PARTIAL: community/experts_recommended_for -->
          </div><!-- end .event-image -->

          <p class="event-date-time"><asp:Literal runat="server" ID="litEventDate" /></p>
          <p class="event-host-name"><sc:FieldRenderer runat="server" ID="frExpertName" FieldName="Expert Name" /></p>
          <p class="event-host-title"><sc:FieldRenderer runat="server" ID="frHostTitle" FieldName="Expert Heading" /></p>
          <p class="event-topics-subhead">
              <asp:Literal  ID="litTopicsCoveredLabel" runat="server" /></p>
          <p class="event-topics">
              <asp:Literal ID="litTopicsCovered" runat="server" /></p>

          <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />


            <asp:PlaceHolder ID="phCallToActions" runat="server" Visible="false">
                <sc:FieldRenderer ID="frRsvp" Parameters="class=button event-rsvp rs_skip" runat="server" FieldName="RSVP for Event Link" />
                <sc:FieldRenderer ID="frAddToCalendar" Parameters="class=button event-calendar rs_skip" runat="server" FieldName="Add To Calendar Link" />
            </asp:PlaceHolder>

        </div> <!-- end .event-content -->

        <div class="col-5 col offset-1 event-sidebar rs_read_this">
            <!-- BEGIN PARTIAL: community/experts_recommended_for -->
            <%----%>
            <%--  Phase 2--%>
            <div class="recommended-for">
                <p><%= UnderstoodDotOrg.Common.DictionaryConstants.RecommendedForLabel %></p>
                 
                 <uc1:CommunityRecommendationIcons runat="server" ID="CommunityRecommendationIcons" />

            </div>
                
            <!-- END PARTIAL: community/experts_recommended_for -->

            <asp:PlaceHolder ID="phHelpful" runat="server" Visible="false">
                <!-- BEGIN PARTIAL: helpful-count -->
                <sc:sublayout id="Sublayout3" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCountsSideColumn.ascx" />
                <!-- END PARTIAL: helpful-count -->
                
                <!-- BEGIN PARTIAL: find-helpful -->
                <sc:sublayout id="Sublayout2" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" />
            </asp:PlaceHolder>
            <!-- END PARTIAL: find-helpful -->
        </div> <!-- end .event-sidebar -->
      </div>
    </div>

    <asp:PlaceHolder ID="phVideoDetails" runat="server" Visible="false">
    <div class="row webinar-video">
      <div class="container">
        <!-- BEGIN PARTIAL: video-player -->
        <div class="player-container">
          <div class="player">
                <script language="JavaScript" type="text/javascript" src="/includes/js/brightcove/BrightcoveExperiences.js"></script> 
            <sc:FieldRenderer ID="frVideoEmbed" runat="server" FieldName="Video Embed" />
          </div>
        </div>
        <!-- END PARTIAL: video-player -->

        <!-- BEGIN PARTIAL: transcript-control -->
        <div class="transcript-container Video">
          <div class="read-more mobile-close">
            <a href="E"><%= UnderstoodDotOrg.Common.DictionaryConstants.CloseTranscriptLabel %><i class="icon-arrow-up-blue"></i></a>
          </div>
          <div class="transcript-wrap clearfix rs_read_this">
            <div>
              <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.ViewTranscriptLabel %></h2>

                <sc:FieldRenderer ID="frVideoTranscript" FieldName="Video Transcript" runat="server" />
            </div>
          </div>
          <div class="read-more read-more-bottom"></div>
        </div>
        <!-- END PARTIAL: transcript-control -->
     
        <!-- BEGIN PARTIAL: find-helpful -->
        <sc:sublayout id="Sublayout1" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulOther.ascx" />
        <!-- END PARTIAL: find-helpful -->
        
      </div>
    </div>
    </asp:PlaceHolder>
</div>
