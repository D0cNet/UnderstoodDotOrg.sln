<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpertListing.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.ExpertListing" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Repeater ID="rptListing" runat="server" OnItemDataBound="rptListing_ItemDataBound" Visible="false">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Panel ID="rowSubParentPanel" runat="server" CssClass="col col-6">

                    <div class="about-expert rs_read_this">
                        <div class="expert-listing-image">
                            <sc:Image ID="scExpertImage" runat="server" Field="Expert Image" />
                            <asp:Image runat="server" ID="imgDefaultImage" src="http://placehold.it/230x230&amp;text=230x230" alt="FPO content image" />
                        </div>
                        <div class="expert-listing-details">
                            <h4>
                                <sc:FieldRenderer ID="frHeading" runat="server" FieldName="Heading" />
                            </h4>
                            <p class="credentials">
                                <sc:FieldRenderer ID="frSubHeading" runat="server" FieldName="SubHeading" />
                            </p>
                           <%-- <div class="all-tasks">
                                <p class="tasks">Hosts Webinars</p>
                                <p class="tasks">Blogs</p>
                            </div>--%>
                            <sc:Link ID="scFollowTwittLink" runat="server" Field="Follow on Twitter" CssClass="links rs_skip"></sc:Link>
                            <sc:Link ID="scFollowBlogLink" runat="server" CssClass="links rs_skip" Field="Follow my blog"></sc:Link>
                            <sc:Link ID="scBioLink" runat="server" CssClass="links rs_skip" Field="See my bio"></sc:Link>

                        </div>
                    </div>
                    <!-- .about-expert -->
                </asp:Panel>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
<asp:Label runat="server" ID="lblmoreArticle" style="display:none;" ClientIDMode="Static" Text="true"></asp:Label>