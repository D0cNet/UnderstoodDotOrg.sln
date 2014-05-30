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
<asp:Button ID="btnEM2" runat="server" Text="EM2" OnClick="btnEM2_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM3" runat="server" Text="EM3" OnClick="btnEM3_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM4" runat="server" Text="EM4" OnClick="btnEM4_Click" />
<br /><br />
<hr />
<%--<asp:Button ID="btnEM5" runat="server" Text="EM5" OnClick="btnEM5_Click" />
<br /><br />
<hr />--%>
<asp:Button ID="btnEM6" runat="server" Text="EM6" OnClick="btnEM6_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM7" runat="server" Text="EM7" OnClick="btnEM7_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM8" runat="server" Text="EM8" OnClick="btnEM8_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM9" runat="server" Text="EM9" OnClick="btnEM9_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM10" runat="server" Text="EM10" OnClick="btnEM10_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM11" runat="server" Text="EM11" OnClick="btnEM11_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM12" runat="server" Text="EM12" OnClick="btnEM12_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM13" runat="server" Text="EM13" OnClick="btnEM13_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM14" runat="server" Text="EM14" OnClick="btnEM14_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM15" runat="server" Text="EM15" OnClick="btnEM15_Click" />
<br /><br />
<br />
<asp:Button ID="btnEM16" runat="server" Text="EM16" OnClick="btnEM16_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM17" runat="server" Text="EM17" OnClick="btnEM17_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM18" runat="server" Text="EM18" OnClick="btnEM18_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM19" runat="server" Text="EM19" OnClick="btnEM19_Click" />
<br /><br />
<hr />
<%--<asp:Button ID="btnEM20" runat="server" Text="EM20" OnClick="btnEM20_Click" />
<br /><br />
<hr />--%>
<asp:Button ID="btnEM21" runat="server" Text="EM21" OnClick="btnEM21_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM22" runat="server" Text="EM22" OnClick="btnEM22_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM23" runat="server" Text="EM23" OnClick="btnEM23_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM24" runat="server" Text="EM24" OnClick="btnEM24_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM25" runat="server" Text="EM25" OnClick="btnEM25_Click" />
<br /><br />
<hr />
<asp:Button ID="btnEM28" runat="server" Text="EM28" OnClick="btnEM28_Click" />
<br /><br />
<hr />
<hr />
<br />
<h4>Results:</h4>
<asp:Label ID="lblMessage" runat="server" ></asp:Label>
<br /><br />