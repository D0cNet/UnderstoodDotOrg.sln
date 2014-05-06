<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogPostBody.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.BlogPostBody" %>
<div class="col col-17 blog-post-content skiplink-content" aria-role="main">
    <header class="comments-headers">
        <h2><sc:FieldRenderer ID="BlogTitle" runat="server" FieldName="Title"/></h2>
        <p class="byline"><sc:FieldRenderer ID="BlogDate" runat="server" FieldName="Date" /> by <a href="REPLACE"><sc:FieldRenderer ID="BlogAuthor" runat="server" FieldName="Author"/></a></p>
    </header>

    <article class="post">
        <sc:FieldRenderer ID="BlogBody" runat="server" FieldName="Body" />
    </article>

    <div class="about-the-author">
        <h4>About the Author</h4>

        <a class="author-image" href="REPLACE">
            <img alt="65x65 Placeholder" src="http://placehold.it/65x65" />
        </a>

        <div class="author-details">
            <a class="author-name" href="REPLACE">Skyler Jones</a>
            <a class="author-more-posts" href="REPLACE">More Posts by this Author</a>
            <p class="author-description">Inventore eius dolor ut dolor ex nostrum sapiente et repellat quibusdam</p>
        </div>
    </div>
</div>
