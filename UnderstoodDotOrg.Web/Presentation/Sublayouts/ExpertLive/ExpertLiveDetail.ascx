<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertLiveDetail.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.ExpertLiveDetail" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Panel runat="server" ID="pnlFilter" CssClass="container">
    <div class="row">
        <div class="container">
            <div class="experts-nav-form  rs_read_this clearfix skiplink-toolbar">
                <asp:Panel runat="server" ID="pnlExpertLiveFilter" class="dropdown">
                    <a href="#" data-toggle="dropdown" role="button" class="dropdown-toggle">
                        <span class="current-page">Featured</span>
                        <span class="dropdown-title rs_skip">Filter By</span>
                    </a>
                    <asp:Repeater runat="server" ID="rptFilter" OnItemDataBound="rptFilter_ItemDataBound">
                        <HeaderTemplate>
                            <ul role="menu" class="dropdown-menu rs_skip">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li class="" role="presentation">
                                <sc:FieldRenderer runat="server" ID="frLink" FieldName="Link" />
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </asp:Panel>
                <asp:DropDownList ID="ddlIssue" OnSelectedIndexChanged="ddlIssue_SelectedIndexChanged" runat="server" AutoPostBack="true" name="experts-nav-issue"></asp:DropDownList>
                <asp:DropDownList ID="ddlGrade" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" runat="server" AutoPostBack="true" name="experts-nav-grade"></asp:DropDownList>
                <asp:DropDownList ID="ddlTopics" OnSelectedIndexChanged="ddlTopics_SelectedIndexChanged" runat="server" AutoPostBack="true" name="experts-nav-topic"></asp:DropDownList>

            </div>
            <!-- experts-nav-form -->
        </div>
    </div>
</asp:Panel>
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
</div>
