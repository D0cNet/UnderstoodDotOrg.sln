<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenOfficeHoursModule.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.OpenOfficeHoursModule" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container live-chat">
    <div class="row">
        <header class="col col-24">
            <div class="rs_read_this">
                <h2><sc:FieldRenderer ID="frLiveChatHeading" runat="server" FieldName="Live Chat Heading" /></h2>
                <p class="subhead"><sc:FieldRenderer ID="frLiveChatSubHeading" runat="server" FieldName="Live Chat SubHeading" /></p>
            </div>
            <ul class="live-chat-navigation">
                <li class="header"><a id="hrefSeeArchive" runat="server" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeAllFragment %></a></li>
                <li class="rsArrow rsArrowLeft">
                    <button class="rsArrowIcn"></button>
                </li>
                <li class="rsArrow rsArrowRight">
                    <button class="rsArrowIcn"></button>
                </li>
            </ul>
        </header>
    </div>

    <asp:Repeater ID="rptExperts" runat="server">
        <HeaderTemplate>
            <div class="live-chat-content row">
                <div class="event-cards">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="col col-12 event-card rs_read_this">
                <div class="event-card-info group">
                    <div class="event-card-upper">
                        <div class="event-card-image">
                            <asp:HyperLink ID="hlExpertDetail" runat="server">
                                <asp:Image ID="imgExpert" runat="server" />
                                <div class="image-label">
                                    <asp:Literal ID="litExpertType" runat="server" />
                                </div>
                            </asp:HyperLink>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <p class="event-card-heading"><%= UnderstoodDotOrg.Common.DictionaryConstants.OfficeHoursWithLabel %></p>
                            <p class="event-card-title"><sc:FieldRenderer ID="frExpertName" runat="server" FieldName="Expert Name" /></p>
                            <p><sc:FieldRenderer ID="frExpertSubheading" runat="server" FieldName="Expert Subheading" /></p>

                            <p class="event-card-info-link"><asp:HyperLink ID="hlExpertDetailCta" runat="server" /></p>
                            <p class="event-card-info-link"><asp:HyperLink ID="hlOfficeHours" runat="server" /></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><asp:HyperLink ID="hlExpertDetailCtaMobile" runat="server" /></p>
                    <p class="event-card-info-link"><asp:HyperLink ID="hlOfficeHoursMobile" runat="server" /></p>
                </div>
                <!-- end .event-card-info -->
            </div>
        </ItemTemplate>
        <FooterTemplate>
                </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>

</div>
