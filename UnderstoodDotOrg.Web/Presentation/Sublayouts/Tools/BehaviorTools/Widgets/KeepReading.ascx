<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KeepReading.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.Widgets.KeepReading" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptRelatedArticles" runat="server">
    <HeaderTemplate>
        <div class="keep-reading">
            <h3><sc:FieldRenderer runat="server" FieldName="Sidebar Related Articles Title" /></h3>
            <ul>
    </HeaderTemplate>
    <ItemTemplate>
                <li <%# (Container.ItemIndex + 1 == rptRelatedArticles.Items.Count) ? "last-child" : "" %>><asp:HyperLink ID="hlArticleLink" runat="server" /></li>
    </ItemTemplate>
    <FooterTemplate>
            </ul>
        </div>
    </FooterTemplate>
</asp:Repeater>