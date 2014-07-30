<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DidYouFindThisHelpfulOther.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.DidYouFindThisHelpfulOther" %>

<div class="find-this-helpful content rs_read_this">

    <h4><asp:Literal ID="ltlDidYouFindThisHelpful" runat="server"></asp:Literal></h4>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" class="update-panel">
            <ContentTemplate>
                <ul>
                    <li>
                        <button id="btnYes" runat="server" class="button yes rs_skip rs_preserve" onserverclick="btnYes_ServerClick"></button>
                
                    </li>
                    <li class="gray">
                        <button id="btnNo" runat="server" class="button no rs_skip rs_preserve" onserverclick="btnNo_ServerClick"></button>
                    </li>
                </ul>
            </ContentTemplate>
        </asp:UpdatePanel>
    <div class="clearfix"></div>

</div>