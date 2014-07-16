<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberProfileCard.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards.MemberProfileCard" %>

<div class="member-card-container">
    <div class="rs_read_this col member-card <%= ColumnCss %>">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="<%= ProfileUrl %>">
                    <asp:Image ID="imgAvatar" runat="server" />
                </a>
            </div>
            <!-- end .member-card-image -->
            <div class="member-card-name hyphenate member">

                <a href="<%= ProfileUrl %>" class="name-member"><asp:Literal ID="litScreenName" runat="server" /></a>
                <p class="location"><asp:Literal ID="litLocation" runat="server" /></p>

            </div>
            <!-- end .member-card-name -->

            <div class="card-buttons member">

                <button type="button" class="button blue rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeActivityLabel %></button>

            </div>
            <!-- end .member.card-buttons -->

        </div>
        <!-- end .member-card-info -->
        <asp:Repeater ID="rptChildren" runat="server">
            <HeaderTemplate>
                <div class="member-card-specialties">
                    <ul>
                        <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.GradeLevelLabel %></span>
            </HeaderTemplate>
            <ItemTemplate>
                <li class=''><a href="#"><asp:Literal ID="litGrade" runat="server" /></a><!-- BEGIN PARTIAL: community/child_info_card -->
                    <div class="card-child-info popover rs_skip">
                        <div class="popover-content">
                            <span class="caret"></span>
                            <h3><asp:Literal ID="litChildInfo" runat="server" /></h3>
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
                            <asp:Repeater ID="rptIssues" 
                                ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child.ChildIssueItem"
                                runat="server">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li><%# Item.IssueName.Raw %></li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div class="card-buttons">
                                <a href="<%= ProfileUrl %>" class="button gray"><%= UnderstoodDotOrg.Common.DictionaryConstants.ViewProfileLabel %></a>
                                <a href="<%= ProfileActivityUrl %>" class="button blue"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeActivityLabel %></a>
                            </div>
                        </div>
                    </div>
                    <!-- END PARTIAL: community/child_info_card -->
                </li>
            </ItemTemplate>
            <FooterTemplate>
                        <li class="specialty specialty-final">
                            <span class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.AdditionalInformationLabel %></span>
                            <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                        </li>
                    </ul>
                </div>
            </FooterTemplate>
        </asp:Repeater>
                
    </div>
    <!-- end .member-card -->
</div>
<!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
