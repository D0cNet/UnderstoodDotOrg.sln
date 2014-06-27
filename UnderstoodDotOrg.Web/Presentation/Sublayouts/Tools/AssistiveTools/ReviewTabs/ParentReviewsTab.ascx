<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParentReviewsTab.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.ReviewTabs.ParentReviewsTab" %>

<div id="tabs2-parent-reviews" class="panel-container">
    <div class="row ">
        <div class="col col-17">
            <div class="review-intro rs_read_this">
                <span class="visuallyhidden">review rating</span>
                <div class="review-rating">
                    <!-- BEGIN PARTIAL: results-slider -->
                    <div class="results-slider blue-four" aria-label="4">4</div>
                    <!-- END PARTIAL: results-slider -->
                    <h4>7 Reviews of this App</h4>
                    <p>For learning &amp; attention issues</p>
                </div>
                <!-- end review-rating -->
                <div class="review-rating-sort select-inverted-mobile">
                    <label for="parent-review-comment-sort">Sort By:</label>
                    <select name="comment-sort-option" class="comment-sort" id="parent-review-comment-sort">
                        <option value="">Date: Newest to Oldest</option>
                        <option>A-Z</option>
                        <option>Z-A</option>
                    </select>
                </div>
                <!-- end review-rating -->
            </div>
            <!-- end .review-intro -->
            <div class="parent-reviews">
                <asp:Repeater ID="rptReviews" runat="server" OnItemDataBound="rptReviews_ItemDataBound">
                    <HeaderTemplate>
                        <section class="parent-review rs_read_this what-you-need-to-know-rs-wrapper">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="review-section-title">
                            <div class="review-section grade">
                                Grade
                                <span class="review-grade four"><asp:Literal ID="litGrade" runat="server"></asp:Literal></span>
                            </div>
                            <div class="review-section quality">
                                Quality
                                <span class="visuallyhidden">rating</span>
                                <span>
                                    <asp:Literal ID="litRating" runat="server"></asp:Literal>
                                </span>
                            </div>
                            <div class="review-section date"><asp:Literal ID="litReviewDate" runat="server"></asp:Literal></div>
                        </div>
                    <p>
                        <strong>aperiam minima exercitationem sapiente omnis.</strong> Quod debitis quos molestiae quo nemo sed tempora deserunt at distinctio aut. illo voluptatem iure qui. sed porro iure voluptate et reprehenderit vel dolores quam maxime consequatur rerum
                    </p>
                    <asp:Repeater ID="rptSkills" runat="server" OnItemDataBound="rptSkills_ItemDataBound">
                        <HeaderTemplate>
                            <p>
                                <span>Good For</span>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <span>
                                <a class="link-separator" href="REPLACE">Reading</a>
                            </span>
                        </ItemTemplate>
                        <FooterTemplate>
                            </p>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div class="review-report">
                        <span class="write-review">
                            <i></i>
                            <a href="REPLACE">Write Your Own Review</a></span>
                        <span class="review-report">
                            <i></i>
                            <a href="REPLACE">Report</a></span>
                    </div>
                    <!-- end review-report -->
                    </ItemTemplate>
                    <FooterTemplate>
                        </section>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <style>
                .what-you-need-to-know-tabs #tabs2-parent-reviews section .review-section.date{
                    margin-left: 70px;
                }
            </style>
            <!-- .parent-reviews -->
            <!-- Show More -->
            <div class="show-more">
                <a href="#" class="show-more-link" data-path="assistive-tech/reviews" data-container="parent-reviews" data-item="parent-review" data-count="6">More Results<i class="icon-arrow-down-blue"></i></a>
            </div>
            <!-- .show-more -->
            <!-- BEGIN PARTIAL: rate-this-app -->
            <section class="rate-this-app">
                <header>
                    <h2>Rate this App</h2>
                </header>
                <p>For learning & attention issues</p>
                <div class="is-it-any-good">
                    <h3>Is it any good ?</h3>
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
                    <h3>For kids</h3>
                    <label for="rate-for-kids">
                        <asp:DropDownList ID="ddlGrades" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator3"
                            controltovalidate="ddlGrades"
                            validationgroup="vlgReviewInputs"
                            runat="server">
                        </asp:RequiredFieldValidator>
                    </label>
                </div>
                <div class="i-think-it-is">
                    <h3>I think it is</h3>
                    <label for="rate-i-think">
                        <asp:DropDownList ID="ddlIThinkItIs" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator4"
                            controltovalidate="ddlIThinkItIs"
                            validationgroup="vlgReviewInputs"
                            runat="server">
                        </asp:RequiredFieldValidator>
                    </label>
                </div>
                <div class="it-is-good-for">
                    <fieldset>
                        <legend>It is good for</legend>
                        <asp:Repeater ID="rptSkillsChecklist" runat="server" OnItemDataBound="rptSkillsChecklist_ItemDataBound">
                            <HeaderTemplate>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <span class="checkbox-wrap">
                                        <input id="inputSkill" runat="server" type="checkbox" name="rate-goodfor-reading" aria-required="true"></span>
                                    <label for="rate-goodfor-reading"><asp:Literal ID="litSkill" runat="server"></asp:Literal></label>
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
                        <span>Tell other families what you think</span>
                        <asp:TextBox ID="txbWhatYouThink" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator2"
                            controltovalidate="txbWhatYouThink"
                            validationgroup="vlgReviewInputs"
                            runat="server">
                        </asp:RequiredFieldValidator>
                    </label>
                </div>
                <div class="give-your-review">
                    <label>
                        <span>Give your review a title</span>
                        <asp:TextBox ID="txbReviewTitle" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator1"
                            controltovalidate="txbReviewTitle"
                            validationgroup="vlgReviewInputs"
                            runat="server">
                        </asp:RequiredFieldValidator>
                    </label>
                </div>
                <asp:HiddenField ID="hfKeyValuePairs" runat="server" />
                <asp:HiddenField ID="hfRating" runat="server" />
                <script>
                    $(function () {
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

                            if($this.hasClass("blue-one"))
                                hiddenField2.val(1);
                            else if ($this.hasClass("blue-two"))
                                hiddenField2.val(2);
                            else if ($this.hasClass("blue-three"))
                                hiddenField2.val(3);
                            else if ($this.hasClass("blue-four"))
                                hiddenField2.val(4);
                            else 
                                hiddenField2.val(5);
                        })
                    })
                </script>
                <button ID="btnSubmit" class="review-submit" runat="server" type="button" onserverclick="btnSubmit_Click">Submit</button>
            </section>
            <!-- END PARTIAL: rate-this-app -->
        </div>
        <!-- end .col col-17 -->
        <div class="col col-6">
            <!-- BEGIN PARTIAL: rate-this-app-sidebar -->
            <section class="rate-this-app-sidebar">
                <header>
                    <h2>Rate This App</h2>
                </header>
                <p>For learning & attention issues</p>
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
            </section>
            <!-- END PARTIAL: rate-this-app-sidebar -->
        </div>
        <!-- end .col.col-7 -->
    </div>
    <!-- end .row -->
</div>
