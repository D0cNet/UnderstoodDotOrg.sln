<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SectionPageTopic.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Section.SectionPageTitle" %>

<div class="container page-topic has-recommendations">
    <div class="row">
        <div class="col col-23 offset-1">

            <a class="back-to-previous" href="REPLACE"><i class="icon-arrow-left-blue"></i>Homepage</a>

            <h1>School &amp; Learning</h1>

        </div>
        <sc:Sublayout ID="slRecommendations" Path="~/Presentation/Sublayouts/Section/Recommendations.ascx" runat="server" />
    </div>
</div>
