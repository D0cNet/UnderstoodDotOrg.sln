<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Checklist Article Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Checklist_Article_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: article-intro-text -->
            <div class="article-intro-text">
                <p>
                    <%--This would be the intro text to the slideshow. It should run about 35 words. Lorem ipsum dolor sit amet, consectetur adipiscing elit vestibulum convallis risus id felis.--%>
                    <sc:fieldrenderer id="frSummary" runat="server" fieldname="Body Content" />
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
                                                            <asp:CheckBox ID="cbTopicItem" runat="server"></asp:CheckBox>
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

                    <div class="checklist-actions clearfix">
                        <div class="save-answers">
                            <button class="submit button">Save My Answers</button>
                        </div>
                        <div class="download-pdf">
                            <button class="download button gray">Download as PDF</button>
                        </div>
                        <!--        <div class="button"><input class="checklist-form-save" type="submit" value="Save My Answers"></div>
        <div class="button"><input class="submit-button" type="submit" value="Download as PDF"></div> -->
                    </div>
                    <!-- .checklist-questions -->
                </div>
                <!-- .checklist-form -->
            </div>
            <!-- .article-checklist -->

            <!-- END PARTIAL: article-checklist -->
            <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:sublayout id="SBReviewedBy" runat="server" path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" visible="false" />

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
            <section class="comments-summary">
                <header>
                    <h3>Comments (19)</h3>
                </header>
                <div class="quote-container">
                    <blockquote>
                        <p>Neque quo aut aperiam officia atque error. praesentium nisi provident nihil eveniet perspiciatis consequuntur dicta odit. labore omnis distinctio possimus maxime autem ullam. iste fugiat reprehenderit modi delectus reiciendis eos deserunt expedita sed at cupiditate minima eligendi sed</p>
                        <i class="arrow-quote-bottom"></i>
                    </blockquote>
                    <span><strong>Carrie S</strong> &bull; 30 min ago</span>
                </div>

                <ul>
                    <li><a href="REPLACE">See All Comments</a></li>
                    <li><a href="REPLACE">Add My Comment</a></li>
                </ul>
            </section>
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
