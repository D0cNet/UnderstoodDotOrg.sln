<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepFour.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepFour" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container profile-questions flush" id="divProgressBar" runat="server">
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
                        <asp:Literal ID="uxErrorMessage" runat="server" Visible="false"></asp:Literal>
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
                            <asp:ListView runat="server" ID="uxSchoolLeft" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="ListInterestDataBound">
                                <ItemTemplate>
                                    <div class="checkbox-wrapper">
                                        <label>
                                            <%--<input type="checkbox" name="q1a1">--%>
                                            <asp:CheckBox ID="interest" runat="server" />
                                            <span>
                                                <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                <%# Eval("Fields[Interest Name]") %>
                                            </span>
                                            <asp:HiddenField ID="interestHidden" runat="server" />
                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <!-- .checkboxes-left -->

                        <div class="column-right">
                            <asp:ListView runat="server" ID="uxSchoolRight" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="ListInterestDataBound">
                                <ItemTemplate>
                                    <div class="checkbox-wrapper">
                                        <label>
                                            <%--<input type="checkbox" name="q1a1">--%>
                                            <asp:CheckBox ID="interest" runat="server" />
                                            <span>
                                                <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                <%# Eval("Fields[Interest Name]") %>
                                            </span>
                                            <asp:HiddenField ID="interestHidden" runat="server" />
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

                <div class="column-wrapper clearfix">
                    <div class="column-left">
                        <div class="question-wrapper help-question">
                            <h3 class="question">
                                <sc:text id="Text15" field="Ways To Help Question Title" runat="server" />
                            </h3>
                            <div class="checkboxes-wrapper">
                                <asp:ListView runat="server" ID="uxWaysToHelp" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="ListInterestDataBound">
                                    <ItemTemplate>
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <%--<input type="checkbox" name="q1a1">--%>
                                                <asp:CheckBox ID="interest" runat="server" />
                                                <span>
                                                    <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                    <%# Eval("Fields[Interest Name]") %>
                                                </span>
                                                <asp:HiddenField ID="interestHidden" runat="server" />
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
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
                                <asp:ListView runat="server" ID="uxHomeLife" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="ListInterestDataBound">
                                    <ItemTemplate>
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <%--<input type="checkbox" name="q1a1">--%>
                                                <asp:CheckBox ID="interest" runat="server" />
                                                <span>
                                                    <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                    <%# Eval("Fields[Interest Name]") %>
                                                </span>
                                                <asp:HiddenField ID="interestHidden" runat="server" />
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
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
                                <asp:ListView runat="server" ID="uxGrowingUp" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="ListInterestDataBound">
                                    <ItemTemplate>
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <%--<input type="checkbox" name="q1a1">--%>
                                                <asp:CheckBox ID="interest" runat="server" />
                                                <span>
                                                    <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                    <%# Eval("Fields[Interest Name]") %>
                                                </span>
                                                <asp:HiddenField ID="interestHidden" runat="server" />
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
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
                                <asp:ListView runat="server" ID="uxSocialEmotional" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="ListInterestDataBound">
                                    <ItemTemplate>
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <%--<input type="checkbox" name="q1a1">--%>
                                                <asp:CheckBox ID="interest" runat="server" />
                                                <span>
                                                    <%--<sc:text id="Text7" field="SI Area 1" runat="server" />--%>
                                                    <%# Eval("Fields[Interest Name]") %>
                                                </span>
                                                <asp:HiddenField ID="interestHidden" runat="server" />
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
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
                        <asp:ListView runat="server" ID="uxJourney" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="ListJourneyDataBound">
                            <ItemTemplate>
                                <div class="radio-wrapper radiobuttonJourney">
                                    <label>
                                        <%--<input type="radio" name="q6" value="a1">--%>
                                        <asp:RadioButton runat="server" ID="interest" GroupName="journey"/>
                                        <span>
                                            <%--<sc:text id="Text37" field="WAY Area 1" runat="server" />--%>
                                            <%# Eval("Fields[Interest Name]") %>
                                        </span>
                                        <asp:HiddenField ID="interestHidden" runat="server" />
                                    </label>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
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
                            <asp:RadioButton ID="uxMotherButton" runat="server" GroupName="parent" EnableViewState="true"/>
                        </label>
                        <label class="button">
                            <%--<sc:text id="Text42" field="Dad Button Text" runat="server" />
                            <input name="q7" value="girl" type="radio">--%>
                            <asp:Literal ID="uxFather" runat="server"></asp:Literal>
                            <asp:RadioButton ID="uxFatherButton" runat="server" GroupName="parent" EnableViewState="true" />
                        </label>
                    </div>
                    <label class="inline">
                        <asp:DropDownList ID="uxParentList" runat="server">
                        </asp:DropDownList>
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
                            <asp:CheckBox ID="cbConnections" CssClass="no-uniform" runat="server" />
                            <span>
                                <sc:text id="Text58" field="Interest Text" runat="server" />
                            </span>
                        </label>
                        <label>
                            <asp:CheckBox ID="cbNewsLetter" CssClass="no-uniform" runat="server" />
                            <span>
                                <sc:text id="Text59" field="Personalized Newsletter Text" runat="server" />
                            </span>
                        </label>
                    </div>
                </div>
                <!-- .connect-question -->

                <div class="form-actions">
                    <asp:Button CssClass="button" ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" />
                    <!--input class="button" type="submit" value="Submit"-->
                </div>
            </div>
            <!-- .profile-questions.step-3 -->

            <!-- END PARTIAL: profile-questions-step3 -->
        </div>
    </div>
</div>
