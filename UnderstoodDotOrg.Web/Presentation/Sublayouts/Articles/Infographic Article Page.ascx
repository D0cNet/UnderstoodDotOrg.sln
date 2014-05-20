<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Infographic Article Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Infographic_Article_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>



<sc:Sublayout ID="Sublayout1" Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulCountOnly.ascx" runat="server"></sc:Sublayout>

<div class="container article">
    <div class="row">
        <!-- article -->
        <div class="col col-22 offset-1">
            <div class="infographic">
                <%-- <img src="http://placehold.it/100x1000" width="100%" /> --%>
                <sc:FieldRenderer ID="frInfographicImage" runat="server" FieldName="Image" />
                <!-- BEGIN PARTIAL: infographic-zoom -->
                <div class="infographic-zoom">
                    <%--generate embed code, have click-to-copy support--%>
                    <a href="REPLACE" class="infographic-zoom-icon infographic-zoom-icon-embed" data-toggle="modal" data-target="#embed-overlay">Embed</a>
                    <%--open download stream--%>
                    <a href="/Handlers/DownloadFile.ashx?id=<%= Sitecore.Context.Item.ID.ToString() %>" class="infographic-zoom-icon infographic-zoom-icon-download">Download</a>
                    <%--<asp:Button runat="server" ID="uxButtonDownload" CssClass="infographic-zoom-icon infographic-zoom-icon-download" Text="Download" OnClick="uxButtonDownload_Click" />--%>
                    <%--zoom in on infographic within viewport--%>
                    <a href="REPLACE" class="infographic-zoom-icon infographic-zoom-icon-zoom-in">Zoom In</a>
                    <%--zoom out on infographic within viewport--%>
                    <a href="REPLACE" class="infographic-zoom-icon infographic-zoom-icon-zoom-out">Zoom Out</a>
                </div>
                <!-- end infographic-zoom -->

                <%--<!-- BEGIN PARTIAL: embed-overlay -->
                <!-- Embed Overlay Modal -->
                <div class="modal fade" id="embed-overlay" tabindex="-1" role="dialog" aria-labelledby="embed-overlay-modal" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-body embed-overlay">
                                <div class="checklist-close" data-dismiss="modal"><i class="icon-close"></i><span>Close</span></div>
                                <h3>Infographic Embed Tag</h3>
                                <textarea name="" placeholder="Enter your suggestion&hellip;">
                                    <%-- <iframe width="560" height="315" src="//www.youtube.com/embed/Z1BwhYKTv3c" frameborder="0" allowfullscreen></iframe>
                                    <sc:FieldRenderer ID="frInfographEmbedtag" runat="server" FieldName="Body Content" />
                                </textarea>
                                <div class="copy-button-container">
                                    <input type="submit" class="submit-button copy" value="Copy">
                                </div>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
                <!-- END PARTIAL: embed-overlay -->--%>

<!-- BEGIN PARTIAL: embed-overlay -->
<!-- Embed Overlay Modal -->
<div class="modal fade" id="embed-overlay" tabindex="-1" role="dialog" aria-labelledby="embed-overlay-modal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body embed-overlay">
        <i class="close-overlay" data-dismiss="modal">Close</i>
        <h3>Infographic Embed Tag</h3>
        <%--<textarea name="" placeholder="Enter your suggestion&hellip;">
            <iframe width="560" height="315" src="//www.youtube.com/embed/Z1BwhYKTv3c" frameborder="0" allowfullscreen></iframe>
        </textarea>--%>
          <asp:TextBox runat="server" ID="uxModalEmbed" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
        <div class="copy-button-container">
          <a href="REPLACE" class="button submit-button copy">Copy</a> <%--TODO: implement click-to-copy--%>
        </div>
          <div id="copyAlert" class="alert success fade hidden" data-alert="alert">Embed code has been copied to your clipboard</div>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<!-- END PARTIAL: embed-overlay -->

                <!-- END PARTIAL: infographic-zoom -->
            </div>
            <!-- end infographic -->
            <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" Visible="false" />
            <%--<p class="reviewed-by">
                <span class="reviewed-by-title">Reviewed&nbsp;by</span> <span class="reviewed-by-author">
                   <%--<a href="REPLACE">Dr. Samantha Frank</a>
                   <asp:HyperLink ID="hlReviewdby" runat="server">
                       <sc:FieldRenderer ID="frReviewedby" runat="server" FieldName="Revierwer Name" />
                    </asp:HyperLink>
                </span><span class="dot"></span><span class="reviewed-by-date">
                    <%--12&nbsp;Dec&nbsp;&apos;13
                    <sc:Date ID="dtReviewdDate" Field="Reviewed Date" runat="server" Format="dd MMM yy" />
                </span>
            </p>--%>
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
    </div>
</div>
<!-- .container -->

