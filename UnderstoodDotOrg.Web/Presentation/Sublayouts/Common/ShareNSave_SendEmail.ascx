<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareNSave_SendEmail.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ShareNSave_SendEmail" %>

<div>
    Send this to friend<br />
    enter your name <asp:TextBox ID="txtYourname" runat="server"></asp:TextBox><br />
    enter your email <asp:TextBox ID="txtYourEMailID" runat="server"></asp:TextBox><br />
    enter recipent's EmailID<asp:TextBox ID="txtRecipentEMailID" runat="server"></asp:TextBox><br />
    I saw this and thought you might find it helpful<asp:TextBox ID="txtThoughts" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />




</div>