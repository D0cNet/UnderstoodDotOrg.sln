<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepOne.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepOne" %>
<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>Complete My Profile</h1>
                    <p class="subtitle">qui porro molestias alias consequatur quod earum ipsum voluptas voluptatem ut quam ut</p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header">Progress</div>
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
            <!-- BEGIN PARTIAL: profile-questions-step1 -->
            <div class="profile-questions step-1">

                <div class="profile-questions-child-wrapper">
                    <!-- BEGIN PARTIAL: profile-questions-child -->
                    <div class="question-wrapper clearfix">
                        <p class="question with-margin">My child struggling with learning or attention issues is a:</p>
                        <div class="radio-toggle-wrapper">
                            <label class="button">Boy<input name="q1" value="boy" type="radio"></label>
                            <label class="button">Girl<input name="q1" value="girl" type="radio"></label>
                        </div>
                        <label class="inline">
                            <span class="question-spacer">in</span>
                            <select name="q1b">
                                <option value="">Select Grade</option>
                                <option value="1">Grade 1</option>
                                <option value="2">Grade 2</option>
                                <option value="3">Grade 3</option>
                                <option value="4">Grade 4</option>
                                <option value="5">Grade 5</option>
                                <option value="6">Grade 6</option>
                                <option value="7">Grade 7</option>
                                <option value="8">Grade 8</option>
                                <option value="9">Grade 9</option>
                                <option value="10">Grade 10</option>
                                <option value="11">Grade 11</option>
                                <option value="12">Grade 12</option>
                            </select>
                        </label>
                    </div>
                    <!-- .question-wrapper -->

                    <!-- END PARTIAL: profile-questions-child -->
                </div>

                <div class="question-wrapper clearfix child-count-question">
                    <h3 class="question-inline">I have a <span class="child-counter">second</span> child who struggles with learning and attention issues</h3>
                    <div class="radio-toggle-wrapper no-margin">
                        <label class="button add-more-children">Yes<input name="q2" value="yes" class="radio-toggle" type="radio"></label>
                        <label class="button">No<input name="q2" value="no" class="radio-toggle" type="radio"></label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper clearfix">
                    <h3 class="question-inline">My child has siblings who are not struggling with learning or attention issues</h3>
                    <div class="radio-toggle-wrapper no-margin">
                        <label class="button">Yes<input name="q3" value="yes" class="radio-toggle" type="radio"></label>
                        <label class="button">No<input name="q3" value="no" class="radio-toggle" type="radio"></label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="form-actions">
                    <input class="button" type="submit" value="Next">
                </div>
            </div>
            <!-- .profile-questions.step-1 -->

            <!-- END PARTIAL: profile-questions-step1 -->
        </div>
    </div>
</div>
