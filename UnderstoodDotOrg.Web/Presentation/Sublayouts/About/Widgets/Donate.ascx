<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Donate.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Widgets.DonateWidget" %>
<div class="donate rs_read_this">
    <h4><%= Model.Title.Rendered %></h4>
    <p><%= Model.Body.Rendered %></p>
    <ul class="donation-amounts group">
        <li>
            <asp:HyperLink CssClass="button" ID="hypDonate25" runat="server">$25</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink CssClass="button" ID="hypDonate50" runat="server">$50</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink CssClass="button" ID="hypDonate100" runat="server">$100</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink CssClass="button" ID="hypDonateOther" runat="server"><%= Model.OtherOptionLabel.Rendered %></asp:HyperLink>
        </li>
    </ul>
</div>
<!-- .donate -->
