<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Favorites.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs.Favorites" %>
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
                                            <div class="buttons-container clearfix">

                                                <button class="icon icon-plus rs_preserve">save this</button>
                                                <button class="icon icon-print">print</button>
                                                <button class="icon icon-bell rs_preserve">remind me</button>
                                            </div>
                                            <div class="share-dropdown-menu-wrap">
                                                <!-- BEGIN PARTIAL: share-content-dropdown -->
                                                <!-- This file shared on multiple pages -->

                                                <div class="share-dropdown-menu rs_skip">
                                                    <button class="social-share-button rs_preserve">Share <i class="icon-arrow"></i></button>
                                                    <div class="share-menu">
                                                        <span class="social-share">Share <i class="icon-arrow"></i></span>
                                                        <ul>
                                                            <li class="clearfix">
                                                                <a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a>
                                                            </li>
                                                            <li class="clearfix">
                                                                <a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a>
                                                            </li>
                                                            <li class="clearfix">
                                                                <a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a>
                                                            </li>
                                                            <li class="clearfix">
                                                                <a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                <!-- END PARTIAL: share-content-dropdown -->
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
            <asp:Panel runat="server" ID="pnlNoProfile" Visible="false">
                <p class="empty">
                    You don't have a community profile, to create one please 
                        <asp:HyperLink CssClass="comment-link" ID="hypCompleteYourProfile" runat="server">click here.</asp:HyperLink>
                </p>
            </asp:Panel>
            <!-- END PARTIAL: account-myfavorites -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
