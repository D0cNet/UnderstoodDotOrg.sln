<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParentReviewsTab.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.ReviewTabs.ParentReviewsTab" %>

<div id="tabs2-parent-reviews" class="panel-container">
    <div class="row ">
        <div class="col col-17">
            <div class="review-intro rs_read_this">
                <span class="visuallyhidden">review rating</span>
                <div class="review-rating">
                    <!-- BEGIN PARTIAL: results-slider -->
                    <asp:Literal ID="litAverageRating" runat="server"></asp:Literal>
                    <!-- END PARTIAL: results-slider -->
                    <h4><asp:Literal ID="litNumberOfReviews" runat="server"></asp:Literal></h4>
                    <p><%= UnderstoodDotOrg.Common.DictionaryConstants.ForLearningIssuesLabel %></p>
                </div>
                <!-- end review-rating -->
                <div class="review-rating-sort select-inverted-mobile">
                    <label for="parent-review-comment-sort">Sort By:</label>
                    <asp:DropDownList ID="ddlSorting" runat="server" CssClass="comment-sort" AutoPostBack="true" OnSelectedIndexChanged="ddlSorting_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <!-- end review-rating -->
            </div>
            <!-- end .review-intro -->
            <div class="parent-reviews">
                <section class="parent-review rs_read_this what-you-need-to-know-rs-wrapper">
                    <asp:Repeater ID="rptReviews" runat="server" OnItemDataBound="rptReviews_ItemDataBound">
                        <ItemTemplate>
                            <div class="review-section-title">
                                <div class="review-section grade">
                                    <%= UnderstoodDotOrg.Common.DictionaryConstants.GradeLabel %>
                                    <span class="review-grade four"><asp:Literal ID="litGrade" runat="server"></asp:Literal></span>
                                </div>
                                <div class="review-section quality">
                                    <%= UnderstoodDotOrg.Common.DictionaryConstants.QualityLabel %>
                                    <span class="visuallyhidden">rating</span>
                                    <span>
                                        <asp:Literal ID="litRating" runat="server"></asp:Literal>
                                    </span>
                                </div>
                                <div class="review-section date"><asp:Literal ID="litReviewDate" runat="server"></asp:Literal></div>
                            </div>
                        <p>
                            <strong><asp:Literal ID="litTitle" runat="server"></asp:Literal></strong> <asp:Literal ID="litReviewContent" runat="server"></asp:Literal>
                        </p>
                        <asp:Repeater ID="rptSkills" runat="server" OnItemDataBound="rptSkills_ItemDataBound">
                            <HeaderTemplate>
                                <p>
                                    <span><%= UnderstoodDotOrg.Common.DictionaryConstants.GoodForLabel %></span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <span class="link-separator"><asp:Literal ID="litSkill" runat="server"></asp:Literal></span>
                            </ItemTemplate>
                            <FooterTemplate>
                                </p>
                            </FooterTemplate>
                        </asp:Repeater>
                        <div class="review-report">
                            <span class="write-review">
                                <i></i>
                                <a href="#write-review"><%= UnderstoodDotOrg.Common.DictionaryConstants.WriteYourOwnReviewLabel %></a></span>
                            <span class="review-report">
                                <i></i>
                                <a href="#" id="reportAnchor" runat="server" onserverclick="reportAnchor_ServerClick"><%= UnderstoodDotOrg.Common.DictionaryConstants.ReviewReportLabel %></a></span>
                        </div>
                        <!-- end review-report -->
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:Panel ID="pnlShowMore" runat="server" CssClass="hide-show-more">
                        <asp:Repeater ID="rptShowMoreReviews" runat="server" OnItemDataBound="rptReviews_ItemDataBound">
                            <ItemTemplate>
                                <div class="review-section-title">
                                    <div class="review-section grade">
                                        <%= UnderstoodDotOrg.Common.DictionaryConstants.GradeLabel %>
                                        <span class="review-grade four"><asp:Literal ID="litGrade" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="review-section quality">
                                        <%= UnderstoodDotOrg.Common.DictionaryConstants.QualityLabel %>
                                        <span class="visuallyhidden">rating</span>
                                        <span>
                                            <asp:Literal ID="litRating" runat="server"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="review-section date"><asp:Literal ID="litReviewDate" runat="server"></asp:Literal></div>
                                </div>
                            <p>
                                <strong><asp:Literal ID="litTitle" runat="server"></asp:Literal></strong> <asp:Literal ID="litReviewContent" runat="server"></asp:Literal>
                            </p>
                            <asp:Repeater ID="rptSkills" runat="server" OnItemDataBound="rptSkills_ItemDataBound">
                                <HeaderTemplate>
                                    <p>
                                        <span><%= UnderstoodDotOrg.Common.DictionaryConstants.GoodForLabel %></span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <span class="link-separator"><asp:Literal ID="litSkill" runat="server"></asp:Literal></span>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </p>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div class="review-report">
                                <span class="write-review">
                                    <i></i>
                                    <a href="#write-review"><%= UnderstoodDotOrg.Common.DictionaryConstants.WriteYourOwnReviewLabel %></a></span>
                                <span class="review-report">
                                    <i></i>
                                    <a href="#" id="reportAnchor" runat="server" onserverclick="reportAnchor_ServerClick"><%= UnderstoodDotOrg.Common.DictionaryConstants.ReviewReportLabel %></a></span>
                            </div>
                            <!-- end review-report -->
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                </section>


            </div>
            <style>
                .what-you-need-to-know-tabs #tabs2-parent-reviews section .review-section.date{
                    margin-left: 70px;
                }

                .hide-show-more{
                    display: none;
                }
            </style>
            <!-- .parent-reviews -->
            <!-- Show More -->
            <asp:Panel ID="pnlMoreLink" runat="server" CssClass="show-more" Visible="false">
                <a href="#" class="show-more-link" data-path="assistive-tech/reviews" data-container="parent-reviews" data-item="parent-review" data-count="6" onclick="$('.hide-show-more').show(); $(this).hide();"><%= UnderstoodDotOrg.Common.DictionaryConstants.MoreResultsLabel %><i class="icon-arrow-down-blue"></i></a>
            </asp:Panel>
            <script>
                $(function () {

                    if (<%= OpenTab.ToString().ToLower() %>)
                    {
                        location.hash = '#tabs2-parent-reviews';
                    }
                })
            </script>
            <!-- .show-more -->
            <!-- BEGIN PARTIAL: rate-this-app -->
            <asp:Panel ID="pnlReview" runat="server">
                <section id="write-review" class="rate-this-app">
                    <header>
                        <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.RateThisAppLabel %></h2>
                    </header>
                    <p><%= UnderstoodDotOrg.Common.DictionaryConstants.ForLearningIssuesLabel %></p>
                    <div class="is-it-any-good">
                        <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.RateThisAppLabel %></h3>
                        <!-- BEGIN PARTIAL: results-slider-ratings -->
                        <div class="results-slider zero blue blue-one ">
                            <span class="visuallyhidden">quality rating</span>
                            <button class="slider-button">1</button>
                            <button class="slider-button">2</button>
                            <button class="slider-button">3</button>
                            <button class="slider-button">4</button>
                            <button class="slider-button">5</button>
                        </div>
                        <!-- END PARTIAL: results-slider-ratings -->
                    </div>
                    <div class="for-kids">
                        <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.ForKidsLabel %></h3>
                        <label for="rate-for-kids">
                            <asp:DropDownList ID="ddlGrades" runat="server" aria-required="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvGrades" 
                                ControlToValidate="ddlGrades"
                                validationgroup="vlgReviewInputs" 
                                runat="server" 
                                CssClass="validationerror"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                    <div class="i-think-it-is">
                        <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.IThinkItIsLabel %></h3>
                        <label for="rate-i-think">
                            <asp:DropDownList ID="ddlIThinkItIs" runat="server" aria-required="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator id="rfvIThinkItIs"
                                controltovalidate="ddlIThinkItIs"
                                validationgroup="vlgReviewInputs"
                                runat="server"
                                CssClass="validationerror">
                            </asp:RequiredFieldValidator>
                        </label>
                    </div>
                    <div class="it-is-good-for">
                        <fieldset>
                            <legend><%= UnderstoodDotOrg.Common.DictionaryConstants.ItIsGoodForLabel %></legend>
                            <asp:Repeater ID="rptIssuesChecklist" runat="server" OnItemDataBound="rptSkillsChecklist_ItemDataBound">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <span class="checkbox-wrap">
                                            <input id="inputSkill" runat="server" type="checkbox" name="rate-goodfor-reading"></span>
                                        <label id="issueLabel" runat="server" for="rate-goodfor-reading"><asp:Literal ID="litSkill" runat="server"></asp:Literal></label>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </fieldset>
                    </div>
                    <div class="tell-other-families">
                        <label>
                            <span><%= UnderstoodDotOrg.Common.DictionaryConstants.TellOtherFamiliesLabel %></span>
                            <asp:TextBox ID="txbWhatYouThink" runat="server" TextMode="MultiLine" aria-required="true"></asp:TextBox>
                            <asp:RequiredFieldValidator id="rfvWhatYouThink"
                                controltovalidate="txbWhatYouThink"
                                validationgroup="vlgReviewInputs"
                                runat="server"
                                CssClass="validationerror">
                            </asp:RequiredFieldValidator>
                        </label>
                    </div>
                    <div class="give-your-review">
                        <label>
                            <span><%= UnderstoodDotOrg.Common.DictionaryConstants.GiveReviewTitleLabel %></span>
                            <asp:TextBox ID="txbReviewTitle" runat="server" TextMode="MultiLine" aria-required="true"></asp:TextBox>
                            <asp:RequiredFieldValidator id="rfvReviewTitle"
                                controltovalidate="txbReviewTitle"
                                validationgroup="vlgReviewInputs"
                                runat="server"
                                CssClass="validationerror">
                            </asp:RequiredFieldValidator>
                        </label>
                    </div>
                    <asp:HiddenField ID="hfKeyValuePairs" runat="server" />
                    <asp:HiddenField ID="hfRating" runat="server" />
                    <script>
                        $(function () {

                            if (<%= OpenTab.ToString().ToLower() %>)
                            {
                                setTimeout(function(){
                                   location.hash = '#tabs2-parent-reviews';
                            }, 1000);
                            }

                            var hiddenField = $("[id*='hfKeyValuePairs']");
                            var hiddenField2 = $("[id*='hfRating']");

                            $(".checkbox-wrap").click(function () {
                                var values = "";
                                var first = true;

                                $(this).parent().parent().find(".checked").each(function () {
                                    if (first) {
                                        values = $(this).find('input').data("id");
                                        first = false;
                                    }
                                    else
                                        values += "|" + $(this).find('input').data("id");
                                })

                                hiddenField.val(values);
                            })

                            $(".results-slider").click(function () {
                                $this = $(this);

                                setHiddenRatingValue($this);
                            })

                            function setHiddenRatingValue($element)
                            {
                                if ($element.hasClass("blue-one"))
                                    hiddenField2.val(1);
                                else if ($element.hasClass("blue-two"))
                                    hiddenField2.val(2);
                                else if ($element.hasClass("blue-three"))
                                    hiddenField2.val(3);
                                else if ($element.hasClass("blue-four"))
                                    hiddenField2.val(4);
                                else
                                    hiddenField2.val(5);
                            }

                            setHiddenRatingValue($(".is-it-any-good .results-slider"));
                        })
                    </script>
                    <button ID="btnSubmit" class="review-submit" runat="server" type="button" causesvalidation="false" onserverclick="btnSubmit_Click" onclick="reviewValidate();"><%= UnderstoodDotOrg.Common.DictionaryConstants.SubmitAnswerLabel %></button>
                </section>
           </asp:Panel>
            <!-- END PARTIAL: rate-this-app -->
        </div>
        <!-- end .col col-17 -->
        <div class="col col-6">
            <!-- BEGIN PARTIAL: rate-this-app-sidebar -->
            <section class="rate-this-app-sidebar">
                <header>
                    <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.RateThisAppLabel %></h2>
                </header>
                <p><%= UnderstoodDotOrg.Common.DictionaryConstants.ForLearningIssuesLabel %></p>
                <!-- BEGIN PARTIAL: results-slider-ratings -->
                <div class="results-slider zero blue blue-one ">
                    <span class="visuallyhidden">quality rating</span>
                    <button class="slider-button">1</button>
                    <button class="slider-button">2</button>
                    <button class="slider-button">3</button>
                    <button class="slider-button">4</button>
                    <button class="slider-button">5</button>
                </div>
                <script>
                    $(function(){
                        if(<%= (!IsUserLoggedIn).ToString().ToLower() %>)
                        {
                            setTimeout(function(){
                                $('.results-slider').off('click');
                            }, 2000);
                        }
                    })
                </script>
                <!-- END PARTIAL: results-slider-ratings -->
            </section>
            <!-- END PARTIAL: rate-this-app-sidebar -->
        </div>
        <!-- end .col.col-7 -->
    </div>
    <!-- end .row -->
</div>
<style>
    span.validationerror {
        color: #de5a02 !important;
        font-family: Arial, sans-serif !important;
        font-size: 14px !important;
        font-size: 0.875rem !important;
    }
</style>
