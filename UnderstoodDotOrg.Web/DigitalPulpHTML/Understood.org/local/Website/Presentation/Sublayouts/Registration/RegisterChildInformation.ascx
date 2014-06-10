<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegisterChildInformation.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Registration.RegisterChildInformation" %>
<div class="container registration-profile-container flush">
    <div class="row">
        <div class="col col-15 offset-5">
            <!-- BEGIN PARTIAL: registration-profile-child -->
            <div class="registration-profile about-child">
                <h2>Tell us about your child</h2>
                <div class="question-wrapper">
                    <p class="question">My child struggles with</p>
                    <div class="checkboxes-wrapper">
                        <div class="checkbox-wrapper">
                            <label>
                                <div class="checker"><span>
                                    <input type="checkbox" name="q1a1"></span></div>
                                <span>Reading</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <div class="checker"><span>
                                    <input type="checkbox" name="q1a2"></span></div>
                                <span>Writing</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <div class="checker"><span>
                                    <input type="checkbox" name="q1a3"></span></div>
                                <span>Math</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <div class="checker"><span>
                                    <input type="checkbox" name="q1a4"></span></div>
                                <span>Listening comprehension</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <div class="checker"><span>
                                    <input type="checkbox" name="q1a5"></span></div>
                                <span>Spoken language</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <div class="checker"><span>
                                    <input type="checkbox" name="q1a6"></span></div>
                                <span>Executive function (organization, planning, flexible thinking)</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <div class="checker"><span>
                                    <input type="checkbox" name="q1a7"></span></div>
                                <span>Hyperactivity/impulsivity</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <div class="checker"><span>
                                    <input type="checkbox" name="q1a8"></span></div>
                                <span>Attention/staying focused</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <div class="checker"><span>
                                    <input type="checkbox" name="q1a9"></span></div>
                                <span>Social skills</span>
                            </label>
                        </div>
                        <div class="checkbox-wrapper">
                            <label>
                                <div class="checker"><span>
                                    <input type="checkbox" name="q1a10"></span></div>
                                <span>Motor skills</span>
                            </label>
                        </div>
                    </div>
                    <!-- .checkboxes-wrapper -->
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper">
                    <div class="select-wrapper select-inverted-mobile">
                        <div class="selector" style="width: 100%;">
                            <span style="width: 100%; -moz-user-select: none;">My child is enrolled (select grade)</span><select name="q1b">
                                <option value="">My child is enrolled (select grade)</option>
                                <option>Grade 1</option>
                                <option>Grade 2</option>
                                <option>Grade 3</option>
                                <option>Grade 4</option>
                                <option>Grade 5</option>
                                <option>Grade 6</option>
                                <option>Grade 7</option>
                                <option>Grade 8</option>
                                <option>Grade 9</option>
                                <option>Grade 10</option>
                                <option>Grade 11</option>
                                <option>Grade 12</option>
                            </select>
                        </div>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper">
                    <div class="textfield-wrapper">
                        <input type="textfield" placeholder="My child's nickname" name="q2" class="uniform-input text">
                    </div>
                    <p class="question-description">Child's nickname is private -- only viewable by you.</p>
                </div>
                <!-- .question-wrapper -->

                <div class="form-actions">
                    <input type="submit" value="See my Recommendations" class="button">
                    <div class="spacer"></div>
                    <a href="REPLACE" class="full-profile-link">or complete my full profile</a>
                </div>
            </div>
            <!-- .registration-profile -->

            <!-- END PARTIAL: registration-profile-child -->
        </div>
    </div>
</div>
