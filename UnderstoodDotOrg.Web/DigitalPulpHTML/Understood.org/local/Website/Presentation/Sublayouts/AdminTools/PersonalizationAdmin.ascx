<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonalizationAdmin.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools.PersonalizationAdmin" %>
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
            Body:<sc:FieldRenderer FieldName="Instructions" ID="scInstructions" runat="server" />
            <br />
            <br />
            Select a User:<asp:DropDownList ID="ddlSelectParent" runat="server">
            </asp:DropDownList>
            <br />
            Select a Child:<asp:DropDownList ID="ddlSelectChild" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="btnRunPersonalization" runat="server" OnClick="btnRunPersonalization_Click" Text="Preview Personalization" />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text="No Results"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col col-24">
            <asp:GridView ID="gridPreview" runat="server" DataSourceID="ContentObjectDataSource">
            </asp:GridView>
            <asp:ObjectDataSource ID="ContentObjectDataSource" runat="server"></asp:ObjectDataSource>
        </div>
    </div>
    <br />
    <hr />

    <div class="row">
        <div class="col col-24">
            Help:<sc:FieldRenderer FieldName="Help Email" ID="scHelpEmail" runat="server" />
        </div>
    </div>

    
</div>
