<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TyceOverview.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TyceOverview" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<div class="container tyce-personalize">
    <div class="row">
        <div class="content">
            <div class="text rs_read_this">
                <h2><%= Model.PersonalizationBoxTitle.Rendered %></h2>
                <%= Model.PersonalizationBoxAbstract.Rendered %>
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
        <div class="col col-22 offset-1 rs_read_this">
            <h2>On-Demand</h2>
            <%= Model.TyceBasePage.ContentPage.BodyContent.Rendered %>
        </div>
    </div>
</div>
<!-- .tyce-on-demand -->
<div class="container tyce-on-demand-container simulations">
    <div class="row">
        <div class="col col-23 offset-1">
            <h3><%= Model.SimulationListingTitle.Rendered %></h3>
            <%= Model.SimulationListingAbstract.Rendered %>
        </div>
    </div>
    <div class="row">
        <div class="col col-23 offset-1 rs_read_this">
            <ul class="item-5">
                <asp:Repeater ID="rptrSimulations" runat="server" 
                    ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components.ChildLearningIssueItem">
                    <ItemTemplate>
                        <li>
                            <a href="<%= PlayerPageItem.GetUrl() %>?simq=<%# Item.ID.Guid %>&standalone=true">
                                <h4>
                                    <%# Item.ChildDemographic.NavigationTitle.Rendered %>
                                </h4>
                                <i class="icon-block <%# Item.ChildDemographic.CssClass.Raw %>"><b></b></i>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>
<!-- .tyce-on-demand-container -->
<div class="container tyce-on-demand-container stories">
    <div class="row">
        <div class="col col-23 offset-1 rs_read_this">
            <h3>Children's Stories</h3>
            <ul class="tab-controls">
                <%--<li>
                    <a href="#stories-k-2">Pre K - Grade 2</a></li>
                <li>
                    <a href="#stories-3-6">Grade 3 - 6</a></li>
                <li>
                    <a href="#stories-7-12">Grade 7 - 12</a></li>--%>
                <asp:Repeater ID="rptrChildStoryTabs" runat="server"
                    ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components.TYCEGradeGroupItem">
                    <ItemTemplate>
                        <li><a href="#cs<%# Item.ID.ToShortID().ToString() %>"><%# Item.Title.Rendered %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <asp:Repeater ID="rptrChildStories" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components.TYCEGradeGroupItem">
        <ItemTemplate>
            <%--<div class="row<%# Container.ItemIndex == 0 ? " active" : string.Empty %>" id="cs<%# Item.ID.ToShortID().ToString() %>"
                style="display: <%# Container.ItemIndex == 0 ? "block" : "none" %>;">--%>
            <div class="row" id="cs<%# Item.ID.ToShortID().ToString() %>">
            <div class="col col-23 offset-1 rs_read_this">
                <div class="title"><%# Item.Title.Rendered %></div></div>
                <ul class="item-5">
                    <asp:Repeater ID="rptrIssues" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href="<%= PlayerPageItem.GetUrl() %>?simq=<%# Eval("IssueId") %>&gradeId=<%# Eval("InRangeGradeId") %>&standalone=true">
                                    <h4><%# Eval("NavigationTitle") %></h4>
                                    <img alt="<%# Eval("NavigationTitle") %>" src="<%# Eval("Image") %>" /><i class="icon play"></i>
                                </a>
                                <p><%# Eval("ChildName") %> <i class="icon <%# Eval("CssClass") %>"></i></p>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<!-- .tyce-on-demand-container -->
