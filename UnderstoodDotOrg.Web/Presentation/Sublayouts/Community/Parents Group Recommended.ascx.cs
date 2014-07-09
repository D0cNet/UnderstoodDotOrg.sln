using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Services.MemberServices;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parents_Group_Recommended : BaseSublayout
    {
        GroupSummaryList rptGroupCards;
        protected override void OnInit(EventArgs e)
        {
            Item parentItem = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(Constants.Pages.ParentsGroups));
            string itemHref = Sitecore.Links.LinkManager.GetItemUrl(parentItem);
            ref_ParentGroup.HRef = itemHref;
            litBackLink.Text = DictionaryConstants.GroupRecommendedBackLink;//back to parents page
            litRecommendHeader.Text = DictionaryConstants.RecommendedHeader;
            litGroupPrivacy.Text = DictionaryConstants.GroupPrivacyStatement;
            if (CurrentMember != null)
            {
                litViewProfileLink1.Text = String.Format(DictionaryConstants.ViewProfileLink1,
                    CurrentMember != null ?
                    CurrentMember.GetMemberPublicProfile() :
                    UnderstoodDotOrg.Common.Helpers.MembershipHelper.SignUpLink()
                    );
            }
            
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
            rptGroupCards = (GroupSummaryList)Page.LoadControl("~/Presentation/Sublayouts/Common/GroupSummaryList.ascx");
            rptGroupCards.ID = "rptGroupCards";
            groupList.Controls.Add(rptGroupCards);
            Item currItem = Sitecore.Context.Item;
           
            //Get all groups under parent folder
            List<GroupItem> groups =currItem.Parent.Children.Where(x => x.TemplateID.ToString().Equals(Constants.Groups.GroupTemplateID)).Select(x => new GroupItem(x)).ToList<GroupItem>();

            //Convert sitecore group items to GroupCardModels
            var grpItems = groups.Select(x => Groups.GroupCardModelFactory(x)).ToList<GroupCardModel>();
            Session["groupItems"] = grpItems;
            rptGroupCards.DataSource = FindRecommendedGroups(); ///TODO: To decide on logic for finding recommendations
            rptGroupCards.DataBind();
        }

        private List<GroupCardModel> FindRecommendedGroups()
        {
           
            List<GroupCardModel> grpItems = new List<GroupCardModel>();

            if (CurrentMember != null)
            {
                
                String [] issues = new List<string>(CurrentMember.Children.Select(x => x.Issues.Select(k => k.Key.ToString("B").ToUpper())).SelectMany(x=>x)).ToArray();
                String[] grades = new List<string>(CurrentMember.Children.Select(x => x.Grades.Select(g => g.Key.ToString("B").ToUpper())).SelectMany(x => x)).ToArray() ;
                String[] topics = CurrentMember.Interests.Select(x => x.Key.ToString("B").ToUpper()).ToArray();
                String[] states = new string[] { CurrentMember.zipCodeToState() };
                String[] partners = new string[0]; //Partners not applicable to Member profile
                return Groups.FindGroups(issues,topics,grades,states,partners).OrderByDescending(x=> x.NumOfMembers).ToList();
                
            }
            return grpItems;
           
        }

        protected void ShowMoreLink_ServerClick(object sender, EventArgs e)
        {

        }
    }
}