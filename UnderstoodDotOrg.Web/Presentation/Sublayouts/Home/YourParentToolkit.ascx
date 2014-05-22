<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YourParentToolkit.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Home.YourParentToolkit" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN MODULE: Your Parent Toolkit -->
<div class="container parent-toolkit">
    <div class="row">
        <div class="col col-24">

            <header class="header-parent-toolkit">
                <h2>
                    <sc:FieldRenderer ID="frParentToolKitHeading" runat="server" FieldName="Your Parent Toolkit Heading" />
                </h2>
                <sc:FieldRenderer ID="frParentToolDetail" runat="server" FieldName="Your Parent Toolkit Details" />
            </header>
            <!-- .header-parent-toolkit -->

        </div>
        <!-- .col -->
    </div>
    <!-- .row -->

    <div class="row">
        <div class="col col-8 offset-3">

            <!-- BEGIN PARTIAL: behavior-tool -->
            <div class="behavior-tool">
                <div class="behavior-form select-container">

                    <h3>
                        <sc:FieldRenderer ID="frWidgetTitle" runat="server" FieldName="Widget Title" />
                    </h3>
                    <p>
                        <sc:FieldRenderer ID="frWidgetDetail" runat="server" FieldName="Widget Detail" />
                    </p>

                    <fieldset>
                        <label for="behaviortool-issue" class="visuallyhidden">Select behavior issue</label>
                        <asp:DropDownList ID="ddlChallengeGroups" runat="server"
                            RepeatLayout="unorderedlist" RepeatDirection="vertical" required="required" aria-required="true">
                        </asp:DropDownList>

                        <label for="behaviortool-grade" class="visuallyhidden">Select grade</label>
                        <asp:DropDownList ID="ddlGradeGroups" runat="server"
                            RepeatLayout="unorderedlist" RepeatDirection="vertical" required="required" aria-required="true">
                        </asp:DropDownList>
                    </fieldset>

                    <div class="submit-button-wrap">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_OnClick" Text="Submit" />
                        <%--<input class="submit-button" type="submit" value="Submit">--%>
                    </div>

                </div>
            </div>

            <!-- END PARTIAL: behavior-tool -->

        </div>
        <!-- .col -->
        <div class="col col-13">

            <!-- BEGIN PARTIAL: toolkit -->
            <div class="tools-container">
                <div id="toolkit-slides-container">
                    <asp:Repeater ID="rptEventCarousel" runat="server" OnItemDataBound="rptEventCarousel_ItemDataBound">
                        <ItemTemplate>
                            <asp:Literal runat="server" ID="litDevStart" Visible="false" Text="<div class='slide'>"></asp:Literal>
                            <asp:Literal runat="server" ID="litStartUL" Visible="false" Text="<ul>"></asp:Literal>
                            <li>
                                <div class="icon" runat="server" id="divIcon">
                                    <sc:Link ID="scLink" runat="server" Field="Link" />
                                </div>
                            </li>
                            <asp:Literal runat="server" ID="litEndUL" Visible="false" Text="</ul>"></asp:Literal>
                            <asp:Literal runat="server" ID="litDivEnd" Visible="false" Text="</div>"></asp:Literal>
                        </ItemTemplate>
                    </asp:Repeater>

                    <!-- .slide -->
                </div>
                <!-- #toolkit-slides-container -->
            </div>
            <!-- .tools-container -->
            <!-- END PARTIAL: toolkit -->

        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>
<!-- .container.parent-toolkit -->

<!-- END MODULE: Your Parent Toolkit -->
