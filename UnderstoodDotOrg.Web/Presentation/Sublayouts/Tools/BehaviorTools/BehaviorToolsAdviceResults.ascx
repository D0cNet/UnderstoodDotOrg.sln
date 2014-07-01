<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsAdviceResults.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsAdviceResults" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container behavior-results flush">
  <div class="row">
    <div class="col col-24">
      <!-- BEGIN PARTIAL: advice-results -->
<section class="advice-results">
  <div class="row">
    <div class="col col-24">
    <header>
      <h3 class="rs_read_this"><%= UnderstoodDotOrg.Common.DictionaryConstants.WorkOnFragment %> <asp:Literal ID="litChallenge" runat="server" /></h3>
      <i class="icon-tooltip"></i>
        <sc:FieldRenderer ID="frCallToActionLink" Parameters="class=how-to-use" runat="server" FieldName="Call To Action Link" />
    </header>
      </div>
  </div>

<asp:PlaceHolder ID="phSearchResults" runat="server" Visible="false">
    <script id="behavior-search-result" type="text/template">
        <div class="search-result skiplink-content rs_read_this" aria-role="main">
            <div class="result-body">
                <div class="result-tip">{{Title}}</div>
                <div class="result-info">
                <span class="tip-comment">{{CommentCount}}<span class="visuallyhidden">comments</span></span>
                <span class="tip-like" href="#"><i class="icon-advice-like"></i>{{HelpfulCount}}<span class="visuallyhidden">likes</span></span>
                </div>
                <div class="result-hover rs_skip">
                <div class="hover-link-wrapper">
                    <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i><span><%= UnderstoodDotOrg.Common.DictionaryConstants.SaveThisButtonText %></span></a>
                </div>
                <div class="hover-link-wrapper">
                    <a class="tip-remind-me" href="REPLACE"><i class="icon-advice-bell"></i><span><%= UnderstoodDotOrg.Common.DictionaryConstants.RemindMeButtonText %></span></a>
                </div>
                </div>
            </div>
            <a class="tip-view rs_skip" href="{{Url}}"><%= UnderstoodDotOrg.Common.DictionaryConstants.ViewTipButtonText %></a>
        </div>
    </script>

    <asp:Repeater ID="rptResults" runat="server" ItemType="UnderstoodDotOrg.Domain.Search.JSON.SearchBehaviorArticle">
        <HeaderTemplate>
            <div class="results-outer-wrapper">
                <div id="behavior-search-results" class="results-wrapper">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="search-result skiplink-content rs_read_this" aria-role="main">
                <div class="result-body">
                    <div class="result-tip"><%# Item.Title %></div>
                    <div class="result-info">
                    <span class="tip-comment"><%# Item.CommentCount %><span class="visuallyhidden">comments</span></span>
                    <span class="tip-like" href="#"><i class="icon-advice-like"></i><%# Item.HelpfulCount %><span class="visuallyhidden">likes</span></span>
                    </div>
                    <div class="result-hover rs_skip">
                    <div class="hover-link-wrapper">
                        <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i><span><%= UnderstoodDotOrg.Common.DictionaryConstants.SaveThisButtonText %></span></a>
                    </div>
                    <div class="hover-link-wrapper">
                        <a class="tip-remind-me" href="REPLACE"><i class="icon-advice-bell"></i><span><%= UnderstoodDotOrg.Common.DictionaryConstants.RemindMeButtonText %></span></a>
                    </div>
                    </div>
                </div>
                <a class="tip-view rs_skip" href="<%# Item.Url %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.ViewTipButtonText %></a>
            </div>
        </ItemTemplate>
        <FooterTemplate>
                </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>

    <asp:PlaceHolder ID="phMoreResults" runat="server" Visible="false">
    <div class="container show-more rs_skip">
      <div class="row">
        <div class="col col-24">
            <a class="show-more-behavior-results-link" href="#" data-container="behavior-search-results" data-template="behavior-search-result" data-path="<%= AjaxPath %>" data-challenge="<%= SelectedChallenge %>" data-grade="<%= SelectedGrade %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreButtonText %><i class="icon-arrow-down-blue"></i></a>
        </div>
      </div>
    </div>
    </asp:PlaceHolder>

</asp:PlaceHolder>

<asp:PlaceHolder ID="phNoResults" runat="server" Visible="false">
    <sc:FieldRenderer runat="server" FieldName="No Results Message" />
</asp:PlaceHolder>


</section>

<!-- END PARTIAL: advice-results -->
    </div>
  </div>
</div><!-- .container -->

<asp:Repeater ID="rptLinks" runat="server">
<HeaderTemplate>
    <div class="behavior-tool-related-articles-small">
        <div class="behavior-tool-related-articles">
            <ul>
</HeaderTemplate>
<ItemTemplate>
    <li><asp:HyperLink ID="hlArticleLink" runat="server" /></li>
</ItemTemplate>
<FooterTemplate>
            </ul>
        </div>
    </div>
</FooterTemplate>
</asp:Repeater>