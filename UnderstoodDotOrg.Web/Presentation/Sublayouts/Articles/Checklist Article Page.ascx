<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Checklist Article Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Checklist_Article_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: article-intro-text -->
            <div class="article-intro-text">
                <p>
                    <%--This would be the intro text to the slideshow. It should run about 35 words. Lorem ipsum dolor sit amet, consectetur adipiscing elit vestibulum convallis risus id felis.--%>
                    <sc:FieldRenderer ID="frSummary" runat="server" FieldName="Intro text" />
                </p>
            </div>
            <!-- END PARTIAL: article-intro-text -->
            <!-- BEGIN PARTIAL: article-checklist -->
            <div class="article-checklist">
                <div class="checklist-form">
                    <div class="checklist-questions">
                        <div class="checklist-question-wrapper">
                            <asp:Repeater ID="rptHeaderChkbox" runat="server" OnItemDataBound="rptHeaderChkbox_ItemDataBound">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="checklist-question">
                                        <asp:CheckBox ID="cbHeaderItem" runat="server"></asp:CheckBox>
                                        <sc:FieldRenderer ID="frHeaderItem" runat="server" FieldName="Title" />
                                    </div>
                                    <div class="checkboxes-wrapper">
                                        <asp:Repeater ID="rptTopicChkbox" runat="server" OnItemDataBound="rptTopicChkbox_ItemDataBound">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="checkbox-wrapper">
                                                    <asp:CheckBox ID="cbTopicItem" runat="server"></asp:CheckBox>
                                                    <sc:FieldRenderer runat="server" ID="frTopicItem" FieldName="Topic Title" />
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <%--
      <div class="checklist-question-wrapper">
        <div class="checklist-question">Reading</div>
        <div class="checkboxes-wrapper">
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q1a1">
              <span>Lose place on the line</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q1a2">
              <span>Switch lines</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q1a3">
              <span>Have difficulty making sense of a passage unless you read it several times</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q1a4">
              <span>Slow in finding place again if looking away</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q1a5">
              <span>Add words that are not there</span>
            </label>
          </div>
        </div><!-- .checkboxes-wrapper -->
      </div><!-- .checklist-question -->

      <div class="checklist-question-wrapper">
        <div class="checklist-question">Spelling</div>
        <div class="checkboxes-wrapper">
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q2a1">
              <span>Spell a word different ways in the same piece if work</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q2a2">
              <span>Reverse letters in a word</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q2a3">
              <span>Confuse letters</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q2a4">
              <span>Forget basic spelling rules</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q2a5">
              <span>Add letters to a word</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q2a6">
              <span>Miss out letters in a word</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q2a7">
              <span>Miss out parts of a word</span>
            </label>
          </div>
        </div><!-- .checkboxes-wrapper -->
      </div><!-- .checklist-question -->

      <div class="checklist-question-wrapper">
        <div class="checklist-question">Writing</div>
        <div class="checkboxes-wrapper">
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q3a1">
              <span>Form letters and numbers badly</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q3a2">
              <span>Tight pen grip</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q3a3">
              <span>Hand ache</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q3a4">
              <span>Unable to use and/or understand punctuation marks</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q3a5">
              <span>Forget to cross"t", "i" or cross "i" instead of "t"</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q3a6">
              <span>Leave out capitals</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q3a7">
              <span>Leave out syllables in words</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q3a8">
              <span>Find it difficult to copy notes from a board</span>
            </label>
          </div>
        </div><!-- .checkboxes-wrapper -->
      </div><!-- .checklist-question -->

      <div class="checklist-question-wrapper">
        <div class="checklist-question">Other Indicators</div>
        <div class="checkboxes-wrapper">
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q4a1">
              <span>Confusion between left and right</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q4a2">
              <span>Distorted sense of time</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q4a3">
              <span>Easily distracted and has poor concentration</span>
            </label>
          </div>
          <div class="checkbox-wrapper">
            <label>
              <input type="checkbox" name="q4a4">
              <span>Confusion with mathematical symbols</span>
            </label>
          </div>
        </div><!-- .checkboxes-wrapper -->
      </div><!-- .checklist-question --> --%>

                        <div class="checklist-actions">
                            <div class="save-answers">
                                <button class="submit">Save My Answers</button>
                            </div>
                            <div class="download-pdf">
                                <button class="download">Download as PDF</button>
                            </div>
                            <!--        <div class="button"><input class="checklist-form-save" type="submit" value="Save My Answers"></div>
        <div class="button"><input class="submit-button" type="submit" value="Download as PDF"></div> -->
                        </div>

                    </div>
                    <!-- .checklist-questions -->
                </div>
                <!-- .checklist-form -->
            </div>
            <!-- .article-checklist -->

            <!-- END PARTIAL: article-checklist -->
            <!-- BEGIN PARTIAL: reviewed-by -->
           <p class="reviewed-by">
                <span class="reviewed-by-title">Reviewed&nbsp;by</span> <span class="reviewed-by-author">
                    <%--<a href="REPLACE">Dr. Samantha Frank</a>--%>
                   <asp:HyperLink ID="hlReviewdby" runat="server">
                       <sc:FieldRenderer ID="frReviewedby" runat="server" FieldName="Revierwer Name" />
                    </asp:HyperLink>
                </span><span class="dot"></span><span class="reviewed-by-date">
                    <%--12&nbsp;Dec&nbsp;&apos;13 --%>
                    <sc:Date ID="dtReviewdDate" Field="Reviewed Date" runat="server" Format="dd MMM yy" />
                </span>
            </p>
            <!-- END PARTIAL: reviewed-by -->
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful content">

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

            </div>
            <!-- END PARTIAL: find-helpful -->
        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1">
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
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful sidebar">

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

            </div>
            <!-- END PARTIAL: find-helpful -->
            <!-- BEGIN PARTIAL: keep-reading -->
            <%--<div class="keep-reading">
                <h3>Keep Reading</h3>
                <ul>
                    <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
                    <li><a href="REPLACE">How to Build a Homework Plan</a></li>
                    <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
                </ul>
            </div>--%>
            <sc:Sublayout ID="slKeepReading" runat="server" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
            <!-- END PARTIAL: keep-reading -->
            <!-- BEGIN PARTIAL: comments-summary -->
            <section class="comments-summary">
                <header>
                    <h3>Comments (19)</h3>
                </header>
                <div class="quote-container">
                    <blockquote>
                        <p>Neque quo aut aperiam officia atque error. praesentium nisi provident nihil eveniet perspiciatis consequuntur dicta odit. labore omnis distinctio possimus maxime autem ullam. iste fugiat reprehenderit modi delectus reiciendis eos deserunt expedita sed at cupiditate minima eligendi sed</p>
                        <i class="arrow-quote-bottom"></i>
                    </blockquote>
                    <span><strong>Carrie S</strong> &bull; 30 min ago</span>
                </div>

                <ul>
                    <li><a href="REPLACE">See All Comments</a></li>
                    <li><a href="REPLACE">Add My Comment</a></li>
                </ul>
            </section>
            <!-- END PARTIAL: comments-summary -->
            <!-- BEGIN PARTIAL: sidebar-promos -->
            <div class="sidebar-promos">
                <div class="promo purple-dark">
                    <a href="REPLACE">
                        <span>Get advice</span>
                        <i class="icon-arrow-promo"></i>
                    </a>
                </div>
                <!-- end promo -->

                <div class="promo purple-light">
                    <a href="REPLACE">
                        <span>Find Technology that can Help</span>
                        <i class="icon-arrow-promo"></i>
                    </a>
                </div>
                <!-- end promo -->

                <div class="promo blue">
                    <a href="REPLACE">
                        <span>Navigating Your Child's Healthcare Needs</span>
                        <i class="icon-arrow-promo"></i>
                    </a>
                </div>
                <!-- end promo -->
            </div>
            <!-- end sidebar-promos -->

            <!-- END PARTIAL: sidebar-promos -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
