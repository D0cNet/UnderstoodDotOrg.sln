<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Group Discussion.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Group_Discussion" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ConnectButton.ascx" TagPrefix="uc1" TagName="ConnectButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ThanksButton.ascx" TagPrefix="uc1" TagName="ThanksButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/ThinkingOfYouButton.ascx" TagPrefix="uc1" TagName="ThinkingOfYouButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/LikeButton.ascx" TagPrefix="uc1" TagName="LikeButton" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/Cards/ProfileCommentCard.ascx" TagPrefix="uc1" TagName="ProfileCommentCard" %>

<!-- BEGIN PARTIAL: community/main_header -->

<!-- END PARTIAL: community/main_header -->
<script>
    jQuery(document).ready(function () {
        jQuery("a").click(
               function (evt) {
                   if (jQuery(this).attr("href").indexOf("REPLACE") > -1) {

                       alert("Link not implemented!");
                       return false;

                   }
               });
      
            var helpfulInProgress = false;

     

            function helpful_clickHandler(e) {
                e.preventDefault();
                var self = this;

                if (helpfulInProgress) {
                    return;
                }

                helpfulInProgress = true;

                var data = {
                    'contentId': $(this).data('content-id'),
                    'contentTypeId': $(this).data('content-type-id')
                };

                $.ajax({
                    url: $(".likes").data('endpoint') + 'FoundReplyHelpful',
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(data),
                    method: 'POST'
                }).done(function (data) {

                    var result = data.d;

                    if (result.IsSuccessful) {
                        $(self).find('p').html(result.HelpfulCount.toString());
                    } else {
                        // TODO: display error or redirect to login?
                    }
                }).always(function () {
                    helpfulInProgress = false;
                });
                return false;
            }

            $("button.likes").click(helpful_clickHandler);

    


    });

</script>
<div class="container">
    <div class="row">
        <div class="container">
            <header class="groups-heading">
                <!-- BEGIN PARTIAL: community/breadcrumb_menu -->
                <!--breadcrumb menu-->
                <a href="REPLACE" runat="server" id="hrfBack" class="back-to-previous rs_skip">
                    <i class="icon-arrow-left-blue"></i>
                    <asp:Literal ID="litBack" Text="" runat="server" />
                </a>
                <!-- END PARTIAL: community/breadcrumb_menu -->
                <!-- BEGIN PARTIAL: community/groups_private_heading -->
                <!--groups private partial-->
                <div class="col groups-private">
                    <p class="col"><%= UnderstoodDotOrg.Common.DictionaryConstants.OnlyMembersCanSeeLabel %></p>
                    <i class="icon"></i>
                </div>
                <!-- END PARTIAL: community/groups_private_heading -->
            </header>
            <div class="col col-24 skiplink-content" aria-role="main">
                <div class="col col-18 discussion-list">
                    <header class="col title rs_read_this">
                        <h2>
                            <asp:Label ID="lblSubject" runat="server"></asp:Label></h2>
                    </header>
                    <!-- BEGIN PARTIAL: community/groups_discussion_post -->
                    <!--Groups Discussion-Post-->
                    <div class="discussion-post clearfix rs_read_this">
                        <div class="col col-4 discussion-contributer">
                            <%--OP--%>
                            <uc1:ProfileCommentCard runat="server" id="ProfileCommentCard" />
                        </div>
                        <div class="discussion-comment">
                            <p>
                                <asp:Literal Text="" ID="litComment" runat="server" />
                            </p>
                        </div>
                        <footer class="discussion-footer rs_skip">
                            <h4><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowYourSupportLabel %></h4>
                            <ul class="support-menu">
                                <li>
                                    <uc1:ThanksButton runat="server" ID="ThanksButton" />
                                </li>
                                <li>
                                    <uc1:ThinkingOfYouButton runat="server" ID="ThinkingOfYouButton" />
                                </li>
                                <li>
                                    <uc1:LikeButton runat="server" ID="LikeButton" />
                                </li>
                            </ul>
                        </footer>
                        <%-- <sc:SubLayout ID="sbDiscussioinList" Path="~/Presentation/Sublayouts/Common/GroupDiscussionList.ascx" runat="server"></sc:SubLayout>--%>
                    </div>

                    <asp:PlaceHolder ID="plhGroupDiscussions" runat="server"></asp:PlaceHolder>


                    <!--Groups Discussion-Post-->

                    <!-- END PARTIAL: community/groups_discussion_post -->

                    <!--Groups Discussion-Post-->


                </div>
                <!-- end .discussion-list -->
                <div class="col col-4 offset-1 discussion-sidebar rs_read_this">
                    <div class="discussion-meta skiplink-sidebar">
                        <div class="discussion">
                            <i class="number-bubble-icon">
                                <asp:Literal ID="litMemberCount" runat="server"></asp:Literal></i>
                            <p class="parents-in-discussion"><%= UnderstoodDotOrg.Common.DictionaryConstants.ParentsInThisDiscussionLabel %></p>
                        </div>
                        <!-- end .discussion -->
                        <div class="replies">
                            <i class="replies-bubble-icon">
                                <asp:Literal Text="" ID="litNumReplies" runat="server" /></i>
                            <p class="replies"><%= UnderstoodDotOrg.Common.DictionaryConstants.RepliesLabel %></p>
                        </div>
                        <!-- end .replies -->
                        <p class="something-to-add"><%= UnderstoodDotOrg.Common.DictionaryConstants.DoYouHaveSomethingToAddLabel %></p>
                        <a href="#joinlink" class="button rs_skip"><%= UnderstoodDotOrg.Common.DictionaryConstants.JoinDiscussionLabel %></a>
                    </div>
                    <!-- end .discussion-meta -->
                </div>
                <!-- end .discussion-sidebar -->
            </div>
            <div class="col col-16 offset-2 join-discussion" id="joinlink">
                <fieldset>
                    <label for="join-discussion-text" class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.JoinDiscussionLabel %></label>
                    <%--<textarea class="comment" id="join-discussion-text" placeholder="Join the discussion"></textarea>--%>
                    <asp:TextBox CssClass="comment" Columns="40" Rows="40" ID="txtBody" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<a href="REPLACE" class="button rs_skip">Submit</a>--%>
                    <asp:LinkButton CssClass="button rs_skip" OnClick="lbSubmitReply_Click" Text="<%# UnderstoodDotOrg.Common.DictionaryConstants.SubmitButtonText %>" ID="lbSubmitReply" runat="server" />
                </fieldset>
            </div>
            <!-- end .join-discussion -->
        </div>
    </div>
</div>

