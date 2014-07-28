<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MostActiveGroups.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.Most_Active_Groups" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/GroupJoinButton.ascx" TagPrefix="uc1" TagName="GroupJoinButton" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>



        <div class="community-groups">
            <div class="row">
                <div class="col col-24 community-groups-wrapper">
                    <h2 class="rs_read_this">
                        <asp:Literal ID="litMostActiveGroupsLabel" runat="server" /></h2>
                    <div class="carousel-arrow-wrapper">
                        <!-- BEGIN PARTIAL: community/carousel_arrows -->
                        <div class="arrows groups next-prev-menu arrows-gray">

                            <asp:HyperLink ID="hrefAllGroups" CssClass="view-all" runat="server">

                                <asp:Literal ID="litSeeAllGroups" runat="server" />

                            </asp:HyperLink>

                            <div class="rsArrow rsArrowLeft">
                                <button class="rsArrowIcn"></button>
                            </div>
                            <div class="rsArrow rsArrowRight">
                                <button class="rsArrowIcn"></button>
                            </div>
                        </div>
                        <!-- end .arrows -->
                        <!-- END PARTIAL: community/carousel_arrows -->
                    </div>
                    <div class="row group-cards">
                        <!-- BEGIN PARTIAL: community/group_card -->


                        <asp:Repeater ID="rptAllGroups" runat="server">
                            <ItemTemplate>
                                <div class="col col-12 group-card rs_read_this">
                                    <div class="group-card-image">
                                        <asp:HyperLink ID="hrefImageLink" runat="server">
                                            <asp:Image ImageUrl="http://placehold.it/150x85" ID="imgGroup" runat="server" />
                                        </asp:HyperLink>

                                    </div>
                                    <!-- end .group-card-image -->
                                    <div class="group-card-info group  col col-16">
                                        <asp:HyperLink CssClass="group-card-name" ID="hrefTitleLink" runat="server"><%# Eval("Title")%></asp:HyperLink>

                                        <br />
                                        <span class="group-card-members">
                                            <asp:Literal ID="litMembers" runat="server" />
                                        </span>
                                        <br />
                                        <span class="group-card-posts">
                                            <asp:Literal ID="litDiscussions" runat="server" />
                                        </span>
                                        <br />
                                        <div class="card-buttons">
                                            <uc1:GroupJoinButton runat="server" Class="button rs_skip" ID="btnJoin" />
                                            <asp:LinkButton CssClass="link-remove-fade" CommandName="RemoveGroup" ID="btnSkip" OnCommand="btnSkip_Command" CommandArgument='<%# Eval("GroupID") %>' CausesValidation="false" runat="server">
                                                <asp:Literal ID="litSkipThis" runat="server" />
                                            </asp:LinkButton>
                                            <%--<button runat="server" id="btnSkip"  class="action-skip-this rs_skip">
                                </button>--%>
                                        </div>
                                        <!-- end .card-buttons -->
                                    </div>
                                    <!-- end .group-card-info -->
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <!-- end .group-cards -->
                </div>
                <!-- end .col.col-24.container -->
            </div>
            <!-- end .row -->
        </div>
        <!-- end .community-groups -->
    </ContentTemplate>
</asp:UpdatePanel>
