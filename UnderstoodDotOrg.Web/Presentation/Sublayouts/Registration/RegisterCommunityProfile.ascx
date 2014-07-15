<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegisterCommunityProfile.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Registration.RegisterCommunityProfile" %>

<div class="container registration-profile-container flush">
    <div class="row">
        <div class="col col-16 offset-5 center">
            <!-- BEGIN PARTIAL: registration-profile-create -->
            <div class="registration-profile community-profile skiplink-content rs_read_this" aria-role="main">
                <h1 class="register-community-profile"><%= Model.Header.Rendered %></h1>
                <p class="subtitle"><%= Model.Subtitle.Rendered %></p>
                <div class="question-wrapper">
                    <div class="textfields-wrapper">
                        <div class="textfield-wrapper clearfix">
                            <%--<input type="textfield" name="screenname" placeholder="<%= UnderstoodDotOrg.Common.DictionaryConstants.ScreenNameWatermark %>">--%>
                            <asp:Label ID="lblScreenName" runat="server" AssociatedControlID="txtScreenName"></asp:Label>
                            <asp:TextBox runat="server" ID="txtScreenName"></asp:TextBox>
                            <div class="why-ask-popover-trigger rs_skip">
                                <button class="why-do-we-ask popover-link rs_preserve"><%= Model.WhyDoWeAskLinkText.Rendered %></button>
                            </div>
                            <div class="popover-container rs_skip">
                                <%--<span class="title">We ask for a screenname</span> so other parents in the community can offer you support and get connected with you. You can always choose not to connect with other parents.--%>
                                <%= Model.WhyDoWeAskPopupContent.Rendered %>
                            </div>
                        </div>
                    </div>
                    <!-- .textfields-wrapper -->
                    <p class="question-description"><%= Model.Description.Rendered %></p>
                </div>
                <!-- .question-wrapper -->

                <div class="question-wrapper sign-up-newsletter">
                    <div class="checkbox-wrapper">
                        <label>
                            <%--<input class="no-uniform" type="checkbox" name="newsletter">--%>
                            <asp:CheckBox CssClass="no-uniform" runat="server" name="newsletter" ID="chkNewsletter" />
                            <span><%= Model.NewsletterText.Rendered %></span>
                        </label>
                    </div>
                </div>
                <!-- .question-wrapper -->

                <div>
                    <asp:Literal runat="server" ID="uxErrorMessage"></asp:Literal>
                </div>

                <div class="form-actions">
                    <%--<input type="submit" CssClass="button" value="Join Group">--%>
                    <asp:Button runat="server" CssClass="button rs_skip" Text="" ID="btnRegister" OnClick="btnRegister_Click" />
                    <div class="spacer"></div>
                    <%--<a class="full-profile-link" href="REPLACE">or complete my full profile</a>--%>
                    <asp:HyperLink ID="hypCompleteMyProfile" runat="server" CssClass="full-profile-link rs_skip"></asp:HyperLink>
                </div>
            </div>
            <!-- .registration-profile -->

            <!-- END PARTIAL: registration-profile-create -->
        </div>
    </div>
</div>
