<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArchivedEventsModule.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.ArchivedEventsModule" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<%@ Register TagPrefix="udo" TagName="ArchiveListing" Src="~/Presentation/Sublayouts/Common/Cards/EventArchiveListing.ascx" %>

<div class="container archive">
    <div class="row skiplink-content" aria-role="main">
        <header class="col col-24 rs_read_this">
            <h2><%--Recently Added to the Archive--%>
                <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Archive Heading" />
            </h2>
        </header>
    </div>

    <!-- BEGIN PARTIAL: community/experts_archive_card -->
    <div class="event-cards">
        <udo:ArchiveListing ID="archiveEvents" runat="server" />

        <asp:Panel runat="server" ID="pnlNoArchiveMessage" class="no-webinars rs_read_this" Visible="false">
            <sc:FieldRenderer ID="frNoArchiveMessage" runat="server" FieldName="No Archive Message" />
        </asp:Panel>
    </div>
    <!-- end .event-cards -->
    <!-- END PARTIAL: community/experts_archive_card -->
    <div class="row">
        <div class="container child-content-indicator">
            <!-- Key -->
            <div class="row">
                <div class="col col-24">
                    <asp:HyperLink runat="server" ID="hlSeeArchive" CssClass="button see-archive"></asp:HyperLink>
                    <%--<a class="button see-archive" href="REPLACE">See Archive</a>--%>
                    <%--
                        Phase 2
                        <div aria-hidden="true" class="children-key">
                        <ul>
                            <li><i class="child-a"></i>for Michael</li>
                            <li><i class="child-b"></i>for Elizabeth</li>
                            <li><i class="child-c"></i>for Ethan</li>
                            <li><i class="child-d"></i>for Jeremy</li>
                            <li><i class="child-e"></i>for Franklin</li>
                        </ul>
                    </div>
                    --%>
                        <sc:Sublayout ID="Sublayout1" runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
                </div>
                <!-- .col -->
            </div>
            <!-- .row -->
        </div>
        <!-- .child-content-indicator -->

    </div>

</div>