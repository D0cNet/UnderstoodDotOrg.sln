using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.ChecklistArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Checklist_Article_Page : System.Web.UI.UserControl
    {
        ChecklistArticlePageItem ObjChecklistArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjChecklistArticle = new ChecklistArticlePageItem(Sitecore.Context.Item);
            if (ObjChecklistArticle != null)
            {
                // Create the checklist from base object
                if (ObjChecklistArticle.InnerItem.GetChildren() != null)
                {
                    //Get HeaderItems for Header Repeater
                    List<HeaderCheckboxItem> AllHeaders = ChecklistArticlePageItem.GetAllHeaderItem(ObjChecklistArticle);
                    if (AllHeaders != null)
                    {
                        rptHeaderChkbox.DataSource = AllHeaders;
                        rptHeaderChkbox.DataBind();

                    }
                }
            }
        }
        protected void rptHeaderChkbox_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HeaderCheckboxItem HeadItem = e.Item.DataItem as HeaderCheckboxItem;
            if (HeadItem != null)
            {
                FieldRenderer frHeaderItem = e.FindControlAs<FieldRenderer>("frHeaderItem");
                frHeaderItem.Item = HeadItem;
                List<TopicCheckboxItem> Topics = ChecklistArticlePageItem.GetAllTopicItem(HeadItem);
                if (Topics != null)
                {
                    if (HeadItem.ShowCheckbox.Checked == false)// No checkbox for current header and its topics
                    {
                        CheckBox cbHeaderItem = e.FindControlAs<CheckBox>("cbHeaderItem");
                        cbHeaderItem.Enabled = false;
                        cbHeaderItem.Checked = false;

                    }
                    else
                    {
                        CheckBox cbHeaderItem = e.FindControlAs<CheckBox>("cbHeaderItem");
                        cbHeaderItem.Enabled = true;

                    }

                    Repeater rptTopicChkbox = e.FindControlAs<Repeater>("rptTopicChkbox");
                    rptTopicChkbox.DataSource = Topics;
                    rptTopicChkbox.DataBind();
                }

            }

        }

        protected void rptTopicChkbox_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TopicCheckboxItem TopicItem = e.Item.DataItem as TopicCheckboxItem;
            if (TopicItem != null)
            {
                if (TopicItem.ShowCheckbox.Checked == false)
                {
                    CheckBox cbTopicItem = e.FindControlAs<CheckBox>("cbTopicItem");
                    cbTopicItem.Enabled = false;
                }


                FieldRenderer frTopicItem = e.FindControlAs<FieldRenderer>("frTopicItem");
                frTopicItem.Item = TopicItem;
            }
        }
    }
}