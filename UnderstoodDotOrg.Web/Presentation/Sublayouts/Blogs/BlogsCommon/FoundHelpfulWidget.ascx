<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoundHelpfulWidget.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.FoundHelpfulWidget" %>
<!-- BEGIN PARTIAL: helpful-count -->
<div class="post-meta">
    <div class="count-helpful">
        <a href="#count-helpful-content"><span>34</span>Found this helpful</a>
    </div>
    <!-- END PARTIAL: helpful-count -->
    <div class="replies">
        <!-- BEGIN PARTIAL: comments-count -->
        <div class="count-comments">
            <a href="#count-comments"><span>19</span>Comments</a>
        </div>
        <!-- END PARTIAL: comments-count -->
    </div>
</div>

<div class="was-this-helpful" id="count-helpful">
    <h5>Did you find this helpful?</h5>
    <a href="REPLACE" class="button yes">Yes</a>
    <a href="REPLACE" class="button gray no">No</a>
</div>