<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyComments.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent.MyCommentsTest" %>
<div class="landing-mycomments landing-modules rs_read_this">
    <header class="clearfix">
        <h3>My Comments<span class="landing-module-count"><asp:Label ID="lblCount" runat="server"></asp:Label></span></h3>
    </header>
    <asp:Panel runat="server" ID="pnlComments" Visible="false">
        <ul class="landing-module-items">
            <asp:Repeater ID="rptComments" runat="server" OnItemDataBound="rptComments_ItemDataBound">
                <ItemTemplate>
                    <li>
                        <span>
                            <asp:HyperLink CssClass="comment-link" ID="hypCommentLink" runat="server" />
                            <p class="comment-description">
                                <asp:Literal ID="litCommentBody" runat="server"></asp:Literal>
                            </p>
                        </span>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="bottom rs_skip">
            <asp:HyperLink ID="hypCommentsTab" runat="server">See All Comments</asp:HyperLink>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNoComments" Visible="false">
        <p class="empty">You have not made any comments</p>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNoProfile" Visible="false">
        <p class="empty">You don't have a community profile, to create one please <asp:HyperLink CssClass="comment-link" ID="hypCompleteYourProfile" runat="server">click here.</asp:HyperLink></p>
    </asp:Panel>
</div>
<!-- /.landing-notifications /.landing-modules -->
