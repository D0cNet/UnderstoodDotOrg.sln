<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DonationPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.DonationPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<input type="hidden" id="hfDonationApiKey" value="<%= Model.ConvioDonationAPIKey.Rendered %>" />
<input type="hidden" id="hfDonationFormId" value="<%= Model.ConvioDonationFormID.Rendered %>" />
<input type="hidden" id="hfDonationLevelId" value="<%= Model.ConvioDonationLevelID.Rendered %>" />
<input type="hidden" id="hfDonationSuccessUrl" value="<%= ThankYouPageUrl %>" />
<input type="hidden" id="hfDonationEcardId" value="<%= Model.ConvioDonationEcardID.Rendered %>" />
<div class="container flush donate-create-wrap">
    <div class="row">
        <div class="col col-24 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: about-donate-create -->
            <div class="donate-choose-gift">
                <header class="rs_read_this about-donate-rs-wrapper">
                    <h1><%= Model.ContentPage.PageTitle.Rendered %></h1>
                    <%= Model.ContentPage.BodyContent.Rendered %>
                </header>
                <div class="choose-gift-section rs_read_this about-donate-rs-wrapper">
                    <h2>1. <%= Model.AmountHeader.Rendered %></h2>
                    <div class="choose-gift-wrapper">
                        <asp:Repeater ID="rptrDonationAmounts" runat="server" 
                            ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.DonationAmountItem">
                            <ItemTemplate>
                                <%# Container.ItemIndex % 2 == 0 ? "<div class=\"gift-group clearfix rs_preserve\">" : string.Empty %>
                                <label>
                                    <input type="radio" name="gift-amount" data-other="<%# Item.IsCustomAmount.Checked.ToString().ToLower() %>" 
                                        value="">
                                    <span>
                                        <button type="button" class="donate-amount-button" 
                                            data-param-value="<%# Item.IsCustomAmount.Checked ? string.Empty : Item.Amount.Integer.ToString() %>">
                                            <span class="number"><%# Item.DisplayAmount.Rendered %></span>
                                            <span class="gift-description"><%# Item.ShortDescription.Rendered %></span>
                                            <span class="icon-check">
                                                <img class="check-img" src="/Presentation/includes/images/icon-check.png" /></span>
                                        </button>
                                    </span>
                                </label>
                                <%# Container.ItemIndex % 2 != 0 ? "</div>" : string.Empty %>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- .choose-gift-wrapper -->
                    <!-- BEGIN PARTIAL: about-donate-other-amount -->
                    <div class="other-amount-form">
                        <div class="form-group">
                            <div class="form-fit">
                                <label for="donate-amount"><sc:FieldRenderer ID="frEnterDiff" FieldName="Enter a different amount Text" runat="server" /></label>
                            </div>
                            <div class="form-flex">
                                <div class="dollar-prefix"><sc:FieldRenderer ID="frMoney" FieldName="Monetary Sign" runat="server" /></div>
                                <input type="text" placeholder="" name="donate-amount" id="donate-amount">
                            </div>
                        </div>
                    </div>
                    <!-- .gift-for-wrapper -->
                    <!-- END PARTIAL: about-donate-other-amount -->
                </div>
                <!-- .choose-gift-section -->
                <div class="gift-for-section">
                    <div class="rs_read_this about-donate-rs-wrapper">
                        <h2>2. <%= Model.GiftforSomeoneHeader.Rendered %></h2>
                        <div class="gift-for-wrapper rs_preserve">
                            <label class="yes-send-card">
                                <input type="radio" class="radio" name="gift-card" data-e-card="true" value="">
                                <span>
                                    <button type="button" class="ecard-button send-ecard-true"><sc:FieldRenderer ID="frYesC" FieldName="Yes send an ecard Text" runat="server" /></button></span>
                            </label>
                            <label class="no-card">
                                <input type="radio" name="gift-card" data-e-card="false" value="">
                                <span>
                                    <button type="button" class="ecard-button send-ecard-false"><sc:FieldRenderer ID="frNoC" FieldName="No Card Text" runat="server" /></button></span>
                            </label>
                        </div>
                        <!-- .gift-for-wrapper -->
                    </div>
                    <!-- BEGIN PARTIAL: about-donate-ecard -->
                    <div class="ecard-form-wrapper form-center rs_read_this about-donate-rs-wrapper">
                        <div class="form-group">
                            <label for="donate-ecard-name"><sc:FieldRenderer ID="frNofR" FieldName="Name of Recipient Text" runat="server" /></label>
                            <input type="text" placeholder="" name="donate-ecard-name" id="donate-ecard-name" aria-required="true">
                        </div>
                        <div class="form-group">
                            <label for="donate-ecard-email"><sc:FieldRenderer ID="frEmailofR" FieldName="Email of Recipient Text" runat="server"  /></label>
                            <input type="text" placeholder="" name="donate-ecard-email" id="donate-ecard-email" aria-required="true">
                        </div>
                        <div class="form-group">
                            <label for="donate-ecard-message"><sc:FieldRenderer ID="frMSG" FieldName="Message Text" runat="server" /></label>
                            <textarea name="ecard-message" class="ecard-message" id="donate-ecard-message"></textarea>
                        </div>
                    </div>
                    <!-- .gift-for-wrapper -->
                    <!-- END PARTIAL: about-donate-ecard -->
                </div>
                <!-- .gift-for-section-->
                <div class="gift-occurance-section rs_read_this about-donate-rs-wrapper">
                    <h2>3. <%= Model.RecurringGiftHeader.Rendered %></h2>
                    <div class="gift-occurance-wrapper">
                        <div class="radio-wrapper">
                            <label for="gift-occurrence-once">
                                <input type="radio" name="gift-occurance" id="gift-occurrence-once" value="" checked>
                                <span><sc:FieldRenderer ID="frOneTime" FieldName="This is a one time gift Text" runat="server" /></span>
                            </label>
                            <label for="gift-occurrence-monthly">
                                <input type="radio" name="gift-occurance" id="gift-occurrence-monthly" value="">
                                <span><sc:FieldRenderer ID="frMonthly" FieldName="This is a monthly gift Text" runat="server" /></span>
                            </label>
                        </div>
                    </div>
                    <!-- .monthly-gift-wrapper -->
                </div>
                <!-- .monthly-gift-section-->
                <div class="how-pay-section">
                    <div class="about-donate-rs-wrapper">
                        <div class="rs_read_this">
                            <h2>4. <%= Model.PaymentInformationHeader.Rendered %></h2>
                            <div class="visuallyhidden"><sc:FieldRenderer ID="frPayBy" FieldName="Pay by Text" runat="server" /></div>
                            <span class="visuallyhidden"><sc:FieldRenderer ID="frCredCard" FieldName="Credit Card Text" runat="server" /></span>
                            <span class="visuallyhidden"><sc:FieldRenderer ID="frCheck" FieldName="Check Text" runat="server" /></span>
                        </div>
                        <div class="how-pay-option-wrapper form-center">
                            <div class="pay-by"><sc:FieldRenderer ID="frpb" FieldName="Pay by Text" runat="server" /></div>
                            <div class="radio-wrapper">
                                <label for="pay-option-credit">
                                    <input name="pay-option" id="pay-option-credit" type="radio" data-credit-card="true" name="" value="" checked>
                                    <span><sc:FieldRenderer ID="frCredCard2" FieldName="Credit Card Text" runat="server" /></span>
                                </label>
                                <label for="pay-option-check">
                                    <input name="pay-option" id="pay-option-check" type="radio" name="" value="">
                                    <span><sc:FieldRenderer ID="frCheck2" FieldName="Check Text" runat="server" /></span>
                                </label>
                            </div>
                        </div>
                        <!-- .how-pay-wrapper -->
                    </div>
                    <!-- START FORM -->
                    <div class="how-pay-form-wrapper form-center">
                        <!-- BEGIN PARTIAL: about-donate-pay-by-check -->
                        <div class="pay-by-check rs_read_this about-donate-rs-wrapper">
                            <h3><%= Model.CheckHelpImageHeader.Rendered %></h3>
                            <img class="pay-by-check" alt="Pay By Check Sample" src="<%= Model.CheckHelpImage.MediaUrl %>" />
                            <div class="form-group">
                                <label for="donate-account-name"><sc:FieldRenderer ID="frNameonAccount" FieldName="Name on Account Text" runat="server" /></label>
                                <input type="text" placeholder="" name="donate-account-name" id="donate-account-name" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-account-routing"><sc:FieldRenderer ID="frBankRoutingNumber" FieldName="Bank Routing Number Text" runat="server" /></label>
                                <input type="text" placeholder="" name="donate-account-routing" id="donate-account-routing" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-account-number"><sc:FieldRenderer ID="frCheckingAccountNumber" FieldName="Checking Account Number Text" runat="server" /></label>
                                <input type="text" placeholder="" name="donate-account-number" id="donate-account-number" aria-required="true">
                            </div>
                        </div>
                        <!-- END PARTIAL: about-donate-pay-by-check -->
                        <!-- BEGIN PARTIAL: about-donate-pay-by-credit -->
                        <div class="pay-by-credit rs_read_this about-donate-rs-wrapper">
                            <div class="form-group">
                                <label for="card-number-input"><sc:FieldRenderer ID="frCardNumber" FieldName="Card Number Text" runat="server" /></label>
                                <input type="text" placeholder="" id="card-number-input" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="ccv-input"><sc:FieldRenderer ID="frCVVNumber" FieldName="CVV Number Text" runat="server" /></label>
                                <input type="text" placeholder="" class="cvv-input" id="ccv-input" aria-required="true">

                                <div class="cvv-info-wrapper rs_skip">
                                    <div class="popover-trigger-container">
                                        <button class="popover-link rs_preserve" data-popover-placement="bottom"><i class="icon-tooltip-dark">&nbsp;</i></button></div>
                                    <!-- BEGIN PARTIAL: popover-cvv-info -->
                                    <div class="cvv-tooltip popover-container">
                                        <%= Model.CVVHelpText.Rendered %>
                                    </div>
                                    <!-- .cvv-tooltip -->
                                    <!-- END PARTIAL: popover-cvv-info -->
                                </div>
                            </div>
                            <div class="form-group expiration-date-wrap">
                                <!-- Uniform requires label tags to be in the select-container or the width will not be set properly -->
                                <span class="label"><sc:FieldRenderer ID="frExpDate" FieldName="Expiration Date Text" runat="server" /></span>
                                <div class="select-container select-inverted-mobile month-dropdown">
                                    <label for="month-dropdown" class="visuallyhidden"><sc:FieldRenderer ID="frSelectDD" FieldName="Month Dropdown Text" runat="server" /></label>
                                    <select name="month-dropdown" id="month-dropdown" aria-required="true">
                                        <option value="">MM</option>
                                        <option>01</option>
                                        <option>02</option>
                                        <option>03</option>
                                        <option>04</option>
                                        <option>05</option>
                                        <option>06</option>
                                        <option>07</option>
                                        <option>08</option>
                                        <option>09</option>
                                        <option>10</option>
                                        <option>11</option>
                                        <option>12</option>
                                    </select>
                                </div>
                                <div class="select-container select-inverted-mobile year-dropdown">
                                    <label for="year-dropdown" class="visuallyhidden"><sc:FieldRenderer ID="frSelectYear" FieldName="Select Year Text" runat="server" /></label>
                                    <select name="year-dropdown" id="year-dropdown" aria-required="true">
                                        <option value="">YYYY</option>
                                        <option>2014</option>
                                        <option>2015</option>
                                        <option>2016</option>
                                        <option>2017</option>
                                        <option>2018</option>
                                        <option>2019</option>
                                        <option>2020</option>
                                        <option>2021</option>
                                        <option>2022</option>
                                        <option>2023</option>
                                        <option>2024</option>
                                        <option>2025</option>
                                        <option>2026</option>
                                        <option>2027</option>
                                        <option>2028</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <!-- END PARTIAL: about-donate-pay-by-credit -->
                        <div class="rs_read_this form-group-rs-wrapper about-donate-rs-wrapper">
                            <div class="form-group">
                                <label for="donate-first-name"><sc:FieldRenderer ID="frFN" FieldName="First Name Text" runat="server" /></label>
                                <input type="text" placeholder="" name="donate-first-name" id="donate-first-name" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-last-name"><sc:FieldRenderer ID="frLN" FieldName="Last Name Text" runat="server" /></label>
                                <input type="text" placeholder="" name="donate-last-name" id="donate-last-name" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-email"><sc:FieldRenderer ID="frEmail" FieldName="Email Text" runat="server" /></label>
                                <input type="text" placeholder="" name="donate-email" id="donate-email" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-phone"><sc:FieldRenderer ID="frPhone" FieldName="Phone Text" runat="server" /></label>
                                <input type="text" placeholder="" class="phone-input" name="donate-phone" id="donate-phone" aria-required="true">
                                <div class="select-container select-inverted-mobile cell-dropdown">
                                    <label for="phone-type" class="visuallyhidden"><sc:FieldRenderer ID="frPhoneType" FieldName="Phone Type Text" runat="server" /></label>
                                    <select name="phone-type" id="phone-type">
                                        <option value="">Cell</option>
                                        <option value="home">Home</option>
                                        <option value="work">Work</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="donate-address1"><sc:FieldRenderer ID="frStreetAddress" FieldName="Street Adress Text" runat="server" /></label>
                                <input type="text" placeholder="" name="donate-address1" id="donate-address1" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-address2"><sc:FieldRenderer ID="frStreetAddress2" FieldName="Street Adress 2 Text" runat="server" /></label>
                                <input type="text" placeholder="" name="donate-address2" id="donate-address2">
                            </div>
                            <div class="form-group">
                                <label for="donate-city"><sc:FieldRenderer ID="frCity" FieldName="CIty Text" runat="server" /></label>
                                <input type="text" placeholder="" name="donate-city" id="donate-city" aria-required="true">
                            </div>
                            <div class="form-group">
                                <!-- Uniform requires label tags to be in the select-container or the width will not be set properly -->
                                <span class="label" for="state-dropdown"><sc:FieldRenderer ID="frStateProvince" FieldName="State Province Text" runat="server" /></span>
                                <div class="select-container select-inverted-mobile state-dropdown">
                                    <label for="state-dropdown" class="visuallyhidden"><sc:FieldRenderer ID="frStateProvince2" FieldName="State Province Text" runat="server" /></label>
                                    <asp:DropDownList ID="ddlStates" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="donate-zip"><sc:FieldRenderer ID="frZip" FieldName="Zip Code Text" runat="server" /></label>
                                <input type="text" placeholder="" class="zip-input" name="donate-zip" id="donate-zip" aria-required="true">
                            </div>
                        </div>
                    </div>
                    <!-- .how-pay-wrapper -->
                </div>
                <!-- .how-pay-section-->
                <!-- END FORM -->
                <div class="about-donate-footer form-center">
                    <label class="keep-posted-wrap" for="donate-keep-posted">
                        <input type="checkbox" name="donate-keep-posted" id="donate-keep-posted" checked>
                        <span class="keep-posted"><sc:FieldRenderer ID="frKeepMePosted" FieldName="Yes Keep Me Posted Text" runat="server" /></span>
                    </label>
                    <p class="donate-to-partners">
                        <sc:FieldRenderer ID="frWhenYouGiveToUnderstood" FieldName="When You Give To Understood Text" runat="server" />
                    </p>
                    <div class="button-wrap">
                        <button type="button" id="submit-donation" class="button about-donate rs_skip"><sc:FieldRenderer ID="frDonate" FieldName="Donate Button Text" runat="server" /></button>
                    </div>
                </div>
                <div class="about-donate-notes clearfix">
                    <p class="small-note">
                       <sc:FieldRenderer ID="frSmallNote" FieldName="Understood Small Note" runat="server"/> 
                    </p>
                    <div class="logo-img-wrap">
                        <%--<img class="logo-img" alt="Verisign" src="/Presentation/includes/images/logo.partner.verisign.png" />--%>
                        <sc:Image ID="LogoImage" Field="Logo Image" runat="server" />
                    </div>
                </div>
            </div>
            <!-- .donate-choose-gift -->
            <!-- END PARTIAL: about-donate-create -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
