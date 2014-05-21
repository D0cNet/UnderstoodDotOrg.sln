using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Links;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parent_Group_Boards : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            
            if (Page.Request.QueryString["groupsearch"] != null)
            {
                pnlDefaultSection.Visible = false;
                pnlSearchSection.Visible = true;

            }
            else
            {
                Item currItem = Sitecore.Context.Item;
                GroupItem grpItem = new GroupItem(currItem);
                pnlDefaultSection.Visible = true;
                pnlSearchSection.Visible = false;
                if (grpItem != null)
                {
                    GroupCardModel grpModel = new GroupCardModel(grpItem);
                    if (grpModel != null)
                    {
                        rptForums.DataSource = grpModel.Forums;
                        rptForums.DataBind();

                        lvJumpto.DataSource = grpModel.Forums;
                        lvJumpto.DataBind();

                        ddlForums.DataSource = grpModel.Forums;
                        ddlForums.DataBind();
                    }
                }

              
            }

           
        }

        protected void rptForums_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater childModel_repeater = (Repeater)e.Item.FindControl("rptThreads");
            if (childModel_repeater != null)
            {
                childModel_repeater.DataSource = ((ForumModel)e.Item.DataItem).Threads;
                childModel_repeater.DataBind();
            }

        }

        protected void rptThreads_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                if (e.Item.DataItem is ThreadModel)
                {
                    Item thread = null;
                    HiddenField hdSub = (HiddenField)e.Item.FindControl("hdSubject");
                    if (hdSub != null)
                    {

                        string subject = hdSub.Value;
                        thread = Sitecore.Context.Database.SelectSingleItem("fast:/sitecore/content/Home//*[@Subject = '" + subject + "']");
                        // ID = thread.ID.ToString();
                    }
                    HtmlAnchor hrefDiscussions = (HtmlAnchor)e.Item.FindControl("hrefDiscussion");
                    if (hrefDiscussions != null)
                    {
                        if (thread != null)
                        {
                            hrefDiscussions.HRef = LinkManager.GetItemUrl(thread);
                        }
                    }
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
            //     string frmItemID =String.Empty;
            //     frmItemID = ddlForums.SelectedIndex > -1 ? ddlForums.SelectedValue : String.Empty;
            //    if (!String.IsNullOrEmpty(frmItemID))
            //    {
            //        //Grab information from fields
            //        string subject = txtSubject.Text;
            //        string body = txtBody.Text;
                   

            //        try
            //        {
            //            //Create item in Telligent
            //            ThreadModel thModel = TelligentService.CreateForumThread(frmItemID, subject, body);
            //            if (thModel != null)
            //            {
            //                //Create item in sitecore with returned forumID and threadID
            //                if (CreateSitecoreForumThread(thModel, frmItemID, Sitecore.Context.Language))
            //                {
            //                    error_msg.Visible = false;
            //                    ForumModel frmModel = new ForumModel(frmItem);


            //                    if (frmModel != null)
            //                    {
            //                        rptThread.DataSource = frmModel.Threads;
            //                        rptThread.DataBind();
            //                    }

            //                }
            //                else
            //                {
            //                    error_msg.Text = "Failed to create discussion.";
            //                    error_msg.Visible = true;
            //                }


            //            }


            //        }
            //        catch (Exception ex)
            //        {
            //            Sitecore.Diagnostics.Error.LogError(ex.Message);
            //        }
            //    }
            //}
            //else
            //    modal_discussion.Visible = true;

        }

        private bool CreateSitecoreForumThread(ThreadModel thModel, ForumItem frmItem, Language lang)
        {
            bool errorState = false;
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

                        Item newItem = masterDb.GetItem(parentItem.Paths.Path + "/" + thModel.Subject, lang);
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
                            errorState = true;
                        }
                        catch (Exception ex)
                        {
                            errorState = false;
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
                errorState = false;
            }

            return errorState;
        }

        protected void lvJumpto_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if(e.Item.DataItem !=null)
            {
                if (e.Item.DataItem is ForumModel)
                {
                     Item forum = null;
                    //HiddenField hdSub = (HiddenField)e.Item.FindControl("hdSubject");
                    //if(hdSub !=null)
                    //{

                    //    string subject = hdSub.Value;
                    //     thread = Sitecore.Context.Database.SelectSingleItem("fast:/sitecore/content/Home//*[@Subject = '"+ subject +"']");
                    //   // ID = thread.ID.ToString();
                    //}
                    HtmlAnchor forumHref = (HtmlAnchor)e.Item.FindControl("hrefForum");
                    if(forumHref !=null)
                    {
                        var forumtext = forumHref.InnerText;
                        forum =Sitecore.Context.Database.SelectSingleItem("fast:/sitecore/content/Home//*[@Name = '"+ forumtext +"']");
                        if(forum!=null)
                            forumHref.HRef = LinkManager.GetItemUrl(forum);
                    }
                }
            }
        }
    }
}