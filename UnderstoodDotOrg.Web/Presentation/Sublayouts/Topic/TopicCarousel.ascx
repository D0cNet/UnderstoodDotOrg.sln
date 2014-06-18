<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicCarousel.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic.TopicCarousel" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Repeater runat="server" ID="rptTopicCarousel" OnItemDataBound="rptTopicCarousel_ItemDataBound">
    <HeaderTemplate>
        <!-- BEGIN MODULE: Topic Carousel -->
        <div class="container carousel-tertiary">
            <div class="row">
                <div class="col col-24">
                    <!-- BEGIN PARTIAL: topic-carousel -->
                    <div id="topic-carousel" class="royalSlider topicCarousel rsDefault">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="rsContent">
            <p class="title"></p>
            <asp:HyperLink runat="server" ID="hlImageLink" >
                <asp:Image ID="imgFeatured" runat="server" />
            </asp:HyperLink>
            <button class="rsTmb">
                <asp:Literal runat="server" ID="litNavigationTitle"/>
            </button>
        </div>
    </ItemTemplate>
    <FooterTemplate>
                    </div>

                    <button class="play-pause pause"><%= UnderstoodDotOrg.Common.DictionaryConstants.PauseLabel %></button>
                    <!-- END PARTIAL: topic-carousel -->
                </div>
            </div>
        </div>
    </FooterTemplate>
</asp:Repeater>