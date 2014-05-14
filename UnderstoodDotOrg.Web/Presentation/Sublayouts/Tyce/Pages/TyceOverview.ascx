<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TyceOverview.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TyceOverview" %>
<div class="container tyce-personalize">
    <div class="row">
        <div class="content">
            <div class="text">
                <h2><%= PageItem.ChildSelectionBoxTitle.Rendered %></h2>
                <%= PageItem.ChildSelectionBoxAbstract.Rendered %>
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
                            <a href="REPLACE">
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

<div class="modal fade modal-standard" id="tyce-modal-select-child" tabindex="-1" role="dialog" aria-hidden="true" style="z-index:1031;">
    <div class="modal-dialog">
        <div class="modal-content">
            <button type="button" class="close-overlay" data-dismiss="modal" aria-hidden="true">Close</button>
            <div class="modal-body">
                <h2>Select your Child</h2>
                <p>Your profile contains three children. Please select the child you'd like to base this experience on.</p>

                <fieldset>
                    <legend class="visuallyhidden">Select your Child</legend>
                    <ul class="input-buttons">
                        <li>
                            <input type="radio" name="tyce-child" id="tyce-child-01">
                            <label for="tyce-child-01">David, 7</label>
                        </li>
                        <li>
                            <input type="radio" name="tyce-child" id="tyce-child-02">
                            <label for="tyce-child-02">Cara, 8</label>
                        </li>
                        <li>
                            <input type="radio" name="tyce-child" id="tyce-child-03">
                            <label for="tyce-child-03">Stephanie, 11</label>
                        </li>
                    </ul>
                </fieldset>
                <div class="actions">
                    <a href="REPLACE" class="button">Ok let's go</a>
                    <a href="REPLACE" class="button gray">Let Me Customize</a>
                </div>

            </div>
            <!-- /.modal-body -->
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->
