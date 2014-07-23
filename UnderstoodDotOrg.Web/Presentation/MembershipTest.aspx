<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MembershipTest.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.MembershipTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Old Email: <asp:Literal runat="server" ID="litEmail"></asp:Literal><br />
            New Email: <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox> <br />
            <asp:Button ID="btnGo" runat="server" Text="Update" OnClick="btnGo_Click" />
        </div>
    </form>
</body>
</html>
