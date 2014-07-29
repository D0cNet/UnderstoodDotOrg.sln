using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
//using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Services.CommunityServices;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Modals
{
    public partial class CommunityQAQuestionAsked : BaseSublayout
    {
        protected override void OnInit(EventArgs e)
        {
            litClose.Text = UnderstoodDotOrg.Common.DictionaryConstants.CloseText;
            litCancel.Text = UnderstoodDotOrg.Common.DictionaryConstants.CancelButtonText;
            litCancel2.Text = UnderstoodDotOrg.Common.DictionaryConstants.CancelButtonText;
            litChildsGradeText.Text = UnderstoodDotOrg.Common.DictionaryConstants.ChildsGradeLabel;
            litQuestionText.Text = UnderstoodDotOrg.Common.DictionaryConstants.QuestionTopicLabel;

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String search = Server.UrlDecode(Request.QueryString["search"]);

                List<Question> questions = TelligentService.GetQuestionsList(2, 100);

                if (!String.IsNullOrEmpty(search))
                {
                    questions = questions.Where(x => Server.HtmlDecode(x.Title).ToLower().Contains(search.ToLower())).ToList();
                }

                if (questions.Count <= 3)
                {
                    divShowMore.Visible = false;
                }

                questionsRepeater.DataSource = questions;
                questionsRepeater.DataBind();


            }

            //don't do this, and we won't have anything to save...
            this.DoSetup();
        }

        protected void DoSetup()
        {
            Item currItem = Sitecore.Context.Item;

            Item[] items = null;

            //Grades Drop List
            Sitecore.Data.Fields.MultilistField grades = currItem.Fields["Grades"];
            if (grades != null)
            {
                ddlGrades.Items.Insert(0, new ListItem() { Text = DictionaryConstants.NoneOfTheseLabel, Value = string.Empty });

                items = grades.GetItems();
                //ddlGrades.Items.Add(new ListItem() { Text = DictionaryConstants.GradesLabel, Value = "" });
                foreach (var item in items)
                {
                    ddlGrades.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString().Equals("{7DD838FD-8BD3-4861-8E1E-540E6ED9BBE9}") ? string.Empty : item.ID.ToString() });
                }

                ddlGrades.DataBind();
            }


            //Topic Drop List
            Sitecore.Data.Fields.MultilistField topics = currItem.Fields["Topics"];
            if (topics != null)
            {
                ddlTopics.Items.Insert(0, new ListItem() { Text = DictionaryConstants.NoneOfTheseLabel, Value = string.Empty });

                items = topics.GetItems();
                //ddlTopics.Items.Add(new ListItem() { Text = DictionaryConstants.TopicsLabel, Value = "" });
                foreach (var item in items)
                {
                    ddlTopics.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                }

                ddlTopics.DataBind();
            }

            Sitecore.Data.Fields.MultilistField issues = currItem.Fields["Issues"];

            if (issues != null)
            {
                items = issues.GetItems();

                var dbIssues = items.Select(x => new ChildIssueItem(x));

                uxIssues.DataSource = dbIssues;
                uxIssues.DataBind();

            }

        }

        protected void uxIssues_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var checkbox = e.Item.FindControl("uxIssueCheckbox") as CheckBox;
            var hidden = e.Item.FindControl("uxIssueHidden") as HiddenField;
            var item = ((ChildIssueItem)e.Item.DataItem);

            if (checkbox != null && hidden != null)
            {
                /*
                //if editing, check to see if this is already selected for the kid
                if (status == Constants.QueryStrings.Registration.ModeEdit)
                {
                    if (singleChild.Issues.ToList().Exists(x => x.Key == Guid.Parse(item.ID.ToString())))
                    {
                        checkbox.Checked = true;
                    }
                }
                */

                checkbox.Attributes.Add("value", ((ChildIssueItem)e.Item.DataItem).ID.ToString());
                hidden.Value = item.ID.ToString();
            }

        }

        protected void SubmitQuestionButton_Click(object sender, EventArgs e)
        {
            var title = QuestionTitleTextBox.Text;
            var body = EnterQuestionTextBox.Text;

            string topic = String.IsNullOrEmpty(ddlTopics.SelectedValue.ToString()) ? String.Empty : ddlTopics.SelectedValue.ToString();

            string grade = String.IsNullOrEmpty(ddlGrades.SelectedValue.ToString()) ? String.Empty : ddlGrades.SelectedValue.ToString(); 

            var user = "";
            try
            {
                if (this.CurrentMember.ScreenName != String.Empty || this.CurrentMember.ScreenName != null)
                {
                    user = this.CurrentMember.ScreenName;
                }
            }
            catch
            {
                user = "admin";
            }

            List<string> issues = new List<string>();

            //save selected issues
            foreach (var item in uxIssues.Items)
            {
                var checkbox = item.FindControl("uxIssueCheckbox") as CheckBox;
                var hidden = item.FindControl("uxIssueHidden") as HiddenField;

                if (checkbox.Checked)
                {
                    issues.Add(hidden.Value);
                    //singleChild.Issues.Add(new Issue() { Key = Guid.Parse(checkbox.Attributes["value"]) });
                    //singleChild.Issues.Add(new Issue() { Key = Guid.Parse(hidden.Value) });
                }
            }

            var newQuestion = TelligentService.CreateQuestion(title, body, grade, topic, issues, user);

            if (newQuestion != null)
            {
                var url = "/en/Community and Events/Q and A/Q and A Details.aspx" + newQuestion.QueryString;

                Item item = Questions.CreateSitecoreQuestion(title, newQuestion.WikiId, newQuestion.WikiPageId, newQuestion.ContentId, grade, topic, issues, Sitecore.Context.Language);

                if (item != null)
                {
                    //error_msg.Visible = false;

                    //Redirect to discussion
                    //Publish thread item
                    PublishItem(item);
                    //Sitecore.Web.WebUtil.Redirect(Sitecore.Links.LinkManager.GetItemUrl(threadItem));
                    ///  clientsideScript("alert('" +String.Format( DictionaryConstants.ForumCreateConfirmation,subject)+"');");
                    //Page.Response.Redirect(Page.Request.Url.ToString(), false);
                }

                Response.Redirect(url);

            }
            else
            {
                //The assumption is that if the Thread is null, then there was an error in telligent API call and nothing was created
                //error_msg.Text = DictionaryConstants.FailedToCreateDiscussionError;
                //error_msg.Visible = true;
                //ShowClientSideForm(HiddenText);
            }
            

        }

        /// <summary>
        /// Function taken from http://briancaos.wordpress.com/2011/01/14/create-and-publish-items-in-sitecore/
        /// </summary>
        /// <param name="item"></param>
        private void PublishItem(Sitecore.Data.Items.Item item)
        {
            // The publishOptions determine the source and target database,
            // the publish mode and language, and the publish date
            Sitecore.Publishing.PublishOptions publishOptions =
              new Sitecore.Publishing.PublishOptions(item.Database,
                                                     Sitecore.Data.Database.GetDatabase("web"),
                                                     Sitecore.Publishing.PublishMode.SingleItem,
                                                     item.Language,
                                                     System.DateTime.Now);  // Create a publisher with the publishoptions
            Sitecore.Publishing.Publisher publisher = new Sitecore.Publishing.Publisher(publishOptions);

            // Choose where to publish from
            publisher.Options.RootItem = item;

            // Publish children as well?
            publisher.Options.Deep = true;

            // Do the publish!
            publisher.Publish();
        }
 
        protected void questionsRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            var item = (Question)e.Item.DataItem;
            HyperLink hypUserProfileLink = (HyperLink)e.Item.FindControl("hypUserProfileLink");

            hypUserProfileLink.NavigateUrl = MembershipHelper.GetPublicProfileUrl(item.Author);
        }

    }
}