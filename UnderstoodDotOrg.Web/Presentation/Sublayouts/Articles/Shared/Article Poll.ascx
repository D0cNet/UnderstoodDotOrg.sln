<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Article Poll.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.Article_Poll" %>

<!-- BEGIN PARTIAL: article-poll -->
<section class="article-poll">

    <div class="poll-question">
        <div class="poll-question-left">
            <h3>Reader Poll</h3>
            <img class="foo" alt="FPO content image" src="http://placehold.it/190x107&amp;text=190x107" />
        </div>
        <!-- .poll-question-left -->
        <div class="poll-question-right">
            <div class="help-me"><a href="REPLACE">Help me decide</a></div>
            <fieldset>
                <legend>Are you considering Ritalin for your child?</legend>
                <label for="article-poll-answer1">
                    <input type="radio" id="article-poll-answer1" name="article-poll-answer">
                    Yes</label>
                <label for="article-poll-answer2">
                    <input type="radio" id="article-poll-answer2" name="article-poll-answer">
                    No</label>
            </fieldset>
        </div>
        <!-- .poll-question-right -->
    </div>
    <!-- .poll-question -->

    <div class="poll-results">
        <h3>Are you considering Ritalin for your child?</h3>

        <div class="row poll-result poll-result-1">
            <div class="col col-3">
                <div class="poll-answer poll-answer-1">Yes</div>
            </div>
            <div class="col col-18">
                <div class="poll-bar poll-bar-1" style="width: 16%; background-color: #406aad;">&nbsp;</div>
            </div>
            <div class="col col-3">
                <div class="poll-percent poll-percent-1">16%</div>
            </div>
        </div>

        <div class="row poll-result poll-result-2">
            <div class="col col-3">
                <div class="poll-answer poll-answer-2">No</div>
            </div>
            <div class="col col-18">
                <div class="poll-bar poll-bar-2" style="width: 84%; background-color: #59ab7e;">&nbsp;</div>
            </div>
            <div class="col col-3">
                <div class="poll-percent poll-percent-2">84%</div>
            </div>
        </div>

        <hr>
        <div class="poll-footer">
            <div class="poll-footer-left">
                <span>567</span> Responses
     
            </div>
            <div class="poll-footer-right">
                <p>Find Out More</p>
                <p><a href="REPLACE">10 Tips to Help Kids Get Organized</a></p>
                <p><a href="REPLACE">How to Build a Homework Plan</a></p>
            </div>
        </div>
        <!-- .poll-footer -->
    </div>
    <!-- .poll-results -->

</section>
<!-- .article-poll -->