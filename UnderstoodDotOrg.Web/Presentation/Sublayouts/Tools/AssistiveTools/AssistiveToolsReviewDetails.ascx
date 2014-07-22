<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsReviewDetails.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsReviewDetails" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- Page Title -->
<div class="container page-topic">
    <div class="row">
        <div class="col col-14 offset-1">
            <div class="rs_read_this">
                <h1><%= Model.AssistiveToolsBasePage.ContentPage.PageTitle %></h1>
                <%= Model.AssistiveToolsBasePage.ContentPage.BodyContent %>
            </div>
        </div>
        <div class="col col-9">
            <!-- BEGIN PARTIAL: share-save -->
            <sc:Sublayout ID="sbShareTool" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />
            <!-- END PARTIAL: share-save -->
        </div>
    </div>
</div>

<div class="container tech-results-single-container">
    <div class="row">
        <!-- article -->
        <div class="col col-23 offset-1">
            <!-- BEGIN PARTIAL: back-button -->
            <!-- Back Button -->
            <div class="back-button">
                <div class="rating-container">
                    <div><sc:FieldRenderer ID="frRandRby" runat="server" FieldName="Review and ratings by Text" /></div>
                    <sc:FieldRenderer ID="frSponsorImage" runat="server" FieldName="Sponsor Image" />
                </div>
                <div class="back-results-container">
                    <a id="anchorBackLink" runat="server" class="back-to-previous"><i id="arrowDiv" runat="server" class="icon-arrow-left-blue"></i><asp:label ID="lblBackToResults" runat="server" Text="" /></a>
                </div>
            </div>
            <!-- .container -->

            <!-- END PARTIAL: back-button -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container article">
    <div class="row">
        <!-- article -->
        <div class="col col-24 skiplink-feature">
            <!-- BEGIN PARTIAL: tech-results-single -->
            <section class="tech-search-results single">
                <div class="tech-results-wrapper rs_read_this">
                    <div class="search-result row">
                        <div class="result-image screenshots-popover col col-4 offset-1">
                            <!-- This hidden span's content matches the alt tag of the image which ReadSpeaker is ignoring -->
                            <span class="visuallyhidden rs_read"><%= Model.ThumbnailImage.Field.Alt %></span>
                            <div class="result-image-inner">
                                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">
                                    <%= Model.ThumbnailImage.Rendered %>
                                </a>
                                <span class="icon-search rs_preserve"><%= UnderstoodDotOrg.Common.DictionaryConstants.SearchLabel %></span>
                            </div>
                            <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
                            <!-- popover hidden content -->
                            <div class="popover-container popover-content rs_skip">
                                <!-- Borrows CSS class from other module -->
                                <section class="user-child-details-popover">
                                    <div class="tooltip-title rs_skip"><%= Model.Title.Rendered %></div>
                                    <div class="change-slide-buttons arrows-gray rs_skip">
                                        <span class="count">
                                            <span class="curr">1</span>
                                            <%= UnderstoodDotOrg.Common.DictionaryConstants.ofFragment %> <%= Model.Screenshots.ListItems.Count %></span>
                                        <div class="rsArrow rsArrowRight">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                        <div class="rsArrow rsArrowLeft">
                                            <div class="rsArrowIcn"></div>
                                        </div>
                                    </div>
                                    <asp:Repeater ID="rptrScreenshots" runat="server">
                                        <ItemTemplate>
                                            <div class="slide<%# Container.ItemIndex == 0 ? " active" : string.Empty %>">
                                                <img alt="<%# Eval("Alt") %>" src="<%# Eval("Url") %>" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </section>
                            </div>
                            <!-- END PARTIAL: assistive-tech-screenshots-popover -->
                            <div class="result-type">(App, 2013)</div>
                        </div>

                        <div class="result-ratings-wrap col col-11 offset-1">
                            <div class="result-ratings">
                                <div class="result-details">
                                    <h3 class="result-title"><%= Model.Title.Rendered %></h3>
                                    <div class="result-description"><%= Model.Summary.Rendered %></div>
                                    <div class="result-keywords">
                                        <ul>
                                            <asp:Repeater ID="rptrSubjects" runat="server" 
                                                ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData.AssistiveToolsSubjectItem">
                                                <ItemTemplate>
                                                    <li>
                                                        <a href="REPLACE"><%# Item.Metadata.ContentTitle.Rendered %></a>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>

                                <div class="tech-search-results-ratings">
                                    <div class="rating-grade-container">
                                        <div class="rating-label"><asp:label ID="lblGrade" runat="server" Text="" /></div>
                                        <div class="grade-scale-wrapper">
                                            <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.RatingLabel %></span>
                                            <div class="grade-scale">
                                                <div class="selection grade<%= Model.TargetGrade.Rendered %>"><%= Model.TargetGrade.Rendered %></div>
                                                <asp:Repeater ID="rptrAppropriateGrades" runat="server">
                                                    <ItemTemplate>
                                                        <span class="grade<%# Eval("Grade") %> grade <%# Eval("Color") %> rs_skip" aria-hidden="true" 
                                                            role="presentation"><%# Eval("Grade") %></span>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                        <div class="grade-info-wrapper rs_skip">
                                            <div class="popover-trigger-container">
                                                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip"><asp:label ID="lblMoreInfo" runat="server" Text="" /></i></a>
                                            </div>
                                            <!-- BEGIN PARTIAL: popover-grade-info -->
                                            <div class="grade-tooltip popover-container">
                                                <div class="tooltip-title"><asp:label ID="lblAboutOurRatingSystem" runat="server" Text="" /></div>
                                                <div class="ratings-wrapper">
                                                    <div class="rating">
                                                        <div class="rating-icon">
                                                            <span class="circle green"></span>
                                                        </div>
                                                        <div class="rating-info"><strong><asp:label ID="lblOnFragment" runat="server" Text="" /></strong> <asp:label ID="lblContentIsAppropriate" runat="server" Text="" /></div>
                                                    </div>
                                                    <div class="rating">
                                                        <div class="rating-icon">
                                                            <span class="circle yellow"></span>
                                                        </div>
                                                        <div class="rating-info"><strong><asp:label ID="lblPauseFragment" runat="server" Text="" /></strong> <asp:label ID="lblKnowYourChild" runat="server" Text="" /></div>
                                                    </div>
                                                    <div class="rating">
                                                        <div class="rating-icon">
                                                            <span class="circle red"></span>
                                                        </div>
                                                        <div class="rating-info"><strong><asp:label ID="lblOffFragment" runat="server" Text="" /></strong> <asp:label ID="lblNotAppropriate" runat="server" Text="" /></div>
                                                    </div>
                                                </div>
                                                <!-- .ratings-wrapper -->
                                            </div>
                                            <!-- .grade-tooltip -->
                                            <!-- END PARTIAL: popover-grade-info -->
                                        </div>
                                    </div>

                                    <div class="quality-learning-scale-wrap">

                                        <div class="quality-scale-container">
                                            <div class="rating-label"><asp:label ID="lblQuality" runat="server" Text="" /></div>
                                            <div class="quality-scale-wrapper">
                                                <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.RatingLabel %></span>
                                                <div class="quality-scale">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider blue-<%= SpelledNumbers[Model.Quality.Integer] %>" 
                                                        aria-label="<%= Model.Quality.Integer %>"><%= Model.Quality.Integer %></div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                            </div>

                                            <div class="quality-info-wrapper rs_skip">
                                                <div class="popover-trigger-container">
                                                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip"><asp:label ID="lblMoreInformation" runat="server" Text="" /></i></a>
                                                </div>
                                                <!-- BEGIN PARTIAL: popover-quality-info -->
                                                <div class="quality-tooltip popover-container">
                                                    <div class="tooltip-title"><asp:label ID="lblQualityRating" runat="server" Text="" /></div>
                                                    <div class="ratings-wrapper">
                                                        <div class="rating">
                                                            <div class="rating-icon">
                                                                <!-- BEGIN PARTIAL: results-slider -->
                                                                <div class="results-slider blue-five" aria-label="5">5</div>
                                                                <!-- END PARTIAL: results-slider -->
                                                            </div>
                                                            <div class="rating-info"><asp:label ID="lblTheBest" runat="server" Text="" /></div>
                                                        </div>
                                                        <div class="rating">
                                                            <div class="rating-icon">
                                                                <!-- BEGIN PARTIAL: results-slider -->
                                                                <div class="results-slider blue-four" aria-label="4">4</div>
                                                                <!-- END PARTIAL: results-slider -->
                                                            </div>
                                                            <div class="rating-info"><asp:label ID="lblReallyGood" runat="server" Text="" /></div>
                                                        </div>
                                                        <div class="rating">
                                                            <div class="rating-icon">
                                                                <!-- BEGIN PARTIAL: results-slider -->
                                                                <div class="results-slider blue-three" aria-label="3">3</div>
                                                                <!-- END PARTIAL: results-slider -->
                                                            </div>
                                                            <div class="rating-info"><asp:label ID="lblJustFine" runat="server" Text="" /></div>
                                                        </div>
                                                        <div class="rating">
                                                            <div class="rating-icon">
                                                                <!-- BEGIN PARTIAL: results-slider -->
                                                                <div class="results-slider blue-two" aria-label="2">2</div>
                                                                <!-- END PARTIAL: results-slider -->
                                                            </div>
                                                            <div class="rating-info"><asp:label ID="lblDisappointing" runat="server" Text="" /></div>
                                                        </div>
                                                        <div class="rating">
                                                            <div class="rating-icon">
                                                                <!-- BEGIN PARTIAL: results-slider -->
                                                                <div class="results-slider blue-one" aria-label="1">1</div>
                                                                <!-- END PARTIAL: results-slider -->
                                                            </div>
                                                            <div class="rating-info"><asp:label ID="lblDontBother" runat="server" Text="" /></div>
                                                        </div>
                                                    </div>
                                                    <!-- .ratings-wrapper -->
                                                </div>
                                                <!-- .quality-tooltip -->
                                                <!-- END PARTIAL: popover-quality-info -->
                                            </div>
                                        </div>
                                        <div class="learning-scale-container">
                                            <div class="rating-label"><%= UnderstoodDotOrg.Common.DictionaryConstants.Learningfragment %></div>
                                            <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.RatingLabel %></span>
                                            <div class="learning-scale-wrapper">
                                                <div class="learning-scale">
                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                    <div class="results-slider purple-<%= SpelledNumbers[Model.Learning.Integer] %>" 
                                                        aria-label="<%= Model.Learning.Integer %>"><%= Model.Learning.Integer %></div>
                                                    <!-- END PARTIAL: results-slider -->
                                                </div>
                                                <div class="learning-info-wrapper rs_skip">
                                                    <div class="popover-trigger-container">
                                                        <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip"><asp:label ID="lblMoreInformation1" runat="server" Text="" /></i></a>
                                                    </div>
                                                    <!-- BEGIN PARTIAL: popover-learning-info -->
                                                    <div class="learning-tooltip popover-container">
                                                        <div class="tooltip-title"><%= UnderstoodDotOrg.Common.DictionaryConstants.Learningfragment %> <%= UnderstoodDotOrg.Common.DictionaryConstants.RatingLabel %></div>
                                                        <div class="ratings-wrapper">
                                                            <div class="rating">
                                                                <div class="rating-icon">
                                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                                    <div class="results-slider purple-five" aria-label="5">5</div>
                                                                    <!-- END PARTIAL: results-slider -->
                                                                </div>
                                                                <div class="rating-info"><strong><asp:label ID="lblBestFragment" runat="server" Text="" /></strong> <asp:label ID="lblReallyEngaging" runat="server" Text="" /></div>
                                                            </div>
                                                            <div class="rating">
                                                                <div class="rating-icon">
                                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                                    <div class="results-slider purple-four" aria-label="4">4</div>
                                                                    <!-- END PARTIAL: results-slider -->
                                                                </div>
                                                                <div class="rating-info"><strong><asp:label ID="lblVeryGoodFragment" runat="server" Text="" /></strong> <asp:label ID="lblEngaging" runat="server" Text="" /></div>
                                                            </div>
                                                            <div class="rating">
                                                                <div class="rating-icon">
                                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                                    <div class="results-slider purple-three" aria-label="3">3</div>
                                                                    <!-- END PARTIAL: results-slider -->
                                                                </div>
                                                                <div class="rating-info"><strong><asp:label ID="lblGoodFragment" runat="server" Text="" /></strong> <asp:label ID="lblPrettyEngaging" runat="server" Text="" /></div>
                                                            </div>
                                                            <div class="rating">
                                                                <div class="rating-icon">
                                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                                    <div class="results-slider purple-two" aria-label="2">2</div>
                                                                    <!-- END PARTIAL: results-slider -->
                                                                </div>
                                                                <div class="rating-info"><strong><asp:label ID="lblFairFragment" runat="server" Text="" /></strong> <asp:label ID="lblSomewhatEngaging" runat="server" Text="" /></div>
                                                            </div>
                                                            <div class="rating">
                                                                <div class="rating-icon">
                                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                                    <div class="results-slider purple-one" aria-label="1">1</div>
                                                                    <!-- END PARTIAL: results-slider -->
                                                                </div>
                                                                <div class="rating-info"><strong><asp:label ID="lblNotForLearningFragment" runat="server" Text="" /></strong> <asp:label ID="lblNotRecommended" runat="server" Text="" /></div>
                                                            </div>
                                                            <div class="rating">
                                                                <div class="rating-icon">
                                                                    <!-- BEGIN PARTIAL: results-slider -->
                                                                    <div class="results-slider zero" aria-label="0">0</div>
                                                                    <!-- END PARTIAL: results-slider -->
                                                                </div>
                                                                <div class="rating-info"><strong><asp:label ID="lblNotForKidsFragment" runat="server" Text="" /></strong> <asp:label ID="lblNotAgeAppropriate" runat="server" Text="" /></div>
                                                            </div>
                                                        </div>
                                                        <!-- .ratings-wrapper -->
                                                    </div>
                                                    <!-- .learning-tooltip -->
                                                    <!-- END PARTIAL: popover-learning-info -->
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                                <!-- .tech-search-results-ratings -->
                            </div>
                            <!-- .result-ratings -->
                        </div>
                        <div class="col col-6 offset-1">
                            <!-- BEGIN PARTIAL: get-this-app -->
                            <div class="get-this-app">
                                <div class="purchase"><%= UnderstoodDotOrg.Common.DictionaryConstants.PurchaseLabel %></div>
                                <div class="price"><%= UnderstoodDotOrg.Common.DictionaryConstants.PriceLabel %> <%= Model.Price.Rendered %></div>
                                <% if (Model.AppleAppStoreID != string.Empty) { %>
                                <a href="https://itunes.apple.com/app/<%= Model.AppleAppStoreID.Rendered %>">
                                    <sc:Image ID="AppleImage" Field="App Store Image" runat="server" />
                                </a>
                                <% } 
                                   if (Model.AppleAppStoreID != string.Empty) { %>
                                <a href="https://play.google.com/store/apps/details?id=<%= Model.GooglePlayStoreID.Rendered %>">
                                    <sc:Image ID="GoogleImage" Field="Google Store Image" runat="server" />
                                </a>
                                <% } %>
                            </div>
                            <!-- END PARTIAL: get-this-app -->
                        </div>
                    </div>
                    <!-- .search-result -->
                </div>
                <!-- .tech-results-wrapper -->
            </section>
            <!-- END PARTIAL: tech-results-single -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
