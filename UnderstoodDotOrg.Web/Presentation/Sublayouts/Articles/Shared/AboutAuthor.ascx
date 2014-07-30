<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutAuthor.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.AboutAuthor" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<section class="about-the-author">
    <header>
        <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_AbouttheAuthorText %></h2>
    </header>

    <asp:HyperLink ID="hlAuthorImage" runat="server" Visible="false">
        <sc:image id="frAuthorImage" field="Author Image" runat="server" maxheight="60" maxwidth="60" height="60" width="60" />
    </asp:HyperLink>

    <div class="author-text">
        <h3><sc:fieldrenderer id="frAuthorName" runat="server" fieldname="Author Name" /></h3>
        <p><asp:Literal ID="litBioSentence" runat="server"></asp:Literal></p>
        <asp:HyperLink ID="hlAuthorMorePost" runat="server"></asp:HyperLink>
    </div>
</section>
