<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertLiveDetail.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.ExpertLiveDetail" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/ExpertLive/EventFilterNav.ascx" />

<div class="container events-chat">
    <div class="row">
        <div class="container">
            <div class="col col-12 event-cards skiplink-feature">
                <div class="rs_read_this">
                    <h2>
                        <sc:FieldRenderer ID="frUpcomingWebinarsHeading" runat="server" FieldName="Webinars Heading" />
                    </h2>
                    <p class="subhead">
                        <sc:FieldRenderer ID="frUpcomingWebinarsSubheading" runat="server" FieldName="Webinars Subheading" />
                    </p>
                </div>

                <!-- BEGIN PARTIAL: community/experts_event_card -->
                <asp:Repeater runat="server" ID="rptUpcomingWebinars">
                    <ItemTemplate>
                        <sc:Sublayout ID="slExpertEvent" runat="server" Path="~/Presentation/Sublayouts/Common/Cards/ExpertEvent.ascx" />
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Panel runat="server" ID="pnlNoWebinars" class="no-webinars rs_read_this" Visible="false">
                    <sc:FieldRenderer ID="frNoWebinars" runat="server" FieldName="No Webinars Message" />
                </asp:Panel>
                <!-- end .event-card -->
                <!-- END PARTIAL: community/experts_event_card -->
            </div>
            <!-- end .event-cards -->

            <div class="col col-12 event-cards">
                <div class="rs_read_this">
                    <h2>
                        <sc:FieldRenderer ID="frChatHeading" runat="server" FieldName="Chat Heading"/>
                    </h2>
                    <p class="subhead">
                        <sc:FieldRenderer ID="frChatSubheading" runat="server" FieldName="Chat SubHeading"/>
                    </p>
                </div>
                <!-- BEGIN PARTIAL: community/experts_chat_card -->
                <asp:Repeater runat="server" ID="rptExpertChat">
                    <ItemTemplate>
                        <sc:Sublayout ID="slExpertChat" runat="server" Path="~/Presentation/Sublayouts/Common/Cards/ExpertChat.ascx" />
                    </ItemTemplate>
                </asp:Repeater>
                <!-- end .event-card -->
                <asp:Panel runat="server" ID="pnlNoChatMessage" class="no-webinars rs_read_this" Visible="false">
                    <sc:FieldRenderer ID="frNoChatMessage" runat="server" FieldName="No Chat Message" />
                </asp:Panel>
                <!-- END PARTIAL: community/experts_chat_card -->
            </div>
            <!-- end .event-cards -->
        </div>
    </div>
     <div class="row">
           <%-- <a class="col-4 button offset-20" href="REPLACE">See Calendar</a>--%>
         <asp:HyperLink CSSClass="col-4 button offset-20" ID="hypCalendarLink" runat="server" ></asp:HyperLink>
        </div>
</div>
