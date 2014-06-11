<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.ContactUsWidget" %>

<div class="about-contact-block">
    <h2><%= Model.Title.Rendered %></h2>
    <%= Model.Body.Rendered %>
</div>
<!-- .about-contact-block -->
