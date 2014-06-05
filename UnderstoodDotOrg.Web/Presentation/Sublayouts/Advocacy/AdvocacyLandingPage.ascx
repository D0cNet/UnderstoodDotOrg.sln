<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvocacyLandingPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy.AdvocacyLandingPage" %>
<div class="container l-take-action">
    <div class="row">
        <div class="col col-15 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: advocacy/take-action-today -->
            <div class="take-action">
                <h2 class="rs_read_this"><%= Model.ActionAlertsHeading.Rendered %></h2>
                <div class="take-action-items">
                    <asp:Repeater ID="rptrActionAlerts" runat="server" 
                        ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General.AdvocacyLinkItem">
                        <ItemTemplate>
                            <div class="action-item rs_read_this take-action-rs-wrapper">
                                <div class="action-header">
                                    <a href="<%# Item.Link.Url %>" class="action-image">
                                        <img alt="<%# Item.Image.Field.Alt %>" src="<%# Item.Image.MediaUrl %>" />
                                    </a>
                                    <h3 class="action-title">
                                        <a href="<%# Item.Link.Url %>"><%# Item.Heading.Rendered %></a>
                                    </h3>
                                    <div class="action-description">
                                       <%# Item.Abstract.Rendered %> 
                                    </div>
                                </div>
                                <div class="action-button-wrap">
                                    <button type="button" runat="server" class="button action-button" data-url="<%# Item.Link.Url %>" 
                                        onserverclick="btnActNow_Click">
                                        <%# Item.ActNowButtonText.Rendered %>
                                    </button>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!-- take-action-today -->
            <!-- END PARTIAL: advocacy/take-action-today -->
        </div>
        <div class="col col-7 offset-1 skiplink-sidebar take-action-large">
            <div class="take-action-module">
                <div class="l-take-action-share clearfix">
                    <!-- BEGIN PARTIAL: share-save -->
                    <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />
                    <!-- END PARTIAL: share-save -->
                </div>
                <div class="l-take-action-signup">
                    <!-- BEGIN PARTIAL: advocacy/take-action-signup -->
                    <div class="take-action-signup rs_read_this take-action-rs-wrapper">
                        <h4>Signup for Action Alerts!</h4>
                        <fieldset>
                            <label for="take-action-email" class="visuallyhidden"></label>
                            <input type="text" placeholder="Enter email address" name="signup-newsletter-email" id="take-action-email" class="take-action-input">
                            <input id="take-action-email-button" class="button take-action-email-button" type="submit" value="Sign Up">
                        </fieldset>
                    </div>
                    <!-- .donate -->
                    <!-- END PARTIAL: advocacy/take-action-signup -->
                </div>
                <div class="l-take-action-promo">
                    <!-- BEGIN PARTIAL: advocacy/take-action-promo -->
                    <div class="take-action-promo">
                        <img alt="270x280 Placeholder" src="http://placehold.it/270x280" />
                    </div>
                    <!-- END PARTIAL: advocacy/take-action-promo -->
                </div>
            </div>
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container l-on-the-issues">
    <div class="row">
        <div class="col col-24 skiplink-feature">
            <!-- BEGIN PARTIAL: advocacy/on-the-issues -->
            <div class="container issues-intro">
                <div class="row">
                    <div class="col col-23  offset-1">
                        <h2 class="rs_read_this"><%= Model.FeaturedArticlesHeading.Rendered %></h2>
                    </div>
                </div>
            </div>
            <div class="container issues-grid">
                <div class="row">
                    <asp:Repeater ID="rptArticles" runat="server" OnItemDataBound="rptArticles_ItemDataBound">
                        <ItemTemplate>
                            <div class="col col-11 offset-1 issues-column">
                                <div class="issues-item rs_read_this advocacy-issues-rs-wrapper clearfix">
                                    <div class="issues-image">
                                        <asp:HyperLink id="hypArticleThumbnailLink" runat="server">
                                           <asp:Image id="articleThumbnail" runat="server" imageurl="..." />
                                        </asp:HyperLink>
                                    </div>
                                    <div class="issues-title">
                                        <h3>
                                            <asp:HyperLink id="hypArticleLink" runat="server"></asp:HyperLink>
                                        </h3>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!-- END PARTIAL: advocacy/on-the-issues -->
        </div>
        <div class="col col-7 take-action-small-after">
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container">
    <div class="row">
        <div class="col col-24 take-action-small">
            <!-- Insert Small item in here-->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->