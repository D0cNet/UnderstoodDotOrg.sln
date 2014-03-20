<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepFour.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepFour" %>
<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>Complete My Profile</h1>
                    <p class="subtitle">amet qui earum placeat omnis sed dolorem voluptas ipsa sint alias et earum</p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header">Progress</div>
                        <div class="progress-bar step-3">
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
            <!-- BEGIN PARTIAL: profile-questions-step3 -->
            <div class="profile-questions step-3">
                <h2>What topics are you interested in?</h2>

                <div class="question-wrapper clearfix school-issues-question">
                    <h3 class="question">School Issues</h3>
                    <div class="checkboxes-wrapper">

                        <div class="column-left">
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a1">
                                    <span>Choosing or changing schools</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a2">
                                    <span>Mainstream vs. special ed</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a3">
                                    <span>School services (IEPs/504 plans)</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a4">
                                    <span>Homeschooling</span>
                                </label>
                            </div>
                        </div>
                        <!-- .checkboxes-left -->

                        <div class="column-right">
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a8">
                                    <span>Working with teachers</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a9">
                                    <span>RTI/MTSS</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a10">
                                    <span>Bullying</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a11">
                                    <span>Homework & study skills</span>
                                </label>
                            </div>
                        </div>
                        <!-- .checkboxes-right -->
                    </div>
                    <!-- .checkboxes-wrapper -->
                </div>
                <!-- .question-wrapper -->

                <div class="column-wrapper clearfix">
                    <div class="column-left">
                        <div class="question-wrapper help-question">
                            <h3 class="question">Ways to Help Your Child</h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span>Evaluations</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a2">
                                        <span>Therapies & medications</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a3">
                                        <span>Tutors & academic skill programs</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a4">
                                        <span>Technologies & apps</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a5">
                                        <span>Advocating for your child's rights</span>
                                    </label>
                                </div>
                            </div>
                            <!-- .checkboxes-wrapper -->
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->

                    <div class="column-right">
                        <div class="question-wrapper home-life-question">
                            <h3 class="question">Home Life</h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a1">
                                        <span>Travel, entertainment & activities</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a2">
                                        <span>Siblings</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a3">
                                        <span>Communicating with family & friends</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a4">
                                        <span>Finding support</span>
                                    </label>
                                </div>
                            </div>
                            <!-- .checkboxes-wrapper -->
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->
                </div>
                <!-- .column-wrapper -->

                <div class="column-wrapper clearfix">
                    <div class="column-left">
                        <div class="question-wrapper growing-up-question">
                            <h3 class="question">Growing Up</h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a1">
                                        <span>Teenage concerns (driving, dating, etc.)</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a2">
                                        <span>College & vocational school</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a3">
                                        <span>Work & jobs</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a4">
                                        <span>Assisted living</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a5">
                                        <span>Self-advocacy skills</span>
                                    </label>
                                </div>
                            </div>
                            <!-- .checkboxes-wrapper -->
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->

                    <div class="column-right">
                        <div class="question-wrapper social-emotional-question">
                            <h3 class="question">Social/Emotional Issues</h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q5a1">
                                        <span>Feelings & self-esteem</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q5a2">
                                        <span>Social challenges & friendship</span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q5a3">
                                        <span>Behavior issues</span>
                                    </label>
                                </div>
                            </div>
                            <!-- .checkboxes-wrapper -->
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->
                </div>
                <!-- .column-wrapper -->

                <div class="question-wrapper journey-question">
                    <h3 class="question">Where are you in the journey?</h3>
                    <div class="radios-wrapper">
                        <div class="radio-wrapper">
                            <label>
                                <input type="radio" name="q6" value="a1">
                                <span>I'm still trying to figure out what is going on with my child.</span>
                            </label>
                        </div>
                        <div class="radio-wrapper">
                            <label>
                                <input type="radio" name="q6" value="a2">
                                <span>We've been working through my child's issues this past year.</span>
                            </label>
                        </div>
                        <div class="radio-wrapper">
                            <label>
                                <input type="radio" name="q6" value="a3">
                                <span>We've been working through my child's issues for many years now.</span>
                            </label>
                        </div>
                    </div>
                    <!-- .radios-wrapper -->
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper role-question">
                    <p class="question with-margin">What is your role?</p>
                    <div class="radio-toggle-wrapper">
                        <label class="button">Mom<input name="q7" value="boy" type="radio"></label>
                        <label class="button">Dad<input name="q7" value="girl" type="radio"></label>
                    </div>
                    <label class="inline">
                        <select name="q7b">
                            <option value="">Other (select one)</option>
                            <option value="grandparent">Grandparent</option>
                            <option value="aunt_uncle">Aunt / Uncle</option>
                            <option value="teacher">Teacher</option>
                            <option value="medical">Medical Professional</option>
                            <option value="caregiver">Caregiver</option>
                            <option value="other">Other</option>
                        </select>
                    </label>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper connect-question">
                    <p class="question">
                        Would you like to connect with our parent community?
     
                                    <span class="question-description">A safe place to share experiences and advice with people who understand.</span>
                    </p>
                    <div class="textfields-wrapper">
                        <div class="textfield-wrapper">
                            <input type="textfield" name="connect-1" placeholder="Enter a Screen Name">
                            <span class="popover-trigger-container"><a class="popover-link" href="REPLACE">Why do we ask?</a></span>
                            <div class="popover-container">
                                <p><span class="title">lorem ipsum soged</span> Voluptas autem quia cum repellendus tempore quasi culpa reprehenderit consequatur aperiam impedit aut quaerat. quibusdam non alias sunt. dolores quas vitae voluptates optio commodi. eligendi id nulla fugiat nemo error sit consequuntur sed cum accusamus nobis velit incidunt. ducimus error delectus in voluptatem est et consequuntur officia. voluptas nihil sapiente explicabo sint</p>
                            </div>
                        </div>
                        <div class="textfield-wrapper">
                            <input type="textfield" name="connect-2" placeholder="Zip Code">
                            <span class="popover-trigger-container"><a class="popover-link" href="REPLACE">Why do we ask?</a></span>
                            <div class="popover-container">
                                <p><span class="title">lorem ipsum soged</span> Sint voluptate qui nobis ut. doloribus eos sint quisquam aut dignissimos ipsum quaerat sunt neque. quisquam necessitatibus voluptatem accusantium commodi suscipit ex sunt autem eaque. atque et commodi deleniti nostrum qui in</p>
                            </div>
                        </div>
                    </div>
                    <div class="no-uniform-wrapper">
                        <label>
                            <input class="no-uniform" type="checkbox">
                            <span>I'm interested in connect requests from parents like me.</span>
                        </label>
                        <label>
                            <input class="no-uniform" type="checkbox">
                            <span>Yes, I’d like to sign up for my personalized newsletter.</span>
                        </label>
                    </div>
                </div>
                <!-- .connect-question -->

                <div class="form-actions">
                    <input class="button" type="submit" value="Submit">
                </div>
            </div>
            <!-- .profile-questions.step-3 -->

            <!-- END PARTIAL: profile-questions-step3 -->
        </div>
    </div>
</div>
