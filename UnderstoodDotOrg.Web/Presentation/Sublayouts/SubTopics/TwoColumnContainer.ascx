<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwoColumnContainer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics.TwoColumnContainer" %>

<%--<!-- BEGIN PARTIAL: children-key -->
<div class="container child-content-indicator first">
    <!-- Key -->
    <div class="row">
        <div class="col col-23 offset-1">
            <div class="children-key">
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
<!-- END PARTIAL: children-key -->--%>
<sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />

<!-- BEGIN MODULE: Article Listing -->
<div class="container article-listing-container single-col">
    <div class="row">
        <sc:placeholder key="Left" runat="server" />
        <sc:placeholder key="Right" runat="server" />
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<!-- END MODULE: Article Listing -->

<!-- BEGIN PARTIAL: footer -->
