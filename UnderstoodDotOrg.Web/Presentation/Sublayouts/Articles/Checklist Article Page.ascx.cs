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
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Checklist_Article_Page : System.Web.UI.UserControl
    {
        ChecklistArticlePageItem ObjChecklistArticle;
        public string PageUrl = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ObjChecklistArticle = new ChecklistArticlePageItem(Sitecore.Context.Item);
            if (ObjChecklistArticle != null)
            {
                PageUrl = ObjChecklistArticle.GetUrl();
                if (ObjChecklistArticle.DefaultArticlePage.Reviewedby.Item != null && ObjChecklistArticle.DefaultArticlePage.ReviewedDate.DateTime != null)//Reviwer Name
                    SBReviewedBy.Visible = true;
                else
                    SBReviewedBy.Visible = false;
                if (ObjChecklistArticle.ShowPromotionalControl.Checked == true)
                {
                    sbSidebarPromo.Visible = true;
                }
                else
                {
                    sbSidebarPromo.Visible = false;
                }
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
                
                if (frHeaderItem != null)
                {
                    frHeaderItem.Item = HeadItem;

                    List<TopicCheckboxItem> Topics = ChecklistArticlePageItem.GetAllTopicItem(HeadItem);

                    if (Topics != null)
                    {
                        Repeater rptTopicChkbox = e.FindControlAs<Repeater>("rptTopicChkbox");
                        if (rptTopicChkbox != null)
                        {
                            rptTopicChkbox.DataSource = Topics;
                            rptTopicChkbox.DataBind();
                        }
                    }
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
                    if (cbTopicItem != null)
                    {
                        cbTopicItem.Enabled = false;
                    }
                }

                FieldRenderer frTopicItem = e.FindControlAs<FieldRenderer>("frTopicItem");
                if (frTopicItem != null )
                {
                    frTopicItem.Item = TopicItem;
                }
            }
        }

		protected void btnSaveAnswers_Click(object sender, EventArgs e)
		{
			Item savedAnswersRegistration = Sitecore.Context.Database.GetItem(Constants.Pages.Registration1);
			if (savedAnswersRegistration != null)
			{
				Response.Redirect(savedAnswersRegistration.GetUrl());
			}
		}

		
    }
}