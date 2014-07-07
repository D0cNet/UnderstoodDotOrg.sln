<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogPostBody.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.BlogPostBody" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="col col-17 blog-post-content skiplink-content" aria-role="main">
    <header class="comments-headers">
        <h2><sc:FieldRenderer id="BlogTitle" runat="server" fieldname="Title" /></h2>
        <p class="byline">
            <sc:FieldRenderer id="BlogDate" runat="server" fieldname="Date" />
            <sc:Text Field="By Text" runat="server" /> <a id="linkAuthor" runat="server">
                <sc:FieldRenderer id="frBlogAuthor" runat="server" fieldname="Author" />
            </a>
        </p>
    </header>
    <article class="post">
        <p>
            <sc:FieldRenderer id="BlogBody" runat="server" fieldname="Body" />
        </p>
    </article>

    <div class="about-the-author">
        <h4><sc:Text Field="About The Author Text" runat="server" /></h4>

        <a class="author-image" href="REPLACE">
            <img alt="65x65 Placeholder" src="http://placehold.it/65x65" />
        </a>

        <div class="author-details">
            <a class="author-name" id="linkAuthor2" runat="server"><sc:FieldRenderer id="frBlogAuthor2" runat="server" fieldname="Author" /></a>
            <a class="author-more-posts" id="linkAuthor3" runat="server"><sc:Text Field="More Posts By This Author Text" runat="server" /></a>
            <p class="author-description"><asp:Literal ID="ltAuthorBio" runat="server" /></p>
        </div>
    </div>
</div>