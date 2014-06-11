<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertListing.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.ExpertListing" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:ListView ID="lvExperts" runat="server" GroupItemCount="3">
    <LayoutTemplate>
        <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
    </LayoutTemplate>
    <GroupTemplate>
        <div class="row about-expert-row">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </div>
    </GroupTemplate>
    <ItemTemplate>
        <div class="col col-6 offset-<%# (Container.DataItemIndex % 3 == 0) ? "1" : "2" %>">
            <div class="about-expert rs_read_this">
                <div class="expert-listing-image">
                    <asp:HyperLink ID="hlExpertThumbnail" runat="server"><asp:Image ID="imgExpert" runat="server" /></asp:HyperLink>
                </div>
                <div class="expert-listing-details">
                    <h4><asp:HyperLink ID="hlExpertName" runat="server"><sc:FieldRenderer ID="frExpertName" runat="server" FieldName="Expert Name" /></asp:HyperLink></h4>
                    <p class="credentials"><sc:FieldRenderer ID="frExpertSubheading" runat="server" FieldName="Expert Subheading" /></p>

                    <asp:Repeater ID="rptTasks" runat="server" ItemType="System.String">
                        <HeaderTemplate>
                            <div class="all-tasks">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <p class="tasks"><%# Item %></p>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    
                    <sc:FieldRenderer ID="frTwitterLink" runat="server" FieldName="Twitter Link" Parameters="class=links" />
                    <sc:FieldRenderer ID="frBlogLink" runat="server" FieldName="Blog Link" Parameters="class=links" />
                    <asp:HyperLink CssClass="links" ID="hlExpertDetail" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeMyBioLabel %></asp:HyperLink>
                </div>
            </div><!-- .about-expert -->

        </div><!-- .col -->
    </ItemTemplate>
</asp:ListView>