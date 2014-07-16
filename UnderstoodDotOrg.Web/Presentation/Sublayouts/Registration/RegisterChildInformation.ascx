<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegisterChildInformation.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Registration.RegisterChildInformation" %>

<div class="container registration-profile-container flush">
    <div class="row">
        <div class="col col-15 offset-5">
            <!-- BEGIN PARTIAL: registration-profile-child -->
            <div class="registration-profile about-child skiplink-content rs_read_this" aria-role="main">
                <h1><%= Model.Header.Rendered %></h1>

                <div class="question-wrapper">
                    <fieldset>
                        <legend class="question"><%= Model.Question.Rendered %></legend>
                        <div class="checkboxes-wrapper">
                            <asp:ListView ID="rptIssues" runat="server" OnItemDataBound="rptIssues_ItemDataBound" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child.ChildIssueItem">
                                <ItemTemplate>
                                    <div class="checkbox-wrapper">
                                        <label>
                                            <asp:CheckBox ID="uxIssueCheckbox" runat="server" />
                                            <span>
                                                <%# Item.IssueName %>
                                            </span>
                                            <asp:HiddenField ID="uxIssueHidden" runat="server" />
                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <!-- .checkboxes-wrapper -->
                    </fieldset>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper">
                    <div class="select-wrapper select-inverted-mobile">
                        <asp:DropDownList runat="server" ID="ddlGrades" aria-required="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="valGrade" runat="server" ControlToValidate="ddlGrades" InitialValue="" CssClass="validationerror"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper">
                    <div class="radio-toggle-wrapper">
                        <label class="button gray">
                            <%= UnderstoodDotOrg.Common.DictionaryConstants.BoyButtonText %>
                            <asp:RadioButton ID="uxBoy" runat="server" GroupName="q1a" />
                        </label>
                        <label class="button gray">
                            <%= UnderstoodDotOrg.Common.DictionaryConstants.GirlButtonText %>
                            <asp:RadioButton ID="uxGirl" runat="server" GroupName="q1a" />
                        </label>
                        <asp:CustomValidator ID="valGender" runat="server" ClientValidationFunction="ValidateRadioButtons" CssClass="validationerror"></asp:CustomValidator>
                    </div>
                </div>

                <div class="question-wrapper">
                    <div class="textfield-wrapper">
                        <%--<label for="q2" class="visuallyhidden" aria-hidden="true"><%= Model.Childnicknameplaceholder.Rendered %></label>--%>
                        <%--<input type="text" name="q2" id="q2" placeholder="My child's nickname" aria-required="true">--%>
                        <asp:Label runat="server" ID="lblChildNickname" CssClass="visuallyhidden"></asp:Label>
                        <asp:TextBox runat="server" ID="txtChildNickname"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valNickname" runat="server" ControlToValidate="txtChildNickname" CssClass="validationerror"></asp:RequiredFieldValidator>
                    </div>
                    <p class="question-description"><%= Model.Childnicknamenotice.Rendered %></p>
                </div>
                <!-- .question-wrapper -->

                <div class="form-actions">
                    <%--<input type="submit" class="button rs_skip" value="See my Recommendations">--%>
                    <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="button rs_skip" />
                    <div class="spacer"></div>
                    <%--<a class="full-profile-link rs_skip" href="REPLACE">or complete my full profile</a>--%>
                    <asp:HyperLink runat="server" ID="hypCompleteProfile" CssClass="full-profile-link rs_skip"></asp:HyperLink>
                </div>
                <!-- .form-actions -->

            </div>
            <!-- .registration-profile -->
            <!-- END PARTIAL: registration-profile-child -->
        </div>
    </div>
</div>
