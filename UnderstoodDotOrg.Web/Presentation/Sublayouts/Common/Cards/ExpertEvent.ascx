<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertEvent.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards.ExpertEvent" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="event-card  first col-22 offset-2">
    <div class="event-card-info group rs_read_this">
        <div class="event-card-image">
            <a href="<%= EventUrl %>">
                <asp:Image ID="imgThumbnail" runat="server" />
                <div class="image-label">
                    <asp:Literal runat="server" ID="litExpertType" />
                </div>
            </a>
        </div>
        <!-- end .event-card-image -->
        <div class="event-card-details">
            <div class="event-card-datetime">
                <asp:Literal runat="server" ID="litEventDate"/>
                <%--Sun Mar 18 at 12am UTC--%>
            </div>
            <!-- end .event-card-datetime -->
            <div class="event-card-title">
                <a href="<%= EventUrl %>">
                    <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                </a>
            </div>
            <!-- end .event-card-title -->
        </div>
        <!-- end .event-card-details -->
    </div>
    <!-- end .event-card-info -->
</div>