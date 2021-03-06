﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicPageHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic.TopicPageHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN PARTIAL: pagetopic -->
<!-- Page Title -->

<div class="container page-topic with-share">
    <div class="row  header-wrapper">
        <div class="col col-14 offset-1 header-title rs_read_this">
            <asp:HyperLink runat="server" ID="hlBreadcrumbNav" CssClass="back-to-previous">
                <i class="icon-arrow-left-blue"></i>
                <asp:Literal runat="server" ID="litPreviousLink" />
            </asp:HyperLink>

            <h1>
                <asp:Literal runat="server" ID="litTitle" /></h1>
        </div>

        <div class="col col-9 header-share-save">
            <!-- BEGIN PARTIAL: share-save -->
            <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />

            <!-- END PARTIAL: share-save -->
        </div>
    </div>
</div>


<asp:Repeater runat="server" ID="rptTopicHeader" OnItemDataBound="rptTopicHeader_ItemDataBound">
    <HeaderTemplate>
        <nav class="container nav-secondary">
            <div class="row">
                <div class="col col-24">
                    <!-- BEGIN ELEMENT: Menu -->
                    <div class="label-menu"><span><%= UnderstoodDotOrg.Common.DictionaryConstants.MenuButtonText %></span></div>
                    <ul class="menu" aria-label="secondary-navigation" aria-role="navigation">
                        <li class="title">
                            <%-- UN-4965 TRANSLATION NEEDED --%>
                            <span><%--Overview--%>
                                <%= UnderstoodDotOrg.Common.DictionaryConstants.OverviewButtonText %>
                            </span>
                            <i class="icon-hide-show-fff"></i>
                        </li>
                        <li class="submenu">
                            <div class="inner">
                                <div class="label-more">
                                    <button><%= UnderstoodDotOrg.Common.DictionaryConstants.MoreButtonText %> <i class="icon-hide-show-fff"></i></button>
                                </div>
                                <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li id="liNav" runat="server"><span>
            <asp:HyperLink runat="server" ID="hlNavigationTitle"></asp:HyperLink>
        </span></li>
    </ItemTemplate>
    <FooterTemplate>
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
    </FooterTemplate>
</asp:Repeater>
