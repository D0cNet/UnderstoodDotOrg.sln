<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Promotionals List.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.Promotionals_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<asp:Repeater ID="rptPromoList" runat="server" OnItemDataBound="rptPromoList_ItemDataBound" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General.PromoItem">
    <ItemTemplate>
        <asp:Panel ID="pnlPromoItem" CssClass="promo " runat="server">
            <asp:HyperLink ID="hlRedirect" runat="server">
                   <%# Item.PromoURL.Rendered %>
                <i class="icon-arrow-promo"></i>
            </asp:HyperLink>
        </asp:Panel>
    </ItemTemplate>
</asp:Repeater>
<!--<div class="promo purple-dark">
    <asp:HyperLink ID="hlPromo1" runat="server">
        <span>
            <sc:FieldRenderer ID="frPromo1" runat="server" FieldName="Page Title" />
        </span>
        <i class="icon-arrow-promo"></i>
    </asp:HyperLink>
    <%--  <a href="REPLACE">
      <span>Get advice</span>
      <i class="icon-arrow-promo"></i>
    </a>--%>
</div>
<!-- end promo -->
<!--<div class="promo purple-light">
    <asp:HyperLink ID="hlPromo2" runat="server">
        <span>
            <sc:FieldRenderer ID="frPromo2" runat="server" FieldName="Page Title" />
        </span>
        <i class="icon-arrow-promo"></i>
    </asp:HyperLink>

</div>
<!-- end promo -->
<!--<div class="promo blue">
    <asp:HyperLink ID="hlPromo3" runat="server">
        <span>
            <sc:FieldRenderer ID="frPromo3" runat="server" FieldName="Page Title" />
        </span>
        <i class="icon-arrow-promo"></i>
    </asp:HyperLink>
</div>
<!-- end promo -->

