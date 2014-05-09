<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Take Action Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy.TakeActionPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container page-topic advocacy-pagetopic advocacy-article-rs-wrapper">
  <div class="row" >
    <div class="col col-14 offset-1">
      
        <a href="REPLACE" class="back-to-previous"><i class="icon-arrow-left-blue"></i>Back to Action Center</a>
      
      <div>
        <h1 class="rs_read_this"><%--Multi-Tier System of Supports/ Response to Intervention--%>
            <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
        </h1>
        
          <p class="page-subtitle hidden">Lorem ipsum dolor sit amet, consectetur adipiscing elit nulla egestas</p>
        
      </div>
    </div>

    
    <div class="col col-8 partner-image-column">
      <span class="powered-by">Powered by</span>
      <%--<a href="REPLACE" class="partner-image">
        <img src=http://placehold.it/210x55>
      </a>--%>
        <asp:HyperLink ID="hlPartnerLogo" runat="server">
            <sc:FieldRenderer ID="frPartnerLogo"  runat="server" FieldName="Logo" />
        </asp:HyperLink>
      <%--<a href="REPLACE" class="partner-text">
        National Center for Learning Disabilities
      </a> --%>
      <div class="share-save-pagetopic"></div>
    </div>
    

    <sc:Placeholder ID="Placeholder1" Key="ShareNSave" runat="server" />
 <%--<div class="col col-9">
      <!-- BEGIN PARTIAL: share-save -->
<div class="share-save-container">
  <div class="share-save-social-icon">
  	<div class="toggle">
	    <a href="REPLACE" class="socicon icon-facebook">Facebook</a><br />
	    <a href="REPLACE" class="socicon icon-twitter">Twitter</a><br />
	    <a href="REPLACE" class="socicon icon-googleplus">Google&#43;</a><br />
	    <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
	</div>
  </div>
  <div class="share-save-icon">
    <h3>Share &amp; Save</h3>
    <!-- leave no white space for layout consistency -->
    <a href="REPLACE" class="icon icon-share">Share</a><span class="tools"><a href="REPLACE" class="icon icon-email">Email</a><a href="REPLACE" class="icon icon-save">Save</a><a href="REPLACE" class="icon icon-print">Print</a><a href="REPLACE" class="icon icon-remind">Remind</a><a href="REPLACE" class="icon icon-rss">RSS</a></span>
  </div>
</div>

<!-- END PARTIAL: share-save -->
    </div> --%>
    

  </div>
</div><!-- .container -->

<!-- END PARTIAL: pagetopic -->

<div class="container l-take-action">
    <div class="row">
        <div class="col col-17 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: advocacy/take-action-today -->
            <div class="take-action">
                <h2><%--Take Action Today--%>
                    <sc:FieldRenderer ID="frCampaignSectionHeadline" runat="server" FieldName="Campaign Section Headline" />
                </h2>
                <div class="take-action-items">

                    <asp:Repeater ID="rptCampaigns" runat="server" OnItemDataBound="rptCampaigns_ItemDataBound">
                        <ItemTemplate>
                            <div class="action-item">
                                <div class="action-header">
                                   <%--  <a href="REPLACE" class="action-image">
                                       <img alt="290x163 Placeholder" src="http://placehold.it/290x163" />
                                    </a>--%>
                                    <asp:HyperLink ID="hlCampaignImage" runat="server">
                                         <sc:FieldRenderer ID="frCampaignImage" runat="server" FieldName="Image" />
                                    </asp:HyperLink>
                                    <h3 class="action-title">
                                        <%--<a href="REPLACE">Tell Congress to Stop Cutting Education</a>--%>
                                        <asp:HyperLink ID="hlCampaignTitle" runat="server">
                                            <sc:FieldRenderer ID="frCampaignTitle" runat="server" FieldName="Page Title" />
                                        </asp:HyperLink>
                                    </h3>
                                    <p class="action-description">
                                        <%--delectus esse minus sed et eum doloremque autem laboriosam explicabo est voluptas aut voluptates laboriosam autem ea ipsa perferendis aspernatur--%>
                                        <sc:FieldRenderer ID="frCampaignBodyContent" runat="server" FieldName="Body Content" />
                                    </p>
                                </div>
                                <div class="action-button-wrap">
                                    <%--<button type="button" class="button action-button">Act Now</button>--%>
                                    <asp:Button CssClass="button action-button" runat="server" ID="btnActNow" OnClick="btnActNow_Click" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <%--<div class="action-item">
      <div class="action-header">
        <a href="REPLACE" class="action-image"><img alt="290x163 Placeholder" src="http://placehold.it/290x163" /></a>
        <h3 class="action-title">
          <a href="REPLACE">Expand Job Training for People with LD</a>
        </h3>
        <p class="action-description">iste soluta a autem eum sint est deserunt odit minima doloribus incidunt non et quidem et labore maxime architecto voluptatibus</p>
      </div>
      <div class="action-button-wrap">
        <button type="button" class="button action-button">Act Now</button>
      </div>
    </div>

    <div class="action-item">
      <div class="action-header">
        <a href="REPLACE" class="action-image"><img alt="290x163 Placeholder" src="http://placehold.it/290x163" /></a>
        <h3 class="action-title">
          <a href="REPLACE">Tell Congress to Invest in Childhood Literacy</a>
        </h3>
        <p class="action-description">quis porro blanditiis distinctio nam consequatur ut distinctio et non vel est fuga sed ad eligendi libero et pariatur molestias</p>
      </div>
      <div class="action-button-wrap">
        <button type="button" class="button action-button">Act Now</button>
      </div>
    </div> --%>
                </div>
            </div>
            <!-- take-action-today -->
            <!-- END PARTIAL: advocacy/take-action-today -->
            <!-- UN-1601 -->
            <!-- UN-2751 -->
        </div>
        <div class="col col-7 skiplink-sidebar take-action-large">
            <div class="take-action-module">
                <div class="l-take-action-share">
                    <!-- BEGIN PARTIAL: share-save -->
                    <div class="share-save-container">
                        <div class="share-save-social-icon">
                            <div class="toggle">
                                <a href="REPLACE" class="socicon icon-facebook">Facebook</a><br />
                                <a href="REPLACE" class="socicon icon-twitter">Twitter</a><br />
                                <a href="REPLACE" class="socicon icon-googleplus">Google&#43;</a><br />
                                <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
                            </div>
                        </div>
                        <div class="share-save-icon">
                            <h3>Share &amp; Save</h3>
                            <!-- leave no white space for layout consistency -->
                            <a href="REPLACE" class="icon icon-share">Share</a><span class="tools"><a href="REPLACE" class="icon icon-email">Email</a><a href="REPLACE" class="icon icon-save">Save</a><a href="REPLACE" class="icon icon-print">Print</a><a href="REPLACE" class="icon icon-remind">Remind</a><a href="REPLACE" class="icon icon-rss">RSS</a></span>
                        </div>
                    </div>

                    <!-- END PARTIAL: share-save -->
                </div>
                <div class="l-take-action-signup">
                    <!-- BEGIN PARTIAL: advocacy/take-action-signup -->
                    <div class="take-action-signup">
                        <h4>Signup for Action Alerts!</h4>
                        <fieldset>
                            <label for="take-action-email" class="visuallyhidden"></label>
                            <input type="text" placeholder="Enter email address" name="signup-newsletter-email" id="take-action-email" class="take-action-input">
                            <input id="take-action-email-button" class="button" type="submit" value="Signup">
                        </fieldset>
                    </div>
                    <!-- .donate -->
                    <!-- END PARTIAL: advocacy/take-action-signup -->
                </div>
                <div class="l-take-action-promo">
                    <!-- BEGIN PARTIAL: advocacy/take-action-promo -->
                    <div class="take-action-promo">
                        <%--<img alt="270x280 Placeholder" src="http://placehold.it/270x280" />--%>
                        <asp:HyperLink ID="hlPromo" runat="server">
                            <sc:FieldRenderer ID="frPromoImage" runat="server" FieldName="Promo Image" />
                        </asp:HyperLink>
                    </div>
                    <!-- END PARTIAL: advocacy/take-action-promo -->
                </div>
            </div>
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container l-on-the-issues">
    <div class="row">
        <div class="col col-24 skiplink-feature">
            <!-- BEGIN PARTIAL: advocacy/on-the-issues -->
            <div class="container issues-intro">
                <div class="row">
                    <div class="col col-24">
                        <h2><%--See where NCLD stands on the issues--%>
                            <sc:FieldRenderer ID="frFeaturedsectionHeadline" FieldName="Featured section Headline" runat="server" />
                        </h2>
                    </div>
                </div>
            </div>

            <div class="container issues-grid">

                <div class="row">
                    <asp:Repeater ID="rptFeaturedArticles" runat="server" OnItemDataBound="rptFeaturedArticles_ItemDataBound">
                        <ItemTemplate>
                            <div class="col col-11 offset-1 issues-column">
                                <div class="issues-item clearfix">
                                    <div class="issues-image">
                                      <asp:HyperLink ID="hlArticleImage" runat="server">
                                          <sc:FieldRenderer ID="frArticleImage" runat="server" FieldName="Content Thumbnail" />
                                      </asp:HyperLink>
                                     <%-- <a href="REPLACE">
                                            <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>--%>
                                    </div>
                                    <div class="issues-title">
                                        <h3><%--<a href="REPLACE">Sed Quia Dolorum Id Cumque</a>--%>
                                            <asp:HyperLink ID="hlArticleTitle" runat="server">
                                                <sc:FieldRenderer ID="frArticleTitle" runat="server" FieldName="Page Title" />
                                            </asp:HyperLink>
                                        </h3>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%-- <div class="col col-11 offset-1 issues-column">
                        <div class="issues-item clearfix">
                            <div class="issues-image">
                                <a href="REPLACE">
                                    <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                            </div>
                            <div class="issues-title">
                                <h3><a href="REPLACE">Sed Quia Dolorum Id Cumque</a></h3>
                            </div>
                        </div>
                    </div>
                    <div class="col col-11 offset-1 issues-column">
                        <div class="issues-item clearfix">
                            <div class="issues-image">
                                <a href="REPLACE">
                                    <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                            </div>
                            <div class="issues-title">
                                <h3><a href="REPLACE">Accusamus Iste Sint Perspiciatis Ex</a></h3>
                            </div>
                        </div>
                    </div>
                    <div class="col col-11 offset-1 issues-column">
                        <div class="issues-item clearfix">
                            <div class="issues-image">
                                <a href="REPLACE">
                                    <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                            </div>
                            <div class="issues-title">
                                <h3><a href="REPLACE">Deserunt Eligendi Sint Quis Sed</a></h3>
                            </div>
                        </div>
                    </div>
                    <div class="col col-11 offset-1 issues-column">
                        <div class="issues-item clearfix">
                            <div class="issues-image">
                                <a href="REPLACE">
                                    <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                            </div>
                            <div class="issues-title">
                                <h3><a href="REPLACE">Est Et Exercitationem Tempore Eos</a></h3>
                            </div>
                        </div>
                    </div>
                    <div class="col col-11 offset-1 issues-column">
                        <div class="issues-item clearfix">
                            <div class="issues-image">
                                <a href="REPLACE">
                                    <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                            </div>
                            <div class="issues-title">
                                <h3><a href="REPLACE">Occaecati Officia Et Corporis Nam</a></h3>
                            </div>
                        </div>
                    </div>
                    <div class="col col-11 offset-1 issues-column">
                        <div class="issues-item clearfix">
                            <div class="issues-image">
                                <a href="REPLACE">
                                    <img alt="190x107 Placeholder" src="http://placehold.it/190x107" /></a>
                            </div>
                            <div class="issues-title">
                                <h3><a href="REPLACE">Aliquam Enim Deleniti Quia Sunt</a></h3>
                            </div>
                        </div>
                    </div> --%>
                </div>

            </div>
            <!-- END PARTIAL: advocacy/on-the-issues -->
        </div>
        <div class="col col-7 take-action-small-after">
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container">
    <div class="row">
        <div class="col col-24 take-action-small">
            <!-- Insert Small item in here-->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<%--<div class="container more-carousel more-carousel-no-border-bottom">
    <div class="row">
        <div class="col col-24">
            <h2>More Like this:</h2>
            <!-- BEGIN PARTIAL: more-carousel -->
            <div id="featured-slides-container" class="arrows-gray">
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
            </div>
            <!-- #more-carousel-slides-container-->

            <!-- END PARTIAL: more-carousel -->
        </div>
    </div>
</div> --%>


<!-- BEGIN PARTIAL: footer -->


