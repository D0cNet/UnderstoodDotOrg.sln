<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommunitySubHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.CommunitySubHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN PARTIAL: pagetopic -->
<!-- Page Title -->
<div class="container community-main-header">
    <header>
        <div class="row  header-wrapper">

            <div class="col col-14 offset-1 header-title rs_read_this">

                <asp:HyperLink runat="server" ID="hlBreadcrumbNav" CssClass="back-to-previous"><i class="icon-arrow-left-blue"></i><asp:Literal runat="server" ID="txtBreadcrumbNav"/></asp:HyperLink>

                <h1><%--Grade School--%>
                    <asp:Literal runat="server" ID="scTopicTitle"></asp:Literal>
                </h1>

            </div>

            <div class="col col-9 header-share-save">
                <!-- BEGIN PARTIAL: share-save -->
                <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />

                <!-- END PARTIAL: share-save -->
            </div>

        </div>
    </header>


    <nav class="container nav-secondary">
        <div class="row">
            <div class="col col-24">

                <!-- BEGIN ELEMENT: Menu -->

                <div class="label-menu"><span><%= UnderstoodDotOrg.Common.DictionaryConstants.MenuFragment %></span></div>
                <ul class="menu" aria-label="secondary-navigation" aria-role="navigation">
                    <li class="submenu">
                        <div class="inner">
                            <div class="label-more"><span><%= UnderstoodDotOrg.Common.DictionaryConstants.MoreFragment %> <i class="icon-hide-show-fff"></i></span></div>
                            <ul>
                                <asp:Repeater runat="server" ID="rptTopicHeader" OnItemDataBound="rptTopicHeader_ItemDataBound">
                                    <ItemTemplate>
                                        <li id="listItem" runat="server"><span><%--<a href="REPLACE" class="selected">Overview</a>--%>
                                            <asp:HyperLink runat="server" ID="hlNavigationTitle"></asp:HyperLink>
                                        </span></li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                        <!-- .inner -->
                    </li>
                    <!-- .submenu -->
                </ul>
                <!-- .menu -->

                <!-- END ELEMENT: Menu -->

            </div>
            <!-- .col -->
        </div>
        <!-- .row -->
    </nav>
</div>
