<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Newsletter_ChildInfo.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup.Newsletter_ChildInfo" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container l-itemize-your-child-header flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: about/email-itemize-title -->
            <div class="email-itemize-title rs_read_this">
                <h1>
                    <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                </h1>
                <p>
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

                    
                    <asp:Repeater ID="rptChildIssue" runat="server" OnItemDataBound="rptChildIssue_ItemDataBound">
                        <HeaderTemplate>
                            <fieldset class="row needs-help-with-options">
                        </HeaderTemplate>
                        <ItemTemplate>

                            <div class="col col-12">
                                <asp:Repeater ID="rptIssueCol" runat="server" OnItemDataBound="rptIssueCol_ItemDataBound">
                                <ItemTemplate>
                                    <div class="checkbox-wrapper">
                                        <label>
                                            <asp:CheckBox ID="cbChildIssue" runat="server" />
                                            <span>
                                                <asp:Literal ID="litChildIssue" runat="server" />
                                            </span>
                                            <asp:HiddenField ID="hfChildIssue" runat="server" />
                                        </label>
                                    </div>

                                </ItemTemplate>
                                </asp:Repeater>
                            </div>

                        </ItemTemplate>
                        <FooterTemplate>
                            </fieldset>
                        </FooterTemplate>
                    </asp:Repeater>


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
                        <asp:DropDownList ID="ddlGrades" runat="server" />
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
                            <asp:TextBox ID="txtNickname" runat="server" />
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
                            <span>I have another child who is struggling</span>
                        </label>
                    </div>

                    <div class="form-action-next">
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
