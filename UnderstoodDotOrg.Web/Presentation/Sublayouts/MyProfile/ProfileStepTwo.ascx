<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepTwo.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepTwo" %>
<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>
                        <sc:Text Field="Header Title" ID="PageHeader1" runat="server" />
                    </h1>
                    <p class="subtitle"><sc:Text Field="Header Text" ID="HeaderText1" runat="server" /></p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header"><sc:Text Field="Header Progress Bar Text" ID="BarText1" runat="server" /></div>
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
                <h2><sc:Text Field="Form Title" runat="server" /></h2>

                <div class="question-wrapper clearfix short-bottom trouble-question">
                    <h3 class="question-inline"><sc:Text Field="Child Nickname Question Title" runat="server" />
     
                                    <span class="question-description"><sc:Text Field="Child Nickname Question Text" runat="server" /></span>
                    </h3>
                    <input type="textfield">
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper evaluation-question">
                    <h3 class="question"><sc:Text Field="Trouble Areas Question Title" runat="server" /></h3>
                    <div class="checkboxes-wrapper">
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a1">
                                <span><sc:Text ID="Text1" Field="TA Area 1" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a2">
                                <span><sc:Text ID="Text2" Field="TA Area 2" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a3">
                                <span><sc:Text ID="Text3" Field="TA Area 3" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a4">
                                <span><sc:Text ID="Text4" Field="TA Area 4" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a5">
                                <span><sc:Text ID="Text5" Field="TA Area 5" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a6">
                                <span><sc:Text ID="Text6" Field="TA Area 6" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a7">
                                <span><sc:Text ID="Text7" Field="TA Area 7" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a8">
                                <span><sc:Text ID="Text8" Field="TA Area 8" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a9">
                                <span><sc:Text ID="Text9" Field="TA Area 9" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a10">
                                <span><sc:Text ID="Text10" Field="TA Area 10" runat="server" /></span>
                            </label>
                        </div>
                    </div>
                    <!-- .checkboxes-wrapper -->
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper evaluation-question">
                    <h3 class="question"><sc:Text ID="Text11" Field="Formally Evaluated Question Title" runat="server" /></h3>
                    <div class="radio-toggle-wrapper">
                        <label class="button"><sc:Text ID="Text12" Field="Yes Button" runat="server" /><input name="q2" value="yes" class="radio-toggle" type="radio"></label>
                        <label class="button"><sc:Text ID="Text13" Field="No Button" runat="server" /><input name="q2" value="no" class="radio-toggle" type="radio"></label>
                        <label class="button"><sc:Text ID="Text14" Field="In Progress Button" runat="server" /><input name="q2" value="progress" class="radio-toggle" type="radio"></label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper family-question">
                    <h3 class="question"><sc:Text ID="Text15" Field="Special Circumstances Question Title" runat="server" /></h3>
                    <div class="checkboxes-wrapper">
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q3a1">
                                <span><sc:Text ID="Text16" Field="SC Area 1" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q3a2">
                                <span><sc:Text ID="Text17" Field="SC Area 2" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q3a3">
                                <span><sc:Text ID="Text18" Field="SC Area 3" runat="server" /></span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q3a4">
                                <span><sc:Text ID="Text19" Field="SC Area 4" runat="server" /></span>
                            </label>
                        </div>
                    </div>
                    <!-- .checkboxes-wrapper -->
                    <div class="question-description"><span>*</span><sc:Text ID="Text20" Field="Special Circumstances Question SubText" runat="server" /></div>
                </div>
                <!-- .question-wrapper -->

                <div class="form-actions">
                    <input class="button" type="submit" value="<sc:Text ID="Text21" Field="Next Button Text" runat="server" />">
                </div>
            </div>
            <!-- .profile-questions.step-2 -->

            <!-- END PARTIAL: profile-questions-step2 -->
        </div>
    </div>
</div>
