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
                                                <input id="issueInput" class="input-checkbox-class" runat="server" onclick="CheckIssues($(this));" type="checkbox" name=""></span>
                                            <label id="lblCheckbox" runat="server" for=""></label>

                                            <asp:HiddenField ID="hdnKeyValuePair" runat="server" ClientIDMode="Static" />
                                            <asp:HiddenField ID="hdnChecked" runat="server" ClientIDMode="Static" />
                                        </li>
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
                                RepeatLayout="unorderedlist" RepeatDirection="vertical">
                            </asp:DropDownList>

                            <nav>
                                <asp:Repeater ID="rptGrades" runat="server" OnItemDataBound="rptGrades_ItemDataBound">
                                    <ItemTemplate>
                                        <button id="gradeBtn" runat="server" class="grade" onclick="CheckGrades($(this));"></button>
                                    </ItemTemplate>
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
                        <asp:HiddenField ID="hdnGetAllCheckedIssues" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnGetAllCheckedGrades" runat="server" ClientIDMode="Static" />
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

<script type="text/javascript" >
    //$(window).load(function () {
    //    // home page recommendation select or checked controls on page load or radio button and button click.
    //    $('.container-guide-me-overlay .select-behavior ul li').each(function () {
    //        if ($(this).find('#hdnChecked').val() == 'true') {
    //            $(this).find('span').addClass('checked');
    //        }
    //    });

    //    checkIssuesGrades();
    //});

    //var $getCheckedIds;
    //function GetAllCheckedInput() {

    //    $getCheckedIds = '';
    //    $('.container-guide-me-overlay .select-behavior ul li').each(function () {
    //        if ($(this).find('div.checker span').hasClass('checked')) {
    //            if ($getCheckedIds != null && $getCheckedIds != '') {
    //                $getCheckedIds += "," + $(this).find('.input-checkbox-class').attr("data-value");
    //            }
    //            else {
    //                $getCheckedIds = $(this).find('.input-checkbox-class').attr("data-value");
    //            }
    //            $('#hdnGetAllCheckedIssues').val($getCheckedIds);
    //        }
    //    });

    //    $('.container-guide-me-overlay .select-grade nav button').each(function () {
    //        if ($(this).hasClass('active')) {
    //            $('#hdnGetAllCheckedGrades').val($(this).attr("data-value"));
    //            return false;
    //        }
    //    });

    //    var $deviceCheck = ((/android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini/i.test(navigator.userAgent.toLowerCase())));

    //    if ($deviceCheck) {
    //        $('#hdnGetAllCheckedGrades').val($('.container-guide-me-overlay .guideme-grade-mobile option:selected').val());
    //    }

    //}

    //function CheckIssues($this) {
    //    //alert($this.attr("checked"));
    //    if ($this.attr('checked') == "checked") {
    //        $this.removeAttr('checked');
    //    }
    //    else {
    //        $this.attr('checked', 'checked');
    //    }
    //    checkSelection();
    //}

    //function CheckGrades($this) {
    //    if ($this.attr('checked') == "checked") {
    //        $this.removeAttr('checked');
    //    }
    //    else {
    //        $this.attr('checked', 'checked');
    //    }
    //    checkSelection();
    //}

    //function checkSelection() {
    //    var $checkIssue = "false";
    //    var $checkGrade = "false";
    //    $('.container-guide-me-overlay .select-behavior ul li').each(function () {
    //        if ($(this).find('input.input-checkbox-class').attr('checked') == "checked") {
    //            $checkIssue = "true";
    //            return false;
    //        }
    //        return;
    //    });

    //    $('.container-guide-me-overlay .select-grade nav button').each(function () {
    //        if ($(this).attr('checked') == "checked") {
    //            $checkGrade = "true";
    //            return false;
    //        }
    //        return;
    //    });

    //    if ($checkIssue == "true" && $checkGrade == "true") {
    //        $("input.button-guide-me-recommendations").removeAttr('disabled');
    //    }
    //    else {
    //        $("input.button-guide-me-recommendations").attr('disabled', 'disabled');
    //    }
    //}

</script>