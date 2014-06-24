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
                    <h3><asp:Literal Text="" ID="litStruggle2" runat="server" /></h3>
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
                                <h4 class="mobile"><asp:Literal Text="" ID="litStruggle3" runat="server" /></h4>
                                <legend class="desktop"><asp:Literal Text="" ID="litSelectAll" runat="server" /></legend>

                                <asp:Repeater ID="rptChildIssues" runat="server" OnItemDataBound="rptChildIssues_ItemDataBound">
                                    <HeaderTemplate>
                                        <ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <span class="checkbox-wrap">
                                                <asp:CheckBox ID="cbIssue" runat="server" CssClass="input-checkbox-class" />
                                            </span>
                                            <asp:Label ID="lblIssue" runat="server" AssociatedControlID="cbIssue" />

                                            <asp:HiddenField ID="hfIssue" runat="server" />
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

                            <h4><asp:Literal Text="" ID="litChildEnrolled2" runat="server" /></h4>

                            <label for="guideme-grade" class="visuallyhidden"><asp:Literal Text="" ID="litChildEnrolled" runat="server" /></label>
                            <asp:DropDownList ID="ddlGradeGroups" runat="server" CssClass="guideme-grade-mobile"/>

                            <nav>
                                <asp:Repeater ID="rptGrades" runat="server" OnItemDataBound="rptGrades_ItemDataBound">
                                    <ItemTemplate>
                                        <button id="gradeBtn" runat="server" class="grade"></button>
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
                        <asp:Button ID="btnSubmit" runat="server" CssClass="button submit-button button-guide-me-recommendations" OnClick="btnSubmit_OnClick" />
                        <asp:HiddenField ID="hfGradeChoice" runat="server" ClientIDMode="Static" />
                    </div>

                </div>
                <!-- .col -->
                <div class="col col-6">

                    <div class="complete-profile">
                        <a href="<%= CompleteMyProfileUrl %>"><asp:Literal Text="" ID="litComplete1" runat="server" /></a>
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
                    <i class="icon"></i>
                    <asp:Literal Text="" ID="litHelpmsg" runat="server" />
                </div>
                <!-- .col -->
                <div class="col col-12">
                    <button type="button" class="button button-guide-me">
                        <asp:Literal Text="" ID="litStruggle" runat="server" /> </button>
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
