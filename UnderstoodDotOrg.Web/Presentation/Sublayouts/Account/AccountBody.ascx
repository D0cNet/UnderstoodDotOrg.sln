<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountBody.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.AccountBody" %>

<!-- BEGIN PARTIAL: sign-in-prompt-links -->
<div class="sign-in-prompt-links" id="divNotSignedIn" runat="server" visible="false">
    <div class="rs_read_this row">
        <img alt=" " src="../images/icon.sign-in-prompt.lock.png" />
        <h3>This User&#39;s Profile is currently private</h3>
        <h5>Parent profiles are only visible to logged-in members</h5>
        <h4><a href="REPLACE">Sign in</a> or <a href="REPLACE">Sign up</a> to view more</h4>
    </div>
</div>
<!-- END PARTIAL: sign-in-prompt-links -->

<!-- BEGIN PARTIAL: sign-in-prompt -->
<div class="sign-in-prompt" id="divPrivateProfile" runat="server" visible="false">
    <img alt=" " src="../images/icon.sign-in-prompt.lock.png" />
    <h3>This User&#39;s Profile is currently private</h3>
</div>
<!-- END PARTIAL: sign-in-prompt -->

<div class="container" id="divNotConnected" runat="server" visible="false">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: member-view-content -->
            <div class="member-view-content">
                <div class="member-view-children">
                    <div class="row">
                        <div class="col col-6 section-label">
                            <h3>Children</h3>
                        </div>
                        <div class="col col-18">
                            <!-- START Template-->
                            <asp:Repeater ID="rptChildren" runat="server">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col col-12 rs_read_this">
                                            <h4>Grade 3, boy, evaluated:</h4>
                                            <ul>
                                                <li>Spoken Language</li>
                                                <li>Listening comprehension</li>
                                                <li>Social skills, including conversation</li>
                                                <li>Motor skills</li>
                                            </ul>
                                        </div>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                        <div class="col col-11 offset-1 rs_read_this">
                                            <h4>Grade 5, girl, evaluated:</h4>
                                            <ul>
                                                <li>Reading</li>
                                                <li>Math</li>
                                                <li>Writing</li>
                                                <li>Attebtuib.hyperac</li>
                                                <li>Organization, planning, time management</li>
                                            </ul>
                                        </div>
                                    </div>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                            <!-- /. row -->
                            <!-- END Template-->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.member-view-children -->
                <hr>
                <div class="row member-view-interests rs_read_this">
                    <div class="col col-6 section-label">
                        <h3>Interests</h3>
                    </div>
                    <div class="col col-18">
                        <ul>
                            <li>School services (IEPs/504 Plans)</li>
                            <li>Homeschooling</li>
                            <li>Bullying</li>
                            <li>Evaluations</li>
                            <li>Tutors</li>
                            <li>Technologies/apps</li>
                            <li>Advocating for your child’s rights</li>
                        </ul>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.member-view-interests-->
                <hr>
                <div class="row member-view-groups rs_read_this">
                    <div class="col col-6 section-label">
                        <h3>Groups</h3>
                    </div>
                    <div class="col col-18">
                        <ul>
                            <li><a href="REPLACE">Parents of kids with attention issues</a></li>
                            <li><a href="REPLACE">Parents of kids with ADD</a></li>
                            <li><a href="REPLACE">Parents of kids in NJ</a></li>
                            <li><a href="REPLACE">Parents of kids with ADD</a></li>
                            <li><a href="REPLACE">Parents of kids in NJ</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- /.member-view-groups-->
            <!-- END PARTIAL: member-view-content -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
