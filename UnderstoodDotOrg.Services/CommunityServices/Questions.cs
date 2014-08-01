using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.SecurityModel;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
namespace UnderstoodDotOrg.Services.CommunityServices
{
    public static class Questions
    {

        public static List<Question> FindQuestions(Member user)
        {

             String [] issues = new List<string>(user.Children.Select(x => x.Issues.Select(k => k.Key.ToString("B").ToUpper())).SelectMany(x=>x)).ToArray();
                String[] grades = new List<string>(user.Children.Select(x => x.Grades.Select(g => g.Key.ToString("B").ToUpper())).SelectMany(x => x)).ToArray() ;
                String[] topics = user.Interests.Select(x => x.Key.ToString("B").ToUpper()).ToArray();
                //String[] states = new string[] { user.zipCodeToState() };
                //String[] partners = new string[0];
                return FindQuestions(issues, topics, grades);
        }
        /// <summary>
        /// Function to return a list of GroupModels based on the search criteria for Groups
        /// </summary>
        /// <param name="issues"></param>
        /// <param name="topic"></param>
        /// <param name="grade"></param>
        /// <param name="states"></param>
        /// <param name="partner"></param>
        /// <returns></returns>
        public static List<Question> FindQuestions(string[] issues, string[] topics, string[] grades)
        {
            List<Question> results = new List<Question>();
            StringBuilder strb = new StringBuilder();
            StringBuilder strValues = new StringBuilder();
            //if (Session["groupItems"] is List<GroupCardModel>)
            //{

            //    //throw new NotImplementedException();
            //    ///TODO: Implement search results
            //    results=(List<GroupCardModel>)Session["groupItems"] ;
            //}
            strb.Append("fast:/sitecore/content/Home//*[@@templateid = '" + Constants.Questions.QuestionTemplateID + "'");
            string AndCondition = " and (";
            string OrCondition = " or ";
            if ((issues.Count() > 0) || topics.Count() > 0 || grades.Count() > 0)
            {

                strValues.Append(AndCondition);

                //Build search string based on parameters
                //Order matters according to Speckle UN-595
                foreach (string issue in issues)
                {

                    strValues.Append(" @Issues= '%" + issue + "%'").Append(OrCondition);

                }


                foreach (string grade in grades)
                {

                    strValues.Append(" @Grade= '%" + grade + "%'").Append(OrCondition);
                }

                foreach (string topic in topics)
                {

                    strValues.Append(" @Topic= '%" + topic + "%'").Append(OrCondition);
                }

                //Clip " or " from last criteria
                strValues.Replace(OrCondition, ")", strValues.Length - OrCondition.Length, OrCondition.Length);
            }

            strb.Append(strValues).Append("]");

            //Use sitecore fast query to perform search
            Item[] questions = Sitecore.Context.Database.SelectItems(strb.ToString());

            results = questions
                .Select(x => QuestionFactory(x))
                .Where(x => x != null)
                //.OrderByDescending(x => x.NumOfMembers)
                .ToList<Question>();

            return results;
        }

        public static Question QuestionFactory(Item item)
        {
            String wikiId = item["WikiId"];
            String contentId = item["ContentId"];
            String wikiPageId = item["WikiPageId"];

            Question question = TelligentService.TelligentService.GetQuestion(wikiId, wikiPageId, contentId);
            if (question != null)
            {
                Sitecore.Data.Fields.MultilistField grades = item.Fields["Grade"];

                if (grades != null)
                {
                    foreach (ID id in grades.TargetIDs)
                    {
                        Item targetItem = Sitecore.Context.Database.Items[id];
                        question.Grade = targetItem.Name;
                    }

                }

                Sitecore.Data.Fields.MultilistField topics = item.Fields["Topic"];

                if (topics != null && topics.Count > 0)
                {
                    //foreach (ID id in topics.TargetIDs)
                    //{
                    // Item targetItem = Sitecore.Context.Database.Items[id];
                    question.Group = topics.TargetIDs.Select(x => Sitecore.Context.Database.Items[x]).FirstOrDefault().Name; //targetItem.Name;
                    //}

                }

                Sitecore.Data.Fields.MultilistField issues = item.Fields["Issues"];

                if (issues != null)
                {
                    foreach (ID id in issues.TargetIDs)
                    {
                        Item targetItem = Sitecore.Context.Database.Items[id];
                        question.Issues.Add(targetItem.Name);
                    }

                }
                Item QAItem = Sitecore.Context.Database.GetItem(ID.Parse(Constants.Pages.QandADetails));
                question.QueryString = "?wikiId=" + wikiId + "&wikiPageId=" + wikiPageId + "&contentId=" + contentId;
                question.Url =QAItem.GetUrl()+ question.QueryString; //"/en/community and events/q and a/q and a details.aspx" +
            }
            return question;
        }

        public static Item CreateSitecoreQuestion(string title, string wikiId, string wikiPageId, string contentId, string grade, string topic, List<String> issues, Language lang)
        {
            Item newItem = null;

            try
            {
                //if (thModel != null && frmItem != null && lang != null)
                {
                    //Again we need to handle security
                    //In this example we just disable it
                    using (new SecurityDisabler())
                    {
                        //First get the parent item from the master database
                        Database masterDb = global:: Sitecore.Configuration.Factory.GetDatabase("master");
                        
                        //get the parent
                        Item parentItem = masterDb.GetItem("{7356A32F-1795-4EAE-BE24-EBBD79B3093C}", lang);

                        if (parentItem != null)
                        {
                            //Now we need to get the template from which the item is created (Forum Thread Template)
                            TemplateItem template = masterDb.GetTemplate(UnderstoodDotOrg.Common.Constants.Questions.QuestionTemplateID);

                            //newItem = masterDb.GetItem(parentItem.Paths.Path + "/" + title, lang);
                            //if (newItem == null)
                            {
                                //Now we can add the new item as a child to the parent
                                newItem = parentItem.Add(title, template);
                            }

                            //We can now manipulate the fields and publish as in the previous example
                            //Item item = masterDb.GetItem(newItem);
                            //Begin editing
                            newItem.Editing.BeginEdit();
                            try
                            {
                                //perform the editing
                                newItem.Fields["WikiId"].Value = wikiId;
                                newItem.Fields["WikiPageId"].Value = wikiPageId;
                                newItem.Fields["ContentId"].Value = contentId;
                                newItem.Fields["Grade"].Value = grade;
                                newItem.Fields["Topic"].Value = topic;

                                Sitecore.Data.Fields.MultilistField issuesField = newItem.Fields["Issues"];

                                foreach(var issue in issues)
                                {
                                    issuesField.Add(issue);
                                }

                                //newItem.Fields["Issues"].SetValue = issuesField;
                                // errorState = true;
                            }
                            catch (Exception ex)
                            {
                                // errorState = false;
                                throw ex;
                            }
                            finally
                            {
                                //Close the editing state
                                newItem.Editing.EndEdit();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Error with :" + ItemName + " (" + lang.Name + ")\n Details:\n" + ex.Message));
                Sitecore.Diagnostics.Error.LogError("Error with Question:" + wikiPageId + " (" + lang.Name + ")\n Details:\n" + ex.Message);
                newItem = null;
            }

            return newItem;
        }

        public static Question GetQuestion(string wikiId, string wikiPageId, string contentId)
        {
            List<Question> results = new List<Question>();
            StringBuilder strb = new StringBuilder();
            StringBuilder strValues = new StringBuilder();
            //if (Session["groupItems"] is List<GroupCardModel>)
            //{

            //    //throw new NotImplementedException();
            //    ///TODO: Implement search results
            //    results=(List<GroupCardModel>)Session["groupItems"] ;
            //}
            strb.Append("fast:/sitecore/content/Home//*[@@templateid = '" + Constants.Questions.QuestionTemplateID + "'");
            string AndCondition = " and (";
            string OrCondition = " or ";
            if (!String.IsNullOrEmpty(wikiId) && !String.IsNullOrEmpty(wikiPageId))
            {

                strValues.Append(AndCondition);

                //Build search string based on parameters
                //Order matters according to Speckle UN-595
                strValues.Append(" @WikiId= '%" + wikiId + "%'").Append(" and ");
                strValues.Append(" @WikiPageId= '%" + wikiPageId + "%'").Append(" )");
                //strValues.Append(" @ContentId= '%" + contentId + "%'").Append(AndCondition);

                //Clip " or " from last criteria
                strValues.Replace(OrCondition, ")", strValues.Length - OrCondition.Length, OrCondition.Length);
            }

            strb.Append(strValues).Append("]");

            //Use sitecore fast query to perform search
            Item[] questions = Sitecore.Context.Database.SelectItems(strb.ToString());

            results = questions
                .Select(x => QuestionFactory(x))
                .Where(x => x != null)
                //.OrderByDescending(x => x.NumOfMembers)
                .ToList<Question>();

            return results.FirstOrDefault<Question>();

        }
        public static List<Question> RecentQuestions(int listCount)
        {
            List<Question> q = new List<Question>();
            Item QAItem = Sitecore.Context.Database.GetItem(ID.Parse(Constants.Pages.QandADetails));
            if (QAItem.HasChildren)
            {
                q = QAItem.Children.Select(question => QuestionFactory(question))
                                    //.Where(question => question != null)
                                    //.OrderByDescending(question => int.Parse(question.CommentCount))
                                    //.ThenByDescending(question => Convert.ToDateTime(question.Date))
                                    .Take(listCount)
                                    .ToList<Question>();
            }

            return q;


        }
    }
}
