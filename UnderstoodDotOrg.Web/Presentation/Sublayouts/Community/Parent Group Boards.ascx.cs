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
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parent_Group_Boards : BaseSublayout//System.Web.UI.UserControl
    {
      
        protected override void OnInit(EventArgs e)
        {
            litjumpToText.Text = DictionaryConstants.JumpToText;
            
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
                  
                    if (grpItem != null)
                    {
                        Session["groupitem"] = grpItem;
                        GroupCardModel grpModel = Groups.GroupCardModelFactory(grpItem);
                       
                        if (grpModel != null)
                        {
                            rptForums.DataSource = grpModel.Forums;
                            rptForums.DataBind();

                            lvJumpto.DataSource = currItem.Children.Select(x => Forum.ForumModelFactory(new ForumItem(x))).ToList<ForumModel>();  //grpModel.Forums;
                            lvJumpto.DataBind();

                     
                        }
                    }
                   
                }

                
              
            }

           
        }

        protected void rptForums_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                if (e.Item.DataItem is ForumModel)
                {

                    Literal litstartDiscussion = (Literal)e.Item.FindControl("litstartDiscussion");
                    if (litstartDiscussion != null)
                    {
                        litstartDiscussion.Text = DictionaryConstants.StartDiscussion;
                    }
                    
                    Literal litDiscussionLabel = (Literal)e.Item.FindControl("litDiscussionLabel");
                    if (litDiscussionLabel != null)
                    {
                        litDiscussionLabel.Text = DictionaryConstants.DiscussionLabel;
                    }
                   
                     Literal litRepliesLabel = (Literal)e.Item.FindControl("litRepliesLabel");
                    if (litRepliesLabel != null)
                    {
                        litRepliesLabel.Text = DictionaryConstants.RepliesLabel;
                    }


                    Literal litLatestPostLabel = (Literal)e.Item.FindControl("litLatestPostLabel");
                    if (litLatestPostLabel != null)
                    {
                        litLatestPostLabel.Text = DictionaryConstants.LatestPostLabel;
                    }
                    Literal litViewAll = (Literal)e.Item.FindControl("litViewAll");
                    if (litViewAll != null)
                    {
                        litViewAll.Text = DictionaryConstants.ViewAllLabel;
                    }
                    ForumModel item = (ForumModel)e.Item.DataItem;
                    Repeater childModel_repeater = (Repeater)e.Item.FindControl("rptThreads");
                    if (childModel_repeater != null)
                    {
                        childModel_repeater.DataSource = ((ForumModel)e.Item.DataItem).Threads.Take(3).ToList<ThreadModel>();
                        childModel_repeater.DataBind();
                    }
                    HtmlAnchor hrefForumLink = (HtmlAnchor)e.Item.FindControl("hrefForumLink");
                    if (hrefForumLink != null)
                    {
                        if (!String.IsNullOrEmpty(item.ForumID))
                        {
                            hrefForumLink.HRef = Forum.ConvertForumIDtoSitecoreItem(item.ForumID).GetUrl(); //LinkManager.GetItemUrl(thread);
                        }
                    }
                }
            }
        }

        protected void rptThreads_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                if (e.Item.DataItem is ThreadModel)
                {
                    ThreadModel item = (ThreadModel)e.Item.DataItem ;
                    Item thread = null;
                    HiddenField hdFrmID = (HiddenField)e.Item.FindControl("forumId");
                    HiddenField hdThID = (HiddenField)e.Item.FindControl("threadId");
                    string forumId = String.Empty;
                    string threadId = String.Empty;
                    if (hdFrmID != null && hdThID !=null)
                    {

                         forumId = hdFrmID.Value;
                         threadId = hdThID.Value;
                        thread = Threads.ConvertThreadtoSitecoreItem(forumId, threadId); //Sitecore.Context.Database.SelectSingleItem("fast:/sitecore/content/Home//*[@Subject = '" + subject + "']");
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

                    HtmlAnchor hrefLastPostUser = (HtmlAnchor)e.Item.FindControl("hrefLastPostUser");
                    if (hrefLastPostUser != null)
                    {
                        if (thread != null)
                        {
                            hrefLastPostUser.HRef = MemberExtensions.GetMemberPublicProfile(item.LastPostUser);
                        }
                    }
                   
                }
            }
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
                        forum = Forum.ConvertForumIDtoSitecoreItem(frmModel.ForumID);
                        if(forum!=null)
                            forumHref.HRef = LinkManager.GetItemUrl(forum);
                    }
                }
            }
        }

       
    }
}