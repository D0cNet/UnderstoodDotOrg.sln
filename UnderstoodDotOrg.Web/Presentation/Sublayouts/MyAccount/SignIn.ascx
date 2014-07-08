<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignIn.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.SignIn" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: sign-in -->
<div class="container sign-up-link">
    <div class="row">
        <div class="col col-23">
            <p><sc:FieldRenderer runat="server" FieldName="P Tag Not A Member Text" /> <asp:HyperLink runat="server" ID="uxRegisterLink"></asp:HyperLink></p>
        </div>
    </div>
</div>
<div class="container myaccount-sign-in">
    <div class="row">
        <div class="col col-14 centered">
            <h1>Sign In</h1>
            <a class="fb-sign-in" href="REPLACE">
                <sc:Image ID="scFacebookSigninImage" runat="server" Field="FacebookSigninImage" />
            </a>
            <div id="fb-root"></div>
            <p>
                <%--Or sign in with your email address--%>
                <sc:Text ID="directions" runat="server" Field="Directions"></sc:Text>
            </p>
            <label>
                <%--<input type="text" placeholder="Enter email address"> --%>
                <asp:TextBox ID="uxEmailAddress" runat="server"></asp:TextBox>
            </label>
            <label>
                <%--<input type="text" placeholder="Enter Password" >--%>
                <asp:TextBox ID="uxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </label>

            <div>
                <span class="validationerror">
                    <asp:Literal ID="uxError" runat="server"></asp:Literal>
                </span>
            </div>
            <%--<button class="button">Sign In</button>--%>
            <asp:Button CssClass="button" ID="uxSignIn" runat="server" OnClick="uxSignIn_Click" />
            <%--<a class="sign-in-forgot-password" href="REPLACE">Forgot Your Password?</a>--%>
            <asp:HyperLink runat="server" ID="uxForgotPassword" CssClass="sign-in-forgot-password"></asp:HyperLink>

        </div>
    </div>
</div>
<!-- END PARTIAL: sign-in -->
