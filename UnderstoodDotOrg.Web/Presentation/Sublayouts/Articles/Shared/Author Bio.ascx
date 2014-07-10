<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Author Bio.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Author_Bio" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container skiplink-feature">
    <!-- BEGIN PARTIAL: about/expert-bio -->
    <div class="expert-bio">

        <div class="row rs_read_this expert-bio-rs-wrapper">
            <div class="col col-5 offset-1">

                <div class="expert-bio-details">
                    <div class="expert-bio-image">
                        <asp:Image ID="imgExpert" runat="server" />
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

<div class="container">
    <!-- BEGIN PARTIAL: about/expert-blog-posts -->
    <div class="expert-blog-posts">

        <div class="row expert-blog-posts-title">

            <div class="col col-18 offset-1">
                <h3 class="rs_read_this"><sc:FieldRenderer ID="frExpertBlogsHeading" runat="server" FieldName="Expert Blogs Heading" /></h3>
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
