<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupSummaryList.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.GroupSummaryList" %>
<asp:Repeater ID="rptGroupCards" runat="server">
    <HeaderTemplate>
        <div class="row">
    </HeaderTemplate>
    <ItemTemplate> 
        <div class="col-24 group-summary rs_read_this" aria-role="main">
        <div class="col col-18 topic clearfix">
            <header>
            <h3><%#Eval("Title") %></h3>
                <span class="children-key">
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
                </span>
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
            <a href="<%#Eval("JoinUrl") %>" class="button rs_skip">Join this Group</a>
            </div>
        </div>
        </div> 

    </ItemTemplate>
    <FooterTemplate></div></FooterTemplate>

</asp:Repeater>

 
