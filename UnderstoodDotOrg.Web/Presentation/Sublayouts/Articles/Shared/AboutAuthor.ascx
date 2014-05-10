<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutAuthor.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.AboutAuthor" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<section class="about-the-author">
    <header>
        <h2>About the Author</h2>
    </header>
    <%--<img src="http://placehold.it/60x60" alt="REPLACE">--%>
    <asp:HyperLink ID="hlAuthorImage" runat="server">
        <%--<sc:FieldRenderer ID="frAuthorImage" FieldName="Author Image" runat="server" Width="60px" Height="60px" />--%>
        <sc:Image ID="frAuthorImage" Field="Author Image" runat="server" MaxHeight="60" MaxWidth="60" Height="60" Width="60" />
    </asp:HyperLink>

    <div class="author-text">
        <h3><%-- Christine Flagler--%>
            <!--<sc:Text ID="txAuthorName" runat="server" Field="Author Name" />-->
            <sc:FieldRenderer ID="frAuthorName" runat="server" FieldName="Author Name" />
        </h3>
        <p>
            <%--Lorem ipsum dolor sit amet, consectetuer laoreet dolore adipiscing elit, sed diam nonummy nibh euismod tincidunt ut dolore.--%>
            <sc:FieldRenderer ID="frAuthorBio" runat="server" FieldName="Author Biodata" />
        </p>
        <asp:HyperLink ID="hlAuthorMorePost" runat="server" Text="More Posts by this Author">
        </asp:HyperLink>
        <%--<a href="REPLACE">More Posts by this Author</a>--%>
    </div>
</section>
