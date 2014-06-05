<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepTwo.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepTwo" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>
                        <sc:Text Field="Header Title" ID="PageHeader1" runat="server" />
                    </h1>
                    <p class="subtitle">
                        <sc:Text Field="Header Text" ID="HeaderText1" runat="server" />
                    </p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header">
                            <sc:Text Field="Header Progress Bar Text" ID="BarText1" runat="server" />
                        </div>
                        <div class="progress-bar step-2">
                            <span class="step-1 step">1</span>
                            <span class="step-1-progress progress">
                                <span class="progress-spacer">
                                    <span class="progress-percent"></span>
                                </span>
                            </span>
                            <span class="step-2 step">2</span>
                            <span class="step-2-progress progress">
                                <span class="progress-spacer">
                                    <span class="progress-percent"></span>
                                </span>
                            </span>
                            <span class="step-3 step">3</span>
                            <span class="step-3-progress progress">
                                <span class="progress-spacer">
                                    <span class="progress-percent"></span>
                                </span>
                            </span>
                            <span class="done step">Done</span>
                        </div>
                    </div>
                    <!-- .progress-bar-wrapper -->

                    <!-- END PARTIAL: profile-questions-header-right -->
                </div>
            </header>
        </div>
    </div>
</div>

<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: profile-questions-step2 -->


            <div class="profile-questions step-2">
                <h2>
                    <%--<sc:text field="Form Title" runat="server" />--%>
                    <asp:Literal ID="uxFormTitle" runat="server"></asp:Literal>
                </h2>

                <asp:PlaceHolder ID="uxGenderAndGrade" runat="server" Visible="false">
                    <div class="question-wrapper clearfix">
                        <p class="question with-margin">
                            <sc:Text ID="Text4" Field="Child Struggling Question Title" runat="server" />
                        </p>
                        <div class="radio-toggle-wrapper">
                            <label class="button">
                                <%= BoyButton %>
                                <asp:RadioButton ID="uxBoy" runat="server" GroupName="q1a" />

                            </label>
                            <label class="button">
                                <%= GirlButton %>
                                <asp:RadioButton ID="uxGirl" runat="server" GroupName="q1a" />
                            </label>
                        </div>

                        <label class="inline">
                            <span class="question-spacer">
                                <sc:Text ID="Text7" Field="In Text" runat="server" />
                            </span>
                            <asp:DropDownList ID="uxSelectGrade" runat="server" name="q1b">
                            </asp:DropDownList>
                        </label>
                    </div>
                </asp:PlaceHolder>

                <div class="question-wrapper clearfix short-bottom trouble-question">
                    <h3 class="question-inline">
                        <sc:Text Field="Child Nickname Question Title" runat="server" />

                        <span class="question-description">
                            <sc:Text Field="Child Nickname Question Text" runat="server" />
                        </span>
                    </h3>
                    <asp:TextBox ID="ScreenNameTextBox" type="textfield" runat="server" />
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper evaluation-question">
                    <h3 class="question">
                        <%--<sc:text field="Trouble Areas Question Title" runat="server" />--%>
                        <asp:Literal runat="server" ID="uxTroubleAreasTitle"></asp:Literal>
                    </h3>
                    <div class="checkboxes-wrapper">
                        <asp:ListView ID="uxIssues" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child.ChildIssueItem" OnItemDataBound="uxIssues_ItemDataBound">
                            <ItemTemplate>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <asp:CheckBox ID="uxIssueCheckbox" runat="server" />
                                        <span>
                                            <%# Item.IssueName %>
                                        </span>
                                    </label>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <!-- .checkboxes-wrapper -->
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper evaluation-question">
                    <h3 class="question">
                        <%--<sc:text id="Text11" field="Formally Evaluated Question Title" runat="server" />--%>
                        <asp:Literal runat="server" ID="uxEvaluatedTitle"></asp:Literal>
                    </h3>
                    <div class="radio-toggle-wrapper">
                        <label class="button">
                            <%--<sc:text id="Text12" field="Yes Button" runat="server" />--%>
                            <%= YesButton %>
                            <%--<input name="q2" value="yes" class="radio-toggle" type="radio">--%>
                            <asp:RadioButton ID="q2a1" runat="server" GroupName="q2" CssClass="radio-toggle" />
                        </label>
                        <label class="button">
                            <%--<sc:text id="Text13" field="No Button" runat="server" />--%>
                            <%= NoButton %>
                            <%--<input name="q2" value="no" class="radio-toggle" type="radio">--%>
                            <asp:RadioButton ID="q2a2" runat="server" GroupName="q2" CssClass="radio-toggle" />
                        </label>
                        <label class="button">
                            <%--<sc:text id="Text14" field="In Progress Button" runat="server" />--%>
                            <%= InProgressText %>
                            <%--<input name="q2" value="progress" class="radio-toggle" type="radio">--%>
                            <asp:RadioButton ID="q2a3" runat="server" GroupName="q2" CssClass="radio-toggle" />
                        </label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <asp:Panel ID="uxFamilyCircumstances" runat="server" Visible="false">
                    <div class="question-wrapper family-question">
                        <h3 class="question">
                            <sc:Text ID="Text15" Field="Special Circumstances Question Title" runat="server" />
                        </h3>
                        <div class="checkboxes-wrapper">
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q3a1">
                                    <span>
                                        <sc:Text ID="Text16" Field="SC Area 1" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q3a2">
                                    <span>
                                        <sc:Text ID="Text17" Field="SC Area 2" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q3a3">
                                    <span>
                                        <sc:Text ID="Text18" Field="SC Area 3" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q3a4">
                                    <span>
                                        <sc:Text ID="Text19" Field="SC Area 4" runat="server" />
                                    </span>
                                </label>
                            </div>
                        </div>
                        <!-- .checkboxes-wrapper -->
                        <div class="question-description">
                            <span>*</span><sc:Text ID="Text20" Field="Special Circumstances Question SubText" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
                <!-- .question-wrapper -->

                <div class="form-actions">
                    <asp:Button ID="NextButton" CssClass="button" runat="server" OnClick="NextButton_Click" />
                    <!--<input class="button" type="submit" value="<sc:Text ID="Text21" Field="Next Button Text" runat="server" />">-->
                </div>
            </div>
            <!-- .profile-questions.step-2 -->

            <!-- END PARTIAL: profile-questions-step2 -->
        </div>
    </div>
</div>
