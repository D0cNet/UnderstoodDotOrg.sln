<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatDetails.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.ChatDetails" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register Src="~/Presentation/Sublayouts/Recommendation/CommunityRecommendationIcons.ascx" TagPrefix="uc1" TagName="CommunityRecommendationIcons" %>
<div class="container event">
    <header class="row">
        <div class="event-container">
            <ul class="breadcrumbs">
                <li><asp:HyperLink ID="hlBackExperts" runat="server" /></li>
            </ul>

            <h2 class="rs_read_this"><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></h2>
        </div>
    </header>

    <div class="row">
        <div class="event-container">
            <div class="col-18 col event-content skiplink-content" aria-role="main">
                <div class="rs_read_this">
                    <div class="event-image">
                        <div class="thumbnail">
                            <asp:HyperLink ID="hlExpertDetails" runat="server">
                                <asp:Image ID="imgExpert" runat="server" />
                                <div class="image-label">
                                    <asp:Literal ID="litExpertType" runat="server" />
                                </div>
                            </asp:HyperLink>
                        </div>

                    <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                    <%--
                    Phase 2 --%>
                    <div class="recommended-for">
                         <p><%= UnderstoodDotOrg.Common.DictionaryConstants.RecommendedForLabel %></p>
                            <uc1:CommunityRecommendationIcons runat="server" ID="CommunityRecommendationIcons1" />
           
                    </div>
                    <!-- END PARTIAL: community/experts_recommended_for -->
                </div><!-- end .event-image -->

                <p class="event-date-time"><asp:Literal ID="litEventDate" runat="server" /></p>
                <p class="event-host-name"><sc:FieldRenderer ID="frExpertName" runat="server" FieldName="Expert Name" /></p>
                <p class="event-host-title"><sc:FieldRenderer ID="frHostTitle" runat="server" FieldName="Expert Subheading" /></p>
                
                <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />

                <asp:PlaceHolder ID="phCallToActions" runat="server" Visible="false">
                    <sc:FieldRenderer ID="frRsvp" Parameters="class=button event-rsvp rs_skip" FieldName="RSVP for Event Link" runat="server" />
                    <sc:FieldRenderer ID="frAddToCalendar" Parameters="class=button event-calendar rs_skip" runat="server" FieldName="Add To Calendar Link" />
                </asp:PlaceHolder>
            </div>

            <asp:PlaceHolder ID="phPastChatDetails" runat="server" Visible="false">
                <sc:FieldRenderer ID="frChatTranscript" runat="server" FieldName="Chat Transcript" />

                <!-- BEGIN PARTIAL: find-helpful -->
                <sc:sublayout id="Sublayout1" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulOther.ascx" />
                <!-- END PARTIAL: find-helpful -->
            </asp:PlaceHolder>
        </div> <!-- end .event-content -->
        
            <div class="col-5 col offset-1 event-sidebar skiplink-sidebar rs_read_this">
                <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                <%--
              Phase 2--%>
                <div class="recommended-for">
                    <p><%= UnderstoodDotOrg.Common.DictionaryConstants.RecommendedForLabel %></p>
                 <uc1:CommunityRecommendationIcons runat="server" ID="CommunityRecommendationIcons2" />
           
                </div>
                <!-- END PARTIAL: community/experts_recommended_for -->
                
                <asp:PlaceHolder ID="phPastSidebarDetails" runat="server" Visible="false">
                <!-- BEGIN PARTIAL: helpful-count -->
                <sc:sublayout id="Sublayout3" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCountsSideColumn.ascx" />
                <!-- END PARTIAL: helpful-count -->
                
                <!-- BEGIN PARTIAL: find-helpful -->
                <sc:sublayout id="Sublayout2" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" />
                <!-- END PARTIAL: find-helpful -->
                </asp:PlaceHolder>
            </div> <!-- end .event-sidebar -->
        </div>
    </div>
</div>
