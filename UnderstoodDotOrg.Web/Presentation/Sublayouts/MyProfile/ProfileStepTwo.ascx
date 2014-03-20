<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepTwo.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepTwo" %>
<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>Complete My Profile</h1>
                    <p class="subtitle">delectus odit labore quos impedit magni pariatur ea distinctio labore consequatur inventore ea</p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header">Progress</div>
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
                <h2>Tell us about your 3rd grader</h2>

                <div class="question-wrapper clearfix short-bottom trouble-question">
                    <h3 class="question-inline">Your child's nickname
     
                                    <span class="question-description">Child's nickname is private and only viewable by you.</span>
                    </h3>
                    <input type="textfield">
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper evaluation-question">
                    <h3 class="question">What is he having trouble with?</h3>
                    <div class="checkboxes-wrapper">
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a1">
                                <span>Reading</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a2">
                                <span>Writing</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a3">
                                <span>Math</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a4">
                                <span>Listening comprehension</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a5">
                                <span>Spoken language</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a6">
                                <span>Executive function (organization, planning, flexible thinking)</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a7">
                                <span>Hyperactivity/impulsivity</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a8">
                                <span>Attention/staying focused</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a9">
                                <span>Social skills</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q1a10">
                                <span>Motor skills</span>
                            </label>
                        </div>
                    </div>
                    <!-- .checkboxes-wrapper -->
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper evaluation-question">
                    <h3 class="question">Has he been formally evaluated for learning or attention issues?</h3>
                    <div class="radio-toggle-wrapper">
                        <label class="button">Yes<input name="q2" value="yes" class="radio-toggle" type="radio"></label>
                        <label class="button">No<input name="q2" value="no" class="radio-toggle" type="radio"></label>
                        <label class="button">In Progress<input name="q2" value="progress" class="radio-toggle" type="radio"></label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper family-question">
                    <h3 class="question">Are there any special family circumstances? *</h3>
                    <div class="checkboxes-wrapper">
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q3a1">
                                <span>Parents are divorced</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q3a2">
                                <span>Blended family</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q3a3">
                                <span>Single parent</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <input type="checkbox" name="q3a4">
                                <span>Adopted child</span>
                            </label>
                        </div>
                    </div>
                    <!-- .checkboxes-wrapper -->
                    <div class="question-description"><span>*</span> This will help us personalize for you today and in the future.</div>
                </div>
                <!-- .question-wrapper -->

                <div class="form-actions">
                    <input class="button" type="submit" value="Next">
                </div>
            </div>
            <!-- .profile-questions.step-2 -->

            <!-- END PARTIAL: profile-questions-step2 -->
        </div>
    </div>
</div>
