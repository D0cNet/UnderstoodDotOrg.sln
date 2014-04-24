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
                        <h2><sc:Text Field="Page Title" runat="server" /></h2>
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
                            <%--<h2>About Me</h2>--%>
                            <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.AboutMeLabel %></h2>
                            <a href="REPLACE">Edit</a>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <%--<h3>My Role</h3>--%>
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.MyRoleLabel %></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span>Mother</span>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <%--<h3>My Journey</h3>--%>
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.MyJourneyLabel %></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span>I'm just starting to work on my child's issues</span>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <%--<h3>My Interests</h3>--%>
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.MyInterestsLabel %></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <ul>
                                        <!-- begin MyInterests ul -->
                                        <li>School services (IEPs/504) Plans</li>
                                        <li>Homeschooling</li>
                                        <li>Bullying</li>
                                        <li>Evaluations</li>
                                        <li>Tutors</li>
                                        <li>Technologies/apps</li>
                                        <li>Advocating for your child's rights</li>
                                    </ul>
                                    <!-- end MyInterests ul -->
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
                            <%--<h2>My Children</h2>--%>
                            <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.MyChildrenLabel %></h2>
                            <a href="REPLACE">Add a Third Child</a>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <div class="col col-5 offset-1 clearfix">
                                    <h3>Michael</h3>
                                    <a href="REPLACE" class="child-edit">Edit</a>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <div class="children-heading">Grade 3, boy, evaluated&#58;</div>
                                    <ul>
                                        <li class="children-list">Spoken Language</li>
                                        <li class="children-list">Listening comprehension</li>
                                        <li class="children-list">Social skills, including conversation</li>
                                        <li class="children-list">Motor skills</li>
                                    </ul>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1 clearfix">
                                    <h3>Sally</h3>
                                    <a href="REPLACE" class="child-edit">Edit</a>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <div class="children-heading">Grade 5, girl, evaluated&#58;</div>
                                    <ul>
                                        <li class="children-list">Reading</li>
                                        <li class="children-list">Math</li>
                                        <li class="children-list">Writing</li>
                                        <li class="children-list">Attention/hyperactive</li>
                                        <li class="children-list">Organization, planning, time management</li>
                                    </ul>
                                </div>
                            </div>
                            <!-- .row -->
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->
                    <div class="profile-notice inline">
                        <%--<p>Child nicknames are private and only viewable by you.</p>--%>
                        <p><%= UnderstoodDotOrg.Common.DictionaryConstants.NicknameReminderText %></p>
                    </div>
                </div>
                <!-- profile-section -->
                <!-- End My Children -->

                <div class="profile-section community-section">
                    <div class="row profile-row">
                        <div class="col col-4">
                            <%--<h2>Community</h2>--%>
                            <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.CommunityLabel %></h2>
                            <a href="REPLACE">Edit</a>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <%--<h3>My Screen Name</h3>--%>
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.MyScreenNameLabel %></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span>SonyasMom65</span>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <%--<h3>My Connections</h3>--%>
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.MyConnectionsLabel %></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span>I'm open to receiving &quot;connect&quot; requests from other parents</span>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <%--<h3>My Location</h3>--%>
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.MyLocationLabel %></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span>07040</span>
                                </div>
                            </div>
                            <!-- .row -->
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->
                    <div class="row profile-notice inline">
                        <%--<p>Zip code is private. Your community profile shows your state.</p>--%>
                        <p><%= UnderstoodDotOrg.Common.DictionaryConstants.ZipcodeReminderText %></p>
                    </div>
                </div>
                <!-- profile-section -->
                <!-- End Community -->

                <div class="profile-section privacy-section">
                    <div class="row profile-row">
                        <div class="col col-4">
                            <%--<h2>Privacy</h2>--%>
                            <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.PrivacyLabel %></h2>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <%--<h3>What does my profile look like to others?</h3>--%>
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.MyPublicViewLabel %></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <ul>
                                        <li><a href="REPLACE">Visitors &gt;</a></li>
                                        <li><a href="REPLACE">Members &gt;</a></li>
                                        <li><a href="REPLACE">Friends &gt;</a></li>
                                    </ul>
                                </div>
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
                            <%--<h2>Email &amp; Password</h2>--%>
                            <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.EmailAndPasswordLabel %></h3>
                            <a href="REPLACE">Edit</a>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <%--<h3>Email</h3>--%>
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.EmailLabel %></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span>sonya.mik@email.com</span>
                                </div>
                            </div>
                            <!-- .row -->
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <%--<h3>Password</h3>--%>
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.PasswordLabel %></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span class="password">&middot;&middot;&middot;&middot;&middot;&middot;&middot;&middot;&middot;&middot;&middot;&middot;</span>
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
                            <%--<h2>Contact</h2>--%>
                            <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.ContactLabel %></h2>
                            <a href="REPLACE">Edit</a>
                        </div>
                        <div class="col col-20 profile-details">
                            <div class="row">
                                <div class="col col-5 offset-1">
                                    <%--<h3>Mobile Phone&nbsp;#</h3>--%>
                                    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.MobilePhoneLabel %></h3>
                                </div>
                                <div class="col col-18 profile-detail-information">
                                    <span>555-555-5555</span>
                                </div>
                            </div>
                            <!-- .row -->
                        </div>
                        <!-- .col -->
                    </div>
                    <!-- .row -->
                    <div class="row profile-notice">
                        <%--<p>Mobile phone number is private and viewable only by you.</p>--%>
                        <p><%= UnderstoodDotOrg.Common.DictionaryConstants.ContactReminderText %></p>
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
