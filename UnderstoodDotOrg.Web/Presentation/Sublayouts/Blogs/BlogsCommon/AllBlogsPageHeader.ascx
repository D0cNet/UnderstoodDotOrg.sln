<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllBlogsPageHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.AllBlogsPageHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="community-blogs-main">
    <div class="row">
        <div class="col col-24 skiplink-feature">
            <div class="rs_read_this community-blogs-main-rs-wrapper">
                <div class="blog-image">
                    <img alt="310x174 Placeholder" src="http://placehold.it/310x174" />
                </div>
                <div class="blog-info">
                    <h2>
                        <sc:Text Field="The Understood Blog Text" runat="server" />
                    </h2>
                    <p>
                        <sc:Text Field="Understood Blog Description" runat="server" />
                    </p>
                    <a id="btnUnderstoodBlog" runat="server" class="button" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.ReadTheUnderstoodBlogButtonLabel %></a>
                </div>
            </div>
        </div>
    </div>
</div>