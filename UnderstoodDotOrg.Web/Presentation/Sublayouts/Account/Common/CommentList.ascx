<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentList.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Common.CommentList" %>

<asp:Repeater ID="rptComments" runat="server" OnItemDataBound="rptComments_ItemDataBound">
    <ItemTemplate>
        <div class="row">
            <asp:Panel ID="pnlAuthor" runat="server" Visible="false" CssClass="col col-6 comments-col-left">
                <h3><asp:Literal ID="litScreenName" runat="server" /></h3>
                <p><%= UnderstoodDotOrg.Common.DictionaryConstants.LastUpdatedLabel %></p>
                <p><asp:Literal ID="litLastUpdated" runat="server" /></p>
            </asp:Panel>
            <asp:Panel ID="pnlComment" runat="server" CssClass="col col-18 comments-col-right">
                <div class="rs_read_this friends-view-three-rs-wrapper">
                    <h5><asp:HyperLink runat="server" ID="hlTitle" /></h5>
                    <p><asp:Literal ID="litComment" runat="server" /></p>
                    <footer><asp:Literal ID="litDate" runat="server" />
                        <button><asp:Literal ID="litLikeCount" runat="server" /><span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.LikesLabel %></span></button></footer>
                </div>
            </asp:Panel>
        </div>
    </ItemTemplate>
</asp:Repeater>