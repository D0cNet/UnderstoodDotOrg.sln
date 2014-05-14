﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeaturedQuestions.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA.FeaturedQuestions" %>
<div class="col col-24 featured-parent-questions skiplink-content" aria-role="main">
    <h2>Featured Parent Questions</h2>

    <div class="parent-questions">
        <asp:Repeater ID="questionsRepeater" runat="server">
            <ItemTemplate>
                <!-- BEGIN PARTIAL: community/parent_question_card -->
                <div class="card-parent-question clearfix">
                    <div class="question-image">
                        <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                    </div>
                    <div class="question-info">
                        <a href="REPLACE" class="title"><%# Eval("_title") %></a>
                        <span class="details">In <a href="REPLACE" class="topic"><%# Eval("_group") %></a> - Asked by <a href="REPLACE" class="author"><%# Eval("_author") %></a> <span class="bullet">&bull;</span> <%# Eval("_publishedDate") %></span>
                        <a class="button" href="REPLACE">Follow This Question</a>
                    </div>
                    <div class="question-reply-container">
                        <div class="question-replies"><span class="count-replies"><%# Eval("_commentCount") %></span> replies</div>
                    </div>
                </div>
                <!-- END PARTIAL: community/parent_question_card -->
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <!-- Show More -->
    <!-- BEGIN PARTIAL: community/show_more -->
    <!--Show More-->
    <div class="container show-more">
        <div class="row">
            <div class="col col-24">
                <a class="show-more-link " href="#" data-path="community/parent-questions" data-container="parent-questions" data-item="card-parent-question" data-count="6">Show More<i class="icon-arrow-down-blue"></i></a>
            </div>
        </div>
    </div>
    <!-- .show-more -->
    <!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->

</div>