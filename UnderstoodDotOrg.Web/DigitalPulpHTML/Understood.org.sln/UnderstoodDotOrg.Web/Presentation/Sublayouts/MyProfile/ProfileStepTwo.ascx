<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepTwo.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepTwo" %>

<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>
                        <sc:text field="Header Title" id="PageHeader1" runat="server" />
                    </h1>
                    <p class="subtitle">
                        <sc:text field="Header Text" id="HeaderText1" runat="server" />
                    </p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header">
                            <sc:text field="Header Progress Bar Text" id="BarText1" runat="server" />
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

                <div class="question-wrapper clearfix short-bottom trouble-question">
                    <h3 class="question-inline">
                        <sc:text field="Child Nickname Question Title" runat="server" />

                        <span class="question-description">
                            <sc:text field="Child Nickname Question Text" runat="server" />
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
                        <div class="checkbox-wrapper">
                            <label>
                                <%--<input type="checkbox" name="q1a1">--%>
                                <asp:CheckBox ID="q1a1" runat="server" />
                                <span>
                                    <%--<sc:text id="Text1" field="TA Area 1" runat="server" />--%>
                                    <asp:Literal ID="uxQ1a1" runat="server"></asp:Literal>
                                </span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <%--<input type="checkbox" name="q1a2">
                                <span>
                                    <sc:text id="Text2" field="TA Area 2" runat="server" />
                                </span>--%>
                                <asp:CheckBox ID="q1a2" runat="server" />
                                <span>
                                    <asp:Literal ID="uxQ1a2" runat="server"></asp:Literal>
                                </span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <%--<input type="checkbox" name="q1a3">
                                <span>
                                    <sc:text id="Text3" field="TA Area 3" runat="server" />
                                </span>--%>
                                <asp:CheckBox ID="q1a3" runat="server" />
                                <span>
                                    <asp:Literal ID="uxQ1a3" runat="server"></asp:Literal>
                                </span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <%--<input type="checkbox" name="q1a4">
                                <span>
                                    <sc:text id="Text4" field="TA Area 4" runat="server" />
                                </span>--%>
                                <asp:CheckBox ID="q1a4" runat="server" />
                                <span>
                                    <asp:Literal ID="uxQ1a4" runat="server"></asp:Literal>
                                </span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <%--<input type="checkbox" name="q1a5">
                                <span>
                                    <sc:text id="Text5" field="TA Area 5" runat="server" />
                                </span>--%>
                                <asp:CheckBox ID="q1a5" runat="server" />
                                <span>
                                    <asp:Literal ID="uxQ1a5" runat="server"></asp:Literal>
                                </span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <%--<input type="checkbox" name="q1a6">
                                <span>
                                    <sc:text id="Text6" field="TA Area 6" runat="server" />
                                </span>--%>
                                <asp:CheckBox ID="q1a6" runat="server" />
                                <span>
                                    <asp:Literal ID="uxQ1a6" runat="server"></asp:Literal>
                                </span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <%--<input type="checkbox" name="q1a7">
                                <span>
                                    <sc:text id="Text7" field="TA Area 7" runat="server" />
                                </span>--%>
                                <asp:CheckBox ID="q1a7" runat="server" />
                                <span>
                                    <asp:Literal ID="uxQ1a7" runat="server"></asp:Literal>
                                </span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <%--<input type="checkbox" name="q1a8">
                                <span>
                                    <sc:text id="Text8" field="TA Area 8" runat="server" />
                                </span>--%>
                                <asp:CheckBox ID="q1a8" runat="server" />
                                <span>
                                    <asp:Literal ID="uxQ1a8" runat="server"></asp:Literal>
                                </span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <%--<input type="checkbox" name="q1a9">
                                <span>
                                    <sc:text id="Text9" field="TA Area 9" runat="server" />
                                </span>--%>
                                <asp:CheckBox ID="q1a9" runat="server" />
                                <span>
                                    <asp:Literal ID="uxQ1a9" runat="server"></asp:Literal>
                                </span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <%--<input type="checkbox" name="q1a10">
                                <span>
                                    <sc:text id="Text10" field="TA Area 10" runat="server" />
                                </span>--%>
                                <asp:CheckBox ID="q1a10" runat="server" />
                                <span>
                                    <asp:Literal ID="uxQ1a10" runat="server"></asp:Literal>
                                </span>
                            </label>
                        </div>
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
                            <sc:text id="Text15" field="Special Circumstances Question Title" runat="server" />
                        </h3>
                        <div class="checkboxes-wrapper">
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q3a1">
                                    <span>
                                        <sc:text id="Text16" field="SC Area 1" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q3a2">
                                    <span>
                                        <sc:text id="Text17" field="SC Area 2" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q3a3">
                                    <span>
                                        <sc:text id="Text18" field="SC Area 3" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q3a4">
                                    <span>
                                        <sc:text id="Text19" field="SC Area 4" runat="server" />
                                    </span>
                                </label>
                            </div>
                        </div>
                        <!-- .checkboxes-wrapper -->
                        <div class="question-description">
                            <span>*</span><sc:text id="Text20" field="Special Circumstances Question SubText" runat="server" />
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
