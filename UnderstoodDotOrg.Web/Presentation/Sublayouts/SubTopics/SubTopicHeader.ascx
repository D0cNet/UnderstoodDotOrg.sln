<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubTopicHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics.SubTopicHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container page-topic with-share">
    <div class="row  header-wrapper">
        <div class="col col-14 offset-1 header-title rs_read_this">
            <asp:HyperLink runat="server" ID="hlBreadcrumbNav" CssClass="back-to-previous"><i class="icon-arrow-left-blue"></i><asp:Literal runat="server" ID="litPreviousLink"/></asp:HyperLink>

            <h1><asp:Literal runat="server" ID="litTitle" /></h1>
        </div>

        <div class="col col-9 header-share-save">
            <!-- BEGIN PARTIAL: share-save -->
            <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />

            <!-- END PARTIAL: share-save -->
        </div>
    </div>
</div>