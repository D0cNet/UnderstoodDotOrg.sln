using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Services.Models.Telligent;

namespace UnderstoodDotOrg.Services.CommunityServices
{
    public static class Questions
    {
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

            if (topics != null)
            {
                foreach (ID id in topics.TargetIDs)
                {
                    Item targetItem = Sitecore.Context.Database.Items[id];
                    question.Group = targetItem.Name;
                }

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
    }
}
