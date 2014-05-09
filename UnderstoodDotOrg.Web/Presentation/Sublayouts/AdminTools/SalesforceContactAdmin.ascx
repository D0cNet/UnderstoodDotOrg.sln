<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalesforceContactAdmin.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools.SalesforceContactAdmin" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article">
    <div class="row">
        <div class="col col-24">
         Title:<sc:FieldRenderer  FieldName="Page Title" ID="scPageTitle" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col col-24">
            Subheader: <sc:FieldRenderer FieldName="Page Subtitle" ID="scPagetSubtitle" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col col-9">
            First Name:<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br /> 
        </div>
    </div>
    <div class="row">
        <div class="col col-9">
            Last Name:<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
         </div>
    </div>
   <div class="row">
        <div class="col col-9">
            Email:<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br /> 
        </div>
    </div>
       <div class="row">
            <div class="col col-9">
                <asp:Button ID="btnSubmit" runat="server" Text="Create Member in Salesforce" OnClick="btnSubmit_Click" />
            </div>
       </div>
</div>
