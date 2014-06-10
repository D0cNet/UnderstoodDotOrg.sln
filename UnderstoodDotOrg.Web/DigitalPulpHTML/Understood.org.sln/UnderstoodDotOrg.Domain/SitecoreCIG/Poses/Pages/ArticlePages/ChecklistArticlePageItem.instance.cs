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
    

        public static HeaderCheckboxItem GetHeaderCheckboxItem()
        {
            HeaderCheckboxItem HeaderItem = null;
            return HeaderItem;
        }
        public static List<HeaderCheckboxItem> GetAllHeaderItem(ChecklistArticlePageItem ObjChkArt)
        {
           IEnumerable<Item> AllHeader = ObjChkArt.InnerItem.GetChildren().Where(t => t.TemplateID.ToString() == HeaderCheckboxItem.TemplateId.ToString());
           List<HeaderCheckboxItem> FinalHeadsers = new List<HeaderCheckboxItem>();
           foreach (HeaderCheckboxItem hNode in AllHeader)
           {
               FinalHeadsers.Add(hNode);
           }
           return FinalHeadsers;
        }
        public static List<TopicCheckboxItem> GetAllTopicItem(HeaderCheckboxItem ObjHeaderChk)
        {
            IEnumerable<Item> AllTopic = ObjHeaderChk.InnerItem.GetChildren().Where(t => t.TemplateID.ToString() == TopicCheckboxItem.TemplateId.ToString());
            List<TopicCheckboxItem> Topics = new List<TopicCheckboxItem>();
            foreach (TopicCheckboxItem  tNode in AllTopic)
            {
                Topics.Add(tNode);
            }
            return Topics;
        }
        public static Item[][] GetChecklistItems(ChecklistArticlePageItem ObjChkArt)
        {
            Item[][] AllChilds=null;
            List<HeaderCheckboxItem> AllHeaders = GetAllHeaderItem(ObjChkArt);
            if (AllHeaders != null && AllHeaders.Count() > 0)
            {
                AllChilds = new Item[AllHeaders.Count()][];
                for (int hcnt = 0; hcnt < AllHeaders.Count() - 1; hcnt++)
                {
                    //AllChilds[hcnt]=AllHeaders[hcnt];
                    List<TopicCheckboxItem> AllTopics = GetAllTopicItem(AllHeaders[hcnt]);
                    if (AllTopics != null && AllTopics.Count() > 0)
                        AllChilds[hcnt] = new Item[AllTopics.Count()];
                    else
                        AllChilds[hcnt] = new Item[0];

                }
            }
            return AllChilds;
        }
    }
}