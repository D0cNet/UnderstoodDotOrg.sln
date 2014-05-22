﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DonationPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.DonationPage" %>
<div class="container flush donate-create-wrap">
    <div class="row">
        <div class="col col-24 skiplink-content" aria-role="main" aria-role="main">
            <!-- BEGIN PARTIAL: about-donate-create -->
            <div class="donate-choose-gift">
                <header class="rs_read_this about-donate-rs-wrapper">
                    <h1><%= Model.ContentPage.PageTitle.Rendered %></h1>
                    <%= Model.ContentPage.PageSummary.Rendered %>
                </header>
                <div class="choose-gift-section rs_read_this about-donate-rs-wrapper">
                    <h2>1. <%= Model.AmountHeader.Rendered %></h2>
                    <div class="choose-gift-wrapper">
                        <div class="gift-group clearfix rs_preserve">
                            <label>
                                <input type="radio" name="gift-amount" value="">
                                <span>
                                    <button>
                                        <span class="number">$25</span>
                                        <span class="gift-description">Can provide education for 1 parents.</span>
                                        <span class="icon-check">
                                            <img class="check-img" alt="Check mark" src="/Presentation/includes/images/icon-check.png" /></span>
                                    </button>
                                </span>
                            </label>
                            <label>
                                <input type="radio" name="gift-amount" value="">
                                <span>
                                    <button>
                                        <span class="number">$50</span>
                                        <span class="gift-description">Can provide education for 2 parents.</span>
                                        <span class="icon-check">
                                            <img class="check-img" alt="Check mark" src="/Presentation/includes/images/icon-check.png" /></span>
                                    </button>
                                </span>
                            </label>
                        </div>
                        <div class="gift-group clearfix rs_preserve">
                            <label>
                                <input type="radio" name="gift-amount" value="">
                                <span>
                                    <button>
                                        <span class="number">$100</span>
                                        <span class="gift-description">Can provide education for 3 parents.</span>
                                        <span class="icon-check">
                                            <img class="check-img" alt="Check mark" src="/Presentation/includes/images/icon-check.png" /></span>
                                    </button>
                                </span>
                            </label>
                            <label>
                                <input type="radio" name="gift-amount" data-other="true" value="">
                                <span>
                                    <button>
                                        <span class="number">Other</span>
                                        <span class="gift-description">Can provide education for x parents.</span>
                                        <span class="icon-check">
                                            <img class="check-img" alt="Check mark" src="/Presentation/includes/images/icon-check.png" /></span>
                                    </button>
                                </span>
                            </label>
                        </div>
                    </div>
                    <!-- .choose-gift-wrapper -->
                    <!-- BEGIN PARTIAL: about-donate-other-amount -->
                    <div class="other-amount-form">
                        <div class="form-group">
                            <div class="form-fit">
                                <label for="donate-amount">Enter a different amount:</label>
                            </div>
                            <div class="form-flex">
                                <div class="dollar-prefix">$</div>
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
                                    <button>Yes, send an e-card</button></span>
                            </label>
                            <label class="no-card">
                                <input type="radio" name="gift-card" value="">
                                <span>
                                    <button>No Card</button></span>
                            </label>
                        </div>
                        <!-- .gift-for-wrapper -->
                    </div>

                    <!-- BEGIN PARTIAL: about-donate-ecard -->
                    <div class="ecard-form-wrapper form-center rs_read_this about-donate-rs-wrapper">
                        <div class="form-group">
                            <label for="donate-ecard-name">Name of Recipient</label>
                            <input type="text" placeholder="" name="donate-ecard-name" id="donate-ecard-name" aria-required="true">
                        </div>
                        <div class="form-group">
                            <label for="donate-ecard-email">Email of Recipient</label>
                            <input type="text" placeholder="" name="donate-ecard-email" id="donate-ecard-email" aria-required="true">
                        </div>
                        <div class="form-group">
                            <label for="donate-ecard-message">Message</label>
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
                                <span>This is a one-time-gift</span>
                            </label>
                            <label for="gift-occurrence-monthly">
                                <input type="radio" name="gift-occurance" id="gift-occurrence-monthly" value="">
                                <span>This is a monthly gift</span>
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
                            <div class="visuallyhidden">Pay by</div>
                            <span class="visuallyhidden">Credit Card</span>
                            <span class="visuallyhidden">Check</span>
                        </div>
                        <div class="how-pay-option-wrapper form-center">
                            <div class="pay-by">Pay by</div>
                            <div class="radio-wrapper">
                                <label for="pay-option-credit">
                                    <input name="pay-option" id="pay-option-credit" type="radio" data-credit-card="true" name="" value="" checked>
                                    <span>Credit Card</span>
                                </label>
                                <label for="pay-option-check">
                                    <input name="pay-option" id="pay-option-check" type="radio" name="" value="">
                                    <span>Check</span>
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
                                <label for="donate-account-name">Name on Account</label>
                                <input type="text" placeholder="" name="donate-account-name" id="donate-account-name" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-account-routing">Bank Routing Number</label>
                                <input type="text" placeholder="" name="donate-account-routing" id="donate-account-routing" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-account-number">Checking Account Number</label>
                                <input type="text" placeholder="" name="donate-account-number" id="donate-account-number" aria-required="true">
                            </div>
                        </div>
                        <!-- END PARTIAL: about-donate-pay-by-check -->
                        <!-- BEGIN PARTIAL: about-donate-pay-by-credit -->
                        <div class="pay-by-credit rs_read_this about-donate-rs-wrapper">
                            <div class="form-group">
                                <label for="card-number-input">Card Number</label>
                                <input type="text" placeholder="" id="card-number-input" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="ccv-input">CVV Number</label>
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
                                <span class="label">Expiration Date</span>
                                <div class="select-container select-inverted-mobile month-dropdown">
                                    <label for="month-dropdown" class="visuallyhidden">Month Dropdown</label>
                                    <select name="month-dropdown" aria-required="true">
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
                                    <label for="year-dropdown" class="visuallyhidden">Select Year</label>
                                    <select name="year-dropdown" aria-required="true">
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
                                <label for="donate-first-name">First Name</label>
                                <input type="text" placeholder="" name="donate-first-name" id="donate-first-name" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-last-name">Last Name</label>
                                <input type="text" placeholder="" name="donate-last-name" id="donate-last-name" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-email">Email</label>
                                <input type="text" placeholder="" name="donate-email" id="donate-email" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-phone">Phone</label>
                                <input type="text" placeholder="" class="phone-input" name="donate-phone" id="donate-phone" aria-required="true">
                                <div class="select-container select-inverted-mobile cell-dropdown">
                                    <label for="phone-type" class="visuallyhidden">Phone Type</label>
                                    <select name="phone-type" id="phone-type">
                                        <option value="">Cell</option>
                                        <option value="home">Home</option>
                                        <option value="work">Work</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="donate-address1">Street Address</label>
                                <input type="text" placeholder="" name="donate-address1" id="donate-address1" aria-required="true">
                            </div>
                            <div class="form-group">
                                <label for="donate-address2">Street Address 2</label>
                                <input type="text" placeholder="" name="donate-address2" id="donate-address2">
                            </div>
                            <div class="form-group">
                                <label for="donate-city">City</label>
                                <input type="text" placeholder="" name="donate-city" id="donate-city" aria-required="true">
                            </div>
                            <div class="form-group">
                                <!-- Uniform requires label tags to be in the select-container or the width will not be set properly -->
                                <span class="label" for="state-dropdown">State/Province</span>
                                <div class="select-container select-inverted-mobile state-dropdown">
                                    <label for="state-dropdown" class="visuallyhidden">State/Province</label>
                                    <select name="state-dropdown" id="state-dropdown" aria-required="true">
                                        <option value="">Select</option>
                                        <option value="NY">New York</option>
                                        <option value="CT">Connecticut</option>
                                        <option value="VT">Vermont</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="donate-zip">ZIP/Postal Code</label>
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
                        <span class="keep-posted">Yes, keep me posted on the lastest Understood news.</span>
                    </label>
                    <p class="donate-to-partners">
                        When you give to Understood you also give to our various partners
                    </p>
                    <div class="button-wrap">
                        <button class="button about-donate rs_skip">Donate</button>
                    </div>
                </div>
                <div class="about-donate-notes clearfix">
                    <p class="small-note">
                        Understood is a 501(c)(3) nonprofit recognized by the IRS, and all donations to Understood are tax-deductible in accordance with IRS regulations. 2014 Understood
                    </p>
                    <div class="logo-img-wrap">
                        <img class="logo-img" alt="Verisign" src="/Presentation/includes/images/logo.partner.verisign.png" />
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