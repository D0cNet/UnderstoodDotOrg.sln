<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConnectTemplateFront.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Notification_Templates.ConnectTemplateFront" %>
<li class="new-connection">
    <p class="timestamp">
        <i class="icon-notification-link"></i>
        <%#Eval("TimeStamp") %> <span class="dot"></span><%#Eval("FriendlyDate") %>
    </p>
    <p class="notification-item">
            <%# Eval("Action") %>
    </p>
    <p class="clearfix button-wrapper">
            <asp:LinkButton ID="btnAccept"  OnClick="btnAccept_Click"   Text="" CssClass="button rs_skip" runat="server" />
            <asp:LinkButton Text="" ID="btnDecline" OnClick="btnDecline_Click" CssClass="button gray rs_skip" runat="server" />
    </p>
</li>