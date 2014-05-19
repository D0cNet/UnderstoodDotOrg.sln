<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PastWebinar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.PastWebinar" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container event">
    <header class="row">
        <div class="event-container skiplink-feature">
            <ul class="breadcrumbs">
                <p>
                    <li><%--<a href="REPLACE">Back to Ducimus Quia</a>--%>
                        <asp:HyperLink runat="server" ID="hlBackToLink" ></asp:HyperLink>
                    </li>
            </ul>

            <h2 class="rs_read_this"> <sc:FieldRenderer ID="frPageTItle" runat="server" FieldName="Page Title" /></h2>
        </div>
    </header>

    <div class="row">
        <div class="event-container">
            <div class="col-18 col event-content rs_read_this">
                <div class="event-image">
                    <div class="thumbnail">
                       <asp:HyperLink ID="hlLink" runat="server">
                            <sc:FieldRenderer ID="scThumbImg" runat="server" FieldName="Expert Image" />
                            <asp:Image runat="server" ID="imgExpertDefault" ImageUrl="http://placehold.it/150x150" Visible="false" />
                            <div class="image-label">
                                <asp:Literal ID="litGuest" runat="server"></asp:Literal>
                            </div>
                        </asp:HyperLink>
                    </div>

                    <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                    <div class="recommended-for">
                        <p>Recommended for</p>
                        <span class="children-key">
                            <ul>
                                <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                    <!-- END PARTIAL: community/experts_recommended_for -->
                </div>
                <!-- end .event-image -->

                <p class="event-date-time"><asp:Literal runat="server" ID="ltEventDate"></asp:Literal></p>
                <p class="event-host-name"><sc:FieldRenderer ID="frExpertName" runat="server" FieldName="Expert Name" /></p>
                <p class="event-host-title"><sc:FieldRenderer ID="frHeading" runat="server" FieldName="Heading" /></p>
                <p class="event-topics-subhead"><sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="Subheading" /></p>
                <p class="event-topics"><sc:FieldRenderer ID="frEventHeading" runat="server" FieldName="Heading" /></p>
                <sc:FieldRenderer ID="frbody" runat="server" FieldName="Body Content" />
                <%--<p>Earum fuga quia porro unde libero. laudantium natus quis fugit sed eum distinctio esse fugit sequi corporis molestias. aut dolorum ut voluptatum ipsum in iure minus quae</p>--%>

            </div>
            <!-- end .event-content -->
            <div class="col-5 col offset-1 event-sidebar rs_read_this">
                <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                <div class="recommended-for">
                    <p>Recommended for</p>
                    <span class="children-key">
                        <ul>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>
                </div>
                <!-- END PARTIAL: community/experts_recommended_for -->
                <!-- BEGIN PARTIAL: community/experts_was_this_helpful -->
                <div class="was-this-helpful clearfix" id="count-helpful">

                    <p class="helpful-count"><em>30</em>Found this helpful</p>


                    <h4>Did you find this helpful?</h4>
                    <a class="button yes rs_skip" href="REPLACE">Yes</a>
                    <a class="button gray no rs_skip" href="REPLACE">No</a>
                </div>
                <!-- END PARTIAL: community/experts_was_this_helpful -->
            </div>
            <!-- end .event-sidebar -->
        </div>
    </div>

    <asp:Panel runat="server" ID="pnlVideo" CssClass="row webinar-video" Visible="false">
        <div class="container">
            <!-- BEGIN PARTIAL: video-player -->
            
            <sc:Sublayout ID="sbAboutAuthor" runat="server" Path="~/Presentation/Sublayouts/ExpertLive/VideoResources.ascx" Visible="true" />
                    <%--<script language="JavaScript" type="text/javascript" src="http://admin.brightcove.com/js/BrightcoveExperiences.js"></script>
                    <object class="BrightcoveExperience">
                        <param name="bgcolor" value="#FFFFFF" />
                        <param name="width" value="480" />
                        <param name="height" value="270" />
                        <param name="playerID" value="3203925133001" />
                        <param name="playerKey" value="AQ~~,AAAC6NDP1nE~,dOSiqHy89Sli4ZPOUFfVGW6O9wJ4rR6y" />
                        <param name="isVid" value="true" />
                        <param name="isUI" value="true" />
                        <param name="dynamicStreaming" value="true" />
                        <param name="@videoPlayer" value="3203925031001" />
                        <param name="includeAPI" value="true" />
                    </object>--%>
                
            <!-- END PARTIAL: video-player -->

            
        </div>

        <div class="webinar-actions clearfix">
            <!-- BEGIN PARTIAL: community/experts_was_this_helpful -->
            <div class="was-this-helpful clearfix" id="Div1">


                <h4>Did you find this helpful?</h4>
                <a class="button yes rs_skip" href="REPLACE">Yes</a>
                <a class="button gray no rs_skip" href="REPLACE">No</a>
            </div>
            <!-- END PARTIAL: community/experts_was_this_helpful -->
        </div>
    </asp:Panel>
</div>
