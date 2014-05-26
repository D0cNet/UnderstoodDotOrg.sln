<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Text" %>

<%@ Import Namespace="Sitecore.Collections" %>
<%@ Import Namespace="Sitecore.Data.Items" %>

<script runat="server">
    
    string templateId = string.Empty;
    List<Item> allItem = new List<Item>();
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            if (!txtTemplateBox.Text.IsNullOrEmpty()) {
                GetAllSitecoreItem();
            }
        }
    }

    Item siteItem = null;
    private void GetAllSitecoreItem() {
        Sitecore.Data.Database db = Sitecore.Data.Database.GetDatabase("master");
        siteItem = db.GetItem(Sitecore.Context.Site.RootPath);
        if (siteItem != null) {
            GetItems(siteItem);
        }
    }

    private void GetItems(Item siteItem) {
        ChildList childList = siteItem.Children;
        Item root;
        foreach (Item child in childList) {
            if (child != null) {
                AddRequiredItem(child);
                BuildXmlNodesForChildren(child);
            }
        }
        if (allItem.Any()) {
            ltItemsCount.Text = "Total Items Count - " + allItem.Count().ToString();
            rptItems.DataSource = allItem;
            rptItems.DataBind();
        }
    }
    private void btnSubmit_OnClick(object sender, EventArgs e) {
        if (!txtTemplateBox.Text.IsNullOrEmpty()) {
            templateId = txtTemplateBox.Text;
            GetAllSitecoreItem();
        }
    }


    /// <summary>
    /// Recursive method to iterate through all child items and build
    /// XML tree.
    /// </summary>
    /// <param name="parentItem"></param>
    /// <param name="root"></param>
    /// <param name="doc">Initial XML Document item.</param>
    private Item BuildXmlNodesForChildren(Item parentItem) {

        //Iterate though children
        Sitecore.Collections.ChildList childList = parentItem.Children;
        foreach (Item child in childList) {
            if (child != null) {
                AddRequiredItem(child);
                BuildXmlNodesForChildren(child);
            }
        }
        return parentItem;
    }

    private void AddRequiredItem(Item child) {
        if (child.TemplateID.ToString().ToLower().Equals(templateId.ToLower())) {
            allItem.Add(child);
        }
    }

    protected void rptItems_ItemDataBound(object sender, RepeaterItemEventArgs e) {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            Item itm = e.Item.DataItem as Item;
            if (itm != null) {
                Literal ltItemName = (Literal)e.Item.FindControl("ltItemName");
                Literal ltTemplate = (Literal)e.Item.FindControl("ltTemplate");
                Literal ltPath = (Literal)e.Item.FindControl("ltPath");
                Literal litUrl = (Literal)e.Item.FindControl("litUrl");
                if (ltItemName != null) {
                    ltItemName.Text = itm.Name;

                }
                if (litUrl != null) {
                    litUrl.Text = itm.Paths.ContentPath.ToString();
                }
                if (ltTemplate != null) {
                    ltTemplate.Text = itm.TemplateName;

                }

                if (ltPath != null) {
                    //ltPath.Text = itm.Paths.GetFriendlyUrl();
                    ltPath.Text = Sitecore.Links.LinkManager.GetItemUrl(itm);
                }
            }
        }
    }

</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:TextBox ID="txtTemplateBox" runat="server" Width="300"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_OnClick"></asp:Button>&nbsp;&nbsp;
            <asp:Literal ID="ltItemsCount" runat="server"></asp:Literal>
        </div>

        <br />
        <br />

        <div>
            <asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_ItemDataBound">

                <HeaderTemplate>
                    <table style="border: 1px Black solid">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="border: 1px Black solid">
                            <asp:Literal ID="ltItemName" runat="server"></asp:Literal>
                        </td>
                        <td style="border: 1px Black solid">
                            <asp:Literal ID="ltTemplate" runat="server"></asp:Literal>
                        </td>
                        <td style="border: 1px Black solid">
                            <asp:Literal ID="ltPath" runat="server"></asp:Literal>
                        </td>
                        <td style="border: 1px Black solid">
                            <asp:Literal ID="litUrl" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
