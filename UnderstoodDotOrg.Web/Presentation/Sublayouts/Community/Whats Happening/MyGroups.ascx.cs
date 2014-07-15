using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class MyGroups : BaseSublayout//System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            litMyGroupsLabel.Text = DictionaryConstants.MyGroupsLabel;
            litSeeAllGroups.Text = DictionaryConstants.SeeAllGroupsLabel;
            rptMyGroups.ItemDataBound += rptMyGroups_ItemDataBound;
           base.OnInit(e);
        }

        protected void rptMyGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item != null)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    GroupCardModel thisItem = ((GroupCardModel)e.Item.DataItem);
                    ThreadModel recentThread= (thisItem.Forums
                                                    .Where(f=>f.Threads.Count >0 && f.Threads!=null)
                                                    .Select(x => x.Threads.OrderByDescending(t => t.LastPostDate)).FirstOrDefault()).FirstOrDefault();
                    GroupJoinButton joinBtn = e.FindControlAs<GroupJoinButton>("btnJoin");
                    if (joinBtn != null)
                    {
                        var id = thisItem.GroupID;
                        joinBtn.LoadState(id);
                    }

                    Literal litReplies = e.FindControlAs<Literal>("litRepliesLabel");
                    if (litReplies != null)
                    {
                        litReplies.Text = DictionaryConstants.RepliesLabel;


                    }
                    Literal litPostedByLabel = e.FindControlAs<Literal>("litPostedByLabel");
                    if (litPostedByLabel != null)
                    {
                        litPostedByLabel.Text = DictionaryConstants.PostedByLabel;


                    }

                    if (recentThread != null)
                    {
                        HyperLink hrefDiscussionLink = e.FindControlAs<HyperLink>("hrefDiscussionLink");
                        if (hrefDiscussionLink != null)
                        {
                            hrefDiscussionLink.NavigateUrl = Threads.ConvertThreadtoSitecoreItem(recentThread.ForumID, recentThread.ThreadID).GetUrl();

                        }
                        Literal litDiscussionExcerpt = e.FindControlAs<Literal>("litDiscussionExcerpt");
                        if (litDiscussionExcerpt != null)
                        {
                            litDiscussionExcerpt.Text = recentThread.Subject;


                        }
                        Literal litNumReplies = e.FindControlAs<Literal>("litNumReplies");
                        if (litNumReplies != null)
                        {
                            litNumReplies.Text = recentThread.ReplyCount;


                        }
                      
                        Literal litPostUserName = e.FindControlAs<Literal>("litPostUserName");
                        if (litPostUserName != null)
                        {
                            litPostUserName.Text = recentThread.LastPostUser;


                        }
                        HyperLink hrefPostUser = e.FindControlAs<HyperLink>("hrefPostUser");
                        if (hrefPostUser != null)
                        {
                            hrefPostUser.NavigateUrl = MembershipHelper.GetPublicProfileUrl(recentThread.LastPostUser);

                        }
                        Literal litPostTime = e.FindControlAs<Literal>("litPostTime");
                        if (litPostTime != null)
                        {
                            litPostTime.Text = recentThread.LastPostTime;


                        }

                    }
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                List<GroupCardModel> grps = new List<GroupCardModel>();
                if (IsUserLoggedIn && !String.IsNullOrEmpty(CurrentMember.ScreenName))
                {
                    //Check to see user groups
                    grps = TelligentService.GetUserGroups(CurrentMember.ScreenName);
                    if (grps != null && grps.Count > 2)
                    {
                        this.Visible = true;
                    }
                    else
                    {
                        this.Visible = false;
                        return;
                    }
                        

                   
                    


                }
                else
                {
                    this.Visible = false;
                    return;
                }
                var rnd = new Random();
               // var result = source.OrderBy(item => rnd.Next());
                rptMyGroups.DataSource = grps.OrderBy(c=> rnd.Next()).ToList<GroupCardModel>();
                rptMyGroups.DataBind();
            }
            
           
        }
    }
}