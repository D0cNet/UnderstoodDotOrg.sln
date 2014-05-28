<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DidYouFindThisHelpfulOther.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.DidYouFindThisHelpfulOther" %>

<div class="find-this-helpful content">

    <h4><asp:Literal ID="ltlDidYouFindThisHelpful" runat="server"></asp:Literal></h4>
    <ul>
        <li>
            <button class="helpful-yes"><asp:Literal ID="ltlYes" runat="server"></asp:Literal></button>
        </li>
        <li>
            <button class="helpful-no"><asp:Literal ID="ltlNo" runat="server"></asp:Literal></button>
        </li>
    </ul>
    <div class="clearfix"></div>

</div>