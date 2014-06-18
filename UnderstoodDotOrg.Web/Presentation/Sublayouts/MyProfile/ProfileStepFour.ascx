<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepFour.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepFour" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container profile-questions-header-container flush" id="divProgressBar" runat="server">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left rs_read_this">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>
                        <sc:Text ID="Text1" Field="Header Title" runat="server" />
                    </h1>
                    <p class="subtitle">
                        <sc:Text ID="Text2" Field="Header Text" runat="server" />
                        <asp:Literal ID="uxErrorMessage" runat="server" Visible="false"></asp:Literal>
                    </p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper rs_read_this">
                        <div class="progress-header">
                            <sc:Text ID="Text3" Field="Header Progress Bar Text" runat="server" />
                        </div>
                        <div class="progress-bar step-3 rs_skip">
                            <span class="step-1 step" aria-hidden="true" role="presentation">1</span>
                            <span class="step-1-progress progress">
                                <span class="progress-spacer">
                                    <span class="progress-percent"></span>
                                </span>
                            </span>
                            <span class="step-2 step" aria-hidden="true" role="presentation">2</span>
                            <span class="step-2-progress progress">
                                <span class="progress-spacer">
                                    <span class="progress-percent"></span>
                                </span>
                            </span>
                            <span class="step-3 step" aria-hidden="true" role="presentation">3</span>
                            <span class="step-3-progress progress">
                                <span class="progress-spacer">
                                    <span class="progress-percent"></span>
                                </span>
                            </span>
                            <span class="done step" aria-hidden="true" role="presentation">Done</span>
                        </div>
                    </div>
                    <!-- .progress-bar-wrapper -->

                    <!-- END PARTIAL: profile-questions-header-right -->
                </div>
            </header>
        </div>
    </div>
</div>

<div class="container profile-questions-container flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: profile-questions-step3 -->
            <div class="profile-questions step-3 skiplink-content" aria-role="main">
                <h2>
                    <sc:Text ID="Text5" Field="Form Title" runat="server" />
                </h2>

                <div class="question-wrapper clearfix school-issues-question rs_read_this">
                    <fieldset>
                        <legend class="question">
                            <sc:Text ID="Text6" Field="School Issues Question Title" runat="server" />
                        </legend>
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
                    </fieldset>
                </div>
                <!-- .question-wrapper -->

                <div class="column-wrapper clearfix">
                    <div class="column-left">
                        <div class="question-wrapper help-question rs_read_this">
                            <fieldset>
                                <legend class="question">
                                    <sc:Text ID="Text15" Field="Ways To Help Question Title" runat="server" />
                                </legend>
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
                            </fieldset>
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->

                    <div class="column-right">
                        <div class="question-wrapper home-life-question rs_read_this">
                            <fieldset>
                                <legend class="question">
                                    <sc:Text ID="Text21" Field="Home Life Question Title" runat="server" />
                                </legend>
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
                            </fieldset>
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->
                </div>
                <!-- .column-wrapper -->

                <div class="column-wrapper clearfix">
                    <div class="column-left">
                        <div class="question-wrapper growing-up-question rs_read_this">
                            <fieldset>
                                <legend class="question">
                                    <sc:Text ID="Text26" Field="Growing Up Question Title" runat="server" />
                                </legend>
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
                            </fieldset>
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->

                    <div class="column-right">
                        <div class="question-wrapper social-emotional-question rs_read_this">
                            <fieldset>
                                <legend class="question">
                                    <sc:Text ID="Text32" Field="Social Emotional Issues Question Title" runat="server" />
                                </legend>
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
                            </fieldset>
                        </div>
                        <!-- .question-wrapper -->
                    </div>
                    <!-- .column-right -->
                </div>
                <!-- .column-wrapper -->

                <div class="question-wrapper journey-question rs_read_this">
                    <fieldset>
                        <legend class="question">
                            <sc:Text ID="Text36" Field="Where Are You Question Title" runat="server" />
                        </legend>
                        <div class="radios-wrapper">
                            <asp:ListView runat="server" ID="uxJourney" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="ListJourneyDataBound">
                                <ItemTemplate>
                                    <div class="radio-wrapper radiobuttonJourney">
                                        <label>
                                            <%--<input type="radio" name="q6" value="a1">--%>
                                            <asp:RadioButton runat="server" ID="interest" GroupName="journey" />
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
                    </fieldset>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper role-question clearfix rs_read_this">
                    <fieldset>
                        <legend class="question with-margin">
                            <sc:Text ID="Text40" Field="What Is Your Role Question Title" runat="server" />
                        </legend>
                        <div class="radio-toggle-wrapper">
                            <label class="button gray">
                                <%--<sc:text id="Text41" field="Mom Button Text" runat="server" />
                            <input name="q7" value="boy" type="radio">--%>
                                <asp:Literal ID="uxMother" runat="server"></asp:Literal>
                                <asp:RadioButton ID="uxMotherButton" runat="server" GroupName="parent" EnableViewState="true" />
                            </label>
                            <label class="button gray">
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
                    </fieldset>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper connect-question rs_read_this">
                    <p class="question">
                        <sc:Text ID="Text50" Field="Connect Question Title" runat="server" />
                    </p>

                    <span class="question-description">
                        <sc:Text ID="Text51" Field="Connect Question Text" runat="server" />
                    </span>
                    <div class="textfields-wrapper">
                        <div class="textfield-wrapper">
                            <asp:Label AssociatedControlID="ScreenNameTextField" ID="lblScreenName" runat="server" CssClass="visuallyhidden" aria-hidden="true">Enter a Screen Name</asp:Label>
                            <asp:TextBox type="textfield" ID="ScreenNameTextField" runat="server" />
                            <!--input type="textfield" name="connect-1" placeholder="Screen Name"-->
                            <span class="popover-trigger-container">
                                <div class="popover-link rs_preserve rs_skip">
                                    <sc:Text ID="Text52" Field="Why Do We Ask Text 1" runat="server" />
                                </div>
                            </span>
                            <div class="popover-container">
                                <p class="rs_skip">
                                    <span class="title">
                                        <sc:Text ID="Text53" Field="Why Do We Ask Subtext Header 1" runat="server" />
                                    </span>
                                    <sc:Text ID="Text54" Field="Why Do We Ask Subtext 1" runat="server" />
                                </p>
                            </div>
                        </div>
                        <div class="textfield-wrapper">
                            <asp:Label AssociatedControlID="ZipCodeTextField" ID="lblZipCodes" runat="server" CssClass="visuallyhidden" aria-hidden="true">Zip Code</asp:Label>
                            <asp:TextBox type="textfield" ID="ZipCodeTextField" runat="server" />
                            <!--input type="textfield" name="connect-2" placeholder="Zip Code"-->
                            <span class="popover-trigger-container">
                                <div class="popover-link rs_preserve rs_skip">
                                    <sc:Text ID="Text55" Field="Why Do We Ask Text 2" runat="server" />
                                </div>
                            </span>
                            <div class="popover-container">
                                <p class="rs_skip">
                                    <span class="title">
                                        <sc:Text ID="Text56" Field="Why Do We Ask Subtext Header 2" runat="server" />
                                    </span>
                                    <sc:Text ID="Text57" Field="Why Do We Ask Subtext 2" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="no-uniform-wrapper">
                        <label>
                            <asp:CheckBox ID="cbConnections" CssClass="no-uniform" runat="server" />
                            <span>
                                <sc:Text ID="Text58" Field="Interest Text" runat="server" />
                            </span>
                        </label>
                        <label>
                            <asp:CheckBox ID="cbNewsLetter" CssClass="no-uniform" runat="server" />
                            <span>
                                <sc:Text ID="Text59" Field="Personalized Newsletter Text" runat="server" />
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
