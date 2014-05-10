<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewerInfo.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.ReviewerInfo" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<p class="reviewed-by">
    <span class="reviewed-by-title">Reviewed&nbsp;by</span> <span class="reviewed-by-author">
        <%--<a href="REPLACE">Dr. Samantha Frank</a>--%>
        <asp:HyperLink ID="hlReviewdby" runat="server">
            <sc:FieldRenderer ID="frReviewedby" runat="server" FieldName="Revierwer Name" />
        </asp:HyperLink>
    </span>
    <asp:Placeholder ID="uxReviewDate" runat="server" Visible="false">
        <span class="dot"></span>
        <span class="reviewed-by-date">
            <%--12&nbsp;Dec&nbsp;&apos;13 --%>
            <sc:Date ID="dtReviewdDate" Field="Reviewed Date" runat="server" Format="dd MMM yy" />
        </span>
    </asp:Placeholder>
</p>
