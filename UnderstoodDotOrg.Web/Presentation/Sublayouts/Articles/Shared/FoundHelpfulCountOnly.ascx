﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoundHelpfulCountOnly.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.FoundHelpfulCountOnly" %>

<!-- END PARTIAL: pagetopic -->
<div class="count-mobile rs_read_this">
    <!-- BEGIN PARTIAL: helpful-count -->

    <div class="count-helpful">
        <a href="#count-helpful-content"><asp:Label ID="lblHelpfulCountMobile" runat="server"></asp:Label><asp:Literal ID="ltlFoundThisHelpfulMobile" runat="server"></asp:Literal></a>
    </div>
    <!-- END PARTIAL: helpful-count -->
</div>
<div class="container article-intro">
    <div class="row">
        <!-- helpful count -->
        <div class="col col-10 article-intro-count multiple">
            <!-- BEGIN PARTIAL: helpful-count -->

            <div class="count-helpful">
                <a href="#count-helpful-content"><asp:Label ID="lblHelpfulCount" runat="server"></asp:Label><asp:Literal ID="ltlFoundThisHelpful" runat="server"></asp:Literal></a>
            </div>
            <!-- END PARTIAL: helpful-count -->
        </div>

        <!-- intro-text -->
        <div class="col col-13 offset-1 article-intro-text-wrapper rs_read_this">
            <!-- BEGIN PARTIAL: article-intro-text -->
            <div class="article-intro-text">
                <sc:FieldRenderer FieldName="Page Summary" runat="server"></sc:FieldRenderer>
            </div>
            <!-- END PARTIAL: article-intro-text -->
        </div>

    </div>
    <!-- .row -->
</div>
<!-- .container -->