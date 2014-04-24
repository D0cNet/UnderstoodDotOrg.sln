<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignUp.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.SignUp" %>

<!-- BEGIN PARTIAL: sign-up -->
<div class="container sign-in-link flush">
    <div class="row">
        <div class="col col-23">
            <p>Already signed up? <a href="REPLACE">Sign In</a></p>
        </div>
    </div>
</div>
<div class="container sign-up">
    <div class="row skiplink-content" aria-role="main">
        <div class="col col-16 offset-5">
            <h1>Sign Up</h1>
            <a class="fb-sign-in" href="REPLACE">
                <img alt="facebook" src="Presentation/includes/images/icon.fb-sign-in@2x.png" />
            </a>
            <p>Or create an account using your email address</p>
            <div class="sign-up-inputs">
                <label class="first-name error">
                    <input type="text" placeholder="First name" aria-required="true">
                    <span>* Please enter your first name</span>
                </label>
                <p>we only need your first name</p>
                <label class="email-address error">
                    <input type="text" placeholder="Enter email address" aria-required="true">
                    <span>* It looks like you mistyped your email address. Please try again.</span>
                </label>
                <label class="enter-password error">
                    <input type="text" placeholder="Enter password" aria-required="true">
                    <span>* Please create a password that has 6 or more characters. You can use letters and/or numbers.</span>
                </label>
                <p>password must be at least 6 characters</p>
                <label class="re-enter-password error">
                    <input type="text" placeholder="Re-enter Password" aria-required="true">
                    <span>* Please retype your password to match your password above</span>
                </label>
                <div class="zip-code error">
                    <label>
                        <input type="text" placeholder="Zip code (optional)">
                    </label>
                    <p class="why-do-we-ask-container">optional <a class="why-do-we-ask popover-link" href="REPLACE" data-popover-placement="bottom">Why do we ask?</a></p>

                    <div class="why-do-we-ask-popover popover-container">
                        <div class="why-do-we-ask-content">
                            We ask for a screenname so other parents in the community can offer you support and get connected with you. You can always choose not to connect with other parents.
           
                        </div>
                    </div>
                    <span>* It looks like you mistyped your zip code. Please try again.</span>
                </div>
            </div>

            <div class="sign-up-newsletter">
                <label for="email-checkbox">
                    <input type="checkbox" id="email-checkbox" checked>
                    <span>Yes, send me my email newsletter, customized for me and my family.</span>
                </label>

                <p>By signing up for Understood.org I acknowledge that I reside in the United States and am at least 13 years old.</p>

                <button class="button">Sign Up</button>

                <div class="we-take-your-privacy-seriously-container"><a class="we-take-your-privacy-seriously popover-link" href="REPLACE" data-popover-placement="bottom">We take your privacy seriously</a></div>

                <div class="we-take-your-privacy-seriously-popover popover-container">
                    <div class="we-take-your-privacy-seriously-content">
                        <strong>Understood.com</strong> is an independent, not-for-profit website. We collect your information so we can make your site experience relevant for you. We will not share your information and are not affiliated with any pharmaceutical or other for-profit company. <a href="REPLACE">Read our privacy policy</a>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>
<!-- END PARTIAL: sign-up -->
