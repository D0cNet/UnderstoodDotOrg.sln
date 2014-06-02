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

namespace UnderstoodDotOrg.Framework.UI.Discussions
{
    public static class Discussion
    {
        public static Item CreateSitecoreForumThread(ThreadModel thModel, string frmItemID, Language lang)
        {
            Item forumItem = ConvertForumIDtoSitecoreItem(frmItemID);
            return CreateSitecoreForumThread(thModel, forumItem, lang);
           

        }
        public static Item CreateSitecoreForumThread(ThreadModel thModel, ForumItem frmItem, Language lang)
        {
           
            Item newItem = null;
            try
            {
                if (thModel != null && frmItem != null && lang != null)
                {
                    //Again we need to handle security
                    //In this example we just disable it
                    using (new SecurityDisabler())
                    {
                        //First get the parent item from the master database
                        Database masterDb = global:: Sitecore.Configuration.Factory.GetDatabase("master");
                        Item parentItem = masterDb.Items[frmItem.InnerItem.Paths.Path, lang];


                        //Now we need to get the template from which the item is created (Forum Thread Template)
                        TemplateItem template = masterDb.GetTemplate(ThreadModel.TemplateID);

                        //StringBuilder sb = new StringBuilder(ItemName.Trim());

                        // string newName = ItemName.Replace('.', '_');//.Substring(0, ItemName.LastIndexOf("."));
                        // if(newName.Contains("."))
                        //     newName=newName.Substring(newName.IndexOf(".") + 1);

                         newItem = masterDb.GetItem(parentItem.Paths.Path + "/" + thModel.Subject, lang);
                        if (newItem == null)
                        {
                            //Now we can add the new item as a child to the parent
                            newItem = parentItem.Add(thModel.Subject, template);
                        }


                        //We can now manipulate the fields and publish as in the previous example
                        //Item item = masterDb.GetItem(newItem);
                        //Begin editing
                        newItem.Editing.BeginEdit();
                        try
                        {
                            //perform the editing
                            newItem.Fields["ForumID"].Value = thModel.ForumID;
                            newItem.Fields["ThreadID"].Value = thModel.ThreadID;
                            newItem.Fields["Body"].Value = thModel.Body;
                            newItem.Fields["Subject"].Value = thModel.Subject;
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
            catch (Exception ex)
            {
                //Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Error with :" + ItemName + " (" + lang.Name + ")\n Details:\n" + ex.Message));
                Sitecore.Diagnostics.Error.LogError("Error with :" + thModel.Subject + " (" + lang.Name + ")\n Details:\n" + ex.Message);
                newItem = null;
            }

            return  newItem ;
        }
        public static Item ConvertForumIDtoSitecoreItem(string id)
        {
            Item forumItem = null;

            forumItem = Sitecore.Context.Database.SelectSingleItem("fast:/sitecore/content/Home//*[@@templateid = '" + Constants.Forums.ForumTemplateID + "' and @ForumID = '" + id + "']");

            return forumItem;
        }
    }
}
