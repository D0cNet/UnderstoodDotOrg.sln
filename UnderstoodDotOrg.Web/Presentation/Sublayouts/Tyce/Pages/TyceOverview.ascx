<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TyceOverview.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TyceOverview" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<div class="container tyce-personalize">
    <div class="row">
        <div class="content">
            <div class="text">
                <h2><%= PageItem.PersonalizationBoxTitle.Rendered %></h2>
                <%= PageItem.PersonalizationBoxAbstract.Rendered %>
            </div>
            <div class="button-wrap">
                <a href="REPLACE" class="button button-select-children">Go</a>
            </div>
        </div>
    </div>
</div>
<!-- .tyce-personalize -->
<div class="container tyce-on-demand">
    <div class="row">
        <div class="col col-22 offset-1">
            <h2><%= PageItem.TyceBasePage.ContentPage.SectionTitle.Rendered %></h2>
            <%= PageItem.TyceBasePage.ContentPage.BodyContent.Rendered %>
        </div>
    </div>
</div>
<!-- .tyce-on-demand -->
<div class="container tyce-on-demand-container simulations">
    <div class="row">
        <div class="col col-23 offset-1">
            <h3><%= PageItem.SimulationListingTitle.Rendered %></h3>
            <%= PageItem.SimulationListingAbstract.Rendered %>
        </div>
    </div>
    <div class="row">
        <div class="col col-23 offset-1">
            <ul class="item-5">
                <asp:Repeater ID="rptrSimulations" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href="<%= PlayerPageItem.GetUrl() %>">
                                <h4>
                                    <%# Eval("ChildDemographic.NavigationTitle.Rendered") %>
                                </h4>
                                <i class="icon-block <%# Eval("ChildDemographic.CssClass.Raw") %>"><b></b></i>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>
<!-- .tyce-on-demand-container -->
