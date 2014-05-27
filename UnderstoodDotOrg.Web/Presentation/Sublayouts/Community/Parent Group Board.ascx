<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Group Board.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Group_Board" %>

<script type="text/javascript">
    function checkValidation() {
        if (!Page_ClientValidate("newDiscussion")) {
            return false;
        }
        else {
            return confirm('Items created by end user cannot be modified until published. Are you sure you want to create a thread?');
        }
    }

    jQuery(document).ready(function () {


        jQuery("#btn_start_discussion").click(
             function () {
                 jQuery(".modal_discussion").toggle();
                 //alert("Discussion button clicked");
             });
    });
</script>
<div class="container">
    <div class="row">
        <div class="container">
            <header class="groups-heading rs_read_this">
                <!-- BEGIN PARTIAL: community/breadcrumb_menu -->
                <!--breadcrumb menu-->
                <a href="REPLACE" class="back-to-previous rs_skip">
                    <i class="icon-arrow-left-blue"></i>Back to Parents of Kids with Reading Issues
                </a>
                <!-- END PARTIAL: community/breadcrumb_menu -->
                <div class="col col-24 title">
                    <h2>
                        <asp:Literal Text="" ID="litForumName" runat="server" /></h2>
                </div>
                <!-- BEGIN PARTIAL: community/groups_private_heading -->
                <!--groups private partial-->
                <div class="col groups-private">
                    <p class="col">Only members can see the conversations</p>
                    <i class="icon"></i>
                </div>
                <!-- END PARTIAL: community/groups_private_heading -->
            </header>

            <!-- BEGIN PARTIAL: community/groups_start_discussion -->
            <!--discussion board-->

            <div class="col col-24 search-board">
                <div class="rs_read_this discussion-board-rs-wrapper">
                    <div class="col-16 discussion-boards mobile-group-search-form offset-1 skiplink-toolbar">
                        <h3>Search this board</h3>


                        <!-- BEGIN PARTIAL: community/groups_search_form -->
                        <!--groups search form-->
                        <fieldset class="group-search-form mobile-group-search-form">
                            <label for="group-search-text" class="visuallyhidden" aria-hidden="true">Search</label>
                            <input type="text" class="group-search" id="group-search-text" name="group-search" placeholder="Enter conversation">
                            <input class="group-search-button" type="submit" value="Go">
                        </fieldset>
                        <!-- END PARTIAL: community/groups_search_form -->




                    </div>
                    <!-- end .discussion-boards -->
                    <div class="col-6 start-discussion">
                        <p>Got a question?</p>
                        <p class="want-to-talk">Want to talk?</p>
                        <a href="REPLACE" class="button">Start a Discussion</a>
                    </div>
                    <!-- end .start-discussion -->
                </div>
            </div>
            <!-- end .discussion-board -->
            <!-- END PARTIAL: community/groups_start_discussion -->

            <div class="modal_discussion" runat="server" id="modal_discussion" style="display: none; clear: both">


                <asp:Label ID="lblSubject" runat="server" Text="Subject:" />
                <asp:TextBox ID="txtSubject" ValidationGroup="newDiscussion" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqdSubject" ValidationGroup="newDiscussion" ControlToValidate="txtSubject" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />

                <asp:Label ID="lblBody" runat="server" Text="Body:" />
                <asp:TextBox ID="txtBody" ValidationGroup="newDiscussion" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="newDiscussion" ID="rqdDiscussion" ControlToValidate="txtBody" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />

                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="button" OnClientClick="javascript:return checkValidation();" ClientIDMode="Static" ValidationGroup="newDiscussion" runat="server" Text="Create" />
                <asp:Label Text="" CssClass="error" ID="error_msg" ForeColor="Red" Visible="false" runat="server" />

            </div>

            <div class="col col-23 individual-group skiplink-content" aria-role="main">
                <!-- BEGIN PARTIAL: community/groups_table -->
                <div class="discussion-box col col-23 offset-1">
                    <%--      <header class="rs_skip">

    

    
                    <h4 class="col summary">Discussion</h4>
                    <h4 class="col started-by">Started by</h4>
                    <h4 class="col replies">Replies</h4>
                    <h4 class="col latest-post-tabular">Latest Post</h4>
    

                  </header>--%>

                    <asp:Repeater ID="rptThread" OnItemDataBound="rptThread_ItemDataBound" runat="server">

                        <HeaderTemplate>
                            <ul class="discussions table-discussions search-results rs_read_this">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <div class="col summary">
                                    <asp:HiddenField Value='<%# Eval("Subject") %>' runat="server" ID="hdSubject" />
                                    <h4>Discussion:</h4>
                                    <a href="REPLACE" id="hrefDiscussion" runat="server"><%# Eval("Snippet") %></a>
                                </div>
                                <div class="col latest-post rs_skip">
                                    <h4>Latest Post:</h4>
                                    <p class="mins-ago"><%# Eval("LastPostTime") %></p>
                                    <a href="REPLACE"><%# Eval("LastPostUser") %></a>
                                    <p><%# Eval("LastPostBody") %></p>
                                </div>
                                <div class="col started-by">
                                    <h4>Started by:</h4>
                                    <a href="REPLACE"><%# Eval("StartedBy") %></a>
                                </div>

                                <div class="col replies">
                                    <h4>Replies:</h4>
                                    <p><%# Eval("ReplyCount") %></p>
                                </div>
                                <div class="col latest-post-tabular">
                                    <h4>Latest Post:</h4>
                                    <p>5<%# Eval("LastPostTime") %></p>
                                    <a href="REPLACE"><%# Eval("LastPostUser") %></a>
                                    <p><%# Eval("LastPostBody") %></p>
                                </div>

                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                    <%--<%----%>
                    <%--<ul class="discussions table-discussions search-results rs_read_this">
    
      <!-- BEGIN PARTIAL: community/individual_board_list_item -->
                <!--individual board list item-->
                <li>
                  <div class="col summary">
                    <h4>Discussion:</h4>
                    <a href="REPLACE">Vel Illo Debitis Sint Voluptatem Odio Perspiciatis. Vero Nihil Voluptatum Totam Quam Et Dolores Nostrum Occaecati Aliquam Sint Modi Dolorem Suscipit</a>
                  </div>
                  <div class="col latest-post rs_skip">
                    <h4>Latest Post:</h4>
                    <p class="mins-ago">32 mins ago</p>
                    <a href="REPLACE">Rem</a>
                    <p>Neque Officia Adipisci Voluptate Vel Doloremque Ab Et</p>
                  </div>
                  <div class="col started-by">
                    <h4>Started by:</h4>
                    <a href="REPLACE">Debitis</a>
                  </div>

                  <div class="col replies">
                    <h4>Replies:</h4>
                    <p>16</p>
                  </div>
                  <div class="col latest-post-tabular">
                    <h4>Latest Post:</h4>
                    <p>58 mins ago</p>
                    <a href="REPLACE">Ut</a>
                    <p>Provident Reprehenderit Aperiam Architecto Consequatur Quam Vel Et Consectetur Voluptas Non</p>
                  </div>
                </li>
                <!-- END PARTIAL: community/individual_board_list_item -->
                      <!-- BEGIN PARTIAL: community/individual_board_list_item -->
                <!--individual board list item-->
                <li>
                  <div class="col summary">
                    <h4>Discussion:</h4>
                    <a href="REPLACE">Repudiandae Dolorum Laborum Soluta Voluptatem Nemo Corporis Nihil Itaque Ducimus Voluptas Omnis Quo Amet. Quia Eos Qui Eaque Ipsa Quaerat Ullam Repellendus Facere</a>
                  </div>
                  <div class="col latest-post rs_skip">
                    <h4>Latest Post:</h4>
                    <p class="mins-ago">38 mins ago</p>
                    <a href="REPLACE">Sit</a>
                    <p>Molestias Perferendis Et Ea Officiis Vero Est A Dolor Odit Minima Itaque Accusamus</p>
                  </div>
                  <div class="col started-by">
                    <h4>Started by:</h4>
                    <a href="REPLACE">Quaerat</a>
                  </div>

                  <div class="col replies">
                    <h4>Replies:</h4>
                    <p>77</p>
                  </div>
                  <div class="col latest-post-tabular">
                    <h4>Latest Post:</h4>
                    <p>28 mins ago</p>
                    <a href="REPLACE">Facilis</a>
                    <p>Debitis Mollitia Id Et Natus</p>
                  </div>
                </li>
                <!-- END PARTIAL: community/individual_board_list_item -->
                      <!-- BEGIN PARTIAL: community/individual_board_list_item -->
                <!--individual board list item-->
                <li>
                  <div class="col summary">
                    <h4>Discussion:</h4>
                    <a href="REPLACE">Perspiciatis Nam Omnis Accusamus Et. Dolores Architecto Quia Quis Et Est Porro Libero Dolorem Eveniet Expedita</a>
                  </div>
                  <div class="col latest-post rs_skip">
                    <h4>Latest Post:</h4>
                    <p class="mins-ago">52 mins ago</p>
                    <a href="REPLACE">Rerum</a>
                    <p>Blanditiis Velit Sit Ut Porro Enim Eum Fugit Nihil Non Soluta Ipsum Quaerat</p>
                  </div>
                  <div class="col started-by">
                    <h4>Started by:</h4>
                    <a href="REPLACE">Illo</a>
                  </div>

                  <div class="col replies">
                    <h4>Replies:</h4>
                    <p>69</p>
                  </div>
                  <div class="col latest-post-tabular">
                    <h4>Latest Post:</h4>
                    <p>57 mins ago</p>
                    <a href="REPLACE">Temporibus</a>
                    <p>Atque Unde Natus Ut Itaque Quia Mollitia Omnis Non Accusantium</p>
                  </div>
                </li>
                <!-- END PARTIAL: community/individual_board_list_item -->
    

             </ul>--%>
                    <!-- end .discussions -->
                </div>
                <!-- END PARTIAL: community/groups_table -->
            </div>
            <!-- end .individual-group -->
        </div>
    </div>
</div>
<div class="container show-more rs_skip">
    <div class="row">
        <div class="col col-24">
            <a class="show-more-link " data-container="table-discussions" data-count="3" data-item="summary" data-path="community/groups-board-results" href="#">Show More<i class="icon-arrow-down-blue"></i></a>
        </div>
    </div>
</div>


<!-- END PARTIAL: community/main_header -->
