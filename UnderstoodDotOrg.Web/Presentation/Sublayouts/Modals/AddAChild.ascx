<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddAChild.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Modals.AddAChild" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="submit-question-modal modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <div class="modal-close close"><i class="icon-close"></i><span>Close</span></div>
            </div>
            <div class="modal-body">
                    <div class="container profile-questions flush step1">
                        <div class="row">
                            <div class="col col-22 offset-1">
                                <!-- BEGIN PARTIAL: profile-questions-step1 -->
                                <div class="profile-questions step-1">
                                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                                    <div class="profile-questions-child-wrapper">
                                        <!-- BEGIN PARTIAL: profile-questions-child -->
                                        <div class="question-wrapper clearfix">
                                            <p class="question with-margin">
                                                <sc:text field="Child Struggling Question Title" runat="server" />
                                            </p>
                                            <div class="radio-toggle-wrapper">
                                                <label class="button">
                                                    <asp:Literal ID="litBoy" runat="server"></asp:Literal>
                                                    <asp:RadioButton ID="uxBoy1" runat="server" GroupName="q1a" />

                                                </label>
                                                <label class="button">
                                                    <asp:Literal ID="litGirl" runat="server"></asp:Literal>
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

                                    <div class="form-actions">
                                        <a href="#" id="NextButtonStep1" runat="server" class="button next-button"></a>
                                    </div>
                                </div>
                                <!-- .profile-questions.step-1 -->

                                <!-- END PARTIAL: profile-questions-step1 -->
                            </div>
                        </div>
                    </div>

                    <div class="container profile-questions flush step2">
                        <div class="row">
                            <div class="col col-22 offset-1">
                                <!-- BEGIN PARTIAL: profile-questions-step2 -->
                                <div class="profile-questions step-2">
                                    <h2>
                                        <asp:Literal ID="uxFormTitle1" runat="server"></asp:Literal>
                                    </h2>

                                    <div class="question-wrapper clearfix short-bottom trouble-question">
                                        <h3 class="question-inline">
                                            <sc:text field="Child Nickname Question Title" runat="server" />

                                            <span class="question-description">
                                                <sc:text field="Child Nickname Question Text" runat="server" />
                                            </span>
                                        </h3>
                                        <asp:TextBox ID="ScreenNameTextBox" type="textfield" runat="server" />
                                    </div>
                                    <!-- .question-wrapper -->

                                    <div class="question-wrapper evaluation-question">
                                        <h3 class="question">
                                            <asp:Literal runat="server" ID="uxTroubleAreasTitle"></asp:Literal>
                                        </h3>
                                        <div class="checkboxes-wrapper">
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="q1a1" runat="server" />
                                                    <span>
                                                        <asp:Literal ID="uxQ1a1" runat="server"></asp:Literal>
                                                    </span>
                                                </label>
                                            </div>
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="q1a2" runat="server" />
                                                    <span>
                                                        <asp:Literal ID="uxQ1a2" runat="server"></asp:Literal>
                                                    </span>
                                                </label>
                                            </div>
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="q1a3" runat="server" />
                                                    <span>
                                                        <asp:Literal ID="uxQ1a3" runat="server"></asp:Literal>
                                                    </span>
                                                </label>
                                            </div>
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="q1a4" runat="server" />
                                                    <span>
                                                        <asp:Literal ID="uxQ1a4" runat="server"></asp:Literal>
                                                    </span>
                                                </label>
                                            </div>
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="q1a5" runat="server" />
                                                    <span>
                                                        <asp:Literal ID="uxQ1a5" runat="server"></asp:Literal>
                                                    </span>
                                                </label>
                                            </div>
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="q1a6" runat="server" />
                                                    <span>
                                                        <asp:Literal ID="uxQ1a6" runat="server"></asp:Literal>
                                                    </span>
                                                </label>
                                            </div>
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="q1a7" runat="server" />
                                                    <span>
                                                        <asp:Literal ID="uxQ1a7" runat="server"></asp:Literal>
                                                    </span>
                                                </label>
                                            </div>
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="q1a8" runat="server" />
                                                    <span>
                                                        <asp:Literal ID="uxQ1a8" runat="server"></asp:Literal>
                                                    </span>
                                                </label>
                                            </div>
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="q1a9" runat="server" />
                                                    <span>
                                                        <asp:Literal ID="uxQ1a9" runat="server"></asp:Literal>
                                                    </span>
                                                </label>
                                            </div>
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="q1a10" runat="server" />
                                                    <span>
                                                        <asp:Literal ID="uxQ1a10" runat="server"></asp:Literal>
                                                    </span>
                                                </label>
                                            </div>
                                        </div>
                                        <!-- .checkboxes-wrapper -->
                                    </div>
                                    <!-- .question-wrapper -->

                                    <div class="question-wrapper evaluation-question">
                                        <h3 class="question">
                                            <asp:Literal runat="server" ID="uxEvaluatedTitle"></asp:Literal>
                                        </h3>
                                        <div class="radio-toggle-wrapper">
                                            <label class="button">
                                                <asp:Literal ID="litYesButton" runat="server"></asp:Literal>
                                                <asp:RadioButton ID="q2a1" runat="server" GroupName="q2" CssClass="radio-toggle q2a1" />
                                            </label>
                                            <label class="button">
                                                <asp:Literal ID="litNoButton" runat="server"></asp:Literal>
                                                <asp:RadioButton ID="q2a2" runat="server" GroupName="q2" CssClass="radio-toggle q2a2" />
                                            </label>
                                            <label class="button">
                                                <asp:Literal ID="litInProgressText" runat="server"></asp:Literal>
                                                <asp:RadioButton ID="q2a3" runat="server" GroupName="q2" CssClass="radio-toggle q2a3" />
                                            </label>
                                        </div>
                                    </div>
                                    <!-- .question-wrapper -->

<%--                                    <div class="form-actions">
                                        <asp:Button ID="btnNext" CssClass="button" runat="server" OnClick="NextButton_Click" />
                                    </div>--%>
                                </div>
                                <!-- .profile-questions.step-2 -->
                                <!-- END PARTIAL: profile-questions-step2 -->
                            </div>
                        </div>
                    </div>

                    <div class="container profile-questions flush step3">
                        <div class="row">
                            <div class="col col-22 offset-1">
                                <!-- BEGIN PARTIAL: profile-questions-step2b -->
                                <div class="profile-questions step-2b">
                                    <h2>
                                        <%--<sc:text id="Text4" field="Form Title" runat="server" />--%>
                                        <asp:Literal ID="uxFormTitle2" runat="server"></asp:Literal>
                                    </h2>

                                    <div class="question-wrapper clearfix difficulties-question">
                                        <h3 class="question">
                                            <sc:text id="Text5" field="Learning Disorders Question Title" runat="server" />
                                        </h3>
                                        <p class="question-description">
                                            <sc:text id="Text6" field="Learning Disorders Question Text" runat="server" />

                                        </p>
                                        <div class="checkboxes-wrapper">
                                            <div class="column-left">

                                                <asp:ListView ID="uxLeftList" runat="server" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="ListItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="checkbox-wrapper">
                                                            <label>
                                                                <asp:CheckBox ID="diagnosis" runat="server" />
                                                                <span class="description">
                                                                    <%--<sc:text id="Text7" field="LD Area 1" runat="server" />--%>
                                                                    <%# Eval("Fields[Diagnosis Name]") %>
                                                                </span>
                                                                <span class="info-link">
                                                                    <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                                                </span>
                                                                <span class="popover-container">
                                                                    <span class="title title-block">
                                                                        <%--<sc:text id="Text39" field="LD Area 1 Mouse Over Title" runat="server" />--%>
                                                                        <%# Eval("Fields[Diagnosis Name]") %>
                                                                    </span>
                                                                    <%--<a href="REPLACE">Learn more</a>--%>
                                                                    <%# Eval("Fields[Diagnosis Description]") %>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </div>
                                            <!-- .checkboxes-left -->

                                            <div class="column-right">
                                                <asp:ListView ID="uxRightList" runat="server" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="ListItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="checkbox-wrapper">
                                                            <label>
                                                                <%--<input type="checkbox" name="q1a1">--%>
                                                                <asp:CheckBox ID="diagnosis" runat="server" />
                                                                <span class="description">
                                                                    <%--<sc:text id="Text7" field="LD Area 1" runat="server" />--%>
                                                                    <%# Eval("Fields[Diagnosis Name]") %>
                                                                </span>
                                                                <span class="info-link">
                                                                    <div class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></div>
                                                                </span>
                                                                <span class="popover-container">
                                                                    <span class="title title-block">
                                                                        <%--<sc:text id="Text39" field="LD Area 1 Mouse Over Title" runat="server" />--%>
                                                                        <%# Eval("Fields[Diagnosis Name]") %>
                                                                    </span>
                                                                    <%--<sc:text id="Text52" field="LD Area 1 Mouse Over" runat="server" />--%>
                                                                    <%--<a href="REPLACE">Learn more</a>--%>
                                                                    <%# Eval("Fields[Diagnosis Description]") %>
                                                                </span>
                                                            </label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </div>
                                            <!-- .checkboxes-right -->
                                        </div>
                                        <!-- .checkboxes-wrapper -->
                                    </div>
                                    <!-- .question-wrapper -->

                                    <div class="question-wrapper iep-question select-question clearfix">
                                        <p class="question-inline">
                                            <%--<sc:text id="Text26" field="IEP Question Title" runat="server" />--%>
                                            <asp:Literal ID="uxIEPquestion" runat="server"></asp:Literal>
                                        </p>
                                        <div class="select-wrapper clearfix">
                                            <div class="select-inner-wrapper clearfix">
                                                <asp:DropDownList ID="uxIEPStatus" runat="server" name="iepstatus"></asp:DropDownList>
                                                <span>
                                                    <a href="REPLACE" class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a>
                                                </span>
                                                <div class="iep-tooltip popover-container">
                                                    <p><span class="title">lorem ipsum soged</span> Et beatae itaque quod est voluptatem eligendi. necessitatibus harum consectetur veritatis illum iste autem saepe. ducimus quasi eaque tempore qui natus fugiat id qui sit et ut</p>
                                                </div>
                                            </div>
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
                                                <asp:DropDownList ID="ux504Status" runat="server" name="iepstatus"></asp:DropDownList>
                                                <span>
                                                    <a href="REPLACE" class="icon-wrapper popover-link" data-popover-placement="bottom"><i class="icon-tooltip">&nbsp;</i></a>
                                                </span>
                                                <div class="504-tooltip popover-container">
                                                    <p><span class="title">lorem ipsum soged</span> Unde non repudiandae eum nobis blanditiis doloribus quae ea. voluptatem voluptas a qui eligendi et qui perferendis. nihil aut quo molestiae omnis sunt ducimus cum illo beatae accusamus. nostrum voluptates error numquam omnis eligendi minima aperiam. aperiam quis quo deserunt quae occaecati ut dolores autem et esse</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- .question-wrapper -->

                                    <div class="form-actions">
                                        <asp:Button ID="NextButton" runat="server" type="submit" OnClick="NextButton_Click" />
                                        <%--<button id="NextButton" onserverclick="NextButton_Click" class="button" runat="server"></button>
                                        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />--%>
                                        <%--<asp:LinkButton ID="NextButton" OnClick="NextButton_Click" runat="server"></asp:LinkButton>--%>
                                        <!--<input class="button" type="submit" value="Next" runat="server" />">-->
                                    </div>
                                </div>
                                <!-- .profile-questions.step-2 -->

                                <!-- END PARTIAL: profile-questions-step2b -->
                            </div>
                        </div>
                    </div>
            </div>
        </div>
        <!-- .modal-content -->
    </div>
    <!-- .modal-dialog -->
</div>
<!-- modal -->
<script type="text/javascript">
    $(document).ready(function () {
        $(".step2").hide();
        $(".step3").hide();
        $(".next-button").click(function () {
            $(".step1").hide();
            $(".step2").show();
            return false;
        });
        $(".q2a1").click(function () {
            $(".step2").hide();
            $(".q2a1").attr("checked", true)
            $(".q2a2").removeAttr("checked")
            $(".q2a3").removeAttr("checked")
            $(".step3").show();
        });
        $(".q2a2").click(function () {
            $(".q2a2").attr("checked", true)
            $(".q2a1").removeAttr("checked")
            $(".q2a3").removeAttr("checked")
        });
        $(".q2a3").click(function () {
            $(".q2a3").attr("checked", true)
            $(".q2a1").removeAttr("checked")
            $(".q2a2").removeAttr("checked")
        });
    });
</script>
