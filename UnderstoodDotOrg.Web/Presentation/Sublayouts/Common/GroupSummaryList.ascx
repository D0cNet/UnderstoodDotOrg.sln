<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupSummaryList.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.GroupSummaryList" %>
<%@ Register Src="~/Presentation/Sublayouts/Recommendation/CommunityRecommendationIcons.ascx" TagPrefix="uc1" TagName="CommunityRecommendationIcons" %>

<asp:ListView ID="lvGroupCards" runat="server">
    <EmptyDataTemplate>
        <div class="row">
         <p>
             <asp:Literal Text="" ID="litEmptyDataText" runat="server" /></p>
        </div>
    </EmptyDataTemplate>
    <LayoutTemplate>
         <div class="row">
             <asp:PlaceHolder runat="server"  ID="itemPlaceholder"/>
         </div>
    </LayoutTemplate>
    <ItemTemplate>
         <div class="col-24 group-summary rs_read_this" aria-role="main">
        <div class="col col-18 topic clearfix">
            <header>
            <a id="titleLink" runat="server"><h3><%#Eval("Title") %></h3></a>
                <%--<span class="children-key">
                    <ul>
                    <li>
                        <i class='child-b' title='CHILD NAME HERE'></i>

                    </li>
                        <li>
                            <i class='child-d' title='CHILD NAME HERE'></i>

                        </li>
                        <li>
                            <i class='child-e' title='CHILD NAME HERE'></i>

                        </li>
                    </ul>
                </span>--%>
                <uc1:CommunityRecommendationIcons runat="server" id="CommunityRecommendationIcons" />
            </header>
            <div class="col col-4 feature-image"><img alt="150x150 Placeholder" src="<%#Eval("ModeratorAvatarUrl") %>"/></div>
            <div class="col col-18 description">
            <p class="group-description-info"><%# Eval("Description") %></p>
            <p class="leader"><%# Eval("ModeratorName")  %>,<%#Eval("ModeratorTitle") %></p>
            </div>
        </div>
        <div class="col col-6 statistics">
            <p class="members"><%#Eval("NumOfMembers", "{0:0,0.00}") %> Members</p>
            <p class="discussions"><%#Eval("NumOfDiscussions", "{0:0,0.00}") %> Discussions</p>
            <div class="submit-button-wrap">
            <%--<a href="<%#Eval("JoinUrl") %>" class="button rs_skip">Join this Group</a>--%>
                <asp:LinkButton ID="btnJoinGroup"  OnClick="btnJoinGroup_Click" CssClass="button rs_skip" runat="server" Text=""></asp:LinkButton>
            </div>
        </div>
        </div> 

    </ItemTemplate>
    
</asp:ListView>

 
