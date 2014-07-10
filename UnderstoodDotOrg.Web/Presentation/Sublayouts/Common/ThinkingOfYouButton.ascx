<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThinkingOfYouButton.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ThinkingOfYouButton" %>
 
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="btnContainer">
<button runat="server" id="btnThinkingOfYou"  class="thinking-of-you">
        <i class="flower-icon"></i>
        <p>
            <asp:Literal id="litThinkingOfYou" runat="server" />  </p>
    </button>
                    </div>
    </ContentTemplate>
</asp:UpdatePanel> 
