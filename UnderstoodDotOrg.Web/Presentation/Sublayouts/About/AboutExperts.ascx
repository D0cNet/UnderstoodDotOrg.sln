<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutExperts.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.AboutExperts" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>



<!-- END PARTIAL: pagetopic -->
<!-- styling for .about-pagetopic can be found in about-partners -->

<div class="container flush l-about-experts-intro-carousel">
    <div class="row skiplink-feature">
        <div class="col col-11 offset-1">
            <!-- BEGIN PARTIAL: about/about-experts-introduction -->
            <div class="about-experts-introduction">
                <p>
                    <%--We are proud to have a share of in-depth knowledge and Repellat assumenda quis maxime laudantium illo tempora possimus. libero odit est neque eius alias optio omnis deleniti. voluptatem illo provident voluptatibus et esse vitae velit nulla quo facilis expedita non. ut aut et necessitatibus quis molestiae sunt distinctio. perferendis aut et veniam fuga et aperiam possimus dolorum non reprehenderit occaecati odio adipisci architecto--%>
                    <sc:FieldRenderer ID="frAboutExpertIntroduction" runat="server" FieldName="About Expert Introduction" />
                </p>
            </div>
            <!-- END PARTIAL: about/about-experts-introduction -->
        </div>
        <div class="col col-11 offset-1">
            <!-- BEGIN PARTIAL: about/about-experts-event-carousel -->
            <div class="about-experts-event-carousel">
                <h3>Coming up on Experts Live</h3>

                <div class="event-carousel">
                    <div class="about-expert">

                        <div class="about-expert-data">
                            <div class="event-carousel-image">
                                <img alt="FPO content image" src="http://placehold.it/150x150&amp;text=150x150" />
                                <div class="caption">Expert</div>
                            </div>
                            <div class="event-carousel-details">
                                <p class="date">Tue Aug 23 8pm EST</p>
                                <p class="chat-with">Chat with</p>
                                <h4>Dr. Mangru</h4>
                                <p class="credentials">Director of Speech Pathology</p>
                            </div>
                        </div>

                    </div>
                    <!-- /.about-expert -->

                    <div class="about-expert">

                        <div class="about-expert-data">
                            <div class="event-carousel-image">
                                <img alt="FPO content image" src="http://placehold.it/150x150&amp;text=150x150" />
                                <div class="caption">Expert</div>
                            </div>
                            <div class="event-carousel-details">
                                <p class="date">Tue Aug 23 8pm EST</p>
                                <p class="chat-with">Chat with</p>
                                <h4>2 Dr. Mangru fdskjjfkjfkdds</h4>
                                <p class="credentials">Director of Speech Pathology</p>
                            </div>
                        </div>

                    </div>
                    <!-- /.about-expert -->

                    <div class="about-expert">

                        <div class="about-expert-data">
                            <div class="event-carousel-image">
                                <img alt="FPO content image" src="http://placehold.it/150x150&amp;text=150x150" />
                                <div class="caption">Expert</div>
                            </div>
                            <div class="event-carousel-details">
                                <p class="date">Tue Aug 23 8pm EST</p>
                                <p class="chat-with">Chat with</p>
                                <h4>3 Dr. Mangru</h4>
                                <p class="credentials">Director of Speech Pathology</p>
                            </div>
                        </div>

                    </div>
                    <!-- /.about-expert -->

                </div>
                <!-- /.event-carousel -->

            </div>
            <!-- /.about-experts-event-carousel -->

            <!-- END PARTIAL: about/about-experts-event-carousel -->
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container .flush -->
<div class="container" aria-role="main">
    <!-- BEGIN PARTIAL: about/about-experts-listing -->
    <div class="about-experts-listing">

        <div class="row">
            <div class="col col-22 offset-1">
                <h3><%--Learn more about our Experts--%>
                    <sc:FieldRenderer ID="frExpertsDetailsHeadline" runat="server" FieldName="Experts Details Headline" />
                </h3>
            </div>
            <!-- .col -->
        </div>
        <!-- .row -->

        <asp:Repeater ID="rptSetCss" runat="server" OnItemDataBound="rptSetCss_ItemDataBound">
            <ItemTemplate>
                <asp:Panel ID="PnlRawCss" runat="server" CssClass="row about-expert-row">
                    <asp:Repeater ID="rpt3Expert" runat="server" OnItemDataBound="rpt3Expert_ItemDataBound">
                        <ItemTemplate>
                            <asp:Panel ID="pnlExprtAt" runat="server" CssClass="col col-6 offset-">
                                <div class="about-expert">
                                    <div class="expert-listing-image">
                                        <%--<img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />--%>
                                        <sc:FieldRenderer ID="frExpertImage" runat="server" Field="Expert Image" />
                                    </div>
                                    <div class="expert-listing-details">
                                        <h4><%--Dr. Axxx--%>
                                            <sc:FieldRenderer ID="frFullName" runat="server" FieldName="Full Name" />
                                        </h4>
                                        <p class="credentials">
                                            <%--Executive Director, Exceptional Children's Assistance Center--%>
                                            <sc:FieldRenderer ID="frTitleandInstitution" runat="server" FieldName="Title and Institution" />
                                        </p>
                                        <div class="all-tasks">
                                            <asp:Repeater ID="rptParticipations" runat="server" OnItemDataBound="rptParticipations_ItemDataBound">
                                                <ItemTemplate>
                                                    <p class="tasks">
                                                        <%--Hosts Webinars--%>

                                                        <sc:FieldRenderer ID="frParticipation" runat="server" FieldName="Name" />
                                                    </p>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <%--<p class="tasks">Hosts Webinars</p>
                            <p class="tasks">Blogs</p>--%>
                                        </div>
                                        <asp:HyperLink ID="hlTwitterLink" runat="server" Text="Follow on Twitter"></asp:HyperLink><br />
                                        <asp:HyperLink ID="hlBlogPageLink" runat="server" Text="Follow my blog"></asp:HyperLink><br />
                                        <asp:HyperLink ID="hlBioPageLink" runat="server" Text="See my bio"></asp:HyperLink><br />

                                        <%--<a href="REPLACE" class="links">Follow on Twitter</a>--%>
                                        <%--<a href="REPLACE" class="links">See my bio</a>--%>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:Repeater>

                </asp:Panel>
            </ItemTemplate>

        </asp:Repeater>



        <div class="row about-expert-row  skiplink-content">
            <div class="col col-6 offset-1">
                <div class="about-expert">
                    <div class="expert-listing-image">
                        <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
                    </div>
                    <div class="expert-listing-details">
                        <h4>Dr. Axxx</h4>
                        <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
                        <div class="all-tasks">
                            <p class="tasks">Hosts Webinars</p>
                            <p class="tasks">Blogs</p>
                        </div>
                        <a href="REPLACE" class="links">Follow on Twitter</a>
                        <a href="REPLACE" class="links">See my bio</a>
                    </div>
                </div>
                <!-- .about-expert -->
            </div>
            <!-- .col -->
            <div class="col col-6 offset-2">
                <div class="about-expert">
                    <div class="expert-listing-image">
                        <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
                    </div>
                    <div class="expert-listing-details">
                        <h4>Dr. Bxxx</h4>
                        <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
                        <div class="all-tasks">
                            <p class="tasks">Hosts Webinars</p>
                        </div>
                        <a href="REPLACE" class="links">Follow on Twitter</a>
                        <a href="REPLACE" class="links">Follow my blog</a>
                        <a href="REPLACE" class="links">See my bio</a>
                    </div>
                </div>
                <!-- .about-expert -->
            </div>
            <!-- .col -->
            <div class="col col-6 offset-2">
                <div class="about-expert">
                    <div class="expert-listing-image">
                        <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
                    </div>
                    <div class="expert-listing-details">
                        <h4>Dr. Robert Aunningham</h4>
                        <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
                        <div class="all-tasks">
                            <p class="tasks">Hosts Office Hours &amp; Webinars</p>
                        </div>
                        <a href="REPLACE" class="links">Follow on Twitter</a>
                        <a href="REPLACE" class="links">See my bio</a>
                    </div>
                </div>
                <!-- .about-expert -->
            </div>
            <!-- .col -->
        </div>
        <!-- .row -->
        <div class="row about-expert-row">
            <div class="col col-6 offset-1">
                <div class="about-expert">
                    <div class="expert-listing-image">
                        <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
                    </div>
                    <div class="expert-listing-details">
                        <h4>Dr. Axxx</h4>
                        <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
                        <div class="all-tasks">
                            <p class="tasks">Hosts Webinars</p>
                            <p class="tasks">Blogs</p>
                        </div>
                        <a href="REPLACE" class="links">Follow on Twitter</a>
                        <a href="REPLACE" class="links">See my bio</a>
                    </div>
                </div>
                <!-- .about-expert -->
            </div>
            <!-- .col -->
            <div class="col col-6 offset-2">
                <div class="about-expert">
                    <div class="expert-listing-image">
                        <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
                    </div>
                    <div class="expert-listing-details">
                        <h4>Dr. Bxxx</h4>
                        <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
                        <div class="all-tasks">
                            <p class="tasks">Hosts Webinars</p>
                        </div>
                        <a href="REPLACE" class="links">Follow on Twitter</a>
                        <a href="REPLACE" class="links">Follow my blog</a>
                        <a href="REPLACE" class="links">See my bio</a>
                    </div>
                </div>
                <!-- .about-expert -->
            </div>
            <!-- .col -->
            <div class="col col-6 offset-2">
                <div class="about-expert">
                    <div class="expert-listing-image">
                        <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
                    </div>
                    <div class="expert-listing-details">
                        <h4>Dr. Robert Aunningham</h4>
                        <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
                        <div class="all-tasks">
                            <p class="tasks">Hosts Office Hours &amp; Webinars</p>
                        </div>
                        <a href="REPLACE" class="links">Follow on Twitter</a>
                        <a href="REPLACE" class="links">See my bio</a>
                    </div>
                </div>
               <!-- .about-expert -->
            </div>
            <!-- .col -->
        </div>
        <!-- .row -->
        <div class="row about-expert-row">
            <div class="col col-6 offset-1">
                <div class="about-expert">
                    <div class="expert-listing-image">
                        <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
                    </div>
                    <div class="expert-listing-details">
                        <h4>Dr. Axxx</h4>
                        <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
                        <div class="all-tasks">
                            <p class="tasks">Hosts Webinars</p>
                            <p class="tasks">Blogs</p>
                        </div>
                        <a href="REPLACE" class="links">Follow on Twitter</a>
                        <a href="REPLACE" class="links">See my bio</a>
                    </div>
                </div>
                <!-- .about-expert -->
            </div>
            <!-- .col -->
            <div class="col col-6 offset-2">
                <div class="about-expert">
                    <div class="expert-listing-image">
                        <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
                    </div>
                    <div class="expert-listing-details">
                        <h4>Dr. Bxxx</h4>
                        <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
                        <div class="all-tasks">
                            <p class="tasks">Hosts Webinars</p>
                        </div>
                        <a href="REPLACE" class="links">Follow on Twitter</a>
                        <a href="REPLACE" class="links">Follow my blog</a>
                        <a href="REPLACE" class="links">See my bio</a>
                    </div>
                </div>
                <!-- .about-expert -->
            </div>
            <!-- .col -->
            <div class="col col-6 offset-2">
                <div class="about-expert">
                    <div class="expert-listing-image">
                        <img alt="FPO content image" src="http://placehold.it/230x230&amp;text=230x230" />
                    </div>
                    <div class="expert-listing-details">
                        <h4>Dr. Robert Aunningham</h4>
                        <p class="credentials">Executive Director, Exceptional Children's Assistance Center</p>
                        <div class="all-tasks">
                            <p class="tasks">Hosts Office Hours &amp; Webinars</p>
                        </div>
                        <a href="REPLACE" class="links">Follow on Twitter</a>
                        <a href="REPLACE" class="links">See my bio</a>
                    </div>
                </div>
                <!-- .about-expert -->

            </div>
            <!-- .col -->

        </div>
        <!-- .row -->

    </div>
    <!-- .about-experts-listing -->
    <!-- END PARTIAL: about/about-experts-listing -->
</div>
<!-- end .container -->

<!-- Show More -->
<!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more">
    <div class="row">
        <div class="col col-24">
            <a class="show-more-link " href="#" data-path="about/about-experts-listing" data-container="about-experts-listing" data-item="about-expert" data-count="3">Show More<i class="icon-arrow-down-blue"></i></a>
        </div>
    </div>
</div>
<!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
<!-- .show-more -->

<!-- BEGIN PARTIAL: footer -->

