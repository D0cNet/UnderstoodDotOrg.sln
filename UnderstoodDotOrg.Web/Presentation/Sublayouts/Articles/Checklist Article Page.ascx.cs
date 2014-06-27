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
using UnderstoodDotOrg.Domain.Understood.Quiz;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Membership;
using Newtonsoft.Json;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Checklist_Article_Page : BaseSublayout
    {
        ChecklistArticlePageItem ObjChecklistArticle;
        public string PageUrl = "";
        Quiz savedQuiz = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindData();
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

        public void BindData()
        {
            if (CurrentMember != null)
            {
                try
                {
                    MembershipManager mgr = new MembershipManager();
                    CurrentMember = mgr.QuizResults_FillMember(CurrentMember);
                    savedQuiz = CurrentMember.CompletedQuizes.Where(i => i.QuizID == Sitecore.Context.Item.ID.ToGuid()).FirstOrDefault<Quiz>();
                }
                catch
                {

                }
            }

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

        protected void rptTopicChkbox_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TopicCheckboxItem TopicItem = e.Item.DataItem as TopicCheckboxItem;
            if (TopicItem != null)
            {
                CheckBox cbTopicItem = e.FindControlAs<CheckBox>("cbTopicItem");
                if (TopicItem.ShowCheckbox.Checked == false)
                {
                    if (cbTopicItem != null)
                    {
                        cbTopicItem.Enabled = false;
                    }
                }

                if (savedQuiz != null)
                {
                    QuizItem temp = savedQuiz.MemberAnswers.Where(i =>  i.QuestionId == TopicItem.ID.ToGuid()).FirstOrDefault();
                    if (temp != null)
                    {
                        cbTopicItem.Checked = Convert.ToBoolean(temp.AnswerValue);
                    }
                }

                cbTopicItem.Attributes.Add("data-id", TopicItem.ID.ToString());

                FieldRenderer frTopicItem = e.FindControlAs<FieldRenderer>("frTopicItem");
                if (frTopicItem != null )
                {
                    frTopicItem.Item = TopicItem;
                }
            }
        }

		protected void btnSaveAnswers_Click(object sender, EventArgs e)
		{
            if (IsUserLoggedIn)
            {
                try
                {

                    string JSON = hfKeyValuePairs.Value;
                    Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(JSON);

                    Checklist cl = new Checklist();
                    cl.MemberId = CurrentMember.MemberId;
                    cl.ChecklistID = Sitecore.Context.Item.ID.ToGuid();

                    if (values != null)
                    {
                        foreach (KeyValuePair<string, string> entry in values)
                        {
                            ChecklistItem clItem = new ChecklistItem();

                            clItem.QuestionId = new Guid(entry.Key);
                            clItem.Checked = Convert.ToBoolean(entry.Value);

                            cl.MemberAnswers.Add(clItem);
                        }
                        MembershipManager mgr = new MembershipManager();
                        mgr.ChecklistResults_SaveToDb(cl.MemberId, cl);

                        btnSaveAnswers.Attributes.Add("class", "aspNetDisabled submit button");
                        btnSaveAnswers.Attributes.Add("disabled", "disabled");
                        confirmationText.Visible = true;
                    }
                }
                catch
                {
                    errorText.Visible = true;  
                }
            }
            else
            {
                Response.Redirect(MyAccountFolderItem.GetSignUpPage());
            }

            BindData();
		}	
    }
}