<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessControlTest.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AccessControlTest" %>

<%@ Register Src="~/Presentation/AccessControlTestControl.ascx" TagPrefix="uc1" TagName="AccessControlTestControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:AccessControlTestControl runat="server" ID="AccessControlTestControl" />
        </div>
    </form>
</body>
</html>
