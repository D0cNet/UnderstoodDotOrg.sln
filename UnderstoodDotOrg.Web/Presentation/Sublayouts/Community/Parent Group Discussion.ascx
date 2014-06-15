<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Group Discussion.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Group_Discussion" %>

    <!-- BEGIN PARTIAL: community/main_header -->

    <!-- END PARTIAL: community/main_header -->
<script>
    jQuery(document).ready(function () {
        jQuery("a").click(
               function (evt) {
                   if (jQuery(this).attr("href").indexOf("REPLACE") > -1) {

                       alert("Link not implemented!");
                       return false;

                   }
               });

    });

</script>
    <div class="container">
        <div class="row">
            <div class="container">
                <header class="groups-heading">
                    <!-- BEGIN PARTIAL: community/breadcrumb_menu -->
                    <!--breadcrumb menu-->
                    <a href="REPLACE" runat="server" id="hrfBack" class="back-to-previous rs_skip">
                        <i class="icon-arrow-left-blue"></i>
                        <asp:Literal ID="litBack" Text="" runat="server" />
                    </a>
                    <!-- END PARTIAL: community/breadcrumb_menu -->
                    <!-- BEGIN PARTIAL: community/groups_private_heading -->
                    <!--groups private partial-->
                    <div class="col groups-private">
                        <p class="col">Only members can see the conversations</p>
                        <i class="icon"></i>
                    </div>
                    <!-- END PARTIAL: community/groups_private_heading -->
                </header>
                <div class="col col-24 skiplink-content" aria-role="main">
                    <div class="col col-18 discussion-list">
                        <header class="col title rs_read_this">
                            <h2>
                                <asp:Label ID="lblSubject" runat="server"></asp:Label></h2>
                        </header>
                        <!-- BEGIN PARTIAL: community/groups_discussion_post -->
                        <!--Groups Discussion-Post-->
                        <div class="discussion-post clearfix rs_read_this">
                            <div class="col col-4 discussion-contributer">
                                <div class="contributer-image">
                                    <asp:Image ID="imgAvatar" runat="server" />

                                </div>
                                <a class="name" href="REPLACE">
                                    <asp:Label Text="" ID="lblName" runat="server" /></a>
                                <p class="location">
                                    <asp:Label Text="" ID="lblLocation" runat="server" />
                                </p>
                                <a href="REPLACE" class="button rs_skip">Connect</a>
                                <div class="member-card-specialties parents-member-cards">
                                    <asp:Repeater ID="rptChildCard" OnItemDataBound="rptChildCard_ItemDataBound" ClientIDMode="Static" runat="server">
                                        <HeaderTemplate>
                                            <ul>
                                                <span class="visuallyhidden">grade level</span>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li class='specialty '>
                                                <!-- BEGIN PARTIAL: community/child_info_card -->
                                                <span tabindex='0' data-tabbable='true'>
                                                    <%#Eval("Grade") %>th</span>

                                                <div class="card-child-info popover">
                                                    <div class="popover-content">
                                                        <span class="caret"></span>
                                                        <h3>Grade <%#Eval("Grade") %>,
								                <%#Eval("Gender") %>
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
                                                        <asp:Repeater ID="rptChildIssues" ClientIDMode="Static" runat="server">
                                                            <HeaderTemplate>
                                                                <ul>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <li><%#Eval("IssueName") %></li>
                                                            </ItemTemplate>
                                                            <FooterTemplate></ul></FooterTemplate>
                                                        </asp:Repeater>
                                                        <%-- <ul>
								                <li>Illo Fuga</li>
								                <li>Voluptas Repudiandae</li>
								                <li>Nostrum Maiores</li>
								                <li>Temporibus Sit</li>
							                </ul>--%>
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

                                        </ItemTemplate>

                                        <FooterTemplate>
                                            </ul>

                                        </FooterTemplate>
                                    </asp:Repeater>

                                </div>
                            </div>
                            <div class="discussion-comment">
                                <p>
                                    <asp:Literal Text="" ID="litComment" runat="server" />
                                </p>
                            </div>
                            <footer class="discussion-footer rs_skip">
                                <h4>Show your support</h4>
                                <ul class="support-menu">
                                    <li>
                                        <button class="thanks">
                                            <i class="smiley-icon"></i>
                                            <p>Thanks</p>
                                        </button>
                                    </li>
                                    <li>
                                        <button class="thinking-of-you">
                                            <i class="flower-icon"></i>
                                            <p>Thinking of You</p>
                                        </button>
                                    </li>
                                    <li>
                                        <button class="likes">
                                            <i class="thumbs-up-icon"></i>
                                            <p>15</p>
                                        </button>
                                    </li>
                                </ul>
                            </footer>
                            <%-- <sc:SubLayout ID="sbDiscussioinList" Path="~/Presentation/Sublayouts/Common/GroupDiscussionList.ascx" runat="server"></sc:SubLayout>--%>
                        </div>
                        <asp:PlaceHolder ID="plhGroupDiscussions" runat="server"></asp:PlaceHolder>
                        <!--Groups Discussion-Post-->

                        <!-- END PARTIAL: community/groups_discussion_post -->

                        <!--Groups Discussion-Post-->


                    </div>
                    <!-- end .discussion-list -->
                    <div class="col col-4 offset-1 discussion-sidebar rs_read_this">
                        <div class="discussion-meta skiplink-sidebar">
                            <div class="discussion">
                                <i class="number-bubble-icon"><asp:literal ID="litMemberCount" runat="server"></asp:literal></i>
                                <p class="parents-in-discussion">Parents in this Discussion</p>
                            </div>
                            <!-- end .discussion -->
                            <div class="replies">
                                <i class="replies-bubble-icon">
                                    <asp:Literal Text="" ID="litNumReplies" runat="server" /></i>
                                <p class="replies">Replies</p>
                            </div>
                            <!-- end .replies -->
                            <p class="something-to-add">Do you have something to add?</p>
                            <a href="#joinlink" class="button rs_skip">Join Discussion</a>
                        </div>
                        <!-- end .discussion-meta -->
                    </div>
                    <!-- end .discussion-sidebar -->
                </div>
                <div class="col col-16 offset-2 join-discussion" id="joinlink">
                    <fieldset>
                        <label for="join-discussion-text" class="visuallyhidden">Join the discussion</label>
                        <%--<textarea class="comment" id="join-discussion-text" placeholder="Join the discussion"></textarea>--%>
                        <asp:TextBox CssClass="comment" Columns="40" Rows="40" ID="txtBody" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                        <%--<a href="REPLACE" class="button rs_skip">Submit</a>--%>
                        <asp:LinkButton CssClass="button rs_skip" OnClick="lbSubmitReply_Click" Text="Submit" ID="lbSubmitReply" runat="server" />
                    </fieldset>
                </div>
                <!-- end .join-discussion -->
            </div>
        </div>
    </div>

