<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sandbox.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools.Sandbox" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>



    <h1>Test User Activity Logging</h1>
    User Guid:<asp:TextBox ID="txtMemberGuid" runat="server" Width="401px" ReadOnly="True">810EBB87-14E1-4DAF-8EAE-F69E1754C640</asp:TextBox>
<p>
    Content Item Guid<asp:TextBox ID="txtContentId" runat="server" ReadOnly="true" Width="401px">93BCF308-EE08-4F66-AB64-F4CB495BB64F</asp:TextBox>
</p>
<p>
    Activity Type<asp:TextBox ID="txtActivityType" runat="server">1</asp:TextBox>
</p>
Activity Value

<asp:TextBox ID="txtActivityValue" runat="server" Width="254px"></asp:TextBox>
<br /><br />
<asp:Button ID="btnActivityInsert" runat="server" Text="Submit User Activity" OnClick="btnActivityInsert_Click" />
<p>
    Was Activity Log a Success? <asp:Label ID="lblSuccess" runat="server" Text="Unknown" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
</p>

<hr />

<p>PosesUser3@mailinator.com
    </p>
<p>
    <br />
</p>
<p>
    &nbsp;</p>


<h1>Test Unauthorized Member Creation</h1>
Email<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
<br /><br />

<asp:Button ID="btnSubmit" runat="server" Text="Create Entry" OnClick="btnSubmit_Click" />
<hr />
Some quiz result tests<br />
Quizid: <asp:TextBox runat="server" id="txtQuizId"></asp:TextBox><br />
Selected Answer: <asp:TextBox runat="server" ID="txtAnswerId"></asp:TextBox><br />
Selected Answer Value: <asp:TextBox runat="server" ID="txtAnswerValue"></asp:TextBox><br />

<hr />
Test Quiz reader
<asp:Button ID="btnQuizReader" runat="server" Text="Read Quiz Results" OnClick="btnQuizReader_Click" />