<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewerInfo.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.ReviewerInfo" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<p class="reviewed-by">
    <span class="reviewed-by-title">Reviewed&nbsp;by</span> <span class="reviewed-by-author">
        <%--<a href="REPLACE">Dr. Samantha Frank</a>--%>
        <asp:HyperLink ID="hlReviewdby" runat="server">
            <sc:fieldrenderer id="frReviewedby" runat="server" fieldname="Revierwer Name" />
        </asp:HyperLink>
    </span><span class="dot"></span><span class="reviewed-by-date">
        <%--12&nbsp;Dec&nbsp;&apos;13 --%>
        <sc:date id="dtReviewdDate" field="Reviewed Date" runat="server" format="dd MMM yy" />
    </span>
</p>
