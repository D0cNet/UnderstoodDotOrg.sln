<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Eventcards.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.Eventcards" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container events-chat">
    <div class="row skiplink-content" aria-role="main">
        <div class="container">
            <div class="col col-11 offset-1 event-cards">
                <div class="rs_read_this event-card-heading-wrapper">
                    <h2><sc:FieldRenderer ID="frUpcomingWebniarsHeading" runat="server" FieldName="Webinars Heading" /></h2>
                    <p class="subhead"><sc:FieldRenderer ID="frUpcomingWebniarsSubheading" runat="server" FieldName="Webinars Subheading" /></p>
                </div>

                <!-- BEGIN PARTIAL: community/experts_event_card -->
                <asp:Repeater runat="server" ID="rptUpcomingWebinars" OnItemDataBound="rptUpcomingWebinars_ItemDataBound">
                    <ItemTemplate>
                        <div class="event-card col-22 offset-2">
                            <div class="event-card-info group rs_read_this">
                                <div class="event-card-image">
                                     <asp:HyperLink runat="server" ID="hlExpertBio">
                                        <sc:Image ID="scExpertImage" runat="server" Field="Expert Image" />
                                        <asp:Image runat="server" ID="imgExpertDefault" ImageUrl="http://placehold.it/150x150" Visible="false" />
                                        <asp:Panel runat="server" ID="pnlExpertImageLabel" Visible="false" CssClass="image-label">
                                            <asp:Literal runat="server" ID="ltExpertType"></asp:Literal>
                                            <%--Expert--%>
                                        </asp:Panel>
                                    </asp:HyperLink>
                                </div>
                                <!-- end .event-card-image -->
                                <div class="event-card-details">
                                    <div class="event-card-datetime">
                                        <asp:Literal runat="server" ID="ltEventDate"></asp:Literal>
           
                                    </div>
                                    <!-- end .event-card-datetime -->
                                    <div class="event-card-title">
                                       <asp:HyperLink runat="server" ID="hlWebniearDetail">
                                            <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                                        </asp:HyperLink>
                                    </div>
                                    <!-- end .event-card-title -->
                                </div>
                                <!-- end .event-card-details -->
                            </div>
                            <!-- end .event-card-info -->
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- end .event-card -->
                <!-- END PARTIAL: community/experts_event_card -->
            </div>
            <!-- end .event-cards -->

            <div class="col col-11 offset-1 event-cards">
                <div class="rs_read_this event-card-heading-wrapper">
                    <h2><sc:FieldRenderer ID="frChatHeading" runat="server" FieldName="Chat Heading" /></h2>
                    <p class="subhead"> <sc:FieldRenderer ID="frChatSubheading" runat="server" FieldName="Chat SubHeading" /></p>
                </div>
                <!-- BEGIN PARTIAL: community/experts_chat_card -->
                <asp:Repeater runat="server" ID="rptExpertChat" OnItemDataBound="rptExpertChat_ItemDataBound">
                    <ItemTemplate>
                        <div class="event-card col-22 offset-2">
                            <div class="event-card-info group rs_read_this">
                                <div class="event-card-image">
                                   <asp:HyperLink runat="server" ID="hlExpertBio">
                                        <sc:Image ID="scExpertImage" runat="server" Field="Expert Image" />
                                        <asp:Image runat="server" ID="imgExpertDefault" ImageUrl="http://placehold.it/150x150" Visible="false" />

                                        <asp:Panel runat="server" ID="pnlExpertImageLabel" Visible="false" CssClass="image-label">
                                            <asp:Literal runat="server" ID="ltExpertType"></asp:Literal>
                                        </asp:Panel>
                                    </asp:HyperLink>
                                </div>
                                <!-- end .event-card-image -->
                                <div class="event-card-details">
                                    <div class="event-card-datetime">
                                         <asp:Literal runat="server" ID="ltEventDate"></asp:Literal>
           
                                    </div>
                                    <!-- end .event-card-datetime -->
                                    <div class="event-card-title">
                                         <asp:HyperLink runat="server" ID="hlChatDetail">
                                            <sc:FieldRenderer ID="frExpertHeading" runat="server" FieldName="Heading" />
                                        </asp:HyperLink>
                                    </div>
                                    <!-- end .event-card-title -->
                                    <p class="event-host-title"><sc:FieldRenderer ID="frHostTitle" runat="server" FieldName="Heading" /></p>
                                </div>
                                <!-- end .event-card-details -->
                            </div>
                            <!-- end .event-card-info -->
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- end .event-card -->
                <!-- END PARTIAL: community/experts_chat_card -->
            </div>
            <!-- end .event-cards -->
        </div>

        <a href="REPLACE" class="button see-calendar rs_skip">See Calendar</a>
    </div>
</div>
