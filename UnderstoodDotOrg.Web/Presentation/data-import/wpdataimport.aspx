<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wpdataimport.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.data_import.wpdataimport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:RadioButtonList runat="server" ID="rblArticleType" >
        <asp:ListItem Text="Basic Article Image" Value="1" ></asp:ListItem>
        <asp:ListItem Text="Video" Value="2" ></asp:ListItem>
        <asp:ListItem Text="Audio" Value="3" ></asp:ListItem>
        <asp:ListItem Text="Slide show" Value="4" ></asp:ListItem>
        <asp:ListItem Text="Deep Dive Article" Value="5" ></asp:ListItem>
        <asp:ListItem Text="Infographic" Value="6" ></asp:ListItem>
        <asp:ListItem Text="Simple Expert Article" Value="7" ></asp:ListItem>
        <asp:ListItem Text="Text Only Tips Article" Value="8" ></asp:ListItem>
        <asp:ListItem Text="Action Style Listing" Value="9" ></asp:ListItem>
        <asp:ListItem Text="Toolkit" Value="10" ></asp:ListItem>
        <asp:ListItem Text="Checklist" Value="11" ></asp:ListItem>
        <asp:ListItem Text="Quiz" Value="12" ></asp:ListItem>
    </asp:RadioButtonList>
        <asp:Button runat="server" Text="Import" Id="btnSubmit" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
