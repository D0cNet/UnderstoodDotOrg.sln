<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reset_Password.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Reset_Password" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: reset-password -->
<asp:Panel runat="server" DefaultButton="uxSave" CssClass="container reset-password flush">
    <div class="row skiplink-content" aria-role="main">
        <div class="col col-12 centered">
            <header>
                <h1><%--Reset Your Password--%>
                    <sc:Text ID="PageHeading" runat="server" Field="Page Title"></sc:Text>
                </h1>
            </header>
            <sc:FieldRenderer runat="server" ID="frPasswordDirections" FieldName="Directions"/>
            <sc:Text ID="description" runat="server" Field="Body Content"></sc:Text>

            <label>
                <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.EnterNewPasswordWatermark %></span>
                <%--<input type="text" placeholder="Enter new password" aria-required="true">--%>
                <asp:TextBox ID="uxPassword" runat="server" TextMode="Password" aria-required="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="uxPassword" CssClass="validationerror"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="valRegPassword" runat="server" ControlToValidate="uxPassword" CssClass="validationerror"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="valCompPassword" runat="server" ControlToValidate="uxPassword" ControlToCompare="uxPasswordConfirm" CssClass="validationerror"></asp:CompareValidator>
            </label>

            <label>
                <span class="visuallyhidden">Re-enter new password</span>
                <%--<input type="text" placeholder="Re-enter new password" aria-required="true">--%>
                <asp:TextBox ID="uxPasswordConfirm" runat="server" TextMode="Password" aria-required="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPasswordConfirm" runat="server" ControlToValidate="uxPasswordConfirm" CssClass="validationerror"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="valRegPasswordConfirm" runat="server" ControlToValidate="uxPasswordConfirm" CssClass="validationerror"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="valCompPasswordConfirm" runat="server" ControlToValidate="uxPasswordConfirm" ControlToCompare="uxPassword" CssClass="validationerror"></asp:CompareValidator>
            </label>

            <%--<button class="button">Save</button>--%>
            <asp:Button runat="server" ID="uxSave" OnClick="uxSave_Click" CssClass="button" />
            <asp:Literal ID="uxMessage" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Panel>
<!-- end .forgot-password -->

<!-- END PARTIAL: reset-password -->
