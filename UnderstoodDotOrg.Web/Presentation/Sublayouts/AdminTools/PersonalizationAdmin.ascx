<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonalizationAdmin.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools.PersonalizationAdmin" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<style type="text/css">
    .article-entry, .article-child {
        margin-bottom: 1em;
    }
    .article-child {
        padding: 30px;
    }
    .article-mappings {
        overflow: hidden;
        font-size: 11px;
    }
    .article-column {
        float: left;
        width: 33%;
    }
</style>

<asp:UpdatePanel ID="pnlSearch" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">

    <ContentTemplate>

        <asp:Label runat="server" AssociatedControlID="txtEmail">Member's Email</asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" />

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />

        <asp:Repeater runat="server" ID="rptInterests" OnItemDataBound="rptInterests_ItemDataBound">
            <HeaderTemplate>
                <h3>Parent Interests:</h3>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li><asp:Literal ID="litInterest" runat="server" /></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>

        <asp:Panel ID="pnlChildren" runat="server" Visible="false">
            Select Child: <asp:DropDownList ID="ddlChildren" runat="server" />
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
            <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="pnlResults">
                <ProgressTemplate>
                    Searching...
                </ProgressTemplate>
            </asp:UpdateProgress>
        </asp:Panel>

    </ContentTemplate>

</asp:UpdatePanel>

<asp:UpdatePanel ID="pnlResults" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSearch" />
    </Triggers>
    <ContentTemplate>

        <div class="article-child">
            <h3><asp:Literal ID="litChild" runat="server" /></h3>
            <asp:Repeater ID="rptIssues" OnItemDataBound="rptIssues_ItemDataBound" runat="server">
                <HeaderTemplate>
                    <h4>Issues:</h4>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><asp:Literal ID="litIssue" runat="server" /></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

            <asp:Repeater ID="rptArticles" runat="server" OnItemDataBound="rptArticles_ItemDataBound">
                <HeaderTemplate>
                    <div class="articles-list">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="article-entry">
                        <h4><asp:HyperLink ID="hlTitle" runat="server"><asp:Literal ID="litTitle" runat="server" /></asp:HyperLink></h4>
                        
                        <div class="article-mappings">
                        <div class="article-column">
                        <asp:Repeater ID="rptArticleGrades" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child.GradeLevelItem">
                            <HeaderTemplate>
                                <h5>Grades:</h5>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><%# Item.Name.Raw %></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                        </div>

                        <div class="article-column">
                        <asp:Repeater ID="rptArticleIssues" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child.ChildIssueItem">
                            <HeaderTemplate>
                                <h5>Issues:</h5>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><%# Item.IssueName.Raw %></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                        </div>

                        <div class="article-column">
                        <asp:Repeater ID="rptArticleInterests" runat="server" ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent.ParentInterestItem">
                            <HeaderTemplate>
                                <h5>Interests:</h5>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><%# Item.InterestName.Raw %></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                        </div>

                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        </ContentTemplate>
    </asp:UpdatePanel>