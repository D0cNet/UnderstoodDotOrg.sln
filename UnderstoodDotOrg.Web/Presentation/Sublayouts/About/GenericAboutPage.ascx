<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenericAboutPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.GenericAboutPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container l-about-understood">
    <div class="row">
        <div class="col col-15 offset-1 skiplink-content" aria-role="main">
            <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />
        </div>
    </div>
</div>
