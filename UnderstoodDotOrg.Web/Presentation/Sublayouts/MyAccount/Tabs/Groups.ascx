<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Groups.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs.Groups" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container my-account-subheader groups-subheader">
    <div class="row">
        <!-- subheader -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: my-groups-subheader -->
            <div class="row">
                <!-- subheader -->
                <div class="col col-8">
                    <h2 class="rs_read_this"><sc:FieldRenderer ID="frGroups" FieldName="My Groups Text" runat="server"/></h2>
                </div>
                <div class="col col-16">
                    <div class="row" runat="server" id="divDdlGroups">
                        <div class="col push-5 offset-1 my-groups-dropdown-label">
                            <label for="subheadergroups">
                                <span><sc:FieldRenderer ID="frMyGroupsDD" FieldName="My Groups Drop Down Label" runat="server"/></span>
                            </label>
                        </div>
                        <div class="col push-5">
                            <div class="select-container filter-group">
                                <fieldset>
                                    <asp:DropDownList name="my-groups-dropdown" ID="ddlGroups" runat="server" EnableViewState="true" OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END PARTIAL: my-groups-subheader -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container groups-discussion">
    <div class="row">
        <div class="col col-22 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: account-mygroups -->
            <asp:Panel runat="server" ID="pnlGroups" Visible="false">
                <section class="account-mygroups rs_read_this">
                    <div class="row mygroups-header-wrap">
                        <div class="col col-12">
                            <header>
                                <h2><sc:FieldRenderer ID="frRecentDiscussions" FieldName="Recent Discussions Text" runat="server"/></h2>
                            </header>
                        </div>
                        <div class="col col-6 offset-6">
                            <asp:HyperLink CssClass="button start-discussion rs_skip" ID="hypStartADiscussion" runat="server"><sc:FieldRenderer ID="frStartADiscussion" FieldName="Start A Discussion Label" runat="server"/></asp:HyperLink>
                        </div>
                    </div>

                    <div class="row mygroup-grid-header clearfix">
                        <h3 class="col col-15"><sc:FieldRenderer ID="FieldRenderer3" runat="server" FieldName="Discussions Text" /></h3>
                        <h3 class="col col-3 offset-1"><sc:FieldRenderer ID="FieldRenderer2" runat="server" FieldName="Replies Text" /></h3>
                        <h3 class="col col-4 offset-1"><sc:FieldRenderer ID="FieldRenderer1" runat="server" FieldName="Latest Post Text" /></h3>
                    </div>

                    <div class="row mygroup-list clearfix">
                        <asp:Repeater ID="rptComments" runat="server" OnItemDataBound="rptComments_ItemDataBound">
                            <ItemTemplate>
                                <div class="row mygroup-item clearfix repeater-item">
                                    <p class="col col-15 mygroup-title">
                                        <asp:HyperLink ID="hypCommentLink" runat="server"></asp:HyperLink>
                                    </p>
                                    <div class="col col-3 offset-1 reply-count-wrapper">
                                        <span class="reply-count">
                                            <asp:Literal ID="litRepliesCount" runat="server"></asp:Literal>
                                        </span><span class="reply-label"><sc:FieldRenderer ID="FieldRenderer2" runat="server" FieldName="Replies Text" /></span>
                                    </div>
                                    <div class="col col-4 offset-1">
                                        <p class="timestamp">
                                            <span class="lastest-post"><sc:FieldRenderer runat="server" FieldName="Latest Post Text" /></span>
                                            <asp:Literal ID="litCommentTime" runat="server"></asp:Literal>
                                        </p>
                                        <p class="posted-by-name">
                                            <asp:HyperLink ID="hypCommentAuthor" runat="server"></asp:HyperLink>
                                        </p>
                                    </div>
                                </div>
                                <!-- .mygroup-item -->
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <!-- .mygroup-list -->

                    <div class="showmore-footer">
                        <!-- Show More -->
                        <!-- BEGIN PARTIAL: community/show_more -->
                        <!--Show More-->
                        <div class="container show-more rs_skip">
                            <div class="row">
                                <div class="col col-24">
                                    <a class="show-more-link show_more" href="#" data-path="my-account/my-groups" data-container="mygroup-list" data-item="mygroup-item" data-count="2"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreLabel %><i class="icon-arrow-down-blue"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- .show-more -->
                        <!-- END PARTIAL: community/show_more -->
                        <!-- .show-more -->
                    </div>

                </section>
            </asp:Panel>
            <!-- .account-mygroups container -->
            <asp:Panel runat="server" ID="pnlNoGroups" Visible="false">
                <p class="empty">
                    <sc:FieldRenderer ID="frYouHaveNotJoinedAGroup" FieldName="You Have Not Joined A Group Text" runat="server"/>
                </p>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlNoProfile" Visible="false">
                <sc:FieldRenderer ID="frNoCommunityProfile" FieldName="No Community Profile Text" runat="server"/>
            </asp:Panel>
            <!-- END PARTIAL: account-mygroups -->
        </div>
    </div>
    <!-- .row -->
    <div class="row" id="divStartADiscussion" runat="server" visible="false">
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: my-groups-discussion-form -->
            <section class="my-groups-discussion-form clearfix rs_read_this">
                <header>
                    <h2><sc:FieldRenderer ID="FieldRenderer4" FieldName="Start a Discussion With Parents" runat="server"/></h2>
                </header>
                <label>
                    <span class="visuallyhidden">Title of discussion</span>
                    <asp:TextBox ID="txtSubject" ValidationGroup="newDiscussion" placholder="Title of discussion" runat="server"></asp:TextBox>
                </label>
                <label>
                    <span class="visuallyhidden">More detail</span>
                    <asp:TextBox ID="txtBody" ValidationGroup="newDiscussion" placeholder="More detail" runat="server" TextMode="MultiLine"></asp:TextBox>
                </label>
                <asp:Button ID="btnSubmit" CssClass="button start-discussion rs_skip" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </section>

            <!-- END PARTIAL: my-groups-discussion-form -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
<script type="text/javascript">
    var showCount = 3;
    $(document).ready(function () {
        for (var i = showCount; i < $(".repeater-item").length; i++) {
            $(".repeater-item").eq(i).hide();
        }
    });
    $(".show-more-link").click(function () {
        for (var i = showCount; i < showCount + 3; i++) {
            $(".repeater-item").eq(i).show();
        }
        showCount += 3;
    })
</script>
