<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignIn.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.SignIn" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: sign-in -->
<div class="container sign-up-link">
    <div class="row">
        <div class="col col-23">
            <p>Not a member yet? <%--<a href="REPLACE">Sign Up</a>--%><asp:HyperLink runat="server" ID="uxRegisterLink"></asp:HyperLink></p>
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
            <p>
                <%--Or sign in with your email address--%>
                <sc:Text id="directions" runat="server" Field="Directions" ></sc:Text>
            </p>
            <label>
                <%--<input type="text" placeholder="Enter email address" --%>>
          <asp:TextBox ID="uxEmailAddress" runat="server"></asp:TextBox>
            </label>
            <label>
                <%--<input type="text" placeholder="Enter Password" >--%>
                <asp:TextBox ID="uxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </label>
            <%--<button class="button">Sign In</button>--%>
            <asp:Button CssClass="button" ID="uxSignIn" runat="server" OnClick="uxSignIn_Click" />
            <a class="sign-in-forgot-password" href="REPLACE">Forgot Your Password?</a>
            <asp:Literal ID="uxError" runat="server"></asp:Literal>
        </div>
    </div>
</div>
<!-- END PARTIAL: sign-in -->
