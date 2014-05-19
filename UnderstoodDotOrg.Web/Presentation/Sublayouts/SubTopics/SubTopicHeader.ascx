<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubTopicHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics.SubTopicHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container page-topic with-share">
    <div class="row  header-wrapper">
        <div class="col col-14 offset-1 header-title rs_read_this">
            <asp:HyperLink runat="server" ID="hlBreadcrumbNav" CssClass="back-to-previous">
                <i class="icon-arrow-left-blue"></i>
                <asp:Literal runat="server" ID="litPreviousLink"></asp:Literal>
            </asp:HyperLink>

            <h1><asp:Literal runat="server" ID="litTitle" /></h1>
        </div>

        <div class="col col-9 header-share-save">
            <!-- BEGIN PARTIAL: share-save -->
            <div class="share-save-container">
                <div class="share-save-social-icon">
                    <div class="toggle">
                        <a class="socicon icon-facebook" href="REPLACE">Facebook</a><br>
                        <a class="socicon icon-twitter" href="REPLACE">Twitter</a><br>
                        <a class="socicon icon-googleplus" href="REPLACE">Google+</a><br>
                        <a class="socicon icon-pinterest" href="REPLACE">Pinterest</a><br>
                    </div>
                </div>
                <div class="share-save-icon">
                    <h3>Share &amp; Save</h3>
                    <!-- leave no white space for layout consistency -->
                    <a class="icon icon-share" href="REPLACE">Share</a><span class="tools"><a class="icon icon-email" href="REPLACE">Email</a><a class="icon icon-save" href="REPLACE">Save</a><a class="icon icon-print" href="REPLACE">Print</a><a class="icon icon-remind" href="REPLACE">Remind</a><a class="icon icon-rss" href="REPLACE">RSS</a></span>
                </div>
            </div>

            <!-- END PARTIAL: share-save -->
        </div>
    </div>
</div>