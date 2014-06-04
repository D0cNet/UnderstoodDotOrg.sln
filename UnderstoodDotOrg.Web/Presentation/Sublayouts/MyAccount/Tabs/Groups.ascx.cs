using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Framework.UI.Discussions;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs
{
    public partial class Groups : BaseSublayout<AccountGroupsPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurrentMember.ScreenName == null)
                {
                    pnlNoProfile.Visible = true;
                }
                else
                {
                    List<GroupModel> groupsList = CommunityHelper.GetUserGroups(CurrentMember.ScreenName);
                    ddlGroups.DataSource = groupsList;
                    ddlGroups.DataValueField = "Url";
                    ddlGroups.DataTextField = "Title";
                    ddlGroups.DataBind();
                    if (ddlGroups.Items.Count != 0)
                    {
                        pnlGroups.Visible = true;
                        divStartADiscussion.Visible = true;
                        hypStartADiscussion.NavigateUrl = ddlGroups.SelectedItem.Value + "/MyDiscussion%20Board";
                        var commentsList = CommunityHelper.ReadComments();
                        var commentsByGroup = commentsList.Where(x => x.ParentTitle == ddlGroups.SelectedItem.Text);
                        if (commentsList != null)
                        {
                            rptComments.DataSource = commentsByGroup;
                            rptComments.DataBind();
                        }
                    }
                    else
                    {
                        pnlNoGroups.Visible = true;
                    }
                }
            }
        }

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as Comment;
            HyperLink hypCommentLink = (HyperLink)e.Item.FindControl("hypCommentLink");
            hypCommentLink.NavigateUrl = "/";
            hypCommentLink.Text = Regex.Replace(Regex.Replace(item.Body, @"<[^>]+>|&nbsp;", "").Trim(), @"\s{2,}", " ");

            Literal litCommentTime = (Literal)e.Item.FindControl("litCommentTime");
            litCommentTime.Text = item.CommentDate.ToString();

            Literal litRepliesCount = (Literal)e.Item.FindControl("litRepliesCount");
            litRepliesCount.Text = item.ReplyCount;

            HyperLink hypCommentAuthor = (HyperLink)e.Item.FindControl("hypCommentAuthor");
            hypCommentAuthor.NavigateUrl = "/";
            hypCommentAuthor.Text = item.AuthorDisplayName;
        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            var commentsList = CommunityHelper.ReadComments();

            if (commentsList != null)
            {
                rptComments.DataSource = commentsList.Where(x => x.ParentTitle == ddlGroups.SelectedItem.Text);
                rptComments.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var frmItem = Session["forumItem"] as ForumItem;
            Item threadItem = null;
            if (frmItem != null)
            {
                //Grab information from fields
                string subject = txtSubject.Text;
                string body = txtBody.Text;
                string frmId = frmItem.ForumID.Text;

                try
                {
                    //Create item in Telligent
                    ThreadModel thModel = TelligentService.CreateForumThread(frmId, subject, body);
                    if (thModel != null)
                    {
                        //Create item in sitecore with returned forumID and threadID
                        threadItem = Discussion.CreateSitecoreForumThread(thModel, frmItem, Sitecore.Context.Language);
                        if (threadItem!=null)
                        {
                            Response.Redirect("/Community and Events/Groups/" + ddlGroups.SelectedItem.Value);
                        }
                        else
                        {
                            //error handling
                        }
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError(ex.Message);
                }
            }
        }

        //private bool CreateSitecoreForumThread(ThreadModel thModel, ForumItem frmItem, Language lang)
        //{
        //    bool errorState = false;
        //    try
        //    {
        //        if (thModel != null && frmItem != null && lang != null)
        //        {
        //            //Again we need to handle security
        //            //In this example we just disable it
        //            using (new SecurityDisabler())
        //            {
        //                //First get the parent item from the master database
        //                Database masterDb = global:: Sitecore.Configuration.Factory.GetDatabase("master");
        //                Item parentItem = masterDb.Items[frmItem.InnerItem.Paths.Path, lang];


        //                //Now we need to get the template from which the item is created (Forum Thread Template)
        //                TemplateItem template = masterDb.GetTemplate(ThreadModel.TemplateID);

        //                //StringBuilder sb = new StringBuilder(ItemName.Trim());

        //                // string newName = ItemName.Replace('.', '_');//.Substring(0, ItemName.LastIndexOf("."));
        //                // if(newName.Contains("."))
        //                //     newName=newName.Substring(newName.IndexOf(".") + 1);

        //                Item newItem = masterDb.GetItem(parentItem.Paths.Path + "/" + thModel.Subject, lang);
        //                if (newItem == null)
        //                {
        //                    //Now we can add the new item as a child to the parent
        //                    newItem = parentItem.Add(thModel.Subject, template);
        //                }


        //                //We can now manipulate the fields and publish as in the previous example
        //                //Item item = masterDb.GetItem(newItem);
        //                //Begin editing
        //                newItem.Editing.BeginEdit();
        //                try
        //                {
        //                    //perform the editing
        //                    newItem.Fields["ForumID"].Value = thModel.ForumID;
        //                    newItem.Fields["ThreadID"].Value = thModel.ThreadID;
        //                    newItem.Fields["Body"].Value = thModel.Body;
        //                    newItem.Fields["Subject"].Value = thModel.Subject;
        //                    errorState = true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    errorState = false;
        //                    throw ex;
        //                }
        //                finally
        //                {
        //                    //Close the editing state
        //                    newItem.Editing.EndEdit();
        //                }



        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Error with :" + ItemName + " (" + lang.Name + ")\n Details:\n" + ex.Message));
        //        Sitecore.Diagnostics.Error.LogError("Error with :" + thModel.Subject + " (" + lang.Name + ")\n Details:\n" + ex.Message);
        //        errorState = false;
        //    }

        //    return errorState;
        //}
    }
}