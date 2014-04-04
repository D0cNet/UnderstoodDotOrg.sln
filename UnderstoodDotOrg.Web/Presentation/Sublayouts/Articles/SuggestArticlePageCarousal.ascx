<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuggestArticlePageCarousal.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.SuggestArticlePageCarousal" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container more-carousel">
    <div class="row">
        <div class="col col-23">
            <h2><%--More Like this:--%>
                <sc:FieldRenderer ID="frRelatedLinkTitle" runat="server" FieldName="Related Link Header Title"/>
            </h2>
            <!-- BEGIN PARTIAL: more-carousel -->
            <div id="more-carousel-slides-container">
                <asp:Repeater ID="rptMoreArticle" runat="server" OnItemDataBound="rptMoreArticle_ItemDataBound">
                    <HeaderTemplate>
                        <div id="partners-slides-container" class="arrows-gray">
                            <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hlLink">
                            <sc:FieldRenderer ID="frLinkTitle" runat="server" FieldName="Page Title" />
                            <sc:FieldRenderer runat="server" ID="frLinkImage" Field="Content Thumbnail" />
                        </asp:HyperLink>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </div>
                    </FooterTemplate>
                </asp:Repeater>
                <!--<ul>
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
  </ul> -->
            </div>
            <!-- #more-carousel-slides-container-->

            <!-- END PARTIAL: more-carousel -->
        </div>
    </div>
</div>
