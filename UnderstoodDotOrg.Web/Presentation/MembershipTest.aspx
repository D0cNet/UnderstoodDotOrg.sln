<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MembershipTest.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.MembershipTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        ValidateRadioButtons = function (sender, args) {
            args.IsValid = $("input[name*=" + sender.groupName + "]:checked").length > 0;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="radio-toggle-wrapper">
            <label class="button">
                Boy
                <asp:RadioButton ID="uxBoy" runat="server" GroupName="q1a" />
            </label>
            <label class="button">
                Girl
                <asp:RadioButton ID="uxGirl" runat="server" GroupName="q1a" />
            </label>
            <div>
                <asp:CustomValidator ID="valGender" runat="server" ClientValidationFunction="ValidateRadioButtons"></asp:CustomValidator>
            </div>
        </div>
        <div class="radio-toggle-wrapper">
            <label class="button">
                Boy
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="q2a" />
            </label>
            <label class="button">
                Girl
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="q2a" />
            </label>
            <div>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateRadioButtons"></asp:CustomValidator>
            </div>
        </div>
        <div>
            <asp:TextBox ID="uxText" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valText" runat="server" ControlToValidate="uxText" ErrorMessage="provide a value in the textbox"></asp:RequiredFieldValidator>
        </div>
        <asp:Button Text="Submit" ID="uxSubmit" runat="server" CausesValidation="true" />
    </form>

    <script src="/Presentation/includes/js/vendor/jquery-1.10.2.min.js" type="text/javascript"></script>




</body>
</html>
