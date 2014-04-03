<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepFour.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepFour" %>
<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1><sc:Text ID="Text1" Field="Header Title" runat="server" /></h1>
                    <p class="subtitle"><sc:Text ID="Text2" Field="Header Text" runat="server" /></p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header"><sc:Text ID="Text3" Field="Header Progress Bar Text" runat="server" /></div>
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
                            <span class="done step"><sc:Text ID="Text4" Field="Header Progress Bar Done Text" runat="server" /></span>
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
                <h2><sc:Text ID="Text5" Field="Form Title" runat="server" /></h2>

                <div class="question-wrapper clearfix school-issues-question">
                    <h3 class="question"><sc:Text ID="Text6" Field="School Issues Question Title" runat="server" /></h3>
                    <div class="checkboxes-wrapper">

                        <div class="column-left">
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a1">
                                    <span><sc:Text ID="Text7" Field="SI Area 1" runat="server" /></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a2">
                                    <span><sc:Text ID="Text8" Field="SI Area 2" runat="server" /></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a3">
                                    <span><sc:Text ID="Text9" Field="SI Area 3" runat="server" /></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a4">
                                    <span><sc:Text ID="Text10" Field="SI Area 4" runat="server" /></span>
                                </label>
                            </div>
                        </div>
                        <!-- .checkboxes-left -->

                        <div class="column-right">
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a8">
                                    <span><sc:Text ID="Text11" Field="SI Area 5" runat="server" /></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a9">
                                    <span><sc:Text ID="Text12" Field="SI Area 6" runat="server" /></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a10">
                                    <span><sc:Text ID="Text13" Field="SI Area 7" runat="server" /></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a11">
                                    <span><sc:Text ID="Text14" Field="SI Area 8" runat="server" /></span>
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
                            <h3 class="question"><sc:Text ID="Text15" Field="Ways To Help Question Title" runat="server" /></h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span><sc:Text ID="Text16" Field="WTH Area 1" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a2">
                                        <span><sc:Text ID="Text17" Field="WTH Area 2" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a3">
                                        <span><sc:Text ID="Text18" Field="WTH Area 3" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a4">
                                        <span><sc:Text ID="Text19" Field="WTH Area 4" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a5">
                                        <span><sc:Text ID="Text20" Field="WTH Area 5" runat="server" /></span>
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
                            <h3 class="question"><sc:Text ID="Text21" Field="Home Life Question Title" runat="server" /></h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a1">
                                        <span><sc:Text ID="Text22" Field="HL Area 1" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a2">
                                        <span><sc:Text ID="Text23" Field="HL Area 2" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a3">
                                        <span><sc:Text ID="Text24" Field="HL Area 3" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a4">
                                        <span><sc:Text ID="Text25" Field="HL Area 4" runat="server" /></span>
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
                            <h3 class="question"><sc:Text ID="Text26" Field="Growing Up Question Title" runat="server" /></h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a1">
                                        <span><sc:Text ID="Text27" Field="GU Area 1" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a2">
                                        <span><sc:Text ID="Text28" Field="GU Area 2" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a3">
                                        <span><sc:Text ID="Text29" Field="GU Area 3" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a4">
                                        <span><sc:Text ID="Text30" Field="GU Area 4" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a5">
                                        <span><sc:Text ID="Text31" Field="GU Area 5" runat="server" /></span>
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
                            <h3 class="question"><sc:Text ID="Text32" Field="Social Emotional Issues Question Title" runat="server" /></h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q5a1">
                                        <span><sc:Text ID="Text33" Field="SEI Area 1" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q5a2">
                                        <span><sc:Text ID="Text34" Field="SEI Area 2" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q5a3">
                                        <span><sc:Text ID="Text35" Field="SEI Area 3" runat="server" /></span>
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
                    <h3 class="question"><sc:Text ID="Text36" Field="Where Are You Question Title" runat="server" /></h3>
                    <div class="radios-wrapper">
                        <div class="radio-wrapper">
                            <label>
                                <input type="radio" name="q6" value="a1">
                                <span><sc:Text ID="Text37" Field="WAY Area 1" runat="server" /></span>
                            </label>
                        </div>
                        <div class="radio-wrapper">
                            <label>
                                <input type="radio" name="q6" value="a2">
                                <span><sc:Text ID="Text38" Field="WAY Area 2" runat="server" /></span>
                            </label>
                        </div>
                        <div class="radio-wrapper">
                            <label>
                                <input type="radio" name="q6" value="a3">
                                <span><sc:Text ID="Text39" Field="WAY Area 3" runat="server" /></span>
                            </label>
                        </div>
                    </div>
                    <!-- .radios-wrapper -->
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper role-question">
                    <p class="question with-margin"><sc:Text ID="Text40" Field="What Is Your Role Question Title" runat="server" /></p>
                    <div class="radio-toggle-wrapper">
                        <label class="button"><sc:Text ID="Text41" Field="Mom Button Text" runat="server" /><input name="q7" value="boy" type="radio"></label>
                        <label class="button"><sc:Text ID="Text42" Field="Dad Button Text" runat="server" /><input name="q7" value="girl" type="radio"></label>
                    </div>
                    <label class="inline">
                        <select name="q7b">
                            <option value=""><sc:Text ID="Text43" Field="Other Field Default" runat="server" /></option>
                            <option value="grandparent"><sc:Text ID="Text44" Field="Other Field 1" runat="server" /></option>
                            <option value="aunt_uncle"><sc:Text ID="Text45" Field="Other Field 2" runat="server" /></option>
                            <option value="teacher"><sc:Text ID="Text46" Field="Other Field 3" runat="server" /></option>
                            <option value="medical"><sc:Text ID="Text47" Field="Other Field 4" runat="server" /></option>
                            <option value="caregiver"><sc:Text ID="Text48" Field="Other Field 5" runat="server" /></option>
                            <option value="other"><sc:Text ID="Text49" Field="Other Field 6" runat="server" /></option>
                        </select>
                    </label>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper connect-question">
                    <p class="question">
                        <sc:Text ID="Text50" Field="Connect Question Title" runat="server" />
     
                                    <span class="question-description"><sc:Text ID="Text51" Field="Connect Question Text" runat="server" /></span>
                    </p>
                    <div class="textfields-wrapper">
                        <div class="textfield-wrapper">
                            <asp:TextBox type="textfield" ID="ScreenNameTextField" runat="server" />
                            <!--input type="textfield" name="connect-1" placeholder="Screen Name"-->
                            <span class="popover-trigger-container"><a class="popover-link" href="REPLACE"><sc:Text ID="Text52" Field="Why Do We Ask Text 1" runat="server" /></a></span>
                            <div class="popover-container">
                                <p><span class="title"><sc:Text ID="Text53" Field="Why Do We Ask Subtext Header 1" runat="server" /></span> <sc:Text ID="Text54" Field="Why Do We Ask Subtext 1" runat="server" /></p>
                            </div>
                        </div>
                        <div class="textfield-wrapper">
                            <asp:TextBox type="textfield" ID="ZipCodeTextField" runat="server" />
                            <!--input type="textfield" name="connect-2" placeholder="Zip Code"-->
                            <span class="popover-trigger-container"><a class="popover-link" href="REPLACE"><sc:Text ID="Text55" Field="Why Do We Ask Text 2" runat="server" /></a></span>
                            <div class="popover-container">
                                <p><span class="title"><sc:Text ID="Text56" Field="Why Do We Ask Subtext Header 2" runat="server" /></span> <sc:Text ID="Text57" Field="Why Do We Ask Subtext 2" runat="server" /></p>
                            </div>
                        </div>
                    </div>
                    <div class="no-uniform-wrapper">
                        <label>
                            <input class="no-uniform" type="checkbox">
                            <span><sc:Text ID="Text58" Field="Interest Text" runat="server" /></span>
                        </label>
                        <label>
                            <input class="no-uniform" type="checkbox">
                            <span><sc:Text ID="Text59" Field="Personalized Newsletter Text" runat="server" /></span>
                        </label>
                    </div>
                </div>
                <!-- .connect-question -->

                <div class="form-actions">
                    <asp:Button CssClass="button" ID="SubmitButton" runat="server" />
                    <!--input class="button" type="submit" value="Submit"-->
                </div>
            </div>
            <!-- .profile-questions.step-3 -->

            <!-- END PARTIAL: profile-questions-step3 -->
        </div>
    </div>
</div>
