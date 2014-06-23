<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewerInfo.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.ReviewerInfo" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel runat="server" ID="pnlReviewBy" Visible="false">
<p class="reviewed-by" runat="server">
    <span class="reviewed-by-title">Reviewed&nbsp;by</span> <span class="reviewed-by-author">
        <asp:HyperLink ID="hlReviewedBy" runat="server">
            <sc:FieldRenderer ID="frReviewedBy" runat="server" FieldName="Expert Name" />
        </asp:HyperLink>
    </span>
    <asp:Placeholder ID="uxReviewDate" runat="server" Visible="false">
        <span class="dot"></span>
        <span class="reviewed-by-date">
            <sc:Date ID="dtReviewdDate" Field="Reviewed Date" runat="server" Format="dd MMM yy" />
        </span>
    </asp:Placeholder>
</p>
</asp:Panel>