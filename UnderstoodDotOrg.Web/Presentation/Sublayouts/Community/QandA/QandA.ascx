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
                <select name="question-search-issue" id="question-search-issue" aria-required="true">
                    <option value="">Child's Issue</option>
                    <option>Issue 1</option>
                    <option>Issue 2</option>
                    <option>Issue 3</option>
                    <option>Issue 4</option>
                </select>

                <label for="question-search-grade" class="visuallyhidden">Grade</label>
                <select name="question-search-grade" id="question-search-grade" aria-required="true">
                    <option value="">Grade</option>
                    <option>Grade 1</option>
                    <option>Grade 2</option>
                    <option>Grade 3</option>
                    <option>Grade 4</option>
                </select>

                <label for="question-search-topic" class="visuallyhidden">Topic</label>
                <select name="question-search-topic" id="question-search-topic" aria-required="true">
                    <option value="">Topic</option>
                    <option>Topic 1</option>
                    <option>Topic 2</option>
                    <option>Topic 3</option>
                    <option>Topic 4</option>
                </select>

                <fieldset class="question-search-form">
                    <label for="question-search-text" class="visuallyhidden">Search</label>
                    <input type="text" class="question-search" id="question-search-text" name="search-term" placeholder="Search" />
                    <input class="search-button" type="submit" value="Go">
                </fieldset>
            </div>
            <sc:Placeholder Key="QuestionsList" runat="server" />

        </div>
    </div>
</div>
