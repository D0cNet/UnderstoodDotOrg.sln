<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoreToExplore.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.MoreToExplore" %>
<!-- BEGIN PARTIAL: footer -->
<!-- BEGIN MODULE: More to Explore -->
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container more-to-explore">
    <div class="row">
        <div class="col col-24">

            <h2 class="rs_read_this">
                <sc:FieldRenderer ID="frMoreExploreTitle" runat="server" FieldName="More Explore Title"></sc:FieldRenderer>
            </h2>

        </div>
    </div>
    <div class="row">
        <div class="col col-24">

            <!-- BEGIN PARTIAL: more-explore-carousel -->
            <div class="more-to-explore-container">
                <asp:Repeater ID="rptMoreExplorer" runat="server" OnItemDataBound="rptMoreExplorer_ItemDataBound">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <sc:Sublayout ID="slTile" runat="server" />
                            <%--<sc:FieldRenderer ID="frMoreExploreText" runat="server" FieldName="Explore Text"></sc:FieldRenderer>--%>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <!-- END PARTIAL: more-explore-carousel -->

        </div>
    </div>
</div>

<!-- END MODULE: More to Explore -->
