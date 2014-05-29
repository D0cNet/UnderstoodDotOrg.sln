<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuizKeepReadingControl.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.QuizKeepReadingControl" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

      <!-- BEGIN PARTIAL: keep-reading -->
<%--<div class="keep-reading keep-reading-mobile">--%>
<div class="keep-reading keep-reading-lg">
  <h3><%--Keep Reading--%>
      <sc:FieldRenderer ID="frHeadline"  runat="server" FieldName="Keep Reading Headline"/>
  </h3>
    <asp:Repeater ID="rptKeepReading" runat="server" OnItemDataBound="rptKeepReading_ItemDataBound">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="hlPageTitle" runat="server">
                    <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                </asp:HyperLink>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>