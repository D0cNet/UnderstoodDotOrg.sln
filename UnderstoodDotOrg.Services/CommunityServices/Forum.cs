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
    public static class Forum
    {

        public static Item CreateSitecoreForum(ForumModel frmModel, string groupItemID, Language lang)
        {
            Item grpItem = Groups.ConvertGroupIDtoSitecoreItem(groupItemID);
            return CreateSitecoreForum(frmModel, grpItem, lang);


        }
        public static Item CreateSitecoreForum(ForumModel frmModel, GroupItem grpItem, Language lang)
        {

            Item newItem = null;
            try
            {
                if (frmModel != null && grpItem != null && lang != null)
                {
                    //Again we need to handle security
                    //In this example we just disable it
                    using (new SecurityDisabler())
                    {
                        //First get the parent item from the master database
                        Database masterDb = global:: Sitecore.Configuration.Factory.GetDatabase("master");
                        Item parentItem = masterDb.Items[grpItem.InnerItem.Paths.Path, lang];


                        //Now we need to get the template from which the item is created (Forum Thread Template)
                        TemplateItem template = masterDb.GetTemplate(ForumModel.TemplateID);

                        //StringBuilder sb = new StringBuilder(ItemName.Trim());

                        // string newName = ItemName.Replace('.', '_');//.Substring(0, ItemName.LastIndexOf("."));
                        // if(newName.Contains("."))
                        //     newName=newName.Substring(newName.IndexOf(".") + 1);

                        newItem = masterDb.GetItem(parentItem.Paths.Path + "/" + frmModel.Name, lang);
                        if (newItem == null)
                        {
                            //Now we can add the new item as a child to the parent
                            newItem = parentItem.Add(frmModel.Name, template);
                        }


                        //We can now manipulate the fields and publish as in the previous example
                        //Item item = masterDb.GetItem(newItem);
                        //Begin editing
                        newItem.Editing.BeginEdit();
                        try
                        {
                            //perform the editing
                            newItem.Fields["GroupID"].Value = frmModel.GroupID;
                            newItem.Fields["ForumID"].Value = frmModel.ForumID;
                            
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
                Sitecore.Diagnostics.Error.LogError("Error with :" + frmModel.Name + " (" + lang.Name + ")\n Details:\n" + ex.Message);
                newItem = null;
            }

            return newItem;
        }
        public static Item ConvertForumIDtoSitecoreItem(string id)
        {
            Item forumItem = null;
            Database masterDb = global:: Sitecore.Configuration.Factory.GetDatabase("master");
            forumItem = masterDb.SelectSingleItem("fast:/sitecore/content/Home//*[@@templateid = '" + Constants.Forums.ForumTemplateID + "' and @ForumID = '" + id + "']");

            return forumItem;
        }
        public static Item ConvertForumNametoSitecoreItem(string name)
        {
            Item forumItem = null;
            Database masterDb = global:: Sitecore.Configuration.Factory.GetDatabase("master");
            forumItem = masterDb.SelectSingleItem("fast:/sitecore/content/Home//*[@@templateid = '" + Constants.Forums.ForumTemplateID + "' and @@name = '" + name + "']");

            return forumItem;
        }
        public static ForumModel ForumModelFactory(ForumItem item)
        {
            ForumModel frm = new ForumModel(item, TelligentService.TelligentService.ReadThreadList);
            return frm;
        }

    }
}
