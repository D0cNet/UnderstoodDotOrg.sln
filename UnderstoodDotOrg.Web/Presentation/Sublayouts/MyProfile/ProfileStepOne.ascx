﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepOne.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepOne" %>
<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>
                        <sc:text field="Header Title" runat="server" />
                    </h1>
                    <p class="subtitle">
                        <sc:text id="Text1" field="Header Text" runat="server" />
                    </p>
                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header">
                            <sc:text id="Text2" field="Header Progress Bar Text" runat="server" />
                        </div>
                        <div class="progress-bar step-1">
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
                            <span class="done step">
                                <sc:text id="Text3" field="Header Progress Bar Done Text" runat="server" />
                            </span>
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
            <!-- BEGIN PARTIAL: profile-questions-step1 -->
            <div class="profile-questions step-1">
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                <div class="profile-questions-child-wrapper">
                    <!-- BEGIN PARTIAL: profile-questions-child -->
                    <div class="question-wrapper clearfix">
                        <p class="question with-margin">
                            <sc:text id="Text4" field="Child Struggling Question Title" runat="server" />
                        </p>
                        <div class="radio-toggle-wrapper">
                            <label class="button">
                                <%= BoyButton %>
                                <asp:RadioButton ID="uxBoy1" runat="server" GroupName="q1a" />

                            </label>
                            <label class="button">
                                <%= GirlButton %>
                                <asp:RadioButton ID="uxGirl1" runat="server" GroupName="q1a" />
                            </label>
                        </div>

                        <label class="inline">
                            <span class="question-spacer">
                                <sc:text id="Text7" field="In Text" runat="server" />
                            </span>
                            <asp:DropDownList ID="uxSelectGrade1" runat="server" name="q1b">
                                
                            </asp:DropDownList>
                        </label>
                    </div>
                    <!-- .question-wrapper -->

                    <!-- END PARTIAL: profile-questions-child -->
                </div>

                <%--2nd child--%>
                <div class="profile-questions-child-wrapper hidden">
                    <!-- BEGIN PARTIAL: profile-questions-child -->
                    <div class="question-wrapper clearfix">
                        <p class="question with-margin">
                            <sc:text id="Text5" field="Child Struggling Question Title" runat="server" />
                        </p>
                        <div class="radio-toggle-wrapper">
                            <label class="button">
                                <%= BoyButton %>
                                <asp:RadioButton ID="uxBoy2" runat="server" GroupName="q2a" />

                            </label>
                            <label class="button">
                                <%= GirlButton %>
                                <asp:RadioButton ID="uxGirl2" runat="server" GroupName="q2a" />
                            </label>
                        </div>

                        <label class="inline">
                            <span class="question-spacer">
                                <sc:text id="Text6" field="In Text" runat="server" />
                            </span>
                            <asp:DropDownList ID="uxSelectGrade2" runat="server" name="q2b">
                                
                            </asp:DropDownList>
                        </label>
                    </div>
                    <!-- .question-wrapper -->

                    <!-- END PARTIAL: profile-questions-child -->
                </div>

                <%--3rd child--%>
                <div class="profile-questions-child-wrapper hidden">
                    <!-- BEGIN PARTIAL: profile-questions-child -->
                    <div class="question-wrapper clearfix">
                        <p class="question with-margin">
                            <sc:text id="Text8" field="Child Struggling Question Title" runat="server" />
                        </p>
                        <div class="radio-toggle-wrapper">
                            <label class="button">
                                <%= BoyButton %>
                                <asp:RadioButton ID="uxBoy3" runat="server" GroupName="q3a" />

                            </label>
                            <label class="button">
                                <%= GirlButton %>
                                <asp:RadioButton ID="uxGirl3" runat="server" GroupName="q3a" />
                            </label>
                        </div>

                        <label class="inline">
                            <span class="question-spacer">
                                <sc:text id="Text9" field="In Text" runat="server" />
                            </span>
                            <asp:DropDownList ID="uxSelectGrade3" runat="server" name="q3b">
                                
                            </asp:DropDownList>
                        </label>
                    </div>
                    <!-- .question-wrapper -->

                    <!-- END PARTIAL: profile-questions-child -->
                </div>

                <%--4th child--%>
                <div class="profile-questions-child-wrapper hidden">
                    <!-- BEGIN PARTIAL: profile-questions-child -->
                    <div class="question-wrapper clearfix">
                        <p class="question with-margin">
                            <sc:text id="Text10" field="Child Struggling Question Title" runat="server" />
                        </p>
                        <div class="radio-toggle-wrapper">
                            <label class="button">
                                <%= BoyButton %>
                                <asp:RadioButton ID="uxBoy4" runat="server" GroupName="q4a" />

                            </label>
                            <label class="button">
                                <%= GirlButton %>
                                <asp:RadioButton ID="uxGirl4" runat="server" GroupName="q4a" />
                            </label>
                        </div>

                        <label class="inline">
                            <span class="question-spacer">
                                <sc:text id="Text11" field="In Text" runat="server" />
                            </span>
                            <asp:DropDownList ID="uxSelectGrade4" runat="server" name="q4b">
                                
                            </asp:DropDownList>
                        </label>
                    </div>
                    <!-- .question-wrapper -->

                    <!-- END PARTIAL: profile-questions-child -->
                </div>

                <%--5th child--%>
                <div class="profile-questions-child-wrapper hidden">
                    <!-- BEGIN PARTIAL: profile-questions-child -->
                    <div class="question-wrapper clearfix">
                        <p class="question with-margin">
                            <sc:text id="Text12" field="Child Struggling Question Title" runat="server" />
                        </p>
                        <div class="radio-toggle-wrapper">
                            <label class="button">
                                <%= BoyButton %>
                                <asp:RadioButton ID="uxBoy5" runat="server" GroupName="q5a" />

                            </label>
                            <label class="button">
                                <%= GirlButton %>
                                <asp:RadioButton ID="uxGirl5" runat="server" GroupName="q5a" />
                            </label>
                        </div>

                        <label class="inline">
                            <span class="question-spacer">
                                <sc:text id="Text13" field="In Text" runat="server" />
                            </span>
                            <asp:DropDownList ID="uxSelectGrade5" runat="server" name="q5b">
                                
                            </asp:DropDownList>
                    </div>
                    <!-- .question-wrapper -->

                    <!-- END PARTIAL: profile-questions-child -->
                </div>

                <%--6th child--%>
                <div class="profile-questions-child-wrapper hidden">
                    <!-- BEGIN PARTIAL: profile-questions-child -->
                    <div class="question-wrapper clearfix">
                        <p class="question with-margin">
                            <sc:text id="Text14" field="Child Struggling Question Title" runat="server" />
                        </p>
                        <div class="radio-toggle-wrapper">
                            <label class="button">
                                <%= BoyButton %>
                                <asp:RadioButton ID="uxBoy6" runat="server" GroupName="q6a" />

                            </label>
                            <label class="button">
                                <%= GirlButton %>
                                <asp:RadioButton ID="uxGirl6" runat="server" GroupName="q6a" />
                            </label>
                        </div>

                        <label class="inline">
                            <span class="question-spacer">
                                <sc:text id="Text15" field="In Text" runat="server" />
                            </span>
                            <asp:DropDownList ID="uxSelectGrade6" runat="server" name="q6b">
                                
                            </asp:DropDownList>
                        </label>
                    </div>
                    <!-- .question-wrapper -->

                    <!-- END PARTIAL: profile-questions-child -->
                </div>

                <div class="question-wrapper clearfix child-count-question">
                    <h3 class="question-inline">
                        <sc:text id="Text24" field="More Children Question Part 1" runat="server" />
                        <span class="child-counter">second</span>
                        <sc:text id="Text25" field="More Children Question Part 2" runat="server" />
                    </h3>
                    <div class="radio-toggle-wrapper no-margin">
                        <label class="button add-more-children">
                            <%= YesButton %>
                            <asp:RadioButton ID="uxAddChildYes" runat="server" CssClass="radio-toggle" GroupName="AddChild" />
                        </label>
                        <label class="button">
                            <%= NoButton %>
                            <asp:RadioButton ID="uxAddChildNo" runat="server" CssClass="radio-toggle" GroupName="AddChild" />
                        </label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper clearfix">
                    <h3 class="question-inline">
                        <sc:text id="Text21" field="Siblings Question Title" runat="server" />
                    </h3>
                    <div class="radio-toggle-wrapper no-margin">
                        <label class="button">
                            <%= YesButton %>
                            <asp:RadioButton ID="uxOtherChildrenYes" runat="server" CssClass="radio-toggle" GroupName="OtherChildren" />
                        </label>
                        <label class="button">
                            <%= NoButton %>
                            <asp:RadioButton ID="uxOtherChildrenNo" runat="server" CssClass="radio-toggle" GroupName="OtherChildren" />
                        </label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="form-actions"> 
                    <asp:Button ID="NextButton" CssClass="button" runat="server" OnClick="NextButton_Click" />
                    <!--<input class="button" type="submit" value="Next">-->
                </div>
            </div>
            <!-- .profile-questions.step-1 -->

            <!-- END PARTIAL: profile-questions-step1 -->
        </div>
    </div>
</div>
