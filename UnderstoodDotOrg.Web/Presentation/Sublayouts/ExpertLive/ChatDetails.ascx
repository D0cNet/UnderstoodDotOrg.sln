<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatDetails.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.ChatDetails" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container event">
    <header class="row">
        <div class="event-container">
            <ul class="breadcrumbs">
                <li><asp:HyperLink ID="hlBackExperts" runat="server" /></li>
            </ul>

            <h2 class="rs_read_this"><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></h2>
        </div>
    </header>

    <div class="row">
        <div class="event-container">
            <div class="col-18 col event-content skiplink-content" aria-role="main">
                <div class="rs_read_this">
                    <div class="event-image">
                        <div class="thumbnail">
                            <asp:HyperLink ID="hlExpertDetails" runat="server">
                                <asp:Image ID="imgExpert" runat="server" />
                                <div class="image-label">
                                    <asp:Literal ID="litExpertType" runat="server" />
                                </div>
                            </asp:HyperLink>
                        </div>

                    <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                    <%--
                    Phase 2 
                    <div class="recommended-for">
                        <p>Recommended for</p>
                        <span class="children-key">
                            <ul>
                                <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>--%>
                    <!-- END PARTIAL: community/experts_recommended_for -->
                </div><!-- end .event-image -->

                <p class="event-date-time"><asp:Literal ID="litEventDate" runat="server" /></p>
                <p class="event-host-name"><sc:FieldRenderer ID="frExpertName" runat="server" FieldName="Expert Name" /></p>
                <p class="event-host-title"><sc:FieldRenderer ID="frHostTitle" runat="server" FieldName="Expert Subheading" /></p>
                
                <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />

                <asp:PlaceHolder ID="phCallToActions" runat="server" Visible="false">
                    <sc:FieldRenderer ID="frRsvp" Parameters="class=button event-rsvp rs_skip" FieldName="RSVP for Event Link" runat="server" />
                    <sc:FieldRenderer ID="frAddToCalendar" Parameters="class=button event-calendar rs_skip" runat="server" FieldName="Add To Calendar Link" />
                </asp:PlaceHolder>
            </div>

            <asp:PlaceHolder ID="phPastChatDetails" runat="server" Visible="false">
                <sc:FieldRenderer ID="frChatTranscript" runat="server" FieldName="Chat Transcript" />

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
            </asp:PlaceHolder>
        </div> <!-- end .event-content -->
        
            <div class="col-5 col offset-1 event-sidebar skiplink-sidebar rs_read_this">
                <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                <%--
              Phase 2
                <div class="recommended-for">
                    <p>Recommended for</p>
                    <span class="children-key">
                        <ul>
                            <li><i class='child-a' title='CHILD NAME HERE'></i></li><li><i class='child-b' title='CHILD NAME HERE'></i></li><li><i class='child-c' title='CHILD NAME HERE'></i></li><li><i class='child-d' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>
                </div>--%>
                <!-- END PARTIAL: community/experts_recommended_for -->
                
                <asp:PlaceHolder ID="phPastSidebarDetails" runat="server" Visible="false">
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
                <!-- END PARTIAL: find-helpful -->
                </asp:PlaceHolder>
            </div> <!-- end .event-sidebar -->
        </div>
    </div>
</div>
