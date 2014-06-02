<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertChat.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards.ExpertChat" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="event-card first col-22 offset-2">
    <div class="event-card-info group rs_read_this">
        <div class="event-card-image">
            <asp:HyperLink ID="hlExpertDetail" runat="server">
                <asp:Image runat="server" ID="imgThumbnail" />

                <div class="image-label">
                    <asp:Literal runat="server" ID="litExpertType" />
                </div>
            </asp:HyperLink>
        </div><!-- end .event-card-image -->
        <div class="event-card-details">
            <div class="event-card-datetime">
                <asp:Literal ID="litEventDate" runat="server" />
            </div><!-- end .event-card-datetime -->
            <div class="event-card-title">
                <asp:HyperLink ID="hlEventDetail" runat="server">
                    <sc:FieldRenderer ID="frExpertHeading" runat="server" FieldName="Expert Heading" />
                </asp:HyperLink>
            </div><!-- end .event-card-title -->
            <p class="event-host-title"><sc:FieldRenderer ID="frExpertSubheading" runat="server" FieldName="Expert Subheading" /></p>
            <span class="children-key">
              <ul>
                  <li><i class="child-a" title="CHILD NAME HERE"></i></li>
              </ul>
            </span>
        </div><!-- end .event-card-details -->
    </div><!-- end .event-card-info -->
</div><!-- end .event-card -->