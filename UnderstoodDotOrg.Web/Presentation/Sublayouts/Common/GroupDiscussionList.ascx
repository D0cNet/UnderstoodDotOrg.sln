<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupDiscussionList.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.GroupDiscussionList" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ConnectButton.ascx" TagPrefix="uc1" TagName="ConnectButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ThanksButton.ascx" TagPrefix="uc1" TagName="ThanksButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ThinkingOfYouButton.ascx" TagPrefix="uc1" TagName="ThinkingOfYouButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/LikeButton.ascx" TagPrefix="uc1" TagName="LikeButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/Cards/ProfileCommentCard.ascx" TagPrefix="uc1" TagName="ProfileCommentCard" %>

<asp:Repeater ID="rptDiscussionList" OnItemDataBound="rptDiscussionList_ItemDataBound" runat="server">
    <HeaderTemplate>
        <div class="discussion-post clearfix rs_read_this">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col col-4 discussion-contributer">
            <%--each poster in thread--%>
            <uc1:ProfileCommentCard runat="server" id="ProfileCommentCard" />
        </div>
        <div class="discussion-comment">
            <p><%# Eval("Body") %></p>
        </div>
        <footer class="discussion-footer rs_skip">
            <h4><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowYourSupportLabel %></h4>
            <ul class="support-menu">
                <li>
                    <uc1:ThanksButton runat="server" ID="btnThanks" />

                </li>
                <li>
                    <uc1:ThinkingOfYouButton runat="server" ID="btnThinkingOfYou" />
                </li>
                <li>
                    <uc1:LikeButton runat="server" ID="btnLike" />
                </li>
            </ul>
        </footer>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>




