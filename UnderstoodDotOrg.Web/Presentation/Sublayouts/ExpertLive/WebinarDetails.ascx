<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebinarDetails.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.WebinarDetails" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container event">

    <header class="row">
      <div class="event-container skiplink-feature">
        <ul class="breadcrumbs">
          <li><a href="REPLACE">Back to Omnis Repudiandae</a></li>
        </ul>

        <h2 class="rs_read_this"><sc:FieldRenderer ID="frPageTItle" runat="server" FieldName="Page Title" /></h2>
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
            <div class="recommended-for">
                <p>Recommended for</p>
                <span class="children-key">
                    <ul>
                        <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
                    </ul>
                </span>
            </div>
            <!-- END PARTIAL: community/experts_recommended_for -->
          </div><!-- end .event-image -->

          <p class="event-date-time"><asp:Literal runat="server" ID="litEventDate" /></p>
          <p class="event-host-name"><sc:FieldRenderer runat="server" ID="frExpertName" FieldName="Expert Name" /></p>
          <p class="event-host-title"><sc:FieldRenderer runat="server" ID="frHostTitle" FieldName="Subheading" /></p>
          <p class="event-topics-subhead"><sc:FieldRenderer ID="frTopicsHeading" runat="server" FieldName="Event Heading" /></p>
          <p class="event-topics"><sc:FieldRenderer ID="frTopics" FieldName="Event Subheading" runat="server" /></p>

          <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />

        </div> <!-- end .event-content -->

        <div class="col-5 col offset-1 event-sidebar rs_read_this">
            <!-- BEGIN PARTIAL: community/experts_recommended_for -->
            <div class="recommended-for">
                <p>Recommended for</p>
                <span class="children-key">
                    <ul>
                        <li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-e' title='CHILD NAME HERE'></i></li>
                    </ul>
                </span>
            </div>
            <!-- END PARTIAL: community/experts_recommended_for -->

            <asp:PlaceHolder ID="phHelpful" runat="server" Visible="false">
                <!-- BEGIN PARTIAL: helpful-count -->
                <div class="count-helpful">
                  <a href="#count-helpful-content"><span>34</span>Found this helpful</a>
                </div>
                <!-- END PARTIAL: helpful-count -->

                <!-- BEGIN PARTIAL: find-helpful -->
                <div class="find-this-helpful sidebar rs_read_this" id="count-helpful-sidebar">
                      <h4>Did you find this helpful?</h4>
                      <ul>
                        <li>
                          <button class="button yes rs_skip">Yes</button>
                        </li>
                        <li>
                          <button class="button no gray rs_skip">No</button>
                        </li>
                      </ul>
                      <div class="clearfix"></div>
                </div>
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
            <sc:FieldRenderer ID="frVideoEmbed" runat="server" FieldName="Video Embed" />
          </div>
        </div>
        <!-- END PARTIAL: video-player -->

        <!-- BEGIN PARTIAL: transcript-control -->
        <div class="transcript-container Video">
          <div class="read-more mobile-close">
            <a href="REMOVE">Close Transcript<i class="icon-arrow-up-blue"></i></a>
          </div>
          <div class="transcript-wrap clearfix rs_read_this">
            <div>
              <h2>Video Transcript</h2>

                <sc:FieldRenderer ID="frVideoTranscript" FieldName="Video Transcript" runat="server" />
            </div>
          </div>
          <div class="read-more read-more-bottom"></div>
        </div>
        <!-- END PARTIAL: transcript-control -->
     
        <!-- BEGIN PARTIAL: find-helpful -->
        <div class="find-this-helpful content rs_read_this" id="count-helpful-content">
              <h4>Did you find this helpful?</h4>
              <ul>
                <li>
                  <button class="button yes rs_skip">Yes</button>
                </li>
                <li>
                  <button class="button no gray rs_skip">No</button>
                </li>
              </ul>
              <div class="clearfix"></div>
        </div>
        <!-- END PARTIAL: find-helpful -->
        
      </div>
    </div>
    </asp:PlaceHolder>
</div>