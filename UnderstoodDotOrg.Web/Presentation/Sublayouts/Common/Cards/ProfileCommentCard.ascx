<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileCommentCard.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards.ProfileCommentCard" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ConnectButton.ascx" TagPrefix="uc1" TagName="ConnectButton" %>

<div class="contributer-image">
    <asp:Image ID="imgAvatar" runat="server" />

</div>
<asp:HyperLink ID="hypName" runat="server" CssClass="name"></asp:HyperLink>
<p class="location">
    <asp:Literal ID="litLocation" runat="server" />
</p>
<uc1:ConnectButton runat="server" ID="btnConnect" />
<div class="member-card-specialties rs_preserve parents-member-cards">
    <asp:Repeater ID="rptChildCard" OnItemDataBound="rptChildCard_ItemDataBound" ClientIDMode="Static" runat="server">
        <HeaderTemplate>
            <ul>
                <%--replace with dictionary--%>
                <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.GradeLevelLabel %></span>
        </HeaderTemplate>
        <ItemTemplate>
            <li class=''>
                <%--<a href='REPLACE'>4th</a><!-- BEGIN PARTIAL: community/child_info_card -->--%>
                <asp:HyperLink runat="server" ID="hypChildGrade"></asp:HyperLink>

                <div class="card-child-info popover rs_skip">
                    <div class="popover-content">
                        <span class="caret"></span>
                        <h3><%--Grade 4, Boy--%>
                            <asp:Literal runat="server" ID="litGrade"></asp:Literal>,&nbsp;<asp:Literal runat="server" ID="litGender"></asp:Literal>
                        </h3>
                        <!-- BEGIN PARTIAL: community/carousel_arrows -->
                        <div class="arrows child-info-next-prev-menu arrows-gray">
                            <div class="rsArrow rsArrowLeft">
                                <button class="rsArrowIcn"></button>
                            </div>
                            <div class="rsArrow rsArrowRight">
                                <button class="rsArrowIcn"></button>
                            </div>
                        </div>
                        <!-- end .arrows -->
                        <!-- END PARTIAL: community/carousel_arrows -->
                        <ul>
                            <asp:Repeater ID="rptChildIssues" runat="server" OnItemDataBound="rptChildIssues_ItemDataBound">
                                <ItemTemplate>
                                    <li>
                                        <asp:Literal runat="server" ID="litChildIssue"></asp:Literal>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <%--<li>Dolores Omnis</li>
                            <li>Veniam Alias</li>
                            <li>Et Corporis</li>
                            <li>Adipisci Corrupti</li>--%>
                        </ul>
                        <div class="card-buttons">
                            <%--<button class="button gray">View Profile</button>--%>
                            <asp:Hyperlink ID="hypViewProfile" runat="server" CssClass="button gray" ></asp:Hyperlink>
                            <%--<button class="button blue">See Activity</button>--%>
                            <asp:Hyperlink ID="hypSeeActivity" runat="server" CssClass="button blue" ></asp:Hyperlink>
                        </div>
                    </div>
                </div>
                <%--<!-- END PARTIAL: community/child_info_card -->--%>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            <li class="specialty specialty-final">
                <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.AdditionalInformationLabel %></span>
                <span tabindex='0' data-tabbable='true'>&nbsp;</span>
            </li>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

</div>
