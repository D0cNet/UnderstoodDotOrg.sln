<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommunityQAQuestionAsked.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Modals.CommunityQAQuestionAsked" %>
<div class="submit-question-modal modal fade">
    <div class="modal-dialog">
        <div class="modal-content">

            <div class="modal-header">
                <div class="modal-close close"><i class="icon-close"></i><span><asp:Literal ID="litClose" runat="server" /></span></div>


            </div>

            <div class="modal-body">
                <!-- BEGIN PARTIAL: community/qa_already_asked_question -->
                <div class="community-ask-question already-asked">
                    <p class="already-asked-header"><sc:Text Field="Already Asked" runat="server" /></p>

                    <ul class="similar-answers">
                        <!-- BEGIN PARTIAL: community/question-asked -->
                        <li>
                            <div class="question-number"><em>1</em></div>

                            <div class="question-detail">
                                <p>
                                    <a href="REPLACE">Ex voluptatem ratione quibusdam quo inventore praesentium est eveniet porro?</a>
                                </p>

                                <div class="question-data">
                                    <div class="question-stats">
                                        <span class="group-label">In Reading Issues</span>
                                        <span class="user">Asked by Voluptas</span>
                                        <span class="date-time">1 hour ago</span>
                                    </div>

                                    <p class="replies">1 <span class="label">replies</span></p>
                                </div>
                            </div>

                            <div class="question-replies">
                                1
        <span class="label">replies</span>
                            </div>
                        </li>
                        <!-- END PARTIAL: community/question-asked -->
                        <!-- BEGIN PARTIAL: community/question-asked -->
                        <li>
                            <div class="question-number"><em>2</em></div>

                            <div class="question-detail">
                                <p>
                                    <a href="REPLACE">Rerum omnis doloribus quis veniam sint culpa animi laboriosam expedita temporibus porro doloremque?</a>
                                </p>

                                <div class="question-data">
                                    <div class="question-stats">
                                        <span class="group-label">In Reading Issues</span>
                                        <span class="user">Asked by Rem</span>
                                        <span class="date-time">1 hour ago</span>
                                    </div>

                                    <p class="replies">8 <span class="label">replies</span></p>
                                </div>
                            </div>

                            <div class="question-replies">
                                8
        <span class="label">replies</span>
                            </div>
                        </li>
                        <!-- END PARTIAL: community/question-asked -->
                        <!-- BEGIN PARTIAL: community/question-asked -->
                        <li>
                            <div class="question-number"><em>3</em></div>

                            <div class="question-detail">
                                <p>
                                    <a href="REPLACE">Enim natus qui earum quam sapiente molestias nisi est sit est possimus?</a>
                                </p>

                                <div class="question-data">
                                    <div class="question-stats">
                                        <span class="group-label">In Reading Issues</span>
                                        <span class="user">Asked by Doloribus</span>
                                        <span class="date-time">1 hour ago</span>
                                    </div>

                                    <p class="replies">5 <span class="label">replies</span></p>
                                </div>
                            </div>

                            <div class="question-replies">
                                5
        <span class="label">replies</span>
                            </div>
                        </li>
                        <!-- END PARTIAL: community/question-asked -->
                    </ul>



                    <!-- Show More -->
                    <!-- BEGIN PARTIAL: community/show_more -->
                    <!--Show More-->
                    <div class="container show-more rs_skip">
                        <div class="row">
                            <div class="col col-24">
                                <a class="show-more-link " href="#" data-path="community/questions-asked" data-container="similar-answers" data-item="question-number" data-count="3">Show More<i class="icon-arrow-down-blue"></i></a>
                            </div>
                        </div>
                    </div>
                    <!-- .show-more -->
                    <!-- END PARTIAL: community/show_more -->
                    <!-- .show-more -->

                    <a class="button continue" href="REPLACE">
                        <span><sc:Text Field="Already Asked" runat="server" /></span>
                        <span><sc:Text Field="Still Need Help" runat="server" /></span>
                    </a>
                </div>
                <!-- END PARTIAL: community/qa_already_asked_question -->
                <!-- BEGIN PARTIAL: community/qa_submit_question -->
                <form id="Form1" runat="server">
                <div class="community-ask-question submit-question">  
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
