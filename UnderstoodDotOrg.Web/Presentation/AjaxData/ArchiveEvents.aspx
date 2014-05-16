<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArchiveEvents.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.ArchiveEvents" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
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
<asp:Label runat="server" ID="lblmoreArticle" style="display:none;" ClientIDMode="Static" Text="true"></asp:Label>