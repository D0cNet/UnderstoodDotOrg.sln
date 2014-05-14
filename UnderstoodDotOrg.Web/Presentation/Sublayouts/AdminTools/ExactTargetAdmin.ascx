<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExactTargetAdmin.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools.ExactTargetAdmin" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<h2>This is a test area for ExactTarget</h2>
<br />
<hr />
<h4>Email Information From ExactTarget</h4>
<br />
<asp:Label ID="lblEmailID" runat="server" Text="Email ID"></asp:Label><asp:TextBox ID="tbxEmailID" runat="server"></asp:TextBox>  Available in the ET UI [Content > My Emails > Properties] 
<br />
<asp:Label ID="lblCustomerKey" runat="server" Text="Customer Key"></asp:Label><asp:TextBox ID="tbxCustomerKey" runat="server"></asp:TextBox>  Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
<br />
<hr />
<h4>Subscriber 1:</h4>
<asp:Label ID="lblSubscriberEmail1" runat="server" Text="Subscriber Email 1"></asp:Label><asp:TextBox ID="tbxSubscriberEmail1" runat="server" Width="250px"></asp:TextBox>
<br />
<asp:Label ID="lblSubscriberKey1" runat="server" Text="Key 1"></asp:Label><asp:TextBox ID="tbxSubscriberKey1" runat="server" Width="250px"></asp:TextBox>
<br />
<asp:Label ID="lblSubscriberFN1" runat="server" Text="First Name 1"></asp:Label><asp:TextBox ID="tbxSubscriberFN1" runat="server" Width="250px"></asp:TextBox>
<br />
<br />
<hr />
<h4>Subscriber 2:</h4>
<asp:Label ID="lblSubscriberEmail2" runat="server" Text="Subscriber Email 2"></asp:Label><asp:TextBox ID="tbxSubscriberEmail2" runat="server" Width="250px"></asp:TextBox>
<br />
<asp:Label ID="lblSubscriberKey2" runat="server" Text="Key 2"></asp:Label><asp:TextBox ID="tbxSubscriberKey2" runat="server" Width="250px"></asp:TextBox>
<br />
<asp:Label ID="lblSubscriberFN2" runat="server" Text="First Name 2"></asp:Label><asp:TextBox ID="tbxSubscriberFN2" runat="server" Width="250px"></asp:TextBox>
<br />
<br />
<hr />
<asp:Button ID="btnETTests" runat="server" Text="Invoke Trigger Send Email" OnClick="btnETTests_Click" />
<br />
<br /><!-- START OF PASSWORD RESET TEST -->
<h3>Reset Password Email Test</h3>
<br />
<asp:Label ID="Label3" runat="server" Text="Enter your reset link here"></asp:Label><asp:TextBox ID="txtResetLink" runat="server"  />
<br />
<br />
<h4>Results:</h4>
<asp:Label ID="lblMessage" runat="server" ></asp:Label>
<br /><br />