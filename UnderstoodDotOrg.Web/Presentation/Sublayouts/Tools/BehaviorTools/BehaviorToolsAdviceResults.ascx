<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsAdviceResults.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsAdviceResults" %>
<div class="container behavior-results flush">
  <div class="row">
    <div class="col col-24">
      <!-- BEGIN PARTIAL: advice-results -->
<section class="advice-results">
  <div class="row">
    <div class="col col-24">
    <header>
      <h3>Work on task-to-task transitions</h3>
      <i class="icon-tooltip"></i>
      <a class="how-to-use" href="REPLACE">How to use these strategies</a>
    </header>
      </div>
  </div>

<asp:Repeater ID="rptResults" runat="server">
    <HeaderTemplate>
        <div class="results-outer-wrapper">
            <div class="results-wrapper">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="search-result">
            <div class="result-body">
                <div class="result-tip">Make a picture schedule</div>
                <div class="result-info">
                <span class="tip-comment">19</span>
                <span class="tip-like" href="REPLACE"><i class="icon-advice-like"></i>3</span>
                </div>
                <div class="result-hover">
                <div class="hover-link-wrapper">
                    <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i>Save This</a>
                </div>
                <div class="hover-link-wrapper">
                    <a class="tip-print" href="REPLACE"><i class="icon-advice-print"></i>Print This</a>
                </div>
                </div>
            </div>
            <a class="tip-view" href="REPLACE">View Tip</a>
        </div>
    </ItemTemplate>
    <FooterTemplate>
            </div>
        </div>
    </FooterTemplate>
</asp:Repeater>

  <a class="results-more-link" href="#" data-path="" data-challenge="" data-grade=""><span>More Results</span><i class="icon-results-more"></i></a>
</section>

<!-- END PARTIAL: advice-results -->
    </div>
  </div>
</div><!-- .container -->