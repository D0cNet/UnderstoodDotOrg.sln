<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Newsletter_ParentInterest.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup.Newsletter_ParentInterest" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container l-personalize-interests-header flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: about/personalize-interests-title -->
            <div class="personalize-interests-title rs_read_this">
                <h1><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></h1>
                <p><sc:FieldRenderer ID="frSectionTitle" runat="server" FieldName="Section Title" /></p>
            </div>
            <!-- END PARTIAL: about/personalize-interests-title -->
        </div>
    </div>
</div>

<div class="container l-personalize-interests flush">
    <!-- BEGIN PARTIAL: about/personalize-interests-content -->
    <div class="personalize-interests-content">

        <div class="row">
            <div class="col col-22 offset-1">

                <div class="school-issues skiplink-content  rs_read_this personalize-interests-rs-wrapper" aria-role="main">

                    <div class="row school-issues-title">
                        <div class="col col-22">
                            <h3><sc:FieldRenderer ID="frSchoolIssuesHeading" runat="server" FieldName="School Issues Heading" /></h3>
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->

                    <fieldset class="row school-issues-options">
                        <div class="col col-12">

                            <asp:Repeater ID="rptSchoolIssuesLeft" runat="server">
                                <ItemTemplate>
                                    <div class="checkbox-wrapper">
                                        <label>
                                            <asp:CheckBox ID="cbInterest" runat="server" />
                                            <span><asp:Literal ID="litInterest" runat="server" /></span>
                                            <asp:HiddenField ID="hfInterest" runat="server" />
                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
    
                        </div>
                        <!-- .col -->
                        <div class="col col-12">
                            <div class="column-wrap">
                                <asp:Repeater ID="rptSchoolIssuesRight" runat="server">
                                    <ItemTemplate>
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <asp:CheckBox ID="cbInterest" runat="server" />
                                                <span><asp:Literal ID="litInterest" runat="server" /></span>
                                                <asp:HiddenField ID="hfInterest" runat="server" />
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                            
                            </div>

                        </div>
                        <!-- .col -->
                    </fieldset>
                    <!-- .row.needs-help-with-options -->

                </div>
                <!-- .needs-help-with -->

            </div>
            <!-- .col -->
        </div>
        <!-- .row -->

        <div class="row">
            <div class="col col-11 offset-1 rs_read_this personalize-interests-rs-wrapper">

                <fieldset class="ways-to-help">

                    <h3><sc:FieldRenderer ID="frWaysToHelpHeading" runat="server" FieldName="Ways To Help Heading" /></h3>

                    <asp:Repeater ID="rptWaysToHelp" runat="server">
                        <ItemTemplate>
                            <div class="checkbox-wrapper">
                                <label>
                                    <asp:CheckBox ID="cbInterest" runat="server" />
                                    <span><asp:Literal ID="litInterest" runat="server" /></span>
                                    <asp:HiddenField ID="hfInterest" runat="server" />
                                </label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </fieldset>
                <!-- .ways-to-help -->

            </div>
            <!-- .col -->
            <div class="col col-11 rs_read_this personalize-interests-rs-wrapper  home-life-rs-wrapper">

                <fieldset class="home-life">

                    <h3><sc:FieldRenderer ID="frHomeLifeHeading" runat="server" FieldName="Home Life Heading" /></h3>

                    <asp:Repeater ID="rptHomeLife" runat="server">
                        <ItemTemplate>
                            <div class="checkbox-wrapper">
                                <label>
                                    <asp:CheckBox ID="cbInterest" runat="server" />
                                    <span><asp:Literal ID="litInterest" runat="server" /></span>
                                    <asp:HiddenField ID="hfInterest" runat="server" />
                                </label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </fieldset>
                <!-- .home-life -->

            </div>
            <!-- .col -->
        </div>
        <!-- .row -->

        <div class="row">
            <div class="col col-11 offset-1 rs_read_this personalize-interests-rs-wrapper">

                <fieldset class="growing-up">

                    <h3><sc:FieldRenderer ID="frGrowingUpHeading" runat="server" FieldName="Growing Up Heading" /></h3>

                    <asp:Repeater ID="rptGrowingUp" runat="server">
                        <ItemTemplate>
                            <div class="checkbox-wrapper">
                                <label>
                                    <asp:CheckBox ID="cbInterest" runat="server" />
                                    <span><asp:Literal ID="litInterest" runat="server" /></span>
                                    <asp:HiddenField ID="hfInterest" runat="server" />
                                </label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </fieldset>
                <!-- .growing-up -->

            </div>
            <!-- .col -->
            <div class="col col-11 rs_read_this personalize-interests-rs-wrapper social-emotional-rs-wrapper">

                <fieldset class="social-emotional-issues">

                    <h3><sc:FieldRenderer ID="frSocialEmotionalHeading" runat="server" FieldName="Social Emotional Heading" /></h3>

                    <asp:Repeater ID="rptSocial" runat="server">
                        <ItemTemplate>
                            <div class="checkbox-wrapper">
                                <label>
                                    <asp:CheckBox ID="cbInterest" runat="server" />
                                    <span><asp:Literal ID="litInterest" runat="server" /></span>
                                    <asp:HiddenField ID="hfInterest" runat="server" />
                                </label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </fieldset>
                <!-- .social-emotional-issues -->

            </div>
            <!-- .col -->
        </div>
        <!-- .row -->

        <div class="row">
            <div class="col col-22 offset-1 rs_read_this personalize-interests-rs-wrapper">

                <fieldset class="preferred-language">

                    <h3><sc:FieldRenderer ID="frPreferredLanguage" runat="server" FieldName="Preferred Language Heading" /></h3>

                    <div class="radio-wrapper">
                        <label>
                            <asp:RadioButton ID="rbLanguageEnglish" GroupName="Language" runat="server" />
                            <span>English</span>
                        </label>
                    </div>
                    <div class="radio-wrapper">
                        <label>
                            <asp:RadioButton ID="rbLanguageSpanish" GroupName="Language" runat="server" />
                            <span>Spanish</span>
                        </label>
                    </div>

                    <asp:CustomValidator ID="cvLanguage" runat="server" Display="Dynamic" />

                </fieldset>
                <!-- .preferred-language -->

            </div>
            <!-- .col -->
        </div>
        <!-- .row -->

        <div class="row">
            <div class="col col-22 offset-1">

                <div class="personalize-interests-next">

                    <div class="form-action-next">
                        <asp:Button ID="btnSubmit" CssClass="button" runat="server" CausesValidation="true" />
                    </div>

                </div>
                <!-- .personalize-interests-next -->

            </div>
            <!-- .col -->
        </div>
        <!-- .row -->

    </div>
    <!-- .email-itemize-content -->
    <!-- END PARTIAL: about/personalize-interests-content -->
</div>