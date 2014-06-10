<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignIn.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.SignIn" %>
     <!-- BEGIN PARTIAL: sign-in -->
<div class="container sign-up-link">
  <div class="row">
    <div class="col col-23">
      <p>Not a member yet? <a href="REPLACE">Sign Up</a></p>
    </div>
  </div>
</div>
<div class="container myaccount-sign-in">
  <div class="row">
    <div class="col col-14 centered">
      <h1>Sign In</h1>
      <a class="fb-sign-in" href="REPLACE">
        <img alt="" src="Presentation/includes/img/icon.fb-sign-in@2x.png" />
      </a>
      <p>Or sign in with your email address</p>
      <label>
        <input type="text" placeholder="Enter email address" >
      </label>
      <label>
        <input type="text" placeholder="Enter Password" >
      </label>
      <button class="button">Sign In</button>
      <a class="sign-in-forgot-password" href="REPLACE">Forgot Your Password?</a>
    </div>
  </div>
</div>
<!-- END PARTIAL: sign-in -->
