<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutUnderstood.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.AboutUnderstood" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container l-about-understood">
    <div class="row">
        <div class="col col-15 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: about-understood-video -->
            <div class="about-video-container">
                <p>
                    <%--Et fugit consequatur explicabo quasi autem corrupti consequatur ab deserunt minima ea quas eum. et saepe omnis et dolorem distinctio tempore excepturi numquam et ut consequatur aut. qui aut facere nisi ut voluptas eveniet voluptates ea omnis. eligendi itaque architecto eum ut qui culpa fuga ratione ut nihil quia et aut quae. debitis minus commodi sapiente sit blanditiis--%>
                    <sc:FieldRenderer ID="frSummary" runat="server" FieldName="Page Summary" />
                </p>
                <div class="about-video-frame">
                    <img alt="590x333 Placeholder" src="http://placehold.it/590x333" />
                    <sc:FieldRenderer ID="frVideo" runat="server" FieldName="Video to Show" />
                </div>
                <!-- end about-video-frame -->
            </div>
            <!-- end about-video-container -->
            <!-- END PARTIAL: about-understood-video -->
            <!-- BEGIN PARTIAL: transcript-control -->
            <div class="transcript-container Video">
                <%--<div class="read-more mobile-close">
                    <a href="REMOVE">Close Transcript<i class="icon-arrow-up-blue"></i></a>
                </div> --%>
                <div class="transcript-wrap">
                    <div>

                        <sc:FieldRenderer ID="FrVideoTranscript" runat="server" FieldName="Video Transcript" />
                        <%-- <h2>Video Transcript</h2>

                        <h3>Dr.Richard Nightengale:</h3>
                        <p>Fugit maxime quisquam cum velit beatae quis aut qui fugit voluptatem. omnis maxime blanditiis assumenda in quia ducimus. inventore omnis quibusdam praesentium ab unde. rerum ut cumque aut enim. adipisci blanditiis dolorum voluptatem ea</p>

                        <h3>Parent:</h3>
                        <p>Magni consequatur et tenetur est fugiat sint rerum cumque officiis cumque. nam vitae et inventore dolorem qui iure provident distinctio beatae dolore est. et est qui laudantium suscipit eum nam animi veritatis vitae porro</p>

                        <h3>Dr.Richard Nightengale:</h3>
                        <p>Accusamus et odio iure iste eum vitae sapiente ut ut autem. ut aspernatur nisi corporis facere nihil fugiat. atque aut quis suscipit tempore neque qui. architecto id at pariatur voluptatem labore molestias facilis accusantium voluptatem animi consectetur eius omnis. et ab quia sed saepe neque ipsum veritatis quas nesciunt nulla saepe totam</p>

                        <h3>Parent:</h3>
                        <p>Provident eveniet dolores fuga sit maiores qui excepturi mollitia vero. aperiam consequatur beatae eligendi et. non non repellendus doloribus iusto esse veniam est</p>

                        <h3>Dr.Richard Nightengale:</h3>
                        <p>Beatae ipsum accusantium vel nam consequatur voluptatem nihil ea. accusamus aut unde velit sint laboriosam dolores maxime esse aperiam sed iure illum qui dolorem. earum amet aspernatur quod aspernatur illum. neque molestiae harum sed et. quis et provident voluptates doloribus sint consequatur molestiae pariatur sint sapiente voluptate quae doloribus quis</p>

                        <h3>Parent:</h3>
                        <p>Laboriosam unde sunt quis veritatis temporibus quis. aut odio mollitia rerum nemo in et eos repudiandae doloribus. est aut et blanditiis esse sit suscipit id eveniet vel eveniet modi quaerat</p>--%>
                    </div>
                </div>
                <div class="read-more read-more-bottom"></div>
            </div>
            <!-- END PARTIAL: transcript-control -->
            <!-- BEGIN PARTIAL: about-understood-listing -->
            <div class="listing-container">
                <div class="listing-content">
                    <h2><%--Our Mission--%>
                        <sc:FieldRenderer ID="frMissionHeadline" runat="server" FieldName="Mission Headline" />
                    </h2>
                    <sc:FieldRenderer ID="frMissionImage" runat="server" FieldName="Mission Thumbnail" />
                    <%--<img alt="289x164 Placeholder" src="http://placehold.it/289x164" />--%>
                    <p>
                        <%--dolorum velit et libero illo asperiores ut rerum ad vel qui dignissimos asperiores qui dicta --%>
                        <sc:FieldRenderer ID="frMissionSummary" runat="server" FieldName="Mission Summary" />
                        <a href="REMOVE">Read&nbsp;More</a>
                    </p>
                </div>
                <div class="listing-content">
                    <h2><%--Our Story--%>
                        <sc:FieldRenderer ID="frStoryHeadline" runat="server" FieldName="Story Headline" />
                    </h2>
                    <sc:FieldRenderer ID="frStoryImage" runat="server" FieldName="Story Thumbnail" />
                    <%-- <img alt="289x164 Placeholder" src="http://placehold.it/289x164" />--%>
                    <p>
                        <%--sed molestiae modi reiciendis voluptas odit sed quia quia eum repellat deserunt aut dolorum omnis--%>
                        <sc:FieldRenderer ID="frStorySummary" runat="server" FieldName="Story Summary" />
                        <a href="REMOVE">Read&nbsp;More</a>
                    </p>
                </div>
                <div class="listing-content">
                    <h2><%--Our Team--%>
                        <sc:FieldRenderer ID="frTeamHeadline" runat="server" FieldName="Team Headline" />
                    </h2>
                    <%--<img alt="289x164 Placeholder" src="http://placehold.it/289x164" />--%>
                    <sc:FieldRenderer ID="frTeamImage" runat="server" FieldName="Team Thumbnail" />
                    <p>
                        <%--error aspernatur sapiente ab quis enim quos quam eos et ipsum quasi possimus aut aut--%>
                        <sc:FieldRenderer ID="frTeamSummary" runat="server" FieldName="Team Summary" />
                        <a href="REMOVE">Read&nbsp;More</a>
                    </p>
                </div>
                <div class="listing-content">
                    <h2><%--Experts &amp; Parents--%>
                        <sc:FieldRenderer ID="frExpertPartnerHeadline" runat="server" FieldName="Expert Partner Headline" />
                    </h2>
                    <%--<img alt="289x164 Placeholder" src="http://placehold.it/289x164" />--%>
                    <sc:FieldRenderer ID="frExpertpartnerImage" runat="server" FieldName="Expert Partner Thumbnail" />
                    <p>
                        <%--totam consequatur doloremque excepturi optio ut quaerat eos quo vel qui quia dolor dolore dolorem --%>
                        <sc:FieldRenderer ID="frExpertpartnerSummary" runat="server" FieldName="Expert Partner Summary" />
                        <a href="REMOVE">Read&nbsp;More</a>
                    </p>
                </div>
            </div>
            <!-- end listing-container -->
            <!-- END PARTIAL: about-understood-listing -->
        </div>
        <div class="about-large-block">
            <div class="col col-7 offset-1 donate-advice-sidebar skiplink-sidebar">
                <!-- BEGIN PARTIAL: donate -->
                <div class="donate rs_read_this">
                    <h4>Please Donate</h4>
                    <p>Vivamus feugiat congue augue, sit amet congue nisl mattis?</p>
                    <ul class="donation-amounts group">
                        <li><a href="REPLACE" class="button">$25</a></li>
                        <li><a href="REPLACE" class="button">$50</a></li>
                        <li><a href="REPLACE" class="button">$100</a></li>
                        <li><a href="REPLACE" class="button">Other</a></li>
                    </ul>
                </div>
                <!-- .donate -->
                <!-- END PARTIAL: donate -->
                <!-- BEGIN PARTIAL: get-advice -->
                <div class="get-advice">
                    <h4>Get Advice
                        <br>
                        Just For You</h4>
                    <p>Has your child had a formal evaluation for learning &amp; attention issues?</p>
                    <ul>
                        <li><a href="REPLACE" class="button">Yes</a></li>
                        <li><a href="REPLACE" class="button">No</a></li>
                        <li class="in-progress"><a href="REPLACE" class="button">In Progress</a></li>
                        <li class="complete-profile"><a href="REPLACE">Complete My Profile</a></li>
                    </ul>
                </div>
                <!-- .get-advice -->
                <!-- END PARTIAL: get-advice -->
                <!-- BEGIN PARTIAL: about-contact-us -->
                <div class="about-contact-block">
                    <h2>Contact Us</h2>
                    <h3>For general support</h3>
                    <a href="REPLACE">info@Understood.org</a>
                    <h3>Questions for experts</h3>
                    <a href="REPLACE">experts@Understood.org</a>
                    <h3>Media inquiries</h3>
                    <a href="REPLACE">jsmith@Understood.org</a>
                </div>
                <!-- .about-contact-block -->
                <!-- END PARTIAL: about-contact-us -->
            </div>
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container -->
<div class="container flush l-founding-partners-carousel">
    <div class="row">
        <div class="col col-24 about-small-block-after skiplink-feature">
            <!-- BEGIN PARTIAL: founding-carousel -->
            <div class="founding-container">
                <header>
                    <h2><%--Our Coalition of Founding Partners--%>
                        <sc:FieldRenderer ID="frPartnersListHeadline" runat="server" FieldName="Partner List Headline" />
                    </h2>
                    <p>
                        <%--inventore rem nisi qui sit rerum minima culpa quia ratione vel facilis quis qui quisquam.--%>
                        <sc:FieldRenderer ID="frPartnerListSummary" runat="server" FieldName="Partner List Summary" />
                        <%--<a href="REPLACE">Read&nbsp;more</a> --%>
                        <asp:HyperLink ID="hlPartnersListPage" runat="server" Text="Read more"></asp:HyperLink>

                    </p>
                </header>
                <div class="founding-carousel-outer">
                    <div class="founding-slides-wrapper arrows-gray">
                        <div class="row">
                            <asp:Repeater ID="rptPartnerList" runat="server" OnItemDataBound="rptPartnerList_ItemDataBound">
                                <ItemTemplate>
                                    <div class="col col-4">
                                        <ul>
                                            <li>
                                                <asp:HyperLink ID="hlPartnerLogo" runat="server">
                                                    <sc:FieldRenderer ID="frPartnerLogo" runat="server" FieldName="Logo" />
                                                </asp:HyperLink>
                                                <%-- <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a> --%>
                                            </li>
                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                            <%-- <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>
                            <div class="col col-4">
                                <li>
                                    <a href="REPLACE">
                                        <img alt="150x89 Placeholder" src="http://placehold.it/150x89" /></a>
                                </li>
                            </div>--%>
                        </div>
                        <!-- end row -->
                    </div>
                    <!-- end founding-slides-wrapper -->
                </div>
                <!-- end founding-carousel-outer -->
            </div>
            <!-- end founding-container -->
            <!-- END PARTIAL: founding-carousel -->
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container  flush -->

