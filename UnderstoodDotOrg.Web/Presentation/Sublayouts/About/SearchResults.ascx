<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResults.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.SearchResults" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container l-search-box-container skiplink-toolbar">
  <div class="row">
    <div class="col col-22 offset-1">
      <!-- BEGIN PARTIAL: about/search-box-module -->
        <div class="search-box-module">
          <fieldset>
            <legend><%= UnderstoodDotOrg.Common.DictionaryConstants.SearchLabel %></legend>
              <span class="field">
                <label for="search-term" class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.SearchLabel %></label>
                <asp:TextBox ID="txtSearch" runat="server" />
                <asp:Button ID="btnSearch" runat="server" />
              </span>
          </fieldset>
        </div>
        <!-- END PARTIAL: about/search-box-module -->
    </div>
  </div>
</div>

<asp:PlaceHolder ID="phResults" runat="server">
<div class="container l-results-and-filter l-results-misspelling">
  <div class="row">
    <div class="col col-24 rs_read_this">
      <!-- UN-1741 - # of Results & Filter -->
      <!-- BEGIN PARTIAL: about/results-and-filter -->
        <div class="results">
          <asp:PlaceHolder ID="phResultsNoMisspelling" runat="server">
              <h1><%= ResultCount %> Results for <span>&ldquo;<%= SearchTerm %>&rdquo;</span></h1>
          </asp:PlaceHolder>
            <asp:PlaceHolder ID="phResultsMisspelling" runat="server">
                <h1>Showing results for <span>&ldquo;<%= SearchTerm %>&rdquo;</span></h1>
                <h2>Search instead for <asp:Literal ID="litMisspellings" runat="server" /></h2>
                <h3><%= ResultCount %> Results for <span>&ldquo;<%= SearchTerm %>&rdquo;</span></h3>
            </asp:PlaceHolder>
            
        </div>
        <label>
          <asp:DropDownList ID="ddlSearchFilter" AutoPostBack="true" runat="server" />
        </label>
        <div class="clearfix"></div>
<!-- END PARTIAL: about/results-and-filter -->
    </div>
  </div>
</div>

<script id="search-result-entry" type="text/template">
    <div class="row search-result-container rs_read_this">
        <div class="col col-6 search-image">
        <img class="" alt="" src="{{Thumbnail}}" />
        </div>

        <div class="col col-11 offset-1 search-content">
        <h4><a href="{{Url}}">{{{Title}}}</a></h4>
        <p>{{Blurb}}</p>
        </div>

        <div class="col col-5 search-category">
        <span>{{Type}}</span>
        </div>
    </div>
</script>

<div class="container about-search-results-container">
    <div class="row">
    <div class="col col-24">

    <asp:Repeater ID="rptResults" runat="server" ItemType="UnderstoodDotOrg.Domain.Search.JSON.SearchArticle">
        <HeaderTemplate>
            <div class="about-search-results skiplink-content" aria-role="main">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="row search-result-container rs_read_this">
                <div class="col col-6 search-image">
                <img alt="" src="<%#: Item.Thumbnail %>" />
                </div>

                <div class="col col-11 offset-1 search-content">
                <h4><a href="<%#: Item.Url %>"><%# Item.Title%></a></h4>
                <p><%#: Item.Blurb %></p>
                </div>

                <div class="col col-5 search-category">
                <span><%#: Item.Type %></span>
                </div><!-- end .col.col-5 -->
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div> 
            <!-- .about-search-results -->
        </FooterTemplate>
    </asp:Repeater>

    <asp:PlaceHolder ID="phMoreResults" runat="server">
        <div class="about-search-results-more">
        <!-- Show More -->
        <!-- BEGIN PARTIAL: community/show_more -->
        <!--Show More-->
        <div class="container show-more rs_skip">
            <div class="row">
            <div class="col col-24">
                <a class="show-more-search-results-link" href="#" data-path="<%= AjaxUrl %>" data-type="<%= AjaxType %>" data-container="about-search-results" data-term="<%= AjaxTerm %>" data-item="search-result-entry"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></a>
            </div>
            </div>
        </div><!-- .show-more -->
        <!-- END PARTIAL: community/show_more -->
        <!-- .show-more -->
        </div><!-- .about-search-results-more -->
    </asp:PlaceHolder>

    </div><!-- .col -->
    </div><!-- .row -->
</div> <!-- .container -->

</asp:PlaceHolder>

<asp:Placeholder id="phNoResults" runat="server" Visible="false">
    <div class="container l-about-zero-results">
            <div class="row">
            <div class="col col-24 zero-results-inner">
                <div class="col col-22 offset-1 rs_read_this zero-results-inner-rs-wrapper">
                <!-- UN-3289 - Zero Results -->
                <!-- BEGIN PARTIAL: about/about-zero-results.erb -->
                <div class="about-zero-results">
                    <h1>0 Results for <span>&ldquo;<asp:Literal ID="litSearchTermNoResults" runat="server" />&rdquo;</span></h1>
                    <p>We couldn't find any results that match your search words. Try these:</p>
                    <ul>
                    <li>Check your spelling</li>
                    <li>Use different search words in the search bar above</li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <!-- END PARTIAL: about/about-zero-results.erb -->
                </div>
            </div>
            </div>
        </div>
</asp:Placeholder>
      

