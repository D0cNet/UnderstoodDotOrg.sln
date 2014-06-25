<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation.CreateAccount" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%--<div id="wrapper">--%>


<!-- BEGIN PARTIAL: pagetopic -->
<!-- FIXME: Documentation needed to explain share on/off functionality in page topic module -->

<!-- Determine variables present and change column width to fit the content available -->


<!-- Page Title -->
<div class="container page-topic recommendations with-share">
    <div class="row">
        <div class="col col-14 offset-1">

            <div>
                <h1 class="rs_read_this"><%--Just For You--%>
                    <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                </h1>

                <p class="page-subtitle">
                    <%--Customized advice and interactive tools--%>
                    <sc:FieldRenderer ID="frPageSummary" runat="server" FieldName="Body Content" />
                </p>

            </div>
        </div>
        <div class="col col-9">
            <!-- BEGIN PARTIAL: share-save -->
            <sc:Placeholder ID="Placeholder1" Key="ShareNSave" runat="server" />
            <%--<div class="share-save-container">
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
</div>--%>

            <!-- END PARTIAL: share-save -->
        </div>
    </div>
</div>
<!-- .container -->

<!-- END PARTIAL: pagetopic -->

<div class="container">
    <div class="row">
        <div class="col col-10 offset-1 recommendations-sample">
            <%--<img alt="Sample Journal Screen" src="Presentation/includes/images/sample.journal.screen.jpg" />--%>
            <sc:FieldRenderer ID="frImageContent" runat="server" FieldName="Image Content"/>
        </div>

        <div class="col col-11 recommendations-usage">
            <h3><%--3 ways to use recommendations--%>
                <sc:FieldRenderer ID="frrecommendationHeader" runat="server" FieldName="Recommendation Header" />
            </h3>
            <asp:Repeater ID="rptRecommendationCallouts" runat="server" OnItemDataBound="rptRecommendationCallouts_ItemDataBound">
                <ItemTemplate>
                    <dl>
                        <dt><span class="count"><%--1 --%>
                            <sc:FieldRenderer ID="frCalloutNumber" runat="server" FieldName="Content Title" />
                        </span></dt>
                        <dd><%--Visit Just for You in your Parent Toolkit. We'll match what we show you there to your child's age and issue, and your interests - no more sifting through irrelevant articles.--%>
                            <sc:FieldRenderer ID="frCalloutDescription" runat="server" FieldName="Content Description" />
                        </dd>
                    </dl>
                </ItemTemplate>
            </asp:Repeater>

            <%-- <dl>
        <dt><span class="count">2</span></dt>
        <dd>Look for recommendations while you browse Understood. Selecting recommended tips, tools, events and more connects you quickly to what's most helpful for you, your child and your family.</dd>
      </dl>

      <dl>
        <dt><span class="count">3</span></dt>
        <dd>Update your profile. The more you tell us about your child and interests, the better we can help you find just the right information and advice.</dd>
      </dl>--%>

            <div class="buttons">
                <%--<button class="button gray" >Sign In</button>
                <button class="button sign-up">Sign Up</button>--%>
                <asp:Button ID="btnSignIn" runat="server" Text="Sign In" CssClass="button gray" />
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="button sign-up" />
            </div>
        </div>
    </div>
</div>


<div class="container additional-recommendations">
    <div class="row">
        <div class="col col-11 offset-1">
            <ul class="recommendations-promos">
                <asp:Repeater ID="rptPromoDetails" runat="server" OnItemDataBound="rptPromoDetails_ItemDataBound">
                    <ItemTemplate>
                        <li class="promo">
                            <asp:Panel ID="pnlImageType" runat="server" CssClass="thumb">
                                <%-- <a class="thumb" href="REPLACE">class="thumb video" OR class="thumb" 
                                    <img alt="190x105 Placeholder" src="http://placehold.it/190x105" />
                                    </a>--%>
                                <asp:HyperLink ID="hlPromoMedia" runat="server">
                                    <sc:FieldRenderer ID="frPromoMedia" runat="server" FieldName="Promo Image" />
                                </asp:HyperLink>
                            </asp:Panel>
                            <%--<a href="text" href="REPLACE">Aliquam Non Sapiente Quisquam Ducimus Quaerat
                            </a>--%>
                            <sc:FieldRenderer ID="frPromoTitle" runat="server" FieldName="Page Title" />
                            <span class="children-key">
                                <ul>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <%-- <li class="promo">
                    <a class="thumb" href="REPLACE">
                        <img alt="190x105 Placeholder" src="http://placehold.it/190x105" />
                    </a>

                    <a href="text" href="REPLACE">Aliquam Non Sapiente Quisquam Ducimus Quaerat
                    </a>

                    <span class="children-key">
                        <ul>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>
                </li>

                <li class="promo">
                    <a class="thumb video" href="REPLACE">
                        <img alt="190x105 Placeholder" src="http://placehold.it/190x105" />
                    </a>

                    <div class="promo-content">
                        <a href="text" href="REPLACE">Mollitia Impedit Accusantium Quia Veritatis Rerum
                        </a>

                        <span class="children-key">
                            <ul>
                                <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                            </ul>
                        </span>
                    </div>
                </li> --%>
            </ul>
        </div>
        <div class="col col-12 related-tool-wrapper">
            <a href="REPLACE" class="related-tool parenting-coach">
                <span class="tool-intro">Try a related tool</span>
                <span class="tool-name">Parenting Coach</span>
                <span class="tool-description">Practical tips for everyday challenges</span>
            </a>
        </div>

        <%--<!-- BEGIN PARTIAL: children-key -->
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
        <!-- END PARTIAL: children-key -->--%>
        <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
    </div>
</div>

<!-- BEGIN PARTIAL: footer -->

