<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QandA.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Q_and_A.QandA" %>
<div class="container community-q-a">
    <div class="row">
        <div class="col col-24">
            <sc:Placeholder Key="QuestionToolbar" runat="server" />
            <div class="box-search clearfix">
                <div class="dropdown-container">
                    <div class="dropdown">
                        <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                            <span class="current-page">Featured</span>
                            <span class="dropdown-title">Filter By</span>
                        </a>
                        <ul class="dropdown-menu" role="menu">

                            <li role="presentation" class="current-page">
                                <a role="menuitem" href="REPLACE">Featured</a>
                            </li>

                            <li role="presentation" class="">
                                <a role="menuitem" href="REPLACE">Recommended</a>
                            </li>

                            <li role="presentation" class="">
                                <a role="menuitem" href="REPLACE">Calendar</a>
                            </li>

                            <li role="presentation" class="">
                                <a role="menuitem" href="REPLACE">Archive</a>
                            </li>

                        </ul>
                    </div>
                </div>
                <label for="question-search-issue" class="visuallyhidden">Child's Issue</label>
                   <asp:DropDownList name="parentgroupstool-issue"  AppendDataBoundItems="true" DataTextField="Name" DataValueField="Id" ID="ddlChildIssues" aria-required="true" runat="server">
                   </asp:DropDownList>

                <label for="question-search-grade" class="visuallyhidden">Grade</label>
                  <asp:DropDownList name="question-search-grade"  AppendDataBoundItems="true" DataTextField="Name" DataValueField="Id" ID="ddlGrades" aria-required="true" runat="server">                       
                  </asp:DropDownList>


                <label for="question-search-topic" class="visuallyhidden">Topic</label>
                  <asp:DropDownList name="parentgroupstool-topics" DataTextField="Name" AppendDataBoundItems="true" DataValueField="Id" ID="ddlTopics" aria-required="true" runat="server">                                            
                  </asp:DropDownList>

                <asp:Panel runat="server" DefaultButton="btnSearch">
                    <fieldset class="question-search-form">
                        <label for="question-search-text" class="visuallyhidden"><asp:Literal ID="litSearch" runat="server" /></label>
                        <asp:TextBox CssClass="question-search" ID="txtSearch" placeholder="Search" runat="server" />
                        <asp:Button CssClass="search-button" ID="btnSearch" OnClick="btnSearch_Click" runat="server" />
                    </fieldset>
                </asp:Panel>
            </div>
            <sc:Placeholder Key="QuestionsList" runat="server" />

        </div>
    </div>
</div>
