<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwoRow.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Containers.TwoRow" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="content cf">
    <div class="wrapper">
        <div id="content_overview">
            <sc:Placeholder ID="top" runat="server" Key="top" />
        </div>
        <div >
            <sc:Placeholder ID="bottom" runat="server" Key="bottom" />
        </div>  
    </div>
</div>