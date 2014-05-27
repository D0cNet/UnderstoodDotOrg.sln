<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PromotionalsList.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.PromotionalsList" %>

<asp:Repeater ID="rptPromoList" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General.PromoItem">
    <ItemTemplate>
        <div class="promo <%# Container.ItemIndex == 0 ? "purple-dark" : Container.ItemIndex == 1 ? "purple-light" : "blue" %>">
            <a href="<%# Item.PromoURL.Url %>">   
                <span><%# Item.ContentPage.BasePageNEW.NavigationTitle.Rendered %></span>                
                <i class="icon-arrow-promo"></i>
            </a>
        </div>
        <!-- end promo -->
    </ItemTemplate>
</asp:Repeater>