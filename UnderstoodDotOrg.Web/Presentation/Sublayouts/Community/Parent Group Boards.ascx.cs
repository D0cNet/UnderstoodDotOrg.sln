using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Links;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Framework.UI.Discussions;
using UnderstoodDotOrg.Framework.UI.Forums;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parent_Group_Boards : BaseSublayout//System.Web.UI.UserControl
    {
        public const string validation_group = "newDiscussion";
        public string confirmationMessage = "Items created by end user cannot be modified until published. Are you sure you want to create a thread?";
        protected override void OnInit(EventArgs e)
        {
           
            base.OnInit(e);
        }

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
                    ddlForums.ValidationGroup = validation_group;
                    txtFName.ValidationGroup = validation_group;
                    btnSubmit.ValidationGroup = validation_group;
                    rqdDropDownFName.ValidationGroup = validation_group;
                    rqdDiscussion.ValidationGroup = validation_group;
                    rqdFname.ValidationGroup = validation_group;
                    rqdSubject.ValidationGroup = validation_group;
                   // modal_discussion.Visible = false;
                    if (grpItem != null)
                    {
                        Session["groupitem"] = grpItem;
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
            //Client side validation passed
            if (CurrentMember!=null && !String.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                try
                {
                    string frmItemID = String.Empty;
                    GroupItem grpitem = Session["groupitem"] as GroupItem;

                    if (grpitem != null)
                    {
                        //Grab information from fields
                        string subject = txtSubject.Text;
                        string body = txtBody.Text;

                        ///Go through selection process
                        if (!String.IsNullOrWhiteSpace(ddlForums.SelectedValue)) //If forum was selected
                            frmItemID = ddlForums.SelectedIndex > -1 ? ddlForums.SelectedValue : String.Empty;
                        else if (!String.IsNullOrEmpty(txtFName.Text)) //If a name was input
                        {

                            //Create forum and return ForumID
                            ForumModel frmModel = TelligentService.CreateForum(grpitem.GroupID, txtFName.Text);
                            if (frmModel != null)
                            {
                                Item frmItem = Forum.CreateSitecoreForum(frmModel, grpitem, Sitecore.Context.Language);
                                if (frmItem != null)
                                {
                                    //Success
                                    frmItemID = frmModel.ForumID;
                                }
                                else
                                {
                                    var msg = "Error creating forum item in btnSubmit_Click.";
                                    Sitecore.Diagnostics.Error.LogError(msg);
                                    error_msg.Text = msg;
                                    error_msg.Visible = true;
                                    ShowClientSideForm();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            var msg = "Error validation failed selecting forum.";
                            Sitecore.Diagnostics.Error.LogError(msg);
                            error_msg.Text = msg;
                            error_msg.Visible = true;
                            ShowClientSideForm();
                            return;
                        }
                        Item threadItem = null;
                        if (!String.IsNullOrEmpty(frmItemID))
                        {


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
                                        //Sitecore.Web.WebUtil.Redirect(Sitecore.Links.LinkManager.GetItemUrl(threadItem));
                                        clientsideScript("alert('Forum dicsussion created. Please publish in Sitecore to view");

                                    }
                                    else
                                    {
                                        error_msg.Text = "Failed to create discussion.";
                                        error_msg.Visible = true;
                                        ShowClientSideForm();
                                    }


                                }


                            }
                            catch (Exception ex)
                            {
                                Sitecore.Diagnostics.Error.LogError(ex.Message);
                                error_msg.Text = "Failed to create discussion.";
                                error_msg.Visible = true;
                                ShowClientSideForm();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error creating forum item in btnSubmit_Click.\nError:\n " + ex.Message);
                    error_msg.Text = "Critical Error creating discussion.";
                    error_msg.Visible = true;
                    ShowClientSideForm();
                }
            }
            else
            {
                error_msg.Text = "You are not logged on.";
                error_msg.Visible = true;
                ShowClientSideForm();
            }
            //}
            //else
            //    modal_discussion.Visible = true;

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

        private void ShowClientSideForm()
        {
           clientsideScript("jQuery('.modal_discussion').toggle();"); 
        }

        private void clientsideScript(string jsText)
        {
            StringBuilder cstext1 = new StringBuilder();
            cstext1.Append("<script type=text/javascript>"+jsText+"</");
            cstext1.Append("script>");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowDiscussionEntry()", cstext1.ToString());
        }
    }
}