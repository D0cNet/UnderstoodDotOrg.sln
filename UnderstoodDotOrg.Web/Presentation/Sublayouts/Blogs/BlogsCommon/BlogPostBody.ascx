<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogPostBody.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.BlogPostBody" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="rs_read_this blog-post-content-rs-wrapper" aria-role="main">
    <header class="comments-headers">
        <h2 class="rs_skip">
            <sc:FieldRenderer ID="BlogTitle" runat="server" FieldName="Title" />
        </h2>
        <p class="byline">
            <sc:FieldRenderer ID="BlogDate" runat="server" FieldName="Date" />
            <sc:Text Field="By Text" runat="server" />
            <a id="linkAuthor" runat="server">
                <sc:FieldRenderer ID="frBlogAuthor" runat="server" FieldName="Author" />
            </a>
        </p>
    </header>
    <article class="post">
        <p>
            <sc:FieldRenderer ID="BlogBody" runat="server" FieldName="Body" />
        </p>
    </article>
</div>
<div class="about-the-author rs_read_this">
    <h4>
        <sc:Text Field="About The Author Text" runat="server" />
    </h4>

    <a class="author-image" href="REPLACE">
        <img alt="65x65 Placeholder" src="http://placehold.it/65x65" />
    </a>

    <div class="author-details">
        <a class="author-name" id="linkAuthor2" runat="server">
            <sc:FieldRenderer ID="frBlogAuthor2" runat="server" FieldName="Author" />
        </a>
        <a class="author-more-posts" id="linkAuthor3" runat="server">
            <sc:Text Field="More Posts By This Author Text" runat="server" />
        </a>
        <p class="author-description">
            <asp:Literal ID="ltAuthorBio" runat="server" /></p>
    </div>
</div>
<div class="find-this-helpful-small clearfix">
    <!-- Module within only appears in under 650px window width-->
</div>
