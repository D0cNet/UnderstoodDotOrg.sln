<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutAuthor.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.AboutAuthor" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="rs_about_author rs_read_this">
    <section class="about-the-author">
        <header>
            <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_AbouttheAuthorText %></h2>
        </header>
        <%--<img src="http://placehold.it/60x60" alt="REPLACE">--%>
        <asp:HyperLink ID="hlAuthorImage" runat="server" Visible="false">
            <%--<sc:FieldRenderer ID="frAuthorImage" FieldName="Author Image" runat="server" Width="60px" Height="60px" />--%>
            <sc:image id="frAuthorImage" field="Author Image" runat="server" maxheight="60" maxwidth="60" height="60" width="60" />
        </asp:HyperLink>

        <div class="author-text">
            <h3><%-- Christine Flagler--%>
                <!--<sc:Text ID="txAuthorName" runat="server" Field="Author Name" />-->
                <sc:fieldrenderer id="frAuthorName" runat="server" fieldname="Author Name" />
            </h3>
            <p>
                <%--Lorem ipsum dolor sit amet, consectetuer laoreet dolore adipiscing elit, sed diam nonummy nibh euismod tincidunt ut dolore.--%>
                <sc:fieldrenderer id="frAuthorBio" runat="server" fieldname="Author Biodata" />
            </p>
            <asp:HyperLink ID="hlAuthorMorePost" runat="server" Text="<%# UnderstoodDotOrg.Common.DictionaryConstants.Articles_MorePostsbythisAuthorText %>" Visible="false">
            </asp:HyperLink>
            <%--<a href="REPLACE">More Posts by this Author</a>--%>
        </div>
    </section>
</div>
