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
                    <asp:Image ID="imgExpert" runat="server" />
                </div>
                <div class="expert-listing-details">
                    <h4><sc:FieldRenderer ID="frExpertName" runat="server" FieldName="Expert Name" /></h4>
                    <p class="credentials"><sc:FieldRenderer ID="frExpertSubheading" runat="server" FieldName="Expert Subheading" /></p>

                    <asp:Repeater ID="rptTasks" runat="server">
                        <HeaderTemplate>
                            <div class="all-tasks">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <p class="tasks"></p>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    
                    <sc:FieldRenderer ID="frTwitterLink" runat="server" FieldName="Twitter Link" Parameters="class=links" />
                    <sc:FieldRenderer ID="frBlogLink" runat="server" FieldName="Blog Link" Parameters="class=links" />
                    <asp:HyperLink ID="hlExpertDetail" runat="server">See my bio</asp:HyperLink>
                </div>
            </div><!-- .about-expert -->

        </div><!-- .col -->
    </ItemTemplate>
</asp:ListView>