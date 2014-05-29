<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArchiveListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.ArchiveListing" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register TagPrefix="udo" TagName="ArchiveListing" Src="~/Presentation/Sublayouts/Common/Cards/EventArchiveListing.ascx" %>

<!-- BEGIN PARTIAL: community/experts_sub_nav -->
<div class="container">
    <div class="row">
        <div class="container">
            <div class="experts-nav-form  rs_read_this clearfix skiplink-toolbar">
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
            </div>
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
            <udo:ArchiveListing ID="archiveEvents" runat="server" />
        </div>
        <!-- end .event-cards -->
        <!-- END PARTIAL: community/experts_archive_card -->
    </div>
</div>


<!-- Show More -->
<!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<asp:Panel ID="pnlMoreArticle" runat="server" ClientIDMode="Static"  CssClass="container show-more rs_skip" Visible="false">
    <div class="row">
        <div class="col col-24">
            <a class="show-more-link " id="archivelisting" href="#" data-path="community/event-cards" data-container="event-cards-container" data-item="event-cards" data-count="4">Show More<i class="icon-arrow-down-blue"></i></a>
        </div>
    </div>
</asp:Panel>
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
<asp:HiddenField runat="server" ID="hfTopic" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hfGrade" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hfChildIssue" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hfSearchKey" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hfResultsPerClick" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hfGUID" ClientIDMode="Static" />

<!-- END PARTIAL: community/experts_suggest_webinar -->
