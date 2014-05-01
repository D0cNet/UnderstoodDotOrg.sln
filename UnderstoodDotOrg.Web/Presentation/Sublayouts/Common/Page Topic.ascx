<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Page Topic.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Page_Topic" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: pagetopic -->
<!-- Page Title -->
<div class="container page-topic <%= AdditionalCssClass %>">
    <div class="row">
        <div class="col col-14 offset-1">

            <h1><%--Technology that Can Help--%>
                <sc:FieldRenderer ID="rfTitle" runat="server" FieldName="Page Title" />
            </h1>
            <p class="page-subtitle">
                <%--Lorem ipsum dolor sit amet, consectetur adipiscing elit nulla egestas --%>
                <%--<sc:FieldRenderer ID="frSummary" runat="server" FieldName="Page Summary" />--%>
                <asp:HyperLink ID="hlAuthorName" runat="server">
                    <sc:FieldRenderer ID="frAuthorName" runat="server" FieldName="Author Name" />
                </asp:HyperLink>
            </p>

        </div>

        <div class="col col-9">
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
                    <a href="REPLACE" class="icon icon-share">Share</a>
                    <span class="tools">
                        <a href="REPLACE" class="icon icon-email">Email</a>
                        <a href="REPLACE" class="icon icon-save">Save</a>
                        <a href="REPLACE" class="icon icon-print">Print</a>
                        <a href="REPLACE" class="icon icon-remind">Remind</a>
                        <a href="REPLACE" class="icon icon-rss">RSS</a>
                    </span>
                </div>
            </div>

            <!-- END PARTIAL: share-save -->
        </div>

    </div>
</div>
<!-- .container -->

<!-- END PARTIAL: pagetopic -->
