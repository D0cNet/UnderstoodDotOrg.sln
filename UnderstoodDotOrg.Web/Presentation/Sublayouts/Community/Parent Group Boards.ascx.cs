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
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI.Discussions;
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
                if (!IsPostBack)
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
            if (Page.IsValid)
            {
                string frmItemID = String.Empty;
                frmItemID = ddlForums.SelectedIndex > -1 ? ddlForums.SelectedValue : String.Empty;
                Item threadItem = null;
                if (!String.IsNullOrEmpty(frmItemID))
                {
                    //Grab information from fields
                    string subject = txtSubject.Text;
                    string body = txtBody.Text;




                    try
                    {
                        //Create item in Telligent
                        ThreadModel thModel = TelligentService.CreateForumThread(frmItemID, subject, body);
                        if (thModel != null)
                        {
                            //Create item in sitecore with returned forumID and threadID
                            threadItem = Discussion.CreateSitecoreForumThread(thModel, frmItemID, Sitecore.Context.Language);
                            if (threadItem != null)
                            {
                                error_msg.Visible = false;
                                //ForumModel frmModel = new ForumModel(frmItem);

                                //Redirect to discussion
                                Sitecore.Web.WebUtil.Redirect(Sitecore.Links.LinkManager.GetItemUrl(threadItem));


                            }
                            else
                            {
                                error_msg.Text = "Failed to create discussion.";
                                error_msg.Visible = true;
                            }


                        }


                    }
                    catch (Exception ex)
                    {
                        Sitecore.Diagnostics.Error.LogError(ex.Message);
                    }
                }
                
            }
            else
                modal_discussion.Visible = true;

        }

        

       

        protected void lvJumpto_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if(e.Item.DataItem !=null)
            {
                if (e.Item.DataItem is ForumModel)
                {
                    ForumModel frmModel = e.Item.DataItem as ForumModel;
                     Item forum = null;
                   
                    HtmlAnchor forumHref = (HtmlAnchor)e.Item.FindControl("hrefForum");
                    if(forumHref !=null)
                    {
                        var forumtext = forumHref.InnerText;
                        //Sitecore.Context.Database.SelectSingleItem("fast:/sitecore/content/Home//*[@Name = '"+ forumtext +"']");
                        forum = Discussion.ConvertForumIDtoSitecoreItem(frmModel.ForumID);
                        if(forum!=null)
                            forumHref.HRef = LinkManager.GetItemUrl(forum);
                    }
                }
            }
        }
    }
}