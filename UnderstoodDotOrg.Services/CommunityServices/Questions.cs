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

namespace UnderstoodDotOrg.Services.CommunityServices
{
    public static class Questions
    {
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
                                newItem.Fields["Issues"].Value = issues.ToString();
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
