<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Promotionals List.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.Promotionals_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="sidebar-promos">
    <div class="promo purple-dark">
        <a href="REPLACE"><span>
            <%--Get advice--%>
            <asp:HyperLink ID="hlPromo1" runat="server">
                <sc:FieldRenderer ID="frPromo1" runat="server" FieldName="Page Title" />
            </asp:HyperLink>
        </span><i class="icon-arrow-promo"></i></a>
    </div>
    <!-- end promo -->
    <div class="promo purple-light">
        <a href="REPLACE"><span><%--Find Technology that can Help--%>
            <asp:HyperLink ID="hlPromo2" runat="server">
                <sc:FieldRenderer ID="frPromo2" runat="server" FieldName="Page Title" />
            </asp:HyperLink>
        </span><i class="icon-arrow-promo"></i></a>
    </div>
    <!-- end promo -->
    <div class="promo blue">
        <a href="REPLACE"><span><%--Navigating Your Child's Healthcare Needs--%>
            <asp:HyperLink ID="hlPromo3" runat="server">
                <sc:FieldRenderer ID="frPromo3" runat="server" FieldName="Page Title" />
            </asp:HyperLink>
        </span><i class="icon-arrow-promo"></i></a>
    </div>
    <!-- end promo -->
</div>
