<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonalizationAdmin.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools.PersonalizationAdmin" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<html>
    <head></head>
    <body>

        <form runat="server">

            <link href="/Presentation/includes/css/vendor/bootstrap.css" rel="stylesheet" />
            <link href="/Presentation/includes/css/vendor/ui-lightness/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
            <script src="/Presentation/includes/js/vendor/jquery-1.10.2.min.js" type="text/javascript"></script>
            <script src="/Presentation/includes/js/vendor/jquery-ui-1.10.4.custom.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var $dp = $("#datepicker input");
            $dp.datepicker();

            if ($dp.val() == "") {
                $dp.datepicker('setDate', new Date());
            }
        });
    </script>

            <asp:ScriptManager runat="server" />

<style type="text/css">
    body {
        margin: 5px;
    }
    .article-entry, .article-child {
        margin-bottom: 1em;
    }
    .article-mappings {
        overflow: hidden;
        font-size: 11px;
    }
    .article-column {
        float: left;
        width: 33%;
    }
    h3, h4,  h5 {
        margin: .3em 0;
    }
    ul {
        margin: .5em 0;
    }
    .article-entry {
        margin: 5px;
        padding: 5px;
        border: 1px solid black;
    }
</style>


<div id="datepicker">
    <asp:Label runat="server" AssociatedControlID="txtDate">Date</asp:Label>
    <asp:TextBox ID="txtDate" runat="server" />
</div>

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


<asp:UpdatePanel ID="pnlSearch" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSubmit" />
    </Triggers>
    <ContentTemplate>

        <asp:Panel ID="pnlChildren" runat="server" Visible="false">
            Select Child: <asp:DropDownList ID="ddlChildren" runat="server" data-theme="none" />
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
                        <asp:Repeater ID="rptArticleGrades" runat="server" OnItemDataBound="rptArticleGrades_ItemDataBound">
                            <HeaderTemplate>
                                <h5>Grades:</h5>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><asp:Literal ID="litGrade" runat="server" /></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                        </div>

                        <div class="article-column">
                        <asp:Repeater ID="rptArticleIssues" runat="server" OnItemDataBound="rptArticleIssues_ItemDataBound">
                            <HeaderTemplate>
                                <h5>Issues:</h5>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><asp:Literal ID="litIssue" runat="server" /></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                        </div>

                        <div class="article-column">
                        <asp:Repeater ID="rptArticleInterests" runat="server" OnItemDataBound="rptArticleInterests_ItemDataBound">
                            <HeaderTemplate>
                                <h5>Interests:</h5>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><asp:Literal ID="litInterest" runat="server" /></li>
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

            </form>

        </body>
</html>