<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DidYouFindThisHelpfulSideBar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.DidYouFindThisHelpfulSideBar" %>

<div class="find-this-helpful-large">
    <!-- Module within only appears in over 650px window width-->
    <!-- BEGIN PARTIAL: find-helpful -->
    <div class="find-this-helpful sidebar">
        <h4><asp:Literal ID="ltlDidYouFindThisHelpful" runat="server"></asp:Literal></h4>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" class="update-panel">
                <ContentTemplate>
                    <ul>
                        <li>
                            <button id="btnYes" runat="server" class="helpful-yes" onserverclick="btnYes_ServerClick"></button>
                        </li>
                        <li>
                            <button id="btnNo" runat="server" class="helpful-no" onserverclick="btnNo_ServerClick"></button>
                        </li>
                    </ul>
                </ContentTemplate>
            </asp:UpdatePanel>
        <div class="clearfix">
        </div>
    </div>
    <!-- END PARTIAL: find-helpful -->
</div>
