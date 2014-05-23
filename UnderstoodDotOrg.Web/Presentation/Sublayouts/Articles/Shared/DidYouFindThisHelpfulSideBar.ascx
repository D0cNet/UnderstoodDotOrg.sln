<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DidYouFindThisHelpfulSideBar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.DidYouFindThisHelpfulSideBar" %>

<div class="find-this-helpful-large">
    <!-- Module within only appears in over 650px window width-->
    <!-- BEGIN PARTIAL: find-helpful -->
    <div class="find-this-helpful sidebar">
        <h4><asp:Literal ID="ltlDidYouFindThisHelpful" runat="server"></asp:Literal></h4>
        <ul>
            <li>
                <button class="helpful-yes"><asp:Literal ID="ltlYes" runat="server"></asp:Literal></button>
            </li>
            <li>
                <button class="helpful-no"><asp:Literal ID="ltlNo" runat="server"></asp:Literal></button>
            </li>
        </ul>
        <div class="clearfix">
        </div>
    </div>
    <!-- END PARTIAL: find-helpful -->
</div>
