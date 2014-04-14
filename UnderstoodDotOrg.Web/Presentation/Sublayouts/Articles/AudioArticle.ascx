<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AudioArticle.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.AudioArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article-intro">
    <div class="row">
        <!-- helpful count -->
        <div class="col col-10 article-intro-count multiple">
            <!-- BEGIN PARTIAL: helpful-count -->
            <div class="count-helpful">
                <a href="REPLACE"><span>34</span>Found this helpful</a>
            </div>
            <!-- END PARTIAL: helpful-count -->
            <!-- BEGIN PARTIAL: comments-count -->
            <div class="count-comments">
                <a href="REPLACE"><span>19</span>Comments</a>
            </div>
            <!-- END PARTIAL: comments-count -->
        </div>

        <!-- intro-text -->
        <div class="col col-13 offset-1">
            <!-- BEGIN PARTIAL: article-intro-text -->
            <div class="article-intro-text">
                <%--<p>This would be the intro text to the slideshow. It should run about 35 words. Lorem ipsum dolor sit amet, consectetur adipiscing elit vestibulum convallis risus id felis.</p> --%>
                <sc:FieldRenderer ID="frAudioIntro" runat="server" FieldName="Intro Text" />
            </div>
            <!-- END PARTIAL: article-intro-text -->
        </div>

    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-24">
            <!-- BEGIN PARTIAL: audio-pull-quote -->
            <div class="audio-quote">
                <div class="audio-quote-img">
                    <%--<img class="foo" alt="FPO content image" src="http://placehold.it/290x163&amp;text=290x163" />--%>
                    <sc:Image ID="ImgAudioImage" runat="server" Field="Content Thumbnail" />
                </div>
                <div class="audio-quote-text">
                    <%--<p class="audio-quote-content">"Best quote from the audio file gets shown here dolor sit amet, consectetuer adipiscing elit. Best quote from the audio file gets shown her dolor sit amet, consect etuer adipiscing elit. Best quote from the audio file gets shown her dolor sit amet, consectetuer adipiscing elit."</p>
    <p class="audio-quote-author">-Dr. Torrington, MD</p>--%>
                    <sc:FieldRenderer ID="frAudioQuote" runat="server" FieldName="Quote" />
                </div>
            </div>
            <!-- END PARTIAL: audio-pull-quote -->
            <!-- BEGIN PARTIAL: audio-player -->
            <div id="audio-player-1" class="jp-jplayer"></div>
            <div id="audio-player-interface-1" class="jp-audio">
                <div class="jp-type-single">
                    <div class="jp-gui jp-interface">
                        <ul class="jp-controls">
                            <li><a href="javascript:;" class="jp-play" tabindex="1">play</a></li>
                            <li><a href="javascript:;" class="jp-pause" tabindex="1">pause</a></li>
                            <li><a href="javascript:;" class="jp-stop" tabindex="1">stop</a></li>
                            <li class="jp-mute-li"><a href="javascript:;" class="jp-mute" tabindex="1" title="mute">mute</a></li>
                            <li class="jp-unmute-li"><a href="javascript:;" class="jp-unmute" tabindex="1" title="unmute">unmute</a></li>
                            <li class="jp-volume-max-li"><a href="javascript:;" class="jp-volume-max" tabindex="1" title="max volume">max volume</a></li>
                        </ul>
                        <div class="jp-progress">
                            <div class="jp-seek-bar">
                                <div class="jp-play-bar"></div>
                            </div>
                        </div>
                        <div class="jp-volume-bar">
                            <div class="jp-volume-bar-value"></div>
                        </div>
                        <div class="jp-time-holder">
                            <div class="jp-current-time"></div>
                            <div class="jp-duration"></div>
                            <ul class="jp-toggles">
                                <li><a href="javascript:;" class="jp-repeat" tabindex="1" title="repeat">repeat</a></li>
                                <li><a href="javascript:;" class="jp-repeat-off" tabindex="1" title="repeat off">repeat off</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="jp-title">
                        <ul>
                            <%-- <li>Bubble</li>--%>
                        </ul>
                    </div>
                    <div class="jp-no-solution">
                        <span>Update Required</span>
                        To play the media you will need to either update your browser to a recent version or update your <a href="http://get.adobe.com/flashplayer/" target="_blank">Flash plugin</a>.
   
                    </div>
                </div>
            </div>
            <!-- END PARTIAL: audio-player -->
        </div>
    </div>
</div>
<!-- .container -->

<div class="container">
    <div class="row">
        <div class="col col-24">
            <!-- BEGIN PARTIAL: transcript-control -->
            <div class="transcript-container Audio">
                <div class="transcript-wrap">
                    <div>
                        <sc:FieldRenderer runat="server" ID="frAudioTranscript" FieldName="Transcript" />
                        <%--<h2>Audio Transcript</h2>

      <h3>Dr.Richard Nightengale:</h3>
      <p>Esse est cum nobis unde officia debitis consequatur. et amet sequi facere sequi voluptatem deserunt quae et corrupti sunt voluptates sit quis maxime. porro facilis quis magnam impedit accusamus ad enim velit</p>

      <h3>Parent:</h3>
      <p>Non aut quaerat velit et illo ut expedita placeat. odio consequatur ea architecto itaque consectetur voluptate temporibus et. earum pariatur qui ratione ullam officia esse sit ea ea aut quidem voluptatum aut rerum. nemo voluptatem perferendis iusto rerum ullam ut hic voluptas porro magnam assumenda. id veniam iste est asperiores eligendi. doloremque magni occaecati alias consequatur totam quidem est ullam facere cupiditate eum nam</p>

      <h3>Dr.Richard Nightengale:</h3>
      <p>Quisquam expedita et quidem ratione ex vel. accusamus facilis et voluptatem qui et voluptatem rerum et commodi ipsam perferendis cum. laudantium veniam praesentium ratione architecto distinctio et. voluptatibus qui officiis atque ea reprehenderit. et quam dolor repellendus et</p>

      <h3>Parent:</h3>
      <p>Et amet architecto quae officia libero ullam fugit rerum pariatur vel placeat voluptatem. eum autem eos impedit est quia molestiae iste laudantium molestiae rem. voluptatem sunt repellat unde. est ipsam sequi et sed corrupti aut occaecati qui sit</p>

      <h3>Dr.Richard Nightengale:</h3>
      <p>Labore aspernatur aut molestias possimus id nihil assumenda accusamus ea non repellat velit. autem autem molestiae officiis est voluptatum consequatur quae qui natus repellendus iste sit quidem quo. vel neque pariatur voluptatum itaque repellat ab atque iusto delectus qui repudiandae magnam deserunt debitis. qui est rerum aliquid sed sint ipsa culpa</p>

      <h3>Parent:</h3>
      <p>Et harum aut qui. vero accusantium possimus esse in cum ipsa sequi a fugit distinctio ad eveniet illum autem. harum impedit autem rem. ex consequatur aut error sed ducimus delectus cum corporis aut quis placeat qui. in et aut quidem minus perspiciatis enim. numquam cum consequuntur facere soluta</p>--%>
                    </div>
                </div>
                <div class="read-more"></div>
            </div>
            <!-- END PARTIAL: transcript-control -->
        </div>
    </div>
</div>

<div class="container">
    <div class="row">
        <div class="col col-15">
            <!-- BEGIN PARTIAL: reviewed-by -->
            <p class="reviewed-by">
                <span class="reviewed-by-title">Reviewed&nbsp;by</span> <span class="reviewed-by-author">
                    <%--<a href="REPLACE">Dr. Samantha Frank</a>--%>
                    <sc:Link ID="lnkReviewedBy" runat="server" Field="Revierwer Name">
                    </sc:Link>
                    <asp:HyperLink ID="HyplnkReviewedBy" runat="server"></asp:HyperLink>
                </span><span class="dot"></span><span class="reviewed-by-date">
                    <%--12&nbsp;Dec&nbsp;&apos;13 --%>
                    <sc:Date ID="dtReviewdDate" Field="Reviewed Date" runat="server" Format="dd MMM yy" />
                </span>
            </p>
            <!-- END PARTIAL: reviewed-by -->
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful persist">
                <hr>
                <h4>Did you find this helpful?</h4>
                <ul>
                    <li>
                        <button class="helpful-yes">Yes</button>
                    </li>
                    <li>
                        <button class="helpful-no">No</button>
                    </li>
                </ul>
                <div class="clearfix"></div>
                <hr>
            </div>
            <!-- END PARTIAL: find-helpful -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

 
<%--<div class="container more-carousel">
    <div class="row">
        <div class="col col-24 offset-1">
           
            <h2>More Like this:</h2> 
            <!-- BEGIN PARTIAL: more-carousel -->
            
           <asp:Repeater ID="rptMoreArticle" runat="server" OnItemDataBound="rptMoreArticle_ItemDataBound">
                <HeaderTemplate>
                    <div id="partners-slides-container" class="arrows-gray">
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <ul>
                        <asp:HyperLink runat="server" ID="hlLinkTitle">
                            <sc:FieldRenderer ID="frLinkTitle" runat="server" FieldName="Page Title" />
                            <sc:FieldRenderer runat="server" ID="frLinkImage" Field="Content Thumbnail" />
                        </asp:HyperLink>
                    </ul>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                    </div>
                </FooterTemplate>
            </asp:Repeater> 
            <!--<div id="more-carousel-slides-container">
                <ul>
                    <li>
                        <a href="REPLACE">
                            <p>Understand Your Child's Problem: Start a Log</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                    <li>
                        <a href="REPLACE">
                            <p>Does my Child Have Dyslexia? Take the Quiz</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                    <li>
                        <a href="REPLACE">
                            <p>Get Better Recommendations: Create a Profile</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                    <li>
                        <a href="REPLACE">
                            <p>Understand Your Child's Problem: Start a Log</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                    <li>
                        <a href="REPLACE">
                            <p>Does my Child Have Dyslexia? Take the Quiz</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                    <li>
                        <a href="REPLACE">
                            <p>Get Better Recommendations: Create a Profile</p>
                            <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
                        </a>
                    </li>
                </ul>
            </div> -->
            <!-- #more-carousel-slides-container-->

            <!-- END PARTIAL: more-carousel -->
        </div>
    </div>
</div> --%>

<!-- comments -->
<%--<div class="container comments">
    <div class="row">
        <!-- comments col -->
        <div class="col col-23 offset-1">
            <!-- BEGIN PARTIAL: comment-list -->
            <section class="comment-list">

                <header>
                    <span class="comment-count">Comments (19)</span>
                    <select name="comment-sort-option" class="comment-sort">
                        <option value="">Sort by</option>
                        <option>A-Z</option>
                        <option>Z-A</option>
                    </select>
                </header>

                <div class="comment-list-wrapper">

                    <div class="comment-wrapper">
                        <div class="comment-header">
                            <span class="comment-avatar">
                                <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                            </span>
                            <span class="comment-info">
                                <span class="comment-username">Patricia S</span>
                                <span class="comment-date">3 days ago</span>
                            </span>
                            <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                        </div>
                        <div class="comment-body">
                            <p>
                                Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                            </p>
                        </div>
                        <div class="comment-actions">
                            <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                            <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                            <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                        </div>
                    </div>
                    <!-- .comment-wrapper -->

                    <div class="comment-wrapper">
                        <div class="comment-header">
                            <span class="comment-avatar">
                                <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                            </span>
                            <span class="comment-info">
                                <span class="comment-username">Patricia S</span>
                                <span class="comment-date">3 days ago</span>
                            </span>
                            <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                        </div>
                        <div class="comment-body">
                            <p>
                                Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                            </p>
                        </div>
                        <div class="comment-actions">
                            <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                            <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                            <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                        </div>
                    </div>
                    <!-- .comment-wrapper -->

                    <div class="comment-wrapper">
                        <div class="comment-header">
                            <span class="comment-avatar">
                                <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                            </span>
                            <span class="comment-info">
                                <span class="comment-username">Patricia S</span>
                                <span class="comment-date">3 days ago</span>
                            </span>
                            <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                        </div>
                        <div class="comment-body">
                            <p>
                                Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                            </p>
                        </div>
                        <div class="comment-actions">
                            <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                            <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                            <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                        </div>
                    </div>
                    <!-- .comment-wrapper -->

                    <div class="comment-wrapper">
                        <div class="comment-header">
                            <span class="comment-avatar">
                                <img alt="60x60 Placeholder" src="http://placehold.it/60x60" />
                            </span>
                            <span class="comment-info">
                                <span class="comment-username">Patricia S</span>
                                <span class="comment-date">3 days ago</span>
                            </span>
                            <a class="comment-like"><i class="icon-comment-like"></i>3</a>
                        </div>
                        <div class="comment-body">
                            <p>
                                Aenean commodo urna lectus, eget semper lacus aliquet fermentum. Donec nisl velit, iaculis at vulputate ut, condimentum sed massa. Nunc gravida arcu ac enim auctor varius. Fusce pellentesque, metus eget eleifend convallis, justo tellus vulputate sapien, et porta felis neque eu libero. Ut non justo ac tellus laoreet pulvinar id non sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla et mi at enim dapibus suscipit vel sit amet augue.
       
                            </p>
                        </div>
                        <div class="comment-actions">
                            <a class="comment-reply" href="REPLACE"><i class="icon-comment-reply"></i>Reply</a>
                            <a class="comment-like" href="REPLACE"><i class="icon-comment-like"></i>This Helped</a>
                            <a class="comment-flag" href="REPLACE"><i class="icon-comment-flag"></i>Report as inappropriate</a>
                        </div>
                    </div>
                    <!-- .comment-wrapper -->
                </div>
                <!-- .comment-list-wrapper -->

                <div class="comment-footer">
                    <div class="comment-more-wrapper">
                        <a class="comment-more" href="REPLACE">More Comments<i class="icon-comment-more"></i></a>
                    </div>
                    <div class="comment-form">
                        <textarea name="comment-form-reply" class="comment-form-reply" placeholder="Add your comment..."></textarea>
                        <input type="submit" value="Submit" class="comment-form-submit submit-button" />
                        <div class="clearfix"></div>
                    </div>
                </div>

            </section>
            <!-- .comment-list -->

            <!-- END PARTIAL: comment-list -->
        </div>
    </div>
    <!-- .row -->
</div>--%>
<!-- .container -->

