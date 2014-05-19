<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyCommentsTest.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent.MyCommentsTest" %>
<!-- BEGIN PARTIAL: account-landing-mycomments -->
<div class="landing-mycomments landing-modules">
  <header class="clearfix">
    <h3>My Comments<span class="landing-module-count"><asp:Label ID="lblCount" runat="server"></asp:Label></span></h3>
  </header>
    <asp:ListView runat="server" ID="topComments">
        <EmptyDataTemplate>
            <p>
                <asp:Label id="litEmpty" Text="You have not made any comments on our site."  runat="server" /></p>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <ul runat="server">
                <li runat="server" id="itemPlaceHolder"></li>
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
              <li>
                    <span class="comment-wrap">
                        <asp:HyperLink NavigateUrl="#" CssClass="comment-link" ID="cLink" runat="server" />
                        <p class="comment-description"><asp:Literal ID="cDesc" runat="server"></asp:Literal></p>
                    </span>
                  </li>
        </ItemTemplate>
    </asp:ListView>

        <%--<asp:Repeater ID="topComments" runat="server">
            
            <HeaderTemplate>
              <ul class="landing-module-items">
            </HeaderTemplate>
            <ItemTemplate>
                   <li>
                    <span class="comment-wrap">
                        <asp:HyperLink NavigateUrl="#" CssClass="comment-link" ID="cLink" runat="server" />

                        <p class="comment-description"><asp:Literal ID="cDesc" runat="server"></asp:Literal></p>
                    </span>
                  </li>

            </ItemTemplate>
            
            <FooterTemplate>
             </ul>
            </FooterTemplate>
            
        </asp:Repeater>--%>
    
  

    <div class="bottom"><a href="REPLACE">See All Comments</a></div>
  
</div><!-- /.landing-notifications /.landing-modules -->
<!-- END PARTIAL: account-landing-mycomments -->
    