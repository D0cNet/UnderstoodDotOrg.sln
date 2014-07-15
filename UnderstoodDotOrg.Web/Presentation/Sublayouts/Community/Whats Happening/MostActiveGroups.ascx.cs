using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class Most_Active_Groups : BaseSublayout //System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            litMostActiveGroupsLabel.Text = DictionaryConstants.MostActiveGroupsLabel;
            litSeeAllGroups.Text = DictionaryConstants.SeeAllGroupsLabel;
            rptAllGroups.ItemDataBound += rptAllGroups_ItemDataBound;
            hrefAllGroups.NavigateUrl = Sitecore.Context.Database.GetItem(Constants.Pages.ParentsGroups).GetUrl();
            base.OnInit(e);
        }

        List<GroupCardModel> selectedGroups
        {
            get { return Session["_selectedGroups"] as List<GroupCardModel>; }
            set { Session["_selectedGroups"] = value; }
        }

        protected void rptAllGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //throw new NotImplementedException();
            if(e.Item !=null)
            {
                if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    GroupCardModel thisItem = ((GroupCardModel) e.Item.DataItem);
                       GroupJoinButton joinBtn = e.FindControlAs<GroupJoinButton>("BtnJoin");
                    if(joinBtn!=null)
                    {
                        if(e.Item.DataItem is GroupCardModel)
                        {
                            var id = thisItem.GroupID;
                            joinBtn.LoadState(id);
                        }
                    }
                    if (IsUserLoggedIn && !String.IsNullOrEmpty(CurrentMember.ScreenName))
                    {

                        HyperLink hrefImageLink = e.FindControlAs<HyperLink>("hrefImageLink");
                        if (hrefImageLink != null)
                        {
                            hrefImageLink.NavigateUrl = thisItem.GrpItem.GetUrl();
                        }

                        HyperLink hrefTitleLink = e.FindControlAs<HyperLink>("hrefTitleLink");
                        if (hrefImageLink != null)
                        {
                            hrefTitleLink.NavigateUrl = thisItem.GrpItem.GetUrl();
                        }
                    }
                    Image imgGroup = e.FindControlAs<Image>("imgGroup");
                    if(imgGroup!=null)
                    {
                        imgGroup.ImageUrl = thisItem.ModeratorAvatarUrl??"http://placehold.it/150x85";
                    }
                    Literal litSkipThis = e.FindControlAs<Literal>("litSkipThis");
                    if(litSkipThis!=null)
                    {
                        litSkipThis.Text = DictionaryConstants.SkipThisLabel; //Skip this
                    }
                    Literal litMembers = e.FindControlAs<Literal>("litMembers");
                    if(litMembers!=null)
                    {
                        litMembers.Text = thisItem.NumOfMembers + DictionaryConstants.MembersLabel;
                    }
                    Literal litDiscussions = e.FindControlAs<Literal>("litDiscussions");
                    if (litDiscussions != null)
                    {
                        litDiscussions.Text = thisItem.NumOfDiscussions + DictionaryConstants.PostsLabel;
                    }
                }
                
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
             * This user is SIGNED IN.
             Display all groups that match the child grade, child issue for any of their children or their parent interest in reverse chronological order based on most recent post.
             Users can identify recommendations they do not want. This link only appears underneath recommendations made by the system.
             Once a group or event is identified as not desired, it no longer appears in this list.
             If all recommendations are rejected, and no groups were joined, this module disappears.
             If all recommendations are rejected, and 1 or more groups were joined, display the groups this user is a active member of. Instead of a link to "join" link would say "view discussions".
             * 
             * Retrieve groups of logged in user
             if user is apart of a group/s
             * Module available only to authenticated users
             Display is limited only to groups for which the user is registered
             Each group listed displays the most recent discussion title as a clickable link
             Each discussion title is accompanied by a counter that lists the number of comments in each discussion
             Each discussion counter lists the username of the last user to comment
             A user can register with any number of groups without limit, only the two with the most recent activity appear here
             If user is a member of more than 3 groups, show 2 of the 3 in random selection here on page load
            
             else
             Retrieve all groups filtered
             Show the 6 most active groups by total # of posts in a gallery.
             Order the groups by most recent activity/post. *
             * */
          
            if (!IsPostBack)
            {
                List<GroupCardModel> grps = new List<GroupCardModel>();
                if (IsUserLoggedIn && !String.IsNullOrEmpty(CurrentMember.ScreenName))
                {
                    grps = TelligentService.GetUserGroups(CurrentMember.ScreenName);
                    if (grps.Count > 2)
                    {
                        this.Visible = false;
                        return;
                    }
                    else
                    {
                        this.Visible = true;
                        litMostActiveGroupsLabel.Text = DictionaryConstants.RecommendedGroupsLabel;
                        if (selectedGroups == null)
                        {


                            String[] issues = new List<string>(CurrentMember.Children.Select(x => x.Issues.Select(k => k.Key.ToString("B").ToUpper())).SelectMany(x => x)).ToArray();
                            String[] grades = new List<string>(CurrentMember.Children.Select(x => x.Grades.Select(g => g.Key.ToString("B").ToUpper())).SelectMany(x => x)).ToArray();
                            String[] topics = CurrentMember.Interests.Select(x => x.Key.ToString("B").ToUpper()).ToArray();
                            String[] states = new string[0];
                            String[] partners = new string[0];
                            grps = Groups.FindGroups(issues, topics, grades, states, partners);
                            selectedGroups = grps;
                        }
                        else
                        {
                            grps = selectedGroups;
                        }
                    }
                }
                else
                {




                    grps = Groups.FindGroups().OrderByDescending(g => g.LastActivityDate)
                                                             .Take(6)
                                                             .ToList<GroupCardModel>();



                }
                if (grps == null || grps.Count == 0)
                {
                    this.Visible = false;
                }
                else
                {
                    rptAllGroups.DataSource = grps;
                    rptAllGroups.DataBind();
                }
            }
        }
    }
}