<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SavedProfileQuestionsControl.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.SavedProfileQuestionsControl" %>
<!-- BEGIN PARTIAL: profile-saved-questions -->
<div class="profile-bar-container skiplink-content" aria-role="main">
    <div class="row">
        <div class="col col-24 centered rs_read_this">
            <ul class="profile-slide">
                <li>
                    <div class="icon support-plan">
                        <a href="REPLACE">
                            <sc:text field="Question 1 Text" runat="server" />
                        </a>
                    </div>
                    <a href="REPLACE" class="rs_skip">
                        <sc:text id="Text1" field="Question 1 Link" runat="server" />
                    </a>
                </li>
                <li>
                    <div class="icon observation-logs">
                        <a href="REPLACE">
                            <sc:text id="Text2" field="Question 2 Text" runat="server" />
                        </a>
                    </div>
                    <a href="REPLACE" class="rs_skip">
                        <sc:text id="Text3" field="Question 2 Link" runat="server" />
                    </a>
                </li>
                <li>
                    <div class="icon childs-world">
                        <a href="REPLACE">
                            <sc:text id="Text4" field="Question 3 Text" runat="server" />
                        </a>
                    </div>
                    <a href="REPLACE" class="rs_skip">
                        <sc:text id="Text5" field="Question 3 Link" runat="server" />
                    </a>
                </li>
            </ul>
        </div>
        <!-- .col col-24 -->
    </div>
    <!-- .row -->
</div>
<!-- .profile-bar-container -->
