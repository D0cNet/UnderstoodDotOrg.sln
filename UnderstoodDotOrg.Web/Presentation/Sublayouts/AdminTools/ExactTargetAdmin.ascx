<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExactTargetAdmin.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools.ExactTargetAdmin" ValidateRequestMode="Disabled" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<h2>This is a test area for ExactTarget</h2>
<br />
<hr />
<asp:Label ID="LabelHtmlContent" runat="server" Text="HTML content for Emails without predefined content"></asp:Label>
<br />
<asp:TextBox ID="txtHtmlContent" runat="server" TextMode="multiline" rows="10" Width="450px" validateRequest="false"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label1" runat="server" Text="HTML for webinar module"></asp:Label>
<br />
<asp:TextBox ID="txtWebinarCode" runat="server" TextMode="multiline" rows="10" Width="450px" validateRequest="false"></asp:TextBox>
<br />
<br />
<h4>Subscriber 1:</h4>
<asp:Label ID="lblSubscriberEmail1" runat="server" Text="Subscriber Email 1"></asp:Label><asp:TextBox ID="tbxSubscriberEmail1" runat="server" Width="250px"></asp:TextBox>
<br />
<asp:Label ID="lblSubscriberKey1" runat="server" Text="Key 1"></asp:Label><asp:TextBox ID="tbxSubscriberKey1" runat="server" Width="250px"></asp:TextBox>
<br />
<asp:Label ID="lblSubscriberFN1" runat="server" Text="First Name 1"></asp:Label><asp:TextBox ID="tbxSubscriberFN1" runat="server" Width="250px"></asp:TextBox>
<br />
<br />
<hr />
<asp:Button ID="btnETTests" runat="server" Text="Invoke Trigger Send Email" OnClick="btnETTests_Click" />
<br /><br />
<br />
<br />
<h4>Results:</h4>
<asp:Label ID="lblMessage" runat="server" ></asp:Label>
<br /><br />