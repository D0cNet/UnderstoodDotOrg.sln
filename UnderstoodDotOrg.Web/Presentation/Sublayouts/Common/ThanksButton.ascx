<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThanksButton.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ThanksButton" %>
     
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
         <button runat="server"  id="btnThanks"   class="thanks">
            <i class="smiley-icon"></i>
            <p>
                <asp:Literal ID="litThanksLabel" runat="server" /></p>
        </button>
        
    </ContentTemplate>
</asp:UpdatePanel> 
