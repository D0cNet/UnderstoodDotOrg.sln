<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepThree.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepThree" %>
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
                        <div class="progress-bar step-2b">
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
            <!-- BEGIN PARTIAL: profile-questions-step2b -->
            <div class="profile-questions step-2b">
                <h2><sc:Text ID="Text4" Field="Form Title" runat="server" /></h2>

                <div class="question-wrapper clearfix difficulties-question">
                    <h3 class="question"><sc:Text ID="Text5" Field="Learning Disorders Question Title" runat="server" /></h3>
                    <p class="question-description">
                        <sc:Text ID="Text6" Field="Learning Disorders Question Text" runat="server" />
   
                    </p>
                    <div class="checkboxes-wrapper">

                        <div class="column-left">
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a1">
                                    <span class="description"><sc:Text ID="Text7" Field="LD Area 1" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text39" Field="LD Area 1 Mouse Over Title" runat="server" /></span><sc:Text ID="Text52" Field="LD Area 1 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a2">
                                    <span class="description"><sc:Text ID="Text8" Field="LD Area 2" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text40" Field="LD Area 2 Mouse Over Title" runat="server" /></span><sc:Text ID="Text53" Field="LD Area 2 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a3">
                                    <span class="description"><sc:Text ID="Text9" Field="LD Area 3" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text41" Field="LD Area 3 Mouse Over Title" runat="server" /></span><sc:Text ID="Text54" Field="LD Area 3 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a4">
                                    <span class="description"><sc:Text ID="Text10" Field="LD Area 4" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text42" Field="LD Area 4 Mouse Over Title" runat="server" /></span><sc:Text ID="Text55" Field="LD Area 4 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a5">
                                    <span class="description"><sc:Text ID="Text11" Field="LD Area 5" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text43" Field="LD Area 5 Mouse Over Title" runat="server" /></span><sc:Text ID="Text56" Field="LD Area 5 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a6">
                                    <span class="description"><sc:Text ID="Text12" Field="LD Area 6" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text44" Field="LD Area 6 Mouse Over Title" runat="server" /></span><sc:Text ID="Text57" Field="LD Area 6 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a7">
                                    <span class="description"><sc:Text ID="Text13" Field="LD Area 7" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text45" Field="LD Area 7 Mouse Over Title" runat="server" /></span><sc:Text ID="Text58" Field="LD Area 7 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                        </div>
                        <!-- .checkboxes-left -->

                        <div class="column-right">
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a8">
                                    <span class="description"><sc:Text ID="Text14" Field="LD Area 8" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text46" Field="LD Area 8 Mouse Over Title" runat="server" /></span><sc:Text ID="Text59" Field="LD Area 8 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a9">
                                    <span class="description"><sc:Text ID="Text15" Field="LD Area 9" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text47" Field="LD Area 9 Mouse Over Title" runat="server" /></span><sc:Text ID="Text60" Field="LD Area 9 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a10">
                                    <span class="description"><sc:Text ID="Text16" Field="LD Area 10" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text48" Field="LD Area 10 Mouse Over Title" runat="server" /></span><sc:Text ID="Text61" Field="LD Area 10 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a11">
                                    <span class="description"><sc:Text ID="Text17" Field="LD Area 11" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text49" Field="LD Area 11 Mouse Over Title" runat="server" /></span><sc:Text ID="Text62" Field="LD Area 11 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a12">
                                    <span class="description"><sc:Text ID="Text18" Field="LD Area 12" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text50" Field="LD Area 12 Mouse Over Title" runat="server" /></span><sc:Text ID="Text63" Field="LD Area 12 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a13">
                                    <span class="description"><sc:Text ID="Text19" Field="LD Area 13" runat="server" /></span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block"><sc:Text ID="Text51" Field="LD Area 13 Mouse Over Title" runat="server" /></span><sc:Text ID="Text64" Field="LD Area 13 Mouse Over" runat="server" /><a href="REPLACE">Learn more</a></span>
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
                        <div class="question-wrapper focus-question">
                            <h3 class="question"><sc:Text ID="Text20" Field="Attention And Focus Question Title" runat="server" /></h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span><sc:Text ID="Text21" Field="AF Area 1" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span><sc:Text ID="Text22" Field="AF Area 1" runat="server" /></span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span><sc:Text ID="Text23" Field="AF Area 1" runat="server" /></span>
                                    </label>
                                </div>
                            </div>
                            <!-- .checkboxes-wrapper -->
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->

                    <div class="column-right">
                        <div class="question-wrapper disorder-question">
                            <h3 class="question"><sc:Text ID="Text24" Field="Other Disorder Question Title" runat="server" /></h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span><sc:Text ID="Text25" Field="OD Area 1" runat="server" /></span>
                                    </label>
                                </div>
                            </div>
                            <!-- .checkboxes-wrapper -->
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-left -->
                </div>
                <!-- .column-wrapper -->

                <div class="question-wrapper iep-question select-question clearfix">
                    <p class="question-inline"><sc:Text ID="Text26" Field="IEP Question Title" runat="server" /></p>
                    <div class="select-wrapper clearfix">
                        <div class="select-inner-wrapper clearfix">
                            <select>
                                <option value=""><sc:Text ID="Text27" Field="IEP Option Default" runat="server" /></option>
                                <option value="has_iep"><sc:Text ID="Text28" Field="IEP Option 1" runat="server" /></option>
                                <option value="lost_iep"><sc:Text ID="Text29" Field="IEP Option 2" runat="server" /></option>
                                <option value="not_qualified"><sc:Text ID="Text30" Field="IEP Option 3" runat="server" /></option>
                                <option value="coming_up"><sc:Text ID="Text31" Field="IEP Option 4" runat="server" /></option>
                                <option value="no_iep"><sc:Text ID="Text32" Field="IEP Option 5" runat="server" /></option>
                            </select>
                            <span><a href="REPLACE" class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></span>
                            <div class="iep-tooltip popover-container">
                                <p><span class="title">lorem ipsum soged</span> Et beatae itaque quod est voluptatem eligendi. necessitatibus harum consectetur veritatis illum iste autem saepe. ducimus quasi eaque tempore qui natus fugiat id qui sit et ut</p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper iep-question select-question clearfix">
                    <h3 class="question-inline"><sc:Text ID="Text33" Field="504 Plan Question Title" runat="server" /></h3>
                    <div class="select-wrapper clearfix">
                        <div class="select-inner-wrapper clearfix">
                            <select>
                                <option value=""><sc:Text ID="Text34" Field="504 Option Default" runat="server" /></option>
                                <option value="has_iep"><sc:Text ID="Text35" Field="504 Option 1" runat="server" /></option>
                                <option value="lost_iep"><sc:Text ID="Text36" Field="504 Option 2" runat="server" /></option>
                                <option value="not_qualified"><sc:Text ID="Text37" Field="504 Option 3" runat="server" /></option>
                                <option value="no_iep"><sc:Text ID="Text38" Field="504 Option 4" runat="server" /></option>
                            </select>
                            <span><a href="REPLACE" class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a></span>
                            <div class="504-tooltip popover-container">
                                <p><span class="title">lorem ipsum soged</span> Unde non repudiandae eum nobis blanditiis doloribus quae ea. voluptatem voluptas a qui eligendi et qui perferendis. nihil aut quo molestiae omnis sunt ducimus cum illo beatae accusamus. nostrum voluptates error numquam omnis eligendi minima aperiam. aperiam quis quo deserunt quae occaecati ut dolores autem et esse</p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="form-actions">
                    <input class="button" type="submit" value="<sc:Text ID="Text39" Field="Next Button Text" runat="server" />">
                </div>
            </div>
            <!-- .profile-questions.step-2 -->

            <!-- END PARTIAL: profile-questions-step2b -->
        </div>
    </div>
</div>
