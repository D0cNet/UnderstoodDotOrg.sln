using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.ChecklistArticle;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;
using System.Linq;
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
    public partial class ChecklistArticlePageItem
    {
        public static TreeView GetChecklistTree(ChecklistArticlePageItem ObjChecklistArt)
        {
            TreeView ChildItemsTree = null;
            var ChildItems = ObjChecklistArt.InnerItem.GetChildren(); //.Where(t => t.IsOfType(HeaderCheckboxItem.TemplateId));
            if (ChildItems != null)
            {
                var HeaderItems = ChildItems.Where(t => t.IsOfType(HeaderCheckboxItem.TemplateId));
                foreach (HeaderCheckboxItem HeadItem in HeaderItems)
                {
                    //get topic checkbox item
                    if (HeadItem != null)
                    { // Add Header Topic Node in Tree
                        //check for checkbox
                        TreeNode HeadNode = new TreeNode(HeadItem.Title.ToString(), HeadItem.ID.ToString());
                        if (HeadItem.ShowCheckbox == true)
                        { HeadNode.ShowCheckBox = true; }

                        if (HeadNode != null) ChildItemsTree.CheckedNodes.Add(HeadNode);
                        var TopicItems = HeadItem.InnerItem.GetChildren().Where(t => t.IsOfType(TopicCheckboxItem.TemplateId) && (t.Parent.ID.ToString() == HeadItem.ID.ToString()));
                        if (TopicItems != null)
                        {
                            foreach (TopicCheckboxItem TopicItem in TopicItems)
                            {
                                if (TopicItem != null)
                                {
                                    TreeNode ChildNode = new TreeNode(TopicItem.TopicTitle.ToString(), TopicItem.ID.ToString());
                                    HeadNode.ChildNodes.Add(ChildNode);
                                }

                            }
                        }
                    }

                }
            }
            return ChildItemsTree;

        }

        public static HeaderCheckboxItem GetHeaderCheckboxItem()
        {
            HeaderCheckboxItem HeaderItem = null;
            return HeaderItem;
        }
    }
}