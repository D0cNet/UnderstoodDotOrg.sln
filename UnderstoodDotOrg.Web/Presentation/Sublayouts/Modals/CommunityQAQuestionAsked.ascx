<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommunityQAQuestionAsked.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Modals.CommunityQAQuestionAsked" %>
<div class="submit-question-modal modal fade">
    <div class="modal-dialog">
        <div class="modal-content">

            <div class="modal-header">
                <div class="modal-close close"><i class="icon-close"></i><span><asp:Literal ID="litClose" runat="server" /></span></div>


            </div>

            <div class="modal-body">
                <!-- BEGIN PARTIAL: community/qa_already_asked_question -->
                <div id="divAlreadyAsked" class="community-ask-question already-asked rs_read_this" runat="server">
                    <p class="already-asked-header"><sc:Text Field="Already Asked" runat="server" /></p>

                    <ul class="similar-answers">
        <asp:Repeater ID="questionsRepeater" ItemType="UnderstoodDotOrg.Services.Models.Telligent.Question" runat="server" OnItemDataBound="questionsRepeater_ItemDataBound">
            <ItemTemplate>
                        <!-- BEGIN PARTIAL: community/question-asked -->
                        <li class="already-asked-question clearfix repeater-item-qa">
                            <div class="question-number"><em><%# Container.ItemIndex + 1 %></em></div>

                            <div class="question-detail">
                                <p>
                                    <a href="<%# Item.Url %>"><%# Item.Title %></a>
                                </p>

                                <div class="question-data">
                                    <div class="question-stats">
                                        <span class="group-label">In <%# Item.Group %></span>
                                        <span class="user">Asked by <asp:HyperLink ID="hypUserProfileLink" CssClass="author" runat="server"><%# Item.Author %></asp:HyperLink></span>
                                        <span class="date-time"> <%# Item.PublishedDate %></span>
                                    </div>

                                    <p class="replies"><%# Item.CommentCount %> <span class="label"><%= UnderstoodDotOrg.Common.DictionaryConstants.RepliesLabel%></span></p>
                                </div>
                            </div>

                            <div class="question-replies">
                                <%# Item.CommentCount %>
        <span class="label"><%= UnderstoodDotOrg.Common.DictionaryConstants.RepliesLabel%></span>
                            </div>
                        </li>
                        <!-- END PARTIAL: community/question-asked -->

            </ItemTemplate>
        </asp:Repeater>

                    </ul>



                    <!-- Show More -->
                    <!-- BEGIN PARTIAL: community/show_more -->
                    <!--Show More-->
                    <div class="container show-more rs_skip" id="divShowMore" runat="server">
                        <div class="row">
                            <div class="col col-24">
                                <a class="show-more-link-qa" href="#" data-path="community/similar-answers" data-container="similar-answers" data-item="already-asked-question" data-count="3"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeMoreLabel %><i class="icon-arrow-down-blue"></i></a>
                            </div>
                        </div>
                    </div>
                    <!-- .show-more -->
                    <!-- END PARTIAL: community/show_more -->
                    <!-- .show-more -->

                    <a class="button continue rs_skip rs_preserve" href="REPLACE">
                        <span><sc:Text Field="Still Need Help" runat="server" /></span>
                        <span><sc:Text Field="Submit Your Question" runat="server" /></span>
                    </a>
                </div>
                <!-- END PARTIAL: community/qa_already_asked_question -->
                <!-- BEGIN PARTIAL: community/qa_submit_question -->
                <form id="Form1" runat="server">
                <div id="divCommunityAsk" class="community-ask-question submit-question" runat="server">  
                    <h1><sc:Text Field="Submit Your Question" runat="server" /></h1>
                    <h4 class="subhead"><sc:Text Field="Ask Your Question" runat="server" /></h4>
                    <asp:TextBox ID="EnterQuestionTextBox" class="question" minlength="100" MaxLength="1000" aria-required="required" required="required" placeholder="Enter your question..." runat="server" />

                    <h4 class="subhead"><sc:Text Field="Question Title" runat="server" /></h4>
                    <p><sc:Text Field="Question Title Description" runat="server" /></p>

                    <asp:TextBox ID="QuestionTitleTextBox" class="question-title" minlength="100" MaxLength="100" aria-required="required" required="required" placeholder="Enter your question's title..." runat="server" />
                    <p class="legend"><sc:Text Field="Question Title Length" runat="server" /></p>

                    <fieldset class="related-issues">
                        <h4><sc:Text Field="Related Issues Title" runat="server" />:</h4>

                        <div class="checkboxes">
                            <asp:ListView ID="uxIssues" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child.ChildIssueItem" OnItemDataBound="uxIssues_ItemDataBound">
                                <ItemTemplate>
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="uxIssueCheckbox" runat="server" />
                                            <label for="issues-reading" class="label-checkbox"><%# Item.IssueName %></label>
                                            <asp:HiddenField ID="uxIssueHidden" runat="server" />

                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>

                        </div>

                    </fieldset>

                    <fieldset>
                        <label class="selector-label" for="grade-selection"><asp:Literal ID="litChildsGradeText" runat="server" />:</label>
                        <asp:DropDownList name="grade-selection"  AppendDataBoundItems="true" DataTextField="Name" DataValueField="Id" ID="ddlGrades" aria-required="true" runat="server">                       
                        </asp:DropDownList>

                        <label class="selector-label" for="question-topic"><asp:Literal ID="litQuestionText" runat="server" />:</label>
                      <asp:DropDownList name="question-topic"  AppendDataBoundItems="true" DataTextField="Name" DataValueField="Id" ID="ddlTopics" aria-required="true" runat="server">                       
                      </asp:DropDownList>

                    </fieldset>

                    <div class="button-group">
                        <a href="REPLACE" class="button gray close desktop"><asp:Literal ID="litCancel" runat="server" /></a>
                        <button onserverclick="SubmitQuestionButton_Click" class="button" runat="server"><sc:Text Field="Submit Your Question" runat="server" /></button>
                        <a href="REPLACE" class="button gray close mobile"><asp:Literal ID="litCancel2" runat="server" /></a>
                    </div>
                </div>   
                 </form>
                <!-- END PARTIAL: community/qa_submit_question -->
            </div>

        </div>
        <!-- .modal-content -->
    </div>    
<!-- .modal-dialog -->
</div>
<!-- modal -->

<script type="text/javascript">

    var qaShowCount = 3;
    $(document).ready(function () {
        for (var i = qaShowCount; i < $(".repeater-item-qa").length; i++) {
            $(".repeater-item-qa").eq(i).hide();
        }
    });
    $(".show-more-link-qa").click(function () {
        for (var i = qaShowCount; i < qaShowCount + 5; i++) {
            $(".repeater-item-qa").eq(i).show();
        }
        qaShowCount += 5;
        if ($(".repeater-item-qa").length <= qaShowCount) {
            $(".show-more-link-qa").hide();
        }
    })

</script>