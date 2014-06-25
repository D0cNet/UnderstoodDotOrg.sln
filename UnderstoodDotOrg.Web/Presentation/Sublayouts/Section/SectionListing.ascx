<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SectionListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Section.SectionListing" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<%--<!-- BEGIN PARTIAL: children-key -->
<div class="container child-content-indicator first">
    <!-- Key -->
    <div class="row">
        <div class="col col-23 offset-1">
            <div class="children-key">
                <ul>
                    <li><i class="child-a"></i>for Michael</li>
                    <li><i class="child-b"></i>for Elizabeth</li>
                    <li><i class="child-c"></i>for Ethan</li>
                    <li><i class="child-d"></i>for Jeremy</li>
                    <li><i class="child-e"></i>for Franklin</li>
                </ul>
            </div>
            <!-- .children-key -->
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>
<!-- .child-content-indicator -->
<!-- END PARTIAL: children-key -->--%>
<sc:sublayout runat="server" path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />

<!-- FIXME: should all .listing elements on this page be combined into one? -->


<asp:Repeater runat="server" ID="rptTopicLandingItems" OnItemDataBound="rptTopicLanding_ItemDataBound">
    <ItemTemplate>
        <!-- BEGIN MODULE: Listing -->
        <div class="container listing">
            <div class="rs_read_this row">
                <!-- Listing Row -->
                <div class="row">
                    <div class="col col-23 offset-1 skiplink-content" aria-role="main">
                        ">
                    <h2><%--<a href="REPLACE">Early Learners <i class="icon-arrow-right-blue"></i></a>--%>
                        <asp:HyperLink ID="hlTopicLink" runat="server">
                        </asp:HyperLink><i class="icon-arrow-right-blue"></i>
                    </h2>
                    </div>
                </div>

                <div class="row listing-row">
                    <asp:Repeater runat="server" ID="rptTopicListItems" OnItemDataBound="rptTopicListItems_ItemDataBound">
                        <ItemTemplate>
                            <asp:PlaceHolder ID="phThumbnail" runat="server" Visible="false">
                                <div class="col col-5 offset-1">
                                    <asp:Image ID="imgThumbnail" runat="server" />
                                </div>
                            </asp:PlaceHolder>
                            <div class="col col-5 offset-1">
                                <h3>
                                    <asp:HyperLink ID="hlTopicTitle" runat="server" />
                                </h3>
                                <div class="children">
                                    <i class="child-a" title="CHILD NAME HERE"></i><i class="child-c" title="CHILD NAME HERE"></i><i class="child-e" title="CHILD NAME HERE"></i>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>

                </div>
                <!-- .row -->
            </div>
        </div>
        <!-- END MODULE: Listing -->
    </ItemTemplate>
</asp:Repeater>



<%--<!-- BEGIN PARTIAL: children-key -->
<div class="container child-content-indicator second">
    <!-- Key -->
    <div class="row">
        <div class="col col-23 offset-1">
            <div class="children-key">
                <ul>
                    <li><i class="child-a"></i>for Michael</li>
                    <li><i class="child-b"></i>for Elizabeth</li>
                    <li><i class="child-c"></i>for Ethan</li>
                    <li><i class="child-d"></i>for Jeremy</li>
                    <li><i class="child-e"></i>for Franklin</li>
                </ul>
            </div>
            <!-- .children-key -->
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>
<!-- .child-content-indicator -->
<!-- END PARTIAL: children-key -->--%>
<sc:sublayout runat="server" path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
