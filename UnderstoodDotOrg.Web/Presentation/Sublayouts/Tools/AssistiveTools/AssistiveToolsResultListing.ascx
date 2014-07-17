<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssistiveToolsResultListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.AssistiveToolsResultListing" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>

<div class="search-result row rs_read_this">
    <div class="result-image screenshots-popover col col-3 offset-1">
        <div class="result-image-inner">
            <!-- This hidden span's content matches the alt tag of the image which ReadSpeaker is ignoring -->
            <span class="visuallyhidden rs_read"><%= Model.ThumbnailImage.Field.Alt %></span>
            <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom">
                <%= Model.ThumbnailImage.Rendered %>
            </a>
            <span class="icon-search rs_preserve rs_skip"><asp:Label id="lblSearch" runat="server" Text="" /></span>
        </div>
        <!-- BEGIN PARTIAL: assistive-tech-screenshots-popover -->
        <!-- popover hidden content -->
        <div class="popover-container popover-content rs_skip" style="display:none;">
            <!-- Borrows CSS class from other module -->
            <section class="user-child-details-popover">
                <div class="tooltip-title"><%= Model.Title.Rendered %></div>
                <div class="change-slide-buttons arrows-gray rs_skip">
                    <span class="count">
                        <span class="curr">1</span>
                        of 3</span>
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
    <div class="result-details col col-7 offset-1">
        <h3 class="result-title"><a href="<%= Model.GetUrl() %>" style="color: rgb(122, 65, 131);"><%= Model.Title.Rendered %></a></h3>
        <div class="result-description"><%= Model.Summary.Rendered %></div>
        <div class="result-keywords">
            <ul>
                <asp:Repeater ID="rptrSubjects" runat="server"
                    ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData.AssistiveToolsSubjectItem">
                    <ItemTemplate>
                        <li>
                            <%# Item.Metadata.ContentTitle.Rendered %>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="see-rating rs_skip" style="display: none;">
            <div class="popover-trigger-container">
                <a href="REPLACE" class="popover-link rs_preserve rs_skip" data-popover-placement="bottom"><asp:Label ID="lblSeeRating" runat="server" Text="" /></a>
            </div>
            <!-- BEGIN PARTIAL: popover-see-rating -->
            <div class="search-result row popover-container" style="display: none;">
                <div class="result-image">
                    <%= Model.ThumbnailImage.Rendered %>
                    <div class="result-type">(App, 2013)</div>
                </div>
                <div class="result-details">
                    <h3 class="result-title"><%= Model.Title.Rendered %></h3>
                    <div class="result-description"><%= Model.Summary.Rendered %></div>
                </div>

                <div class="result-ratings col col-11 offset-1">
                    <div class="rating-label"><asp:Label ID="lblGrade" runat="server" Text="" /></div>
                    <div class="grade-scale-wrapper">
                        <span class="visuallyhidden">rating</span>
                        <div class="grade-scale">
                            <div class="selection grade<%= Model.TargetGrade.Rendered %>"><%= Model.TargetGrade.Rendered %></div>
                            <asp:Repeater ID="rptrAppropriateGrades" runat="server">
                                <ItemTemplate>
                                    <span class="grade<%# Eval("Grade") %> grade <%# Eval("Color") %> rs_skip"><%# Eval("Grade") %></span>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <div class="rating-label"><asp:label ID="lblQuality" runat="server" Text="" /></div>
                    <div class="quality-scale-wrapper">
                        <span class="visuallyhidden">rating</span>
                        <div class="quality-scale">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-<%= SpelledNumbers[Model.Quality.Integer] %>" aria-label="<%= Model.Quality.Integer %>"><%= Model.Quality.Integer %></div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                    </div>

                    <div class="rating-label"><asp:Label runat="server" ID="lblLearningFragment" Text="" /></div>
                    <div class="learning-scale-wrapper">
                        <span class="visuallyhidden">rating</span>
                        <div class="learning-scale">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider purple-<%= SpelledNumbers[Model.Learning.Integer] %>" aria-label="<%= Model.Learning.Integer %>"><%= Model.Learning.Integer %></div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                    </div>
                </div>
                <!-- .result-ratings -->
            </div>
            <!-- .search-result -->
            <!-- END PARTIAL: popover-see-rating -->
        </div>
    </div>

    <div class="result-ratings show-popover col col-10">
        <div class="rating-label"><asp:Label ID="lblGrade1" runat="server" Text="" /></div>
        <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.RatingLabel %></span>
        <div class="grade-scale-wrapper">
            <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.RatingLabel %></span>
            <div class="grade-scale">
                <div class="selection grade<%= Model.TargetGrade.Rendered %>"><%= Model.TargetGrade.Rendered %></div>
                <asp:Repeater ID="rptrAppropriateGrades2" runat="server">
                    <ItemTemplate>
                        <span class="grade<%# Eval("Grade") %> grade <%# Eval("Color") %> rs_skip" aria-hidden="true" role="presentation"><%# Eval("Grade") %></span>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="grade-info-wrapper rs_skip">
            <div class="popover-trigger-container">
                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip"><asp:Label ID="lblMoreInformation" runat="server" Text="" /></i></a>
            </div>
            <!-- BEGIN PARTIAL: popover-grade-info -->
            <div class="grade-tooltip popover-container" style="display: none;">
                <div class="tooltip-title"><asp:label id="lblAboutOurRatingSystem" runat="server" text="" /></div>
                <div class="ratings-wrapper">
                    <div class="rating">
                        <div class="rating-icon">
                            <span class="circle green"></span>
                        </div>
                        <div class="rating-info"><strong><asp:Label ID="lblOnFragment" runat="server" Text="" /></strong> <asp:Label ID="lblContentIsAppropriate" runat="server" Text="" /></div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <span class="circle yellow"></span>
                        </div>
                        <div class="rating-info"><strong><asp:Label ID="lblPauseFragment" runat="server" Text="" /></strong> <asp:Label ID="lblKnowYourChild" runat="server" Text="" /></div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <span class="circle red"></span>
                        </div>
                        <div class="rating-info"><strong><asp:Label ID="lblOffFragment" runat="server" Text="" /></strong> <asp:Label ID="lblNotAppropriate" runat="server" Text="" /></div>
                    </div>
                </div>
                <!-- .ratings-wrapper -->
            </div>
            <!-- .grade-tooltip -->
            <!-- END PARTIAL: popover-grade-info -->
        </div>

        <div class="rating-label"><asp:Label ID="lblQuality1" runat="server" Text="" /></div>
        <div class="quality-scale-wrapper">
            <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.RatingLabel %></span>
            <div class="quality-scale">
                <!-- BEGIN PARTIAL: results-slider -->
                <div class="results-slider blue-<%= SpelledNumbers[Model.Quality.Integer] %>" aria-label="<%= Model.Quality.Integer %>"><%= Model.Quality.Integer %></div>
                <!-- END PARTIAL: results-slider -->
            </div>
        </div>
        <div class="quality-info-wrapper rs_skip">
            <span class="popover-trigger-container">
                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip"><asp:Label ID="lblMoreInformation1" runat="server" Text="" /></i></a></span>
            <!-- BEGIN PARTIAL: popover-quality-info -->
            <div class="quality-tooltip popover-container" style="display: none;">
                <div class="tooltip-title"><asp:Label ID="lblQualityRating" runat="server" Text="" /></div>
                <div class="ratings-wrapper">
                    <div class="rating">
                        <div class="rating-icon">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-five" aria-label="5">5</div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                        <div class="rating-info"><asp:Label ID="lblTheBest" runat="server" Text="" /></div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-four" aria-label="4">4</div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                        <div class="rating-info"><asp:Label ID="lblReallyGood" runat="server" Text="" /></div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-three" aria-label="3">3</div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                        <div class="rating-info"><asp:Label ID="lblJustFine" runat="server" Text="" /></div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-two" aria-label="2">2</div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                        <div class="rating-info"><asp:Label ID="lblDisappointing" runat="server" Text="" /></div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-one" aria-label="1">1</div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                        <div class="rating-info"><asp:Label ID="lblDontBother" runat="server" Text="" /></div>
                    </div>
                </div>
                <!-- .ratings-wrapper -->
            </div>
            <!-- .quality-tooltip -->
            <!-- END PARTIAL: popover-quality-info -->
            <a class="quality-review-link" href="<%= Model.GetUrl()+"#tabs2-parent-reviews" %>"><asp:Literal ID="litNumReviews" runat="server"></asp:Literal> <%= UnderstoodDotOrg.Common.DictionaryConstants.ReviewsLabel %></a>
        </div>

        <div class="rating-label"><asp:Label ID="lblLearningFragment1" runat="server" Text="" /></div>
        <div class="learning-scale-wrapper">
            <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.RatingLabel %></span>
            <div class="learning-scale">
                <!-- BEGIN PARTIAL: results-slider -->
                <div class="results-slider purple-<%= SpelledNumbers[Model.Learning.Integer] %>" aria-label="<%= Model.Learning.Integer %>"><%= Model.Learning.Integer %></div>
                <!-- END PARTIAL: results-slider -->
            </div>
            <div class="learning-info-wrapper rs_skip">
                <div class="popover-trigger-container">
                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip"><asp:Label ID="lblMoreInformation2" runat="server" Text="" /></i></a>
                </div>
                <!-- BEGIN PARTIAL: popover-learning-info -->
                <div class="learning-tooltip popover-container" style="display: none;">
                    <div class="tooltip-title">Learning Rating</div>
                    <div class="ratings-wrapper">
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider purple-five" aria-label="5">5</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong><asp:Label ID="lblBestFragment" runat="server" Text="" /></strong> <asp:Label ID="lblReallyEngaging" runat="server" Text="" /></div>
                        </div>
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider purple-four" aria-label="4">4</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong><asp:Label ID="lblVeryGoodFragment" runat="server" Text="" /></strong> <asp:Label ID="lblEngaging" runat="server" Text="" /></div>
                        </div>
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider purple-three" aria-label="3">3</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong><asp:Label ID="lblGoodFragment" runat="server" Text="" /></strong> <asp:Label ID="lblPrettyEngaging" runat="server" Text="" /></div>
                        </div>
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider purple-two" aria-label="2">2</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong><asp:Label ID="lblFairFragment" runat="server" Text="" /></strong> <asp:Label ID="lblSomewhatEngaging" runat="server" Text="" /></div>
                        </div>
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider purple-one" aria-label="1">1</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong><asp:Label ID="lblNotForLearningFragment" runat="server" Text="" /></strong> <asp:Label ID="lblNotRecommended" runat="server" Text="" /></div>
                        </div>
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider zero" aria-label="0">0</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong><asp:Label ID="lblNotForKidsFragment" runat="server" Text="" /></strong> <asp:Label ID="lblNotAgeAppropriate" runat="server" Text="" /></div>
                        </div>
                    </div>
                    <!-- .ratings-wrapper -->
                </div>
                <!-- .learning-tooltip -->
                <!-- END PARTIAL: popover-learning-info -->
            </div>
        </div>
    </div>
    <!-- .result-ratings -->
</div>
<!-- .search-result -->
