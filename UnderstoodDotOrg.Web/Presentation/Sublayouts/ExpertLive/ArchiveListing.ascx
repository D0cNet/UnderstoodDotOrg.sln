<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArchiveListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.ArchiveListing" %>
<!-- BEGIN PARTIAL: community/experts_sub_nav -->
<div class="container">
    <div class="row">
        <div class="container">
            <asp:Panel runat="server" ID="pnlSearch" CssClass="experts-nav-form  rs_read_this clearfix skiplink-toolbar" DefaultButton="btnSubmit">
                <div class="dropdown">
                    <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                        <span class="current-page">Archive</span>
                        <span class="dropdown-title rs_skip">Filter By</span>
                    </a>
                    <asp:Repeater runat="server" ID="rptFilter" OnItemDataBound="rptFilter_ItemDataBound">
                        <HeaderTemplate>
                            <ul role="menu" class="dropdown-menu rs_skip">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li class="current-page" role="presentation">
                                <sc:fieldrenderer runat="server" id="frLink" fieldname="Link" />
                                <%--<a href="REPLACE" role="menuitem">Featured</a>--%>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <asp:DropDownList ID="ddlIssue" OnSelectedIndexChanged="ddlIssue_SelectedIndexChanged" runat="server" AutoPostBack="true" Width="150px" name="experts-nav-issue"></asp:DropDownList>
                <asp:DropDownList ID="ddlGrade" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" runat="server" AutoPostBack="true" Width="150px" name="experts-nav-grade"></asp:DropDownList>
                <asp:DropDownList ID="ddlTopics" OnSelectedIndexChanged="ddlTopics_SelectedIndexChanged" runat="server" AutoPostBack="true" Width="150px" name="experts-nav-topic"></asp:DropDownList>

                <fieldset class="archive-search-form">
                    <label for="search-archive-text" class="visuallyhidden" aria-hidden="true">Search archive</label>
                    <input runat="server" id="txtSearch" type="text" class="archive-search" name="search-archive" placeholder="Search archive" />
                    <asp:Button type="submit" runat="server" ClientIDMode="Static" OnClick="btnSubmit_Click" ID="btnSubmit" Text="Go" class="search-button" />
                </fieldset>
            </asp:Panel>
            <!-- experts-nav-form -->
        </div>
    </div>
</div>
<!-- END PARTIAL: community/experts_sub_nav -->

<div class="container archive">
    <div class="row skiplink-content" aria-role="main">
        <header class="col col-24">
            <h2 class="rs_read_this">Experts Live: Archive</h2>
        </header>
    </div>

    <div class="event-cards-container">
        <!-- BEGIN PARTIAL: community/experts_archive_card -->
        <div class="event-cards">
            <asp:Repeater runat="server" ID="rptEventCard" OnItemDataBound="rptEventCard_ItemDataBound">
                <ItemTemplate>
                    <div class="row">
                        <div class="event-card rs_read_this">
                            <div class="event-card-info group">
                                <div class="event-card-image col equalize   ">
                                    <asp:HyperLink runat="server" ID="hlExpertBio">
                                        <sc:image id="scExpertImage" runat="server" field="Expert Image" />
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
                                            <sc:fieldrenderer id="frPageTitle" runat="server" fieldname="Page Title" />
                                        </asp:HyperLink>
                                    </div>
                                    <!-- end .event-card-title -->
                                    <p class="event-card-topics-head">
                                        <sc:fieldrenderer id="frHeading" runat="server" fieldname="Heading" />
                                    </p>
                                    <p class="event-card-topics">
                                        <sc:fieldrenderer id="frSubheading" runat="server" fieldname="SubHeading" />
                                    </p>
                                    <span class="children-key">
                                        <ul>
                                            <li><i class="child-a" title="CHILD NAME HERE"></i></li>
                                            <li><i class="child-b" title="CHILD NAME HERE"></i></li>
                                        </ul>
                                    </span>
                                </div>
                                <!-- end .event-card-details -->
                                <div class="event-card-date-details col equalize">
                                    <p class="event-type">
                                        <asp:Literal runat="server" ID="ltEventType"></asp:Literal>
                                    </p>
                                    <p class="event-date">
                                        <asp:Literal runat="server" ID="ltEventDate"></asp:Literal>
                                    </p>
                                    <p class="event-date-sub">
                                        <asp:Literal runat="server" ID="ltEventSubDate"></asp:Literal>
                                    </p>
                                </div>
                                <!-- end .event-card-details -->

                            </div>
                            <!-- end .event-card-info -->
                        </div>
                        <!-- end .event-card -->
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%--<div class="row">
                <div class="event-card rs_read_this">
                    <div class="event-card-info group">
                        <div class="event-card-image col equalize   ">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <span class="visuallyhidden">play button</span>
                                <div class="image-label">
                                    Guest Expert
                       
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details col equalize">
                            <div class="event-card-title">
                                <a href="REPLACE">Omnis Amet Enim Ullam Repellendus Pariatur Ea Adipisci Odit Eum</a>
                            </div>
                            <!-- end .event-card-title -->
                            <p class="event-card-topics-head">Top Questions</p>
                            <p class="event-card-topics">Sint Praesentium Consequatur Voluptatem Voluptatem Tenetur Non Magnam Impedit Id</p>
                            <span class="children-key">
                                <ul>
                                    <li><i class="child-a" title="CHILD NAME HERE"></i></li>
                                    <li><i class="child-b" title="CHILD NAME HERE"></i></li>
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

    </div>
</div>


<!-- Show More -->
<!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more rs_skip">
    <div class="row">
        <div class="col col-24">
            <a class="show-more-link " href="#" data-path="community/event-cards" data-container="event-cards-container" data-item="event-cards" data-count="4">Show More<i class="icon-arrow-down-blue"></i></a>
        </div>
    </div>
</div>
<!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
<!-- .show-more -->

<!-- BEGIN PARTIAL: children-key -->
<div class="container child-content-indicator ">
    <!-- Key -->
    <div class="row">
        <div class="col col-23 offset-1">
            <div class="children-key" aria-hidden="true">
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
<!-- END PARTIAL: children-key -->
<!-- BEGIN PARTIAL: community/experts_suggest_webinar -->
<div class="suggest-webinar-form">
    <div class="row">
        <div class="form-wrapper rs_read_this">

            <header>
                <h3>Suggest a Webinar</h3>
            </header>

            <fieldset class="col col-24">
                <label for="enter-your-topic-text" class="visuallyhidden" aria-hidden="true">Enter your topic</label>
                <input type="text" class="suggest-webinar-field" id="enter-your-topic-text" placeholder="Enter your topic" />
                <input type="submit" class="button suggest-webinar-submit rs_skip" value="Submit Topic" />
            </fieldset>

        </div>
    </div>
</div>
<!-- END PARTIAL: community/experts_suggest_webinar -->
