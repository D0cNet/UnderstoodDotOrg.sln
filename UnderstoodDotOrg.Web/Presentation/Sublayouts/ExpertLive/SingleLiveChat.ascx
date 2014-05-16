<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SingleLiveChat.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.SingleLiveChat" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="col col-11 offset-1">
    <!-- BEGIN PARTIAL: about/about-experts-event-carousel -->
    <div class="about-experts-event-carousel">
        <h3 class="rs_read_this"><sc:FieldRenderer ID="frLiveChatHeading" runat="server" FieldName="Expert Live Carousel Heading" /> </h3>
        <div class="event-carousel">
            <asp:Repeater ID="rptEventCarousel" runat="server" OnItemDataBound="rptEventCarousel_ItemDataBound">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>

                    <div class="about-expert">
                        <div class="about-expert-data rs_read_this">
                            <div class="event-carousel-image">
                                <sc:Image ID="scExpertImage" runat="server" Field="Expert Image" />
                                <asp:Image runat="server" ID="imgExpertDefault" ImageUrl="http://placehold.it/150x150" Visible="false" />
                                <asp:Panel runat="server" ID="pnlExpertImageLabel" Visible="false" CssClass="caption">
                                    <asp:Literal ID="litExpert" runat="server"></asp:Literal>
                                </asp:Panel>
                            </div>
                            <div class="event-carousel-details">
                                <p class="date">
                                    <%--<sc:Date ID="scDate" runat="server" Field="Event Date" Format="dd MMM yy" />--%>
                                    <asp:Literal runat="server" ID="ltEventDate"></asp:Literal>
                                </p>
                                <p class="chat-with">Chat with</p>
                                <h4>
                                    <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Expert Name" />
                                </h4>
                                <p class="credentials">
                                    <sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="SubHeading" />
                                </p>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!-- /.event-carousel -->

    </div>
    <!-- /.about-experts-event-carousel -->

    <!-- END PARTIAL: about/about-experts-event-carousel -->
</div>
