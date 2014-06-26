<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TyceOverview.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TyceOverview" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<div class="container tyce-personalize">
    <div class="row">
        <div class="content">
            <div class="text">
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
        <div class="col col-22 offset-1">
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
        <div class="col col-23 offset-1">
            <ul class="item-5">
                <asp:Repeater ID="rptrSimulations" runat="server" 
                    ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components.ChildLearningIssueItem">
                    <ItemTemplate>
                        <li>
                            <a href="<%= QuestionsPageItem.GetUrl() %>?simq=<%# Item.ID.Guid %>">
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
        <div class="col col-23 offset-1">
            <h3>Children's Stories</h3>
            <ul class="tab-controls">
                <li>
                    <a href="#stories-k-2">Pre K - Grade 2</a></li>
                <li>
                    <a href="#stories-3-6">Grade 3 - 6</a></li>
                <li>
                    <a href="#stories-7-12">Grade 7 - 12</a></li>
            </ul>
        </div>
    </div>
    <div class="row" id="stories-k-2">
        <div class="col col-23 offset-1">
            <div class="title">Pre K - Grade 2</div>
            <ul class="item-5">
                <li>
                    <a href="REPLACE">
                        <h4>Reading<br>
                            Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Dylan <i class="icon reading-issues"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Writing<br>
                            Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Stephanie <i class="icon writing-issues"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Math<br>
                            Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Evan <i class="icon math-issues"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Organization &amp;<br>
                            Time
                            <abbr title="Management">Mgmt</abbr></h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Laura <i class="icon organization-time"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Attention/Self<br>
                            Control Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Charlotte <i class="icon attention-issues"></i></p>
                </li>
            </ul>
        </div>
    </div>
    <div class="row" id="stories-3-6">
        <div class="col col-23 offset-1">
            <div class="title">Grade 3 - 6</div>
            <ul class="item-5">
                <li>
                    <a href="REPLACE">
                        <h4>Reading<br>
                            Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Sophia <i class="icon reading-issues"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Writing<br>
                            Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Aiden <i class="icon writing-issues"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Math<br>
                            Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Emma <i class="icon math-issues"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Organization &amp;<br>
                            Time
                            <abbr title="Management">Mgmt</abbr></h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Jackson <i class="icon organization-time"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Attention/Self<br>
                            Control Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Olivia <i class="icon attention-issues"></i></p>
                </li>
            </ul>
        </div>
    </div>
    <div class="row" id="stories-7-12">
        <div class="col col-23 offset-1">
            <div class="title">Grade 7 - 12</div>
            <ul class="item-5">
                <li>
                    <a href="REPLACE">
                        <h4>Reading<br>
                            Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Ethan <i class="icon reading-issues"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Writing<br>
                            Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Isabella <i class="icon writing-issues"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Math<br>
                            Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Evan <i class="icon math-issues"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Organization &amp;<br>
                            Time
                            <abbr title="Management">Mgmt</abbr></h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Liam <i class="icon organization-time"></i></p>
                </li>
                <li>
                    <a href="REPLACE">
                        <h4>Attention/Self<br>
                            Control Issues</h4>
                        <img alt="FPO content image" src="http://placehold.it/150x84&amp;text=150x84" /><i class="icon play"></i>
                    </a>
                    <p>Ava <i class="icon attention-issues"></i></p>
                </li>
            </ul>
        </div>
    </div>
</div>
<!-- .tyce-on-demand-container -->
