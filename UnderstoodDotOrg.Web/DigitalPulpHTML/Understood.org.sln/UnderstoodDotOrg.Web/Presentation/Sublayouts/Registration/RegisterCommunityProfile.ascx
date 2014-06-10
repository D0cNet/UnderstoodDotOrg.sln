<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegisterCommunityProfile.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Registration.RegisterCommunityProfile" %>
<div class="container registration-profile-container flush">
    <div class="row">
        <div class="col col-16 offset-5 center">
            <!-- BEGIN PARTIAL: registration-profile-create -->
            <div class="registration-profile community-profile">
                <h2>Create your community profile</h2>
                <p class="subtitle">Our community is a safe place to share experiences and advice with people who understand.</p>
                <div class="question-wrapper">
                    <div class="textfields-wrapper">
                        <div class="textfield-wrapper clearfix">
                            <input type="textfield" name="screenname" placeholder="Enter a Screen Name">
                            <div class="why-ask-popover-trigger">
                                <a href="REPLACE" class="why-do-we-ask popover-link">Why do we ask?</a>
                            </div>
                            <div class="popover-container">
                                <span class="title">We ask for a screenname</span> so other parents in the community can offer you support and get connected with you. You can always choose not to connect with other parents.
       
                            </div>
                        </div>
                    </div>
                    <!-- .textfields-wrapper -->
                    <p class="question-description">Understood makes it easy to connect with parents who share your challenges. Are you interested in connect requests from parents like you?</p>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper sign-up-newsletter">
                    <div class="checkbox-wrapper">
                        <label>
                            <input class="no-uniform" type="checkbox" name="newsletter">
                            <span>Yes, I would like to sign up for my personalized newsletter.</span>
                        </label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div class="form-actions">
                    <input type="submit" class="button" value="Join Group">
                    <div class="spacer"></div>
                    <a class="full-profile-link" href="REPLACE">or complete my full profile</a>
                </div>
            </div>
            <!-- .registration-profile -->

            <!-- END PARTIAL: registration-profile-create -->
        </div>
    </div>
</div>
