<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepFive.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepFive" %>

<div class="container profile-questions-header-container flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <header class="profile-questions-header">
                <div class="column-left rs_read_this">
                    <!-- BEGIN PARTIAL: profile-questions-header-left -->
                    <h1>
                        <sc:text field="Header Title" runat="server" />
                    </h1>
                    <p class="subtitle">
                        <sc:text field="Header Text" runat="server" />
                    </p>
                    <p class="subtitle">
                        <sc:text field="Take Me Back Text" runat="server" />
                        <a href="REPLACE">
                            <sc:text field="Link Page Title Text" runat="server" />
                        </a>
                    </p>

                    <!-- END PARTIAL: profile-questions-header-left -->
                </div>
                <div class="column-right">
                    <!-- BEGIN PARTIAL: profile-questions-header-right -->
                    <div class="progress-bar-wrapper rs_read_this">
                        <div class="progress-header">
                            <sc:text field="Header Progress Bar Text" runat="server" />
                        </div>
                        <div class="progress-bar step-done rs_skip">
                            <span class="step-1 step" aria-hidden="true" role="presentation">1</span>
                            <span class="step-1-progress progress">
                                <span class="progress-spacer">
                                    <span class="progress-percent"></span>
                                </span>
                            </span>
                            <span class="step-2 step" aria-hidden="true" role="presentation">2</span>
                            <span class="step-2-progress progress">
                                <span class="progress-spacer">
                                    <span class="progress-percent"></span>
                                </span>
                            </span>
                            <span class="step-3 step" aria-hidden="true" role="presentation">3</span>
                            <span class="step-3-progress progress">
                                <span class="progress-spacer">
                                    <span class="progress-percent"></span>
                                </span>
                            </span>
                            <span class="done step" aria-hidden="true" role="presentation">Done</span>
                        </div>
                    </div>
                    <!-- .progress-bar-wrapper -->

                    <!-- END PARTIAL: profile-questions-header-right -->
                </div>
            </header>
        </div>
    </div>
</div>



<div class="container profile-questions-container flush">
    <div class="row">
        <div class="col col-22 offset-1">
            <sc:placeholder id="Placeholder1" key="ProfileQuestions" runat="server" />
            <!-- END PARTIAL: profile-saved-questions -->
        </div>
    </div>
</div>
