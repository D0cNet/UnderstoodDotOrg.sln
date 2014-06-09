<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Connections.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Tabs.Connections" %>
<div class="container flush friends-view-tabs-page-header">&nbsp;</div>

<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-24 offset-1">
            <div class="tab-container friends-view-tabs friends-connections skiplink-content" aria-role="main">

                <!-- BEGIN PARTIAL: friends-view-tabs -->
                <ul class="etabs">
                    <li class="tab profile-tab active"><asp:HyperLink ID="hypProfileTab" runat="server">Profile</asp:HyperLink></li>
                    <li class="tab connections-tab "><asp:HyperLink ID="hypConnectionsTab" runat="server">Connections</asp:HyperLink></li>
                    <li class="tab comments-tab "><asp:HyperLink ID="hypCommentsTab" runat="server">Comments <span class="comment-number">15</span></asp:HyperLink></li>
                </ul>
                <div class="friends-view-tabs-select select-inverted-mobile">
                    <div class="etabs-dropdown">
                        <select class="">
                            <option value="profile">Profile</option>
                            <option value="connections">Connections</option>
                            <option value="comments">Comments</option>
                        </select>
                    </div>
                </div>
                <!-- END PARTIAL: friends-view-tabs -->

                <div class="panel-container connections-panel">

                    <!-- BEGIN PARTIAL: friends-view-tabs-2 -->
                    <div class="my-connections-grid profile-connections">
                        <div class="row">
                            <section class="connections group" id="user_equal_heights">
                                <div class="row member-cards">
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Harvey43</a>
                                                    <p class="location">nobis</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>4th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 4,
            Boy
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
                                                                    <li>Hic Aut</li>
                                                                    <li>Officiis Voluptatibus</li>
                                                                    <li>Dolorum Rem</li>
                                                                    <li>Et Nobis</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">PetersDad with Long Name</a>
                                                    <p class="location">sit</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>5th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 5,
            Boy
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
                                                                    <li>Praesentium Explicabo</li>
                                                                    <li>Enim At</li>
                                                                    <li>Est Rerum</li>
                                                                    <li>Nam Ut</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>11th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 11,
            Girl
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
                                                                    <li>Eos Molestiae</li>
                                                                    <li>Itaque Commodi</li>
                                                                    <li>Debitis Dicta</li>
                                                                    <li>Velit Praesentium</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">PetersDad17 Hasaverylongname</a>
                                                    <p class="location">voluptate</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>5th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 5,
            Boy
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
                                                                    <li>Nulla Assumenda</li>
                                                                    <li>Et Dolorum</li>
                                                                    <li>Aliquam Ut</li>
                                                                    <li>Soluta Ut</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>6th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 6,
            Boy
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
                                                                    <li>Maiores Aperiam</li>
                                                                    <li>Aliquid Sunt</li>
                                                                    <li>Quos Quam</li>
                                                                    <li>Laborum Est</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>8th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 8,
            Boy
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
                                                                    <li>At Necessitatibus</li>
                                                                    <li>Aliquam Blanditiis</li>
                                                                    <li>Odio Quis</li>
                                                                    <li>Voluptatibus Nemo</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                                        <div class="image-label">Blogger</div>
                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate Blogger">

                                                    <a href="REPLACE" class="name-member">Pete Clapp</a>
                                                    <span class="location">Understood Blogger</span>
                                                    <a href="REPLACE" class="name-community">Molestias Voluptas blog</a>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">
                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class='specialty-long'><a href='REPLACE'>PreK</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>PreK,
            Boy
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
                                                                    <li>Cum Rem</li>
                                                                    <li>At Et</li>
                                                                    <li>Molestias Eos</li>
                                                                    <li>Occaecati Et</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>3rd</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 3,
            Girl
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
                                                                    <li>Magni Nihil</li>
                                                                    <li>Animi Impedit</li>
                                                                    <li>Officia Deserunt</li>
                                                                    <li>In Quod</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>10th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 10,
            Girl
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
                                                                    <li>Asperiores Porro</li>
                                                                    <li>Consequatur Debitis</li>
                                                                    <li>Veritatis Sunt</li>
                                                                    <li>At Quasi</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty-long'><a href='REPLACE'>Adult</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Adult,
            Girl
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
                                                                    <li>Quod Dolore</li>
                                                                    <li>Unde Non</li>
                                                                    <li>Nesciunt Eius</li>
                                                                    <li>Exercitationem Sed</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Tammie72</a>
                                                    <p class="location">earum</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>4th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 4,
            Girl
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
                                                                    <li>Impedit Deleniti</li>
                                                                    <li>Sit Molestiae</li>
                                                                    <li>Consequatur Et</li>
                                                                    <li>Minima Dolorum</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>7th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 7,
            Girl
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
                                                                    <li>Et Officiis</li>
                                                                    <li>Assumenda Aut</li>
                                                                    <li>Aut Earum</li>
                                                                    <li>Id Voluptatem</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty-long'><a href='REPLACE'>Adult</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Adult,
            Boy
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
                                                                    <li>Nostrum Expedita</li>
                                                                    <li>Rerum Temporibus</li>
                                                                    <li>Nam Laborum</li>
                                                                    <li>Laborum Ipsam</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                                        <div class="image-label">Moderator</div>
                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate Moderator">

                                                    <a href="REPLACE" class="name-member">Billy Vick</a>
                                                    <span class="location">Group Moderator</span>
                                                    <a href="REPLACE" class="name-community">Title of Community Group</a>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">
                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class='specialty-long'><a href='REPLACE'>PreK</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>PreK,
            Boy
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
                                                                    <li>Dolor Dolore</li>
                                                                    <li>Voluptates Est</li>
                                                                    <li>Reiciendis Tempora</li>
                                                                    <li>Repudiandae Aperiam</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>2nd</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 2,
            Boy
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
                                                                    <li>At Enim</li>
                                                                    <li>Voluptatem Neque</li>
                                                                    <li>Magni Asperiores</li>
                                                                    <li>Vero Officia</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>10th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 10,
            Girl
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
                                                                    <li>Nam Ut</li>
                                                                    <li>Adipisci Laudantium</li>
                                                                    <li>Voluptate Quidem</li>
                                                                    <li>Omnis Non</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>12th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 12,
            Boy
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
                                                                    <li>Dolores Quo</li>
                                                                    <li>Eius Porro</li>
                                                                    <li>Sequi Consequatur</li>
                                                                    <li>Excepturi Quia</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Sheryl36</a>
                                                    <p class="location">ut</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>7th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 7,
            Boy
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
                                                                    <li>Quia Eos</li>
                                                                    <li>Et Sapiente</li>
                                                                    <li>Earum Tempora</li>
                                                                    <li>Iusto Necessitatibus</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>9th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 9,
            Boy
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
                                                                    <li>Perspiciatis Accusantium</li>
                                                                    <li>Dolore Et</li>
                                                                    <li>Quae Animi</li>
                                                                    <li>Suscipit Ducimus</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>11th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 11,
            Girl
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
                                                                    <li>Et Consequatur</li>
                                                                    <li>Tempore Velit</li>
                                                                    <li>Adipisci Quos</li>
                                                                    <li>Delectus Saepe</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty-long'><a href='REPLACE'>Adult</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Adult,
            Boy
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
                                                                    <li>Aut Temporibus</li>
                                                                    <li>Quidem Atque</li>
                                                                    <li>Dolor Et</li>
                                                                    <li>Est Est</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                                        <div class="image-label">Expert</div>
                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate Expert">

                                                    <a href="REPLACE" class="name-member">Jordyn Norman</a>
                                                    <span class="location">Ullam Quis</span>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">
                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class='specialty-long'><a href='REPLACE'>PreK</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>PreK,
            Boy
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
                                                                    <li>Sunt Ad</li>
                                                                    <li>Dolor Itaque</li>
                                                                    <li>Debitis Laudantium</li>
                                                                    <li>Fugiat Hic</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>4th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 4,
            Boy
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
                                                                    <li>Eaque Exercitationem</li>
                                                                    <li>Ipsam Aut</li>
                                                                    <li>Cupiditate Neque</li>
                                                                    <li>Fugit Deserunt</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>5th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 5,
            Boy
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
                                                                    <li>Doloribus Repellendus</li>
                                                                    <li>Temporibus Consequatur</li>
                                                                    <li>Amet Nemo</li>
                                                                    <li>Non Id</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>7th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 7,
            Boy
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
                                                                    <li>Enim Perferendis</li>
                                                                    <li>Culpa Minima</li>
                                                                    <li>Cupiditate Nulla</li>
                                                                    <li>Ipsam Natus</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Piper95</a>
                                                    <p class="location">voluptas</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>4th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 4,
            Girl
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
                                                                    <li>Nihil Quo</li>
                                                                    <li>Labore Vel</li>
                                                                    <li>Ratione Animi</li>
                                                                    <li>Eaque Minima</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>11th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 11,
            Boy
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
                                                                    <li>Odit Dolorem</li>
                                                                    <li>Assumenda Aut</li>
                                                                    <li>Quasi Repudiandae</li>
                                                                    <li>Qui Tenetur</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Alonzo24</a>
                                                    <p class="location">fugit</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>1st</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 1,
            Boy
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
                                                                    <li>Ut Sunt</li>
                                                                    <li>Porro Commodi</li>
                                                                    <li>Eligendi Enim</li>
                                                                    <li>Voluptatibus Sint</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>9th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 9,
            Boy
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
                                                                    <li>Veritatis Est</li>
                                                                    <li>Nemo Ea</li>
                                                                    <li>Est Eos</li>
                                                                    <li>Deserunt Laboriosam</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty-long'><a href='REPLACE'>Adult</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Adult,
            Girl
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
                                                                    <li>Alias Id</li>
                                                                    <li>Consequatur Maxime</li>
                                                                    <li>Et Officiis</li>
                                                                    <li>Id Minus</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                                        <div class="image-label">Moderator</div>
                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate Moderator">

                                                    <a href="REPLACE" class="name-member">Harvey Kaplan</a>
                                                    <span class="location">Group Moderator</span>
                                                    <a href="REPLACE" class="name-community">Title of Community Group</a>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">
                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>3rd</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 3,
            Boy
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
                                                                    <li>Aut Ea</li>
                                                                    <li>Doloremque Qui</li>
                                                                    <li>Sunt Iusto</li>
                                                                    <li>Consectetur Sequi</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>11th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 11,
            Boy
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
                                                                    <li>Dolor Omnis</li>
                                                                    <li>Sed Sapiente</li>
                                                                    <li>Ipsum Dignissimos</li>
                                                                    <li>Occaecati Ratione</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Joey42</a>
                                                    <p class="location">delectus</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>2nd</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 2,
            Girl
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
                                                                    <li>Ut Cupiditate</li>
                                                                    <li>Minus Pariatur</li>
                                                                    <li>In Totam</li>
                                                                    <li>Magni Aut</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>8th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 8,
            Girl
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
                                                                    <li>Exercitationem Ut</li>
                                                                    <li>Est Consequuntur</li>
                                                                    <li>Quas At</li>
                                                                    <li>Non Harum</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Reid87</a>
                                                    <p class="location">suscipit</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>9th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 9,
            Boy
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
                                                                    <li>Dolorum Corporis</li>
                                                                    <li>Nihil Commodi</li>
                                                                    <li>Recusandae Maxime</li>
                                                                    <li>Inventore Excepturi</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class='specialty-long'><a href='REPLACE'>Adult</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Adult,
            Girl
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
                                                                    <li>Quo Quod</li>
                                                                    <li>Cum Ullam</li>
                                                                    <li>Dignissimos Et</li>
                                                                    <li>Dolorem Consequuntur</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Tracy48</a>
                                                    <p class="location">alias</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>7th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 7,
            Boy
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
                                                                    <li>Eius Et</li>
                                                                    <li>Atque Maiores</li>
                                                                    <li>Nisi Vel</li>
                                                                    <li>Ex Quia</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Isabelle14</a>
                                                    <p class="location">velit</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>1st</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 1,
            Girl
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
                                                                    <li>Libero Incidunt</li>
                                                                    <li>Quis Sit</li>
                                                                    <li>Itaque Et</li>
                                                                    <li>Velit Consequatur</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Josephine59</a>
                                                    <p class="location">et</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>4th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 4,
            Boy
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
                                                                    <li>Rem Laborum</li>
                                                                    <li>Ducimus Eum</li>
                                                                    <li>Iusto Voluptatum</li>
                                                                    <li>Totam Maiores</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>10th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 10,
            Boy
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
                                                                    <li>Natus Est</li>
                                                                    <li>In Animi</li>
                                                                    <li>Et Vitae</li>
                                                                    <li>Et Explicabo</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                    <!-- BEGIN PARTIAL: community/member_card -->
                                    <div class="member-card-container">
                                        <div class="rs_read_this col member-card col-6">
                                            <div class="member-card-info group">
                                                <div class="member-card-image">
                                                    <a href="REPLACE">
                                                        <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />

                                                    </a>
                                                </div>
                                                <!-- end .member-card-image -->
                                                <div class="member-card-name hyphenate member">

                                                    <a href="REPLACE" class="name-member">Denis66</a>
                                                    <p class="location">enim</p>

                                                </div>
                                                <!-- end .member-card-name -->

                                                <div class="card-buttons member">

                                                    <button type="button" class="button blue rs_skip">See Activity</button>

                                                </div>
                                                <!-- end .member.card-buttons -->

                                            </div>
                                            <!-- end .member-card-info -->
                                            <div class="member-card-specialties">
                                                <ul>
                                                    <span class="visuallyhidden">grade level</span>
                                                    <li class=''><a href='REPLACE'>3rd</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 3,
            Girl
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
                                                                    <li>Officiis Blanditiis</li>
                                                                    <li>Dolores Asperiores</li>
                                                                    <li>Qui Quia</li>
                                                                    <li>Quas Natus</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>
                                                    <li class=''><a href='REPLACE'>4th</a><!-- BEGIN PARTIAL: community/child_info_card -->

                                                        <div class="card-child-info popover rs_skip">
                                                            <div class="popover-content">
                                                                <span class="caret"></span>
                                                                <h3>Grade 4,
                                                                Girl
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
                                                                    <li>Et Molestias</li>
                                                                    <li>Ut Rerum</li>
                                                                    <li>Aperiam Molestiae</li>
                                                                    <li>Et Sint</li>
                                                                </ul>
                                                                <div class="card-buttons">
                                                                    <button class="button gray">View Profile</button>
                                                                    <button class="button blue">See Activity</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END PARTIAL: community/child_info_card -->
                                                    </li>

                                                    <li class="specialty specialty-final">
                                                        <span class="visuallyhidden">additional information</span>
                                                        <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- end .member-card -->
                                    </div>
                                    <!-- end .member-card-container  -->
                                    <!-- END PARTIAL: community/member_card -->
                                </div>
                            </section>
                        </div>
                        <div class="showmore-footer">
                            <!-- Show More -->
                            <!-- BEGIN PARTIAL: community/show_more -->
                            <!--Show More-->
                            <div class="container show-more rs_skip">
                                <div class="row">
                                    <div class="col col-24">
                                        <a class="show-more-link show_more" href="#" data-path="my-account/profile.friend.connections" data-container="member-cards" data-item="member-card-container" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
                                    </div>
                                </div>
                            </div>
                            <!-- .show-more -->
                            <!-- END PARTIAL: community/show_more -->
                            <!-- .show-more -->
                        </div>
                    </div>
                    <!-- END PARTIAL: friends-view-tabs-2 -->
                </div>
                <!-- end .connections-panel -->
            </div>
            <!-- end .tab-container.friends-view-tabs -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
