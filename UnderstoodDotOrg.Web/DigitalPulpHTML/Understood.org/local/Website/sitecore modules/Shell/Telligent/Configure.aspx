<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configure.aspx.cs" Inherits="Telligent.Evolution.SitecoreIntegration.Web.Configure" %>
<%@ Register Namespace="Telligent.DynamicConfiguration.Controls" Assembly="Telligent.DynamicConfiguration" TagPrefix="TDC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <title>Configure</title>
        <link href="/sitecore/shell/themes/standard/default/Content Manager.css" rel="stylesheet" />
        <base target="_self" />
		<link href="a/css/utility.css" rel="stylesheet"  />		
    </head>
	<body spellcheck="true">
		<form runat="server">
			<div class="header">
				<span>Select and configure an Evolution Widget</span>
			</div>
			<div class="content">
				<div class="field">
					<label class="block" style="font-weight:bold">
						<asp:Label runat="server" Text="Select Widget" class="block"></asp:Label>
					</label>
					<asp:DropDownList runat="server" ID="ddlWidgets"></asp:DropDownList>
				</div>	
				<div class="scrollable">
					<div class="scEditorSections">
						<TDC:ConfigurationForm RenderGroupsInTabs="false" runat="server" ID="ConfigurationForm"  >
							<PropertyFormGroupHeaderTemplate>
								<div class="field-list-header"></div>
								<div class="scEditorSectionCaptionExpanded">
									<TDC:PropertyGroupData Property="Name" runat="server" />
								</div>
								<table class="scEditorSectionPanel" width="100%">
									<tr>
										<td class="scEditorSectionPanelCell">
							</PropertyFormGroupHeaderTemplate>			
							<PropertyFormPropertyTemplate>
									<table width="100%" cellspacing="0" cellpadding="0" border="0" class="scEditorFieldMarker field-item <%# Eval("ID") %>">
										<tbody>
											<tr>
												<td class="scEditorFieldMarkerBarCell" id="FieldMarker<%# Eval("ID") %>"></td>
												<td class="scEditorFieldMarkerInputCell">                            
													<div class="scEditorFieldLabel">
														<TDC:PropertyData Property="Name" runat="server" />
													</div>
													<div>
														<TDC:PropertyData Property="Description" runat="server" />
													</div>
													<div>
														<TDC:PropertyControl runat="server" />
													</div>
												</td>
											</tr>
										</tbody>
									</table>
							</PropertyFormPropertyTemplate>
							<PropertyFormGroupFooterTemplate>                
										</td>
									</tr>
								</table>
							</PropertyFormGroupFooterTemplate>
						</TDC:ConfigurationForm>
						<asp:Literal runat="server" ID="Values" />
					</div>
				</div>
			</div>
			<div class="actions">
				<asp:Button runat="server" Text="Save" ID="SaveButton" />
			</div>
        </form>
    </body>
</html>