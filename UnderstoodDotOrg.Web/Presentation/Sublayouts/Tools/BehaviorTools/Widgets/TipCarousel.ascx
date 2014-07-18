<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TipCarousel.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.Widgets.TipCarousel" %>

<asp:Repeater ID="rptTips" runat="server">
<HeaderTemplate>
    <div class="second-next-prev-menu arrows-gray" data-start-slide-number="<%= StartSlideIndex %>">
        <span class="next-prev-text"><%= UnderstoodDotOrg.Common.DictionaryConstants.NextTipButtonText %></span>
        <div class="second-next-prev-menu-slider">
</HeaderTemplate>
<ItemTemplate>
    <p class="next-prev-title"><asp:HyperLink ID="hlTip" runat="server" /></p>
</ItemTemplate>
<FooterTemplate>
        </div>
    </div>
</FooterTemplate>
</asp:Repeater>