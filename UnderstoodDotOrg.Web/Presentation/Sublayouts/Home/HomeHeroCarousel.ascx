<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeHeroCarousel.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Home.HomeHeroCarousel" %>
<!-- BEGIN MODULE: Hero Carousel -->
<div class="container hero-carousel">
    <div class="row">
        <div class="col col-24">
            <div class="hero-carousel-inner">
                <!-- BEGIN PARTIAL: hero-carousel -->
                <button id="carousel-keyboard-trigger" class="carousel-keyboard-trigger">
                </button>
                <ol class="carousel-pagers">
                    <li class="rsArrow rsArrowLeft">
                        <button class="rsArrowIcn">
                        </button>
                    </li>
                    <li class="rsArrow rsArrowRight">
                        <button class="rsArrowIcn">
                        </button>
                    </li>
                </ol>
                <ol class="carousel-navigation">
                </ol>
                <button class="play-pause pause">
                    Pause</button>
                <div id="hero-carousel-wrapper" class="rsDefault" data-random="false">
                    <asp:Repeater runat="server" ID="rptHomeSlider" OnItemDataBound="rptHomeSlider_ItemDataBound">
                        <ItemTemplate>
                            <asp:Panel runat="server" ID="pnlSliderImage" CssClass="slide">
                                <asp:Panel runat="server" ID="pnlSliderText" class="text">
                                    <sc:fieldrenderer id="frSliderText" runat="server" fieldname="Text" />
                                    <%--<p>
                                        Empowered parent, confident  child.
                                    </p>
                                    <p>
                                        It isn't easy&hellip;
                                    </p>--%>
                                </asp:Panel>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%-- <!-- .slide -->
                    <div class="slide" style="background-image: url(Presentation/includes/images/temp.bg.slide.1200.02.jpg)">
                        <div class="text text-color-white">
                            <p>
                                You can make a difference.
                            </p>
                        </div>
                    </div>
                    <!-- .slide -->
                    <div class="slide" style="background-image: url(Presentation/includes/images/temp.bg.slide.1200.03.jpg)">
                        <div class="text text-color-purple">
                            <p>
                                Step 1:<br>
                                Understand your child's struggles.
                            </p>
                        </div>
                    </div>--%>
                    <!-- .slide -->
                </div>
                <!-- #hero-carousel-wrapper -->
                <!-- END PARTIAL: hero-carousel -->
            </div>
            <!-- .hero-carousel-inner -->
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
    <!-- BEGIN PARTIAL: guide-me-overlay -->
    <section class="container-guide-me-overlay">
        <asp:Panel runat="server" DefaultButton="btnSubmit" CssClass="form">

            <input type="hidden" name="guideme-grade" id="guideme-grade-desktop" value="">

            <header class="row">
                <div class="col col-16 offset-4">
                    <h3>My child struggles with...</h3>
                </div>
                <!-- .col -->
                <div class="col col-4">
                    <a class="close-guide">Close</a>
                </div>
                <!-- .col -->
            </header>
            <!-- .row -->


            <fieldset>
                <div class="row">
                    <div class="col col-10 offset-2">

                        <article class="module select-behavior">
                            <fieldset>
                                <h4 class="mobile">My child struggles with...</h4>
                                <legend class="desktop">Select all that apply:</legend>

                                <asp:Repeater ID="rptChildIssues" runat="server" OnItemDataBound="rptChildIssues_ItemDataBound">
                                    <HeaderTemplate>
                                        <ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <span class="checkbox-wrap">
                                                <input id="issueInput" class="input-checkbox-class" runat="server" type="checkbox" name=""></span>
                                            <label id="lblCheckbox" runat="server" for=""></label>

                                            <asp:HiddenField ID="hdnKeyValuePair" runat="server" ClientIDMode="Static" />
                                            <asp:HiddenField ID="hdnChecked" runat="server" ClientIDMode="Static" />
                                        </li>
                                        <%-- <li>
                                            <span class="checkbox-wrap">
                                                <input type="checkbox" name="guideme-issue-writing" id="guideme-issue-writing"></span>
                                            <label for="guideme-issue-writing">Writing</label>
                                        </li>
                                        <li>
                                            <span class="checkbox-wrap">
                                                <input type="checkbox" name="guideme-issue-math" id="guideme-issue-math"></span>
                                            <label for="guideme-issue-math">Math</label>
                                        </li>
                                        <li>
                                            <span class="checkbox-wrap">
                                                <input type="checkbox" name="guideme-issue-listening" id="guideme-issue-listening"></span>
                                            <label for="guideme-issue-listening">Listening comprehension</label>
                                        </li>
                                        <li>
                                            <span class="checkbox-wrap">
                                                <input type="checkbox" name="guideme-issue-spoken-languages" id="guideme-issue-spoken-languages"></span>
                                            <label for="guideme-issue-spoken-languages">Spoken Language</label>
                                        </li>
                                        <li>
                                            <span class="checkbox-wrap">
                                                <input type="checkbox" name="guideme-issue-executive-function" id="guideme-issue-executive-function"></span>
                                            <label for="guideme-issue-executive-function">Executive function (organization, planning, flexible thinking)</label>
                                        </li>
                                        <li>
                                            <span class="checkbox-wrap">
                                                <input type="checkbox" name="guideme-issue-hyperactivity" id="guideme-issue-hyperactivity"></span>
                                            <label for="guideme-issue-hyperactivity">Hyperactivity or impulsiveity</label>
                                        </li>
                                        <li>
                                            <span class="checkbox-wrap">
                                                <input type="checkbox" name="guideme-issue-attention" id="guideme-issue-attention"></span>
                                            <label for="guideme-issue-attention">Attention or staying focused</label>
                                        </li>
                                        <li>
                                            <span class="checkbox-wrap">
                                                <input type="checkbox" name="guideme-issue-social-skills" id="guideme-issue-social-skills"></span>
                                            <label for="guideme-issue-social-skills">Social skills</label>
                                        </li>
                                        <li>
                                            <span class="checkbox-wrap">
                                                <input type="checkbox" name="guideme-issue-motor-skills" id="guideme-issue-motor-skills"></span>
                                            <label for="guideme-issue-motor-skills">Motor skills</label>
                                        </li>--%>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </fieldset>
                        </article>
                        <!-- article.select-behavior -->

                    </div>
                    <!-- .col -->
                    <div class="col col-12">

                        <article class="module select-grade">

                            <h4>My child is enrolled in:</h4>

                            <label for="guideme-grade" class="visuallyhidden">My child is enrolled in:</label>
                            <asp:DropDownList ID="ddlGradeGroups" runat="server" CssClass="guideme-grade-mobile"
                                RepeatLayout="unorderedlist" RepeatDirection="vertical" required="required" aria-required="true">
                            </asp:DropDownList>
                            <%--<select name="guideme-grade" id="guideme-grade" class="guideme-grade-mobile" aria-required="true">
                                <option value="">Select grade</option>
                                <option value="grade-preschool">Toddler Preschool</option>
                                <option value="grade-kindergarten">Kindergarten</option>
                                <option value="grade-grade1">Grade 1</option>
                                <option value="grade-grade2">Grade 2</option>
                                <option value="grade-grade3">Grade 3</option>
                                <option value="grade-grade4">Grade 4</option>
                                <option value="grade-grade5">Grade 5</option>
                                <option value="grade-grade6">Grade 6</option>
                                <option value="grade-grade7">Grade 7</option>
                                <option value="grade-grade8">Grade 8</option>
                                <option value="grade-grade9">Grade 9</option>
                                <option value="grade-grade10">Grade 10</option>
                                <option value="grade-grade11">Grade 11</option>
                                <option value="grade-grade12">Grade 12</option>
                                <option value="grade-after-highschool">After Highschool</option>
                            </select>--%>

                            <nav>
                                <asp:Repeater ID="rptGrades" runat="server" OnItemDataBound="rptGrades_ItemDataBound">
                                    <ItemTemplate>
                                        <button id="gradeBtn" runat="server" onclick="" class="grade"></button>
                                    </ItemTemplate>
                                    <%--<button class="grade" id="grade-preschool">Toddler Preschool</button>
                                    <button class="grade" id="grade-kindergarten">Kindergarten</button>
                                    <button class="grade" id="grade-grade1">Grade 1</button>
                                    <button class="grade" id="grade-grade2">Grade 2</button>
                                    <button class="grade" id="grade-grade3">Grade 3</button>
                                    <button class="grade" id="grade-grade4">Grade 4</button>
                                    <button class="grade" id="grade-grade5">Grade 5</button>
                                    <button class="grade" id="grade-grade6">Grade 6</button>
                                    <button class="grade" id="grade-grade7">Grade 7</button>
                                    <button class="grade" id="grade-grade8">Grade 8</button>
                                    <button class="grade" id="grade-grade9">Grade 9</button>
                                    <button class="grade" id="grade-grade10">Grade 10</button>
                                    <button class="grade" id="grade-grade11">Grade 11</button>
                                    <button class="grade" id="grade-grade12">Grade 12</button>
                                    <button class="grade" id="grade-after-highschool">After Highschool</button>--%>
                                </asp:Repeater>
                            </nav>

                        </article>
                        <!-- article.select-grade -->

                    </div>
                    <!-- .col -->
                </div>
                <!-- .row -->
            </fieldset>


            <footer class="row">
                <div class="col col-8 offset-8">

                    <div class="submit-button-wrap">
                        <asp:Button ID="btnSubmit" runat="server" Text="See my recommendations" CssClass="button submit-button button-guide-me-recommendations" OnClientClick="GetAllCheckedInput();" OnClick="btnSubmit_OnClick" />
                        <%--<input class="button submit-button button-guide-me-recommendations" type="submit" value="See my recommendations">--%>
                        <asp:HiddenField ID="hdnGetAllChecked" runat="server" ClientIDMode="Static" />
                    </div>

                </div>
                <!-- .col -->
                <div class="col col-6">

                    <div class="complete-profile">
                        <a href="REPLACE">Complete my profile for<br>
                            even better recommendations</a>
                    </div>

                </div>
                <!-- .col -->
            </footer>
            <!-- .row -->

        </asp:Panel>
        <!-- .form -->
    </section>
    <!-- .container-guide-me-overlay -->
    <!-- END PARTIAL: guide-me-overlay -->
</div>
<!-- .container -->
<!-- END MODULE: Hero Carousel -->
<!-- BEGIN MODULE: Guide Me -->
<div class="container guide-me">
    <div class="row">
        <div class="col col-20 centered">
            <div class="row guide-me-inner skiplink-toolbar">
                <div class="col col-12">
                    <i class="icon"></i>How can we help?
                </div>
                <!-- .col -->
                <div class="col col-12">
                    <button type="button" class="button button-guide-me">
                        My child struggles with...</button>
                </div>
                <!-- .col -->
            </div>
            <!-- .row.guide-me-inner -->
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>
<!-- .container.guide-me -->
<!-- END MODULE: Guide Me -->
<asp:HiddenField runat="server" ID="hfRandomizeSlider" ClientIDMode="Static" />

<script type="text/javascript">

    $(document).ready(function () {
        $('.container-guide-me-overlay .select-behavior ul li').each(function () {
            //alert('hiii');
            //alert($(this).find('#hdnChecked').val());
            if ($(this).find('#hdnKeyValuePair').val() != '' && $(this).find('#hdnChecked').val() == 'true') {
                $(this).find('.input-checkbox-class').parent('span').addClass('checked');
            }
        });
    });

    var $getCheckedIds;
    function GetAllCheckedInput() {
        $getCheckedIds = '';
        $('.container-guide-me-overlay .select-behavior ul li').each(function () {
            if ($(this).find('.input-checkbox-class').parent('span').hasClass('checked')) {
                if ($getCheckedIds != null && $getCheckedIds != '') {
                    $getCheckedIds += "," + $(this).find('.input-checkbox-class').attr("data-value");
                }
                else {
                    $getCheckedIds = $(this).find('.input-checkbox-class').attr("data-value");
                }
                $('#hdnGetAllChecked').val($getCheckedIds);
            }
        });
    }

</script>
