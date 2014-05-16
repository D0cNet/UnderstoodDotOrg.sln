<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertDetailPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.ExpertDetailPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- styling for .about-pagetopic can be found in about-partners -->

<div class="container skiplink-feature">
    <!-- BEGIN PARTIAL: about/expert-bio -->
    <div class="expert-bio">

        <div class="row rs_read_this expert-bio-rs-wrapper">
            <div class="col col-5 offset-1">

                <div class="expert-bio-details">
                    <div class="expert-bio-image">
                        <sc:Image ID="scBioImage" runat="server" Field="Expert Image" />
                        <asp:Image runat="server" ID="imgExpertDefault" ImageUrl="http://placehold.it/150x150" Visible="false" />
                    </div>
                    <div class="expert-bio-detail">
                        <p class="hours-intro">
                            <asp:Literal ID="litHours" runat="server"></asp:Literal>
                        </p>
                        <p class="hours">
                            <sc:FieldRenderer ID="frHours" runat="server" FieldName="Online Office Hours" />
                        </p>
                        <sc:Link ID="scFollowTwittLink" runat="server" Field="Follow on Twitter" CssClass="links rs_skip"></sc:Link>
                        <sc:Link ID="scFollowBlogLink" runat="server" CssClass="links rs_skip" Field="Follow my blog"></sc:Link>
                        <sc:Link ID="scBioLink" runat="server" CssClass="links rs_skip" Field="See my bio"></sc:Link>

                    </div>
                </div>
                <!-- .expert-bio-details -->

            </div>
            <!-- .col -->

            <div class="col col-16 offset-1">

                <div class="expert-bio-text">
                    <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />
                </div>
                <!-- .expert-bio-text -->

            </div>
            <!-- .col -->

        </div>
        <!-- .row -->

    </div>
    <!-- .expert-bio -->
    <!-- END PARTIAL: about/expert-bio -->
</div>
<!-- end .container -->

<div class="container skiplink-content" aria-role="main">
    <!-- BEGIN PARTIAL: about/expert-events -->
    <div class="expert-events future">

        <div class="row expert-events-title">

            <div class="col col-18 offset-1">
                <h3 class="rs_read_this"><%--Robert&apos;s Events--%>
                    <asp:Literal runat="server" ID="ltEventListHeader"></asp:Literal>
                </h3>
            </div>
            <div class="col col-3 offset-1 expert-events-see-more">
                <a href="REPLACE" class="see-more">See more</a>
            </div>
            <!-- /.col -->

        </div>
        <!-- /.row /.expert-events-title -->

        <div class="expert-event-container">
            <asp:Repeater runat="server" ID="rptEventDetails" OnItemDataBound="rptEventDetails_ItemDataBound">
                <ItemTemplate>
                    <div class="row expert-event rs_read_this">

                        <div class="col col-6 offset-1">
                            <asp:HyperLink runat="server" ID="hlExpertBio">
                                <sc:Image ID="scExpertImage" runat="server" Field="Expert Image" />
                                <asp:Image runat="server" ID="imgExpertDefault" ImageUrl="http://placehold.it/150x150" Visible="false" />
                                <asp:Panel runat="server" ID="pnlExpertImageLabel" Visible="false" CssClass="image-label">
                                    <asp:Literal runat="server" ID="ltExpertType"></asp:Literal>
                                    <%--Expert--%>
                                </asp:Panel>
                            </asp:HyperLink>
                            <!-- /.expert-event-image -->
                        </div>
                        <!-- /.col -->

                        <div class="col col-3 push-13">
                            <div class="expert-event-type">
                                <h4><asp:Literal runat="server" ID="ltEventType" ></asp:Literal></h4>
                                <p class="time-past"><span><asp:Literal runat="server" ID="ltEventDate" ></asp:Literal></span> <asp:Literal runat="server" ID="ltEventSubDate" ></asp:Literal></p>
                            </div>
                            <!-- /.expert-event-type -->
                        </div>
                        <!-- /.col -->

                        <div class="col col-1 push-9 border-col">
                            <div>&nbsp;</div>
                        </div>

                        <div class="col col-11 offset-1 pull-4">
                            <div class="expert-event-details">
                                <p class="date-future"><asp:Literal runat="server" ID="ltFEventDate"></asp:Literal></p>
                               <%-- <p class="date-past">Tue Aug 23 at 8pm EST</p>--%>
                                <a href="REPLACE" class="event-title"><sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" /></a>
                                <h5><sc:FieldRenderer ID="frHeading" runat="server" FieldName="Heading" /></h5>
                                <p class="topics-covered"><sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="SubHeading" /></p>
                                <div class="links-future">
                                    
                                    <asp:HyperLink runat="server" ID="hlEventLine" >Event Details</asp:HyperLink> 
                                    <%--<a href="REPLACE">RSVP for this event</a>--%>
                                    <sc:FieldRenderer runat="server" ID="frRSVNLink" FieldName="RSVP for Event" />
                                    <sc:FieldRenderer runat="server" ID="frAddToMyCalendar" FieldName="Add to My Calendar" />
                                </div>
                            </div>
                            <!-- /.expert-event-details -->
                        </div>
                        <!-- /.col -->

                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <!-- /.row -->

            <%--<div class="row expert-event rs_read_this">

                <div class="col col-6 offset-1">
                    <div class="expert-event-image">
                        <a href="REPLACE">
                            <img alt="FPO content image" src="http://placehold.it/230x129&amp;text=230x129" /></a>
                    </div>
                    <!-- /.expert-event-image -->
                </div>
                <!-- /.col -->

                <div class="col col-3 push-13">
                    <div class="expert-event-type">
                        <h4>Live Chat</h4>
                        <p class="time-past"><span>8</span> days ago</p>
                    </div>
                    <!-- /.expert-event-type -->
                </div>
                <!-- /.col -->

                <div class="col col-1 push-9 border-col">
                    <div>&nbsp;</div>
                </div>

                <div class="col col-11 offset-1 pull-4">
                    <div class="expert-event-details">
                        <p class="date-future">Tue Aug 23 at 8pm EST</p>
                        <p class="date-past">Tue Aug 23 at 8pm EST</p>
                        <a href="REPLACE" class="event-title">Live Chat with Dr. Janet Miller</a>
                        <p class="topics-covered">Executive Director, Exceptional Children&apos;s Assistance Center</p>
                        <div class="links-future">
                            <a href="REPLACE">Event Details</a>
                            <a href="REPLACE">RSVP for this event</a>
                            <a href="REPLACE">Add to my calendar</a>
                        </div>
                    </div>
                    <!-- /.expert-event-details -->
                </div>
                <!-- /.col -->

            </div>--%>
            <!-- /.row -->

        </div>
        <!-- /.expert-event-container -->

    </div>
    <!-- /.expert-events -->

    <!-- END PARTIAL: about/expert-events -->
</div>
<!-- end .container -->

<div class="container">
    <!-- BEGIN PARTIAL: about/expert-blog-posts -->
    <div class="expert-blog-posts">

        <div class="row expert-blog-posts-title">

            <div class="col col-18 offset-1">
                <h3 class="rs_read_this">Robert&apos;s Blog Posts</h3>
            </div>
            <div class="col col-3 offset-1 expert-events-see-more">
                <a href="REPLACE" class="see-more">See more</a>
            </div>
            <!-- /.col -->

        </div>
        <!-- /.row /.expert-blog-posts-title -->

        <div class="expert-blog-post-container">

            <div class="row expert-blog-post rs_read_this">

                <div class="col col-6 offset-1">
                    <div class="expert-blog-post-image">
                        <a href="REPLACE">
                            <img alt="FPO content image" src="http://placehold.it/230x129&amp;text=230x129" /></a>
                    </div>
                    <!-- /.expert-blog-post-image -->
                </div>
                <!-- /.col -->

                <div class="col col-3 push-13">
                    <div class="expert-blog-post-type">
                        <h4>72</h4>
                        <p class="comments">Comments</p>
                    </div>
                    <!-- /.expert-blog-post-type -->
                </div>
                <!-- /.col -->

                <div class="col col-1 push-9 border-col">
                    <div>&nbsp;</div>
                </div>

                <div class="col col-11 offset-1 pull-4">
                    <div class="expert-blog-post-details">
                        <a href="REPLACE" class="event-title">Helicopter Parent or ADHD Advocate?</a>
                        <p class="post-meta">Posted by <a href="REPLACE" class="author">Robert Cunningham</a> on Jun 26, 2013</p>
                        <p class="excerpt">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi en&hellip; <a href="REPLACE">Read more</a></p>
                        <div class="blog-shapes">
                            <i class="child-a"></i>
                            <i class="child-c"></i>
                        </div>
                    </div>
                    <!-- /.expert-blog-post-details -->
                </div>
                <!-- /.col -->

            </div>
            <!-- /.row -->

            <div class="row expert-blog-post rs_read_this">

                <div class="col col-6 offset-1">
                    <div class="expert-blog-post-image">
                        <a href="REPLACE">
                            <img alt="FPO content image" src="http://placehold.it/230x129&amp;text=230x129" /></a>
                    </div>
                    <!-- /.expert-blog-post-image -->
                </div>
                <!-- /.col -->

                <div class="col col-3 push-13">
                    <div class="expert-blog-post-type">
                        <h4>72</h4>
                        <p class="comments">Comments</p>
                    </div>
                    <!-- /.expert-blog-post-type -->
                </div>
                <!-- /.col -->

                <div class="col col-1 push-9 border-col">
                    <div>&nbsp;</div>
                </div>

                <div class="col col-11 offset-1 pull-4">
                    <div class="expert-blog-post-details">
                        <a href="REPLACE" class="event-title">Helicopter Parent or ADHD Advocate?</a>
                        <p class="post-meta">Posted by <a href="REPLACE" class="author">Robert Cunningham</a> on Jun 26, 2013</p>
                        <p class="excerpt">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi en&hellip; <a href="REPLACE">Read more</a></p>
                        <div class="blog-shapes">
                            <i class="child-b"></i>
                        </div>
                    </div>
                    <!-- /.expert-blog-post-details -->
                </div>
                <!-- /.col -->

            </div>
            <!-- /.row -->

        </div>
        <!-- /.expert-blog-post-container -->

        <div class="row blog-shapes">
            <!-- BEGIN PARTIAL: children-key -->
            <div class="container child-content-indicator ">
                <!-- Key -->
                <div class="row">
                    <div class="col col-23 offset-1">
                        <div class="children-key" aria-hidden="true">
                            <ul>
                                <li><i class="child-a"></i>for Michael</li>
                                <li><i class="child-b"></i>for Elizabeth</li>
                                <li><i class="child-c"></i>for Ethan</li>
                                <li><i class="child-d"></i>for Jeremy</li>
                                <li><i class="child-e"></i>for Franklin</li>
                            </ul>
                        </div>
                        <!-- .children-key -->
                    </div>
                    <!-- .col -->
                </div>
                <!-- .row -->
            </div>
            <!-- .child-content-indicator -->
            <!-- END PARTIAL: children-key -->
        </div>
        <!-- /.row /.shapes -->

    </div>
    <!-- /.expert-blog-posts -->
    <!-- END PARTIAL: about/expert-blog-posts -->
</div>
<!-- end .container -->
