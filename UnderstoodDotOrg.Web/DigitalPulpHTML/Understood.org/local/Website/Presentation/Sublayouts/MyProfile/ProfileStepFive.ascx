<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileStepFive.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile.ProfileStepFive" %>
<div class="container profile-questions flush">
                <div class="row">
                    <div class="col col-22 offset-1">
                        <header class="profile-questions-header">
                            <div class="column-left">
                                <!-- BEGIN PARTIAL: profile-questions-header-left -->
                                <h1><sc:Text Field="Header Title" runat="server" /></h1>
                                <p class="subtitle"><sc:Text Field="Header Text" runat="server" /></p>
                                <p class="subtitle"><sc:Text Field="Take Me Back Text" runat="server" /> <a href="REPLACE"><sc:Text Field="Link Page Title Text" runat="server" /></a></p>

                                <!-- END PARTIAL: profile-questions-header-left -->
                            </div>
                            <div class="column-right">
                                <!-- BEGIN PARTIAL: profile-questions-header-right -->
                                <div class="progress-bar-wrapper">
                                    <div class="progress-header"><sc:Text Field="Header Progress Bar Text" runat="server" /></div>
                                    <div class="progress-bar step-done">
                                        <span class="step-1 step">1</span>
                                        <span class="step-1-progress progress">
                                            <span class="progress-spacer">
                                                <span class="progress-percent"></span>
                                            </span>
                                        </span>
                                        <span class="step-2 step">2</span>
                                        <span class="step-2-progress progress">
                                            <span class="progress-spacer">
                                                <span class="progress-percent"></span>
                                            </span>
                                        </span>
                                        <span class="step-3 step">3</span>
                                        <span class="step-3-progress progress">
                                            <span class="progress-spacer">
                                                <span class="progress-percent"></span>
                                            </span>
                                        </span>
                                        <span class="done step"><sc:Text Field="Header Progress Bar Done Text" runat="server" /></span>
                                    </div>
                                </div>
                                <!-- .progress-bar-wrapper -->

                                <!-- END PARTIAL: profile-questions-header-right -->
                            </div>
                        </header>
                    </div>
                </div>
            </div>



            <div class="container profile-questions flush">
                <div class="row">
                    <div class="col col-22 offset-1">
                        <sc:Placeholder ID="Placeholder1" Key="ProfileQuestions" runat="server" />
                        <!-- END PARTIAL: profile-saved-questions -->
                    </div>
                </div>
            </div>