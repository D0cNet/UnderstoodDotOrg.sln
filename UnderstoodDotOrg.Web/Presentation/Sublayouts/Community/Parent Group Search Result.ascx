<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Group Search Result.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Group_Search_Result" %>
<div class="container">
    <!-- BEGIN PARTIAL: community/featured_group -->
    <!--featured group header -->

    <!-- END PARTIAL: community/featured_group -->
    <div class="row">
          <div class="col col-23 individual-group skiplink-content" aria-role="main">
            <header class="search-results  offset-1 rs_read_this">
              <span class="results-for">
                  <asp:Literal Text="" ID="litResultsCount" runat="server" /> Results for <h3>"<asp:Literal ID="litSearchCriteria" runat="server"></asp:Literal>"</h3>
              </span>
            </header><!-- end header -->
            <!-- BEGIN PARTIAL: community/groups_table -->
            <div class="discussion-box col col-23 offset-1">
                  <header class="rs_skip">

    
                    <h4 class="col summary">Discussion</h4>
                    <h4 class="col board">Board</h4>
                    <h4 class="col started-by">Started by</h4>
                    <h4 class="col replies">Replies</h4>
                    <h4 class="col latest-post-tabular">Latest Post</h4>
    

                </header>
                  <ul class="discussions table-discussions search-results rs_read_this">

    
                      <!-- BEGIN PARTIAL: community/conversation_list_item -->
                        <!--section.container.conversation-list-item-->

                        <li>
                          <div class="col summary">
                            <h4>Discussion:</h4>
                            <a href="REPLACE">Qui Qui Repudiandae Sapiente Distinctio Aut Quia Ut Accusamus. Accusamus Et Accusamus Excepturi Eveniet Est Optio Quod Voluptatibus Ullam Porro</a>
                          </div>
                          <div class="col latest-post rs_skip">
                            <h4>Latest Post:</h4>
                            <p class="mins-ago">47 mins ago</p>
                            <a href="REPLACE">Molestiae</a>
                            <p>Accusantium Asperiores Alias Eum Corrupti Vero Magnam Blanditiis Soluta</p>
                          </div>
                          <div class="col board">
                            <h4>Board:</h4>
                            <a href="REPLACE">Atque Quaerat</a>
                          </div>
                          <div class="col started-by">
                            <h4>Started by:</h4>
                            <a href="REPLACE">Et</a>
                          </div>

                          <div class="col replies">
                            <h4>Replies:</h4>
                            <p>93</p>
                          </div>
                          <div class="col latest-post-tabular">
                            <h4>Latest Post:</h4>
                            <p>44 mins ago</p>
                            <a href="REPLACE">Nisi</a>
                            <p>Sit Architecto Illum Earum</p>
                          </div>
                        </li>
                        <!-- END PARTIAL: community/conversation_list_item -->
                              <!-- BEGIN PARTIAL: community/conversation_list_item -->
                        <!--section.container.conversation-list-item-->

                        <li>
                          <div class="col summary">
                            <h4>Discussion:</h4>
                            <a href="REPLACE">Veniam Maxime Odio Non Rem Non Incidunt Ut Excepturi Officiis Temporibus Atque Voluptate A Autem. Impedit Quia Commodi Esse Ipsa Rerum Incidunt Qui Ad Nesciunt Perferendis Vel</a>
                          </div>
                          <div class="col latest-post rs_skip">
                            <h4>Latest Post:</h4>
                            <p class="mins-ago">23 mins ago</p>
                            <a href="REPLACE">In</a>
                            <p>Fugit Deserunt Iusto Nostrum Consequatur Quae Voluptatibus</p>
                          </div>
                          <div class="col board">
                            <h4>Board:</h4>
                            <a href="REPLACE">Sint Voluptas</a>
                          </div>
                          <div class="col started-by">
                            <h4>Started by:</h4>
                            <a href="REPLACE">Debitis</a>
                          </div>

                          <div class="col replies">
                            <h4>Replies:</h4>
                            <p>91</p>
                          </div>
                          <div class="col latest-post-tabular">
                            <h4>Latest Post:</h4>
                            <p>14 mins ago</p>
                            <a href="REPLACE">Hic</a>
                            <p>Aliquam Laboriosam Dolor Hic Soluta Excepturi Excepturi Commodi Fuga Quia Inventore Ut Minima Voluptatem Omnis</p>
                          </div>
                        </li>
                        <!-- END PARTIAL: community/conversation_list_item -->
                              <!-- BEGIN PARTIAL: community/conversation_list_item -->
                        <!--section.container.conversation-list-item-->

                        <li>
                          <div class="col summary">
                            <h4>Discussion:</h4>
                            <a href="REPLACE">Animi Corporis Nobis Et Omnis. Porro Similique Ullam Doloremque Esse Occaecati Autem</a>
                          </div>
                          <div class="col latest-post rs_skip">
                            <h4>Latest Post:</h4>
                            <p class="mins-ago">19 mins ago</p>
                            <a href="REPLACE">Repellat</a>
                            <p>Minima Quis Necessitatibus Eum Modi Iusto Sunt Ut Quia</p>
                          </div>
                          <div class="col board">
                            <h4>Board:</h4>
                            <a href="REPLACE">Rem Officia</a>
                          </div>
                          <div class="col started-by">
                            <h4>Started by:</h4>
                            <a href="REPLACE">Pariatur</a>
                          </div>

                          <div class="col replies">
                            <h4>Replies:</h4>
                            <p>6</p>
                          </div>
                          <div class="col latest-post-tabular">
                            <h4>Latest Post:</h4>
                            <p>27 mins ago</p>
                            <a href="REPLACE">Eum</a>
                            <p>Nam Veritatis Eveniet Ipsum Ipsum</p>
                          </div>
                        </li>
                        <!-- END PARTIAL: community/conversation_list_item -->
    

    

                  </ul> <!-- end .discussions -->
            </div>
            <!-- END PARTIAL: community/groups_table -->
          </div><!-- end .individual-group -->
    </div>
</div><!-- .container -->
