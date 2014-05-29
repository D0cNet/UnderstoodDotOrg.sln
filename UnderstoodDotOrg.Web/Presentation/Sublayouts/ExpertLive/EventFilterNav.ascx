<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventFilterNav.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.EventFilterNav" %>

<!-- BEGIN PARTIAL: community/experts_sub_nav -->
<div class="container">
    <div class="row">
        <div class="container">
            <div class="experts-nav-form  rs_read_this clearfix skiplink-toolbar">
                <div class="dropdown">
                    <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                        <span class="current-page"><asp:Literal ID="litSelectedMenu" runat="server" /></span>
                        <span class="dropdown-title rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.FilterByLabel %></span>
                    </a>
                    <asp:Repeater runat="server" ID="rptFilter" OnItemDataBound="rptFilter_ItemDataBound">
                        <HeaderTemplate>
                            <ul role="menu" class="dropdown-menu rs_skip">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li role="presentation">
                                <sc:fieldrenderer runat="server" id="frLink" fieldname="Link" />
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <asp:DropDownList ID="ddlIssue" runat="server" AutoPostBack="true" />
                <asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="true" />
                <asp:DropDownList ID="ddlTopics" runat="server" AutoPostBack="true" />
            </div>
            <!-- experts-nav-form -->
        </div>
    </div>
</div>
<!-- END PARTIAL: community/experts_sub_nav -->