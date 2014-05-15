<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertLiveDetail.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.ExpertLiveDetail" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Panel runat="server" ID="pnlFilter" CssClass="container">
    <div class="row">
        <div class="container">
            <div class="experts-nav-form  rs_read_this clearfix skiplink-toolbar" id="_b4946f96-6e28-8774-d6b8-0f6a78be2ac1">
                <div id="readspeaker_button1" class="rsbtn_player rs_skip rs_preserve rshidden">
                    <a href="http://app.readspeaker.com/cgi-bin/rsent?customerid=74&amp;lang=en_us&amp;readid=_b4946f96-6e28-8774-d6b8-0f6a78be2ac1&amp;url=http%3A%2F%2Fun-qa-sprint7-20140425.herokuapp.com%2Fcommunity.experts.c3.html" title="Listen" accesskey="L" class="rsbtn_play" data-rsevent-id="rs_900278" role="button">
                        <span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">Listen<span></span></span></span>
                        <span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>
                    </a>
                </div>
                <div class="skip-link-secondary"><a id="Toolbarlink" class="skip-link secondary-navigation-link rs_skip" href="#">Back to Navigation</a></div>
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
                            <li class="current-page" role="presentation">
                                <sc:FieldRenderer runat="server" ID="frLink" FieldName="Link" />
                                <%--<a href="REPLACE" role="menuitem">Featured</a>--%>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </asp:Panel>
                <asp:DropDownList ID="ddlIssue" OnSelectedIndexChanged="ddlIssue_SelectedIndexChanged" runat="server" AutoPostBack="true" Width="150px" name="experts-nav-issue"></asp:DropDownList>
                <asp:DropDownList ID="ddlGrade" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" runat="server" AutoPostBack="true" Width="150px" name="experts-nav-grade"></asp:DropDownList>
                <asp:DropDownList ID="ddlTopics" OnSelectedIndexChanged="ddlTopics_SelectedIndexChanged" runat="server" AutoPostBack="true" Width="150px" name="experts-nav-topic"></asp:DropDownList>

            </div>
            <!-- experts-nav-form -->
        </div>
    </div>
</asp:Panel>
<div class="container events-chat">
    <div class="row">
        <div class="container">
            <div class="col col-12 event-cards skiplink-feature">
                <div class="skip-link-secondary"><a id="Featurelink" class="skip-link secondary-navigation-link rs_skip" href="#">Back to Navigation</a></div>
                <div class="rs_read_this" id="_752c0389-e844-9201-d7c6-05a07a9ff79c">
                    <div id="readspeaker_button2" class="rsbtn_player rs_skip rs_preserve rshidden">
                        <a href="http://app.readspeaker.com/cgi-bin/rsent?customerid=74&amp;lang=en_us&amp;readid=_752c0389-e844-9201-d7c6-05a07a9ff79c&amp;url=http%3A%2F%2Fun-qa-sprint7-20140425.herokuapp.com%2Fcommunity.experts.c3.html" title="Listen" accesskey="L" class="rsbtn_play" data-rsevent-id="rs_917397" role="button">
                            <span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">Listen<span></span></span></span>
                            <span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>
                        </a>
                    </div>
                    <h2 runat="server">
                        <sc:FieldRenderer ID="frUpcomingWebniarsHeading" runat="server" FieldName="Webinars Heading" />
                    </h2>
                    <p class="subhead">
                        <sc:FieldRenderer ID="frUpcomingWebniarsSubheading" runat="server" FieldName="Webinars Subheading" />
                    </p>
                </div>

                <!-- BEGIN PARTIAL: community/experts_event_card -->
                <asp:Repeater runat="server" ID="rptUpcomingWebinars" OnItemDataBound="rptUpcomingWebinars_ItemDataBound">
                    <ItemTemplate>
                        <asp:Panel runat="server" ID="pnlUpcomingWebinars" class="event-card  first col-22 offset-2" Style="height: 210px;">
                            <div class="event-card-info group rs_read_this" id="_a2a7a28b-a9fb-50a4-38df-2f4d3fb937a0">
                                <div id="readspeaker_button3" class="rsbtn_player rs_skip rs_preserve rshidden">
                                    <a href="http://app.readspeaker.com/cgi-bin/rsent?customerid=74&amp;lang=en_us&amp;readid=_a2a7a28b-a9fb-50a4-38df-2f4d3fb937a0&amp;url=http%3A%2F%2Fun-qa-sprint7-20140425.herokuapp.com%2Fcommunity.experts.c3.html" title="Listen" accesskey="L" class="rsbtn_play" data-rsevent-id="rs_960077" role="button">
                                        <span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">Listen<span></span></span></span>
                                        <span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>
                                    </a>
                                </div>
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
                                        <%--Sun Mar 18 at 12am UTC--%>
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
                        </asp:Panel>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Panel runat="server" ID="pnlNoWebniars" class="no-webinars rs_read_this" Visible="false">
                    <sc:FieldRenderer ID="frNoWebniars" runat="server" FieldName="No Webinars Message" />
                </asp:Panel>
                <!-- end .event-card -->
                <!-- END PARTIAL: community/experts_event_card -->
            </div>
            <!-- end .event-cards -->

            <div class="col col-12 event-cards">
                <div class="rs_read_this" id="_35370f8f-d84d-a968-e978-1af2256f5ea1">
                    <div id="readspeaker_button5" class="rsbtn_player rs_skip rs_preserve rshidden">
                        <a href="http://app.readspeaker.com/cgi-bin/rsent?customerid=74&amp;lang=en_us&amp;readid=_35370f8f-d84d-a968-e978-1af2256f5ea1&amp;url=http%3A%2F%2Fun-qa-sprint7-20140425.herokuapp.com%2Fcommunity.experts.c3.html" title="Listen" accesskey="L" class="rsbtn_play" data-rsevent-id="rs_873588" role="button">
                            <span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">Listen<span></span></span></span>
                            <span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>
                        </a>
                    </div>
                    <h2>
                        <sc:FieldRenderer ID="frChatHeading" runat="server" FieldName="Chat Heading"/>
                    </h2>
                    <p class="subhead">
                        <sc:FieldRenderer ID="frChatSubheading" runat="server" FieldName="Chat SubHeading"/>
                    </p>
                </div>
                <!-- BEGIN PARTIAL: community/experts_chat_card -->
                <asp:Repeater runat="server" ID="rptExpertChat" OnItemDataBound="rptExpertChat_ItemDataBound">
                    <ItemTemplate>
                        <asp:Panel runat="server" CssClass="event-card first col-22 offset-2" Style="height: 210px;">
                            <div class="event-card-info group rs_read_this" id="_1f67fd3c-a02a-f15a-6884-d642c13a5549">
                                <div id="readspeaker_button6" class="rsbtn_player rs_skip rs_preserve rshidden">
                                    <a href="http://app.readspeaker.com/cgi-bin/rsent?customerid=74&amp;lang=en_us&amp;readid=_1f67fd3c-a02a-f15a-6884-d642c13a5549&amp;url=http%3A%2F%2Fun-qa-sprint7-20140425.herokuapp.com%2Fcommunity.experts.c3.html" title="Listen" accesskey="L" class="rsbtn_play" data-rsevent-id="rs_610481" role="button">
                                        <span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">Listen<span></span></span></span>
                                        <span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>
                                    </a>
                                </div>
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
                                        <%--<a href="REPLACE">Et Sit Totam Dolore</a>--%>
                                        <asp:HyperLink runat="server" ID="hlChatDetail">
                                            <sc:FieldRenderer ID="frExpertHeading" runat="server" FieldName="Heading" />
                                        </asp:HyperLink>
                                    </div>
                                    <!-- end .event-card-title -->
                                    <p class="event-host-title">
                                        <%--eos consequatur voluptas ut laboriosam neque--%>
                                        <sc:FieldRenderer ID="frHostTitle" runat="server" FieldName="Heading" />
                                    </p>
                                    <span class="children-key">
                                        <ul>
                                            <li><i title="CHILD NAME HERE" class="child-a"></i></li>
                                        </ul>
                                    </span>
                                </div>
                                <!-- end .event-card-details -->
                            </div>
                            <!-- end .event-card-info -->
                        </asp:Panel>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- end .event-card -->
                <!-- END PARTIAL: community/experts_chat_card -->
            </div>
            <!-- end .event-cards -->
        </div>
    </div>

    <div class="row">
        <a href="REPLACE" class="col-4 button offset-20 rs_skip">See Calendar</a>
    </div>
</div>
