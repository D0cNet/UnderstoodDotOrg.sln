<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventArchive.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.EventArchive" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container archive">
    <asp:Panel runat="server" aria-role="main" CssClass="row skiplink-content" DefaultButton="btnSubmit">
        <div class="skip-link-secondary"><a id="Contentlink" class="skip-link secondary-navigation-link rs_skip" href="#">Back to Navigation</a></div>
        <header class="col col-24 rs_read_this" id="_3651aaeb-c6a0-d005-d187-accc015c300e">
            <div id="readspeaker_button15" class="rsbtn_player rs_skip rs_preserve rshidden">
                <a href="http://app.readspeaker.com/cgi-bin/rsent?customerid=74&amp;lang=en_us&amp;readid=_3651aaeb-c6a0-d005-d187-accc015c300e&amp;url=http%3A%2F%2Fun-qa-sprint7-20140425.herokuapp.com%2Fcommunity.experts.c3.html" title="Listen" accesskey="L" class="rsbtn_play" data-rsevent-id="rs_782741" role="button">
                    <span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">Listen<span></span></span></span>
                    <span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>
                </a>
            </div>
            <h2><%--Recently Added to the Archive--%>
                <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Archive Heading" />
            </h2>

            <fieldset class="archive-search-form">
                <label aria-hidden="true" class="visuallyhidden" for="search-archive">Search Archive</label>
                <input type="text" runat="server" id="txtSearch" placeholder="Search archive" name="search-archive" class="archive-search">
                <asp:Button type="submit" runat="server" ClientIDMode="Static" OnClick="btnSubmit_Click" Id="btnSubmit" Text="Go" class="search-button" />
            </fieldset>
        </header>
    </asp:Panel>

    <!-- BEGIN PARTIAL: community/experts_archive_card -->
    <div class="event-cards">
        <asp:Repeater runat="server" ID="rptEventCard" OnItemDataBound="rptEventCard_ItemDataBound">
            <ItemTemplate>
                <div class="row">
                    <div class="event-card rs_read_this" id="_79e7bcc7-411c-1cf0-2dfb-eacfcdc2c807">
                        <div id="readspeaker_button16" class="rsbtn_player rs_skip rs_preserve rshidden">
                            <a href="http://app.readspeaker.com/cgi-bin/rsent?customerid=74&amp;lang=en_us&amp;readid=_79e7bcc7-411c-1cf0-2dfb-eacfcdc2c807&amp;url=http%3A%2F%2Fun-qa-sprint7-20140425.herokuapp.com%2Fcommunity.experts.c3.html" title="Listen" accesskey="L" class="rsbtn_play" data-rsevent-id="rs_388676" role="button">
                                <span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">Listen<span></span></span></span>
                                <span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>
                            </a>
                        </div>
                        <div class="event-card-info group">
                            <div class="event-card-image col equalize">
                                <asp:HyperLink runat="server" ID="hlExpertBio">
                                    <sc:Image ID="scExpertImage" runat="server" Field="Expert Image" />
                                    <asp:Image runat="server" ID="imgExpertDefault" ImageUrl="http://placehold.it/150x150" Visible="false" />
                                    <span class="visuallyhidden">play button</span>
                                    <asp:Panel runat="server" ID="pnlExpertImageLabel" Visible="false" CssClass="image-label">
                                        <asp:Literal runat="server" ID="ltExpertType"></asp:Literal>
                                    </asp:Panel>
                                </asp:HyperLink>
                            </div>
                            <!-- end .event-card-image -->
                            <div class="event-card-details col equalize">
                                <div class="event-card-title">
                                    <asp:HyperLink runat="server" ID="hlWebniearDetail">
                                        <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                                    </asp:HyperLink>
                                </div>
                                <!-- end .event-card-title -->
                                <p class="event-card-topics-head"><sc:FieldRenderer ID="frHeading" runat="server" FieldName="Heading" /></p>
                                <p class="event-card-topics"><sc:FieldRenderer ID="frSubheading" runat="server" FieldName="SubHeading" /></p>
                                <span class="children-key">
                                    <ul>
                                        <li><i title="CHILD NAME HERE" class="child-a"></i></li>
                                        <li><i title="CHILD NAME HERE" class="child-b"></i></li>
                                    </ul>
                                </span>
                            </div>
                            <!-- end .event-card-details -->
                            <div class="event-card-date-details col equalize">
                                <p class="event-type"><asp:Literal runat="server" ID="ltEventType" ></asp:Literal></p>
                                <p class="event-date"><asp:Literal runat="server" ID="ltEventDate" ></asp:Literal></p>
                                <p class="event-date-sub"><asp:Literal runat="server" ID="ltEventSubDate" ></asp:Literal></p>
                            </div>
                        </div>
                        <!-- end .event-card-info -->
                    </div>
                    <!-- end .event-card -->
                </div>
            </ItemTemplate>
        </asp:Repeater>


        <%--<div class="row">
            <div class="event-card rs_read_this" id="_d65f24d6-cda8-5e21-526f-5035e51aee89">
                <div id="readspeaker_button17" class="rsbtn_player rs_skip rs_preserve rshidden">
                    <a href="http://app.readspeaker.com/cgi-bin/rsent?customerid=74&amp;lang=en_us&amp;readid=_d65f24d6-cda8-5e21-526f-5035e51aee89&amp;url=http%3A%2F%2Fun-qa-sprint7-20140425.herokuapp.com%2Fcommunity.experts.c3.html" title="Listen" accesskey="L" class="rsbtn_play" data-rsevent-id="rs_50237" role="button">
                        <span class="rsbtn_left rsimg rspart"><span class="rsbtn_text">Listen<span></span></span></span>
                        <span class="rsbtn_right rsimg rsplay rspart"><i class="icon icon-play"></i></span>
                    </a>
                </div>
                <div class="event-card-info group">
                    <div class="event-card-image col equalize   ">
                        <a href="REPLACE">
                            <img src="http://placehold.it/150x150" alt="150x150 Placeholder">
                            <span class="visuallyhidden">play button</span>
                            <div class="image-label">
                                Expert
                       
                            </div>
                        </a>
                    </div>
                    <!-- end .event-card-image -->
                    <div class="event-card-details col equalize">
                        <div class="event-card-title">
                            <a href="REPLACE">Earum Voluptas Numquam Sed Consequuntur Cumque Aut Veniam Facilis Enim</a>
                        </div>
                        <!-- end .event-card-title -->
                        <p class="event-card-topics-head">Top Questions</p>
                        <p class="event-card-topics">Dignissimos Et Aliquid Aut Ut Et Ratione Libero Beatae Optio</p>
                        <span class="children-key">
                            <ul>
                                <li><i title="CHILD NAME HERE" class="child-a"></i></li>
                                <li><i title="CHILD NAME HERE" class="child-b"></i></li>
                            </ul>
                        </span>
                    </div>
                    <!-- end .event-card-details -->
                    <div class="event-card-date-details col equalize">
                        <p class="event-type">Chat</p>
                        <p class="event-date">Sept 30</p>
                        <p class="event-date-sub">2014</p>
                    </div>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
        </div>--%>
    </div>
    <!-- end .event-cards -->
    <!-- END PARTIAL: community/experts_archive_card -->
    <div class="row">


        <div class="container child-content-indicator">
            <!-- Key -->
            <div class="row">
                <div class="col col-24">
                    <asp:HyperLink runat="server" ID="hlSeeArchive" CssClass="button see-archive" ></asp:HyperLink>
                    <%--<a class="button see-archive" href="REPLACE">See Archive</a>--%>
                    <div aria-hidden="true" class="children-key">
                        <ul>
                            <li><i class="child-a"></i>for Michael</li>
                            <li><i class="child-b"></i>for Elizabeth</li>
                            <li><i class="child-c"></i>for Ethan</li>
                            <li><i class="child-d"></i>for Jeremy</li>
                            <li><i class="child-e"></i>for Franklin</li>
                        </ul>
                    </div>
                    <!-- .children-key -->

                </div>
                <!-- .col -->
            </div>
            <!-- .row -->
        </div>
        <!-- .child-content-indicator -->

    </div>

</div>
