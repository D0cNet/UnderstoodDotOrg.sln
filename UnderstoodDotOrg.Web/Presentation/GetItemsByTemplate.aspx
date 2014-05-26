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
   
            if (rbtLstOptions.SelectedItem != null && !rbtLstOptions.SelectedItem.ToString().IsNullOrEmpty()) {
                Response.Write(rbtLstOptions.SelectedValue.ToString() + "check <br/>");
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
            AddRequiredItem(child);

            root = BuildXmlNodesForChildren(child);
        }
        if (allItem.Any()) {
            ltItemsCount.Text = "Total Items Count - " + allItem.Count().ToString();
            rptItems.DataSource = allItem;
            rptItems.DataBind();
        }
        else {
            ltItemsCount.Text = "No Results Found";
        }
    }
    private void btnSubmit_OnClick(object sender, EventArgs e) {
        //if (!txtTemplateBox.Text.IsNullOrEmpty()) {
        //    templateId = txtTemplateBox.Text;
        if (rbtLstOptions.SelectedItem != null && !rbtLstOptions.SelectedItem.ToString().IsNullOrEmpty()) {
            templateId = rbtLstOptions.SelectedValue.ToString();
            GetAllSitecoreItem();
        }
        //}
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
            <asp:Label runat="server" ID="lblMessage" Text="Please select article type:"></asp:Label>
            <%--<asp:TextBox ID="txtTemplateBox" runat="server" Width="300"></asp:TextBox> &nbsp;&nbsp;--%>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_OnClick"></asp:Button>&nbsp;&nbsp;<br />
            <asp:RadioButtonList ID="rbtLstOptions" runat="server"
                RepeatDirection="Vertical" RepeatLayout="Table">
                <asp:ListItem Text="Landing Page Resource Article Page" Value="{A4D4F492-6782-44B5-89AC-C513065152C5}"></asp:ListItem>
                <asp:ListItem Text="Basic Article Page" Value="{67D1EA88-ECA0-4B4F-BA2A-AD2E83ED4FF0}"></asp:ListItem>
                <asp:ListItem Text="Action Style List Page" Value="{DE610867-BB6C-4E3F-957C-3A340BF028F5}"></asp:ListItem>
                <asp:ListItem Text="Audio Article Page" Value="{F1826F3A-1F30-4D63-8EDC-A0093E185D6A}"></asp:ListItem>
                <asp:ListItem Text="Checklist Article Page" Value="{8EF35E23-A052-4458-A799-4736C7D1F8C5}"></asp:ListItem>
                <asp:ListItem Text="Deep Dive Article Page" Value="{155A3DF6-CE18-4332-A872-7FE10693AECA}"></asp:ListItem>
                <asp:ListItem Text="Infographic Article Page" Value="{BE7A3EE2-B9EE-4ACA-8C61-7EAF22B9E341}"></asp:ListItem>
                <asp:ListItem Text="Simple Expert Article" Value="{30244F7E-3B61-4DB1-B101-622CAE7936D8}"></asp:ListItem>
                <asp:ListItem Text="Slideshow Article Page" Value="{11511214-ECAD-46D7-9370-878299E45BEA}"></asp:ListItem>
                <asp:ListItem Text="Text Only Tips Article Page" Value="{2B01CB7C-78DE-46B8-B1B9-66263F58D343}"></asp:ListItem>
                <asp:ListItem Text="Video Article Page" Value="{D84F2F6F-7B29-49B6-B940-5546CDBBE21B}"></asp:ListItem>
                <asp:ListItem Text="Glossary Page" Value="{CE1AAFB1-90B3-44DF-8F09-38C9B3ACA9C1}"></asp:ListItem>
                <asp:ListItem Text="Toolkit Article Page" Value="{8A8EE8DC-7953-433A-B3B1-79E19B76A9A9}"></asp:ListItem>
            </asp:RadioButtonList>

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
