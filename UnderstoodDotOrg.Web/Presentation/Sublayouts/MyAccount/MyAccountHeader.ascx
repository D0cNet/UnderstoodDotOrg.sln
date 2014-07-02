<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyAccountHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.MyAccountHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register Src="~/Presentation/Sublayouts/Tools/MyAccount/Private Message Tool.ascx" TagPrefix="uc1" TagName="PrivateMessageTool" %>

<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<div class="container">
    <div class="row back-to-previous-nav">
        <!-- article -->
        <div class="col col-22 offset-1">
            <asp:HyperLink ID="hlSectionTitle" runat="server" CssClass="back-to-previous"><i class="icon-arrow-left-blue"></i>Back to <sc:fieldrenderer id="frSectionTitle" runat="server" fieldname="Navigation Title" /></asp:HyperLink>
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
<!-- BEGIN PARTIAL: my-account-nav -->

<div class="container my-account-nav">
    <div class="row account-top-wrapper">
        <div class="col col-23 offset-1">
            <div class="account-photo skiplink-dashboard">
                <div style="display:none;" id="uploadAvatar">
                <asp:FileUpload ID="fuUserAvatar" runat="server" AllowMultiple="false" />
                <asp:Button ID="btnUpload" OnClick="FileUpload" Text="Upload Avatar" runat="server" />
                    </div>
                    <img style="height:150px; width:150px;" alt="150x150 Placeholder" id="userAvatar" runat="server" onclick="DisplayForm()" src="http://placehold.it/150x150" />
            </div>
            <div class="account-info">
                <h1 class="account-username"><%= CurrentMember.ScreenName %></h1>
                <p class="account-location"></p>
            </div>
            <div class="account-links">
                <a class="profile-link button" href="<%= MyProfilePage.GetUrl() %>"><%= MyProfilePage.MyAccountBase.ContentPage.BasePageNEW.NavigationTitle.Rendered %></a>
                <span class="button-wrapper">

                    <a class="notifications-link button" href='<%= MyNotifications %>' >Notifications<span class="notification-count" runat="server" visible="false" id="spnCount"><asp:Literal ID="litNotifCount" runat="server"></asp:Literal></span></a>

                </span>
            </div>
        </div>
    </div>
    <div class="account-nav-wrapper">
        <div class="row">
            <nav class="account-nav">
                <asp:Repeater ID="rptrAccountNav" runat="server"
                    ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.MyAccountBaseItem"
                    OnItemDataBound="rptrAccountNav_ItemDataBound">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlNavLink" runat="server" NavigateUrl="<%# Item.GetUrl() %>">
                            <div class="icon-wrapper">
                                <i class="<%# Item.IconCssClass.Rendered %>"></i>
                                <span><%# Item.AccountNavigationTitle.Rendered %></span>
                            </div>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:Repeater>
            </nav>
        </div>
    </div>
</div>
<!-- END PARTIAL: my-account-nav -->
<script>
    function DisplayForm() {
        var form = document.getElementById("uploadAvatar");
        if (form.style.display == "none") {
            form.style.display = "block";
        }
        else
            form.style.display = "none";
    }
</script>
