<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyComments.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent.MyCommentsTest" %>
<!-- BEGIN PARTIAL: account-landing-mycomments -->
<%--<div class="landing-mycomments landing-modules">
  <header class="clearfix">
    <h3>My Comments<span class="landing-module-count"></span></h3>
  </header>
    <asp:ListView runat="server" ID="topComments" OnItemDataBound="topComments_ItemDataBound">
        <EmptyDataTemplate>
            <p>
                <asp:Label id="litEmpty" Text="You have not made any comments on our site."  runat="server" /></p>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <ul runat="server">
                <li runat="server" id="itemPlaceHolder"></li>
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <span class="comment-wrap">
                    <asp:HyperLink NavigateUrl="#" CssClass="comment-link" ID="cLink" runat="server" />
                    <p class="comment-description">
                        <asp:Literal ID="cDesc" runat="server"></asp:Literal></p>
                </span>
            </li>
        </ItemTemplate>
    </asp:ListView>
    <div class="bottom">
        <asp:HyperLink ID="hypCommentsTab" runat="server">See All Comments</asp:HyperLink>
    </div>
  
</div><!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-mycomments -->--%>
    

<div class="landing-mycomments landing-modules rs_read_this">
    <header class="clearfix">
        <h3>My Comments<span class="landing-module-count"><asp:Label ID="lblCount" runat="server"></asp:Label></span></h3>
    </header>

    <ul class="landing-module-items">
        <asp:Repeater ID="rptComments" runat="server" OnItemDataBound="rptComments_ItemDataBound">
            <ItemTemplate>
                <li>
                    <span>
                        <asp:HyperLink CssClass="comment-link" ID="hypCommentLink" runat="server" />
                        <p class="comment-description"><asp:Literal ID="litCommentBody" runat="server"></asp:Literal></p>
                    </span>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="bottom rs_skip">
        <asp:HyperLink ID="hypCommentsTab" runat="server">See All Comments</asp:HyperLink>
    </div>

</div>
<!-- /.landing-notifications /.landing-modules -->
