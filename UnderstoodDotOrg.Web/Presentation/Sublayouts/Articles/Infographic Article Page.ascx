<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Infographic Article Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Infographic_Article_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>



<sc:Sublayout ID="Sublayout1" Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulCountOnly.ascx" runat="server"></sc:Sublayout>

<div class="container article">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <div class="article-copy">
                <sc:FieldRenderer ID="frBodyContent" runat="server" FieldName="Body Content" />
            </div>
            <div class="infographic">
                <%-- <img src="http://placehold.it/100x1000" width="100%" /> --%>
                <sc:FieldRenderer ID="frInfographicImage" runat="server" FieldName="Image" />
                <!-- BEGIN PARTIAL: infographic-zoom -->
                <div class="infographic-zoom">
                    <%--generate embed code, have click-to-copy support--%>
                    <a href="REPLACE" class="infographic-zoom-icon infographic-zoom-icon-embed" data-toggle="modal" data-target="#embed-overlay"><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_EmbedText %></a>
                    <%--open download stream--%>
                    <a href="/Handlers/DownloadFile.ashx?id=<%= Sitecore.Context.Item.ID.ToString() %>" class="infographic-zoom-icon infographic-zoom-icon-download"><%= UnderstoodDotOrg.Common.DictionaryConstants.DownloadButtonText %></a>
                    <%--<asp:Button runat="server" ID="uxButtonDownload" CssClass="infographic-zoom-icon infographic-zoom-icon-download" Text="Download" OnClick="uxButtonDownload_Click" />--%>
                    <%--zoom in on infographic within viewport--%>
                    <a href="REPLACE" class="infographic-zoom-icon infographic-zoom-icon-zoom-in"><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_ZoomInText %></a>
                    <%--zoom out on infographic within viewport--%>
                    <a href="REPLACE" class="infographic-zoom-icon infographic-zoom-icon-zoom-out"><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_ZoomOutText %></a>
                </div>
                <style>
                    .infographic img {
                        width: 100%;
                        height: auto;
                    }
                </style>
                <!-- end infographic-zoom -->

                    <!-- BEGIN PARTIAL: embed-overlay -->
                    <!-- Embed Overlay Modal -->
                    <div class="modal fade" id="embed-overlay" tabindex="-1" role="dialog" aria-labelledby="embed-overlay-modal" aria-hidden="true">
                      <div class="modal-dialog">
                        <div class="modal-content">
                          <div class="modal-body embed-overlay">
                            <i class="close-overlay" data-dismiss="modal"><%= UnderstoodDotOrg.Common.DictionaryConstants.CloseText %></i>
                            <h3><sc:FieldRenderer ID="frInfoEmebedTag" FieldName="Infographic Embed Tag Text" runat="server"/></h3>
                            <%--<textarea name="" placeholder="Enter your suggestion&hellip;">
                                <iframe width="560" height="315" src="//www.youtube.com/embed/Z1BwhYKTv3c" frameborder="0" allowfullscreen></iframe>
                            </textarea>--%>
                              <asp:TextBox runat="server" ID="uxModalEmbed" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                            <div class="copy-button-container">
                              <a href="REPLACE" class="button submit-button copy"><%= UnderstoodDotOrg.Common.DictionaryConstants.CopyText %></a> <%--TODO: implement click-to-copy--%>
                            </div>
                              <div id="copyAlert" class="alert success fade hidden" data-alert="alert"><sc:FieldRenderer ID="frCodeEmbed" runat="server" FieldName="Embed Code Text"/></div>
                          </div>
                        </div><!-- /.modal-content -->
                      </div><!-- /.modal-dialog -->
                    </div><!-- /.modal -->
                    <!-- END PARTIAL: embed-overlay -->

                <!-- END PARTIAL: infographic-zoom -->
            </div>
            <div class="article-copy">
                <sc:FieldRenderer ID="frOutro" runat="server" FieldName="Outro Text" />
            </div>
            <!-- end infographic -->
            <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" />
        </div>
    </div>
</div>
<!-- .container -->

<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpful.ascx" runat="server"></sc:Sublayout>

