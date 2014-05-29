<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArchiveEvents.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.ArchiveEvents" %>
<%@ Register TagPrefix="udo" TagName="EventListing" Src="~/Presentation/Sublayouts/Common/Cards/EventArchiveListing.ascx" %>

<udo:EventListing ID="eventListing" runat="server" />
<asp:Placeholder id="phMoreResults" runat="server" Visible="false"><input type="hidden" /></asp:Placeholder>