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

                            <%--<div class="checkbox-wrapper">
                                <label for="q1a2">
                                    <input type="checkbox" name="q1a2" id="q1a2">
                                    <span>Writing</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label for="q1a3">
                                    <input type="checkbox" name="q1a3" id="q1a3">
                                    <span>Math</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label for="q1a4">
                                    <input type="checkbox" name="q1a4" id="q1a4">
                                    <span>Listening comprehension</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label for="q1a5">
                                    <input type="checkbox" name="q1a5" id="q1a5">
                                    <span>Spoken language</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label for="q1a6">
                                    <input type="checkbox" name="q1a6" id="q1a6">
                                    <span>Executive function (organization, planning, flexible thinking)</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label for="q1a7">
                                    <input type="checkbox" name="q1a7" id="q1a7">
                                    <span>Hyperactivity/impulsivity</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label for="q1a8">
                                    <input type="checkbox" name="q1a8" id="q1a8">
                                    <span>Attention/staying focused</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label for="q1a9">
                                    <input type="checkbox" name="q1a9" id="q1a9">
                                    <span>Social skills</span>
                                </label>
                            </div>
                            <div class="checkbox-wrapper">
                                <label for="q1a10">
                                    <input type="checkbox" name="q1a10" id="q1a10">
                                    <span>Motor skills</span>
                                </label>
                            </div>--%>
                        </div>
                        <!-- .checkboxes-wrapper -->
                    </fieldset>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper">
                    <div class="select-wrapper select-inverted-mobile">
                        <asp:DropDownList runat="server" ID="ddlGrades" aria-required="true">
                        </asp:DropDownList>
                        <%--<select name="q1b" id="q1b" aria-required="true">
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
                        </select>--%>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper">
                    <div class="textfield-wrapper">
                        <%--<label for="q2" class="visuallyhidden" aria-hidden="true"><%= Model.Childnicknameplaceholder.Rendered %></label>--%>
                        <%--<input type="text" name="q2" id="q2" placeholder="My child's nickname" aria-required="true">--%>
                        <asp:Label runat="server" ID="lblChildNickname" CssClass="visuallyhidden"></asp:Label>
                        <asp:TextBox runat="server" ID="txtChildNickname"></asp:TextBox>
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
