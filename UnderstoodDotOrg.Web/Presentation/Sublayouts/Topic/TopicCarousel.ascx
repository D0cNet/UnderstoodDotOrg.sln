<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicCarousel.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic.TopicCarousel" %>

<!-- BEGIN MODULE: Topic Carousel -->
<div class="container carousel-tertiary">
    <div class="row">
        <div class="col col-24">

            <!-- BEGIN PARTIAL: topic-carousel -->
            <div id="topic-carousel" class="royalSlider topicCarousel rsDefault">
                <asp:Repeater runat="server" ID="rptTopicCarousel" OnItemDataBound="rptTopicCarousel_ItemDataBound">
                    <ItemTemplate>
                        <div class="rsContent">
                            <p class="title"></p>
                            <asp:HyperLink runat="server" ID="hlNavigationtitle" >
                                <sc:image id="scThumbnailImage" runat="server" field="Featured Image" />
                                <asp:Image runat="server" ID="defaultImage" Visible="false" ImageUrl="http://placehold.it/630x354" />
                            </asp:HyperLink>
                            <%--<a href="REPLACE">
                                <img alt="630x354 Placeholder" class="rsImg" src="http://placehold.it/630x354" /></a>--%>
                            <div class="rsTmb">
                                <sc:Text runat="server" Field="Navigation Title" Id="scNavigationTitle"></sc:Text> 
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
               
                <%--<div class="rsContent">
    <p class="title"></p>
    <a href="REPLACE">
    <img alt="630x354 Placeholder" class="rsImg" src="http://placehold.it/630x354" /></a>
    <div class="rsTmb">Tips: Trouble Following Directions</div>
  </div>
  <div class="rsContent">
    <p class="title"></p>
    <a href="REPLACE">
    <img alt="630x354 Placeholder" class="rsImg" src="http://placehold.it/630x354" /></a>
    <div class="rsTmb">Expert Webinar: Time- Blindedness and ADHD</div>
  </div>
  <div class="rsContent">
    <p class="title"></p>
    <a href="REPLACE">
    <img alt="630x354 Placeholder" class="rsImg" src="http://placehold.it/630x354" /></a>
    <div class="rsTmb">Grab this summer-friendly book list</div>
  </div>--%>
            </div>
            <!-- END PARTIAL: topic-carousel -->

        </div>
    </div>
</div>
<!-- .container.carousel-tertiary -->

<!-- END MODULE: Topic Carousel -->
