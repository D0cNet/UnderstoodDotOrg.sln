<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SavedProfileQuestionsControl.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.SavedProfileQuestionsControl" %>
    <!-- BEGIN PARTIAL: profile-saved-questions -->
    <div class="profile-bar-container">
        <div class="row">
            <div class="col col-24 centered">
                <ul class="profile-slide">
                    <li>
                        <div class="icon support-plan">
                            <a href="REPLACE"><sc:Text Field="Question 1 Text" runat="server" /></a>
                        </div>
                        <a href="REPLACE"><sc:Text ID="Text1" Field="Question 1 Link" runat="server" /></a>
                    </li>
                    <li>
                        <div class="icon observation-logs">
                            <a href="REPLACE"><sc:Text ID="Text2" Field="Question 2 Text" runat="server" /></a>
                        </div>
                        <a href="REPLACE"><sc:Text ID="Text3" Field="Question 2 Link" runat="server" /></a>
                    </li>
                    <li>
                        <div class="icon childs-world">
                            <a href="REPLACE"><sc:Text ID="Text4" Field="Question 3 Text" runat="server" /></a>
                        </div>
                        <a href="REPLACE"><sc:Text ID="Text5" Field="Question 3 Link" runat="server" /> </a>
                    </li>
                </ul>
            </div>
            <!-- .col col-24 -->
        </div>
        <!-- .row -->
    </div>
    <!-- .profile-bar-container -->