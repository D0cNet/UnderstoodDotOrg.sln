<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WhatsHappeningLoggedOut.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.WhatsHappening" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="community-page" class="whats-happening-page">
    <sc:Sublayout ID="sbEvents" runat="server" Path="~/Presentation/SubLayouts/Community/Whats Happening/UpcomingEvents.ascx" />
    <sc:Sublayout ID="sbQuestions" runat="server" Path="~/Presentation/SubLayouts/Community/Whats Happening/RecentQuestions.ascx" />
    <sc:Sublayout ID="sbCommunityMembers" runat="server" Path="~/Presentation/SubLayouts/Community/Whats Happening/CommunityMembers.ascx" />
    <sc:Sublayout ID="sbMyFriends" runat="server" Path="~/Presentation/SubLayouts/Community/Whats Happening/MyFriends.ascx" Visible="false"/>
    <sc:Sublayout ID="sbGroups" runat="server" Path="~/Presentation/SubLayouts/Community/Whats Happening/MostActiveGroups.ascx" />
    <sc:Sublayout ID="sbRecentBlogPosts" runat="server" Path="~/Presentation/SubLayouts/Community/Whats Happening/RecentBlogPosts.ascx" />
</div>