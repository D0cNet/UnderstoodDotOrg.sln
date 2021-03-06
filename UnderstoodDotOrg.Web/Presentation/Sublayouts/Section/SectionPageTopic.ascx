﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SectionPageTopic.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Section.SectionPageTitle" %>

<div class="container page-topic no-share">
    <div class="row">
        <div class="col col-14 offset-1">
            <asp:HyperLink runat="server" ID="hlBackLink" CssClass="back-to-previous"><i class="icon-arrow-left-blue"></i><%= HomepageLink %></asp:HyperLink>
           <h1>
                <asp:Literal runat="server" ID="scTopicTitle" ></asp:Literal>
            </h1>

        </div>
    </div>
</div>
