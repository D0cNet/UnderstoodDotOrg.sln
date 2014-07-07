<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogMostSharedWidget.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.BlogMostSharedWidget" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="blog-most-shared">
    <h3><sc:Text Field="Most Shared This Week Text" runat="server" /></h3>
    <asp:Repeater ID="rptMostShared" runat="server"
        ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.BlogPost">
        <ItemTemplate>
            <h4><a href="<%# Item.Url %>"><%# Item.Title %></a></h4>
        </ItemTemplate>
    </asp:Repeater>
</div>
