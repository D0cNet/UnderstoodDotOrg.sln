<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WidgetUploadUtility.aspx.cs" Inherits="Telligent.Evolution.SitecoreIntegration.Web.sitecore_modules.Shell.Telligent.Evolution.SitecoreIntegration.WidgetUtility" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Telligent Evolution Widget Utility</title>
    <link href="/default.css" rel="stylesheet" />
	<link href="a/css/utility.css" rel="stylesheet"  />
    <sc:VisitorIdentification runat="server" />
</head>
<body>
	<form id="form1" runat="server">
		<div class="header">
			<span>Select an Evolution Widget to Install</span>
		</div>
		<div class="content">
			<div class="field">
				<label class="block">Upload an Evolution Widget Export</label>
				<asp:FileUpload runat="server" ID="txtFile" />
			</div>
			
 			<div class="message">
				<asp:Literal runat="server" ID="litMessage" />
			</div>
		</div>
		<div class="actions">
        <asp:LinkButton runat="server" ID="btnClear" Text="Expire Widget Caches"/> 
			<asp:Button runat="server" ID="btnUpload" Text="Upload" />
    		   
		</div>
    </form>
</body>
</html>
