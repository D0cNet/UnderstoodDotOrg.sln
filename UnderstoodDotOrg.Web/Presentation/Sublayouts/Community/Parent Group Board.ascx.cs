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
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parent_Group_Board : BaseSublayout//System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Item currItem = Sitecore.Context.Item;
                if (currItem != null)
                {
                    hrfBack.HRef = LinkManager.GetItemUrl(currItem.Parent);
                    litBack.Text = currItem.Parent.Name;
                    ForumItem frmItem = new ForumItem(currItem);
                    Session["forumItem"] = frmItem;
                    if (frmItem != null)
                    {
                        ForumModel frmModel = Forum.ForumModelFactory(frmItem);

                        litForumName.Text = frmModel.Name;
                        if (frmModel != null)
                        {
                            rptThread.DataSource = frmModel.Threads;
                            rptThread.DataBind();
                        }
                    }
                }
            }
            
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    if (Page.IsValid)
        //    {
        //        if (IsUserLoggedIn)
        //        {
        //            if (!String.IsNullOrEmpty(CurrentMember.ScreenName))
        //            {
        //                var frmItem = Session["forumItem"] as ForumItem;
        //                Item threadItem = null;
        //                if (frmItem != null)
        //                {
        //                    //Grab information from fields
        //                    string subject = txtSubject.Text;
        //                    string body = txtBody.Text;
        //                    string frmId = frmItem.ForumID.Text;

        //                    try
        //                    {
        //                        //Create item in Telligent
        //                        ThreadModel thModel = TelligentService.CreateForumThread(CurrentMember.ScreenName,frmId, subject, body);
        //                        if (thModel != null)
        //                        {
        //                            //Create item in sitecore with returned forumID and threadID
        //                            threadItem = Discussion.CreateSitecoreForumThread(thModel, frmItem, Sitecore.Context.Language);
        //                            if (threadItem != null)
        //                            {
        //                                error_msg.Visible = false;
        //                                ForumModel frmModel = new ForumModel(frmItem);


        //                                if (frmModel != null)
        //                                {
        //                                    rptThread.DataSource = frmModel.Threads;
        //                                    rptThread.DataBind();
        //                                    txtSubject.Text = String.Empty;
        //                                    txtBody.Text = String.Empty;
        //                                }

        //                            }
        //                            else
        //                            {
        //                                error_msg.Text = "Failed to create discussion.";
        //                                error_msg.Visible = true;
        //                            }


        //                        }


        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Sitecore.Diagnostics.Error.LogError(ex.Message);
        //                    }
        //                }
        //            }
        //            else
        //                modal_discussion.Visible = true;

        //        }
        //    }
        //}

        

        protected void rptThread_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                if (e.Item.DataItem is ThreadModel)
                {
                    Item thread = null;
                    HiddenField hdSub = (HiddenField)e.Item.FindControl("hdSubject");
                    if(hdSub !=null)
                    {

                        string subject = hdSub.Value;
                         thread = Sitecore.Context.Database.SelectSingleItem("fast:/sitecore/content/Home//*[@Subject = '"+ subject +"']");
                       // ID = thread.ID.ToString();
                    }
                    HtmlAnchor hrefDiscussions = (HtmlAnchor)e.Item.FindControl("hrefDiscussion");
                    if (hrefDiscussions != null)
                    {
                        if (thread != null)
                        {
                            hrefDiscussions.HRef = LinkManager.GetItemUrl(thread) ;
                        }
                    }

                    HtmlAnchor hrefprofile = (HtmlAnchor)e.Item.FindControl("hrefProfile");
                    if (hrefprofile != null)
                    {
                        if (thread != null)
                        {

                            hrefprofile.HRef = MembershipHelper.GetPublicProfileUrl(((ThreadModel)e.Item.DataItem).StartedBy);
                        }
                    }
                    HtmlAnchor hrefprofile2 = (HtmlAnchor)e.Item.FindControl("hrefProfile2");
                    if (hrefprofile != null)
                    {
                        if (thread != null)
                        {

                            hrefprofile2.HRef = MembershipHelper.GetPublicProfileUrl(((ThreadModel)e.Item.DataItem).LastPostUser);
                        }
                    }
                    HtmlAnchor hrefprofile3 = (HtmlAnchor)e.Item.FindControl("hrefProfile3");
                    if (hrefprofile != null)
                    {
                        if (thread != null)
                        {

                            hrefprofile3.HRef = MembershipHelper.GetPublicProfileUrl(((ThreadModel)e.Item.DataItem).LastPostUser);
                        }
                    }
                }
            }
        }
    }
}