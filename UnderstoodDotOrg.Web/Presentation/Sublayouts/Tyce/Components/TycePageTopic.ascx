<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TycePageTopic.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components.TycePageTopic" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<div class="container tyce-page-topic">
    <div class="row">
        <div class="col col-14 offset-1">
            <a href="<%= PreviousPageItem.GetUrl() %>" class="back-to-previous">
                <i class="icon-arrow-left-blue"></i><%= PreviousPageItem.NavigationTitle.Rendered %>
            </a>
        </div>
    </div>
    <div class="row">
        <div class="col col-22 offset-1">
            <div class="text text-small rs_read_this">
                <h1><%= PageItem.ContentPage.PageTitle.Rendered %></h1>
                <%= PageItem.ContentPage.BodyContent.Rendered %>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col col-24">
            <!-- BEGIN PARTIAL: share-save -->
            <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />
            <!-- END PARTIAL: share-save -->
        </div>
    </div>
</div>
<!-- .tyce-page-topic -->