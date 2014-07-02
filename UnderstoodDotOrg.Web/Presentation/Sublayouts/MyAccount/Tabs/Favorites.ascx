<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Favorites.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs.Favorites" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container my-account-subheader saved-subheader">
    <div class="row">
        <!-- subheader -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: my-saved-subheader -->
            <h2 class="rs_read_this">My Saved</h2>
            <fieldset>
                <span class="select-container filter">
                    <label for="my-comments-filter" class="visuallyhidden">Filter Comments</label>
                    <select name="filter" id="filter" class="my-account-dropdown">
                        <option value="">All</option>
                    </select>
                </span>
                <span class="select-container sort">
                    <select name="sort" id="sort" class="my-account-dropdown">
                        <option value="">Most Recent</option>
                        <option value="">Oldest To Newest</option>
                        <option value="">Number Of Comments</option>
                        <option value="">Recent Comments</option>
                    </select>
                </span>
            </fieldset>

            <!-- END PARTIAL: my-saved-subheader -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container">
    <div class="row">
        <div class="col col-23 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: account-myfavorites -->
            <asp:Panel runat="server" ID="pnlFavorites" Visible="false">
                <section class="account-myfavorites">
                    <asp:Repeater ID="rptFavorites" runat="server" OnItemDataBound="rptFavorites_ItemDataBound">
                        <ItemTemplate>
                            <div class="row myfavorites-list rs_read_this repeater-item">
                                <div class="myfavorites-item clearfix">
                                    <div class="col col-3">
                                        <h3 class="favorite-type">
                                            <asp:Literal ID="litType" runat="server"></asp:Literal>
                                        </h3>
                                    </div>
                                    <div class="col col-12 offset1 favorite-title-wrap">
                                        <asp:HyperLink ID="hypFavoriteTitle" CssClass="favorite-title" runat="server"></asp:HyperLink>
                                    </div>
                                    <!-- /.col -->
                                    <div class="col col-9 offset1 favorite-toolbar">
                                        <div class="favorite-comment-count">
                                            <asp:HyperLink ID="hypReplyCount" runat="server"></asp:HyperLink>
                                            <span class="visuallyhidden">comments</span>
                                        </div>
                                        <div class="tools">
                                            <div class="top">
                                                <!-- BEGIN PARTIAL: share-content-dropdown -->
                                                <div class="share-dropdown-menu rs_skip">
                                                    <button class="social-share-button">Share <i class="icon-arrow"></i></button>
                                                    <div class="share-menu">
                                                        <span class="social-share">Share <i class="icon-arrow"></i></span>
                                                        <ul>
                                                            <li class="clearfix">
                                                                <asp:HyperLink ID="hlFacebook" CssClass="icon-facebook share-icon" runat="server">
                                                                    <i class="icon-facebook"></i>
                                                                    <asp:Literal ID="ltlFacebook" runat="server"></asp:Literal>
                                                                </asp:HyperLink>
                                                            </li>
                                                            <li class="clearfix">
                                                                <asp:HyperLink ID="hlTwitter" CssClass="icon-twitter share-icon" runat="server">
                                                                    <i class="icon-twitter"></i>
                                                                    <asp:Literal ID="ltlTwitter" runat="server"></asp:Literal>
                                                                </asp:HyperLink>
                                                            </li>
                                                            <li class="clearfix">
                                                                <asp:HyperLink ID="hlGooglePlus" CssClass="icon-google share-icon" runat="server">
                                                                    <i class="icon-google"></i>
                                                                    <asp:Literal ID="ltlGooglePlus" runat="server"></asp:Literal>
                                                                </asp:HyperLink>
                                                            </li>
                                                            <li class="clearfix">
                                                                <a href="//www.pinterest.com/pin/create/button/" data-pin-do="buttonPin">
                                                                    <img src="//assets.pinterest.com/images/pidgets/pinit_fg_en_round_red_16.png" /></a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                <!-- END PARTIAL: share-content-dropdown -->
                                                <!-- BEGIN PARTIAL: article-action-buttons -->
                                                <div class="article-actions buttons-container rs_skip clearfix">
                                                    <button class="icon-email">email</button>
                                                    <button id="lbUnSave" runat="server" class="icon icon-plus rs_preserve active" onserverclick="lbUnsave_Click"></button>
                                                    <button class="icon-print" onclick="window.print()">print</button>
                                                    <%--OOS for this release--%>
                                                    <%--<button class="icon-bell">remind me</button>--%>
                                                    <%--When You need it check MembershipManager.LogMemberActivity(x,y,z,q). Sample usage is in Sandbox.ascx.cs--%>
                                                </div>

                                                <!-- END PARTIAL: article-action-buttons -->
                                                <div class="clearfix"></div>
                                            </div>
                                            <!-- /.share-dropdown-menu-wrap-->
                                        </div>
                                        <!-- /.icon tools -->
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.myfavorites-item -->
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </section>
                <div class="showmore-footer">
                    <!-- Show More -->
                    <!-- BEGIN PARTIAL: community/show_more -->
                    <!--Show More-->
                    <div class="container show-more rs_skip">
                        <div class="row">
                            <div class="col col-24">
                                <a class="show-more-link show_more" href="#" data-path="my-account/my-saved" data-container="account-myfavorites" data-item="myfavorites-list" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
                            </div>
                        </div>
                    </div>
                    <!-- .show-more -->
                    <!-- END PARTIAL: community/show_more -->
                    <!-- .show-more -->
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlNoFavorites" Visible="false">
                <p class="empty">
                    You have not saved any
            <asp:HyperLink ID="hypArticles" runat="server">favorite articles</asp:HyperLink>,
            <asp:HyperLink ID="hypBehaviourTool" runat="server">behavior tips</asp:HyperLink>, or
            <asp:HyperLink ID="hypExpertsLive" runat="server">expert answers</asp:HyperLink>
                    yet. When you do, your favorites will appear here.
                </p>
            </asp:Panel>
            <!-- END PARTIAL: account-myfavorites -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
