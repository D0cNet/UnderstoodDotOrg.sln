<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LiveChat.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.LiveChat" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container live-chat">
    <div class="row">
        <header class="col col-24">
            <div class="rs_read_this" id="_97202071-69ea-35e2-ea93-95b896ab0666">
                <div id="readspeaker_button8" class="rsbtn_player rs_skip rs_preserve rshidden">
                    <a href="http://app.readspeaker.com/cgi-bin/rsent?customerid=74&amp;lang=en_us&amp;readid=_97202071-69ea-35e2-ea93-95b896ab0666&amp;url=http%3A%2F%2Fun-qa-sprint7-20140425.herokuapp.com%2Fcommunity.experts.c3.html" title="Listen" accesskey="L" class="rsbtn_play" data-rsevent-id="rs_883985" role="button">
                        <span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">Listen<span></span></span></span>
                        <span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>
                    </a>
                </div>
                <h2><%--Live Chat: Expert Office Hours--%>
                    <sc:FieldRenderer ID="frLiveChatHeading" runat="server" FieldName="Live Chat Heading" />
                </h2>
                <p class="subhead">
                    <sc:FieldRenderer ID="frLiveChatSubHeading" runat="server" FieldName="Live Chat SubHeading" />
                </p>
            </div>
            <ul class="live-chat-navigation">
                <li class="header"><a href="REPLACE">See All</a></li>
                <li class="rsArrow rsArrowLeft rsArrowDisabled">
                    <button class="rsArrowIcn"></button>
                </li>
                <li class="rsArrow rsArrowRight">
                    <button class="rsArrowIcn"></button>
                </li>
            </ul>
        </header>
    </div>

    <div class="live-chat-content row">
        <div class="event-cards rsAutoHeight rsHor" style="height: 255px; visibility: visible;">
            <div class="rsOverflow" style="width: 950px; height: 289px; transition: height 600ms ease-in-out 0s;">
                <div class="rsContainer" style="transition-duration: 0s; transform: translate3d(0px, 0px, 0px);">

                    <asp:Repeater ID="rptLiveChat" runat="server" OnItemDataBound="rptLiveChat_ItemDataBound">
                        <HeaderTemplate>
                            <div class="rsSlide">
                                <div class="m-featured-slide">
                                    <div class="rsContent">
                                        <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <div class="col col-12 event-card rs_read_this">
                                    <div id="readspeaker_button33" class="rsbtn_player rs_skip rs_preserve rshidden">
                                        <a href="http://app.readspeaker.com/cgi-bin/rsent?customerid=74&amp;lang=en_us&amp;readid=f013eaf8-5f95-3e4f-12e6-59abea2a3a2a&amp;url=http%3A%2F%2Fun-qa-sprint7-20140425.herokuapp.com%2Fcommunity.experts.c3.html" title="Listen" accesskey="L" class="rsbtn_play" data-rsevent-id="rs_320805" role="button">
                                            <span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">Listen<span></span></span></span>
                                            <span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>
                                        </a>
                                    </div>
                                    <div class="event-card-info group">
                                        <div class="event-card-upper">
                                            <div class="event-card-image">
                                                <asp:HyperLink ID="hlLInkCardImage" runat="server" TabIndex="-1">
                                                    <sc:Image ID="scExpertImage" runat="Server" Field="Expert Image" />
                                                    <asp:Image runat="server" ID="imgExpertDefault" ImageUrl="http://placehold.it/150x150" Visible="false" />
                                                    <asp:Panel runat="server" ID="pnlExpertImageLabel" Visible="false" CssClass="image-label">
                                                        <asp:Literal ID="litGuest" runat="server"></asp:Literal>
                                                    </asp:Panel>
                                                </asp:HyperLink>
                                            </div>
                                            <!-- end .event-card-image -->
                                            <div class="event-card-details">
                                                <p class="event-card-heading"><%--totam nihil qui--%>
                                                    <%--<sc:FieldRenderer ID="frHostTitle" runat="server" FieldName="Heading" />--%>
                                                    <asp:Literal runat="server" ID="ltOpenOfficeHours" ></asp:Literal>
                                                </p>
                                                <p class="event-card-title"><%--Et Quis Harum--%>
                                                    <sc:FieldRenderer ID="frExpertName" runat="server" FieldName="Expert Name" />
                                                </p>
                                                <sc:FieldRenderer ID="frPageSummary" runat="server" FieldName="Page Summary" />
                                                
                                                <p class="event-card-info-link"><%--<a href="REPLACE" tabindex="-1">quod nihil</a>--%>
                                                    <asp:HyperLink runat="server" ID="hlMeetExpert" ></asp:HyperLink>
                                                </p>
                                                <p class="event-card-info-link"><%--<a href="REPLACE" tabindex="-1">sunt ut</a>--%>
                                                    <asp:HyperLink runat="server" ID="hlOfficeHours" ></asp:HyperLink>

                                                </p>
                                            </div>
                                            <!-- end .event-card-details -->
                                        </div>

                                        <!-- Duplicate links for mobile to accomplish mobile layout -->
                                        <p class="event-card-info-link"><a href="REPLACE">aspernatur consectetur</a></p>
                                        <p class="event-card-info-link"><a href="REPLACE">incidunt assumenda</a></p>
                                    </div>
                                    <!-- end .event-card-info -->
                                </div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                                   </div>
                                     </div>
                                         </div>
                        </FooterTemplate>
                    </asp:Repeater>






                </div>
            </div>
            <div style="clear: both; float: none;"></div>
        </div>
        <!-- end .event-cards -->
    </div>
</div>
