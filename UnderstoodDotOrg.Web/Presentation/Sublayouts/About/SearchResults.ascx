<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResults.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.SearchResults" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Panel runat="server" DefaultButton="btnSearch" CssClass="container l-search-box-container skiplink-toolbar">
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
</asp:Panel>

<asp:Panel ID="pnlResults" runat="server">
<div class="container l-results-and-filter l-results-misspelling">
  <div class="row">
    <div class="col col-24 rs_read_this">
      <!-- UN-1741 - # of Results & Filter -->
      <!-- BEGIN PARTIAL: about/results-and-filter -->

        <asp:Panel ID="pnlResultsNoMisspelling" runat="server" CssClass="results">
            <h1><%= ResultCount %> <sc:FieldRenderer ID="frResultsFor" runat="server" FieldName="Results For Label" /> <span>&ldquo;<%= SearchTerm %>&rdquo;</span></h1>
        </asp:Panel>
        <asp:Panel ID="pnlResultsMisspelling" runat="server" CssClass="results">
            <h1><sc:FieldRenderer ID="frShowingResultsFor" runat="server" FieldName="Showing Results For Label" /> <span>&ldquo;<%= SearchTerm %>&rdquo;</span></h1>
            <h2><sc:FieldRenderer ID="frSearchInsteadFor" runat="server" FieldName="Search Instead For Label" /> <asp:Literal ID="litMisspellings" runat="server" /></h2>
            <h3><%= ResultCount %> <sc:FieldRenderer ID="frResultsFor2" runat="server" FieldName="Results For Label" /> <span>&ldquo;<%= SearchTerm %>&rdquo;</span></h3>
        </asp:Panel>
            
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
                <a class="show-more-search-results-link" href="#" data-path="<%= AjaxUrl %>" data-type="<%= AjaxType %>" data-container="about-search-results" data-term="<%= AjaxTerm %>" data-item="search-result-entry" data-lang="<%= Sitecore.Context.Language.Name %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></a>
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

</asp:Panel>

<asp:Panel id="pnlNoResults" runat="server" Visible="false">
    <div class="container l-about-zero-results">
        <div class="row">
            <div class="col col-24 zero-results-inner">
                <div class="col col-22 offset-1 rs_read_this zero-results-inner-rs-wrapper">
                <!-- UN-3289 - Zero Results -->
                <!-- BEGIN PARTIAL: about/about-zero-results.erb -->
                <div class="about-zero-results">
                    <h1>0 <sc:FieldRenderer ID="frResultsFor3" runat="server" FieldName="Results For Label" /> <span>&ldquo;<asp:Literal ID="litSearchTermNoResults" runat="server" />&rdquo;</span></h1>
                    <sc:FieldRenderer ID="frNoResultsMessage" runat="server" FieldName="No Results Message" />
                    <div class="clearfix"></div>
                </div>
                <!-- END PARTIAL: about/about-zero-results.erb -->
                </div>
            </div>
        </div>
    </div>

    <div class="container about-tools-header">
      <div class="row">
        <div class="col col-22 offset-1">
          <h3><sc:FieldRenderer ID="frToolWidgetsHeading" runat="server" FieldName="Tool Widgets Heading" /></h3>
        </div>
      </div>
    </div>
<!-- BEGIN PARTIAL: about/tools -->

<asp:Repeater ID="rptWidgets" runat="server">
    <HeaderTemplate>
        <div class="about-tools select-inverted-mobile">
            <div class="container mini-tools-wrap">
                <div class="row">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col col-8 <%# Container.ItemIndex == 0 ? "skiplink-content" : "" %>" <%# Container.ItemIndex == 0 ? "aria-role=\"main\"" : "" %>>
            <section class="mini-tool rs_read_this">
                <sc:Sublayout ID="slWidget" runat="server" />
            </section>
        </div>
    </ItemTemplate>
    <FooterTemplate>
                </div><!-- .row --> 
            </div><!-- .container --> 
        </div>
    </FooterTemplate>
</asp:Repeater>
<!-- END PARTIAL: tools -->
</asp:Panel>
      

