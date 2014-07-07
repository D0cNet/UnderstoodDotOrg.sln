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
            <span class="icon-search rs_preserve rs_skip">search</span>
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
                            <a href="REPLACE"><%# Item.Metadata.ContentTitle.Rendered %></a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="see-rating rs_skip" style="display: none;">
            <div class="popover-trigger-container">
                <a href="REPLACE" class="popover-link rs_preserve rs_skip" data-popover-placement="bottom">See Rating</a>
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
                    <div class="rating-label">Grade</div>
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

                    <div class="rating-label">Quality</div>
                    <div class="quality-scale-wrapper">
                        <span class="visuallyhidden">rating</span>
                        <div class="quality-scale">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-<%= SpelledNumbers[Model.Quality.Integer] %>" aria-label="<%= Model.Quality.Integer %>"><%= Model.Quality.Integer %></div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                    </div>

                    <div class="rating-label">Learning</div>
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
        <div class="rating-label">Grade</div>
        <span class="visuallyhidden">rating</span>
        <div class="grade-scale-wrapper">
            <span class="visuallyhidden">rating</span>
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
                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a>
            </div>
            <!-- BEGIN PARTIAL: popover-grade-info -->
            <div class="grade-tooltip popover-container" style="display: none;">
                <div class="tooltip-title">About our rating system</div>
                <div class="ratings-wrapper">
                    <div class="rating">
                        <div class="rating-icon">
                            <span class="circle green"></span>
                        </div>
                        <div class="rating-info"><strong>On:</strong> Content is appropriate for kids this age.</div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <span class="circle yellow"></span>
                        </div>
                        <div class="rating-info"><strong>Pause:</strong> Know your child; some content may not be right for some kids.</div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <span class="circle red"></span>
                        </div>
                        <div class="rating-info"><strong>Off:</strong> Not appropriate for kids this age.</div>
                    </div>
                </div>
                <!-- .ratings-wrapper -->
            </div>
            <!-- .grade-tooltip -->
            <!-- END PARTIAL: popover-grade-info -->
        </div>

        <div class="rating-label">Quality</div>
        <div class="quality-scale-wrapper">
            <span class="visuallyhidden">rating</span>
            <div class="quality-scale">
                <!-- BEGIN PARTIAL: results-slider -->
                <div class="results-slider blue-<%= SpelledNumbers[Model.Quality.Integer] %>" aria-label="<%= Model.Quality.Integer %>"><%= Model.Quality.Integer %></div>
                <!-- END PARTIAL: results-slider -->
            </div>
        </div>
        <div class="quality-info-wrapper rs_skip">
            <span class="popover-trigger-container">
                <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a></span>
            <!-- BEGIN PARTIAL: popover-quality-info -->
            <div class="quality-tooltip popover-container" style="display: none;">
                <div class="tooltip-title">Quality Rating</div>
                <div class="ratings-wrapper">
                    <div class="rating">
                        <div class="rating-icon">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-five" aria-label="5">5</div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                        <div class="rating-info">The best!</div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-four" aria-label="4">4</div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                        <div class="rating-info">Really Good</div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-three" aria-label="3">3</div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                        <div class="rating-info">Just Fine</div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-two" aria-label="2">2</div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                        <div class="rating-info">Disappointing</div>
                    </div>
                    <div class="rating">
                        <div class="rating-icon">
                            <!-- BEGIN PARTIAL: results-slider -->
                            <div class="results-slider blue-one" aria-label="1">1</div>
                            <!-- END PARTIAL: results-slider -->
                        </div>
                        <div class="rating-info">Don't Bother</div>
                    </div>
                </div>
                <!-- .ratings-wrapper -->
            </div>
            <!-- .quality-tooltip -->
            <!-- END PARTIAL: popover-quality-info -->
            <a class="quality-review-link" href="REPLACE"><asp:Literal ID="litNumReviews" runat="server"></asp:Literal> Reviews</a>
        </div>

        <div class="rating-label">Learning</div>
        <div class="learning-scale-wrapper">
            <span class="visuallyhidden">rating</span>
            <div class="learning-scale">
                <!-- BEGIN PARTIAL: results-slider -->
                <div class="results-slider purple-<%= SpelledNumbers[Model.Learning.Integer] %>" aria-label="<%= Model.Learning.Integer %>"><%= Model.Learning.Integer %></div>
                <!-- END PARTIAL: results-slider -->
            </div>
            <div class="learning-info-wrapper rs_skip">
                <div class="popover-trigger-container">
                    <a href="REPLACE" class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip">more information</i></a>
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
                            <div class="rating-info"><strong>Best:</strong> Really engaging, excellent learning approach.</div>
                        </div>
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider purple-four" aria-label="4">4</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong>Very Good:</strong> Engaging, very good learning approach.</div>
                        </div>
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider purple-three" aria-label="3">3</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong>Good:</strong> Pretty engaging, good learning approach.</div>
                        </div>
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider purple-two" aria-label="2">2</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong>Fair:</strong> Somewhat engaging, okay learning approach.</div>
                        </div>
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider purple-one" aria-label="1">1</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong>Not for learning:</strong> Not recommended for learning.</div>
                        </div>
                        <div class="rating">
                            <div class="rating-icon">
                                <!-- BEGIN PARTIAL: results-slider -->
                                <div class="results-slider zero" aria-label="0">0</div>
                                <!-- END PARTIAL: results-slider -->
                            </div>
                            <div class="rating-info"><strong>Not for kids:</strong> Not age-appropriate for kids; not recommended for learning.</div>
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
