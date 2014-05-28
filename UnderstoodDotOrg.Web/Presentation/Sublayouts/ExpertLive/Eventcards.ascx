<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Eventcards.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.Eventcards" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container events-chat">
    <div class="row skiplink-content" aria-role="main">
        <div class="container">
            <div class="col col-11 offset-1 event-cards">
                <div class="rs_read_this event-card-heading-wrapper">
                    <h2><sc:FieldRenderer ID="frUpcomingWebinarsHeading" runat="server" FieldName="Webinars Heading" /></h2>
                    <p class="subhead"><sc:FieldRenderer ID="frUpcomingWebinarsSubheading" runat="server" FieldName="Webinars Subheading" /></p>
                </div>

                <sc:Sublayout ID="slExpertEvent" runat="server" Path="~/Presentation/Sublayouts/Common/Cards/ExpertEvent.ascx" />
                    
            </div>
            <!-- end .event-cards -->

            <div class="col col-11 offset-1 event-cards">
                <div class="rs_read_this event-card-heading-wrapper">
                    <h2><sc:FieldRenderer ID="frChatHeading" runat="server" FieldName="Chat Heading" /></h2>
                    <p class="subhead"> <sc:FieldRenderer ID="frChatSubheading" runat="server" FieldName="Chat SubHeading" /></p>
                </div>
                
                <sc:Sublayout ID="slExpertChat" runat="server" Path="~/Presentation/Sublayouts/Common/Cards/ExpertChat.ascx" />
                    
            </div>
            <!-- end .event-cards -->
        </div>

    </div>
</div>
