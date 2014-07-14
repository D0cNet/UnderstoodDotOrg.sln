<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_Profile.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.My_Profile" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container my-account-subheader">
    <div class="row">
        <!-- subheader -->
        <div class="col col-23">
            <!-- BEGIN PARTIAL: my-profile-subheader -->
            <header class="subheader">
                <div class="row">
                    <div class="col col-22 offset-1 group">
                        <%--<h2>My Profile</h2>--%>
                        <h2>
                            <sc:text field="Page Title" runat="server" />
                        </h2>
                    </div>
                </div>
            </header>
            <!-- END PARTIAL: my-profile-subheader -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container my-profile">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: my-profile-content -->
            <!-- Begin About Me -->
            <div class="profile-wrap">
                <div class="profile-section">
                    <div class="row profile-row">
                        <div class="col col-4">
                            <h2>
                                <asp:Literal ID="ltlAboutMeLabel" runat="server"></asp:Literal></h2>
                            <asp:HyperLink ID="hypEditCommunityAboutMe" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.EditFragment %></asp:HyperLink>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <h3>
                                        <asp:Literal ID="ltlMyRoleLabel" runat="server"></asp:Literal></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span class="cnt">
                                        <asp:Literal ID="uxRole" runat="server"></asp:Literal></span>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <h3>
                                        <asp:Literal ID="ltlMyJourneyLabel" runat="server"></asp:Literal></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span class="cnt">
                                        <asp:Literal ID="uxJourney" runat="server"></asp:Literal></span>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <h3>
                                        <asp:Literal ID="ltlMyInterestsLabel" runat="server"></asp:Literal></h3>
                                </div>
                                <div class="col col-18 profile-detail-information cnt">
                                    <!-- end MyInterests ul -->
                                    <asp:ListView ID="uxInterestList" runat="server" ItemType="UnderstoodDotOrg.Domain.Membership.Interest">
                                        <LayoutTemplate>
                                            <ul>
                                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                            </ul>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <li>
                                                <%# Eval("Value") %>
                                            </li>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                            </div>
                            <!-- .row -->
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->
                </div>
                <!-- profile-section -->
                <!-- End About Me -->

                <div class="profile-section children-section">
                    <div class="row profile-row">
                        <div class="col col-4 section-label">
                            <h2>
                                <asp:Literal ID="ltlMyChildrenLabel" runat="server"></asp:Literal></h2>
                            <%--<a href="REPLACE">Add a Third Child</a>--%>
                            <asp:HyperLink ID="uxAddChild" runat="server" CssClass="addChildButton"></asp:HyperLink>
                        </div>
                        <div class="col col-20 profile-details">
                            <asp:ListView runat="server" ID="uxChildList" ItemType="UnderstoodDotOrg.Domain.Membership.Child" OnItemDataBound="uxChildList_ItemDataBound">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col col-5 offset-1 clearfix">
                                            <h3><%# Eval("Nickname") %></h3>
                                            <a href="<%# getChildEditLink(Container) %>" class="child-edit"><%= UnderstoodDotOrg.Common.DictionaryConstants.EditFragment %></a>
                                        </div>
                                        <div class="col col-18 profile-detail-information">
                                            <div class="children-heading">
                                                <asp:Literal ID="uxGrade" runat="server"></asp:Literal>,&nbsp;
                                                <asp:Literal runat="server" ID="uxGender"></asp:Literal>,&nbsp;
                                                <asp:Literal runat="server" ID="uxEvaluationStatus"></asp:Literal>&#58;
                                            </div>
                                            <asp:ListView runat="server" ID="uxChildIssueList" ItemType="UnderstoodDotOrg.Domain.Membership.Issue">
                                                <LayoutTemplate>
                                                    <ul>
                                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                                    </ul>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <li class="children-list"><%# Eval("Value") %></li>
                                                </ItemTemplate>
                                            </asp:ListView>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->
                    <div class="profile-notice inline">
                        <p>
                            <asp:Literal ID="ltlNicknameReminderText" runat="server"></asp:Literal></p>
                    </div>
                </div>
                <!-- profile-section -->
                <!-- End My Children -->

                <div class="profile-section community-section">
                    <div class="row profile-row">
                        <div class="col col-4">
                            <h2>
                                <asp:Literal ID="ltlCommunityLabel" runat="server"></asp:Literal></h2>
                            <asp:HyperLink ID="hypEditCommunity" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.EditFragment %></asp:HyperLink>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <h3>
                                        <asp:Literal ID="ltlMyScreenNameLabel" runat="server"></asp:Literal></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span>
                                        <asp:Literal ID="uxScreenname" runat="server"></asp:Literal></span>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <h3>
                                        <asp:Literal ID="ltlMyConnectionsLabel" runat="server"></asp:Literal></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <%--<span>I'm open to receiving &quot;connect&quot; requests from other parents</span>--%>
                                    <span>
                                        <asp:Literal ID="uxPrivacyLevel" runat="server"></asp:Literal></span>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <h3>
                                        <asp:Literal ID="ltlMyLocationLabel" runat="server"></asp:Literal></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span class="cnt">
                                        <asp:Literal ID="uxZipcode" runat="server"></asp:Literal></span>
                                </div>
                            </div>
                            <!-- .row -->
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->
                    <div class="row profile-notice inline">
                        <p>
                            <asp:Literal ID="ltlZipcodeReminderText" runat="server"></asp:Literal></p>
                    </div>
                </div>
                <!-- profile-section -->
                <!-- End Community -->

                <div class="profile-section privacy-section">
                    <div class="row profile-row">
                        <div class="col col-4">
                            <h2>
                                <asp:Literal ID="ltlPrivacyLabel" runat="server"></asp:Literal></h2>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <asp:PlaceHolder runat="server" ID="uxPublicView">
                                    <div class="col col-5 offset-1">
                                        <h3>
                                            <asp:Literal ID="ltlMyPublicViewLabel" runat="server"></asp:Literal></h3>
                                    </div>
                                    <div class="col col-18 profile-detail-information">
                                        <ul>
                                            <li>
                                                <asp:HyperLink ID="hypViewAsVisitors" runat="server"><sc:FieldRenderer ID="frVisitors" FieldName="Visitors Text" runat="server"/> <i class="icon-arrow-right-blue"></i></asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypViewAsMembers" runat="server"><sc:FieldRenderer ID="frMembers" FieldName="Members Text" runat="server"/> <i class="icon-arrow-right-blue"></i></asp:HyperLink></li>
                                            <li>
                                                <asp:HyperLink ID="hypViewAsFriends" runat="server"><sc:FieldRenderer ID="frFriends" FieldName="Friends Text" runat="server"/> <i class="icon-arrow-right-blue"></i></asp:HyperLink></li>
                                        </ul>
                                    </div>
                                </asp:PlaceHolder>
                                <asp:Panel runat="server" ID="uxNoProfile" Visible="false">
                                    <p class="empty">
                                        <sc:FieldRenderer ID="frNoProfileText" runat="server" FieldName="No Profile Text" />
                                        <asp:HyperLink CssClass="comment-link" ID="hypCompleteYourProfile" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.ClickHereFragment %></asp:HyperLink>
                                    </p>
                                </asp:Panel>
                            </div>
                            <!-- .row -->
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->
                </div>
                <!-- profile-section -->
                <!-- End Privacy -->

                <div class="profile-section">
                    <div class="row profile-row">
                        <div class="col col-4">
                            <h2>
                                <asp:Literal ID="ltlEmailAndPasswordLabel" runat="server"></asp:Literal></h2>
                            <a href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.EditFragment %></a>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <h3>
                                        <asp:Literal ID="ltlEmailLabel" runat="server"></asp:Literal></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <%--<span>sonya.mik@email.com</span>--%>
                                    <span>
                                        <asp:Literal ID="uxEmailAddress" runat="server"></asp:Literal></span>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <h3>
                                        <asp:Literal ID="ltlPasswordLabel" runat="server"></asp:Literal></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span class="password">
                                        <asp:Literal runat="server" ID="uxPassword"></asp:Literal></span>
                                </div>
                            </div>
                            <!-- .row -->
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->
                </div>
                <!-- profile-section -->
                <!-- End Email and Password -->

                <div class="profile-section contact-section">
                    <div class="row profile-row">
                        <div class="col col-4">
                            <h2>
                                <asp:Literal ID="ltlContactLabel" runat="server"></asp:Literal></h2>
                            <a href="#" class="btnEdit"><%= UnderstoodDotOrg.Common.DictionaryConstants.EditFragment %></a>
                            <a href="#" class="btnCancel"><%= UnderstoodDotOrg.Common.DictionaryConstants.CancelFragment %></a>
                            <asp:LinkButton ID="lbSave_PhoneNumber" CssClass="lbSave" Text="<%# UnderstoodDotOrg.Common.DictionaryConstants.SaveButtonText %>" OnClick="lbSave_PhoneNumber_Click" runat="server"></asp:LinkButton>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <h3>
                                        <asp:Literal ID="ltlMobilePhoneLabel" runat="server"></asp:Literal></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span class="cnt">
                                        <asp:Literal runat="server" ID="uxPhoneNumber"></asp:Literal></span>
                                    <span class="form-field">
                                        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox></span>
                                </div>
                            </div>
                            <!-- .row -->
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->
                    <div class="row profile-notice">
                        <p>
                            <asp:Literal ID="ltlContactReminderText" runat="server"></asp:Literal></p>
                    </div>
                </div>
                <!-- profile-section -->
                <!-- End Contact -->
            </div>
            <!-- .profile-wrap -->
            <!-- END PARTIAL: my-profile-content -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<asp:Literal ID="ltlJS" runat="server"></asp:Literal>