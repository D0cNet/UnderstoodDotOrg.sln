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
            <div class="text text-small">
                <h1><%= PageItem.ContentPage.PageTitle.Rendered %></h1>
                <%= PageItem.ContentPage.PageSummary.Rendered %>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col col-24">
            <!-- BEGIN PARTIAL: share-save -->
            <div class="share-save-container">
                <div class="share-save-social-icon">
                    <div class="toggle">
                        <a href="REPLACE" class="socicon icon-facebook">Facebook</a><br />
                        <a href="REPLACE" class="socicon icon-twitter">Twitter</a><br />
                        <a href="REPLACE" class="socicon icon-googleplus">Google&#43;</a><br />
                        <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
                    </div>
                </div>
                <div class="share-save-icon">
                    <h3>Share &amp; Save</h3>
                    <!-- leave no white space for layout consistency -->
                    <a href="REPLACE" class="icon icon-share">Share</a><span class="tools"><a href="REPLACE" class="icon icon-email">Email</a><a href="REPLACE" class="icon icon-save">Save</a><a href="REPLACE" class="icon icon-print">Print</a><a href="REPLACE" class="icon icon-remind">Remind</a><a href="REPLACE" class="icon icon-rss">RSS</a></span>
                </div>
            </div>
            <!-- END PARTIAL: share-save -->
        </div>
    </div>
</div>
<!-- .tyce-page-topic -->