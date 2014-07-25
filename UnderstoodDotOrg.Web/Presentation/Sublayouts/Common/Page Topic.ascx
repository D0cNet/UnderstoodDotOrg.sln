<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Page Topic.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Page_Topic" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: pagetopic -->
<!-- Page Title -->
<div class="container page-topic <%= AdditionalCssClass %>">
    <div class="row">
        <div class="col col-14 offset-1">
            <asp:HyperLink ID="hlSectionTitle" runat="server" CssClass="back-to-previous"><i class="icon-arrow-left-blue"></i><sc:FieldRenderer ID="frSectionTitle" runat="server" FieldName="Navigation Title" /></asp:HyperLink>
            <div>
                <h1 class="rs_read_this">
                    <sc:FieldRenderer ID="frTitle" runat="server" FieldName="Page Title" />
                </h1>
                <asp:PlaceHolder ID="phAuthorInfo" runat="server" Visible="false">
                    <p class="page-subtitle">
                        <%--Lorem ipsum dolor sit amet, consectetur adipiscing elit nulla egestas --%>
                        <%--<sc:FieldRenderer ID="frSummary" runat="server" FieldName="Page Summary" />--%>
                        <%= UnderstoodDotOrg.Common.DictionaryConstants.ByFragment %> 
                        <asp:HyperLink ID="hlAuthorName" runat="server">
                            <sc:FieldRenderer ID="frAuthorName" runat="server" FieldName="Author Name" />
                        </asp:HyperLink>
                    </p>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phBehaviorArticleInfo" runat="server" Visible="false">
                    <p class="page-subtitle behavior-subtitle">
                        <sc:FieldRenderer ID="frBehaviorSubtitle" runat="server" FieldName="Hero Subheading" />
                    </p>
                </asp:PlaceHolder>
            </div>
        </div>

        <sc:Sublayout ID="sbShareNSave" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />

    </div>
</div>
<!-- .container -->

<!-- END PARTIAL: pagetopic -->
