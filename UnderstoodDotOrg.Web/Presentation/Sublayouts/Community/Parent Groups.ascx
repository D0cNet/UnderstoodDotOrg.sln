<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Parent Groups.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Groups" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/GroupSummaryList.ascx" TagPrefix="GroupSummaryList" TagName="GroupSummaryList" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

 <div class="container group-summary-wrapper skiplink-content parent-groups">
    <div class="row">
      <div class="container">
            <header class="groups-heading rs_read_this">
                <div class="col title">
                    <h2>
                        <asp:Literal ID="litParentGroupsLabel" runat="server" /><span></span></h2>
                </div>
                <div class="col show-groups rs_skip">
                    <a href="REPLACE" id="ref_recommended_group" runat="server">
                        <asp:Literal ID="litShowGroupsMatchLabel" runat="server" /></a>
                </div>
                <!-- BEGIN PARTIAL: community/groups_private_heading -->
                <!--groups private partial-->
                <div class="col groups-private">
                    <p class="col">
                        <asp:Literal ID="litGroupsPrivacyLabel" runat="server" />
                    </p>
                    <i class="icon"></i>
                </div>

                <!-- END PARTIAL: community/groups_private_heading -->
            </header>
                <div class="col-24 parentgroups-tool clearfix skiplink-toolbar">
                    <div class="parentgroups-form rs_read_this">

                        <asp:DropDownList name="parentgroupstool-issue" AppendDataBoundItems="true" DataTextField="Name" DataValueField="Id" ID="ddlChildIssues" aria-required="true" runat="server">
                        </asp:DropDownList>


                        <asp:DropDownList name="parentgroupstool-grade" AppendDataBoundItems="true" DataTextField="Name" DataValueField="Id" ID="ddlGrades" aria-required="true" runat="server">
                        </asp:DropDownList>



                        <asp:DropDownList name="parentgroupstool-topics" DataTextField="Name" AppendDataBoundItems="true" DataValueField="Id" ID="ddlTopics" aria-required="true" runat="server">
                        </asp:DropDownList>


                        <asp:DropDownList name="parentgroupstool-state" DataTextField="Name" AppendDataBoundItems="true" DataValueField="Id" ID="ddlStates" aria-required="true" runat="server">
                        </asp:DropDownList>

                        <asp:DropDownList name="parentgroupstool-partner" DataTextField="Name" AppendDataBoundItems="true" DataValueField="Id" ID="ddlPartners" aria-required="true" runat="server">
                        </asp:DropDownList>
                        <div class="submit-button-wrap">
                            <%--<input class="button rs_skip" type="submit" value="Search">--%>
                            <asp:Button CssClass="button rs_skip" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                        </div>

                    </div>
                </div>
        </div>
    </div>
        <div class="group-summary-container">
            <div class="row skiplink-content">
                <!-- BEGIN PARTIAL: community/group_summary -->
                <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="linkShowMore" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <GroupSummaryList:GroupSummaryList runat="server" ID="rptGroupCards" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- END PARTIAL: community/group_summary -->
        </div>
    <!-- BEGIN PARTIAL: community/show_more -->
    <!--Show More-->
    <div class="container show-more rs_skip">
        <div class="row">
            <div class="col col-24">
                <asp:LinkButton ID="linkShowMore" runat="server" OnClick="ShowMore" >
                <%--<a runat="server" id="linkShowMore" onserverclick="ShowMore" href="#" data-path="community/group-summary" data-container="group-summary-container" data-item="row" data-count="6">--%>
                    <asp:Literal ID="litShowMore" runat="server" /><i class="icon-arrow-down-blue"></i></asp:LinkButton>
            </div>
        </div>
    </div>
    <!-- .show-more -->
    <!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->
</div>
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.8;">
            <span style="border-width: 0px; position: fixed; padding: 50px; background-color: #FFFFFF; font-size: 36px; left: 40%; top: 40%;">Loading...</span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>


<sc:Sublayout ID="Sublayout1" runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
