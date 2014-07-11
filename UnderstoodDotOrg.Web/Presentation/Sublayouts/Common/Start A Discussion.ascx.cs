using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Start_A_Discussion : BaseSublayout //System.Web.UI.UserControl
    {
        public const string validation_group = "newDiscussion";
        public string confirmationMessage = DictionaryConstants.ForumValidationConfirmation;

        public string HiddenText
        {
            get { return hdSelectedText.Value; }
            set { hdSelectedText.Value = value; }
        }
        protected override void OnInit(EventArgs e)
        {
            litGotAQuestionLabel.Text = DictionaryConstants.GotAQuestionLabel;
            litWantToTalkLabel.Text = DictionaryConstants.WantToTalkLabel;
            litStartADiscussionLabel.Text = DictionaryConstants.StartDiscussion;
            base.OnInit(e);
        }

        public string InitialDropDownText { get { return DictionaryConstants.InitialDropDownText; } }
        public string InitialTextBoxText { get { return DictionaryConstants.InitialTextBoxText; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            rqdDropDownFName.Enabled = String.IsNullOrEmpty(txtFName.Text);
            txtFName.Text = HiddenText;
            if (!IsPostBack)
            {
                ddlForums.Items.Add(new ListItem() { Value = "0", Text = InitialDropDownText });
                txtFName.Attributes.Add("placeholder", InitialTextBoxText);
                ddlForums.ValidationGroup = validation_group;
                txtFName.ValidationGroup = validation_group;
                btnSubmit.ValidationGroup = validation_group;
                rqdDropDownFName.ValidationGroup = validation_group;
                rqdDiscussion.ValidationGroup = validation_group;
              
                rqdSubject.ValidationGroup = validation_group;


                //Are we on a forum or Group??
                Item currItem = Sitecore.Context.Item;

                

                if (currItem.TemplateID.ToString().Equals(GroupItem.TemplateId))
                {
                    GroupItem grpItem = new GroupItem(currItem);
                    Session["_item"] = grpItem;
                    GroupCardModel grpModel = Groups.GroupCardModelFactory(grpItem);

                    if (grpModel != null)
                    {
                       

                        ddlForums.DataSource = grpModel.Forums;
                        ddlForums.DataBind();
                        //rbddlFname.Checked = true;
                        //rbddlFname.Visible = false;
                        //rbtxtFname.Checked = false;
                        //rbtxtFname.Disabled = true;
                        //rbtxtFname.Visible = false;
                       //txtFName.Visible = false;
                    }
                }
                else
                {
                   

                    if (currItem.TemplateID.ToString().Equals(ForumItem.TemplateId))
                    { 
                        ForumItem frmItem = new ForumItem(currItem);
                        Session["_item"] = frmItem;
                        //Disable forum selection and select 
                        ddlForums.Enabled = false;
                        ddlForums.Visible = false;
                        //rbddlFname.Disabled = true;
                        //rbddlFname.Visible = false;
                        //rqdDropDownFName.Enabled = false;
                        //rbtxtFname.Checked = true;
                        //rbtxtFname.Disabled = true;
                        //rbtxtFname.Visible = false;
                        txtFName.Visible = true;
                        txtFName.Text = frmItem.DisplayName;
                        txtFName.Enabled = false;
                    }
                }

               
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
                                                     Database.GetDatabase("web"),
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Client side validation passed
            if (CurrentMember != null && !String.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                //Grab information from fields
                string subject = txtSubject.Text;
                string body = txtBody.Text;
                string frmItemID = String.Empty;
                try
                {
                    
                    GroupItem grpItem = Session["_item"] as GroupItem;
                    ForumItem frmItem = Session["_item"] as ForumItem;
                    if (grpItem != null)
                    {
                        

                        ///Go through selection process
                        if (!ddlForums.SelectedValue.Equals("0")) //If forum was selected
                            frmItemID = ddlForums.SelectedIndex > -1 ? ddlForums.SelectedValue : String.Empty;
                        else if (!String.IsNullOrEmpty(txtFName.Text)) //If a name was input
                        {
                            frmItemID = new ForumItem( Forum.ConvertForumNametoSitecoreItem(txtFName.Text)).ForumID;
                            //Create forum and return ForumID
                        //    ForumModel frmModel = TelligentService.CreateForum(CurrentMember.ScreenName, grpItem.GroupID.Text, txtFName.Text);
                        //    if (frmModel != null)
                        //    {
                        //        Item frmItemLocal = Forum.CreateSitecoreForum(frmModel, grpItem, Sitecore.Context.Language);
                        //        if (frmItemLocal != null)
                        //        {
                        //            //Success
                        //            frmItemID = frmModel.ForumID;
                        //            //Publish sitecore item
                        //            PublishItem(frmItemLocal);
                        //        }
                        //        else
                        //        {
                        //            //Delete Telligent Forum
                        //            TelligentService.DeleteForum(frmModel.ForumID);
                        //            var msg = "Error creating forum item in sitecore";
                        //            Sitecore.Diagnostics.Error.LogError(msg);
                        //            error_msg.Text = msg;
                        //            error_msg.Visible = true;
                        //            ShowClientSideForm();
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        var msg = "Error creating forum item in Telligent.";
                        //        Sitecore.Diagnostics.Error.LogError(msg);
                        //        error_msg.Text = msg;
                        //        error_msg.Visible = true;
                        //        ShowClientSideForm();
                        //        return;
                        //    }
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
                       
                    }
                    if(frmItem !=null)
                    {

                        frmItemID = frmItem.ForumID.Text;

                       
                    }

                    Item threadItem = null;
                    if (!String.IsNullOrEmpty(frmItemID))
                    {


                        try
                        {
                            //Create item in Telligent
                            ThreadModel thModel = TelligentService.CreateForumThread(CurrentMember.ScreenName, frmItemID, subject, body);
                            if (thModel != null)
                            {
                                //Create item in sitecore with returned forumID and threadID
                                threadItem = Discussion.CreateSitecoreForumThread(thModel, frmItemID, Sitecore.Context.Language);
                                if (threadItem != null)
                                {
                                    error_msg.Visible = false;
                                   
                                    //Redirect to discussion
                                    //Publish thread item
                                    PublishItem(threadItem);
                                    //Sitecore.Web.WebUtil.Redirect(Sitecore.Links.LinkManager.GetItemUrl(threadItem));
                                  ///  clientsideScript("alert('" +String.Format( DictionaryConstants.ForumCreateConfirmation,subject)+"');");
                                    Page.Response.Redirect(Page.Request.Url.ToString(), false);
                                }
                                else
                                {
                                    //Delete from Telligent
                                    TelligentService.DeleteForumThread(frmItemID, thModel.ThreadID);
                                    error_msg.Text = "Failed to create discussion.";
                                    error_msg.Visible = true;
                                    ShowClientSideForm();
                                }


                            }
                            else
                            {
                                //The assumption is that if the Thread is null, then there was an error in telligent API call and nothing was created
                                error_msg.Text = "Failed to create discussion.";
                                error_msg.Visible = true;
                                ShowClientSideForm();
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
        

        }

        private void ShowClientSideForm()
        {
            clientsideScript("jQuery('.modal_discussion').dialog('open')");
        }

        private void clientsideScript(string jsText)
        {
            StringBuilder cstext1 = new StringBuilder();
            cstext1.Append("<script type='text/javascript'>jQuery(document).ready(function() {");
            cstext1.Append(jsText);
            cstext1.Append(@"});</script>");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowDiscussionEntry()", cstext1.ToString());
        }
    }
}