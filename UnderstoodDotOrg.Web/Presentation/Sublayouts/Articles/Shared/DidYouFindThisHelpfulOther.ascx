<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DidYouFindThisHelpfulOther.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.DidYouFindThisHelpfulOther" %>

<div class="find-this-helpful content">

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
    <div class="clearfix"></div>

</div>