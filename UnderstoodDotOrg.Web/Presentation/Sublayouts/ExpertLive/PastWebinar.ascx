<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PastWebinar.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.PastWebinar" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container event">
    <header class="row">
        <div class="event-container skiplink-feature">
            <ul class="breadcrumbs">
                    <li><%--<a href="REPLACE">Back to Ducimus Quia</a>--%>
                        <asp:HyperLink runat="server" ID="hlBackToLink" ></asp:HyperLink>
                    </li>
            </ul>

            <h2 class="rs_read_this"> <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></h2>
        </div>
    </header>

    <div class="row">
        <div class="event-container">
            <div class="col-18 col event-content rs_read_this">
                <div class="event-image">
                    <div class="thumbnail">
                       <asp:HyperLink ID="hlLink" runat="server">
                            <sc:FieldRenderer ID="scThumbImg" runat="server" FieldName="Expert Image" />
                            <asp:Image runat="server" ID="imgExpertDefault" ImageUrl="http://placehold.it/150x150" Visible="false" />
                            <div class="image-label">
                                <asp:Literal ID="litGuest" runat="server"></asp:Literal>
                            </div>
                        </asp:HyperLink>
                    </div>

                    <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                    <div class="recommended-for">
                        <p>Recommended for</p>
                        <span class="children-key">
                            <ul>
                                <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                    <!-- END PARTIAL: community/experts_recommended_for -->
                </div>
                <!-- end .event-image -->

                <p class="event-date-time"><asp:Literal runat="server" ID="ltEventDate"></asp:Literal></p>
                <p class="event-host-name"><sc:FieldRenderer ID="frExpertName" runat="server" FieldName="Expert Name" /></p>
                <p class="event-host-title"><sc:FieldRenderer ID="frHeading" runat="server" FieldName="Heading" /></p>
                <p class="event-topics-subhead"><sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="Subheading" /></p>
                <p class="event-topics"><sc:FieldRenderer ID="frEventHeading" runat="server" FieldName="Heading" /></p>
                <sc:FieldRenderer ID="frbody" runat="server" FieldName="Body Content" />
                <%--<p>Earum fuga quia porro unde libero. laudantium natus quis fugit sed eum distinctio esse fugit sequi corporis molestias. aut dolorum ut voluptatum ipsum in iure minus quae</p>--%>

            </div>
            <!-- end .event-content -->
            <div class="col-5 col offset-1 event-sidebar rs_read_this">
                <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                <div class="recommended-for">
                    <p>Recommended for</p>
                    <span class="children-key">
                        <ul>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>
                </div>
                <!-- END PARTIAL: community/experts_recommended_for -->
                <!-- BEGIN PARTIAL: community/experts_was_this_helpful -->
                <div class="was-this-helpful clearfix" id="count-helpful">

                    <p class="helpful-count"><em>30</em>Found this helpful</p>


                    <h4>Did you find this helpful?</h4>
                    <a class="button yes rs_skip" href="REPLACE">Yes</a>
                    <a class="button gray no rs_skip" href="REPLACE">No</a>
                </div>
                <!-- END PARTIAL: community/experts_was_this_helpful -->
            </div>
            <!-- end .event-sidebar -->
        </div>
    </div>

    <asp:Panel runat="server" ID="pnlVideo" CssClass="row webinar-video" Visible="false">
        <div class="container">
            <!-- BEGIN PARTIAL: video-player -->
            <div class="player-container">
              <div class="player">
                <sc:FieldRenderer ID="frVideoEmbed" runat="server" FieldName="Video Embed" />
              </div>
            </div>
            <!-- END PARTIAL: video-player -->

            <div class="col col-18 offset-3">
              <!-- BEGIN PARTIAL: transcript-control -->
                <div class="transcript-container Video">
                  <div class="read-more mobile-close">
                    <a href="REMOVE">Close Transcript<i class="icon-arrow-up-blue"></i></a>
                  </div>
                  <div class="transcript-wrap clearfix rs_read_this">
                    <div>
                      <h2>Video Transcript</h2>

                      <h3>Dr.Richard Nightengale:</h3>
                      <p>Distinctio quas itaque molestiae doloremque beatae id neque eum voluptatem iure. dolores nihil ullam labore iusto et fugiat. officiis mollitia voluptatem quasi quis omnis in voluptatibus velit. qui a adipisci fugiat suscipit sed quas nulla tempore. ut qui iure ut quasi dolores id aliquam velit minima non. incidunt voluptatem quae et labore libero explicabo blanditiis velit</p>

                      <h3>Parent:</h3>
                      <p>Alias maxime et voluptatibus aut dolore et consequuntur eveniet. voluptatem quo sit ad tenetur vel et aliquid dolores. aliquam sed ipsam repellat laudantium architecto. molestias est eligendi fuga est ea ipsum. officiis voluptatem repudiandae est eos minima aut voluptas dolor molestiae. cum adipisci saepe omnis repellat. dolores quas expedita doloremque et</p>

                      <h3>Dr.Richard Nightengale:</h3>
                      <p>A est velit et fugiat qui ducimus quia autem libero non ducimus. et praesentium enim omnis. temporibus qui consequatur dolor voluptatem repellendus inventore porro sint quasi quam</p>

                      <h3>Parent:</h3>
                      <p>Quam rerum eos recusandae vero veritatis ea aspernatur modi veritatis maxime similique quas amet. harum quaerat quae ratione molestiae ad. necessitatibus voluptatibus enim est explicabo est fugiat debitis ut non dolor eaque sunt. nisi perspiciatis repudiandae veniam. nulla ducimus ullam nulla. exercitationem dignissimos in voluptatibus necessitatibus rem et aperiam hic eius delectus sequi laboriosam qui laboriosam. itaque ad molestias occaecati consequatur veniam vero facilis accusantium sit ut nam est recusandae</p>

                      <h3>Dr.Richard Nightengale:</h3>
                      <p>Sed eius ea optio sit aut ut animi quia minus sed necessitatibus ut. placeat nesciunt nihil beatae laborum ratione. repellendus fugiat perferendis nihil libero repudiandae quibusdam ut distinctio nemo culpa architecto. ipsum explicabo voluptates in sunt nostrum consequatur dolor. rerum commodi deserunt vero deleniti velit ab facilis. earum rerum explicabo et autem maiores</p>

                      <h3>Parent:</h3>
                      <p>Velit reiciendis soluta itaque quaerat vel perferendis ad vitae doloribus nulla officia nostrum. consequatur maxime odit autem voluptas et voluptate ut aliquam. ducimus assumenda adipisci ducimus nam. fuga quam illo corporis porro et inventore totam sequi ut aut pariatur sed. aut et aut totam autem quaerat tempore sint aut nam. doloribus debitis nihil mollitia cupiditate eveniet nesciunt est voluptas autem atque tenetur aspernatur. et occaecati consequuntur et voluptate sint perferendis asperiores</p>
                    </div>
                  </div>
                  <div class="read-more read-more-bottom"></div>
                </div>
                <!-- END PARTIAL: transcript-control -->
            </div>
          </div>

            <div class="webinar-actions clearfix">
                <!-- BEGIN PARTIAL: community/experts_was_this_helpful -->
                <div class="was-this-helpful clearfix" id="Div1">
    

                    <h4>Did you find this helpful?</h4>
                    <a class="button yes rs_skip" href="REPLACE">Yes</a>
                    <a class="button gray no rs_skip" href="REPLACE">No</a>
                </div>
                <!-- END PARTIAL: community/experts_was_this_helpful -->
            </div>
    </asp:Panel>
</div>
