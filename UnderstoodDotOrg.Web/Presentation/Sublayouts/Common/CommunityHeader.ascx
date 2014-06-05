<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommunityHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: community/main_header -->
<div class="container community-main-header ">
    <header>
        <div class="row header-wrapper">
            <div class="col col-14 offset-1 header-title">
                <h1>Welcome to the Understood Community</h1>
                <p class="subhead">A private parent community with expert guidance and support</p>
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
                <div class="label-menu"><span>Menu</span></div>
                <ul class="menu" aria-role="navigation" aria-label="secondary-navigation">
                    <li class="title">
                        <p class="select-topic">Select a topic:</p>
                        <button><asp:Literal ID="litInitialMenuChoice" runat="server" /></button>
                        <i class="icon-hide-show-fff"></i>
                    </li>
                    <li class="submenu">
                        <div class="inner">
                            <div class="label-more">
                                <button>More <i class="icon-hide-show-fff"></i></button>
                            </div>
                            <ul>
                                <asp:Repeater ID="rptLinks" runat="server">
                                    <ItemTemplate>
                                        <li><span><sc:FieldRenderer ID="frLink" runat="server" FieldName="Link" /></span></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</div>
