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
                            <div class="rsTmb">
                                <asp:Literal runat="server" ID="ltNavigationTitle" ></asp:Literal>
                               <%-- <sc:Text runat="server" Field="Navigation Title" Id="scNavigationTitle"></sc:Text> --%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
               
            </div>
            <!-- END PARTIAL: topic-carousel -->

        </div>
    </div>
</div>
<!-- .container.carousel-tertiary -->

<!-- END MODULE: Topic Carousel -->
