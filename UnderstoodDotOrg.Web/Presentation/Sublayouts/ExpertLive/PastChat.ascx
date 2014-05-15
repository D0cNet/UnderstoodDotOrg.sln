<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PastChat.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.PastChat" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container event">
    <header class="row">
        <div class="event-container">
            <ul class="breadcrumbs">
                <p>
                    <li><a href="REPLACE">Back to Blanditiis Aut</a></li>
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
                            <asp:HyperLink ID="hlLink" runat="server">
                                <sc:FieldRenderer ID="scThumbImg" runat="server" FieldName="Expert Image" />
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
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                        <!-- END PARTIAL: community/experts_recommended_for -->
                    </div>
                    <!-- end .event-image -->

                    <p class="event-date-time">
                        <%--<sc:Date ID="scDate" runat="server" Field="Event Date" Format="dd MMM yy" />--%>
                        <asp:Literal runat="server" ID="ltEventDate"></asp:Literal>
                    </p>
                    <p class="event-host-name"><sc:FieldRenderer ID="frHeading" runat="server" FieldName="Heading" /></p>
                    <p class="event-host-title"> <sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="SubHeading" /></p>
                     <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />
                </div>

                <asp:Repeater runat="server" ID="rptComments" OnItemDataBound="rptComments_ItemDataBound">
                    <ItemTemplate>
                        <div class="rs_read_this past-chat-rs-wrapper">
                            <h4 class="question"><%--Qui Corporis Amet--%>
                                <sc:fieldrenderer id="frTitle" runat="server" fieldname="Comment Title" />
                            </h4>
                            <sc:fieldrenderer id="frContent" runat="server" fieldname="Content" />
                            <%--<p>Sit quidem odio alias non. veritatis fuga aut eum nobis aut nulla facilis sapiente asperiores incidunt. magni nam quis voluptate reprehenderit id recusandae reiciendis nam sed est fugit quos est aliquid. autem dolores maxime ducimus qui. est porro consequatur quibusdam sit soluta quia eaque saepe et</p>--%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <!-- BEGIN PARTIAL: community/experts_was_this_helpful -->
                <div class="was-this-helpful clearfix" id="count-helpful">

                    <p class="helpful-count"><em>74</em>Found this helpful</p>


                    <h4>Did you find this helpful?</h4>
                    <a class="button yes rs_skip" href="REPLACE">Yes</a>
                    <a class="button gray no rs_skip" href="REPLACE">No</a>
                </div>
                <!-- END PARTIAL: community/experts_was_this_helpful -->
            </div>
            <!-- end .event-content -->
            <div class="col-5 col offset-1 event-sidebar skiplink-sidebar rs_read_this">
                <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                <div class="recommended-for">
                    <p>Recommended for</p>
                    <span class="children-key">
                        <ul>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>
                </div>
                <!-- END PARTIAL: community/experts_recommended_for -->
                <!-- BEGIN PARTIAL: community/experts_was_this_helpful -->
                <div class="was-this-helpful clearfix" id="Div1">

                    <p class="helpful-count"><em>75</em>Found this helpful</p>


                    <h4>Did you find this helpful?</h4>
                    <a class="button yes rs_skip" href="REPLACE">Yes</a>
                    <a class="button gray no rs_skip" href="REPLACE">No</a>
                </div>
                <!-- END PARTIAL: community/experts_was_this_helpful -->
            </div>
            <!-- end .event-sidebar -->
        </div>
    </div>
</div>





