<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SectionTools.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Section.SectionTools" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container mini-tools-wrap" style="<%= BackgroundImage %>">

    <div class="row">
        <asp:Repeater ID="rptWidgets" runat="server">
            <ItemTemplate>
                <div class="col col-8 <%# Container.ItemIndex == 0 ? "skiplink-content" : "" %>" <%# Container.ItemIndex == 0 ? "aria-role=\"main\"" : "" %>>
                    <section class="mini-tool rs_read_this">
                        <sc:Sublayout ID="slWidget" runat="server" />
                    </section>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</div>
