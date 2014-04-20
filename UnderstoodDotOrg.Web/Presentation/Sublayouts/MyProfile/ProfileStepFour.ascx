<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepFour.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepFour" %>

<div class="container profile-questions flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>
                        <sc:text id="Text1" field="Header Title" runat="server" />
                    </h1>
                    <p class="subtitle">
                        <sc:text id="Text2" field="Header Text" runat="server" />
                    </p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper">
                        <div class="progress-header">
                            <sc:text id="Text3" field="Header Progress Bar Text" runat="server" />
                        </div>
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
                            <span class="done step">
                                <sc:text id="Text4" field="Header Progress Bar Done Text" runat="server" />
                            </span>
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
                <h2>
                    <sc:text id="Text5" field="Form Title" runat="server" />
                </h2>

                <div class="question-wrapper clearfix school-issues-question">
                    <h3 class="question">
                        <sc:text id="Text6" field="School Issues Question Title" runat="server" />
                    </h3>
                    <div class="checkboxes-wrapper">

                        <div class="column-left">
                            <asp:ListView runat="server" ID="uxSchoolLeft" ItemType="Sitecore.Data.Items.Item">
                                <ItemTemplate>
                                    <div class="checkbox-wrapper">
                                        <label>
                                            <%--<input type="checkbox" name="q1a1">--%>
                                            <asp:CheckBox ID="issue" runat="server" />
                                            <span>
                                                <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                <%# Eval("Fields[Interest Name]") %>
                                            </span>
                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                            <%--<div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a1">
                                    <span>
                                        <sc:text id="Text7" field="SI Area 1" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a2">
                                    <span>
                                        <sc:text id="Text8" field="SI Area 2" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a3">
                                    <span>
                                        <sc:text id="Text9" field="SI Area 3" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a4">
                                    <span>
                                        <sc:text id="Text10" field="SI Area 4" runat="server" />
                                    </span>
                                </label>
                            </div>--%>
                        </div>
                        <!-- .checkboxes-left -->

                        <div class="column-right">
                            <asp:ListView runat="server" ID="uxSchoolRight" ItemType="Sitecore.Data.Items.Item">
                                <ItemTemplate>
                                    <div class="checkbox-wrapper">
                                        <label>
                                            <%--<input type="checkbox" name="q1a1">--%>
                                            <asp:CheckBox ID="issue" runat="server" />
                                            <span>
                                                <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                <%# Eval("Fields[Interest Name]") %>
                                            </span>
                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>

                            <%--<div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a8">
                                    <span>
                                        <sc:text id="Text11" field="SI Area 5" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a9">
                                    <span>
                                        <sc:text id="Text12" field="SI Area 6" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a10">
                                    <span>
                                        <sc:text id="Text13" field="SI Area 7" runat="server" />
                                    </span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label>
                                    <input type="checkbox" name="q1a11">
                                    <span>
                                        <sc:text id="Text14" field="SI Area 8" runat="server" />
                                    </span>
                                </label>
                            </div>--%>
                        </div>
                        <!-- .checkboxes-right -->
                    </div>
                    <!-- .checkboxes-wrapper -->
                </div>
                <!-- .question-wrapper -->

                <div class="column-wrapper clearfix">
                    <div class="column-left">
                        <div class="question-wrapper help-question">
                            <h3 class="question">
                                <sc:text id="Text15" field="Ways To Help Question Title" runat="server" />
                            </h3>
                            <div class="checkboxes-wrapper">
                                <asp:ListView runat="server" ID="uxWaysToHelp" ItemType="Sitecore.Data.Items.Item">
                                    <ItemTemplate>
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <%--<input type="checkbox" name="q1a1">--%>
                                                <asp:CheckBox ID="issue" runat="server" />
                                                <span>
                                                    <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                    <%# Eval("Fields[Interest Name]") %>
                                                </span>
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>

                                <%--<div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a1">
                                        <span>
                                            <sc:text id="Text16" field="WTH Area 1" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a2">
                                        <span>
                                            <sc:text id="Text17" field="WTH Area 2" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a3">
                                        <span>
                                            <sc:text id="Text18" field="WTH Area 3" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a4">
                                        <span>
                                            <sc:text id="Text19" field="WTH Area 4" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q2a5">
                                        <span>
                                            <sc:text id="Text20" field="WTH Area 5" runat="server" />
                                        </span>
                                    </label>
                                </div>--%>
                            </div>
                            <!-- .checkboxes-wrapper -->
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->

                    <div class="column-right">
                        <div class="question-wrapper home-life-question">
                            <h3 class="question">
                                <sc:text id="Text21" field="Home Life Question Title" runat="server" />
                            </h3>
                            <div class="checkboxes-wrapper">
                                <asp:ListView runat="server" ID="uxHomeLife" ItemType="Sitecore.Data.Items.Item">
                                    <ItemTemplate>
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <%--<input type="checkbox" name="q1a1">--%>
                                                <asp:CheckBox ID="issue" runat="server" />
                                                <span>
                                                    <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                    <%# Eval("Fields[Interest Name]") %>
                                                </span>
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <%--<div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a1">
                                        <span>
                                            <sc:text id="Text22" field="HL Area 1" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a2">
                                        <span>
                                            <sc:text id="Text23" field="HL Area 2" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a3">
                                        <span>
                                            <sc:text id="Text24" field="HL Area 3" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q3a4">
                                        <span>
                                            <sc:text id="Text25" field="HL Area 4" runat="server" />
                                        </span>
                                    </label>
                                </div>--%>
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
                            <h3 class="question">
                                <sc:text id="Text26" field="Growing Up Question Title" runat="server" />
                            </h3>
                            <div class="checkboxes-wrapper">
                                <asp:ListView runat="server" ID="uxGrowingUp" ItemType="Sitecore.Data.Items.Item">
                                    <ItemTemplate>
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <%--<input type="checkbox" name="q1a1">--%>
                                                <asp:CheckBox ID="issue" runat="server" />
                                                <span>
                                                    <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                    <%# Eval("Fields[Interest Name]") %>
                                                </span>
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <%--<div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a1">
                                        <span>
                                            <sc:text id="Text27" field="GU Area 1" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a2">
                                        <span>
                                            <sc:text id="Text28" field="GU Area 2" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a3">
                                        <span>
                                            <sc:text id="Text29" field="GU Area 3" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a4">
                                        <span>
                                            <sc:text id="Text30" field="GU Area 4" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q4a5">
                                        <span>
                                            <sc:text id="Text31" field="GU Area 5" runat="server" />
                                        </span>
                                    </label>
                                </div>--%>
                            </div>
                            <!-- .checkboxes-wrapper -->
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->

                    <div class="column-right">
                        <div class="question-wrapper social-emotional-question">
                            <h3 class="question">
                                <sc:text id="Text32" field="Social Emotional Issues Question Title" runat="server" />
                            </h3>
                            <div class="checkboxes-wrapper">
                                <asp:ListView runat="server" ID="uxSocialEmotional" ItemType="Sitecore.Data.Items.Item">
                                    <ItemTemplate>
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <%--<input type="checkbox" name="q1a1">--%>
                                                <asp:CheckBox ID="issue" runat="server" />
                                                <span>
                                                    <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                    <%# Eval("Fields[Interest Name]") %>
                                                </span>
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <%--<div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q5a1">
                                        <span>
                                            <sc:text id="Text33" field="SEI Area 1" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q5a2">
                                        <span>
                                            <sc:text id="Text34" field="SEI Area 2" runat="server" />
                                        </span>
                                    </label>
                                </div>
                                <div class="checkbox-wrapper">
                                    <label>
                                        <input type="checkbox" name="q5a3">
                                        <span>
                                            <sc:text id="Text35" field="SEI Area 3" runat="server" />
                                        </span>
                                    </label>
                                </div>--%>
                            </div>
                            <!-- .checkboxes-wrapper -->
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->
                </div>
                <!-- .column-wrapper -->

                <div class="question-wrapper journey-question">
                    <h3 class="question">
                        <sc:text id="Text36" field="Where Are You Question Title" runat="server" />
                    </h3>
                    <div class="radios-wrapper">
                        <asp:ListView runat="server" ID="uxJourney" ItemType="Sitecore.Data.Items.Item">
                            <ItemTemplate>
                                <div class="radio-wrapper">
                                    <label>
                                        <%--<input type="radio" name="q6" value="a1">--%>
                                        <asp:RadioButton runat="server" ID="journey" GroupName="journey" />
                                        <span>
                                            <%--<sc:text id="Text37" field="WAY Area 1" runat="server" />--%>
                                            <%# Eval("Fields[Interest Name]") %>
                                        </span>
                                    </label>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>

                        <%--<div class="radio-wrapper">
                            <label>
                                <input type="radio" name="q6" value="a1">
                                <span>
                                    <sc:text id="Text37" field="WAY Area 1" runat="server" />
                                </span>
                            </label>
                        </div>
                        <div class="radio-wrapper">
                            <label>
                                <input type="radio" name="q6" value="a2">
                                <span>
                                    <sc:text id="Text38" field="WAY Area 2" runat="server" />
                                </span>
                            </label>
                        </div>
                        <div class="radio-wrapper">
                            <label>
                                <input type="radio" name="q6" value="a3">
                                <span>
                                    <sc:text id="Text39" field="WAY Area 3" runat="server" />
                                </span>
                            </label>
                        </div>--%>
                    </div>
                    <!-- .radios-wrapper -->
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper role-question">
                    <p class="question with-margin">
                        <sc:text id="Text40" field="What Is Your Role Question Title" runat="server" />
                    </p>
                    <div class="radio-toggle-wrapper">
                        <label class="button">
                            <%--<sc:text id="Text41" field="Mom Button Text" runat="server" />
                            <input name="q7" value="boy" type="radio">--%>
                            <asp:Literal ID="uxMother" runat="server"></asp:Literal>
                            <asp:RadioButton ID="uxMotherButton" runat="server" GroupName="parent" />
                        </label>
                        <label class="button">
                            <%--<sc:text id="Text42" field="Dad Button Text" runat="server" />
                            <input name="q7" value="girl" type="radio">--%>
                            <asp:Literal ID="uxFather" runat="server"></asp:Literal>
                            <asp:RadioButton ID="uxFatherButton" runat="server" GroupName="parent" />
                        </label>
                    </div>
                    <label class="inline">
                        <asp:DropDownList ID="uxParentList" runat="server">
                        </asp:DropDownList>
                        <%--<select name="q7b">
                            <option value="">
                                <sc:text id="Text43" field="Other Field Default" runat="server" />
                            </option>
                            <option value="grandparent">
                                <sc:text id="Text44" field="Other Field 1" runat="server" />
                            </option>
                            <option value="aunt_uncle">
                                <sc:text id="Text45" field="Other Field 2" runat="server" />
                            </option>
                            <option value="teacher">
                                <sc:text id="Text46" field="Other Field 3" runat="server" />
                            </option>
                            <option value="medical">
                                <sc:text id="Text47" field="Other Field 4" runat="server" />
                            </option>
                            <option value="caregiver">
                                <sc:text id="Text48" field="Other Field 5" runat="server" />
                            </option>
                            <option value="other">
                                <sc:text id="Text49" field="Other Field 6" runat="server" />
                            </option>
                        </select>--%>
                    </label>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper connect-question">
                    <p class="question">
                        <sc:text id="Text50" field="Connect Question Title" runat="server" />

                        <span class="question-description">
                            <sc:text id="Text51" field="Connect Question Text" runat="server" />
                        </span>
                    </p>
                    <div class="textfields-wrapper">
                        <div class="textfield-wrapper">
                            <asp:TextBox type="textfield" ID="ScreenNameTextField" runat="server" />
                            <!--input type="textfield" name="connect-1" placeholder="Screen Name"-->
                            <span class="popover-trigger-container"><a class="popover-link" href="REPLACE">
                                <sc:text id="Text52" field="Why Do We Ask Text 1" runat="server" />
                            </a></span>
                            <div class="popover-container">
                                <p>
                                    <span class="title">
                                        <sc:text id="Text53" field="Why Do We Ask Subtext Header 1" runat="server" />
                                    </span>
                                    <sc:text id="Text54" field="Why Do We Ask Subtext 1" runat="server" />
                                </p>
                            </div>
                        </div>
                        <div class="textfield-wrapper">
                            <asp:TextBox type="textfield" ID="ZipCodeTextField" runat="server" />
                            <!--input type="textfield" name="connect-2" placeholder="Zip Code"-->
                            <span class="popover-trigger-container"><a class="popover-link" href="REPLACE">
                                <sc:text id="Text55" field="Why Do We Ask Text 2" runat="server" />
                            </a></span>
                            <div class="popover-container">
                                <p>
                                    <span class="title">
                                        <sc:text id="Text56" field="Why Do We Ask Subtext Header 2" runat="server" />
                                    </span>
                                    <sc:text id="Text57" field="Why Do We Ask Subtext 2" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="no-uniform-wrapper">
                        <label>
                            <input class="no-uniform" type="checkbox">
                            <span>
                                <sc:text id="Text58" field="Interest Text" runat="server" />
                            </span>
                        </label>
                        <label>
                            <input class="no-uniform" type="checkbox">
                            <span>
                                <sc:text id="Text59" field="Personalized Newsletter Text" runat="server" />
                            </span>
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
