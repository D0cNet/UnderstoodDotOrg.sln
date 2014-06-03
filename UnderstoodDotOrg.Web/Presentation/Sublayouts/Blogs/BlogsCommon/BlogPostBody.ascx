<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogPostBody.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.BlogPostBody" %>
<div class="col col-17 blog-post-content skiplink-content" aria-role="main">
    <header class="comments-headers">
        <h2><sc:FieldRenderer id="BlogTitle" runat="server" fieldname="Title" /></h2>
        <p class="byline">
            <sc:FieldRenderer id="BlogDate" runat="server" fieldname="Date" />
            by <a id="linkAuthor" runat="server">
                <sc:FieldRenderer id="BlogAuthor" runat="server" fieldname="Author" />
            </a>
        </p>
    </header>
    <article class="post">
        <p>
            <sc:FieldRenderer id="BlogBody" runat="server" fieldname="Body" />
        </p>
    </article>

    <div class="about-the-author">
        <h4>About the Author</h4>

        <a class="author-image" href="REPLACE">
            <img alt="65x65 Placeholder" src="http://placehold.it/65x65" />
        </a>

        <div class="author-details">
            <a class="author-name" href="REPLACE"><sc:FieldRenderer runat="server" fieldname="Author" /></a>
            <a class="author-more-posts" href="REPLACE">More Posts by this Author</a>
            <p class="author-description">Repellat labore magni placeat ea magnam quo veritatis laboriosam amet voluptas necessitatibus sed</p>
        </div>
    </div>
</div>