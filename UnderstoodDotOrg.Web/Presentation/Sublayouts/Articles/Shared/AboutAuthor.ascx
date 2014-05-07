<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutAuthor.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.AboutAuthor" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<section class="about-the-author">
    <header>
        <h2>About the Author</h2>
    </header>
    <%--<img src="http://placehold.it/60x60" alt="REPLACE">--%>
    <asp:HyperLink ID="hlAuthorImage" runat="server">
        <sc:fieldrenderer id="frAuthorImage" fieldname="Author Image" runat="server" width="60px" height="60px" />
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
        <asp:HyperLink ID="hlAuthorMorePost" runat="server" Text="More Posts by this Author">
        </asp:HyperLink>
        <%--<a href="REPLACE">More Posts by this Author</a>--%>
    </div>
</section>
