﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Checklist Article Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Checklist_Article_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: article-intro-text -->
            <div class="article-intro-text">
                <p>
                    <%--This would be the intro text to the slideshow. It should run about 35 words. Lorem ipsum dolor sit amet, consectetur adipiscing elit vestibulum convallis risus id felis.--%>
                    <sc:fieldrenderer id="frSummary" runat="server" fieldname="Intro Text" />
                </p>
            </div>
            <!-- END PARTIAL: article-intro-text -->
            <!-- BEGIN PARTIAL: article-checklist -->
            <div class="article-checklist">
                <div class="checklist-form">
                    <div class="checklist-questions">


                        <asp:Repeater ID="rptHeaderChkbox" runat="server" OnItemDataBound="rptHeaderChkbox_ItemDataBound">
                            <ItemTemplate>
                                <div class="checklist-question-wrapper">
                                    <fieldset>
                                        <%--<div class="checklist-question">--%>
                                        <legend class="checklist-question">
                                            <sc:fieldrenderer id="frHeaderItem" runat="server" fieldname="Title" />
                                        </legend>
                                        <%--<asp:CheckBox ID="cbHeaderItem" runat="server"></asp:CheckBox>
                                        <sc:FieldRenderer ID="frHeaderItem" runat="server" FieldName="Title" />
                                    </div>--%>
                                        <div class="checkboxes-wrapper">
                                            <asp:Repeater ID="rptTopicChkbox" runat="server" OnItemDataBound="rptTopicChkbox_ItemDataBound">
                                                <ItemTemplate>
                                                    <div class="checkbox-wrapper">
                                                        <asp:Label ID="lblTopicItem" runat="server" AssociatedControlID="cbTopicItem">
                                                            <asp:CheckBox CssClass="checkbox-item" ID="cbTopicItem" runat="server"></asp:CheckBox>
                                                            <span>
                                                                <sc:fieldrenderer runat="server" id="frTopicItem" fieldname="Topic Title" />
                                                            </span>
                                                        </asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </fieldset>
                                </div>
                                <!-- .checkboxes-wrapper -->
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <!-- .checklist-question -->

                    <asp:HiddenField ID="hfKeyValuePairs" runat="server" />
                    <script>
                        $(function () {
                            var Answers = {};
                            var hiddenField = $("[id*='hfKeyValuePairs']");

                            $(".checkbox-item, .checklist-question").click(function () {
                                parseBoxes(true);
                            })

                            function parseBoxes(changed) {
                                $(".checklist-questions .checkbox-item").each(function () {
                                    $this = $(this);
                                    Answers[$this.data("id")] = $this.find("input").prop('checked');
                                })

                                if (changed)
                                {
                                    $("input[id*='btnSaveAnswers']").attr("class", "submit button").removeAttr("disabled");
                                }

                                hiddenField.val(JSON.stringify(Answers));
                            }

                            parseBoxes(false);
                        })
                    </script>
                    <div class="checklist-actions clearfix">
                        <p id="confirmationText" runat="server" class="confirmation" visible="false"><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_AnswersSavedText %></p>
                        <p id="errorText" runat="server" visible="false"><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_SomethingWentWrongText %></p>
                        <div class="save-answers">
                            <asp:button runat="server" ID="btnSaveAnswers" class="submit button" OnClick="btnSaveAnswers_Click" />
                        </div>
                        <div class="download-pdf">
                            <div class="download button gray"><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_DownloadasPDFButtonText %></div>
                        </div>
                    </div>
                    <script>
                        // Render the screenshot image
                        $(function () {

                            var clicked = false;
                            var $downloadingModal = $("#checklist-article-downloading-modal");
                            $(".download-pdf>div.download").on("click", function (e) {
                                if (!clicked)
                                {
                                    var doc = new jsPDF();
                                    doc.addHTML(
                                        $("#form1"),                                        
                                        0,
                                        0,
                                        { 'pagesplit': true },
                                        function () {
                                            doc.save('article-download.pdf');
                                            $downloadingModal.modal("hide");
                                        });
                                }
                            })
                        })
                    </script>
                    <!-- .checklist-questions -->
                </div>
                <!-- .checklist-form -->
            </div>
            <div class="article-copy">
                <p>
                    <sc:FieldRenderer ID="frOutro" runat="server" FieldName="Outro Text" />
                </p>
            </div>
            <!-- .article-checklist -->

            <div class="rs_about_author rs_read_this">
                <!-- BEGIN PARTIAL: about-author -->
                <sc:sublayout id="sbAboutAuthor" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/AboutAuthor.ascx" />
                <!-- END PARTIAL: about-author -->

                <!-- BEGIN PARTIAL: reviewed-by -->
                <sc:sublayout id="SBReviewedBy" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" />
                <!-- END PARTIAL: reviewed-by -->
            </div>

        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1 skiplink-sidebar rs_read_this">

            <sc:sublayout id="Sublayout1" path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCountsSideColumn.ascx" runat="server"></sc:sublayout>

            <!-- BEGIN PARTIAL: find-helpful -->
            <sc:sublayout path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" runat="server"></sc:sublayout>
            <!-- END PARTIAL: find-helpful -->
            <!-- BEGIN PARTIAL: keep-reading -->

            <sc:sublayout id="slKeepReading" runat="server" path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
            <!-- END PARTIAL: keep-reading -->
            <!-- BEGIN PARTIAL: comments-summary -->

                <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/CommentsSummary.ascx" />

            <!-- END PARTIAL: comments-summary -->
            <!-- BEGIN PARTIAL: sidebar-promos -->
            <div class="sidebar-promos rs_read_this vertical">
                <sc:sublayout id="sbSidebarPromo" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/PromotionalsList.ascx" />
            </div>

            <!-- end sidebar-promos -->

            <!-- END PARTIAL: sidebar-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
