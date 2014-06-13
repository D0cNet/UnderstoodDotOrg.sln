<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepThree.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepThree" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>
                        <sc:Text ID="Text1" Field="Header Title" runat="server" />
                    </h1>
                    <p class="subtitle">
                        <sc:Text ID="Text2" Field="Header Text" runat="server" />
                    </p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header">
                            <sc:Text ID="Text3" Field="Header Progress Bar Text" runat="server" />
                        </div>
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
                <h2>
                    <%--<sc:text id="Text4" field="Form Title" runat="server" />--%>
                    <asp:Literal ID="uxFormTitle" runat="server"></asp:Literal>
                </h2>

                <div class="question-wrapper clearfix difficulties-question">
                    <asp:CustomValidator ID="valDiagnosis" runat="server" ClientValidationFunction="ValidateRadioButtons" CssClass="validationerror"></asp:CustomValidator>

                    <h3 class="question">
                        <sc:Text ID="Text5" Field="Learning Disorders Question Title" runat="server" />
                    </h3>
                    <p class="question-description">
                        <sc:Text ID="Text6" Field="Learning Disorders Question Text" runat="server" />

                    </p>
                    <div class="checkboxes-wrapper">
                        <div class="column-left">

                            <asp:ListView ID="uxLeftList" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child.ChildDiagnosisItem" OnItemDataBound="ListItemDataBound">
                                <ItemTemplate>
                                    <div class="checkbox-wrapper">
                                        <label>
                                            <%--<input type="checkbox" name="q1a1">--%>
                                            <asp:CheckBox ID="diagnosis" runat="server" />
                                            <span class="description">
                                                <%--<sc:text id="Text7" field="LD Area 1" runat="server" />--%>
                                                <%# Item.DiagnosisName %>
                                            </span>
                                            <asp:HiddenField ID="diagnosisHidden" runat="server" />
                                            <span class="info-link">
                                                <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                            </span>
                                            <span class="popover-container">
                                                <span class="title title-block">
                                                    <%--<sc:text id="Text39" field="LD Area 1 Mouse Over Title" runat="server" />--%>
                                                    <%# Item.DiagnosisName %>
                                                </span>
                                                <%--<sc:text id="Text52" field="LD Area 1 Mouse Over" runat="server" />--%>
                                                <%--<a href="REPLACE">Learn more</a>--%>
                                                <%# Item.DiagnosisDescription %>
                                            </span>
                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>

                            <%--  <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a1">
                                    <span class="description">
                                        <sc:text id="Text7" field="LD Area 1" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text39" field="LD Area 1 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text52" field="LD Area 1 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a2">
                                    <span class="description">
                                        <sc:text id="Text8" field="LD Area 2" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text40" field="LD Area 2 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text53" field="LD Area 2 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a3">
                                    <span class="description">
                                        <sc:text id="Text9" field="LD Area 3" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text41" field="LD Area 3 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text54" field="LD Area 3 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a4">
                                    <span class="description">
                                        <sc:text id="Text10" field="LD Area 4" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text42" field="LD Area 4 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text55" field="LD Area 4 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a5">
                                    <span class="description">
                                        <sc:text id="Text11" field="LD Area 5" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text43" field="LD Area 5 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text56" field="LD Area 5 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a6">
                                    <span class="description">
                                        <sc:text id="Text12" field="LD Area 6" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text44" field="LD Area 6 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text57" field="LD Area 6 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a7">
                                    <span class="description">
                                        <sc:text id="Text13" field="LD Area 7" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text45" field="LD Area 7 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text58" field="LD Area 7 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>--%>
                        </div>
                        <!-- .checkboxes-left -->

                        <div class="column-right">
                            <asp:ListView ID="uxRightList" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child.ChildDiagnosisItem" OnItemDataBound="ListItemDataBound">
                                <ItemTemplate>
                                    <div class="checkbox-wrapper">
                                        <label>
                                            <%--<input type="checkbox" name="q1a1">--%>
                                            <asp:CheckBox ID="diagnosis" runat="server" />
                                            <span class="description">
                                                <%--<sc:text id="Text7" field="LD Area 1" runat="server" />--%>
                                                <%# Item.DiagnosisName %>
                                            </span>
                                            <asp:HiddenField ID="diagnosisHidden" runat="server" />
                                            <span class="info-link">
                                                <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                            </span>
                                            <span class="popover-container">
                                                <span class="title title-block">
                                                    <%--<sc:text id="Text39" field="LD Area 1 Mouse Over Title" runat="server" />--%>
                                                    <%# Item.DiagnosisName %>
                                                </span>
                                                <%--<sc:text id="Text52" field="LD Area 1 Mouse Over" runat="server" />--%>
                                                <%--<a href="REPLACE">Learn more</a>--%>
                                                <%# Item.DiagnosisDescription %>
                                            </span>
                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>

                            <%-- <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a8">
                                    <span class="description">
                                        <sc:text id="Text14" field="LD Area 8" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text46" field="LD Area 8 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text59" field="LD Area 8 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a9">
                                    <span class="description">
                                        <sc:text id="Text15" field="LD Area 9" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text47" field="LD Area 9 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text60" field="LD Area 9 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a10">
                                    <span class="description">
                                        <sc:text id="Text16" field="LD Area 10" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text48" field="LD Area 10 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text61" field="LD Area 10 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a11">
                                    <span class="description">
                                        <sc:text id="Text17" field="LD Area 11" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text49" field="LD Area 11 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text62" field="LD Area 11 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a12">
                                    <span class="description">
                                        <sc:text id="Text18" field="LD Area 12" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text50" field="LD Area 12 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text63" field="LD Area 12 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a13">
                                    <span class="description">
                                        <sc:text id="Text19" field="LD Area 13" runat="server" />
                                    </span>
                                    <span class="info-link">
                                        <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                    </span>
                                    <span class="popover-container"><span class="title title-block">
                                        <sc:text id="Text51" field="LD Area 13 Mouse Over Title" runat="server" />
                                    </span>
                                        <sc:text id="Text64" field="LD Area 13 Mouse Over" runat="server" />
                                        <a href="REPLACE">Learn more</a></span>
                                </label>
                            </div>--%>
                        </div>
                        <!-- .checkboxes-right -->
                    </div>
                    <!-- .checkboxes-wrapper -->
                </div>
                <!-- .question-wrapper -->

                <%--<div class="column-wrapper clearfix">
                    <div class="column-left">
                        <div class="question-wrapper focus-question">
                            <h3 class="question">
                                <sc:text id="Text20" field="Attention And Focus Question Title" runat="server" />
                            </h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span>
                                            <sc:text id="Text21" field="AF Area 1" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span>
                                            <sc:text id="Text22" field="AF Area 1" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span>
                                            <sc:text id="Text23" field="AF Area 1" runat="server" />
                                        </span>
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
                            <h3 class="question">
                                <sc:text id="Text24" field="Other Disorder Question Title" runat="server" />
                            </h3>
                            <div class="checkboxes-wrapper">
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span>
                                            <sc:text id="Text25" field="OD Area 1" runat="server" />
                                        </span>
                                    </label>
                                </div>
                            </div>
                            <!-- .checkboxes-wrapper -->
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-left -->
                </div>--%>
                <!-- .column-wrapper -->

                <div class="question-wrapper iep-question select-question clearfix">
                    <p class="question-inline">
                        <%--<sc:text id="Text26" field="IEP Question Title" runat="server" />--%>
                        <asp:Literal ID="uxIEPquestion" runat="server"></asp:Literal>
                    </p>
                    <div class="select-wrapper clearfix">
                        <div class="select-inner-wrapper clearfix">
                            <%--<select>
                                <option value="">
                                    <sc:text id="Text27" field="IEP Option Default" runat="server" />
                                </option>
                                <option value="has_iep">
                                    <sc:text id="Text28" field="IEP Option 1" runat="server" />
                                </option>
                                <option value="lost_iep">
                                    <sc:text id="Text29" field="IEP Option 2" runat="server" />
                                </option>
                                <option value="not_qualified">
                                    <sc:text id="Text30" field="IEP Option 3" runat="server" />
                                </option>
                                <option value="coming_up">
                                    <sc:text id="Text31" field="IEP Option 4" runat="server" />
                                </option>
                                <option value="no_iep">
                                    <sc:text id="Text32" field="IEP Option 5" runat="server" />
                                </option>
                            </select>--%>
                            <asp:DropDownList ID="uxIEPStatus" runat="server" name="iepstatus"></asp:DropDownList>
                            <span>
                                <a href="REPLACE" class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a>
                            </span>

                            <div class="iep-tooltip popover-container">
                                <p><span class="title">lorem ipsum soged</span> Et beatae itaque quod est voluptatem eligendi. necessitatibus harum consectetur veritatis illum iste autem saepe. ducimus quasi eaque tempore qui natus fugiat id qui sit et ut</p>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="valIEP" runat="server" ControlToValidate="uxIEPStatus" InitialValue="" CssClass="validationerror"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper iep-question select-question clearfix">
                    <h3 class="question-inline">
                        <%--<sc:text id="Text33" field="Section 504 Plan Question Title" runat="server" />--%>
                        <asp:Literal ID="ux504question" runat="server"></asp:Literal>
                    </h3>
                    <div class="select-wrapper clearfix">
                        <div class="select-inner-wrapper clearfix">
                            <%--<select>
                                <option value="">
                                    <sc:text id="Text34" field="504 Option Default" runat="server" />
                                </option>
                                <option value="has_iep">
                                    <sc:text id="Text35" field="504 Option 1" runat="server" />
                                </option>
                                <option value="lost_iep">
                                    <sc:text id="Text36" field="504 Option 2" runat="server" />
                                </option>
                                <option value="not_qualified">
                                    <sc:text id="Text37" field="504 Option 3" runat="server" />
                                </option>
                                <option value="no_iep">
                                    <sc:text id="Text38" field="504 Option 4" runat="server" />
                                </option>
                            </select>--%>
                            <asp:DropDownList ID="ux504Status" runat="server" name="iepstatus"></asp:DropDownList>
                            <span>
                                <a href="REPLACE" class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a>
                            </span>
                            <div class="504-tooltip popover-container">
                                <p><span class="title">lorem ipsum soged</span> Unde non repudiandae eum nobis blanditiis doloribus quae ea. voluptatem voluptas a qui eligendi et qui perferendis. nihil aut quo molestiae omnis sunt ducimus cum illo beatae accusamus. nostrum voluptates error numquam omnis eligendi minima aperiam. aperiam quis quo deserunt quae occaecati ut dolores autem et esse</p>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="val504" runat="server" ControlToValidate="ux504Status" InitialValue="" CssClass="validationerror"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="form-actions">
                    <asp:Button ID="NextButton" CssClass="button" runat="server" OnClick="NextButton_Click" />
                    <!--<input class="button" type="submit" value="Next" runat="server" />">-->
                </div>
            </div>
            <!-- .profile-questions.step-2 -->

            <!-- END PARTIAL: profile-questions-step2b -->
        </div>
    </div>
</div>
