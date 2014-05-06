<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reset_Password.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Reset_Password" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: reset-password -->
<div class="container reset-password flush">
    <div class="row skiplink-content" aria-role="main">
        <div class="col col-12 centered">
            <header>
                <h1><%--Reset Your Password--%>
                    <sc:Text id="PageHeading" runat="server" Field="Page Title"></sc:Text>
                </h1>
            </header>

            <%--<p>Please create a new password. Understood passwords must have 6 characters. You can use letters and/or numbers.</p>--%>
            <sc:Text id="description" runat="server" Field="Page Summary"></sc:Text>

            <label>
                <span class="visuallyhidden">Enter new password</span>
                <%--<input type="text" placeholder="Enter new password" aria-required="true">--%>
                <asp:TextBox ID="uxPassword" runat="server" TextMode="Password" aria-required="true"></asp:TextBox>
            </label>

            <label>
                <span class="visuallyhidden">Re-enter new password</span>
                <%--<input type="text" placeholder="Re-enter new password" aria-required="true">--%>
                <asp:TextBox ID="uxPasswordConfirm" runat="server" TextMode="Password" aria-required="true"></asp:TextBox>
            </label>

            <%--<button class="button">Save</button>--%>
            <asp:Button runat="server" ID="uxSave" OnClick="uxSave_Click" CssClass="button" />
            <asp:Literal ID="uxMessage" runat="server"></asp:Literal>
        </div>
    </div>
</div>
<!-- end .forgot-password -->

<!-- END PARTIAL: reset-password -->
