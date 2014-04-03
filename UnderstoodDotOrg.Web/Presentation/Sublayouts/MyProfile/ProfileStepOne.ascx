<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepOne.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepOne" %>
<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1><sc:Text Field="Header Title" runat="server" /></h1>
                    <p class="subtitle"><sc:Text ID="Text1" Field="Header Text" runat="server" /></p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header"><sc:Text ID="Text2" Field="Header Progress Bar Text" runat="server" /></div>
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
                            <span class="done step"><sc:Text ID="Text3" Field="Header Progress Bar Done Text" runat="server" /></span>
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
                        <p class="question with-margin"><sc:Text ID="Text4" Field="Child Struggling Question Title" runat="server" /></p>
                        <div class="radio-toggle-wrapper">
                            <label class="button"><sc:Text ID="Text5" Field="Boy Button Text" runat="server" /><input name="q1" value="boy" type="radio"></label>
                            <label class="button"><sc:Text ID="Text6" Field="Girl Button Text" runat="server" /><input name="q1" value="girl" type="radio"></label>
                        </div>
                        <label class="inline">
                            <span class="question-spacer"><sc:Text ID="Text7" Field="In Text" runat="server" /></span>
                            <select name="q1b">
                                <option value=""><sc:Text ID="Text8" Field="Select Grade Field Default" runat="server" /></option>
                                <option value="1"><sc:Text ID="Text9" Field="Select Grade Field 1" runat="server" /></option>
                                <option value="2"><sc:Text ID="Text10" Field="Select Grade Field 2" runat="server" /></option>
                                <option value="3"><sc:Text ID="Text11" Field="Select Grade Field 3" runat="server" /></option>
                                <option value="4"><sc:Text ID="Text12" Field="Select Grade Field 4" runat="server" /></option>
                                <option value="5"><sc:Text ID="Text13" Field="Select Grade Field 5" runat="server" /></option>
                                <option value="6"><sc:Text ID="Text14" Field="Select Grade Field 6" runat="server" /></option>
                                <option value="7"><sc:Text ID="Text15" Field="Select Grade Field 7" runat="server" /></option>
                                <option value="8"><sc:Text ID="Text16" Field="Select Grade Field 8" runat="server" /></option>
                                <option value="9"><sc:Text ID="Text17" Field="Select Grade Field 9" runat="server" /></option>
                                <option value="10"><sc:Text ID="Text19" Field="Select Grade Field 10" runat="server" /></option>
                                <option value="11"><sc:Text ID="Text18" Field="Select Grade Field 11" runat="server" /></option>
                                <option value="12"><sc:Text ID="Text20" Field="Select Grade Field 12" runat="server" /></option>
                            </select>
                        </label>
                    </div>
                    <!-- .question-wrapper -->

                    <!-- END PARTIAL: profile-questions-child -->
                </div>

                <div class="question-wrapper clearfix child-count-question">
                    <h3 class="question-inline"><sc:Text ID="Text24" Field="More Children Question Part 1" runat="server" /> <span class="child-counter">second</span> <sc:Text ID="Text25" Field="More Children Question Part 2" runat="server" /></h3>
                    <div class="radio-toggle-wrapper no-margin">
                        <label class="button add-more-children"><sc:Text ID="Text26" Field="More Children Yes Button Text" runat="server" /><input name="q2" value="yes" class="radio-toggle" type="radio"></label>
                        <label class="button"><sc:Text ID="Text27" Field="More Children No Button Text" runat="server" /><input name="q2" value="no" class="radio-toggle" type="radio"></label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper clearfix">
                    <h3 class="question-inline"><sc:Text ID="Text21" Field="Siblings Question Title" runat="server" /></h3>
                    <div class="radio-toggle-wrapper no-margin">
                        <label class="button"><sc:Text ID="Text22" Field="Siblings Yes Button Text" runat="server" /><input name="q3" value="yes" class="radio-toggle" type="radio"></label>
                        <label class="button"><sc:Text ID="Text23" Field="Siblings No Button Text" runat="server" /><input name="q3" value="no" class="radio-toggle" type="radio"></label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="form-actions">
                    <asp:Button ID="NextButton" CssClass="button" runat="server" />
                    <!--<input class="button" type="submit" value="Next">-->
                </div>
            </div>
            <!-- .profile-questions.step-1 -->

            <!-- END PARTIAL: profile-questions-step1 -->
        </div>
    </div>
</div>
