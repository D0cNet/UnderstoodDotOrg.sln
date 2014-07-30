<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HelpfulVote.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.Widgets.HelpfulVote" %>

<div class="find-this-helpful <%= AdditionalCssClass %>">
   
  <h4><%= UnderstoodDotOrg.Common.DictionaryConstants.DidYouFindThisHelpfulLabel %></h4>
  <ul>
    <li>
      <asp:Button ID="btnLike" OnClick="btnThisHelped_Click" CssClass="button helpful-yes rs_preserve" runat="server"/>
    </li>
    <li class="gray">
      <asp:Button ID="btnUnlike" OnClick="btnDidntHelp_Click" CssClass="button helpful-no rs_preserve" runat="server"/>
    </li>
  </ul>
  <div class="clearfix"></div>
   
</div>