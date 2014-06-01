<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DecisionToolLandingPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.DecisionTool.DecisionToolLandingPage" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<div class="container page-topic landing dl-wrapper">
    <div class="row">
        <div class="col col-14 offset-1 skiplink-content">
            <div>
                <h1 class="rs_read_this"><%= Model.ContentPage.PageTitle.Rendered %></h1>
                <p class="dl-heading-detail"><%= Model.ContentPage.PageSummary.Rendered %></p>
            </div>
        </div>

        <div class="col col-9">
            <!-- BEGIN PARTIAL: share-save -->
            <div class="share-save-container">
                <div class="share-save-social-icon">
                    <div class="toggle">
                        <a href="REPLACE" class="socicon icon-facebook">Facebook</a><br />
                        <a href="REPLACE" class="socicon icon-twitter">Twitter</a><br />
                        <a href="REPLACE" class="socicon icon-googleplus">Google&#43;</a><br />
                        <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
                    </div>
                </div>
                <div class="share-save-icon">
                    <h3>Share &amp; Save</h3>
                    <!-- leave no white space for layout consistency -->
                    <a href="REPLACE" class="icon icon-share">Share</a><span class="tools"><a href="REPLACE" class="icon icon-email">Email</a><a href="REPLACE" class="icon icon-save">Save</a><a href="REPLACE" class="icon icon-print">Print</a><a href="REPLACE" class="icon icon-remind">Remind</a><a href="REPLACE" class="icon icon-rss">RSS</a></span>
                </div>
            </div>

            <!-- END PARTIAL: share-save -->
        </div>

        <div class="col col-23 offset-1">
            <%--<!-- BEGIN PARTIAL: children-key -->
            <div class="container child-content-indicator ">
                <!-- Key -->
                <div class="row">
                    <div class="col col-23 offset-1">
                        <div class="children-key" aria-hidden="true">
                            <ul>
                                <li><i class="child-a"></i>for Michael</li>
                                <li><i class="child-b"></i>for Elizabeth</li>
                                <li><i class="child-c"></i>for Ethan</li>
                                <li><i class="child-d"></i>for Jeremy</li>
                                <li><i class="child-e"></i>for Franklin</li>
                            </ul>
                        </div>
                        <!-- .children-key -->
                    </div>
                    <!-- .col -->
                </div>
                <!-- .row -->
            </div>
            <!-- .child-content-indicator -->
            <!-- END PARTIAL: children-key -->--%>
            <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
        </div>

    </div>
</div>
<!-- .container -->
<!-- END PARTIAL: pagetopic-dl-landing -->
<div class="container flush dl-content landing">
    <div class="row">
        <div class="col col-23 offset-1">
            <section class="dl-list-results skiplink-content">
                <asp:Repeater ID="rptrCategories" runat="server" 
                    ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.DecisionTool.DecisionQuestionCategoryFolderItem">
                    <ItemTemplate>
                        <div class="result-section row clearfix">
                            <div class="col col-24">
                                <header>
                                    <h2 class="rs_read_this"><%# Item.Title.Rendered %></h2>
                                </header>
                            </div>
                            <div class="results-outer-wrapper">
                                <div class="results-wrapper" data-section-number="carousel-1">
                                    <asp:Repeater ID="rptrQuestions" runat="server" 
                                        ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Pages.DecisionQuestionPageItem">
                                        <ItemTemplate>
                                            <!-- BEGIN PARTIAL: decision-lite/dl-list-item -->
                                            <div class="search-result rs_read_this<%# Container.ItemIndex % 3 == 0 ? " item-four" : string.Empty %>" 
                                                aria-role="main">
                                                <button class="result-body rs_preserve">
                                                    <div class="result-topic"><%# Item.ContentPage.PageTitle.Rendered %></div>
                                                    <div class="result-hover">
                                                        <div class="hover-link-wrapper">
                                                            <a href="<%# Item.GetStartUrl() %>" class="topic-question"><%# Item.ContentPage.PageTitle.Rendered %></a>
                                                        </div>
                                                    </div>
                                                </button>
                                                <span class="children-key">
                                                    <ul>
                                                        <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                                    </ul>
                                                </span>
                                            </div>
                                            <!-- END PARTIAL: decision-lite/dl-list-item -->
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!-- .results-wrapper -->
                            </div>
                            <!-- .results-outer-wrapper -->
                        </div>
                    </ItemTemplate>
                </asp:Repeater>           
            </section>
        </div>
    </div>
</div>
<!-- .container -->
