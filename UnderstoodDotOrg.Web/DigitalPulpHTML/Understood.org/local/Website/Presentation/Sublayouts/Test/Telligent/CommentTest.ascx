<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentTest.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent.CommentTest" %>
<fieldset style="border:double black"><legend>Blog Post Contents</legend>
<asp:Literal ID="TextField" runat="server" />
</fieldset>
<br />
<form>
<asp:TextBox ID="TextBox" runat="server" />
<asp:Button ID="SubmitButton" OnClick="SubmitButton_Click" Text="Post Comment" runat="server" />
</form>
<br />
<br />
<asp:Repeater