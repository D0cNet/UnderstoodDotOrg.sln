<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TyceNextSteps.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TyceNextSteps" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container tyce-personalize">
    <div class="row">
        <div class="content">
            <div class="text">
                <h2><%= Model.PersonalizationBoxTitle.Rendered %></h2>
                <%= Model.PersonalizationBoxAbstract.Rendered %>
            </div>
            <div class="button-wrap">
                <button class="button">Save Settings</button>
            </div>
        </div>
    </div>
</div>
<!-- .tyce-personalize -->


<div class="container tyce-main-feature">
    <div class="row">
        <div class="col col-10 offset-1">
            <sc:FieldRenderer runat="server" FieldName="Image" Parameters="class=pic&w=391&h=219" />
        </div>
        <div class="col col-10 offset-1">
            <h2>Talk with your Child</h2>
            <%= Model.TyceBasePage.ContentPage.BodyContent.Rendered %>
        </div>
    </div>
</div>
<!-- .tyce-personalize -->

<div class="container tyce-module-3">
    <div class="row">
        <div class="module-wrap">
            <div class="module">
                <h2><%= Model.ExploreTitle.Rendered %></h2>
                <p><%= Model.ExploreContent.Rendered %></p>
                <asp:Repeater ID="rptrIssuesSeen" runat="server" 
                    ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components.ChildLearningIssueItem">
                    <ItemTemplate>
                        <p class="link">
                            <a href="<%# Item.ChildDemographic.InnerItem.Paths.Path %>">Learn About <%# Item.ChildDemographic.NavigationTitle.Rendered %></a>
                        </p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="module">
                <h2><%= Model.ShareItTitle.Rendered %></h2>
                <p><%= Model.ShareItContent.Rendered %></p>
                <ul class="share-tools">
                    <li>
                        <a href="REPLACE" class="icon icon-facebook">Facebook</a></li>
                    <li>
                        <a href="REPLACE" class="icon icon-twitter">Twitter</a></li>
                    <li>
                        <a href="REPLACE" class="icon icon-google">Google +</a></li>
                    <li>
                        <a href="REPLACE" class="icon icon-pinterest">Pinterest</a></li>
                    <li>
                        <a href="REPLACE" class="icon icon-email">Email</a></li>
                </ul>
            </div>
            <div class="module">
                <h2><%= Model.ExpertHeaderText.Rendered %></h2>
                <p><%= Model.ExpertContentText.Rendered %></p>
                <p class="field">
                    <label class="visuallyhidden" for="expert-q">Question for expert</label>
                    <textarea placeholder="<%= Model.PlaceholderText.Rendered %>" id="expert-q"></textarea>
                </p>
                <input type="submit" class="button" value="Submit">
            </div>
        </div>
    </div>
</div>
<!-- .tyce-module-3 -->

<div class="container tyce-addresses">
    <div class="row">
        <div class="col col-22 offset-1">
            <header>
                <p class="message"><%= Model.SpecialThanksHeader.Rendered %></p>
            </header>
        </div>
    </div>
    <div class="row">
        <asp:Repeater ID="rptrSchools" runat="server">
            <ItemTemplate>
                <div class="col col-4 offset-1">
                    <p>
                        <%# Eval("Title.Rendered") %><br>
                        <%# Eval("EducationLevel.Rendered") %><br>
                        <%# Eval("Location.Rendered") %>
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
