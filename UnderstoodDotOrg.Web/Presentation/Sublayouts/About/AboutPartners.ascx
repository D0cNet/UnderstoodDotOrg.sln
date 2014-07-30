<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutPartners.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.AboutPartners" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container">
    <div class="row">
        <div class="col col-24 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: about/about-partners -->
            <div class="col offset-1 our-partners-intro rs_read_this ourPartners">
                <h2>
                    <sc:FieldRenderer ID="frPartnerPageHeadline" runat="server" FieldName="Partner Page Headline" />
                </h2>
                <p>
                    <sc:FieldRenderer ID="frPartnerPageSummary" runat="server" FieldName="Partner Page Summary" />
                </p>
            </div>
            <div class="clearfix"></div>
            <hr>
            <!-- END PARTIAL: about/about-partners -->
            <!-- BEGIN PARTIAL: about/about-partners-list -->
            <div class="offset-1">
                <div class="about-partners-list">
                    <div class="rs_read_this partners-list-rs-wrapper">
                        <h2>
                            <sc:FieldRenderer ID="frPartnerListHeadline" runat="server" FieldName="Partner List Headline" />
                        </h2>
                        <p>
                            <sc:FieldRenderer ID="frPartnerListSummary" runat="server" FieldName="Partner List Summary" />
                        </p>
                    </div>
                    <asp:Repeater ID="rptPartnerInfo" runat="server" OnItemDataBound="rptPartnerInfo_ItemDataBound">
                        <ItemTemplate>
                            <div class="partner-block clearfix rs_read_this">
                                <div class="partner-block-logo">
                                    <asp:HyperLink ID="hlPartnerLogo" runat="server">
                                        <sc:Image ID="imgPartnerLogo" runat="server" Field="Partner Logo" Parameters="mw=271&mh=131" />
                                    </asp:HyperLink>
                                </div>
                                <!-- end partner-block-logo -->
                                <div class="partner-block-text">
                                    <h3>
                                        <asp:HyperLink ID="hlPartnerNameLink" runat="server">
                                            <sc:FieldRenderer ID="frPartnerName" runat="server" FieldName="Partner Name" />
                                        </asp:HyperLink>
                                    </h3>
                                    <p>
                                        <sc:FieldRenderer ID="frPartnerDescription" runat="server" FieldName="Partner Short Description" />
                                    </p>
                                    <span class="partner-block-read-more">
                                        <asp:HyperLink ID="hlPartnerSite" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.ReadMoreLabel %></asp:HyperLink>
                                    </span>
                                </div>
                                <!-- end partner-block-text -->
                            </div>
                            <!-- end partner-block -->
                            <div class="clearfix"></div>
                        </ItemTemplate>
                    </asp:Repeater>




                </div>
                <!-- end about-partner-list -->
            </div>
            <!-- end col offset-1 -->
            <!-- END PARTIAL: about/about-partners-list -->
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container -->

<!-- BEGIN PARTIAL: footer -->


