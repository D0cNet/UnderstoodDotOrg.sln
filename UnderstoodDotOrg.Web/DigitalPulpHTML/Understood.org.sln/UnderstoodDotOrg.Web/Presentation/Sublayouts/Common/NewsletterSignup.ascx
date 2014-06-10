<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsletterSignup.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.NewsletterSignup" %>
<!-- BEGIN MODULE: Newsletter Signup -->
<div class="container">
  <div class="row">

    <!-- FIXME: discard this div and move the .newsletter-signup class to div.container element for consistency -->
    <div class="newsletter-signup">

      <div class="col col-12">

        <header>
          <h2>Personalized Email</h2>
          <p>Stay connected with us by signing up for our weekly personalized emails.</p>
        </header>

      </div><!-- .col -->

      <div class="col col-12">

        <div class="form personalized-email-form">
          <fieldset class="input-wrap">
            <label for="personalized-email-email" class="visuallyhidden">Enter Email Address</label>
            <input type="email" name="personalized-email" id="personalized-email-email" placeholder="Enter email address" aria-required="true">
          </fieldset>
          <div class="submit-button-wrap">
            <input type="submit" class="submit-button" value="Sign Up">
          </div>
        </div>

      </div><!-- .col -->

    </div><!-- .newsletter-signup -->

  </div><!-- .row -->
</div><!-- .container -->

<!-- END MODULE: Newsletter Signup -->