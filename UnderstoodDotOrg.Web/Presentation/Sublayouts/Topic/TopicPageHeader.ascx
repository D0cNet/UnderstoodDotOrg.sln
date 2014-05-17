<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicPageHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic.TopicPageHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN PARTIAL: pagetopic -->
<!-- Page Title -->
<div class="container <%= AdditionalCssClass %>">
    
        <div class="row  header-wrapper">

            <div class="col col-14 offset-1 header-title rs_read_this">

                <asp:HyperLink runat="server" ID="hlBreadcrumbNav" CssClass="back-to-previous">
                    <i class="icon-arrow-left-blue"></i>
                    <asp:Literal runat="server" ID="txtBreadcrumbNav"></asp:Literal>
                </asp:HyperLink>

                <h1><%--Grade School--%>
                    <asp:Literal runat="server" ID="scTopicTitle"></asp:Literal>
                </h1>

            </div>

            <div class="col col-9 header-share-save">
                <!-- BEGIN PARTIAL: share-save -->
                <div class="share-save-container">
                    <div class="share-save-social-icon">
                        <div class="toggle">
                            <a class="socicon icon-facebook" href="REPLACE">Facebook</a><br>
                            <a class="socicon icon-twitter" href="REPLACE">Twitter</a><br>
                            <a class="socicon icon-googleplus" href="REPLACE">Google+</a><br>
                            <a class="socicon icon-pinterest" href="REPLACE">Pinterest</a><br>
                        </div>
                    </div>
                    <div class="share-save-icon">
                        <h3>Share &amp; Save</h3>
                        <!-- leave no white space for layout consistency -->
                        <a class="icon icon-share" href="REPLACE">Share</a><span class="tools"><a class="icon icon-email" href="REPLACE">Email</a><a class="icon icon-save" href="REPLACE">Save</a><a class="icon icon-print" href="REPLACE">Print</a><a class="icon icon-remind" href="REPLACE">Remind</a><a class="icon icon-rss" href="REPLACE">RSS</a></span>
                    </div>
                </div>

                <!-- END PARTIAL: share-save -->
            </div>

        </div>
    


    
</div>
<nav class="container nav-secondary">
    <div class="row">
        <div class="col col-24">

            <!-- BEGIN ELEMENT: Menu -->

            <div class="label-menu"><span><%= UnderstoodDotOrg.Common.DictionaryConstants.MenuButtonText %></span></div>
            <ul class="menu" aria-label="secondary-navigation" aria-role="navigation">
                <li class="title"><span><%= UnderstoodDotOrg.Common.DictionaryConstants.OverviewButtonText %></span> <i class="icon-hide-show-fff"></i></li>
                <li class="submenu">
                    <div class="inner">
                        <div class="label-more"><button><%= UnderstoodDotOrg.Common.DictionaryConstants.MoreButtonText %> <i class="icon-hide-show-fff"></i></button></div>
                        <ul>
                            <asp:Repeater runat="server" ID="rptTopicHeader" OnItemDataBound="rptTopicHeader_ItemDataBound">
                                <ItemTemplate>
                            <li><span><%--<a href="REPLACE" class="selected">Overview</a>--%>
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

