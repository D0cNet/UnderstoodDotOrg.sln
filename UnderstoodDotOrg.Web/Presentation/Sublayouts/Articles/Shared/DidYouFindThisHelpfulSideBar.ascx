<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DidYouFindThisHelpfulSideBar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.DidYouFindThisHelpfulSideBar" %>

<div class="find-this-helpful-large">
    <!-- Module within only appears in over 650px window width-->
    <!-- BEGIN PARTIAL: find-helpful -->
    <div class="find-this-helpful sidebar">
        <h4><asp:Literal ID="ltlDidYouFindThisHelpful" runat="server"></asp:Literal></h4>
        <ul>
            <li>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" class="update-panel">
                    <ContentTemplate>
                        <button id="btnYes" runat="server" class="helpful-yes" onserverclick="btnYes_ServerClick"></button>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </li>
            <li>
                <button id="btnNo" runat="server" class="helpful-no"></button>
            </li>
        </ul>
        <div class="clearfix">
        </div>
    </div>
    <!-- END PARTIAL: find-helpful -->
</div>
