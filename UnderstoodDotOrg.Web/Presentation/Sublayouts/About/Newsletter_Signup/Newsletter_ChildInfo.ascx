<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Newsletter_ChildInfo.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup.Newsletter_ChildInfo" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<!--[if lte IE 8]><html class="no-js nonresponsive old-ie" lang="en"><![endif]-->
<!--[if gte IE 9]><!-->

<!--<![endif]-->

<!-- BEGIN PARTIAL: head -->


<!-- END PARTIAL: head -->


<!-- BEGIN PARTIAL: language-selector -->

<!-- END PARTIAL: language-selector -->



<!-- BEGIN PARTIAL: header -->

<!-- #header-page -->
<!-- END PARTIAL: header -->

<div class="container l-itemize-your-child-header flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: about/email-itemize-title -->
            <div class="email-itemize-title rs_read_this">
                <h1><%--Personalize For Your Child--%>
                    <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="page Title" />
                </h1>
                <p>
                    <%--We&apos;ll send you tips, videos, articles and more support that match your child&apos;s specific needs.--%>
                    <sc:FieldRenderer ID="frSectionTitle" runat="server" FieldName="Section Title" />
                </p>
            </div>
            <!-- END PARTIAL: about/email-itemize-title -->
        </div>
    </div>
</div>

<div class="container l-itemize-your-child flush">
    <!-- BEGIN PARTIAL: about/email-itemize-content -->
    <div class="email-itemize-content">

        <div class="row">
            <div class="col col-22 offset-1">

                <div class="needs-help-with skiplink-content rs_read_this itemize-child-rs-wrapper" aria-role="main">

                    <div class="row needs-help-with-title">
                        <div class="col col-22">
                            <h3>My child needs help with</h3>
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->
                    <fieldset class="row needs-help-with-options">
                        <asp:Repeater ID="rptChildIssue" runat="server" OnItemDataBound="rptChildIssue_ItemDataBound">
                            <ItemTemplate>

                                <div class="col col-12">
                                    <asp:Repeater ID="rptIssueCol" runat="server" OnItemDataBound="rptIssueCol_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="checkbox-wrapper">
                                                <label>
                                                    <asp:CheckBox ID="chkIssue1" runat="server"></asp:CheckBox>
                                                    <span>
                                                        <sc:FieldRenderer runat="server" ID="frCheckItem1" FieldName="Issue Name" />
                                                    </span>

                                                    <%-- <input type="checkbox" name="aqi1">
                                            <span>Reading</span>--%>
                                                </label>
                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!-- .col -->
                                <%-- <asp:Panel ID="pnlRow2" runat="server" Visible="false">
                                    <div class="col col-12">
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <asp:CheckBox ID="chkIssue2" runat="server"></asp:CheckBox>
                                                <span>
                                                    <sc:FieldRenderer runat="server" ID="frCheckItem2" FieldName="Issue Name" />
                                                </span>
                                                <%--  <input type="checkbox" name="aqi6">
                                            <span>Oral expression</span>
                                            </label>
                                        </div>

                                    </div>
                                </asp:Panel>--%>
                                <!-- .col -->

                            </ItemTemplate>
                        </asp:Repeater>

                    </fieldset>
                    <!-- .row.needs-help-with-options -->

                </div>
                <!-- .needs-help-with -->

            </div>
            <!-- .col -->
        </div>
        <!-- .row -->

        <div class="row">
            <div class="col col-11 offset-1">

                <div class="child-enrolled rs_read_this itemize-child-rs-wrapper">

                    <h3>My child is enrolled in</h3>

                    <div class="form-action-select">
                        <asp:DropDownList ID="ddlGrades" runat="server"></asp:DropDownList>
                        <%-- <label>
                            <select>
                                <option value="">Select Grade</option>
                                <option value="grade1">Grade 1</option>
                                <option value="grade2">Grade 2</option>
                                <option value="grade3">Grade 3</option>
                                <option value="grade4">Grade 4</option>
                                <option value="grade5">Grade 5</option>
                            </select>
                        </label>--%>
                    </div>

                </div>
                <!-- .child-enrolled -->

            </div>
            <!-- .col -->
            <div class="col col-11">

                <div class="child-nickname rs_read_this itemize-child-rs-wrapper">

                    <h3>My child&apos;s nickname is</h3>

                    <div class="form-action-text">
                        <label>
                            <%--<input type="text" name="aqi10">--%>
                            <asp:TextBox ID="btnChildNickName" runat="server"></asp:TextBox>
                        </label>
                    </div>

                    <p class="caption">This is private and only viewable by you</p>

                </div>
                <!-- .child-nickname -->

            </div>
            <!-- .col -->
        </div>
        <!-- .row -->

        <div class="row">
            <div class="col col-22 offset-1">

                <div class="email-itemize-next">

                    <div class="checkbox-wrap">
                        <label>
                            <asp:CheckBox ID="chkAnotherChild" runat="server" />
                            <%--<input type="checkbox" name="aqi10">--%>
                            <span>I have another child who is struggling</span>
                        </label>
                    </div>

                    <div class="form-action-next">
                        <%--<input class="button" type="submit" value="Next">--%>
                        <asp:Button CssClass="button" runat="server" ID="btnNext" Text="Next" />
                    </div>

                </div>
                <!-- .email-itemize-next -->

            </div>
            <!-- .col -->
        </div>
        <!-- .row -->

    </div>
    <!-- .email-itemize-content -->
    <!-- END PARTIAL: about/email-itemize-content -->
</div>

<!-- BEGIN PARTIAL: footer -->



<!-- BEGIN MODULE: More to Explore -->


<!-- END MODULE: More to Explore -->

<!-- BEGIN MODULE: Newsletter Signup -->

<!-- .container .newsletter-signup -->

<!-- END MODULE: Newsletter Signup -->

<!-- BEGIN MODULE: Partners Carousel -->
